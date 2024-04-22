Imports System.IO
Imports System.Management

Module IDcomputer

    Public Sub MReg()
        Exit Sub
        'Dim Ka As String = GetHWID()
        'Dim D1 As String = Ka.Substring(1, 7)
        'Dim D2 As String = Ka.Substring(Ka.Length - 6, 6)
        'Dim D3 As String = Ka.Substring(Ka.Length - 8, 6)
        'Dim Ka1 As String = D3 & D2 & D1
        'Dim NameKey As String = PathData1 & "\" & Ka1 & ".key"
        ''   Dim mNameReg As String = System.IO.Path.GetFileName(NameKey)
        'Dim SavePath As String = System.IO.Path.Combine(PathData1, NameKey)
        'If System.IO.File.Exists(SavePath) Then
        '    Dim keyFile As StreamReader
        '    keyFile = New StreamReader(NameKey, True)
        '    '  keyFile = New StreamReader(mNameReg, True)
        '    Dim State As String = keyFile.ReadLine()
        '    If State = Encrypt(GetHWID() & "#Imap2D*3D##" & "Cộng hòa xã hội chủ nghĩa Liên xô", "*Vinhkhang#PhucKhanh!!<!!>/") Then
        '        Exit Sub
        '    Else
        '        MsgBox("                          Phần mềm chưa được đăng ký!" & vbCrLf & "        ID của bạn là: " & GetHWID() & vbCrLf & "Hãy liên hệ qua SĐT: 0344958474, Công Ty: Tiến Phát", MsgBoxStyle.OkOnly, "InMap Thông báo")
        '        FrmMain.Dispose()
        '    End If
        'Else
        '    MsgBox("                          Phần mềm chưa được đăng ký!" & vbCrLf & "        ID của bạn là: " & GetHWID() & vbCrLf & "Hãy liên hệ qua SĐT: 0344958474, Công Ty: Tiến Phát", MsgBoxStyle.OkOnly, "InMap Thông báo")
        '    FrmMain.Dispose()
        'End If
    End Sub

    Public Function GetHWID() As String
        Dim cpu As String = GetProcessorId()
        Dim mb As String = GetMotherBoardID()
        Dim hdd As String = GetVolumeSerial("C")
        Dim hwid As String = GetMD5Hash(cpu & mb & hdd & "#Imap2D*3D##")
        Return hwid
    End Function

    Friend Function GetMD5Hash(ByVal strToHash As String) As String
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strToHash)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)
        Dim strResult As String = ""
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Friend Function GetProcessorId() As String
        Dim strProcessorId As String = String.Empty
        Dim query As New SelectQuery("Win32_processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strProcessorId = info("processorId").ToString()
        Next
        Return strProcessorId
    End Function

    Friend Function GetVolumeSerial(Optional ByVal strDriveLetter As String = "C") As String
        Dim disk As ManagementObject
        disk = New ManagementObject(String.Format("win32_logicaldisk.deviceid=""{0}:""", strDriveLetter))
        disk.Get()
        Return disk("VolumeSerialNumber").ToString()
    End Function

    Friend Function GetMotherBoardID() As String
        Dim strMotherBoardID As String = String.Empty
        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)
        Dim info As ManagementObject
        For Each info In search.Get()
            strMotherBoardID = info("SerialNumber").ToString()
        Next
        Return strMotherBoardID
    End Function

    Public Function Decrypt(text As String, password As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim decrypted As String
        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password))
        Array.Copy(temp, 0, hash, 0, 16)
        Array.Copy(temp, 0, hash, 15, 16)
        AES.Key = hash
        AES.Mode = Security.Cryptography.CipherMode.ECB
        Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
        Dim Buffer As Byte() = Convert.FromBase64String(text)
        decrypted = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return decrypted
    End Function

    Public Function Encrypt(text As String, password As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim Hash_AES As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim encrypted As String
        Dim hash(31) As Byte
        Dim temp As Byte() = Hash_AES.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(password))
        Array.Copy(temp, 0, hash, 0, 16)
        Array.Copy(temp, 0, hash, 15, 16)
        AES.Key = hash
        AES.Mode = Security.Cryptography.CipherMode.ECB
        Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
        Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(text)
        encrypted = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Return encrypted
    End Function

End Module
