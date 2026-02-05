Imports System.ComponentModel
Imports System.Runtime.InteropServices

Module Start
    Sub Main()
        Try
            Dim args As String() = Environment.GetCommandLineArgs()

            If args.Length <= 1 And Not DEBUG_MODE Then
                MessageBox.Show("EROARE: Aplicatia poate fi pornita DOAR din AVACONT (/frm:? /acc:? ", "RTB_Start", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

#If DEBUG Then
            If _formHwnd = IntPtr.Zero Or _mainAccessHwnd = IntPtr.Zero Then
                '################################################
                _formHwnd = New IntPtr(1510336) '################
                '################################################
                _mainAccessHwnd = New IntPtr(3933810)
            End If
#Else
            If _formHwnd = IntPtr.Zero Or _mainAccessHwnd = IntPtr.Zero Then
                messagebox.show("EROARE: Parametrii de lansare invalizi!", "RTB_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Debug.WriteLine("AVERTISMENT: Nu s-a găsit formular părinte!")
            Else
                Debug.WriteLine($"Formular părinte găsit: {GetWindowInfo(_formParentHwnd)}")
            End If
            ' ============================================

            Dim spHwnd As IntPtr = SetParent(frmRTB.Handle, _formHwnd)
            'SetParent returneaza HWND-ul anterior al ferestrei copil daca reuseste, sau NULL daca esueaza
            If spHwnd = IntPtr.Zero Then
                Marshal.GetLastWin32Error()
                Dim dllErrInt As Integer = Marshal.GetLastWin32Error()
                Dim dllErr As String = New Win32Exception(dllErrInt).Message
                MessageBox.Show("EROARE: Formularul ACCESS nu este valid!" & ControlChars.CrLf & dllErr & ControlChars.CrLf & $"Form Handle:{_formHwnd}", "Tree_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If

            PositioneazaInParent(frmRTB)
        Catch ex As Exception
            MessageBox.Show("EROARE: " & ex.Message, "RTB_Start", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(-1)
        End Try
    End Sub
End Module
