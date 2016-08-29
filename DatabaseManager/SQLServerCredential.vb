Friend Class SQLServerCredential

    Public Property ServerURL As String
    Public Property ServerInstanceName As String
    Public Property ServerPort As String
    Public Property DatabaseName As String = "SuperSimple"
    Public Property UserID As String = "sa"
    Public Property Password As String = "simple1234"

    Public ReadOnly Property FormattedDataSource As String
        Get
            If ServerURL.ToUpper.Equals("LOCAL") OrElse ServerURL.ToUpper.Equals(My.Computer.Name) Then
                Return String.Format(".\{0}", ServerInstanceName)
            Else
                Return String.Format("{0}\{1},{2}", ServerURL, ServerInstanceName, ServerPort)
            End If
        End Get
    End Property

    Public Sub New()
        ServerURL = CommonUtil.RegistryHandler.SQLServerURL
        ServerInstanceName = CommonUtil.RegistryHandler.SQLServerInstanceName
        ServerPort = CommonUtil.RegistryHandler.SQLServerPort
    End Sub

    Friend Sub Save()
        CommonUtil.RegistryHandler.SQLServerURL = ServerURL
    End Sub
End Class
