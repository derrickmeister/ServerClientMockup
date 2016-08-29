Imports System.Data.SqlClient

Public Class DBConnectionHandler

    Private Shared _sqlServerCredential As SQLServerCredential

    Public Shared Function ValidateConnection(Optional throwException As Boolean = False) As Boolean
        Try
            Using conn As SqlConnection = GetConnection(5)
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
            If throwException Then Throw
            Return False
        End Try
    End Function

    Public Shared Function GetConnection(Optional connectionTimeoutSec As Integer = 15) As SqlConnection
        If _sqlServerCredential Is Nothing Then _sqlServerCredential = New SQLServerCredential

        Dim scsBuilder = New SqlConnectionStringBuilder
        scsBuilder.DataSource = _sqlServerCredential.FormattedDataSource
        scsBuilder.IntegratedSecurity = False
        scsBuilder.UserID = _sqlServerCredential.UserID
        scsBuilder.Password = _sqlServerCredential.Password
        scsBuilder.InitialCatalog = _sqlServerCredential.DatabaseName
        scsBuilder.ConnectTimeout = connectionTimeoutSec
        scsBuilder.MultipleActiveResultSets = True
        Return New SqlConnection(scsBuilder.ToString)
    End Function

    Public Shared Function ShowAvailableSQLServerList() As Boolean
        Dim sqlServerSelectionPopup As New SQLServerSelectionPopup(_sqlServerCredential)
        Return sqlServerSelectionPopup.ShowDialog = Windows.Forms.DialogResult.OK
    End Function
End Class
