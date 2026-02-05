Imports System.Runtime.InteropServices

Module Helpers
    Public frmRTB As RTB
    Public DEBUG_MODE As Boolean = False
    Public _formHwnd As IntPtr = IntPtr.Zero
    Public _mainAccessHwnd As IntPtr = IntPtr.Zero
    Public _formParentHwnd As IntPtr = IntPtr.Zero
    Public _accessApp As Object = Nothing ' Instanța Access.Application
    Public WithEvents MonitorTimer As New Timers.Timer(1000) ' Timer pentru monitorizare

    Private _cleaningDone As Boolean = False

    ' =============================================================
    ' CONSOLA DEBUG - API
    ' =============================================================
    <DllImport("user32.dll")>
    Public Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetWindowLong(hWnd As IntPtr, nIndex As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Public Function GetWindowText(hWnd As IntPtr, lpString As System.Text.StringBuilder, nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Public Function GetWindowTextLength(hWnd As IntPtr) As Integer
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Function GetParent(hWnd As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function MoveWindow(ByVal hWnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Function GetClientRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Function GetClassLongPtr(hWnd As IntPtr, nIndex As Integer) As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Function GetClassName(hWnd As IntPtr, lpClassName As System.Text.StringBuilder, nMaxCount As Integer) As Integer
    End Function

    <DllImport("gdi32.dll")>
    Public Function GetObject(hBrush As IntPtr, nCount As Integer, lpObj As IntPtr) As Integer
    End Function

    <DllImport("user32.dll")>
    Public Function EnumChildWindows(hWndParent As IntPtr, lpEnumFunc As EnumChildProcDelegate, lParam As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Function PrintWindow(hWnd As IntPtr, hdcBlt As IntPtr, nFlags As UInteger) As Boolean
    End Function

    <DllImport("user32.dll")>
    Public Function IsWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

    <DllImport("oleacc.dll")>
    Public Function AccessibleObjectFromWindow(ByVal hwnd As IntPtr, ByVal dwId As UInteger, ByRef riid As Guid, <MarshalAs(UnmanagedType.IDispatch)> ByRef ppvObject As Object) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Public Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByVal lParam As String) As IntPtr
    End Function

    <DllImport("user32.dll")>
    Public Function SetFocus(hWnd As IntPtr) As IntPtr
    End Function

    Public Delegate Function EnumChildProcDelegate(hWnd As IntPtr, lParam As IntPtr) As Boolean

    <StructLayout(LayoutKind.Sequential)>
    Private Structure LOGBRUSH
        Public lbStyle As Integer
        Public lbColor As UInteger
        Public lbHatch As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure RECT
        Public Left, Top, Right, Bottom As Integer
    End Structure

    Private Const WM_SETTEXT As Integer = &HC
    Private Const GCL_HBRBACKGROUND As Integer = -10
    Private Const OBJID_NATIVEOM As UInteger = &HFFFFFFF0&
    Private Const acSubform As Integer = 112
    Private Const WM_DESTROY As Integer = &H2
    Private Const WM_CLOSE As Integer = &H10
    Private Const GWL_STYLE As Integer = -16
    Private Const WS_CAPTION As Integer = &HC00000
    Private Const WS_POPUP As Integer = &H80000000

    ' --- Functii pentru detectie copil OFormSub ---
    Private Function FindOFormSub(parentHwnd As IntPtr) As IntPtr
        Dim result As IntPtr = IntPtr.Zero
        Dim callback As EnumChildProcDelegate = Function(hWnd, lParam)
                                                    Dim sb As New System.Text.StringBuilder(256)
                                                    Dim v = GetClassName(hWnd, sb, sb.Capacity)
                                                    If sb.ToString() = "OFormSub" Then
                                                        ' Verificăm dimensiunea
                                                        Dim r As RECT
                                                        If GetClientRect(hWnd, r) Then
                                                            Dim height = r.Bottom - r.Top
                                                            If height >= 2 Then ' prag minim 2 pixeli
                                                                result = hWnd
                                                                Return False ' am găsit unul valid, oprim enumerarea
                                                            End If
                                                        End If
                                                    End If
                                                    Return True ' continuăm enumerarea
                                                End Function

        EnumChildWindows(parentHwnd, callback, IntPtr.Zero)
        Return result
    End Function

    Private Function GetChildWindowBackgroundColor(hWnd As IntPtr) As Color
        Dim r As RECT
        GetClientRect(hWnd, r)
        Dim width = r.Right - r.Left
        Dim height = r.Bottom - r.Top
        Dim bmp As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(bmp)
            Dim hdc = g.GetHdc()
            PrintWindow(hWnd, hdc, 0)
            g.ReleaseHdc(hdc)
        End Using

        ' returneaza pixelul din stanga-sus
        Return bmp.GetPixel(0, 0)
    End Function

    Private Function GetFormObjectFromHwnd(hwndCautat As IntPtr) As Object
        If _accessApp Is Nothing Then Return Nothing

        Try
            Dim forms As Object = _accessApp.Forms

            ' 1. Căutăm în formularele principale (Top Level)
            For Each frm As Object In forms
                ' Verificăm dacă acesta este formularul căutat
                If frm.Hwnd = hwndCautat.ToInt32() Then
                    Return frm
                End If

                ' 2. Dacă nu e el, săpăm după subformulare în interiorul lui
                Dim foundSubForm As Object = FindSubFormRecursive(frm, hwndCautat)
                If foundSubForm IsNot Nothing Then
                    Return foundSubForm
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Eroare la căutarea form-ului: ", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Nothing
    End Function

    Private Function FindSubFormRecursive(parentForm As Object, hwndCautat As IntPtr) As Object
        Try
            Dim controls As Object = parentForm.Controls

            For Each ctl As Object In controls
                ' Verificăm proprietatea ControlType (112 = acSubform)
                ' Folosim Late Binding, deci trebuie să fim atenți la erori
                Dim ctlType As Integer = -1
                Try
                    ctlType = ctl.ControlType
                Catch
                    Continue For
                End Try

                If ctlType = acSubform Then
                    ' Am găsit un container de subform.
                    ' Accesăm proprietatea .Form a controlului (formularul din interior)
                    Dim childForm As Object = Nothing
                    Try
                        childForm = ctl.Form
                    Catch
                        ' E posibil ca subformul să fie gol (SourceObject lipsă)
                        Continue For
                    End Try

                    If childForm IsNot Nothing Then
                        ' Verificăm dacă acesta este cel căutat
                        If childForm.Hwnd = hwndCautat.ToInt32() Then
                            Return childForm
                        End If

                        ' Recursivitate: Căutăm și mai adânc (sub-subform)
                        Dim deepSearch As Object = FindSubFormRecursive(childForm, hwndCautat)
                        If deepSearch IsNot Nothing Then
                            Return deepSearch
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ' Ignorăm erorile punctuale de acces la controale
        End Try

        Return Nothing
    End Function

    ' =============================================================
    ' FUNCȚII GENERALE - WINDOW HELPERS
    ' =============================================================
    Public Sub PositioneazaInParent(Frm As RTB)
        Dim rParent As RECT
        GetClientRect(_formHwnd, rParent)
        If Frm.Width <> (rParent.Right - rParent.Left) OrElse Frm.Height <> (rParent.Bottom - rParent.Top) Then
            MoveWindow(Frm.Handle, 0, 0, rParent.Right - rParent.Left, rParent.Bottom - rParent.Top, True)
        End If
    End Sub

    Public Function GetWindowInfo(hWnd As IntPtr) As String
        If hWnd = IntPtr.Zero Then Return "NULL"

        ' Obține titlul ferestrei
        Dim length As Integer = GetWindowTextLength(hWnd)
        If length = 0 Then Return $"HWND:{hWnd:X} (fără titlu)"

        Dim sb As New System.Text.StringBuilder(length + 1)
        Dim v = GetWindowText(hWnd, sb, sb.Capacity)

        ' Obține ProcessID
        Dim processId As Integer = 0
        Dim v1 = GetWindowThreadProcessId(hWnd, processId)

        Return $"HWND:{hWnd:X} | PID:{processId} | Title:[{sb}]"
    End Function

    ' =============================================================
    ' FUNCȚII GENERALE - ACCESS HELPERS
    ' =============================================================
    Public Sub ConecteazaLaAccess(hwndAccess As IntPtr)
        Dim guidIDispatch As New Guid("{00020400-0000-0000-C000-000000000046}") ' IID_IDispatch
        Dim obj As Object = Nothing

        ' Această funcție returnează obiectul "Window" din modelul de obiecte Access
        Dim hr As Integer = AccessibleObjectFromWindow(hwndAccess, OBJID_NATIVEOM, guidIDispatch, obj)

        If hr >= 0 AndAlso obj IsNot Nothing Then
            Try
                ' Din obiectul Window, urcăm la Application
                Dim windowObj As Object = obj
                _accessApp = windowObj.Application

            Catch ex As Exception
                MessageBox.Show("Eroare la obținerea Application din Window: " & ex.Message, "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End Try
        Else
            MessageBox.Show("Nu s-a putut obține obiectul COM din HWND.", "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End If
    End Sub

    Public Function GetAccessFormParent(childHwnd As IntPtr) As IntPtr
        ' Urcă ierarhia până găsește fereastra de tip formular Access (top-level sau popup)
        Dim currentHwnd As IntPtr = GetParent(childHwnd)
        Dim maxLevels As Integer = 10 ' Protecție împotriva loop infinit
        Dim level As Integer = 0

        While currentHwnd <> IntPtr.Zero AndAlso level < maxLevels
            ' Debug - vezi ce ferestre găsești
            Debug.WriteLine($"  Nivel {level}: {GetWindowInfo(currentHwnd)}")

            ' Verificăm dacă e fereastră top-level (are WS_CAPTION sau WS_POPUP)
            Dim style As Integer = GetWindowLong(currentHwnd, GWL_STYLE)
            Dim isTopLevel As Boolean = (style And WS_CAPTION) <> 0 OrElse (style And WS_POPUP) <> 0

            If isTopLevel Then
                Debug.WriteLine($"  → Găsit formular părinte la nivel {level}")
                Return currentHwnd
            End If

            currentHwnd = GetParent(currentHwnd)
            level += 1
        End While

        Debug.WriteLine("  → NU s-a găsit formular părinte, returnez IntPtr.Zero")
        Return IntPtr.Zero
    End Function

    Private Function GetValoareLocala(numeControl As String) As String
        ' 1. Găsim formularul de care suntem lipiți (ParentHwnd)
        Dim targetForm As Object = GetFormObjectFromHwnd(_formHwnd)

        If targetForm Is Nothing Then
            Return "Form not found"
        End If

        ' 2. Citim controlul direct din acest formular
        Try
            Dim ctl As Object = targetForm.Controls(numeControl)
            If ctl Is Nothing Then Return "Control missing"

            Dim val As Object = ctl.Value
            If val Is Nothing Then Return ""

            Return val.ToString()
        Catch ex As Exception
            Return "Err: " & ex.Message
        End Try
    End Function

    Private Sub CurataResurseSiIesi()
        If _cleaningDone Then Return
        _cleaningDone = True

        ' 1. Oprire Timer
        MonitorTimer?.Stop()

        ' 2. Eliberare Access COM (foarte important cu Try/Catch)
        If _accessApp IsNot Nothing Then
            Try
                ' Eliberam referinta COM
                Marshal.ReleaseComObject(_accessApp)
            Catch ex As Exception
                ' Aceasta eroare e normala daca Access s-a inchis deja (RPC unavailable)
                MessageBox.Show("COM Cleanup Info (Access probabil inchis deja): " & ex.Message, "EROARE", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            _accessApp = Nothing
        End If

        GC.Collect()
        GC.Collect()
    End Sub
End Module
