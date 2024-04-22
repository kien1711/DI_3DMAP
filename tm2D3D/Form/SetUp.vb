'Bùi Chí Kiên 22/4/2024 10:36
Imports System.IO
Imports System.IO.Ports
Imports System.Xml

Public Class SetUp
#Region "Biến"
    Dim GocCamera As Integer = 80
    Dim buoc As Double = 5
    Dim LinkDataSaBan As String
    Dim Folder_Data As String
    Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
    Dim LinkDosang As String = "C:\saban\dosang.txt"
    Dim GocDuoi, GocTren As Integer
    Dim tdDoc, tdNgang As Integer
    Dim ChieuCaoLaser, CanhDoc, CanhNgang, CaoTren, CaoDuoi As Integer
    Dim TiLeBuoc As Integer = 16
    Dim BKquay, goc_Doc, goc_Ngang, xung_Doc, xung_Ngang, xung_new_Doc, xung_new_Ngang, xung_old_Doc, xung_old_Ngang As Single
    Dim xung_quay_Doc, xung_quay_Ngang As Integer
    Dim alpha As Single
    Dim SoLuongGoc As Single
    Dim SoLuongXung As Integer
    Dim extra_down, extra_up, extra_right, extra_left As Integer
    Dim Luuextra_down, Luuextra_up, Luuextra_right, Luuextra_left As Integer
    Dim xung_doc_home, xung_ngang_home As Integer
    Dim xungquay As Integer
    Private fileLock As New Object()
    Dim gocquay As Double = 0
    Dim KhoiChay As Integer = 0
    Dim NutDieuKhien As String
    Private WithEvents NhanUp As New System.Windows.Forms.Timer
    Private WithEvents NhanDown As New System.Windows.Forms.Timer
    Private WithEvents DieuKhien As New System.Windows.Forms.Timer
#End Region
#Region "Load"
    Public Sub New()
        InitializeComponent()
        NhanUp.Interval = 100
        NhanDown.Interval = 100
        DieuKhien.Interval = 80
    End Sub
    Private Sub SetUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.TopMost = True
            Me.KeyPreview = True
            Folder_Data = Path.Combine(baseDirectory, "Data")
            LinkDataSaBan = Path.Combine(Folder_Data, "DataSaBan.txt")
            If File.Exists(LinkDosang) Then
                Using reader As New StreamReader(LinkDosang)
                    Dim line As String = reader.ReadLine()
                    If Not String.IsNullOrEmpty(line) Then
                        Dim savedValue As Integer
                        If Integer.TryParse(line, savedValue) Then
                            trackBar1.Value = savedValue
                        End If
                    End If
                End Using
            End If
            Data()
            DocData()
            KhoiChay = 1
            Home()
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Nút Nhấn"
    Private Sub btn_Home_Click(sender As Object, e As EventArgs) Handles btn_Home.Click
        Try
            Home()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Up_Click(sender As Object, e As EventArgs) Handles Up.Click

    End Sub

    Private Sub xoa_home_Click(sender As Object, e As EventArgs) Handles xoa_home.Click
        FrmSBVLM.Instance.TRData("r")
        extra_up = 0
        extra_left = 0
        extra_right = 0
        extra_down = 0
        GhiData()
        DocData()
    End Sub
    Private Sub tb_ChieuCaoLaser_Click(sender As Object, e As EventArgs) Handles tb_ChieuCaoLaser.Click, tb_CaoTren.Click, tb_CaoDuoi.Click, tb_CanhNgang.Click, tb_CanhDoc.Click
        Try
            If Not String.IsNullOrEmpty(tb_ChieuCaoLaser.Text) AndAlso Not String.IsNullOrEmpty(tb_CanhDoc.Text) AndAlso Not String.IsNullOrEmpty(tb_CanhNgang.Text) AndAlso Not String.IsNullOrEmpty(tb_CaoTren.Text) AndAlso Not String.IsNullOrEmpty(tb_CaoDuoi.Text) Then
                If Integer.TryParse(tb_ChieuCaoLaser.Text, ChieuCaoLaser) AndAlso Integer.TryParse(tb_CanhDoc.Text, CanhDoc) AndAlso Integer.TryParse(tb_CanhNgang.Text, CanhNgang) AndAlso Integer.TryParse(tb_CaoTren.Text, CaoTren) AndAlso Integer.TryParse(tb_CaoDuoi.Text, CaoDuoi) Then
                    alpha = Math.Atan((CaoTren - CaoDuoi) / CanhDoc)
                    MessageBox.Show("Giá trị đã được gán.")
                Else
                    MessageBox.Show("Vui lòng nhập giá trị số nguyên hợp lệ.")
                End If
            Else
                MessageBox.Show("Vui lòng nhập giá trị cho cả hai TextBox.")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Up_MouseDown(sender As Object, e As MouseEventArgs) Handles Up.MouseDown, Right.MouseDown, Left.MouseDown, Down.MouseDown
        Dim NutNhan As Button = CType(sender, Button)
        NutDieuKhien = NutNhan.Name
        DieuKhien.Start()
    End Sub
    Private Sub Up_MouseUp(sender As Object, e As MouseEventArgs) Handles Up.MouseUp, Right.MouseUp, Left.MouseUp, Down.MouseUp
        DieuKhien.Stop()
    End Sub
    Private Sub DieuKhien_Tick(sender As Object, e As EventArgs) Handles DieuKhien.Tick
        Try
            If Not String.IsNullOrEmpty(lb_GocQuay.Text) Then
                If Double.TryParse(lb_GocQuay.Text, gocquay) Then
                Else
                    MessageBox.Show("vui lòng nhập giá trị số nguyên hợp lệ.")
                End If
            Else
                MessageBox.Show("vui lòng nhập giá trị cho cả hai textbox.")
            End If
            xungquay = DoToXung(gocquay)
            Select Case NutDieuKhien
                Case "Up"
                    If extra_up < 700 Then
                        extra_up += xungquay
                        If extra_up < 700 Then
                            FrmSBVLM.Instance.TRData("L_0_" + CStr(xungquay) + "_1_0")
                            If extra_down > 0 Then
                                extra_down = extra_down - xungquay
                            End If
                        End If
                    Else
                        xungquay = 0
                    End If
                    Console.WriteLine("Up " + extra_up.ToString())
                Case "Down"
                    If extra_down < 700 Then
                        extra_down += xungquay
                        If extra_down < 700 Then
                            FrmSBVLM.Instance.TRData("L_1_" + CStr(xungquay) + "_0_0")
                            If extra_down > 0 Then
                                extra_up = extra_up - xungquay
                            End If
                        End If
                    Else
                        xungquay = 0
                    End If
                    Console.WriteLine("Down " + extra_down.ToString())
                Case "Left"
                    If extra_left < 150 + extra_right Then
                        extra_left += xungquay
                        If extra_left > 150 Then
                            extra_left = 150
                        End If
                        If extra_left < 150 + extra_right Then
                            FrmSBVLM.Instance.TRData("L_0_0_1_" + CStr(xungquay))
                        End If
                    Else
                        xungquay = 0
                    End If

                    Console.WriteLine("Left " + extra_left.ToString())
                Case "Right"
                    If extra_right < 1000 + extra_left Then
                        extra_right += xungquay
                        If extra_right < 1000 + extra_left Then
                            FrmSBVLM.Instance.TRData("L_0_0_0_" + CStr(xungquay))
                        End If
                    Else
                        xungquay = 0
                    End If
                    If extra_right > 1000 Then
                        extra_right = 1000
                    End If
                    Console.WriteLine("Right" + extra_right.ToString())
            End Select
            xung_doc_home = Math.Abs(extra_up - extra_down)
            xung_ngang_home = Math.Abs(extra_right - extra_left)
            lb_TDDHT.Text = "Góc dọc hiện tại: " + XungToDo(xung_doc_home).ToString + "°"
            lb_TDNHT.Text = "Góc ngang hiện tại: " + XungToDo(xung_ngang_home).ToString + "°"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Sethome_Click(sender As Object, e As EventArgs) Handles btn_Sethome.Click
        GhiData()
    End Sub
    Private Sub btn_Up_buoc_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Up_buoc.MouseDown
        NhanUp.Start()
    End Sub
    Private Sub btn_Up_buoc_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Up_buoc.MouseUp
        NhanUp.Stop()
    End Sub
    Private Sub NhanUp_Tick(sender As Object, e As EventArgs) Handles NhanUp.Tick
        Try
            If buoc < 90 Then
                buoc += 1
                lb_GocQuay.Text = buoc.ToString()
            Else
                NhanUp.Stop() ' Dừng Timer khi giá trị buoc đạt tới 90
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_Down_buoc_MouseDown(sender As Object, e As MouseEventArgs) Handles btn_Down_buoc.MouseDown
        NhanDown.Start()
    End Sub
    Private Sub btn_Down_buoc_MouseUp(sender As Object, e As MouseEventArgs) Handles btn_Down_buoc.MouseUp
        NhanDown.Stop()
    End Sub
    Private Sub NhanDown_Tick(sender As Object, e As EventArgs) Handles NhanDown.Tick
        Try
            If buoc > 0 Then
                buoc = buoc - 1
                lb_GocQuay.Text = buoc.ToString()
            Else
                NhanDown.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub button13_Click(sender As Object, e As EventArgs) Handles button13.Click
        Dim Mau As String
        Dim Tong As String
        If btn_MauMT.FillColor = Color.Red Then
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
                FrmSBVLM.Instance.TRData(Tong)
            End If
        End If
        Me.Hide()
    End Sub
    Private Sub gunaTrackBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles trackBar1.Scroll
        Try
            Dim value As Integer = trackBar1.Value
            SyncLock fileLock  ' Acquire a lock on the lock object
                Using writer As StreamWriter = File.CreateText(LinkDosang)
                    writer.Write(value.ToString())
                End Using
            End SyncLock
            Select Case value
                Case 100
                    FrmSBVLM.Instance.TRData("DS_100")
                    Exit Select
                Case 80 To 99
                    FrmSBVLM.Instance.TRData("DS_100")
                    Exit Select
                Case 60 To 79
                    FrmSBVLM.Instance.TRData("DS_75")
                    Exit Select
                Case 40 To 59
                    FrmSBVLM.Instance.TRData("DS_50")
                    Exit Select
                Case 20 To 39
                    FrmSBVLM.Instance.TRData("DS_25")
                    Exit Select
                Case 0 To 19
                    FrmSBVLM.Instance.TRData("DS_0")
                    Exit Select
                Case Else
                    Exit Select
            End Select
        Catch ex As Exception
            ' Handle the exception
            Console.WriteLine("Error writing to the file: " & ex.Message)
        End Try
    End Sub
    Private Sub btn_MauMT_Click(sender As Object, e As EventArgs) Handles btn_MauMT.Click
        If btn_MauMT.FillColor = Color.Red Then
            btn_MauMT.FillColor = Color.Blue
        ElseIf btn_MauMT.FillColor = Color.Blue Then
            btn_MauMT.FillColor = Color.Red
        End If
        Dim Mau As String
        Dim Tong As String
        If btn_MauMT.FillColor = Color.Red Then
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
                FrmSBVLM.Instance.TRData(Tong)
            End If
        End If
    End Sub
#End Region
#Region "Hàm Con"
    Private Sub Home()
        Try
            FrmSBVLM.Instance.TRData("r")
            If KhoiChay = 1 Then
                extra_up = Luuextra_up
                extra_left = Luuextra_left
                extra_right = Luuextra_right
                extra_down = Luuextra_down
            End If
            System.Threading.Thread.Sleep(7000)
            xung_doc_home = Math.Abs(Luuextra_up - Luuextra_down)
            xung_ngang_home = Math.Abs(Luuextra_right - Luuextra_left)

            If Luuextra_right - Luuextra_left > 0 And Luuextra_up - Luuextra_down > 0 Then
                FrmSBVLM.Instance.TRData("L_0_" + CStr(xung_doc_home) + "_0_" + CStr(xung_ngang_home))
            ElseIf Luuextra_right - Luuextra_left > 0 And Luuextra_up - Luuextra_down < 0 Then
                FrmSBVLM.Instance.TRData("L_1_" + CStr(xung_doc_home) + "_0_" + CStr(xung_ngang_home))
            ElseIf Luuextra_right - Luuextra_left < 0 And Luuextra_up - Luuextra_down > 0 Then
                FrmSBVLM.Instance.TRData("L_0_" + CStr(xung_doc_home) + "_1_" + CStr(xung_ngang_home))
            ElseIf Luuextra_right - Luuextra_left < 0 And Luuextra_up - Luuextra_down < 0 Then
                FrmSBVLM.Instance.TRData("L_1_" + CStr(xung_doc_home) + "_1_" + CStr(xung_ngang_home))
            End If

            lb_TDDHT.Text = "Góc dọc hiện tại: " + XungToDo(xung_doc_home).ToString + "°"
            lb_TDNHT.Text = "Góc ngang hiện tại: " + XungToDo(xung_ngang_home).ToString + "°"
            KhoiChay = 0
        Catch ex As Exception
        End Try
    End Sub
    Public Function IsFloatOrInt(value As String) As Boolean
        Dim intValue As Integer
        Dim floatValue As Single
        Return Int32.TryParse(value, intValue) OrElse Single.TryParse(value, floatValue)
    End Function
    Function DoToXung(ByVal doValue As Double) As Integer
        ' Sử dụng công thức: 1 xung = 0.1125 độ
        Dim xungValue As Integer = doValue / 0.1125
        Return xungValue
    End Function
    Function XungToDo(ByVal XungValue As Double) As Integer
        ' Sử dụng công thức: 1 xung = 0.1125 độ
        Dim DoValue As Integer = XungValue * 0.1125
        Return DoValue
    End Function
#End Region
#Region "Data"
    Private Sub Data()
        Try
            Dim fileName As String = "TruLaser.xml"
            Dim filePath As String = Path.Combine(Folder_Data, fileName)
            If Not File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                Dim rootElement As XmlElement = xmlDoc.CreateElement("DuLieu")
                xmlDoc.AppendChild(rootElement)
                'Luu Data
                Dim Home As XmlElement = xmlDoc.CreateElement("So")
                Home.SetAttribute("ID", "Home")
                Dim extra_up As XmlElement = xmlDoc.CreateElement("extra_up")
                extra_up.InnerText = "0"
                Dim extra_left As XmlElement = xmlDoc.CreateElement("extra_left")
                extra_left.InnerText = "0"
                Dim extra_right As XmlElement = xmlDoc.CreateElement("extra_right")
                extra_right.InnerText = "0"
                Dim extra_down As XmlElement = xmlDoc.CreateElement("extra_down")
                extra_down.InnerText = "0"
                Home.AppendChild(extra_down)
                Home.AppendChild(extra_right)
                Home.AppendChild(extra_left)
                Home.AppendChild(extra_up)
                rootElement.AppendChild(Home)
                xmlDoc.Save(filePath)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DocData()
        Try
            Dim fileName As String = "TruLaser.xml"
            Dim filePath As String = Path.Combine(Folder_Data, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                Dim HomeElement As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='Home']")
                Dim extra_upElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_up"), XmlElement)
                Dim extra_leftElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_left"), XmlElement)
                Dim extra_rightElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_right"), XmlElement)
                Dim extra_downElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_down"), XmlElement)
                Luuextra_up = extra_upElement.InnerText
                Luuextra_left = extra_leftElement.InnerText
                Luuextra_right = extra_rightElement.InnerText
                Luuextra_down = extra_downElement.InnerText
            Else
                MessageBox.Show("Tệp tin TruLaser.xml không tồn tại.")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GhiData()
        Try
            Dim fileName As String = "TruLaser.xml"
            Dim filePath As String = Path.Combine(Folder_Data, fileName)
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                Dim HomeElement As XmlElement = xmlDoc.SelectSingleNode("/DuLieu/So[@ID='Home']")
                Dim extra_upElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_up"), XmlElement)
                Dim extra_leftElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_left"), XmlElement)
                Dim extra_rightElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_right"), XmlElement)
                Dim extra_downElement As XmlElement = DirectCast(HomeElement.SelectSingleNode("extra_down"), XmlElement)
                extra_upElement.InnerText = extra_up
                extra_leftElement.InnerText = extra_left
                extra_rightElement.InnerText = extra_right
                extra_downElement.InnerText = extra_down
                xmlDoc.Save(filePath)
            End If
            Luuextra_up = extra_up
            Luuextra_left = extra_left
            Luuextra_right = extra_right
            Luuextra_down = extra_down
            Console.WriteLine(Luuextra_up.ToString())
            Console.WriteLine(Luuextra_left.ToString())
            Console.WriteLine(Luuextra_right.ToString())
            Console.WriteLine(Luuextra_down.ToString())
        Catch ex As Exception
        End Try
    End Sub
#End Region
End Class