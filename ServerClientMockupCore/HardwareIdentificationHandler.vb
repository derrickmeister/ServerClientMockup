Friend Class HardwareIdentificationHandler

    Public Shared Function GenerateIdentification() As String
        Dim check As String(,) = New String(,) {
                {"Win32_NetworkAdapterConfiguration", "MACAddress"},
                {"Win32_Processor", "UniqueId"},
                {"Win32_Processor", "ProcessorId"},
                {"Win32_Processor", "Name"},
                {"Win32_Processor", "Manufacturer"},
                {"Win32_BIOS", "Manufacturer"},
                {"Win32_BIOS", "SMBIOSBIOSVersion"},
                {"Win32_BIOS", "IdentificationCode"},
                {"Win32_BIOS", "SerialNumber"},
                {"Win32_BIOS", "ReleaseDate"},
                {"Win32_BIOS", "Version"},
                {"Win32_DiskDrive", "Model"},
                {"Win32_DiskDrive", "Manufacturer"},
                {"Win32_DiskDrive", "Signature"},
                {"Win32_DiskDrive", "TotalHeads"},
                {"Win32_BaseBoard", "Model"},
                {"Win32_BaseBoard", "Manufacturer"},
                {"Win32_BaseBoard", "Name"},
                {"Win32_BaseBoard", "SerialNumber"},
                {"Win32_VideoController", "DriverVersion"},
                {"Win32_VideoController", "Name"}
            }

        '{"Win32_NetworkAdapterConfiguration", "MACAddress"},
        '{"Win32_Processor", "UniqueId"},
        '{"Win32_Processor", "ProcessorId"},
        '{"Win32_Processor", "Name"},
        '{"Win32_Processor", "Manufacturer"},
        '{"Win32_BIOS", "Manufacturer"},
        '{"Win32_BIOS", "SMBIOSBIOSVersion"},
        '{"Win32_BIOS", "IdentificationCode"},
        '{"Win32_BIOS", "SerialNumber"},
        '{"Win32_BIOS", "ReleaseDate"},
        '{"Win32_BIOS", "Version"},
        '{"Win32_DiskDrive", "Model"},
        '{"Win32_DiskDrive", "Manufacturer"},
        '{"Win32_DiskDrive", "Signature"},
        '{"Win32_DiskDrive", "TotalHeads"},
        '{"Win32_BaseBoard", "Model"},
        '{"Win32_BaseBoard", "Manufacturer"},
        '{"Win32_BaseBoard", "Name"},
        '{"Win32_BaseBoard", "SerialNumber"},
        '{"Win32_VideoController", "DriverVersion"},
        '{"Win32_VideoController", "Name"}

        Dim query As String = "select {1} from {0} {2}"
        Dim queryex As String = " where IPEnabled = 'True'"
        Dim result As String = String.Empty
        Dim sb As New Text.StringBuilder
        For i = 0 To check.GetLength(0) - 1
            Dim oWMI As New System.Management.ManagementObjectSearcher(String.Format(query, check(i, 0), check(i, 1), IIf(i = 0, queryex, String.Empty)))
            For Each mo As System.Management.ManagementObject In oWMI.Get
                result = TryCast(mo(check(i, 1)), String)
                If Not String.IsNullOrEmpty(result) Then
                    sb.AppendLine(result)
                    Exit For
                End If
            Next
        Next

        Dim sec As New Security.Cryptography.MD5CryptoServiceProvider
        Dim enc As New Text.ASCIIEncoding
        Dim bt() As Byte = enc.GetBytes(sb.ToString)
        bt = sec.ComputeHash(bt)
        sb = New Text.StringBuilder
        For i = 0 To bt.Length - 1
            If i > 0 AndAlso i Mod 2 = 0 Then sb.Append("-")
            sb.AppendFormat("{0:X2}", bt(i))
        Next

        Return sb.ToString
    End Function
End Class
