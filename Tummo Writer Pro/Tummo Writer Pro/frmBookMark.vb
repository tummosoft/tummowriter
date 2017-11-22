Imports WriterProjectLib.Tummosoft.TummoWriter

Public Class frmBookMark
    Private myBookMark As New BookMarksManage
    Private MyPath As New TummoPath

    Private Sub btAdd_Click(sender As Object, e As EventArgs) Handles btAdd.Click
        Dim typeFind As String = DataSyns.typeFind.ToString
        myBookMark.LoadBookMark(MyPath.PathOfBookMark)

        If txtTittle.Text <> "" And txtPath.Text <> "" Then
            myBookMark.WriteBookMarks(MyPath.PathOfBookMark, typeFind, txtTittle.Text, txtPath.Text)
            ' MsgBox(typeFind)
            Me.Close()
        End If
    End Sub
End Class
