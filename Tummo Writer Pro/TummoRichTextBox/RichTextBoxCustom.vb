'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/15/2016
' * Time: 8:57 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace WordEditor
    Public Delegate Sub ZoomChangedEventHandler(sender As Object, e As ZoomChangedEventArgs)

    Public Class RichTextBoxCustom
        Inherits RichTextBox
        ''' <summary>
        ''' Occurs when the zoom factor changes.
        ''' </summary>
        Public Event ZoomChanged As ZoomChangedEventHandler
        Private Const EM_SETZOOM As Integer = 1024 + 225
        Private Const WM_MOUSEWHEEL As Integer = 522
        Private _ZoomFactor As Single = 1


        Protected Overridable Sub OnZoomChanged(e As ZoomChangedEventArgs)
            ' If ZoomChanged IsNot Nothing Then
            If Me._ZoomFactor <> Me.ZoomFactor Then
                    Me._ZoomFactor = e.ZoomFactor
                    RaiseEvent ZoomChanged(Me, e)
                End If
            'End If
        End Sub

        Protected Overrides Sub WndProc(ByRef m As Message)
            MyBase.WndProc(m)
            Select Case m.Msg
                Case EM_SETZOOM, WM_MOUSEWHEEL
                    OnZoomChanged(New ZoomChangedEventArgs(Me.ZoomFactor))
                    Exit Select
            End Select
        End Sub
    End Class

    Public Class ZoomChangedEventArgs
        Inherits EventArgs
        Private ReadOnly m_zoomFactor As Single

        Public Sub New(Zoom_Factor As Single)
            m_zoomFactor = Zoom_Factor
        End Sub

        ' Gets the current zoom factor.
        Public ReadOnly Property ZoomFactor() As Single
            Get
                Return m_zoomFactor
            End Get
        End Property
    End Class

End Namespace
