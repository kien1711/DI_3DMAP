Imports System.IO
Imports System.Xml
Imports Guna.UI2.WinForms.Suite

Public Class CCD
#Region "Khai Báo Biến"
    Dim folderPath1 As String
    Dim folderPath2 As String
    Dim folderPath3 As String
    Dim TenKyHieu As String
    Dim TenKhungHinh As String
    Dim ThongSo As String
    Dim dataNumber As String
    Dim SoLanNhan As Integer = 0
    Private Const waitTime As Integer = 200 ' Thời gian chờ (100ms)
    Private TrangThai As Integer = 0
    Private KiemTra As Boolean = False
    Dim LuuCo As Integer = 0
    Dim ThemCo As Integer = 0
    Public tinhtrang As String
    Public Event CCDToMainSerial As EventHandler(Of String)
    Private BitDoiTen As String
    Private TenBitDon As String
#End Region
#Region "Load"
    Private Sub CCD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
        Dim folderName1 As String = "Data"
        Dim folderName2 As String = "Data\2X"
        Dim folderName3 As String = "Data\HA"
        folderPath1 = Path.Combine(baseDirectory, folderName1)
        folderPath2 = Path.Combine(baseDirectory, folderName2)
        folderPath3 = Path.Combine(baseDirectory, folderName3)
        DB_CCD()
        DocCCD()
        CB_GiaiDoan.SelectedIndex = 0
        CB_Phe.SelectedIndex = 0
        tinhtrang = bt_CCD.Text
    End Sub
#End Region
#Region "Nút Nhấn"
    Private Sub btn_XacNhan_Click(sender As Object, e As EventArgs) Handles btn_XacNhan.Click
        Try
            GB_ChoiKyHieu.Visible = False
            If TenKyHieu = "Xoa" Then
                XoaCCD()
            Else
                Dim searchText As String = FrmMain.Instance.tb_mau.Text
                Dim DuongDanKyHieu As String = folderPath2 & "\" & TenKyHieu & (CB_Phe.SelectedIndex + 1).ToString() & (CB_GiaiDoan.SelectedIndex + 1).ToString() & ".mkx"
                If File.Exists(DuongDanKyHieu) Then
                    GhiCCD(DuongDanKyHieu, "HinhAnh")
                Else
                    Dim DuongDanKyHieu1 As String = folderPath2 & "\P" & TenKyHieu & 11.ToString() & ".mkx"
                    GhiCCD(DuongDanKyHieu1, "HinhAnh")
                End If
                FrmMain.Instance.doico(searchText, DuongDanKyHieu)
            End If
            DocCCD()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub PictureBox1_DoubleClick(sender As Object, e As EventArgs) Handles PictureBox9.DoubleClick, PictureBox8.DoubleClick, PictureBox7.DoubleClick, PictureBox6.DoubleClick, PictureBox50.DoubleClick, PictureBox5.DoubleClick, PictureBox49.DoubleClick, PictureBox48.DoubleClick, PictureBox47.DoubleClick, PictureBox46.DoubleClick, PictureBox45.DoubleClick, PictureBox44.DoubleClick, PictureBox43.DoubleClick, PictureBox42.DoubleClick, PictureBox41.DoubleClick, PictureBox40.DoubleClick, PictureBox4.DoubleClick, PictureBox39.DoubleClick, PictureBox38.DoubleClick, PictureBox37.DoubleClick, PictureBox36.DoubleClick, PictureBox35.DoubleClick, PictureBox34.DoubleClick, PictureBox33.DoubleClick, PictureBox32.DoubleClick, PictureBox31.DoubleClick, PictureBox30.DoubleClick, PictureBox3.DoubleClick, PictureBox29.DoubleClick, PictureBox28.DoubleClick, PictureBox27.DoubleClick, PictureBox26.DoubleClick, PictureBox25.DoubleClick, PictureBox24.DoubleClick, PictureBox23.DoubleClick, PictureBox22.DoubleClick, PictureBox21.DoubleClick, PictureBox20.DoubleClick, PictureBox2.DoubleClick, PictureBox19.DoubleClick, PictureBox18.DoubleClick, PictureBox17.DoubleClick, PictureBox16.DoubleClick, PictureBox15.DoubleClick, PictureBox14.DoubleClick, PictureBox13.DoubleClick, PictureBox12.DoubleClick, PictureBox11.DoubleClick, PictureBox10.DoubleClick, PictureBox1.DoubleClick
        Try
            Dim picturebox As PictureBox = TryCast(sender, PictureBox)
            GB_ChoiKyHieu.Visible = True
            TenKhungHinh = picturebox.Name
            ThongSo = TenKhungHinh.Substring(10)
            Dim label As Label = Me.Controls.Find("label" & ThongSo, True).FirstOrDefault()
            GB_ChoiKyHieu.Text = label.Text
            If picturebox.Tag.ToString() = "" Then
                PB_KhungCo.Image = Nothing
            Else
                Dim hinhAnh As Image = Image.FromFile(picturebox.Tag.ToString())
                PB_KhungCo.Image = hinhAnh
            End If
            CB_GiaiDoan.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TS_CCD_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles TS_CCD.ItemClicked
        TenKyHieu = e.ClickedItem.Name.Substring(2)
        CB_GiaiDoan.Enabled = True
        If TenKyHieu = "Xoa" Then
            PB_KhungCo.Image = Nothing
        Else
            KhungCCD()
        End If
    End Sub
    Private Sub CB_Phe_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_Phe.SelectedIndexChanged
        If CB_Phe.SelectedIndex = 1 Then
            tl1000000.Enabled = False
            tl1000001.Enabled = False
            tl1000002.Enabled = False
            tl1200000.Enabled = False
            tl1100003.Enabled = False
            tl1100004.Enabled = False
            tl130000.Enabled = False
            tl1200001.Enabled = False
            tl1100005.Enabled = False
            tl1100006.Enabled = False
            tl130001.Enabled = False
            tl130002.Enabled = False
            tl130003.Enabled = False
            tl1100007.Enabled = False
            tl130004.Enabled = False
            tl130005.Enabled = False
            tl1200005.Enabled = False
            tl1200006.Enabled = False
            tl1100008.Enabled = False
            tl130014.Enabled = False
            tl130006.Enabled = False
            tl130007.Enabled = False
            tl1100009.Enabled = False
            tl130008.Enabled = False
            tl130015.Enabled = False
            tl130009.Enabled = False
            tl1100010.Enabled = False
            tl130010.Enabled = False
            tl130011.Enabled = False
            tl130016.Enabled = False
            tl130013.Enabled = False
            tl130012.Enabled = False
        ElseIf CB_Phe.SelectedIndex = 0 Then
            tl1000000.Enabled = True
            tl1000001.Enabled = True
            tl1000002.Enabled = True
            tl1200000.Enabled = True
            tl1100003.Enabled = True
            tl1100004.Enabled = True
            tl130000.Enabled = True
            tl1200001.Enabled = True
            tl1100005.Enabled = True
            tl1100006.Enabled = True
            tl130001.Enabled = True
            tl130002.Enabled = True
            tl130003.Enabled = True
            tl1100007.Enabled = True
            tl130004.Enabled = True
            tl130005.Enabled = True
            tl1200005.Enabled = True
            tl1200006.Enabled = True
            tl1100008.Enabled = True
            tl130014.Enabled = True
            tl130006.Enabled = True
            tl130007.Enabled = True
            tl1100009.Enabled = True
            tl130008.Enabled = True
            tl130015.Enabled = True
            tl130009.Enabled = True
            tl1100010.Enabled = True
            tl130010.Enabled = True
            tl130011.Enabled = True
            tl130016.Enabled = True
            tl130013.Enabled = True
            tl130012.Enabled = True
        End If
        KhungCCD()
    End Sub
    Private Sub CB_GiaiDoan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CB_GiaiDoan.SelectedIndexChanged
        KhungCCD()
    End Sub

    Private Sub button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button9.MouseDown, Button8.MouseDown, Button7.MouseDown, Button6.MouseDown, Button50.MouseDown, Button5.MouseDown, Button49.MouseDown, Button48.MouseDown, Button47.MouseDown, Button46.MouseDown, Button45.MouseDown, Button44.MouseDown, Button43.MouseDown, Button42.MouseDown, Button41.MouseDown, Button40.MouseDown, Button4.MouseDown, Button39.MouseDown, Button38.MouseDown, Button37.MouseDown, Button36.MouseDown, Button35.MouseDown, Button34.MouseDown, Button33.MouseDown, Button32.MouseDown, Button31.MouseDown, Button30.MouseDown, Button3.MouseDown, Button29.MouseDown, Button28.MouseDown, Button27.MouseDown, Button26.MouseDown, Button25.MouseDown, Button24.MouseDown, Button23.MouseDown, Button22.MouseDown, Button21.MouseDown, Button20.MouseDown, Button2.MouseDown, Button19.MouseDown, Button18.MouseDown, Button17.MouseDown, Button16.MouseDown, Button15.MouseDown, Button14.MouseDown, Button13.MouseDown, Button12.MouseDown, Button11.MouseDown, Button10.MouseDown, button1.MouseDown
        Try
            Dim button As Button = TryCast(sender, Button)
            dataNumber = Convert.ToInt16(button.Name.Substring(6))
            If SoLanNhan <= 2 Then
                SoLanNhan += 1
                If SoLanNhan = 2 Then
                    KiemTra = True
                Else
                    KiemTra = False
                End If
            End If
            If SoLanNhan = 1 Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Red Then
                    FrmSBVLM.Instance.DieuKhienCo.Text = "C" + dataNumber
                ElseIf button.ForeColor = Color.Blue Then
                    FrmSBVLM.Instance.DieuKhienCo.Text = " "
                End If
            ElseIf SoLanNhan >= 2 And KiemTra = True Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Blue Then
                    FrmSBVLM.Instance.DieuKhienCo.Text = "C" + dataNumber
                ElseIf button.ForeColor = Color.Red Then
                    FrmSBVLM.Instance.DieuKhienCo.Text = " "
                End If
            End If
            Task.Run(Sub() Chon(button, e))

        Catch ex As Exception
        End Try
    End Sub
    Private Async Sub Chon(button As Button, e As MouseEventArgs)
        Try

            Await Task.Delay(waitTime)
            If SoLanNhan = 1 Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath3, "ON.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Blue
                    TrangThai = 1
                ElseIf button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath3, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                    TrangThai = 0
                End If
            ElseIf SoLanNhan >= 2 And KiemTra = True Then
                If button.ForeColor = Color.White Or button.ForeColor = Color.Blue Then
                    Dim filePath As String = Path.Combine(folderPath3, "BLYNK.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.Red
                    TrangThai = 2

                ElseIf button.ForeColor = Color.Red Then
                    Dim filePath As String = Path.Combine(folderPath3, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                    TrangThai = 0


                End If
            End If
            SoLanNhan = 0
            Dim label As Label = Me.Controls.Find("label" & dataNumber, True).FirstOrDefault()

            If TrangThai = 0 Then
                RaiseEvent CCDToMainSerial(Me, "C" + dataNumber.ToString() + "_0")

            ElseIf TrangThai = 1 Then
                If label.ForeColor = Color.Red Then
                    RaiseEvent CCDToMainSerial(Me, "C" + dataNumber.ToString() + "_1r")
                End If
                If label.ForeColor = Color.Blue Then
                    RaiseEvent CCDToMainSerial(Me, "C" + dataNumber.ToString() + "_1b")
                End If
            ElseIf TrangThai = 2 Then
                If label.ForeColor = Color.Red Then
                    RaiseEvent CCDToMainSerial(Me, "C" + dataNumber.ToString() + "_2r")

                End If
                If label.ForeColor = Color.Blue Then
                    RaiseEvent CCDToMainSerial(Me, "C" + dataNumber.ToString() + "_2b")

                End If
            End If

        Catch ex As Exception
        End Try
    End Sub

#End Region
#Region "Hàm Con"
    Private Sub KhungCCD()
        Try
            Dim DuongDanKyHieu As String = folderPath2 & "\" & TenKyHieu & (CB_Phe.SelectedIndex + 1).ToString() & (CB_GiaiDoan.SelectedIndex + 1).ToString() & ".mkx"
            If File.Exists(DuongDanKyHieu) Then
                Dim hinhAnh As Image = Image.FromFile(DuongDanKyHieu)
                PB_KhungCo.Image = hinhAnh
            Else
                Dim DuongDanKyHieu1 As String = folderPath2 & "\P" & TenKyHieu & 11.ToString() & ".mkx"
                If File.Exists(DuongDanKyHieu1) Then
                    Dim hinhAnh As Image = Image.FromFile(DuongDanKyHieu1)
                    PB_KhungCo.Image = hinhAnh
                Else
                    PB_KhungCo.Image = Nothing
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub XoaCCD()
        Try
            Dim fileName As String = "CoCoDong.xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
            xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/DanhSachCo/SoCo[@ID='{ThongSo}']")
            If bitNode IsNot Nothing Then
                Dim PheCoNode As XmlNode = bitNode.SelectSingleNode("PheCo") ' Tìm phần tử <Name> trong <Bit>
                Dim DataNode As XmlNode = bitNode.SelectSingleNode("Data") ' Tìm phần tử <Name> trong <Bit>
                If DataNode IsNot Nothing Then
                    PheCoNode.InnerText = ""
                    DataNode.InnerText = "" ' Ghi giá trị mới vào phần tử <Name>
                    xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub HienCo()
        Try
            If ThemCo <= 50 Then
                ThemCo += 1
                Dim controls As Control() = Me.Controls.Find("button" & ThemCo, True)
                If controls.Length > 0 AndAlso TypeOf controls(0) Is Button Then
                    Dim button As Button = DirectCast(controls(0), Button)
                    button.Visible = True
                End If
                Dim controls_1 As Control() = Me.Controls.Find("label" & ThemCo, True)
                If controls_1.Length > 0 AndAlso TypeOf controls_1(0) Is Label Then
                    Dim label As Label = DirectCast(controls_1(0), Label)
                    label.Visible = True
                End If
                Dim controls_2 As Control() = Me.Controls.Find("pictureBox" & ThemCo, True)
                If controls_2.Length > 0 AndAlso TypeOf controls_2(0) Is PictureBox Then
                    Dim pictureBox As PictureBox = DirectCast(controls_2(0), PictureBox)
                    pictureBox.Visible = True
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub trangthaico()
        For i As Integer = 1 To 50
            If FrmSBVLM.Instance.tb_trangthaico.Text = i.ToString() Then
                Dim buttonName As String = "button" & i.ToString()
                Dim labelName As String = "label" & i.ToString()
                Dim pictureboxName As String = "pictureBox" & i.ToString()
                Dim button As Button = CType(Me.Controls.Find(buttonName, True).FirstOrDefault(), Button)
                Dim label As Label = CType(Me.Controls.Find(labelName, True).FirstOrDefault(), Label)
                Dim pictureBox As PictureBox = CType(Me.Controls.Find(pictureboxName, True).FirstOrDefault(), PictureBox)
                If button IsNot Nothing Then
                    button.Visible = True
                End If
                If label IsNot Nothing Then
                    label.Visible = True
                End If
                If pictureBox IsNot Nothing Then
                    pictureBox.Visible = True
                End If
                Exit For
            End If
        Next i
    End Sub
    Private Sub AnCo()
        Try
            If ThemCo <= 50 Then
                Dim controls As Control() = Me.Controls.Find("button" & ThemCo, True)
                If controls.Length > 0 AndAlso TypeOf controls(0) Is Button Then
                    Dim button As Button = DirectCast(controls(0), Button)
                    button.Visible = False
                    Dim filePath As String = Path.Combine(folderPath3, "OFF.PNG")
                    Dim newImage As Image = Image.FromFile(filePath)
                    button.Image = newImage
                    button.ForeColor = Color.White
                End If
                Dim controls_1 As Control() = Me.Controls.Find("label" & ThemCo, True)
                If controls_1.Length > 0 AndAlso TypeOf controls_1(0) Is Label Then
                    Dim label As Label = DirectCast(controls_1(0), Label)
                    label.Visible = False
                End If

                Dim controls_2 As Control() = Me.Controls.Find("pictureBox" & ThemCo, True)
                If controls_2.Length > 0 AndAlso TypeOf controls_2(0) Is PictureBox Then
                    Dim pictureBox As PictureBox = DirectCast(controls_2(0), PictureBox)
                    pictureBox.Visible = False
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub trangthaiCCD()

        'MessageBox.Show(tinhtrang)
        If tinhtrang = "TP2" Then
            Button2.Visible = True
            Label2.Visible = True
            PictureBox2.Visible = True

        End If
        If tinhtrang = "TP3" Then
            Button3.Visible = True
            Label3.Visible = True
            PictureBox3.Visible = True
        End If

    End Sub

#End Region
#Region "Cơ Sở dữ liệu"
    Private Sub DB_CCD()
        Try
            Dim filePath As String = Path.Combine(folderPath1, "CoCoDong.xml")
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("DanhSachCo")
                xmlDoc.AppendChild(rootElement) ' Tạo các phần tử con cho mỗi dòng trong tệp txt
                For i As Integer = 1 To 50
                    Dim SocoElement As XmlElement = xmlDoc.CreateElement("SoCo")
                    SocoElement.SetAttribute("ID", i)
                    Dim TencoElement As XmlElement = xmlDoc.CreateElement("TenCo")
                    TencoElement.InnerText = "Cờ Số " + i.ToString()
                    Dim PheElement As XmlElement = xmlDoc.CreateElement("PheCo")
                    PheElement.InnerText = ""
                    Dim DataElement As XmlElement = xmlDoc.CreateElement("Data")
                    DataElement.InnerText = ""
                    SocoElement.AppendChild(TencoElement)
                    SocoElement.AppendChild(PheElement)
                    SocoElement.AppendChild(DataElement)
                    rootElement.AppendChild(SocoElement)
                Next
                xmlDoc.Save(filePath) ' Lưu tệp XML
            End If
        Catch ex As Exception

            ' Xử lý các ngoại lệ ở đây
        End Try
    End Sub
    Private Sub DocCCD()
        Try
            Dim filePath As String = Path.Combine(folderPath1, "CoCoDong.xml")
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument để đọc dữ liệu từ tệp XML
                xmlDoc.Load(filePath)
                Dim bitNodes As XmlNodeList = xmlDoc.SelectNodes("/DanhSachCo/SoCo") ' Lấy tất cả các phần tử <Bit> từ tài liệu XML
                For Each bitNode As XmlNode In bitNodes
                    Dim id As Integer = Integer.Parse(bitNode.Attributes("ID").Value) ' Lấy giá trị của thuộc tính ID
                    Dim TenValue As String = bitNode.SelectSingleNode("TenCo").InnerText ' Lấy giá trị của phần tử <Name>
                    Dim PheCoValue As String = bitNode.SelectSingleNode("PheCo").InnerText
                    Dim DataCoValue As String = bitNode.SelectSingleNode("Data").InnerText
                    Dim labelBit As String = "label" & id.ToString()
                    Dim label As Label = Me.Controls.Find(labelBit, True).FirstOrDefault()
                    If label IsNot Nothing Then
                        label.Text = TenValue
                        If PheCoValue = "" Then
                            label.ForeColor = Color.Black
                        ElseIf PheCoValue = 0 Then
                            label.ForeColor = Color.Red
                        ElseIf PheCoValue = 1 Then
                            label.ForeColor = Color.Blue
                        End If
                    End If
                    Dim pictureboxBit As String = "PictureBox" & id.ToString()
                    Dim picturebox As PictureBox = Me.Controls.Find(pictureboxBit, True).FirstOrDefault()
                    If File.Exists(DataCoValue) Then
                        Dim hinhAnh As Image = Image.FromFile(DataCoValue)
                        picturebox.Image = hinhAnh
                        picturebox.Tag = DataCoValue
                    Else
                        picturebox.Image = Nothing
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GhiCCD(data As String, TrangThai As String)
        Try

            Dim filePath As String = Path.Combine(folderPath1, "CoCoDong.xml")
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
            xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/DanhSachCo/SoCo[@ID='{ThongSo}']")

            If bitNode IsNot Nothing Then
                Dim TenCoNode As XmlNode = bitNode.SelectSingleNode("TenCo") ' Tìm phần tử <Name> trong <Bit>
                Dim PheCoNode As XmlNode = bitNode.SelectSingleNode("PheCo") ' Tìm phần tử <Name> trong <Bit>
                Dim DataNode As XmlNode = bitNode.SelectSingleNode("Data") ' Tìm phần tử <Name> trong <Bit>
                If TrangThai = "TenCo" Then
                    If TenCoNode IsNot Nothing Then
                        TenCoNode.InnerText = data
                    End If
                End If
                If TrangThai = "HinhAnh" Then
                    If PheCoNode IsNot Nothing Then
                        If DataNode IsNot Nothing Then
                            PheCoNode.InnerText = CB_Phe.SelectedIndex
                            DataNode.InnerText = data ' Ghi giá trị mới vào phần tử <Name>
                        End If
                    End If
                End If
                xmlDoc.Save(filePath)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub label1_DoubleClick(sender As Object, e As EventArgs) Handles Label9.DoubleClick, Label8.DoubleClick, Label7.DoubleClick, Label6.DoubleClick, Label50.DoubleClick, Label5.DoubleClick, Label49.DoubleClick, Label48.DoubleClick, Label47.DoubleClick, Label46.DoubleClick, Label45.DoubleClick, Label44.DoubleClick, Label43.DoubleClick, Label42.DoubleClick, Label41.DoubleClick, Label40.DoubleClick, Label4.DoubleClick, Label39.DoubleClick, Label38.DoubleClick, Label37.DoubleClick, Label36.DoubleClick, Label35.DoubleClick, Label34.DoubleClick, Label33.DoubleClick, Label32.DoubleClick, Label31.DoubleClick, Label30.DoubleClick, Label3.DoubleClick, Label29.DoubleClick, Label28.DoubleClick, Label27.DoubleClick, Label26.DoubleClick, Label25.DoubleClick, Label24.DoubleClick, Label23.DoubleClick, Label22.DoubleClick, Label21.DoubleClick, Label20.DoubleClick, Label2.DoubleClick, Label19.DoubleClick, Label18.DoubleClick, Label17.DoubleClick, Label16.DoubleClick, Label15.DoubleClick, Label14.DoubleClick, Label13.DoubleClick, Label12.DoubleClick, Label11.DoubleClick, Label10.DoubleClick, label1.DoubleClick
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
            BitDoiTen = clickedLabel.Name
            ThongSo = BitDoiTen.Substring(5)
            tb_DoiTen.SelectAll()
            tb_DoiTen.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_DoiTen_KeyDown(sender As Object, e As KeyEventArgs) Handles tb_DoiTen.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tb_DoiTen.Text.Length < 15 Then
                Dim label As Label = Me.Controls.Find(BitDoiTen, True).FirstOrDefault()
                Dim TenCo As String = tb_DoiTen.Text
                label.Visible = True
                tb_DoiTen.Visible = False
                tb_DoiTen.Location = New Point(1305, -1)
                GhiCCD(TenCo, "TenCo")
                DocCCD()
            Else
                MessageBox.Show("Tên cờ không được vượt quá 14 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                tb_DoiTen.Focus()
            End If
        End If
    End Sub


#End Region
End Class
