<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FastTree1 = New FastTreeNS.FastTree()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(394, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 37)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(394, 54)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 37)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FastTree1
        '
        Me.FastTree1.AutoScroll = True
        Me.FastTree1.AutoScrollMinSize = New System.Drawing.Size(0, 59)
        Me.FastTree1.BackColor = System.Drawing.SystemColors.Window
        Me.FastTree1.ImageCheckBoxOff = CType(resources.GetObject("FastTree1.ImageCheckBoxOff"), System.Drawing.Image)
        Me.FastTree1.ImageCheckBoxOn = CType(resources.GetObject("FastTree1.ImageCheckBoxOn"), System.Drawing.Image)
        Me.FastTree1.ImageCollapse = CType(resources.GetObject("FastTree1.ImageCollapse"), System.Drawing.Image)
        Me.FastTree1.ImageDefaultIcon = CType(resources.GetObject("FastTree1.ImageDefaultIcon"), System.Drawing.Image)
        Me.FastTree1.ImageExpand = CType(resources.GetObject("FastTree1.ImageExpand"), System.Drawing.Image)
        Me.FastTree1.IsEditMode = False
        Me.FastTree1.Location = New System.Drawing.Point(25, 12)
        Me.FastTree1.Name = "FastTree1"
        Me.FastTree1.ShowExpandBoxes = True
        Me.FastTree1.ShowIcons = True
        Me.FastTree1.ShowRootNode = True
        Me.FastTree1.Size = New System.Drawing.Size(346, 344)
        Me.FastTree1.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(397, 97)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 37)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Load to Tree"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 368)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.FastTree1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents FastTree1 As FastTreeNS.FastTree
    Friend WithEvents Button3 As Button
End Class
