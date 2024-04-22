<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class KichBan
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KichBan))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panel3 = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.lb_DataCanh = New System.Windows.Forms.TextBox()
        Me.lb_IDKB = New System.Windows.Forms.TextBox()
        Me.label_CanhDangChay = New System.Windows.Forms.Label()
        Me.btn_ThoatKBSBS = New System.Windows.Forms.Button()
        Me.label_TenCanh = New System.Windows.Forms.Label()
        Me.btn_KichBanSBS = New System.Windows.Forms.Button()
        Me.label_SoCanh = New System.Windows.Forms.Label()
        Me.lb_NameScene = New System.Windows.Forms.TextBox()
        Me.btn_CanhSau = New System.Windows.Forms.Button()
        Me.label_BitCanh = New System.Windows.Forms.Label()
        Me.btn_CanhTruoc = New System.Windows.Forms.Button()
        Me.pnl_DKKichBan = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.bt_themcanhtong = New System.Windows.Forms.Button()
        Me.pnl_DoiTenCanh = New System.Windows.Forms.Panel()
        Me.tb_DoiTenCanh = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_DoiTenCanh = New System.Windows.Forms.Button()
        Me.lablecc = New System.Windows.Forms.Label()
        Me.bn_vitri = New System.Windows.Forms.Button()
        Me.btn_Edit_scene = New System.Windows.Forms.Button()
        Me.btn_FlytoScene = New System.Windows.Forms.Button()
        Me.btn_Delete_scene = New System.Windows.Forms.Button()
        Me.btn_RenameScene = New System.Windows.Forms.Button()
        Me.label_Canh = New System.Windows.Forms.Label()
        Me.pnl_Script = New Guna.UI2.WinForms.Guna2GroupBox()
        Me.bt_Xuatfile = New System.Windows.Forms.Button()
        Me.label_KichBan = New System.Windows.Forms.Label()
        Me.bt_addfile = New System.Windows.Forms.Button()
        Me.btn_Create_namekb = New System.Windows.Forms.Button()
        Me.btn_Chan = New System.Windows.Forms.Button()
        Me.btn_DeleteKB = New System.Windows.Forms.Button()
        Me.pnl_CreateKB2 = New System.Windows.Forms.Panel()
        Me.tb_NameKB = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_CreateKB = New System.Windows.Forms.Button()
        Me.label_TenKichBan = New System.Windows.Forms.Label()
        Me.Panel_Doitenkichban = New System.Windows.Forms.Panel()
        Me.Khung_Doitenkichban = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Nut_Doitenkichban = New System.Windows.Forms.Button()
        Me.label_DoiTenKichBan = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.KB_KichBan = New System.Windows.Forms.ListBox()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.DemTime = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.panel3.SuspendLayout()
        Me.pnl_DKKichBan.SuspendLayout()
        Me.pnl_DoiTenCanh.SuspendLayout()
        Me.pnl_Script.SuspendLayout()
        Me.pnl_CreateKB2.SuspendLayout()
        Me.Panel_Doitenkichban.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.panel3)
        Me.Panel1.Controls.Add(Me.pnl_DKKichBan)
        Me.Panel1.Controls.Add(Me.pnl_Script)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dataGridView1)
        Me.Panel1.Controls.Add(Me.KB_KichBan)
        Me.Panel1.Location = New System.Drawing.Point(120, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1479, 950)
        Me.Panel1.TabIndex = 0
        '
        'panel3
        '
        Me.panel3.BorderColor = System.Drawing.Color.Black
        Me.panel3.BorderRadius = 20
        Me.panel3.BorderThickness = 2
        Me.panel3.Controls.Add(Me.lb_DataCanh)
        Me.panel3.Controls.Add(Me.lb_IDKB)
        Me.panel3.Controls.Add(Me.label_CanhDangChay)
        Me.panel3.Controls.Add(Me.btn_ThoatKBSBS)
        Me.panel3.Controls.Add(Me.label_TenCanh)
        Me.panel3.Controls.Add(Me.btn_KichBanSBS)
        Me.panel3.Controls.Add(Me.label_SoCanh)
        Me.panel3.Controls.Add(Me.lb_NameScene)
        Me.panel3.Controls.Add(Me.btn_CanhSau)
        Me.panel3.Controls.Add(Me.label_BitCanh)
        Me.panel3.Controls.Add(Me.btn_CanhTruoc)
        Me.panel3.CustomBorderColor = System.Drawing.Color.White
        Me.panel3.CustomBorderThickness = New System.Windows.Forms.Padding(0)
        Me.panel3.FillColor = System.Drawing.Color.WhiteSmoke
        Me.panel3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.panel3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.panel3.Location = New System.Drawing.Point(3, 695)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(491, 250)
        Me.panel3.TabIndex = 54
        '
        'lb_DataCanh
        '
        Me.lb_DataCanh.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lb_DataCanh.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lb_DataCanh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_DataCanh.Location = New System.Drawing.Point(154, 133)
        Me.lb_DataCanh.Name = "lb_DataCanh"
        Me.lb_DataCanh.ReadOnly = True
        Me.lb_DataCanh.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lb_DataCanh.Size = New System.Drawing.Size(314, 19)
        Me.lb_DataCanh.TabIndex = 54
        '
        'lb_IDKB
        '
        Me.lb_IDKB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lb_IDKB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lb_IDKB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_IDKB.Location = New System.Drawing.Point(125, 65)
        Me.lb_IDKB.Name = "lb_IDKB"
        Me.lb_IDKB.ReadOnly = True
        Me.lb_IDKB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lb_IDKB.Size = New System.Drawing.Size(346, 19)
        Me.lb_IDKB.TabIndex = 53
        '
        'label_CanhDangChay
        '
        Me.label_CanhDangChay.AutoSize = True
        Me.label_CanhDangChay.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_CanhDangChay.ForeColor = System.Drawing.Color.Black
        Me.label_CanhDangChay.Location = New System.Drawing.Point(3, 22)
        Me.label_CanhDangChay.Name = "label_CanhDangChay"
        Me.label_CanhDangChay.Size = New System.Drawing.Size(236, 31)
        Me.label_CanhDangChay.TabIndex = 11
        Me.label_CanhDangChay.Text = "Cảnh Đang Chạy"
        '
        'btn_ThoatKBSBS
        '
        Me.btn_ThoatKBSBS.Enabled = False
        Me.btn_ThoatKBSBS.FlatAppearance.BorderSize = 0
        Me.btn_ThoatKBSBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_ThoatKBSBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ThoatKBSBS.ForeColor = System.Drawing.Color.Black
        Me.btn_ThoatKBSBS.Image = CType(resources.GetObject("btn_ThoatKBSBS.Image"), System.Drawing.Image)
        Me.btn_ThoatKBSBS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_ThoatKBSBS.Location = New System.Drawing.Point(364, 10)
        Me.btn_ThoatKBSBS.Name = "btn_ThoatKBSBS"
        Me.btn_ThoatKBSBS.Size = New System.Drawing.Size(114, 58)
        Me.btn_ThoatKBSBS.TabIndex = 47
        Me.btn_ThoatKBSBS.Text = "Thoát KB SBS"
        Me.btn_ThoatKBSBS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_ThoatKBSBS.UseVisualStyleBackColor = True
        '
        'label_TenCanh
        '
        Me.label_TenCanh.AutoSize = True
        Me.label_TenCanh.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_TenCanh.ForeColor = System.Drawing.Color.Black
        Me.label_TenCanh.Location = New System.Drawing.Point(5, 91)
        Me.label_TenCanh.Name = "label_TenCanh"
        Me.label_TenCanh.Size = New System.Drawing.Size(174, 25)
        Me.label_TenCanh.TabIndex = 13
        Me.label_TenCanh.Text = "Đối Tượng Cảnh:"
        '
        'btn_KichBanSBS
        '
        Me.btn_KichBanSBS.Enabled = False
        Me.btn_KichBanSBS.FlatAppearance.BorderSize = 0
        Me.btn_KichBanSBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_KichBanSBS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_KichBanSBS.ForeColor = System.Drawing.Color.Black
        Me.btn_KichBanSBS.Image = CType(resources.GetObject("btn_KichBanSBS.Image"), System.Drawing.Image)
        Me.btn_KichBanSBS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_KichBanSBS.Location = New System.Drawing.Point(251, 10)
        Me.btn_KichBanSBS.Name = "btn_KichBanSBS"
        Me.btn_KichBanSBS.Size = New System.Drawing.Size(114, 58)
        Me.btn_KichBanSBS.TabIndex = 46
        Me.btn_KichBanSBS.Text = "Chạy KB SBS"
        Me.btn_KichBanSBS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_KichBanSBS.UseVisualStyleBackColor = True
        '
        'label_SoCanh
        '
        Me.label_SoCanh.AutoSize = True
        Me.label_SoCanh.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_SoCanh.ForeColor = System.Drawing.Color.Black
        Me.label_SoCanh.Location = New System.Drawing.Point(0, 61)
        Me.label_SoCanh.Name = "label_SoCanh"
        Me.label_SoCanh.Size = New System.Drawing.Size(112, 25)
        Me.label_SoCanh.TabIndex = 12
        Me.label_SoCanh.Text = "Tên Cảnh:"
        '
        'lb_NameScene
        '
        Me.lb_NameScene.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lb_NameScene.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lb_NameScene.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_NameScene.Location = New System.Drawing.Point(185, 96)
        Me.lb_NameScene.Name = "lb_NameScene"
        Me.lb_NameScene.ReadOnly = True
        Me.lb_NameScene.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.lb_NameScene.Size = New System.Drawing.Size(287, 19)
        Me.lb_NameScene.TabIndex = 16
        '
        'btn_CanhSau
        '
        Me.btn_CanhSau.FlatAppearance.BorderSize = 0
        Me.btn_CanhSau.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CanhSau.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CanhSau.ForeColor = System.Drawing.Color.Black
        Me.btn_CanhSau.Image = CType(resources.GetObject("btn_CanhSau.Image"), System.Drawing.Image)
        Me.btn_CanhSau.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_CanhSau.Location = New System.Drawing.Point(228, 174)
        Me.btn_CanhSau.Name = "btn_CanhSau"
        Me.btn_CanhSau.Size = New System.Drawing.Size(146, 72)
        Me.btn_CanhSau.TabIndex = 3
        Me.btn_CanhSau.Text = "Cảnh Sau"
        Me.btn_CanhSau.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_CanhSau.UseVisualStyleBackColor = True
        '
        'label_BitCanh
        '
        Me.label_BitCanh.AutoSize = True
        Me.label_BitCanh.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_BitCanh.ForeColor = System.Drawing.Color.Black
        Me.label_BitCanh.Location = New System.Drawing.Point(4, 129)
        Me.label_BitCanh.Name = "label_BitCanh"
        Me.label_BitCanh.Size = New System.Drawing.Size(149, 25)
        Me.label_BitCanh.TabIndex = 14
        Me.label_BitCanh.Text = "Dữ Liệu Cảnh:"
        '
        'btn_CanhTruoc
        '
        Me.btn_CanhTruoc.FlatAppearance.BorderSize = 0
        Me.btn_CanhTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CanhTruoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CanhTruoc.ForeColor = System.Drawing.Color.Black
        Me.btn_CanhTruoc.Image = CType(resources.GetObject("btn_CanhTruoc.Image"), System.Drawing.Image)
        Me.btn_CanhTruoc.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_CanhTruoc.Location = New System.Drawing.Point(76, 174)
        Me.btn_CanhTruoc.Name = "btn_CanhTruoc"
        Me.btn_CanhTruoc.Size = New System.Drawing.Size(146, 72)
        Me.btn_CanhTruoc.TabIndex = 3
        Me.btn_CanhTruoc.Text = "Cảnh Trước"
        Me.btn_CanhTruoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_CanhTruoc.UseVisualStyleBackColor = True
        '
        'pnl_DKKichBan
        '
        Me.pnl_DKKichBan.BorderColor = System.Drawing.Color.Black
        Me.pnl_DKKichBan.BorderRadius = 20
        Me.pnl_DKKichBan.BorderThickness = 2
        Me.pnl_DKKichBan.Controls.Add(Me.bt_themcanhtong)
        Me.pnl_DKKichBan.Controls.Add(Me.pnl_DoiTenCanh)
        Me.pnl_DKKichBan.Controls.Add(Me.bn_vitri)
        Me.pnl_DKKichBan.Controls.Add(Me.btn_Edit_scene)
        Me.pnl_DKKichBan.Controls.Add(Me.btn_FlytoScene)
        Me.pnl_DKKichBan.Controls.Add(Me.btn_Delete_scene)
        Me.pnl_DKKichBan.Controls.Add(Me.btn_RenameScene)
        Me.pnl_DKKichBan.Controls.Add(Me.label_Canh)
        Me.pnl_DKKichBan.CustomBorderColor = System.Drawing.Color.White
        Me.pnl_DKKichBan.CustomBorderThickness = New System.Windows.Forms.Padding(0)
        Me.pnl_DKKichBan.FillColor = System.Drawing.Color.WhiteSmoke
        Me.pnl_DKKichBan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnl_DKKichBan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.pnl_DKKichBan.Location = New System.Drawing.Point(3, 326)
        Me.pnl_DKKichBan.Name = "pnl_DKKichBan"
        Me.pnl_DKKichBan.Size = New System.Drawing.Size(490, 336)
        Me.pnl_DKKichBan.TabIndex = 53
        '
        'bt_themcanhtong
        '
        Me.bt_themcanhtong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.bt_themcanhtong.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_themcanhtong.FlatAppearance.BorderSize = 0
        Me.bt_themcanhtong.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_themcanhtong.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_themcanhtong.ForeColor = System.Drawing.Color.Black
        Me.bt_themcanhtong.Image = CType(resources.GetObject("bt_themcanhtong.Image"), System.Drawing.Image)
        Me.bt_themcanhtong.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_themcanhtong.Location = New System.Drawing.Point(151, 78)
        Me.bt_themcanhtong.Name = "bt_themcanhtong"
        Me.bt_themcanhtong.Size = New System.Drawing.Size(167, 72)
        Me.bt_themcanhtong.TabIndex = 40
        Me.bt_themcanhtong.Text = "Thêm cảnh "
        Me.bt_themcanhtong.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_themcanhtong.UseVisualStyleBackColor = True
        '
        'pnl_DoiTenCanh
        '
        Me.pnl_DoiTenCanh.BackColor = System.Drawing.Color.Transparent
        Me.pnl_DoiTenCanh.Controls.Add(Me.tb_DoiTenCanh)
        Me.pnl_DoiTenCanh.Controls.Add(Me.btn_DoiTenCanh)
        Me.pnl_DoiTenCanh.Controls.Add(Me.lablecc)
        Me.pnl_DoiTenCanh.ForeColor = System.Drawing.Color.Black
        Me.pnl_DoiTenCanh.Location = New System.Drawing.Point(16, 280)
        Me.pnl_DoiTenCanh.Name = "pnl_DoiTenCanh"
        Me.pnl_DoiTenCanh.Size = New System.Drawing.Size(461, 50)
        Me.pnl_DoiTenCanh.TabIndex = 38
        Me.pnl_DoiTenCanh.Visible = False
        '
        'tb_DoiTenCanh
        '
        Me.tb_DoiTenCanh.AutoRoundedCorners = True
        Me.tb_DoiTenCanh.BackColor = System.Drawing.Color.Transparent
        Me.tb_DoiTenCanh.BorderColor = System.Drawing.Color.Black
        Me.tb_DoiTenCanh.BorderRadius = 16
        Me.tb_DoiTenCanh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tb_DoiTenCanh.DefaultText = ""
        Me.tb_DoiTenCanh.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tb_DoiTenCanh.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tb_DoiTenCanh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tb_DoiTenCanh.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tb_DoiTenCanh.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_DoiTenCanh.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tb_DoiTenCanh.ForeColor = System.Drawing.Color.Black
        Me.tb_DoiTenCanh.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_DoiTenCanh.Location = New System.Drawing.Point(113, 8)
        Me.tb_DoiTenCanh.Margin = New System.Windows.Forms.Padding(5)
        Me.tb_DoiTenCanh.Name = "tb_DoiTenCanh"
        Me.tb_DoiTenCanh.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tb_DoiTenCanh.PlaceholderForeColor = System.Drawing.Color.Gray
        Me.tb_DoiTenCanh.PlaceholderText = ""
        Me.tb_DoiTenCanh.SelectedText = ""
        Me.tb_DoiTenCanh.Size = New System.Drawing.Size(207, 34)
        Me.tb_DoiTenCanh.TabIndex = 52
        '
        'btn_DoiTenCanh
        '
        Me.btn_DoiTenCanh.FlatAppearance.BorderSize = 0
        Me.btn_DoiTenCanh.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_DoiTenCanh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_DoiTenCanh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_DoiTenCanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DoiTenCanh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DoiTenCanh.Image = CType(resources.GetObject("btn_DoiTenCanh.Image"), System.Drawing.Image)
        Me.btn_DoiTenCanh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_DoiTenCanh.Location = New System.Drawing.Point(331, 8)
        Me.btn_DoiTenCanh.Name = "btn_DoiTenCanh"
        Me.btn_DoiTenCanh.Size = New System.Drawing.Size(127, 35)
        Me.btn_DoiTenCanh.TabIndex = 2
        Me.btn_DoiTenCanh.Text = "Xác Nhận"
        Me.btn_DoiTenCanh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_DoiTenCanh.UseVisualStyleBackColor = True
        '
        'lablecc
        '
        Me.lablecc.AutoSize = True
        Me.lablecc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lablecc.Location = New System.Drawing.Point(6, 12)
        Me.lablecc.Name = "lablecc"
        Me.lablecc.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lablecc.Size = New System.Drawing.Size(102, 24)
        Me.lablecc.TabIndex = 1
        Me.lablecc.Text = "Tên Cảnh"
        '
        'bn_vitri
        '
        Me.bn_vitri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bn_vitri.FlatAppearance.BorderSize = 0
        Me.bn_vitri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bn_vitri.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bn_vitri.ForeColor = System.Drawing.Color.Black
        Me.bn_vitri.Image = CType(resources.GetObject("bn_vitri.Image"), System.Drawing.Image)
        Me.bn_vitri.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bn_vitri.Location = New System.Drawing.Point(174, 189)
        Me.bn_vitri.Name = "bn_vitri"
        Me.bn_vitri.Size = New System.Drawing.Size(110, 72)
        Me.bn_vitri.TabIndex = 13
        Me.bn_vitri.Text = "Vị trí"
        Me.bn_vitri.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bn_vitri.UseVisualStyleBackColor = True
        '
        'btn_Edit_scene
        '
        Me.btn_Edit_scene.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Edit_scene.FlatAppearance.BorderSize = 0
        Me.btn_Edit_scene.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Edit_scene.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Edit_scene.ForeColor = System.Drawing.Color.Black
        Me.btn_Edit_scene.Image = CType(resources.GetObject("btn_Edit_scene.Image"), System.Drawing.Image)
        Me.btn_Edit_scene.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Edit_scene.Location = New System.Drawing.Point(23, 78)
        Me.btn_Edit_scene.Name = "btn_Edit_scene"
        Me.btn_Edit_scene.Size = New System.Drawing.Size(100, 72)
        Me.btn_Edit_scene.TabIndex = 8
        Me.btn_Edit_scene.Text = "Sửa cảnh"
        Me.btn_Edit_scene.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Edit_scene.UseVisualStyleBackColor = True
        '
        'btn_FlytoScene
        '
        Me.btn_FlytoScene.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_FlytoScene.FlatAppearance.BorderSize = 0
        Me.btn_FlytoScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_FlytoScene.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_FlytoScene.ForeColor = System.Drawing.Color.Black
        Me.btn_FlytoScene.Image = CType(resources.GetObject("btn_FlytoScene.Image"), System.Drawing.Image)
        Me.btn_FlytoScene.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_FlytoScene.Location = New System.Drawing.Point(16, 189)
        Me.btn_FlytoScene.Name = "btn_FlytoScene"
        Me.btn_FlytoScene.Size = New System.Drawing.Size(100, 72)
        Me.btn_FlytoScene.TabIndex = 12
        Me.btn_FlytoScene.Text = "Bay đến"
        Me.btn_FlytoScene.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_FlytoScene.UseVisualStyleBackColor = True
        '
        'btn_Delete_scene
        '
        Me.btn_Delete_scene.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Delete_scene.FlatAppearance.BorderSize = 0
        Me.btn_Delete_scene.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Delete_scene.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Delete_scene.ForeColor = System.Drawing.Color.Black
        Me.btn_Delete_scene.Image = CType(resources.GetObject("btn_Delete_scene.Image"), System.Drawing.Image)
        Me.btn_Delete_scene.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Delete_scene.Location = New System.Drawing.Point(362, 78)
        Me.btn_Delete_scene.Name = "btn_Delete_scene"
        Me.btn_Delete_scene.Size = New System.Drawing.Size(105, 72)
        Me.btn_Delete_scene.TabIndex = 8
        Me.btn_Delete_scene.Text = "Xóa cảnh"
        Me.btn_Delete_scene.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Delete_scene.UseVisualStyleBackColor = True
        '
        'btn_RenameScene
        '
        Me.btn_RenameScene.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_RenameScene.FlatAppearance.BorderSize = 0
        Me.btn_RenameScene.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_RenameScene.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_RenameScene.ForeColor = System.Drawing.Color.Black
        Me.btn_RenameScene.Image = CType(resources.GetObject("btn_RenameScene.Image"), System.Drawing.Image)
        Me.btn_RenameScene.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_RenameScene.Location = New System.Drawing.Point(349, 189)
        Me.btn_RenameScene.Name = "btn_RenameScene"
        Me.btn_RenameScene.Size = New System.Drawing.Size(129, 72)
        Me.btn_RenameScene.TabIndex = 11
        Me.btn_RenameScene.Text = "Đổi tên cảnh"
        Me.btn_RenameScene.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_RenameScene.UseVisualStyleBackColor = True
        '
        'label_Canh
        '
        Me.label_Canh.AutoSize = True
        Me.label_Canh.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_Canh.ForeColor = System.Drawing.Color.Black
        Me.label_Canh.Location = New System.Drawing.Point(7, 10)
        Me.label_Canh.Name = "label_Canh"
        Me.label_Canh.Size = New System.Drawing.Size(296, 31)
        Me.label_Canh.TabIndex = 10
        Me.label_Canh.Text = "Điều Khiển Kịch Bản  "
        '
        'pnl_Script
        '
        Me.pnl_Script.BorderColor = System.Drawing.Color.Black
        Me.pnl_Script.BorderRadius = 20
        Me.pnl_Script.BorderThickness = 2
        Me.pnl_Script.Controls.Add(Me.bt_Xuatfile)
        Me.pnl_Script.Controls.Add(Me.label_KichBan)
        Me.pnl_Script.Controls.Add(Me.bt_addfile)
        Me.pnl_Script.Controls.Add(Me.btn_Create_namekb)
        Me.pnl_Script.Controls.Add(Me.btn_Chan)
        Me.pnl_Script.Controls.Add(Me.btn_DeleteKB)
        Me.pnl_Script.Controls.Add(Me.pnl_CreateKB2)
        Me.pnl_Script.Controls.Add(Me.Panel_Doitenkichban)
        Me.pnl_Script.CustomBorderColor = System.Drawing.Color.White
        Me.pnl_Script.CustomBorderThickness = New System.Windows.Forms.Padding(0)
        Me.pnl_Script.FillColor = System.Drawing.Color.WhiteSmoke
        Me.pnl_Script.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.pnl_Script.ForeColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.pnl_Script.Location = New System.Drawing.Point(3, 3)
        Me.pnl_Script.Name = "pnl_Script"
        Me.pnl_Script.Size = New System.Drawing.Size(490, 285)
        Me.pnl_Script.TabIndex = 52
        '
        'bt_Xuatfile
        '
        Me.bt_Xuatfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_Xuatfile.FlatAppearance.BorderSize = 0
        Me.bt_Xuatfile.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.bt_Xuatfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_Xuatfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_Xuatfile.ForeColor = System.Drawing.Color.Black
        Me.bt_Xuatfile.Image = CType(resources.GetObject("bt_Xuatfile.Image"), System.Drawing.Image)
        Me.bt_Xuatfile.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_Xuatfile.Location = New System.Drawing.Point(228, 53)
        Me.bt_Xuatfile.Name = "bt_Xuatfile"
        Me.bt_Xuatfile.Size = New System.Drawing.Size(123, 72)
        Me.bt_Xuatfile.TabIndex = 44
        Me.bt_Xuatfile.Text = "Xuất file"
        Me.bt_Xuatfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_Xuatfile.UseVisualStyleBackColor = True
        '
        'label_KichBan
        '
        Me.label_KichBan.AutoSize = True
        Me.label_KichBan.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_KichBan.ForeColor = System.Drawing.Color.Black
        Me.label_KichBan.Location = New System.Drawing.Point(6, 9)
        Me.label_KichBan.Name = "label_KichBan"
        Me.label_KichBan.Size = New System.Drawing.Size(130, 31)
        Me.label_KichBan.TabIndex = 6
        Me.label_KichBan.Text = "Kịch Bản"
        '
        'bt_addfile
        '
        Me.bt_addfile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_addfile.FlatAppearance.BorderSize = 0
        Me.bt_addfile.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.bt_addfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_addfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_addfile.ForeColor = System.Drawing.Color.Black
        Me.bt_addfile.Image = CType(resources.GetObject("bt_addfile.Image"), System.Drawing.Image)
        Me.bt_addfile.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_addfile.Location = New System.Drawing.Point(111, 53)
        Me.bt_addfile.Name = "bt_addfile"
        Me.bt_addfile.Size = New System.Drawing.Size(114, 72)
        Me.bt_addfile.TabIndex = 45
        Me.bt_addfile.Text = "Add file"
        Me.bt_addfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_addfile.UseVisualStyleBackColor = True
        '
        'btn_Create_namekb
        '
        Me.btn_Create_namekb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Create_namekb.FlatAppearance.BorderSize = 0
        Me.btn_Create_namekb.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_Create_namekb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Create_namekb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Create_namekb.ForeColor = System.Drawing.Color.Black
        Me.btn_Create_namekb.Image = CType(resources.GetObject("btn_Create_namekb.Image"), System.Drawing.Image)
        Me.btn_Create_namekb.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Create_namekb.Location = New System.Drawing.Point(10, 140)
        Me.btn_Create_namekb.Name = "btn_Create_namekb"
        Me.btn_Create_namekb.Size = New System.Drawing.Size(161, 72)
        Me.btn_Create_namekb.TabIndex = 8
        Me.btn_Create_namekb.Text = "Tạo kịch bản"
        Me.btn_Create_namekb.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Create_namekb.UseVisualStyleBackColor = True
        '
        'btn_Chan
        '
        Me.btn_Chan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Chan.FlatAppearance.BorderSize = 0
        Me.btn_Chan.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_Chan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Chan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Chan.ForeColor = System.Drawing.Color.Black
        Me.btn_Chan.Image = CType(resources.GetObject("btn_Chan.Image"), System.Drawing.Image)
        Me.btn_Chan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_Chan.Location = New System.Drawing.Point(171, 140)
        Me.btn_Chan.Name = "btn_Chan"
        Me.btn_Chan.Size = New System.Drawing.Size(161, 72)
        Me.btn_Chan.TabIndex = 9
        Me.btn_Chan.Text = "Đổi tên kịch bản"
        Me.btn_Chan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Chan.UseVisualStyleBackColor = True
        '
        'btn_DeleteKB
        '
        Me.btn_DeleteKB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_DeleteKB.FlatAppearance.BorderSize = 0
        Me.btn_DeleteKB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_DeleteKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_DeleteKB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_DeleteKB.ForeColor = System.Drawing.Color.Black
        Me.btn_DeleteKB.Image = CType(resources.GetObject("btn_DeleteKB.Image"), System.Drawing.Image)
        Me.btn_DeleteKB.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_DeleteKB.Location = New System.Drawing.Point(326, 140)
        Me.btn_DeleteKB.Name = "btn_DeleteKB"
        Me.btn_DeleteKB.Size = New System.Drawing.Size(148, 72)
        Me.btn_DeleteKB.TabIndex = 6
        Me.btn_DeleteKB.Text = "Xóa kịch bản"
        Me.btn_DeleteKB.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_DeleteKB.UseVisualStyleBackColor = True
        '
        'pnl_CreateKB2
        '
        Me.pnl_CreateKB2.Controls.Add(Me.tb_NameKB)
        Me.pnl_CreateKB2.Controls.Add(Me.btn_CreateKB)
        Me.pnl_CreateKB2.Controls.Add(Me.label_TenKichBan)
        Me.pnl_CreateKB2.Location = New System.Drawing.Point(12, 226)
        Me.pnl_CreateKB2.Name = "pnl_CreateKB2"
        Me.pnl_CreateKB2.Size = New System.Drawing.Size(462, 50)
        Me.pnl_CreateKB2.TabIndex = 15
        Me.pnl_CreateKB2.Visible = False
        '
        'tb_NameKB
        '
        Me.tb_NameKB.AutoRoundedCorners = True
        Me.tb_NameKB.BackColor = System.Drawing.Color.Transparent
        Me.tb_NameKB.BorderColor = System.Drawing.Color.Black
        Me.tb_NameKB.BorderRadius = 16
        Me.tb_NameKB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tb_NameKB.DefaultText = ""
        Me.tb_NameKB.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tb_NameKB.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tb_NameKB.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tb_NameKB.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tb_NameKB.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_NameKB.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tb_NameKB.ForeColor = System.Drawing.Color.Black
        Me.tb_NameKB.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_NameKB.Location = New System.Drawing.Point(141, 8)
        Me.tb_NameKB.Margin = New System.Windows.Forms.Padding(5)
        Me.tb_NameKB.Name = "tb_NameKB"
        Me.tb_NameKB.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tb_NameKB.PlaceholderForeColor = System.Drawing.Color.Gray
        Me.tb_NameKB.PlaceholderText = ""
        Me.tb_NameKB.SelectedText = ""
        Me.tb_NameKB.Size = New System.Drawing.Size(190, 34)
        Me.tb_NameKB.TabIndex = 53
        '
        'btn_CreateKB
        '
        Me.btn_CreateKB.FlatAppearance.BorderSize = 0
        Me.btn_CreateKB.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_CreateKB.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_CreateKB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_CreateKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CreateKB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_CreateKB.ForeColor = System.Drawing.Color.Black
        Me.btn_CreateKB.Image = CType(resources.GetObject("btn_CreateKB.Image"), System.Drawing.Image)
        Me.btn_CreateKB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_CreateKB.Location = New System.Drawing.Point(331, 8)
        Me.btn_CreateKB.Name = "btn_CreateKB"
        Me.btn_CreateKB.Size = New System.Drawing.Size(125, 33)
        Me.btn_CreateKB.TabIndex = 2
        Me.btn_CreateKB.Text = "  Xác Nhận"
        Me.btn_CreateKB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_CreateKB.UseVisualStyleBackColor = True
        '
        'label_TenKichBan
        '
        Me.label_TenKichBan.AutoSize = True
        Me.label_TenKichBan.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_TenKichBan.ForeColor = System.Drawing.Color.Black
        Me.label_TenKichBan.Location = New System.Drawing.Point(9, 14)
        Me.label_TenKichBan.Name = "label_TenKichBan"
        Me.label_TenKichBan.Size = New System.Drawing.Size(132, 24)
        Me.label_TenKichBan.TabIndex = 1
        Me.label_TenKichBan.Text = "Tên kịch bản"
        '
        'Panel_Doitenkichban
        '
        Me.Panel_Doitenkichban.Controls.Add(Me.Khung_Doitenkichban)
        Me.Panel_Doitenkichban.Controls.Add(Me.Nut_Doitenkichban)
        Me.Panel_Doitenkichban.Controls.Add(Me.label_DoiTenKichBan)
        Me.Panel_Doitenkichban.Location = New System.Drawing.Point(12, 226)
        Me.Panel_Doitenkichban.Name = "Panel_Doitenkichban"
        Me.Panel_Doitenkichban.Size = New System.Drawing.Size(462, 50)
        Me.Panel_Doitenkichban.TabIndex = 38
        Me.Panel_Doitenkichban.Visible = False
        '
        'Khung_Doitenkichban
        '
        Me.Khung_Doitenkichban.AutoRoundedCorners = True
        Me.Khung_Doitenkichban.BackColor = System.Drawing.Color.Transparent
        Me.Khung_Doitenkichban.BorderColor = System.Drawing.Color.Black
        Me.Khung_Doitenkichban.BorderRadius = 16
        Me.Khung_Doitenkichban.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.Khung_Doitenkichban.DefaultText = ""
        Me.Khung_Doitenkichban.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Khung_Doitenkichban.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.Khung_Doitenkichban.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Khung_Doitenkichban.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.Khung_Doitenkichban.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Khung_Doitenkichban.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Khung_Doitenkichban.ForeColor = System.Drawing.Color.Black
        Me.Khung_Doitenkichban.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Khung_Doitenkichban.Location = New System.Drawing.Point(113, 8)
        Me.Khung_Doitenkichban.Margin = New System.Windows.Forms.Padding(5)
        Me.Khung_Doitenkichban.Name = "Khung_Doitenkichban"
        Me.Khung_Doitenkichban.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.Khung_Doitenkichban.PlaceholderForeColor = System.Drawing.Color.Gray
        Me.Khung_Doitenkichban.PlaceholderText = ""
        Me.Khung_Doitenkichban.SelectedText = ""
        Me.Khung_Doitenkichban.Size = New System.Drawing.Size(207, 34)
        Me.Khung_Doitenkichban.TabIndex = 54
        '
        'Nut_Doitenkichban
        '
        Me.Nut_Doitenkichban.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Nut_Doitenkichban.FlatAppearance.BorderSize = 0
        Me.Nut_Doitenkichban.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Nut_Doitenkichban.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Nut_Doitenkichban.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Nut_Doitenkichban.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Nut_Doitenkichban.ForeColor = System.Drawing.Color.Black
        Me.Nut_Doitenkichban.Image = CType(resources.GetObject("Nut_Doitenkichban.Image"), System.Drawing.Image)
        Me.Nut_Doitenkichban.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Nut_Doitenkichban.Location = New System.Drawing.Point(332, 10)
        Me.Nut_Doitenkichban.Name = "Nut_Doitenkichban"
        Me.Nut_Doitenkichban.Size = New System.Drawing.Size(127, 35)
        Me.Nut_Doitenkichban.TabIndex = 2
        Me.Nut_Doitenkichban.Text = "  Xác Nhận"
        Me.Nut_Doitenkichban.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Nut_Doitenkichban.UseVisualStyleBackColor = True
        '
        'label_DoiTenKichBan
        '
        Me.label_DoiTenKichBan.AutoSize = True
        Me.label_DoiTenKichBan.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_DoiTenKichBan.ForeColor = System.Drawing.Color.Black
        Me.label_DoiTenKichBan.Location = New System.Drawing.Point(9, 12)
        Me.label_DoiTenKichBan.Name = "label_DoiTenKichBan"
        Me.label_DoiTenKichBan.Size = New System.Drawing.Size(82, 24)
        Me.label_DoiTenKichBan.TabIndex = 1
        Me.label_DoiTenKichBan.Text = "Đổi tên "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(492, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 29)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Danh Sách Kịch Bản"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowDrop = True
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.AllowUserToResizeColumns = False
        Me.dataGridView1.AllowUserToResizeRows = False
        Me.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dataGridView1.GridColor = System.Drawing.Color.Black
        Me.dataGridView1.Location = New System.Drawing.Point(743, 0)
        Me.dataGridView1.MultiSelect = False
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = True
        Me.dataGridView1.RowHeadersVisible = False
        Me.dataGridView1.RowTemplate.ReadOnly = True
        Me.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dataGridView1.Size = New System.Drawing.Size(736, 945)
        Me.dataGridView1.TabIndex = 45
        '
        'KB_KichBan
        '
        Me.KB_KichBan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.KB_KichBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.KB_KichBan.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KB_KichBan.FormattingEnabled = True
        Me.KB_KichBan.ItemHeight = 24
        Me.KB_KichBan.Location = New System.Drawing.Point(497, 55)
        Me.KB_KichBan.Name = "KB_KichBan"
        Me.KB_KichBan.Size = New System.Drawing.Size(243, 890)
        Me.KB_KichBan.TabIndex = 49
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 20
        Me.Guna2Elipse1.TargetControl = Me
        '
        'DemTime
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'KichBan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Panel1)
        Me.Name = "KichBan"
        Me.Size = New System.Drawing.Size(1728, 1050)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.pnl_DKKichBan.ResumeLayout(False)
        Me.pnl_DKKichBan.PerformLayout()
        Me.pnl_DoiTenCanh.ResumeLayout(False)
        Me.pnl_DoiTenCanh.PerformLayout()
        Me.pnl_Script.ResumeLayout(False)
        Me.pnl_Script.PerformLayout()
        Me.pnl_CreateKB2.ResumeLayout(False)
        Me.pnl_CreateKB2.PerformLayout()
        Me.Panel_Doitenkichban.ResumeLayout(False)
        Me.Panel_Doitenkichban.PerformLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Private WithEvents dataGridView1 As DataGridView
    Private WithEvents KB_KichBan As ListBox
    Private WithEvents label_KichBan As Label
    Private WithEvents btn_Chan As Button
    Private WithEvents btn_DeleteKB As Button
    Private WithEvents btn_Create_namekb As Button
    Private WithEvents pnl_CreateKB2 As Panel
    Private WithEvents btn_CreateKB As Button
    Private WithEvents label_TenKichBan As Label
    Private WithEvents Panel_Doitenkichban As Panel
    Private WithEvents Nut_Doitenkichban As Button
    Private WithEvents label_DoiTenKichBan As Label
    Private WithEvents bt_Xuatfile As Button
    Private WithEvents bt_addfile As Button
    Private WithEvents Label1 As Label
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Private WithEvents bn_vitri As Button
    Private WithEvents btn_FlytoScene As Button
    Private WithEvents btn_RenameScene As Button
    Private WithEvents label_Canh As Label
    Private WithEvents btn_Delete_scene As Button
    Private WithEvents btn_Edit_scene As Button
    Private WithEvents pnl_DoiTenCanh As Panel
    Private WithEvents btn_DoiTenCanh As Button
    Private WithEvents lablecc As Label
    Friend WithEvents lb_NameScene As TextBox
    Private WithEvents btn_CanhTruoc As Button
    Private WithEvents label_BitCanh As Label
    Private WithEvents btn_CanhSau As Button
    Private WithEvents label_CanhDangChay As Label
    Private WithEvents label_SoCanh As Label
    Private WithEvents label_TenCanh As Label
    Private WithEvents btn_KichBanSBS As Button
    Private WithEvents btn_ThoatKBSBS As Button
    Friend WithEvents DemTime As Timer
    Friend WithEvents lb_IDKB As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Private WithEvents bt_themcanhtong As Button
    Friend WithEvents tb_DoiTenCanh As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents tb_NameKB As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Khung_Doitenkichban As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnl_Script As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents panel3 As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents pnl_DKKichBan As Guna.UI2.WinForms.Guna2GroupBox
    Friend WithEvents lb_DataCanh As TextBox
End Class
