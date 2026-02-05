Public Class CustomControls
    ' Buton care nu ia focusul
    Public Class NoFocusButton
        Inherits Button

        Public Sub New()
            Me.SetStyle(ControlStyles.Selectable, False)
            ' Adaugă aceste linii pentru un aspect modern de toolbar
            Me.FlatStyle = FlatStyle.Flat
            Me.FlatAppearance.BorderSize = 1
            Me.FlatAppearance.BorderColor = Color.Azure
            Me.BackColor = Color.FromArgb(240, 240, 240)
        End Sub
    End Class

    Public Class NoFocusComboBox
        Inherits ComboBox

        Public Sub New()
            ' Nu mai setăm Selectable = False aici, pentru a permite deschiderea listei
            Me.DropDownStyle = ComboBoxStyle.DropDownList
            Me.FlatStyle = FlatStyle.Flat
        End Sub

        Protected Overrides Sub OnSelectedIndexChanged(e As EventArgs)
            MyBase.OnSelectedIndexChanged(e)
            ' După ce utilizatorul a ales un font, returnăm focusul la RTB
            ' pentru ca acesta să redevină controlul activ
            Dim rtb = Me.FindForm().Controls.Find("rtbExplicatieLunga", True).FirstOrDefault()
            If rtb IsNot Nothing Then rtb.Focus()
        End Sub
    End Class


End Class
