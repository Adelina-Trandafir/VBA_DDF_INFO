Imports System.ComponentModel

Public Class RTB
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

    ' meniu contextual RTB
    Private pColorDialog As ColorDialog
    Private pIgnoreLostFocus As Boolean = False

    Private IsNew As Boolean = True
    Private Sub InitializeazaInfoRevizii()
        pAttachmentButtons = New List(Of Button)()
        splDescriereLunga.Panel1Collapsed = True

        ' === autocompletare ===
        txtExplicatieScurta.Text = InfoCurent.ExplicatieScurta
        rtbExplicatieLunga.Rtf = InfoCurent.ExplicatieLunga

        ' === atașamente existente ===
        If InfoCurent.Attachments Is Nothing OrElse InfoCurent.Attachments.Count = 0 Then
            ' reconstruiesc butoane atașamente
            For Each f In InfoCurent.Attachments
                AddAttachmentButton(f)
            Next
        End If

        ' === setari tooltip ===
        ToolTip1.UseFading = True
        ToolTip1.IsBalloon = True

        'btnOK.Visible = IsNew
        btnAtasteazaDocumente.Visible = IsNew
        rtbExplicatieLunga.ReadOnly = Not IsNew
        txtExplicatieScurta.ReadOnly = Not IsNew
    End Sub

    ' ******************************************************************
    '  ATAȘAMENTE – selectare + butoane dinamice
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
            Sub(s, e)
                pCtxCurrentAttachment = DirectCast(btn.Tag, AttachementModel)
                tsiEliminaAtt.Visible = IsNew
                pCtx.Show(btn, 0, btn.Height)   ' popup sub buton
            End Sub

        flyButoane.Controls.Add(btn)
        If pAttachmentButtons Is Nothing Then pAttachmentButtons = New List(Of Button)
        pAttachmentButtons.Add(btn)
    End Sub

    Private Sub RemoveAttachment(sender As Object, e As EventArgs)
        ' elimină legătura
        Dim att As AttachementModel = DirectCast(DirectCast(sender, Button).Tag, AttachementModel)
        Dim btn As Button = CType(sender, Button)
        Dim path As String = CStr(att.FilePath)

        att.IsDeleted = True

        'elimină tooltip și buton
        ToolTip1.SetToolTip(btn, Nothing)
        flyButoane.Controls.Remove(btn)
        pAttachmentButtons.Remove(btn)
        btn.Dispose()
    End Sub

    ' ******************************************************************
    '  VALIDARE + salvare în model
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

    Private Sub RtbExplicatieLunga_GotFocus(sender As Object, e As EventArgs) Handles rtbExplicatieLunga.GotFocus
        If Not rtbExplicatieLunga.ReadOnly Then splDescriereLunga.Panel1Collapsed = False
    End Sub

    Private Sub RtbExplicatieLunga_LostFocus(sender As Object, e As EventArgs) Handles rtbExplicatieLunga.LostFocus
        ' Dacă focusul se mută pe toolbar → nu ascundem
        If pIgnoreLostFocus Then Exit Sub

        ' Alt control → ascund toolbar-ul
        If Not tsRTB.Focused AndAlso Not tsRTB.ContainsFocus Then
            splDescriereLunga.Panel1Collapsed = True
        End If
    End Sub

    Private Sub PRtbToolbar_Enter(sender As Object, e As EventArgs) Handles tsRTB.Enter
        pIgnoreLostFocus = True
    End Sub

    Private Sub PRtbToolbar_Leave(sender As Object, e As EventArgs) Handles tsRTB.Leave
        pIgnoreLostFocus = False

        ' dacă am ieșit complet din toolbar → ascund
        If Not rtbExplicatieLunga.Focused Then
            splDescriereLunga.Panel1Collapsed = True
        End If
    End Sub

    ' ******************************************************************
    '  OK / CANCEL
    ' ******************************************************************
    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        If Not ValidateForm() Then
            DialogResult = DialogResult.None
            Exit Sub
        End If

        InfoCurent.ExplicatieScurta =
            txtExplicatieScurta.Text.Trim

        InfoCurent.ExplicatieLunga =
            rtbExplicatieLunga.Rtf

        DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    ' =====================================================================
    ' FUNCȚII DE FORMAT (aceleași ca înainte)
    ' =====================================================================
    Private Sub ToggleStyle(st As FontStyle)
        Dim f = rtbExplicatieLunga.SelectionFont
        If f Is Nothing Then f = rtbExplicatieLunga.Font

        Dim newStyle As FontStyle =
            If((f.Style And st) = st, f.Style And Not st, f.Style Or st)

        rtbExplicatieLunga.SelectionFont = New Font(f, newStyle)
    End Sub

    Private Sub PickColor(isBack As Boolean)
        Using cd As New ColorDialog()
            If cd.ShowDialog(Me) = DialogResult.OK Then
                If isBack Then
                    rtbExplicatieLunga.SelectionBackColor = cd.Color
                Else
                    rtbExplicatieLunga.SelectionColor = cd.Color
                End If
            End If
        End Using
    End Sub

    Private Sub BUnderline_Click(sender As Object, e As EventArgs) Handles bUnderline.Click
        ToggleStyle(FontStyle.Underline)
    End Sub

    Private Sub BBold_Click(sender As Object, e As EventArgs) Handles bBold.Click
        ToggleStyle(FontStyle.Bold)
    End Sub

    Private Sub BColorText_Click(sender As Object, e As EventArgs) Handles bColorText.Click
        PickColor(False)
    End Sub

    Private Sub BItalic_Click(sender As Object, e As EventArgs) Handles bItalic.Click
        ToggleStyle(FontStyle.Italic)
    End Sub

    Private Sub BColorBack_Click(sender As Object, e As EventArgs) Handles bBgColor.Click
        PickColor(True)
    End Sub

    Private Sub FrmExplicatie_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'elimină toate butoanele atașamente
        Do While pAttachmentButtons?.Count > 0
            Dim btn As Button = pAttachmentButtons(0)
            ToolTip1.SetToolTip(btn, Nothing)
            flyButoane.Controls.Remove(btn)
            pAttachmentButtons.Remove(btn)
            btn.Dispose()
        Loop
    End Sub

    Private Sub TsiDeschideAtt_Click(sender As Object, e As EventArgs)
        If pCtxCurrentAttachment Is Nothing Then Exit Sub

        Try
            Dim tmp = IO.Path.Combine(IO.Path.GetTempPath,
                                      IO.Path.GetFileName(pCtxCurrentAttachment.FilePath))

            IO.File.WriteAllBytes(tmp, pCtxCurrentAttachment.FileData)
            Process.Start(New ProcessStartInfo(tmp) With {.UseShellExecute = True})

        Catch ex As Exception
            MessageBox.Show("Nu pot deschide fișierul: " & ex.Message)
        End Try
    End Sub

    Private Sub TsiEliminaAtt_Click(sender As Object, e As EventArgs)
        If pCtxCurrentAttachment Is Nothing Then Exit Sub

        ' Caută butonul aferent atașamentului
        Dim btn =
            flyButoane.Controls.Cast(Of Control).
            OfType(Of Button).
            FirstOrDefault(Function(b) b.Tag Is pCtxCurrentAttachment)

        If btn Is Nothing Then Exit Sub

        ' refolosim logica ta de ștergere
        RemoveAttachment(btn, EventArgs.Empty)

        pCtxCurrentAttachment = Nothing
    End Sub

End Class
