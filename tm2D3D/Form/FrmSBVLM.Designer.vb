<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSBVLM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSBVLM))
        Me.label1 = New System.Windows.Forms.Label()
        Me.CB_TaoMuc = New System.Windows.Forms.Panel()
        Me.lb_Khoa3Dmap = New System.Windows.Forms.Label()
        Me.btn_Khoa3Dmap = New Guna.UI2.WinForms.Guna2ToggleSwitch()
        Me.bt_inal = New System.Windows.Forms.TextBox()
        Me.bt_mtt = New System.Windows.Forms.TextBox()
        Me.tb_trangthaico = New System.Windows.Forms.TextBox()
        Me.tb_truyentoado = New System.Windows.Forms.TextBox()
        Me.tb_truyenvitri = New System.Windows.Forms.TextBox()
        Me.tb_kbtruyen = New System.Windows.Forms.TextBox()
        Me.tb_truyen = New System.Windows.Forms.TextBox()
        Me.TxtMuichieuSBVL = New System.Windows.Forms.TextBox()
        Me.TxtKinhtuyentrucSBVL = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tb_CCD = New System.Windows.Forms.TextBox()
        Me.TB_tencanh = New System.Windows.Forms.TextBox()
        Me.TB_socanh = New System.Windows.Forms.TextBox()
        Me.bt_fly = New System.Windows.Forms.TextBox()
        Me.pc_Pin = New System.Windows.Forms.PictureBox()
        Me.tb_pin = New System.Windows.Forms.TextBox()
        Me.lb_pin = New System.Windows.Forms.Label()
        Me.tb_TruyenBit_2 = New System.Windows.Forms.TextBox()
        Me.lb_ThoiGian = New System.Windows.Forms.Label()
        Me.tb_TruyenBit = New System.Windows.Forms.TextBox()
        Me.tb_BN = New System.Windows.Forms.TextBox()
        Me.DieuKhienCo = New System.Windows.Forms.TextBox()
        Me.tb_TrinhChieuSBVL = New System.Windows.Forms.TextBox()
        Me.TxtTrinhchieu = New System.Windows.Forms.TextBox()
        Me.TxtDTmoi = New System.Windows.Forms.TextBox()
        Me.tb_test = New System.Windows.Forms.TextBox()
        Me.TxtLaser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_NhayAll = New System.Windows.Forms.Button()
        Me.btn_OnAll = New System.Windows.Forms.Button()
        Me.btn_OffAll = New System.Windows.Forms.Button()
        Me.bt_xoabit = New System.Windows.Forms.Button()
        Me.btn_exit = New System.Windows.Forms.Button()
        Me.btn_AnCuaSo = New System.Windows.Forms.Button()
        Me.pnl_Tool = New System.Windows.Forms.Panel()
        Me.Guna2GradientPanel1 = New Guna.UI2.WinForms.Guna2GradientPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Guna2Button1 = New System.Windows.Forms.Button()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.btn_KetNoi = New System.Windows.Forms.Button()
        Me.cbb_COM = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.btn_LamMoi = New System.Windows.Forms.Button()
        Me.pnl_Menu = New System.Windows.Forms.Panel()
        Me.btn_XLA = New System.Windows.Forms.Button()
        Me.btn_TrangKichBan = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btn_TrangCoCoDong = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btn_TrangBitTong = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.btn_pnl_OnBit = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.tb_Rserial = New System.Windows.Forms.TextBox()
        Me.btn_TK = New System.Windows.Forms.Button()
        Me.btn_Settings = New System.Windows.Forms.Button()
        Me.BtnSbso = New System.Windows.Forms.Button()
        Me.ThoiGian = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CB_TaoMuc.SuspendLayout()
        CType(Me.pc_Pin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_Tool.SuspendLayout()
        Me.Guna2GradientPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel3.SuspendLayout()
        Me.pnl_Menu.SuspendLayout()
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.label1.ForeColor = System.Drawing.Color.Black
        Me.label1.Location = New System.Drawing.Point(12, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(127, 18)
        Me.label1.TabIndex = 0
        Me.label1.Text = "Kết Nối Tủ Điện"
        '
        'CB_TaoMuc
        '
        Me.CB_TaoMuc.BackColor = System.Drawing.Color.White
        Me.CB_TaoMuc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CB_TaoMuc.Controls.Add(Me.lb_Khoa3Dmap)
        Me.CB_TaoMuc.Controls.Add(Me.btn_Khoa3Dmap)
        Me.CB_TaoMuc.Controls.Add(Me.bt_inal)
        Me.CB_TaoMuc.Controls.Add(Me.bt_mtt)
        Me.CB_TaoMuc.Controls.Add(Me.tb_trangthaico)
        Me.CB_TaoMuc.Controls.Add(Me.tb_truyentoado)
        Me.CB_TaoMuc.Controls.Add(Me.tb_truyenvitri)
        Me.CB_TaoMuc.Controls.Add(Me.tb_kbtruyen)
        Me.CB_TaoMuc.Controls.Add(Me.tb_truyen)
        Me.CB_TaoMuc.Controls.Add(Me.TxtMuichieuSBVL)
        Me.CB_TaoMuc.Controls.Add(Me.TxtKinhtuyentrucSBVL)
        Me.CB_TaoMuc.Controls.Add(Me.Label3)
        Me.CB_TaoMuc.Controls.Add(Me.tb_CCD)
        Me.CB_TaoMuc.Controls.Add(Me.TB_tencanh)
        Me.CB_TaoMuc.Controls.Add(Me.TB_socanh)
        Me.CB_TaoMuc.Controls.Add(Me.bt_fly)
        Me.CB_TaoMuc.Controls.Add(Me.pc_Pin)
        Me.CB_TaoMuc.Controls.Add(Me.tb_pin)
        Me.CB_TaoMuc.Controls.Add(Me.lb_pin)
        Me.CB_TaoMuc.Controls.Add(Me.tb_TruyenBit_2)
        Me.CB_TaoMuc.Controls.Add(Me.lb_ThoiGian)
        Me.CB_TaoMuc.Controls.Add(Me.tb_TruyenBit)
        Me.CB_TaoMuc.Controls.Add(Me.tb_BN)
        Me.CB_TaoMuc.Controls.Add(Me.DieuKhienCo)
        Me.CB_TaoMuc.Controls.Add(Me.tb_TrinhChieuSBVL)
        Me.CB_TaoMuc.Controls.Add(Me.TxtTrinhchieu)
        Me.CB_TaoMuc.Controls.Add(Me.TxtDTmoi)
        Me.CB_TaoMuc.Controls.Add(Me.tb_test)
        Me.CB_TaoMuc.Controls.Add(Me.TxtLaser)
        Me.CB_TaoMuc.Controls.Add(Me.Label2)
        Me.CB_TaoMuc.Controls.Add(Me.btn_NhayAll)
        Me.CB_TaoMuc.Controls.Add(Me.btn_OnAll)
        Me.CB_TaoMuc.Controls.Add(Me.btn_OffAll)
        Me.CB_TaoMuc.Controls.Add(Me.bt_xoabit)
        Me.CB_TaoMuc.Location = New System.Drawing.Point(196, 39)
        Me.CB_TaoMuc.Name = "CB_TaoMuc"
        Me.CB_TaoMuc.Size = New System.Drawing.Size(1724, 1062)
        Me.CB_TaoMuc.TabIndex = 5
        '
        'lb_Khoa3Dmap
        '
        Me.lb_Khoa3Dmap.AutoSize = True
        Me.lb_Khoa3Dmap.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold)
        Me.lb_Khoa3Dmap.Location = New System.Drawing.Point(7, 454)
        Me.lb_Khoa3Dmap.Name = "lb_Khoa3Dmap"
        Me.lb_Khoa3Dmap.Size = New System.Drawing.Size(105, 18)
        Me.lb_Khoa3Dmap.TabIndex = 134
        Me.lb_Khoa3Dmap.Text = "Khóa 3Dmap"
        Me.lb_Khoa3Dmap.Visible = False
        '
        'btn_Khoa3Dmap
        '
        Me.btn_Khoa3Dmap.BackColor = System.Drawing.Color.Transparent
        Me.btn_Khoa3Dmap.CheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_Khoa3Dmap.CheckedState.BorderRadius = 10
        Me.btn_Khoa3Dmap.CheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btn_Khoa3Dmap.CheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.btn_Khoa3Dmap.CheckedState.InnerColor = System.Drawing.Color.White
        Me.btn_Khoa3Dmap.Location = New System.Drawing.Point(28, 475)
        Me.btn_Khoa3Dmap.Name = "btn_Khoa3Dmap"
        Me.btn_Khoa3Dmap.Size = New System.Drawing.Size(45, 22)
        Me.btn_Khoa3Dmap.TabIndex = 133
        Me.btn_Khoa3Dmap.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.btn_Khoa3Dmap.UncheckedState.FillColor = System.Drawing.Color.FromArgb(CType(CType(125, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(149, Byte), Integer))
        Me.btn_Khoa3Dmap.UncheckedState.InnerBorderColor = System.Drawing.Color.White
        Me.btn_Khoa3Dmap.UncheckedState.InnerColor = System.Drawing.Color.White
        Me.btn_Khoa3Dmap.Visible = False
        '
        'bt_inal
        '
        Me.bt_inal.Location = New System.Drawing.Point(515, 818)
        Me.bt_inal.Name = "bt_inal"
        Me.bt_inal.Size = New System.Drawing.Size(211, 20)
        Me.bt_inal.TabIndex = 132
        Me.bt_inal.Visible = False
        '
        'bt_mtt
        '
        Me.bt_mtt.Location = New System.Drawing.Point(515, 845)
        Me.bt_mtt.Name = "bt_mtt"
        Me.bt_mtt.Size = New System.Drawing.Size(211, 20)
        Me.bt_mtt.TabIndex = 131
        Me.bt_mtt.Visible = False
        '
        'tb_trangthaico
        '
        Me.tb_trangthaico.Location = New System.Drawing.Point(742, 848)
        Me.tb_trangthaico.Name = "tb_trangthaico"
        Me.tb_trangthaico.Size = New System.Drawing.Size(100, 20)
        Me.tb_trangthaico.TabIndex = 130
        Me.tb_trangthaico.Visible = False
        '
        'tb_truyentoado
        '
        Me.tb_truyentoado.Location = New System.Drawing.Point(742, 877)
        Me.tb_truyentoado.Name = "tb_truyentoado"
        Me.tb_truyentoado.Size = New System.Drawing.Size(100, 20)
        Me.tb_truyentoado.TabIndex = 129
        Me.tb_truyentoado.Visible = False
        '
        'tb_truyenvitri
        '
        Me.tb_truyenvitri.Location = New System.Drawing.Point(742, 903)
        Me.tb_truyenvitri.Name = "tb_truyenvitri"
        Me.tb_truyenvitri.Size = New System.Drawing.Size(100, 20)
        Me.tb_truyenvitri.TabIndex = 128
        Me.tb_truyenvitri.Visible = False
        '
        'tb_kbtruyen
        '
        Me.tb_kbtruyen.Location = New System.Drawing.Point(742, 931)
        Me.tb_kbtruyen.Name = "tb_kbtruyen"
        Me.tb_kbtruyen.Size = New System.Drawing.Size(100, 20)
        Me.tb_kbtruyen.TabIndex = 127
        Me.tb_kbtruyen.Visible = False
        '
        'tb_truyen
        '
        Me.tb_truyen.Location = New System.Drawing.Point(742, 963)
        Me.tb_truyen.Name = "tb_truyen"
        Me.tb_truyen.Size = New System.Drawing.Size(100, 20)
        Me.tb_truyen.TabIndex = 126
        Me.tb_truyen.Visible = False
        '
        'TxtMuichieuSBVL
        '
        Me.TxtMuichieuSBVL.Location = New System.Drawing.Point(516, 874)
        Me.TxtMuichieuSBVL.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtMuichieuSBVL.Name = "TxtMuichieuSBVL"
        Me.TxtMuichieuSBVL.Size = New System.Drawing.Size(210, 20)
        Me.TxtMuichieuSBVL.TabIndex = 125
        Me.TxtMuichieuSBVL.Text = "6"
        Me.TxtMuichieuSBVL.Visible = False
        '
        'TxtKinhtuyentrucSBVL
        '
        Me.TxtKinhtuyentrucSBVL.Location = New System.Drawing.Point(515, 903)
        Me.TxtKinhtuyentrucSBVL.Name = "TxtKinhtuyentrucSBVL"
        Me.TxtKinhtuyentrucSBVL.Size = New System.Drawing.Size(210, 20)
        Me.TxtKinhtuyentrucSBVL.TabIndex = 124
        Me.TxtKinhtuyentrucSBVL.Text = "105"
        Me.TxtKinhtuyentrucSBVL.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(2, 1001)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 18)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Bút Laser"
        '
        'tb_CCD
        '
        Me.tb_CCD.Location = New System.Drawing.Point(260, 874)
        Me.tb_CCD.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_CCD.Name = "tb_CCD"
        Me.tb_CCD.Size = New System.Drawing.Size(248, 20)
        Me.tb_CCD.TabIndex = 122
        Me.tb_CCD.Visible = False
        '
        'TB_tencanh
        '
        Me.TB_tencanh.Location = New System.Drawing.Point(260, 848)
        Me.TB_tencanh.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_tencanh.Name = "TB_tencanh"
        Me.TB_tencanh.Size = New System.Drawing.Size(248, 20)
        Me.TB_tencanh.TabIndex = 120
        Me.TB_tencanh.Visible = False
        '
        'TB_socanh
        '
        Me.TB_socanh.Location = New System.Drawing.Point(515, 933)
        Me.TB_socanh.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_socanh.Name = "TB_socanh"
        Me.TB_socanh.Size = New System.Drawing.Size(210, 20)
        Me.TB_socanh.TabIndex = 119
        Me.TB_socanh.Visible = False
        '
        'bt_fly
        '
        Me.bt_fly.Location = New System.Drawing.Point(515, 963)
        Me.bt_fly.Name = "bt_fly"
        Me.bt_fly.Size = New System.Drawing.Size(210, 20)
        Me.bt_fly.TabIndex = 118
        Me.bt_fly.Visible = False
        '
        'pc_Pin
        '
        Me.pc_Pin.BackColor = System.Drawing.Color.Transparent
        Me.pc_Pin.BackgroundImage = CType(resources.GetObject("pc_Pin.BackgroundImage"), System.Drawing.Image)
        Me.pc_Pin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pc_Pin.Location = New System.Drawing.Point(6, 1022)
        Me.pc_Pin.Name = "pc_Pin"
        Me.pc_Pin.Size = New System.Drawing.Size(40, 18)
        Me.pc_Pin.TabIndex = 117
        Me.pc_Pin.TabStop = False
        '
        'tb_pin
        '
        Me.tb_pin.Location = New System.Drawing.Point(260, 818)
        Me.tb_pin.Name = "tb_pin"
        Me.tb_pin.Size = New System.Drawing.Size(248, 20)
        Me.tb_pin.TabIndex = 116
        Me.tb_pin.Visible = False
        '
        'lb_pin
        '
        Me.lb_pin.AutoSize = True
        Me.lb_pin.BackColor = System.Drawing.Color.Transparent
        Me.lb_pin.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_pin.ForeColor = System.Drawing.Color.Black
        Me.lb_pin.Location = New System.Drawing.Point(50, 1022)
        Me.lb_pin.Name = "lb_pin"
        Me.lb_pin.Size = New System.Drawing.Size(45, 18)
        Me.lb_pin.TabIndex = 115
        Me.lb_pin.Text = "100%"
        '
        'tb_TruyenBit_2
        '
        Me.tb_TruyenBit_2.Location = New System.Drawing.Point(260, 903)
        Me.tb_TruyenBit_2.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_TruyenBit_2.Name = "tb_TruyenBit_2"
        Me.tb_TruyenBit_2.Size = New System.Drawing.Size(248, 20)
        Me.tb_TruyenBit_2.TabIndex = 107
        Me.tb_TruyenBit_2.Visible = False
        '
        'lb_ThoiGian
        '
        Me.lb_ThoiGian.AutoSize = True
        Me.lb_ThoiGian.BackColor = System.Drawing.Color.Transparent
        Me.lb_ThoiGian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_ThoiGian.ForeColor = System.Drawing.Color.Black
        Me.lb_ThoiGian.Location = New System.Drawing.Point(1604, 1024)
        Me.lb_ThoiGian.Name = "lb_ThoiGian"
        Me.lb_ThoiGian.Size = New System.Drawing.Size(117, 16)
        Me.lb_ThoiGian.TabIndex = 106
        Me.lb_ThoiGian.Text = "Thời gian: 00:00:00"
        '
        'tb_TruyenBit
        '
        Me.tb_TruyenBit.Location = New System.Drawing.Point(260, 933)
        Me.tb_TruyenBit.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_TruyenBit.Name = "tb_TruyenBit"
        Me.tb_TruyenBit.Size = New System.Drawing.Size(248, 20)
        Me.tb_TruyenBit.TabIndex = 105
        Me.tb_TruyenBit.Visible = False
        '
        'tb_BN
        '
        Me.tb_BN.Location = New System.Drawing.Point(6, 963)
        Me.tb_BN.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_BN.Name = "tb_BN"
        Me.tb_BN.Size = New System.Drawing.Size(247, 20)
        Me.tb_BN.TabIndex = 104
        Me.tb_BN.Visible = False
        '
        'DieuKhienCo
        '
        Me.DieuKhienCo.Location = New System.Drawing.Point(6, 933)
        Me.DieuKhienCo.Margin = New System.Windows.Forms.Padding(4)
        Me.DieuKhienCo.Name = "DieuKhienCo"
        Me.DieuKhienCo.Size = New System.Drawing.Size(247, 20)
        Me.DieuKhienCo.TabIndex = 103
        Me.DieuKhienCo.Visible = False
        '
        'tb_TrinhChieuSBVL
        '
        Me.tb_TrinhChieuSBVL.Location = New System.Drawing.Point(5, 903)
        Me.tb_TrinhChieuSBVL.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_TrinhChieuSBVL.Name = "tb_TrinhChieuSBVL"
        Me.tb_TrinhChieuSBVL.Size = New System.Drawing.Size(248, 20)
        Me.tb_TrinhChieuSBVL.TabIndex = 102
        Me.tb_TrinhChieuSBVL.Visible = False
        '
        'TxtTrinhchieu
        '
        Me.TxtTrinhchieu.Location = New System.Drawing.Point(5, 818)
        Me.TxtTrinhchieu.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtTrinhchieu.Name = "TxtTrinhchieu"
        Me.TxtTrinhchieu.Size = New System.Drawing.Size(248, 20)
        Me.TxtTrinhchieu.TabIndex = 99
        Me.TxtTrinhchieu.Visible = False
        '
        'TxtDTmoi
        '
        Me.TxtDTmoi.Location = New System.Drawing.Point(5, 874)
        Me.TxtDTmoi.Name = "TxtDTmoi"
        Me.TxtDTmoi.Size = New System.Drawing.Size(248, 20)
        Me.TxtDTmoi.TabIndex = 101
        Me.TxtDTmoi.Visible = False
        '
        'tb_test
        '
        Me.tb_test.Location = New System.Drawing.Point(5, 845)
        Me.tb_test.Margin = New System.Windows.Forms.Padding(4)
        Me.tb_test.Name = "tb_test"
        Me.tb_test.Size = New System.Drawing.Size(248, 20)
        Me.tb_test.TabIndex = 100
        Me.tb_test.Visible = False
        '
        'TxtLaser
        '
        Me.TxtLaser.Location = New System.Drawing.Point(260, 963)
        Me.TxtLaser.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtLaser.Name = "TxtLaser"
        Me.TxtLaser.Size = New System.Drawing.Size(248, 20)
        Me.TxtLaser.TabIndex = 98
        Me.TxtLaser.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1614, 1006)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Phiên bản: v2.3.0"
        '
        'btn_NhayAll
        '
        Me.btn_NhayAll.BackColor = System.Drawing.Color.Transparent
        Me.btn_NhayAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_NhayAll.FlatAppearance.BorderSize = 0
        Me.btn_NhayAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_NhayAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_NhayAll.ForeColor = System.Drawing.Color.Black
        Me.btn_NhayAll.Image = CType(resources.GetObject("btn_NhayAll.Image"), System.Drawing.Image)
        Me.btn_NhayAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_NhayAll.Location = New System.Drawing.Point(7, 343)
        Me.btn_NhayAll.Name = "btn_NhayAll"
        Me.btn_NhayAll.Size = New System.Drawing.Size(92, 89)
        Me.btn_NhayAll.TabIndex = 2
        Me.btn_NhayAll.Text = "Nhấp Nháy Bit"
        Me.btn_NhayAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_NhayAll.UseVisualStyleBackColor = False
        '
        'btn_OnAll
        '
        Me.btn_OnAll.BackColor = System.Drawing.Color.Transparent
        Me.btn_OnAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_OnAll.FlatAppearance.BorderSize = 0
        Me.btn_OnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_OnAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OnAll.ForeColor = System.Drawing.Color.Black
        Me.btn_OnAll.Image = CType(resources.GetObject("btn_OnAll.Image"), System.Drawing.Image)
        Me.btn_OnAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_OnAll.Location = New System.Drawing.Point(3, 205)
        Me.btn_OnAll.Name = "btn_OnAll"
        Me.btn_OnAll.Size = New System.Drawing.Size(92, 63)
        Me.btn_OnAll.TabIndex = 0
        Me.btn_OnAll.Text = "Bật Bit"
        Me.btn_OnAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_OnAll.UseVisualStyleBackColor = False
        '
        'btn_OffAll
        '
        Me.btn_OffAll.BackColor = System.Drawing.Color.Transparent
        Me.btn_OffAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_OffAll.FlatAppearance.BorderSize = 0
        Me.btn_OffAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_OffAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_OffAll.ForeColor = System.Drawing.Color.Black
        Me.btn_OffAll.Image = CType(resources.GetObject("btn_OffAll.Image"), System.Drawing.Image)
        Me.btn_OffAll.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_OffAll.Location = New System.Drawing.Point(7, 274)
        Me.btn_OffAll.Name = "btn_OffAll"
        Me.btn_OffAll.Size = New System.Drawing.Size(92, 63)
        Me.btn_OffAll.TabIndex = 1
        Me.btn_OffAll.Text = "Tắt Bit"
        Me.btn_OffAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_OffAll.UseVisualStyleBackColor = False
        '
        'bt_xoabit
        '
        Me.bt_xoabit.BackColor = System.Drawing.Color.White
        Me.bt_xoabit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.bt_xoabit.FlatAppearance.BorderSize = 0
        Me.bt_xoabit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bt_xoabit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bt_xoabit.ForeColor = System.Drawing.Color.Black
        Me.bt_xoabit.Image = CType(resources.GetObject("bt_xoabit.Image"), System.Drawing.Image)
        Me.bt_xoabit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.bt_xoabit.Location = New System.Drawing.Point(7, 274)
        Me.bt_xoabit.Name = "bt_xoabit"
        Me.bt_xoabit.Size = New System.Drawing.Size(92, 63)
        Me.bt_xoabit.TabIndex = 121
        Me.bt_xoabit.Text = "Tắt Bit"
        Me.bt_xoabit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.bt_xoabit.UseVisualStyleBackColor = False
        Me.bt_xoabit.Visible = False
        '
        'btn_exit
        '
        Me.btn_exit.BackColor = System.Drawing.Color.Transparent
        Me.btn_exit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_exit.FlatAppearance.BorderSize = 0
        Me.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btn_exit.ForeColor = System.Drawing.Color.Red
        Me.btn_exit.Location = New System.Drawing.Point(79, 2)
        Me.btn_exit.Name = "btn_exit"
        Me.btn_exit.Size = New System.Drawing.Size(40, 38)
        Me.btn_exit.TabIndex = 0
        Me.btn_exit.Text = "X"
        Me.btn_exit.UseVisualStyleBackColor = False
        '
        'btn_AnCuaSo
        '
        Me.btn_AnCuaSo.BackColor = System.Drawing.Color.Transparent
        Me.btn_AnCuaSo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_AnCuaSo.FlatAppearance.BorderSize = 0
        Me.btn_AnCuaSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_AnCuaSo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_AnCuaSo.ForeColor = System.Drawing.Color.Red
        Me.btn_AnCuaSo.Location = New System.Drawing.Point(33, 3)
        Me.btn_AnCuaSo.Name = "btn_AnCuaSo"
        Me.btn_AnCuaSo.Size = New System.Drawing.Size(40, 37)
        Me.btn_AnCuaSo.TabIndex = 1
        Me.btn_AnCuaSo.Text = "-"
        Me.btn_AnCuaSo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_AnCuaSo.UseVisualStyleBackColor = False
        '
        'pnl_Tool
        '
        Me.pnl_Tool.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.pnl_Tool.Controls.Add(Me.Guna2GradientPanel1)
        Me.pnl_Tool.Controls.Add(Me.PictureBox1)
        Me.pnl_Tool.Controls.Add(Me.Guna2Button1)
        Me.pnl_Tool.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnl_Tool.Location = New System.Drawing.Point(0, 0)
        Me.pnl_Tool.Name = "pnl_Tool"
        Me.pnl_Tool.Size = New System.Drawing.Size(1920, 39)
        Me.pnl_Tool.TabIndex = 4
        '
        'Guna2GradientPanel1
        '
        Me.Guna2GradientPanel1.BackColor = System.Drawing.Color.White
        Me.Guna2GradientPanel1.Controls.Add(Me.btn_AnCuaSo)
        Me.Guna2GradientPanel1.Controls.Add(Me.btn_exit)
        Me.Guna2GradientPanel1.FillColor = System.Drawing.Color.White
        Me.Guna2GradientPanel1.FillColor2 = System.Drawing.Color.White
        Me.Guna2GradientPanel1.Location = New System.Drawing.Point(196, -1)
        Me.Guna2GradientPanel1.Name = "Guna2GradientPanel1"
        Me.Guna2GradientPanel1.Size = New System.Drawing.Size(1724, 45)
        Me.Guna2GradientPanel1.TabIndex = 131
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 39)
        Me.PictureBox1.TabIndex = 131
        Me.PictureBox1.TabStop = False
        '
        'Guna2Button1
        '
        Me.Guna2Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.Guna2Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Guna2Button1.FlatAppearance.BorderSize = 0
        Me.Guna2Button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Guna2Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Guna2Button1.Font = New System.Drawing.Font("UVN Huong Que Nang", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Guna2Button1.ForeColor = System.Drawing.Color.Black
        Me.Guna2Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Guna2Button1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Button1.Name = "Guna2Button1"
        Me.Guna2Button1.Size = New System.Drawing.Size(196, 39)
        Me.Guna2Button1.TabIndex = 131
        Me.Guna2Button1.Text = "TIẾN PHÁT"
        Me.Guna2Button1.UseVisualStyleBackColor = False
        '
        'panel3
        '
        Me.panel3.Controls.Add(Me.btn_KetNoi)
        Me.panel3.Controls.Add(Me.cbb_COM)
        Me.panel3.Controls.Add(Me.btn_LamMoi)
        Me.panel3.Controls.Add(Me.label1)
        Me.panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.panel3.Location = New System.Drawing.Point(0, 4)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(196, 106)
        Me.panel3.TabIndex = 0
        '
        'btn_KetNoi
        '
        Me.btn_KetNoi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.btn_KetNoi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_KetNoi.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btn_KetNoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_KetNoi.ForeColor = System.Drawing.Color.Black
        Me.btn_KetNoi.Location = New System.Drawing.Point(12, 66)
        Me.btn_KetNoi.Name = "btn_KetNoi"
        Me.btn_KetNoi.Size = New System.Drawing.Size(108, 37)
        Me.btn_KetNoi.TabIndex = 2
        Me.btn_KetNoi.Text = "Kết nối"
        Me.btn_KetNoi.UseVisualStyleBackColor = False
        '
        'cbb_COM
        '
        Me.cbb_COM.BackColor = System.Drawing.Color.Transparent
        Me.cbb_COM.BorderColor = System.Drawing.Color.Black
        Me.cbb_COM.BorderRadius = 14
        Me.cbb_COM.BorderThickness = 2
        Me.cbb_COM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbb_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbb_COM.FocusedColor = System.Drawing.Color.Black
        Me.cbb_COM.FocusedState.BorderColor = System.Drawing.Color.Black
        Me.cbb_COM.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.cbb_COM.ForeColor = System.Drawing.Color.Black
        Me.cbb_COM.ItemHeight = 30
        Me.cbb_COM.Location = New System.Drawing.Point(12, 27)
        Me.cbb_COM.Name = "cbb_COM"
        Me.cbb_COM.Size = New System.Drawing.Size(108, 36)
        Me.cbb_COM.TabIndex = 116
        '
        'btn_LamMoi
        '
        Me.btn_LamMoi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_LamMoi.FlatAppearance.BorderSize = 0
        Me.btn_LamMoi.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent
        Me.btn_LamMoi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btn_LamMoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btn_LamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_LamMoi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_LamMoi.ForeColor = System.Drawing.Color.Black
        Me.btn_LamMoi.Image = CType(resources.GetObject("btn_LamMoi.Image"), System.Drawing.Image)
        Me.btn_LamMoi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_LamMoi.Location = New System.Drawing.Point(114, 43)
        Me.btn_LamMoi.Name = "btn_LamMoi"
        Me.btn_LamMoi.Size = New System.Drawing.Size(82, 60)
        Me.btn_LamMoi.TabIndex = 3
        Me.btn_LamMoi.Text = "Làm Mới"
        Me.btn_LamMoi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_LamMoi.UseVisualStyleBackColor = True
        '
        'pnl_Menu
        '
        Me.pnl_Menu.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.pnl_Menu.Controls.Add(Me.btn_XLA)
        Me.pnl_Menu.Controls.Add(Me.btn_TrangKichBan)
        Me.pnl_Menu.Controls.Add(Me.btn_TrangCoCoDong)
        Me.pnl_Menu.Controls.Add(Me.btn_TrangBitTong)
        Me.pnl_Menu.Controls.Add(Me.btn_pnl_OnBit)
        Me.pnl_Menu.Controls.Add(Me.tb_Rserial)
        Me.pnl_Menu.Controls.Add(Me.btn_TK)
        Me.pnl_Menu.Controls.Add(Me.btn_Settings)
        Me.pnl_Menu.Controls.Add(Me.BtnSbso)
        Me.pnl_Menu.Controls.Add(Me.panel3)
        Me.pnl_Menu.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnl_Menu.Location = New System.Drawing.Point(0, 39)
        Me.pnl_Menu.Name = "pnl_Menu"
        Me.pnl_Menu.Size = New System.Drawing.Size(196, 1041)
        Me.pnl_Menu.TabIndex = 3
        '
        'btn_XLA
        '
        Me.btn_XLA.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.btn_XLA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btn_XLA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_XLA.FlatAppearance.BorderSize = 0
        Me.btn_XLA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_XLA.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_XLA.ForeColor = System.Drawing.Color.Black
        Me.btn_XLA.Image = CType(resources.GetObject("btn_XLA.Image"), System.Drawing.Image)
        Me.btn_XLA.Location = New System.Drawing.Point(4, 656)
        Me.btn_XLA.Name = "btn_XLA"
        Me.btn_XLA.Size = New System.Drawing.Size(189, 88)
        Me.btn_XLA.TabIndex = 116
        Me.btn_XLA.Text = "Xử lý ảnh"
        Me.btn_XLA.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_XLA.UseVisualStyleBackColor = False
        '
        'btn_TrangKichBan
        '
        Me.btn_TrangKichBan.AutoRoundedCorners = True
        Me.btn_TrangKichBan.BorderRadius = 21
        Me.btn_TrangKichBan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_TrangKichBan.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_TrangKichBan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_TrangKichBan.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_TrangKichBan.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_TrangKichBan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_TrangKichBan.FillColor = System.Drawing.Color.Gray
        Me.btn_TrangKichBan.FillColor2 = System.Drawing.Color.White
        Me.btn_TrangKichBan.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.btn_TrangKichBan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_TrangKichBan.Image = CType(resources.GetObject("btn_TrangKichBan.Image"), System.Drawing.Image)
        Me.btn_TrangKichBan.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_TrangKichBan.ImageOffset = New System.Drawing.Point(-2, 0)
        Me.btn_TrangKichBan.Location = New System.Drawing.Point(12, 420)
        Me.btn_TrangKichBan.Name = "btn_TrangKichBan"
        Me.btn_TrangKichBan.Size = New System.Drawing.Size(162, 44)
        Me.btn_TrangKichBan.TabIndex = 115
        Me.btn_TrangKichBan.Text = "Kịch Bản"
        Me.btn_TrangKichBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_TrangKichBan.TextOffset = New System.Drawing.Point(-10, 0)
        '
        'btn_TrangCoCoDong
        '
        Me.btn_TrangCoCoDong.AutoRoundedCorners = True
        Me.btn_TrangCoCoDong.BorderRadius = 21
        Me.btn_TrangCoCoDong.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_TrangCoCoDong.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_TrangCoCoDong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_TrangCoCoDong.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_TrangCoCoDong.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_TrangCoCoDong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_TrangCoCoDong.FillColor = System.Drawing.Color.Gray
        Me.btn_TrangCoCoDong.FillColor2 = System.Drawing.Color.White
        Me.btn_TrangCoCoDong.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.btn_TrangCoCoDong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_TrangCoCoDong.Image = CType(resources.GetObject("btn_TrangCoCoDong.Image"), System.Drawing.Image)
        Me.btn_TrangCoCoDong.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_TrangCoCoDong.ImageOffset = New System.Drawing.Point(-2, 0)
        Me.btn_TrangCoCoDong.Location = New System.Drawing.Point(12, 340)
        Me.btn_TrangCoCoDong.Name = "btn_TrangCoCoDong"
        Me.btn_TrangCoCoDong.Size = New System.Drawing.Size(162, 44)
        Me.btn_TrangCoCoDong.TabIndex = 114
        Me.btn_TrangCoCoDong.Text = "Cờ Cơ Động"
        Me.btn_TrangCoCoDong.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_TrangCoCoDong.TextOffset = New System.Drawing.Point(-10, 0)
        '
        'btn_TrangBitTong
        '
        Me.btn_TrangBitTong.AutoRoundedCorners = True
        Me.btn_TrangBitTong.BorderRadius = 21
        Me.btn_TrangBitTong.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_TrangBitTong.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_TrangBitTong.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_TrangBitTong.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_TrangBitTong.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_TrangBitTong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_TrangBitTong.FillColor = System.Drawing.Color.Gray
        Me.btn_TrangBitTong.FillColor2 = System.Drawing.Color.White
        Me.btn_TrangBitTong.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.btn_TrangBitTong.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_TrangBitTong.Image = CType(resources.GetObject("btn_TrangBitTong.Image"), System.Drawing.Image)
        Me.btn_TrangBitTong.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_TrangBitTong.ImageOffset = New System.Drawing.Point(-5, 0)
        Me.btn_TrangBitTong.Location = New System.Drawing.Point(12, 260)
        Me.btn_TrangBitTong.Name = "btn_TrangBitTong"
        Me.btn_TrangBitTong.Size = New System.Drawing.Size(162, 44)
        Me.btn_TrangBitTong.TabIndex = 113
        Me.btn_TrangBitTong.Text = "Đối Tượng Tổng"
        Me.btn_TrangBitTong.TextOffset = New System.Drawing.Point(4, 0)
        '
        'btn_pnl_OnBit
        '
        Me.btn_pnl_OnBit.AutoRoundedCorners = True
        Me.btn_pnl_OnBit.BackColor = System.Drawing.Color.Transparent
        Me.btn_pnl_OnBit.BorderRadius = 21
        Me.btn_pnl_OnBit.CheckedState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_pnl_OnBit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_pnl_OnBit.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_pnl_OnBit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_pnl_OnBit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_pnl_OnBit.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_pnl_OnBit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_pnl_OnBit.FillColor = System.Drawing.Color.Gray
        Me.btn_pnl_OnBit.FillColor2 = System.Drawing.Color.White
        Me.btn_pnl_OnBit.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.btn_pnl_OnBit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btn_pnl_OnBit.Image = CType(resources.GetObject("btn_pnl_OnBit.Image"), System.Drawing.Image)
        Me.btn_pnl_OnBit.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.btn_pnl_OnBit.ImageOffset = New System.Drawing.Point(-5, 0)
        Me.btn_pnl_OnBit.Location = New System.Drawing.Point(12, 180)
        Me.btn_pnl_OnBit.Name = "btn_pnl_OnBit"
        Me.btn_pnl_OnBit.PressedDepth = 0
        Me.btn_pnl_OnBit.ShadowDecoration.BorderRadius = 0
        Me.btn_pnl_OnBit.ShadowDecoration.Depth = 0
        Me.btn_pnl_OnBit.ShadowDecoration.Enabled = True
        Me.btn_pnl_OnBit.Size = New System.Drawing.Size(162, 44)
        Me.btn_pnl_OnBit.TabIndex = 112
        Me.btn_pnl_OnBit.Text = "Đối Tượng Đơn"
        '
        'tb_Rserial
        '
        Me.tb_Rserial.BackColor = System.Drawing.Color.White
        Me.tb_Rserial.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tb_Rserial.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Rserial.ForeColor = System.Drawing.Color.Black
        Me.tb_Rserial.Location = New System.Drawing.Point(0, 119)
        Me.tb_Rserial.Name = "tb_Rserial"
        Me.tb_Rserial.ReadOnly = True
        Me.tb_Rserial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tb_Rserial.Size = New System.Drawing.Size(196, 17)
        Me.tb_Rserial.TabIndex = 111
        Me.tb_Rserial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.tb_Rserial.Visible = False
        '
        'btn_TK
        '
        Me.btn_TK.AutoSize = True
        Me.btn_TK.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.btn_TK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_TK.FlatAppearance.BorderSize = 0
        Me.btn_TK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_TK.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_TK.ForeColor = System.Drawing.Color.Black
        Me.btn_TK.Image = CType(resources.GetObject("btn_TK.Image"), System.Drawing.Image)
        Me.btn_TK.Location = New System.Drawing.Point(0, 931)
        Me.btn_TK.Margin = New System.Windows.Forms.Padding(0)
        Me.btn_TK.Name = "btn_TK"
        Me.btn_TK.Size = New System.Drawing.Size(196, 88)
        Me.btn_TK.TabIndex = 12
        Me.btn_TK.Text = "Tài Khoản"
        Me.btn_TK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_TK.UseVisualStyleBackColor = False
        '
        'btn_Settings
        '
        Me.btn_Settings.AutoSize = True
        Me.btn_Settings.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.btn_Settings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Settings.FlatAppearance.BorderSize = 0
        Me.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Settings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Settings.ForeColor = System.Drawing.Color.Black
        Me.btn_Settings.Image = CType(resources.GetObject("btn_Settings.Image"), System.Drawing.Image)
        Me.btn_Settings.Location = New System.Drawing.Point(4, 466)
        Me.btn_Settings.Name = "btn_Settings"
        Me.btn_Settings.Size = New System.Drawing.Size(196, 88)
        Me.btn_Settings.TabIndex = 13
        Me.btn_Settings.Text = "Cài Đặt"
        Me.btn_Settings.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btn_Settings.UseVisualStyleBackColor = False
        '
        'BtnSbso
        '
        Me.BtnSbso.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(159, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.BtnSbso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.BtnSbso.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSbso.FlatAppearance.BorderSize = 0
        Me.BtnSbso.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSbso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSbso.ForeColor = System.Drawing.Color.Black
        Me.BtnSbso.Image = CType(resources.GetObject("BtnSbso.Image"), System.Drawing.Image)
        Me.BtnSbso.Location = New System.Drawing.Point(0, 746)
        Me.BtnSbso.Name = "BtnSbso"
        Me.BtnSbso.Size = New System.Drawing.Size(196, 88)
        Me.BtnSbso.TabIndex = 94
        Me.BtnSbso.Text = "Sa bàn số"
        Me.BtnSbso.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSbso.UseVisualStyleBackColor = False
        '
        'ThoiGian
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'FrmSBVLM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.btn_exit
        Me.ClientSize = New System.Drawing.Size(1920, 1080)
        Me.Controls.Add(Me.CB_TaoMuc)
        Me.Controls.Add(Me.pnl_Menu)
        Me.Controls.Add(Me.pnl_Tool)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSBVLM"
        Me.Text = "FrmSBVLM"
        Me.CB_TaoMuc.ResumeLayout(False)
        Me.CB_TaoMuc.PerformLayout()
        CType(Me.pc_Pin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_Tool.ResumeLayout(False)
        Me.Guna2GradientPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        Me.pnl_Menu.ResumeLayout(False)
        Me.pnl_Menu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btn_OffAll As Button
    Private WithEvents btn_NhayAll As Button
    Private WithEvents btn_OnAll As Button
    Private WithEvents btn_Settings As Button
    Private WithEvents btn_TK As Button
    Private WithEvents btn_LamMoi As Button
    Private WithEvents label1 As Label
    Private WithEvents CB_TaoMuc As Panel
    Private WithEvents BtnSbso As Button
    Private WithEvents btn_exit As Button
    Private WithEvents btn_AnCuaSo As Button
    Private WithEvents pnl_Tool As Panel
    Private WithEvents panel3 As Panel
    Private WithEvents pnl_Menu As Panel
    Friend WithEvents tb_Rserial As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tb_BN As TextBox
    Friend WithEvents DieuKhienCo As TextBox
    Friend WithEvents tb_TrinhChieuSBVL As TextBox
    Friend WithEvents TxtTrinhchieu As TextBox
    Friend WithEvents TxtDTmoi As TextBox
    Friend WithEvents TxtLaser As TextBox
    Friend WithEvents tb_TruyenBit As TextBox
    Friend WithEvents ThoiGian As Timer
    Friend WithEvents lb_ThoiGian As Label
    Private WithEvents btn_KetNoi As Button
    Friend WithEvents tb_TruyenBit_2 As TextBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents lb_pin As Label
    Friend WithEvents tb_pin As TextBox
    Friend WithEvents pc_Pin As PictureBox
    Friend WithEvents bt_fly As TextBox
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents TB_tencanh As TextBox
    Friend WithEvents TB_socanh As TextBox
    Private WithEvents bt_xoabit As Button
    Friend WithEvents tb_CCD As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtMuichieuSBVL As TextBox
    Friend WithEvents TxtKinhtuyentrucSBVL As TextBox
    Friend WithEvents tb_truyen As TextBox
    Friend WithEvents btn_TrangCoCoDong As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btn_TrangBitTong As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents btn_TrangKichBan As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents tb_kbtruyen As TextBox
    Friend WithEvents tb_truyenvitri As TextBox
    Friend WithEvents tb_truyentoado As TextBox
    Friend WithEvents tb_trangthaico As TextBox
    Friend WithEvents btn_pnl_OnBit As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Guna2Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Guna2GradientPanel1 As Guna.UI2.WinForms.Guna2GradientPanel
    Friend WithEvents cbb_COM As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents bt_inal As TextBox
    Friend WithEvents bt_mtt As TextBox
    Private WithEvents btn_XLA As Button
    Friend WithEvents lb_Khoa3Dmap As Label
    Friend WithEvents btn_Khoa3Dmap As Guna.UI2.WinForms.Guna2ToggleSwitch
    Public WithEvents tb_test As TextBox
End Class
