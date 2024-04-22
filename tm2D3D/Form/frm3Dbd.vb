Imports TerraExplorerX
Public Class Frm3Dbd
    Public Shared Instance As Frm3Dbd
    Public mPoint2D As IPosition71
    Friend WithEvents LbTenFile As ToolStripLabel

    Private Sub Frm3Dbd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
        Me.LbTenFile = New System.Windows.Forms.ToolStripLabel()
        LbTenFile.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
        LbTenFile.ForeColor = Color.White
        MenuClose.Items.Add(LbTenFile)
        Creen3Dbd()
        Open3DBD()
        Bdt3Dbd_3DA(AxTEInformationWindowEx1, AxTE3DWindowEx1)
        fLabelStyle3D = SLabelStyleTQ(sgworld3DBd)
    End Sub

    Private Sub Frm3Dbd_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
        AxTE3DWindowEx1.Top = 0
        AxTE3DWindowEx1.Left = 0
        AxTE3DWindowEx1.Height = Me.Height
        AxTE3DWindowEx1.Width = Me.Width
        AxTEInformationWindowEx1.Size = New Size(AxTEInformationWindowEx1.Size.Width, AxTE3DWindowEx1.Height / 2)
        AxTEInformationWindowEx1.Location = New Point(AxTE3DWindowEx1.Width - AxTEInformationWindowEx1.Width - 1, AxTE3DWindowEx1.Height - (AxTEInformationWindowEx1.Height + 1))
    End Sub

    Private Sub MenuClose_SizeChanged(sender As Object, e As EventArgs) Handles MenuClose.SizeChanged
        MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
    End Sub

    Private Sub MnuMini_Click(sender As Object, e As EventArgs) Handles mnuMini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MnuMax_Click(sender As Object, e As EventArgs) Handles mnuMax.Click
        MyScreen()
    End Sub

    Public Sub MyScreen()
        Me.WindowState = FormWindowState.Normal
        If (myScreens.Length = 1) Then
            Me.Location = New Point(0, 0)
            Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
        ElseIf (myScreens.Length = 2) Then
            Me.Location = New Point(Screen.AllScreens(1).WorkingArea.Left, Screen.AllScreens(1).WorkingArea.Top)
            Me.Height = Screen.AllScreens(1).WorkingArea.Height
            Me.Width = Screen.AllScreens(1).WorkingArea.Width
        End If
    End Sub

    Public Sub Open3DBD()
        sgworld3DBd = AxTE3DWindowEx1.CreateInstance("TerraExplorerX.SGWorld71")
        Try
            If FrmMain.Instance.lbChon3Dbd.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
                sgworld3DBd.Project.Open(file3Dbd, True, Nothing, Nothing)
                AxTE3DWindowEx1.Visible = True
                sgworld3DBd.Project.Settings("RemoveSkylineCopyright") = 1
            Else
                Me.Close()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        sgworld3DBd.Command.Execute(1052, 0)
        LbTenFile.Text = sgworld3DBd.Project.Name
        sgworld3DBd.Command.Execute(1065, 0)
        SOpen(sgworld3DBd, 0)
    End Sub

    Private Sub Creen3Dbd()
        'Me.StartPosition = FormStartPosition.Manual
        'Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width / 2, 0)
        'Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height)

        If (myScreens.Length = 1) Then
            Me.Top = 0
            Me.Left = My.Computer.Screen.WorkingArea.Width / 2
            If FrmMain.Instance.chebOpen3DA.Checked = True And FrmMain.Instance.chebOpenMS.Checked = False Then
                Me.Height = My.Computer.Screen.WorkingArea.Height / 2
                Me.Width = My.Computer.Screen.WorkingArea.Width / 2
            ElseIf FrmMain.Instance.chebOpen3DA.Checked = True And FrmMain.Instance.chebOpenMS.Checked = True Then
                Me.Height = My.Computer.Screen.WorkingArea.Height / 2
                Me.Width = My.Computer.Screen.WorkingArea.Width / 4
            ElseIf FrmMain.Instance.chebOpen3DA.Checked = False And FrmMain.Instance.chebOpenMS.Checked = True Then
                Me.Height = My.Computer.Screen.WorkingArea.Height / 2
                Me.Width = My.Computer.Screen.WorkingArea.Width / 2
            Else
                Me.Height = My.Computer.Screen.WorkingArea.Height
                Me.Width = My.Computer.Screen.WorkingArea.Width / 2
            End If
        ElseIf (myScreens.Length = 2) Then
            Me.Top = Screen.AllScreens(1).Bounds.Top
            Me.Left = Screen.AllScreens(1).Bounds.Left
            If FrmMain.Instance.chebOpen3DA.Checked = True Or FrmMain.Instance.chebOpenMS.Checked = True Then
                Me.Height = Screen.AllScreens(1).Bounds.Height
                Me.Width = Screen.AllScreens(1).Bounds.Width / 2
                If FrmMain.Instance.chebOpen3DA.Checked = True And FrmMain.Instance.chebOpenMS.Checked = False Then
                    Me.Height = Screen.AllScreens(1).Bounds.Height
                ElseIf FrmMain.Instance.chebOpen3DA.Checked = True And FrmMain.Instance.chebOpenMS.Checked = True Then
                    Me.Height = Screen.AllScreens(1).Bounds.Height / 2
                End If
            Else
                Me.Height = Screen.AllScreens(1).Bounds.Height
                Me.Width = Screen.AllScreens(1).Bounds.Width
            End If
        End If
        AxTE3DWindowEx1.Top = 0 'FrmMain.Instance.menuMain.Height
        AxTE3DWindowEx1.Left = 0
        AxTE3DWindowEx1.Width = Me.Width
        AxTE3DWindowEx1.Height = Me.Height
    End Sub

End Class