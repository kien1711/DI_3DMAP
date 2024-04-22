
Imports System.IO
Imports System.Threading
Imports System.Xml
Imports Guna.UI2.WinForms

Public Class KichBan
#Region "Biến Toàn Cục"
    Private folderPath As String
    Private folderPath1 As String
    Private TenKichBan As String
    Public Event KichBanToMain As EventHandler(Of String)
    Public Event KichBanToMain1 As EventHandler(Of String)
    Public Event KichBanCanhToMain As EventHandler(Of String)
    Public Event KichBanDataToMain As EventHandler(Of String)
    Public Event KichBanDataToMainToSBS As EventHandler(Of String)
    Private DataCanh As String
    Dim GiaTriTenCanh As String
    Dim GiaTriDoiTuongCanh As String
    Dim ViTriMoi As Integer = 0
    Private MoKichBanSBS As String = 0
    Private rowIndex As Integer = -1
    Private draggedItem As Object = Nothing
    Private isShiftPressed As Boolean = False
    Dim DungDem As Boolean = False
    Dim ThoiGianDem As Integer = 0
    Dim doiten As String
    Dim dem As Integer = 1
    Dim dem1 As Integer = 1
#End Region
#Region "Load"
    Private Sub KichBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim folderName As String = "Data\HA"
            folderPath = Path.Combine(baseDirectory, folderName)
            Dim folderName1 As String = "Data"
            folderPath1 = Path.Combine(baseDirectory, folderName1)
            TimKichBan()
            label_SoCanh.Text = "Tên Cảnh:"
            label_TenCanh.Text = "Đối Tượng Cảnh:"

        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Nút Nhấn"

    Private Sub btn_Create_namekb_Click(sender As Object, e As EventArgs) Handles btn_Create_namekb.Click
        Try

            dem += 1
            If dem Mod 2 <> 0 Then
                pnl_CreateKB2.Visible = False
            Else

                pnl_CreateKB2.Visible = True
                Panel_Doitenkichban.Visible = False
                tb_NameKB.Focus()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_CreateKB_Click(sender As Object, e As EventArgs) Handles btn_CreateKB.Click
        Try
            If tb_NameKB.Text <> "" Then
                TaoKichBan(tb_NameKB.Text)
                TimKichBan()
            Else
                MessageBox.Show("Vui lòng nhập tên kịch bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            tb_NameKB.Text = ""
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_DeleteKB_Click(sender As Object, e As EventArgs) Handles btn_DeleteKB.Click
        Try
            If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                If MessageBox.Show("Kịch bản " & KB_KichBan.Text & " sẽ bị xóa!!" & vbNewLine & "Bạn có muốn xóa không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Try
                        Dim filePath As String = Path.Combine(folderPath1, KB_KichBan.Text & ".xml")
                        File.Delete(filePath)
                        KB_KichBan.Items.Clear()
                        Dim files As String() = Directory.GetFiles(folderPath1, "*.xml") ' Lấy danh sách tất cả các file trong thư mục
                        For Each file As String In files ' Duyệt qua từng file để kiểm tra tên
                            Dim fileName As String = Path.GetFileName(file) ' Lấy tên file từ đường dẫn
                            If fileName.StartsWith("KB_") Then ' Kiểm tra xem tên file có bắt đầu bằng "KB_" hay không
                                Dim itemName As String = Path.GetFileNameWithoutExtension(fileName)
                                KB_KichBan.Items.Add(itemName)
                            End If
                        Next
                        dataGridView1.DataSource = Nothing
                        dataGridView1.Rows.Clear()
                        dataGridView1.Columns.Clear()
                    Catch
                        KB_KichBan.Text = " "
                    End Try
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_NameKB_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Try
                If tb_NameKB.Text <> "" Then
                    TaoKichBan(tb_NameKB.Text)
                    TimKichBan()
                Else
                    MessageBox.Show("Vui lòng nhập tên kịch bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                tb_NameKB.Text = ""
                pnl_CreateKB2.Visible = False
                MessageBox.Show("Tạo kịch bản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub btn_Chan_Click(sender As Object, e As EventArgs) Handles btn_Chan.Click
        Try
            dem1 += 1
            If dem1 Mod 2 <> 0 Then
                Panel_Doitenkichban.Visible = False
            Else
                If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                    pnl_CreateKB2.Visible = False
                    Panel_Doitenkichban.Visible = True
                    Khung_Doitenkichban.Focus()
                    Khung_Doitenkichban.Text = KB_KichBan.Text.Substring(3)
                    Khung_Doitenkichban.SelectAll()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Nut_Doitenkichban_Click(sender As Object, e As EventArgs) Handles Nut_Doitenkichban.Click
        Try
            If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                If Khung_Doitenkichban.Text <> "" Then
                    Dim fileName As String = "KB_" + Khung_Doitenkichban.Text + ".xml"
                    Dim filePath As String = Path.Combine(folderPath1, fileName)
                    If File.Exists(filePath) Then
                        MessageBox.Show("Tên kịch bản đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Khung_Doitenkichban.Text = ""
                    Else

                        Dim oldFileName As String = KB_KichBan.Text & ".xml" ' Tên kịch bản cũ
                        Dim newFileName As String = "KB_" & Khung_Doitenkichban.Text & ".xml" ' Tên kịch bản mới
                        Dim oldFilePath As String = Path.Combine(folderPath1, oldFileName)
                        Dim newFilePath As String = Path.Combine(folderPath1, newFileName)
                        If File.Exists(oldFilePath) Then
                            File.Move(oldFilePath, newFilePath)
                            KB_KichBan.Items.Clear()
                            Dim files As String() = Directory.GetFiles(folderPath1, "*.xml")
                            For Each file As String In files
                                Dim fileName_KB As String = Path.GetFileName(file)
                                If fileName_KB.StartsWith("KB_") Then
                                    Dim itemName As String = Path.GetFileNameWithoutExtension(fileName_KB)
                                    KB_KichBan.Items.Add(itemName)
                                End If
                            Next
                            KB_KichBan.SelectedIndex = 0
                            Khung_Doitenkichban.Text = ""
                            Panel_Doitenkichban.Visible = False
                            MessageBox.Show("Đổi tên kịch bản thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("File không tồn tại: " & oldFileName, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Else
                    MessageBox.Show("Vui lòng nhập tên kịch bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Khung_Doitenkichban_KeyDown(sender As Object, e As KeyEventArgs) Handles Khung_Doitenkichban.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                    If Khung_Doitenkichban.Text <> "" Then
                        Dim fileName As String = "KB_" + Khung_Doitenkichban.Text + ".xml"
                        Dim filePath As String = Path.Combine(folderPath1, fileName)
                        If File.Exists(filePath) Then
                            MessageBox.Show("Tên kịch bản đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Khung_Doitenkichban.Text = ""
                        Else
                            Dim oldFileName As String = KB_KichBan.Text & ".xml" ' Tên kịch bản cũ
                            Dim newFileName As String = "KB_" & Khung_Doitenkichban.Text & ".xml" ' Tên kịch bản mới
                            Dim oldFilePath As String = Path.Combine(folderPath1, oldFileName)
                            Dim newFilePath As String = Path.Combine(folderPath1, newFileName)
                            If File.Exists(oldFilePath) Then
                                File.Move(oldFilePath, newFilePath)
                                KB_KichBan.Items.Clear()
                                Dim files As String() = Directory.GetFiles(folderPath1, "*.xml")
                                For Each file As String In files
                                    Dim fileName_KB As String = Path.GetFileName(file)
                                    If fileName_KB.StartsWith("KB_") Then
                                        Dim itemName As String = Path.GetFileNameWithoutExtension(fileName_KB)
                                        KB_KichBan.Items.Add(itemName)
                                    End If
                                Next
                                KB_KichBan.SelectedIndex = 0
                                Khung_Doitenkichban.Text = ""
                                Panel_Doitenkichban.Visible = False
                                MessageBox.Show("Đổi tên kịch bản thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("File không tồn tại: " & oldFileName, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    Else
                        MessageBox.Show("Vui lòng nhập tên kịch bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub btn_Add_scene_Click(sender As Object, e As EventArgs)
        Try
            If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                RaiseEvent KichBanToMain(Me, KB_KichBan.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_RenameScene_Click(sender As Object, e As EventArgs) Handles btn_RenameScene.Click
        Try
            Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            If GiaTriTenCanh <> "" Then
                pnl_DoiTenCanh.Visible = True
                tb_DoiTenCanh.Text = GiaTriTenCanh
                tb_DoiTenCanh.Focus()
                tb_DoiTenCanh.SelectAll()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_DoiTenCanh_Click(sender As Object, e As EventArgs) Handles btn_DoiTenCanh.Click
        Try
            DoiTenCanh()
            pnl_DoiTenCanh.Visible = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tb_DoiTenCanh_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If e.KeyCode = Keys.Enter Then
                DoiTenCanh()
                pnl_DoiTenCanh.Visible = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dataGridView1.CellMouseClick
        If e.Button = MouseButtons.Right AndAlso e.RowIndex >= 0 Then
            dataGridView1.ClearSelection()
            dataGridView1.Rows(e.RowIndex).Selected = True
            Dim contextMenuStrip As New ContextMenuStrip()
            Dim listBox As New ListBox()
            listBox.Items.Add("Xóa cảnh")
            listBox.Items.Add("Thêm cảnh")
            listBox.Items.Add("Sửa cảnh")
            listBox.Items.Add("Đổi tên cảnh")
            AddHandler listBox.SelectedIndexChanged, AddressOf ContextMenu_SelectedIndexChanged
            listBox.BorderStyle = BorderStyle.None
            AddHandler listBox.SelectedIndexChanged, Sub(senderListBox, eventArgs)
                                                         contextMenuStrip.Close()
                                                     End Sub
            Dim toolStripControlHost As New ToolStripControlHost(listBox)
            contextMenuStrip.Items.Add(toolStripControlHost)
            contextMenuStrip.ShowImageMargin = False
            contextMenuStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode
            contextMenuStrip.BackColor = SystemColors.Window
            listBox.Size = New Size(contextMenuStrip.Width - 2, contextMenuStrip.Height - 2)
            listBox.Font = New Font(listBox.Font.FontFamily, 14)
            Dim cursorPosition As Point = dataGridView1.PointToClient(Cursor.Position)
            contextMenuStrip.Show(dataGridView1, cursorPosition)
        End If
    End Sub
    Private Sub ContextMenu_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim listBox As ListBox = DirectCast(sender, ListBox)
        Dim selectedOption As String = listBox.SelectedItem.ToString()
        Select Case selectedOption
            Case "Xóa cảnh"
                Try
                    Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                    Dim result As DialogResult = MessageBox.Show("Xóa Cảnh " & GiaTriTenCanh, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    If result = DialogResult.Yes Then
                        Dim fileName As String = TenKichBan + ".xml"
                        Dim filePath As String = Path.Combine(folderPath1, fileName)
                        Dim xmlDoc As New XmlDocument()
                        xmlDoc.Load(filePath)
                        Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{GiaTriTenCanh}']")
                        If bitNode IsNot Nothing Then
                            bitNode.ParentNode.RemoveChild(bitNode)
                            xmlDoc.Save(filePath)
                            LoadKichBan()
                        End If
                    End If
                Catch ex As Exception
                End Try
            Case "Thêm cảnh"
                Try
                    FrmSBVLM.Instance.tb_truyen.Text = "10"
                    If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                        RaiseEvent KichBanToMain1(Me, KB_KichBan.Text)
                    End If
                    FrmSBVLM.Instance.themcanhtong1 = 0
                Catch ex As Exception
                End Try
            Case "Sửa cảnh"
                Try
                    FrmSBVLM.Instance.tb_truyen.Text = "01"
                    If Not String.IsNullOrEmpty(KB_KichBan.Text) Then

                        Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                        Dim Data As String = GiaTriTenCanh + "," + TenKichBan

                        If Not String.IsNullOrEmpty(GiaTriTenCanh) Then
                            RaiseEvent KichBanCanhToMain(Me, Data)
                        End If
                    End If
                Catch ex As Exception
                End Try
            Case "Đổi tên cảnh"
                Try
                    Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                    If GiaTriTenCanh <> "" Then
                        pnl_DoiTenCanh.Visible = True
                        tb_DoiTenCanh.Text = GiaTriTenCanh
                        tb_DoiTenCanh.Focus()
                        tb_DoiTenCanh.SelectAll()
                    End If
                Catch ex As Exception
                End Try
        End Select
    End Sub

    Private Sub btn_Delete_scene_Click(sender As Object, e As EventArgs) Handles btn_Delete_scene.Click
        Try
            Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Dim result As DialogResult = MessageBox.Show("Xóa Cảnh " & GiaTriTenCanh, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                Dim fileName As String = TenKichBan + ".xml"
                Dim filePath As String = Path.Combine(folderPath1, fileName)
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{GiaTriTenCanh}']")
                If bitNode IsNot Nothing Then
                    bitNode.ParentNode.RemoveChild(bitNode)
                    xmlDoc.Save(filePath)
                    LoadKichBan()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_Edit_scene_Click(sender As Object, e As EventArgs) Handles btn_Edit_scene.Click
        Try

            FrmSBVLM.Instance.tb_truyen.Text = "01"
            If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                Dim Data As String
                Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                Data = GiaTriTenCanh + "," + TenKichBan
                FrmSBVLM.Instance.tb_kbtruyen.Text = Data
                If Not String.IsNullOrEmpty(GiaTriTenCanh) Then
                    RaiseEvent KichBanCanhToMain(Me, Data)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub bt_Xuatfile_Click(sender As Object, e As EventArgs) Handles bt_Xuatfile.Click
        Try
            Dim folderBrowserDialog As New FolderBrowserDialog()
            folderBrowserDialog.Description = "Chọn vị trí lưu thư mục kịch bản"
            If folderBrowserDialog.ShowDialog() = DialogResult.OK Then
                Dim selectedFolderPath As String = folderBrowserDialog.SelectedPath
                Dim bitDonFolderPath As String = Path.Combine(selectedFolderPath, "KichBan")
                If Not Directory.Exists(bitDonFolderPath) Then
                    Directory.CreateDirectory(bitDonFolderPath)
                End If
                Dim sourceFiles As String() = Directory.GetFiles(folderPath1, "KB_*.xml")
                For Each sourceFilePath As String In sourceFiles
                    Dim fileName As String = Path.GetFileName(sourceFilePath)
                    Dim destinationFilePath As String = Path.Combine(bitDonFolderPath, fileName)
                    File.Copy(sourceFilePath, destinationFilePath, True)
                Next
                MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub bt_addfile_Click(sender As Object, e As EventArgs) Handles bt_addfile.Click
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
                TimKichBan()
                MessageBox.Show("Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_CanhSau_Click(sender As Object, e As EventArgs) Handles btn_CanhSau.Click
        CanhSau()
    End Sub
    Public Sub CanhSau()
        Try
            If MoKichBanSBS = 1 Then
                If FrmMain.Instance.RMSBS = True Then
                    FrmMain.Instance.btnTien.PerformClick()
                End If
            ElseIf MoKichBanSBS = 0 Then
                If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                    If dataGridView1.SelectedRows.Count = 0 Then
                        dataGridView1.Rows(0).Selected = True
                        GiaTriTenCanh = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                        GiaTriDoiTuongCanh = dataGridView1.SelectedRows(0).Cells(1).Value.ToString()
                        lb_IDKB.Text = GiaTriTenCanh
                        lb_NameScene.Text = GiaTriDoiTuongCanh
                        TruyenDataToMain(GiaTriTenCanh)
                    ElseIf dataGridView1.SelectedRows.Count > 0 Then
                        Dim rowCount As Integer = dataGridView1.Rows.Count - 1
                        Dim selectedRow As DataGridViewRow = dataGridView1.SelectedRows(0)
                        Dim selectedRowIndex As Integer = selectedRow.Index
                        If selectedRowIndex < rowCount Then
                            selectedRowIndex = selectedRowIndex + 1
                            dataGridView1.Rows(selectedRowIndex).Selected = True
                            GiaTriTenCanh = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                            GiaTriDoiTuongCanh = dataGridView1.SelectedRows(0).Cells(1).Value.ToString()
                            lb_IDKB.Text = GiaTriTenCanh
                            lb_NameScene.Text = GiaTriDoiTuongCanh
                            TruyenDataToMain(GiaTriTenCanh)
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_CanhTruoc_Click(sender As Object, e As EventArgs) Handles btn_CanhTruoc.Click
        CanhTruoc()
    End Sub
    Public Sub CanhTruoc()
        Try
            If MoKichBanSBS = 1 Then
                If FrmMain.Instance.RMSBS = True Then
                    FrmMain.Instance.btnLui.PerformClick()
                End If
            ElseIf MoKichBanSBS = 0 Then
                Dim GiaTriTenCanh As String
                Dim GiaTriDoiTuongCanh As String

                If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                    If dataGridView1.SelectedRows.Count = 0 Then
                        dataGridView1.Rows(0).Selected = True
                        GiaTriTenCanh = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                        GiaTriDoiTuongCanh = dataGridView1.SelectedRows(0).Cells(1).Value.ToString()
                        lb_IDKB.Text = GiaTriTenCanh
                        lb_NameScene.Text = GiaTriDoiTuongCanh
                        TruyenDataToMain(GiaTriTenCanh)
                    ElseIf dataGridView1.SelectedRows.Count > 0 Then
                        Dim rowCount As Integer = dataGridView1.Rows.Count
                        Dim selectedRow As DataGridViewRow = dataGridView1.SelectedRows(0)
                        Dim selectedRowIndex As Integer = selectedRow.Index
                        If selectedRowIndex < rowCount Then
                            If selectedRowIndex > 0 Then
                                selectedRowIndex = selectedRowIndex - 1
                                dataGridView1.Rows(selectedRowIndex).Selected = True
                                GiaTriTenCanh = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
                                GiaTriDoiTuongCanh = dataGridView1.SelectedRows(0).Cells(1).Value.ToString()
                                lb_IDKB.Text = GiaTriTenCanh
                                lb_NameScene.Text = GiaTriDoiTuongCanh
                                TruyenDataToMain(GiaTriTenCanh)
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Hàm Con"
    Private Sub TaoKichBan(data As String)
        Try
            Dim fileName As String = "KB_" + data + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            If File.Exists(filePath) Then
                MessageBox.Show("Tên kịch bản đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                pnl_CreateKB2.Visible = True
            Else
                Dim xmlDoc As New XmlDocument() ' Tạo một tài liệu XML mới
                Dim rootElement As XmlElement = xmlDoc.CreateElement("KichBan")
                xmlDoc.AppendChild(rootElement) ' Thêm phần tử root vào tài liệu XML
                xmlDoc.Save(filePath) ' Lưu tệp XML
                MessageBox.Show("Tạo kịch bản thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                pnl_CreateKB2.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TimKichBan()
        Try
            Dim xmlFiles As String() = Directory.GetFiles(folderPath1, "KB_*.xml")
            KB_KichBan.Items.Clear()
            For Each xmlFile As String In xmlFiles
                Dim tenTepXML As String = Path.GetFileNameWithoutExtension(xmlFile)
                KB_KichBan.Items.Add(tenTepXML)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadKichBan()
        Try

            Dim fileName As String = TenKichBan & ".xml" ' Tên file XML
            Dim filePath As String = Path.Combine(folderPath1, fileName) ' Đường dẫn đầy đủ của file
            Dim db As New DataTable() ' Tạo cấu trúc bảng
            db.Columns.Add("Tên Cảnh")
            db.Columns.Add("Tên Đối Tượng")
            If File.Exists(filePath) Then
                Dim xmlDoc As New XmlDocument()
                xmlDoc.Load(filePath)
                Dim nodeList As XmlNodeList = xmlDoc.SelectNodes("//TenCanh")
                For Each node As XmlNode In nodeList
                    Dim newRow As DataRow = db.NewRow() ' Thêm dòng dữ liệu vào bảng
                    newRow("Tên Cảnh") = node.Attributes("ID").Value
                    newRow("Tên Đối Tượng") = node.SelectSingleNode("BitCanh").InnerText
                    db.Rows.Add(newRow)
                Next
                dataGridView1.DataSource = db ' Hiển thị trong dataGridView1
                dataGridView1.Columns("Tên Cảnh").Width = 100 ' Cột NameScene độ rộng 50
                dataGridView1.Columns("Tên Đối Tượng").Width = 500 ' Cột NameBit độ rộng 600
                dataGridView1.Columns("Tên Cảnh").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dataGridView1.Columns("Tên Cảnh").SortMode = DataGridViewColumnSortMode.NotSortable
                dataGridView1.Columns("Tên Đối Tượng").SortMode = DataGridViewColumnSortMode.NotSortable
                dataGridView1.ClearSelection() ' xóa dòng đã chọn trong datagridview1

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DoiTenCanh()
        Try
            Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
            xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{GiaTriTenCanh}']")
            If bitNode IsNot Nothing Then
                bitNode.Attributes("ID").Value = tb_DoiTenCanh.Text ' Ghi giá trị mới vào phần tử <Name>
                xmlDoc.Save(filePath) ' Lưu lại tệp XML sau khi chỉnh sửa
                LoadKichBan()
                tb_DoiTenCanh.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TruyenDataToMain(data As String)
        Try
            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument() ' Tạo đối tượng XmlDocument
            xmlDoc.Load(filePath) ' Load tệp XML từ đường dẫn
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{data}']/Data")

            If bitNode IsNot Nothing Then
                DataCanh = bitNode.InnerText
                Dim txt2 As String = ""

                For i As Integer = 0 To DataCanh.Length - 1
                    If DataCanh(i) = "0"c Then
                        txt2 &= "00"
                    End If
                    If DataCanh(i) = "1"c Then
                        txt2 &= "01"
                    End If
                    If DataCanh(i) = "2"c Then
                        txt2 &= "11"
                    End If
                Next
                Dim hexList As List(Of String) = Enumerable.Range(0, txt2.Length \ 8) _
                            .Select(Function(i) txt2.Substring(8 * i, 8)) _
                            .Select(Function(s) Convert.ToByte(s, 2)) _
                            .Select(Function(b) b.ToString("X2")) _
                            .ToList()
                Dim hex As String = String.Concat(hexList)
                lb_DataCanh.Text = hex
                RaiseEvent KichBanDataToMain(Me, hex)
                RaiseEvent KichBanDataToMainToSBS(Me, DataCanh)
            End If

        Catch ex As Exception
        End Try
    End Sub
    Public Sub resetKichBan()
        lb_IDKB.Text = ""
        lb_NameScene.Text = ""
        lb_DataCanh.Text = ""
    End Sub
#End Region
#Region "Nhận dữ liệu"
#End Region
#Region "Chọn Kịch Bản"
    Private Sub KB_KichBan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles KB_KichBan.SelectedIndexChanged
        Try
            If KB_KichBan.SelectedIndex >= 0 Then
                TenKichBan = KB_KichBan.Text
                LoadKichBan()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub truyenkb(data As String)
        doiten = 0
        If dataGridView1.Rows.Count = 0 Then
            Return
        End If
        Dim found As Boolean = False
        For Each row As DataGridViewRow In dataGridView1.Rows
            If row.Cells(0).Value IsNot Nothing AndAlso data = row.Cells(0).Value.ToString() Then
                doiten = 1
                found = True
                Exit For
            End If
        Next
        If Not found Then
            doiten = 0
        End If
        FrmSBVLM.Instance.doiten = doiten
    End Sub
    Private Sub dataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dataGridView1.CellDoubleClick
        Try

            Dim GiaTriTenCanh As String
            Dim GiaTriDoiTuongCanh As String
            GiaTriTenCanh = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            GiaTriDoiTuongCanh = dataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            lb_IDKB.Text = GiaTriTenCanh
            lb_NameScene.Text = GiaTriDoiTuongCanh
            TruyenDataToMain(GiaTriTenCanh)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub kichbanSBS()
        Try
            KB_KichBan.Enabled = False
            dataGridView1.Enabled = False
            pnl_Script.Enabled = False
            pnl_DKKichBan.Enabled = False
            btn_ThoatKBSBS.Enabled = True
            label_BitCanh.Visible = False
            label_TenCanh.Visible = True
            label_SoCanh.Visible = True
            lb_IDKB.Visible = True
            lb_NameScene.Visible = True
            lb_DataCanh.Visible = False
            KB_KichBan.ClearSelected()
            dataGridView1.DataSource = Nothing
            dataGridView1.Rows.Clear()
            dataGridView1.Columns.Clear()
            label_SoCanh.Text = "Số Cảnh:"
            label_TenCanh.Text = "Tên Cảnh:"
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btn_KichBanSBS_Click(sender As Object, e As EventArgs) Handles btn_KichBanSBS.Click
        Try
            If MoKichBanSBS = 0 Then
                MoKichBanSBS = 1
                KB_KichBan.Enabled = False
                dataGridView1.Enabled = False
                pnl_Script.Enabled = False
                pnl_DKKichBan.Enabled = False
                btn_ThoatKBSBS.Enabled = True
                label_BitCanh.Visible = False
                label_TenCanh.Visible = True
                label_SoCanh.Visible = True
                lb_IDKB.Visible = True
                lb_NameScene.Visible = True
                lb_DataCanh.Visible = False
                KB_KichBan.ClearSelected()
                dataGridView1.DataSource = Nothing
                dataGridView1.Rows.Clear()
                dataGridView1.Columns.Clear()
                FrmMain.Instance.TrinhchieuPN()
                label_SoCanh.Text = "Số Cảnh:"
                label_TenCanh.Text = "Tên Cảnh:"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub trangkichban()
        Try
            If MoKichBanSBS = 1 Then
                MoKichBanSBS = 0
                KB_KichBan.Enabled = True
                dataGridView1.Enabled = True
                pnl_Script.Enabled = True
                pnl_DKKichBan.Enabled = True
                label_BitCanh.Visible = True
                label_TenCanh.Visible = True
                label_SoCanh.Visible = True
                lb_IDKB.Visible = True
                lb_NameScene.Visible = True
                lb_DataCanh.Visible = True
                FrmMain.Instance.btnCloseTrC.PerformClick()
                btn_ThoatKBSBS.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub thoatkichban()
        If MoKichBanSBS = 1 Then
            MoKichBanSBS = 0
            KB_KichBan.Enabled = True
            dataGridView1.Enabled = True
            pnl_Script.Enabled = True
            pnl_DKKichBan.Enabled = True
            label_BitCanh.Visible = True
            label_TenCanh.Visible = True
            label_SoCanh.Visible = True
            lb_IDKB.Visible = True
            lb_NameScene.Visible = True
            lb_DataCanh.Visible = True
            btn_ThoatKBSBS.Enabled = False
            label_SoCanh.Text = "Tên Cảnh:"
            label_TenCanh.Text = "Đối Tượng Cảnh:"
            lb_IDKB.Text = " "
            lb_NameScene.Text = " "
            FrmMain.Instance.motrinhchieu = False
            Me.Invoke(Sub()
                          FrmMain.Instance.btnCloseTrC.PerformClick()
                      End Sub)
        End If
    End Sub
    Private Sub btn_ThoatKBSBS_Click(sender As Object, e As EventArgs) Handles btn_ThoatKBSBS.Click
        Try
            thoatkichban()

        Catch ex As Exception
        End Try
    End Sub
    Public Sub thoatkbsbs()
        Try
            MoKichBanSBS = 0
            KB_KichBan.Enabled = True
            dataGridView1.Enabled = True
            pnl_Script.Enabled = True
            pnl_DKKichBan.Enabled = True
            label_BitCanh.Visible = True
            label_TenCanh.Visible = True
            label_SoCanh.Visible = True
            lb_IDKB.Visible = True
            lb_NameScene.Visible = True
            lb_DataCanh.Visible = True
            FrmMain.Instance.btnCloseTrC.PerformClick()
            btn_ThoatKBSBS.Enabled = False
            label_SoCanh.Text = "Tên Cảnh:"
            label_TenCanh.Text = "Đối Tượng Cảnh:"
            lb_IDKB.Text = " "
            lb_NameScene.Text = " "
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DemTime_Tick(sender As Object, e As EventArgs) Handles DemTime.Tick
        ThoiGianDem += 1
        If ThoiGianDem >= 7 Then
            If dataGridView1.SelectedRows.Count > 0 Then
                rowIndex = dataGridView1.SelectedRows(0).Index
                If rowIndex >= 0 Then
                    GiaTriTenCanh = dataGridView1.Rows(rowIndex).Cells(0).Value.ToString()
                    If TypeOf dataGridView1.DataSource Is DataTable Then
                        Dim dataTable As DataTable = DirectCast(dataGridView1.DataSource, DataTable)
                        If rowIndex < dataTable.Rows.Count Then
                            draggedItem = dataTable.Rows(rowIndex).ItemArray.Clone()
                        End If
                    End If
                    dataGridView1.DoDragDrop(draggedItem, DragDropEffects.Move)
                End If
            End If
        End If
    End Sub
    Private Sub dataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles dataGridView1.MouseDown
        Try
            If e.Button = MouseButtons.Left Then
                DungDem = True
                ThoiGianDem = 0
                DemTime.Start()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dataGridView1_MouseUp(sender As Object, e As MouseEventArgs) Handles dataGridView1.MouseUp
        DemTime.Stop()
        DungDem = False
        ThoiGianDem = 0
    End Sub
    Private Sub dataGridView1_DragOver(sender As Object, e As DragEventArgs) Handles dataGridView1.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub dataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles dataGridView1.DragDrop
        Try
            dataGridView1.ClearSelection()
            Dim targetRowIndex = dataGridView1.HitTest(dataGridView1.PointToClient(New Point(e.X, e.Y)).X, dataGridView1.PointToClient(New Point(e.X, e.Y)).Y).RowIndex
            If targetRowIndex >= 0 AndAlso targetRowIndex <> rowIndex Then
                If TypeOf dataGridView1.DataSource Is DataTable Then
                    Dim dataTable = DirectCast(dataGridView1.DataSource, DataTable)
                    dataTable.Rows.RemoveAt(rowIndex)
                    dataTable.Rows.InsertAt(dataTable.NewRow(), targetRowIndex)
                    dataTable.Rows(targetRowIndex).ItemArray = DirectCast(draggedItem, Object())
                    dataGridView1.Rows(targetRowIndex).Selected = True
                    ViTriMoi = targetRowIndex
                    DoiviTri()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DoiviTri()
        Try
            Dim fileName As String = TenKichBan & ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath)
            Dim parentNode As XmlNode = xmlDoc.SelectSingleNode("/KichBan")
            For Each row As DataGridViewRow In dataGridView1.Rows
                If Not row.IsNewRow Then
                    Dim TenCanh As String = row.Cells(0).Value.ToString()
                    Dim node1 As XmlNode = parentNode.SelectSingleNode($"TenCanh[@ID='{TenCanh}']")
                    If node1 IsNot Nothing Then
                        parentNode.RemoveChild(node1)
                        parentNode.AppendChild(node1)
                    Else
                        MessageBox.Show($"Không tìm thấy nút với ID={TenCanh}")
                    End If
                End If
            Next
            xmlDoc.Save(filePath)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub TKB()
        btn_KichBanSBS.Enabled = True
    End Sub
    Public Sub TKB1()
        btn_KichBanSBS.Enabled = False
    End Sub

    Private Sub bt_themcanhtong_Click(sender As Object, e As EventArgs) Handles bt_themcanhtong.Click
        Try
            FrmSBVLM.Instance.tb_truyen.Text = "10"
            If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                RaiseEvent KichBanToMain1(Me, KB_KichBan.Text)
            End If
            FrmSBVLM.Instance.themcanhtong1 = 0
        Catch ex As Exception
        End Try
    End Sub





    Private Sub tb_DoiTenCanh_KeyDown_1(sender As Object, e As KeyEventArgs) Handles tb_DoiTenCanh.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                DoiTenCanh()
                pnl_DoiTenCanh.Visible = False
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub tb_NameKB_KeyDown_1(sender As Object, e As KeyEventArgs) Handles tb_NameKB.KeyDown
        If e.KeyCode = Keys.Enter Then
            Try
                If tb_NameKB.Text <> "" Then
                    TaoKichBan(tb_NameKB.Text)
                    TimKichBan()
                Else
                    MessageBox.Show("Vui lòng nhập tên kịch bản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
                tb_NameKB.Text = ""
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub bn_vitri_Click(sender As Object, e As EventArgs) Handles bn_vitri.Click
        Try
            Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath)
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{GiaTriTenCanh}']/Location")
            If bitNode IsNot Nothing Then
                bitNode.InnerText = FrmSBVLM.Instance.tb_truyenvitri.Text
                xmlDoc.Save(filePath)
                LoadKichBan()
                MessageBox.Show("Đã lưu vị trí thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_FlytoScene_Click(sender As Object, e As EventArgs) Handles btn_FlytoScene.Click
        Try
            Dim GiaTriTenCanh As String = dataGridView1.SelectedRows(0).Cells(0).Value.ToString()

            Dim fileName As String = TenKichBan + ".xml"
            Dim filePath As String = Path.Combine(folderPath1, fileName)
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(filePath)
            Dim bitNode As XmlNode = xmlDoc.SelectSingleNode($"/KichBan/TenCanh[@ID='{GiaTriTenCanh}']/Location")
            Dim GiaTriDoiTuongCanh As String = dataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            lb_IDKB.Text = GiaTriTenCanh
            lb_NameScene.Text = GiaTriDoiTuongCanh
            TruyenDataToMain(GiaTriTenCanh)
            If bitNode IsNot Nothing Then
                FrmSBVLM.Instance.tb_truyentoado.Text = bitNode.InnerText
                LoadKichBan()
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub KB_KichBan_KeyDown(sender As Object, e As KeyEventArgs) Handles KB_KichBan.KeyDown
        If e.KeyCode = Keys.Delete Then
            Try
                If Not String.IsNullOrEmpty(KB_KichBan.Text) Then
                    If MessageBox.Show("Kịch bản " & KB_KichBan.Text & " sẽ bị xóa!!" & vbNewLine & "Bạn có muốn xóa không?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        Try
                            Dim filePath As String = Path.Combine(folderPath1, KB_KichBan.Text & ".xml")
                            File.Delete(filePath)
                            KB_KichBan.Items.Clear()
                            Dim files As String() = Directory.GetFiles(folderPath1, "*.xml") ' Lấy danh sách tất cả các file trong thư mục
                            For Each file As String In files ' Duyệt qua từng file để kiểm tra tên
                                Dim fileName As String = Path.GetFileName(file) ' Lấy tên file từ đường dẫn
                                If fileName.StartsWith("KB_") Then ' Kiểm tra xem tên file có bắt đầu bằng "KB_" hay không
                                    Dim itemName As String = Path.GetFileNameWithoutExtension(fileName)
                                    KB_KichBan.Items.Add(itemName)
                                End If
                            Next
                            dataGridView1.DataSource = Nothing
                            dataGridView1.Rows.Clear()
                            dataGridView1.Columns.Clear()
                        Catch
                            KB_KichBan.Text = " "
                        End Try
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub





















#End Region
#Region "Trang Thái Nút Nhấn Mới"
    'Private Sub Button1_MouseClick(sender As Object, e As MouseEventArgs) Handles Button1.MouseClick, Button2.MouseClick
    '    ' Lấy tên của button được nhấn
    '    Dim clickedButton As Button = DirectCast(sender, Button)
    '    Dim buttonName As String = clickedButton.Name

    '    ' Lấy toạ độ x và y của sự kiện
    '    Dim xCoordinate As Integer = e.X
    '    Dim yCoordinate As Integer = e.Y

    '    If (xCoordinate > 60) Then

    '        clickedButton.Text = "2"
    '    ElseIf (xCoordinate > 30) Then

    '        clickedButton.Text = "1"
    '    Else
    '        clickedButton.Text = "0"
    '    End If
    'End Sub
#End Region
End Class
