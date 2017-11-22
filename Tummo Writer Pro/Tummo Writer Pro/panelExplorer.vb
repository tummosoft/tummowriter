Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word
Imports Novacode
Imports Image = Novacode.Image
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports WordEditor
Imports System.IO
Imports System.Reflection
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Xml
Imports WriterProjectLib.Tummosoft.TummoWriter

'Imports Tummosoft.DataModel

Public Class panelExplorer
    Private typeFind As Integer
    Private SelectPath As String
    Private lstFile As New List(Of String)
    Private historyLstFile As New List(Of String)
    Private indexFile As String
    Private FullFile As String
    Private MyBookMark As New BookMarksManage
    Private MyPath As New TummoPath
    Private WordApp As Microsoft.Office.Interop.Word.Application
    Private docx As Microsoft.Office.Interop.Word.Document
    Private _itemselected As String
    Private _ItemIndex As Integer = -1
    Private _currentIndex As Integer = -1
    Private _currentItemIndex As Integer = -1
    Private _tempItemIndex As Integer = -1
    Private _mousePoint As System.Drawing.Point
    Dim t As System.Threading.Thread
    Private currentproject As DataModel.Node
    Private newproject As ProjectItem
    Public Test1 As String = "hello"

    Sub New()

        ' This call is eadequired by the designer.
        InitializeComponent()
        typeFind = 0
        DataSyns.typeFind = 0
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub panelExplorer_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ' Add any initialization after the InitializeComponent() call.
        Dim app As Word.Application = Globals.ThisAddIn.Application
        '  AddHandler app.DocumentChange, AddressOf app_DocumentChange
        '  AddHandler app.DocumentBeforeSave, AddressOf app_DocumentBeforeSave
        'AddHandler app.DocumentBeforeClose, AddressOf app_DocumentBeforeClose
        ' LoadProject()

    End Sub

    Private Sub app_DocumentBeforeClose(Doc As Word.Document, ByRef Cancel As Boolean)
        'RemoveOrphanedTaskPanes()
        'MsgBox("have")
    End Sub

    Private Sub rTab_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'treeFile.Build(Nothing)
        listFile.ItemCount = 0
    End Sub

    Public Property CurrentPath() As String
        Get
            Return SelectPath
        End Get

        Set(value As String)
            SelectPath = value
            cboPath.Text = value
        End Set
    End Property

    Public Property ItemSelected() As String
        Get
            Return _itemselected
        End Get

        Set(value As String)
            _itemselected = value
        End Set
    End Property

    Public Property ItemIndex() As String
        Get
            Return _ItemIndex
        End Get

        Set(value As String)
            _ItemIndex = value
        End Set
    End Property

    Private Sub LoadTest()
        'FolderBrowserDialog1.ShowDialog()
        CurrentPath = "C:\Users\Nguyen Van Hien\Documents\Test"
        Dim di As New IO.DirectoryInfo(SelectPath)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        lstFile.Clear()

        For Each dra In diar1
            Dim exfile As String = dra.ToString
            exfile = exfile.Substring(exfile.Length - 3, 3)
            'lstFile.Add(dra.FullName)

            lstFile.Add(dra.Name)
            historyLstFile.Add(dra.Name)
        Next

        listFile.ItemCount = lstFile.Count
    End Sub

    Private Sub SortAZ()

        lstFile.Clear()

        historyLstFile.Sort()
        For Each dra In historyLstFile
            lstFile.Add(dra.ToString)
        Next

        listFile.ItemCount = lstFile.Count
    End Sub

    Private Sub DragTable()
        Dim Range As Microsoft.Office.Interop.Word.Range = DirectCast(Globals.ThisAddIn.Application.ActiveWindow.RangeFromPoint(0, 0), Microsoft.Office.Interop.Word.Range)
        Dim table As Word.Table = Globals.ThisAddIn.Application.ActiveDocument.Tables.Add(Range, 4, 4)

        table.Range.Font.Size = 8
        'table.Styl ("Table Grid 8")
        table.Rows(1).Cells(1).Range.Text = "Order Details"
        table.Rows(1).Cells(2).Range.Text = "Order Details"
        table.Rows(1).Cells(3).Range.Text = "Order Details"
        table.Rows(1).Cells(4).Range.Text = "Order Details"
        For i As Integer = 2 To 4
            For j As Integer = 1 To 4
                table.Rows(i).Cells(j).Range.Text = "ff" & i

            Next
        Next

        DoDragDrop(table, DragDropEffects.Copy)
    End Sub

    Private Sub toolFilter_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles toolFilter.DropDownItemClicked
        Dim item As ToolStripItem = e.ClickedItem
        Dim textitem As String = item.Tag

        If textitem = "0" Then
            typeFind = 0
            DataSyns.typeFind = 0
            toolFilter.Image = My.Resources.folder_explorer
            cboPath.Text = "c:\"
        ElseIf textitem = "1" Then
            typeFind = 1
            DataSyns.typeFind = 1
            toolFilter.Image = My.Resources.filter
            cboPath.Text = "*.doc *.docx *.rtf"
        ElseIf textitem = "2" Then
            DataSyns.typeFind = 2
            toolFilter.Image = My.Resources.find
            cboPath.Text = "content search"
        End If
    End Sub

    Private Sub btRun_Click(sender As Object, e As EventArgs) Handles btRun.Click
        If typeFind = 0 Then
            FileOption1()
        ElseIf typeFind = 1 Then
            Dim tempArr() As String = cboPath.Text.Split(" ")
            FileOption2(tempArr)
        ElseIf typeFind = 2 Then
            FileOption3(cboPath.Text)
        End If
    End Sub

#Region "Option"
    Private Sub FileOption1()

        FolderBrowserDialog1.ShowDialog()
        CurrentPath = FolderBrowserDialog1.SelectedPath
        Dim di As New IO.DirectoryInfo(CurrentPath)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        lstFile.Clear()

        For Each dra In diar1
            lstFile.Add(dra.Name)
        Next

        listFile.ItemCount = lstFile.Count
        historyLstFile.AddRange(lstFile.ToList)
    End Sub

    Private Sub FileOption2(FileEx() As String)

        If FileEx.Count - 1 >= 0 Then
            lstFile.Clear()

            For Each w1 In FileEx

                w1 = w1.Replace("*.", String.Empty)

                For Each w2 In historyLstFile
                    Dim exfile As String = w2.ToString
                    If exfile <> "" Then
                        exfile = exfile.Substring(exfile.Length - 3, 3)

                        If w1.ToLower = exfile.ToLower Then
                            lstFile.Add(w2.ToString)
                            ' MsgBox(w1 & " - " & exfile)
                        ElseIf w2.Contains(w1) Then
                            lstFile.Add(w2)
                        End If
                    End If
                Next
            Next

            listFile.ItemCount = lstFile.Count
        End If

    End Sub

    Private Sub FileOption3(SearchContent As String)
        lstFile.Clear()

        For Each w2 In historyLstFile
            Dim exfile As String = w2.ToString
            If exfile <> "" Then
                exfile = exfile.Substring(exfile.Length - 3, 3)
                Dim FullDoc As String = CurrentPath & "\" & w2.ToString
                ' MsgBox(FullDoc)
                If exfile.ToLower = "ocx" Then
                    If SearchWord(FullDoc, SearchContent) = True Then
                        lstFile.Add(w2.ToString)
                    End If
                    '  lstFile.Add(w2.ToString)
                    ' MsgBox(w1 & " - " & exfile)
                End If
            End If
        Next

        listFile.ItemCount = lstFile.Count
    End Sub

    Private Function SearchWord(sFile As String, sWord As String) As Boolean
        Dim g_document As DocX
        Dim g_text As String
        ' Dim result As Boolean = False

        g_document = docx.Load(sFile)
        g_text = g_document.Text '.FindAll("khuyến mãi")

        'g_document.SaveAs("dddd", )
        If g_text.Contains(sWord) Then
            Return True
        Else
            Return False
        End If
    End Function
#End Region

    Private Sub listFile_ItemTextNeeded(sender As Object, e As FastTreeNS.StringItemEventArgs) Handles listFile.ItemTextNeeded
        e.Result = lstFile(e.ItemIndex)
    End Sub

    Private Sub listFile_ItemSelectedStateChanged(sender As Object, e As FastTreeNS.ItemSelectedStateChangedEventArgs) Handles listFile.ItemSelectedStateChanged
        _ItemIndex = e.ItemIndex
        Dim exfile As String = lstFile(e.ItemIndex)
        _itemselected = exfile
        exfile = exfile.Substring(exfile.Length - 3, 3)

        If exfile = "ocx" Or exfile = "doc" Or exfile = "rtf" Then
            mnListFile.Items.Clear()
            mnListFile.Items.Add("Open Document").Tag = "_openWordDocument"
            mnListFile.Items.Add("-")
            mnListFile.Items.Add("Close...").Tag = "_closeWordDocument"
            mnListFile.Items.Add("-")
            ' mnListFile.Items.Add("View...").Tag = "_viewWordDocument"
            ' mnListFile.Items.Add("-")
            mnListFile.Items.Add("Insert...").Tag = "_insertWordDocument"
            mnListFile.Items.Add("-")
            mnListFile.Items.Add("Sort A-Z").Tag = "_azWordDocument"
            mnListFile.Items(0).Image = My.Resources.open_folder
            mnListFile.Items(2).Image = My.Resources.cancel
            mnListFile.Items(4).Image = My.Resources.document_view_book
            mnListFile.Items(6).Image = My.Resources.document_insert
            mnListFile.Items(8).Image = My.Resources.sort_asc_az
        ElseIf exfile = "txt" Then
            mnListFile.Items.Clear()
            mnListFile.Items.Add("View").Tag = "_viewWordDocument"
            mnListFile.Items.Add("-")
            mnListFile.Items.Add("Insert").Tag = "_insertWordDocument"
            mnListFile.Items.Add("-")
            mnListFile.Items.Add("Sort A-Z").Tag = "_azWordDocument"
            mnListFile.Items(0).Image = My.Resources.document_view_book
            mnListFile.Items(2).Image = My.Resources.document_insert
            mnListFile.Items(4).Image = My.Resources.sort_asc_az
        ElseIf exfile = "png" Or exfile = "peg" Or exfile = "gif" Or exfile = "jpg" Then
            mnListFile.Items.Clear()
            mnListFile.Items.Add("View Photo").Tag = "_viewPhoto"
            mnListFile.Items.Add("-")
            mnListFile.Items.Add("Insert to document").Tag = "_insertPhoto"
            mnListFile.Items.Add("-")
            mnListFile.Items.Add("Sort A-Z").Tag = "_azWordDocument"
            mnListFile.Items(0).Image = My.Resources.photos
            mnListFile.Items(2).Image = My.Resources.photo_add
            mnListFile.Items(4).Image = My.Resources.sort_asc_az
        End If
    End Sub

    Private Sub listFile_ItemIconNeeded(sender As Object, e As FastTreeNS.ImageItemEventArgs) Handles listFile.ItemIconNeeded
        Dim exfile As String = lstFile(e.ItemIndex)
        exfile = exfile.Substring(exfile.Length - 3, 3)

        'MsgBox(exfile)
        'If e.ItemIndex = 1 Then
        'e.Result = ImageList1.Images(0)
        'End If

        If exfile.ToUpper = "OCX" Then
            e.Result = ImageList1.Images(4)
        ElseIf exfile.ToUpper = "DOC" Then
            e.Result = ImageList1.Images(4)
        ElseIf exfile.ToUpper = "PEG" Then
            e.Result = ImageList1.Images(5)
        ElseIf exfile.ToUpper = "GIF" Then
            e.Result = ImageList1.Images(6)
        ElseIf exfile.ToUpper = "JPG" Then
            e.Result = ImageList1.Images(7)
        ElseIf exfile.ToUpper = "PNG" Then
            e.Result = ImageList1.Images(8)
        ElseIf exfile.ToUpper = "RTF" Then
            e.Result = ImageList1.Images(9)
        ElseIf exfile.ToUpper = "TXT" Then
            e.Result = ImageList1.Images(10)
        ElseIf exfile.ToUpper = "7Z" Then
            e.Result = ImageList1.Images(14)
        ElseIf exfile.ToUpper = "EXE" Then
            e.Result = ImageList1.Images(15)
        ElseIf exfile.ToUpper = "RAR" Then
            e.Result = ImageList1.Images(16)
        ElseIf exfile.ToUpper = "XLS" Then
            e.Result = ImageList1.Images(17)
        End If

        If e.ItemIndex = _currentIndex Then
            e.Result = ImageList1.Images(18)
        End If
    End Sub

    Private Sub cboPath_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cboPath.KeyPress
        If typeFind = 1 Then
            If cboPath.Text.Length >= 1 Then
                Dim tempArr() As String = cboPath.Text.Split(" ")
                FileOption2(tempArr)
            ElseIf cboPath.Text = "" Then
                lstFile.Clear()
                lstFile.AddRange(historyLstFile.ToList)
                listFile.ItemCount = lstFile.Count
            End If
        ElseIf typeFind = 2 Then
            If cboPath.Text.Length <= 3 Then
                lstFile.Clear()
                lstFile.AddRange(historyLstFile.ToList)
                listFile.ItemCount = lstFile.Count
            End If
        End If

    End Sub

    Private Sub fFolder_Click(sender As Object, e As EventArgs) Handles fFolder.Click
        FileOption1()
    End Sub

    Private Sub dropBookMark_Click(sender As Object, e As EventArgs) Handles dropBookMark.Click
        Dim listBookMark = MyBookMark.LoadBookMark(MyPath.PathOfBookMark)

        dropBookMark.DropDownItems.Clear()

        For Each w1 In listBookMark
            dropBookMark.DropDownItems.Add(w1.Tittle).Tag = w1.Type & "|" & w1.Path
        Next
    End Sub

    Private Sub dropBookMark_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles dropBookMark.DropDownItemClicked
        Dim item1 As ToolStripItem = e.ClickedItem
        Dim str1 As String = item1.Tag
        Dim getvalue() As String = str1.Split("|")

        If getvalue(0) = "0" Then
            typeFind = 0
            toolFilter.Image = My.Resources.folder_explorer

            CurrentPath = getvalue(1)
            If IO.Directory.Exists(CurrentPath) Then
                Dim di As New IO.DirectoryInfo(CurrentPath)
                Dim diar1 As IO.FileInfo() = di.GetFiles()
                Dim dra As IO.FileInfo

                lstFile.Clear()

                For Each dra In diar1
                    lstFile.Add(dra.Name)
                Next

                listFile.ItemCount = lstFile.Count
                historyLstFile.AddRange(lstFile.ToList)
            Else
                MsgBox("Đường dẫn không tồn tại!", MsgBoxStyle.Critical)
            End If
        ElseIf getvalue(0) = "1" Then
            typeFind = 1
            toolFilter.Image = My.Resources.filter

            cboPath.Text = getvalue(1)
            Dim tempArr() As String = cboPath.Text.Split(" ")
            FileOption2(tempArr)
        ElseIf getvalue(0) = "2" Then
            typeFind = 2
            toolFilter.Image = My.Resources.find

            cboPath.Text = getvalue(1)
            FileOption3(cboPath.Text)
        End If
    End Sub

    Private Sub fSearch_Click(sender As Object, e As EventArgs) Handles fSearch.Click
        listFile.ItemCount = lstFile.Count
        historyLstFile.AddRange(lstFile.ToList)
        typeFind = 2
    End Sub

    Private Sub btAddBookMark_Click(sender As Object, e As EventArgs) Handles btAddBookMark.Click
        Dim frmAddBookMark As New frmBookMark
        frmAddBookMark.Show()
        frmAddBookMark.txtTittle.Text = cboPath.Text
        frmAddBookMark.txtPath.Text = cboPath.Text
    End Sub

    Private Sub OpenDoc(FilePath As String)
        Try
            If Globals.ThisAddIn.Application.ActiveWindow.Application.Documents.Count >= 1 Then
                Globals.ThisAddIn.Application.ActiveWindow.Application.Documents.Close(True)
                docx = Globals.ThisAddIn.Application.Documents.Open(FilePath)
            Else
                Globals.ThisAddIn.Application.ActiveWindow.Application.Documents.Open(FilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub mnListFile_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles mnListFile.ItemClicked
        Dim item1 As ToolStripItem = e.ClickedItem

        If ItemSelected <> "" Then
            Dim exfile As String = ItemSelected.Substring(ItemSelected.Length - 3, 3)
            Dim FullPath As String = CurrentPath & "\" & ItemSelected
            'MsgBox(exfile)
            If exfile = "ocx" Or exfile = "doc" Or exfile = "rtf" Then
                If item1.Tag = "_openWordDocument" Then
                    t = New System.Threading.Thread(Sub() OpenDoc(FullPath))
                    t.SetApartmentState(System.Threading.ApartmentState.STA)
                    t.Start()
                    _currentIndex = ItemIndex
                ElseIf item1.Tag = "_closeWordDocument" Then
                    Globals.ThisAddIn.Application.ActiveWindow.Application.Documents.Close(True)
                    '  ElseIf item1.Tag = "_viewWordDocument" Then
                    ' ViewRTF(FullPath)
                ElseIf item1.Tag = "_insertWordDocument" Then
                    InsertDocument(FullPath)
                ElseIf item1.Tag = "_azWordDocument" Then
                    '_azWordDocument
                    SortAZ()
                End If
            ElseIf exfile = "txt" Then
                If item1.Tag = "_viewWordDocument" Then
                    ViewRTF(FullPath)
                ElseIf item1.Tag = "_insertWordDocument" Then
                    InsertDocument(FullPath)
                ElseIf item1.Tag = "_azWordDocument" Then
                    '_azWordDocument
                    SortAZ()
                End If
            ElseIf exfile = "png" Or exfile = "peg" Or exfile = "gif" Or exfile = "jpg" Then
                If item1.Tag = "_viewPhoto" Then
                    Dim newphoto As frmPhotoView = New frmPhotoView(FullPath, _mousePoint)
                    ' newphoto.Location = New System.Drawing.Point(_mousePoint.X, _mousePoint.Y)
                    newphoto.Show()
                ElseIf item1.Tag = "_insertPhoto" Then
                    Dim objSelection = Globals.ThisAddIn.Application.ActiveWindow.Selection
                    Dim selectRange As Range = objSelection.Range
                    ' MsgBox(selectRange.Start & "-" & selectRange.End)
                    Dim Range As Microsoft.Office.Interop.Word.Range = selectRange 'DirectCast(Globals.ThisAddIn.Application.ActiveWindow.RangeFromPoint(objSelection.Start, objSelection.End), Microsoft.Office.Interop.Word.Range)
                    Range.InlineShapes.AddPicture(FullPath)
                    Range.InsertParagraph()
                    '_insertPhoto
                ElseIf item1.Tag = "_azWordDocument" Then
                    '_azWordDocument
                    SortAZ()
                End If

            End If
        End If
    End Sub

    Private Sub InsertDocument(FilePath As String)

        ' Dim WordApp = New Globals.ThisAddIn.Application.ActiveWindow.Application()
        ' Dim currentDoc As Word.Document = WordApp.Documents.Open(FilePath)
        'WordApp.Selection.InsertFile()
        If File.Exists(FilePath) Then
            Globals.ThisAddIn.Application.ActiveWindow.Application.Selection.InsertFile(FilePath)
        End If

    End Sub
    Private Sub ViewRTF(FilePath As String)
        Try
            Dim RTFPath As String = ""

            If File.Exists(MyPath.PathOfTemp & "\testRTF.rtf") Then
                File.Delete(MyPath.PathOfTemp & "\testRTF.rtf")
            End If

            Dim exfile As String = FilePath.Substring(FilePath.Length - 3, 3)

            '   MsgBox(FilePath)
            If exfile = "ocx" Or exfile = "doc" Then
                Dim WordApp = New Microsoft.Office.Interop.Word.Application()
                Dim currentDoc = WordApp.Documents.Open(FilePath, [ReadOnly]:=True, Visible:=False)

                currentDoc.SaveAs(MyPath.PathOfTemp & "\testRTF", Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatRTF)
                currentDoc.Close()
                WordApp.Quit()

                RTFPath = MyPath.PathOfTemp & "\testRTF.rtf"
            ElseIf exfile = "rtf" Or exfile = "txt" Then
                RTFPath = FilePath
            End If

            If File.Exists(RTFPath) Then
                Dim frm As New WordEditor.MainForm
                frm.Show()
                frm.OpenFile(RTFPath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub listFile_ItemForeColorNeeded(sender As Object, e As FastTreeNS.ColorItemEventArgs) Handles listFile.ItemForeColorNeeded
        If e.ItemIndex = _currentIndex Then
            e.Result = Color.DarkRed
        End If
    End Sub

    Private Sub listFile_MouseClick(sender As Object, e As MouseEventArgs) Handles listFile.MouseClick
        _mousePoint = Cursor.Position
    End Sub

    Public Sub ReadProject(xmlfile As String)
        newproject = New ProjectItem(xmlfile)
        currentproject = newproject.ReadProject

        treeProject.Build(currentproject)
        ' ExtractProject()
    End Sub

    Private Sub treeProject_NodeIconNeeded(sender As Object, e As FastTreeNS.ImageNodeEventArgs) Handles treeProject.NodeIconNeeded

        'e.Result = If(TryCast(e.Node, DataModel.Node).Type = 1, ImageList1.Images(5), ImageList1.Images(7))
        If TryCast(e.Node, DataModel.Node).Type = 0 Then
            e.Result = ImageList1.Images(20)
        ElseIf TryCast(e.Node, DataModel.Node).Type = 1 Then
            e.Result = ImageList1.Images(13)
        ElseIf TryCast(e.Node, DataModel.Node).Type = 2 Then
            e.Result = ImageList1.Images(4)
        End If

        If TryCast(e.Node, DataModel.Node).Index = _currentItemIndex Then
            e.Result = ImageList1.Images(18)
        End If
    End Sub

    Private Sub treeProject_NodeSelectedStateChanged(sender As Object, e As FastTreeNS.NodeSelectedStateChangedEventArgs) Handles treeProject.NodeSelectedStateChanged
        Dim temp As DataModel.Node = e.Node
        DataSyns.IdFolder = temp.ParentID
        DataSyns.itemTittle = temp.Title
        DataSyns.itemID = temp.ID
        DataSyns.itemType = temp.Type
        DataSyns.itemFile = temp.FileName
        _tempItemIndex = temp.Index
        ' MsgBox(temp.ParentID)
    End Sub

    Private Sub treeProject_NodeForeColorNeeded(sender As Object, e As FastTreeNS.ColorNodeEventArgs) Handles treeProject.NodeForeColorNeeded
        ' e.Result = If(TryCast(e.Node, DataModel.Node).Title = "Chương 1", Color.Tomato, Color.Tomato)
        If TryCast(e.Node, DataModel.Node).Type = 0 Then
            e.Result = Color.MidnightBlue
        ElseIf TryCast(e.Node, DataModel.Node).Type = 1 Then
            e.Result = Color.OrangeRed
        ElseIf TryCast(e.Node, DataModel.Node).Type = 2 Then
            e.Result = Color.Black
        End If

        If TryCast(e.Node, DataModel.Node).Index = _currentItemIndex Then
            e.Result = Color.HotPink
        End If
    End Sub

    Private Sub mnProject_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles mnProject.ItemClicked
        Dim itemclicked As ToolStripItem = e.ClickedItem

        If itemclicked.Name = "mnOpen1" Then
            Dim fullpath As String = DataSyns.currentFolder & "\doc\" & DataSyns.itemFile
            t = New System.Threading.Thread(Sub() OpenDoc(FullPath))
            t.SetApartmentState(System.Threading.ApartmentState.STA)
            t.Start()

            _currentItemIndex = _tempItemIndex
            'ElseIf itemclicked.Name = "mnView1" Then
            ' Dim fullpath As String = DataSyns.currentFolder & "\doc\" & DataSyns.itemFile
            ' MsgBox(fullpath)
            '  ViewRTF(fullpath)
        ElseIf itemclicked.Name = "mnNewFolder" Then
            Dim Form1 As New frmAddItem
            Form1.TypeItem = 1
            Form1.ModeForm = "NEW"
            Form1.Show()
        ElseIf itemclicked.Name = "mnNewDocument" Then
            Dim Form1 As New frmAddItem
            Form1.TypeItem = 2
            Form1.ModeForm = "NEW"
            Form1.Show()
        ElseIf itemclicked.Name = "mnEdit" Then
            Dim Form1 As New frmAddItem
            Form1.TypeItem = DataSyns.itemType
            Form1.ModeForm = "EDIT"
            Form1.txtTittle.Text = DataSyns.itemTittle
            Form1.Show()
        ElseIf itemclicked.Name = "mnDelete" Then
            If DataSyns.itemType = 1 Then
                newproject.RemoveFolder(DataSyns.itemID)
                ReadProject(DataSyns.currentFile)
                treeProject.ExpandAll()
            ElseIf DataSyns.itemType = 2 Then
                newproject.RemoveDocument(DataSyns.itemID)
                ReadProject(DataSyns.currentFile)
                treeProject.ExpandAll()
            End If
        ElseIf itemclicked.Name = "mnCheckAll" Then
            treeProject.CheckAll()
        ElseIf itemclicked.Name = "mnUnCheckAll" Then
            treeProject.UncheckAll()
        End If
    End Sub

    Private Sub treeProject_NodeCheckedStateChanged(sender As Object, e As FastTreeNS.NodeCheckedStateChangedEventArgs) Handles treeProject.NodeCheckedStateChanged
        ' Dim selectindex = treeProject.SelectedItemIndex
        Dim index As Integer = TryCast(e.Node, DataModel.Node).Index
        ' nodeID = nodeID - 1

        DataSyns._checkedItem.Item(index).Checked = e.Checked
        ' MsgBox(nodeID)

        'Dim selectedItem As CheckedItem = (From o As CheckedItem In DataSyns._checkedItem Where o.NodeID = nodeID)

        'selectedItem.Checked = True
        'MsgBox(e.ToString)
    End Sub


End Class
