Imports System.ComponentModel

' Buton care nu ia focusul
Public Class NoFocusButton
    Inherits Button

    Public Sub New()
        Me.SetStyle(ControlStyles.Selectable, False)
    End Sub
End Class

Public Class RTB
    Implements IMessageFilter

    Private Property InfoCurent As New Model()

    Private Class Model
        Public Property Compartiment As String = ""
        Public Property ExplicatieScurta As String = ""
        Public Property ExplicatieLunga As String = ""
        Public Property Attachments As New List(Of AttachementModel)

        Public Function Contains(obj As Object) As Boolean
            Dim att As AttachementModel = TryCast(obj, AttachementModel)
            If att Is Nothing Then Return False
            For Each a In Attachments
                If a.FilePath = att.FilePath AndAlso a.FileData.SequenceEqual(att.FileData) Then
                    Return True
                End If
            Next
            Return False
        End Function
    End Class

    Private Class AttachementModel
        Public Property IdAttachProp As Integer = -1
        Public Property FilePath As String = ""
        Public Property FileData As Byte() = Array.Empty(Of Byte)
        Public Property IsDeleted As Boolean = False
        Public Property IsNew As Boolean = True
    End Class

    ' butoanele dinamice pentru atașamente
    Private pAttachmentButtons As List(Of Button)
    Private pCtxCurrentAttachment As AttachementModel

    Private pIgnoreLostFocus As Boolean = False
    Private IsNew As Boolean = True

    Private Const WM_MOUSEACTIVATE As Integer = &H21
    Private Const MA_ACTIVATE As Integer = 1

    ' ******************************************************************
    '  LOAD / INIT
    ' ******************************************************************
    Private Sub RTB_Load(sender As Object, e As EventArgs) Handles Me.Load
        Application.AddMessageFilter(Me)

        ' Inițializare atașamente
        pAttachmentButtons = New List(Of Button)()
        ToolTip1.UseFading = True
        ToolTip1.IsBalloon = True

        ' Tooltip-uri pentru butoane
        ToolTip1.SetToolTip(pBtnBold, "Text îngroșat (Bold)")
        ToolTip1.SetToolTip(pBtnItalic, "Text înclinat (Italic)")
        ToolTip1.SetToolTip(pBtnUnderline, "Text subliniat (Underline)")
        ToolTip1.SetToolTip(pBtnColor, "Culoare text")
        ToolTip1.SetToolTip(pBtnBgColor, "Culoare fundal text")
    End Sub

    Private Sub RTB_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.RemoveMessageFilter(Me)

        ' Elimină toate butoanele atașamente
        Do While pAttachmentButtons?.Count > 0
            Dim btn As Button = pAttachmentButtons(0)
            ToolTip1.SetToolTip(btn, Nothing)
            flyButoane.Controls.Remove(btn)
            pAttachmentButtons.Remove(btn)
            btn.Dispose()
        Loop
    End Sub

    Private Sub ShowToolbar()
        pToolbarPanel.Visible = True
        pToolbarPanel.BringToFront()
        rtbExplicatieLunga.SetBounds(0, 44, pnlExplicatieHost.ClientSize.Width, pnlExplicatieHost.ClientSize.Height - 44)
    End Sub

    Private Sub HideToolbar()
        pToolbarPanel.Visible = False
        rtbExplicatieLunga.SetBounds(0, 0, pnlExplicatieHost.ClientSize.Width, pnlExplicatieHost.ClientSize.Height)
    End Sub

    ' ******************************************************************
    '  MESSAGE FILTER
    ' ******************************************************************
    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Return False
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_MOUSEACTIVATE Then
            m.Result = New IntPtr(MA_ACTIVATE)
            Me.Activate()
            Exit Sub
        End If
        MyBase.WndProc(m)
    End Sub

    ' ******************************************************************
    '  FOCUS - arată/ascunde toolbar
    ' ******************************************************************
    Private Sub RtbExplicatieLunga_GotFocus(sender As Object, e As EventArgs) Handles rtbExplicatieLunga.GotFocus
        If Not rtbExplicatieLunga.ReadOnly Then
            ShowToolbar()
        End If
    End Sub

    Private Sub RtbExplicatieLunga_LostFocus(sender As Object, e As EventArgs) Handles rtbExplicatieLunga.LostFocus
        If pIgnoreLostFocus Then Exit Sub
        HideToolbar()
    End Sub

    ' ******************************************************************
    '  FORMATARE TEXT - butoane toolbar
    ' ******************************************************************
    Private Sub ToggleStyle(st As FontStyle)
        Dim f = rtbExplicatieLunga.SelectionFont
        If f Is Nothing Then f = rtbExplicatieLunga.Font

        Dim newStyle As FontStyle = If((f.Style And st) = st, f.Style And Not st, f.Style Or st)
        rtbExplicatieLunga.SelectionFont = New Font(f, newStyle)
    End Sub

    Private Sub PickColor(isBack As Boolean)
        pIgnoreLostFocus = True
        Using cd As New ColorDialog()
            If cd.ShowDialog(Me) = DialogResult.OK Then
                If isBack Then
                    rtbExplicatieLunga.SelectionBackColor = cd.Color
                Else
                    rtbExplicatieLunga.SelectionColor = cd.Color
                End If
            End If
        End Using
        pIgnoreLostFocus = False
    End Sub

    Private Sub pBtnBold_Click(sender As Object, e As EventArgs) Handles pBtnBold.Click
        ToggleStyle(FontStyle.Bold)
    End Sub

    Private Sub pBtnItalic_Click(sender As Object, e As EventArgs) Handles pBtnItalic.Click
        ToggleStyle(FontStyle.Italic)
    End Sub

    Private Sub pBtnUnderline_Click(sender As Object, e As EventArgs) Handles pBtnUnderline.Click
        ToggleStyle(FontStyle.Underline)
    End Sub

    Private Sub pBtnColor_Click(sender As Object, e As EventArgs) Handles pBtnColor.Click
        PickColor(False)
    End Sub

    Private Sub pBtnBgColor_Click(sender As Object, e As EventArgs) Handles pBtnBgColor.Click
        PickColor(True)
    End Sub

    ' ******************************************************************
    '  ATAȘAMENTE
    ' ******************************************************************
    Private Sub BtnAtasteazaDocumente_Click(sender As Object, e As EventArgs) Handles btnAtasteazaDocumente.Click
        Using d As New OpenFileDialog()
            d.Filter = "Documente|*.pdf;*.jpg;*.jpeg;*.png"
            d.Multiselect = True

            If d.ShowDialog(Me) <> DialogResult.OK Then Exit Sub

            For Each f In d.FileNames
                Dim att As New AttachementModel With {
                    .FilePath = f,
                    .FileData = IO.File.ReadAllBytes(f),
                    .IsDeleted = False
                }

                If Not InfoCurent.Attachments.Contains(att) Then
                    InfoCurent.Attachments.Add(att)
                    AddAttachmentButton(att)
                End If
            Next
        End Using
    End Sub

    Private Sub AddAttachmentButton(att As AttachementModel)
        Dim btn As New Button With {
            .Text = "Attachment",
            .Height = 34,
            .Width = 120,
            .Margin = New Padding(0),
            .Tag = att
        }
        ToolTip1.SetToolTip(btn, IO.Path.GetFileName(att.FilePath))

        AddHandler btn.Click,
            Sub(s, ev)
                pCtxCurrentAttachment = DirectCast(btn.Tag, AttachementModel)
                tsiEliminaAtt.Visible = IsNew
                pCtx.Show(btn, 0, btn.Height)
            End Sub

        flyButoane.Controls.Add(btn)
        pAttachmentButtons.Add(btn)
    End Sub

    Private Sub RemoveAttachment(btn As Button)
        Dim att As AttachementModel = DirectCast(btn.Tag, AttachementModel)
        att.IsDeleted = True

        ToolTip1.SetToolTip(btn, Nothing)
        flyButoane.Controls.Remove(btn)
        pAttachmentButtons.Remove(btn)
        btn.Dispose()
    End Sub

    Private Sub TsiDeschideAtt_Click(sender As Object, e As EventArgs) Handles tsiDeschideAtt.Click
        If pCtxCurrentAttachment Is Nothing Then Exit Sub

        Try
            Dim tmp = IO.Path.Combine(IO.Path.GetTempPath, IO.Path.GetFileName(pCtxCurrentAttachment.FilePath))
            IO.File.WriteAllBytes(tmp, pCtxCurrentAttachment.FileData)
            Process.Start(New ProcessStartInfo(tmp) With {.UseShellExecute = True})
        Catch ex As Exception
            MessageBox.Show("Nu pot deschide fișierul: " & ex.Message)
        End Try
    End Sub

    Private Sub TsiEliminaAtt_Click(sender As Object, e As EventArgs) Handles tsiEliminaAtt.Click
        If pCtxCurrentAttachment Is Nothing Then Exit Sub

        Dim btn = flyButoane.Controls.OfType(Of Button).FirstOrDefault(Function(b) b.Tag Is pCtxCurrentAttachment)
        If btn IsNot Nothing Then
            RemoveAttachment(btn)
        End If

        pCtxCurrentAttachment = Nothing
    End Sub

    ' ******************************************************************
    '  VALIDARE
    ' ******************************************************************
    Private Function ValidateForm() As Boolean
        If String.IsNullOrWhiteSpace(txtExplicatieScurta.Text) Then
            MessageBox.Show("Completați explicația scurtă!", "Validare")
            txtExplicatieScurta.Focus()
            Return False
        End If

        If String.IsNullOrWhiteSpace(rtbExplicatieLunga.Text) Then
            Dim r = MessageBox.Show(
                "Descrierea pe larg lipsește. Folosesc explicația scurtă?",
                "Confirmare",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If r = DialogResult.No Then
                rtbExplicatieLunga.Focus()
                Return False
            End If

            rtbExplicatieLunga.Text = txtExplicatieScurta.Text
        End If

        Return True
    End Function
End Class