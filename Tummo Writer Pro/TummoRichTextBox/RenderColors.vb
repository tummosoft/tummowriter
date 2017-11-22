'
' * Created by SharpDevelop.
' * User: Nguyen Van Hien
' * Date: 1/15/2016
' * Time: 8:54 PM
' * 
' * To change this template use Tools | Options | Coding | Edit Standard Headers.
' 


Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace WordEditor
    Class RenderColors
        Inherits ToolStripProfessionalRenderer
        Private selected As Color = Color.FromArgb(75, SystemColors.MenuHighlight.R, SystemColors.MenuHighlight.G, SystemColors.MenuHighlight.B)
        Private rc As Rectangle

        Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
            ' Use a blank white background. 
            rc = New Rectangle(0, 0, e.Item.Width, e.Item.Height)
            e.Graphics.FillRectangle(Brushes.White, rc)
            rc = New Rectangle(2, 0, e.Item.Width - 13, e.Item.Height - 1)
            If e.Item.Selected Then
                Using br As Brush = New SolidBrush(selected)
                    ' Fill with selection color.
                    e.Graphics.FillRectangle(br, rc)
                End Using
                Using p As New Pen(ProfessionalColors.MenuItemBorder)
                    ' Draw selection rectangle around item.
                    e.Graphics.DrawRectangle(p, rc)
                End Using
            End If
            rc = New Rectangle(4, 2, 40, 11)
            ' Fill a rectangle in the color of the menu item.
            Using b As Brush = New SolidBrush(Color.FromName(e.Item.Name))
                e.Graphics.FillRectangle(b, rc)
            End Using
            e.Graphics.DrawRectangle(Pens.Black, rc)
            ' Draw text of selected color.
            Using fnt As New Font("Tahoma", 8, FontStyle.Regular)
                e.Graphics.DrawString(e.Item.Text, fnt, Brushes.Black, New Point(50, 1))
            End Using
        End Sub
    End Class
End Namespace



