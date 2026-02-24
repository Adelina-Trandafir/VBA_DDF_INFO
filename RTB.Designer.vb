Imports VBA_DDF_INFO.CustomControls
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
        pToolbarPanel = New Panel()
        pCmbFonts = New NoFocusComboBox()
        pBtnBold = New NoFocusButton()
        pBtnItalic = New NoFocusButton()
        pBtnUnderline = New NoFocusButton()
        pBtnColor = New NoFocusButton()
        pBtnBgColor = New NoFocusButton()
        rtbExplicatieLunga = New RichTextBox()
        flyButoane = New FlowLayoutPanel()
        pnlFooter = New Panel()
        BtnSave = New NoFocusButton()
        BtnClose = New NoFocusButton()
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
        pToolbarPanel.SuspendLayout()
        pnlFooter.SuspendLayout()
        pCtx.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPrompt
        ' 
        lblPrompt.Dock = DockStyle.Fill
        lblPrompt.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lblPrompt.Location = New Point(5, 2)
        lblPrompt.Name = "lblPrompt"
        lblPrompt.Size = New Size(790, 34)
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
        Label1.Size = New Size(750, 34)
        Label1.TabIndex = 0
        Label1.Text = "Descrierea pe larg a stării de fapt și de drept"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lyDescriereRevizie
        ' 
        lyDescriereRevizie.BackColor = SystemColors.Control
        lyDescriereRevizie.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        lyDescriereRevizie.ColumnCount = 1
        lyDescriereRevizie.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100F))
        lyDescriereRevizie.Controls.Add(lblPrompt, 0, 0)
        lyDescriereRevizie.Controls.Add(txtExplicatieScurta, 0, 1)
        lyDescriereRevizie.Controls.Add(lyDescriereLungaLabel, 0, 2)
        lyDescriereRevizie.Controls.Add(lyDescrierePeLung, 0, 3)
        lyDescriereRevizie.Controls.Add(flyButoane, 0, 4)
        lyDescriereRevizie.Controls.Add(pnlFooter, 0, 5)
        lyDescriereRevizie.Dock = DockStyle.Fill
        lyDescriereRevizie.Location = New Point(0, 0)
        lyDescriereRevizie.Margin = New Padding(0)
        lyDescriereRevizie.Name = "lyDescriereRevizie"
        lyDescriereRevizie.Padding = New Padding(1)
        lyDescriereRevizie.RowCount = 6
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 38F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 42F))
        lyDescriereRevizie.Size = New Size(800, 450)
        lyDescriereRevizie.TabIndex = 5
        ' 
        ' txtExplicatieScurta
        ' 
        txtExplicatieScurta.BorderStyle = BorderStyle.FixedSingle
        txtExplicatieScurta.Dock = DockStyle.Fill
        txtExplicatieScurta.Font = New Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtExplicatieScurta.Location = New Point(5, 37)
        txtExplicatieScurta.Margin = New Padding(3, 0, 3, 0)
        txtExplicatieScurta.Name = "txtExplicatieScurta"
        txtExplicatieScurta.Size = New Size(790, 29)
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
        lyDescriereLungaLabel.Location = New Point(2, 72)
        lyDescriereLungaLabel.Margin = New Padding(0)
        lyDescriereLungaLabel.Name = "lyDescriereLungaLabel"
        lyDescriereLungaLabel.RowCount = 1
        lyDescriereLungaLabel.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        lyDescriereLungaLabel.Size = New Size(796, 34)
        lyDescriereLungaLabel.TabIndex = 4
        ' 
        ' btnAtasteazaDocumente
        ' 
        btnAtasteazaDocumente.FlatAppearance.BorderColor = Color.White
        btnAtasteazaDocumente.FlatAppearance.BorderSize = 0
        btnAtasteazaDocumente.FlatStyle = FlatStyle.Flat
        btnAtasteazaDocumente.ForeColor = SystemColors.HotTrack
        btnAtasteazaDocumente.Image = My.Resources.Resources.attach_file
        btnAtasteazaDocumente.Location = New Point(756, 0)
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
        lyDescrierePeLung.Location = New Point(2, 107)
        lyDescrierePeLung.Margin = New Padding(0)
        lyDescrierePeLung.Name = "lyDescrierePeLung"
        lyDescrierePeLung.RowCount = 1
        lyDescrierePeLung.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        lyDescrierePeLung.Size = New Size(796, 259)
        lyDescrierePeLung.TabIndex = 5
        ' 
        ' pnlExplicatieHost
        ' 
        pnlExplicatieHost.Controls.Add(pToolbarPanel)
        pnlExplicatieHost.Controls.Add(rtbExplicatieLunga)
        pnlExplicatieHost.Dock = DockStyle.Fill
        pnlExplicatieHost.Location = New Point(3, 3)
        pnlExplicatieHost.Name = "pnlExplicatieHost"
        pnlExplicatieHost.Size = New Size(790, 253)
        pnlExplicatieHost.TabIndex = 0
        ' 
        ' pToolbarPanel
        ' 
        pToolbarPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pToolbarPanel.BackColor = SystemColors.Window
        pToolbarPanel.BorderStyle = BorderStyle.FixedSingle
        pToolbarPanel.Controls.Add(pCmbFonts)
        pToolbarPanel.Controls.Add(pBtnBold)
        pToolbarPanel.Controls.Add(pBtnItalic)
        pToolbarPanel.Controls.Add(pBtnUnderline)
        pToolbarPanel.Controls.Add(pBtnColor)
        pToolbarPanel.Controls.Add(pBtnBgColor)
        pToolbarPanel.Location = New Point(0, 0)
        pToolbarPanel.Margin = New Padding(0)
        pToolbarPanel.Name = "pToolbarPanel"
        pToolbarPanel.Size = New Size(790, 44)
        pToolbarPanel.TabIndex = 0
        pToolbarPanel.Visible = False
        ' 
        ' pCmbFonts
        ' 
        pCmbFonts.DropDownStyle = ComboBoxStyle.DropDownList
        pCmbFonts.FlatStyle = FlatStyle.Flat
        pCmbFonts.Font = New Font("Segoe UI", 10F)
        pCmbFonts.IntegralHeight = False
        pCmbFonts.ItemHeight = 28
        pCmbFonts.Location = New Point(4, 4)
        pCmbFonts.Name = "pCmbFonts"
        pCmbFonts.Size = New Size(260, 36)
        pCmbFonts.TabIndex = 5
        ' 
        ' pBtnBold
        ' 
        pBtnBold.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pBtnBold.Cursor = Cursors.Hand
        pBtnBold.FlatStyle = FlatStyle.Flat
        pBtnBold.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        pBtnBold.Location = New Point(270, 4)
        pBtnBold.Name = "pBtnBold"
        pBtnBold.Size = New Size(36, 36)
        pBtnBold.TabIndex = 6
        pBtnBold.Text = "B"
        pBtnBold.UseVisualStyleBackColor = False
        ' 
        ' pBtnItalic
        ' 
        pBtnItalic.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pBtnItalic.Cursor = Cursors.Hand
        pBtnItalic.FlatStyle = FlatStyle.Flat
        pBtnItalic.Font = New Font("Segoe UI", 9F, FontStyle.Italic)
        pBtnItalic.Location = New Point(307, 4)
        pBtnItalic.Name = "pBtnItalic"
        pBtnItalic.Size = New Size(36, 36)
        pBtnItalic.TabIndex = 7
        pBtnItalic.Text = "I"
        pBtnItalic.UseVisualStyleBackColor = False
        ' 
        ' pBtnUnderline
        ' 
        pBtnUnderline.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pBtnUnderline.Cursor = Cursors.Hand
        pBtnUnderline.FlatStyle = FlatStyle.Flat
        pBtnUnderline.Font = New Font("Segoe UI", 9F, FontStyle.Underline)
        pBtnUnderline.Location = New Point(344, 4)
        pBtnUnderline.Name = "pBtnUnderline"
        pBtnUnderline.Size = New Size(36, 36)
        pBtnUnderline.TabIndex = 8
        pBtnUnderline.Text = "U"
        pBtnUnderline.UseVisualStyleBackColor = False
        ' 
        ' pBtnColor
        ' 
        pBtnColor.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pBtnColor.Cursor = Cursors.Hand
        pBtnColor.FlatStyle = FlatStyle.Flat
        pBtnColor.ForeColor = Color.Red
        pBtnColor.Location = New Point(390, 4)
        pBtnColor.Name = "pBtnColor"
        pBtnColor.Size = New Size(36, 36)
        pBtnColor.TabIndex = 9
        pBtnColor.Text = "A"
        pBtnColor.UseVisualStyleBackColor = False
        ' 
        ' pBtnBgColor
        ' 
        pBtnBgColor.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pBtnBgColor.Cursor = Cursors.Hand
        pBtnBgColor.FlatStyle = FlatStyle.Flat
        pBtnBgColor.ForeColor = Color.SteelBlue
        pBtnBgColor.Location = New Point(427, 4)
        pBtnBgColor.Name = "pBtnBgColor"
        pBtnBgColor.Size = New Size(36, 36)
        pBtnBgColor.TabIndex = 10
        pBtnBgColor.Text = "▄"
        pBtnBgColor.UseVisualStyleBackColor = False
        ' 
        ' rtbExplicatieLunga
        ' 
        rtbExplicatieLunga.AcceptsTab = True
        rtbExplicatieLunga.BorderStyle = BorderStyle.FixedSingle
        rtbExplicatieLunga.Dock = DockStyle.Fill
        rtbExplicatieLunga.Font = New Font("Consolas", 9F)
        rtbExplicatieLunga.Location = New Point(0, 0)
        rtbExplicatieLunga.Name = "rtbExplicatieLunga"
        rtbExplicatieLunga.Size = New Size(790, 253)
        rtbExplicatieLunga.TabIndex = 3
        rtbExplicatieLunga.Text = ""
        ' 
        ' flyButoane
        ' 
        flyButoane.AutoScroll = True
        flyButoane.Dock = DockStyle.Fill
        flyButoane.Location = New Point(2, 367)
        flyButoane.Margin = New Padding(0)
        flyButoane.Name = "flyButoane"
        flyButoane.Size = New Size(796, 38)
        flyButoane.TabIndex = 6
        ' 
        ' pnlFooter
        ' 
        pnlFooter.BackColor = Color.FromArgb(CByte(245), CByte(245), CByte(245))
        pnlFooter.Controls.Add(BtnSave)
        pnlFooter.Controls.Add(BtnClose)
        pnlFooter.Dock = DockStyle.Fill
        pnlFooter.Location = New Point(2, 406)
        pnlFooter.Margin = New Padding(0)
        pnlFooter.Name = "pnlFooter"
        pnlFooter.Size = New Size(796, 42)
        pnlFooter.TabIndex = 7
        ' 
        ' BtnSave
        ' 
        BtnSave.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        BtnSave.Cursor = Cursors.Hand
        BtnSave.Dock = DockStyle.Right
        BtnSave.FlatAppearance.BorderSize = 0
        BtnSave.FlatAppearance.MouseOverBackColor = SystemColors.Info
        BtnSave.FlatStyle = FlatStyle.Flat
        BtnSave.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        BtnSave.ForeColor = Color.Black
        BtnSave.Image = My.Resources.Resources.floppy_disc
        BtnSave.ImageAlign = ContentAlignment.MiddleRight
        BtnSave.Location = New Point(621, 0)
        BtnSave.Margin = New Padding(0)
        BtnSave.Name = "BtnSave"
        BtnSave.Padding = New Padding(0, 0, 10, 0)
        BtnSave.Size = New Size(175, 42)
        BtnSave.TabIndex = 1
        BtnSave.Text = "SALVEAZĂ"
        BtnSave.TextAlign = ContentAlignment.MiddleLeft
        BtnSave.UseVisualStyleBackColor = True
        ' 
        ' BtnClose
        ' 
        BtnClose.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        BtnClose.Cursor = Cursors.Hand
        BtnClose.Dock = DockStyle.Left
        BtnClose.FlatAppearance.BorderSize = 0
        BtnClose.FlatAppearance.MouseOverBackColor = SystemColors.ActiveCaption
        BtnClose.FlatStyle = FlatStyle.Flat
        BtnClose.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        BtnClose.ForeColor = Color.Black
        BtnClose.Image = My.Resources.Resources.logout
        BtnClose.ImageAlign = ContentAlignment.MiddleLeft
        BtnClose.Location = New Point(0, 0)
        BtnClose.Margin = New Padding(0)
        BtnClose.Name = "BtnClose"
        BtnClose.Padding = New Padding(10, 0, 0, 0)
        BtnClose.Size = New Size(175, 42)
        BtnClose.TabIndex = 0
        BtnClose.Text = "ÎNCHIDE"
        BtnClose.TextAlign = ContentAlignment.MiddleRight
        BtnClose.UseVisualStyleBackColor = True
        ' 
        ' pCtx
        ' 
        pCtx.ImageScalingSize = New Size(24, 24)
        pCtx.Items.AddRange(New ToolStripItem() {tsiEliminaAtt, ToolStripSeparator4, tsiDeschideAtt})
        pCtx.Name = "pCtx"
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
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        ClientSize = New Size(800, 450)
        ControlBox = False
        Controls.Add(lyDescriereRevizie)
        FormBorderStyle = FormBorderStyle.None
        Name = "RTB"
        lyDescriereRevizie.ResumeLayout(False)
        lyDescriereRevizie.PerformLayout()
        lyDescriereLungaLabel.ResumeLayout(False)
        lyDescrierePeLung.ResumeLayout(False)
        pnlExplicatieHost.ResumeLayout(False)
        pToolbarPanel.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pCtx.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lyDescriereRevizie As TableLayoutPanel
    Friend WithEvents txtExplicatieScurta As TextBox
    Friend WithEvents lyDescriereLungaLabel As TableLayoutPanel
    Friend WithEvents btnAtasteazaDocumente As Button
    Friend WithEvents lyDescrierePeLung As TableLayoutPanel
    Friend WithEvents pnlExplicatieHost As Panel
    Friend WithEvents pToolbarPanel As Panel
    Friend WithEvents pBtnBold As NoFocusButton
    Friend WithEvents pBtnItalic As NoFocusButton
    Friend WithEvents pBtnUnderline As NoFocusButton
    Friend WithEvents pBtnColor As NoFocusButton
    Friend WithEvents pBtnBgColor As NoFocusButton
    Friend WithEvents rtbExplicatieLunga As RichTextBox
    Friend WithEvents flyButoane As FlowLayoutPanel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents BtnClose As NoFocusButton
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pCtx As ContextMenuStrip
    Friend WithEvents tsiEliminaAtt As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsiDeschideAtt As ToolStripMenuItem
    Friend WithEvents pCmbFonts As NoFocusComboBox
    Friend WithEvents BtnSave As NoFocusButton
End Class