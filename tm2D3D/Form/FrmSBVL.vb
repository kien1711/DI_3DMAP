Imports System.IO
Imports System.IO.Ports
Imports System.Text
Imports System.Threading
''Imports TerraExplorerX

Public Class FrmSBVL

#Region "khai báo biến toàn cục"
    Private isPortOpen As Boolean = False
    Private serialPort As SerialPort
    Private LuuBitLe As New List(Of Integer)()
    Private folderPath As String
    Private dataString As Char() = New Char(319) {}
    Private first40Bits As String
    Private last40Bits As String
    Private WithEvents fileWatcher As FileSystemWatcher
    Private WithEvents fileWatcher1 As FileSystemWatcher
    Private WithEvents fileWatcher2 As FileSystemWatcher
    Dim LinkDTPTC As String = "C:\saban\tuongtacXY\DataPythonToC#.txt"
    Dim LinkCCD As String = "C:\saban\tuongtacXY\cocodong.txt"
    Dim LCxx As Integer = 0
    Dim LCyy As Integer = 0
    Dim Roat As Integer = 45
    Dim DoCao As Integer = 30000
    Private xpos1 As Integer
    Private ypos1 As Integer
    Private newpoint As System.Drawing.Point
    Dim ThemNut As Integer = 0

    Dim TenCo As String = ""
    Dim ToadoSB As String = ""

    Dim XoaNut As Integer = 0
    Dim colast
    Dim [mod] As Boolean = False
    Dim locxx1 As Single = 0
    Dim locyy1 As Single = 0

    Public id23 As Boolean = 0
#Region "biến toàn cục cho trụ laser"
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
#End Region

#End Region
#Region "Load"
    Private Sub FrmSBVL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
#Region "Tạo Data"
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim folderName As String = "Data"
            folderPath = Path.Combine(baseDirectory, folderName)
            Try
                If Not Directory.Exists(folderPath) Then
                    Directory.CreateDirectory(folderPath)
                End If
            Catch
            End Try
#End Region
            KN_Port()
            DB_BitLe()
            DB_BitTong()
            DB_Cocodong()
            DB_LuuBit()
            RDoiTuong()
            TreeviewBit()
            LoadBitTong()
            ResetDataString()
            ResetButton()
            LoadCCD()
            Load_Bit()
            btn_KetNoi.BackColor = Color.Green
            btn_KetNoi.ForeColor = Color.White
            btn_Trang1.BackColor = Color.FromArgb(0, 117, 214)
            btn_Trang1.ForeColor = Color.White
            ' khởi tạo cho toolstrip cờ cơ động
            If id23 = 1 Then


            End If
            fileWatcher = New FileSystemWatcher With {
            .Path = Path.GetDirectoryName(LinkDTPTC),
            .Filter = Path.GetFileName(LinkDTPTC),
            .NotifyFilter = NotifyFilters.LastWrite ' Theo dõi sự kiện chỉnh sửa tệp tin
            } ' Khởi tạo FileSystemWatcher
            AddHandler fileWatcher.Changed, AddressOf RDataPythonToC ' Xác định các sự kiện cần theo dõi
            fileWatcher.EnableRaisingEvents = True ' Bắt đầu theo dõi


            fileWatcher2 = New FileSystemWatcher With {
            .Path = Path.GetDirectoryName(LinkCCD),
            .Filter = Path.GetFileName(LinkCCD),
            .NotifyFilter = NotifyFilters.LastWrite ' Theo dõi sự kiện chỉnh sửa tệp tin
            } ' Khởi tạo FileSystemWatcher
            AddHandler fileWatcher2.Changed, AddressOf RCCD ' Xác định các sự kiện cần theo dõi
            fileWatcher2.EnableRaisingEvents = True ' Bắt đầu theo dõi

            'fileWatcher.EnableRaisingEvents = False ' Dừng theo dõi
            'fileWatcher.Dispose()
            SCreenDkSBVL()
            CB_DKSabanso.Checked = True
            btn_ThemNut.Location = New Point(344, 32)
            btn_XoaNut.Location = New Point(368, 32)
            Me.Size = New Size(253, 245)
            SBVL.Size = New Size(253, 245)
            btn_Exit.Location = New Point(230, 1)
            Dim FolderPath1 As String = "C:\TIENPHAT\kichban"
            LoadTextFilesToListBox(FolderPath1)

            Dim filePath3 As String = "C:/TIENPHAT/Sabanmau/dosang.txt"
            If File.Exists(filePath3) Then
                Using reader As New StreamReader(filePath3)
                    Dim line As String = reader.ReadLine()
                    If Not String.IsNullOrEmpty(line) Then
                        Dim savedValue As Integer
                        If Integer.TryParse(line, savedValue) Then
                            trackBar1.Value = savedValue
                        End If
                    End If
                End Using
            End If
            'FrmMain.pnTrinhchieu.Visible = True
            'FrmMain.pnTrinhchieu.Location = New Point(-100, -200)
        Catch
        End Try
    End Sub
#End Region
#Region "Kết nối"
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
                            btn_KetNoi.ForeColor = Color.White
                            btn_KetNoi.Text = "Đóng"
                            isPortOpen = True
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
                btn_KetNoi.BackColor = Color.Green ' Đặt màu nền lại thành màu mặc định hoặc một màu khác
                btn_KetNoi.ForeColor = Color.White
                btn_KetNoi.Text = "Kết nối"
                isPortOpen = False
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
    Public Sub DongPort()
        Try
            If btn_KetNoi.BackColor = Color.Red Then
                serialPort.Close()
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Nút Nhấn"
    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button9.MouseDown, Button8.MouseDown, Button7.MouseDown, Button6.MouseDown, Button5.MouseDown, Button40.MouseDown, Button4.MouseDown, Button39.MouseDown, Button38.MouseDown, Button37.MouseDown, Button36.MouseDown, Button35.MouseDown, Button34.MouseDown, Button33.MouseDown, Button32.MouseDown, Button31.MouseDown, Button30.MouseDown, Button3.MouseDown, Button29.MouseDown, Button28.MouseDown, Button27.MouseDown, Button26.MouseDown, Button25.MouseDown, Button24.MouseDown, Button23.MouseDown, Button22.MouseDown, Button21.MouseDown, Button20.MouseDown, Button2.MouseDown, Button19.MouseDown, Button18.MouseDown, Button17.MouseDown, Button16.MouseDown, Button15.MouseDown, Button14.MouseDown, Button13.MouseDown, Button12.MouseDown, Button11.MouseDown, Button10.MouseDown, Button1.MouseDown
        Try
            If CB_DoiTenBit.Checked = False Then
                If CB_ThemBitTong.Checked = False Then
                    Dim button As Button = TryCast(sender, Button)
                    Dim dataNumber As Integer = Convert.ToInt16(button.Name.Substring(6))
                    TrangThaiNut(button, e, dataNumber)
                    TRBitTong(button, e, dataNumber)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub TrangThaiNut(button As Button, e As MouseEventArgs, dataNumber As Integer)
        Try
            If e.Button = MouseButtons.Left Then
                If button.BackColor = Color.White Then
                    button.BackColor = Color.Blue
                    button.ForeColor = Color.White
                ElseIf button.BackColor = Color.Blue Then
                    button.BackColor = Color.White
                    button.ForeColor = Color.Black
                ElseIf button.BackColor = Color.Red Then
                    button.BackColor = Color.Blue
                    button.ForeColor = Color.White
                End If
            ElseIf e.Button = MouseButtons.Middle Then
                If button.BackColor = Color.White Then
                    button.BackColor = Color.Red
                    button.ForeColor = Color.White
                ElseIf button.BackColor = Color.Red Then
                    button.BackColor = Color.White
                    button.ForeColor = Color.Black
                ElseIf button.BackColor = Color.Blue Then
                    button.BackColor = Color.Red
                    button.ForeColor = Color.White
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub TRBitTong(button As Button, e As MouseEventArgs, dataNumber As Integer)
        Try
            Dim SoDong As Integer
            If btn_Trang1.BackColor = Color.FromArgb(0, 117, 214) Then
                SoDong = dataNumber
            End If
            If btn_Trang2.BackColor = Color.FromArgb(0, 117, 214) Then
                SoDong = dataNumber + 40
            End If
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines As String() = File.ReadAllLines(filePath)
            Dim lineToModify As String = lines(SoDong - 1)
            Dim parts As String() = lineToModify.Split(","c)
            Dim part1 As String = parts(0).Trim()
            Dim part2 As String = parts(1).Trim()
            Dim part3 As String = parts(2).Trim()
            If parts.Length = 4 Then
                Dim hexList As List(Of String) = Enumerable.Range(0, part3.Length \ 8) _
                .Select(Function(i) part3.Substring(8 * i, 8)) _
                .Select(Function(s) Convert.ToByte(s, 2)) _
                .Select(Function(b) b.ToString("X2")) _
                .ToList()
                Dim hex As String = String.Concat(hexList)
                first40Bits = hex.Substring(0, 40)
                last40Bits = hex.Substring(40)
            End If
            If button.BackColor = Color.Red Then
                If CB_DKSabanso.Checked = False Then
                    SBSBitTong(part3, "Nhay")
                End If
                Dim modifiedLine As String = $"{part1},{part2},{part3},{2}"
                lines(SoDong - 1) = modifiedLine
                File.WriteAllLines(filePath, lines)
                If KiemTraData(first40Bits) Then
                    Thread.Sleep(100)
                    TRData("DB1_" + first40Bits)
                End If
                If KiemTraData(last40Bits) Then
                    Thread.Sleep(100)
                    TRData("DB2_" + first40Bits)
                End If
            End If
            If button.BackColor = Color.Blue Then
                If CB_DKSabanso.Checked = False Then
                    SBSBitTong(part3, "Sang")
                End If
                Dim modifiedLine As String = $"{part1},{part2},{part3},{1}"
                lines(SoDong - 1) = modifiedLine
                File.WriteAllLines(filePath, lines)
                If KiemTraData(first40Bits) Then
                    Thread.Sleep(100)
                    TRData("DA1_" + first40Bits)
                End If
                If KiemTraData(last40Bits) Then
                    Thread.Sleep(100)
                    TRData("DA2_" + first40Bits)
                End If
            End If
            If button.BackColor = Color.White Then
                If CB_DKSabanso.Checked = False Then
                    SBSBitTong(part3, "Sang")
                End If
                Dim modifiedLine As String = $"{part1},{part2},{part3},{0}"
                lines(SoDong - 1) = modifiedLine
                File.WriteAllLines(filePath, lines)
                If KiemTraData(first40Bits) Then
                    Thread.Sleep(100)
                    TRData("DO1_" + first40Bits)
                End If
                If KiemTraData(last40Bits) Then
                    Thread.Sleep(100)
                    TRData("DO2_" + first40Bits)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub SBSBitTong(data As String, TrangThai As String)
        Try
            Dim fileName As String = "Doituong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim full As String = ""
            If File.Exists(filePath) Then
                Dim lines As String() = File.ReadAllLines(filePath)
                For i As Integer = 0 To data.Length - 1
                    If data(i) <> "0" Then
                        Dim nodeName As String = tv_BitLe.Nodes(i).Text
                        Dim FullTen As String = nodeName + "_" + (i + 1).ToString()
                        For Each line As String In lines
                            Dim trimmedLine As String = line.Trim()
                            Dim lastIndex As Integer = trimmedLine.LastIndexOf("\")
                            Dim result As String = trimmedLine.Substring(lastIndex + 1)
                            If FullTen = result Then
                                full = full & "," & trimmedLine
                            End If
                        Next
                    End If
                Next
                full = full.TrimStart(","c)
                If TrangThai = "Nhay" Then
                    Lenhve = "NNtructiep3"
                    If FrmMain.txtNnTrt.Text = "" Then
                        FrmMain.txtNnTrt.Text = full
                    Else
                        FrmMain.txtNnTrt.Text = FrmMain.txtNnTrt.Text & "," & full
                    End If
                End If
                If TrangThai = "Sang" Then
                    Dim Ten As String = FrmMain.txtNnTrt.Text.Replace(full, String.Empty).Replace(",,", ",")
                    Dim BoPhay As String = Ten.Trim(",").TrimEnd(",")
                    FrmMain.txtNnTrt.Text = ""
                    FrmMain.txtNnTrt.Text = BoPhay
                    FrmMain.sgworldMain.ProjectTree.SetVisibility(FrmMain.sgworldMain.ProjectTree.FindItem(full), True)
                End If
            Else
                MessageBox.Show("Tệp Doituong.txt không tồn tại.")
            End If
        Catch
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
    Private Sub Btn_Exit_Click(sender As Object, e As EventArgs) Handles btn_Exit.Click
        Try
            Me.Hide()
            FrmMain.btnCloseTrC.PerformClick()
            'ShowTaskbar()
            tb_SKB.Text = 0
            tb_TKB.Text = "Name"
        Catch
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button40.Click, Button4.Click, Button39.Click, Button38.Click, Button37.Click, Button36.Click, Button35.Click, Button34.Click, Button33.Click, Button32.Click, Button31.Click, Button30.Click, Button3.Click, Button29.Click, Button28.Click, Button27.Click, Button26.Click, Button25.Click, Button24.Click, Button23.Click, Button22.Click, Button21.Click, Button20.Click, Button2.Click, Button19.Click, Button18.Click, Button17.Click, Button16.Click, Button15.Click, Button14.Click, Button13.Click, Button12.Click, Button11.Click, Button10.Click
        Try
            Dim button As Button = TryCast(sender, Button)
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim dataNumber As Integer = Convert.ToInt16(button.Name.Substring(6))
            Dim lines As String() = File.ReadAllLines(filePath)
            If CB_ThemBitTong.Checked = True Then
                ResetDataString()
                For Each index As String In LuuBitLe
                    Dim intIndex As Integer = Integer.Parse(index)
                    dataString(intIndex) = "1"c
                Next
                If btn_Trang1.BackColor = Color.FromArgb(0, 117, 214) Then
                    Dim lineToModify As String = lines(dataNumber - 1)
                    Dim parts As String() = lineToModify.Split(","c)
                    Dim part1 As String = parts(0).Trim()
                    Dim part2 As String = parts(1).Trim()
                    Dim part3 As String = parts(2).Trim()
                    Dim Nhan As String = New String(dataString)
                    Dim modifiedLine As String = $"{part1},{part2},{Nhan},{0}"
                    lines(dataNumber - 1) = modifiedLine
                    File.WriteAllLines(filePath, lines)
                ElseIf btn_Trang2.BackColor = Color.FromArgb(0, 117, 214) Then
                    Dim lineToModify As String = lines(dataNumber + 39)
                    Dim parts As String() = lineToModify.Split(","c)
                    Dim part1 As String = parts(0).Trim()
                    Dim part2 As String = parts(1).Trim()
                    Dim part3 As String = parts(2).Trim()
                    Dim Nhan As String = New String(dataString)
                    Dim modifiedLine As String = $"{part1},{part2},{Nhan},{0}"
                    lines(dataNumber + 39) = modifiedLine
                    File.WriteAllLines(filePath, lines)
                End If

                BoCheck()
                LuuBitLe.Clear()
                button.BackColor = Color.White
                button.ForeColor = Color.Black
                CB_ThemBitTong.Checked = False
                MessageBox.Show("Thêm Bit Thành Công")
            End If
            If CB_DoiTenBit.Checked = True Then
                Dim newName As String = tb_DoiTen.Text
                If newName.Length <= 22 Then
                    button.Text = newName
                    If btn_Trang1.BackColor = Color.FromArgb(0, 117, 214) Then
                        Dim lineToModify As String = lines(dataNumber - 1)
                        Dim parts As String() = lineToModify.Split(","c)
                        Dim part1 As String = parts(0).Trim()
                        Dim part2 As String = newName
                        Dim part3 As String = parts(2).Trim()
                        Dim modifiedLine As String = $"{part1},{part2},{part3},{0}"
                        lines(dataNumber - 1) = modifiedLine
                    ElseIf btn_Trang2.BackColor = Color.FromArgb(0, 117, 214) Then
                        Dim lineToModify As String = lines(dataNumber + 39)
                        Dim parts As String() = lineToModify.Split(","c)
                        Dim part1 As String = parts(0).Trim()
                        Dim part2 As String = newName
                        Dim part3 As String = parts(2).Trim()
                        Dim modifiedLine As String = $"{part1},{part2},{part3},{0}"
                        lines(dataNumber + 39) = modifiedLine
                    End If

                    File.WriteAllLines(filePath, lines)
                    button.BackColor = Color.White
                    button.ForeColor = Color.Black
                    CB_DoiTenBit.Checked = False
                    pnl_DoiTen.Visible = False
                Else
                    MessageBox.Show("Tên mới không được vượt quá 22 kí tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub TTBit()
        Try
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines As String() = File.ReadAllLines(filePath)
            For i As Integer = 0 To 79
                Dim lineToModify As String = lines(i)
                Dim parts As String() = lineToModify.Split(","c)
                Dim part1 As String = parts(0).Trim()
                Dim part2 As String = parts(1).Trim()
                Dim part3 As String = parts(2).Trim()
                If btn_All.BackColor = Color.Blue Then
                    Dim modifiedLine As String = $"{part1},{part2},{part3},{1}"
                    lines(i) = modifiedLine
                    File.WriteAllLines(filePath, lines)
                End If
                If flag_all.BackColor = Color.Red Then
                    Dim modifiedLine As String = $"{part1},{part2},{part3},{2}"
                    lines(i) = modifiedLine
                    File.WriteAllLines(filePath, lines)
                End If
                If btn_Off.BackColor = Color.Blue Then
                    Dim modifiedLine As String = $"{part1},{part2},{part3},{0}"
                    lines(i) = modifiedLine
                    File.WriteAllLines(filePath, lines)
                End If
            Next
        Catch
        End Try
    End Sub
    Private Sub Btn_All_Click(sender As Object, e As EventArgs) Handles btn_All.Click
        Try
            btn_All.BackColor = Color.Blue
            flag_all.BackColor = Color.White
            TRMauNut()
            DaCheck()
            TTBit()
            TRData("Full")
        Catch
        End Try
    End Sub
    Private Sub flag_all_Click(sender As Object, e As EventArgs) Handles flag_all.Click
        Try
            flag_all.BackColor = Color.Red
            btn_All.BackColor = Color.White
            TRMauNut1()
            DaCheck()
            TTBit()
            TRData("FB1")
        Catch
        End Try
    End Sub
    Private Sub btn_Off_Click(sender As Object, e As EventArgs) Handles btn_Off.Click
        Try
            btn_Off.BackColor = Color.Blue
            btn_All.BackColor = Color.White
            flag_all.BackColor = Color.White
            BoCheck()
            TRMauNut()
            TRData("Off")
            TTBit()
            ResetButton()
        Catch
        End Try
    End Sub
    Private Sub btn_ResetCo_Click_1(sender As Object, e As EventArgs) Handles btn_ResetCo.Click
        Try
            TRData("clear")
        Catch
        End Try
    End Sub
    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Try
            Dim result As DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả các nút?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                btn_Off.BackColor = Color.Blue
                btn_All.BackColor = Color.White
                flag_all.BackColor = Color.White
                BoCheck()
                TRMauNut()
                TRData("Off")
                ResetButton()
                Dim fileName1 As String = "BitTong.txt"
                Dim filePath1 As String = Path.Combine(folderPath, fileName1)

                Dim fileName As String = "LuuBit.txt"
                Dim filePath As String = Path.Combine(folderPath, fileName)
                btn_ThemNut.Location = New Point(344, 32)
                btn_XoaNut.Location = New Point(368, 32)
                btn_Trang2.Visible = False

                For i As Integer = 1 To 80
                    Dim TenNutHienTai As String = "Button" + i.ToString()
                    Dim buttonHienTai As Button = Me.Controls.Find(TenNutHienTai, True).FirstOrDefault()
                    File.WriteAllText(filePath, i.ToString())
                Next
                btn_ThemNut.Location = New Point(344, 32)
                btn_XoaNut.Location = New Point(368, 32)
                btn_Trang2.Visible = False
                ThemNut = 0
                File.WriteAllText(filePath, ThemNut.ToString())
                For i As Integer = 1 To 80
                    Dim TenNutHienTai As String = "Button" + i.ToString()
                    Dim buttonHienTai As Button = Me.Controls.Find(TenNutHienTai, True).FirstOrDefault()
                    If buttonHienTai IsNot Nothing Then
                        buttonHienTai.Visible = False
                    End If
                Next
                Dim lines As String() = File.ReadAllLines(filePath1)
                Dim lineIndex As Integer = 0
                Dim startLineIndex As Integer = 1 ' Định nghĩa dòng bắt đầu đọc (dòng 40)
                For Each line As String In lines
                    lineIndex += 1
                    If lineIndex >= startLineIndex Then ' Bỏ qua các dòng trước dòng bắt đầu
                        Dim trimmedLine As String = line.Trim()
                        If Not String.IsNullOrEmpty(trimmedLine) Then
                            Dim commaIndex As Integer = trimmedLine.IndexOf(",")
                            If commaIndex >= 0 AndAlso commaIndex < trimmedLine.Length - 1 Then
                                Dim nodeText As String = trimmedLine.Substring(commaIndex + 1)
                                Dim firstPart As String = trimmedLine.Substring(0, commaIndex)
                                Dim secondPart As String = trimmedLine.Substring(commaIndex + 1)
                                Dim buttonName As String = "Button" & (lineIndex - startLineIndex + 1).ToString()
                                Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                                If button IsNot Nothing Then
                                    button.Text = secondPart.Substring(0, secondPart.IndexOf(","))
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub TRMauNut()
        Try
            For i As Integer = 1 To 40
                Dim buttonName As String = "Button" & i.ToString()
                Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                If button IsNot Nothing Then
                    If btn_Off.BackColor = Color.Blue Then
                        button.BackColor = Color.White
                        button.ForeColor = Color.Black
                    End If
                    If btn_All.BackColor = Color.Blue Then
                        button.BackColor = Color.Blue
                        button.ForeColor = Color.White
                    End If
                End If
            Next
            btn_Off.BackColor = Color.White
        Catch
        End Try
    End Sub
    Private Sub TRMauNut1()
        Try
            For i As Integer = 1 To 40
                Dim buttonName As String = "Button" & i.ToString()
                Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                If button IsNot Nothing Then
                    If flag_all.BackColor = Color.White Then
                        button.BackColor = Color.White
                        button.ForeColor = Color.Black
                    End If
                    If flag_all.BackColor = Color.Red Then
                        button.BackColor = Color.Red
                        button.ForeColor = Color.White
                    End If
                End If
            Next
            btn_Off.BackColor = Color.White
        Catch
        End Try
    End Sub
    Private Sub DaCheck()
        Try
            RemoveHandler tv_BitLe.AfterCheck, AddressOf Tv_BitLe_AfterCheck ' Tạm thời vô hiệu hóa sự kiện AfterCheck
            For Each node As TreeNode In tv_BitLe.Nodes ' Check tất cả các mục trong TreeView
                node.Checked = True ' Check cho mục gốc
            Next
            AddHandler tv_BitLe.AfterCheck, AddressOf Tv_BitLe_AfterCheck ' Kích hoạt lại sự kiện AfterCheck
        Catch
        End Try
    End Sub
    Private Sub BoCheck()
        Try
            RemoveHandler tv_BitLe.AfterCheck, AddressOf Tv_BitLe_AfterCheck ' Tạm thời vô hiệu hóa sự kiện AfterCheck
            For Each node As TreeNode In tv_BitLe.Nodes 'bỏ Check tất cả các mục trong TreeView
                node.Checked = False 'bỏ Check cho mục gốc
            Next
            AddHandler tv_BitLe.AfterCheck, AddressOf Tv_BitLe_AfterCheck ' Kích hoạt lại sự kiện AfterCheck
        Catch
        End Try
    End Sub
    Private Sub ResetDataString()
        Try
            For i As Integer = 0 To dataString.Length - 1
                dataString(i) = "0"c
            Next
        Catch
        End Try
    End Sub
    Private Sub tv_BitLe_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles tv_BitLe.BeforeSelect
        Try
            e.Cancel = True
        Catch
        End Try

    End Sub
    Private Sub CB_ThemBitTong_Click(sender As Object, e As EventArgs) Handles CB_ThemBitTong.Click
        Try
            If CB_DKSabanso.Checked = False Then
                CB_DKSabanso.Checked = True
            End If
            CB_DoiTenBit.Checked = False
        Catch
        End Try
    End Sub
    Private Sub CB_DoiTenBit_Click(sender As Object, e As EventArgs) Handles CB_DoiTenBit.Click
        Try
            If CB_DKSabanso.Checked = False Then
                CB_DKSabanso.Checked = True
            End If
            tb_DoiTen.Text = ""
            pnl_DoiTen.Visible = True
            CB_ThemBitTong.Checked = False
            tb_DoiTen.Focus()
        Catch
        End Try
    End Sub
    Private Sub btn_Trang2_Click(sender As Object, e As EventArgs) Handles btn_Trang2.Click
        Try
            If ThemNut >= 40 Then
                For i As Integer = 1 To 40
                    Dim buttonName As String = "Button" & i.ToString()
                    Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                    button.Visible = False
                Next
                For i As Integer = 1 To ThemNut - 40
                    Dim buttonName As String = "Button" & i.ToString()
                    Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                    button.Visible = True
                Next
                Dim fileName As String = "BitTong.txt"
                Dim filePath As String = Path.Combine(folderPath, fileName)
                Dim lines1 As String() = File.ReadAllLines(filePath)
                btn_Trang2.BackColor = Color.FromArgb(0, 117, 214)
                btn_Trang2.ForeColor = Color.White
                btn_Trang1.BackColor = Color.White
                btn_Trang1.ForeColor = Color.Black

                For i As Integer = 41 To 80
                    Dim lineToModify As String = lines1(i - 1)
                    Dim parts As String() = lineToModify.Split(","c)
                    Dim part4 As String = parts(3).Trim()

                    Dim buttonName As String = "Button" & (i - 40).ToString()
                    Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()

                    If button IsNot Nothing Then
                        If part4 = 0 Then
                            button.BackColor = Color.White
                            button.ForeColor = Color.Black
                        End If
                        If part4 = 1 Then
                            button.BackColor = Color.Blue
                            button.ForeColor = Color.White
                        End If
                        If part4 = 2 Then
                            button.BackColor = Color.Red
                            button.ForeColor = Color.White
                        End If
                    End If
                Next
                Try
                    If File.Exists(filePath) Then
                        Dim lines As String() = File.ReadAllLines(filePath)
                        Dim lineIndex As Integer = 0
                        Dim startLineIndex As Integer = 41 ' Định nghĩa dòng bắt đầu đọc (dòng 40)
                        For Each line As String In lines
                            lineIndex += 1
                            If lineIndex >= startLineIndex Then ' Bỏ qua các dòng trước dòng bắt đầu
                                Dim trimmedLine As String = line.Trim()
                                If Not String.IsNullOrEmpty(trimmedLine) Then
                                    Dim commaIndex As Integer = trimmedLine.IndexOf(",")
                                    If commaIndex >= 0 AndAlso commaIndex < trimmedLine.Length - 1 Then
                                        Dim nodeText As String = trimmedLine.Substring(commaIndex + 1)
                                        Dim firstPart As String = trimmedLine.Substring(0, commaIndex)
                                        Dim secondPart As String = trimmedLine.Substring(commaIndex + 1)
                                        Dim buttonName As String = "Button" & (lineIndex - startLineIndex + 1).ToString()
                                        Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                                        If button IsNot Nothing Then
                                            button.Text = secondPart.Substring(0, secondPart.IndexOf(","))
                                        End If
                                    End If
                                End If
                            End If
                        Next
                    Else
                        MessageBox.Show("Tệp BitTong.txt không tồn tại.")
                    End If
                Catch ex As Exception

                End Try
            End If
        Catch
        End Try
    End Sub
    Private Sub btn_Trang1_Click(sender As Object, e As EventArgs) Handles btn_Trang1.Click
        Try
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines1 As String() = File.ReadAllLines(filePath)
            btn_Trang1.BackColor = Color.FromArgb(0, 117, 214)
            btn_Trang1.ForeColor = Color.White
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
            If ThemNut <= 40 Then
                For i As Integer = 1 To ThemNut
                    Dim lineToModify As String = lines1(i - 1)
                    Dim parts As String() = lineToModify.Split(","c)
                    Dim part4 As String = parts(3).Trim()

                    Dim buttonName As String = "Button" & i.ToString()
                    Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                    button.Visible = True
                    If button IsNot Nothing Then
                        If part4 = 0 Then
                            button.BackColor = Color.White
                            button.ForeColor = Color.Black
                        End If
                        If part4 = 1 Then
                            button.BackColor = Color.Blue
                            button.ForeColor = Color.White
                        End If
                        If part4 = 2 Then
                            button.BackColor = Color.Red
                            button.ForeColor = Color.White
                        End If
                    End If
                Next
            End If
            If ThemNut > 40 Then
                For i As Integer = 1 To 40
                    Dim lineToModify As String = lines1(i - 1)
                    Dim parts As String() = lineToModify.Split(","c)
                    Dim part4 As String = parts(3).Trim()

                    Dim buttonName As String = "Button" & i.ToString()
                    Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                    button.Visible = True
                    If button IsNot Nothing Then
                        If part4 = 0 Then
                            button.BackColor = Color.White
                            button.ForeColor = Color.Black
                        End If
                        If part4 = 1 Then
                            button.BackColor = Color.Blue
                            button.ForeColor = Color.White
                        End If
                        If part4 = 2 Then
                            button.BackColor = Color.Red
                            button.ForeColor = Color.White
                        End If
                    End If
                Next
            End If
            Try
                If File.Exists(filePath) Then
                    Dim lines As String() = File.ReadAllLines(filePath)
                    Dim lineIndex As Integer = 0
                    Dim startLineIndex As Integer = 1 ' Định nghĩa dòng bắt đầu đọc (dòng 40)
                    For Each line As String In lines
                        lineIndex += 1
                        If lineIndex >= startLineIndex Then ' Bỏ qua các dòng trước dòng bắt đầu
                            Dim trimmedLine As String = line.Trim()
                            If Not String.IsNullOrEmpty(trimmedLine) Then
                                Dim commaIndex As Integer = trimmedLine.IndexOf(",")
                                If commaIndex >= 0 AndAlso commaIndex < trimmedLine.Length - 1 Then
                                    Dim nodeText As String = trimmedLine.Substring(commaIndex + 1)
                                    Dim firstPart As String = trimmedLine.Substring(0, commaIndex)
                                    Dim secondPart As String = trimmedLine.Substring(commaIndex + 1)
                                    Dim buttonName As String = "Button" & (lineIndex - startLineIndex + 1).ToString()
                                    Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        button.Text = secondPart.Substring(0, secondPart.IndexOf(","))
                                    End If
                                End If
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("Tệp BitTong.txt không tồn tại.")
                End If
            Catch
            End Try
        Catch
        End Try
    End Sub
    Private Sub btn_ThemNut_Click(sender As Object, e As EventArgs) Handles btn_ThemNut.Click
        Try
            Dim fileName As String = "LuuBit.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If 0 <= ThemNut AndAlso ThemNut <= 79 Then
                ThemNut += 1
                File.WriteAllText(filePath, ThemNut)
            End If

            If ThemNut <= 40 Then
                Dim TenNut As String = "Button" + ThemNut.ToString()
                Dim button As Button = Me.Controls.Find(TenNut, True).FirstOrDefault()
                btn_Trang2.Visible = False
                btn_ThemNut.Location = New Point(344, 32)
                btn_XoaNut.Location = New Point(368, 32)

                If button IsNot Nothing Then
                    button.Visible = True
                End If
            End If

            If ThemNut > 40 Then
                Dim TenNut As String = "Button" + (ThemNut - 40).ToString()
                Dim button As Button = Me.Controls.Find(TenNut, True).FirstOrDefault()
                If button IsNot Nothing Then
                    button.Visible = True
                End If
                btn_Trang2.Visible = True
                btn_ThemNut.Location = New Point(422, 32)
                btn_XoaNut.Location = New Point(446, 32)
            End If
        Catch
        End Try
    End Sub
    Private Sub btn_XoaNut_Click(sender As Object, e As EventArgs) Handles btn_XoaNut.Click
        Try
            Dim fileName As String = "LuuBit.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines1 As String() = File.ReadAllLines(filePath)
            If ThemNut >= 1 AndAlso ThemNut <= 80 Then
                If ThemNut > 40 Then
                    Dim TenNut As String = "Button" + (ThemNut - 40).ToString()
                    Dim button As Button = Me.Controls.Find(TenNut, True).FirstOrDefault()
                    If button IsNot Nothing Then
                        If btn_Trang2.ForeColor = Color.White Then
                            button.Visible = False
                        End If
                    End If
                    btn_Trang2.Visible = True
                    btn_ThemNut.Location = New Point(422, 32)
                    btn_XoaNut.Location = New Point(446, 32)
                End If
                If ThemNut <= 40 Then
                    btn_Trang2.Visible = False
                    btn_ThemNut.Location = New Point(344, 32)
                    btn_XoaNut.Location = New Point(368, 32)
                    Dim TenNut As String = "Button" + ThemNut.ToString()
                    Dim button As Button = Me.Controls.Find(TenNut, True).FirstOrDefault()
                    If button IsNot Nothing Then
                        button.Visible = False
                    End If
                End If
                ThemNut -= 1
                File.WriteAllText(filePath, ThemNut)
            End If
        Catch
        End Try
    End Sub
    Private Sub SBVL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SBVL.SelectedIndexChanged
        Try
            Select Case SBVL.SelectedTab.TabIndex
                Case 0
                    Me.Size = New Size(253, 245)
                    SBVL.Size = New Size(253, 245)
                    btn_Exit.Location = New Point(230, 1)
                Case 1
                    Me.Size = New Size(966, 654)
                    SBVL.Size = New Size(966, 654)
                    btn_Exit.Location = New Point(941, 1)
                Case 2
                    Me.Size = New Size(332, 275)
                    SBVL.Size = New Size(332, 275)
                    btn_Exit.Location = New Point(310, 1)
                Case 3
                    Me.Size = New Size(332, 374)
                    SBVL.Size = New Size(332, 374)
                    btn_Exit.Location = New Point(310, 1)
                Case 4
                    Me.Size = New Size(637, 479)
                    SBVL.Size = New Size(637, 479)
                    btn_Exit.Location = New Point(610, 1)
            End Select
        Catch
        End Try
    End Sub
    Private Sub BtnQuetDT_Click_1(sender As Object, e As EventArgs) Handles BtnQuetDT.Click
        Try
            File.Delete(PathData & "\BitLe.txt")
            Using writer As New StreamWriter(Path.Combine(PathData, "Doituong.txt"), False)
                writer.Write(String.Empty)
            End Using
            FrmMain.ScanGroup()
            DB_BitLe()
            RDoiTuong()
            TreeviewBit()
        Catch
        End Try
    End Sub
    Private Sub btn_BacNam_Click(sender As Object, e As EventArgs) Handles btn_BacNam.Click
        FrmMain.HuongBac()
    End Sub
#End Region
#Region "Cơ Sở Dữ Liệu"
    Private Sub DB_BitLe()
        Try
            Dim fileName As String = "BitLe.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If Not File.Exists(filePath) Then
                For i As Integer = 1 To 192
                    Dim name As String = i.ToString() + "," + "Bit " + i.ToString()
                    Dim line As String = $"{name}"
                    File.AppendAllText(filePath, line & Environment.NewLine)
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub DB_BitTong()
        Try
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If Not File.Exists(filePath) Then
                For i As Integer = 1 To 80
                    Dim Bit As String = String.Concat(Enumerable.Repeat("0", 320))
                    Dim name As String = i.ToString() + ",Bit Tổng," + Bit + ",0"
                    Dim line As String = $"{name}"
                    File.AppendAllText(filePath, line & Environment.NewLine)
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub DB_Cocodong()
        Try
            Dim fileName As String = "DataCDD.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If Not File.Exists(filePath) Then
                For i As Integer = 1 To 5
                    Dim name As String = "Trống " + i.ToString()
                    Dim line As String = $"{name}_{0}_{0}"
                    File.AppendAllText(filePath, line & Environment.NewLine)
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub DB_LuuBit()
        Try
            Dim fileName As String = "LuuBit.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If Not File.Exists(filePath) Then
                Dim name As String = 0
                File.AppendAllText(filePath, name)
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Treeview"
    Private Sub TreeviewBit()
        Try
            tv_BitLe.Nodes.Clear()
            tv_BitLe.SelectedNode = Nothing
            tv_BitLe.CheckBoxes = True
            Dim fileName As String = "BitLe.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If File.Exists(filePath) Then
                Dim lines As String() = File.ReadAllLines(filePath)
                For Each line As String In lines
                    Dim trimmedLine As String = line.Trim()
                    If Not String.IsNullOrEmpty(trimmedLine) Then
                        Dim commaIndex As Integer = trimmedLine.IndexOf(",")
                        If commaIndex >= 0 AndAlso commaIndex < trimmedLine.Length - 1 Then
                            Dim nodeText As String = trimmedLine.Substring(commaIndex + 1)
                            Dim rootNode As TreeNode = New TreeNode(nodeText)
                            tv_BitLe.Nodes.Add(rootNode)
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Tệp BitLe.txt không tồn tại.")
            End If
        Catch
        End Try
    End Sub
    Private Sub Tv_BitLe_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tv_BitLe.AfterCheck
        Try
            Dim nodeIndex As Integer = e.Node.Index
            Dim indexString As String = nodeIndex.ToString()
            Dim TenNut As String = e.Node.Text
            Dim FullTen As String = TenNut + "_" + (nodeIndex + 1).ToString()
            If e.Node.Checked Then
                If CB_ThemBitTong.Checked = True Then
                    If Not LuuBitLe.Contains(indexString) Then
                        LuuBitLe.Add(indexString)
                    End If
                Else
                    If CB_DKSabanso.Checked = False Then
                        LayDoiTuong(FullTen, 1)
                    End If
                    Dim data As String = "A" + (nodeIndex).ToString()
                    TRData(data)
                End If
            Else
                If CB_ThemBitTong.Checked = True Then
                    If LuuBitLe.Contains(indexString) Then
                        LuuBitLe.Remove(indexString)
                    End If
                Else
                    If CB_DKSabanso.Checked = False Then
                        LayDoiTuong(FullTen, 0)
                    End If
                    Dim data As String = "T" + (nodeIndex).ToString()
                    TRData(data)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub Tv_BitLe_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs)
        Try
            Dim selectedNode As TreeNode = e.Node
            Dim newName As String = InputBox("Nhập tên mới:", "Đổi tên", selectedNode.Text)
            If Not String.IsNullOrEmpty(newName) Then
                Try
                    selectedNode.Text = newName
                    Dim nodeIndex As Integer = selectedNode.Index
                    Dim fileName As String = "BitLe.txt"
                    Dim filePath As String = Path.Combine(folderPath, fileName)
                    If File.Exists(filePath) Then
                        Dim lines As String() = File.ReadAllLines(filePath)
                        If nodeIndex >= 0 AndAlso nodeIndex < lines.Length Then
                            Dim trimmedLine As String = lines(nodeIndex).Trim()
                            Dim commaIndex As Integer = trimmedLine.IndexOf(",")
                            If commaIndex >= 0 AndAlso commaIndex < trimmedLine.Length - 1 Then
                                Dim existingNodeText As String = trimmedLine.Substring(commaIndex + 1)
                                Dim newLine As String = lines(nodeIndex).Substring(0, commaIndex + 1) & newName
                                lines(nodeIndex) = newLine
                            End If
                        End If
                        File.WriteAllLines(filePath, lines)
                    Else
                        MessageBox.Show("Tệp BitLe.txt không tồn tại.")
                    End If
                Catch
                End Try
            End If
        Catch
        End Try
    End Sub
    Private Sub LayDoiTuong(FullTen, check)
        Try
            Dim fileName As String = "Doituong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If File.Exists(filePath) Then
                Dim lines As String() = File.ReadAllLines(filePath)
                For Each line As String In lines
                    Dim trimmedLine As String = line.Trim()
                    Dim lastIndex As Integer = trimmedLine.LastIndexOf("\")
                    Dim result As String = trimmedLine.Substring(lastIndex + 1)
                    If FullTen = result Then
                        Lenhve = "NNtructiep3"
                        If check = 1 Then
                            If FrmMain.txtNnTrt.Text = "" Then
                                FrmMain.txtNnTrt.Text = trimmedLine
                            Else
                                FrmMain.txtNnTrt.Text = FrmMain.txtNnTrt.Text & "," & trimmedLine
                            End If
                        ElseIf check = 0 Then
                            Dim Ten As String = FrmMain.txtNnTrt.Text.Replace(trimmedLine, String.Empty).Replace(",,", ",")
                            Dim BoPhay As String = Ten.Trim(",").TrimEnd(",")
                            FrmMain.txtNnTrt.Text = ""
                            FrmMain.txtNnTrt.Text = BoPhay


                            FrmMain.sgworldMain.ProjectTree.SetVisibility(FrmMain.sgworldMain.ProjectTree.FindItem(trimmedLine), True)
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Tệp Doituong.txt không tồn tại.")
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Truyền Arduino"
    Private Sub TRData(data As String)
        Try
            If serialPort Is Nothing OrElse Not serialPort.IsOpen Then
                Return
            End If
            serialPort.WriteLine(data)
            Thread.Sleep(50)
        Catch
        End Try
    End Sub
    Private Sub btn_LamMoi_Click(sender As Object, e As EventArgs) Handles btn_LamMoi.Click
        Try
            If btn_KetNoi.BackColor = Color.Red Then
                serialPort.Close() ' Đóng cổng COM
            End If
            btn_KetNoi.BackColor = Color.Green ' Đặt màu nền lại thành màu mặc định hoặc một màu khác
            btn_KetNoi.ForeColor = Color.White
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
#End Region
#Region "Load Name BitTong"
    Private Sub LoadBitTong()
        Try
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            If File.Exists(filePath) Then
                Dim lines As String() = File.ReadAllLines(filePath)
                Dim lineIndex As Integer = 0
                Dim startLineIndex As Integer = 1 ' Định nghĩa dòng bắt đầu đọc (dòng 40)
                For Each line As String In lines
                    lineIndex += 1
                    If lineIndex >= startLineIndex Then ' Bỏ qua các dòng trước dòng bắt đầu
                        Dim trimmedLine As String = line.Trim()
                        If Not String.IsNullOrEmpty(trimmedLine) Then
                            Dim commaIndex As Integer = trimmedLine.IndexOf(",")
                            If commaIndex >= 0 AndAlso commaIndex < trimmedLine.Length - 1 Then
                                Dim nodeText As String = trimmedLine.Substring(commaIndex + 1)
                                Dim firstPart As String = trimmedLine.Substring(0, commaIndex)
                                Dim secondPart As String = trimmedLine.Substring(commaIndex + 1)
                                Dim buttonName As String = "Button" & (lineIndex - startLineIndex + 1).ToString()
                                Dim button As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()
                                If button IsNot Nothing Then
                                    button.Text = secondPart.Substring(0, secondPart.IndexOf(","))
                                End If
                            End If
                        End If
                    End If
                Next
            Else
                MessageBox.Show("Tệp BitTong.txt không tồn tại.")
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Cờ cơ động"
    Private Sub btn_co1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_co1.MouseDown, btn_co5.MouseDown, btn_co4.MouseDown, btn_co3.MouseDown, btn_co2.MouseDown
        Try
            Dim button As Button = TryCast(sender, Button)
            Dim dataNumber As Integer = Convert.ToInt16(button.Name.Substring(6))
            If txtTenKH.Text = "" Then
                TrangThaiNut(button, e, dataNumber)
                If cb_NhapNhayCo.Checked = True Then
                    If button.BackColor = Color.Blue Then
                        TRData("C" + dataNumber.ToString() + "_2b")
                        DieuKhienCo.Text = button.Text
                    ElseIf button.BackColor = Color.Red Then
                        TRData("C" + dataNumber.ToString() + "_2r")
                        DieuKhienCo.Text = button.Text
                    ElseIf button.BackColor = Color.White Then
                        TRData("C" + dataNumber.ToString() + "_0")
                        DieuKhienCo.Text = ""
                    End If
                Else
                    If button.BackColor = Color.Blue Then
                        TRData("C" + dataNumber.ToString() + "_1b")
                    ElseIf button.BackColor = Color.Red Then
                        TRData("C" + dataNumber.ToString() + "_1r")
                    ElseIf button.BackColor = Color.White Then
                        TRData("C" + dataNumber.ToString() + "_0")
                    End If
                End If
            Else
                add_CCD(button, e, dataNumber)
            End If
        Catch
        End Try
    End Sub
    Private Sub LoadCCD()
        Try
            Dim fileName As String = "DataCDD.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines As String() = File.ReadAllLines(filePath)
            For i As Integer = 1 To 5
                Dim lineToModify As String = lines(i - 1)
                Dim parts As String() = lineToModify.Split("_"c)
                Dim part1 As String = parts(0).Trim()
                Dim TenCCD As String = "btn_co" + i.ToString()
                Dim button As Button = Me.Controls.Find(TenCCD, True).FirstOrDefault()
                If button IsNot Nothing Then
                    button.Text = part1
                End If
            Next
        Catch
        End Try
    End Sub
    Private Sub add_CCD(button As Button, e As MouseEventArgs, dataNumber As Integer)
        Try
            Dim fileName As String = "DataCDD.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines As String() = File.ReadAllLines(filePath)
            Dim lineToModify As String = lines(dataNumber - 1)
            Dim parts As String() = lineToModify.Split("_"c)
            Dim part1 As String = parts(1).Trim()
            Dim part2 As String = parts(2).Trim()
            Dim TenDT As String = txtTenKH.Text
            Dim modifiedLine As String = $"{TenDT}_{part1}_{part2}"
            lines(dataNumber - 1) = modifiedLine
            File.WriteAllLines(filePath, lines)
            txtTenKH.Text = ""
            LoadCCD()
        Catch
        End Try
    End Sub
    Private Sub btn_ResetCo_Click(sender As Object, e As EventArgs)
        Try
            TRData("Clear")
        Catch
        End Try
    End Sub
#End Region
#Region "Nhận dữ liệu arduino"
    Private Sub NhanData(data As String)
        Try
            Dim DataSerial As String = data.Trim()
            If DataSerial.EndsWith("_on") Then
                Dim path1 = "C:/saban/tuongtacXY/cocodong.txt"
                Dim numberCCD As String = DataSerial.Substring(1, 1)
                colast = DataSerial.Substring(1, 1)
                Dim text1 As String = "bat_C" + numberCCD
                File.WriteAllText(path1, text1)
            End If
            If DataSerial.EndsWith("QC") Then
                Dim path1 = "C:/saban/tuongtacXY/quechi.txt"
                Dim text1 As String = "bat_QC"
                File.WriteAllText(path1, text1)
            End If
            If DataSerial.EndsWith("RM") Then
                Dim path1 As String = "C:/saban/tuongtacXY/remoteLaze.txt"
                Dim content As String = File.ReadAllText(path1)
                If content.Contains("tat") Then
                    content = content.Replace("tat", "bat")
                    File.WriteAllText(path1, content)
                End If
            End If
            If DataSerial.EndsWith("tatRM") Then
                Dim path1 As String = "C:/saban/tuongtacXY/remoteLaze.txt"
                Dim content As String = File.ReadAllText(path1)
                If content.Contains("bat") Then
                    content = content.Replace("bat", "tat")
                    File.WriteAllText(path1, content)
                End If
            End If
            If DataSerial.EndsWith("ADOWN") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCxx -= 30
                End If
                If DoCao < 50000 Then
                    LCxx -= 100
                End If
                If DoCao < 75000 Then
                    LCxx -= 150
                Else
                    LCxx -= 200
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("AUP") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCxx += 30
                End If
                If DoCao < 50000 Then
                    LCxx += 100
                End If
                If DoCao < 75000 Then
                    LCxx += 150
                Else
                    LCxx += 200
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("AL") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCyy -= 30
                End If
                If DoCao < 50000 Then
                    LCyy -= 100
                End If
                If DoCao < 75000 Then
                    LCyy -= 150
                Else
                    LCyy -= 200
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("AR") Then
                Thread.Sleep(50)
                If DoCao < 25000 Then
                    LCyy += 30
                End If
                If DoCao < 50000 Then
                    LCyy += 100
                End If
                If DoCao < 75000 Then
                    LCyy += 150
                Else
                    LCyy += 200
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("Z-") Then
                Thread.Sleep(50)
                If DoCao < 5000 Then
                    DoCao += 5000
                Else
                    DoCao += 10000
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("Z+") Then
                Thread.Sleep(50)
                If DoCao < 1000 Then
                    DoCao -= 0
                Else
                    DoCao -= 5000
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("N+") Then
                If Roat <= 80 Then
                    Roat += 10
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("N-") Then
                If Roat > 10 Then
                    Roat -= 10
                End If
                Dim txt1 As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt1
            End If
            If DataSerial.EndsWith("KB+") Then
                tb_TrinhChieuSBVL.Text = "KB+"
            End If
            If DataSerial.EndsWith("KB-") Then
                tb_TrinhChieuSBVL.Text = "KB-"
            End If
            If DataSerial.StartsWith("TP") Then
                Dim startIndex As Integer = DataSerial.IndexOf("TP") + 2
                Dim result As String = DataSerial.Substring(startIndex)
                Dim TenCCD As String = "btn_co" + result
                Dim button As Button = Me.Controls.Find(TenCCD, True).FirstOrDefault()
                If button IsNot Nothing Then
                    button.ForeColor = Color.Red
                End If
            End If
            If DataSerial.StartsWith("5") Then
                tb_BN.Text = "5"
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Đọc TXT"
    Private Sub RDataPythonToC(sender As Object, e As FileSystemEventArgs)
        Try
            Dim fileContent As String = File.ReadAllText(LinkDTPTC)
            Dim values As String() = fileContent.Split(","c) ' Tách chuỗi dữ liệu thành hai phần dựa vào dấu phẩy
            If values.Length = 2 Then 'Kiểm tra xem chuỗi dữ liệu được tách thành hai phần hay không             
                LCxx = Integer.Parse(values(0))
                LCyy = Integer.Parse(values(1))
                Dim txt As String = LCxx.ToString() + "," + LCyy.ToString() + "," + "-" + Roat.ToString() + "," + DoCao.ToString()
                tb_test.Text = txt
                'Dim path1 = "C:/saban/tuongtacXY/remoteLaze.txt"
                'File.ReadAllText(path1)
                'Dim text1 As String = "tat"
                'File.WriteAllText(path1, text1)
            Else
                Console.WriteLine("Không thể tách chuỗi dữ liệu thành hai phần.")
            End If
        Catch
        End Try
    End Sub
    Private Sub RCCD(sender As Object, e As FileSystemEventArgs)
        Try
            Dim filePath As String = Path.Combine(folderPath, LinkCCD)
            Dim lines As String = File.ReadAllText(filePath)
            Dim values As String() = lines.Split("_"c)
            Dim TT As String = values(0).Trim()
            Dim IDCo As String = values(1).Trim()
            If TT = "tat" Then
                TRData(IDCo + "_3")
            End If
        Catch
        End Try
    End Sub
    Private Sub RDataCCD(sender As Object, e As FileSystemEventArgs)
        'Try

        '    Dim fileName As String = "DataCDD.txt"
        '    Dim filePath As String = Path.Combine(folderPath, fileName)
        '    Dim lines As String() = File.ReadAllLines(filePath)
        '    Dim part1 As String
        '    Dim part2 As String
        '    Dim part3 As String
        '    Dim part4 As String
        '    Dim modifiedLine As String
        '    Dim fileContent As String = File.ReadAllText(LinkToaDoCCD)
        '    Dim values As String() = fileContent.Split("_"c) ' Tách chuỗi dữ liệu thành hai phần dựa vào dấu gạch dưới
        '    If values.Length = 2 Then ' Kiểm tra xem chuỗi dữ liệu được tách thành hai phần hay không
        '        part1 = values(0).Substring(1) ' Cắt bỏ một chữ đầu của part1
        '        part2 = values(1)
        '        Dim values1 As String() = part2.Split(","c) ' Tách phần thứ hai thành hai phần dựa vào dấu phẩy
        '        If values1.Length = 2 Then ' Kiểm tra xem phần thứ hai có được tách thành hai phần hay không
        '            part3 = values1(0)
        '            part4 = values1(1)
        '            Dim lineToModify As String = lines(part1 - 1)
        '            Dim Doc As String() = lineToModify.Split("_"c)
        '            Dim So1 As String = Doc(0).Trim()
        '            Dim So2 As String = Doc(1).Trim()
        '            Dim So3 As String = Doc(2).Trim()
        '            modifiedLine = $"{So1}_{part3}_{part4}"
        '            TxtDTmoi.Text = modifiedLine
        '        Else
        '            Console.WriteLine("Không thể tách phần thứ hai thành hai phần.")
        '        End If
        '    Else
        '        Console.WriteLine("Không thể tách chuỗi dữ liệu thành hai phần.")
        '    End If
        'Catch
        'End Try
    End Sub
    Private Sub RDoiTuong()
        Try
            Dim fileName As String = "Doituong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim fileName1 As String = "BitLe.txt"
            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
            If File.Exists(filePath) Then
                Dim lines As String() = File.ReadAllLines(filePath, Encoding.UTF8)
                Dim lines1 As String() = File.ReadAllLines(filePath1)
                For Each line As String In lines
                    Dim trimmedLine As String = line.Trim()
                    Dim lastIndex As Integer = trimmedLine.LastIndexOf("\")
                    If lastIndex >= 0 AndAlso lastIndex < trimmedLine.Length - 1 Then
                        Dim result As String = trimmedLine.Substring(lastIndex + 1)
                        Dim parts As String() = result.Split("_"c)
                        Thread.Sleep(20)
                        If parts.Length >= 2 Then
                            Dim part1 As String = parts(0)
                            Dim part2 As Integer = parts(1)
                            Dim lineToModify As String = lines1(part2 - 1)
                            Dim DanhSach As String() = lineToModify.Split(","c)
                            Dim Stt As String = DanhSach(0).Trim()
                            Dim modifiedLine As String = $"{Stt},{part1}"
                            lines1(part2 - 1) = modifiedLine
                            File.WriteAllLines(filePath1, lines1)
                        End If
                    End If
                Next

            Else
                MessageBox.Show("Tệp Doituong.txt không tồn tại.")
            End If
        Catch
        End Try
    End Sub
    Private Sub Load_Bit()
        Try
            Dim fileName As String = "LuuBit.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines As String = File.ReadAllText(filePath)
            ThemNut = lines
            For i As Integer = 0 To lines
                If i > 0 Then
                    Dim TenNut As String = "Button" + i.ToString()
                    Dim button As Button = Me.Controls.Find(TenNut, True).FirstOrDefault()
                    If button IsNot Nothing Then
                        button.Visible = True
                    End If
                End If
            Next
        Catch
        End Try
    End Sub
#End Region
#Region "Theo dõi TextBox"
    Private Sub TxtTrinhchieu_TextChanged(sender As Object, e As EventArgs) Handles TxtTrinhchieu.TextChanged
        Try
            TRData("Off")
            Thread.Sleep(200)
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
    Private Sub tb_test_TextChanged(sender As Object, e As EventArgs) Handles tb_test.TextChanged
        Try
            If tb_test.InvokeRequired Then
                tb_test.Invoke(Sub() FrmMain.TxtFly.Text = tb_test.Text)
            Else
                FrmMain.TxtFly.Text = tb_test.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub DieuKhienCo_TextChanged(sender As Object, e As EventArgs) Handles DieuKhienCo.TextChanged
        Try
            If DieuKhienCo.InvokeRequired Then
                DieuKhienCo.Invoke(Sub() FrmMain.DieuKhienCo.Text = DieuKhienCo.Text)
            Else
                FrmMain.DieuKhienCo.Text = DieuKhienCo.Text
            End If
        Catch
        End Try
    End Sub
    Private Sub tb_BN_TextChanged(sender As Object, e As EventArgs) Handles tb_BN.TextChanged
        Try
            If tb_BN.InvokeRequired Then
                tb_BN.Invoke(Sub() FrmMain.tb_BN.Text = tb_BN.Text)
            Else
                FrmMain.tb_BN.Text = tb_BN.Text
            End If
            tb_BN.Text = ""
        Catch
        End Try
    End Sub

#End Region
#Region "Chia Màn Hình"
    Private Sub SCreenDkSBVL()
        Try
            Me.TopMost = True
            Me.StartPosition = FormStartPosition.CenterScreen
        Catch
        End Try
        'If (myScreens.Length = 1) Then
        '    Me.Top = My.Computer.Screen.WorkingArea.Height - Me.Height
        '    Me.Left = My.Computer.Screen.WorkingArea.Width - Me.Height
        'ElseIf (myScreens.Length = 2) Then
        '    Me.Top = Screen.AllScreens(1).Bounds.Top
        '    Me.Left = Screen.AllScreens(1).Bounds.Left
        'End If
    End Sub
    Private Sub BtnQuetDT_Click(sender As Object, e As EventArgs)
        Try
            FrmMain.ScanGroup()
        Catch
        End Try
    End Sub
    Private Sub FrmSBVL_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Try
            xpos1 = Control.MousePosition.X - Me.Location.X
            ypos1 = Control.MousePosition.Y - Me.Location.Y
        Catch
        End Try
    End Sub
    Private Sub FrmSBVL_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
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
    Public Sub KichBan()
        Try
            SBVL.SelectedTab = SBVL.TabPages(3)
        Catch
        End Try
    End Sub
#End Region
#Region "Resetbutton"
    Private Sub ResetButton()
        Try
            Dim fileName As String = "BitTong.txt"
            Dim filePath As String = Path.Combine(folderPath, fileName)
            Dim lines As String() = File.ReadAllLines(filePath)
            For i As Integer = 1 To 80
                Dim lineToModify As String = lines(i - 1)
                Dim parts As String() = lineToModify.Split(","c)
                Dim part1 As String = parts(0).Trim()
                Dim part2 As String = parts(1).Trim()
                Dim part3 As String = parts(2).Trim()
                Dim part4 As String = parts(3).Trim()
                Dim modifiedLine As String = $"{part1},{part2},{part3},{0}"
                lines(i - 1) = modifiedLine
                File.WriteAllLines(filePath, lines)
            Next
        Catch
        End Try
    End Sub
#End Region
#Region "Tạo Đối tượng Sabanso"
    Private Sub TxtDTmoi_TextChanged(sender As Object, e As EventArgs) Handles TxtDTmoi.TextChanged
        Try
            If TxtDTmoi.InvokeRequired Then
                TxtDTmoi.Invoke(Sub() FrmMain.tb_DTMSBVL.Text = TxtDTmoi.Text)
            Else
                FrmMain.tb_DTMSBVL.Text = TxtDTmoi.Text
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Kịch Bản"
    Private Sub LoadTextFilesToListBox(folderPath1 As String)
        Try
            If Directory.Exists(folderPath1) Then
                Dim files As String() = Directory.GetFiles(folderPath1, "*.txt")
                For Each file As String In files
                    Dim fileInfo As New FileInfo(file)
                    Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(fileInfo.Name)
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub btn_S_Click(sender As Object, e As EventArgs) Handles btn_S.Click
        Try
            FrmMain.btnTien.PerformClick()
        Catch
        End Try
    End Sub
    Private Sub btn_T_Click(sender As Object, e As EventArgs) Handles btn_T.Click
        Try
            FrmMain.btnLui.PerformClick()
        Catch
        End Try
    End Sub
    Private Sub btn_AddKB_Click(sender As Object, e As EventArgs) Handles btn_AddKB.Click
        FrmMain.TrinhchieuPN()
    End Sub
    Private Sub btn_ExitKB_Click(sender As Object, e As EventArgs) Handles btn_ExitKB.Click
        Try
            FrmMain.btnCloseTrC.PerformClick()
            tb_SKB.Text = 0
            tb_TKB.Text = "Name"
            TRData("Off")
            Thread.Sleep(50)
        Catch
        End Try
    End Sub


    Private Sub tb_TrinhChieuSBVL_TextChanged(sender As Object, e As EventArgs) Handles tb_TrinhChieuSBVL.TextChanged
        Try
            If tb_TrinhChieuSBVL.InvokeRequired Then
                tb_TrinhChieuSBVL.Invoke(Sub() FrmMain.tb_TrinhChieu.Text = tb_TrinhChieuSBVL.Text)
                tb_TrinhChieuSBVL.Text = ""
            Else
                FrmMain.tb_TrinhChieu.Text = tb_TrinhChieuSBVL.Text
                tb_TrinhChieuSBVL.Text = ""
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "phần trụ laser"
    ' tính toán góc quay cho trụ laser
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
    'event cho btn điều khiển laser
    Private Sub btn_Dieukhien(sender As Object, e As EventArgs) Handles btn_up.Click, btn_right.Click, btn_left.Click, btn_down.Click
        Try
            Dim button As Button = TryCast(sender, Button)
            Dim Namebtn As String = button.Name.Substring(4) ' lấy tên btn
            Dim numberGocTam As Integer = 0 '  biến tạm ép kiểu
            Dim numberGoc As Integer = 0
            ' thử chuyển đổi góc quay điều khiển
            If Integer.TryParse(tb_DoQuay.Text, numberGocTam) Then
                numberGoc = numberGocTam
            Else
                'mess Nội dung của TextBox không phải là số nguyên
                'MessageBox.Show("Nội dung của GÓC QUAY không phải là số nguyên")
                tb_DoQuay.Text = "5"
            End If

            If (Namebtn = "down") Then  'hướng lên giảm độ trục dọc tới 0 độ
                If (GDocNow - numberGoc) < 0 Then
                Else
                    GDocNow = GDocNow - numberGoc
                    lb_GDoc.Text = GDocNow.ToString()
                End If
            ElseIf (Namebtn = "up") Then ' hướng xuống tăng độ trục dọc tới 90 độ
                If (GDocNow + numberGoc) > 130 Then
                Else
                    GDocNow = GDocNow + numberGoc
                    lb_GDoc.Text = GDocNow.ToString()
                End If
            ElseIf (Namebtn = "right") Then ' quay sang trái giảm độ trục ngang tới 0 độ
                If (GNgangNow - numberGoc) < 0 Then
                Else
                    GNgangNow = GNgangNow - numberGoc
                    lb_GNgang.Text = GNgangNow.ToString()
                End If
            ElseIf (Namebtn = "left") Then ' quay sang phải tăng độ trục ngang tới 90 độ
                If (GNgangNow + numberGoc) > 160 Then
                Else
                    GNgangNow = GNgangNow + numberGoc
                    lb_GNgang.Text = GNgangNow.ToString()
                End If
            End If ' event bấm nút
            ' truyển xuống sa bàn mẫu 
            Dim GNgangInt As Integer
            Dim GDocInt As Integer

            If Integer.TryParse(GNgangNow.ToString(), GNgangInt) AndAlso Integer.TryParse(GDocNow.ToString(), GDocInt) Then
                Dim dataToSend As String = "g" + GNgangInt.ToString() + "_" + GDocInt.ToString()
                serialPort.Write(dataToSend)
            Else
                ' Lỗi chuyển đổi, không thể sử dụng GNgangInt và GDocInt
                'Console.WriteLine("Lỗi chuyển đổi thành kiểu Integer.")
            End If
        Catch
        End Try
    End Sub
    'event btn cho 4 nút xác nhận góc bù
    Private Sub btn_BuTru(sender As Object, e As EventArgs) Handles btn_0Doc.Click, btn_0Ngang.Click, btn_90Ngang.Click, btn_xaDoc.Click
        Try
            Dim button As Button = TryCast(sender, Button)
            Dim Namebtn As String = button.Name.Substring(4) ' lấy tên btn
            ' bù góc ngang
            If Namebtn = "0Ngang" Then
                G0doNgang = GNgangNow
                tb_0doNgang.Text = G0doNgang.ToString()
            ElseIf Namebtn = "90Ngang" Then
                G90doNgang = GNgangNow
                tb_90doNgang.Text = G90doNgang.ToString()

            ElseIf Namebtn = "0Doc" Then
                G0doDoc = GDocNow
                tb_0Doc.Text = G0doDoc.ToString()
            ElseIf Namebtn = "xaDoc" Then
                GocXaNhatDoc = GDocNow
                tb_XaNhatDoc.Text = GocXaNhatDoc.ToString()
            End If
        Catch
        End Try
    End Sub
    ' nhận được toạ độ từ sa bàn số
    Private Sub TxtLaser_TextChanged(sender As Object, e As EventArgs) Handles TxtLaser.TextChanged
        Try
            If CB_BatTruLaser.Checked = True Then
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
            End If
        Catch
        End Try
    End Sub
    ' load thông số quan trọng của sa bàn mẫu 
    Public Sub LoadThongSo(sender As Object, e As EventArgs)
        Try
            If Integer.TryParse(tb_CanhNgang.Text, CanhNgang) Then
            Else
                MessageBox.Show("Nội dung của CẠNH NGANG không phải là số nguyên")
                tb_CanhNgang.Text = "0"
            End If

            If Integer.TryParse(tb_CanhDoc.Text, CanhDoc) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_CanhDoc.Text = "0"
            End If

            If Integer.TryParse(tb_ChieuCao.Text, ChieuCao) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_ChieuCao.Text = "0"
            End If

            If Integer.TryParse(tb_0doNgang.Text, G0doNgang) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_0doNgang.Text = "0"
            End If

            If Integer.TryParse(tb_90doNgang.Text, G90doNgang) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_90doNgang.Text = "0"
            End If

            If Integer.TryParse(tb_0Doc.Text, G0doDoc) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_0Doc.Text = "0"
            End If

            If Integer.TryParse(tb_XaNhatDoc.Text, GocXaNhatDoc) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_XaNhatDoc.Text = "0"
            End If
        Catch
        End Try
    End Sub
    Private Sub Button82_Click(sender As Object, e As EventArgs) Handles Button82.Click
        Try
            If Integer.TryParse(tb_CanhNgang.Text, CanhNgang) Then
            Else
                MessageBox.Show("Nội dung của CẠNH NGANG không phải là số nguyên")
                tb_CanhNgang.Text = "0"
            End If

            If Integer.TryParse(tb_CanhDoc.Text, CanhDoc) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_CanhDoc.Text = "0"
            End If

            If Integer.TryParse(tb_ChieuCao.Text, ChieuCao) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_ChieuCao.Text = "0"
            End If

            If Integer.TryParse(tb_0doNgang.Text, G0doNgang) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_0doNgang.Text = "0"
            End If

            If Integer.TryParse(tb_90doNgang.Text, G90doNgang) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_90doNgang.Text = "0"
            End If

            If Integer.TryParse(tb_0Doc.Text, G0doDoc) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_0Doc.Text = "0"
            End If

            If Integer.TryParse(tb_XaNhatDoc.Text, GocXaNhatDoc) Then
            Else
                MessageBox.Show("Nội dung của CẠNH DỌC không phải là số nguyên")
                tb_XaNhatDoc.Text = "0"
            End If
        Catch
        End Try
    End Sub
    Private Sub trackBar1_Scroll(sender As Object, e As EventArgs) Handles trackBar1.Scroll
        Try
            Dim value As Integer = trackBar1.Value
            Using writer As StreamWriter = File.CreateText("C:/TIENPHAT/Sabanmau/dosang.txt")
                writer.Write(value.ToString())
            End Using

            Select Case value
                Case 0
                    TRData("DS_100")
                    FrmMain.todonhay = 11
                Case 1
                    TRData("DS_75")
                    FrmMain.todonhay = 13
                Case 2
                    TRData("DS_50")
                    FrmMain.todonhay = 15
                Case 3
                    TRData("DS_25")
                    FrmMain.todonhay = 17
                Case 4
                    TRData("DS_0")
            End Select
        Catch
        End Try
    End Sub
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Try
            Dim value As Integer = TrackBar2.Value
            Select Case value
                Case 0
                    FrmMain.todoco = 1000000
                Case 1
                    FrmMain.todoco = 10000
            End Select
        Catch
        End Try
    End Sub
    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        Try
            Dim value As Integer = TrackBar3.Value
            Select Case value
                Case 0
                    FrmMain.CheDoBay = 0
                Case 1
                    FrmMain.CheDoBay = 1
            End Select
        Catch
        End Try
    End Sub
#Region "Cài đặt mũi tên"
    Private Sub btn_XMT_Click(sender As Object, e As EventArgs) Handles btn_XMT.Click
        Try
            Dim Mau As String
            Dim Tong As String
            If btn_MauMT.BackColor = Color.Red Then
                Mau = "255,0,0"
            Else
                Mau = "0,255,0"
            End If
            If tb_SoBit.Text <> "" AndAlso tb_DDLed.Text <> "" AndAlso tb_slLed.Text <> "" AndAlso tb_Tocdo.Text <> "" Then
                If tb_SoBit.Text > 0 AndAlso tb_DDLed.Text > 0 AndAlso tb_slLed.Text > 0 AndAlso tb_Tocdo.Text > 0 Then
                    If tb_Tocdo.Text < 50 Then
                        tb_Tocdo.Text = 50
                        MessageBox.Show("Tốc độ led không được dưới 50")
                    ElseIf tb_Tocdo.Text > 1000 Then
                        tb_Tocdo.Text = 1000
                        MessageBox.Show("Tốc độ led không được quá 1000")
                    End If
                    Dim SoDuoiLed As Integer = Integer.Parse(tb_slLed.Text)
                    Tong = "color" & tb_SoBit.Text & "_" & Mau & "_" & tb_DDLed.Text & "_" & (SoDuoiLed - 1) & "_" & tb_Tocdo.Text
                    TRData(Tong)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub btn_MauMT_Click(sender As Object, e As EventArgs) Handles btn_MauMT.Click
        If btn_MauMT.BackColor = Color.Red Then
            btn_MauMT.BackColor = Color.Blue
        ElseIf btn_MauMT.BackColor = Color.Blue Then
            btn_MauMT.BackColor = Color.Red
        End If
    End Sub
    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub
#End Region
#End Region
End Class