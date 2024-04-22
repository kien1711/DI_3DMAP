Imports System.IO
Imports TerraExplorerX
Public Class FrmTC
    Public Shared Instance As FrmTC
    Public mPoint2D As IPosition71
    Friend WithEvents LbTenFile As ToolStripLabel
    Dim LinkDoCao As String = "C:\saban\tuongtacXY\docao1.txt"
    Dim LinkDoNghieng As String = "C:\saban\tuongtacXY\donghieng1.txt"
    Dim Roat As Integer = 69
    Dim DoCao1 As Integer = 250000
    Public FRMS As Boolean = False
    Private Sub Frm3Dbd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LbTenFile = New System.Windows.Forms.ToolStripLabel()
        LbTenFile.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
        LbTenFile.ForeColor = Color.White
        Creen3Dbd()
        Open3DBD()
        FrmTCcreen()
        Bdt3Dbd_3DA(AxTEInformationWindowEx1, AxTE3DWindowEx1)
        fLabelStyle3D = SLabelStyleTQ(sgworld3DBd)


        Nentrinhdien()
        AxTEInformationWindowEx1.Visible = False
        FRMS = True
    End Sub
    Public Sub FrmTCcreen()
        Try
            If (myScreens.Length = 1) Then
                Me.Location = New Point(0, 0)
                'Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
            ElseIf (myScreens.Length = 2) Then
                For Each scr As Screen In Screen.AllScreens
                    If Not scr.Primary Then
                        Me.Top = scr.Bounds.Top
                        Me.Left = scr.Bounds.Left
                        Exit For
                    End If
                Next
                'Me.Top = Screen.AllScreens(1).Bounds.Top
                'Me.Left = Screen.AllScreens(1).Bounds.Left
                'Me.Size = New Size(Screen.AllScreens(1).WorkingArea.Width, Screen.AllScreens(1).WorkingArea.Height)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Frm3Dbd_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Try
            AxTE3DWindowEx1.Top = 0
            AxTE3DWindowEx1.Left = 0
            AxTE3DWindowEx1.Height = Me.Height
            AxTE3DWindowEx1.Width = Me.Width
            AxTEInformationWindowEx1.Size = New Size(AxTEInformationWindowEx1.Size.Width, AxTE3DWindowEx1.Height / 2)
            AxTEInformationWindowEx1.Location = New Point(AxTE3DWindowEx1.Width - AxTEInformationWindowEx1.Width - 1, AxTE3DWindowEx1.Height - (AxTEInformationWindowEx1.Height + 1))
        Catch
        End Try
    End Sub
    Public Sub Open3DBD()

        sgworld3DBd = AxTE3DWindowEx1.CreateInstance("TerraExplorerX.SGWorld71")
        Try
            If FrmMain.Instance.btfile.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
                sgworld3DBd.Project.Open(filebt, True, Nothing, Nothing)
                AxTE3DWindowEx1.Visible = True
                sgworld3DBd.Project.Settings("RemoveSkylineCopyright") = 1
                Task.Run(Sub() KD_VD_Fly())
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
    Public Sub Open3DBD1()
        sgworld3DBd = AxTE3DWindowEx1.CreateInstance("TerraExplorerX.SGWorld71")
        Try
            If FrmMain.Instance.btfile.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
                ' Đóng project hiện tại
                sgworld3DBd.Project.Close()

                ' Mở lại project từ file
                sgworld3DBd.Project.Open(filebt, True, Nothing, Nothing)
                AxTE3DWindowEx1.Visible = True
                sgworld3DBd.Project.Settings("RemoveSkylineCopyright") = 1
                Task.Run(Sub() KD_VD_Fly())
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
        Nentrinhdien1()
    End Sub
    Private Sub Nentrinhdien1()
        Try
            Dim id As String = sgworld3DBd.ProjectTree.FindItem("Trinhchieu")
            If String.IsNullOrWhiteSpace(id) Or String.IsNullOrEmpty(id) Then
                sgworld3DBd.ProjectTree.LoadFlyLayer(PathData & "\Trinhchieu.fly",)
            End If
            sgworld3DBd.Command.Execute(1054, 0)


            Dim ic = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem("Trinh bay\Khung\Khung"))
            sgworld3DBd.Navigate.FlyTo(sgworld3DBd.Creator.CreatePosition(ic.Position.X, ic.Position.Y, FrmMain.Instance.DoCao_met, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, FrmMain.Instance.GocNghieng, 0, 0), ActionCode.AC_JUMP)
        Catch
        End Try
    End Sub
    Private Sub Nentrinhdien()
        Try
            Dim id As String = sgworld3DBd.ProjectTree.FindItem("Trinhchieu")
            If String.IsNullOrWhiteSpace(id) Or String.IsNullOrEmpty(id) Then
                sgworld3DBd.ProjectTree.LoadFlyLayer(PathData & "\Trinhchieu.fly",)
            End If
            sgworld3DBd.Command.Execute(1054, 0)
            Dim ic = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem("Trinh bay\Khung\Khung"))
            sgworld3DBd.Navigate.FlyTo(sgworld3DBd.Creator.CreatePosition(ic.Position.X, ic.Position.Y, FrmMain.Instance.DoCao_met, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, FrmMain.Instance.GocNghieng, 0, 0), ActionCode.AC_JUMP)
        Catch
        End Try
    End Sub
    Public Sub formclos()
        Me.Close()
    End Sub
    Private Sub Creen3Dbd()
        Try
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
        Catch
        End Try
    End Sub
    Dim DoCao_met As Integer
    Dim GocNghieng As Integer
    Private Sub KD_VD_Fly()
        Try
            While True
                Dim currentPos As Object = sgworld3DBd.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN)
                Dim kinhdo = currentPos.X
                Dim vido = currentPos.Y
                DoCao_met = CInt(currentPos.Altitude)
                GocNghieng = CInt(90 - (currentPos.Pitch - 270))
                docaoreal.Text = DoCao_met.ToString()
                donghiengreal.Text = GocNghieng.ToString()
            End While
        Catch ex As Exception

        End Try
    End Sub

#Region "Python"
    Public Sub New()
        InitializeComponent()
        Instance = Me
    End Sub
    Public Shared Event ValueChanged1 As EventHandler(Of String)
    Public Shared Property ReturnedValue1 As String
    Private _isClosed As Boolean = False
    Public ReadOnly Property IsClosed As Boolean
        Get
            Return _isClosed
        End Get
    End Property
    Private Sub FrmTC_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _isClosed = True
    End Sub
    Public Shared Sub ShowTC()
        Try
            Dim form As New FrmTC()
            form.Show()
            ' Chờ cho đến khi form đóng
            While Not form.IsClosed
                Application.DoEvents() ' Cho phép ứng dụng xử lý các sự kiện khác trong khi chờ đợi
            End While
        Catch
        End Try
    End Sub
    Public Shared Sub TCclose()
        Instance.Close()
    End Sub
#End Region
End Class