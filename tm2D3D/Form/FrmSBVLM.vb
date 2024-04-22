Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Xml
Imports System.Text
Imports System.Security.Cryptography
Imports Microsoft.SqlServer
Public Class FrmSBVLM
#Region "Khai Báo Biến"
    Public Shared Instance As FrmSBVLM
    'đường dẫn thư mục data
    Private folderPath As String
    Private folderPath1 As String
    'liên kết các usercontrol
    Dim WithEvents BangBitTong As New BitTong
    Dim WithEvents BangBitDon As New BitDon
    Dim WithEvents BangKichBan As New KichBan
    Dim WithEvents BangCodong As New CCD
    Dim WithEvents BangLogin As New Login
    Dim WithEvents BangSetup As New SetUp
    Private xpos1 As Integer
    Private ypos1 As Integer
    Private newpoint As System.Drawing.Point
    Private OnTong As String
    Private isPortOpen As Boolean = False
    Private serialPort As SerialPort
    Private isTbRserialVisible As Boolean = False
    Public Shared LCxx As Integer = 0
    Public Shared LCyy As Integer = 0
    Public Shared Roat As Integer = 45
    Public Shared DoCao As Integer = 70000
    Dim TenCo As String = ""
    Dim ToadoSB As String = ""
    Dim XoaNut As Integer = 0
    Dim colast
    Dim [mod] As Boolean = False
    Dim locxx1 As Single = 0
    Dim locyy1 As Single = 0
    'Thời gian
    Dim TGNgay As String
    Dim TGGio As String
    Dim TongGio As String
    '3DmapTP
    Dim Mo3DmapTP As String
    Private TT3DmapTP As String = 0
    'PhienBan
    Dim ThongTin_LC As String
    Dim TrangThai_LC As String
    Dim IDKey_1 As String
    Dim IDKey_2 As String
    Public tbck As String
    'theo dõi xml
    Private WithEvents watcher As New FileSystemWatcher()
    Private stopwatch As New Stopwatch()
    Dim xmlFilePath As String
    'biến toàn cục cho trụ laser
    ' thông tin cơ bản của sa bàn (sa bàn mẫu vuông 108 x 108)
    Public CanhNgang As Integer = 108
    Public CanhDoc As Integer = 108
    Public ChieuCao As Integer = 140
    Public LocX As Integer = 0 ' toạ độ điểm đặt trên sa bàn số
    Public LocY As Integer = 0 ' toạ độ điểm đặt trên sa bàn số
    ' góc bù trừ cho đủ 
    Public G0doNgang As Integer = 0
    Public G90doNgang As Integer = 0
    Public G0doDoc As Integer = 0
    Public GocXaNhatDoc As Integer = 0
    ' góc quay hiện tại
    Public GNgangNow As Integer = 0
    Public GDocNow As Integer = 0
    Public GocXaNhatLT = 0
    Dim GiaTri() As String = {"0", "z", "x", "v", "t", "r", "p", "n", "l", "j", "h", "f", "d", "b", "y", "w", "u", "s", "q", "o", "m", "k", "i", "g", "e", "c", "a", "A", "B", "C", "D", "E", "F"}
    Dim xmlDoc As New XmlDocument()
    Public themcanhtong As Integer = 0
    Public ThemCanh As String
    Public SuaCanh As String
    Public themcanhtong1 As Integer = 0
    Public doiten As String
    Public bitdon As String
    Dim Goc_Ngang_Now As Double = 0
    Dim Goc_Doc_Now As Double = 0
    Dim Home_N As Double = 0
    Dim Home_D As Double = 0
    Dim Crong As Double = 0
    Dim Cdai As Double = 0
    Dim Ccao As Double = 0
    Dim KcA As Double = 0
    Dim Buoc_quay As Double = 0
    Dim Ccao_SBtop As Single = 0
    Dim Ccao_SBbot As Single = 0
    Dim HN As Integer = 0
    Dim HD As Integer = 0
    Dim LocationX As Double = 0
    Dim LocationY As Double = 0
    Dim LocationX1 As Double = 0
    Dim LocationY1 As Double = 0
    Dim Khoa3Dmap As Boolean = True
#End Region
#Region "Load"
    Public Sub New()
        InitializeComponent()
        ' Gán giá trị của Instance bằng phiên bản hiện tại của FrmMain
        Instance = Me
    End Sub
    Private Sub FrmSBVLM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim MSProcesses As Process() = Process.GetProcessesByName("ustation")
            Array.ForEach(MSProcesses, Sub(p As Process) p.Kill())
            Dim MSProcesses1 As Process() = Process.GetProcessesByName("TerraExplorer")
            Array.ForEach(MSProcesses1, Sub(p As Process) p.Kill())
            tb_truyen.Text = "11"
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim folderName As String = "Data\HA"
            folderPath = Path.Combine(baseDirectory, folderName)
            Dim folderName1 As String = "Data"
            folderPath1 = Path.Combine(baseDirectory, folderName1)
            xmlFilePath = Path.Combine(folderPath1, "Settings.xml")
            FrmSBVLMScreen()
            KN_Port()
            DocSettings()
            CB_TaoMuc.Controls.Add(BangBitDon)
            CB_TaoMuc.Controls.Add(BangBitTong)
            CB_TaoMuc.Controls.Add(BangKichBan)
            CB_TaoMuc.Controls.Add(BangCodong)
            BangBitDon.Visible = True
            BangBitTong.Visible = False
            BangCodong.Visible = False
            BangKichBan.Visible = False
            PhanQuyen()
            TheoDoiXMl_Settins()
            stopwatch.Start()
            ThoiGian.Start()
            bt_fly.Text = "0"
            btn_Khoa3Dmap.Checked = True
        Catch eX As Exception
        End Try
    End Sub
    Public Sub FrmSBVLMScreen()
        Try
            If (myScreens.Length = 1) Then
                Me.Location = New Point(0, 0)
                'Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
            ElseIf (myScreens.Length = 2) Then
                For Each scr As Screen In Screen.AllScreens
                    If Not scr.Primary Then
                        Me.Top = scr.Bounds.Top
                        Me.Left = scr.Bounds.Left
                        Exit For
                    End If
                Next
                'Me.Top = Screen.AllScreens(1).Bounds.Top
                'Me.Left = Screen.AllScreens(1).Bounds.Left
                'Me.Size = New Size(Screen.AllScreens(1).WorkingArea.Width, Screen.AllScreens(1).WorkingArea.Height)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ThoiGian_Tick(sender As Object, e As EventArgs) Handles ThoiGian.Tick
        Try
            Dim ThoiGianHienTai As TimeSpan
            If TimeSpan.TryParse(TGGio, ThoiGianHienTai) Then
                Dim ThoiGianDem As TimeSpan = stopwatch.Elapsed
                Dim TongThoiGian As TimeSpan = ThoiGianDem.Add(ThoiGianHienTai)
                TongGio = TongThoiGian.ToString("hh\:mm\:ss")
                lb_ThoiGian.Text = "Thời gian: " & TongThoiGian.ToString("hh\:mm\:ss")

            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Kết Nối Port"
    Private Sub KN_Port()
        Try
            cbb_COM.Items.Clear() ' Xóa các mục có sẵn trong ComboBox
            Dim ports As String() = SerialPort.GetPortNames() ' Lấy danh sách các cổng COM có sẵn trên máy tính
            If ports.Length = 0 Then ' Kiểm tra nếu không có cổng COM nào được tìm thấy
                Return
            End If
            For Each port As String In ports ' Thêm các cổng COM vào ComboBox
                cbb_COM.Items.Add(port)
            Next port
            If cbb_COM.Items.Count > 0 Then ' Chọn mặc định cổng COM đầu tiên
                cbb_COM.SelectedIndex = 0
            Else
            End If
        Catch
        End Try
    End Sub
    Private Sub Btn_KetNoi_Click(sender As Object, e As EventArgs) Handles btn_KetNoi.Click
        Try
            If Not isPortOpen Then
                If cbb_COM.SelectedItem IsNot Nothing Then
                    ' Lấy cổng COM đã chọn từ ComboBox
                    Dim selectedPort As String = cbb_COM.SelectedItem.ToString()
                    ' Tạo đối tượng SerialPort và cấu hình các thiết lập
                    serialPort = New SerialPort(selectedPort) With {
                        .BaudRate = 115200, ' Tốc độ baud rate
                        .DataBits = 8, ' Số bit dữ liệu
                        .Parity = Parity.None, ' Kiểu kiểm tra lỗi
                        .StopBits = StopBits.One ' Số bit stop
                        }
                    ' Đặt sự kiện xử lý dữ liệu từ cổng COM (nếu cần)
                    AddHandler serialPort.DataReceived, AddressOf DataReceivedHandler
                    ' Mở cổng COM
                    Try
                        serialPort.Open()
                        If serialPort.IsOpen Then
                            ' Cổng COM đã được mở

                            btn_KetNoi.BackColor = Color.Red
                            btn_KetNoi.ForeColor = Color.Black
                            btn_KetNoi.Text = "Đóng"
                            isPortOpen = True
                            btn_LamMoi.Enabled = False
                        Else
                            MessageBox.Show("Không thể mở cổng COM.")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Không thể mở cổng COM: " & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Vui lòng chọn một cổng COM.")
                End If
            Else
                ' Đã kết nối, nên đóng cổng COM để ngắt kết nối
                serialPort.Close() ' Đóng cổng COM
                btn_KetNoi.BackColor = Color.FromArgb(0, 117, 227)  ' Đặt màu nền lại thành màu mặc định hoặc một màu khác
                btn_KetNoi.ForeColor = Color.Black
                btn_KetNoi.Text = "Kết nối"
                isPortOpen = False
                btn_LamMoi.Enabled = True
            End If
        Catch
        End Try
    End Sub
    Private Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim dataReceived As String = serialPort.ReadLine()
            NhanData(dataReceived)
            Me.Invoke(Sub() tb_Rserial.Text = dataReceived)
        Catch
        End Try
    End Sub
    Private Sub NhanData(data As String)
        Try
            Dim DataSerial As String = data.Trim()

            If DataSerial.EndsWith("_on") Then
                Dim numberCCD As String = DataSerial.Substring(1, 1)
                colast = DataSerial.Substring(1, 1)
                Dim text1 As String = "bat_C" + numberCCD
                ValueChanged2Event.Invoke(Me, "bat_C" + numberCCD)
                'File.WriteAllText(LinkCocodong, text1)
            End If
            If DataSerial.EndsWith("QC") Then
                Dim path1 = "C:/saban/tuongtacXY/quechi.txt"
                Dim text1 As String = "bat_QC"
                File.WriteAllText(path1, text1)

            End If
            If DataSerial.EndsWith("RM") Then
                ValueChanged2Event.Invoke(Me, "on_laser")
            End If
            If DataSerial.EndsWith("5") Then
                If bt_fly.Text = "1" Then
                    bt_fly.Text = "0"
                ElseIf bt_fly.Text = "0" Then
                    bt_fly.Text = "1"
                End If
            End If

            If DataSerial.StartsWith("RM_") Then
                ValueChanged2Event.Invoke(Me, "on_laser")
                tb_pin.Text = DataSerial
                Dim value As String = tb_pin.Text
                Dim valueAfterRM As String = value.Substring(3)
                Dim numericValue As Decimal
                If Decimal.TryParse(valueAfterRM.Substring(1), numericValue) Then
                    If numericValue >= 3.0 AndAlso numericValue <= 4.0 Then
                        LocNhieuPin(numericValue) ' Lọc nhiễu bằng cách sử dụng trung bình di động
                    ElseIf numericValue >= 4.0 Then
                        Me.Invoke(Sub()
                                      lb_pin.Text = "100%"
                                  End Sub)
                    End If
                End If
                If valueAfterRM <= "P3.00" Then
                    lb_pin.Text = "0%"
                ElseIf valueAfterRM >= "P4.00" Then
                    lb_pin.Text = "100%"
                End If
                HinhPTPin()
            End If
            If DataSerial.EndsWith("tatRM") Then
                ValueChanged2Event.Invoke(Me, "off_laser")
            End If
            If DataSerial.EndsWith("ADOWN") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCxx -= 0.5
                End If
                If DoCao < 50000 Then
                    LCxx -= 4
                End If
                If DoCao < 75000 Then
                    LCxx -= 6.5
                Else
                    LCxx -= 9
                End If
                'DCsetup()
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("AUP") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCxx += 0.5
                End If
                If DoCao < 50000 Then
                    LCxx += 4
                End If
                If DoCao < 75000 Then
                    LCxx += 6.5
                Else
                    LCxx += 9
                End If
                'DCsetup()
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("AL") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCyy -= 0.5
                End If
                If DoCao < 50000 Then
                    LCyy -= 4
                End If
                If DoCao < 75000 Then
                    LCyy -= 6.5
                Else
                    LCyy -= 9
                End If
                'DCsetup()
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("AR") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCyy += 0.5
                End If
                If DoCao < 50000 Then
                    LCyy += 4
                End If
                If DoCao < 75000 Then
                    LCyy += 6.5
                Else
                    LCyy += 9
                End If
                'DCsetup()
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("Z-") Then
                Thread.Sleep(50)
                FrmMain.Instance.DCaoT()
            End If
            If DataSerial.EndsWith("Z+") Then
                Thread.Sleep(50)
                FrmMain.Instance.DCaoC()
            End If
            If DataSerial.EndsWith("X+") Then
                Thread.Sleep(50)
                FrmMain.Instance.GNghiengC()
            End If
            If DataSerial.EndsWith("X-") Then
                Thread.Sleep(50)
                FrmMain.Instance.GNghiengT()
            End If
            If DataSerial.EndsWith("KB+") Then
                BangKichBan.CanhSau()
                tb_TrinhChieuSBVL.Text = "KB+"
            End If
            If DataSerial.EndsWith("KB-") Then
                BangKichBan.CanhTruoc()
                tb_TrinhChieuSBVL.Text = "KB-"
            End If
            If DataSerial.StartsWith("TP") Then
                Dim startIndex As Integer = DataSerial.IndexOf("TP") + 2
                Dim result As String = DataSerial.Substring(startIndex)
                tb_trangthaico.Text = result
            End If
            If DataSerial.StartsWith("5") Then
                tb_BN.Text = "5"
            End If
        Catch
        End Try
    End Sub
    Private Sub Btn_LamMoi_Click(sender As Object, e As EventArgs) Handles btn_LamMoi.Click
        Try
            TRData("Reset")
            If btn_KetNoi.BackColor = Color.Red Then
                serialPort.Close() ' Đóng cổng COM
            End If
            btn_KetNoi.BackColor = Color.FromArgb(0, 117, 227)
            btn_KetNoi.ForeColor = Color.Black
            btn_KetNoi.Text = "Kết nối"
            isPortOpen = False
            cbb_COM.Items.Clear()
            Dim ports As String() = SerialPort.GetPortNames()
            For Each port As String In ports
                cbb_COM.Items.Add(port)
            Next
            Try
                cbb_COM.SelectedIndex = 0
            Catch
            End Try
        Catch
        End Try
    End Sub
    Public Sub TRData(data As String)
        Try
            If btn_KetNoi.Text = "Đóng" Then
                If serialPort Is Nothing OrElse Not serialPort.IsOpen Then
                    Return
                End If
                If data = "HG" Then
                    Goc_Ngang_Now = 10
                    Goc_Doc_Now = 90
                    serialPort.WriteLine("HG")
                Else
                    serialPort.WriteLine(data)
                    Console.WriteLine(data)
                End If
                Thread.Sleep(50)
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "tru lazer"
    Public Sub Data_laser(data As String)
        Try
            Dim kitu1 As String = data.Substring(0, 1)
            If serialPort.IsOpen = True Then
                ' xác nhận kích thước sa bàn
                If kitu1 = "A" Then

                    Dim vitri1 As Integer = data.IndexOf(","c)

                    Cdai = Integer.Parse(data.Substring(2, vitri1 - 2))
                    Crong = Integer.Parse(data.Substring(vitri1 + 1))
                    ' show thông số sa bàn
                    Dim tamX As Double = Crong / 100
                    Dim tamY As Double = Cdai / 100

                    Dim tamS As String = "S_" & tamY.ToString() & "," & tamX.ToString()
                    serialPort.WriteLine(tamS)
                ElseIf kitu1 = "B" Then
                    ' xác nhận chiều cao trụ laser và khoảng cách A
                    Dim vitri1 As Integer = data.IndexOf(","c)
                    Ccao = Single.Parse(data.Substring(2, vitri1 - 2))
                    KcA = Single.Parse(data.Substring(vitri1 + 1))
                ElseIf kitu1 = "C" Then
                    ' xác nhận khoảng cách B và C
                    Dim vitri1 As Integer = data.IndexOf(","c)
                    Ccao_SBtop = Single.Parse(data.Substring(2, vitri1 - 2))
                    Ccao_SBbot = Single.Parse(data.Substring(vitri1 + 1))
                ElseIf kitu1 = "D" Then
                    Dim kitu2 As String = data.Substring(1, 1)
                    Buoc_quay = Double.Parse(data.Substring(2))

                    If kitu2 = "+" Then
                        HD = 1
                        serialPort.WriteLine("L_0,0_" & Buoc_quay.ToString() & "," & HD.ToString())

                        Goc_Doc_Now = Goc_Doc_Now + Buoc_quay
                    ElseIf kitu2 = "-" Then
                        HD = 0
                        serialPort.WriteLine("L_0,0_" & Buoc_quay.ToString() & "," & HD.ToString())

                        Goc_Doc_Now = Goc_Doc_Now - Buoc_quay
                    End If
                ElseIf kitu1 = "E" Then
                    Dim kitu2 As String = data.Substring(1, 1)
                    Buoc_quay = Double.Parse(data.Substring(2))

                    If kitu2 = "+" Then
                        HN = 1
                        serialPort.WriteLine("L_" & Buoc_quay.ToString() & "," & HN.ToString() & "_0,0")

                        Goc_Ngang_Now = Goc_Ngang_Now + Buoc_quay
                    ElseIf kitu2 = "-" Then
                        HN = 0
                        serialPort.WriteLine("L_" & Buoc_quay.ToString() & "," & HN.ToString() & "_0,0")

                        Goc_Ngang_Now = Goc_Ngang_Now - Buoc_quay
                    End If
                ElseIf kitu1 = "F" Then
                    Set_home()
                ElseIf kitu1 = "G" Then
                    Go_home()
                ElseIf kitu1 = "H" Then
                    Home_G28()
                End If
            Else

            End If
        Catch
        End Try
    End Sub
    Private Sub Set_home()
        Try
            Dim goca As Double = -Math.Asin((Ccao_SBtop - Ccao_SBbot) / Cdai)
            LocationX = 0
            LocationY = 0
            Dim Z_Y As Double = ((Cdai - LocationY) * (Ccao_SBtop - Ccao_SBbot)) / Cdai ' chiều cao tại vị trí toạ độ XY
            Dim Goc_A As Double = Math.Atan(Math.Sqrt((Crong + KcA - LocationX) * (Crong + KcA - LocationX) + (LocationY * LocationY)) / (Ccao - Z_Y - Ccao_SBbot))
            Dim bienmoi_D As Double = Math.Tan(Goc_A) * Z_Y
            LocationX1 = bienmoi_D * Math.Cos(Math.Atan(LocationY / (Crong + KcA - LocationX)))
            LocationY1 = bienmoi_D * Math.Sin(Math.Atan(LocationY / (Crong + KcA - LocationX)))
            LocationX = LocationX - LocationX1
            LocationY = LocationY + LocationY1
            Home_N = 0
            Home_D = 0
            Goc_Ngang_Now = Home_N
            Goc_Doc_Now = Home_D
        Catch
        End Try
    End Sub
    Private Sub Go_home()
        Try
            Dim GocN_vehome As Double
            Dim GocD_vehome As Double

            If Home_D - Goc_Doc_Now > 0 Then
                If Home_N - Goc_Ngang_Now > 0 Then
                    GocN_vehome = Math.Abs(Home_N - Goc_Ngang_Now)
                    HN = 1
                Else
                    GocN_vehome = Math.Abs(Home_N - Goc_Ngang_Now)
                    HN = 0
                End If

                GocD_vehome = Math.Abs(Home_D - Goc_Doc_Now)
                HD = 1
            Else
                If Home_N - Goc_Ngang_Now > 0 Then
                    GocN_vehome = Math.Abs(Home_N - Goc_Ngang_Now)
                    HN = 1
                Else
                    GocN_vehome = Math.Abs(Home_N - Goc_Ngang_Now)
                    HN = 0
                End If

                GocD_vehome = Math.Abs(Home_D - Goc_Doc_Now)
                HD = 0
            End If

            Dim datat As String = "L_" & GocN_vehome.ToString() & "," & HN.ToString() & "_" & GocD_vehome.ToString() & "," & HD.ToString()

            If serialPort.IsOpen Then
                serialPort.WriteLine(datat)
            End If

            Goc_Doc_Now = Home_D
            Goc_Ngang_Now = Home_N
        Catch
        End Try
    End Sub
    Private Sub Home_G28()
        Try
            Goc_Ngang_Now = 10
            Goc_Doc_Now = 90
            If serialPort.IsOpen Then
                serialPort.WriteLine("HG")
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Nút Nhấn"
    Private Sub Btn_TrangBitTong_Click(sender As Object, e As EventArgs) Handles btn_TrangBitTong.Click
        Try
            tb_truyen.Text = "00"
            BangCodong.Visible = False
            BangBitTong.Visible = True
            BangBitDon.Visible = False
            BangKichBan.Visible = False
            BangBitTong.MainBitTong()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Btn_pnl_OnBit_Click(sender As Object, e As EventArgs) Handles btn_pnl_OnBit.Click
        Try
            tb_truyen.Text = "00"
            BangCodong.Visible = False
            BangBitDon.Visible = True
            BangBitTong.Visible = False
            BangKichBan.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Public Sub trangkichban1()
        Try
            tb_truyen.Text = "11"
            BangCodong.Visible = False
            BangKichBan.Visible = True
            BangBitDon.Visible = False
            BangBitTong.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_TrangKichBan_Click(sender As Object, e As EventArgs) Handles btn_TrangKichBan.Click
        Try
            tb_truyen.Text = "11"
            BangCodong.Visible = False
            BangKichBan.Visible = True
            BangBitDon.Visible = False
            BangBitTong.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_TrangCoCoDong_Click(sender As Object, e As EventArgs) Handles btn_TrangCoCoDong.Click
        Try
            BangCodong.Visible = True
            BangKichBan.Visible = False
            BangBitDon.Visible = False
            BangBitTong.Visible = False
        Catch eX As Exception
        End Try
    End Sub
    Public Sub thoatkichban()
        BangKichBan.thoatkichban()
    End Sub
    Private Sub Btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        Try
            Thoat()
            ValueChanged1Event.Invoke(Me, "Thoat")
            Threading.Thread.Sleep(100)
            Me.Close()
            ''System.Windows.Forms.Application.Exit()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub btn_OnAll_Click(sender As Object, e As EventArgs) Handles btn_OnAll.Click
        Try
            OnTong = 1
            BangBitDon.TTALL(OnTong)
            BangBitTong.TTALL(OnTong)
            TRData("Full")
            If Mo3DmapTP = 1 Then
                SangSBS()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_OffAll_Click(sender As Object, e As EventArgs) Handles btn_OffAll.Click
        Try
            OnTong = 0
            BangBitDon.TTALL(OnTong)
            BangBitTong.TTALL(OnTong)
            BangBitDon.resetBitTong()
            BangBitDon.resetKichBan()
            BangKichBan.resetKichBan()
            BangBitDon.ResetLuuDataString()
            TRData("Off")
            If Mo3DmapTP = 1 Then
                SangSBS()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub loadkb()
        BangKichBan.LoadKichBan()
    End Sub
    Private Sub btn_NhayAll_Click(sender As Object, e As EventArgs) Handles btn_NhayAll.Click
        Try
            OnTong = 2
            BangBitDon.TTALL(OnTong)
            BangBitTong.TTALL(OnTong)
            TRData("FB1")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_AnCuaSo_Click(sender As Object, e As EventArgs) Handles btn_AnCuaSo.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub btn_TK_Click(sender As Object, e As EventArgs) Handles btn_TK.Click
        Try
            Thoat()
            If Mo3DmapTP = 1 Then
                FrmMain.Instance.ResetLogin()
            End If
            ValueChanged1Event.Invoke(Me, "TaiKhoan")
        Catch
        End Try
    End Sub
    Private Sub btn_PhongTo_Click(sender As Object, e As EventArgs)
        Me.WindowState = FormWindowState.Maximized
    End Sub
#End Region
#Region "CHIA MÀN HÌNH"
    Private Sub Pnl_Tool_MouseDown(sender As Object, e As MouseEventArgs) Handles pnl_Tool.MouseDown
        Try
            xpos1 = Control.MousePosition.X - Me.Location.X
            ypos1 = Control.MousePosition.Y - Me.Location.Y
        Catch
        End Try
    End Sub
    Private Sub Pnl_Tool_MouseMove(sender As Object, e As MouseEventArgs) Handles pnl_Tool.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                newpoint = Control.MousePosition
                newpoint.X -= (xpos1)
                newpoint.Y -= (ypos1)
                Me.Location = newpoint
            End If
        Catch
        End Try
    End Sub
    Public Sub trangkichban()
        BangKichBan.trangkichban()
    End Sub
    Public Sub TKB()
        BangKichBan.TKB()
    End Sub
    Public Sub TKB1()
        BangKichBan.TKB1()
    End Sub
    Private Sub BtnSbso_Click(sender As Object, e As EventArgs) Handles BtnSbso.Click
        Try
            For Each scr As Screen In Screen.AllScreens
                If Not scr.Primary Then
                    Me.Top = scr.Bounds.Top
                    Me.Left = scr.Bounds.Left
                    Exit For
                End If
            Next
            Dim form As New FrmMain()
            If Mo3DmapTP = 0 Then
                GhiSettings("Mo3DmapTP")
                form.Show()
                Khoa_3Dmap(1)
            End If
            If Mo3DmapTP = 1 Then
                form.Show()
                Khoa_3Dmap(1)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Di Chuyển"
    Private Sub Guna2GradientPanel1_MouseDown(sender As Object, e As MouseEventArgs) Handles Guna2GradientPanel1.MouseDown
        Try
            xpos1 = Control.MousePosition.X - Me.Location.X
            ypos1 = Control.MousePosition.Y - Me.Location.Y
            If Me.WindowState = FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Normal
            End If
        Catch
        End Try
    End Sub
    Private Sub Guna2GradientPanel1_MouseUp(sender As Object, e As MouseEventArgs) Handles Guna2GradientPanel1.MouseUp
        Try
            If Me.WindowState <> FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.WindowState = FormWindowState.Normal
            End If
        Catch
        End Try
    End Sub
    Private Sub Guna2GradientPanel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Guna2GradientPanel1.MouseMove
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                newpoint = Control.MousePosition
                newpoint.X -= (xpos1)
                newpoint.Y -= (ypos1)
                Me.Location = newpoint
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Nhân dữ liệu"
    Private Sub BiTongToMain(sender As Object, BitId As String) Handles BangBitTong.BitTongToMain
        Try
            If tb_truyen.Text = "11" Or tb_truyen.Text = "00" Then
                tb_truyen.Text = "21"
            End If
            Dim name As String = BangBitTong.buttonNameVariable
            BangBitDon.MainToBitDon(BitId, name)
            btn_pnl_OnBit.Enabled = False
            btn_TrangCoCoDong.Enabled = False
            btn_TrangKichBan.Enabled = False
            BtnSbso.Enabled = False
            btn_Settings.Enabled = False

            btn_TK.Enabled = False
            btn_OnAll.Enabled = False
            btn_OffAll.Enabled = False
            'bt_xoabit.Visible = False
            btn_NhayAll.Enabled = False
            btn_TrangBitTong.Enabled = True
            BangBitDon.Visible = True

        Catch ex As Exception
        End Try
    End Sub
    Private Sub BitTongToMain(sender As Object, e As String) Handles BangBitTong.BitTongToMain
        Try

            If e = "KichBan" Then
                BangKichBan.LoadKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub truyenkb()
        BangKichBan.truyenkb(BangBitTong.tb_DoiTenBit.Text)
    End Sub
    Private Sub BitDonToMain(sender As Object, e As String) Handles BangBitDon.BitDonToMain
        Try
            If e = "BitTong" Then
                btn_pnl_OnBit.Enabled = True
                btn_TrangCoCoDong.Enabled = True
                btn_TrangKichBan.Enabled = True
                BtnSbso.Enabled = True
                btn_Settings.Enabled = True
                btn_TK.Enabled = True
                btn_OnAll.Enabled = True
                btn_OffAll.Enabled = True
                'bt_xoabit.Visible = False
                btn_NhayAll.Enabled = True
                BangBitDon.Visible = False
                BangBitTong.Visible = True
            End If
            If e = "KichBan" Then
                BangKichBan.LoadKichBan()
            End If
            If e = "BitTong1" Then
                btn_pnl_OnBit.Enabled = False
                btn_TrangCoCoDong.Enabled = False
                btn_TrangKichBan.Enabled = False
                BtnSbso.Enabled = True
                btn_Settings.Enabled = True
                btn_TK.Enabled = True
                btn_OnAll.Enabled = False
                btn_OffAll.Enabled = False
                'bt_xoabit.Visible = False
                btn_NhayAll.Enabled = False
                BangBitDon.Visible = False
                BangBitTong.Visible = True
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub BitDonKichBanToMain(sender As Object, e As String) Handles BangBitDon.BitDonKichBanToMain
        Try
            If e = "xong" Then
                btn_pnl_OnBit.Enabled = True
                btn_TrangCoCoDong.Enabled = True
                btn_TrangKichBan.Enabled = True
                btn_TrangBitTong.Enabled = True
                BtnSbso.Enabled = True
                btn_Settings.Enabled = True
                btn_TK.Enabled = True
                btn_OnAll.Enabled = True
                btn_OffAll.Enabled = True
                'bt_xoabit.Visible = False
                btn_NhayAll.Enabled = True
                BangBitDon.Visible = False
                BangBitTong.Visible = False
                BangKichBan.Visible = True

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BitTongKichBanToMain(sender As Object, e As String) Handles BangBitTong.BitTongKichBanToMain
        Try
            If e = "xong" Then
                btn_pnl_OnBit.Enabled = True
                btn_TrangCoCoDong.Enabled = True
                btn_TrangKichBan.Enabled = True
                btn_TrangBitTong.Enabled = True
                BtnSbso.Enabled = True
                btn_Settings.Enabled = True
                btn_TK.Enabled = True
                btn_OnAll.Enabled = True
                btn_OffAll.Enabled = True
                'bt_xoabit.Visible = False
                btn_NhayAll.Enabled = True
                BangBitDon.Visible = False
                BangBitTong.Visible = False
                BangBitDon.maintobitdon()
                BangKichBan.Visible = True

                Dim fileName1 As String = "TBitTong1.xml"
                Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath1)
                Dim modifiedVariable As String = String.Empty

                Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit/Data")
                If bitNode IsNot Nothing Then
                    Dim variableToStoreData As String = bitNode.InnerText
                    For index As Integer = 0 To variableToStoreData.Length - 1
                        If variableToStoreData(index) = "2"c Then
                            modifiedVariable &= "1"
                        Else
                            modifiedVariable &= variableToStoreData(index)
                        End If
                    Next
                    bitNode.InnerText = modifiedVariable
                    xmlDoc.Save(filePath1)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub BangBitDon_BitDonToSerial(sender As Object, e As String) Handles BangBitDon.BitDonToSerial
        Try
            If tb_truyen.Text = "11" Or tb_truyen.Text = "00" Then
                Dim SBit As String() = e.Split("_")
                Dim TenBit As String = SBit(0)
                Dim SoBit As String = SBit(1)
                TRData(TenBit + SoBit)
                If TenBit = "T" Then
                    TT3DmapTP = 0
                ElseIf TenBit = "A" Then
                    TT3DmapTP = 2
                ElseIf TenBit = "B" Then
                    TT3DmapTP = 2
                End If
                If Integer.TryParse(SoBit, Nothing) Then
                    Dim giaTriSauTang As Integer = Integer.Parse(SoBit) + 1
                    If Mo3DmapTP = 1 Then
                        tb_TruyenBit.Text = giaTriSauTang.ToString()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BangBitTong_BitTongToSerial1(sender As Object, e As String) Handles BangBitTong.BitTongToSerial
        Try
            If tb_truyen.Text = "11" Or tb_truyen.Text = "00" Then
                Thread.Sleep(300)
                Dim DuLieu As String() = e.Split("_")
                Dim TrangThai As String
                Dim Hex As String
                If DuLieu.Length >= 2 Then
                    TrangThai = DuLieu(0)
                    Hex = DuLieu(1)
                End If

                Dim first40Bits As String = Hex.Substring(0, 40)
                Dim last40Bits As String = Hex.Substring(40)
                If TrangThai = 0 Then
                    If KiemTraData(first40Bits) Then
                        Thread.Sleep(100)
                        TRData("DO1_" + first40Bits)
                    End If
                    If KiemTraData(last40Bits) Then
                        Thread.Sleep(100)
                        TRData("DO2_" + last40Bits)
                    End If
                End If
                If TrangThai = 1 Then
                    If KiemTraData(first40Bits) Then
                        Thread.Sleep(100)
                        TRData("DA1_" + first40Bits)
                    End If
                    If KiemTraData(last40Bits) Then
                        Thread.Sleep(100)
                        TRData("DA2_" + last40Bits)
                    End If
                End If
                If TrangThai = 2 Then
                    If KiemTraData(first40Bits) Then
                        Thread.Sleep(100)
                        TRData("DB1_" + first40Bits)
                    End If
                    If KiemTraData(last40Bits) Then
                        Thread.Sleep(100)
                        TRData("DB2_" + last40Bits)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BangBitTong_BitTongToSerial(sender As Object, e As String) Handles BangBitTong.BitTongToSerial1
        Try
            Dim DuLieu As String() = e.Split("_")
            Dim TrangThai As String
            Dim Hex As String
            If DuLieu.Length >= 2 Then
                TrangThai = DuLieu(0)
                Hex = DuLieu(1)
            End If

            Dim first40Bits As String = Hex.Substring(0, 40)
            Dim last40Bits As String = Hex.Substring(40)
            If TrangThai = 0 Then
                If KiemTraData(first40Bits) Then
                    'Thread.Sleep(100)
                    TRData("DO1_" + first40Bits)
                End If
                If KiemTraData(last40Bits) Then
                    'Thread.Sleep(100)
                    TRData("DO2_" + last40Bits)
                End If
            End If
            If TrangThai = 1 Then
                If KiemTraData(first40Bits) Then
                    'Thread.Sleep(100)
                    TRData("DA1_" + first40Bits)
                End If
                If KiemTraData(last40Bits) Then
                    'Thread.Sleep(100)
                    TRData("DA2_" + last40Bits)
                End If
            End If
            If TrangThai = 2 Then
                If KiemTraData(first40Bits) Then
                    'Thread.Sleep(100)
                    TRData("DB1_" + first40Bits)
                End If
                If KiemTraData(last40Bits) Then
                    'Thread.Sleep(100)
                    TRData("DB2_" + last40Bits)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BangBitTong_BitTongTo3DmapTP(sender As Object, e As String) Handles BangBitTong.BitTongTo3DmapTP
        If tb_truyen.Text = "11" Or tb_truyen.Text = "00" Then
            Dim DuLieu As String() = e.Split("_")
            Dim TrangThai As String = DuLieu(0)
            Dim SoNut As Integer = DuLieu(1)
            Dim so As Integer = DuLieu(2)
            If TrangThai = 0 Then
                TT3DmapTP = 0
            ElseIf TrangThai = 1 Then
                TT3DmapTP = 2
            ElseIf TrangThai = 2 Then
                TT3DmapTP = 2
            End If

            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
            xmlDoc.Load(filePath)
            Dim ID As String = $"{SoNut}_{so}"
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{SoNut}_{so}']/Data")
            If bitNode IsNot Nothing Then
                Dim DataValue As String = bitNode.InnerText
                If ID = $"{SoNut}_{so}" Then
                    For i As Integer = 0 To DataValue.Length - 1
                        If DataValue(i) = "1"c Then
                            If Mo3DmapTP = 1 Then
                                tb_TruyenBit.Text = i + 1.ToString()
                            End If
                        End If
                    Next
                End If
            End If
        End If
    End Sub
    Private Sub BangBitTong_BitTongTo3DmapTP1(sender As Object, e As String) Handles BangBitTong.BitTongTo3DmapTP1
        If tb_truyen.Text = "11" Or tb_truyen.Text = "00" Then

            Dim DuLieu As String() = e.Split("_")
            Dim TrangThai As String = DuLieu(0)
            Dim SoNut As String = DuLieu(1)
            If TrangThai = 0 Then
                TT3DmapTP = 0
            ElseIf TrangThai = 1 Then
                TT3DmapTP = 2
            ElseIf TrangThai = 2 Then
                TT3DmapTP = 2
            End If
            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
            xmlDoc.Load(filePath)
            Dim ID As String = $"{SoNut}"
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{SoNut}']/Data")
            If bitNode IsNot Nothing Then
                Dim DataValue As String = bitNode.InnerText
                For i As Integer = 0 To DataValue.Length - 1
                    If DataValue(i) = "1"c Then
                        If Mo3DmapTP = 1 Then
                            tb_TruyenBit.Text = i + 1.ToString()
                        End If
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub KichBanToMain(sender As Object, e As String) Handles BangKichBan.KichBanToMain
        Try
            BangBitDon.MainKichBanToBitDon(e)

            btn_pnl_OnBit.Enabled = False
            btn_TrangCoCoDong.Enabled = False
            BtnSbso.Enabled = False
            btn_Settings.Enabled = False
            btn_TK.Enabled = False
            btn_OnAll.Enabled = False
            btn_OffAll.Enabled = False
            'bt_xoabit.Visible = False
            btn_NhayAll.Enabled = False
            btn_TrangBitTong.Enabled = False
            btn_TrangKichBan.Enabled = True
            BangBitDon.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub KichBanToMain2(sender As Object, e As String) Handles BangKichBan.KichBanToMain1
        Try
            tb_truyen.Text = "10"
            BangBitTong.MainKichBanToBitTong(e)
            btn_pnl_OnBit.Enabled = False
            btn_TrangCoCoDong.Enabled = False
            BtnSbso.Enabled = False
            btn_Settings.Enabled = False
            btn_TK.Enabled = False
            btn_OnAll.Enabled = False
            btn_OffAll.Enabled = False
            'bt_xoabit.Visible = False
            btn_NhayAll.Enabled = False
            btn_TrangBitTong.Enabled = False
            btn_TrangKichBan.Enabled = True
            BangBitTong.Visible = True

        Catch ex As Exception
        End Try
    End Sub
    Private Sub KichBanCanhToMain(sender As Object, e As String) Handles BangKichBan.KichBanCanhToMain
        Try
            tb_truyen.Text = "01"
            BangBitTong.KichBanCanhToMain(e)
            BangBitTong.LoadGTKichBan()
            btn_pnl_OnBit.Enabled = False
            btn_TrangCoCoDong.Enabled = False
            BtnSbso.Enabled = False
            btn_Settings.Enabled = False
            btn_TK.Enabled = False
            btn_OnAll.Enabled = False
            btn_OffAll.Enabled = False
            'bt_xoabit.Visible = True
            btn_NhayAll.Enabled = False
            btn_TrangBitTong.Enabled = False
            btn_TrangKichBan.Enabled = True
            BangBitTong.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub KichBanToMain1(sender As Object, e As String) Handles BangBitDon.KichBanToMain1
        Try
            tb_truyen.Text = "01"
            BangBitTong.KichBanCanhToMain(e)
            btn_pnl_OnBit.Enabled = False
            btn_TrangCoCoDong.Enabled = False
            BtnSbso.Enabled = False
            btn_Settings.Enabled = False
            btn_TK.Enabled = False
            btn_OnAll.Enabled = False
            btn_OffAll.Enabled = False
            'bt_xoabit.Visible = True
            btn_NhayAll.Enabled = False
            btn_TrangBitTong.Enabled = False
            btn_TrangKichBan.Enabled = True
            BangBitTong.Visible = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub KichBanDataToMain_Serial(sender As Object, e As String) Handles BangKichBan.KichBanDataToMain
        Try
            Dim KB1 As String = e.Substring(0, 54)
            Dim KB2 As String = e.Substring(54, 54)
            Dim KB3 As String = e.Substring(108, 29)
            If KiemTraData(KB1) Then
                Thread.Sleep(100)
                TRData("KB1_" + KB1)
            End If
            If KiemTraData(KB2) Then
                Thread.Sleep(100)
                TRData("KB2_" + KB2)
            End If
            If KiemTraData(KB3) Then
                Thread.Sleep(100)
                TRData("KB3_" + KB3)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CCDToMainSerial_Serial(sender As Object, e As String) Handles BangCodong.CCDToMainSerial
        Try
            TRData(e)
        Catch ex As Exception
        End Try
    End Sub
    Private Function KiemTraData(input As String) As Boolean
        Try

            For Each c As Char In input
                If c <> "0"c Then
                    Return True
                End If
            Next
            Return False
        Catch
        End Try
    End Function
    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        BangSetup.Show()
    End Sub
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        isTbRserialVisible = Not isTbRserialVisible
        tb_Rserial.Visible = isTbRserialVisible
    End Sub
#End Region
#Region "Truyền FrmMain.Instance"
    Public Sub tb_test_TextChanged(sender As Object, e As EventArgs) Handles tb_test.TextChanged
        Try
            'If tb_test.InvokeRequired Then
            '    tb_test.Invoke(Sub() FrmMain.Instance.tb_DTMSBVL.Text = tb_test.Text)
            'Else
            '    FrmMain.Instance.tb_DTMSBVL.Text = tb_test.Text
            'End If
            If tb_test.InvokeRequired Then
                tb_test.Invoke(Sub() FrmMain.Instance.TxtFly.Text = tb_test.Text)
            Else
                FrmMain.Instance.TxtFly.Text = tb_test.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub tb_Rserial_TextChanged(sender As Object, e As EventArgs) Handles tb_Rserial.TextChanged
        Try
            If tb_Rserial.InvokeRequired Then
                tb_Rserial.Invoke(Sub() BangCodong.bt_CCD.Text = tb_Rserial.Text)
            Else
                BangCodong.bt_CCD.Text = tb_Rserial.Text
            End If
            BangCodong.trangthaiCCD()
        Catch
        End Try
    End Sub
    Private Sub TB_tencanh_TextChanged(sender As Object, e As EventArgs) Handles TB_tencanh.TextChanged
        Try
            If TB_tencanh.InvokeRequired Then
                TB_tencanh.Invoke(Sub() BangKichBan.lb_NameScene.Text = TB_tencanh.Text)
            Else
                BangKichBan.lb_NameScene.Text = TB_tencanh.Text
            End If

        Catch
        End Try
    End Sub
    Private Sub TB_socanh_TextChanged(sender As Object, e As EventArgs) Handles TB_socanh.TextChanged
        Try
            If TB_socanh.InvokeRequired Then
                TB_socanh.Invoke(Sub() BangKichBan.lb_IDKB.Text = TB_socanh.Text)
            Else
                BangKichBan.lb_IDKB.Text = TB_socanh.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub bt_fly_TextChanged(sender As Object, e As EventArgs) Handles bt_fly.TextChanged
        Try
            If bt_fly.InvokeRequired Then
                bt_fly.Invoke(Sub() FrmMain.Instance.bt_fly.Text = bt_fly.Text)
            Else
                FrmMain.Instance.bt_fly.Text = bt_fly.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub TxtLaser_TextChanged(sender As Object, e As EventArgs) Handles TxtLaser.TextChanged
        Try
            If TxtLaser.Text <> "" Then
                Dim newText As String() = TxtLaser.Text.Split(","c)
                LocY = newText(0) 'TỌA ĐỘ Y
                LocX = newText(1) ' TỌA ĐỘ X
                If LocY >= CanhNgang Or LocX >= CanhDoc Then
                    'MessageBox.Show("Toạ độ lớn hơn chiều ngang hoặc dọc của sa bàn")
                Else
                    tinhtoan()
                End If
                Dim GNgangInt As Integer
                Dim GDocInt As Integer
                If Integer.TryParse(GNgangNow.ToString(), GNgangInt) AndAlso Integer.TryParse(GDocNow.ToString(), GDocInt) Then
                    Dim dataToSend As String = "g" + GNgangInt.ToString() + "_" + GDocInt.ToString()
                    serialPort.Write(dataToSend)
                Else
                    ' Lỗi chuyển đổi, không thể sử dụng GNgangInt và GDocInt
                    'Console.WriteLine("Lỗi chuyển đổi thành kiểu Integer.")
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub TxtTrinhchieu_TextChanged(sender As Object, e As EventArgs) Handles TxtTrinhchieu.TextChanged
        Try

            Dim newText As String = TxtTrinhchieu.Text
            If TxtTrinhchieu.Text.Contains(".") Then
                Dim values As String() = newText.Split("."c) ' Tách các giá trị thành một mảng
                If values.Length = 2 Then
                    Dim Bit As Double = CDbl(values(0))
                    Bit -= 1 ' Trừ 1 từ giá trị Bit
                    TRData("A" + Bit.ToString())
                End If
            Else
                Dim values As String() = newText.Split(","c) ' Tách các giá trị thành một mảng
                Dim bitArray(319) As Char ' Mảng chứa 320 bit
                For i As Integer = 0 To bitArray.Length - 1
                    bitArray(i) = "0"c ' Gán giá trị "0" cho mỗi vị trí trong mảng
                Next
                For Each value As String In values
                    Dim position As Integer = Integer.Parse(value.Substring(0, value.Length - 1)) ' Lấy vị trí từ giá trị
                    Dim bitValue As Integer = Integer.Parse(value.Substring(value.Length - 1)) ' Lấy giá trị bit từ giá trị
                    bitArray(position - 1) = bitValue.ToString()(0) ' Gán giá trị bit vào vị trí tương ứng trong mảng
                Next
                Dim txt2 As String = ""
                For i As Integer = 0 To bitArray.Length - 1
                    If bitArray(i) = "0"c Then
                        txt2 &= "00"
                    End If
                    If bitArray(i) = "1"c Then
                        txt2 &= "01"
                    End If
                    If bitArray(i) = "2"c Then
                        txt2 &= "11"
                    End If
                Next
                Dim hexList As List(Of String) = Enumerable.Range(0, txt2.Length \ 8) _
                    .Select(Function(i) txt2.Substring(8 * i, 8)) _
                    .Select(Function(s) Convert.ToByte(s, 2)) _
                    .Select(Function(b) b.ToString("X2")) _
                    .ToList()
                Dim hex As String = String.Concat(hexList)
                Dim KB1 As String = hex.Substring(0, 54)
                Dim KB2 As String = hex.Substring(54, 54)
                Dim KB3 As String = hex.Substring(108, 52)
                If KiemTraData(KB1) Then
                    Thread.Sleep(100)
                    TRData("KB1_" + KB1)
                End If
                If KiemTraData(KB2) Then
                    Thread.Sleep(100)
                    TRData("KB2_" + KB2)
                End If
                If KiemTraData(KB3) Then
                    Thread.Sleep(100)
                    TRData("KB3_" + KB3)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub tb_TrinhChieuSBVL_TextChanged(sender As Object, e As EventArgs) Handles tb_TrinhChieuSBVL.TextChanged
        Try
            If tb_TrinhChieuSBVL.InvokeRequired Then
                tb_TrinhChieuSBVL.Invoke(Sub() FrmMain.Instance.tb_TrinhChieu.Text = tb_TrinhChieuSBVL.Text)
                tb_TrinhChieuSBVL.Text = ""
            Else
                FrmMain.Instance.tb_TrinhChieu.Text = tb_TrinhChieuSBVL.Text
                tb_TrinhChieuSBVL.Text = ""
            End If
        Catch
        End Try
    End Sub
    Private Sub DieuKhienCo_TextChanged(sender As Object, e As EventArgs) Handles DieuKhienCo.TextChanged
        Try
            If DieuKhienCo.InvokeRequired Then
                DieuKhienCo.Invoke(Sub() FrmMain.Instance.DieuKhienCo1.Text = DieuKhienCo.Text)

            Else
                FrmMain.Instance.DieuKhienCo1.Text = DieuKhienCo.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub tb_BN_TextChanged(sender As Object, e As EventArgs) Handles tb_BN.TextChanged
        Try
            If tb_BN.InvokeRequired Then
                tb_BN.Invoke(Sub() FrmMain.Instance.tb_BN.Text = tb_BN.Text)
            Else
                FrmMain.Instance.tb_BN.Text = tb_BN.Text
            End If
            tb_BN.Text = ""
        Catch
        End Try
    End Sub
    Private Sub tinhtoan()
        Try
            Dim CanhHuyen As Double = Math.Sqrt((CanhDoc - LocX) * (CanhDoc - LocX) + (CanhNgang - LocY) * (CanhNgang - LocY))
            Dim GNgangLT As Double = Math.Atan((CanhNgang - LocY) / (CanhDoc - LocX)) * (180 / Math.PI)
            Dim GDocLT As Double = Math.Atan(CanhHuyen / ChieuCao) * (180 / Math.PI)
            Dim gocxanhatlythuyet As Double = Math.Atan(Math.Sqrt((CanhNgang * CanhNgang) + (CanhDoc * CanhDoc)) / ChieuCao) * (180 / Math.PI)

            'bù trừ ngang
            Dim GNgangTT As Double = G0doNgang + (G90doNgang - G0doNgang) / 90 * GNgangLT
            ' bù trừ góc dọc
            Dim GDocTT As Double = G0doDoc + ((GDocLT / gocxanhatlythuyet) * (GocXaNhatDoc - G0doDoc))

            GDocNow = GDocTT
            GNgangNow = GNgangTT
        Catch
        End Try
    End Sub
#End Region
#Region "Hàm Con"
    Private Sub LayDoiTuong(data As String)
        Try
            Threading.Thread.Sleep(10)
            Dim fileName As String = "DoiTuong.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                xmlDoc.Load(filePath)
                Dim DuLieu As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/Ten[@ID='" & data & "']")
                Dim DataDL As XmlElement = DirectCast(DuLieu.SelectSingleNode("Data"), XmlElement)
                Dim TenDT As String = DataDL.InnerText

                If Khoa3Dmap = False Then
                    If TT3DmapTP = 0 Then

                        Dim existingItems As String() = FrmMain.Instance.txtNnTrt.Text.Split(","c)
                        Dim updatedItems As New List(Of String)()
                        For Each item As String In existingItems
                            If item.Trim() <> TenDT Then
                                updatedItems.Add(item)
                            End If
                        Next
                        FrmMain.Instance.txtNnTrt.Text = String.Join(",", updatedItems)
                        FrmMain.Instance.sgworldMain.ProjectTree.SetVisibility(FrmMain.Instance.sgworldMain.ProjectTree.FindItem(TenDT), True)
                    End If

                    If TT3DmapTP = 2 Then
                        Lenhve = "NNtructiep3"
                        If FrmMain.Instance.txtNnTrt.Text = "" Then
                            FrmMain.Instance.txtNnTrt.Text = TenDT
                        Else
                            FrmMain.Instance.txtNnTrt.Text = FrmMain.Instance.txtNnTrt.Text & "," & TenDT
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ' Xử lý ngoại lệ nếu cần
        End Try
    End Sub
    Private Sub SangSBS()
        Try
            FrmMain.Instance.txtNnTrt.Text = ""
            tb_TruyenBit.Text = ""
            FrmMain.Instance.sgworldMain.ProjectTree.SetVisibility("", True)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RunCmdCommandElevated(ByVal command As String)
        Dim processInfo As New ProcessStartInfo("cmd.exe") With
    {
        .Verb = "runas", ' Chạy với quyền quản trị
        .Arguments = "/C " & command, ' Chạy lệnh và đóng cửa sổ Command Prompt
        .CreateNoWindow = True, ' Ẩn cửa sổ Command Prompt
        .UseShellExecute = True
    }
        Dim process As New Process()
        process.StartInfo = processInfo
        process.Start()
        process.WaitForExit()
    End Sub
    Private Sub tb_TruyenBit_TextChanged(sender As Object, e As EventArgs) Handles tb_TruyenBit.TextChanged
        Try
            If tb_TruyenBit.InvokeRequired Then
                tb_TruyenBit.Invoke(Sub() LayDoiTuong(tb_TruyenBit.Text))
            Else
                LayDoiTuong(tb_TruyenBit.Text)
            End If
        Catch ex As Exception
        End Try
        tb_TruyenBit.Text = ""
    End Sub
    Private Sub tb_TruyenBit_2_TextChanged(sender As Object, e As EventArgs) Handles tb_TruyenBit_2.TextChanged
        Try
            If tb_TruyenBit_2.InvokeRequired Then
                tb_TruyenBit_2.Invoke(Sub() SangSBS())
            Else
                SangSBS()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Thoat()
        TRData("Off")
        OnTong = 0
        BangBitDon.TTALL(OnTong)
        BangBitTong.TTALL(OnTong)
        RunCmdCommandElevated("date " & TGNgay)
        RunCmdCommandElevated("time " & TongGio)
        GhiSettings("Tat3DmapTP")
    End Sub
    Public Sub Khoa_3Dmap(data As String)
        If data = 1 Then
            lb_Khoa3Dmap.Visible = True
            btn_Khoa3Dmap.Visible = True
        Else
            lb_Khoa3Dmap.Visible = False
            btn_Khoa3Dmap.Visible = False
        End If
    End Sub
#End Region
#Region "Cơ sở dữ liệu"
    Private Sub DocSettings()
        Try
            Dim fileName As String = "Settings.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                ' Mo3DmapTP
                Dim mo3DmapTPElement As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='Mo3DmapTP']")
                Dim trangThaiElement As XmlElement = DirectCast(mo3DmapTPElement.SelectSingleNode("TrangThai"), XmlElement)
                Mo3DmapTP = trangThaiElement.InnerText
                ' ThoiGian
                Dim ThoiGianElement As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='ThoiGian']")
                Dim NgayElement As XmlElement = DirectCast(ThoiGianElement.SelectSingleNode("Ngay"), XmlElement)
                Dim GioElement As XmlElement = DirectCast(ThoiGianElement.SelectSingleNode("Gio"), XmlElement)
                TGNgay = NgayElement.InnerText
                TGGio = GioElement.InnerText
                ' PhienBan
                Dim PhienBan As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='PhienBan']")
                Dim ThongTin_DLC As XmlElement = DirectCast(PhienBan.SelectSingleNode("ThongTin"), XmlElement)
                Dim TrangThai_DLC As XmlElement = DirectCast(PhienBan.SelectSingleNode("TrangThai"), XmlElement)
                ThongTin_LC = ThongTin_DLC.InnerText
                TrangThai_LC = TrangThai_DLC.InnerText
                Dim decodedString As String = HexToString(TrangThai_LC)
                IDKey_1 = decodedString.Substring(0, 4)
                IDKey_2 = Array.IndexOf(GiaTri, decodedString.Substring(decodedString.Length - 1, 1))
                Dim PhanTramPin As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='PhanTramPin']")
                Dim PT_Pin As XmlElement = DirectCast(PhanTramPin.SelectSingleNode("ThongTin"), XmlElement)
                Me.Invoke(Sub()
                              lb_pin.Text = PT_Pin.InnerText
                              HinhPTPin()
                          End Sub)
            Else
                MessageBox.Show("Tệp tin Settings.xml không tồn tại.")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GhiSettings(data As String)
        Try
            If File.Exists(xmlFilePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(xmlFilePath)
                Dim mo3DmapTPElement As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='Mo3DmapTP']")
                Dim trangThaiElement As XmlElement = DirectCast(mo3DmapTPElement.SelectSingleNode("TrangThai"), XmlElement)
                If data = "Mo3DmapTP" Then
                    trangThaiElement.InnerText = "1"
                ElseIf data = "Tat3DmapTP" Then
                    trangThaiElement.InnerText = "0"
                End If
                xmlDoc.Save(xmlFilePath)
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Giải Mã"
    Private Function HexToString(hexString As String) As String
        Dim bytes As Byte() = Enumerable.Range(0, hexString.Length / 2).Select(Function(i) Convert.ToByte(hexString.Substring(i * 2, 2), 16)).ToArray()
        Return Encoding.UTF8.GetString(bytes)
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
    Private Sub PhanQuyen()
        Try
            Select Case IDKey_2
                Case "0"
                    BtnSbso.Enabled = False
                    btn_pnl_OnBit.Enabled = True
                    btn_TrangBitTong.Enabled = False
                    btn_TrangCoCoDong.Enabled = False
                    btn_TrangKichBan.Enabled = False
                Case "1"
                    BtnSbso.Enabled = False
                    btn_pnl_OnBit.Enabled = True
                    btn_TrangBitTong.Enabled = True
                    btn_TrangCoCoDong.Enabled = False
                    btn_TrangKichBan.Enabled = False
                Case "2"
                    BtnSbso.Enabled = False
                    btn_pnl_OnBit.Enabled = True
                    btn_TrangBitTong.Enabled = True
                    btn_TrangCoCoDong.Enabled = True
                    btn_TrangKichBan.Enabled = False
                Case "3"
                    BtnSbso.Enabled = False
                    btn_pnl_OnBit.Enabled = True
                    btn_TrangBitTong.Enabled = True
                    btn_TrangCoCoDong.Enabled = True
                    btn_TrangKichBan.Enabled = True
                Case "4"
                    BtnSbso.Enabled = True
                    btn_pnl_OnBit.Enabled = True
                    btn_TrangBitTong.Enabled = True
                    btn_TrangCoCoDong.Enabled = True
                    btn_TrangKichBan.Enabled = True
                Case Else
                    Dim key As String = ThongTin_LC + ".txt"
                    Dim txtFiles As String = Path.Combine(folderPath1, key)
                    File.Delete(txtFiles)
                    MessageBox.Show("Key phần mềm chưa được phân quyền", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    System.Windows.Forms.Application.Exit()
            End Select
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Theo dõi XML"
    Private Sub TheoDoiXMl_Settins()
        Try
            watcher.Path = Path.GetDirectoryName(xmlFilePath)
            watcher.Filter = "Settings.xml"
            watcher.NotifyFilter = NotifyFilters.LastWrite
            watcher.EnableRaisingEvents = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub watcher_Changed(sender As Object, e As FileSystemEventArgs) Handles watcher.Changed
        Try
            If e.FullPath = xmlFilePath Then
                Invoke(New Action(AddressOf DocSettings))
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Kịch Bản Sa Bàn Số"
    Public Sub KichbanSBS()
        Try
            BangCodong.Visible = False
            BangKichBan.Visible = True
            BangBitDon.Visible = False
            BangBitTong.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BangKichBan_KichBanDataToMainToSBS(sender As Object, e As String) Handles BangKichBan.KichBanDataToMainToSBS
        Try
            If Mo3DmapTP = 1 Then
                tb_TruyenBit_2.Text = " "
                tb_TruyenBit_2.Text = "1"
                TT3DmapTP = 2
                For i As Integer = 0 To e.Length - 1
                    If e(i) = "2"c OrElse e(i) = "1"c Then
                        If Mo3DmapTP = 1 Then
                            tb_TruyenBit.Text = (i + 1).ToString()
                        End If
                    End If

                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Thoát Phần Mềm"
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub bt_xoabit_Click(sender As Object, e As EventArgs)
        'Try
        '    OnTong = 0
        '    BangBitDon.TTALL(OnTong)
        '    BangBitTong.TTALL(OnTong)
        '    BangBitDon.resetBitTong()
        '    BangBitDon.resetKichBan()
        '    BangBitTong.resetkb()
        '    BangKichBan.resetKichBan()
        'Catch ex As Exception
        'End Try
    End Sub
#End Region
#Region "locnhieupin"
    Private DanhSachNhieu As New List(Of Decimal)()
    Private Sub LocNhieuPin(newValue As Decimal)
        DanhSachNhieu.Add(newValue) ' Thêm giá trị mới vào danh sách
        If DanhSachNhieu.Count > 25 Then ' Giữ danh sách có kích thước tối đa là 25
            DanhSachNhieu.RemoveAt(0)
        End If
        Dim GiaTriTB As Decimal = DanhSachNhieu.Average() ' Tính trung bình di động
        Dim Pin As Integer = CInt((GiaTriTB - 3.0) / (4.0 - 3.0) * 100) ' Tính toán phần trăm và cập nhật giao diện người dùng
        Me.Invoke(Sub()
                      lb_pin.Text = Pin.ToString() & "%"
                      xmlDoc.Load(xmlFilePath)
                      Dim PT_Pin As XmlElement = DirectCast(xmlDoc.SelectSingleNode("/DuLieu/So[@ID='PhanTramPin']").SelectSingleNode("ThongTin"), XmlElement)
                      PT_Pin.InnerText = lb_pin.Text
                      xmlDoc.Save(xmlFilePath)
                  End Sub)
    End Sub
    Private Sub HinhPTPin()
        Dim pinValue As Double
        If Double.TryParse(lb_pin.Text.TrimEnd("%"c), pinValue) Then
            Dim newImage As Image = Nothing
            If pinValue >= 100 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Max.PNG"))
            ElseIf pinValue >= 80 AndAlso pinValue < 100 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Max.PNG"))
            ElseIf pinValue >= 60 AndAlso pinValue < 80 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Min1.PNG"))
            ElseIf pinValue >= 40 AndAlso pinValue < 60 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Min2.PNG"))
            ElseIf pinValue >= 20 AndAlso pinValue < 40 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Min3.PNG"))
                MessageBox.Show("Lưu ý: Pin bút laser của bạn hiện đang ở mức dưới 40%. Hãy nạp đầy pin để đảm bảo hoạt động ổn định.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf pinValue >= 0 AndAlso pinValue < 20 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Min3.PNG"))
                MessageBox.Show("Lưu ý: Pin bút laser của bạn hiện đang ở mức dưới 20%. Hãy nạp đầy pin để đảm bảo hoạt động ổn định.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf pinValue <= 0 Then
                newImage = Image.FromFile(Path.Combine(folderPath, "Min3.PNG"))
                MessageBox.Show("Lưu ý: Pin bút laser của bạn hiện đang ở mức 0%. Hãy nạp đầy pin để đảm bảo hoạt động ổn định.", "Thông Báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            pc_Pin.BackgroundImage = newImage
        End If
    End Sub
    Private Sub tb_trangthaico_TextChanged(sender As Object, e As EventArgs) Handles tb_trangthaico.TextChanged
        Try
            If tb_trangthaico.InvokeRequired Then
                tb_trangthaico.Invoke(Sub() BangCodong.trangthaico())
            End If
        Catch
        End Try

    End Sub
#End Region
#Region "Python"
    Public Shared Event ValueChanged1 As EventHandler(Of String)
    Public Shared Property ReturnedValue1 As String
    Private Shared Bam1 As String = ""
    Public Shared Event ValueChanged2 As EventHandler(Of String)
    Public Shared Property ReturnedValue2 As String
    Private Shared Bam2 As String = ""
    Private _isClosed As Boolean = False
    Public ReadOnly Property IsClosed As Boolean
        Get
            Return _isClosed
        End Get
    End Property
    Private Sub FrmSBVLM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _isClosed = True
    End Sub
    Public Shared Sub ShowFrmSBVLM()
        Dim form As New FrmSBVLM()
        AddHandler FrmSBVLM.ValueChanged1, Sub(sender, value)
                                               ReturnedValue1 = value
                                           End Sub
        AddHandler FrmSBVLM.ValueChanged2, Sub(sender, value)
                                               ReturnedValue2 = value
                                           End Sub
        form.Show()
        ' Chờ cho đến khi form đóng
        While Not form.IsClosed
            Application.DoEvents() ' Cho phép ứng dụng xử lý các sự kiện khác trong khi chờ đợi
        End While
        ReturnedValue1 = Bam1
        ReturnedValue2 = Bam2
    End Sub
    Public Shared Property txt As String
    Public Shared Sub FlyXY(x As Integer, y As Integer)
        Try
            LCxx = x
            LCyy = y
            txt = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
            Instance.tb_test.Text = txt
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Public Shared Sub PythonCall()
        FrmSBVLM.ValueChanged1Event.Invoke(Nothing, "DaNhan")
    End Sub
    Public Shared Sub PythonCCD(data As String)
        Dim values As String() = data.Split("_"c)
        If values.Length = 2 Then
            Dim part1 As String = values(0).Substring(1)
            Dim part2 As String = values(1)
            Dim values1 As String() = part2.Split(","c)
            If values1.Length = 2 Then
                Dim part3 As String = values1(0)
                Dim part4 As String = values1(1)
                Dim ba As String = part1 + "_" + part3 + "," + part4
                Dim txt As String = part3 + "," + part4 + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                Dim mtb As String = $"C{part1}"
                Instance.TxtDTmoi.Text = txt
                Instance.bt_mtt.Text = mtb
                Instance.bt_inal.Text = ba
                ValueChanged2Event.Invoke(Nothing, "tat_" + mtb)
                Instance.TRData(mtb + "_3")
            End If
        End If
    End Sub
    Public Shared Sub PythonThoat()
        Instance.Thoat()
        If Instance.Mo3DmapTP = 1 Then
            FrmMain.Instance.ResetLogin()
        End If
        Instance.Close()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        ValueChanged1Event.Invoke(Me, "Ex")
    End Sub
    Public Shared Sub DongPort()
        Try
            Instance.serialPort.Close() ' Đóng cổng COM
            Instance.btn_KetNoi.ForeColor = Color.White
            Instance.btn_KetNoi.Text = "Kết nối"
            Instance.isPortOpen = False
            Instance.btn_LamMoi.Enabled = True
        Catch ex As Exception
            'MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub tb_truyentoado_TextChanged(sender As Object, e As EventArgs) Handles tb_truyentoado.TextChanged
        Try
            If tb_truyentoado.InvokeRequired Then
                tb_truyentoado.Invoke(Sub() FrmMain.Instance.tb_truyentoado.Text = tb_truyentoado.Text)
            Else
                FrmMain.Instance.tb_truyentoado.Text = tb_truyentoado.Text
            End If
            tb_truyentoado.Text = ""
        Catch
        End Try
    End Sub
    Private Sub bt_mtt_TextChanged(sender As Object, e As EventArgs) Handles bt_mtt.TextChanged
        Try
            If bt_mtt.InvokeRequired Then
                bt_mtt.Invoke(Sub() FrmMain.Instance.tb_mau.Text = bt_mtt.Text)
            Else
                FrmMain.Instance.tb_mau.Text = bt_mtt.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub bt_inal_TextChanged(sender As Object, e As EventArgs) Handles bt_inal.TextChanged
        Try
            If bt_inal.InvokeRequired Then
                bt_inal.Invoke(Sub() FrmMain.Instance.bt_ccd1.Text = bt_inal.Text)
            Else
                FrmMain.Instance.bt_ccd1.Text = bt_inal.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub btn_XLA_Click(sender As Object, e As EventArgs) Handles btn_XLA.Click
        ValueChanged1Event.Invoke(Me, "Xulyanh")
        Threading.Thread.Sleep(100)
    End Sub
    Private Sub btn_Khoa3Dmap_CheckedChanged(sender As Object, e As EventArgs) Handles btn_Khoa3Dmap.CheckedChanged
        Try
            If btn_Khoa3Dmap.Checked = True Then
                Khoa3Dmap = True
            Else
                Khoa3Dmap = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TxtDTmoi_TextChanged(sender As Object, e As EventArgs) Handles TxtDTmoi.TextChanged
        Try
            If TxtDTmoi.InvokeRequired Then
                TxtDTmoi.Invoke(Sub() FrmMain.Instance.bt_flyccd.Text = TxtDTmoi.Text)
            Else
                FrmMain.Instance.bt_flyccd.Text = TxtDTmoi.Text
            End If
        Catch
        End Try
    End Sub
    Public Sub ShowTC()
        ValueChanged1Event.Invoke(Me, "TCopen")
    End Sub
    Public Sub ThoatTC()
        ValueChanged1Event.Invoke(Me, "TCclose")
    End Sub
#End Region
End Class