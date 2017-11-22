Imports System.Windows.Forms
Imports System.Drawing
Imports System.IO
Public Class frmNewProject
    Dim CurrentPath As String
    Dim newproject As ProjectItem

    Private Sub frmNewProject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'listGroup.FullRowSelect = True



        '  Dim item As ListViewItem = listGroup.Items.Add("Blank")
        ' item.ImageIndex = 0

        'listGroup.Items.Add("Fiction").ImageIndex = 1
        ' listGroup.Items.Add("Non-Fiction").ImageIndex = 1
        '  listGroup.Items.Add("Script Writing").ImageIndex = 1
        ' listGroup.Items.Add("Miscellaneous").ImageIndex = 1
    End Sub

    Private Sub listGroup_SelectedIndexChanged(sender As Object, e As EventArgs)
        'For Each w1 As ListViewItem In listGroup.SelectedItems
        'w1.BackColor = Color.YellowGreen
        'Next
    End Sub

    Private Sub btBrowse_Click(sender As Object, e As EventArgs) Handles btBrowse.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        FolderBrowserDialog1.ShowDialog()
        CurrentPath = FolderBrowserDialog1.SelectedPath

        txtSaveTo.Text = CurrentPath

        If txtName.Text <> "" And txtSaveTo.Text <> "" And txtAuthor.Text <> "" Then
            btOK.Enabled = True
        End If
    End Sub

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub

    Private Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        If txtName.Text <> "" And txtSaveTo.Text <> "" And txtAuthor.Text <> "" Then
            Dim fullpath As String = CurrentPath & "\" & txtName.Text & "\project.tummo"

            If Not File.Exists(fullpath) Then
                TreeProject.CreateNewProject(CurrentPath, txtName.Text)
                newproject = New ProjectItem(fullpath)
                newproject.EditTittle(0, txtName.Text)
                newproject.EditAuthor(0, txtAuthor.Text)

                ThisAddIn.MyTab1.ReadProject(fullpath)
                ThisAddIn.MyTab1.treeProject.ExpandAll()
                DataSyns.currentFile = fullpath
                DataSyns.currentFolder = CurrentPath & "\" & txtName.Text
                'DataSyns.currentProject
                Me.Close()
            Else
                MsgBox("Project exits!")
            End If
        End If

    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If txtName.Text <> "" And txtSaveTo.Text <> "" And txtAuthor.Text <> "" Then
            btOK.Enabled = True
        End If
    End Sub

    Private Sub txtAuthor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAuthor.KeyPress
        If txtName.Text <> "" And txtSaveTo.Text <> "" And txtAuthor.Text <> "" Then
            btOK.Enabled = True
        End If
    End Sub

    Private Sub txtSaveTo_TextChanged(sender As Object, e As EventArgs) Handles txtSaveTo.TextChanged
        If txtName.Text <> "" And txtSaveTo.Text <> "" And txtAuthor.Text <> "" Then
            btOK.Enabled = True
        End If
    End Sub
End Class