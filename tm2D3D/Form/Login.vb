Imports System.Globalization
Imports System.IO
Imports System.Management
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Xml
Public Class Login
#Region "Hàm Khởi tạo Login và Biến"
    Public Shared Instance As Login
    Dim CongIDMay As String
    Dim IDMay As String
    Dim ID As String
    Dim MaDau As String
    Dim MaGiua1 As String
    Dim MaGiua2 As String
    Dim MaCuoi As String
    Dim Folder_Data As String
    Dim Folder_Key As String
    Dim MoPM As Boolean = False
    Dim RPMDK As String
    Dim TKhoan As String = "Admin"
    Dim MKhau As String = "123456"
    Dim LinkluuKey As String = "C:/Program Files (x86)"
    Private GioiHan As Integer = 0
    Dim LuaChon As String = 0
    Dim XoaKeey As Integer = 0
    Dim TG_MT As String = DateTime.Now.ToString()
    Dim dateTime_MT As DateTime = DateTime.Parse(TG_MT)
    Dim Time_MT As String = dateTime_MT.Date.ToString("MM/dd/yyyy")
    Dim GMID As String
    Dim FullTimeHT As String
    Dim FullTimeHT_1 As String
    Dim PQ_SNHH As String
    Dim FullTimeHH As String
    Dim GT_PQ As String
    Dim Full_SNHH As String
    Dim ThoiGianHT As String
    Dim ThoiGianHT_1 As String
    Dim ThoiGianHH As String
    Dim ChuyenTG As DateTime
    Dim ngayThoiGianHT_1 As DateTime
    Dim ngayThoiGianHT As DateTime
    Dim GiaTri() As String = {"0", "z", "x", "v", "t", "r", "p", "n", "l", "j", "h", "f", "d", "b", "y", "w", "u", "s", "q", "o", "m", "k", "i", "g", "e", "c", "a", "A", "B", "C", "D", "E", "F"}
    Dim LuuPTPin As String
#End Region
#Region "Load"
    Public Sub New()
        InitializeComponent()
        Instance = Me
    End Sub
    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lb_KichHoat.Visible = True
        Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
        Dim folderName As String = "Data"
        Folder_Key = "PMDK"
        Folder_Data = Path.Combine(baseDirectory, folderName)
        Folder_Key = Path.Combine(LinkluuKey, Folder_Key)
        If Not Directory.Exists(Folder_Data) Then Directory.CreateDirectory(Folder_Data)
        If Not Directory.Exists(Folder_Key) Then Directory.CreateDirectory(Folder_Key)
        CongIDMay = GetMD5Hash(GetProcessorId() & GetMotherboardID() & GetVolumeSerial("C"))
        ID = TextToHEX(CongIDMay.Substring(1, 1) & CongIDMay.Substring(7, 1) & CongIDMay.Substring(3, 1) & CongIDMay.Substring(CongIDMay.Length - 1, 1))
        IDMay = CongIDMay.Substring(1, 1) & CongIDMay.Substring(7, 1) & CongIDMay.Substring(3, 1) & CongIDMay.Substring(CongIDMay.Length - 1, 1)
        GiaMaKey()
        If MoPM = False Then
            MessageBox.Show("Chú ý: Phiên bản hiện tại của phần mềm chưa được đăng ký." & Environment.NewLine & "ID của bạn là: " & ID & Environment.NewLine & "SĐT: 0344958474" & Environment.NewLine & "Công Ty: Tiến Phát", "Thông Báo!", MessageBoxButtons.OK)
            Clipboard.SetText(ID)
        End If
    End Sub
#End Region
#Region "Hàm mã hóa ID Máy"
    Function TextToHEX(text As String) As String
        Dim hexBuilder As New StringBuilder()
        For Each c As Char In text
            hexBuilder.AppendFormat("{0:X2}", Convert.ToInt32(c))
        Next
        Return hexBuilder.ToString()
    End Function
    Function HexToText(hexString As String) As String
        Dim textBuilder As New StringBuilder()
        For i As Integer = 0 To hexString.Length - 2 Step 2
            Dim hexByte As String = hexString.Substring(i, 2)
            textBuilder.Append(Chr(Convert.ToInt32(hexByte, 16)))
        Next
        Return textBuilder.ToString()
    End Function
    Public Function GetMD5Hash(ByVal input As String) As String
        Using md5 As MD5 = MD5.Create()
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hashBytes As Byte() = md5.ComputeHash(inputBytes)
            Dim sb As New StringBuilder()
            For i As Integer = 0 To hashBytes.Length - 1
                sb.Append(hashBytes(i).ToString("x2"))
            Next
            Return sb.ToString()
        End Using
    End Function
    Private Sub GiaMaKey()
        Try
            Dim filePath As String = Path.Combine(Folder_Data, ID + ".txt")
            If File.Exists(filePath) Then
                Dim fileContent As String = File.ReadAllText(filePath)
                Dim parts As String() = fileContent.Split("-"c)
                If parts.Length = 5 Then
                    GMID = parts(0)
                    FullTimeHT = parts(1)
                    PQ_SNHH = parts(2)
                    FullTimeHH = parts(3)
                    FullTimeHT_1 = parts(4)
                    If GMID = IDMay Then
                        GM_NgayHT()
                    Else
                        lbl_Status.Text = "Chưa Kích Hoạt"
                        lbl_Status.ForeColor = Color.Red
                        lb_KichHoat.Visible = True
                    End If
                Else
                    lbl_Status.Text = "Chưa Kích Hoạt"
                    lbl_Status.ForeColor = Color.Red
                    lb_KichHoat.Visible = True
                End If
            Else
                lbl_Status.Text = "Chưa Kích Hoạt"
                lbl_Status.ForeColor = Color.Red
                lb_KichHoat.Visible = True
            End If
        Catch
            lbl_Status.Text = "Chưa Kích Hoạt"
            lbl_Status.ForeColor = Color.Red
            lb_KichHoat.Visible = True
        End Try
    End Sub
    Private Sub GM_NgayHT()
        Try
            Dim Ngay_HT As String = FullTimeHT(2)
            Dim Thang_HT As String = FullTimeHT(1)
            Dim Nam_HT1 As String = FullTimeHT(0)
            Dim Nam_HT2 As String = FullTimeHT(3)
            Dim VT_NgayHT As Integer = Array.IndexOf(GiaTri, Ngay_HT)
            Dim VT_NgayHT1 As String = If(VT_NgayHT < 10, "0" & VT_NgayHT.ToString(), VT_NgayHT.ToString())
            Dim VT_ThangHT As Integer = Array.IndexOf(GiaTri, Thang_HT)
            Dim VT_NamHT1 As Integer = Array.IndexOf(GiaTri, Nam_HT1)
            Dim VT_NamHT2 As Integer = Array.IndexOf(GiaTri, Nam_HT2)
            Dim VT_ThangHT1 As String = If(VT_ThangHT < 10, "0" & VT_ThangHT.ToString(), VT_ThangHT.ToString())
            ThoiGianHT = VT_ThangHT1 & VT_NgayHT1 & VT_NamHT1 & VT_NamHT2
            If DateTime.TryParseExact(ThoiGianHT, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, ngayThoiGianHT) Then
                If ngayThoiGianHT <= DateTime.Now Then
                    GM_SNHH()
                Else
                    MessageBox.Show("Lưu ý: Đồng hồ máy tính không đồng bộ với thời gian hệ thống. Vui lòng kiểm tra và điều chỉnh.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GM_SNHH()
        Try
            Dim SNHH_1 As String
            Dim SNHH_2 As String
            Dim SNHH_3 As String
            Dim GT_SNHH_1 As Integer
            Dim GT_SNHH_2 As Integer
            Dim GT_SNHH_3 As Integer
            If PQ_SNHH.Length = 2 Then
                SNHH_1 = PQ_SNHH.Substring(0, 1)
                GT_SNHH_1 = Array.IndexOf(GiaTri, SNHH_1)
                Full_SNHH = GT_SNHH_1.ToString()
            End If
            If PQ_SNHH.Length = 3 Then
                SNHH_1 = PQ_SNHH.Substring(0, 1)
                SNHH_2 = PQ_SNHH.Substring(1, 1)
                GT_SNHH_1 = Array.IndexOf(GiaTri, SNHH_1)
                GT_SNHH_2 = Array.IndexOf(GiaTri, SNHH_2)
                Full_SNHH = GT_SNHH_1.ToString() & GT_SNHH_2.ToString()
            End If
            If PQ_SNHH.Length = 4 Then
                SNHH_1 = PQ_SNHH.Substring(0, 1)
                SNHH_2 = PQ_SNHH.Substring(1, 1)
                SNHH_3 = PQ_SNHH.Substring(2, 1)
                GT_SNHH_1 = Array.IndexOf(GiaTri, SNHH_1)
                GT_SNHH_2 = Array.IndexOf(GiaTri, SNHH_2)
                GT_SNHH_3 = Array.IndexOf(GiaTri, SNHH_3)
                Full_SNHH = GT_SNHH_1.ToString() & GT_SNHH_2.ToString() & GT_SNHH_3.ToString()
            End If
            GT_PQ = PQ_SNHH.Substring(PQ_SNHH.Length - 1, 1)
            TimeHetHan()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TimeHetHan()
        Try
            Dim Ngay_HH As String = FullTimeHH(2)
            Dim Thang_HH As String = FullTimeHH(1)
            Dim Nam_HH1 As String = FullTimeHH(0)
            Dim Nam_HH2 As String = FullTimeHH(3)
            Dim VT_NgayHH As Integer = Array.IndexOf(GiaTri, Ngay_HH)
            Dim VT_NgayHH1 As String = If(VT_NgayHH < 10, "0" & VT_NgayHH.ToString(), VT_NgayHH.ToString())
            Dim VT_ThangHH As Integer = Array.IndexOf(GiaTri, Thang_HH)
            Dim VT_NamHH1 As Integer = Array.IndexOf(GiaTri, Nam_HH1)
            Dim VT_NamHH2 As Integer = Array.IndexOf(GiaTri, Nam_HH2)
            Dim VT_ThangHH1 As String = If(VT_ThangHH < 10, "0" & VT_ThangHH.ToString(), VT_ThangHH.ToString())
            ThoiGianHH = VT_ThangHH1 & VT_NgayHH1 & VT_NamHH1 & VT_NamHH2
            If DateTime.TryParseExact(ThoiGianHT, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, ChuyenTG) Then
                Dim newDate As DateTime = ChuyenTG.AddDays(Full_SNHH)
                If ThoiGianHH = newDate.ToString("MMddyyyy") Then
                    KhoaNgay()
                Else
                    MessageBox.Show("Mã Key không chính xác. Hãy đảm bảo bạn đã nhập đúng thông tin và thử lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub KhoaNgay()
        Try
            Dim Ngay_HT_1 As String = FullTimeHT_1(2)
            Dim Thang_HT_1 As String = FullTimeHT_1(1)
            Dim Nam_HT1_1 As String = FullTimeHT_1(0)
            Dim Nam_HT2_1 As String = FullTimeHT_1(3)
            Dim VT_NgayHT_1 As Integer = Array.IndexOf(GiaTri, Ngay_HT_1)
            Dim VT_NgayHT1_1 As String = If(VT_NgayHT_1 < 10, "0" & VT_NgayHT_1.ToString(), VT_NgayHT_1.ToString())
            Dim VT_ThangHT_1 As Integer = Array.IndexOf(GiaTri, Thang_HT_1)
            Dim VT_NamHT1_1 As Integer = Array.IndexOf(GiaTri, Nam_HT1_1)
            Dim VT_NamHT2_1 As Integer = Array.IndexOf(GiaTri, Nam_HT2_1)
            Dim VT_ThangHT1_1 As String = If(VT_ThangHT_1 < 10, "0" & VT_ThangHT_1.ToString(), VT_ThangHT_1.ToString())
            ThoiGianHT_1 = VT_ThangHT1_1 & VT_NgayHT1_1 & VT_NamHT1_1 & VT_NamHT2_1
            If DateTime.TryParseExact(ThoiGianHT_1, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, ngayThoiGianHT_1) Then
                If ngayThoiGianHT_1 <= DateTime.Now Then
                    SoSanhBaoMat()
                Else
                    MessageBox.Show("Lưu ý: Đồng hồ máy tính không đồng bộ với thời gian hệ thống. Vui lòng kiểm tra và điều chỉnh.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LayTGMT()
        Try
            Dim dateTime_MT As DateTime = DateTime.Parse(DateTime.Now.ToString())
            Time_MT = dateTime_MT.[Date].ToString("MM/dd/yyyy")
            Dim Ngay_HT As String = Time_MT.Substring(3, 2)
            Dim Ngay_HT_1 As Integer = 0
            Dim Ngay_HT_2 As String = ""
            Dim Thang_HT_1 As Integer = 0
            Dim Thang_HT_2 As String = ""
            Dim Namdau_HT_1 As Integer = 0
            Dim Namdau_HT1 As String = ""
            Dim Namcuoi_HT_1 As Integer = 0
            Dim Namcuoi_HT2 As String = ""
            If Integer.TryParse(Ngay_HT, Ngay_HT_1) AndAlso Ngay_HT_1 >= 0 AndAlso Ngay_HT_1 < GiaTri.Length Then
                Ngay_HT_2 = GiaTri(Ngay_HT_1)
            End If
            Dim Thang_HT As String = Time_MT.Substring(0, 2)
            If Integer.TryParse(Thang_HT, Thang_HT_1) AndAlso Thang_HT_1 >= 0 AndAlso Thang_HT_1 < GiaTri.Length Then
                Thang_HT_2 = GiaTri(Thang_HT_1)
            End If
            Dim Namdau_HT As String = Time_MT.Substring(6, 2)
            If Integer.TryParse(Namdau_HT, Namdau_HT_1) AndAlso Namdau_HT_1 >= 0 AndAlso Namdau_HT_1 < GiaTri.Length Then
                Namdau_HT1 = GiaTri(Namdau_HT_1)
            End If
            Dim Namcuoi_HT As String = Time_MT.Substring(8, 2)
            If Integer.TryParse(Namcuoi_HT, Namcuoi_HT_1) AndAlso Namcuoi_HT_1 >= 0 AndAlso Namcuoi_HT_1 < GiaTri.Length Then
                Namcuoi_HT2 = GiaTri(Namcuoi_HT_1)
            End If
            FullTimeHT_1 = Namdau_HT1 & Thang_HT_2 & Ngay_HT_2 & Namcuoi_HT2
            If File.Exists(Path.Combine(Folder_Data, ID + ".txt")) Then
                Dim fileContent As String = File.ReadAllText(Path.Combine(Folder_Data, ID + ".txt"))
                Dim parts As String() = fileContent.Split("-"c)
                If parts.Length = 4 Then
                    File.WriteAllText(Path.Combine(Folder_Data, ID + ".txt"), fileContent + "-" + FullTimeHT_1)
                ElseIf parts.Length = 5 Then
                    parts(4) = FullTimeHT_1
                    File.WriteAllText(Path.Combine(Folder_Data, ID + ".txt"), String.Join("-", parts))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SoSanhBaoMat()
        Try
            Dim ngayThoiGianHH As DateTime
            If DateTime.TryParseExact(ThoiGianHH, "MMddyyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, ngayThoiGianHH) Then
                LayTGMT()
                If ngayThoiGianHH >= DateTime.Now Then
                    MoPM = True
                    LuaChon = TextToHEX(IDMay & GT_PQ)
                    DeleteSettingsFile()
                    Settings()
                    lbl_Status.Text = "Đã Kích Hoạt"
                    lbl_Status.ForeColor = Color.Green
                    lb_KichHoat.ForeColor = Color.FromArgb(0, 117, 214)
                    lb_KichHoat.Text = "Thời gian hết hạn: " + ngayThoiGianHH.ToString("dd-MM-yyyy")
                    Try
                        Dim hieuThoiGian As TimeSpan = ngayThoiGianHH - DateTime.Now
                        If hieuThoiGian.Days.ToString() < 10 Then
                            lb_SNCL.Visible = True
                            lb_SNCL.Text = "Số ngày còn lại: " + hieuThoiGian.Days.ToString()
                        End If
                    Catch ex As Exception
                    End Try
                Else
                    MessageBox.Show("Lưu ý: Phiên bản hiện tại của phần mềm đã hết hạn. Hãy liên hệ với bộ phận hỗ trợ để biết thêm thông tin về cách gia hạn sử dụng.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "ID Máy Tính"
    Public Shared Function GetProcessorId() As String ' lấy thông số CPU
        Try
            Dim strProcessorId As String = String.Empty
            Dim query As New SelectQuery("Win32_processor")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strProcessorId = info("processorId").ToString()
            Next
            Return strProcessorId
        Catch ex As Exception

        End Try
    End Function
    Public Shared Function GetMotherboardID() As String ' lấy thông tin mainboard
        Try
            Dim strMotherBoardID As String = String.Empty
            Dim query As New SelectQuery("Win32_BaseBoard")
            Dim search As New ManagementObjectSearcher(query)
            Dim info As ManagementObject
            For Each info In search.Get()
                strMotherBoardID = info("SerialNumber").ToString()
            Next
            Return strMotherBoardID
        Catch ex As Exception

        End Try
    End Function
    Public Shared Function GetVolumeSerial(Optional ByVal driveLetter As String = "C") As String ' lấy thông tin ổ đĩa
        Try
            Dim disk As New ManagementObject($"win32_logicaldisk.deviceid=""{driveLetter}:""")
            disk.Get()
            Dim volumeSerial As String = disk("VolumeSerialNumber").ToString()
            Return volumeSerial
        Catch ex As Exception

        End Try
    End Function
#End Region
#Region "Nút Nhấn"
    Private Sub btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        ValueChangedEvent.Invoke(Me, "Thoat")
        Threading.Thread.Sleep(100)
        Application.Exit()
    End Sub
    Private Sub btn_DangNhap_Click(sender As Object, e As EventArgs) Handles btn_DangNhap.Click
        Try
            If MoPM Then
                If String.IsNullOrWhiteSpace(txtUserName.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản, mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim username As String = txtUserName.Text.Trim()
                    Dim password As String = txtPassword.Text.Trim()
                    username = SanitizeInput(username) ' Loại bỏ các ký tự đặc biệt từ username và password
                    password = SanitizeInput(password)
                    If TKhoan = username Then
                        If MKhau = password Then
                            LayThoiGian()
                            If GT_PQ = "r" Then
                                ValueChangedEvent.Invoke(Me, "CCT")
                                Threading.Thread.Sleep(100)
                                Me.Close()
                            Else
                                ValueChangedEvent.Invoke(Me, "CCL")
                                Threading.Thread.Sleep(100)
                                Me.Close()
                            End If
                        Else
                            txtPassword.Text = ""
                            txtUserName.Text = ""
                            MessageBox.Show("Mật khẩu hoặc tài khoản không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        txtPassword.Text = ""
                        txtUserName.Text = ""
                        MessageBox.Show("Mật khẩu hoặc tài khoản không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Chú ý: Phiên bản hiện tại của phần mềm chưa được đăng ký." & Environment.NewLine & "ID của bạn là: " & ID & Environment.NewLine & "SĐT: 0344958474" & Environment.NewLine & "Công Ty: Tiến Phát", "Thông Báo!", MessageBoxButtons.OK)
                Clipboard.SetText(ID)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If MoPM Then
                    If String.IsNullOrWhiteSpace(txtUserName.Text) OrElse String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản, mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Dim username As String = txtUserName.Text.Trim()
                        Dim password As String = txtPassword.Text.Trim()
                        username = SanitizeInput(username) ' Loại bỏ các ký tự đặc biệt từ username và password
                        password = SanitizeInput(password)
                        If TKhoan = username Then
                            If MKhau = password Then
                                LayThoiGian()
                                If GT_PQ = "r" Then
                                    ValueChangedEvent.Invoke(Me, "CCT")
                                    Threading.Thread.Sleep(100)
                                    Me.Close()
                                Else
                                    ValueChangedEvent.Invoke(Me, "CCL")
                                    Threading.Thread.Sleep(100)
                                    Me.Close()
                                End If
                            Else
                                txtPassword.Text = ""
                                txtUserName.Text = ""
                                MessageBox.Show("Mật khẩu hoặc tài khoản không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            txtPassword.Text = ""
                            txtUserName.Text = ""
                            MessageBox.Show("Mật khẩu hoặc tài khoản không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("Chú ý: Phiên bản hiện tại của phần mềm chưa được đăng ký." & Environment.NewLine & "ID của bạn là: " & ID & Environment.NewLine & "SĐT: 0344958474" & Environment.NewLine & "Công Ty: Tiến Phát", "Thông Báo!", MessageBoxButtons.OK)
                    Clipboard.SetText(ID)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub
    Private Sub lb_KichHoat_Click(sender As Object, e As EventArgs) Handles lb_KichHoat.Click
        If Not MoPM Then
            If pnl_Key.Visible Then
                pnl_Key.Visible = False
            Else
                pnl_Key.Visible = True
            End If
        End If
    End Sub
    Private Sub lb_KichHoat_MouseEnter(sender As Object, e As EventArgs) Handles lb_KichHoat.MouseEnter
        If Not MoPM Then
            lb_KichHoat.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold)
            lb_KichHoat.Text = "       Nhập Key phần mềm!"
        End If
    End Sub
    Private Sub lb_KichHoat_MouseLeave(sender As Object, e As EventArgs) Handles lb_KichHoat.MouseLeave
        If Not MoPM Then
            lb_KichHoat.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold)
            lb_KichHoat.Text = "Phần mềm chưa được đăng ký"
        End If
    End Sub
    Private Sub btn_KichHoat_Click(sender As Object, e As EventArgs) Handles btn_KichHoat.Click
        Try
            If String.IsNullOrWhiteSpace(tb_Key.Text) Then
                Return
            Else
                Dim parts As String() = tb_Key.Text.Split("-"c)
                Dim desiredValue As String = parts(0)
                If GioiHan < 3 Then
                    If desiredValue = IDMay Then
                        LayTGMT()
                        pnl_Key.Visible = False
                        Dim fileName As String = ID & ".txt"
                        Dim filePath As String = Path.Combine(Folder_Data, fileName)
                        Dim filePath1 As String = Path.Combine(Folder_Key, fileName)
                        Try
                            Directory.CreateDirectory(Folder_Data)
                            Directory.CreateDirectory(Folder_Key)
                            ' Tạo và ghi nội dung vào tệp tin văn bản
                            Dim fileContent As String = tb_Key.Text + "-" + FullTimeHT_1
                            Dim MH_Key As String = GetMD5Hash(fileContent)
                            File.WriteAllText(filePath, fileContent)
                            If File.Exists(filePath1) Then
                                Dim lines As String() = File.ReadAllLines(filePath1)
                                Dim mhKeyExists As Boolean = False
                                For Each line As String In lines
                                    If line.Trim() = MH_Key Then
                                        mhKeyExists = True
                                        Exit For
                                    End If
                                Next
                                RPMDK = File.ReadAllText(filePath1)
                                If mhKeyExists Then
                                    tb_Key.Text = ""
                                    MessageBox.Show("Key đã được kích hoạt!" & Environment.NewLine & "Vui lòng không sử dụng lại key cũ", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Else
                                    File.WriteAllText(filePath, fileContent)
                                    Dim combinedContent As String = RPMDK & Environment.NewLine & MH_Key
                                    File.WriteAllText(filePath1, combinedContent)
                                    MessageBox.Show("Đang tiến hành kiểm tra Key..." & Environment.NewLine & "Vui lòng đợi trong khi phần mềm khởi động lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    ValueChangedEvent.Invoke(Me, "Reset")
                                    Threading.Thread.Sleep(100)
                                    Me.Close()
                                End If
                            Else
                                File.WriteAllText(filePath, fileContent)
                                File.WriteAllText(filePath1, MH_Key)
                                MessageBox.Show("Đang tiến hành kiểm tra Key..." & Environment.NewLine & "Vui lòng đợi trong khi phần mềm khởi động lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ValueChangedEvent.Invoke(Me, "Reset")
                                Threading.Thread.Sleep(100)
                                Me.Close()
                            End If
                        Catch ex As Exception
                        End Try
                    Else
                        tb_Key.Text = ""
                        GioiHan += 1
                        XoaKey()
                        MessageBox.Show("Mã Key không chính xác. Hãy đảm bảo bạn đã nhập đúng thông tin và thử lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    Application.Exit()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tb_Key_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_Key.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If String.IsNullOrWhiteSpace(tb_Key.Text) Then
                    Return
                Else
                    Dim parts As String() = tb_Key.Text.Split("-"c)
                    Dim desiredValue As String = parts(0)
                    If GioiHan < 3 Then
                        If desiredValue = IDMay Then
                            LayTGMT()
                            pnl_Key.Visible = False
                            Dim fileName As String = ID & ".txt"
                            Dim filePath As String = Path.Combine(Folder_Data, fileName)
                            Dim filePath1 As String = Path.Combine(Folder_Key, fileName)
                            Try
                                Directory.CreateDirectory(Folder_Data)
                                Directory.CreateDirectory(Folder_Key)
                                ' Tạo và ghi nội dung vào tệp tin văn bản
                                Dim fileContent As String = tb_Key.Text + "-" + FullTimeHT_1
                                Dim MH_Key As String = GetMD5Hash(fileContent)
                                File.WriteAllText(filePath, fileContent)
                                If File.Exists(filePath1) Then
                                    Dim lines As String() = File.ReadAllLines(filePath1)
                                    Dim mhKeyExists As Boolean = False
                                    For Each line As String In lines
                                        If line.Trim() = MH_Key Then
                                            mhKeyExists = True
                                            Exit For
                                        End If
                                    Next
                                    RPMDK = File.ReadAllText(filePath1)
                                    If mhKeyExists Then
                                        tb_Key.Text = ""
                                        MessageBox.Show("Key đã được kích hoạt!" & Environment.NewLine & "Vui lòng không sử dụng lại key cũ", "Cảnh Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Else
                                        File.WriteAllText(filePath, fileContent)
                                        Dim combinedContent As String = RPMDK & Environment.NewLine & MH_Key
                                        File.WriteAllText(filePath1, combinedContent)
                                        MessageBox.Show("Đang tiến hành kiểm tra Key..." & Environment.NewLine & "Vui lòng đợi trong khi phần mềm khởi động lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        ValueChangedEvent.Invoke(Me, "Reset")
                                        Threading.Thread.Sleep(100)
                                        Me.Close()
                                    End If
                                Else
                                    File.WriteAllText(filePath, fileContent)
                                    File.WriteAllText(filePath1, MH_Key)
                                    MessageBox.Show("Đang tiến hành kiểm tra Key..." & Environment.NewLine & "Vui lòng đợi trong khi phần mềm khởi động lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    ValueChangedEvent.Invoke(Me, "Reset")
                                    Threading.Thread.Sleep(100)
                                    Me.Close()
                                End If
                            Catch ex As Exception
                            End Try
                        Else
                            tb_Key.Text = ""
                            GioiHan += 1
                            XoaKey()
                            MessageBox.Show("Mã Key không chính xác. Hãy đảm bảo bạn đã nhập đúng thông tin và thử lại.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    Else
                        Application.Exit()
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub btn_XoaKey_Click(sender As Object, e As EventArgs) Handles btn_XoaKey.Click
        XoaKeey += 1
        If XoaKeey >= 5 Then
            XoaKey()
            MessageBox.Show("Key đã được xóa thành công.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ValueChangedEvent.Invoke(Me, "Reset")
            Threading.Thread.Sleep(100)
            Me.Close()
        End If
    End Sub
#End Region
#Region "Hàm Con"
    Private Function SanitizeInput(input As String) As String
        ' Loại bỏ các ký tự đặc biệt từ input
        input = input.Replace("'", "").Replace("--", "")
        Return input
    End Function
    Private Sub LayThoiGian()
        Try
            Dim ThoiGianDayDu As String = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss")
            Dim LenhNgay As String = ThoiGianDayDu.Split(" "c)(0)
            Dim LenhGio As String = ThoiGianDayDu.Split(" "c)(1)

            Dim fileName As String = "Settings.xml"
            Dim filePath As String = Path.Combine(Folder_Data, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                Dim DLThoiGian As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='ThoiGian']")
                Dim Ngay As XmlElement = DirectCast(DLThoiGian.SelectSingleNode("Ngay"), XmlElement)
                Dim Gio As XmlElement = DirectCast(DLThoiGian.SelectSingleNode("Gio"), XmlElement)
                Ngay.InnerText = LenhNgay
                Gio.InnerText = LenhGio
                xmlDoc.Save(filePath)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub XoaKey()
        Dim key As String = ID + ".txt"
        Dim txtFiles As String = Path.Combine(Folder_Data, key)
        File.Delete(txtFiles)
    End Sub
#End Region
#Region "Tạo Setting"
    Private Sub Settings()
        Try
            Dim fileName As String = "Settings.xml"
            Dim filePath As String = Path.Combine(Folder_Data, fileName)
            Dim xmlDoc As New XmlDocument()
            Dim rootElement As XmlElement = xmlDoc.CreateElement("DuLieu")
            xmlDoc.AppendChild(rootElement)

            'Luu Mo3DmapTP
            Dim Mo3DmapTP As XmlElement = xmlDoc.CreateElement("So")
            Mo3DmapTP.SetAttribute("ID", "Mo3DmapTP")
            Dim TrangThai As XmlElement = xmlDoc.CreateElement("TrangThai")
            TrangThai.InnerText = "0"
            Mo3DmapTP.AppendChild(TrangThai)
            rootElement.AppendChild(Mo3DmapTP)

            'Luu ThoiGian
            Dim ThoiGian As XmlElement = xmlDoc.CreateElement("So")
            ThoiGian.SetAttribute("ID", "ThoiGian")
            Dim Ngay As XmlElement = xmlDoc.CreateElement("Ngay")
            Dim Gio As XmlElement = xmlDoc.CreateElement("Gio")
            Ngay.InnerText = "0"
            Gio.InnerText = "0"
            ThoiGian.AppendChild(Gio)
            ThoiGian.AppendChild(Ngay)
            rootElement.AppendChild(ThoiGian)

            'Luu PhienBan
            Dim PhienBan As XmlElement = xmlDoc.CreateElement("So")
            PhienBan.SetAttribute("ID", "PhienBan")
            Dim PB_ThongTin As XmlElement = xmlDoc.CreateElement("ThongTin")
            Dim PB_TrangThai As XmlElement = xmlDoc.CreateElement("TrangThai")
            PB_ThongTin.InnerText = ID
            PB_TrangThai.InnerText = LuaChon
            PhienBan.AppendChild(PB_ThongTin)
            PhienBan.AppendChild(PB_TrangThai)
            rootElement.AppendChild(PhienBan)

            Dim PhanTramPin As XmlElement = xmlDoc.CreateElement("So")
            PhanTramPin.SetAttribute("ID", "PhanTramPin")
            Dim PT_Pin As XmlElement = xmlDoc.CreateElement("ThongTin")
            PT_Pin.InnerText = LuuPTPin
            PhanTramPin.AppendChild(PT_Pin)
            rootElement.AppendChild(PhanTramPin)

            xmlDoc.Save(filePath)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DeleteSettingsFile()
        Try
            Dim fileName As String = "Settings.xml"
            Dim filePath As String = Path.Combine(Folder_Data, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                Dim PT_Pin As XmlElement = DirectCast(xmlDoc.SelectSingleNode("/DuLieu/So[@ID='PhanTramPin']").SelectSingleNode("ThongTin"), XmlElement)
                LuuPTPin = PT_Pin.InnerText
                File.Delete(filePath)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Python"
    Public Shared Event ValueChanged As EventHandler(Of String)
    Public Shared Property ReturnedValue As String
    Private Shared Bam As String = ""
    Private _isClosed As Boolean = False
    Public ReadOnly Property IsClosed As Boolean
        Get
            Return _isClosed
        End Get
    End Property
    ' Sự kiện xảy ra khi form đóng
    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _isClosed = True
    End Sub
    Public Shared Sub ShowLogin()
        Dim form As New Login()
        AddHandler form.ValueChanged, Sub(sender, value)
                                          ReturnedValue = value
                                      End Sub
        form.Show()

        ' Chờ cho đến khi form đóng
        While Not form.IsClosed
            Application.DoEvents() ' Cho phép ứng dụng xử lý các sự kiện khác trong khi chờ đợi
        End While

        ' Tiếp tục thực hiện các công việc sau khi form đã đóng
        ReturnedValue = Bam
    End Sub
    Public Shared Sub LoginThoat()
        Instance.Close()
    End Sub
#End Region
End Class