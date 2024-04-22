Imports TerraExplorerX
Public Class Frm3DA
    Public Shared Instance As Frm3DA
    Public mPoint3DA As IPosition71
    Friend WithEvents LbTenFile As ToolStripLabel

    Private Sub Frm3DA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
        Me.LbTenFile = New System.Windows.Forms.ToolStripLabel()
        LbTenFile.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
        LbTenFile.ForeColor = Color.White
        MenuClose.Items.Add(LbTenFile)
        Creen3DA()
        Open3DA()
        Bdt3Dbd_3DA(AxTEInformationWindowEx2, AxTE3DWindowEx2)
        fLabelStyle3D = SLabelStyleTQ(sgworld3DA)
    End Sub

    Private Sub Frm3DA_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
        AxTE3DWindowEx2.Top = 0
        AxTE3DWindowEx2.Left = 0
        AxTE3DWindowEx2.Height = Me.Height
        AxTE3DWindowEx2.Width = Me.Width
        AxTEInformationWindowEx2.Size = New Size(AxTEInformationWindowEx2.Size.Width, AxTE3DWindowEx2.Height / 2)
        AxTEInformationWindowEx2.Location = New Point(AxTE3DWindowEx2.Width - AxTEInformationWindowEx2.Width - 1, AxTE3DWindowEx2.Height - (AxTEInformationWindowEx2.Height + 1))
    End Sub

    Private Sub MnuMini_Click(sender As Object, e As EventArgs) Handles mnuMini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub MnuMax_Click(sender As Object, e As EventArgs) Handles mnuMax.Click
        Frm3Dbd.Instance.MyScreen()
    End Sub

    Private Sub MenuClose_SizeChanged(sender As Object, e As EventArgs) Handles MenuClose.SizeChanged
        MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
    End Sub

    Private Sub Open3DA()
        sgworld3DA = AxTE3DWindowEx2.CreateInstance("TerraExplorerX.SGWorld71")
        Try
            If FrmMain.Instance.lbChon3Dbd.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
                sgworld3DA.Project.Open(file3DA, True, Nothing, Nothing)
                AxTE3DWindowEx2.Visible = True
                sgworld3DA.Project.Settings("RemoveSkylineCopyright") = 1
            Else
                Me.Close()
                Exit Sub
            End If
        Catch ex As Exception
        End Try
        sgworld3DA.Command.Execute(1052, 0)
        LbTenFile.Text = sgworld3DA.Project.Name
        SOpen(sgworld3DA, 0)
    End Sub

    Private Sub Creen3DA()
        If (myScreens.Length = 1) Then
            If FrmMain.Instance.chebOpenMS.Checked = True Then
                Me.Top = 0 ' My.Computer.Screen.WorkingArea.Height / 2
                Me.Left = 3 / 4 * My.Computer.Screen.WorkingArea.Width
                Me.Height = My.Computer.Screen.WorkingArea.Height / 2
                Me.Width = My.Computer.Screen.WorkingArea.Width / 4
            Else
                Me.Top = My.Computer.Screen.WorkingArea.Height / 2
                Me.Left = My.Computer.Screen.WorkingArea.Width / 2
                Me.Height = My.Computer.Screen.WorkingArea.Height / 2
                Me.Width = My.Computer.Screen.WorkingArea.Width / 2
            End If
        ElseIf (myScreens.Length = 2) Then
            If FrmMain.Instance.chebOpenMS.Checked = False Then
                Me.Top = Screen.AllScreens(1).Bounds.Top
                Me.Left = Screen.AllScreens(1).Bounds.Left + Screen.AllScreens(1).Bounds.Width / 2
                Me.Height = Screen.AllScreens(1).Bounds.Height
            ElseIf FrmMain.Instance.chebOpenMS.Checked = True Then
                Me.Top = Screen.AllScreens(1).Bounds.Top + Screen.AllScreens(1).Bounds.Height / 2
                Me.Left = Screen.AllScreens(1).Bounds.Left
                Me.Height = Screen.AllScreens(1).Bounds.Height / 2
            End If
            Me.Width = Screen.AllScreens(1).Bounds.Width / 2
        End If
        AxTE3DWindowEx2.Top = 0
        AxTE3DWindowEx2.Left = 0
        AxTE3DWindowEx2.Width = Me.Width
        AxTE3DWindowEx2.Height = Me.Height
    End Sub

End Class