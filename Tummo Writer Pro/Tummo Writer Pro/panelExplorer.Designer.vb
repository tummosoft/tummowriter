<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class panelExplorer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(panelExplorer))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.mnListFile = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mn_listFile_Insert = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabFile = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.treeProject = New FastTreeNS.FastTree()
        Me.mnProject = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnOpen1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnNewFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnNewDocument = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnCheckAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnUnCheckAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabProject = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.listFile = New FastTreeNS.FastList()
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
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.KryptonManager1 = New ComponentFactory.Krypton.Toolkit.KryptonManager(Me.components)
        Me.mnListFile.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabFile.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.mnProject.SuspendLayout()
        Me.tabProject.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnListFile
        '
        Me.mnListFile.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnListFile.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mn_listFile_Insert, Me.ToolStripSeparator1, Me.ToolStripMenuItem2, Me.ToolStripSeparator2, Me.ToolStripMenuItem3})
        Me.mnListFile.Name = "mnListFile"
        Me.mnListFile.Size = New System.Drawing.Size(145, 82)
        '
        'mn_listFile_Insert
        '
        Me.mn_listFile_Insert.Name = "mn_listFile_Insert"
        Me.mn_listFile_Insert.Size = New System.Drawing.Size(144, 22)
        Me.mn_listFile_Insert.Text = "Insert Item"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(141, 6)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(144, 22)
        Me.ToolStripMenuItem2.Text = "Open Item"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(141, 6)
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(144, 22)
        Me.ToolStripMenuItem3.Text = "Remove Item"
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabFile)
        Me.tabControl1.Controls.Add(Me.tabProject)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.ImageList = Me.ImageList1
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(308, 418)
        Me.tabControl1.TabIndex = 5
        '
        'tabFile
        '
        Me.tabFile.Controls.Add(Me.Panel4)
        Me.tabFile.Location = New System.Drawing.Point(4, 24)
        Me.tabFile.Name = "tabFile"
        Me.tabFile.Size = New System.Drawing.Size(300, 390)
        Me.tabFile.TabIndex = 2
        Me.tabFile.Text = "Project"
        Me.tabFile.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.treeProject)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(300, 390)
        Me.Panel4.TabIndex = 1
        '
        'treeProject
        '
        Me.treeProject.AutoScroll = True
        Me.treeProject.AutoScrollMinSize = New System.Drawing.Size(0, 73)
        Me.treeProject.BackColor = System.Drawing.SystemColors.Window
        Me.treeProject.ContextMenuStrip = Me.mnProject
        Me.treeProject.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeProject.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeProject.FullItemSelect = True
        Me.treeProject.HotTracking = True
        Me.treeProject.HotTrackingColor = System.Drawing.Color.SteelBlue
        Me.treeProject.ImageCheckBoxOff = CType(resources.GetObject("treeProject.ImageCheckBoxOff"), System.Drawing.Image)
        Me.treeProject.ImageCheckBoxOn = CType(resources.GetObject("treeProject.ImageCheckBoxOn"), System.Drawing.Image)
        Me.treeProject.ImageCollapse = CType(resources.GetObject("treeProject.ImageCollapse"), System.Drawing.Image)
        Me.treeProject.ImageDefaultIcon = CType(resources.GetObject("treeProject.ImageDefaultIcon"), System.Drawing.Image)
        Me.treeProject.ImageExpand = CType(resources.GetObject("treeProject.ImageExpand"), System.Drawing.Image)
        Me.treeProject.IsEditMode = False
        Me.treeProject.ItemHeightDefault = 20
        Me.treeProject.Location = New System.Drawing.Point(0, 0)
        Me.treeProject.Margin = New System.Windows.Forms.Padding(3, 5, 3, 3)
        Me.treeProject.Name = "treeProject"
        Me.treeProject.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.treeProject.SelectionColor = System.Drawing.Color.SteelBlue
        Me.treeProject.ShowCheckBoxes = True
        Me.treeProject.ShowExpandBoxes = True
        Me.treeProject.ShowIcons = True
        Me.treeProject.ShowRootNode = True
        Me.treeProject.Size = New System.Drawing.Size(300, 390)
        Me.treeProject.TabIndex = 1
        '
        'mnProject
        '
        Me.mnProject.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.mnProject.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnOpen1, Me.ToolStripSeparator7, Me.mnNewFolder, Me.ToolStripSeparator4, Me.mnNewDocument, Me.ToolStripSeparator5, Me.mnEdit, Me.ToolStripSeparator6, Me.mnDelete, Me.ToolStripSeparator8, Me.mnCheckAll, Me.mnUnCheckAll})
        Me.mnProject.Name = "mnListFile"
        Me.mnProject.Size = New System.Drawing.Size(158, 188)
        '
        'mnOpen1
        '
        Me.mnOpen1.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.open_folder
        Me.mnOpen1.Name = "mnOpen1"
        Me.mnOpen1.Size = New System.Drawing.Size(157, 22)
        Me.mnOpen1.Text = "Open"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(154, 6)
        '
        'mnNewFolder
        '
        Me.mnNewFolder.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.folder
        Me.mnNewFolder.Name = "mnNewFolder"
        Me.mnNewFolder.Size = New System.Drawing.Size(157, 22)
        Me.mnNewFolder.Text = "New Folder"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(154, 6)
        '
        'mnNewDocument
        '
        Me.mnNewDocument.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.document_empty
        Me.mnNewDocument.Name = "mnNewDocument"
        Me.mnNewDocument.Size = New System.Drawing.Size(157, 22)
        Me.mnNewDocument.Text = "New Document"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(154, 6)
        '
        'mnEdit
        '
        Me.mnEdit.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.document_editing
        Me.mnEdit.Name = "mnEdit"
        Me.mnEdit.Size = New System.Drawing.Size(157, 22)
        Me.mnEdit.Text = "Edit"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(154, 6)
        '
        'mnDelete
        '
        Me.mnDelete.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.cancel
        Me.mnDelete.Name = "mnDelete"
        Me.mnDelete.Size = New System.Drawing.Size(157, 22)
        Me.mnDelete.Text = "Delete"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(154, 6)
        '
        'mnCheckAll
        '
        Me.mnCheckAll.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.check_box_mix
        Me.mnCheckAll.Name = "mnCheckAll"
        Me.mnCheckAll.Size = New System.Drawing.Size(157, 22)
        Me.mnCheckAll.Text = "Check All"
        '
        'mnUnCheckAll
        '
        Me.mnUnCheckAll.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.check_box_uncheck
        Me.mnUnCheckAll.Name = "mnUnCheckAll"
        Me.mnUnCheckAll.Size = New System.Drawing.Size(157, 22)
        Me.mnUnCheckAll.Text = "Uncheck All"
        '
        'tabProject
        '
        Me.tabProject.Controls.Add(Me.Panel1)
        Me.tabProject.ImageIndex = 3
        Me.tabProject.Location = New System.Drawing.Point(4, 24)
        Me.tabProject.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabProject.Name = "tabProject"
        Me.tabProject.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tabProject.Size = New System.Drawing.Size(300, 390)
        Me.tabProject.TabIndex = 0
        Me.tabProject.Text = "Files"
        Me.tabProject.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(294, 382)
        Me.Panel1.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.listFile)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 31)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(294, 351)
        Me.Panel3.TabIndex = 2
        '
        'listFile
        '
        Me.listFile.AllowDragItems = True
        Me.listFile.AutoScroll = True
        Me.listFile.AutoScrollMinSize = New System.Drawing.Size(0, 2202)
        Me.listFile.BackColor = System.Drawing.SystemColors.Window
        Me.listFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.listFile.ContextMenuStrip = Me.mnListFile
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
        Me.listFile.Location = New System.Drawing.Point(0, 0)
        Me.listFile.Margin = New System.Windows.Forms.Padding(4)
        Me.listFile.Name = "listFile"
        Me.listFile.SelectionColor = System.Drawing.Color.SteelBlue
        Me.listFile.ShowIcons = True
        Me.listFile.Size = New System.Drawing.Size(294, 351)
        Me.listFile.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(294, 31)
        Me.Panel2.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboPath, Me.toolFilter, Me.btRun, Me.ToolStripSeparator3, Me.btAddBookMark, Me.dropBookMark})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(294, 25)
        Me.ToolStrip1.TabIndex = 0
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
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder_blue.png")
        Me.ImageList1.Images.SetKeyName(1, "document_editing.png")
        Me.ImageList1.Images.SetKeyName(2, "report_green.png")
        Me.ImageList1.Images.SetKeyName(3, "folder.png")
        Me.ImageList1.Images.SetKeyName(4, "file_extension_doc.png")
        Me.ImageList1.Images.SetKeyName(5, "file_extension_jpeg.png")
        Me.ImageList1.Images.SetKeyName(6, "file_extension_gif.png")
        Me.ImageList1.Images.SetKeyName(7, "file_extension_jpg.png")
        Me.ImageList1.Images.SetKeyName(8, "file_extension_png.png")
        Me.ImageList1.Images.SetKeyName(9, "file_extension_rtf.png")
        Me.ImageList1.Images.SetKeyName(10, "file_extension_txt.png")
        Me.ImageList1.Images.SetKeyName(11, "filter_advanced.png")
        Me.ImageList1.Images.SetKeyName(12, "find.png")
        Me.ImageList1.Images.SetKeyName(13, "folder.png")
        Me.ImageList1.Images.SetKeyName(14, "file_extension_7z.png")
        Me.ImageList1.Images.SetKeyName(15, "file_extension_exe.png")
        Me.ImageList1.Images.SetKeyName(16, "file_extension_rar.png")
        Me.ImageList1.Images.SetKeyName(17, "file_extension_xls.png")
        Me.ImageList1.Images.SetKeyName(18, "play_select.png")
        Me.ImageList1.Images.SetKeyName(19, "paragraph_spacing.png")
        Me.ImageList1.Images.SetKeyName(20, "home_page.png")
        Me.ImageList1.Images.SetKeyName(21, "check_box_mix.png")
        Me.ImageList1.Images.SetKeyName(22, "check_box_uncheck.png")
        '
        'panelExplorer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "panelExplorer"
        Me.Size = New System.Drawing.Size(308, 418)
        Me.mnListFile.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.tabFile.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.mnProject.ResumeLayout(False)
        Me.tabProject.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As Windows.Forms.FolderBrowserDialog
    Friend WithEvents mnListFile As Windows.Forms.ContextMenuStrip
    Friend WithEvents mn_listFile_Insert As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabControl1 As Windows.Forms.TabControl
    Friend WithEvents tabProject As Windows.Forms.TabPage
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents listFile As FastTreeNS.FastList
    Friend WithEvents ImageList1 As Windows.Forms.ImageList
    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents cboPath As Windows.Forms.ToolStripComboBox
    Friend WithEvents btRun As Windows.Forms.ToolStripButton
    Friend WithEvents btAddBookMark As Windows.Forms.ToolStripButton
    Friend WithEvents KryptonManager1 As ComponentFactory.Krypton.Toolkit.KryptonManager
    Friend WithEvents toolFilter As Windows.Forms.ToolStripSplitButton
    Friend WithEvents fFolder As Windows.Forms.ToolStripMenuItem
    Friend WithEvents fFilter As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As Windows.Forms.ToolStripSeparator
    Friend WithEvents dropBookMark As Windows.Forms.ToolStripDropDownButton
    Friend WithEvents fSearch As Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabFile As Windows.Forms.TabPage
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents treeProject As FastTreeNS.FastTree
    Friend WithEvents mnProject As Windows.Forms.ContextMenuStrip
    Friend WithEvents mnNewFolder As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnNewDocument As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnEdit As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnDelete As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnOpen1 As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnCheckAll As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnUnCheckAll As Windows.Forms.ToolStripMenuItem
End Class
