Imports System
Imports System.IO
Imports Novacode
Imports Image = Novacode.Image

Module TreeProject
    Private MyPath As New TummoPath
    Private docx As Microsoft.Office.Interop.Word.Document

    Public Sub CreateDocument(file As String)

        Dim g_document1 As Novacode.DocX = Novacode.DocX.Create(file)
        Dim g_paragraph1 As Novacode.Paragraph = g_document1.InsertParagraph("New Document")
        g_document1.Save()
    End Sub

    Public Sub CreateNewProject(DirPath As String, ProjectName As String)
        Dim Path1 As String = DirPath & "\" & ProjectName

        'Dim TargetPath2 As String = PathOfMyDocuments() & "\Tummo Spell 2016 AddIn\user"
        ' If (Not System.IO.Directory.Exists(TargetPath1)) Then
        System.IO.Directory.CreateDirectory(Path1)
        System.IO.Directory.CreateDirectory(Path1 & "\doc")
        System.IO.Directory.CreateDirectory(Path1 & "\img")

        'Using sw As New StreamWriter(File.Open(Path1 & "\project.tummo", FileMode.Append), System.Text.Encoding.Unicode)
        ' sw.WriteLine("<?xml version=""1.0"" encoding=""utf-8""?>") ' WriteLine(My.Resources.project_tummo)
        ' sw.WriteLine("<project>")
        '  sw.WriteLine("<root id=""0"" tittle=""Tittle Documents"" author=""Author Documents"" cover=""picture.png"" />")
        '  sw.WriteLine("<folder id=""1"" tittle=""New Documents"" />")
        ' sw.WriteLine("<document folderid=""1"" id=""3"" tittle=""Chapter 1"" file=""1.docx"" /> ")
        ' sw.WriteLine("<folder id = ""2"" tittle=""Notes"" />")

        ' sw.WriteLine("</project>")
        ' WriteLine(My.Resources.template1)
        ' End Using
        File.Copy(MyPath.PathOfTemplate & "\template1.xml", Path1 & "\project.tummo")

        Dim g_document1 As Novacode.DocX = Novacode.DocX.Create(Path1 & "\doc\1.docx")
        Dim g_paragraph1 As Novacode.Paragraph = g_document1.InsertParagraph("Document 1")
        g_document1.Save()

        Dim g_document2 As Novacode.DocX = Novacode.DocX.Create(Path1 & "\doc\2.docx")
        Dim g_paragraph2 As Novacode.Paragraph = g_document2.InsertParagraph("Document 2")
        g_document2.Save()

        Dim g_document3 As Novacode.DocX = Novacode.DocX.Create(Path1 & "\doc\3.docx")
        Dim g_paragraph3 As Novacode.Paragraph = g_document3.InsertParagraph("Note 1")
        g_document3.Save()

        Dim g_document4 As Novacode.DocX = Novacode.DocX.Create(Path1 & "\doc\4.docx")
        Dim g_paragraph4 As Novacode.Paragraph = g_document4.InsertParagraph("Note 2")
        g_document4.Save()
    End Sub


End Module
