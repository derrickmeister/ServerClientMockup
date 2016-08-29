Public Class LoginForm
    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Me.DialogResult = DialogResult.OK
        Close()
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class