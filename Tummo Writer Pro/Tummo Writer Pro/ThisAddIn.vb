Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Xml.Linq
Imports Word = Microsoft.Office.Interop.Word
Imports Office = Microsoft.Office.Core
Imports Microsoft.Office.Tools.Word

Public Class ThisAddIn
    Public Shared MyTab1 As New panelExplorer
    Public Shared myCustomTaskPane As Microsoft.Office.Tools.CustomTaskPane
    Public Shared panelDisplayed As Boolean
    Private MyPath As New TummoPath

    '  Public Shared tabStyle As New panelStyle

    Private Sub ThisAddIn_Startup() Handles Me.Startup

        myCustomTaskPane = CustomTaskPanes.Add(MyTab1, "Explorer")
        myCustomTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft
        myCustomTaskPane.Visible = True
        myCustomTaskPane.Width = 310

        '   myCustomTaskPane = CustomTaskPanes.Add(tabStyle, "Style")
        '  myCustomTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionRight
        '  myCustomTaskPane.Visible = True

        Dim app As Word.Application = Globals.ThisAddIn.Application
        '  AddHandler app.DocumentChange, AddressOf app_DocumentChange
        '  AddHandler app.DocumentBeforeSave, AddressOf app_DocumentBeforeSave
        AddHandler app.DocumentBeforeClose, AddressOf app_DocumentBeforeClose
        AddHandler app.DocumentOpen, AddressOf app_DocumentOpen
        AddHandler app.WindowActivate, AddressOf app_WindowActivate
        AddHandler app.NewDocument, AddressOf app_NewDocument

        MyPath.CheckStart()
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub

    Private Sub RemoveOrphanedTaskPanes()
        If Me.CustomTaskPanes.Count >= 2 Then
            For i As Integer = 2 To Me.CustomTaskPanes.Count
                Dim ctp = Me.CustomTaskPanes.Item(i)
                If ctp.Title = "Explorer" Then
                    Me.CustomTaskPanes.RemoveAt(i)
                End If
            Next
        End If

    End Sub

    Public Sub RemoveAllCalendarTaskPanes()
        For i As Integer = Me.CustomTaskPanes.Count To 1 Step -1
            Dim ctp = Me.CustomTaskPanes.Item(i)
            If ctp.Title = "Explorer" Then
                Me.CustomTaskPanes.RemoveAt(i)
            End If
        Next
    End Sub

    Public Sub AddCalendarTaskPane(ByVal doc As Word.Document)
        myCustomTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(
            New panelExplorer(), "Explorer", doc.ActiveWindow)
        myCustomTaskPane.DockPosition = Microsoft.Office.Core.MsoCTPDockPosition.msoCTPDockPositionLeft

        myCustomTaskPane.Visible = True
        myCustomTaskPane.Width = 310
        panelDisplayed = True
    End Sub

    Public Sub AddAllCalendarTaskPanes()
        If Globals.ThisAddIn.Application.Documents.Count > 0 Then
            If Globals.ThisAddIn.Application.ShowWindowsInTaskbar Then
                For Each _doc As Word.Document In Globals.ThisAddIn.Application.Documents
                    AddCalendarTaskPane(_doc)
                    myCustomTaskPane.Width = 310
                    panelDisplayed = True
                Next
            Else
                If Not panelDisplayed Then
                    AddCalendarTaskPane(Globals.ThisAddIn.Application.ActiveDocument)
                    myCustomTaskPane.Width = 310
                    panelDisplayed = True
                End If
            End If

        End If
    End Sub

    Public Sub OnDropOccurred(x As Integer, y As Integer, data As Object)
        'Get the Word range from the form's point location 
        Dim range As Microsoft.Office.Interop.Word.Range = DirectCast(Globals.ThisAddIn.Application.ActiveWindow.RangeFromPoint(x, y), Microsoft.Office.Interop.Word.Range)
        'Insert a dummy details table for the selected order
        Dim table As Word.Table = Me.Application.ActiveDocument.Tables.Add(range, 4, 4)

        table.Range.Font.Size = 8
        'table.Styl ("Table Grid 8")
        table.Rows(1).Cells(1).Range.Text = "Order Details"
        table.Rows(1).Cells(2).Range.Text = "Order Details"
        table.Rows(1).Cells(3).Range.Text = "Order Details"
        table.Rows(1).Cells(4).Range.Text = "Order Details"
        For i As Integer = 2 To 4
            For j As Integer = 1 To 4
                table.Rows(i).Cells(j).Range.Text = data.ToString()

            Next
        Next
    End Sub
    Private Sub app_WindowActivate(Doc As Word.Document, wn As Word.Window) 'Handles app.ApplicationEvents4_Event_NewDocument

    End Sub

    Private Sub app_DocumentBeforeClose(Doc As Word.Document, ByRef Cancel As Boolean)
        'RemoveOrphanedTaskPanes()
    End Sub

    Private Sub app_NewDocument(Doc As Word.Document)

        ' If panelDisplayed And Me.Application.ShowWindowsInTaskbar Then
        'AddCalendarTaskPane(Doc)
        ' End If

    End Sub

    Private Sub app_DocumentOpen(Doc As Word.Document)
        '   RemoveOrphanedTaskPanes()
        ' If panelDisplayed And Me.Application.ShowWindowsInTaskbar Then
        'AddCalendarTaskPane(Doc)
        'End If
    End Sub

End Class
