Imports System.Windows.Forms

Public Class OnScreenKeybaordHandler

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function FindWindow(lpClassName As String, lpWindowName As String) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SendMessage(hWnd As Integer, Msg As UInteger, wParam As Integer, lParam As Integer) As Integer
    End Function

    Public Shared Sub ShowOnScreenKeyboard(Optional inputCtrl As Control = Nothing)
        Try
            Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
        Catch ex As Exception
            Throw New OnScreenKeyboardException("Failed to open On-screen Keyboard.", ex)
        End Try
        If inputCtrl IsNot Nothing Then inputCtrl.Focus()
    End Sub

    Private Const WM_SYSCOMMAND As Integer = &H112
    Private Const SC_CLOSE As Integer = &HF060
    Private Const SC_MINIMIZE As Integer = &HF020

    Public Shared Sub CloseOnScreenKeyboard()
        ' Retrive the handle of the window and sendmessage to the window
        Dim iHandle As Integer = FindWindow("IPTIP_Main_Window", String.Empty)
        If iHandle > 0 Then
            SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0)
        End If
    End Sub

End Class
