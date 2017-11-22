Imports System
Imports System.Drawing
Imports System.Windows.Forms
'using System.Drawing.Printing;
Imports System.Text
Imports System.IO
Imports System.Drawing.Drawing2D

Namespace WordEditor
    Partial Public Class mainForm
        Inherits Form
        Private format As Format
        Private pageSettings As System.Drawing.Printing.PageSettings
        Private printRtf As PrintRichText
        Private tc As TwipsConverter
        Private Const ONE_PIXEL As Byte = 1
        Private Const NUMBER_POS As Byte = 8
        Private Const HALF_POINT As Byte = 4
        Private Const PORTRAIT_RIGHT_LIMIT As Integer = 823
        Private riValue As Integer
        Private rightIndentVal As Integer
        Private oldRightMarginX As Integer
        Private rightIndentOffset As Integer = 124
        Private rightMarginMouseX As Integer
        Private selFnt As Font
        ' Private highlightColor As ColorTable
        Private selAlign As HorizontalAlignment
        Private saved As Boolean = True
        Private appFolder As String = "\Word_Editor\"
        Private currentFile As String = ""
        Private recentFiles As String()
        Private zoomChanging As Boolean
        Private posLeft As Integer
        Private posTop As Integer
        Private formWidth As Integer
        Private formHeight As Integer
        Private selectedColor As Color = Color.Black
        Private br As Brush
        Private Delegate Sub AddFonts()
        Private delgAddFonts As AddFonts
        Private ffNames As String()
        Private fontSize As SizeF


        Public Sub New()
            ' this.ruler = new TopRuler();
            ' Set Rich Textbox and right margin line.
            ' ruler.InitializeObjects(this.richText, this.rightMarginLine);

        End Sub

        Public Sub GetSettings(newLocation As Object)
            Dim userFolder As String = ""
            Try
                userFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\EditorPro\"
                If Directory.Exists(userFolder) Then
                    Dim userFile As String = userFolder & "Settings.txt"
                    If File.Exists(userFile) Then
                        Dim s As String() = New String() {Environment.NewLine}
                        Dim settings As String() = File.ReadAllText(userFile).Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                        Dim rConv As New RectangleConverter()
                        Dim rc As Rectangle
                        rc = CType(rConv.ConvertFromString(settings(0)), Rectangle)
                        If newLocation Is Nothing Then
                            posLeft = rc.Left
                            posTop = rc.Top
                        Else
                            Dim pt As Point = CType(newLocation, Point)
                            posLeft = pt.X
                            posTop = pt.Y
                        End If
                        formWidth = rc.Width
                        formHeight = rc.Height
                        ' Validate location.  Use designer form
                        ' settings if form is cut off of the screen.
                        If posLeft > 0 AndAlso posTop > 0 Then
                            Dim bounds As Rectangle = Screen.PrimaryScreen.Bounds
                            If posLeft + formWidth > bounds.Width OrElse posTop + formHeight > bounds.Height Then
                                formWidth = 0
                            End If
                        Else
                            formWidth = 0
                        End If

                        If settings(1) = "True" Then
                            WindowState = FormWindowState.Maximized
                        End If
                    End If
                End If
            Catch
                Try
                    If userFolder.Length > 0 AndAlso Directory.Exists(userFolder) AndAlso File.Exists(userFolder & "Settings.txt") Then
                        File.Delete(userFolder & "Settings.txt")
                    End If
                Catch
                End Try
            End Try

        End Sub

        Public Sub OpenFile(fullpath As String)
            Try
                If Directory.Exists(Path.GetDirectoryName(fullpath)) AndAlso File.Exists(fullpath) Then
                    Dim ext As String = Path.GetExtension(fullpath).ToLower()
                    If ext = ".rtf" Then
                        'richText.LoadFile(fullpath, RichTextBoxStreamType.RichText)
                    Else
                        ' richText.LoadFile(fullpath, RichTextBoxStreamType.PlainText)
                    End If
                    currentFile = fullpath
                    'currentFileLabel.Text = "Current File:  " & currentFile
                    Me.Text = Path.GetFileNameWithoutExtension(currentFile) & " - EditorPro"
                    saved = True
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End Try
        End Sub

        Private Sub InitializeComponent()
            Me.RichTextBoxCustom1 = New TummoRichTextBox.WordEditor.RichTextBoxCustom()
            Me.SuspendLayout()
            '
            'RichTextBoxCustom1
            '
            Me.RichTextBoxCustom1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RichTextBoxCustom1.Location = New System.Drawing.Point(0, 0)
            Me.RichTextBoxCustom1.Name = "RichTextBoxCustom1"
            Me.RichTextBoxCustom1.Size = New System.Drawing.Size(758, 261)
            Me.RichTextBoxCustom1.TabIndex = 0
            Me.RichTextBoxCustom1.Text = ""
            '
            'mainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(758, 261)
            Me.Controls.Add(Me.RichTextBoxCustom1)
            Me.Name = "mainForm"
            Me.Text = "Form1"
            Me.ResumeLayout(False)

        End Sub

        Private Sub mainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            RichTextBoxCustom1.LoadFile("C:\Users\Nguyen Van Hien\Documents\Test\tiengvietRTF.rtf")
        End Sub

        Friend WithEvents RichTextBoxCustom1 As RichTextBoxCustom
    End Class
End Namespace
