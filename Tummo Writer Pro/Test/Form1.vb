Imports FileHelpers
Imports System.IO
Imports WordEditor
Imports System
Imports System.Xml
Imports Novacode
Imports Image = Novacode.Image

Public Class Form1
    Private lstBookMark As List(Of BookMarks)
    Dim res() As BookMarks
    Dim newproject As DataModel.Node

    Public Sub LoadBookMark(FilePath As String)
        Dim engine As New FileHelperEngine(GetType(BookMarks))
        Dim FindDup As New Dictionary(Of String, String)

        Dim res() As BookMarks = DirectCast(engine.ReadFile(FilePath), BookMarks())
        Dim str As String = ""

        lstBookMark = New List(Of BookMarks)
        For Each w1 In res
            Dim sWord As String = w1.Tittle
            lstBookMark.Add(w1)
        Next


    End Sub

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

        '    For Each w1 In lstBookMark
        '   If path <> w1.Path Then
        '   engine.WriteNext(w1)
        '   End If
        '   Next
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

    Private Sub shhd()
        Dim engine As New FileHelperEngine(GetType(BookMarks))
        Dim FindDup As New Dictionary(Of String, String)

        res = DirectCast(engine.ReadFile("C:\Users\Nguyen Van Hien\Documents\Tummo Writer Plus\data\bookmark\bookmark_file.txt"), BookMarks())
        Dim str As String = ""

        lstBookMark = New List(Of BookMarks)
        For Each w1 In res
            Dim sWord As String = w1.Tittle
            lstBookMark.Add(w1)
            'TextBox1.AppendText(w1.Tittle & vbNewLine)
        Next


        ' temp1 = (From o In res Select o.Words).ToList()
        '   temp2 = (From o In res Select o.Mean).ToList()
        '  result = (From o In res).ToList()
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PictureBox1.Image = Image.FromFile("F:\CODE\Addin\add-in 13\document_new.png")

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim employees(2) As Employee
        employees(0) = New Employee(1, "Prakash", "Rangan", 70000)
        employees(1) = New Employee(5, "Norah", "Miller", 21000)
        employees(2) = New Employee(17, "Cecil", "Walker", 60000)

        ' Create XmlWriterSettings.
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True

        ' Create XmlWriter.
        Using writer As XmlWriter = XmlWriter.Create("C:\Users\Nguyen Van Hien\Documents\employees.xml", settings)
            ' Begin writing.
            writer.WriteStartDocument()
            writer.WriteStartElement("project") ' Root.

            ' Loop over employees in array.
            Dim employee As Employee
            For Each employee In employees
                writer.WriteStartElement("root")
                writer.WriteAttributeString("tittle", "Doc suong mu")
                writer.WriteAttributeString("author", "Nguyen Manh")
                writer.WriteAttributeString("cover", "c:\picture.png")

                ' writer.WriteElementString("ID", employee._id.ToString)
                ' writer.WriteElementString("FirstName", employee._firstName)
                'writer.WriteElementString("LastName", employee._lastName)
                'writer.WriteElementString("Salary", employee._salary.ToString)
                writer.WriteEndElement()
            Next

            ' End document.
            writer.WriteEndElement()
            writer.WriteEndDocument()
        End Using
    End Sub

    Public Sub ExportToDoc()
        'C:\Users\Nguyen Van Hien\Documents\Test\1.docx
        Using document As Novacode.DocX = DocX.Create("C:\Users\Nguyen Van Hien\Documents\Test\publish.docx")

            'p1.Append
            For i = 1 To 4
                Dim fullpath As String = "C:\Users\Nguyen Van Hien\Documents\Test\" & i & ".docx"
                If File.Exists(fullpath) Then
                    'Dim lstDocument As Novacode.DocX = DocX.Load()
                    Dim p1 As Novacode.Paragraph = document.InsertParagraph()

                    document.ApplyTemplate(fullpath)
                    'document.Save()
                    'Dim p1 As Novacode.Paragraph '= document.InsertParagraph()
                    ' Dim template1 As Novacode.tem
                    ' For Each p2 As Novacode.Paragraph In lstDocument.Paragraphs
                    '  p1.para = p2
                    'p1.Append(p2.Text)

                    '  p1.InsertParagraphAfterSelf(p2)
                    '  p1.Append(p2.Text)
                    'Next
                    'p1.InsertPageBreakAfterSelf()
                    ' p1.InsertPageBreakAfterSelf()
                End If
            Next

            document.Save()

            ' g_document = DocX.Load(@"docs\InvoiceTemplate.docx");

            'g_document = CreateInvoiceFromTemplate(DocX.Load(@"docs\InvoiceTemplate.docx"));

            'g_document.SaveAs(@"docs\Invoice_The_Happy_Builder.docx");
        End Using


    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ExportToDoc()
    End Sub
End Class

<DelimitedRecord("|")>
Public Class BookMarks
    Public Type As String
    Public Tittle As String
    Public Path As String
End Class

Public Class TummoProject
    Public Property Tittle() As String
        Get
            Return m_Tittle
        End Get
        Set
            m_Tittle = Value
        End Set
    End Property
    Private m_Tittle As String

    Public Property Author() As String
        Get
            Return m_Author
        End Get
        Set
            m_Author = Value
        End Set
    End Property
    Private m_Author As String

    Public Property Cover() As String
        Get
            Return m_Cover
        End Get
        Set
            m_Cover = Value
        End Set
    End Property
    Private m_Cover As String

    Public Property FolderItem() As List(Of Folder)
        Get
            Return m_Item
        End Get
        Set
            m_Item = Value
        End Set
    End Property
    Private m_Item As List(Of Folder)

    Public Property DocumentItem() As List(Of Documents)
        Get
            Return m_Item1
        End Get
        Set
            m_Item1 = Value
        End Set
    End Property
    Private m_Item1 As List(Of Documents)

    Public Sub New(title__1 As String, _author As String, _cover As String)
        Tittle = title__1
        Author = _author
        Cover = _cover
        FolderItem = New List(Of Folder)()
        DocumentItem = New List(Of Documents)()
    End Sub

    Public Sub AddFolder(child As Folder)
        FolderItem.Add(child)
    End Sub

    Public Sub AddDocuments(child As Documents)
        DocumentItem.Add(child)
    End Sub
End Class

Public Class Folder
    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set
            m_ID = Value
        End Set
    End Property
    Private m_ID As String

    Public Property Tittle() As String
        Get
            Return m_Tittle
        End Get
        Set
            m_Tittle = Value
        End Set
    End Property
    Private m_Tittle As String

    Public Property DocumentItem() As List(Of Documents)
        Get
            Return m_Child
        End Get
        Set
            m_Child = Value
        End Set
    End Property
    Private m_Child As List(Of Documents)

    Public Sub AddDocument(child As Documents)
        DocumentItem.Add(child)
    End Sub
End Class

Public Class Documents
    Public Property FolderID() As String
        Get
            Return m_FolderID
        End Get
        Set
            m_FolderID = Value
        End Set
    End Property
    Private m_FolderID As String

    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set
            m_ID = Value
        End Set
    End Property
    Private m_ID As String

    Public Property Tittle() As String
        Get
            Return m_Tittle
        End Get
        Set
            m_Tittle = Value
        End Set
    End Property
    Private m_Tittle As String

    Public Property File() As String
        Get
            Return m_File
        End Get
        Set
            m_File = Value
        End Set
    End Property
    Private m_File As String
End Class

Class Employee
    Public Sub New(ByVal id As Integer, ByVal firstName As String,
               ByVal lastName As String, ByVal salary As Integer)
        ' Set fields.
        Me._id = id
        Me._firstName = firstName
        Me._lastName = lastName
        Me._salary = salary
    End Sub

    ' Storage of employee data.
    Public _firstName As String
    Public _id As Integer
    Public _lastName As String
    Public _salary As Integer
End Class
