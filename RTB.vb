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

        ' Populare selector fonturi
        PopuleazaSelectorFonturi()

        ' Citire date din Access la deschidere
        CitesteDateDinAccess()
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

        ' Dezactivam DockStyle.Fill pentru ca acesta impiedica redimensionarea manuala
        rtbExplicatieLunga.Dock = DockStyle.None

        ' Ajustam pozitia (Y=44) si inaltimea (Total - 44) pentru a face loc toolbar-ului
        ' Toolbar-ul are inaltimea 44 conform definitiei din designer
        rtbExplicatieLunga.SetBounds(0, 42, pnlExplicatieHost.ClientSize.Width, pnlExplicatieHost.ClientSize.Height - 42)

        ' Setam Anchor pentru ca RTB-ul sa urmareasca marginile containerului la resize
        rtbExplicatieLunga.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
    End Sub

    Private Sub HideToolbar()
        pToolbarPanel.Visible = False

        ' Revenim la DockStyle.Fill pentru a ocupa tot spatiul cand toolbar-ul este ascuns
        rtbExplicatieLunga.Dock = DockStyle.Fill
    End Sub

    Private Sub PopuleazaSelectorFonturi()
        ' pCmbFonts este numele pe care il poti da controlului in Designer
        pCmbFonts.Items.Clear()
        For Each family In FontFamily.Families
            pCmbFonts.Items.Add(family.Name)
        Next
        ' Setam fontul curent ca selectie default
        pCmbFonts.Text = rtbExplicatieLunga.Font.Name
    End Sub

    Private Sub CloseFormAndExit() Handles BtnClose.Click
        Try
            Const WM_CLOSE As Integer = &H10

            If _formHwnd <> IntPtr.Zero Then
                SendMessage(_formHwnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero)
            End If
        Catch ex As Exception
            Debug.WriteLine("Eroare la trimitere WM_CLOSE: " & ex.Message)
        Finally
            CurataResurseSiIesi()
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        If ValidateForm() Then
            CloseFormAndExit()
        End If
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
        ' Verificăm dacă ignorăm explicit (ex: ColorDialog deschis)
        If pIgnoreLostFocus Then Exit Sub

        ' TRUC: Verificăm unde se află mouse-ul în momentul pierderii focusului
        ' Dacă este deasupra panelului de toolbar, nu îl închidem
        Dim mousePos = pToolbarPanel.PointToClient(Control.MousePosition)
        If pToolbarPanel.ClientRectangle.Contains(mousePos) Then
            Exit Sub ' Utilizatorul interacționează cu toolbar-ul, deci îl lăsăm vizibil
        End If

        HideToolbar()
    End Sub

    Private Sub rtbExplicatieLunga_SelectionChanged(sender As Object, e As EventArgs) Handles rtbExplicatieLunga.SelectionChanged
        ActualizeazaStareButoane()
    End Sub

    Private Sub ActualizeazaAspectButon(btn As Button, esteActiv As Boolean)
        If esteActiv Then
            ' Culoare de fundal albastru deschis și margine mai groasă
            btn.BackColor = Color.LightSteelBlue
            btn.FlatAppearance.BorderColor = Color.DodgerBlue
            btn.FlatAppearance.BorderSize = 2
        Else
            ' Resetare la aspectul standard
            btn.BackColor = Color.FromArgb(240, 240, 240) ' Culoarea default a controlului
            btn.FlatAppearance.BorderColor = Color.Azure
            btn.FlatAppearance.BorderSize = 1
        End If
    End Sub

    Private Sub ActualizeazaStareButoane()
        ' Verificare de siguranta pentru controale
        If rtbExplicatieLunga Is Nothing Or pCmbFonts Is Nothing Then Exit Sub

        Dim f As Font = rtbExplicatieLunga.SelectionFont

        ' Daca selectia este mixta (ex: ai selectat doua cuvinte cu fonturi diferite), 
        ' SelectionFont returneaza Nothing. In acest caz, afisam fontul de baza al controlului.
        If f Is Nothing Then f = rtbExplicatieLunga.Font

        ' 1. Actualizam butoanele (Bold, Italic, Underline)
        ' (Presupunem ca ai metoda ActualizeazaAspectButon definita anterior)
        ActualizeazaAspectButon(pBtnBold, f.Bold)
        ActualizeazaAspectButon(pBtnItalic, f.Italic)
        ActualizeazaAspectButon(pBtnUnderline, f.Underline)

        ' 2. Actualizam selectorul de fonturi (ComboBox)
        ' Dezactivam temporar evenimentul ca sa nu rescriem formatarea textului
        RemoveHandler pCmbFonts.SelectedIndexChanged, AddressOf pCmbFonts_SelectedIndexChanged

        pCmbFonts.Text = f.Name

        ' Reactivam evenimentul
        AddHandler pCmbFonts.SelectedIndexChanged, AddressOf pCmbFonts_SelectedIndexChanged
    End Sub

    ' ******************************************************************
    '  FORMATARE TEXT - butoane toolbar
    ' ******************************************************************
    Private Sub pCmbFonts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pCmbFonts.SelectedIndexChanged
        ' Verificăm dacă există o selecție sau un font de bază
        If rtbExplicatieLunga Is Nothing Then Exit Sub

        ' Numele fontului ales
        Dim numeFont As String = pCmbFonts.Text
        If String.IsNullOrEmpty(numeFont) Then Exit Sub

        ' Luăm fontul curent al selecției
        Dim fontCurent As Font = rtbExplicatieLunga.SelectionFont

        ' Dacă selecția e mixtă (fontCurent e Nothing), folosim fontul default al controlului
        If fontCurent Is Nothing Then fontCurent = rtbExplicatieLunga.Font

        Try
            ' Creăm noul font păstrând dimensiunea și stilul (Bold, Italic etc.)
            Dim noulFont As New Font(numeFont, fontCurent.Size, fontCurent.Style)

            ' Aplicăm noul font selecției
            rtbExplicatieLunga.SelectionFont = noulFont

            ' Redăm focusul către RichTextBox pentru a vedea cursorul
            rtbExplicatieLunga.Focus()
        Catch ex As Exception
            Debug.WriteLine("Eroare la schimbarea fontului: " & ex.Message)
        End Try
    End Sub

    Private Sub ToggleStyle(st As FontStyle)
        Dim f = rtbExplicatieLunga.SelectionFont
        If f Is Nothing Then f = rtbExplicatieLunga.Font

        Dim newStyle As FontStyle = If((f.Style And st) = st, f.Style And Not st, f.Style Or st)
        rtbExplicatieLunga.SelectionFont = New Font(f, newStyle)

        ActualizeazaStareButoane()
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
        Try
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

            SetValoareLocala("txtExplicatieScurta", txtExplicatieScurta.Text)
            SetValoareLocala("rtbExplicatieLunga", rtbExplicatieLunga.Rtf)

            Return True
        Catch ex As Exception
            MessageBox.Show("Eroare la validare: " & ex.Message, "Validare", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return True
    End Function

    Private Sub CitesteDateDinAccess()
        Try
            ' Verificam daca avem conexiune la Access
            If _accessApp Is Nothing Then Exit Sub

            ' Gasim obiectul formular din Access folosind HWND-ul primit la lansare
            Dim targetForm As Object = GetFormObjectFromHwnd(_formHwnd)
            If targetForm Is Nothing Then Exit Sub

            ' Citire Explicatie Scurta (TextBox standard)
            Dim ctlScurta As Object = Nothing
            Try : ctlScurta = targetForm.Controls("txtExplicatieScurta") : Catch : End Try

            If ctlScurta IsNot Nothing AndAlso Not IsDBNull(ctlScurta.Value) Then
                txtExplicatieScurta.Text = ctlScurta.Value.ToString()
            End If

            ' Citire Explicatie Lunga (presupunem ca Access stocheaza RTF)
            Dim ctlLunga As Object = Nothing
            Try : ctlLunga = targetForm.Controls("rtbExplicatieLunga") : Catch : End Try

            If ctlLunga IsNot Nothing AndAlso Not IsDBNull(ctlLunga.Value) Then
                Dim valoare As String = ctlLunga.Value.ToString()
                ' Verificam daca este string RTF valid
                If valoare.StartsWith("{\rtf") Then
                    rtbExplicatieLunga.Rtf = valoare
                Else
                    rtbExplicatieLunga.Text = valoare
                End If
            End If

        Catch ex As Exception
            Debug.WriteLine("Eroare la incarcarea datelor initiale din Access: " & ex.Message)
        End Try
    End Sub
End Class