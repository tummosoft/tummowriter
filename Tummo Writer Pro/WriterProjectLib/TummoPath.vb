Imports System.IO
Public Class TummoPath
    Public Function CurrentPath() As String
        Dim result As String

        result = Directory.GetCurrentDirectory()

        Return result
    End Function

    Public Function PathOfMyDocuments() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        Return result
    End Function

    Public Sub CopyDic(Target As String)
        Dim TargetPath2 As String = PathOfMyDocuments() & "\Tummo Writer Plus\user\user.dic"
        If File.Exists(TargetPath2) Then
            File.Copy(TargetPath2, Target)
        End If
    End Sub

    Public Sub RetoreDic(Source As String)
        Dim TargetPath2 As String = PathOfMyDocuments() & "\Tummo Writer Plus\user\user.dic"
        If File.Exists(Source) Then
            File.Copy(Source, TargetPath2, True)
        End If
    End Sub
    Public Sub CheckFolder()
        Dim TargetPath1 As String = PathOfMyDocuments() & "\Tummo Writer Plus\data"
        Dim TargetPath2 As String = PathOfMyDocuments() & "\Tummo Writer Plus\user"
        If (Not System.IO.Directory.Exists(TargetPath1)) Then
            System.IO.Directory.CreateDirectory(TargetPath1)
            System.IO.Directory.CreateDirectory(TargetPath2)
        End If

        'result = PathOfMyDocuments & "\Tummo Spell 2016 AddIn" 
    End Sub

    Public Function PathOfData() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Plus\data"

        Return result
    End Function

    Public Function PathOfUser() As String
        'Dim GetPath As DirectoryInfo
        Dim result As String

        result = PathOfMyDocuments() & "\Tummo Writer Plus\user"

        Return result
    End Function
End Class
