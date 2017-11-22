Imports FileHelpers
Imports System.IO

Namespace Tummosoft.TummoWriter
    Public Class BookMarksManage
        Private lstBookMark As List(Of BookMarks)
        Dim res() As BookMarks

        Public Function LoadBookMark(FilePath As String) As List(Of BookMarks)
            Dim engine As New FileHelperEngine(GetType(BookMarks))
            Dim FindDup As New Dictionary(Of String, String)

            Dim res() As BookMarks = DirectCast(engine.ReadFile(FilePath), BookMarks())
            Dim str As String = ""

            lstBookMark = New List(Of BookMarks)
            For Each w1 In res
                Dim sWord As String = w1.Tittle
                lstBookMark.Add(w1)
            Next

            Return lstBookMark
        End Function

        Private Function CheckPath(Path As String) As Boolean
            Dim result = (From o In lstBookMark Where o.Path = Path).ToList

            If result.Count > 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Sub WriteBookMarks(filebookmark As String, id As String, tittle As String, path As String)
            Dim tempvalue As New BookMarks
            Dim engine As New FileHelperAsyncEngine(GetType(BookMarks))

            '  If IO.File.Exists(filebookmark) Then
            ' IO.File.Delete(filebookmark)
            'End If

            Dim sw As New StreamWriter(File.Open(filebookmark, FileMode.Append), System.Text.Encoding.Unicode)

            engine.BeginWriteStream(sw)

            tempvalue.Type = id
            tempvalue.Tittle = tittle
            tempvalue.Path = path

            engine.WriteNext(tempvalue)

            engine.Close()
        End Sub

        Public Sub DeleteBookMarks(filebookmark As String, path As String)

            Dim engine As New FileHelperAsyncEngine(GetType(BookMarks))

            engine.BeginWriteFile(filebookmark)

            For Each w1 In lstBookMark
                If path <> w1.Path Then
                    engine.WriteNext(w1)
                End If
            Next

            engine.Close()
        End Sub

    End Class

    <DelimitedRecord("|")>
    Public Class BookMarks
        Public Type As String
        Public Tittle As String
        Public Path As String
    End Class
End Namespace

