Public Class TestOnScreenKeyboard

    Private _lastFocusedTextBoxCtrl As TextBox
    Private _isKeyboardHidden As Boolean

    Private Sub TestOnScreenKeyboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl IsNot TextBox Then Continue For
            AddHandler ctrl.LostFocus, AddressOf TextBoxLostFocusHandler
        Next
    End Sub

    Private Sub TestOnScreenKeyboard_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        CommonUtil.OnScreenKeybaordHandler.CloseOnScreenKeyboard()
        _isKeyboardHidden = True
    End Sub

    Private Sub TextBoxLostFocusHandler(sender As Object, e As EventArgs)
        _lastFocusedTextBoxCtrl = CType(sender, TextBox)
    End Sub

    Private Sub btnKeyboard_Click(sender As Object, e As EventArgs) Handles btnShowKeyboard.Click
        CommonUtil.OnScreenKeybaordHandler.ShowOnScreenKeyboard(_lastFocusedTextBoxCtrl)
    End Sub

End Class