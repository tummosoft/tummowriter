Partial Class rMenu
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
   Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim RibbonDropDownItemImpl1 As Microsoft.Office.Tools.Ribbon.RibbonDropDownItem = Me.Factory.CreateRibbonDropDownItem
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.btNewProject = Me.Factory.CreateRibbonButton
        Me.Separator3 = Me.Factory.CreateRibbonSeparator
        Me.btLoadProject = Me.Factory.CreateRibbonButton
        Me.Group2 = Me.Factory.CreateRibbonGroup
        Me.btShowPanel = Me.Factory.CreateRibbonButton
        Me.Separator4 = Me.Factory.CreateRibbonSeparator
        Me.dropSaveAs = Me.Factory.CreateRibbonDropDown
        Me.checkBreakPage = Me.Factory.CreateRibbonCheckBox
        Me.btPublish = Me.Factory.CreateRibbonButton
        Me.Group4 = Me.Factory.CreateRibbonGroup
        Me.btAbout = Me.Factory.CreateRibbonButton
        Me.Separator2 = Me.Factory.CreateRibbonSeparator
        Me.btWebsite = Me.Factory.CreateRibbonButton
        Me.btVideo = Me.Factory.CreateRibbonButton
        Me.btForum = Me.Factory.CreateRibbonButton
        Me.CheckBox1 = Me.Factory.CreateRibbonCheckBox
        Me.Tab1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.Group2.SuspendLayout()
        Me.Group4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office
        Me.Tab1.Groups.Add(Me.Group1)
        Me.Tab1.Groups.Add(Me.Group2)
        Me.Tab1.Groups.Add(Me.Group4)
        Me.Tab1.Label = "Tummo Writer Pro"
        Me.Tab1.Name = "Tab1"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.btNewProject)
        Me.Group1.Items.Add(Me.Separator3)
        Me.Group1.Items.Add(Me.btLoadProject)
        Me.Group1.Label = "Project"
        Me.Group1.Name = "Group1"
        '
        'btNewProject
        '
        Me.btNewProject.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btNewProject.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.document_new
        Me.btNewProject.Label = "New Project"
        Me.btNewProject.Name = "btNewProject"
        Me.btNewProject.ShowImage = True
        '
        'Separator3
        '
        Me.Separator3.Name = "Separator3"
        '
        'btLoadProject
        '
        Me.btLoadProject.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btLoadProject.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.open_folder1
        Me.btLoadProject.Label = "Open"
        Me.btLoadProject.Name = "btLoadProject"
        Me.btLoadProject.ShowImage = True
        '
        'Group2
        '
        Me.Group2.Items.Add(Me.btShowPanel)
        Me.Group2.Items.Add(Me.Separator4)
        Me.Group2.Items.Add(Me.dropSaveAs)
        Me.Group2.Items.Add(Me.checkBreakPage)
        Me.Group2.Items.Add(Me.CheckBox1)
        Me.Group2.Items.Add(Me.btPublish)
        Me.Group2.Label = "Tool"
        Me.Group2.Name = "Group2"
        '
        'btShowPanel
        '
        Me.btShowPanel.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btShowPanel.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.tab_content
        Me.btShowPanel.Label = "Show Panel"
        Me.btShowPanel.Name = "btShowPanel"
        Me.btShowPanel.ShowImage = True
        '
        'Separator4
        '
        Me.Separator4.Name = "Separator4"
        '
        'dropSaveAs
        '
        RibbonDropDownItemImpl1.Label = "DOCX"
        Me.dropSaveAs.Items.Add(RibbonDropDownItemImpl1)
        Me.dropSaveAs.Label = "Save As"
        Me.dropSaveAs.Name = "dropSaveAs"
        '
        'checkBreakPage
        '
        Me.checkBreakPage.Checked = True
        Me.checkBreakPage.Label = "Break Page"
        Me.checkBreakPage.Name = "checkBreakPage"
        '
        'btPublish
        '
        Me.btPublish.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btPublish.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.compare
        Me.btPublish.Label = "Build"
        Me.btPublish.Name = "btPublish"
        Me.btPublish.ShowImage = True
        '
        'Group4
        '
        Me.Group4.Items.Add(Me.btAbout)
        Me.Group4.Items.Add(Me.Separator2)
        Me.Group4.Items.Add(Me.btWebsite)
        Me.Group4.Items.Add(Me.btVideo)
        Me.Group4.Items.Add(Me.btForum)
        Me.Group4.Label = "Help"
        Me.Group4.Name = "Group4"
        '
        'btAbout
        '
        Me.btAbout.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btAbout.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.About_icon
        Me.btAbout.Label = "About"
        Me.btAbout.Name = "btAbout"
        Me.btAbout.ShowImage = True
        '
        'Separator2
        '
        Me.Separator2.Name = "Separator2"
        '
        'btWebsite
        '
        Me.btWebsite.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.home_page_icon__1_
        Me.btWebsite.Label = "Website"
        Me.btWebsite.Name = "btWebsite"
        Me.btWebsite.ShowImage = True
        '
        'btVideo
        '
        Me.btVideo.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.YouTube_icon
        Me.btVideo.Label = "Demo Video"
        Me.btVideo.Name = "btVideo"
        Me.btVideo.ShowImage = True
        '
        'btForum
        '
        Me.btForum.Image = Global.Tummo_Writer_Pro.My.Resources.Resources.comment
        Me.btForum.Label = "Support"
        Me.btForum.Name = "btForum"
        Me.btForum.ShowImage = True
        '
        'CheckBox1
        '
        Me.CheckBox1.Checked = True
        Me.CheckBox1.Label = "Page Count"
        Me.CheckBox1.Name = "CheckBox1"
        '
        'rMenu
        '
        Me.Name = "rMenu"
        Me.RibbonType = "Microsoft.Word.Document"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.Group2.ResumeLayout(False)
        Me.Group2.PerformLayout()
        Me.Group4.ResumeLayout(False)
        Me.Group4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents Group2 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btNewProject As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btShowPanel As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DropDown1 As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents DropDown3 As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents Separator1 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents Group4 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btAbout As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btVideo As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btWebsite As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Separator2 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents btForum As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btLoadProject As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Separator3 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents ToggleButton1 As Microsoft.Office.Tools.Ribbon.RibbonToggleButton
    Friend WithEvents btPublish As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents dropSaveAs As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents checkBreakPage As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
    Friend WithEvents Separator4 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents CheckBox1 As Microsoft.Office.Tools.Ribbon.RibbonCheckBox
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property rMenu() As rMenu
        Get
            Return Me.GetRibbon(Of rMenu)()
        End Get
    End Property
End Class
