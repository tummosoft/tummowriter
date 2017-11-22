Imports Microsoft.Office.Tools.Ribbon
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports EPubDocument = Epub.Document
Imports NavPoint = Epub.NavPoint

Public Class rMenu
    Dim WordApp As Microsoft.Office.Interop.Word.Application
    Dim docx As Microsoft.Office.Interop.Word.Document
    Dim MyPath As New TummoPath

    Private Sub rMenu_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

    End Sub

    Private Sub btLoadProject_Click(sender As Object, e As RibbonControlEventArgs) Handles btLoadProject.Click
        'C:\Users\Nguyen Van Hien\Documents\Test\test.xml
        'ThisAddIn.MyTab1.ReadProject("C:\Users\Nguyen Van Hien\Documents\Test\test.xml")
        'ThisAddIn.MyTab1.treeProject.ExpandAll()
        'DataSyns.currentfile = "C:\Users\Nguyen Van Hien\Documents\Test\test.xml"
        'ThisAddIn.MyTab1.ExtractProject()
        Dim OpenFileDialog1 As New OpenFileDialog
        OpenFileDialog1.Filter = "Tummo Writer Documents (*.tummo)|*.tummo"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fullpath As String = OpenFileDialog1.FileName
            Dim path As String = IO.Path.GetDirectoryName(fullpath)
            Dim filename As String = System.IO.Path.GetFileName(fullpath)

            ThisAddIn.MyTab1.ReadProject(fullpath)
            ThisAddIn.MyTab1.treeProject.ExpandAll()
            DataSyns.currentFile = fullpath
            DataSyns.currentFolder = path

            '   MsgBox(path)
        End If
    End Sub

    Private Sub btNewProject_Click(sender As Object, e As RibbonControlEventArgs) Handles btNewProject.Click
        Dim newform As New frmNewProject
        newform.Show()
    End Sub

    Private Sub btAbout_Click(sender As Object, e As RibbonControlEventArgs) Handles btAbout.Click
        Dim frmAb As New frmAbout

        frmAb.Show()
    End Sub

    Private Sub btShowPanel_Click(sender As Object, e As RibbonControlEventArgs) Handles btShowPanel.Click
        If ThisAddIn.panelDisplayed Then
            ThisAddIn.myCustomTaskPane.Visible = False
            ThisAddIn.panelDisplayed = False
        Else
            ThisAddIn.myCustomTaskPane.Visible = True
            ThisAddIn.panelDisplayed = True
        End If
    End Sub

    Private Sub ExportDOC()
        Dim DocPath As String = DataSyns.currentFolder & "\doc"
        Dim haveselected As Boolean = False

        Globals.ThisAddIn.Application.ActiveWindow.Application.Documents.Add()

        For Each w1 As CheckedItem In DataSyns._checkedItem
            If w1.Checked = True Then
                haveselected = True
                If w1.NodeType = 2 Then
                    For i = 0 To ThisAddIn.MyTab1.treeProject.ItemCount - 1
                        Dim nodeID As Integer = TryCast(ThisAddIn.MyTab1.treeProject.GetNodeByIndex(i), DataModel.Node).ID
                        Dim Filename As String = TryCast(ThisAddIn.MyTab1.treeProject.GetNodeByIndex(i), DataModel.Node).FileName
                        If nodeID = w1.NodeID Then
                            'MsgBox(w1.NodeTittle)
                            Dim FullPath As String = DocPath & "\" & Filename

                            If File.Exists(FullPath) Then
                                Globals.ThisAddIn.Application.ActiveWindow.Application.Selection.InsertFile(FullPath)
                                If checkBreakPage.Checked Then
                                    Globals.ThisAddIn.Application.ActiveWindow.Application.Selection.InsertBreak()
                                    ' Globals.ThisAddIn.Application.ActiveWindow.Application.Selection.HeaderFooter.PageNumbers.Add()
                                End If
                            End If
                        End If

                    Next
                End If
            End If
        Next

        If haveselected = False Then
            MsgBox("Please select your page to publish!", MsgBoxStyle.Critical, "Tummo Writer")
        End If
    End Sub

    Private Sub ExportEPUB()
        Dim DocPath As String = DataSyns.currentFolder & "\doc"
        Dim output As String = "C:\Users\Nguyen Van Hien\Documents\Test"

        For Each w1 As CheckedItem In DataSyns._checkedItem
            If w1.Checked = True Then
                If w1.NodeType = 2 Then
                    For i = 0 To ThisAddIn.MyTab1.treeProject.ItemCount - 1
                        Dim nodeID As Integer = TryCast(ThisAddIn.MyTab1.treeProject.GetNodeByIndex(i), DataModel.Node).ID
                        Dim Filename As String = TryCast(ThisAddIn.MyTab1.treeProject.GetNodeByIndex(i), DataModel.Node).FileName
                        If nodeID = w1.NodeID Then
                            'MsgBox(w1.NodeTittle)
                            Dim FullPath As String = DocPath & "\" & Filename

                            If File.Exists(FullPath) Then
                                If checkBreakPage.Checked Then
                                    Dim WordApp = New Microsoft.Office.Interop.Word.Application()
                                    Dim currentDoc = WordApp.Documents.Open(FullPath, [ReadOnly]:=True, Visible:=False)

                                    currentDoc.SaveAs(output & nodeID, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML)
                                    currentDoc.Close()
                                    WordApp.Quit()
                                End If
                            End If
                        End If

                    Next
                End If
            End If
        Next


        'C:\Users\Nguyen Van Hien\Documents\Test\1.docx
    End Sub
    Private Sub btPublish_Click(sender As Object, e As RibbonControlEventArgs) Handles btPublish.Click

        If dropSaveAs.SelectedItemIndex = 0 Then
            ExportDOC()
        End If
    End Sub

    Private Sub btWebsite_Click(sender As Object, e As RibbonControlEventArgs) Handles btWebsite.Click
        Dim webAddress As String = "http://tummosoftware.com"
        Process.Start(webAddress)
    End Sub

    Private Sub btVideo_Click(sender As Object, e As RibbonControlEventArgs) Handles btVideo.Click
        Dim webAddress As String = "https://youtu.be/uAakLsmKebs"
        Process.Start(webAddress)
    End Sub

    Private Sub btForum_Click(sender As Object, e As RibbonControlEventArgs) Handles btForum.Click
        Dim webAddress As String = "https://facebook.com/tummosoft"
        Process.Start(webAddress)
    End Sub

    Private Sub CheckBox1_Click(sender As Object, e As RibbonControlEventArgs) Handles CheckBox1.Click
        ExportEPUB()
    End Sub
End Class
