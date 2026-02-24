Imports System.ComponentModel
Imports System.Runtime.InteropServices

Module Start
    Private ReadOnly Ver As Single = CSng(Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major)

    Sub Main()
        Try
            Dim args As String() = Environment.GetCommandLineArgs()
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2)
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
#If DEBUG Then
            If _formHwnd = IntPtr.Zero Or _mainAccessHwnd = IntPtr.Zero Then
                '################################################
                _formHwnd = New IntPtr(5509778) '################
                '################################################
                _mainAccessHwnd = New IntPtr(7012612)
            End If
#Else

            If args.Length <= 1 And Not DEBUG_MODE Then
                MessageBox.Show("EROARE: Aplicatia poate fi pornita DOAR din AVACONT (/frm:? /acc:? ", $"RTB_Start v{Ver}", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(-1)
            End If

            For Each arg As String In args
                Dim lowerArg As String = arg.ToLower()

                If lowerArg.StartsWith("/frm:") Then
                    _formHwnd = New IntPtr(Long.Parse(arg.Substring(5)))
                ElseIf lowerArg.StartsWith("/acc:") Then
                    _mainAccessHwnd = New IntPtr(Long.Parse(arg.Substring(5)))
                End If
            Next

            If _formHwnd = IntPtr.Zero Or _mainAccessHwnd = IntPtr.Zero Then
                MessageBox.Show("EROARE: Parametrii de lansare invalizi!", "RTB_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(-1)
            End If
#End If
            ' Conectare COM
            If Not IsWindow(_mainAccessHwnd) Then
                MessageBox.Show("EROARE: Fereastra Access invalida in DEBUG MODE!", "RTB_Start", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(-1)
            End If

            ConecteazaLaAccess(_mainAccessHwnd)

            ' === GĂSIRE FORMULAR PĂRINTE ACCESS ===
            Debug.WriteLine("Căutare formular părinte Access:")
            _formParentHwnd = GetAccessFormParent(_formHwnd)

            If _formParentHwnd = IntPtr.Zero Then
                _formParentHwnd = _formHwnd
            End If
            ' ============================================

            If Not IsWindow(_formHwnd) OrElse Not IsWindow(_formParentHwnd) Then
                MessageBox.Show("EROARE: Fereastra formular Access invalida!", "RTB_Start", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Environment.Exit(-1)
            End If

            ' Creare instanță formular
            frmRTB = New RTB()

            ' Adăugare handlere pentru sincronizare cu Access
            AddHandler frmRTB.txtExplicatieScurta.LostFocus, AddressOf ScrieInAccessExplicatieScurta
            AddHandler frmRTB.rtbExplicatieLunga.LostFocus, AddressOf ScrieInAccessExplicatieLunga

            Dim spHwnd As IntPtr = SetParent(frmRTB.Handle, _formHwnd)
            'SetParent returneaza HWND-ul anterior al ferestrei copil daca reuseste, sau NULL daca esueaza
            If spHwnd = IntPtr.Zero Then
                Dim dllErrInt As Integer = Marshal.GetLastWin32Error()
                Dim dllErr As String = New Win32Exception(dllErrInt).Message
                MessageBox.Show("EROARE: Formularul ACCESS nu este valid!" & ControlChars.CrLf & dllErr & ControlChars.CrLf & $"Form Handle:{_formHwnd}", "Tree_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If

            PositioneazaInParent(frmRTB)
            HookParentResize()
            ' Pornire monitorizare fereastră părinte
            AddHandler MonitorTimer.Elapsed, AddressOf VerificaFereastraParinte
            MonitorTimer.Start()

            ' Pornire application loop
            Application.Run(frmRTB)

        Catch ex As Exception
            MessageBox.Show("EROARE: " & ex.Message, "RTB_Start", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End Try
    End Sub

    Private Sub ScrieInAccessExplicatieScurta(sender As Object, e As EventArgs)
        Try
            If _accessApp Is Nothing Then Exit Sub

            Dim targetForm As Object = GetFormObjectFromHwnd(_formHwnd)
            If targetForm Is Nothing Then Exit Sub

            Dim ctl As Object = targetForm.Controls("txtExplicatieScurta")
            If ctl IsNot Nothing Then
                ctl.Value = frmRTB.txtExplicatieScurta.Text
            End If
        Catch ex As Exception
            Debug.WriteLine("Eroare scriere txtExplicatieScurta în Access: " & ex.Message)
        End Try
    End Sub

    Private Sub ScrieInAccessExplicatieLunga(sender As Object, e As EventArgs)
        Try
            If _accessApp Is Nothing Then Exit Sub

            Dim targetForm As Object = GetFormObjectFromHwnd(_formHwnd)
            If targetForm Is Nothing Then Exit Sub

            Dim ctl As Object = targetForm.Controls("rtbExplicatieLunga")
            If ctl IsNot Nothing Then
                ctl.Value = frmRTB.rtbExplicatieLunga.Rtf
            End If
        Catch ex As Exception
            Debug.WriteLine("Eroare scriere rtbExplicatieLunga în Access: " & ex.Message)
        End Try
    End Sub

    Private Sub VerificaFereastraParinte(sender As Object, e As Timers.ElapsedEventArgs)
        If Not IsWindow(_formHwnd) OrElse Not IsWindow(_mainAccessHwnd) Then
            MonitorTimer.Stop()
            UnhookParentResize()

            If frmRTB IsNot Nothing AndAlso frmRTB.IsHandleCreated Then
                frmRTB.Invoke(Sub()
                                  Application.Exit()
                              End Sub)
            Else
                Environment.Exit(0)
            End If
        End If
    End Sub
End Module