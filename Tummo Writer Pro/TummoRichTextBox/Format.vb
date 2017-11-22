'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/15/2016
' * Time: 8:50 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


' Freeware. Written by Matt Fomich.
' matt.fomich@gmail.com

Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace WordEditor
    ''' <summary>
    ''' Applies character and paragraph formatting to text in a RichTextBox.
    ''' </summary>
    Public Class Format
        Private hWnd As IntPtr
        Private Const WM_USER As Integer = 1024
        Private Const EM_GETCHARFORMAT As Integer = WM_USER + 58
        Private Const EM_SETCHARFORMAT As Integer = WM_USER + 68
        Private Const CFM_FACE As UInteger = 536870912
        Private Const CFM_SIZE As UInteger = 2147483648UI
        Private Const TWIPS_PER_POINT As Integer = 20
        Private Const SCF_DEFAULT As Integer = 0
        Private Const SCF_SELECTION As Integer = 1
        Public Const PFM_SPACEAFTER As Integer = 128
        Public Const PFM_LINESPACING As Integer = 256
        Private Const EM_GETPARAFORMAT As Integer = 1085
        Public Const EM_SETPARAFORMAT As Integer = 1095
        Public Const PFM_RIGHTINDENT As Integer = 2
        Private Const BL_SINGLE_LINE_SPACING As Byte = 0
        Private Const BL_ONE_AND_HALF_LINE_SPACING As Byte = 1
        Private Const BL_DOUBLE_LINE_SPACING As Byte = 2

        <DllImport("user32.dll", EntryPoint:="SendMessage", CharSet:=CharSet.Auto)>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Int32, wParam As Int32, ByRef lParam As CHARFORMAT) As Int32
        End Function

        <DllImport("user32.dll", EntryPoint:="SendMessage", CharSet:=CharSet.Auto)>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Int32, wParam As Int32, ByRef lParam As PARAFORMAT2) As Int32
        End Function

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
        Private Structure CHARFORMAT
            Public cbSize As Integer
            Public dwMask As UInt32
            Public dwEffects As UInt32
            Public yHeight As Int32
            Public yOffset As Int32
            Public crTextColor As Int32
            Public bCharSet As Byte
            Public bPitchAndFamily As Byte
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
            Public szFaceName As Char()
        End Structure

        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto)>
        Public Structure PARAFORMAT2
            ' PARAFORMAT & PARAFORMAT2
            Public cbSize As Integer
            Public dwMask As UInteger
            Public wNumbering As Int16
            Public wReserved As Int16
            Public dxStartIndent As Integer
            Public dxRightIndent As Integer
            Public dxOffset As Integer
            Public wAlignment As Int16
            Public cTabCount As Int16
            <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)>
            Public rgxTabs As Integer()
            ' PARAFORMAT2 only below
            Public dySpaceBefore As Integer
            Public dySpaceAfter As Integer
            Public dyLineSpacing As Integer
            Public sStyle As Int16
            Public bLineSpacingRule As Byte
            Public bOutlineLevel As Byte
            Public wShadingWeight As Int16
            Public wShadingStyle As Int16
            Public wNumberingStart As Int16
            Public wNumberingStyle As Int16
            Public wNumberingTab As Int16
            Public wBorderSpace As Int16
            Public wBorderWidth As Int16
            Public wBorders As Int16
        End Structure

        ''' <summary>
        ''' Provides a simple interface to apply appropriate
        ''' paragraph line spacing to the selected text.
        ''' </summary>
        Public Structure LineSpacing
            ''' <summary>
            ''' Single-spaced line spacing between lines of text.
            ''' </summary>
            Public Shared ReadOnly Property [Single]() As Byte
                Get
                    Return BL_SINGLE_LINE_SPACING
                End Get
            End Property

            ''' <summary>
            ''' One and one half spaced line spacing between lines of text.
            ''' </summary>
            Public Shared ReadOnly Property OneAndHalf() As Byte
                Get
                    Return BL_ONE_AND_HALF_LINE_SPACING
                End Get
            End Property

            ''' <summary>
            ''' Double-spaced line spacing between lines of text. 
            ''' </summary>
            Public Shared ReadOnly Property [Double]() As Byte
                Get
                    Return BL_DOUBLE_LINE_SPACING
                End Get
            End Property
        End Structure

        ''' <summary>
        ''' Initializes new instance of Format Class, for formatting text
        ''' in a RichTextBox.
        ''' </summary>
        ''' <param name="rtbHandle">The handle to the RichTextbox to edit.</param>
        Friend Sub New(rtbHandle As IntPtr)
            hWnd = rtbHandle
        End Sub

        ''' <summary>
        ''' Sets the selected text font face to
        ''' the specified font name.
        ''' </summary>
        Friend WriteOnly Property SelectionFontName() As String
            Set
                SetSelectionFontName(Value)
            End Set
        End Property

        ''' <summary>
        ''' Sets the selected text font size to
        ''' the specified size.
        ''' </summary>
        Friend WriteOnly Property SelectionFontSize() As Single
            Set
                SetSelectionFontSize(Value)
            End Set
        End Property

        ''' <summary>
        ''' Adds (or removes) the specified font style
        ''' to the selected text.
        ''' </summary>
        ''' <param name="fs"></param>
        ''' <param name="AddStyle"></param>
        Friend Sub SetSelectionFontStyle(fs As FontStyle, AddStyle As Boolean)
            Dim cf As New CHARFORMAT()
            cf.cbSize = Marshal.SizeOf(cf)
            cf.dwMask = CType(fs, UInt32)
            If AddStyle Then
                cf.dwEffects = cf.dwMask
            End If
            SendMessage(hWnd, EM_SETCHARFORMAT, SCF_SELECTION, cf)
        End Sub

        Private Sub SetSelectionFontName(font As String)
            Dim cf As New CHARFORMAT()
            cf.cbSize = Marshal.SizeOf(cf)
            cf.dwMask = CFM_FACE
            Dim ch As New Char()
            font = font.PadRight(32, ch)
            cf.szFaceName = font.ToCharArray()
            SendMessage(hWnd, EM_SETCHARFORMAT, SCF_SELECTION, cf)
        End Sub

        Private Sub SetSelectionFontSize(size As Single)
            Dim cf As New CHARFORMAT()
            cf.cbSize = Marshal.SizeOf(cf)
            cf.dwMask = CFM_SIZE
            cf.yHeight = CInt(Math.Truncate(size * TWIPS_PER_POINT))
            SendMessage(hWnd, EM_SETCHARFORMAT, SCF_SELECTION, cf)
        End Sub

        ''' <summary>
        ''' Sets vertical line spacing between lines
        ''' of text, for the current text selection.
        ''' </summary>
        ''' <param name="spacing">Set to one of the bLineSpacingRule (BL_) constants,
        ''' such as "BL_SINGLE_LINE_SPACING".</param>
        Public Sub SetSelectionLineSpacing(spacing As Byte)
            ' Ignore request if spacing value not valid.
            ' Valid values are 0, 1 and 2.
            If spacing < 3 Then
                Dim pf As New PARAFORMAT2()
                pf.cbSize = Marshal.SizeOf(pf)
                pf.dwMask = pf.dwMask Or PFM_LINESPACING Or PFM_SPACEAFTER
                pf.bLineSpacingRule = spacing
                SendMessage(hWnd, EM_SETPARAFORMAT, SCF_SELECTION, pf)
            End If
        End Sub

        ''' <summary>
        ''' Gets the existing vertical line spacing between
        ''' lines of text, for the current text selection.
        ''' </summary>
        Public Function GetSelectionLineSpacing() As Byte
            Dim pf As New PARAFORMAT2()
            pf.cbSize = Marshal.SizeOf(pf)
            pf.dwMask = pf.dwMask Or PFM_LINESPACING Or PFM_SPACEAFTER
            SendMessage(hWnd, EM_GETPARAFORMAT, SCF_SELECTION, pf)
            Return pf.bLineSpacingRule
        End Function

        ''' <summary>
        ''' Gets or sets the right indent value of the
        ''' selected text, in twips.
        ''' </summary>
        Public Property SelectionRightIndentTwips() As Integer
            Get
                Return GetSelectionRightIndent()
            End Get

            Set
                SetSelectionRightIndent(Value)
            End Set
        End Property

        ''' <summary>
        ''' Sets the right indent value. Right indent is the
        ''' distance to indent to the left, from the right
        ''' margin. The larger the number, the further to
        ''' the left the text will be indented.
        ''' </summary>
        ''' <param name="twipsIndentValue"></param>
        Private Sub SetSelectionRightIndent(twipsIndentValue As Integer)
            Dim pf As New PARAFORMAT2()
            pf.cbSize = Marshal.SizeOf(pf)
            pf.dwMask = PFM_RIGHTINDENT
            pf.dxRightIndent = twipsIndentValue
            SendMessage(hWnd, EM_SETPARAFORMAT, SCF_SELECTION, pf)
        End Sub

        ''' <summary>
        ''' Returns the rtf formatting right indent value for the
        ''' selected text, in twips.
        ''' </summary>
        ''' <returns>The right indent value in twips.</returns>
        Private Function GetSelectionRightIndent() As Integer
            Dim pf As New PARAFORMAT2()
            pf.cbSize = Marshal.SizeOf(pf)
            pf.dwMask = PFM_RIGHTINDENT
            SendMessage(hWnd, EM_GETPARAFORMAT, SCF_SELECTION, pf)
            Return pf.dxRightIndent
        End Function
    End Class
End Namespace



