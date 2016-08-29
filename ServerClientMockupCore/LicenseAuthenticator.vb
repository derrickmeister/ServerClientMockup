Public Class LicenseAuthenticator

    Public Shared Function GetHardwareID() As String
        Return HardwareIdentificationHandler.GenerateIdentification
    End Function
End Class
