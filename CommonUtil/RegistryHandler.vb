Public Class RegistryHandler

    Private Shared ReadOnly Property RegistryBaseKeyReadOnly As Microsoft.Win32.RegistryKey
        Get
            Return My.Computer.Registry.LocalMachine.OpenSubKey("Software\MyCompany\ServerClientMockup")
        End Get
    End Property

    Public Shared ReadOnly Property SQLServerInstanceName As String
        Get
            Return RegistryBaseKeyReadOnly.GetValue("SQLServerInstanceName", String.Empty).ToString
        End Get
    End Property

    Public Shared ReadOnly Property SQLServerURL As String
        Get
            Return RegistryBaseKeyReadOnly.GetValue("SQLServerURL", String.Empty).ToString
        End Get
    End Property

    Public Shared ReadOnly Property SQLServerPort As String
        Get
            Return RegistryBaseKeyReadOnly.GetValue("SQLServerPort", String.Empty).ToString
        End Get
    End Property

End Class
