Imports System.IO
Imports System
Imports System.Xml

Public Class ProjectItem
    Private _filename As String
    Private currentproject As DataModel.Node
    Public ProjectTittle As String
    Public ProjectAuthor As String
    Public ProjectCover As String
    Public _listID As List(Of Integer)

    Sub New(_filename1 As String)
        _filename = _filename1
        _listID = New List(Of Integer)
    End Sub

    Public Function ReadProject() As DataModel.Node
        Dim xmlDoc As System.Xml.XmlDocument = New System.Xml.XmlDocument
        'Dim CurrentProject As DataModel.Node = Nothing
        '"C:\Users\Nguyen Van Hien\Documents\Test\test.xml"
        xmlDoc.Load(_filename)

        DataSyns._checkedItem = New List(Of CheckedItem)

        Dim root As System.Xml.XmlNode = xmlDoc.DocumentElement
        Dim _index As Integer = 0

        For Each w1 As System.Xml.XmlNode In root.SelectNodes("/project/root")
            Dim Tittle As String = w1.Attributes.ItemOf("tittle").InnerText
            Dim Author As String = w1.Attributes.ItemOf("author").InnerText
            Dim Cover As String = w1.Attributes.ItemOf("cover").InnerText

            ProjectTittle = Tittle
            ProjectAuthor = Author
            ProjectCover = Cover
            ' CurrentProject = New currentproject(Tittle, Author, Cover)
            currentproject = New DataModel.Node(_index, 0, 0, 0, Tittle, "")
            Dim cheked As New CheckedItem
            cheked.NodeID = 0
            cheked.NodeType = 0
            cheked.NodeTittle = Tittle
            cheked.Checked = False
            DataSyns._checkedItem.Add(cheked)
        Next

        For Each w1 As System.Xml.XmlNode In root.SelectNodes("/project/folder")
            Dim ParentId As Integer = w1.Attributes.ItemOf("id").InnerText
            Dim Tittle As String = w1.Attributes.ItemOf("tittle").InnerText

            _index = _index + 1
            Dim n = New DataModel.Node(_index, 1, ParentId, ParentId, Tittle, "")
            _listID.Add(ParentId)
            currentproject.AddChild(n)

            Dim cheked As New CheckedItem
            cheked.NodeID = ParentId
            cheked.NodeType = 1
            cheked.NodeTittle = Tittle
            cheked.Checked = False
            DataSyns._checkedItem.Add(cheked)

            For Each w2 As System.Xml.XmlNode In root.SelectNodes("/project/document")
                Dim FolderId As Integer = w2.Attributes.ItemOf("folderid").InnerText
                Dim Id2 As String = w2.Attributes.ItemOf("id").InnerText
                Dim Tittle2 As String = w2.Attributes.ItemOf("tittle").InnerText
                Dim File As String = w2.Attributes.ItemOf("file").InnerText

                If FolderId = ParentId Then
                    _index = _index + 1
                    Dim subNode = New DataModel.Node(_index, 2, ParentId, Id2, Tittle2, File)
                    n.AddChild(subNode)
                    _listID.Add(Id2)
                    Dim cheked1 As New CheckedItem
                    cheked1.NodeID = Id2
                    cheked1.NodeType = 2
                    cheked1.NodeTittle = Tittle2
                    cheked1.Checked = False
                    DataSyns._checkedItem.Add(cheked1)
                End If
            Next
        Next

        DataSyns._listID = _listID
        Return currentProject
    End Function


    Public Sub AddFolder(_id As Integer, _tittle As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim root As XmlNode = xmlDoc.SelectSingleNode("/project")
        Dim newItem As XmlElement = xmlDoc.CreateElement("folder")
        Dim newAttr As XmlAttribute = xmlDoc.CreateAttribute("tittle")

        newAttr.Value = _tittle

        newItem.SetAttribute("id", _id)
        newItem.Attributes.Append(newAttr)
        xmlDoc.DocumentElement.AppendChild(newItem)

        xmlDoc.Save(_filename)
    End Sub

    Public Sub AddDocument(_id As Integer, _folderid As Integer, _tittle As String, _file As String)

        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim root As XmlNode = xmlDoc.SelectSingleNode("/project")
        Dim newItem As XmlElement = xmlDoc.CreateElement("document")

        Dim TittleAttr As XmlAttribute = xmlDoc.CreateAttribute("tittle")
        TittleAttr.Value = _tittle
        Dim FileAttr As XmlAttribute = xmlDoc.CreateAttribute("file")
        FileAttr.Value = _file
        Dim FolderIdAttr As XmlAttribute = xmlDoc.CreateAttribute("folderid")
        FolderIdAttr.Value = _folderid
        '<document folderid="2" id="6" tittle="Note 1" file="note1.docx" />

        xmlDoc.DocumentElement.AppendChild(newItem)
        newItem.SetAttribute("id", _id)
        newItem.Attributes.Append(FolderIdAttr)
        newItem.Attributes.Append(TittleAttr)
        newItem.Attributes.Append(FileAttr)

        xmlDoc.Save(_filename)
        TreeProject.CreateDocument(DataSyns.currentFolder & "\doc\" & _id & ".docx")

        ' MsgBox(DataSyns.currentFolder)
    End Sub

    Public Sub EditFolder(_id As Integer, _tittle As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim attr As XmlAttribute
        attr = xmlDoc.SelectSingleNode("project/folder[@id='" & _id & "']/@tittle")
        attr.Value = _tittle

        xmlDoc.Save(_filename)
    End Sub

    Public Sub EditDocument(_id As Integer, _tittle As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim attr As XmlAttribute
        attr = xmlDoc.SelectSingleNode("project/document[@id='" & _id & "']/@tittle")
        attr.Value = _tittle

        xmlDoc.Save(_filename)
    End Sub

    Public Sub EditTittle(_id As Integer, _tittle As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim attr As XmlAttribute
        attr = xmlDoc.SelectSingleNode("project/root[@id='" & _id & "']/@tittle")
        attr.Value = _tittle

        xmlDoc.Save(_filename)
    End Sub

    Public Sub EditAuthor(_id As Integer, _tittle As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim attr As XmlAttribute
        attr = xmlDoc.SelectSingleNode("project/root[@id='" & _id & "']/@author")
        attr.Value = _tittle

        xmlDoc.Save(_filename)
    End Sub

    Public Sub EditCover(_id As Integer, _value As String)
        Dim xmlDoc As New XmlDocument
        xmlDoc.Load(_filename)
        Dim attr As XmlAttribute
        attr = xmlDoc.SelectSingleNode("project/root[@id='" & _id & "']/@cover")
        attr.Value = _value

        xmlDoc.Save(_filename)
    End Sub

    Public Sub RemoveDocument(_id As Integer)
        Dim xmlDoc As New XmlDocument

        xmlDoc.Load(_filename)
        Dim node1 As XmlNode = xmlDoc.SelectSingleNode("project/document[@id='" & _id & "']")

        If node1 IsNot Nothing Then
            node1.ParentNode.RemoveChild(node1)
            xmlDoc.Save(_filename)
            Dim fullpath As String = DataSyns.currentFolder & "\doc\" & _id & ".docx"
            If File.Exists(fullpath) Then
                File.Delete(fullpath)
            End If
        End If
    End Sub

    Public Sub RemoveFolder(_id As Integer)
        Dim xmlDoc As New XmlDocument

        xmlDoc.Load(_filename)
        Dim node1 As XmlNode = xmlDoc.SelectSingleNode("project/folder[@id='" & _id & "']")

        If node1 IsNot Nothing Then
            node1.ParentNode.RemoveChild(node1)
            xmlDoc.Save(_filename)

        End If
    End Sub
End Class

Public Class CheckedItem
    Public NodeType As Integer
    Public NodeID As Integer
    Public NodeTittle As String
    Public Checked As Boolean
End Class