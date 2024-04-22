Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Xml
Imports MicroStationDGN

Public Class BitDon
#Region "Biến Toàn Cục"
    Private folderPath As String
    Private folderPath1 As String
    Private BitDoiTen As String
    Private TenBitDon As String
    Private SoLanNhan As Integer = 0
    Dim Trang As String = 1
    Public ThemBitTong As String = 0

    Dim SoBitTong As String = 0
    Private Const waitTime As Integer = 200 ' Thời gian chờ (200ms)
    Public Event BitDonToSerial As EventHandler(Of String)
    Public Event BitDonToMain As EventHandler(Of String)
    Public Event BitDonKichBanToMain As EventHandler(Of String)
    Public Event KichBanCanhToMain As EventHandler(Of String)
    Public Event KichBanToMain1 As EventHandler(Of String)
    Private dataString As Char() = New Char(319) {}
    Private KiemTra As Boolean = False
    Private IDBit As String = 0
    Dim ThemCanh As String = 0
    Dim SuaCanh As String = 0
    Private TenKichBan As String
    Private TenKichBanCanh As String
    Private TenCanh As String
    Dim DanhSachTenBit1 As New List(Of String)()
    Dim KichBan As New KichBan()
    Dim DataValue As String
    Dim Bit_ID As String = 0
#End Region
#Region "Load"
    Private Sub BitDon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim folderName As String = "Data\HA"
            folderPath = Path.Combine(baseDirectory, folderName)
            Dim folderName1 As String = "Data"
            folderPath1 = Path.Combine(baseDirectory, folderName1)
            DB_TBitLe1()
            DB_TBitLe2()
            DB_TBitLe3()
            DB_TBitLe4()
            ResetDataString()
            LoadTrang(Trang)
            btn_Plus.Location = New Point(81, 99)
            btn_minus.Location = New Point(111, 99)

        Catch ex As Exception
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
#End Region
#Region "Nút Nhấn"
    Private Sub button1_MouseDown(sender As Object, e As MouseEventArgs) Handles button9.MouseDown, button80.MouseDown, button8.MouseDown, button79.MouseDown, button78.MouseDown, button77.MouseDown, button76.MouseDown, button75.MouseDown, button74.MouseDown, button73.MouseDown, button72.MouseDown, button71.MouseDown, button70.MouseDown, button7.MouseDown, button69.MouseDown, button68.MouseDown, button67.MouseDown, button66.MouseDown, button65.MouseDown, button64.MouseDown, button63.MouseDown, button62.MouseDown, button61.MouseDown, button60.MouseDown, button6.MouseDown, button59.MouseDown, button58.MouseDown, button57.MouseDown, button56.MouseDown, button55.MouseDown, button54.MouseDown, button53.MouseDown, button52.MouseDown, button51.MouseDown, button50.MouseDown, button5.MouseDown, button49.MouseDown, button48.MouseDown, button47.MouseDown, button46.MouseDown, button45.MouseDown, button44.MouseDown, button43.MouseDown, button42.MouseDown, button41.MouseDown, button40.MouseDown, button4.MouseDown, button39.MouseDown, button38.MouseDown, button37.MouseDown, button36.MouseDown, button35.MouseDown, button34.MouseDown, button33.MouseDown, button32.MouseDown, button31.MouseDown, button30.MouseDown, button3.MouseDown, button29.MouseDown, button28.MouseDown, button27.MouseDown, button26.MouseDown, button25.MouseDown, button24.MouseDown, button23.MouseDown, button22.MouseDown, button21.MouseDown, button20.MouseDown, button2.MouseDown, button19.MouseDown, button18.MouseDown, button17.MouseDown, button16.MouseDown, button15.MouseDown, button14.MouseDown, button13.MouseDown, button12.MouseDown, button11.MouseDown, button10.MouseDown, button1.MouseDown
        Try
            Dim button As Button = TryCast(sender, Button)
            Dim dataNumber As Integer = Convert.ToInt16(button.Name.Substring(6))
            If SoLanNhan <= 2 Then
                SoLanNhan += 1
                If SoLanNhan = 2 Then
                    KiemTra = True
                Else
                    KiemTra = False
                End If
            End If
            Task.Run(Sub() Chon(button, e))
        Catch ex As Exception
        End Try
    End Sub
    Private Async Sub Chon(button As Button, e As MouseEventArgs)
        Try
            Await Task.Delay(waitTime)
            Dim Status As Integer
            Dim dataNumber As Integer = Convert.ToInt16(button.Name.Substring(6))
            Dim SoBit As String
            Dim TenBit As String
            If SoLanNhan = 1 Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath, "ON.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Blue
                ElseIf button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                End If
            ElseIf SoLanNhan >= 2 And KiemTra = True Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath, "BLYNK.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Red
                ElseIf button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                End If
            End If
            SoLanNhan = 0
            If button.ForeColor = Color.White Then
                Status = 0
            ElseIf button.ForeColor = Color.Blue Then
                Status = 1
            ElseIf button.ForeColor = Color.Red Then
                Status = 2
            End If
            Dim numberPart As String = New String(button.Name.Where(Function(c) Char.IsDigit(c)).ToArray())
            Dim number As Integer
            If Integer.TryParse(numberPart, number) Then
                For i As Integer = 1 To 4
                    Dim TenTrang As String = "btn_Trang" + i.ToString()
                    Dim button1 As Button = Me.Controls.Find(TenTrang, True).FirstOrDefault()
                    Dim Ten As String = "label" & numberPart.ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                    Dim label As Label = Me.Controls.Find(Ten, True).FirstOrDefault()
                    Dim CatTen() As String = label.Text.Split(":"c)
                    If CatTen.Length >= 2 Then
                        TenBit = CatTen(1).Trim()
                    End If
                    If button1.BackColor = Color.FromArgb(0, 117, 227) Then
                        If i >= 1 AndAlso i <= 4 Then
                            SoBit = ((dataNumber + (i - 1) * 80) - 1).ToString()
                            If Status = 0 Then
                                RaiseEvent BitDonToSerial(Me, "T_" + SoBit)
                                dataString(SoBit) = "0"c
                                LuudataString(SoBit) = "0"c
                                luugiatri()
                                If DanhSachTenBit1.Contains(TenBit) Then
                                    DanhSachTenBit1.Remove(TenBit)
                                    If SuaCanh = 1 Then
                                        LuuGTKichBanTrang()
                                    End If
                                End If

                            ElseIf Status = 1 Then
                                RaiseEvent BitDonToSerial(Me, "A_" + SoBit)
                                dataString(SoBit) = "1"c
                                LuudataString(SoBit) = "1"c
                                luugiatri()
                                If Not DanhSachTenBit1.Contains(TenBit) Then
                                    DanhSachTenBit1.Add(TenBit)
                                    If SuaCanh = 1 Then
                                        LuuGTKichBanTrang()
                                    End If
                                End If
                            ElseIf Status = 2 Then
                                RaiseEvent BitDonToSerial(Me, "B_" + SoBit)
                                dataString(SoBit) = "2"c
                                LuudataString(SoBit) = "2"c
                                luugiatri()
                                If Not DanhSachTenBit1.Contains(TenBit) Then
                                    DanhSachTenBit1.Add(TenBit)
                                    If SuaCanh = 1 Then
                                        LuuGTKichBanTrang()
                                    End If
                                End If
                            End If
                        End If
                        Dim fileName As String = "TBitLe" + i.ToString() + ".xml"
                        Dim filePath As String = Path.Combine(folderPath1, fileName)
                        Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
                        xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitLeData/Bit[@ID='{number}']")
                        If bitNode IsNot Nothing Then
                            Dim nameNode As XmlNode = bitNode.SelectSingleNode("Status") ' Tìm phần tử <Name> trong <Bit>
                            If nameNode IsNot Nothing Then
                                nameNode.InnerText = Status ' Ghi giá trị mới vào phần tử <Name>
                                xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                            End If
                        End If
                    End If
                Next
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub luugiatri()
        Dim fileName1 As String = "TBitTong1.xml"
        Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
        Dim xmlDoc1 As New XmlDocument() ' Tạo đối tượng XmlDocument
        xmlDoc1.Load(filePath1) ' Load tệp XML từ đường dẫn
        Dim bitNode1 As XmlNode = xmlDoc1.SelectSingleNode($"/BitTongData/Bit[@ID='{Bit_ID}']/Data")
        If bitNode1 IsNot Nothing Then
            bitNode1.InnerText = dataString
            xmlDoc1.Save(filePath1)
        End If
    End Sub
    Private Sub tb_DoiTen_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_DoiTen.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If tb_DoiTen.Text <> "" Then
                    If tb_DoiTen.Text.Length < 22 Then
                        Dim TenBit As String = TenBitDon + ": " + tb_DoiTen.Text
                        Dim label As Label = Me.Controls.Find(BitDoiTen, True).FirstOrDefault()
                        Dim numberPart As String = New String(label.Name.Where(Function(c) Char.IsDigit(c)).ToArray())
                        Dim number As Integer
                        If Integer.TryParse(numberPart, number) Then
                            If label IsNot Nothing Then
                                For i As Integer = 1 To 4
                                    label.Text = TenBit
                                    Dim TenTrang As String = "btn_Trang" + i.ToString()
                                    Dim button As Button = Me.Controls.Find(TenTrang, True).FirstOrDefault()
                                    If button.BackColor = Color.FromArgb(0, 117, 227) Then
                                        Dim fileName As String = "TBitLe" + i.ToString() + ".xml"
                                        Dim filePath As String = Path.Combine(folderPath1, fileName)
                                        Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
                                        xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
                                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitLeData/Bit[@ID='{number}']")
                                        If bitNode IsNot Nothing Then
                                            Dim nameNode As XmlNode = bitNode.SelectSingleNode("Name") ' Tìm phần tử <Name> trong <Bit>
                                            If nameNode IsNot Nothing Then
                                                nameNode.InnerText = TenBit ' Ghi giá trị mới vào phần tử <Name>
                                                xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                                                label.Visible = True
                                                tb_DoiTen.Visible = False
                                                tb_DoiTen.Location = New Point(1305, -1)
                                            End If
                                        End If
                                    End If
                                Next
                            End If
                        End If
                    Else
                        MessageBox.Show("Tên đối tượng không được vượt quá 22", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tb_DoiTen.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Reset_Click(sender As Object, e As EventArgs) Handles btn_Reset.Click
        Try
            HamDoiTen()
            Dim XacNhan As DialogResult = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If XacNhan = DialogResult.Yes Then
                For i As Integer = 1 To 4
                    Dim fileName As String = "TBitLe" + i.ToString() + ".xml"
                    Dim filePath As String = Path.Combine(folderPath1, fileName)
                    Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
                    xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
                    For a As Integer = 1 To 80
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitLeData/Bit[@ID='{a}']")
                        If bitNode IsNot Nothing Then
                            Dim nameNode As XmlNode = bitNode.SelectSingleNode("Name") ' Tìm phần tử <Name> trong <Bit>
                            If nameNode IsNot Nothing Then
                                If i = 1 Then
                                    Dim section As Integer = (a - 1) \ 8 + 1
                                    Dim subsection As Integer = (a - 1) Mod 8 + 1
                                    Dim id As String = $"{section}.{subsection}"
                                    nameNode.InnerText = id + ": Bit " & a.ToString() ' Ghi giá trị mới vào phần tử <Name>
                                    xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                                End If
                                If i = 2 Then
                                    Dim section As Integer = (a - 1) \ 8 + 1
                                    Dim subsection As Integer = (a - 1) Mod 8 + 1
                                    Dim id As String = $"{10 + section}.{subsection}"
                                    nameNode.InnerText = id + ": Bit " & (a + 80).ToString() ' Ghi giá trị mới vào phần tử <Name>
                                    xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                                End If
                                If i = 3 Then
                                    Dim section As Integer = (a - 1) \ 8 + 1
                                    Dim subsection As Integer = (a - 1) Mod 8 + 1
                                    Dim id As String = $"{20 + section}.{subsection}"
                                    nameNode.InnerText = id + ": Bit " & (a + 160).ToString() ' Ghi giá trị mới vào phần tử <Name>
                                    xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                                End If
                                If i = 4 Then
                                    Dim section As Integer = (a - 1) \ 8 + 1
                                    Dim subsection As Integer = (a - 1) Mod 8 + 1
                                    Dim id As String = $"{30 + section}.{subsection}"
                                    nameNode.InnerText = id + ": Bit " & (a + 240).ToString() ' Ghi giá trị mới vào phần tử <Name>
                                    xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                                End If
                            End If
                        End If
                    Next
                Next
                LoadTrang(Trang)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Plus_Click(sender As Object, e As EventArgs) Handles btn_Plus.Click
        Try
            HamDoiTen()
            If btn_Trang1.Visible = True And btn_Trang2.Visible = False Then
                btn_Trang2.Visible = True
                btn_Trang3.Visible = False
                btn_Trang4.Visible = False
                btn_Plus.Location = New Point(157, 99)
                btn_minus.Location = New Point(187, 99)
                btn_minus.Enabled = True
                Trang2()
            ElseIf btn_Trang2.Visible = True And btn_Trang3.Visible = False Then
                btn_Trang3.Visible = True
                btn_Trang4.Visible = False
                btn_Plus.Location = New Point(233, 99)
                btn_minus.Location = New Point(263, 99)
                btn_minus.Enabled = True
                Trang3()
            ElseIf btn_Trang3.Visible = True And btn_Trang4.Visible = False Then
                btn_Trang4.Visible = True
                btn_Plus.Location = New Point(309, 99)
                btn_minus.Location = New Point(339, 99)
                btn_Plus.Enabled = False
                btn_minus.Enabled = True
                Trang4()
            End If
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                LoadGTBitTong(IDBit)
            End If
            If SuaCanh = 1 Then
                LoadGTKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_minus_Click(sender As Object, e As EventArgs) Handles btn_minus.Click
        Try
            HamDoiTen()
            If btn_Trang2.Visible = True And btn_Trang3.Visible = False Then
                btn_Trang2.Visible = False
                btn_Plus.Location = New Point(81, 99)
                btn_minus.Location = New Point(111, 99)
                btn_Plus.Enabled = True
                btn_minus.Enabled = False
                Trang1()
            ElseIf btn_Trang3.Visible = True And btn_Trang4.Visible = False Then
                btn_Trang3.Visible = False
                btn_Plus.Location = New Point(157, 99)
                btn_minus.Location = New Point(187, 99)
                btn_Plus.Enabled = True
                Trang2()
            ElseIf btn_Trang3.Visible = True And btn_Trang4.Visible = True Then
                btn_Trang4.Visible = False
                btn_Plus.Location = New Point(233, 99)
                btn_minus.Location = New Point(263, 99)
                btn_Plus.Enabled = True
                Trang3()
            End If
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                LoadGTBitTong(IDBit)
            End If
            If SuaCanh = 1 Then
                LoadGTKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Cơ sở dữ liệu"
    Private Sub DB_TBitLe1()
        Try
            Dim fileName As String = "TBitLe1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("BitLeData")
                xmlDoc.AppendChild(rootElement) ' Tạo các phần tử con cho mỗi dòng trong tệp txt
                For i As Integer = 1 To 80
                    Dim section As Integer = (i - 1) \ 8 + 1
                    Dim subsection As Integer = (i - 1) Mod 8 + 1
                    Dim id As String = $"{section}.{subsection}"
                    Dim bitElement As XmlElement = xmlDoc.CreateElement("Bit")
                    bitElement.SetAttribute("ID", i)
                    Dim nameElement As XmlElement = xmlDoc.CreateElement("Name")
                    nameElement.InnerText = id + ": Bit " & i.ToString()
                    Dim StatusElement As XmlElement = xmlDoc.CreateElement("Status")
                    StatusElement.InnerText = "0"
                    bitElement.AppendChild(nameElement)
                    bitElement.AppendChild(StatusElement)
                    rootElement.AppendChild(bitElement)
                Next
                xmlDoc.Save(filePath) ' Lưu tệp XML
            End If
        Catch ex As Exception
            ' Xử lý các ngoại lệ ở đây
        End Try
    End Sub
    Private Sub DB_TBitLe2()
        Try
            Dim fileName As String = "TBitLe2.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("BitLeData")
                xmlDoc.AppendChild(rootElement) ' Tạo các phần tử con cho mỗi dòng trong tệp txt
                For i As Integer = 1 To 80
                    Dim section As Integer = (i - 1) \ 8 + 1
                    Dim subsection As Integer = (i - 1) Mod 8 + 1
                    Dim id As String = $"{10 + section}.{subsection}"
                    Dim bitElement As XmlElement = xmlDoc.CreateElement("Bit")
                    bitElement.SetAttribute("ID", i)
                    Dim nameElement As XmlElement = xmlDoc.CreateElement("Name")
                    nameElement.InnerText = id + ": Bit " & (i + 80).ToString()
                    Dim StatusElement As XmlElement = xmlDoc.CreateElement("Status")
                    StatusElement.InnerText = "0"
                    bitElement.AppendChild(nameElement)
                    bitElement.AppendChild(StatusElement)
                    rootElement.AppendChild(bitElement)
                Next
                xmlDoc.Save(filePath) ' Lưu tệp XML
            End If
        Catch ex As Exception
            ' Xử lý các ngoại lệ ở đây
        End Try
    End Sub
    Private Sub DB_TBitLe3()
        Try
            Dim fileName As String = "TBitLe3.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("BitLeData")
                xmlDoc.AppendChild(rootElement) ' Tạo các phần tử con cho mỗi dòng trong tệp txt
                For i As Integer = 1 To 80
                    Dim section As Integer = (i - 1) \ 8 + 1
                    Dim subsection As Integer = (i - 1) Mod 8 + 1
                    Dim id As String = $"{20 + section}.{subsection}"
                    Dim bitElement As XmlElement = xmlDoc.CreateElement("Bit")
                    bitElement.SetAttribute("ID", i)
                    Dim nameElement As XmlElement = xmlDoc.CreateElement("Name")
                    nameElement.InnerText = id + ": Bit " & (i + 160).ToString()
                    Dim StatusElement As XmlElement = xmlDoc.CreateElement("Status")
                    StatusElement.InnerText = "0"
                    bitElement.AppendChild(nameElement)
                    bitElement.AppendChild(StatusElement)
                    rootElement.AppendChild(bitElement)
                Next
                xmlDoc.Save(filePath) ' Lưu tệp XML
            End If
        Catch ex As Exception
            ' Xử lý các ngoại lệ ở đây
        End Try
    End Sub
    Private Sub DB_TBitLe4()
        Try
            Dim fileName As String = "TBitLe4.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("BitLeData")
                xmlDoc.AppendChild(rootElement) ' Tạo các phần tử con cho mỗi dòng trong tệp txt
                For i As Integer = 1 To 80
                    Dim section As Integer = (i - 1) \ 8 + 1
                    Dim subsection As Integer = (i - 1) Mod 8 + 1
                    Dim id As String = $"{30 + section}.{subsection}"
                    Dim bitElement As XmlElement = xmlDoc.CreateElement("Bit")
                    bitElement.SetAttribute("ID", i)
                    Dim nameElement As XmlElement = xmlDoc.CreateElement("Name")
                    nameElement.InnerText = id + ": Bit " & (i + 240).ToString()
                    Dim StatusElement As XmlElement = xmlDoc.CreateElement("Status")
                    StatusElement.InnerText = "0"
                    bitElement.AppendChild(nameElement)
                    bitElement.AppendChild(StatusElement)
                    rootElement.AppendChild(bitElement)
                Next
                xmlDoc.Save(filePath) ' Lưu tệp XML
            End If
        Catch ex As Exception
            ' Xử lý các ngoại lệ ở đây
        End Try
    End Sub
#End Region
#Region "Bit Lẻ"
    Private Sub label1_DoubleClick(sender As Object, e As EventArgs) Handles label9.DoubleClick, label80.DoubleClick, label8.DoubleClick, label79.DoubleClick, label78.DoubleClick, label77.DoubleClick, label76.DoubleClick, label75.DoubleClick, label74.DoubleClick, label73.DoubleClick, label72.DoubleClick, label71.DoubleClick, label70.DoubleClick, label7.DoubleClick, label69.DoubleClick, label68.DoubleClick, label67.DoubleClick, label66.DoubleClick, label65.DoubleClick, label64.DoubleClick, label63.DoubleClick, label62.DoubleClick, label61.DoubleClick, label60.DoubleClick, label6.DoubleClick, label59.DoubleClick, label58.DoubleClick, label57.DoubleClick, label56.DoubleClick, label55.DoubleClick, label54.DoubleClick, label53.DoubleClick, label52.DoubleClick, label51.DoubleClick, label50.DoubleClick, label5.DoubleClick, label49.DoubleClick, label48.DoubleClick, label47.DoubleClick, label46.DoubleClick, label45.DoubleClick, label44.DoubleClick, label43.DoubleClick, label42.DoubleClick, label41.DoubleClick, label40.DoubleClick, label4.DoubleClick, label39.DoubleClick, label38.DoubleClick, label37.DoubleClick, label36.DoubleClick, label35.DoubleClick, label34.DoubleClick, label33.DoubleClick, label32.DoubleClick, label31.DoubleClick, label30.DoubleClick, label3.DoubleClick, label29.DoubleClick, label28.DoubleClick, label27.DoubleClick, label26.DoubleClick, label25.DoubleClick, label24.DoubleClick, label23.DoubleClick, label22.DoubleClick, label21.DoubleClick, label20.DoubleClick, label2.DoubleClick, label19.DoubleClick, label18.DoubleClick, label17.DoubleClick, label16.DoubleClick, label15.DoubleClick, label14.DoubleClick, label13.DoubleClick, label12.DoubleClick, label11.DoubleClick, label10.DoubleClick, label1.DoubleClick
        Try

            If tb_DoiTen.Visible = True Then
                Dim label As Label = Me.Controls.Find(BitDoiTen, True).FirstOrDefault()
                label.Visible = True
            End If
            Dim clickedLabel As Label = DirectCast(sender, Label)
            Dim labelX As Integer = clickedLabel.Location.X
            Dim labelY As Integer = clickedLabel.Location.Y
            tb_DoiTen.Location = New Point(labelX, labelY - 4)
            tb_DoiTen.Visible = True
            clickedLabel.Visible = False
            Dim CatTen() As String = clickedLabel.Text.Split(":"c)
            If CatTen.Length >= 2 Then
                Dim SoBit As String = CatTen(0).Trim()
                Dim TenBit As String = CatTen(1).Trim()
                tb_DoiTen.Text = TenBit
                tb_DoiTen.SelectAll()
                tb_DoiTen.Focus()
                BitDoiTen = clickedLabel.Name
                TenBitDon = SoBit

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Trang1_Click(sender As Object, e As EventArgs) Handles btn_Trang1.Click
        Try
            HamDoiTen()
            Trang1()
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                LoadGTBitTong(IDBit)
            End If
            If SuaCanh = 1 Then
                LoadGTKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Trang2_Click(sender As Object, e As EventArgs) Handles btn_Trang2.Click
        Try
            HamDoiTen()
            Trang2()
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                LoadGTBitTong(IDBit)
            End If
            If SuaCanh = 1 Then
                LoadGTKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Trang3_Click(sender As Object, e As EventArgs) Handles btn_Trang3.Click
        Try
            HamDoiTen()
            Trang3()
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                LoadGTBitTong(IDBit)
            End If
            If SuaCanh = 1 Then
                LoadGTKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Trang4_Click(sender As Object, e As EventArgs) Handles btn_Trang4.Click
        Try
            HamDoiTen()
            Trang4()
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                LoadGTBitTong(IDBit)
            End If
            If SuaCanh = 1 Then
                LoadGTKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadTrang(Trang As String)
        Try
            If ThemCanh = 0 Then
                pnl_DoiTen.Visible = False
                pnl_DoiTen.Location = New Point(1097, 75)
            End If
            Dim fileName As String = "TBitLe" + Trang + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes("/BitLeData/Bit") ' Lấy tất cả các phần tử <Bit> từ tài liệu XML
                For Each bitNode As XmlNode In bitNodes
                    Dim id As Integer = Integer.Parse(bitNode.Attributes("ID").Value) ' Lấy giá trị của thuộc tính ID
                    Dim nameValue As String = bitNode.SelectSingleNode("Name").InnerText ' Lấy giá trị của phần tử <Name>
                    Dim StatusValue As String = bitNode.SelectSingleNode("Status").InnerText
                    Dim StatusBit As String = "button" & id.ToString()
                    Dim button As Button = Me.Controls.Find(StatusBit, True).FirstOrDefault()
                    If button IsNot Nothing Then
                        If StatusValue = 0 Then
                            Dim fileName1 As String = "OFF.PNG"
                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                            Dim newImage As Image = Image.FromFile(filePath1)
                            button.Image = newImage
                            button.ForeColor = Color.White
                        ElseIf StatusValue = 1 Then
                            Dim fileName1 As String = "ON.PNG"
                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                            Dim newImage As Image = Image.FromFile(filePath1)
                            button.Image = newImage
                            button.ForeColor = Color.Blue
                        ElseIf StatusValue = 2 Then
                            Dim fileName1 As String = "BLYNK.PNG"
                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                            Dim newImage As Image = Image.FromFile(filePath1)
                            button.Image = newImage
                            button.ForeColor = Color.Red
                        End If
                    End If
                    Dim Ten As String = "label" & id.ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                    Dim label As Label = Me.Controls.Find(Ten, True).FirstOrDefault()
                    If label IsNot Nothing Then
                        label.Text = nameValue
                        label.ForeColor = Color.Black
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Trang1()
        Try
            btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
            btn_Trang1.ForeColor = Color.White
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
            btn_Trang3.BackColor = Color.White
            btn_Trang3.ForeColor = Color.Black
            btn_Trang4.BackColor = Color.White
            btn_Trang4.ForeColor = Color.Black
            Trang = "1"
            LoadTrang(Trang)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Trang2()
        Try
            btn_Trang1.BackColor = Color.White
            btn_Trang1.ForeColor = Color.Black
            btn_Trang2.BackColor = Color.FromArgb(0, 117, 227)
            btn_Trang2.ForeColor = Color.White
            btn_Trang3.BackColor = Color.White
            btn_Trang3.ForeColor = Color.Black
            btn_Trang4.BackColor = Color.White
            btn_Trang4.ForeColor = Color.Black
            Trang = "2"
            LoadTrang(Trang)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Trang3()
        Try
            btn_Trang1.BackColor = Color.White
            btn_Trang1.ForeColor = Color.Black
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
            btn_Trang3.BackColor = Color.FromArgb(0, 117, 227)
            btn_Trang3.ForeColor = Color.White
            btn_Trang4.BackColor = Color.White
            btn_Trang4.ForeColor = Color.Black
            Trang = "3"
            LoadTrang(Trang)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Trang4()
        Try
            btn_Trang1.BackColor = Color.White
            btn_Trang1.ForeColor = Color.Black
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
            btn_Trang3.BackColor = Color.White
            btn_Trang3.ForeColor = Color.Black
            btn_Trang4.BackColor = Color.FromArgb(0, 117, 227)
            btn_Trang4.ForeColor = Color.White
            Trang = "4"
            LoadTrang(Trang)
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Truyền dữ liệu"

    Public Sub MainToBitDon(BitId As String, name As String)
        Try

            btn_XacNhan.Location = New Point(1290, 10)
            btn_XacNhan.Visible = True
            lb_DanhSachBitDon.Text = "Thêm đối tượng tổng: " + name
            btn_ThemDSB.Visible = False
            btn_XuatDSB.Visible = False
            btn_Reset.Visible = False
            TTALL(0) ' tắt tất cả

            IDBit = BitId

            LoadGTBitTong(IDBit)
            Bit_ID = BitId.ToString()
            'LoadTrang1()
            ThemBitTong = 1



        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_XacNhan_Click(sender As Object, e As EventArgs) Handles btn_XacNhan.Click
        Try
            HamDoiTen()

            If ThemBitTong = 1 Then
                If FrmSBVLM.Instance.tb_truyen.Text = "10" Or FrmSBVLM.Instance.tb_truyen.Text = "01" Then
                    XNBitTong1()
                    ResetDataString()
                    TTALL(0)
                ElseIf FrmSBVLM.Instance.tb_truyen.Text = "21" Then
                    XNBitTong()
                    FrmSBVLM.Instance.tb_truyen.Text = "00"
                    ResetDataString()
                    TTALL(0)
                End If
            End If
            'If FrmSBVLM.Instance.tb_truyen.Text = "10" Then
            '    XNKichBan()
            'End If

            'If FrmSBVLM.Instance.tb_truyen.Text = "01" Then
            '    XNKichBanCanh()
            'End If
        Catch eX As Exception
        End Try
    End Sub
    Public Sub MainKichBanToBitDon(data As String)
        Try
            TTALL(0)
            ResetDataString()
            'LoadTrang1()
            SoLanNhan = 0
            ThemCanh = 1
            SuaCanh = 0
            ThemBitTong = 0
            btn_ThemDSB.Visible = False
            btn_XuatDSB.Visible = False
            btn_Reset.Visible = False
            btn_XacNhan.Location = New Point(1290, 10)
            btn_XacNhan.Visible = True
            pnl_DoiTen.Visible = True
            pnl_DoiTen.Location = New Point(1124, 75)
            lb_DoiTenBit.Text = "Tên Cảnh   "
            tb_TenCanh.Text = ""
            lb_DanhSachBitDon.Text = "Kịch Bản: " + data
            TenKichBan = data
        Catch ex As Exception
        End Try
    End Sub
    Public Sub KichBanCanhToMain1(data As String)
        Try
            ResetDataString()
            'LoadTrang1()
            SoLanNhan = 0
            ThemCanh = 1
            SuaCanh = 1
            ThemBitTong = 0
            btn_ThemDSB.Visible = False
            btn_XuatDSB.Visible = False
            btn_Reset.Visible = False
            btn_XacNhan.Location = New Point(1290, 10)
            btn_XacNhan.Visible = True
            Dim DuLieu As String() = data.Split(",")
            If DuLieu.Length >= 2 Then
                TenKichBanCanh = DuLieu(0)
                TenKichBan = DuLieu(1)
            End If
            lb_DanhSachBitDon.Text = "Tên Cảnh: " + TenKichBanCanh
            LoadGTKichBan()
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Lưu Giá Trị Bit Tổng"
    'Private Sub LuuGTBitTong()
    '    Try
    '        Dim fileName As String = "TBitTong1.xml"
    '        Dim filePath As String = Path.Combine(folderPath1, fileName)
    '        Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
    '        xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
    '        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{Bit_ID}']")
    '        If bitNode IsNot Nothing Then
    '            Dim nameNode As XmlNode = bitNode.SelectSingleNode("Data") ' Tìm phần tử <Name> trong <Bit>
    '            If nameNode IsNot Nothing Then
    '                nameNode.InnerText = dataString ' Ghi giá trị mới vào phần tử <Name>
    '                xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
    '            End If
    '        End If
    '        ResetDataString()
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Private Sub LuuGTBitTong()
        Try
            Dim cutBit_ID() As String = Bit_ID.Split("_"c) ' Tách chuỗi bằng dấu _
            Dim nhom As String = cutBit_ID(0) ' Phần đầu tiên
            Dim id As String = cutBit_ID(1) ' Phần thứ hai

            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
            xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
            Dim ketQuaCatBuilder As New StringBuilder()
            For position As Integer = 0 To 318
                Dim foundOne As Boolean = False
                Dim foundNodes As Integer = 0
                For i As Integer = 1 To 16
                    Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{nhom}_{i}']/Data")
                    If bitNode IsNot Nothing Then
                        foundNodes += 1
                        Dim variableToStoreData As String = bitNode.InnerText
                        If variableToStoreData.Length > position AndAlso variableToStoreData(position) = "1"c Then
                            foundOne = True
                            Exit For
                        End If
                    End If
                    If foundNodes < 16 AndAlso foundOne Then
                        Exit For
                    End If
                Next
                If foundOne Then
                    ketQuaCatBuilder.Append("1"c)
                Else
                    ketQuaCatBuilder.Append("0"c)
                End If
            Next
            Dim ketQuaCat As String = ketQuaCatBuilder.ToString()
            Dim xmlDoc2 As New XmlDocument()
            xmlDoc2.Load(filePath)

            Dim bitNode2 As XmlNode = xmlDoc2.SelectSingleNode($"/BitTongData/Bit[@ID='{nhom}']/Data")
            If bitNode2 IsNot Nothing Then
                bitNode2.InnerText = ketQuaCat
                xmlDoc2.Save(filePath)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadGTBitTong(BitID As String)
        Try
            Dim so As Integer = 0
            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes("/BitTongData/Bit") ' Lấy tất cả các phần tử <Bit> từ tài liệu XML
                For Each bitNode As XmlNode In bitNodes
                    Dim id As String = bitNode.Attributes("ID").InnerText ' Lấy giá trị của thuộc tính ID
                    Dim DataValue As String = bitNode.SelectSingleNode("Data").InnerText ' Lấy giá trị của phần tử <Name>
                    If id = BitID Then
                        For i As Integer = 0 To DataValue.Length - 1
                            If DataValue(i) = "1"c Then
                                If i >= 0 AndAlso i <= 79 Then
                                    If btn_Trang1.ForeColor = Color.White Then
                                        so = i + 1
                                        Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                        Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                        If button IsNot Nothing Then
                                            Dim fileName1 As String = "ON.PNG"
                                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                            Dim newImage As Image = Image.FromFile(filePath1)
                                            button.Image = newImage
                                            button.ForeColor = Color.Blue
                                        End If
                                    End If
                                End If
                                If i >= 80 AndAlso i <= 159 Then
                                    If btn_Trang2.ForeColor = Color.White Then
                                        so = (i - 80) + 1
                                        Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                        Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                        If button IsNot Nothing Then
                                            Dim fileName1 As String = "ON.PNG"
                                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                            Dim newImage As Image = Image.FromFile(filePath1)
                                            button.Image = newImage
                                            button.ForeColor = Color.Blue
                                        End If
                                    End If
                                End If
                                If i >= 160 AndAlso i <= 239 Then
                                    If btn_Trang3.ForeColor = Color.White Then
                                        so = (i - 160) + 1
                                        Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                        Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                        If button IsNot Nothing Then
                                            Dim fileName1 As String = "ON.PNG"
                                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                            Dim newImage As Image = Image.FromFile(filePath1)
                                            button.Image = newImage
                                            button.ForeColor = Color.Blue
                                        End If
                                    End If
                                End If
                                If i >= 240 AndAlso i <= 319 Then
                                    If btn_Trang4.ForeColor = Color.White Then
                                        so = (i - 240) + 1
                                        Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                        Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                        If button IsNot Nothing Then
                                            Dim fileName1 As String = "ON.PNG"
                                            Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                            Dim newImage As Image = Image.FromFile(filePath1)
                                            button.Image = newImage
                                            button.ForeColor = Color.Blue
                                        End If
                                    End If
                                End If
                                dataString(i) = "1"c
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Lưu Giá Trị Kịch Bản"
    Private Sub LuuGTKichBan()
        Try
            If DanhSachTenBit1.Count <> 0 Then
                Dim fileName As String = TenKichBan + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)
                Dim mangChuoi As String() = DanhSachTenBit1.ToArray()
                If File.Exists(filePath) Then
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath)
                    Dim nodeList As XmlNodeList = xmlDoc.SelectNodes("//TenCanh[@ID]")
                    Dim rootElement As XmlElement = xmlDoc.DocumentElement
                    Dim TenCanhElement As XmlElement = xmlDoc.CreateElement("TenCanh")
                    TenCanhElement.SetAttribute("ID", tb_TenCanh.Text)
                    Dim bitCanhElement As XmlElement = xmlDoc.CreateElement("BitCanh")
                    bitCanhElement.InnerText = String.Join(",", DanhSachTenBit1.ToArray())
                    Dim dataElement As XmlElement = xmlDoc.CreateElement("Data")
                    dataElement.InnerText = dataString
                    Dim locationElement As XmlElement = xmlDoc.CreateElement("Location")
                    locationElement.InnerText = "Trống"
                    TenCanhElement.AppendChild(bitCanhElement)
                    TenCanhElement.AppendChild(dataElement)
                    TenCanhElement.AppendChild(locationElement)
                    rootElement.AppendChild(TenCanhElement)
                    xmlDoc.Save(filePath)
                    DanhSachTenBit1.Clear()
                    RaiseEvent BitDonToMain(Me, "KichBan")
                Else

                End If

            End If
        Catch ex As Exception
            Console.WriteLine("Lỗi: " & ex.Message)
        End Try
    End Sub
    Public Sub LuuGTKichBanCanh()
        Try
            If DanhSachTenBit1.Count <> 0 Or SuaCanh = 1 Then
                Dim fileName As String = TenKichBan + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)
                Dim mangChuoi As String() = DanhSachTenBit1.ToArray()
                If File.Exists(filePath) Then
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath)
                    Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']")
                    If bitNode IsNot Nothing Then
                        Dim BitCanhNode As XmlNode = bitNode.SelectSingleNode("BitCanh")
                        If BitCanhNode IsNot Nothing Then
                            BitCanhNode.InnerText = String.Join(",", DanhSachTenBit1.ToArray())
                        End If
                        Dim DataNode As XmlNode = bitNode.SelectSingleNode("Data")
                        If DataNode IsNot Nothing Then
                            DataNode.InnerText = dataString
                        End If
                    End If
                    xmlDoc.Save(filePath)
                    DanhSachTenBit1.Clear()
                    RaiseEvent BitDonToMain(Me, "KichBan")
                Else

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadGTKichBan()
        Try
            Dim so As Integer = 0
            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']")
                For Each bitNode As XmlNode In bitNodes
                    Dim DataValue As String = bitNode.SelectSingleNode("Data").InnerText
                    TenCanh = bitNode.SelectSingleNode("BitCanh").InnerText
                    Dim TenCanh_1 As String() = TenCanh.Split(",") 'Thêm từng phần tử vào danh sách
                    For Each TenCanh_2 As String In TenCanh_1
                        Dim TenCanh_3 As String = TenCanh_2.Trim() 'Loại bỏ khoảng trắng nếu có
                        If Not DanhSachTenBit1.Contains(TenCanh_3) Then
                            DanhSachTenBit1.Add(TenCanh_3)
                        End If
                    Next
                    For i As Integer = 0 To DataValue.Length - 1
                        If DataValue(i) = "1"c Then
                            If i >= 0 AndAlso i <= 79 Then
                                If btn_Trang1.ForeColor = Color.White Then
                                    so = i + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "ON.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If i >= 80 AndAlso i <= 159 Then
                                If btn_Trang2.ForeColor = Color.White Then
                                    so = (i - 80) + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "ON.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If i >= 160 AndAlso i <= 239 Then
                                If btn_Trang3.ForeColor = Color.White Then
                                    so = (i - 160) + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "ON.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            If i >= 240 AndAlso i <= 319 Then
                                If btn_Trang4.ForeColor = Color.White Then
                                    so = (i - 240) + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "ON.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Blue
                                    End If
                                End If
                            End If
                            dataString(i) = "1"c
                        End If
                        If DataValue(i) = "2"c Then
                            If i >= 0 AndAlso i <= 79 Then
                                If btn_Trang1.ForeColor = Color.White Then
                                    so = i + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "BLYNK.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Red
                                    End If
                                End If
                            End If
                            If i >= 80 AndAlso i <= 159 Then
                                If btn_Trang2.ForeColor = Color.White Then
                                    so = (i - 80) + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "BLYNK.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Red
                                    End If
                                End If
                            End If
                            If i >= 160 AndAlso i <= 239 Then
                                If btn_Trang3.ForeColor = Color.White Then
                                    so = (i - 160) + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "BLYNK.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Red
                                    End If
                                End If
                            End If
                            If i >= 240 AndAlso i <= 319 Then
                                If btn_Trang4.ForeColor = Color.White Then
                                    so = (i - 240) + 1
                                    Dim Ten As String = "button" & (so).ToString() ' Sử dụng giá trị lấy được (nameValue) theo nhu cầu của bạn
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "BLYNK.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Red
                                    End If
                                End If
                            End If
                            dataString(i) = "2"c
                        End If
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LuuGTKichBanTrang()
        Try
            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath)
            Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']")
            For Each bitNode As XmlNode In bitNodes
                Dim dataNode As XmlNode = bitNode.SelectSingleNode("Data")
                Dim BitCanhNode As XmlNode = bitNode.SelectSingleNode("BitCanh")
                If BitCanhNode IsNot Nothing Then
                    BitCanhNode.InnerText = String.Join(",", DanhSachTenBit1.ToArray())
                End If
                If dataNode IsNot Nothing Then
                    dataNode.InnerText = dataString
                    xmlDoc.Save(filePath)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Xuất Dữ Liệu"
    Private Sub btn_XuatDSB_Click(sender As Object, e As EventArgs) Handles btn_XuatDSB.Click
        Try
            HamDoiTen()
            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Chọn vị trí lưu thư mục Bit Đơn"
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFolderPath As String = folderBrowserDialog.SelectedPath
                Dim bitDonFolderPath As String = Path.Combine(selectedFolderPath, "BitDon")
                If Not Directory.Exists(bitDonFolderPath) Then
                    Directory.CreateDirectory(bitDonFolderPath)
                End If
                For i As Integer = 1 To 4
                    Dim sourceFilePath As String = Path.Combine(folderPath1, $"TBitLe{i}.xml")
                    Dim destinationFilePath As String = Path.Combine(bitDonFolderPath, $"TBitLe{i}.xml")
                    If File.Exists(sourceFilePath) Then
                        File.Copy(sourceFilePath, destinationFilePath, True)
                    End If
                Next
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_ThemDSB_Click(sender As Object, e As EventArgs) Handles btn_ThemDSB.Click
        Try
            HamDoiTen()
            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Chọn thư mục chứa các tệp XML"
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFolderPath As String = folderBrowserDialog.SelectedPath
                Dim xmlFiles As String() = Directory.GetFiles(selectedFolderPath, "*.xml")
                For Each xmlFile As String In xmlFiles
                    If File.Exists(xmlFile) Then
                        Dim xmlFileName As String = Path.GetFileName(xmlFile)
                        Dim destinationPath As String = Path.Combine(folderPath1, xmlFileName)
                        File.Copy(xmlFile, destinationPath, True)
                    End If
                Next
                LoadTrang(Trang)
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Hàm Con"
    Private Sub XNBitTong()
        Try
            If ThemBitTong = 1 Then

                LuuGTBitTong()
                btn_ThemDSB.Visible = True
                btn_XuatDSB.Visible = True
                btn_Reset.Visible = True
                btn_XacNhan.Location = New Point(867, 10)
                btn_XacNhan.Visible = False
                lb_DanhSachBitDon.Text = "Danh Sách Đối Tượng Đơn"
                btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
                btn_Trang1.ForeColor = Color.White
                btn_Trang2.BackColor = Color.White
                btn_Trang2.ForeColor = Color.Black
                btn_Trang3.BackColor = Color.White
                btn_Trang3.ForeColor = Color.Black
                btn_Trang4.BackColor = Color.White
                btn_Trang4.ForeColor = Color.Black
                TTALL(0)
                LuuDataBitLe()
                Trang = "1"
                LoadTrang(Trang)
                ThemBitTong = 0
                RaiseEvent BitDonToMain(Me, "BitTong")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub maintobitdon()
        btn_ThemDSB.Visible = True
        btn_XuatDSB.Visible = True
        btn_Reset.Visible = True
        btn_XacNhan.Location = New Point(867, 10)
        btn_XacNhan.Visible = False
        lb_DanhSachBitDon.Text = "Danh Sách Đối Tượng Đơn"
        btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
        btn_Trang1.ForeColor = Color.White
        btn_Trang2.BackColor = Color.White
        btn_Trang2.ForeColor = Color.Black
        btn_Trang3.BackColor = Color.White
        btn_Trang3.ForeColor = Color.Black
        btn_Trang4.BackColor = Color.White
        btn_Trang4.ForeColor = Color.Black
    End Sub
    Private Sub XNBitTong1()
        Try
            If ThemBitTong = 1 Then
                LuuGTBitTong()
                btn_ThemDSB.Visible = True
                btn_XuatDSB.Visible = True
                btn_Reset.Visible = True
                btn_XacNhan.Location = New Point(867, 10)
                btn_XacNhan.Visible = False
                lb_DanhSachBitDon.Text = "Danh Sách Đối Tượng Đơn"
                btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
                btn_Trang1.ForeColor = Color.White
                btn_Trang2.BackColor = Color.White
                btn_Trang2.ForeColor = Color.Black
                btn_Trang3.BackColor = Color.White
                btn_Trang3.ForeColor = Color.Black
                btn_Trang4.BackColor = Color.White
                btn_Trang4.ForeColor = Color.Black
                TTALL(0)
                LuuDataBitLe()
                Trang = "1"
                LoadTrang(Trang)
                ThemBitTong = 0
                RaiseEvent BitDonToMain(Me, "BitTong1")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub XNKichBan()
        Try

            If ThemCanh = 1 Then
                If SuaCanh = 0 Then
                    If tb_TenCanh.Text <> "" Then
                        LuuGTKichBan()
                    End If

                    btn_ThemDSB.Visible = True
                    btn_XuatDSB.Visible = True
                    btn_Reset.Visible = True
                    btn_XacNhan.Location = New Point(867, 10)
                    btn_XacNhan.Visible = False
                    lb_DanhSachBitDon.Text = "Danh Sách Đối Tượng Đơn"
                    btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
                    btn_Trang1.ForeColor = Color.White
                    btn_Trang2.BackColor = Color.White
                    btn_Trang2.ForeColor = Color.Black
                    btn_Trang3.BackColor = Color.White
                    btn_Trang3.ForeColor = Color.Black
                    btn_Trang4.BackColor = Color.White
                    btn_Trang4.ForeColor = Color.Black
                    TTALL(0)
                    LuuDataBitLe()
                    Trang = "1"
                    LoadTrang(Trang)
                    ThemCanh = 0
                    pnl_DoiTen.Visible = False
                    pnl_DoiTen.Location = New Point(1124, 75)
                    lb_DoiTenBit.Text = "Đổi Tên Bit"
                    tb_TenCanh.Text = ""
                    RaiseEvent BitDonKichBanToMain(Me, "xong")
                    LoadGTKichBan()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub XNKichBanCanh()
        Try
            ThemBitTong = 1
            LuuGTKichBanCanh()
            btn_ThemDSB.Visible = True
            btn_XuatDSB.Visible = True
            btn_Reset.Visible = True
            btn_XacNhan.Location = New Point(867, 10)
            btn_XacNhan.Visible = False
            lb_DanhSachBitDon.Text = "Danh Sách Đối Tượng Đơn"
            btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
            btn_Trang1.ForeColor = Color.White
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
            btn_Trang3.BackColor = Color.White
            btn_Trang3.ForeColor = Color.Black
            btn_Trang4.BackColor = Color.White
            btn_Trang4.ForeColor = Color.Black
            TTALL(0)
            LuuDataBitLe()
            Trang = "1"
            LoadTrang(Trang)
            ThemCanh = 0
            RaiseEvent KichBanToMain1(Me, FrmSBVLM.Instance.tb_kbtruyen.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadTrang1()
        btn_Trang1.Visible = True
        btn_Trang2.Visible = False
        btn_Trang3.Visible = False
        btn_Trang4.Visible = False
        btn_Plus.Location = New Point(81, 99)
        btn_minus.Location = New Point(111, 99)
        btn_Plus.Enabled = True
        btn_minus.Enabled = False
    End Sub
    Public Sub TTALL(data As String)
        Try
            HamDoiTen()
            For i As Integer = 1 To 4
                Dim fileName As String = "TBitLe" + i.ToString() + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
                xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
                For e As Integer = 1 To 80
                    Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitLeData/Bit[@ID='{e}']")
                    If bitNode IsNot Nothing Then
                        Dim nameNode As XmlNode = bitNode.SelectSingleNode("Status") ' Tìm phần tử <Name> trong <Bit>
                        If nameNode IsNot Nothing Then
                            nameNode.InnerText = data ' Ghi giá trị mới vào phần tử <Name>
                        End If
                    End If
                Next
                xmlDoc.Save(filePath)
            Next
            LoadTrang(Trang)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub resetBitTong()
        Try
            If ThemBitTong = 1 Then
                ResetDataString()
                LuuGTBitTong()

            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub resetKichBan()
        Try
            If SuaCanh = 1 Then
                DanhSachTenBit1.Clear()
                ResetDataString()
                LuuGTKichBanCanh()
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Đổi Tên"
    Private Sub pnl_Main_Click(sender As Object, e As EventArgs) Handles pnl_Main.Click
        HamDoiTen()
    End Sub
    Private Sub HamDoiTen()
        If tb_DoiTen.Visible = True Then
            tb_DoiTen.Visible = False
            tb_DoiTen.Text = ""
            If BitDoiTen <> "" Then
                Dim label As Label = Me.Controls.Find(BitDoiTen, True).FirstOrDefault()
                label.Visible = True
            End If
        End If
    End Sub
    Private Sub pnl_Menu_Click(sender As Object, e As EventArgs)
        HamDoiTen()
    End Sub
    Private Sub BitDon_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        HamDoiTen()
    End Sub
    Private Sub lb_DanhSachBitDon_Click(sender As Object, e As EventArgs) Handles lb_DanhSachBitDon.Click
        HamDoiTen()
    End Sub
#End Region
    Private LuudataString As Char() = New Char(319) {}
    Public Sub ResetLuuDataString()
        Try
            For i As Integer = 0 To LuudataString.Length - 1
                LuudataString(i) = "0"c
            Next
        Catch
        End Try
    End Sub
    Private Sub LuuDataBitLe()
        Try
            Dim xmlDoc As New XmlDocument()
            For i As Integer = 1 To 4
                Dim fileName As String = "TBitLe" + i.ToString() + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)
                xmlDoc.Load(filePath)
                For a As Integer = 1 To 80
                    Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitLeData/Bit[@ID='{a}']")
                    If bitNode IsNot Nothing Then
                        Dim nameNode As XmlNode = bitNode.SelectSingleNode("Status") ' Tìm phần tử <Status> trong <Bit>
                        If nameNode IsNot Nothing Then
                            If i = 1 Then
                                Select Case LuudataString(a - 1)
                                    Case "0"c
                                        nameNode.InnerText = 0
                                    Case "1"c
                                        nameNode.InnerText = 1
                                    Case "2"c
                                        nameNode.InnerText = 2
                                End Select
                            End If
                            If i = 2 Then
                                Select Case LuudataString(a + 79)
                                    Case "0"c
                                        nameNode.InnerText = 0
                                    Case "1"c
                                        nameNode.InnerText = 1
                                    Case "2"c
                                        nameNode.InnerText = 2
                                End Select
                            End If
                            If i = 3 Then
                                Select Case LuudataString(a + 159)
                                    Case "0"c
                                        nameNode.InnerText = 0
                                    Case "1"c
                                        nameNode.InnerText = 1
                                    Case "2"c
                                        nameNode.InnerText = 2
                                End Select
                            End If
                            If i = 4 Then
                                Select Case LuudataString(a + 239)
                                    Case "0"c
                                        nameNode.InnerText = 0
                                    Case "1"c
                                        nameNode.InnerText = 1
                                    Case "2"c
                                        nameNode.InnerText = 2
                                End Select
                            End If
                        End If
                    End If
                Next
                xmlDoc.Save(filePath)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



End Class
