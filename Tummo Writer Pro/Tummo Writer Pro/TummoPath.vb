Imports System.IO
Public Class TummoPath
    Public Function CurrentPath() As String
        Dim result As String

        result = Directory.GetCurrentDirectory()

        Return result
    End Function

    Public Sub CheckStart()
        CheckFolder()

        If Not File.Exists(PathOfBookMark()) Then
            WriteBookmark()
        End If
    End Sub

    Private Sub WriteBookmark()
        Using sw As New StreamWriter(File.Open(PathOfBookMark(), FileMode.CreateNew), System.Text.Encoding.Unicode)

            sw.WriteLine("0|c:\|c:\")
            sw.WriteLine("1|word document|*.doc *.docx *.rtf")
            sw.WriteLine("2|word content|word content")
        End Using
    End Sub

    Public Function PathOfMyDocuments() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Return result
    End Function

    Public Sub CheckFolder()
        ' Dim TargetPath1 As String = PathOfMyDocuments() & "\Tummo Writer Pro\data"
        ' Dim TargetPath2 As String = PathOfMyDocuments() & "\Tummo Writer Pro\user"
        If (Not System.IO.Directory.Exists(MainPath)) Then
            System.IO.Directory.CreateDirectory(PathOfData)
            System.IO.Directory.CreateDirectory(PathOfBookMark)
            System.IO.Directory.CreateDirectory(PathOfTemplate)
            System.IO.Directory.CreateDirectory(PathOfStyle)
            System.IO.Directory.CreateDirectory(PathOfProject)
            System.IO.Directory.CreateDirectory(PathOfTemp)
        End If

        'result = PathOfMyDocuments & "\Tummo Spell 2016 AddIn" 
    End Sub

    Public Function MainPath() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro"

        Return result
    End Function

    Public Function PathOfTemp() As String
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro\temp"

        Return result
    End Function

    Public Function PathOfData() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro\data"

        Return result
    End Function

    Public Function PathOfBookMark() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro\data\bookmark\bookmark_file.txt"

        Return result
    End Function

    Public Function PathOfTemplate() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro\data\template"

        Return result
    End Function

    Public Function PathOfStyle() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro\data\style"

        Return result
    End Function

    Public Function PathOfProject() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Pro\project"

        Return result
    End Function
End Class
