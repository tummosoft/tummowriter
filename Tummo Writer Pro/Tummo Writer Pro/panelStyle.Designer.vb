<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class panelStyle
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panelStyle))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.cboPath = New System.Windows.Forms.ToolStripComboBox()
        Me.toolFilter = New System.Windows.Forms.ToolStripSplitButton()
        Me.fFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.fFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.fSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.btRun = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btAddBookMark = New System.Windows.Forms.ToolStripButton()
        Me.dropBookMark = New System.Windows.Forms.ToolStripDropDownButton()
        Me.listFile = New FastTreeNS.FastList()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ImageList = Me.ImageList1
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(290, 420)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.ImageKey = "style.png"
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(282, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Style"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.ImageKey = "note.png"
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(282, 392)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Note"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "style.png")
        Me.ImageList1.Images.SetKeyName(1, "note.png")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.listFile)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(276, 386)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(276, 28)
        Me.Panel2.TabIndex = 2
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPath, Me.toolFilter, Me.btRun, Me.ToolStripSeparator3, Me.btAddBookMark, Me.dropBookMark})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(276, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'cboPath
        '
        Me.cboPath.Items.AddRange(New Object() {"*.rtf *.doc *.docx"})
        Me.cboPath.Name = "cboPath"
        Me.cboPath.Size = New System.Drawing.Size(150, 25)
        Me.cboPath.Text = "c:\"
        '
        'toolFilter
        '
        Me.toolFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolFilter.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fFolder, Me.fFilter, Me.fSearch})
        Me.toolFilter.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.folder_explorer
        Me.toolFilter.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolFilter.Name = "toolFilter"
        Me.toolFilter.Size = New System.Drawing.Size(32, 22)
        Me.toolFilter.ToolTipText = "Option"
        '
        'fFolder
        '
        Me.fFolder.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.folder_explorer
        Me.fFolder.Name = "fFolder"
        Me.fFolder.Size = New System.Drawing.Size(109, 22)
        Me.fFolder.Tag = "0"
        Me.fFolder.Text = "Folder"
        '
        'fFilter
        '
        Me.fFilter.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.filter
        Me.fFilter.Name = "fFilter"
        Me.fFilter.Size = New System.Drawing.Size(109, 22)
        Me.fFilter.Tag = "1"
        Me.fFilter.Text = "Filter"
        '
        'fSearch
        '
        Me.fSearch.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.find
        Me.fSearch.Name = "fSearch"
        Me.fSearch.Size = New System.Drawing.Size(109, 22)
        Me.fSearch.Tag = "2"
        Me.fSearch.Text = "Search"
        '
        'btRun
        '
        Me.btRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btRun.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.agt_action_success
        Me.btRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btRun.Name = "btRun"
        Me.btRun.Size = New System.Drawing.Size(23, 22)
        Me.btRun.ToolTipText = "Run"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btAddBookMark
        '
        Me.btAddBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btAddBookMark.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.bookmark_red
        Me.btAddBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btAddBookMark.Name = "btAddBookMark"
        Me.btAddBookMark.Size = New System.Drawing.Size(23, 22)
        Me.btAddBookMark.ToolTipText = "Bookmark this address"
        '
        'dropBookMark
        '
        Me.dropBookMark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dropBookMark.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.bookmark
        Me.dropBookMark.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.dropBookMark.Name = "dropBookMark"
        Me.dropBookMark.Size = New System.Drawing.Size(29, 22)
        Me.dropBookMark.Text = "ToolStripDropDownButton1"
        Me.dropBookMark.ToolTipText = "Bookmarks"
        '
        'listFile
        '
        Me.listFile.AllowDragItems = True
        Me.listFile.AutoScroll = True
        Me.listFile.AutoScrollMinSize = New System.Drawing.Size(0, 2202)
        Me.listFile.BackColor = System.Drawing.SystemColors.Window
        Me.listFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listFile.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listFile.FullItemSelect = True
        Me.listFile.HotTracking = True
        Me.listFile.HotTrackingColor = System.Drawing.Color.SteelBlue
        Me.listFile.ImageCheckBoxOff = CType(resources.GetObject("listFile.ImageCheckBoxOff"), System.Drawing.Image)
        Me.listFile.ImageCheckBoxOn = CType(resources.GetObject("listFile.ImageCheckBoxOn"), System.Drawing.Image)
        Me.listFile.ImageCollapse = CType(resources.GetObject("listFile.ImageCollapse"), System.Drawing.Image)
        Me.listFile.ImageDefaultIcon = CType(resources.GetObject("listFile.ImageDefaultIcon"), System.Drawing.Image)
        Me.listFile.ImageExpand = CType(resources.GetObject("listFile.ImageExpand"), System.Drawing.Image)
        Me.listFile.IsEditMode = False
        Me.listFile.ItemCount = 100
        Me.listFile.ItemHeightDefault = 20
        Me.listFile.Location = New System.Drawing.Point(0, 28)
        Me.listFile.Margin = New System.Windows.Forms.Padding(4)
        Me.listFile.Name = "listFile"
        Me.listFile.SelectionColor = System.Drawing.Color.SteelBlue
        Me.listFile.ShowIcons = True
        Me.listFile.Size = New System.Drawing.Size(276, 358)
        Me.listFile.TabIndex = 3
        '
        'panelStyle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "panelStyle"
        Me.Size = New System.Drawing.Size(290, 420)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents ImageList1 As Windows.Forms.ImageList
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents cboPath As Windows.Forms.ToolStripComboBox
    Friend WithEvents toolFilter As Windows.Forms.ToolStripSplitButton
    Friend WithEvents fFolder As Windows.Forms.ToolStripMenuItem
    Friend WithEvents fFilter As Windows.Forms.ToolStripMenuItem
    Friend WithEvents fSearch As Windows.Forms.ToolStripMenuItem
    Friend WithEvents btRun As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents btAddBookMark As Windows.Forms.ToolStripButton
    Friend WithEvents dropBookMark As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents listFile As FastTreeNS.FastList
End Class
