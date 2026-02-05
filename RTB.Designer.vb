<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RTB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        components = New ComponentModel.Container()
        Dim lblPrompt As Label
        Dim Label1 As Label
        lyDescriereRevizie = New TableLayoutPanel()
        txtExplicatieScurta = New TextBox()
        lyDescriereLungaLabel = New TableLayoutPanel()
        btnAtasteazaDocumente = New Button()
        lyDescrierePeLung = New TableLayoutPanel()
        pnlExplicatieHost = New Panel()
        splDescriereLunga = New SplitContainer()
        tsRTB = New ToolStrip()
        bBold = New ToolStripButton()
        bItalic = New ToolStripButton()
        bUnderline = New ToolStripButton()
        bColorText = New ToolStripButton()
        bBgColor = New ToolStripButton()
        rtbExplicatieLunga = New RichTextBox()
        flyButoane = New FlowLayoutPanel()
        ToolTip1 = New ToolTip(components)
        pCtx = New ContextMenuStrip(components)
        tsiEliminaAtt = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        tsiDeschideAtt = New ToolStripMenuItem()
        lblPrompt = New Label()
        Label1 = New Label()
        lyDescriereRevizie.SuspendLayout()
        lyDescriereLungaLabel.SuspendLayout()
        lyDescrierePeLung.SuspendLayout()
        pnlExplicatieHost.SuspendLayout()
        CType(splDescriereLunga, ComponentModel.ISupportInitialize).BeginInit()
        splDescriereLunga.Panel1.SuspendLayout()
        splDescriereLunga.Panel2.SuspendLayout()
        splDescriereLunga.SuspendLayout()
        tsRTB.SuspendLayout()
        pCtx.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPrompt
        ' 
        lblPrompt.Dock = DockStyle.Fill
        lblPrompt.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblPrompt.Location = New Point(3, 0)
        lblPrompt.Name = "lblPrompt"
        lblPrompt.Size = New Size(794, 34)
        lblPrompt.TabIndex = 2
        lblPrompt.Text = "Descrierea pe scurt a obiectului documentului de fundamentare/motivul revizuirii"
        lblPrompt.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.Dock = DockStyle.Fill
        Label1.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Label1.Location = New Point(3, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(754, 34)
        Label1.TabIndex = 0
        Label1.Text = "Descrierea pe larg a stării de fapt și de drept"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lyDescriereRevizie
        ' 
        lyDescriereRevizie.ColumnCount = 1
        lyDescriereRevizie.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        lyDescriereRevizie.Controls.Add(lblPrompt, 0, 0)
        lyDescriereRevizie.Controls.Add(txtExplicatieScurta, 0, 1)
        lyDescriereRevizie.Controls.Add(lyDescriereLungaLabel, 0, 2)
        lyDescriereRevizie.Controls.Add(lyDescrierePeLung, 0, 3)
        lyDescriereRevizie.Controls.Add(flyButoane, 0, 4)
        lyDescriereRevizie.Dock = DockStyle.Fill
        lyDescriereRevizie.Location = New Point(0, 0)
        lyDescriereRevizie.Margin = New Padding(0)
        lyDescriereRevizie.Name = "lyDescriereRevizie"
        lyDescriereRevizie.RowCount = 5
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 38F))
        lyDescriereRevizie.Size = New Size(800, 450)
        lyDescriereRevizie.TabIndex = 5
        ' 
        ' txtExplicatieScurta
        ' 
        txtExplicatieScurta.BorderStyle = BorderStyle.FixedSingle
        txtExplicatieScurta.Dock = DockStyle.Fill
        txtExplicatieScurta.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtExplicatieScurta.Location = New Point(3, 34)
        txtExplicatieScurta.Margin = New Padding(3, 0, 3, 0)
        txtExplicatieScurta.Name = "txtExplicatieScurta"
        txtExplicatieScurta.Size = New Size(794, 29)
        txtExplicatieScurta.TabIndex = 3
        ' 
        ' lyDescriereLungaLabel
        ' 
        lyDescriereLungaLabel.ColumnCount = 2
        lyDescriereLungaLabel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        lyDescriereLungaLabel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 40F))
        lyDescriereLungaLabel.Controls.Add(Label1, 0, 0)
        lyDescriereLungaLabel.Controls.Add(btnAtasteazaDocumente, 1, 0)
        lyDescriereLungaLabel.Dock = DockStyle.Fill
        lyDescriereLungaLabel.Location = New Point(0, 68)
        lyDescriereLungaLabel.Margin = New Padding(0)
        lyDescriereLungaLabel.Name = "lyDescriereLungaLabel"
        lyDescriereLungaLabel.RowCount = 1
        lyDescriereLungaLabel.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        lyDescriereLungaLabel.Size = New Size(800, 34)
        lyDescriereLungaLabel.TabIndex = 4
        ' 
        ' btnAtasteazaDocumente
        ' 
        btnAtasteazaDocumente.FlatAppearance.BorderColor = Color.White
        btnAtasteazaDocumente.FlatAppearance.BorderSize = 0
        btnAtasteazaDocumente.FlatStyle = FlatStyle.Flat
        btnAtasteazaDocumente.ForeColor = SystemColors.HotTrack
        btnAtasteazaDocumente.Image = My.Resources.Resources.attach_file
        btnAtasteazaDocumente.Location = New Point(760, 0)
        btnAtasteazaDocumente.Margin = New Padding(0)
        btnAtasteazaDocumente.Name = "btnAtasteazaDocumente"
        btnAtasteazaDocumente.Size = New Size(36, 34)
        btnAtasteazaDocumente.TabIndex = 1
        btnAtasteazaDocumente.TabStop = False
        btnAtasteazaDocumente.UseVisualStyleBackColor = True
        ' 
        ' lyDescrierePeLung
        ' 
        lyDescrierePeLung.ColumnCount = 1
        lyDescrierePeLung.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        lyDescrierePeLung.Controls.Add(pnlExplicatieHost, 0, 0)
        lyDescrierePeLung.Dock = DockStyle.Fill
        lyDescrierePeLung.Location = New Point(0, 102)
        lyDescrierePeLung.Margin = New Padding(0)
        lyDescrierePeLung.Name = "lyDescrierePeLung"
        lyDescrierePeLung.RowCount = 1
        lyDescrierePeLung.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        lyDescrierePeLung.Size = New Size(800, 310)
        lyDescrierePeLung.TabIndex = 5
        ' 
        ' pnlExplicatieHost
        ' 
        pnlExplicatieHost.Controls.Add(splDescriereLunga)
        pnlExplicatieHost.Dock = DockStyle.Fill
        pnlExplicatieHost.Location = New Point(3, 3)
        pnlExplicatieHost.Name = "pnlExplicatieHost"
        pnlExplicatieHost.Size = New Size(794, 304)
        pnlExplicatieHost.TabIndex = 0
        ' 
        ' splDescriereLunga
        ' 
        splDescriereLunga.Dock = DockStyle.Fill
        splDescriereLunga.FixedPanel = FixedPanel.Panel1
        splDescriereLunga.IsSplitterFixed = True
        splDescriereLunga.Location = New Point(0, 0)
        splDescriereLunga.Margin = New Padding(0)
        splDescriereLunga.Name = "splDescriereLunga"
        splDescriereLunga.Orientation = Orientation.Horizontal
        ' 
        ' splDescriereLunga.Panel1
        ' 
        splDescriereLunga.Panel1.Controls.Add(tsRTB)
        splDescriereLunga.Panel1Collapsed = True
        ' 
        ' splDescriereLunga.Panel2
        ' 
        splDescriereLunga.Panel2.Controls.Add(rtbExplicatieLunga)
        splDescriereLunga.Size = New Size(794, 304)
        splDescriereLunga.SplitterDistance = 25
        splDescriereLunga.TabIndex = 0
        splDescriereLunga.TabStop = False
        ' 
        ' tsRTB
        ' 
        tsRTB.AutoSize = False
        tsRTB.CanOverflow = False
        tsRTB.Dock = DockStyle.Fill
        tsRTB.GripMargin = New Padding(0)
        tsRTB.GripStyle = ToolStripGripStyle.Hidden
        tsRTB.ImageScalingSize = New Size(24, 24)
        tsRTB.Items.AddRange(New ToolStripItem() {bBold, bItalic, bUnderline, bColorText, bBgColor})
        tsRTB.Location = New Point(0, 0)
        tsRTB.Name = "tsRTB"
        tsRTB.Padding = New Padding(0)
        tsRTB.Size = New Size(150, 25)
        tsRTB.Stretch = True
        tsRTB.TabIndex = 5
        tsRTB.Text = "ToolStrip1"
        ' 
        ' bBold
        ' 
        bBold.AutoSize = False
        bBold.AutoToolTip = False
        bBold.CheckOnClick = True
        bBold.DisplayStyle = ToolStripItemDisplayStyle.Text
        bBold.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        bBold.ImageAlign = ContentAlignment.BottomLeft
        bBold.ImageScaling = ToolStripItemImageScaling.None
        bBold.ImageTransparentColor = Color.Magenta
        bBold.Margin = New Padding(2, 0, 2, 0)
        bBold.Name = "bBold"
        bBold.Overflow = ToolStripItemOverflow.Never
        bBold.Size = New Size(32, 32)
        bBold.Text = "B"
        bBold.TextImageRelation = TextImageRelation.Overlay
        bBold.ToolTipText = "Text îngroșat"
        ' 
        ' bItalic
        ' 
        bItalic.AutoSize = False
        bItalic.AutoToolTip = False
        bItalic.CheckOnClick = True
        bItalic.DisplayStyle = ToolStripItemDisplayStyle.Text
        bItalic.Font = New Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        bItalic.ImageAlign = ContentAlignment.BottomLeft
        bItalic.ImageScaling = ToolStripItemImageScaling.None
        bItalic.ImageTransparentColor = Color.Magenta
        bItalic.Margin = New Padding(2, 0, 2, 0)
        bItalic.Name = "bItalic"
        bItalic.Overflow = ToolStripItemOverflow.Never
        bItalic.Size = New Size(32, 32)
        bItalic.Text = "I"
        bItalic.TextImageRelation = TextImageRelation.Overlay
        bItalic.ToolTipText = "Text cursiv"
        ' 
        ' bUnderline
        ' 
        bUnderline.AutoSize = False
        bUnderline.AutoToolTip = False
        bUnderline.CheckOnClick = True
        bUnderline.DisplayStyle = ToolStripItemDisplayStyle.Text
        bUnderline.Font = New Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        bUnderline.ImageAlign = ContentAlignment.BottomLeft
        bUnderline.ImageScaling = ToolStripItemImageScaling.None
        bUnderline.ImageTransparentColor = Color.Magenta
        bUnderline.Margin = New Padding(2, 0, 2, 0)
        bUnderline.Name = "bUnderline"
        bUnderline.Overflow = ToolStripItemOverflow.Never
        bUnderline.Size = New Size(32, 32)
        bUnderline.Text = "U"
        bUnderline.TextImageRelation = TextImageRelation.Overlay
        bUnderline.ToolTipText = "Text Subliniat"
        ' 
        ' bColorText
        ' 
        bColorText.AutoSize = False
        bColorText.AutoToolTip = False
        bColorText.CheckOnClick = True
        bColorText.DisplayStyle = ToolStripItemDisplayStyle.Text
        bColorText.ForeColor = Color.MediumOrchid
        bColorText.ImageAlign = ContentAlignment.BottomLeft
        bColorText.ImageScaling = ToolStripItemImageScaling.None
        bColorText.ImageTransparentColor = Color.Magenta
        bColorText.Margin = New Padding(2, 0, 2, 0)
        bColorText.Name = "bColorText"
        bColorText.Overflow = ToolStripItemOverflow.Never
        bColorText.Size = New Size(32, 32)
        bColorText.Text = "🎨"
        bColorText.TextImageRelation = TextImageRelation.Overlay
        bColorText.ToolTipText = "Culoare text"
        ' 
        ' bBgColor
        ' 
        bBgColor.AutoSize = False
        bBgColor.AutoToolTip = False
        bBgColor.BackColor = Color.Gainsboro
        bBgColor.CheckOnClick = True
        bBgColor.DisplayStyle = ToolStripItemDisplayStyle.Text
        bBgColor.ImageAlign = ContentAlignment.BottomLeft
        bBgColor.ImageScaling = ToolStripItemImageScaling.None
        bBgColor.ImageTransparentColor = Color.Magenta
        bBgColor.Margin = New Padding(2, 0, 2, 0)
        bBgColor.Name = "bBgColor"
        bBgColor.Overflow = ToolStripItemOverflow.Never
        bBgColor.Size = New Size(32, 32)
        bBgColor.Text = "🖌️"
        bBgColor.TextImageRelation = TextImageRelation.Overlay
        bBgColor.ToolTipText = "Culoare fundal"
        ' 
        ' rtbExplicatieLunga
        ' 
        rtbExplicatieLunga.AcceptsTab = True
        rtbExplicatieLunga.BorderStyle = BorderStyle.FixedSingle
        rtbExplicatieLunga.BulletIndent = 2
        rtbExplicatieLunga.Dock = DockStyle.Fill
        rtbExplicatieLunga.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtbExplicatieLunga.Location = New Point(0, 0)
        rtbExplicatieLunga.Margin = New Padding(3, 0, 3, 0)
        rtbExplicatieLunga.Name = "rtbExplicatieLunga"
        rtbExplicatieLunga.ScrollBars = RichTextBoxScrollBars.Vertical
        rtbExplicatieLunga.ShowSelectionMargin = True
        rtbExplicatieLunga.Size = New Size(794, 304)
        rtbExplicatieLunga.TabIndex = 3
        rtbExplicatieLunga.Text = ""
        ' 
        ' flyButoane
        ' 
        flyButoane.AutoScroll = True
        flyButoane.Dock = DockStyle.Fill
        flyButoane.Location = New Point(0, 412)
        flyButoane.Margin = New Padding(0)
        flyButoane.Name = "flyButoane"
        flyButoane.Size = New Size(800, 38)
        flyButoane.TabIndex = 6
        ' 
        ' pCtx
        ' 
        pCtx.ImageScalingSize = New Size(24, 24)
        pCtx.Items.AddRange(New ToolStripItem() {tsiEliminaAtt, ToolStripSeparator4, tsiDeschideAtt})
        pCtx.Name = "ContextMenuStrip1"
        pCtx.RenderMode = ToolStripRenderMode.Professional
        pCtx.Size = New Size(251, 74)
        ' 
        ' tsiEliminaAtt
        ' 
        tsiEliminaAtt.Name = "tsiEliminaAtt"
        tsiEliminaAtt.Size = New Size(250, 32)
        tsiEliminaAtt.Text = "Elimină fișier atașat"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(247, 6)
        ' 
        ' tsiDeschideAtt
        ' 
        tsiDeschideAtt.Name = "tsiDeschideAtt"
        tsiDeschideAtt.Size = New Size(250, 32)
        tsiDeschideAtt.Text = "Deschide fișier atașat"
        ' 
        ' RTB
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lyDescriereRevizie)
        Name = "RTB"
        Text = "RTB"
        lyDescriereRevizie.ResumeLayout(False)
        lyDescriereRevizie.PerformLayout()
        lyDescriereLungaLabel.ResumeLayout(False)
        lyDescrierePeLung.ResumeLayout(False)
        pnlExplicatieHost.ResumeLayout(False)
        splDescriereLunga.Panel1.ResumeLayout(False)
        splDescriereLunga.Panel2.ResumeLayout(False)
        CType(splDescriereLunga, ComponentModel.ISupportInitialize).EndInit()
        splDescriereLunga.ResumeLayout(False)
        tsRTB.ResumeLayout(False)
        tsRTB.PerformLayout()
        pCtx.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lyDescriereRevizie As TableLayoutPanel
    Friend WithEvents txtExplicatieScurta As TextBox
    Friend WithEvents lyDescriereLungaLabel As TableLayoutPanel
    Friend WithEvents btnAtasteazaDocumente As Button
    Friend WithEvents lyDescrierePeLung As TableLayoutPanel
    Friend WithEvents pnlExplicatieHost As Panel
    Friend WithEvents splDescriereLunga As SplitContainer
    Friend WithEvents tsRTB As ToolStrip
    Friend WithEvents bBold As ToolStripButton
    Friend WithEvents bItalic As ToolStripButton
    Friend WithEvents bUnderline As ToolStripButton
    Friend WithEvents bColorText As ToolStripButton
    Friend WithEvents bBgColor As ToolStripButton
    Friend WithEvents rtbExplicatieLunga As RichTextBox
    Friend WithEvents flyButoane As FlowLayoutPanel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pCtx As ContextMenuStrip
    Friend WithEvents tsiEliminaAtt As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsiDeschideAtt As ToolStripMenuItem

End Class
