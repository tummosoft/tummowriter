Imports System.IO
Public Class frmAddItem
    Public TypeItem As Integer
    Private thisproject As ProjectItem
    Public ModeForm As String

    Private Sub frmAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        thisproject = New ProjectItem(DataSyns.currentFile)

        If TypeItem = 1 Then
            cboType.Text = "Folder"
        Else
            cboType.Text = "Document"
        End If

        If ModeForm = "NEW" Then
            Me.Text = "Add new"
            btAdd.Text = "Add"
        ElseIf ModeForm = "EDIT" Then
            cboType.Enabled = False
            Me.Text = "Edit"
            btAdd.Text = "Save"
        End If
    End Sub

    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        If ModeForm = "NEW" Then
            If txtTittle.Text <> "" Then
                If cboType.Text = "Folder" Then
                    Dim newid As Integer = GetNewID()
                    thisproject.AddFolder(newid, txtTittle.Text)
                    ThisAddIn.MyTab1.ReadProject(DataSyns.currentFile)
                    ThisAddIn.MyTab1.treeProject.ExpandAll()
                ElseIf cboType.Text = "Document" Then
                    Dim newid As Integer = GetNewID()
                    thisproject.AddDocument(newid, DataSyns.IdFolder, txtTittle.Text, newid & ".docx")
                    ThisAddIn.MyTab1.ReadProject(DataSyns.currentFile)
                    ThisAddIn.MyTab1.treeProject.ExpandAll()
                End If
            End If
            Me.Close()
        ElseIf ModeForm = "EDIT" Then
            If txtTittle.Text <> "" Then
                If cboType.Text = "Folder" Then
                    thisproject.EditFolder(DataSyns.itemID, txtTittle.Text)
                    ThisAddIn.MyTab1.ReadProject(DataSyns.currentFile)
                    ThisAddIn.MyTab1.treeProject.ExpandAll()
                ElseIf cboType.Text = "Document" Then
                    thisproject.EditDocument(DataSyns.itemID, txtTittle.Text)
                    ThisAddIn.MyTab1.ReadProject(DataSyns.currentFile)
                    ThisAddIn.MyTab1.treeProject.ExpandAll()
                End If
                Me.Close()
            End If
        End If
    End Sub

    Public Function GetNewID() As Integer
        Try
            Dim newid As Integer
            Dim countid As Integer = DataSyns._listID.Count
            Dim idnext As Integer = countid + 10

            ' MsgBox(countid)
            For i = countid To idnext
                newid = i
                If DataSyns._listID.IndexOf(newid) = -1 Then
                    Dim fullpath As String = DataSyns.currentFolder & "\doc\" & newid & ".docx"
                    If Not File.Exists(fullpath) Then
                        DataSyns._listID.Add(newid)
                        Exit For
                    End If
                End If
            Next

            Return newid
        Catch ex As Exception

        End Try

    End Function

    Private Sub btCancel_Click(sender As Object, e As EventArgs) Handles btCancel.Click
        Me.Close()
    End Sub
End Class