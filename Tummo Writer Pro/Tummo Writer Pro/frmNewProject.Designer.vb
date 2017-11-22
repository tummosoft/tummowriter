<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNewProject
    Inherits ComponentFactory.Krypton.Toolkit.KryptonForm ' System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNewProject))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonPanel1 = New ComponentFactory.Krypton.Toolkit.KryptonPanel()
        Me.txtAuthor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btCancel = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btOK = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.btBrowse = New ComponentFactory.Krypton.Toolkit.KryptonButton()
        Me.txtSaveTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.KryptonPanel1.SuspendLayout()
        CType(Me.btCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btOK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btBrowse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "blank_report.png")
        Me.ImageList1.Images.SetKeyName(1, "books_infront.png")
        Me.ImageList1.Images.SetKeyName(2, "books.png")
        Me.ImageList1.Images.SetKeyName(3, "bookshelf.png")
        Me.ImageList1.Images.SetKeyName(4, "books_stack.png")
        '
        'KryptonPanel1
        '
        Me.KryptonPanel1.Controls.Add(Me.txtAuthor)
        Me.KryptonPanel1.Controls.Add(Me.Label3)
        Me.KryptonPanel1.Controls.Add(Me.btCancel)
        Me.KryptonPanel1.Controls.Add(Me.btOK)
        Me.KryptonPanel1.Controls.Add(Me.btBrowse)
        Me.KryptonPanel1.Controls.Add(Me.txtSaveTo)
        Me.KryptonPanel1.Controls.Add(Me.Label2)
        Me.KryptonPanel1.Controls.Add(Me.txtName)
        Me.KryptonPanel1.Controls.Add(Me.Label1)
        Me.KryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KryptonPanel1.Location = New System.Drawing.Point(0, 0)
        Me.KryptonPanel1.Name = "KryptonPanel1"
        Me.KryptonPanel1.Size = New System.Drawing.Size(462, 167)
        Me.KryptonPanel1.TabIndex = 11
        '
        'txtAuthor
        '
        Me.txtAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthor.Location = New System.Drawing.Point(88, 51)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(352, 26)
        Me.txtAuthor.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Author"
        '
        'btCancel
        '
        Me.btCancel.DirtyPaletteCounter = 15
        Me.btCancel.Location = New System.Drawing.Point(254, 123)
        Me.btCancel.Name = "btCancel"
        Me.btCancel.Size = New System.Drawing.Size(90, 28)
        Me.btCancel.TabIndex = 4
        Me.btCancel.Text = "Cancel"
        Me.btCancel.Values.ExtraText = ""
        Me.btCancel.Values.Image = Nothing
        Me.btCancel.Values.ImageStates.ImageCheckedNormal = Nothing
        Me.btCancel.Values.ImageStates.ImageCheckedPressed = Nothing
        Me.btCancel.Values.ImageStates.ImageCheckedTracking = Nothing
        Me.btCancel.Values.Text = "Cancel"
        '
        'btOK
        '
        Me.btOK.DirtyPaletteCounter = 14
        Me.btOK.Enabled = False
        Me.btOK.Location = New System.Drawing.Point(350, 123)
        Me.btOK.Name = "btOK"
        Me.btOK.Size = New System.Drawing.Size(90, 28)
        Me.btOK.TabIndex = 5
        Me.btOK.Text = "OK"
        Me.btOK.Values.ExtraText = ""
        Me.btOK.Values.Image = Nothing
        Me.btOK.Values.ImageStates.ImageCheckedNormal = Nothing
        Me.btOK.Values.ImageStates.ImageCheckedPressed = Nothing
        Me.btOK.Values.ImageStates.ImageCheckedTracking = Nothing
        Me.btOK.Values.Text = "OK"
        '
        'btBrowse
        '
        Me.btBrowse.DirtyPaletteCounter = 13
        Me.btBrowse.Location = New System.Drawing.Point(350, 85)
        Me.btBrowse.Name = "btBrowse"
        Me.btBrowse.Size = New System.Drawing.Size(90, 28)
        Me.btBrowse.TabIndex = 3
        Me.btBrowse.Text = "Browse"
        Me.btBrowse.Values.ExtraText = ""
        Me.btBrowse.Values.Image = Nothing
        Me.btBrowse.Values.ImageStates.ImageCheckedNormal = Nothing
        Me.btBrowse.Values.ImageStates.ImageCheckedPressed = Nothing
        Me.btBrowse.Values.ImageStates.ImageCheckedTracking = Nothing
        Me.btBrowse.Values.Text = "Browse"
        '
        'txtSaveTo
        '
        Me.txtSaveTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaveTo.Location = New System.Drawing.Point(88, 85)
        Me.txtSaveTo.Name = "txtSaveTo"
        Me.txtSaveTo.Size = New System.Drawing.Size(256, 26)
        Me.txtSaveTo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(16, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Save to"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(88, 18)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(352, 26)
        Me.txtName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 16)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Project"
        '
        'frmNewProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 167)
        Me.Controls.Add(Me.KryptonPanel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNewProject"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Project"
        Me.TopMost = True
        CType(Me.KryptonPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.KryptonPanel1.ResumeLayout(False)
        Me.KryptonPanel1.PerformLayout()
        CType(Me.btCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btOK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btBrowse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As Windows.Forms.ImageList
    Friend WithEvents KryptonPanel1 As ComponentFactory.Krypton.Toolkit.KryptonPanel
    Friend WithEvents btBrowse As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtSaveTo As Windows.Forms.TextBox
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtName As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents btCancel As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents btOK As ComponentFactory.Krypton.Toolkit.KryptonButton
    Friend WithEvents txtAuthor As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
End Class
