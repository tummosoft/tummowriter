'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/15/2016
' * Time: 8:51 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace WordEditor
    Public Class MainApp
        Public Const DISPLAY_NAME As String = "Word Editor"
        <STAThread>
        Private Shared Sub Main(args As String())
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Dim mainForm As New MainForm()
            Dim location As Object = Nothing
            If args.Length > 0 Then

                If args(0).StartsWith("prev_instance:") Then
                    ' User clicked "New". Get location of previous 
                    ' instance and open new form slightly lower
                    ' and to the right of previous form, unless
                    ' previous form's Window State is maximized.
                    Dim prevLoc As New Point()
                    Try
                        Dim pc As New PointConverter()
                        prevLoc = CType(pc.ConvertFromString(args(0).Substring(14)), Point)
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    End Try
                    '
                    If prevLoc.X > 0 Then
                        ' Open new form slightly lower and
                        ' to the right of previous form.
                        location = New Point(prevLoc.X + 35, prevLoc.Y + 35)
                        ' mainForm.GetSettings(new Point(prevLoc.X + 35, prevLoc.Y + 35));
                        mainForm.StartPosition = FormStartPosition.Manual
                    End If
                Else
                    mainForm.GetSettings(Nothing)
                    ' Windows Explorer selected this application
                    ' to open a file. The first argument should
                    ' be the path of the file to open.
                    mainForm.OpenFile(args(0))
                End If
            End If
            mainForm.GetSettings(location)
            Application.Run(mainForm)
        End Sub
    End Class
End Namespace
