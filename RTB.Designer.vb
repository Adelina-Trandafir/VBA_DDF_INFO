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
        pBtnBold = New NoFocusButton()
        pBtnItalic = New NoFocusButton()
        pBtnUnderline = New NoFocusButton()
        pBtnColor = New NoFocusButton()
        pBtnBgColor = New NoFocusButton()
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
        pToolbarPanel.SuspendLayout()
        pCtx.SuspendLayout()
        SuspendLayout()
        ' 
        ' lblPrompt
        ' 
        lblPrompt.Dock = DockStyle.Fill
        lblPrompt.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
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
        Label1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
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
        lyDescriereRevizie.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
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
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34.0F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34.0F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 34.0F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        lyDescriereRevizie.RowStyles.Add(New RowStyle(SizeType.Absolute, 38.0F))
        lyDescriereRevizie.Size = New Size(800, 450)
        lyDescriereRevizie.TabIndex = 5
        ' 
        ' txtExplicatieScurta
        ' 
        txtExplicatieScurta.BorderStyle = BorderStyle.FixedSingle
        txtExplicatieScurta.Dock = DockStyle.Fill
        txtExplicatieScurta.Font = New Font("Consolas", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtExplicatieScurta.Location = New Point(3, 34)
        txtExplicatieScurta.Margin = New Padding(3, 0, 3, 0)
        txtExplicatieScurta.Name = "txtExplicatieScurta"
        txtExplicatieScurta.Size = New Size(794, 29)
        txtExplicatieScurta.TabIndex = 3
        ' 
        ' lyDescriereLungaLabel
        ' 
        lyDescriereLungaLabel.ColumnCount = 2
        lyDescriereLungaLabel.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        lyDescriereLungaLabel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 40.0F))
        lyDescriereLungaLabel.Controls.Add(Label1, 0, 0)
        lyDescriereLungaLabel.Controls.Add(btnAtasteazaDocumente, 1, 0)
        lyDescriereLungaLabel.Dock = DockStyle.Fill
        lyDescriereLungaLabel.Location = New Point(0, 68)
        lyDescriereLungaLabel.Margin = New Padding(0)
        lyDescriereLungaLabel.Name = "lyDescriereLungaLabel"
        lyDescriereLungaLabel.RowCount = 1
        lyDescriereLungaLabel.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
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
        lyDescrierePeLung.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        lyDescrierePeLung.Controls.Add(pnlExplicatieHost, 0, 0)
        lyDescrierePeLung.Dock = DockStyle.Fill
        lyDescrierePeLung.Location = New Point(0, 102)
        lyDescrierePeLung.Margin = New Padding(0)
        lyDescrierePeLung.Name = "lyDescrierePeLung"
        lyDescrierePeLung.RowCount = 1
        lyDescrierePeLung.RowStyles.Add(New RowStyle(SizeType.Percent, 100.0F))
        lyDescrierePeLung.Size = New Size(800, 310)
        lyDescrierePeLung.TabIndex = 5
        ' 
        ' pnlExplicatieHost
        ' 
        pnlExplicatieHost.Controls.Add(pToolbarPanel)
        pnlExplicatieHost.Controls.Add(rtbExplicatieLunga)
        pnlExplicatieHost.Dock = DockStyle.Fill
        pnlExplicatieHost.Location = New Point(3, 3)
        pnlExplicatieHost.Name = "pnlExplicatieHost"
        pnlExplicatieHost.Size = New Size(794, 304)
        pnlExplicatieHost.TabIndex = 0
        ' 
        ' pToolbarPanel
        ' 
        pToolbarPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pToolbarPanel.BackColor = SystemColors.Window
        pToolbarPanel.BorderStyle = BorderStyle.FixedSingle
        pToolbarPanel.Controls.Add(pBtnBold)
        pToolbarPanel.Controls.Add(pBtnItalic)
        pToolbarPanel.Controls.Add(pBtnUnderline)
        pToolbarPanel.Controls.Add(pBtnColor)
        pToolbarPanel.Controls.Add(pBtnBgColor)
        pToolbarPanel.Location = New Point(0, 0)
        pToolbarPanel.Margin = New Padding(0)
        pToolbarPanel.Name = "pToolbarPanel"
        pToolbarPanel.Size = New Size(794, 44)
        pToolbarPanel.TabIndex = 0
        pToolbarPanel.Visible = False
        ' 
        ' pBtnBold
        ' 
        pBtnBold.Cursor = Cursors.Hand
        pBtnBold.FlatAppearance.BorderSize = 1
        pBtnBold.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        pBtnBold.Location = New Point(4, 4)
        pBtnBold.Name = "pBtnBold"
        pBtnBold.Size = New Size(36, 36)
        pBtnBold.TabIndex = 0
        pBtnBold.Text = "B"
        pBtnBold.UseVisualStyleBackColor = True
        ' 
        ' pBtnItalic
        ' 
        pBtnItalic.Cursor = Cursors.Hand
        pBtnItalic.FlatAppearance.BorderSize = 1
        pBtnItalic.Font = New Font("Segoe UI", 9.0F, FontStyle.Italic)
        pBtnItalic.Location = New Point(41, 4)
        pBtnItalic.Name = "pBtnItalic"
        pBtnItalic.Size = New Size(36, 36)
        pBtnItalic.TabIndex = 1
        pBtnItalic.Text = "I"
        pBtnItalic.UseVisualStyleBackColor = True
        ' 
        ' pBtnUnderline
        ' 
        pBtnUnderline.Cursor = Cursors.Hand
        pBtnUnderline.FlatAppearance.BorderSize = 1
        pBtnUnderline.Font = New Font("Segoe UI", 9.0F, FontStyle.Underline)
        pBtnUnderline.Location = New Point(78, 4)
        pBtnUnderline.Name = "pBtnUnderline"
        pBtnUnderline.Size = New Size(36, 36)
        pBtnUnderline.TabIndex = 2
        pBtnUnderline.Text = "U"
        pBtnUnderline.UseVisualStyleBackColor = True
        ' 
        ' pBtnColor
        ' 
        pBtnColor.Cursor = Cursors.Hand
        pBtnColor.FlatAppearance.BorderSize = 1
        pBtnColor.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        pBtnColor.ForeColor = Color.Red
        pBtnColor.Location = New Point(124, 4)
        pBtnColor.Name = "pBtnColor"
        pBtnColor.Size = New Size(36, 36)
        pBtnColor.TabIndex = 3
        pBtnColor.Text = "A"
        pBtnColor.UseVisualStyleBackColor = True
        ' 
        ' pBtnBgColor
        ' 
        pBtnBgColor.Cursor = Cursors.Hand
        pBtnBgColor.FlatAppearance.BorderSize = 1
        pBtnBgColor.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        pBtnBgColor.ForeColor = Color.Yellow
        pBtnBgColor.Location = New Point(161, 4)
        pBtnBgColor.Name = "pBtnBgColor"
        pBtnBgColor.Size = New Size(36, 36)
        pBtnBgColor.TabIndex = 4
        pBtnBgColor.Text = "▄"
        pBtnBgColor.UseVisualStyleBackColor = True
        ' 
        ' rtbExplicatieLunga
        ' 
        rtbExplicatieLunga.AcceptsTab = True
        rtbExplicatieLunga.BorderStyle = BorderStyle.FixedSingle
        rtbExplicatieLunga.BulletIndent = 2
        rtbExplicatieLunga.Dock = DockStyle.Fill
        rtbExplicatieLunga.Font = New Font("Consolas", 9.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
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
        AutoScaleMode = AutoScaleMode.None
        AutoSize = True
        BackColor = Color.White
        ClientSize = New Size(800, 450)
        ControlBox = False
        Controls.Add(lyDescriereRevizie)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Name = "RTB"
        ShowIcon = False
        ShowInTaskbar = False
        SizeGripStyle = SizeGripStyle.Hide
        Text = "RTB"
        lyDescriereRevizie.ResumeLayout(False)
        lyDescriereRevizie.PerformLayout()
        lyDescriereLungaLabel.ResumeLayout(False)
        lyDescrierePeLung.ResumeLayout(False)
        pnlExplicatieHost.ResumeLayout(False)
        pToolbarPanel.ResumeLayout(False)
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
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents pCtx As ContextMenuStrip
    Friend WithEvents tsiEliminaAtt As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsiDeschideAtt As ToolStripMenuItem

End Class