'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/15/2016
' * Time: 8:53 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


Imports System
Imports System.Runtime.InteropServices
Imports System.Drawing.Printing
Imports System.Windows.Forms

Namespace WordEditor
    '''<Summary>
    ''' Adapted from Martin Muller's article:
    ''' "Getting WYSIWYG Print Results from a .NET RichTextBox",
    ''' MSDN, January 2003.
    ''' http://msdn.microsoft.com/en-us/library/ms996492.aspx
    '''
    ''' Print interfaces (PageSetup, PrintPreview, PrintDialog) have been added.
    '''</Summary>
    Friend Class PrintRichText
        Private pageSettings As PageSettings
        Private rtb As RichTextBox
        Private Const WM_USER As Int32 = &H400
        Private Const EM_FORMATRANGE As Int32 = WM_USER + 57
        Private toChar As Integer
        Private FirstCharEachPage As Integer

        <DllImport("user32.dll")>
        Private Shared Function SendMessage(hWnd As IntPtr, msg As Int32, wParam As Int32, lParam As IntPtr) As Int32
        End Function

        <StructLayout(LayoutKind.Sequential)>
        Private Structure RECT
            Public left As Integer
            Public top As Integer
            Public right As Integer
            Public bottom As Integer
        End Structure
        <StructLayout(LayoutKind.Sequential)>
        Private Structure CHARRANGE
            Public cpMin As Integer
            Public cpMax As Integer
        End Structure
        <StructLayout(LayoutKind.Sequential)>
        Private Structure FORMATRANGE
            Public hdc As IntPtr
            Public hdcTarget As IntPtr
            Public rc As RECT
            Public rcPage As RECT
            Public chrg As CHARRANGE
        End Structure

        ''' <summary>
        ''' Prints either the selected rich text, or all
        ''' the text from a RichTextBox. 
        ''' </summary>
        ''' <param name="rtbToPrint">ref The RichTextbox to print from.</param>
        ''' <param name="pageSet">A Printing PageSettings object, or null.
        ''' If null is used, then the rich text will be printed using the
        ''' default page settings. (Portrait, 8.5 x 11, 1 in. margins).
        ''' </param>
        Friend Sub New(ByRef rtbToPrint As RichTextBoxCustom, pageSet As PageSettings)
            rtb = rtbToPrint
            pageSettings = pageSet
        End Sub

        Public Sub PrintDialog()
            Using pd As New PrintDocument()
                Using dlg As New PrintDialog()
                    If pageSettings IsNot Nothing Then
                        pd.DefaultPageSettings = pageSettings
                    End If
                    AddHandler pd.BeginPrint, New PrintEventHandler(AddressOf printDoc_BeginPrint)
                    AddHandler pd.PrintPage, New PrintPageEventHandler(AddressOf printDoc_PrintPage)
                    AddHandler pd.EndPrint, New PrintEventHandler(AddressOf printDoc_EndPrint)
                    dlg.Document = pd
                    ' Allow user print selection option if there is
                    ' any selected text.
                    dlg.AllowSelection = rtb.SelectionLength > 0
                    dlg.AllowPrintToFile = True
                    If dlg.ShowDialog() = DialogResult.OK Then
                        pd.Print()
                    End If
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Displays a PageSetupDialog to the user.
        ''' </summary>
        Public Sub PageSetupDlg()
            Using pd As New PrintDocument()
                If pageSettings IsNot Nothing Then
                    pd.DefaultPageSettings = pageSettings
                End If
                AddHandler pd.BeginPrint, New PrintEventHandler(AddressOf printDoc_BeginPrint)
                AddHandler pd.PrintPage, New PrintPageEventHandler(AddressOf printDoc_PrintPage)
                AddHandler pd.EndPrint, New PrintEventHandler(AddressOf printDoc_EndPrint)
                Using ps As New PageSetupDialog()
                    ps.Document = pd
                    If ps.ShowDialog() = DialogResult.OK Then
                        pageSettings = pd.DefaultPageSettings
                    End If
                End Using
            End Using
        End Sub

        ''' <summary>
        ''' Displays a PrintPreview dialog to the user.
        ''' </summary>
        Public Sub PrintPreviewDlg()
            Using prev As New PrintPreviewDialog()
                Using pd As New PrintDocument()
                    If pageSettings IsNot Nothing Then
                        pd.DefaultPageSettings = pageSettings
                    End If
                    AddHandler pd.BeginPrint, New PrintEventHandler(AddressOf printDoc_BeginPrint)
                    AddHandler pd.PrintPage, New PrintPageEventHandler(AddressOf printDoc_PrintPage)
                    AddHandler pd.EndPrint, New PrintEventHandler(AddressOf printDoc_EndPrint)
                    prev.Document = pd
                    prev.PrintPreviewControl.Zoom = 1
                    prev.Width = rtb.Parent.Width - 200
                    prev.Height = rtb.Parent.Height - 150
                    prev.UseAntiAlias = True
                    prev.ShowIcon = False
                    prev.AutoScaleMode = AutoScaleMode.Dpi
                    prev.AutoSizeMode = AutoSizeMode.GrowOnly
                    AddHandler prev.Shown, New EventHandler(AddressOf printPrev_Shown)
                    prev.ShowDialog()
                End Using
            End Using
        End Sub

        Private Sub printPrev_Shown(sender As Object, e As EventArgs)
            DirectCast(sender, PrintPreviewDialog).Left = rtb.Parent.Left + 100
            DirectCast(sender, PrintPreviewDialog).Top = rtb.Parent.Top + 120
        End Sub

        ''' <summary>
        ''' Convert between 1/100 inch (unit used by the .NET framework)
        ''' and twips (1/1440 inch, used by Win32 API calls)
        ''' </summary>
        ''' <param name="n">Value in 1/100 inch</param>
        ''' <returns>Value in twips</returns>
        Private Function HundredthInchToTwips(n As Integer) As Int32
            ' return (Int32)(n * 14.4);
            ' changed method for more accuracy.
            Return CType(Math.Truncate(Decimal.Multiply(n, 14.4D)), Int32)
        End Function

        ''' <summary>
        ''' Free cached data from rich edit control after printing.
        ''' </summary>
        Private Sub FormatRangeDone()
            Dim lParam As New IntPtr(0)
            SendMessage(rtb.Handle, EM_FORMATRANGE, 0, lParam)
        End Sub

        ''' <summary>
        ''' Calculate or render the contents of our RichTextBox for printing.
        ''' </summary>
        ''' <param name="measureOnly">If true, only the calculation is performed,
        ''' otherwise the text is rendered as well</param>
        ''' <param name="e">The PrintPageEventArgs object from the
        ''' PrintPage event</param>
        ''' <param name="charFrom">Index of first character to be printed</param>
        ''' <param name="charTo">Index of last character to be printed</param>
        ''' <returns>(Index of last character that fitted on the
        ''' page) + 1</returns>
        Private Function FormatRangeText(measureOnly As Boolean, e As PrintPageEventArgs, charFrom As Integer, charTo As Integer) As Integer
            ' Specify which characters to print.
            Dim cr As CHARRANGE
            cr.cpMin = charFrom
            cr.cpMax = charTo
            ' Specify the area inside page margins.
            Dim rc As RECT
            rc.top = HundredthInchToTwips(e.MarginBounds.Top)
            rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom)
            rc.left = HundredthInchToTwips(e.MarginBounds.Left)
            rc.right = HundredthInchToTwips(e.MarginBounds.Right)
            ' Specify the page area.
            Dim rcPage As RECT
            rcPage.top = HundredthInchToTwips(e.PageBounds.Top)
            rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom)
            rcPage.left = HundredthInchToTwips(e.PageBounds.Left)
            rcPage.right = HundredthInchToTwips(e.PageBounds.Right)
            ' Get device context of output device.
            Dim hdc As IntPtr = e.Graphics.GetHdc()
            ' Fill in the FORMATRANGE struct.
            Dim fr As FORMATRANGE
            fr.chrg = cr
            fr.hdc = hdc
            fr.hdcTarget = hdc
            fr.rc = rc
            fr.rcPage = rcPage
            ' Non-Zero wParam means render, Zero means measure.
            Dim wParam As Int32 = (If(measureOnly, 0, 1))
            ' Allocate memory for the FORMATRANGE struct and
            ' copy the contents of our struct to this memory
            Dim lParam As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr))
            Marshal.StructureToPtr(fr, lParam, False)
            ' Send the actual Win32 message.
            Dim res As Integer = SendMessage(rtb.Handle, EM_FORMATRANGE, wParam, lParam)
            ' Free allocated memory.
            Marshal.FreeCoTaskMem(lParam)
            ' and release the device context.
            e.Graphics.ReleaseHdc(hdc)
            Return res
        End Function

        Private Sub printDoc_BeginPrint(sender As Object, e As PrintEventArgs)
            ' Set range of chars to print, either selection or all text.
            If DirectCast(sender, PrintDocument).PrinterSettings.PrintRange = PrintRange.Selection Then
                FirstCharEachPage = rtb.SelectionStart
                toChar = FirstCharEachPage + rtb.SelectionLength
            Else
                FirstCharEachPage = 0
                toChar = rtb.TextLength
            End If
        End Sub

        Private Sub printDoc_PrintPage(sender As Object, e As PrintPageEventArgs)
            ' calculate and render as much text as will fit
            ' on the page and remember the last character
            ' printed for the beginning of the next page.
            FirstCharEachPage = FormatRangeText(False, e, FirstCharEachPage, toChar)
            ' check if there are more pages to print
            If FirstCharEachPage < toChar Then
                e.HasMorePages = True
            Else
                e.HasMorePages = False
            End If
        End Sub

        Private Sub printDoc_EndPrint(sender As Object, e As PrintEventArgs)
            ' Clean up cached information.
            FormatRangeDone()
        End Sub
    End Class
End Namespace
