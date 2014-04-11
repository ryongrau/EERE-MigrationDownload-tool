<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExtractSingleFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownLoadFromList = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateSelectedNodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenExtract = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseExtract = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveExtract = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsExtract = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImmediatePublishToggle = New System.Windows.Forms.ToolStripMenuItem()
        Me.StructureToggle = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetTargetDownloadFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnterLocalFIlePathBelowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalPathTextBox = New System.Windows.Forms.ToolStripTextBox()
        Me.CustomizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnterNodeCreationPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NodeCreationPage = New System.Windows.Forms.ToolStripTextBox()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.SourcePage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileURL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NodeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddNode = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.LocalFilePath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FileSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDownLoaded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateCreated = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Title = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Subject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OfficeSpecificTopics = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ActiveSheetBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Form1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Form1BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ActiveSheetBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ToolStripMenuItemEditNodes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActiveSheetBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Form1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Form1BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ActiveSheetBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1161, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExtractSingleFile, Me.DownLoadFromList, Me.UpdateSelectedNodesToolStripMenuItem, Me.ToolStripMenuItemEditNodes, Me.ToolStripSeparator2, Me.OpenExtract, Me.CloseExtract, Me.SaveExtract, Me.SaveAsExtract, Me.toolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExtractSingleFile
        '
        Me.ExtractSingleFile.Image = CType(resources.GetObject("ExtractSingleFile.Image"), System.Drawing.Image)
        Me.ExtractSingleFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExtractSingleFile.Name = "ExtractSingleFile"
        Me.ExtractSingleFile.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.ExtractSingleFile.Size = New System.Drawing.Size(331, 22)
        Me.ExtractSingleFile.Text = "&Extract MetaData From Selected File URLs"
        '
        'DownLoadFromList
        '
        Me.DownLoadFromList.Image = CType(resources.GetObject("DownLoadFromList.Image"), System.Drawing.Image)
        Me.DownLoadFromList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DownLoadFromList.Name = "DownLoadFromList"
        Me.DownLoadFromList.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.DownLoadFromList.Size = New System.Drawing.Size(331, 22)
        Me.DownLoadFromList.Text = "Add Media Files from Page &List"
        '
        'UpdateSelectedNodesToolStripMenuItem
        '
        Me.UpdateSelectedNodesToolStripMenuItem.Name = "UpdateSelectedNodesToolStripMenuItem"
        Me.UpdateSelectedNodesToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.UpdateSelectedNodesToolStripMenuItem.Size = New System.Drawing.Size(331, 22)
        Me.UpdateSelectedNodesToolStripMenuItem.Text = "&Update Selected Nodes"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(328, 6)
        '
        'OpenExtract
        '
        Me.OpenExtract.Image = CType(resources.GetObject("OpenExtract.Image"), System.Drawing.Image)
        Me.OpenExtract.Name = "OpenExtract"
        Me.OpenExtract.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenExtract.Size = New System.Drawing.Size(331, 22)
        Me.OpenExtract.Text = "&Open Metadata Extract"
        '
        'CloseExtract
        '
        Me.CloseExtract.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CloseExtract.Name = "CloseExtract"
        Me.CloseExtract.Size = New System.Drawing.Size(331, 22)
        Me.CloseExtract.Text = "&Close Metadata Extract"
        '
        'SaveExtract
        '
        Me.SaveExtract.Image = CType(resources.GetObject("SaveExtract.Image"), System.Drawing.Image)
        Me.SaveExtract.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveExtract.Name = "SaveExtract"
        Me.SaveExtract.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveExtract.Size = New System.Drawing.Size(331, 22)
        Me.SaveExtract.Text = "&Save"
        '
        'SaveAsExtract
        '
        Me.SaveAsExtract.Name = "SaveAsExtract"
        Me.SaveAsExtract.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveAsExtract.Size = New System.Drawing.Size(331, 22)
        Me.SaveAsExtract.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(328, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(331, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit Tool"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImmediatePublishToggle, Me.StructureToggle, Me.SetTargetDownloadFolder, Me.CustomizeToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.ToolsToolStripMenuItem.Text = "&Options"
        '
        'ImmediatePublishToggle
        '
        Me.ImmediatePublishToggle.CheckOnClick = True
        Me.ImmediatePublishToggle.Name = "ImmediatePublishToggle"
        Me.ImmediatePublishToggle.Size = New System.Drawing.Size(242, 22)
        Me.ImmediatePublishToggle.Text = "ImmediatePublish"
        Me.ImmediatePublishToggle.ToolTipText = "select this to enable moving directly to published state- not compatible with ADD" & _
    "ING a new node"
        '
        'StructureToggle
        '
        Me.StructureToggle.CheckOnClick = True
        Me.StructureToggle.Name = "StructureToggle"
        Me.StructureToggle.Size = New System.Drawing.Size(242, 22)
        Me.StructureToggle.Text = "Recreate www1.Folder Structure"
        Me.StructureToggle.ToolTipText = "Check this box in order for the tool to dynamically create folders matching the f" & _
    "older structure found on the server."
        '
        'SetTargetDownloadFolder
        '
        Me.SetTargetDownloadFolder.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnterLocalFIlePathBelowToolStripMenuItem, Me.LocalPathTextBox})
        Me.SetTargetDownloadFolder.Image = CType(resources.GetObject("SetTargetDownloadFolder.Image"), System.Drawing.Image)
        Me.SetTargetDownloadFolder.Name = "SetTargetDownloadFolder"
        Me.SetTargetDownloadFolder.Size = New System.Drawing.Size(242, 22)
        Me.SetTargetDownloadFolder.Text = "Select Target Download Folder"
        '
        'EnterLocalFIlePathBelowToolStripMenuItem
        '
        Me.EnterLocalFIlePathBelowToolStripMenuItem.Name = "EnterLocalFIlePathBelowToolStripMenuItem"
        Me.EnterLocalFIlePathBelowToolStripMenuItem.Size = New System.Drawing.Size(460, 22)
        Me.EnterLocalFIlePathBelowToolStripMenuItem.Text = "Enter Local File Path Below:"
        '
        'LocalPathTextBox
        '
        Me.LocalPathTextBox.Name = "LocalPathTextBox"
        Me.LocalPathTextBox.Size = New System.Drawing.Size(400, 23)
        Me.LocalPathTextBox.Text = "\\doe\dfsfr\"
        Me.LocalPathTextBox.ToolTipText = "This is the base path into which the downloads will be put-- when said feature is" & _
    " enabled-!"
        '
        'CustomizeToolStripMenuItem
        '
        Me.CustomizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnterNodeCreationPageToolStripMenuItem, Me.NodeCreationPage})
        Me.CustomizeToolStripMenuItem.Image = CType(resources.GetObject("CustomizeToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CustomizeToolStripMenuItem.Name = "CustomizeToolStripMenuItem"
        Me.CustomizeToolStripMenuItem.Size = New System.Drawing.Size(242, 22)
        Me.CustomizeToolStripMenuItem.Text = "Select Create Download Page"
        '
        'EnterNodeCreationPageToolStripMenuItem
        '
        Me.EnterNodeCreationPageToolStripMenuItem.Name = "EnterNodeCreationPageToolStripMenuItem"
        Me.EnterNodeCreationPageToolStripMenuItem.Size = New System.Drawing.Size(460, 22)
        Me.EnterNodeCreationPageToolStripMenuItem.Text = "Enter Node Creation Page Below: "
        '
        'NodeCreationPage
        '
        Me.NodeCreationPage.Name = "NodeCreationPage"
        Me.NodeCreationPage.Size = New System.Drawing.Size(400, 23)
        Me.NodeCreationPage.Text = "https://cms.doe.gov/node/add/download?gids_group%5B%5D=291"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel2, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 397)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1161, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripStatusLabel2.Text = "Progress:"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(59, 17)
        Me.ToolStripStatusLabel1.Text = "TaskLabel"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SourcePage, Me.FileURL, Me.NodeID, Me.AddNode, Me.LocalFilePath, Me.FileSize, Me.DateDownLoaded, Me.DateCreated, Me.Title, Me.Subject, Me.OfficeSpecificTopics})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1137, 358)
        Me.DataGridView1.TabIndex = 2
        '
        'SourcePage
        '
        Me.SourcePage.HeaderText = "SourcePage"
        Me.SourcePage.Name = "SourcePage"
        '
        'FileURL
        '
        Me.FileURL.HeaderText = "FileURL"
        Me.FileURL.Name = "FileURL"
        '
        'NodeID
        '
        Me.NodeID.HeaderText = "NodeID"
        Me.NodeID.Name = "NodeID"
        '
        'AddNode
        '
        Me.AddNode.HeaderText = "Add Download Node"
        Me.AddNode.Name = "AddNode"
        Me.AddNode.Text = "Add Download"
        Me.AddNode.ToolTipText = "Click here to add a button to the download. Make sure you set this in 'options'"
        '
        'LocalFilePath
        '
        Me.LocalFilePath.HeaderText = "LocalFilePath"
        Me.LocalFilePath.Name = "LocalFilePath"
        '
        'FileSize
        '
        Me.FileSize.HeaderText = "FileSize"
        Me.FileSize.Name = "FileSize"
        '
        'DateDownLoaded
        '
        Me.DateDownLoaded.HeaderText = "DateDownLoaded"
        Me.DateDownLoaded.Name = "DateDownLoaded"
        '
        'DateCreated
        '
        Me.DateCreated.HeaderText = "DateCreated"
        Me.DateCreated.Name = "DateCreated"
        '
        'Title
        '
        Me.Title.HeaderText = "Title"
        Me.Title.Name = "Title"
        '
        'Subject
        '
        Me.Subject.HeaderText = "Subject"
        Me.Subject.Name = "Subject"
        '
        'OfficeSpecificTopics
        '
        Me.OfficeSpecificTopics.HeaderText = "OfficeSpecificTopics"
        Me.OfficeSpecificTopics.Name = "OfficeSpecificTopics"
        '
        'ActiveSheetBindingSource1
        '
        Me.ActiveSheetBindingSource1.DataSource = GetType(EERE_MigrationDownload_tool.ActiveSheet)
        '
        'Form1BindingSource
        '
        Me.Form1BindingSource.DataSource = GetType(EERE_MigrationDownload_tool.Form1)
        '
        'Form1BindingSource1
        '
        Me.Form1BindingSource1.DataSource = GetType(EERE_MigrationDownload_tool.Form1)
        '
        'ActiveSheetBindingSource
        '
        Me.ActiveSheetBindingSource.DataSource = GetType(EERE_MigrationDownload_tool.ActiveSheet)
        '
        'ToolStripMenuItemEditNodes
        '
        Me.ToolStripMenuItemEditNodes.Name = "ToolStripMenuItemEditNodes"
        Me.ToolStripMenuItemEditNodes.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemEditNodes.Size = New System.Drawing.Size(331, 22)
        Me.ToolStripMenuItemEditNodes.Text = "E&dit Selected Node"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 419)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "EERE Download Migration Data Extraction Tool"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActiveSheetBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Form1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Form1BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ActiveSheetBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExtractSingleFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownLoadFromList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveExtract As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsExtract As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseExtract As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenExtract As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StructureToggle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SetTargetDownloadFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Form1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Form1BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ActiveSheetBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ActiveSheetBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EnterNodeCreationPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NodeCreationPage As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents EnterLocalFIlePathBelowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LocalPathTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents UpdateSelectedNodesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SourcePage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileURL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NodeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddNode As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents LocalFilePath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FileSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDownLoaded As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateCreated As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Title As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Subject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OfficeSpecificTopics As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImmediatePublishToggle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemEditNodes As System.Windows.Forms.ToolStripMenuItem

End Class
