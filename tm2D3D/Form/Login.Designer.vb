<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.lb_KichHoat = New System.Windows.Forms.Label()
        Me.lbl_Status = New System.Windows.Forms.Label()
        Me.txtUserName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.txtPassword = New Guna.UI2.WinForms.Guna2TextBox()
        Me.pnl_Key = New Guna.UI2.WinForms.Guna2ShadowPanel()
        Me.tb_Key = New Guna.UI2.WinForms.Guna2TextBox()
        Me.btn_KichHoat = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.btn_XoaKey = New System.Windows.Forms.PictureBox()
        Me.Guna2DragControl1 = New Guna.UI2.WinForms.Guna2DragControl(Me.components)
        Me.Guna2ShadowForm1 = New Guna.UI2.WinForms.Guna2ShadowForm(Me.components)
        Me.btn_Exit = New System.Windows.Forms.Button()
        Me.Guna2Elipse1 = New Guna.UI2.WinForms.Guna2Elipse(Me.components)
        Me.btn_DangNhap = New Guna.UI2.WinForms.Guna2GradientButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lb_SNCL = New System.Windows.Forms.Label()
        Me.pnl_Key.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btn_XoaKey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lb_KichHoat
        '
        Me.lb_KichHoat.AutoSize = True
        Me.lb_KichHoat.BackColor = System.Drawing.Color.Transparent
        Me.lb_KichHoat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lb_KichHoat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_KichHoat.ForeColor = System.Drawing.Color.Red
        Me.lb_KichHoat.Location = New System.Drawing.Point(42, 361)
        Me.lb_KichHoat.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_KichHoat.Name = "lb_KichHoat"
        Me.lb_KichHoat.Size = New System.Drawing.Size(234, 18)
        Me.lb_KichHoat.TabIndex = 11
        Me.lb_KichHoat.Text = "Phần mềm chưa được đăng ký"
        '
        'lbl_Status
        '
        Me.lbl_Status.AutoSize = True
        Me.lbl_Status.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Status.ForeColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbl_Status.Location = New System.Drawing.Point(44, 294)
        Me.lbl_Status.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbl_Status.Name = "lbl_Status"
        Me.lbl_Status.Size = New System.Drawing.Size(88, 18)
        Me.lbl_Status.TabIndex = 0
        Me.lbl_Status.Text = "Trạng Thái"
        '
        'txtUserName
        '
        Me.txtUserName.AutoRoundedCorners = True
        Me.txtUserName.BackColor = System.Drawing.Color.Transparent
        Me.txtUserName.BorderColor = System.Drawing.Color.Black
        Me.txtUserName.BorderRadius = 17
        Me.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUserName.DefaultText = "Admin"
        Me.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUserName.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtUserName.Location = New System.Drawing.Point(15, 183)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtUserName.PlaceholderText = ""
        Me.txtUserName.SelectedText = ""
        Me.txtUserName.Size = New System.Drawing.Size(296, 36)
        Me.txtUserName.TabIndex = 1
        '
        'txtPassword
        '
        Me.txtPassword.AutoRoundedCorners = True
        Me.txtPassword.BackColor = System.Drawing.Color.Transparent
        Me.txtPassword.BorderColor = System.Drawing.Color.Black
        Me.txtPassword.BorderRadius = 17
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.DefaultText = "123456"
        Me.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(15, 233)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.txtPassword.PlaceholderText = ""
        Me.txtPassword.SelectedText = ""
        Me.txtPassword.Size = New System.Drawing.Size(296, 36)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'pnl_Key
        '
        Me.pnl_Key.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnl_Key.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnl_Key.Controls.Add(Me.tb_Key)
        Me.pnl_Key.Controls.Add(Me.btn_KichHoat)
        Me.pnl_Key.FillColor = System.Drawing.Color.White
        Me.pnl_Key.Location = New System.Drawing.Point(15, 343)
        Me.pnl_Key.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.pnl_Key.Name = "pnl_Key"
        Me.pnl_Key.ShadowColor = System.Drawing.Color.Black
        Me.pnl_Key.ShadowDepth = 0
        Me.pnl_Key.ShadowShift = 0
        Me.pnl_Key.ShadowStyle = Guna.UI2.WinForms.Guna2ShadowPanel.ShadowMode.ForwardDiagonal
        Me.pnl_Key.Size = New System.Drawing.Size(296, 51)
        Me.pnl_Key.TabIndex = 21
        Me.pnl_Key.Visible = False
        '
        'tb_Key
        '
        Me.tb_Key.AutoRoundedCorners = True
        Me.tb_Key.BackColor = System.Drawing.Color.Transparent
        Me.tb_Key.BorderColor = System.Drawing.Color.Black
        Me.tb_Key.BorderRadius = 15
        Me.tb_Key.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.tb_Key.DefaultText = ""
        Me.tb_Key.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.tb_Key.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.tb_Key.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tb_Key.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.tb_Key.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_Key.Font = New System.Drawing.Font("Segoe UI", 15.75!)
        Me.tb_Key.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.tb_Key.Location = New System.Drawing.Point(12, 10)
        Me.tb_Key.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tb_Key.Name = "tb_Key"
        Me.tb_Key.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.tb_Key.PlaceholderText = ""
        Me.tb_Key.SelectedText = ""
        Me.tb_Key.Size = New System.Drawing.Size(224, 32)
        Me.tb_Key.TabIndex = 29
        '
        'btn_KichHoat
        '
        Me.btn_KichHoat.BackColor = System.Drawing.Color.Transparent
        Me.btn_KichHoat.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_KichHoat.FlatAppearance.BorderSize = 0
        Me.btn_KichHoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_KichHoat.Image = CType(resources.GetObject("btn_KichHoat.Image"), System.Drawing.Image)
        Me.btn_KichHoat.Location = New System.Drawing.Point(244, 1)
        Me.btn_KichHoat.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_KichHoat.Name = "btn_KichHoat"
        Me.btn_KichHoat.Size = New System.Drawing.Size(45, 49)
        Me.btn_KichHoat.TabIndex = 1
        Me.btn_KichHoat.UseVisualStyleBackColor = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(86, 10)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(151, 149)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox5.TabIndex = 15
        Me.PictureBox5.TabStop = False
        '
        'btn_XoaKey
        '
        Me.btn_XoaKey.BackColor = System.Drawing.Color.Transparent
        Me.btn_XoaKey.Image = CType(resources.GetObject("btn_XoaKey.Image"), System.Drawing.Image)
        Me.btn_XoaKey.Location = New System.Drawing.Point(15, 290)
        Me.btn_XoaKey.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btn_XoaKey.Name = "btn_XoaKey"
        Me.btn_XoaKey.Size = New System.Drawing.Size(29, 25)
        Me.btn_XoaKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btn_XoaKey.TabIndex = 10
        Me.btn_XoaKey.TabStop = False
        '
        'Guna2DragControl1
        '
        Me.Guna2DragControl1.DockIndicatorTransparencyValue = 0.6R
        Me.Guna2DragControl1.TargetControl = Me
        Me.Guna2DragControl1.UseTransparentDrag = True
        '
        'btn_Exit
        '
        Me.btn_Exit.BackColor = System.Drawing.Color.Transparent
        Me.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btn_Exit.FlatAppearance.BorderSize = 0
        Me.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Exit.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Exit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(214, Byte), Integer))
        Me.btn_Exit.Location = New System.Drawing.Point(287, 1)
        Me.btn_Exit.Name = "btn_Exit"
        Me.btn_Exit.Size = New System.Drawing.Size(38, 35)
        Me.btn_Exit.TabIndex = 7
        Me.btn_Exit.Text = "X"
        Me.btn_Exit.UseVisualStyleBackColor = False
        '
        'Guna2Elipse1
        '
        Me.Guna2Elipse1.BorderRadius = 20
        Me.Guna2Elipse1.TargetControl = Me
        '
        'btn_DangNhap
        '
        Me.btn_DangNhap.AutoRoundedCorners = True
        Me.btn_DangNhap.BackColor = System.Drawing.Color.Transparent
        Me.btn_DangNhap.BorderRadius = 19
        Me.btn_DangNhap.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btn_DangNhap.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btn_DangNhap.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_DangNhap.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btn_DangNhap.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btn_DangNhap.FillColor2 = System.Drawing.Color.Blue
        Me.btn_DangNhap.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.btn_DangNhap.ForeColor = System.Drawing.Color.White
        Me.btn_DangNhap.Location = New System.Drawing.Point(170, 283)
        Me.btn_DangNhap.Name = "btn_DangNhap"
        Me.btn_DangNhap.Size = New System.Drawing.Size(141, 40)
        Me.btn_DangNhap.TabIndex = 0
        Me.btn_DangNhap.Text = "ĐĂNG NHẬP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(215, 400)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Phiên bản: v2.3.0"
        '
        'lb_SNCL
        '
        Me.lb_SNCL.AutoSize = True
        Me.lb_SNCL.BackColor = System.Drawing.Color.Transparent
        Me.lb_SNCL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lb_SNCL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lb_SNCL.ForeColor = System.Drawing.Color.Red
        Me.lb_SNCL.Location = New System.Drawing.Point(44, 343)
        Me.lb_SNCL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_SNCL.Name = "lb_SNCL"
        Me.lb_SNCL.Size = New System.Drawing.Size(129, 18)
        Me.lb_SNCL.TabIndex = 30
        Me.lb_SNCL.Text = "Số ngày còn lại:"
        Me.lb_SNCL.Visible = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(327, 415)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_DangNhap)
        Me.Controls.Add(Me.btn_Exit)
        Me.Controls.Add(Me.pnl_Key)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.lb_KichHoat)
        Me.Controls.Add(Me.btn_XoaKey)
        Me.Controls.Add(Me.lbl_Status)
        Me.Controls.Add(Me.lb_SNCL)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.TransparencyKey = System.Drawing.Color.Lime
        Me.pnl_Key.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btn_XoaKey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btn_KichHoat As Button
    Private WithEvents lb_KichHoat As Label
    Private WithEvents lbl_Status As Label
    Private WithEvents btn_XoaKey As PictureBox
    Private WithEvents PictureBox5 As PictureBox
    Friend WithEvents txtUserName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents txtPassword As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents pnl_Key As Guna.UI2.WinForms.Guna2ShadowPanel
    Friend WithEvents Guna2DragControl1 As Guna.UI2.WinForms.Guna2DragControl
    Friend WithEvents Guna2ShadowForm1 As Guna.UI2.WinForms.Guna2ShadowForm
    Private WithEvents btn_Exit As Button
    Friend WithEvents Guna2Elipse1 As Guna.UI2.WinForms.Guna2Elipse
    Friend WithEvents btn_DangNhap As Guna.UI2.WinForms.Guna2GradientButton
    Friend WithEvents Label1 As Label
    Friend WithEvents tb_Key As Guna.UI2.WinForms.Guna2TextBox
    Private WithEvents lb_SNCL As Label
End Class
