Imports System.IO
Imports System.Threading
Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Guna.UI2.WinForms

Public Class BitTong
#Region "Biến toàn cục"
    Dim ThemBit As Integer = 0
    Dim parsedValue As Integer = 0
    Private folderPath As String
    Private folderPath1 As String
    Private SoLanNhan As Integer = 0
    Private Const waitTime As Integer = 200 ' Thời gian chờ (100ms)
    Private dataString As Char() = New Char(319) {}
    Private dataString1 As Char() = New Char(160) {}
    Dim Trang As String = 1
    Private BitDoiTen As String
    Private TenBitTong As String
    Public Event BitTongToMain As EventHandler(Of String)
    Public Event BitTongToSerial As EventHandler(Of String)
    Public Event BitTongToSerial1 As EventHandler(Of String)
    Public Event BitTongTo3DmapTP As EventHandler(Of String)
    Public Event BitTongTo3DmapTP1 As EventHandler(Of String)
    Dim hex As String
    Private KiemTra As Boolean = False
    Private TrangThai As Integer = 0
    Private TenKichBan As String
    Private TenKichBanCanh As String
    Private TenCanh As String
    Private Thembittong1 As Integer = 0
    Private NhomNow() As Boolean = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
    Private SttNhomBitTong As Integer = 0
    Private SoLuongBTofNhom() As Integer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0} ' 11 số 0 bắt đầu từ 1
    Private KhoaAdd1 As Boolean = 0
    Private KhoaAdd2 As Boolean = 0
    Public Event BitTongKichBanToMain As EventHandler(Of String)
    Dim DanhSachTenBit As New List(Of String)()
    Dim KichBan As New KichBan()
    Dim ThemBitTong As String = 0
    Dim Bitid As String
    Dim TenBit As String
    Dim ID As String
    Dim Status As Integer
    Dim dataString2 As String
    Dim Bit_ID As String
    Dim bit As Integer = 0
    Dim lch As Integer = 0
    Dim IDC As Integer
    Private TenNhom As String
#End Region
#Region "Load"
    Private Sub BitTong_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim folderName As String = "Data\HA"
            folderPath = Path.Combine(baseDirectory, folderName)
            Dim folderName1 As String = "Data"
            folderPath1 = Path.Combine(baseDirectory, folderName1)
            ResetDataString()
            ResetDataString1()
            'LoadTrang(Trang)
            CreatXMLbittong()
            LoadDataXml("1")
            loadtennhom()
            If FrmSBVLM.Instance.tb_truyen.Text = "01" Then
                LoadGTKichBan()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub loadtennhom()
        Try
            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                For i As Integer = 0 To 10
                    Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{i}']/Name")
                    If bitNode IsNot Nothing Then
                        Dim nameValue As String = bitNode.InnerText
                        Dim controlName As String = $"lb_NameNhomBit{i}"
                        Dim name As String = $"pnl_NhomTong{i}"
                        Dim panel1 As Panel = DirectCast(Me.Controls.Find(name, True).FirstOrDefault(), Panel)
                        Dim label As Label = panel1.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Name = controlName)
                        If label IsNot Nothing Then
                            label.Text = nameValue
                        End If
                    End If
                Next

            End If
        Catch
        End Try
    End Sub
    Private Sub LoadDataXml(Trang As String)
        Try
            pnl_BT1.Width = 0
            pnl_BT2.Width = 0
            pnl_BT3.Width = 0
            pnl_BT4.Width = 0
            pnl_BT5.Width = 0
            pnl_BT6.Width = 0
            pnl_BT7.Width = 0
            pnl_BT8.Width = 0
            pnl_BT9.Width = 0
            pnl_BT10.Width = 0
            Dim fileName As String = "TBitTong" + Trang + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)

            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes("/BitTongData/Bit")
                For Each bitNode As XmlNode In bitNodes
                    Dim BitID As String = bitNode.Attributes("ID").Value ' Lấy giá trị của thuộc tính ID
                    If BitID.Length >= 3 Then ' không load lấy giá trị của bit tổng của tổng
                        Dim nameValue As String = bitNode.SelectSingleNode("Name").InnerText ' Lấy giá trị của phần tử <Name>
                        Dim StatusValue As String = bitNode.SelectSingleNode("Status").InnerText
                        'giá trị bit tổng
                        Dim BitID_Cut() As String = BitID.Split("_"c)
                        Dim nhom As Integer = Convert.ToInt16(BitID_Cut(0))
                        Dim Vitri As Integer = Convert.ToInt16(BitID_Cut(1))

                        SoLuongBTofNhom(nhom) = Vitri
                        CreatBitTong(Vitri, nhom, nameValue)
                        CapNhatGiaoDien(nhom)
                    End If
                Next
            End If
        Catch
        End Try
    End Sub
#Region " CSDL"
    Private Sub CreatXMLbittong()
        Try
            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("BitTongData")

                xmlDoc.AppendChild(rootElement) ' Tạo các phần tử con cho mỗi dòng trong tệp txt

                For i As Integer = 1 To 10
                    Dim bitElement As XmlElement = xmlDoc.CreateElement("Bit")
                    bitElement.SetAttribute("ID", i)
                    Dim nameElement As XmlElement = xmlDoc.CreateElement("Name")
                    nameElement.InnerText = "Nhóm Tổng " + i.ToString
                    Dim StatusElement As XmlElement = xmlDoc.CreateElement("Status")
                    StatusElement.InnerText = "0"
                    Dim DataElement As XmlElement = xmlDoc.CreateElement("Data")
                    DataElement.InnerText = String.Concat(Enumerable.Repeat("0", 320))

                    bitElement.AppendChild(nameElement)
                    bitElement.AppendChild(StatusElement)
                    bitElement.AppendChild(DataElement)
                    rootElement.AppendChild(bitElement)
                Next
                xmlDoc.Save(filePath) ' Lưu tệp XML
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Private Sub CreatBitTong(Vitri As Integer, Nhom As Integer, NameBitTong As String)
        Try
            Dim SttHangBitTong As Integer = Vitri - ((Vitri - 1) \ 16) * 16
            Dim SttCotBitTong As Integer = (Vitri - 1) \ 16

            ' BitID = 1_1 ... 1_80 , 2_1 ... 2_5

            Dim Pnl As Panel = New Panel
            Select Case Nhom
                Case 1
                    Pnl = pnl_BT1
                Case 2
                    Pnl = pnl_BT2
                Case 3
                    Pnl = pnl_BT3
                Case 4
                    Pnl = pnl_BT4
                Case 5
                    Pnl = pnl_BT5
                Case 6
                    Pnl = pnl_BT6
                Case 7
                    Pnl = pnl_BT7
                Case 8
                    Pnl = pnl_BT8
                Case 9
                    Pnl = pnl_BT9
                Case 10
                    Pnl = pnl_BT10
            End Select
            Dim BitID As String = Nhom.ToString() + "_" + Vitri.ToString()

            Dim newPicture As New PictureBox()
            newPicture.Size = New Size(30, 30)
            newPicture.SizeMode = PictureBoxSizeMode.Zoom
            newPicture.Name = "Pic" + BitID
            newPicture.Location = New Point(SttCotBitTong * 296 + 5, (SttHangBitTong - 1) * 52 + 11)
            Dim filePath As String = Path.Combine(folderPath, "technical-support.PNG") ' hình button cài đặt bit
            Dim newImage As Image = Image.FromFile(filePath)
            newPicture.Image = newImage
            Pnl.Controls.Add(newPicture)
            newPicture.BringToFront()

            ' thêm button bật tắt
            Dim newButton As New Button()
            newButton.Size = New Size(64, 31)
            newButton.Name = "Button" + BitID
            newButton.Location = New Point(SttCotBitTong * 296 + 39, (SttHangBitTong - 1) * 52 + 10)
            newButton.FlatStyle = FlatStyle.Flat
            newButton.ForeColor = Color.White
            newButton.FlatAppearance.BorderSize = 0
            newButton.FlatAppearance.BorderColor = Color.White
            newButton.FlatAppearance.MouseDownBackColor = Color.Transparent
            newButton.FlatAppearance.MouseOverBackColor = Color.Transparent
            newButton.BackgroundImageLayout = ImageLayout.Zoom
            Dim filePath1 As String = Path.Combine(folderPath, "OFF.PNG")
            Dim newImage1 As Image = Image.FromFile(filePath1)
            newButton.Image = newImage1
            Pnl.Controls.Add(newButton)
            newButton.BringToFront()

            ' thêm label tên
            Dim newLabel As New Label()
            Dim labelFont As New Font("Microsoft Sans Serif", 9.75, FontStyle.Bold)
            newLabel.Name = "Lab" + BitID
            newLabel.Text = NameBitTong
            newLabel.Font = labelFont
            newLabel.AutoSize = True
            newLabel.Location = New Point(SttCotBitTong * 296 + 105, (SttHangBitTong - 1) * 52 + 20)
            Pnl.Controls.Add(newLabel)
            newLabel.BringToFront()

            ' thêm sự kiện
            AddHandler newPicture.DoubleClick, AddressOf pictureBox1_DoubleClick
            AddHandler newButton.MouseDown, AddressOf button1_MouseDown
            AddHandler newLabel.DoubleClick, AddressOf label1_DoubleClick
        Catch
        End Try
    End Sub
    Private Sub RoundPanel(panel As Panel, cornerRadius As Integer)
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90)
        path.AddLine(cornerRadius, 0, panel.Width, 0)
        path.AddLine(panel.Width, 0, panel.Width, panel.Height)
        path.AddLine(panel.Width, panel.Height, 0, panel.Height)
        path.AddLine(0, panel.Height, 0, cornerRadius)
        path.CloseFigure()
        panel.Region = New Region(path)
    End Sub
    Private Sub RoundPanel1(panel As Panel, cornerRadius As Integer)
        Dim path As New GraphicsPath()
        path.AddLine(0, 0, panel.Width, 0)
        path.AddLine(panel.Width, 0, panel.Width, panel.Height)
        path.AddLine(panel.Width, panel.Height, cornerRadius, panel.Height)
        path.AddArc(0, panel.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90) ' Bo góc dưới bên trái
        path.CloseFigure()
        panel.Region = New Region(path)
    End Sub
    Private Sub RoundPanel2(panel As Panel, cornerRadius As Integer)
        Dim path As New GraphicsPath()
        path.AddLine(0, 0, panel.Width - cornerRadius, 0)
        path.AddArc(panel.Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, -90, 90) ' Bo góc phải trên
        path.AddLine(panel.Width, cornerRadius, panel.Width, panel.Height)
        path.AddLine(panel.Width, panel.Height, 0, panel.Height)
        path.AddLine(0, panel.Height, 0, cornerRadius)
        path.CloseFigure()
        panel.Region = New Region(path)
    End Sub
    Private Sub RoundPanel3(panel As Panel, cornerRadius As Integer)
        Dim path As New GraphicsPath()
        path.AddLine(0, 0, panel.Width, 0)
        path.AddLine(panel.Width, 0, panel.Width, panel.Height - cornerRadius)
        path.AddArc(panel.Width - cornerRadius * 2, panel.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90) ' Bo góc phải dưới
        path.AddLine(panel.Width - cornerRadius, panel.Height, 0, panel.Height)
        path.CloseFigure()
        panel.Region = New Region(path)
    End Sub
    Private Sub RoundPanel5(panel As Panel)
        Dim path As New GraphicsPath()
        path.AddRectangle(New Rectangle(0, 0, panel.Width, panel.Height))
        panel.Region = New Region(path)
    End Sub

    Private Sub CapNhatGiaoDien(Nhom As Integer)
        Try
            NhomNow(Nhom) = True
            If pnl_BT1.Visible = True Or Nhom = 1 Then
                pnl_BT1.Location = New Point(2, 40)
                pnl_BT1.Size = New Size((((SoLuongBTofNhom(1) - 1) \ 16) + 1) * 296, 853)
                pnl_BT1.Visible = True
                RoundPanel(pnl_NhomTong1, 22)
                RoundPanel1(pnl_BT1, 40)
                pnl_NhomTong1.Location = New Point(2, 2)
                pnl_NhomTong1.Size = New Size(pnl_BT1.Width, 41)
                pnl_NhomTong1.Visible = True
            End If
            If pnl_BT2.Visible = True Or Nhom = 2 Then

                pnl_BT2.Location = New Point(pnl_BT1.Width + 2, 40)
                pnl_BT2.Size = New Size((((SoLuongBTofNhom(2) - 1) \ 16) + 1) * 296, 853)
                pnl_BT2.Visible = True

                pnl_NhomTong2.Location = New Point(pnl_BT1.Width + 2, 2)
                pnl_NhomTong2.Size = New Size(pnl_BT2.Width, 41)
                pnl_NhomTong2.Visible = True

                If pnl_NhomTong2.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong2, 22)
                    RoundPanel1(pnl_BT2, 40)
                Else
                    RoundPanel5(pnl_NhomTong2)
                    RoundPanel5(pnl_BT2)
                End If
            End If
            If pnl_BT3.Visible = True Or Nhom = 3 Then

                pnl_BT3.Location = New Point(pnl_BT2.Width + pnl_BT1.Width + 2, 40)
                pnl_BT3.Size = New Size((((SoLuongBTofNhom(3) - 1) \ 16) + 1) * 296, 853)
                pnl_BT3.Visible = True

                pnl_NhomTong3.Location = New Point(pnl_BT2.Width + pnl_BT1.Width + 2, 2)
                pnl_NhomTong3.Size = New Size(pnl_BT3.Width, 41)
                pnl_NhomTong3.Visible = True
                If pnl_NhomTong3.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong3, 22)
                    RoundPanel1(pnl_BT3, 40)
                Else
                    RoundPanel5(pnl_NhomTong3)
                    RoundPanel5(pnl_BT3)
                End If
            End If
            If pnl_BT4.Visible = True Or Nhom = 4 Then

                pnl_BT4.Location = New Point(pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width + 2, 40)
                pnl_BT4.Size = New Size((((SoLuongBTofNhom(4) - 1) \ 16) + 1) * 296, 853)
                pnl_BT4.Visible = True

                pnl_NhomTong4.Location = New Point(pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width + 2, 2)
                pnl_NhomTong4.Size = New Size(pnl_BT4.Width, 41)
                pnl_NhomTong4.Visible = True
                If pnl_NhomTong4.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong4, 22)
                    RoundPanel1(pnl_BT4, 40)
                Else
                    RoundPanel5(pnl_NhomTong4)
                    RoundPanel5(pnl_BT4)
                End If
            End If
            If pnl_BT5.Visible = True Or Nhom = 5 Then

                pnl_BT5.Location = New Point(pnl_BT4.Width + pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width + 2, 40)
                pnl_BT5.Size = New Size(((((SoLuongBTofNhom(5) - 1) \ 16) + 1) * 296) - 1, 853)
                pnl_BT5.Visible = True
                pnl_NhomTong5.Location = New Point(pnl_BT4.Width + pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width + 2, 2)
                pnl_NhomTong5.Size = New Size((pnl_BT5.Width), 39)
                pnl_NhomTong5.Visible = True
                If pnl_NhomTong5.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong5, 22)
                    RoundPanel1(pnl_BT5, 40)
                Else
                    RoundPanel2(pnl_NhomTong5, 22)
                    RoundPanel3(pnl_BT5, 40)
                    If pnl_NhomTong5.Location.X < 1135 Then
                        RoundPanel5(pnl_NhomTong5)
                        RoundPanel5(pnl_BT5)
                    End If
                End If
            End If
            '-------'
            If pnl_BT6.Visible = True Or Nhom = 6 Then

                pnl_BT6.Location = New Point(0, 40)
                pnl_BT6.Size = New Size((((SoLuongBTofNhom(6) - 1) \ 16) + 1) * 296, 853)
                pnl_BT6.Visible = True
                RoundPanel(pnl_NhomTong6, 22)
                RoundPanel1(pnl_BT6, 40)
                pnl_NhomTong6.Location = New Point(0, 1)
                pnl_NhomTong6.Size = New Size(pnl_BT6.Width, 41)
                pnl_NhomTong6.Visible = True

            End If
            If pnl_BT7.Visible = True Or Nhom = 7 Then

                pnl_BT7.Location = New Point(pnl_BT6.Width, 40)
                pnl_BT7.Size = New Size((((SoLuongBTofNhom(7) - 1) \ 16) + 1) * 296, 853)
                pnl_BT7.Visible = True

                pnl_NhomTong7.Location = New Point(pnl_BT6.Width, 2)
                pnl_NhomTong7.Size = New Size(pnl_BT7.Width, 41)
                pnl_NhomTong7.Visible = True

                If pnl_NhomTong7.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong7, 22)
                    RoundPanel1(pnl_BT7, 40)
                Else
                    RoundPanel5(pnl_NhomTong7)
                    RoundPanel5(pnl_BT7)
                End If
            End If
            If pnl_BT8.Visible = True Or Nhom = 8 Then

                pnl_BT8.Location = New Point(pnl_BT7.Width + pnl_BT6.Width, 40)
                pnl_BT8.Size = New Size((((SoLuongBTofNhom(8) - 1) \ 16) + 1) * 296, 853)
                pnl_BT8.Visible = True

                pnl_NhomTong8.Location = New Point(pnl_BT7.Width + pnl_BT6.Width, 2)
                pnl_NhomTong8.Size = New Size(pnl_BT8.Width, 41)
                pnl_NhomTong8.Visible = True

                If pnl_NhomTong8.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong8, 22)
                    RoundPanel1(pnl_BT8, 40)
                Else
                    RoundPanel5(pnl_NhomTong8)
                    RoundPanel5(pnl_BT8)
                End If
            End If
            If pnl_BT9.Visible = True Or Nhom = 9 Then

                pnl_BT9.Location = New Point(pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 40)
                pnl_BT9.Size = New Size((((SoLuongBTofNhom(9) - 1) \ 16) + 1) * 296, 853)
                pnl_BT9.Visible = True

                pnl_NhomTong9.Location = New Point(pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 2)
                pnl_NhomTong9.Size = New Size(pnl_BT9.Width, 41)
                pnl_NhomTong9.Visible = True

                If pnl_NhomTong9.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong9, 22)
                    RoundPanel1(pnl_BT9, 40)
                Else
                    RoundPanel5(pnl_NhomTong9)
                    RoundPanel5(pnl_BT9)
                End If
            End If
            If pnl_BT10.Visible = True Or Nhom = 10 Then

                pnl_BT10.Location = New Point(pnl_BT9.Width + pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 40)
                pnl_BT10.Size = New Size((((SoLuongBTofNhom(10) - 1) \ 16) + 1) * 296, 853)
                pnl_BT10.Visible = True

                pnl_NhomTong10.Location = New Point(pnl_BT9.Width + pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 2)
                pnl_NhomTong10.Size = New Size(pnl_BT10.Width, 41)
                pnl_NhomTong10.Visible = True

                If pnl_NhomTong10.Location.X < 10 Then
                    RoundPanel(pnl_NhomTong10, 22)
                    RoundPanel1(pnl_BT10, 40)
                Else
                    RoundPanel2(pnl_NhomTong10, 22)
                    RoundPanel3(pnl_BT10, 40)
                    If pnl_NhomTong10.Location.X < 1135 Then
                        RoundPanel5(pnl_NhomTong10)
                        RoundPanel5(pnl_BT10)
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
    Public buttonNameVariable As String
    Private Sub pictureBox1_DoubleClick(sender As Object, e As EventArgs)
        Try
            dem2()
            Dim pictureBox As PictureBox = TryCast(sender, PictureBox)
            Dim BitID As String = pictureBox.Name.Substring(3)
            Dim buttonName As String = "Lab" & BitID
            Dim targetButton As Label = Me.Controls.Find(buttonName, True).FirstOrDefault()
            If targetButton IsNot Nothing Then
                buttonNameVariable = targetButton.Text
                RaiseEvent BitTongToMain(Me, BitID)
            End If
        Catch
        End Try
    End Sub
    Private Sub LoadTrang(Trang As String)
        Try
            pnl_DoiTen.Visible = False
            pnl_DoiTen.Location = New Point(1097, 75)
            Dim fileName As String = "TBitTong" + Trang + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes("/BitTongData/Bit") ' Lấy tất cả các phần tử <Bit> từ tài liệu XML
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
#End Region
#Region "Nút Nhấn"

    Private Sub ThemBitDS()
        Try
            If ThemBit < 80 Then
                ThemBit += 1
                Dim buttonName As String = "button" & ThemBit
                Dim labelName As String = "label" & ThemBit
                Dim pictureBoxName As String = "pictureBox" & ThemBit

                Dim controls As Control() = Me.Controls.Find(buttonName, True)
                If controls.Length > 0 AndAlso TypeOf controls(0) Is Button Then
                    Dim button As Button = DirectCast(controls(0), Button)
                    button.Visible = True
                End If

                Dim controls_1 As Control() = Me.Controls.Find(labelName, True)
                If controls_1.Length > 0 AndAlso TypeOf controls_1(0) Is Label Then
                    Dim label As Label = DirectCast(controls_1(0), Label)
                    label.Visible = True
                End If

                Dim controls_2 As Control() = Me.Controls.Find(pictureBoxName, True)
                If controls_2.Length > 0 AndAlso TypeOf controls_2(0) Is PictureBox Then
                    Dim pictureBox As PictureBox = DirectCast(controls_2(0), PictureBox)
                    pictureBox.Visible = True
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XoaBitDS()
        Try
            If ThemBit <= 80 Then
                Dim buttonName As String = "button" & ThemBit
                Dim labelName As String = "label" & ThemBit
                Dim pictureBoxName As String = "pictureBox" & ThemBit

                Dim controls As Control() = Me.Controls.Find(buttonName, True)
                If controls.Length > 0 AndAlso TypeOf controls(0) Is Button Then
                    Dim button As Button = DirectCast(controls(0), Button)
                    button.Visible = False
                End If

                Dim controls_1 As Control() = Me.Controls.Find(labelName, True)
                If controls_1.Length > 0 AndAlso TypeOf controls_1(0) Is Label Then
                    Dim label As Label = DirectCast(controls_1(0), Label)
                    label.Visible = False
                End If

                Dim controls_2 As Control() = Me.Controls.Find(pictureBoxName, True)
                If controls_2.Length > 0 AndAlso TypeOf controls_2(0) Is PictureBox Then
                    Dim pictureBox As PictureBox = DirectCast(controls_2(0), PictureBox)
                    pictureBox.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub button1_MouseDown(sender As Object, e As MouseEventArgs)
        Try

            Dim button As Button = TryCast(sender, Button)

            Bitid = button.Name.Substring(6)

            If SoLanNhan <= 2 Then
                SoLanNhan += 1
                If SoLanNhan = 2 Then
                    KiemTra = True
                Else
                    KiemTra = False
                End If
            End If

            Dim fileName1 As String = "TBitTong1.xml"
            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath1)
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bitid}']/Name")
            If bitNode IsNot Nothing Then
                TenBit = bitNode.InnerText
            End If
            ID = button.Name.Substring(button.Name.IndexOf("_") + 1) - 1
            IDC = button.Name.Substring(6, button.Name.IndexOf("_") - 6)
            Task.Run(Sub() Chon(button, e))
        Catch ex As Exception
        End Try
    End Sub


    Private Async Sub Chon(button As Button, e As MouseEventArgs)
        Try
            Await Task.Delay(waitTime)
            If SoLanNhan = 1 Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath, "ON.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Blue
                    TrangThai = 1

                ElseIf button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                    TrangThai = 0

                End If
            ElseIf SoLanNhan >= 2 And KiemTra = True Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath, "BLYNK.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Red
                    TrangThai = 2

                ElseIf button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                    TrangThai = 0
                End If
            End If

            DocGTBitTong()
            SoLanNhan = 0
            If TrangThai = 0 Then
                RaiseEvent BitTongToSerial(Me, "0_" + hex)
                RaiseEvent BitTongTo3DmapTP(Me, "0_" + Bitid.ToString())
            ElseIf TrangThai = 1 Then
                RaiseEvent BitTongToSerial(Me, "1_" + hex)
                RaiseEvent BitTongTo3DmapTP(Me, "1_" + Bitid.ToString())
            ElseIf TrangThai = 2 Then
                RaiseEvent BitTongToSerial(Me, "2_" + hex)
                RaiseEvent BitTongTo3DmapTP(Me, "2_" + Bitid.ToString())
            End If

            TrangThai = 0
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
                Dim TenTrang As String = "btn_Trang1"
                Dim button1 As Button = Me.Controls.Find(TenTrang, True).FirstOrDefault()
                Dim ten As String = $"Lab{Bitid}"
                Dim tenlabel As Label = Me.Controls.Find(ten, True).FirstOrDefault()
                If Status = 0 Then
                    If DanhSachTenBit.Contains(TenBit) Then
                        DanhSachTenBit.Remove(TenBit)
                    End If
                    dataString(ID) = "0"c
                    dataString1(ID + (IDC - 1) * 16) = "0"c

                ElseIf Status = 1 Then

                    dataString(ID) = "1"c
                    If Thembittong1 = 0 Then
                        Dim fileName1 As String = "TBitTong1.xml"
                        Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                        Dim xmlDoc As New XmlDocument()
                        xmlDoc.Load(filePath1)
                        Dim modifiedVariable As String = String.Empty
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bitid}']/Data")
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
                    If tenlabel.Text <> "Bit tổng" Then
                        dataString1(ID + (IDC - 1) * 16) = "1"c
                        If Not DanhSachTenBit.Contains(TenBit) Then
                            DanhSachTenBit.Add(TenBit)
                        End If
                    Else
                        MessageBox.Show("Vui lòng đổi tên đối tượng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                        Dim newImage As Image = Image.FromFile(filePath)
                        button.Image = newImage
                        button.ForeColor = Color.White
                    End If

                ElseIf Status = 2 Then
                    If Not DanhSachTenBit.Contains(TenBit) Then
                        DanhSachTenBit.Add(TenBit)
                    End If

                    dataString(ID) = "2"c
                    If Thembittong1 = 0 Then
                        Dim fileName1 As String = "TBitTong1.xml"
                        Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                        Dim xmlDoc As New XmlDocument()
                        xmlDoc.Load(filePath1)
                        Dim modifiedVariable As String = String.Empty
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bitid}']/Data")
                        If bitNode IsNot Nothing Then
                            Dim variableToStoreData As String = bitNode.InnerText
                            For index As Integer = 0 To variableToStoreData.Length - 1
                                If variableToStoreData(index) = "1"c Then
                                    modifiedVariable &= "2"
                                Else
                                    modifiedVariable &= variableToStoreData(index)
                                End If
                            Next
                            bitNode.InnerText = modifiedVariable
                            xmlDoc.Save(filePath1)
                        End If
                    End If

                    If tenlabel.Text <> "Bit tổng" Then
                        dataString1(ID + (IDC - 1) * 16) = "2"c
                    Else
                        MessageBox.Show("Vui lòng đổi tên đối tượng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                        Dim newImage As Image = Image.FromFile(filePath)
                        button.Image = newImage
                        button.ForeColor = Color.White
                    End If
                End If
            End If
            dataString2 = dataString1

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
                    BitCanhNode.InnerText = String.Join(",", DanhSachTenBit.ToArray())
                    Console.WriteLine(BitCanhNode.InnerText)
                End If
                If dataNode IsNot Nothing Then
                    dataNode.InnerText = dataString
                    xmlDoc.Save(filePath)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DocGTBitTong()
        Try
            Dim fileName1 As String = "TBitTong1.xml"
            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath1)
            Dim modifiedVariable As String = String.Empty
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bitid}']/Data")
            If bitNode IsNot Nothing Then
                Dim variableToStoreData As String = bitNode.InnerText
                'MessageBox.Show($"Data:" & variableToStoreData)
                Dim hexList As List(Of String) = Enumerable.Range(0, variableToStoreData.Length \ 8) _
                    .Select(Function(i) variableToStoreData.Substring(8 * i, 8)) _
                    .Select(Function(s) Convert.ToByte(s, 2)) _
                    .Select(Function(b) b.ToString("X2")) _
                    .ToList()
                hex = String.Concat(hexList)

            End If

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

    Private Sub btn_DoiTen_Click(sender As Object, e As EventArgs) Handles btn_DoiTen.Click
        Try
            If tb_DoiTenBit.Text <> "" Then
                If tb_DoiTenBit.Text.Length < 19 Then
                    Dim TenBit As String = TenBitTong + ": " + tb_DoiTenBit.Text
                    Dim label As Label = Me.Controls.Find(BitDoiTen, True).FirstOrDefault()
                    label.ForeColor = Color.Black
                    Dim numberPart As String = New String(label.Name.Where(Function(c) Char.IsDigit(c)).ToArray())
                    Dim number As Integer
                    If Integer.TryParse(numberPart, number) Then
                        If label IsNot Nothing Then
                            label.Text = TenBit
                            Dim TenTrang As String = "btn_Trang1"
                            Dim fileName As String = "TBitTong1.xml"
                            Dim filePath As String = Path.Combine(folderPath1, fileName)
                            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
                            xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
                            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{number}']")
                            If bitNode IsNot Nothing Then
                                Dim nameNode As XmlNode = bitNode.SelectSingleNode("Name") ' Tìm phần tử <Name> trong <Bit>
                                If nameNode IsNot Nothing Then
                                    nameNode.InnerText = TenBit ' Ghi giá trị mới vào phần tử <Name>
                                    xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                                    pnl_DoiTen.Visible = False
                                    pnl_DoiTen.Location = New Point(1097, 75)
                                End If
                            End If
                        End If
                    End If
                Else
                    MessageBox.Show("Tên đối tượng không được vượt quá 19", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    tb_DoiTenBit.Focus()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_Trang1_Click(sender As Object, e As EventArgs) Handles btn_Trang1.Click
        Try
            pnl_TrangBitTong1.BringToFront()
            btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
            pnl_TrangBitTong2.SendToBack()
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
        Catch
        End Try
    End Sub
    Private Sub btn_Trang2_Click(sender As Object, e As EventArgs) Handles btn_Trang2.Click
        Try
            pnl_TrangBitTong2.BringToFront()
            btn_Trang2.BackColor = Color.FromArgb(0, 117, 227)
            pnl_TrangBitTong1.SendToBack()
            btn_Trang1.BackColor = Color.White
            btn_Trang1.ForeColor = Color.Black
        Catch
        End Try
    End Sub

    Private Sub btn_XuatDSB_Click(sender As Object, e As EventArgs) Handles btn_XuatDSB.Click
        Try
            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Chọn vị trí lưu thư mục Bit Tổng"
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFolderPath As String = folderBrowserDialog.SelectedPath
                Dim bitDonFolderPath As String = Path.Combine(selectedFolderPath, "BitTong")
                If Not Directory.Exists(bitDonFolderPath) Then
                    Directory.CreateDirectory(bitDonFolderPath)
                End If
                For i As Integer = 1 To 2
                    Dim sourceFilePath As String = Path.Combine(folderPath1, $"TBitTong{i}.xml")
                    Dim destinationFilePath As String = Path.Combine(bitDonFolderPath, $"TBitTong{i}.xml")
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
                LoadDataXml("1")
                LoadTrang(Trang)
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Reset DataString"
    Private Sub ResetDataString()
        Try
            For i As Integer = 0 To dataString.Length - 1
                dataString(i) = "0"c
            Next
        Catch
        End Try
    End Sub
    Private Sub ResetDataString1()
        Try
            For i As Integer = 0 To dataString.Length - 1
                dataString1(i) = "0"c
            Next
        Catch
        End Try
    End Sub

#End Region
#Region "Truyền Main"
#End Region
#Region "Hàm con"
    Public Sub TTALL(data As Integer)
        Try
            For i As Integer = 1 To 10
                For j As Integer = 1 To 16
                    Dim StatusBit As String = $"Button{i}_{j}"
                    Dim button As Button = Me.Controls.Find(StatusBit, True).FirstOrDefault()

                    If button IsNot Nothing Then
                        Select Case data
                            Case 0
                                UpdateButtonState(button, Path.Combine(folderPath, "OFF.PNG"), Color.White, 0)
                            Case 1
                                UpdateButtonState(button, Path.Combine(folderPath, "ON.PNG"), Color.Blue, 1)
                            Case 2
                                UpdateButtonState(button, Path.Combine(folderPath, "BLYNK.PNG"), Color.Red, 2)
                        End Select
                    End If
                Next
                Dim buttonName As String = $"btn_NhomBit{i}"
                Dim button1 As Button = Me.Controls.Find(buttonName, True).FirstOrDefault()

                If button1 IsNot Nothing Then
                    Select Case data
                        Case 0
                            UpdateButtonState(button1, Path.Combine(folderPath, "OFF.PNG"), Color.White, 0)
                        Case 1
                            UpdateButtonState(button1, Path.Combine(folderPath, "ON.PNG"), Color.Blue, 1)
                        Case 2
                            UpdateButtonState(button1, Path.Combine(folderPath, "BLYNK.PNG"), Color.Red, 2)
                    End Select
                End If
            Next
        Catch
        End Try
    End Sub
    Public Sub KichBanCanhToMain(data As String)
        Try

            ResetDataString()
            SoLanNhan = 0
            ThemBitTong = 0
            btn_ThemBiTong.Location = New Point(1149, 6)
            btn_ThemDSB.Visible = False
            btn_XuatDSB.Visible = False
            btn_XacNhan.Location = New Point(1290, 10)
            btn_XacNhan.Visible = True
            Thembittong1 = 0
            label81.Text = "Tên Cảnh   "
            tb_DoiTenBit.Text = ""

            TenKichBan = data
            Dim DuLieu As String() = data.Split(",")
            If DuLieu.Length >= 2 Then
                TenKichBanCanh = DuLieu(0)
                TenKichBan = DuLieu(1)
            End If
            Label82.Text = "Tên Cảnh: " + TenKichBanCanh

        Catch ex As Exception
        End Try
    End Sub
    Public Sub MainKichBanToBitTong(data As String)
        Try
            TTALL(0)
            ResetDataString()
            SoLanNhan = 0
            FrmSBVLM.Instance.tb_truyen.Text = "10"
            btn_ThemDSB.Visible = False
            btn_XuatDSB.Visible = False
            btn_ThemBiTong.Visible = False
            btn_XacNhan.Location = New Point(1290, 10)
            btn_XacNhan.Visible = True
            pnl_DoiTen.Visible = True
            pnl_DoiTen.Size = New Size(304, 56)
            pnl_DoiTen.Location = New Point(1174, 76)
            label81.Text = "Tên Cảnh   "
            tb_DoiTenBit.Text = ""
            Label82.Text = "Kịch Bản: " + data
            TenKichBan = data
            Thembittong1 = 0


        Catch ex As Exception
        End Try
    End Sub
    Public Sub MainBitTong()
        Try
            btn_ThemBiTong.Location = New Point(914, 10)
            btn_ThemBiTong.Visible = True

            Label82.Text = "Danh Sách Đối Tượng Tổng"
            Thembittong1 = 1
            FrmSBVLM.Instance.themcanhtong1 = 1
        Catch ex As Exception
        End Try
    End Sub
    Public Sub KichBanCanhToMain1(data As String)
        Try
            ResetDataString()
            ResetDataString1()
            SoLanNhan = 0
            FrmSBVLM.Instance.tb_truyen.Text = "11"

            btn_ThemDSB.Visible = False
            btn_XuatDSB.Visible = False
            btn_XacNhan.Location = New Point(1290, 10)
            btn_XacNhan.Visible = True
            Dim DuLieu As String() = data.Split(",")
            If DuLieu.Length >= 2 Then
                TenKichBanCanh = DuLieu(0)
                TenKichBan = DuLieu(1)
            End If
            Label82.Text = "Tên Cảnh: " + TenKichBanCanh
            LoadGTKichBan()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub resetkb()
        DanhSachTenBit.Clear()
    End Sub
    Public Sub LoadGTKichBan()
        Try

            Dim so As Integer = 0
            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']/Dataall")
                For Each bitNode As XmlNode In bitNodes
                    Dim DataValue As String = bitNode.InnerText
                    For i As Integer = 0 To DataValue.Length - 1
                        If DataValue(i) = "1"c Then
                            dataString1(i) = "1"c
                            If i >= 0 AndAlso i <= 160 Then
                                If btn_Trang1.ForeColor = Color.White Then

                                    so = (i Mod 16)
                                    Dim sodem As Integer = (i \ 16) + 1
                                    sodem = Math.Min(sodem, 10)
                                    Dim Ten As String = $"Button{sodem}_" & (so + 1).ToString()
                                    Dim Button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    Dim fileName2 As String = "TBitTong1.xml"
                                    Dim filePath2 As String = Path.Combine(folderPath1, fileName2)
                                    Dim xmlDoc2 As New XmlDocument()
                                    xmlDoc2.Load(filePath2)
                                    Dim bitNode2 As XmlNode = xmlDoc2.SelectSingleNode($"//BitTongData/Bit[@ID='{sodem}_{(so + 1).ToString()}']/Name")
                                    If bitNode2 IsNot Nothing Then
                                        TenBit = bitNode2.InnerText
                                    End If
                                    If Button IsNot Nothing Then
                                        Dim fileName1 As String = "ON.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        Button.Image = newImage
                                        Button.ForeColor = Color.Blue
                                        DanhSachTenBit.Add(TenBit)
                                    End If
                                End If
                            End If


                        End If
                        If DataValue(i) = "2"c Then
                            dataString1(i) = "2"c
                            If i >= 0 AndAlso i <= 160 Then
                                If btn_Trang1.ForeColor = Color.White Then
                                    so = (i Mod 16)
                                    Dim sodem As Integer = (i \ 16) + 1
                                    sodem = Math.Min(sodem, 10)
                                    Dim Ten As String = $"Button{sodem}_" & (so).ToString()
                                    Dim button As Button = Me.Controls.Find(Ten, True).FirstOrDefault()
                                    Dim fileName2 As String = "TBitTong1.xml"
                                    Dim filePath2 As String = Path.Combine(folderPath1, fileName2)
                                    Dim xmlDoc2 As New XmlDocument()
                                    xmlDoc2.Load(filePath2)
                                    Dim bitNode2 As XmlNode = xmlDoc2.SelectSingleNode($"//BitTongData/Bit[@ID='{sodem}_{so}']/Name")
                                    Dim bitNode3 As XmlNode = xmlDoc2.SelectSingleNode($"//BitTongData/Bit[@ID='{sodem}_{so}']/Data")

                                    If bitNode2 IsNot Nothing Then
                                        TenBit = bitNode2.InnerText
                                    End If

                                    If bitNode3 IsNot Nothing Then
                                        Dim variableToStoreData As String = bitNode3.InnerText
                                        Dim modifiedVariable As String = variableToStoreData.Replace("1"c, "2")
                                        bitNode3.InnerText = modifiedVariable
                                        xmlDoc2.Save(filePath2)
                                    End If
                                    If button IsNot Nothing Then
                                        Dim fileName1 As String = "BLYNK.PNG"
                                        Dim filePath1 As String = Path.Combine(folderPath, fileName1)
                                        Dim newImage As Image = Image.FromFile(filePath1)
                                        button.Image = newImage
                                        button.ForeColor = Color.Red
                                        DanhSachTenBit.Add(TenBit)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next
            End If
            dataString2 = dataString1
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_XacNhan_Click(sender As Object, e As EventArgs) Handles btn_XacNhan.Click
        Try
            If FrmSBVLM.Instance.tb_truyen.Text = "10" And pnl_DoiTen.Visible = True Then
                FrmSBVLM.Instance.truyenkb()
                If FrmSBVLM.Instance.doiten = 0 Then
                    XNKichBan()
                    ResetDataString1()
                    ResetDataString()

                    DanhSachTenBit.Clear()
                ElseIf FrmSBVLM.Instance.doiten = 1 Then
                    MessageBox.Show("Tên này đã tồn tại trong danh sách. Vui lòng nhập một tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

            If FrmSBVLM.Instance.tb_truyen.Text = "01" Then
                XNKichBanCanh()
                ResetDataString1()
                ResetDataString()
                DanhSachTenBit.Clear()
            End If
            DataString3 = ""
            dem2()
        Catch eX As Exception
        End Try
    End Sub
    Private Sub dem2()
        Try
            Dim fileName1 As String = "TBitTong1.xml"
            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath1)
            Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes("/BitTongData/Bit") ' Lấy tất cả các phần tử <Bit> từ tài liệu XML
            For Each bitNode As XmlNode In bitNodes
                Dim DataNode As XmlNode = bitNode.SelectSingleNode("Data")
                Dim DataValue As String = DataNode.InnerText
                Dim modifiedVariable As String = String.Empty
                For i As Integer = 0 To DataValue.Length - 1
                    If DataValue(i) = "2"c Then
                        modifiedVariable &= "1"c
                    Else
                        modifiedVariable &= DataValue(i)
                    End If
                Next
                DataNode.InnerText = modifiedVariable
            Next
            xmlDoc.Save(filePath1)
        Catch
        End Try
    End Sub
    Private Sub XNKichBanCanh()
        Try
            If FrmSBVLM.Instance.tb_truyen.Text = "01" Then
                LuuGTKichBanCanh()
                btn_ThemDSB.Visible = True
                btn_XuatDSB.Visible = True
                btn_XacNhan.Location = New Point(867, 10)
                btn_XacNhan.Visible = False
                btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
                btn_Trang1.ForeColor = Color.White
                btn_Trang2.BackColor = Color.White
                btn_Trang2.ForeColor = Color.Black
                Trang = "1"
                LoadTrang(Trang)
                FrmSBVLM.Instance.ThemCanh = 0
                TTALL(0)
                RaiseEvent BitTongKichBanToMain(Me, "xong")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LuuGTKichBanCanh()
        Try
            Dim ketQuaCat As String
            ketQuaCat = DataString3
            Dim fileName2 As String = TenKichBan + ".xml"
            Dim filePath2 As String = Path.Combine(folderPath1, fileName2)
            Dim xmlDoc2 As New XmlDocument()
            xmlDoc2.Load(filePath2)
            Dim bitNode2 As XmlNode = xmlDoc2.SelectSingleNode($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']/Dataall")
            If bitNode2 IsNot Nothing Then
                bitNode2.InnerText = dataString2

            End If
            xmlDoc2.Save(filePath2)
            Dim bitNode3 As XmlNode = xmlDoc2.SelectSingleNode($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']/Data")
            Dim data As String = bitNode3.InnerText
            Dim fileName1 As String = "TBitTong1.xml"
            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
            Dim xmlDoc1 As New XmlDocument()
            xmlDoc1.Load(filePath1)
            Dim variableToStoreData As String
            Dim modifiedVariable As String = String.Empty
            For Each tenBit As String In DanhSachTenBit

                Dim bitNode As XmlNode = xmlDoc1.SelectSingleNode($"//Bit[Name='{tenBit}']/Data")
                If bitNode IsNot Nothing Then
                    variableToStoreData = bitNode.InnerText
                    For i As Integer = 0 To variableToStoreData.Length - 1
                        Dim hasOne As Boolean = False
                        Dim hasTwo As Boolean = False
                        Dim haszero As Boolean = False
                        For Each otherTenBit As String In DanhSachTenBit
                            If otherTenBit <> tenBit Then
                                Dim otherBitNode As XmlNode = xmlDoc1.SelectSingleNode($"//Bit[Name='{otherTenBit}']/Data")
                                If otherBitNode IsNot Nothing AndAlso otherBitNode.InnerText.Length > i Then
                                    If otherBitNode.InnerText(i) = "1"c Then
                                        hasOne = True
                                    ElseIf otherBitNode.InnerText(i) = "2"c Then
                                        hasTwo = True
                                    ElseIf otherBitNode.InnerText(i) = "0"c Then
                                        haszero = True
                                    End If

                                End If
                            End If
                        Next

                        If hasTwo Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "1"c AndAlso hasTwo Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "1"c AndAlso hasOne Then
                            modifiedVariable &= "1"
                        ElseIf variableToStoreData(i) = "1"c AndAlso haszero Then
                            modifiedVariable &= "1"
                        ElseIf variableToStoreData(i) = "0"c AndAlso hasOne Then
                            modifiedVariable &= "1"
                        ElseIf variableToStoreData(i) = "0"c AndAlso haszero Then
                            modifiedVariable &= "0"
                        ElseIf variableToStoreData(i) = "0"c AndAlso hasTwo Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "2"c AndAlso haszero Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "2"c AndAlso hasOne Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "2"c AndAlso hasTwo Then
                            modifiedVariable &= "2"
                        End If
                    Next
                End If
            Next
            If ketQuaCat = "" Then
                If DanhSachTenBit.Count = 1 Then
                    ketQuaCat = variableToStoreData
                ElseIf DanhSachTenBit.Count > 1 Then
                    ketQuaCat = modifiedVariable.Substring(0, 319)
                ElseIf DanhSachTenBit.Count = 0 Then
                    ketQuaCat = data
                End If
            End If
            If DanhSachTenBit.Count <> 0 Or FrmSBVLM.Instance.tb_truyen.Text = "01" Then
                Dim fileName As String = TenKichBan + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)

                If File.Exists(filePath) Then
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath)
                    Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']")
                    If bitNode IsNot Nothing Then
                        Dim BitCanhNode As XmlNode = bitNode.SelectSingleNode("BitCanh")
                        If BitCanhNode IsNot Nothing Then
                            BitCanhNode.InnerText = String.Join(",", DanhSachTenBit.ToArray())
                        End If
                        Dim DataNode As XmlNode = bitNode.SelectSingleNode("Data")
                        If DataNode IsNot Nothing Then
                            DataNode.InnerText = ketQuaCat
                        End If
                    End If
                    xmlDoc.Save(filePath)
                    RaiseEvent BitTongToMain(Me, "KichBan")
                End If
            End If
            DanhSachTenBit.Clear()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub XNKichBan()
        Try
            If tb_DoiTenBit.Text <> "" Then
                LuuGTKichBan()
            End If
            btn_ThemDSB.Visible = True
            btn_XuatDSB.Visible = True
            btn_XacNhan.Location = New Point(867, 10)
            btn_XacNhan.Visible = False
            btn_Trang1.BackColor = Color.FromArgb(0, 117, 227)
            btn_Trang1.ForeColor = Color.White
            btn_Trang2.BackColor = Color.White
            btn_Trang2.ForeColor = Color.Black
            Trang = "1"
            LoadTrang(Trang)
            FrmSBVLM.Instance.ThemCanh = 0
            pnl_DoiTen.Visible = False
            pnl_DoiTen.Size = New Size(378, 56)
            pnl_DoiTen.Location = New Point(1049, 75)
            label81.Text = "Đổi Tên Bit"
            tb_DoiTenBit.Text = ""
            TTALL(0)

            RaiseEvent BitTongKichBanToMain(Me, "xong")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LuuGTKichBan()
        Try
            Dim ketQuaCat As String
            ketQuaCat = DataString3
            Dim fileName2 As String = TenKichBan + ".xml"
            Dim filePath2 As String = Path.Combine(folderPath1, fileName2)
            Dim xmlDoc2 As New XmlDocument()
            xmlDoc2.Load(filePath2)

            Dim bitNode2 As XmlNode = xmlDoc2.SelectSingleNode($"/KichBan/TenCanh[@ID='{TenKichBanCanh}']/Dataall")
            If bitNode2 IsNot Nothing Then
                bitNode2.InnerText = dataString2
            End If
            xmlDoc2.Save(filePath2)
            Dim fileName1 As String = "TBitTong1.xml"
            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath1)
            Dim variableToStoreData As String
            Dim modifiedVariable As String = String.Empty
            For Each tenBit As String In DanhSachTenBit
                Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//Bit[Name='{tenBit}']/Data")
                If bitNode IsNot Nothing Then
                    variableToStoreData = bitNode.InnerText

                    For i As Integer = 0 To variableToStoreData.Length - 1
                        Dim hasOne As Boolean = False
                        Dim hasTwo As Boolean = False
                        Dim haszero As Boolean = False
                        For Each otherTenBit As String In DanhSachTenBit
                            If otherTenBit <> tenBit Then
                                Dim otherBitNode As XmlNode = xmlDoc.SelectSingleNode($"//Bit[Name='{otherTenBit}']/Data")
                                If otherBitNode IsNot Nothing AndAlso otherBitNode.InnerText.Length > i Then
                                    If otherBitNode.InnerText(i) = "1"c Then
                                        hasOne = True
                                    ElseIf otherBitNode.InnerText(i) = "2"c Then
                                        hasTwo = True
                                    ElseIf otherBitNode.InnerText(i) = "0"c Then
                                        haszero = True
                                    End If
                                End If
                            End If
                        Next
                        If hasTwo Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "1"c AndAlso hasTwo Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "1"c AndAlso hasOne Then
                            modifiedVariable &= "1"
                        ElseIf variableToStoreData(i) = "1"c AndAlso haszero Then
                            modifiedVariable &= "1"
                        ElseIf variableToStoreData(i) = "0"c AndAlso hasOne Then
                            modifiedVariable &= "1"
                        ElseIf variableToStoreData(i) = "0"c AndAlso haszero Then
                            modifiedVariable &= "0"
                        ElseIf variableToStoreData(i) = "0"c AndAlso hasTwo Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "2"c AndAlso haszero Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "2"c AndAlso hasOne Then
                            modifiedVariable &= "2"
                        ElseIf variableToStoreData(i) = "2"c AndAlso hasTwo Then
                            modifiedVariable &= "2"
                        End If
                    Next
                End If
            Next
            If ketQuaCat = "" Then
                If DanhSachTenBit.Count = 1 Then
                    ketQuaCat = variableToStoreData ' Nếu chỉ có một chuỗi variableToStoreData
                Else
                    ketQuaCat = modifiedVariable.Substring(0, 319)
                End If
            End If

            If DanhSachTenBit.Count <> 0 Then
                Dim fileName As String = TenKichBan + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)
                Dim mangChuoi As String() = DanhSachTenBit.ToArray()

                If File.Exists(filePath) Then
                    Dim xmlDoc1 As New XmlDocument()
                    xmlDoc1.Load(filePath)
                    Dim nodeList As XmlNodeList = xmlDoc1.SelectNodes("//TenCanh[@ID]")
                    Dim rootElement As XmlElement = xmlDoc1.DocumentElement
                    Dim TenCanhElement As XmlElement = xmlDoc1.CreateElement("TenCanh")
                    TenCanhElement.SetAttribute("ID", tb_DoiTenBit.Text)
                    Dim bitCanhElement As XmlElement = xmlDoc1.CreateElement("BitCanh")
                    bitCanhElement.InnerText = String.Join(",", DanhSachTenBit.ToArray())
                    Dim dataElement As XmlElement = xmlDoc1.CreateElement("Data")
                    dataElement.InnerText = ketQuaCat
                    Dim locationElement As XmlElement = xmlDoc1.CreateElement("Location")
                    locationElement.InnerText = "Trống"
                    Dim dataallElement As XmlElement = xmlDoc1.CreateElement("Dataall")
                    dataallElement.InnerText = dataString1
                    TenCanhElement.AppendChild(bitCanhElement)
                    TenCanhElement.AppendChild(dataElement)
                    TenCanhElement.AppendChild(locationElement)
                    TenCanhElement.AppendChild(dataallElement)
                    rootElement.AppendChild(TenCanhElement)
                    xmlDoc1.Save(filePath)
                    DanhSachTenBit.Clear()
                    RaiseEvent BitTongToMain(Me, "KichBan")

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_ThemBiTong_Click(sender As Object, e As EventArgs) Handles btn_ThemBiTong.Click
        Try
            KiemTraGiaoDien()
            If KhoaAdd1 = 0 Or KhoaAdd2 = 0 Then
                For i As Integer = 1 To 10
                    If NhomNow(i) = False Then
                        SttNhomBitTong = i
                        NhomNow(i) = True
                        Exit For
                    End If
                Next

                If SttNhomBitTong = 1 Then
                    pnl_TrangBitTong1.BringToFront()
                    pnl_BT1.Size = New Size(296, 832)
                    pnl_BT1.Location = New Point(0, 40)
                    pnl_BT1.Visible = True
                    pnl_NhomTong1.Location = New Point(0, 0)
                    pnl_NhomTong1.Visible = True
                    pnl_NhomTong1.Size = New Size(296, 40)
                ElseIf SttNhomBitTong = 2 Then
                    pnl_BT2.Location = New Point(pnl_BT1.Width, 41)
                    pnl_BT2.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT2.Visible = True
                    pnl_NhomTong2.Location = New Point(pnl_BT1.Width, 0)
                    pnl_NhomTong2.Visible = True
                    pnl_NhomTong2.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 3 Then
                    pnl_BT3.Location = New Point(pnl_BT2.Width + pnl_BT1.Width, 41)
                    pnl_BT3.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT3.Visible = True
                    pnl_NhomTong3.Location = New Point(pnl_BT2.Width + pnl_BT1.Width, 0)
                    pnl_NhomTong3.Visible = True
                    pnl_NhomTong3.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 4 Then
                    pnl_BT4.Location = New Point(pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 41)
                    pnl_BT4.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT4.Visible = True
                    pnl_NhomTong4.Location = New Point(pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 0)
                    pnl_NhomTong4.Visible = True
                    pnl_NhomTong4.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 5 Then
                    pnl_BT5.Location = New Point(pnl_BT4.Width + pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 41)
                    pnl_BT5.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT5.Visible = True
                    pnl_NhomTong5.Location = New Point(pnl_BT4.Width + pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 0)
                    pnl_NhomTong5.Visible = True
                    pnl_NhomTong5.Size = New Size(296, 41)
                End If

                If SttNhomBitTong = 6 Then

                    pnl_BT6.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT6.Location = New Point(0, 41)
                    pnl_BT6.Visible = True

                    pnl_NhomTong6.Location = New Point(0, 0)
                    pnl_NhomTong6.Visible = True
                    pnl_NhomTong6.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 7 Then

                    pnl_BT7.Location = New Point(pnl_BT6.Width, 41)
                    pnl_BT7.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT7.Visible = True

                    pnl_NhomTong7.Location = New Point(pnl_BT6.Width, 0)
                    pnl_NhomTong7.Visible = True
                    pnl_NhomTong7.Size = New Size(296, 41)

                ElseIf SttNhomBitTong = 8 Then

                    pnl_BT8.Location = New Point(pnl_BT7.Width + pnl_BT6.Width, 41)
                    pnl_BT8.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT8.Visible = True
                    pnl_NhomTong8.Location = New Point(pnl_BT7.Width + pnl_BT6.Width, 0)
                    pnl_NhomTong8.Visible = True
                    pnl_NhomTong8.Size = New Size(296, 41)

                ElseIf SttNhomBitTong = 9 Then

                    pnl_BT9.Location = New Point(pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 41)
                    pnl_BT9.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT9.Visible = True

                    pnl_NhomTong9.Location = New Point(pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 0)
                    pnl_NhomTong9.Visible = True
                    pnl_NhomTong9.Size = New Size(296, 41)

                ElseIf SttNhomBitTong = 10 Then

                    pnl_BT10.Location = New Point(pnl_BT9.Width + pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 41)
                    pnl_BT10.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT10.Visible = True

                    pnl_NhomTong10.Location = New Point(pnl_BT9.Width + pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 0)
                    pnl_NhomTong10.Visible = True
                    pnl_NhomTong10.Size = New Size(296, 41)

                End If

                CapNhatGiaoDien(0)
            End If
        Catch
        End Try
    End Sub
    Private Sub Creat_BitTong_New_Click(sender As Object, e As EventArgs) Handles btn_ThemBitTong8.Click, btn_ThemBitTong9.Click, btn_ThemBitTong6.Click, btn_ThemBitTong7.Click, btn_ThemBitTong10.Click, btn_ThemBitTong5.Click, btn_ThemBitTong4.Click, btn_ThemBitTong3.Click, btn_ThemBitTong2.Click, btn_ThemBitTong1.Click
        Try
            Dim button As Button = TryCast(sender, Button)
            Dim Nhom As Integer = Convert.ToInt16(button.Name.Substring(15))
            If SoLuongBTofNhom(Nhom) <= 15 Then
                SoLuongBTofNhom(Nhom) += 1
                If SoLuongBTofNhom(Nhom) <> 1 And (SoLuongBTofNhom(Nhom) - 1) Mod 16 = 16 Then '17, 33 , 49 , 65
                    KiemTraGiaoDien()
                    If KhoaAdd1 = 0 Or KhoaAdd2 = 0 Then
                        CreatBitTong(SoLuongBTofNhom(Nhom), Nhom, "Bit Tổng")
                        CreatDataXmlBitTong(Nhom.ToString + "_" + SoLuongBTofNhom(Nhom).ToString)
                        CapNhatGiaoDien(0)
                    End If
                Else
                    CreatBitTong(SoLuongBTofNhom(Nhom), Nhom, "Bit Tổng")
                    CreatDataXmlBitTong(Nhom.ToString + "_" + SoLuongBTofNhom(Nhom).ToString)
                End If
            End If
        Catch ex As Exception
            'essageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub Delete_BitTong1_New_Click(sender As Object, e As EventArgs) Handles btn_TruBitTong5.Click, btn_TruBitTong4.Click, btn_TruBitTong3.Click, btn_TruBitTong2.Click, btn_TruBitTong1.Click
        Try

            Dim button As Button = TryCast(sender, Button)
            Dim Nhom As Integer = Convert.ToInt16(button.Name.Substring(14))
            If SoLuongBTofNhom(Nhom) = 0 Then
                For Each pnl As Panel In pnl_TrangBitTong1.Controls
                    If pnl.Name = "pnl_BT" + Nhom.ToString Or pnl.Name = "pnl_NhomTong" + Nhom.ToString Then
                        Console.WriteLine(pnl.Name)
                        pnl.Visible = False
                        pnl.Width = 0
                        NhomNow(Nhom) = False
                    End If
                Next
            Else
                DeleteBitTong(SoLuongBTofNhom(Nhom), Nhom)
                SoLuongBTofNhom(Nhom) -= 1
            End If

            CapNhatGiaoDien(0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Delete_BitTong2_New_Click(sender As Object, e As EventArgs) Handles btn_TruBitTong9.Click, btn_TruBitTong8.Click, btn_TruBitTong7.Click, btn_TruBitTong6.Click, btn_TruBitTong10.Click
        Try

            Dim button As Button = TryCast(sender, Button)
            Dim Nhom As Integer = Convert.ToInt16(button.Name.Substring(14))
            If SoLuongBTofNhom(Nhom) = 0 Then
                For Each pnl2 As Panel In pnl_TrangBitTong2.Controls
                    If pnl2.Name = "pnl_BT" + Nhom.ToString Or pnl2.Name = "pnl_NhomTong" + Nhom.ToString Then
                        pnl2.Visible = False
                        pnl2.Width = 0
                        NhomNow(Nhom) = False
                    End If
                Next
            Else
                DeleteBitTong(SoLuongBTofNhom(Nhom), Nhom)
                SoLuongBTofNhom(Nhom) -= 1
            End If

            CapNhatGiaoDien(0)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteBitTong(vitri As Integer, Nhom As Integer)
        Try
            Dim SttHangBitTong As Integer = vitri - (vitri \ 17) * 16
            Dim SttCotBitTong As Integer = vitri \ 17

            Dim Pnl As Panel = New Panel
            Select Case Nhom
                Case 1
                    Pnl = pnl_BT1
                Case 2
                    Pnl = pnl_BT2
                Case 3
                    Pnl = pnl_BT3
                Case 4
                    Pnl = pnl_BT4
                Case 5
                    Pnl = pnl_BT5
                Case 6
                    Pnl = pnl_BT6
                Case 7
                    Pnl = pnl_BT7
                Case 8
                    Pnl = pnl_BT8
                Case 9
                    Pnl = pnl_BT9
                Case 10
                    Pnl = pnl_BT10
            End Select

            Dim BitId As String = Nhom.ToString + "_" + vitri.ToString()
            DeleteDataXmlBitTong(BitId)

            For Each control As Control In Pnl.Controls
                If TypeOf control Is Button Then
                    Dim button As Button = DirectCast(control, Button)
                    Dim Name As String = "Button" + BitId
                    If button.Name = Name Then
                        Pnl.Controls.Remove(button)
                        Exit For
                    End If
                End If
            Next
            For Each control As Control In Pnl.Controls
                If TypeOf control Is PictureBox Then
                    Dim pictureBox As PictureBox = DirectCast(control, PictureBox)
                    Dim picName As String = "Pic" + BitId
                    If pictureBox.Name = picName Then
                        Pnl.Controls.Remove(pictureBox)
                        Exit For
                    End If
                End If
            Next
            For Each control As Control In Pnl.Controls
                If TypeOf control Is Label Then
                    Dim label As Label = DirectCast(control, Label)
                    Dim labelName As String = "Lab" + BitId
                    If label.Name = labelName Then
                        Pnl.Controls.Remove(label)
                        Exit For
                    End If
                End If
            Next
        Catch
        End Try
    End Sub
    Private BitIdDoiTen As String = ""
    Dim clickedLabel As Label
    ' hàm đổi tên label name của bit tổng
    Private Sub label1_DoubleClick(sender As Object, e As EventArgs)
        Try
            clickedLabel = DirectCast(sender, Label)
            Dim labelX As Integer = clickedLabel.Location.X
            Dim labelY As Integer = clickedLabel.Location.Y
            BitIdDoiTen = clickedLabel.Name.Substring(3)
            Dim BitId_Tam() As String = BitIdDoiTen.Split("_")
            Select Case BitId_Tam(0)
                Case "1"
                    pnl_BT1.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "2"
                    pnl_BT2.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "3"
                    pnl_BT3.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "4"
                    pnl_BT4.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "5"
                    pnl_BT5.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "6"
                    pnl_BT6.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "7"
                    pnl_BT7.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "8"
                    pnl_BT8.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "9"
                    pnl_BT9.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
                Case "10"
                    pnl_BT10.Controls.Add(tb_DoiTen)
                    tb_DoiTen.Location = New Point(labelX, labelY)
            End Select
            tb_DoiTen.Visible = True
            tb_DoiTen.BringToFront()
            tb_DoiTen.Text = clickedLabel.Text
            tb_DoiTen.SelectAll()
            tb_DoiTen.Focus()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DeleteDataXmlBitTong(bitId As String)
        Try
            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim doc As New XmlDocument()
            doc.Load(filePath)
            Dim xpathExpression As String = $"//Bit[@ID='{bitId}']"
            Dim bitNode As XmlNode = doc.SelectSingleNode(xpathExpression)
            If bitNode IsNot Nothing Then
                bitNode.ParentNode.RemoveChild(bitNode)
                doc.Save(filePath)
            Else
                MessageBox.Show($"Không tìm thấy phần tử Bit với ID = {bitId}")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CreatDataXmlBitTong(BitID As String)
        Try
            Dim fileName As String = "TBitTong1.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim doc As New XmlDocument()
            doc.Load(filePath)
            Dim newBit As XmlElement = doc.CreateElement("Bit")
            Dim newBitId As String = BitID
            newBit.SetAttribute("ID", newBitId)
            Dim nameElement As XmlElement = doc.CreateElement("Name")
            nameElement.InnerText = "Bit tổng"
            newBit.AppendChild(nameElement)
            Dim statusElement As XmlElement = doc.CreateElement("Status")
            statusElement.InnerText = "0"
            newBit.AppendChild(statusElement)
            Dim dataElement As XmlElement = doc.CreateElement("Data")
            dataElement.InnerText = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"
            newBit.AppendChild(dataElement)
            doc.DocumentElement.AppendChild(newBit)
            doc.Save(filePath)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tb_DoiTen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tb_DoiTen.KeyPress
        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                If tb_DoiTen.Text <> "" Then
                    If tb_DoiTen.Text.Length < 30 Then

                        Dim TenBit As String = tb_DoiTen.Text
                        Dim fileName As String = "TBitTong1.xml"
                        Dim filePath As String = Path.Combine(folderPath1, fileName)
                        Dim xmlDoc As New XmlDocument()
                        xmlDoc.Load(filePath)
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{BitIdDoiTen}']")
                        Dim nameNodes As XmlNodeList = xmlDoc.SelectNodes("//Bit/Name")
                        Dim isUnique As Boolean = True
                        For Each nameNode As XmlNode In nameNodes
                            If nameNode.InnerText = TenBit Then
                                isUnique = False
                                Exit For
                            End If
                        Next
                        If bitNode IsNot Nothing Then
                            Dim nameNode As XmlNode = bitNode.SelectSingleNode("Name") ' Tìm phần tử <Name> trong <Bit>
                            If nameNode IsNot Nothing Then
                                If isUnique Then
                                    Dim files As String() = Directory.GetFiles(folderPath1, "KB_*.xml")
                                    For Each file As String In files
                                        Dim xmlDoc1 As New XmlDocument()
                                        xmlDoc1.Load(file)
                                        Dim root As XmlNode = xmlDoc1.DocumentElement
                                        For Each tenCanhNode As XmlNode In root.SelectNodes("//TenCanh")
                                            Dim bitCanhNode As XmlNode = tenCanhNode.SelectSingleNode("BitCanh")
                                            Dim bitCanhValue As String = bitCanhNode.InnerText
                                            Dim modifiedBitCanh As String = ""
                                            Dim bitValues As String() = bitCanhValue.Split(","c)
                                            For i As Integer = 0 To bitValues.Length - 1
                                                If bitValues(i).Trim() = nameNode.InnerText Then
                                                    bitValues(i) = TenBit
                                                End If
                                            Next
                                            modifiedBitCanh = String.Join(",", bitValues)
                                            bitCanhNode.InnerText = modifiedBitCanh
                                        Next
                                        xmlDoc1.Save(file)
                                    Next

                                    Dim bitNode1 As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{BitIdDoiTen}']")
                                    If bitNode IsNot Nothing Then
                                        Dim nameNode1 As XmlNode = bitNode.SelectSingleNode("Name")
                                        nameNode.InnerText = TenBit
                                        xmlDoc.Save(filePath)
                                    End If
                                Else
                                    MessageBox.Show("Tên đã tồn tại. Vui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    TenBit = clickedLabel.Text
                                End If
                                tb_DoiTen.Visible = False
                                Dim labelName As String = $"Lab{BitIdDoiTen}"
                                Dim targetLabel As Label = DirectCast(Me.Controls.Find(labelName, True).FirstOrDefault(), Label)

                                If targetLabel IsNot Nothing Then
                                    targetLabel.Text = TenBit
                                Else
                                    MessageBox.Show($"Không tìm thấy Label với Name: {labelName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                        FrmSBVLM.Instance.loadkb()
                    Else
                        MessageBox.Show("Tên đối tượng không được vượt quá 30", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tb_DoiTen.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function ChuyenDoiPanel(numberPanel As Integer) As Panel()
        Try
            Dim pnls(1) As Panel
            Select Case numberPanel
                Case 1
                    pnls(0) = pnl_NhomTong1
                    pnls(1) = pnl_BT1
                Case 2
                    pnls(0) = pnl_NhomTong2
                    pnls(1) = pnl_BT2
                Case 3
                    pnls(0) = pnl_NhomTong3
                    pnls(1) = pnl_BT3
                Case 4
                    pnls(0) = pnl_NhomTong4
                    pnls(1) = pnl_BT4
                Case 5
                    pnls(0) = pnl_NhomTong5
                    pnls(1) = pnl_BT5
                Case 6
                    pnls(0) = pnl_NhomTong6
                    pnls(1) = pnl_BT6
                Case 7
                    pnls(0) = pnl_NhomTong7
                    pnls(1) = pnl_BT7
                Case 8
                    pnls(0) = pnl_NhomTong8
                    pnls(1) = pnl_BT8
                Case 9
                    pnls(0) = pnl_NhomTong9
                    pnls(1) = pnl_BT9
                Case 10
                    pnls(0) = pnl_NhomTong10
                    pnls(1) = pnl_BT10
            End Select

            Return pnls
        Catch
        End Try
    End Function
    Private Sub KiemTraGiaoDien()
        Try
            KhoaAdd1 = False
            KhoaAdd2 = False

            ' quét pnl_TrangBitTong1
            Dim pnl_width1 As Integer = 0
            Dim pnl_width2 As Integer = 0

            For Each pnl As Panel In pnl_TrangBitTong1.Controls
                If pnl.Visible = True AndAlso TypeOf pnl Is Panel AndAlso pnl.Name.StartsWith("pnl_BT") Then
                    pnl_width1 += pnl.Width
                End If
            Next
            If pnl_width1 = 1480 Then
                KhoaAdd1 = True
            End If

            ' quét pnl_TrangBitTong2
            For Each pnl As Panel In pnl_TrangBitTong2.Controls
                If pnl.Visible = True AndAlso TypeOf pnl Is Panel AndAlso pnl.Name.StartsWith("pnl_BT") Then
                    pnl_width2 += pnl.Width
                End If
            Next
            If pnl_width2 = 1480 Then
                KhoaAdd2 = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_NhomBit1_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_NhomBit8.MouseDown, btn_NhomBit9.MouseDown, btn_NhomBit10.MouseDown, btn_NhomBit6.MouseDown, btn_NhomBit7.MouseDown, btn_NhomBit5.MouseDown, btn_NhomBit4.MouseDown, btn_NhomBit3.MouseDown, btn_NhomBit2.MouseDown, btn_NhomBit1.MouseDown
        Try
            Dim Button As Button = TryCast(sender, Button)
            Bit_ID = Button.Name.Substring(11)

            If SoLanNhan <= 2 Then
                SoLanNhan += 1
                If SoLanNhan = 2 Then
                    KiemTra = True
                Else
                    KiemTra = False
                End If
            End If
            Chon1(Button, e)
        Catch ex As Exception
        End Try
    End Sub
    Dim Trangthai1 As String
    Private Async Sub Chon1(button As Button, e As MouseEventArgs)
        Try
            Await Task.Delay(waitTime)
            Checkbitong(button)

            If SoLanNhan = 1 Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath, "ON.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Blue
                    Trangthai1 = 1
                    Dim fileName1 As String = "TBitTong1.xml"
                    Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath1)
                    Dim bitNode1 As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bit_ID}']/Data")
                    If bitNode1 IsNot Nothing Then
                        DataString3 = bitNode1.InnerText
                    End If

                ElseIf button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                    Trangthai1 = 0
                    Dim fileName1 As String = "TBitTong1.xml"
                    Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath1)
                    Dim bitNode1 As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bit_ID}']/Data")
                    If bitNode1 IsNot Nothing Then
                        DataString3 = bitNode1.InnerText
                    End If
                End If
            ElseIf SoLanNhan >= 2 And KiemTra = True Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath, "BLYNK.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Red
                    Trangthai1 = 2
                    Dim fileName1 As String = "TBitTong1.xml"
                    Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath1)
                    Dim bitNode1 As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bit_ID}']/Data")
                    If bitNode1 IsNot Nothing Then
                        DataString3 = bitNode1.InnerText
                    End If

                ElseIf button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                    Trangthai1 = 0
                    Dim fileName1 As String = "TBitTong1.xml"
                    Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                    Dim xmlDoc As New XmlDocument()
                    xmlDoc.Load(filePath1)
                    Dim bitNode1 As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bit_ID}']/Data")
                    If bitNode1 IsNot Nothing Then
                        DataString3 = bitNode1.InnerText
                    End If
                End If
            End If
            SoLanNhan = 0
            DocGTBitTong1()

            If Trangthai1 = 0 Then
                RaiseEvent BitTongToSerial1(Me, "0_" + hex)
                RaiseEvent BitTongTo3DmapTP1(Me, "0_" + Bit_ID.ToString())
            ElseIf Trangthai1 = 1 Then
                RaiseEvent BitTongToSerial1(Me, "1_" + hex)
                RaiseEvent BitTongTo3DmapTP1(Me, "1_" + Bit_ID.ToString())
            ElseIf Trangthai1 = 2 Then
                RaiseEvent BitTongToSerial1(Me, "2_" + hex)
                RaiseEvent BitTongTo3DmapTP1(Me, "2_" + Bit_ID.ToString())
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateButtonState(button As Button, imagePath As String, textColor As Color, state As Integer)
        Try
            Dim newImage As Image = Image.FromFile(imagePath)
            button.Image = newImage
            button.ForeColor = textColor
        Catch
        End Try
    End Sub
    Dim statu1s As String = ""
    Dim DataString3 As String
    Private Sub Checkbitong(button As Button)
        Try
            Dim maxButtons As Integer = 16
            Dim baseButtonName As String = "Button" & Bit_ID & "_"

            Dim foundButtons As Integer = 0
            For i As Integer = 1 To maxButtons
                Dim buttonName As String = baseButtonName & i

                Dim button1 As Button = CType(Me.Controls.Find(buttonName, True).FirstOrDefault(), Button)
                Dim name As String = button1.Name.Substring(6)
                If button1 IsNot Nothing Then
                    foundButtons += 1
                    If SoLanNhan = 1 Then
                        If button.ForeColor = Color.White Or button.ForeColor = Color.Red Then
                            UpdateButtonState(button1, Path.Combine(folderPath, "ON.PNG"), Color.Blue, 1)
                            dataString1(i + (Bit_ID - 1) * 16) = "1"c
                            dataString2 = dataString1
                            Dim fileName1 As String = "TBitTong1.xml"
                            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                            Dim xmlDoc As New XmlDocument()
                            xmlDoc.Load(filePath1)
                            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{name}']/Name")
                            If bitNode IsNot Nothing Then
                                TenBit = bitNode.InnerText
                            End If
                            If Not DanhSachTenBit.Contains(TenBit) Then
                                DanhSachTenBit.Add(TenBit)
                            End If
                        ElseIf button.ForeColor = Color.Blue Then
                            UpdateButtonState(button1, Path.Combine(folderPath, "OFF.PNG"), Color.White, 0)
                            dataString1(i + (Bit_ID - 1) * 16) = "0"c
                            dataString2 = dataString1
                            Dim fileName1 As String = "TBitTong1.xml"
                            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                            Dim xmlDoc As New XmlDocument()
                            xmlDoc.Load(filePath1)
                            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{name}']/Name")
                            If bitNode IsNot Nothing Then
                                TenBit = bitNode.InnerText
                            End If
                            If DanhSachTenBit.Contains(TenBit) Then
                                DanhSachTenBit.Remove(TenBit)
                            End If
                        End If
                    ElseIf SoLanNhan >= 2 And KiemTra = True Then
                        If button.ForeColor = Color.White Or button.ForeColor = Color.Blue Then
                            UpdateButtonState(button1, Path.Combine(folderPath, "BLYNK.PNG"), Color.Red, 2)
                            dataString1(i + (Bit_ID - 1) * 16) = "2"c
                            dataString2 = dataString1
                            Dim fileName1 As String = "TBitTong1.xml"
                            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                            Dim xmlDoc As New XmlDocument()
                            xmlDoc.Load(filePath1)
                            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{name}']/Name")
                            If bitNode IsNot Nothing Then
                                TenBit = bitNode.InnerText
                            End If
                            If Not DanhSachTenBit.Contains(TenBit) Then
                                DanhSachTenBit.Add(TenBit)
                            End If
                        ElseIf button.ForeColor = Color.Red Then
                            UpdateButtonState(button1, Path.Combine(folderPath, "OFF.PNG"), Color.White, 0)
                            dataString1(i + (Bit_ID - 1) * 16) = "0"c
                            dataString2 = dataString1
                            Dim fileName1 As String = "TBitTong1.xml"
                            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
                            Dim xmlDoc As New XmlDocument()
                            xmlDoc.Load(filePath1)
                            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{name}']/Name")
                            If bitNode IsNot Nothing Then
                                TenBit = bitNode.InnerText
                            End If
                            If DanhSachTenBit.Contains(TenBit) Then
                                DanhSachTenBit.Remove(TenBit)
                            End If
                        End If
                    End If
                End If
            Next
            If foundButtons = 0 Then
                Exit Sub
            End If
            bit = 0
        Catch
        End Try
    End Sub
    Private Sub DocGTBitTong1()
        Try
            Dim fileName1 As String = "TBitTong1.xml"
            Dim filePath1 As String = Path.Combine(folderPath1, fileName1)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath1)
            Dim modifiedVariable As String = String.Empty
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"//BitTongData/Bit[@ID='{Bit_ID}']/Data")
            If bitNode IsNot Nothing Then
                Dim variableToStoreData As String = bitNode.InnerText
                Dim hexList As List(Of String) = Enumerable.Range(0, variableToStoreData.Length \ 8) _
                    .Select(Function(i) variableToStoreData.Substring(8 * i, 8)) _
                    .Select(Function(s) Convert.ToByte(s, 2)) _
                    .Select(Function(b) b.ToString("X2")) _
                    .ToList()
                hex = String.Concat(hexList)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public TenLabel As String
    Private Sub lb_NameNhomBit1_DoubleClick(sender As Object, e As EventArgs) Handles lb_NameNhomBit1.DoubleClick, lb_NameNhomBit5.DoubleClick, lb_NameNhomBit4.DoubleClick, lb_NameNhomBit3.DoubleClick, lb_NameNhomBit2.DoubleClick, Label5.DoubleClick, Label4.DoubleClick, Label3.DoubleClick, Label2.DoubleClick, Label1.DoubleClick
        Try
            If tb_DoiTen1.Visible = True Then
                Dim label As Label = Me.Controls.Find(BitDoiTen, True).FirstOrDefault()
                label.Visible = True

            End If
            Dim clickedLabel As Label = DirectCast(sender, Label)
            TenLabel = clickedLabel.Name.Substring(14)
            Dim labelX As Integer = clickedLabel.Location.X
            Dim labelY As Integer = clickedLabel.Location.Y
            Dim ten As String = "pnl_NhomTong" & TenLabel
            Dim panel1 As Panel = DirectCast(Me.Controls.Find(ten, True).FirstOrDefault(), Panel)
            panel1.Controls.Add(tb_DoiTen1)
            tb_DoiTen1.Location = New Point(labelX, labelY - 4)
            tb_DoiTen1.Visible = True
            clickedLabel.Visible = False
            tb_DoiTen1.Text = clickedLabel.Text
            tb_DoiTen1.SelectAll()
            tb_DoiTen1.Focus()
            BitDoiTen = clickedLabel.Name
        Catch ex As Exception
        End Try


    End Sub

    Private Sub tb_DoiTen_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_DoiTen1.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If tb_DoiTen1.Text <> "" Then
                    If tb_DoiTen1.Text.Length < 30 Then
                        Dim TenBit As String = tb_DoiTen1.Text
                        Dim fileName As String = "TBitTong1.xml"
                        Dim filePath As String = Path.Combine(folderPath1, fileName)
                        Dim xmlDoc As New XmlDocument()
                        xmlDoc.Load(filePath)
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{TenLabel}']")
                        Dim nameNodes As XmlNodeList = xmlDoc.SelectNodes("//Bit/Name")
                        Dim isUnique As Boolean = True
                        For Each nameNode As XmlNode In nameNodes
                            If nameNode.InnerText = TenBit Then
                                isUnique = False
                                Exit For
                            End If
                        Next
                        If bitNode IsNot Nothing Then
                            Dim nameNode As XmlNode = bitNode.SelectSingleNode("Name") ' Tìm phần tử <Name> trong <Bit>
                            If nameNode IsNot Nothing Then
                                If isUnique Then
                                    Dim files As String() = Directory.GetFiles(folderPath1, "KB_*.xml")
                                    For Each file As String In files
                                        Dim xmlDoc1 As New XmlDocument()
                                        xmlDoc1.Load(file)
                                        Dim root As XmlNode = xmlDoc1.DocumentElement
                                        For Each tenCanhNode As XmlNode In root.SelectNodes("//TenCanh")
                                            Dim bitCanhNode As XmlNode = tenCanhNode.SelectSingleNode("BitCanh")
                                            Dim bitCanhValue As String = bitCanhNode.InnerText
                                            Dim modifiedBitCanh As String = ""
                                            Dim bitValues As String() = bitCanhValue.Split(","c)
                                            For i As Integer = 0 To bitValues.Length - 1
                                                If bitValues(i).Trim() = nameNode.InnerText Then
                                                    bitValues(i) = TenBit
                                                End If
                                            Next
                                            modifiedBitCanh = String.Join(",", bitValues)
                                            bitCanhNode.InnerText = modifiedBitCanh
                                        Next
                                        xmlDoc1.Save(file)
                                    Next
                                    Dim bitNode1 As XmlNode = xmlDoc.SelectSingleNode($"/BitTongData/Bit[@ID='{TenLabel}']")
                                    If bitNode IsNot Nothing Then
                                        Dim nameNode1 As XmlNode = bitNode.SelectSingleNode("Name")
                                        nameNode.InnerText = TenBit
                                        xmlDoc.Save(filePath)
                                    End If
                                Else
                                    MessageBox.Show("Tên đã tồn tại. Vui lòng nhập tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    TenBit = clickedLabel.Text
                                End If
                                tb_DoiTen1.Visible = False
                                Dim labelName As String = "lb_NameNhomBit" & TenLabel
                                Dim targetLabel As Label = DirectCast(Me.Controls.Find(labelName, True).FirstOrDefault(), Label)

                                If targetLabel IsNot Nothing Then
                                    targetLabel.Text = TenBit
                                    targetLabel.Visible = True
                                Else
                                    MessageBox.Show($"Không tìm thấy Label với Name: {labelName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                        FrmSBVLM.Instance.loadkb()
                    Else
                        MessageBox.Show("Tên đối tượng không được vượt quá 30", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tb_DoiTen1.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub HamDoiTen()
        If tb_DoiTen1.Visible = True Then
            tb_DoiTen1.Visible = False
            tb_DoiTen1.Text = ""
            Dim labelName As String = "lb_NameNhomBit" & TenLabel
            Dim targetLabel As Label = DirectCast(Me.Controls.Find(labelName, True).FirstOrDefault(), Label)
            targetLabel.Visible = True

        End If
    End Sub
    Private Sub HamDoiTen1()
        If tb_DoiTen.Visible = True Then
            tb_DoiTen.Visible = False
            tb_DoiTen.Text = ""
            Dim labelName As String = $"Lab{BitIdDoiTen}"
            Dim targetLabel As Label = DirectCast(Me.Controls.Find(labelName, True).FirstOrDefault(), Label)
            targetLabel.Visible = True

        End If
    End Sub
    Private Sub btn_xoanhom_Click(sender As Object, e As EventArgs)
        Try
            KiemTraGiaoDien()
            If KhoaAdd1 = 0 Or KhoaAdd2 = 0 Then
                For i As Integer = 1 To 10
                    If NhomNow(i) = False Then
                        SttNhomBitTong = i
                        NhomNow(i) = True
                        Exit For
                    End If
                Next
                If SttNhomBitTong = 10 Then
                    pnl_TrangBitTong1.BringToFront()
                    pnl_BT1.Size = New Size(296, 832)
                    pnl_BT1.Location = New Point(0, 40)
                    pnl_BT1.Visible = False
                    pnl_NhomTong1.Location = New Point(0, 0)
                    pnl_NhomTong1.Visible = False
                    pnl_NhomTong1.Size = New Size(296, 40)
                ElseIf SttNhomBitTong = 9 Then
                    pnl_BT2.Location = New Point(pnl_BT1.Width, 41)
                    pnl_BT2.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT2.Visible = False
                    pnl_NhomTong2.Location = New Point(pnl_BT1.Width, 0)
                    pnl_NhomTong2.Visible = False
                    pnl_NhomTong2.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 8 Then
                    pnl_BT3.Location = New Point(pnl_BT2.Width + pnl_BT1.Width, 41)
                    pnl_BT3.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT3.Visible = False
                    pnl_NhomTong3.Location = New Point(pnl_BT2.Width + pnl_BT1.Width, 0)
                    pnl_NhomTong3.Visible = False
                    pnl_NhomTong3.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 7 Then
                    pnl_BT4.Location = New Point(pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 41)
                    pnl_BT4.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT4.Visible = False
                    pnl_NhomTong4.Location = New Point(pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 0)
                    pnl_NhomTong4.Visible = False
                    pnl_NhomTong4.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 6 Then
                    pnl_BT5.Location = New Point(pnl_BT4.Width + pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 41)
                    pnl_BT5.Size = New Size(296, pnl_TrangBitTong1.Height - 40)
                    pnl_BT5.Visible = False
                    pnl_NhomTong5.Location = New Point(pnl_BT4.Width + pnl_BT3.Width + pnl_BT2.Width + pnl_BT1.Width, 0)
                    pnl_NhomTong5.Visible = False
                    pnl_NhomTong5.Size = New Size(296, 41)
                End If

                If SttNhomBitTong = 5 Then

                    pnl_BT6.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT6.Location = New Point(0, 41)
                    pnl_BT6.Visible = False

                    pnl_NhomTong6.Location = New Point(0, 0)
                    pnl_NhomTong6.Visible = False
                    pnl_NhomTong6.Size = New Size(296, 41)
                ElseIf SttNhomBitTong = 4 Then

                    pnl_BT7.Location = New Point(pnl_BT6.Width, 41)
                    pnl_BT7.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT7.Visible = False

                    pnl_NhomTong7.Location = New Point(pnl_BT6.Width, 0)
                    pnl_NhomTong7.Visible = False
                    pnl_NhomTong7.Size = New Size(296, 41)

                ElseIf SttNhomBitTong = 3 Then

                    pnl_BT8.Location = New Point(pnl_BT7.Width + pnl_BT6.Width, 41)
                    pnl_BT8.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT8.Visible = False
                    pnl_NhomTong8.Location = New Point(pnl_BT7.Width + pnl_BT6.Width, 0)
                    pnl_NhomTong8.Visible = False
                    pnl_NhomTong8.Size = New Size(296, 41)

                ElseIf SttNhomBitTong = 2 Then

                    pnl_BT9.Location = New Point(pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 41)
                    pnl_BT9.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT9.Visible = False

                    pnl_NhomTong9.Location = New Point(pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 0)
                    pnl_NhomTong9.Visible = False
                    pnl_NhomTong9.Size = New Size(296, 41)

                ElseIf SttNhomBitTong = 1 Then

                    pnl_BT10.Location = New Point(pnl_BT9.Width + pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 41)
                    pnl_BT10.Size = New Size(296, pnl_TrangBitTong2.Height - 41)
                    pnl_BT10.Visible = False

                    pnl_NhomTong10.Location = New Point(pnl_BT9.Width + pnl_BT8.Width + pnl_BT7.Width + pnl_BT6.Width, 0)
                    pnl_NhomTong10.Visible = False
                    pnl_NhomTong10.Size = New Size(296, 41)

                End If

                CapNhatGiaoDien(0)
            End If
        Catch
        End Try
    End Sub

    Private Sub pnl_TrangBitTong1_Click(sender As Object, e As EventArgs) Handles pnl_TrangBitTong1.Click
        HamDoiTen()
        HamDoiTen1()
    End Sub

    Private Sub pnl_Menu_Click(sender As Object, e As EventArgs) Handles pnl_Menu.Click
        HamDoiTen()
        HamDoiTen1()
    End Sub

    Private Sub BitTong_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        HamDoiTen()
        HamDoiTen1()
    End Sub



#End Region
End Class
