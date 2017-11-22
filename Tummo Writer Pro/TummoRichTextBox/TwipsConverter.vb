'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/15/2016
' * Time: 8:55 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


' Freeware. Written by Matt Fomich.
' Performs conversions between pixels and
' twips, based on Windows display settings.

Imports System
Imports System.Runtime.InteropServices

Namespace WordEditor
    Public Class TwipsConverter
        Private Const HORIZONTAL As Byte = 0
        Private Const VERTICAL As Byte = 1
        Const WU_LOGPIXELSX As Int16 = 88
        Const WU_LOGPIXELSY As Int16 = 90
        <DllImport("user32.dll", EntryPoint:="GetDC")>
        Public Shared Function GetDC(hWnd As Integer) As Integer
        End Function
        <DllImport("user32.dll", EntryPoint:="ReleaseDC")>
        Public Shared Function ReleaseDC(hwnd As Integer, hDc As Integer) As Integer
        End Function
        <DllImport("gdi32", EntryPoint:="GetDeviceCaps")>
        Private Shared Function GetDeviceCaps(hdc As Integer, nIndex As Integer) As Integer
        End Function
        Public ReadOnly horizontalPixelsPerTwip As Single
        Public ReadOnly horizontalTwipsPerPixel As Single

        ''' <summary>
        ''' Initializes TwipsConverter class that performs conversions
        ''' between pixels and twips.
        ''' </summary>
        Public Sub New()
            horizontalPixelsPerTwip = twipsToPixels(1, HORIZONTAL)
            horizontalTwipsPerPixel = CSng(Decimal.Divide(1D, CDec(horizontalPixelsPerTwip)))
        End Sub

        ''' <summary>
        ''' Converts Horizontal twips to pixels.
        ''' </summary>
        ''' <param name="twips">The twips value to convert.</param>
        ''' <returns></returns>
        Public Function ConvertHTwipsToPixels(twips As Integer) As Integer
            Return CInt(Math.Truncate(CSng(twips * horizontalPixelsPerTwip)))
            'return decimal.Multiply(twips, horizontalPixelsPerTwip);
        End Function

        ''' <summary>
        ''' Converts pixels to horizontal twips.
        ''' </summary>
        ''' <param name="pixels">the pixel value to convert to horizontal twips.</param>
        ''' <returns>Returns the horizontal twips value in decimals.</returns>
        Public Function ConvertPixelsToHTwips(pixels As Integer) As Integer
            ' return decimal.Multiply(pixels, horizontalTwipsPerPixel);
            Return CInt(Math.Truncate(pixels * horizontalTwipsPerPixel))
        End Function

        ''' <summary>
        ''' Converts Twips to Pixels based on Windows graphic display.
        ''' </summary>
        ''' <param name="twips">The twips to convert to pixels.</param>
        ''' <param name="direction">Zero for horizontal, any other number for vertical.</param>
        ''' <returns>Returns the pixel value in decimals.</returns>
        Private Function twipsToPixels(twips As Integer, direction As Integer) As Single
            Dim dc As Integer
            Dim pixelsPerInch As Integer
            Dim twipsPerInch As Int16 = 1440
            dc = GetDC(0)
            If direction = 0 Then
                ' Horizontal
                pixelsPerInch = GetDeviceCaps(dc, WU_LOGPIXELSX)
            Else
                ' Vertical
                pixelsPerInch = GetDeviceCaps(dc, WU_LOGPIXELSY)
            End If
            dc = ReleaseDC(0, dc)
            If dc <> 1 Then
                Throw New Exception("The device context used was not released.")
            End If
            Dim d As Decimal = Decimal.Divide(twips, twipsPerInch)
            Return CSng(d * pixelsPerInch)
        End Function
    End Class
End Namespace
