Public Class Main

    Private Shared _stationKey As String = ServerClientMockupCore.LicenseAuthenticator.GetHardwareID

    Private Sub btnTestKeyboard_Click(sender As Object, e As EventArgs) Handles btnTestKeyboard.Click
        Dim testKeyboard As New TestOnScreenKeyboard
        testKeyboard.ShowDialog()
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Validate Database Connection
        If Not DatabaseManager.DBConnectionHandler.ValidateConnection Then
            'Show list of servers to connect
            If Not DatabaseManager.DBConnectionHandler.ShowAvailableSQLServerList() Then Close() : Exit Sub
        End If

        'Validate Station Registration
        If Not ValidateStationRegistration() Then
            'Show station registraion confirmation (Add / Swap)
            Close()
            Exit Sub
        End If

        'Validate Station Activation
        If Not ValidateStationActivation() Then
            Close()
            Exit Sub
        End If
        'Show Login

        Dim frmLogin As New LoginForm
        If frmLogin.ShowDialog = DialogResult.Cancel Then Close() : Exit Sub

    End Sub

    Private Function ValidateDatabaseConnection() As Boolean
        Try
            Using conn As SqlClient.SqlConnection = DatabaseManager.DBConnectionHandler.GetConnection(5)
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function ValidateStationRegistration() As Boolean
        Dim returnVal As Integer
        Using conn As SqlClient.SqlConnection = DatabaseManager.DBConnectionHandler.GetConnection
            conn.Open()
            Using cmd As New SqlClient.SqlCommand("select count(*) from TStation where StationKey = @StationKey", conn)
                cmd.Parameters.AddWithValue("@StationKey", _stationKey)
                returnVal = CInt(cmd.ExecuteScalar)
                If returnVal > 1 Then Throw New Exception("Duplicated StationKey has been detected!")
                Return returnVal = 1
            End Using
        End Using
    End Function

    Private Function ValidateStationActivation() As Boolean
        Return True
    End Function

End Class
