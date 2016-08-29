Imports System.Data.SqlClient

Public Class DBConnectionHandler

    Public Shared Function GetConnection() As SqlConnection
        Dim scsBuilder = New SqlConnectionStringBuilder
        scsBuilder.DataSource = GetDataSourceInfo()
        scsBuilder.IntegratedSecurity = False
        scsBuilder.UserID = "sa"
        scsBuilder.Password = "simple1234"
        scsBuilder.InitialCatalog = "SuperSimple"
        scsBuilder.ConnectTimeout = 30
        scsBuilder.MultipleActiveResultSets = True
        Return New SqlConnection(scsBuilder.ToString)
    End Function

    Private Shared Function GetDataSourceInfo() As String
        If CommonUtil.RegistryHandler.SQLServerURL.ToUpper.Equals("LOCAL") Then
            Return String.Format(".\{0}", CommonUtil.RegistryHandler.SQLServerInstanceName)
        Else
            Return String.Format("{0}\{1},{2}", CommonUtil.RegistryHandler.SQLServerURL, CommonUtil.RegistryHandler.SQLServerInstanceName, CommonUtil.RegistryHandler.SQLServerPort)
        End If
    End Function

    Public Shared Function ShowAvailableSQLServerList() As Boolean
        Throw New NotImplementedException()
    End Function
End Class
