Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization
Imports MicroStationDGN
Imports TerraExplorerX
Imports TerraExplorerX.ActionCode
Imports TerraExplorerX.DynamicMotionStyle
Imports TerraExplorerX.DynamicObjectType
Imports TerraExplorerX.WorldPointType
Imports System.Xml
Imports System.Threading
Imports System.Runtime.CompilerServices
Imports System.Drawing.Imaging

Public Class FrmMain
#Region "     Bien"
    Public Shared Instance As FrmMain
    Public sgworldMain As SGWorld71
    Private pChuthap As ITerrainImageLabel71
    Public mPoint As IPosition71 = Nothing, mPointClick As IPosition71 = Nothing
    Private PosPixel As IPosition71 = Nothing, mPos As IPosition71 = Nothing
    Public fLabelStyleMain As ILabelStyle71 = Nothing
    Public P As New Point3D
    Private WaypointArr() As IRouteWaypoint71, WaypointArr1a() As IRouteWaypoint71 = Nothing, WaypointArr1() As IRouteWaypoint71 = Nothing, WaypointArr2() As IRouteWaypoint71 = Nothing, WaypointArr3() As IRouteWaypoint71 = Nothing, WaypointArr4() As IRouteWaypoint71 = Nothing, WaypointArr5() As IRouteWaypoint71 = Nothing, WaypointArr6() As IRouteWaypoint71 = Nothing
    Public loaiDTchuyendong As DynamicMotionStyle, kieuDTchuyendong As DynamicObjectType, mAltitudeType As AltitudeTypeCode
    Private TGian As Double = 0, timerDTCD As Double = 0
    Public WithEvents D23timer As New System.Windows.Forms.Timer, D43timer As New System.Windows.Forms.Timer
    Private WithEvents TimerMohinh As New System.Windows.Forms.Timer, DTCDTimer As New System.Windows.Forms.Timer, TiKichban As New System.Windows.Forms.Timer, TiTructiep As New System.Windows.Forms.Timer, MTtimer As New System.Windows.Forms.Timer, MTtimer1 As New System.Windows.Forms.Timer, TimerTrT As New System.Windows.Forms.Timer ' TimerStop As New System.Windows.Forms.Timer ' = New System.Windows.Forms.Timer
    Private mTempLine As Boolean = False
    Private mauTieude As Color = Nothing
    Public WithEvents SLabel As New Label, ChebTheoNhom As New CheckBox, TxtTenKH As New ToolStripTextBox, TxtVT As New ToolStripTextBox, ChebTron As New CheckBox, ChebTheoGD As New CheckBox, ChebBangDT As New CheckBox
    Public WithEvents LbTieude As New Label, LabelTenKH As New ToolStripLabel, LabelCloseTool As New ToolStripLabel, LabelThongtin As New ToolStripLabel, LbCloseToolRT As New ToolStripLabel, LabelGhichuKH As New ToolStripLabel, TxtGhichuKH As New ToolStripTextBox
    Private ReadOnly networkPort As Integer = 65535
    Private ReadOnly cbNhieuSCH(5) As ComboBox, lbNhieuSCH(5) As Label, chebHL(5) As CheckBox, txtDT(5) As TextBox
    Private ReadOnly lisTdoMT As New List(Of String)
    Private ReadOnly eCD As New List(Of String)
    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" (ByVal lpstrCommand As String, ByVal lpstrReturnString As String, ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer
    Public TextFile As StreamReader = Nothing
    Private xpos1 As Integer
    Private ypos1 As Integer
    Private newpoint As System.Drawing.Point
    Dim DoCao As Integer = 5000
    Dim folderPath1 As String
    Dim xmlFilePath As String
    Dim tbck As String
    Dim tenco As String
    Dim Nen As Integer = 0
    Private WithEvents watcher As New FileSystemWatcher()
    Dim LCxx As Integer = 0
    Dim LCyy As Integer = 0
    Dim Roat As Integer = 45
    Dim DoCao1 As Integer = 30000
    Public DoCao_met As Double = 70000
    Public GocNghieng As Integer = 65
    Dim ToaXCT As Double
    Dim ToaYCT As Double
    Public RMSBS As Boolean = False
    Public RMSS As Boolean = False
    Public motrinhchieu As Integer = False
    Dim WithEvents BangKichBan As New KichBan
    Dim luachon As Integer = 0

#End Region
#Region "   Form, File *.FLY"

    Public Sub New()
        InitializeComponent()
        Instance = Me
        sgworldMain = New SGWorld71()
    End Sub

    Public Sub SetMouseArrow()
        sgworldMain.Window.SetInputMode(MouseInputMode.MI_COM_CLIENT, "", True)
    End Sub

    Private Sub SetMouseHand()
        Try
            sgworldMain.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT, "", True)
        Catch eX As Exception
            Exit Sub
        End Try
    End Sub

    Friend WithEvents LbTenFile As ToolStripLabel, LbToadoM As ToolStripLabel, LbMaychinh As ToolStripLabel

    Private Sub FrmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        PllVtNum = 0
        ChiaManHinh()
        folderPath1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data")
    End Sub

    Private Sub FrmMain_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Try
            Dim g As Graphics = e.Graphics
            Dim p3 As New Point(Me.Width / 2, 0)
            Dim p4 As New Point(Me.Width / 2, Me.Height)
            Using brsGradient1 As New System.Drawing.Drawing2D.LinearGradientBrush(p3, p4, Color.DarkSlateGray, Color.Black)
                g.FillRectangle(brsGradient1, e.ClipRectangle)
            End Using
        Catch
        End Try
    End Sub

    Private Sub AddControls()
        Try
#Disable Warning IDE0017 ' Simplify object initialization
            ChebBangDT = New CheckBox With {.Text = "Bảng đối tượng."}
            ChebBangDT.ForeColor = Color.White
            ChebBangDT.Padding = New Padding(10, 0, 0, 0)
            ChebBangDT.FlatStyle = FlatStyle.Flat
            ChebBangDT.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
            Dim host6 = New ToolStripControlHost(ChebBangDT)
            menuMain.Items.Insert(6, host6)
            AddHandler ChebBangDT.CheckedChanged, AddressOf ChebBangDT_CheckedChanged
            ChebBangDT.Checked = False

#Enable Warning IDE0017 ' Simplify object initialization
            MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
            Me.LbTenFile = New System.Windows.Forms.ToolStripLabel()
            LbTenFile.TextAlign = ContentAlignment.MiddleRight
            LbTenFile.ForeColor = Color.White
            LbTenFile.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
            menuMain.Items.Add(LbTenFile)
            Me.LbToadoM = New System.Windows.Forms.ToolStripLabel()
            LbToadoM.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Regular)
            LbToadoM.RightToLeft = RightToLeft.No
            LbToadoM.ForeColor = Color.White
            MenuClose.Items.Add(LbToadoM)
            'Me.LbMaychinh = New System.Windows.Forms.ToolS
            'tripLabel()
            'LbMaychinh.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Underline)
            'LbMaychinh.Text = ""
            'LbMaychinh.ForeColor = Color.OrangeRed
            'MenuClose.Items.Add(LbMaychinh)
        Catch
        End Try
    End Sub

    Private Sub FrmMain_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Try
            MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
            Me.AxTE3DWindow1.Location = New Point(0, 0)
            Me.AxTE3DWindow1.Size = New Size(Me.Width, Me.Height)
            If Me.Width = Screen.PrimaryScreen.WorkingArea.Width Then
                mnuMax.Visible = False
            Else
                mnuMax.Visible = True
            End If
        Catch
        End Try
    End Sub

    Private Sub DKForm2D()
        Try
            If chebOpen3Dbd.Checked = True Or chebOpenMS.Checked = True Then
                If (myScreens.Length = 1) Then
                    Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height)
                ElseIf (myScreens.Length = 2) Then
                    Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
                    'FrmSBVLM.Instance.InstanceScreen()
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub SMainClose()
        Try
            Me.isNetworkConnected = False
            KillProc()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Sub KillProc()
        For Each p As Process In Process.GetProcesses
            Try
                If p.ProcessName = "ustation" Then
                    p.Kill()
                ElseIf p.ProcessName = "TerraExplorer" Then
                    p.Kill()
                ElseIf p.ProcessName = "Imap3D" Then
                    p.Kill()
                End If
            Catch ex As Exception
                Exit Try
            End Try
        Next
    End Sub

    Private Sub FrmMain_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        SMainClose()
    End Sub

    Private Sub FrmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        SMainClose()
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            CloseAllTool()
            CloseAllPanel()
            Select Case MessageBox.Show("Bạn muốn thoát 3DmapTP không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                Case System.Windows.Forms.DialogResult.OK
                    CloseVKTC()
                    FrmSBVLM.Instance.TKB1()
              ''  ShowTaskbar()
                Case System.Windows.Forms.DialogResult.Cancel
                    e.Cancel = True 'cancel the form closing event
            End Select
        Catch
        End Try
    End Sub

    Private Sub CloseVKTC()

        ' Additional code for closing VKTC
        SState()
        isNetworkConnected = False
        MouseHook1.Dispose()
        Try
            SExitMs()
            SSaveFly()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ExitMs()
        Try
            If mMicrostation = False Then
                Exit Sub
            Else
                MS.CadInputQueue.SendKeyin("DELETE UNUSED LEVELS")
                MS.ActiveDesignFile.Close()
                MS.CadInputQueue.SendCommand("exit", True)
                mMicrostation = False
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub OpenFly(Fle As String)
        If Fle <> "" Then
            Try
                DKForm2D()
                AddControls()
                ChebBangDT.Checked = False
                sgworldMain.Project.Open(Fle, False, "", "")
                'MsgBox("11")
                'sgworldMain.Project.Settings("DisplaySun") = True
                'sgworldMain.Project.Settings("RemoveSkylineCopyright") = 1
                'MsgBox("22")
                Dim TC = sgworldMain.ProjectTree.FindItem("Trinh bay\Khung\Khung")
                If TC <> "" Then
                    cb_maychieu.Enabled = True
                End If

                panelOpenVKTC.Visible = False
                AxTE3DWindow1.Visible = True
                mnuKHQS.Enabled = True
                mnuLuachon.Enabled = True
                mnuTienich.Enabled = True
                mnuSaveAs.Enabled = True
                mnuOpenFly.Enabled = False
                mnuNew.Enabled = False
                mnuMicrostationData.Enabled = False
                OpenFileDialog1.FileName = ""
                fLabelStyleMain = SLabelStyleTQ(sgworldMain)
                cb_maychieu.Text = "Chế độ 3D"
                chuthap.Text = "Mở chữ thập"
                Dim id As String = sgworldMain.ProjectTree.FindItem("Trinhchieu")
                sgworldMain.ProjectTree.DeleteItem(id)
                sgworldMain.Command.Execute(1052, 0)
                MnuCloseSkyline.Enabled = True
                Task.Run(Sub() KD_VD_Fly())
                FrmSBVLM.Instance.TKB()
                If Bd3D = True Then
                    fLabelStyleMain.LockMode = LabelLockMode.LM_AXIS
                Else
                    fLabelStyleMain.LockMode = LabelLockMode.LM_DECAL
                End If
                LbTenFile.Text = "   " & sgworldMain.Project.Name
                sgworldMain.Command.Execute(1062, 0) 'SPEED
                sgworldMain.Command.Execute(1063, 0) 'Latitude met
                If Bd3D = True Then
                    SOpen(sgworldMain, 0.16)
                    sgworldMain.Command.Execute(1054, 0)
                Else
                    SOpen(sgworldMain, 0)
                End If
                ChebBangDT.Visible = True
                DinhviBDT()

                System.Threading.Thread.Sleep(100)
                MnuCloseSkyline.Enabled = True
                sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Temp"))
                ChebBangDT.Checked = True
                RMSBS = True

                TTChuThap = 1
                Dim ChuThap1 = sgworldMain.ProjectTree.FindItem("Chu Thap")
                If ChuThap1 <> "" Then
                    sgworldMain.ProjectTree.DeleteItem(ChuThap1)
                End If
                ScanGroup()
                sgworldMain.Project.Save()
                Task.Run(Sub() LayToaDoSBVL())
            Catch eX As Exception
                'MsgBox("Tập tin *.fly bị lỗi!!!")
                'Me.Close()
            End Try
        Else
            MsgBox("Không có tập tin *.fly")
            Exit Sub
        End If
        MouseHook1.InstallHook()
        Try
            sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Dchuyen"))
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    Private Sub D23timer_Tick(sender As Object, e As EventArgs) Handles D23timer.Tick
        D23timer.Stop()
        Try
            If Bd3D = True Then
                VKTC3D()
            Else
                GoTo eMcrostation
            End If
eMcrostation:
            If mMicrostation = True Then
                MicroStation()
            Else
                GoTo eExit
            End If
eExit:
            Exit Sub
        Catch ex As Exception
        End Try
    End Sub

#Region " Save and ExIt"
    Private Sub SState()
        Try
            File.Delete(PathData & "\State.ini")
            Dim w As New IO.StreamWriter(PathData & "\State.ini", FileMode.CreateNew)
            Dim vitri As String = String.Empty
            If Bd3D = False Then
                vitri = Vitritrinhchieu()
            Else
                vitri = Vitritrinhchieu.Split("_")(0)
            End If
            w.WriteLine(vitri & ";" & cbGiaidoan.SelectedIndex.ToString & ";" & cbTylebando.SelectedIndex.ToString & ";" & cbTa_DP.SelectedIndex.ToString & ";" & cbChieuKH.SelectedIndex.ToString & ";" & cbHienthiToado.SelectedIndex.ToString) '& ";" & txtThamsoToadoX.Text & ";" & txtThamsoToadoY.Text)
            w.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub SSaveFly()
        Try
            sgworldMain.Project.Save() 'Save
            If Bd3D = True Then
                sgworld3DBd.Project.Save()
            ElseIf A3D = True Then
                sgworld3DA.Project.Save()
            Else
                Exit Sub
            End If
        Catch
        End Try
    End Sub

    Private Sub SExitMs()
        Try
            If mMicrostation = False Then
                Exit Sub
            Else
                XoaTextEmpty()
                MS.CadInputQueue.SendKeyin("DELETE UNUSED LEVELS")
                MS.ActiveDesignFile.Close()
                MS.CadInputQueue.SendCommand("exit", True)
                mMicrostation = False
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            XoaMs()
        End Try
    End Sub
    Private Sub KD_VD_Fly()
        Try
            While True
                Dim currentPos As Object = sgworldMain.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN)
                Dim kinhdo = currentPos.X
                Dim vido = currentPos.Y
                Dim DoCao_met As Integer = CInt(currentPos.Altitude)
                Dim GocNghieng As Integer = CInt(85 - (currentPos.Pitch - 270))
                docaoreal.Text = DoCao_met.ToString()
                donghiengreal.Text = GocNghieng.ToString()
            End While
        Catch ex As Exception

        End Try
    End Sub
    Private Sub XoaTextEmpty()
        Try
            MS.CadInputQueue.SendKeyin("mdl silentload selectby;selectby type none;selectby type text;selectby execute")
            MS.CadInputQueue.SendKeyin("mdl unload selectby")
            Dim ee As ElementEnumerator
            ee = MS.ActiveModelReference.GetSelectedElements
            Dim oTextEl As TextElement
            Do While ee.MoveNext
                oTextEl = ee.Current
                If oTextEl.DisplayPriority = 1000 Then
                    MS.ActiveModelReference.RemoveElement(oTextEl)
                    MS.CommandState.StartDefaultCommand()
                End If
            Loop
        Catch
        End Try
    End Sub

    Private Sub XoaMs()
        Try
            CopyUserConfig(PathData & "\dfltuser.cfg")
            System.Threading.Thread.Sleep(10)
            File.Delete("c:\Users\All Users\Bentley\MicroStation\WorkSpace\Users\transDGN.ucf")
        Catch
        End Try
    End Sub

    Private Sub CopyUserConfig(Nguon As String) 'Nguon As String, Dich As String)
        Try
            Dim Dich As String = String.Empty
            Dim Folder As New IO.DirectoryInfo("C:\Users\" & Environment.UserName & "\AppData\Local\Bentley\MicroStation\8.11\")
            For i As Integer = 0 To Folder.GetDirectories.Count - 1
                Dich = Folder.GetDirectories.ElementAt(i).FullName & "\prefs\" & "dfltuser.cfg"
                My.Computer.FileSystem.CopyFile(Nguon, Dich, True)
                File.Copy(PathData & "\RSC\transDGN.ucf", "c:\Users\All Users\Bentley\MicroStation\WorkSpace\Users\transDGN.ucf", True)
            Next
        Catch
        End Try
    End Sub

#End Region

#End Region
#Region "   Mouse, Point"
    Private Sub Laytoado()
        Try
            If Lenhve2 = "dichuyen" Then
                mPointMS1 = sgworldMain.Window.CenterPixelToWorld(WorldPointType.WPT_DEFAULT).Position
                '  MsgBox(mPointMS1.Altitude.ToString)
                '   MsgBox(sgworldMain.Window.RemovePopupByCaption("Text Label Properties")
                D23timer.Start()
                D23timer.Interval = 100
                Lenhve2D2 = Lenhve2
                lenhveMS2 = Lenhve2
                Lenhve2 = ""
            Else
                Exit Sub
            End If
        Catch
        End Try
    End Sub

    Public Function XyNhan(xyVN As Double, mStart As Integer, mLenght As Integer) As String
        Try
            Dim kmXY As Integer = System.Convert.ToInt32(xyVN.ToString.Substring(mStart, mLenght)) '* 1000
            Dim nXY As String = String.Empty
            If cbTylebando.SelectedIndex = 3 Then
                If (kmXY Mod 2 = 0) Then
                    kmXY = kmXY
                Else
                    kmXY -= 1
                End If
            ElseIf cbTylebando.SelectedIndex = 0 Or cbTylebando.SelectedIndex = 1 Or cbTylebando.SelectedIndex = 2 Then
                kmXY = kmXY
            End If
            If kmXY = 0 Then
                nXY = "00"
            Else
                If kmXY.ToString.Length = 1 Then
                    nXY = "0" & kmXY.ToString
                ElseIf kmXY.ToString.Length = 2 Then
                    nXY = kmXY.ToString
                End If
            End If
            XyNhan = nXY
        Catch
        End Try
    End Function
    Private Sub MouseScrollEvent(sender As Object, e As WindowsHookLib.MouseEventArgs) Handles MouseHook1.MouseWheel
        Try
            Dim currentPos As Object = sgworldMain.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN)
            Dim kinhdo = currentPos.X
            Dim vido = currentPos.Y
            DoCao_met = currentPos.Altitude
            GocNghieng = CInt(85 - (currentPos.Pitch - 270))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MouseHook1_MouseMove(sender As Object, e As WindowsHookLib.MouseEventArgs) Handles MouseHook1.MouseMove
        Try
            Dim xPixel As Double = 0, yPixel As Double = 0
            xPixel = System.Windows.Forms.Cursor.Position.X
            yPixel = System.Windows.Forms.Cursor.Position.Y '- menuMain.Height
            PosPixel = sgworldMain.Window.PixelToWorld(xPixel, yPixel, WPT_TERRAIN).Position
            If Not Lenhve = "muitiencongchuyeu" And Not Lenhve = "muiteincongthuyeu" And Not Lenhve = "muitiencongCYngan" And Not Lenhve = "duongdon" And Not Lenhve = "hangraobungnhung" Then '
                Try
                    SVn2000(PosPixel)
                Catch ex As Exception
                End Try
            End If
            If TiTructiep.Enabled = False Then
                If System.Windows.Forms.Cursor.Position.Y < My.Computer.Screen.WorkingArea.Height - 10 Then ' And System.Windows.Forms.Cursor.Position.Y < My.Computer.Screen.WorkingArea.Width Then
                    If cbHienthiToado.SelectedIndex = 0 Then
                        luachon = 0
                        If (PosPixel.X).ToString() > 0 Then
                            LbToadoM.Text = XyNhan(xVN2000, 2, 2) & " " & XyNhan(yVN2000, 1, 2)
                        End If
                    ElseIf cbHienthiToado.SelectedIndex = 1 Then
                        luachon = 1
                        Dim kmX As Integer = 0, kmY As Integer = 0, cX As Integer = 0, cY As Integer = 0, cX1 As Integer = 0, cY1 As Integer = 0
                        Dim o9 As String = String.Empty
                        kmX = System.Convert.ToInt32(xVN2000)
                        kmY = System.Convert.ToInt32(yVN2000)
                        cX = System.Convert.ToInt32(kmX.ToString.Substring(4, 3))
                        cY = System.Convert.ToInt32(kmY.ToString.Substring(3, 3))
                        Dim mX As Integer = System.Convert.ToInt32(kmX.ToString.Substring(2, 2)) * 1000
                        Dim mY As Integer = System.Convert.ToInt32(kmY.ToString.Substring(1, 2)) * 1000
                        Dim dx As Integer = 360, dy As Integer = 340

                        If cbTylebando.SelectedIndex = 3 Then
                            dx *= 2
                            dy *= 2
                            If (mX / 1000 Mod 2 = 0) Then
                                mX = mX
                                cX1 = cX
                            Else
                                mX -= 1000
                                cX1 = cX + 1000
                            End If
                            If (mY / 1000 Mod 2 = 0) Then
                                mY = mY
                                cY1 = cY
                            Else
                                mY -= 1000
                                cY1 = cY + 1000
                            End If
                        ElseIf cbTylebando.SelectedIndex = 0 Or cbTylebando.SelectedIndex = 1 Or cbTylebando.SelectedIndex = 2 Or cbTylebando.SelectedIndex = 3 Or cbTylebando.SelectedIndex = 7 Then
                            cY1 = cY
                            cX1 = cX
                        Else
                            cbHienthiToado.SelectedIndex = 3
                        End If

                        If 0 < cX1 And cX1 < dx Then
                            If 0 < cY1 And cY1 < dy Then
                                o9 = "7"
                            ElseIf dy < cY1 And cY1 < dy * 2 Then
                                o9 = "6"
                            ElseIf 2 * dy < cY1 And cY1 < dy * 3 Then
                                o9 = "5"
                            End If
                        ElseIf dx < cX1 And cX1 < dx * 2 Then
                            If 0 < cY1 And cY1 < dy Then
                                o9 = "8"
                            ElseIf dy < cY1 And cY1 < dy * 2 Then
                                o9 = "9"
                            ElseIf 2 * dy < cY1 And cY1 < dy * 3 Then
                                o9 = "4"
                            End If
                        ElseIf 2 * dx < cX1 And cX1 < dx * 3 Then
                            If 0 < cY1 And cY1 < dy Then
                                o9 = "1"
                            ElseIf dy < cY1 And cY1 < dy * 2 Then
                                o9 = "2"
                            ElseIf 2 * dy < cY1 And cY1 < dy * 3 Then
                                o9 = "3"
                            End If
                        End If
                        If (PosPixel.X).ToString() > 0 Then
                            LbToadoM.Text = XyNhan(xVN2000, 2, 2) & XyNhan(yVN2000, 1, 2) & " " & o9
                        End If
                    ElseIf cbHienthiToado.SelectedIndex = 2 Then
                        LbToadoM.Text = xVN2000.ToString.Substring(0, 9) & ",  " & yVN2000.ToString.Substring(0, 8) ' & ",  " & docaodiem.ToString.Split(".")(0) & "." & docaodiem.ToString.Split(".")(1).Substring(0, 1) '& ";" & mPoint.X.ToString.Substring(0, 9) & "," & mPoint.Y.ToString.Substring(0, 8)
                    ElseIf cbHienthiToado.SelectedIndex = 3 Then
                        Dim xSDO As String = String.Empty, xPHUT1 As String = String.Empty, xPhut2 As String = String.Empty,
xGIAY1 As String = String.Empty, xgiay2 As String = String.Empty, ySDO As String = String.Empty,
                            yPHUT1 As String = String.Empty, yPhut2 As String = String.Empty, yGIAY1 As String = String.Empty, ygiay2 As String = String.Empty
                        xSDO = PosPixel.X.ToString.Split(".")(0)
                        xPHUT1 = ((PosPixel.X - Val(xSDO)) * 60).ToString.Split(".")(0)
                        If xPHUT1.Length = 1 Then xPhut2 = "0" & xPHUT1
                        If xPHUT1.Length = 2 Then xPhut2 = xPHUT1
                        xGIAY1 = (((PosPixel.X - Val(xSDO)) * 60 - Val(xPHUT1)) * 60).ToString.Split(".")(0).ToString
                        If xGIAY1.Length = 1 Then xgiay2 = "0" & xGIAY1
                        If xGIAY1.Length = 2 Then xgiay2 = xGIAY1
                        ySDO = PosPixel.Y.ToString.Split(".")(0)
                        yPHUT1 = ((PosPixel.Y - Val(ySDO)) * 60).ToString.Split(".")(0)
                        If yPHUT1.Length = 1 Then yPhut2 = "0" & yPHUT1
                        If yPHUT1.Length = 2 Then yPhut2 = yPHUT1
                        yGIAY1 = (((PosPixel.Y - Val(ySDO)) * 60 - Val(yPHUT1)) * 60).ToString.Split(".")(0).ToString
                        If yGIAY1.Length = 1 Then ygiay2 = "0" & yGIAY1
                        If yGIAY1.Length = 2 Then ygiay2 = yGIAY1
                        LbToadoM.Text = PosPixel.X.ToString.Substring(0, 8) & ", " & PosPixel.Y.ToString.Substring(0, 7) & " (" & xSDO & "d" & xPhut2 & "'" & xgiay2 & "''" & ", " & ySDO & "d" & yPhut2 & "'" & ygiay2 & ")" ' & "''" & ",  " & docaodiem.ToString.Split(".")(0) & "." & docaodiem.ToString.Split(".")(1).Substring(0, 1)
                    End If
                End If
            Else
                LbToadoM.Text = ""
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub MouseHook1_MouseDown(sender As Object, e As WindowsHookLib.MouseEventArgs) Handles MouseHook1.MouseDown
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                If Me.Bounds.Contains(e.Location) Then
                    If Lenhve = "chonDTnhapnhay" Or Lenhve = "chonDTan" Or Lenhve = "chonMTchuyendong" Or Lenhve = "chonDTchuyendong" Or Lenhve = "chonPhim" Or
                   Lenhve = "amthanh" Or Lenhve = "phimdiahinh" Or Lenhve = "vunghoaluc" Or Lenhve = "XoaGroup2" Or Lenhve = "XoaGrtheoDT" Or Lenhve = "chuyenDTNet" Or
                   Lenhve = "thuoctinh" Or Lenhve = "radaquay" Or Lenhsua = "chonDuongtaoChuoi" Or Lenhve = "chonDTchuyendong" Or
                    Lenhve = "moveGroup" Or Lenhve = "copyGroup" Or Lenhve = "rotateGroup" Or Lenhve = "vungtoduong" Or Lenhve = "duongtovung" Or Lenhve = "catvung" Or Lenhve = "gopvung" Or Lenhve = "giaovung" Or Lenhve = "catduong" Or Lenhve = "noiduong" Or Lenhve = "catvung2" Or Lenhve = "gopvung2" Then PathtoTxt() 'subChuoiGroup()
                End If
            End If

            If e.Button = System.Windows.Forms.MouseButtons.Left Then

                Dim xPixel, yPixel As Double
                xPixel = System.Windows.Forms.Cursor.Position.X
                yPixel = System.Windows.Forms.Cursor.Position.Y
                PosPixel = sgworldMain.Window.PixelToWorld(xPixel, yPixel, WPT_DEFAULT).Position
                mPoint = sgworldMain.Terrain.GetGroundHeightInfo(PosPixel.X, PosPixel.Y, AccuracyLevel.ACCURACY_NORMAL, True).Position

                If Bd3D = True Or mMicrostation = True Then
                    Lenhve2 = "dichuyen"
                End If

                If mNetwork = False Then
                    If Not Lenhve = "" Then
                        If Not Lenhsua = "chonDuongtaoChuoi" And Not Lenhve = "Venhieuco" And Not Lenhve = "XoaGrtheoDT" And Not Lenhve = "muiChuyeu" And Not Lenhve = "muiTCngan" And Not Lenhve = "muithuyeu" And Not Lenhve = "chonDTnhapnhay" And Not Lenhve = "radaquay" And Not Lenhve = "veco" And Not Lenhve = "chonDTan" And Not Lenhve = "chonDTchuyendong" And Not Lenhve = "nDTnhay" And Not Lenhve = "chonMTchuyendong" And Not Lenhve = "XoaGroup2" And Not Lenhve = "moveGroup" And Not Lenhve = "copyGroup" And Not Lenhve = "rotateGroup" And Not Lenhve = "vunghoaluc" And Not Lenhve = "catvung" And Not Lenhve = "catvung2" And Not Lenhve = "chuyenGroup" And Not Lenhve = "chuyenDTNet" And Not Lenhve = "chuyenGroupNet" And Not Lenhve = "gopvung" And Not Lenhve = "giaovung" And Not Lenhve = "catduong" And Not Lenhve = "noiduong" And Not Lenhve = "vungtoduong" And Not Lenhve = "duongtovung" And Not Lenhve = "moveDTtoGr" And
                        Not Lenhve = "thuoctinh" And Not Lenhve = "gopvung2" And Not Lenhve = "phimdiahinh" And Not Lenhve = "NNtructiep" And Not Lenhve = "trinhchieu" And Not Lenhve = "DTdichuyen" And Not Lenhve = "NNtructiep2" And Not Lenhve = "TatDt" And Not Lenhve = "NNtructiep3" And Not Lenhve = "pdf" Then
                            StempLine()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub MouseHook1_MouseUp(sender As Object, e As WindowsHookLib.MouseEventArgs) Handles MouseHook1.MouseUp
        Try
            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                If Lenhve = "chonDTnhapnhay" Or Lenhve = "chonDTan" Or Lenhve = "chonMTchuyendong" Or Lenhve = "chonDTchuyendong" Or Lenhve = "chonPhim" Or Lenhve = "NNtructiep" Or Lenhve = "TatDt" Or
                   Lenhve = "amthanh" Or Lenhve = "phimdiahinh" Or Lenhve = "vunghoaluc" Or Lenhve = "XoaGroup2" Or Lenhve = "XoaGrtheoDT" Or Lenhve = "chuyenDTNet" Or
                   Lenhve = "thuoctinh" Or Lenhve = "radaquay" Or Lenhsua = "chonDuongtaoChuoi" Or Lenhve = "chonPhim" Or Lenhve = "chonDTchuyendong" Or Lenhve = "DTdichuyen" Or
                    Lenhve = "moveGroup" Or Lenhve = "copyGroup" Or Lenhve = "rotateGroup" Or Lenhve = "vungtoduong" Or Lenhve = "duongtovung" Or Lenhve = "catvung" Or Lenhve = "gopvung" Or Lenhve = "giaovung" Or Lenhve = "catduong" Or Lenhve = "noiduong" Or Lenhve = "catvung2" Or Lenhve = "gopvung2" Then MPathTQ()
            End If

            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                If Me.Bounds.Contains(e.Location) Then
                    sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Temp"))
                    soDiem = 0
                    If Lenhve2 = "dichuyen" Then
                        Laytoado()
                    End If
                    If Lenhve = "moveGroup" Then
                        MoveGroupTQ()
                    End If

                    If Lenhve = "copyGroup" Then
                        CopyGroupTQ()
                    End If

                    If Lenhve = "rotateGroup" Then
                        RotateGroupTQ()
                    End If


                    If Lenhve = "XoaGroup2" Or Lenhve = "XoaGrtheoDT" Then SubXoaGroup()
                    If Lenhve = "chuyenDTNet" Or Lenhve = "gopvung2" Or Lenhve = "catvung2" Or Lenhve = "catvung" Or Lenhve = "gopvung" Or Lenhve = "giaovung" Or Lenhve = "catduong" Or Lenhve = "noiduong" Or Lenhve = "duongtovung" Or Lenhve = "vungtoduong" Then
                        SuaVungDuong()
                    End If
                    'Doi tuong chuyen dong
                    If Lenhve = "vunghoaluc" Then VungHoaluc()
                    If Lenhve = "dtChuyendongMH" Or Lenhve = "mohinhnguoidung" Or Lenhve = "1DTchuyendontheoduong" Or Lenhve = "2DTchuyendongngang" Or Lenhve = "2DTchuyendondoc" Or Lenhve = "3DTchuyendonTG" Or Lenhve = "3DTchuyendonTG1" Or Lenhve = "3DTchuyendonNgang" Or Lenhve = "3DTchuyendondoc" Then NhieuMohinh()
                    '  If Lenhve = "dtChuyendongMH" Or Lenhve = "mohinhnguoidung" Then CreateDinamicObject_Mohinh()
                    'Edit Group
                    TyleX = 0
                    TyleY = 0
                    'If Lenhve <> "" Then
                    '    Windows.Forms.Cursor.Position = New System.Drawing.Point(System.Windows.Forms.Cursor.Position.X + 6, System.Windows.Forms.Cursor.Position.Y + 3)
                    'End If
                    If Not Lenhsua = "chonDuongtaoChuoi" And Not Lenhve = "Venhieuco" And Not Lenhve = "XoaGrtheoDT" And Not Lenhve = "muiChuyeu" And Not Lenhve = "muiTCngan" And Not Lenhve = "muithuyeu" And Not Lenhve = "chonDTnhapnhay" And Not Lenhve = "radaquay" And Not Lenhve = "chonDTan" And Not Lenhve = "chonDTchuyendong" And Not Lenhve = "nDTnhay" And Not Lenhve = "chonMTchuyendong" And Not Lenhve = "XoaGroup2" And Not Lenhve = "moveGroup" And Not Lenhve = "copyGroup" And Not Lenhve = "rotateGroup" And Not Lenhve = "vunghoaluc" And Not Lenhve = "catvung" And Not Lenhve = "chuyenGroup" And Not Lenhve = "chuyenDTNet" And Not Lenhve = "chuyenGroupNet" And Not Lenhve = "gopvung" And Not Lenhve = "giaovung" And Not Lenhve = "catduong" And Not Lenhve = "noiduong" And Not Lenhve = "vungtoduong" And Not Lenhve = "duongtovung" And Not Lenhve = "moveDTtoGr" And
                        Not Lenhve = "thuoctinh" And Not Lenhve = "gopvung2" And Not Lenhve = "phimdiahinh" And Not Lenhve = "NNtructiep" And Not Lenhve = "trinhchieu" And Not Lenhve = "DTdichuyen" And Not Lenhve = "NNtructiep2" And Not Lenhve = "TatDt" And Not Lenhve = "NNtructiep3" Then
                        GhiToado()
                    End If

                    If Bd3D = False Then
                        If mMicrostation = False Then
                            BienEmpty()
                        End If
                    End If
                    ScanGroup()
                    sgworldMain.Project.Save()
                    SetMouseHand()

                End If
            End If
        Catch eX As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub MouseHook1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles MouseHook1.MouseClick
        Try
            LenhTD()
            Mausac()

            If e.Button = System.Windows.Forms.MouseButtons.Left Then
                Dim xPixel, yPixel As Double
                xPixel = System.Windows.Forms.Cursor.Position.X
                yPixel = System.Windows.Forms.Cursor.Position.Y
                PosPixel = sgworldMain.Window.PixelToWorld(xPixel, yPixel, WPT_DEFAULT).Position
                mPos = sgworldMain.Terrain.GetGroundHeightInfo(PosPixel.X, PosPixel.Y, AccuracyLevel.ACCURACY_BEST_FROM_MEMORY, True).Position '.ToRelat
                mPointClick = sgworldMain.Terrain.GetGroundHeightInfo(PosPixel.X, PosPixel.Y, AccuracyLevel.ACCURACY_BEST_FROM_MEMORY, True).Position '.ToRelative
                mPointClick.Pitch = 0
                mPointClick.Yaw = 0
                mPointClick.Roll = 0
                mPointClick.Altitude = 0
                mPointClick.AltitudeType = 2
                If Lenhve = "veduongsongsong" Or Lenhve = "KvTrSHHBangMB" Or Lenhve = "Gioituyen" Then ' 
                    CreatePoint(mPoint.X * 360000, mPoint.Y * 360000)
                End If
                If Lenhve = "muitiencongchuyeu" Then
                    If KCDuoiMT <= 0 Then
                        CreatePoint3D()
                        DuoiMT()
                    Else
                        MuitenTQ(GroupBac2Main)
                    End If
                End If
                If Lenhve = "muitiencongCYngan" Or Lenhve = "muiteincongthuyeu" Or Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then MuitenTQ(GroupBac2Main) 'Or Lenhve = "hangraobungnhung"() 'Or Lenhve = "GioituyenHrCD" Or Lenhve = "GioituyenHrKGCC" 
            End If

            If e.Button = System.Windows.Forms.MouseButtons.Right Then
                sgworldMain.Project.Save()
                If Lenhve = "tuyenxamnhap" Then TuyenXamnhap()
                If Lenhve = "TauBPapgiai" Or Lenhve = "TauBPkiemtra" Or Lenhve = "TauBPbatgiu" Then KiemtraBatgiuApgiai()
                If Lenhve = "nganchanBP" Or Lenhve = "phuckichBP" Or Lenhve = "dayNquayve" Or Lenhve = "nganchandamdong" Then NganchanPhuckich()
                If Lenhve = "huongxamnhapCY" Or Lenhve = "huongxamnhapTY" Then HuongXamnhap()
                If Lenhve = "canoBP" Then CanoBP()
                'Tien ich
                If Lenhve = "taophim" Then VideoOnTerrain()
                If Lenhve = "dientichDT" Then TinhDientich()
                If Lenhve = "khoangcach2d" Then KC2diem()
                If Lenhve = "Chieudaiduonghanhquan" Then ChieudaiDT()
                'Duong, vung, chu, image
                If Lenhve = "kvTochucDoihinh" Or Lenhve = "KvTapket" Or Lenhve = "KvDoiTu" Or Lenhve = "KvCodong" Or Lenhve = "KvTamdung" Or Lenhve = "hinhchunhat" Or Lenhve = "MBchupanhTS" Or Lenhve = "kvTKHHdukien" Or Lenhve = "kvkhoinguytrang" Then HCN() ' Hinhchunhat()
                If Lenhve = "veduongsongsong" Or Lenhve = "KvTrSHHBangMB" Then DuongSS()
                If Lenhve = "Doituongchu" Then DTChu()

                If Lenhve = "giaothonghao" Or Lenhve = "Doituongduong" Or Lenhve = "Gioituyen" Or Lenhve = "Giaothonghaoconap" Or Lenhve = "DDgnguytrangLuoi" Or Lenhve = "DDgdichphahoai" Or Lenhve = "DDbotrimin" Or
                    Lenhve = "DDgdichphahoaiMB" Or Lenhve = "DDGngapnuoc" Or Lenhve = "DDgVongtranh" Or Lenhve = "DDgCoDichmatdat" Or Lenhve = "DgVongtranh" Or Lenhve = "DgTieudoc" Or Lenhve = "cuma" Or
                    Lenhve = "Phaduong" Or Lenhve = "Duongcothhacanh" Or Lenhve = "LLTructiep" Or Lenhve = "LLVuotcap" Or Lenhve = "LLHiepdong" Or Lenhve = "LLThuongxuyen" Or Lenhve = "LLKhongthuongxuyen" Or Lenhve = "LLthuongxuyen2" Or
                    Lenhve = "capdachien" Or Lenhve = "capquang" Or Lenhve = "capdongtruc" Or Lenhve = "capnguondien" Or Lenhve = "capliendai" Or Lenhve = "lienlacVT" Or Lenhve = "lienlacViba" Then CacKieuDuong()

                If Lenhve = "chenanh" Then Chenanh()
                'Hai quan'
                If Lenhve = "kvXuaduoi" Then Xuaduoi()
                If Lenhve = "TNchongTN" Then TNchongTN()
                If Lenhve = "tnKTV" Or Lenhve = "tnKTVkoRo" Then TNkinhTV()
                If Lenhve = "phuongvi" Then VePhuongvi()
                If Lenhve = "xuongkhonoi" Then Xuongkhonoi()
                If Lenhve = "thuyloiAngten" Then ThuyloiAngten()
                If Lenhve = "thuyloineo" Or Lenhve = "thuyloiday" Then MinNeoDay()
                If Lenhve = "thuyloitroi" Then Thuyloitroi()
                If Lenhve = "TauDanhcaNN" Or Lenhve = "TauDanhcaVT" Then TauDanhcaVutrang()
                If Lenhve = "TauDanhcaDS" Then TauDanhcaDansu()
                If Lenhve = "xuongcheotay" Then Xuongcheotay()
                If Lenhve = "canoHQ" Or Lenhve = "Canotrinhsat" Or Lenhve = "canoCB" Or Lenhve = "canoBMKT" Or Lenhve = "canoDS" Then CanoHQ()
                If Lenhve = "vantaitauthuyen" Or Lenhve = "TauhodauQS" Or Lenhve = "TauhodauDS" Or Lenhve = "TauhoNuoc" Or Lenhve = "TauBanhvien" Or Lenhve = "TauQuany" Or Lenhve = "TauVTdansu" Or Lenhve = "TauVTquansu" Or Lenhve = "TauVTnuocngoai" Then TauVT()
                If Lenhve = "tausanbay" Or Lenhve = "taukhutruc" Or Lenhve = "tautuanduonghangnang" Or Lenhve = "tautuanduonghangnhe" Or Lenhve = "tausanbayChongngam" Or Lenhve = "tauhove" Or Lenhve = "tautenluanho" Or Lenhve = "tauphaonho" Or Lenhve = "tauphaolon" Or Lenhve = "tautenluanho" Or Lenhve = "tauten4Ong" Or Lenhve = "tauten2Ong" Or Lenhve = "tautuantieu" Or Lenhve = "TauTuanduongchongtaungam" Or
               Lenhve = "tauChongngam" Or Lenhve = "tauTuantieuChongngam" Or Lenhve = "tauxuongdobo" Or Lenhve = "tauPhongloinho" Or Lenhve = "tauPhongloilon" Or Lenhve = "taulaikeo" Or Lenhve = "tauhuanluyen" Or Lenhve = "tautieutu" Or Lenhve = "tauthaloi" Or Lenhve = "tauthaluoi" Or Lenhve = "taupharaoloi" Or Lenhve = "tauquetNoi" Or Lenhve = "taudoboKCH" Or Lenhve = "taudoboNHO" Or Lenhve = "taudoboVUA" Or Lenhve = "taudoboLon" Or
               Lenhve = "taudemkhongkhi" Or Lenhve = "TNgam500" Or Lenhve = "TNgam1000" Or Lenhve = "TNgam5000" Or Lenhve = "TNgamNT1000" Or Lenhve = "TNgamNT3000" Or Lenhve = "TNgamNT5000" Or Lenhve = "tauphongloicanhngam" Or Lenhve = "tauTLHatnhan" Or Lenhve = "tautuantieuTS" Or Lenhve = "tauMtieu" Then TauHaiquan()
                'Khong quan
                If Lenhve = "HuongTcKQ" Then HuongTCKQuan()
                If Lenhve = "kvtrucban" Then KhuvucTrucban()
                If Lenhve = "maybaychivien" Or Lenhve = "tauBPtuantra" Or Lenhve = "maybayhoatdong" Or Lenhve = "toanTSsucsao" Or Lenhve = "toTSsucsao" Or Lenhve = "tuantraBP" Or Lenhve = "toTSDPsucsao" Or Lenhve = "KvhoatdongMBTcdt" Or Lenhve = "KvNhieutieucuc" Or Lenhve = "trinhsatKGM" Then KvMB()
                If Lenhve = "kvgiaochien" Then KhuvucGiaochien() '
                If Lenhve = "HuongTCChuyeuKQchendich" Or Lenhve = "HuongTCThuyeuKQchendich" Or Lenhve = "HuongTCChuyeuKQchienthuat" Or Lenhve = "HuongTCThuyeuKQchienthuat" Or Lenhve = "khongquandanhbien" Or Lenhve = "danhhuongchuyeuHQ" Or Lenhve = "danhhuongthuyeuHQ" Or Lenhve = "tuyenPHkoLTnho" Or Lenhve = "tuyenPHkoLTlon" Or Lenhve = "tuyenPHLTnho" Or Lenhve = "tuyenPHLTLon" Or Lenhve = "HQhanhquan" Then TcKQ_HQ() 'HuongTCThuyeuKQchienthuat
                If Lenhve = "doboduongkhong" Or Lenhve = "doboduongkhongTrT" Or Lenhve = "Tieptebangdu" Then Doboduongkhong()
                If Lenhve = "KvBanDoclapDaidoi" Or Lenhve = "KvBandoclaptieudoan" Or Lenhve = "KvBanTTrDaidoi" Or Lenhve = "KvBanTTrTieudoan" Then HoalucKQ()
                'Hoa hoc
                If Lenhve = "kvtsmatdat" Or Lenhve = "kvtstrenkhong" Then KVTSmatdat()
                If Lenhve = "vetNXdudoan" Then VetNXDudoan()
                If Lenhve = "vetNXthucte" Then VetNXThucte()
                If Lenhve = "KvBaoloanVTr" Or Lenhve = "KvDukienBLkhongVTr" Or Lenhve = "Matcu" Or Lenhve = "KvCanxoadauvet" Or Lenhve = "danhcatgiaothong" Or Lenhve = "KVgayroi" Or Lenhve = "KvMTkoDemat" Or Lenhve = "kvvksinhhoc" Or Lenhve = "ellipse" Or Lenhve = "KvCoBLchongdoi" Or Lenhve = "muctieuphaibaove" Or 'muctieuphaibaove
                  Lenhve = "MatcuBLLD" Or Lenhve = "KvBLHH" Or Lenhve = "KvCanxoadauvet" Or Lenhve = "KvBLLD" Or Lenhve = "kvnganchanChotgiu" Or Lenhve = "Bieutinh" Or Lenhve = "KvBLHH" Or Lenhve = "khuvucBLTieutay" Or Lenhve = "kvcophandong" Or Lenhve = "TrTiepnhanQNDB" Or Lenhve = "TrtiepnhanPTKT" Or Lenhve = "TrNhan_GiaoDB" Or Lenhve = "TrTbiHH" Or Lenhve = "KnNguytrangcongTrSrada" Or Lenhve = "KvTuantieu" Or Lenhve = "kvVaybat" Or Lenhve = "Tauchuachay" Then Ellipse()   'DTEllipe() '

                If Lenhve = "hamchong" Or Lenhve = "baiminHonHop" Or Lenhve = "baiminBB" Or Lenhve = "baiminchongtangHTD" Or Lenhve = "baiminhoahoc" Or Lenhve = "baiminlua" Or Lenhve = "baiminhoahocNo" Or Lenhve = "baicocchongtang" Or Lenhve = "baiminchongtau" Or Lenhve = "hamchong" Or Lenhve = "tamnguytrang" Or
                  Lenhve = "luoinguytrang" Or Lenhve = "MuctieuHH" Or Lenhve = "MTBLLDDachiem" Or Lenhve = "MuctieuChatno" Or Lenhve = "NoilotLL" Or Lenhve = "MTBLLDDukienchiem" Or Lenhve = "CongNongLamtruongCD" Or Lenhve = "khusotanCQXN" Or Lenhve = "khusotannhandan" Or Lenhve = "KhusotanNDBaoLut" Or Lenhve = "KvGiaututhi" Or Lenhve = "MuctieuBLLDCtr" Or Lenhve = "Giamgiucontin" Or Lenhve = "MtieuA2" Or Lenhve = "KvTTrHoalucphandoi" Or Lenhve = "tramxulyTNn" Then DTRectangle()

                If Lenhve = "hinhtron" Or Lenhve = "tamnhiemxa" Or Lenhve = "kvvkhatnhanno" Or Lenhve = "caulacboPD" Or Lenhve = "chuongngaivat" Or Lenhve = "ovatcan" Or Lenhve = "TrTTrQuanDB" Or Lenhve = "choneotau" Or Lenhve = "TrTTrPTKT" Or Lenhve = "TrCMDBtinh" Or Lenhve = "kvttllDongvien" Or Lenhve = "DbanMtuy" Or Lenhve = "tocodongdiettang" Or Lenhve = "TrandiaBtcdt" Or Lenhve = "TrandiaCtcdt" Or Lenhve = "SungBBbanMB" Or Lenhve = "Tuyentucanhgioi" Or
                  Lenhve = "GioihanvungTrSDientuSN" Or Lenhve = "GioihanvungTrSdienttuSCNVHF" Or Lenhve = "GioihanvungTrSdientuSCNUHF" Or Lenhve = "GioihanvungTrSDTsieucaotan" Or Lenhve = "AntoanHatnhan" Or Lenhve = "GioiHanHatnhan" Or Lenhve = "TuyengiaoNvu" Or Lenhve = "BkinhTu" Or Lenhve = "BkinhMB" Or Lenhve = "baihacanh" Or Lenhve = "toTrSDieutra" Or Lenhve = "toTSDQTV" Or Lenhve = "ToSCCodong" Or Lenhve = "GihanVungcheap" Or Lenhve = "hamphao" Or Lenhve = "DbanMtuy" Or Lenhve = "Diaban" Or Lenhve = "hamVK" Or
                  Lenhve = "sanbaytrenbien" Or Lenhve = "sanbaygia" Or Lenhve = "sanbaydachien" Or Lenhve = "sanbayvuotcap" Or Lenhve = "sanbaycap1" Or Lenhve = "sanbaycap2" Or Lenhve = "sanbaycap3" Or Lenhve = "dacnhiemBP" Or Lenhve = "todaccong" Or Lenhve = "tohoahoc" Or Lenhve = "tocongtacBP" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTrsTrongdich" Or Lenhve = "toTrSHHCodong" Or Lenhve = "coilui" Or Lenhve = "dontho" Or Lenhve = "donthuy" Or Lenhve = "HiepdongKQPK" Then DT_Circle()

                If Lenhve = "Phacau" Or Lenhve = "Caubicuontroi" Or Lenhve = "hanhlangbay" Or Lenhve = "caucogioi" Or Lenhve = "CaugoCaubetong" Or Lenhve = "Causat" Or Lenhve = "Caungam" Or Lenhve = "Cautreo" Or Lenhve = "Cautre" Or Lenhve = "CauPMP" Or Lenhve = "Caubidanhpha" Or Lenhve = "cuamoBB" Or Lenhve = "cuamoXT" Or Lenhve = "TuyenchuyentiepChuy" Or Lenhve = "Moibayhongngoai" Or Lenhve = "diadao" Or Lenhve = "Luongraquet" Or
                  Lenhve = "BenloiBB" Or Lenhve = "BenloiOto" Or Lenhve = "BenloiXT" Or Lenhve = "BenvuotBangthuyen" Or Lenhve = "BenvuotsongPha" Or Lenhve = "BenPhatuhanh" Or Lenhve = "BenvuotsongnhieuPT" Or Lenhve = "Daihiepdong" Or Lenhve = "tuyenbancodinh" Or Lenhve = "tuyenthoay" Or Lenhve = "tuyendanhchan" Or Lenhve = "TuyenMBcatcanh" Or Lenhve = "Manchanchongrada" Or Lenhve = "Dexungyeu" Or Lenhve = "Dengapnuoc" Or Lenhve = "Devo" Or
                  Lenhve = "tuyenVCkhongno" Or Lenhve = "tuyenVChonhop" Or Lenhve = "tuyenRMhonhop" Or Lenhve = "tuyenRMbangTrT" Or Lenhve = "kvbaidobo" Or Lenhve = "tuyenTochucDoihinh" Or Lenhve = "tuyenTKdobo" Or Lenhve = "tuyenXPdobo" Or Lenhve = "tuyenPTdobo" Or Lenhve = "tuyenkhoinguytrang" Or Lenhve = "DiemchuanBancanPK" Or Lenhve = "Caugiabangmatphanxa" Or Lenhve = "hambetong" Or Lenhve = "KVPhanlucham" Or Lenhve = "tuyenthuyloineo" Or Lenhve = "tuyenthuyloiday" Then CauTQ()

                If Lenhve = "kvsucoHH" Then KVsucoHH()
                If Lenhve = "kvTKHHxuly" Then KVTapkichHHdaXL()
                If Lenhve = "kvTKHHbangCoi" Then KVTapkichHHbangCoi()
                If Lenhve = "kvTKHHbangTL" Then KVTapkichHHbangTL()
                If Lenhve = "kvTKHHbangMB" Then KVTapkichHHbangMB()
                If Lenhve = "kvTKHHbangphao" Then KVTapkichHHbangPhao()
                'Cong binh
                If Lenhve = "ominchongtang" Then OminChongtang()
                If Lenhve = "minbobinh" Then MinBobinh()
                If Lenhve = "minchongtang" Then MinChongtang()
                If Lenhve = "mindinhhuong" Then Mindinhhuong()
                If Lenhve = "Xeloinuocbanhxich" Then Xeloinuocbanhxich()
                If Lenhve = "Phatuhanh" Then Phatuhanh()
                If Lenhve = "HrNganthuyloi" Or Lenhve = "nhiemvutruocmat" Or Lenhve = "nhiemvutieptheo" Then HraoThuyloi()
                ''Tac chien dien tu
                If Lenhve = "xuongBBDL10" Or Lenhve = "XuongDemkhi" Or Lenhve = "DCTCbangTauNgam" Or Lenhve = "DCTCbangTauDS" Or Lenhve = "DCTCbangTauNN" Then DaccongTC()
                If Lenhve = "muidaccongnuoc" Or Lenhve = "muidaccong" Or Lenhve = "muidaccongTC" Or Lenhve = "muidaccongcodong" Then MuiDC()
                If Lenhve = "doiTShonhop" Or Lenhve = "luonsau" Or Lenhve = "doidaccongTC" Or Lenhve = "DChoatrang" Or Lenhve = "doidaccongnuoc" Or Lenhve = "doidaccong" Or Lenhve = "doihoahoc" Or Lenhve = "doicongtacBP" Or Lenhve = "doiKPHQ" Or Lenhve = "doicongbinh" Or Lenhve = "emsan" Or Lenhve = "coiDKZlui" Or Lenhve = "DoiCtCoso" Or Lenhve = "DQTVcodong" Or Lenhve = "toanTSDN" Or Lenhve = "KhacphucHauquaBLLD" Then DoiDC()
                'Trinh sat
                If Lenhve = "TSTKbatTB" Or Lenhve = "TSPKbatTB" Or Lenhve = "TSbatcocTB" Then TrSbatTB()
                'Ten lua
                If Lenhve = "tenluaChongRada" Then TenluachongRADA()
                If Lenhve = "tenluaCCtuMB" Then TenluaCCtuMB()
                If Lenhve = "TLNguloiTudanNBC" Then TLNguloiTudanNBC()
                If Lenhve = "TLNguloiTudanT" Then TLNguloiTudan()
                If Lenhve = "TLChongngamNBC" Then TLChongngamNBC()
                If Lenhve = "tenluaB72xe" Then B72xe()
                If Lenhve = "tenluacocanhhatnhan" Then Tenluacocanhhatnhan()
                If Lenhve = "tenluacocanhtamxa2Ranh" Or Lenhve = "tenluacocanhtamxa" Or Lenhve = "tenluacocanhtamtrung2Ranh" Or Lenhve = "tenluacocanhtamtrung" Or Lenhve = "tenluacocanhtamgan2Ranh" Or Lenhve = "tenluacocanhtamgan" Then TenluaCocanh()
                'Phao binh
                If Lenhve = "hoalucV" Or Lenhve = "hoalucCN" Then HoalucPB(mPointClick)
                If Lenhve = "TSTiengdong" Or Lenhve = "BanChsangChihuongTC" Or Lenhve = "BanCSphanchiaGioituyen" Or Lenhve = "tuyenbanCS" Or Lenhve = "GiHanNvuTCDT" Then BanChieusang()
                If Lenhve = "Coi160" Or Lenhve = "Coi82" Or Lenhve = "Coi120" Or Lenhve = "Phaophanluccotrung" Or Lenhve = "PhaophanlucKyhieuchung" Or Lenhve = "Phaophanluccolon" Or
                   Lenhve = "mohinhPB" Or Lenhve = "TaungamPB" Or Lenhve = "tenluaB72" Or Lenhve = "tenluaPhagot" Or Lenhve = "Phaobobien" Or Lenhve = "PhaoMDbanbien" Or Lenhve = "KvVatcan" Then CreateModelPBMoi()
                'Tang, Thiet giap"
                If Lenhve = "BanchanDidong" Or Lenhve = "DaiBanchinh" Or Lenhve = "DaiTrSPB" Or Lenhve = "OneXTTc" Or Lenhve = "XTPhuckich" Or Lenhve = "XTBantructiep" Then XTtiencong()
                If Lenhve = "Xeraimin" Or Lenhve = "XeBAT" Or Lenhve = "thietgiaploinuoc" Or Lenhve = "thietgiap" Or Lenhve = "toQStrenTG" Or Lenhve = "PhaoPKtuhanhR" Or Lenhve = "PhaoPKtuhanh" Or Lenhve = "xeTScanhgioi" Or Lenhve = "xechobobinh" Or Lenhve = "xeTSBMP" Then Thietgiap()
                If Lenhve = "Tanguidat" Then Tanguidat()
                If Lenhve = "xetangquetmin" Then Tangquetmin()
                If Lenhve = "xetangloinuoc" Or Lenhve = "xeTSPT76" Then Tangloinuoc()
                If Lenhve = "xetangromooc" Or Lenhve = "tangcancau" Or Lenhve = "TangchoBB" Or Lenhve = "TangHong" Or Lenhve = "TangbiTieudiet" Or Lenhve = "tangsalay" Or Lenhve = "tangmaccan" Or Lenhve = "ThapphaoXT" Or Lenhve = "xetangbaccau" Or Lenhve = "xetanghangnhe" Or Lenhve = "xetanghangnang" Or Lenhve = "xetanghangtrung" Or Lenhve = "toQStrenXT" Then Xetang()
                'Bo binh
                If Lenhve = "hamNBC" Then HamNBC()
                If Lenhve = "HamdachienchongNBC" Then HamdachienchongNBC()
                If Lenhve = "HamkiencochongNBC" Then HamkiencochongNBC()
                If Lenhve = "hamconap" Then Hamconap()
                If Lenhve = "hamkhongconap" Then Hamkhongconap()
                If Lenhve = "congsuhoakhikhongnap" Then Congsuhoakhikhongnap()
                If Lenhve = "congsuhoakhiconap" Then Congsuhoakhiconap()
                If Lenhve = "coi60" Then Coi60()
                If Lenhve = "b41" Then B41()
                If Lenhve = "b40" Then B40()
                If Lenhve = "phongluu" Then Phongluu()
                If Lenhve = "dailien" Then Dailien()
                If Lenhve = "trunglien" Then Trunglien()
                If Lenhve = "DHPNBB" Or Lenhve = "KvPNthenchot" Or Lenhve = "DHPNBBXT" Or Lenhve = "XTchuyenPngu" Or Lenhve = "XTPngutrongTD" Then DoihinhPN()
                If Lenhve = "congsu" Or Lenhve = "DiemtuaTrungdoi" Or Lenhve = "DiemtuaDaidoi" Then DiemtuaTQ()
                If Lenhve = "Muithocsau" Then Muithocsau()
                'Hanh dong tac chien
                If Lenhve = "DoihinhBbXPquaCuamo" Then DoihinhBbXPquaCuamo()
                If Lenhve = "PNtiepxuc" Then PNtiepxuc()
                If Lenhve = "muitiencongkep" Then Muitiencongkep()
                If Lenhve = "trandiachongtang" Then Trandiachongtang()
                If Lenhve = "tiencongquaylai" Then Tiencong_Quaylai()
                If Lenhve = "vaylan" Then Vaylan()
                If Lenhve = "Donlong" Then Donlong()
                'If Lenhve = "tocodongdiettang" Then Tocodongdiettang()
                If Lenhve = "Tiencong_VeXP" Then Tiencong_VeXP()
                If Lenhve = "Tiencong_Dung" Then Tiencong_Dung()
                If Lenhve = "bephongno" Then Mindinhhuong()
                If Lenhve = "tapkich" Then Tapkich()
                If Lenhve = "phuckich" Or Lenhve = "TsatBangChiendau" Then Phuckich()
                If Lenhve = "sucsaotruylung" Or Lenhve = "quanlon" Or Lenhve = "QuanlonDP" Then Sucsaotruylung()
                ' If Lenhve = "quanlon" Then Quanlon()
                If Lenhve = "vayep" Or Lenhve = "DhinhBaovaydich" Then DHBaovay()
                If Lenhve = "chotchan" Then Chotchan()
                If Lenhve = "TuyenTrKTcBobinh" Or Lenhve = "TuyenTrKTcBobinhXetang" Or Lenhve = "TuyenTrKTcBobinhXetang" Or Lenhve = "TuyenTrKTcdBBXT" Or Lenhve = "TuyenTrKTcBBtruocXT" Or Lenhve = "TuyenTrKTcXTtruocBB" Or Lenhve = "DoihinhBBTamdung" Or Lenhve = "TuyenbanXT" Or Lenhve = "XTTiencong" Then DoihinhTrkhaiTC()
                If Lenhve = "HQbangMB" Then HQMB()
                If Lenhve = "HQbangTau" Then HQTau()
                If Lenhve = "HQbangxelua" Then HQXelua()
                If Lenhve = "HQbangoto" Then HQOto()
                If Lenhve = "hanhquanbo" Then HQbo()
                'Luc luong vu trang dia phuong
                If Lenhve = "hamngamDP" Then HamngamDP()
                If Lenhve = "hamngamDPNBC" Then HamngamDPNBC()
                If Lenhve = "hambimat" Or Lenhve = "hambimatNBC" Then HamBimatNBC()
                If Lenhve = "banphongno" Then Banphongno()
                If Lenhve = "khudancumoi" Or Lenhve = "baiminHQ" Or Lenhve = "KvBaoveMtieu" Or Lenhve = "KvCamban" Or Lenhve = "Doituongvung" Or Lenhve = "KvXamcu" Or Lenhve = "CumANQP" Or Lenhve = "Langchiendau" Or Lenhve = "Cumlangchiendau" Then KhudancuMOI()
                If Lenhve = "KVdongquan" Or Lenhve = "khuvucphongthutrongdiem" Or Lenhve = "khuvucphaigiu" Or Lenhve = "khuvucphongthuthenchot" Or Lenhve = "KVTrinhsatSN" Or Lenhve = "KVTrinhsatSCN" Or Lenhve = "KvTRanhchap" Or Lenhve = "KvXamcanh" Or Lenhve = "KvBdCongnghe" Or
                   Lenhve = "cancuhauphuong" Or Lenhve = "cancuchiendau" Or Lenhve = "KvDichmoiden" Or Lenhve = "MTCanbaove" Or Lenhve = "KvLanchiem" Or Lenhve = "CCCDBP" Or Lenhve = "KvHoaluc" Or Lenhve = "KvTieutay" Or Lenhve = "KVbitran" Or Lenhve = "KvKho" Or Lenhve = "KvKT" Or
                   Lenhve = "KVNgapnuoc" Or Lenhve = "KVCatvui" Or Lenhve = "KvKhotrandau" Or Lenhve = "KvTautrandau" Or Lenhve = "KvGkhoantrandau" Or Lenhve = "KvCamTbVTD" Or Lenhve = "KvBvMtieuBangGnhieungoinoVT" Or Lenhve = "KvBiphahuyHN" Or Lenhve = "CumCN" Then KvPhongthu()
                ''Mo hinh
                If Lenhve = "Venhieuco" Then VenhieuSCH()
                If Lenhve = "mohinh" Then CreateModel()
                If Lenhve = "veco" Or Lenhve = "Taungam" Then CrFlage()
                'Tap tin
                If Lenhve = "vekhung" Then Khung()
                'If Lenhve = "PDF" Then TrinhbayVK()
                ' If Lenhve = "ConvertSHP" Then Shape()
                If Lenhve = "ChieusauTS" Then ChieusauTrS()

                ' End If
                If Lenhve = "muitiencongchuyeu" Or Lenhve = "muiteincongthuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then
                    isFinishedChuYeu = True
                    If Lenhve = "hangraobungnhung" Then
                        loaiKH = "2140050"
                        LineDTDuong()
                        FDuongList(LiPtHangrao(ArrayPoint3D(), Tyle * 0.0008), 4294967295, "", 0, 0, mau, -2, True, 4, Tyle * 160, 2)
                        SLenhve3DMs()
                    Else
                        CreateArrowFor3D()
                    End If
                    PllVtNum = 0
                    ReDim PllPts(0 To 0)
                    ReDim PllVts(0 To 0)
                    cPlg2 = Nothing
                    cPlg1 = Nothing
                End If

                SetMouseHand()
            End If

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Sub BienEmpty()
        Try
            'If Lenhve = "vunghoaluc" Then
            '    sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & Giaidoan & "\" & sgworldMain.ProjectTree.GetItemName(GroupBac2Main) & "\" & "temp"))
            'ElseIf Lenhve = "hangraobungnhung" Then
            '    sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & Giaidoan & "\" & sgworldMain.ProjectTree.GetItemName(GroupBac2Main) & "\" & sgworldMain.ProjectTree.GetItemName(GroupBac2Main) & "2"))
            'End If
            Lenhve = ""
            cPlg1 = Nothing
            cPlg2 = Nothing
            mTempLine = False
            Phuongvi = 0
            textKH = ""
            loaiKH = ""
            fileImage = ""
            fileModel = ""
            TxtTenKH.Text = ""
            TxtGhichuKH.Text = ""
            txtKHThuongdung.Text = ""
            txtGroup.Text = ""
            txtNnTrt.Text = ""
            tenMayNet = ""
            mota = ""
            Lenhsua = ""

            GiaidoanNet = ""
            Giaidoan = ""
            SetMouseHand()
            PllVtNum = 0
            ReDim PllVts(0 To 0)
            ChuGhichu = False
            fLabelStyleMain.LockMode = LabelLockMode.LM_DECAL
            TDMuiten = ""
            mNetwork = False
            mLineArray.Clear()
            ReDim PllVts(0 To 0)
            mRegionArray.Clear()
            mLabelArray.Clear()
            mMotionModelArray.Clear()
            mModelArray.Clear()
            mLineNoiArray.Clear()
            KCDuoiMT = 0
            SSaveFly()
            ChebTheoNhom.Checked = False
            chebTheoNhomKHTD.Checked = False
            mPoint = Nothing
            mPos = Nothing
            tenMayNet = ""
            GiaidoanNet = ""
            cbTenluahaiquan.SelectedIndex = 0
            If Lenhve = "vunghoaluc" Then
                sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & Giaidoan & "\" & sgworldMain.ProjectTree.GetItemName(GroupBac2Main) & "\" & "temp"))
            ElseIf Lenhve = "hangraobungnhung" Then
                sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & Giaidoan & "\" & sgworldMain.ProjectTree.GetItemName(GroupBac2Main) & "\" & sgworldMain.ProjectTree.GetItemName(GroupBac2Main) & "2"))
            End If
            sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Temp"))
            sgworldMain.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT, "", True)
        Catch ex As Exception
            Exit Try
        End Try
        AxTE3DWindow1.Focus()

        If panelKHthuongdung.Visible = True Then
            txtKHThuongdung.Focus()
        Else
            TxtTenKH.Focus()
        End If
    End Sub


#Region "...Tinh chuyen Toa do VN2000"
    Dim x0 As Double = 0
    Dim y0 As Double = 0
    Public Sub SVn2000(ccPoint As IPosition71)
        Dim mmMuichieu As Integer = 0
        Try
            ReDim Preserve PllPts(0 To PllVtNum)
            P.X = ccPoint.X '* Math.PI / 180.0
            P.Y = ccPoint.Y '* Math.PI / 180.0
            P.Z = Val(ccPoint.ToAbsolute.ToString.Substring(21, 6))
            PllPts(PllVtNum) = P
            If cbTylebando.SelectedIndex = 0 Then
                mmMuichieu = 3
            ElseIf cbTylebando.SelectedIndex = 1 Or cbTylebando.SelectedIndex = 2 Or cbTylebando.SelectedIndex = 3 Then
                mmMuichieu = 6
            End If
            If 102.0 < P.X And P.X < 108.0 Then KTTU = 105.0
            If 108.0 <= P.X And P.X < 118.0 Then KTTU = 111.0
            If (P.X).ToString() < 0 Then
                '-1.41371669411541 Tọa độ -81 của Cuba chuyển thành radian
                ConvertBLtoXY(P.Y * Math.PI / 180.0, P.X * Math.PI / 180.0, -1.41371669411541, 6)
            Else
                Chuyendoi_BLHWGS84_to_XYZVN2000(P.Y * Math.PI / 180.0, P.X * Math.PI / 180.0, P.Z, xVN2000, yVN2000, hVN2000, KTTU, mmMuichieu)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function Vn2000() As List(Of Double)
        Try
            Dim tdVn2000 As New List(Of Double)
            ReDim Preserve PllPts(0 To PllVtNum)
            P.X = xWGS84 '* Math.PI / 180.0
            P.Y = yWGS84 '* Math.PI / 180.0
            P.Z = 0
            PllPts(PllVtNum) = P
            Chuyendoi_BLHWGS84_to_XYZVN2000(P.Y * Math.PI / 180.0, P.X * Math.PI / 180.0, P.Z, xVN2000, yVN2000, hVN2000, KTTU, mMuichieu)
            tdVn2000.Add(yVN2000)
            tdVn2000.Add(xVN2000)
            tdVn2000.Add(hVN2000)
            Vn2000 = tdVn2000
        Catch
        End Try
    End Function

    Function Vn200WGS84(XVn As Double, YVn As Double, KTT As Double, Muichieu As Double, Goc As Double, CaoCamera As Double) As IPosition71
        Try
            Chuyendoi_XYZVN2000_to_BLHWGS84(XVn, YVn, 0, B84, L84, H84, KTTU, 6)
            ToaXCT = L84
            ToaYCT = B84
            Dim Pto As IPosition71 = sgworldMain.Creator.CreatePosition(L84, B84, 0, 2, 0, Goc, 0, CaoCamera)
            'sgworldMain.Creator.CreateLabel(Pto, "K", "", Nothing, "", "K")
            sgworldMain.Navigate.FlyTo(Pto, AC_FLYTO)
            Vn200WGS84 = Pto
        Catch ex As Exception
        End Try
    End Function

    Private Sub TimWGS84()
        Dim Pto As IPosition71 = Nothing
        If txtKinhtuyentruc.Text = "" And rdKhailuoc.Checked = True Then
            MsgBox("Hãy nhập kinh tuyến trục !")
            Exit Sub
        Else
            Try
                If rdKhailuoc.Checked = True And chebVeKH.Checked = False Then
                    Dim XVn As Double = 0, YVn As Double = 0
                    If Bd3D = False Then
                        XVn = System.Convert.ToDouble(txtToado.Text.Substring(0, 2))
                    Else
                        XVn = System.Convert.ToDouble(txtToado.Text.Substring(0, 2))
                    End If
                    YVn = System.Convert.ToDouble(txtToado.Text.Substring(2, 2))
                    Chuyendoi_XYZVN2000_to_BLHWGS84(XVn, YVn, 0, B84, L84, H84, Val(txtKinhtuyentruc.Text.Split(",")(0)), Val(txtKinhtuyentruc.Text.Split(",")(1)))
                    Pto = sgworldMain.Creator.CreatePosition(L84, B84, 0, 2, 0, -60, 0, 10000)
                End If
                If rdDialy.Checked = True Then
                    txtKinhtuyentruc.Text = ""
                    Dim Xdo As Double = Val(txtToado.Text.Split(";")(0).Split(",")(0))
                    Dim Ydo As Double = Val(txtToado.Text.Split(";")(1).Split(",")(0))
                    Dim Xphut As Double = Val(txtToado.Text.Split(";")(0).Split(",")(1)) / 60
                    Dim Yphut As Double = Val(txtToado.Text.Split(";")(1).Split(",")(1)) / 60
                    Dim Xgiay As Double = Val(txtToado.Text.Split(";")(0).Split(",")(2)) / 3600
                    Dim Ygiay As Double = Val(txtToado.Text.Split(";")(1).Split(",")(2)) / 3600
                    Pto = sgworldMain.Creator.CreatePosition(Xdo + Xphut + Xgiay, Ydo + Yphut + Ygiay, 0, 2, 0, -60, 0, 0)
                    Pto.Distance = 5000
                    'sgworldMain.Navigate.FlyTo(Pto, AC_FLYTO)
                End If
                sgworldMain.Navigate.FlyTo(Pto, AC_FLYTO)
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub CbMuiChieu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMuiChieu.SelectedIndexChanged
        Try
            Select Case cbMuiChieu.SelectedIndex
                Case 1
                    KTTU = 99.0
                    mMuichieu = 3
                Case 2
                    KTTU = 102.0
                    mMuichieu = 3
                Case 3
                    KTTU = 105.0
                    mMuichieu = 3
                Case 4
                    KTTU = 108.0
                    mMuichieu = 3
                Case 5
                    KTTU = 111.0
                    mMuichieu = 3
                Case 6
                    KTTU = 99.0
                    mMuichieu = 6
                Case 7
                    KTTU = 105.0
                    mMuichieu = 6
                Case 8
                    KTTU = 111.0
                    mMuichieu = 6
            End Select
        Catch
        End Try
    End Sub

#End Region

    Public Sub CreatePoint3D()
        Try
            ReDim Preserve PllPts(0 To PllVtNum)
            P.X = mPoint.X
            P.Y = mPoint.Y
            P.Z = 0 'sgworldMain.Terrain.GetGroundHeightInfo(PosPixel.X, PosPixel.Y, AccuracyLevel.ACCURACY_NORMAL, True).Position.Altitude
            PllPts(PllVtNum) = P
        Catch ex As Exception
            ' Handle any exceptions that may occur
            Console.WriteLine("An error occurred: " & ex.Message)
        End Try
    End Sub




    Public Sub CreatePoint(ByVal x As Double, ByVal y As Double)
        Try
            Dim point As New Point3D With {.X = x, .Y = y}
            points.Add(point)
        Catch
        End Try
    End Sub

    Public Sub CreateArrayVector()
        Try
            ReDim Preserve PllVts(0 To PllVtNum * 3 + 2)
            PllVts(PllVtNum * 3) = mPoint.X
            PllVts(PllVtNum * 3 + 1) = mPoint.Y
            PllVts(PllVtNum * 3 + 2) = 0
            If Lenhve = "muitiencongchuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "muiteincongthuyeu" Then
                TDMuiten = TDMuiten & PllVts(PllVtNum * 3).ToString & "," & PllVts(PllVtNum * 3 + 1).ToString & ":"
            End If
            PllVtNum += 1
            soDiem += 1
        Catch
        End Try
    End Sub

    Public Sub Tinhgoc()
        Try
            Dim dx As Double = 0.0, dy As Double = 0.0
            If PllVts(3) <> 0 Or PllVts(4) <> 0 Then
                dx = PllVts(0) - PllVts(3)
                dy = PllVts(1) - PllVts(4)
                If dx = 0.0 Then
                    If dy = 0.0 Then
                        Phuongvi = 0.0
                    ElseIf dy > 0.0 Then
                        Phuongvi = Math.PI / 2.0#
                    ElseIf dy < 0.0 Then
                        Phuongvi = Math.PI * 3.0 / 2.0#
                    End If
                End If
                Dim goc = Math.Atan(Math.Abs(dy / dx))
                If (dx > 0) And (dy >= 0) Then Phuongvi = goc
                If (dx < 0) And (dy >= 0) Then Phuongvi = Math.PI - goc
                If (dx < 0) And (dy <= 0) Then Phuongvi = goc + Math.PI
                If (dx > 0) And (dy <= 0) Then Phuongvi = Math.PI * 2.0 - goc
            Else
                Phuongvi = 0.0
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Public Sub CreateArrayWaypoint()
        Try
            ReDim Preserve WaypointArr(0 To PllVtNum)
            WaypointArr(PllVtNum) = sgworldMain.Creator.CreateRouteWaypoint(mPoint.X, mPoint.Y, 20 * Val(txtDocao.Text), 15 * Val(txtVantoc.Text), 0, 0, 0, TxtTenKH.Text) ' 60 * Val(txtVantoc.Text) / 3.6
            PllVtNum += 1
        Catch
        End Try
    End Sub

#End Region
#Region "...Option"

    Private Sub ChebTQ(txt As String, cheb As CheckBox)
        tenMayNet = ""
        GiaidoanNet = ""
        MTylebando()
        MGiaidoan()
        Bd3D = chebOpen3Dbd.Checked
        Try
            mNetwork = False
            If cheb.Checked = True Then
                Dim ko = sgworldMain.ProjectTree.GetNextItem(String.Empty, ItemCode.SELECTED)
                txt = CheckTheonhom(ko, cheb)
            Else
                If txt = "" Then
                    If panelKHthuongdung.Visible = False Then
                        MouseHook1.Dispose()
                        MsgBox("Hãy nhập tên ký hiệu...", MsgBoxStyle.Critical, "Chú ý...")
                        Exit Sub
                        Lenhve = ""
                        Lenhsua = ""
                        Lenhve2 = ""
                    Else
                        Lenhve = ""
                        Lenhsua = ""
                        Lenhve2 = ""
                    End If
                    Exit Sub
                Else
                    Dkien = True
                    If Not Lenhve = "vekhung" And Not Lenhve = "Trinhbay" Then
                        Giaidoan = Giaidoan
                        tenKH = tenKH
                        SKiemtraTenKH(txt)
                        GroupBac2Main = Gr03(sgworldMain, System.Environment.MachineName, Giaidoan, tenKH)
                        MouseHook1.InstallHook()
                    Else
                        ' MouseHook1.Dispose()
                    End If
                End If
            End If
            textKH = tenKH
            SetMouseArrow()
            cbKieuduong.SelectedIndex = 0
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Function CheckTheonhom(ko As String, cheb As CheckBox) As String
        Try
            Dim txt As String
            If String.IsNullOrEmpty(ko) Then
                MouseHook1.Dispose()
                MsgBox("Chưa có Group được chọn!!!...", MsgBoxStyle.Critical, "Chú ý...")
                Lenhve = ""
                cheb.Checked = False
                Exit Function
            Else
                Dim txtTen As String = sgworldMain.ProjectTree.GetItemName(ko)
                If txtTen = "GD1" Or txtTen = "GD2" Or txtTen = "GD3" Or txtTen = "GD4" Or
               txtTen = "GD5" Or txtTen = "GD6" Or txtTen = "GD7" Then
                    MouseHook1.Dispose()
                    MsgBox("Kiểm tra lại Group đã chọn!!!...", MsgBoxStyle.Critical, "Chú ý...")
                    Lenhve = ""
                    cheb.Checked = False
                    Exit Function
                Else
                    MouseHook1.InstallHook()
                    mChebNhom = True
                    Giaidoan = sgworldMain.ProjectTree.GetItemName(sgworldMain.ProjectTree.GetNextItem(ko, ItemCode.PARENT))
                    GroupBac2Main = Gr03(sgworldMain, System.Environment.MachineName, Giaidoan, tenKH)
                    txt = txtTen
                End If
            End If
            CheckTheonhom = txt
        Catch
        End Try
    End Function

    Public Function SKiemtraTenKH(txt As String) As String
        Try
            Dim STT As Integer = 1
            Dim Phan1 As String
            Giaidoan = "GD" & (cbGiaidoan.SelectedIndex + 1).ToString
            Dim k0 = sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & Giaidoan & "\" & txt)
            If String.IsNullOrEmpty(k0) = False Then
                If sgworldMain.ProjectTree.IsGroup(k0) Then
                    If txt.Contains("-") Then
                        STT = Val(txt.Split("-")(1)) + 1
                        Phan1 = Trim(txt).Split("-")(0)
                    Else
                        STT = STT
                        Phan1 = Trim(txt)
                    End If
                    MsgBox("Đối tượng đã có, hãy nhập tên khác ")
                    txt = ""
                End If
                k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.[NEXT])
            End If
        Catch
        End Try
    End Function

    Private Sub CbGiaidoan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbGiaidoan.SelectedIndexChanged
        MGiaidoan()
    End Sub

    Public Sub MGiaidoan()
        Try
            Giaidoan = "Giai đoạn " & (cbGiaidoan.SelectedIndex + 1).ToString
            ChebTheoNhom.Text = "Theo Nhóm. " & "Giai đoạn " & (cbGiaidoan.SelectedIndex + 1).ToString & ", " & cbTylebando.Text.Replace("Tỷ lệ", "")
            chebTheoNhomKHTD.Text = "Theo Nhóm. " & "Giai đoạn " & (cbGiaidoan.SelectedIndex + 1).ToString & ", " & cbTylebando.Text.Replace("Tỷ lệ", "")

            MaulbToado()
            tenGiaidoan = (cbGiaidoan.SelectedIndex + 1).ToString & ".mkx"
        Catch
        End Try
    End Sub

    Public Sub MTylebando()
        Try
            If cbTylebando.SelectedIndex = 7 Then
                mnuTyletuychon.Visible = True
            Else
                mnuTyletuychon.Visible = False
            End If
            Select Case cbTylebando.SelectedIndex
                Case 0
                    fLabelStyleMain.FontSize = 53
                    Tyle = 0.1
                Case 1
                    fLabelStyleMain.FontSize = 52.5
                    Tyle = 0.25
                Case 2
                    fLabelStyleMain.FontSize = 50
                    Tyle = 0.5
                Case 3
                    fLabelStyleMain.FontSize = 45
                    Tyle = 1.0
                Case 4
                    fLabelStyleMain.FontSize = 42.5
                    Tyle = 2.5
                Case 5
                    fLabelStyleMain.FontSize = 41
                    Tyle = 5.0
                Case 6
                    fLabelStyleMain.FontSize = 40
                    Tyle = 10
                Case 7
                    Tyle = Val(txtMausobando.Text) / 100000
            End Select
        Catch
        End Try
    End Sub

    Private Sub TyleSaban()
        Try
            If cbTylebando.SelectedIndex = 7 Then
                mnuTyletuychon.Visible = True
            Else
                mnuTyletuychon.Visible = False
            End If
            Select Case cbTylebando.SelectedIndex
                Case 0
                    TyleSBVL = 100
                Case 1
                    TyleSBVL = 250
                Case 2
                    TyleSBVL = 500
                Case 3
                    TyleSBVL = 1000
                Case 4
                    TyleSBVL = 2500
                Case 5
                    TyleSBVL = 50000
                Case 6
                    TyleSBVL = 100000
                Case 7
                    Tyle = Val(txtMausobando.Text) / 100000
            End Select
        Catch
        End Try
    End Sub

    Private Sub CbTylebando_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTylebando.SelectedIndexChanged
        Try
            MTylebando()
            MGiaidoan()
            Dorongduong = Tyle * 60.0
            fLabelStyleMain.Scale = Tyle * 6.0
        Catch
        End Try
    End Sub

    Private Sub CbTa_DP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTa_DP.SelectedIndexChanged
        Try
            Select Case cbTa_DP.SelectedIndex
                Case 0
                    mauTieude = Color.Red
                    tl1000000.Enabled = True
                    tl1000001.Enabled = True
                    tl1000002.Enabled = True
                    tl1200000.Enabled = True
                    tl130000.Enabled = True
                    tl1200001.Enabled = True
                    tl130001.Enabled = True
                    tl130002.Enabled = True
                    tl130003.Enabled = True
                    tl130004.Enabled = True
                    tl130005.Enabled = True
                    tl1200005.Enabled = True
                    tl1200006.Enabled = True
                    tl130014.Enabled = True
                    tl130015.Enabled = True
                    tl130016.Enabled = True
                    tl130013.Enabled = True
                    tl130012.Enabled = True
                    tl130006.Enabled = True
                    tl130007.Enabled = True
                    tl130008.Enabled = True
                    tl130015.Enabled = True
                    tl130009.Enabled = True
                    tl130010.Enabled = True
                    tl130011.Enabled = True
                    tl1100003.Enabled = True
                    tl1100004.Enabled = True
                    tl1100005.Enabled = True
                    tl1100006.Enabled = True
                    tl1100007.Enabled = True
                    tl1100008.Enabled = True
                    tl1100009.Enabled = True
                    tl1100010.Enabled = True
                    Ta_Doiphuong = "1"
                    If cbChieuKH.SelectedIndex = 1 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,Right"
                    ElseIf cbChieuKH.SelectedIndex = 0 Then
                    End If
                Case 1
                    mauTieude = Color.Blue
                    tl1000000.Enabled = False
                    tl1000001.Enabled = False
                    tl1000002.Enabled = False
                    tl1200000.Enabled = False
                    tl130000.Enabled = False
                    tl1200001.Enabled = False
                    tl130001.Enabled = False
                    'tl1000002.Enabled = False
                    tl130002.Enabled = False
                    tl130003.Enabled = False
                    tl130004.Enabled = False
                    tl130005.Enabled = False
                    tl1200005.Enabled = False
                    tl1200006.Enabled = False
                    tl130014.Enabled = False
                    tl130015.Enabled = False
                    tl130016.Enabled = False
                    tl130013.Enabled = False
                    tl130012.Enabled = False
                    tl130006.Enabled = False
                    tl130007.Enabled = False
                    tl130008.Enabled = False
                    tl130015.Enabled = False
                    tl130009.Enabled = False
                    tl130010.Enabled = False
                    tl130011.Enabled = False
                    tl1100003.Enabled = False
                    tl1100004.Enabled = False
                    tl1100005.Enabled = False
                    tl1100006.Enabled = False
                    tl1100007.Enabled = False
                    tl1100008.Enabled = False
                    tl1100009.Enabled = False
                    tl1100010.Enabled = False
                    Ta_Doiphuong = "2"
                    If cbChieuKH.SelectedIndex = 0 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,Left"
                    ElseIf cbChieuKH.SelectedIndex = 1 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,Right"
                    End If
            End Select
            MaulbToado()
            tenGiaidoan = (cbGiaidoan.SelectedIndex + 1).ToString & ".mkx"
            chebTheoNhomKHTD.ForeColor = mauTieude
            ChebTheoNhom.ForeColor = mauTieude
            tlMau1.BackColor = mauTieude
        Catch
        End Try
    End Sub

    Private Sub MaulbToado()
        Try
            Dim MLabel As Color = Nothing
            Select Case cbGiaidoan.SelectedIndex
                Case 0
                    If cbTa_DP.SelectedIndex = 1 Then
                        MLabel = Color.FromArgb(0, 255, 255)
                    Else
                        MLabel = Color.FromArgb(255, 100, 255)
                    End If
                Case 1
                    If cbTa_DP.SelectedIndex = 0 Then
                        MLabel = Color.FromArgb(255, 255, 0)
                    Else
                        MLabel = Color.FromArgb(0, 180, 255)
                    End If
                Case 2
                    If cbTa_DP.SelectedIndex = 0 Then
                        MLabel = Color.FromArgb(234, 193, 23)
                    Else
                        MLabel = Color.FromArgb(30, 144, 255)
                    End If
                Case 3
                    If cbTa_DP.SelectedIndex = 0 Then
                        MLabel = Color.FromArgb(255, 127, 0)
                    Else
                        MLabel = Color.FromArgb(67, 110, 238)
                    End If
                Case 4
                    If cbTa_DP.SelectedIndex = 0 Then
                        MLabel = Color.FromArgb(255, 165, 100)
                    Else
                        MLabel = Color.FromArgb(24, 116, 205)
                    End If
                Case 5
                    If cbTa_DP.SelectedIndex = 0 Then
                        MLabel = Color.FromArgb(168, 255, 0)
                    Else
                        MLabel = Color.FromArgb(0, 155, 155)
                    End If
                Case 6
                    MLabel = Color.FromArgb(50, 180, 100)
            End Select
            SLabel.BackColor = MLabel
            LbTieude.BackColor = MLabel
        Catch
        End Try
    End Sub

    Private ReadOnly GDchon As String = String.Empty
    Private ReadOnly Tylechon As String = String.Empty

    Private Sub CbChieuKH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbChieuKH.SelectedIndexChanged
        Try
            If cbChieuKH.SelectedIndex = 0 Then
                ChieuKH = ""
            ElseIf cbChieuKH.SelectedIndex = 1 Then
                ChieuKH = "N"
                'If Not Lenhve = "chuyenDTNet" Then
                '    ChieuKH = "N"
                'Else
                '    ChieuKH = ""
                'End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ChebBangDT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) ' Handles ChebBangDT.CheckedChangedư
        Try
            DinhviBDT()
            If Bd3D = True Then
                Bdt3Dbd_3DA(Frm3Dbd.Instance.AxTEInformationWindowEx1, Frm3Dbd.Instance.AxTE3DWindowEx1)
            End If
            If A3D = True Then
                Bdt3Dbd_3DA(Frm3DA.Instance.AxTEInformationWindowEx2, Frm3DA.Instance.AxTE3DWindowEx2)
            End If
            Try
                sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Dchuyen"))
            Catch ex As Exception
                Exit Try
            End Try
        Catch
        End Try
    End Sub

    Private Sub STaungam(mLenhve As String, mcLoaiKH As String)
        Try
            If mLenhve = "veco" Or mLenhve = "mohinhPB" Or mLenhve = "TaungamPB" Or mLenhve = "Taungam" Or mLenhve = "vunghoaluc" Then 'vunghoaluc
                Lenhve = mLenhve
                loaiKH = mcLoaiKH
                If loaiKH.Contains("cu") Then
                    loaiKH = loaiKH.Replace("cu", "")
                ElseIf loaiKH.Contains("HQ") Then
                    loaiKH = loaiKH.Replace("HQ", "")
                ElseIf loaiKH.Contains("BP") Then
                    loaiKH = loaiKH.Replace("BP", "")
                End If
            ElseIf mLenhve = "" Then
                Lenhve = mcLoaiKH
                If Lenhve.Contains("Git") Then
                    Lenhve = "Gioituyen"
                    loaiKH = mcLoaiKH.Replace("Git", "")
                    StyleLine(Lenhve, DorongVung, TyleX, TyleY)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub StyleLine(mcLoaiKH As String, mDorongVung As Integer, mTyleX As Integer, mTyleY As Integer)
        Try
            Lenhve = mcLoaiKH
            DorongVung = mDorongVung
            TyleX = mTyleX
            TyleY = mTyleY
        Catch
        End Try
    End Sub

    Private Sub RdKhailuoc_CheckedChanged(sender As Object, e As EventArgs) Handles rdKhailuoc.CheckedChanged
        Try
            If rdKhailuoc.Checked = True Then
                txt1000Km.Enabled = True
                lb1000Km.Enabled = True
            Else
                txt1000Km.Enabled = False
                lb1000Km.Enabled = False
                txt1000Km.Text = ""
            End If
        Catch
        End Try
    End Sub

    Private Sub ChebVeKH_CheckedChanged(sender As Object, e As EventArgs) Handles chebVeKH.CheckedChanged
        Try
            If chebVeKH.Checked = True Then
                btnTimdiem.Enabled = False
            Else
                btnTimdiem.Enabled = True
            End If
        Catch
        End Try
    End Sub

    Private Sub Import_KeyPress(e As KeyPressEventArgs, mCharter As Char)
        Try
            If e.KeyChar = mCharter AndAlso mCharter <> ControlChars.Back Then Exit Sub ' cho phép phím BackSpace hoạt động
            If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
                e.Handled = True ' không cho phép nhập ký tự khác số
            End If
        Catch ex As Exception
            e.KeyChar = ""
        End Try
    End Sub

    Private Sub Import2_KeyPress(e As KeyPressEventArgs, mCharter1 As Char, mCharter2 As Char)
        Try
            If e.KeyChar = mCharter1 OrElse e.KeyChar = mCharter2 OrElse e.KeyChar = ControlChars.Back Then Exit Sub ' cho phép phím BackSpace hoạt động
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True ' không cho phép nhập ký tự khác số
            End If
        Catch ex As Exception
            e.KeyChar = ""
        End Try
    End Sub

#End Region
#Region "   Giao dien"

    Private host As ToolStripControlHost, host1 As ToolStripControlHost, host2 As ToolStripControlHost, Labelhost As ToolStripControlHost = Nothing
    Private Sub TxtTenKH_TextChanged(sender As Object, e As EventArgs) Handles TxtTenKH.TextChanged
        tenKH = TxtTenKH.Text
    End Sub

    Private Sub ChebTheoNhom_CheckedChanged(sender As Object, e As EventArgs) Handles ChebTheoNhom.CheckedChanged
        Try
            If Not toolSuachua.Visible = True Then
                If ChebTheoNhom.Checked = True Then
                    TxtTenKH.Enabled = False
                    Dim k0 As String = sgworldMain.ProjectTree.GetNextItem("", ItemCode.SELECTED)
                    TxtTenKH.Text = sgworldMain.ProjectTree.GetItemName(k0)
                Else
                    TxtTenKH.Enabled = True
                    TxtTenKH.Text = ""
                End If
            End If

            If toolSuachua.Visible = True Then
                If ChebTheoNhom.Checked = True Then
                    xoaDTcat = True
                Else
                    xoaDTcat = False
                End If
            Else
                xoaDTcat = False
            End If
        Catch ex As Exception
            MsgBox("Chưa có Group được chọn!!!...", MsgBoxStyle.Critical, "Chú ý...")
            ChebTheoNhom.Checked = False
            Exit Sub
        End Try
    End Sub

    Private Sub MToolstrip(cToolstrip As ToolStrip, tenTieude As String, HeightTool As Integer, WideText As Integer) ', mTenTool As String)
        Try
            CloseAllTool()
            MGiaidoan()
            CloseAllPanel()
            ' SoKT = System.Convert.ToInt32(txtGroup.Text)
            ' soGia = System.Convert.ToInt32(txtGroup.Text)S
            KCDuoiMT = 0
            cbTa_DP.SelectedIndex = 0
            cbChieuKH.SelectedIndex = 0
            cbTenluahaiquan.SelectedIndex = 0
            cbKHbiendoitauhanhquan.SelectedIndex = 0
            cbLoaiKHQS_HDTC.SelectedIndex = 0
            cbLoaiBChanhquanHDTC.SelectedIndex = 0
            cbLoaiMohinh.SelectedIndex = 0
            cbLoaiTrandiaPK.SelectedIndex = 0
            cbLoaiMB.SelectedIndex = 0
            cbLoaiTrandia.SelectedIndex = 0
            cbKieuduong.SelectedIndex = 0
            cbChieuMuiThuyeu.SelectedIndex = 0
            cbKieuTrKTiencong.SelectedIndex = 0
            cbTauHQ.SelectedIndex = 0
            cbTauKtraBatgiuApgiai.SelectedIndex = 0
            '' ClosePanel(pnTrinhchieu)
            cToolstrip.Visible = True
            Dim PxTool As Integer = 0
            PxTool = Me.Width - 294
            If cToolstrip.Visible = True Then
                ' MsgBox(cToolstrip.Height.ToString)
                cToolstrip.Padding = New Padding(1, 0, 0, 0)
                cToolstrip.Margin = New Padding(1, 0, 0, 0)
                cToolstrip.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Regular)
                For Each mItem As ToolStripItem In cToolstrip.Items
                    mItem.AutoToolTip = False
                    If Not mItem.Name = "lblGocquay" Then 'And Not cToolstrip.Name = "txtGocquay" Then
                        mItem.Padding = New Padding(0, 0, 0, 0)
                        mItem.Margin = New Padding(0, 0, 0, 0)
                        mItem.Size = New Size(32, 32)
                    End If
                Next
                ChebTheoNhom.FlatStyle = FlatStyle.Flat
                Dim mCao As Integer = (32 * cToolstrip.Items.Count / 6) + HeightTool
                '   mCao = (32 * cToolstrip.Items.Count / 6) + soGia
                SLabel.Text = tenTieude
                SLabel.AutoSize = True
                SLabel.Font = New System.Drawing.Font("microsoft sans serif", 11, FontStyle.Regular)
                SLabel.Text = Space(WideText / 2) & SLabel.Text & Space(WideText / 2)
                SLabel.BringToFront()
                Labelhost = New ToolStripControlHost(SLabel)
                cToolstrip.Items.Insert(0, Labelhost)
                SLabel.Location = New Point(145 - (SLabel.Width / 2 - 1), 1)
                AddHandler SLabel.DoubleClick, AddressOf SLabel_Click
                If Not cToolstrip.Name = "toolSuachua" And Not cToolstrip.Name = "ToolPDF" Then 'cToolstrip.Name = "toolSuachua" And Not
                    ChebTheoNhom.Checked = False
                    ChebTheoNhom.Text = "Theo Nhóm. " & "Giai đoạn " & (cbGiaidoan.SelectedIndex + 1).ToString & ", " & cbTylebando.Text.Replace("Tỷ lệ", "")
                    ChebTheoNhom.Padding = New Padding(7, 0, 0, 3)
                    host = New ToolStripControlHost(ChebTheoNhom)
                    cToolstrip.Items.Insert(1, host)
                    ChebTheoNhom.ForeColor = mauTieude
                    LabelTenKH.Text = " Tên Ký hiệu: "
                    LabelTenKH.Padding = New Padding(0, 7, 0, 2)
                    LabelTenKH.Enabled = False
                    cToolstrip.Items.Insert(2, LabelTenKH)
                    TxtTenKH.Text = ""
                    TxtTenKH.Margin = New Padding(0, 0, 0, 3)
                    TxtTenKH.BorderStyle = BorderStyle.FixedSingle
                    TxtTenKH.TextBoxTextAlign = HorizontalAlignment.Center
                    TxtTenKH.Size = New Size(190, 20)
                    cToolstrip.Items.Insert(3, TxtTenKH)
                    'TxtVT.Text = ""
                    'TxtVT.Margin = New Padding(0, 0, 0, 3)
                    'TxtVT.BorderStyle = BorderStyle.FixedSingle
                    'TxtVT.TextBoxTextAlign = HorizontalAlignment.Center
                    'TxtVT.Size = New Size(285, 20)
                    'cToolstrip.Items.Insert(4, TxtVT)
                    '/////////
                    If Not cToolstrip.Name = "ToolTI1" And Not cToolstrip.Name = "ToolMH" Then
                        LabelGhichuKH.Text = "  Ghi chú:       "
                        LabelGhichuKH.Padding = New Padding(0, 7, 0, 2)
                        cToolstrip.Items.Insert(4, LabelGhichuKH)
                        LabelGhichuKH.Enabled = False
                        TxtGhichuKH.Margin = New Padding(0, 0, 0, 3)
                        TxtGhichuKH.BorderStyle = BorderStyle.FixedSingle
                        TxtGhichuKH.TextBoxTextAlign = HorizontalAlignment.Center
                        TxtGhichuKH.Size = New Size(189, 20)
                        TxtGhichuKH.Text = ""
                        cToolstrip.Items.Insert(5, TxtGhichuKH)
                        mCao += 22
                    End If

                End If

                If cToolstrip.Name = "toolSuachua" Then
                    ChebTheoNhom.Text = "Xóa đối tượng cắt."
                    ChebTheoNhom.Padding = New Padding(9, 0, 130, 3)
                    ChebTheoNhom.Checked = True
                    host = New ToolStripControlHost(ChebTheoNhom)
                    cToolstrip.Items.Insert(1, host)
                End If

                If cToolstrip.Name = "ToolPDF" Then
                    LabelThongtin.Padding = New Padding(10, 10, 0, 0)
                    LabelThongtin.TextAlign = ContentAlignment.MiddleCenter
                    LabelThongtin.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
                    LabelThongtin.ForeColor = Color.Blue
                    LabelThongtin.Text = "   Tỷ lệ in bản đồ là" & cbTylebando.Text.Replace("Tỷ lệ", "")
                    cToolstrip.Items.Insert(1, LabelThongtin)
                End If

                If cToolstrip.Name = "ToolTI1" Then
                    ChebTheoGD.FlatStyle = FlatStyle.Flat
                    ChebTheoGD.Checked = True
                    ChebTheoGD.Text = "Theo giai đoạn "
                    ChebTheoGD.ForeColor = Color.Black
                    ChebTheoGD.Padding = New Padding(9, 0, 5, 0)
                    host1 = New ToolStripControlHost(ChebTheoGD)
                    cToolstrip.Items.Insert(4, host1)
                    ChebTron.Checked = False
                    ChebTron.FlatStyle = FlatStyle.Flat
                    ChebTron.Text = "Làm trơn. "
                    ChebTron.ForeColor = Color.Black
                    ChebTron.Padding = New Padding(15, 0, 0, 0)
                    host2 = New ToolStripControlHost(ChebTron)
                    cToolstrip.Items.Insert(5, host2)
                End If
                SetSizeToolstrip()
                cToolstrip.Size = New Size(((32 * 9) + 2), mCao)
                cToolstrip.Location = New Point(PxTool, (Me.Height - (cToolstrip.Height + 5)))
                cToolstrip.BringToFront()
                cbTenluahaiquan.Select(0, 0)
                cbKHbiendoitauhanhquan.Select(0, 0)
                cbLoaiKHQS_HDTC.Select(0, 0)
                cbLoaiBChanhquanHDTC.Select(0, 0)
                cbLoaiMohinh.Select(0, 0)
                cbLoaiTrandiaPK.Select(0, 0)
                cbLoaiMB.Select(0, 0)
                cbLoaiTrandia.Select(0, 0)
                cbKieuduong.Select(0, 0)
                cbChieuMuiThuyeu.Select(0, 0)
                cbKieuTrKTiencong.Select(0, 0)
                cbTauHQ.Select(0, 0)
                cbTauKtraBatgiuApgiai.Select(0, 0)
                TxtTenKH.Focus()
                '  AddHandler cToolstrip.DoubleClick, AddressOf CToolstrip_MouseDoubleClick
            Else
                CloseToolstrip(cToolstrip)
            End If
        Catch
        End Try
    End Sub

    Private Sub SLabel_Click(sender As Object, e As EventArgs) Handles SLabel.DoubleClick
        Try
            CloseAllTool()
            SetMouseHand()
        Catch
        End Try
    End Sub

    Private Sub SetSizeToolstrip()
        Try
            lbVantoc.Margin = New Padding(0, 6, 0, 0)
            lbDocao.Margin = New Padding(0, 6, -2, 0)
            lbKCDT.Margin = New Padding(0, 6, 0, 0)
            txtVantoc.Size = New Size(45, 22)
            txtDocao.Size = New Size(45, 22)
            txtDocao.Margin = New Padding(0, 0, 0, 3)
            txtKCDT.Size = New Size(46, 22)
            txtKCDT.Margin = New Padding(0, 0, 0, 3)
            cbTenluahaiquan.Margin = New Padding(4, 0, 0, 3)
            cbTenluahaiquan.Size = New Size(283, 24)
            cbKHbiendoitauhanhquan.Margin = New Padding(4, 0, 0, 3)
            cbKHbiendoitauhanhquan.Size = New Size(283, 24)
            cbLoaiBChanhquanHDTC.Margin = New Padding(4, 0, 0, 3)
            cbLoaiBChanhquanHDTC.Size = New Size(283, 24)
            cbLoaiKHQS_HDTC.Margin = New Padding(4, 0, 0, 3)
            cbLoaiKHQS_HDTC.Size = New Size(283, 24)
            cbChieuMuiThuyeu.Margin = New Padding(4, 0, 0, 3)
            cbChieuMuiThuyeu.Size = New Size(283, 24)
            cbKieuTrKTiencong.Margin = New Padding(4, 0, 0, 3)
            cbKieuTrKTiencong.Size = New Size(283, 24)
            cbLoaiMohinh.Margin = New Padding(4, 0, 0, 3)
            cbLoaiMohinh.Size = New Size(283, 24)
            cbLoaiTrandiaPK.Margin = New Padding(4, 0, 0, 3)
            cbLoaiTrandiaPK.Size = New Size(283, 24)
            cbLoaiMB.Margin = New Padding(4, 0, 0, 3)
            cbLoaiMB.Size = New Size(283, 24)
            cbTauHQ.Margin = New Padding(4, 0, 0, 3)
            cbTauHQ.Size = New Size(283, 24)
            cbTauKtraBatgiuApgiai.Margin = New Padding(4, 0, 0, 3)
            cbTauKtraBatgiuApgiai.Size = New Size(283, 24)
            cbLoaiTrandia.Margin = New Padding(4, 0, 0, 3)
            cbLoaiTrandia.Size = New Size(283, 24)
            cbLoaiTrandia.SelectedIndex = 0
            MauDuongVung.Margin = New Padding(5, 7, 13, 0)
            lbChieucaochu.Margin = New Padding(5, 7, 39, 0)
            txtChieucaochu.Margin = New Padding(11, 2, 2, 0)
            txtChieucaochu.Text = "50"
            lbKieuduong.Margin = New Padding(5, 7, 4, 0)
            tlMau1.Size = New Size(23, 23)
            tlMau1.Margin = New Padding(3, 0, 3, 2)
            tlMau2.Size = New Size(23, 23)
            tlMau2.Margin = New Padding(3, 0, 3, 2)
            lbKieuduong.Margin = New Padding(5, 10, 3, 0)
            cbKieuduong.Size = New Size(191, 23)
            cbKieuduong.Margin = New Padding(6, 4, 3, 0)
            'cbKieuduong.SelectedIndex = 0
            lbKieuchu.Margin = New Padding(5, 7, 3, 0)
            lbNoidungchu.Margin = New Padding(5, 6, 3, 0)
            txtNoidungchu.Size = New Size(282, 23)
            txtNoidungchu.Margin = New Padding(4, 2, 3, 0)
            lbFont.Margin = New Padding(7, 7, 0, 0)
            lbFont.AutoSize = False
            lbFont.Size = New Size(140, 18)
            lbFont.Font = New System.Drawing.Font("microsoft sans serif", 10, FontStyle.Italic)
            lbFont.Text = FontDialog1.Font.Name
            lbFont.ForeColor = Color.Blue
            ' TxtTenKH.Focus()
            ' txtChieucaochu.Margin = New Padding(12, 2, 3, 0)
        Catch
        End Try
    End Sub

    Private Sub CloseToolstrip(cToolstrip As ToolStrip)
        Try
            ChebTheoNhom.Checked = False
            cToolstrip.Items.Remove(Labelhost)
            cToolstrip.Items.Remove(host)
            cToolstrip.Items.Remove(LabelThongtin)
            cToolstrip.Items.Remove(LabelTenKH)
            cToolstrip.Items.Remove(TxtTenKH)
            If cToolstrip.Name = "ToolTI1" Then
                cToolstrip.Items.Remove(host1)
                cToolstrip.Items.Remove(host2)
            End If
            cToolstrip.Update()
            cToolstrip.Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CloseAllTool()
        Try
            CloseToolstrip(ToolMH)
            CloseToolstrip(ToolCB)
            CloseToolstrip(ToolHQ)
            CloseToolstrip(ToolBB)
            CloseToolstrip(ToolTTG)
            CloseToolstrip(ToolPB)
            CloseToolstrip(ToolDC)
            CloseToolstrip(ToolTTLL)
            CloseToolstrip(ToolTCDT)
            CloseToolstrip(ToolHH)
            CloseToolstrip(toolPK)
            CloseToolstrip(ToolLLVTDP)
            CloseToolstrip(ToolDBDV)
            CloseToolstrip(ToolBP)
            CloseToolstrip(ToolBLLD)
            CloseToolstrip(ToolHC)
            CloseToolstrip(ToolHDTC)
            CloseToolstrip(toolSuachua)
            CloseToolstrip(ToolTI1)
            CloseToolstrip(ToolQBTS) 'm
            CloseToolstrip(ToolCY)
            CloseToolstrip(ToolCH)
            CloseToolstrip(ToolKGM)
            CloseToolstrip(ToolKT)
            CloseToolstrip(ToolTTruyen)
            Lenhve = ""
            Lenhve2D = ""
            lenhveMS = ""
            sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Temp"))
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    'Private PointBDT As Point
    Private Sub DinhviBDT()
        Try
            Dim PointBDT As Point
            If ChebBangDT.Checked = True Then
                PointBDT.Y = AxTE3DWindow1.Height - (AxTEInformationWindow1.Height + 2)
                AxTEInformationWindow1.Visible = True
            Else
                PointBDT.Y = Me.Height + 100
                AxTEInformationWindow1.Visible = False
            End If

            AxTEInformationWindow1.Height = Me.Height / 2
            AxTEInformationWindow1.Width = Screen.PrimaryScreen.WorkingArea.Width / 8
            PointBDT.X = 2
            Me.AxTEInformationWindow1.Location = PointBDT
            AxTEInformationWindow1.BringToFront()
        Catch
        End Try
    End Sub

#Region "   OPen"
    Private Sub ChebOpen3Dbd_CheckedChanged(sender As Object, e As EventArgs) Handles chebOpen3Dbd.CheckedChanged
        Try
            If chebOpen3Dbd.Checked = True Then
                lbChon3Dbd.Visible = True
                chebOpen3DA.Enabled = True
                Bd3D = True
            Else
                chebOpen3DA.Enabled = False
                lbChon3Dbd.Visible = False
                Bd3D = False
            End If
        Catch
        End Try
    End Sub

    Private Sub ChebOpenMS_CheckedChanged(sender As Object, e As EventArgs) Handles chebOpenMS.CheckedChanged
        Try
            If chebOpenMS.Checked = True Then
                lbChonMS.Visible = True
                cbMuiChieu.Enabled = True
            Else
                mMicrostation = False
                lbChonMS.Visible = False
                cbMuiChieu.Enabled = False
            End If
            CopyUserConfig(PathData & "\RSC\dfltuser.cfg")
        Catch
        End Try
    End Sub

    Private Sub ChebOpen3DA_CheckedChanged(sender As Object, e As EventArgs) Handles chebOpen3DA.CheckedChanged
        Try
            If chebOpen3DA.Checked = True Then
                lbChon3DA.Visible = True
                A3D = True
            Else
                lbChon3DA.Visible = False
                A3D = False
            End If
        Catch
        End Try
    End Sub

    Private Sub LbChon3Dbd_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChon3Dbd.MouseDown
        MOpenFly(lbChon3Dbd)
    End Sub

    Private Sub LbChon3DA_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChon3DA.MouseDown
        MOpenFly(lbChon3DA)
    End Sub

    Private Sub LbChonFlyChinh_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChonFlyChinh.MouseDown
        MOpenFly(lbChonFlyChinh)
    End Sub

    Private Sub LbChonMS_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChonMS.MouseDown
        Try
            OpenFileDialog1.Title = "Mở tập tin *.DGN"
            OpenFileDialog1.Filter = "Tập tin *.DGN (*.dgn)|*.dgn"
            OpenFileDialog1.ShowDialog()
            lbChonMS.Text = OpenFileDialog1.FileName
            lbChonMS.ForeColor = Color.Blue
        Catch
        End Try
    End Sub

    Private Sub MOpenFly(mLabel As Label)
        Try
            OpenFileDialog1.Title = "Mở tập tin *.FLY"
            OpenFileDialog1.Filter = "Tập tin *.FLY (*.fly)|*.fly|Tập tin MPT (*.mpt)|*.mpt"
            OpenFileDialog1.ShowDialog()
            mLabel.Text = OpenFileDialog1.FileName
            'ChiaManHinh()
            'MessageBox.Show(" Tập tin *.Fly hợp lệ")
        Catch
        End Try
    End Sub

    Private Sub SMouseMove(Mlabel As Label)
        Try
            Mlabel.ForeColor = Color.Red
            Cursor = Cursors.Hand
        Catch
        End Try
    End Sub

    Private Sub SMouseLeave(Mlabel As Label)
        Try
            Mlabel.ForeColor = Color.Blue
            Cursor = Cursors.Default
        Catch
        End Try
    End Sub

    Private Sub LbChon3Dbd_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChon3Dbd.MouseMove
        SMouseMove(lbChon3Dbd)
    End Sub

    Private Sub LbChon3DA_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChon3DA.MouseMove
        SMouseMove(lbChon3DA)
    End Sub

    Private Sub LbChonFlyChinh_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChonFlyChinh.MouseMove
        SMouseMove(lbChonFlyChinh)
    End Sub

    Private Sub LbChonMS_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lbChonMS.MouseMove
        SMouseMove(lbChonMS)
    End Sub

    Private Sub CbChon3Dbd_MouseLeave(sender As Object, e As EventArgs) Handles lbChon3Dbd.MouseLeave
        SMouseLeave(lbChon3Dbd)
    End Sub

    Private Sub LbChon3DA_MouseLeave(sender As Object, e As EventArgs) Handles lbChon3DA.MouseLeave
        SMouseLeave(lbChon3DA)
    End Sub

    Private Sub LbChon3D_MouseLeave(sender As Object, e As EventArgs) Handles lbChonFlyChinh.MouseLeave
        SMouseLeave(lbChonFlyChinh)
    End Sub

    Private Sub LbChonMS_MouseLeave(sender As Object, e As EventArgs) Handles lbChonMS.MouseLeave
        SMouseLeave(lbChonMS)
    End Sub

    Private Sub LbChonFlyChinh_TextChanged(sender As Object, e As EventArgs) Handles lbChonFlyChinh.TextChanged
        Try
            AxTE3DWindow1.Visible = False
            If lbChonFlyChinh.Text <> Trim("Chọn tập tin Văn kiện tác chiến chính (*.fly)") Then
                btnOpen.Enabled = True
                chebOpenMS.Enabled = True
                chebOpen3Dbd.Enabled = True
                btfile.Text = lbChonFlyChinh.Text
            Else
                chebOpenMS.Enabled = False
                chebOpen3Dbd.Enabled = False
                chebOpen3DA.Enabled = False
                btnOpen.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub LbChon3Dbd_TextChanged(sender As Object, e As EventArgs) Handles lbChon3Dbd.TextChanged
        Try
            If lbChon3Dbd.Text <> Trim("Chọn tập tin Văn kiện tác chiến 3D (*.fly)") Then
                file3Dbd = OpenFileDialog1.FileName
                chebOpen3DA.Enabled = True
            Else
                chebOpen3DA.Enabled = False
            End If
        Catch
        End Try
    End Sub
    Private Sub btfile_TextChanged(sender As Object, e As EventArgs) Handles btfile.TextChanged
        Try
            If btfile.Text <> Trim("Chọn tập tin Văn kiện tác chiến 3D (*.fly)") Then
                filebt = OpenFileDialog1.FileName
            End If
        Catch
        End Try
    End Sub
    Private Sub LbChon3DA_TextChanged(sender As Object, e As EventArgs) Handles lbChon3DA.TextChanged
        Try
            If lbChon3DA.Text <> Trim("Chọn tập tin Văn kiện tác chiến 3D (*.fly)") Then
                file3DA = OpenFileDialog1.FileName
            End If
        Catch
        End Try
    End Sub

    Private Sub LbChonMS_TextChanged(sender As Object, e As EventArgs) Handles lbChonMS.TextChanged
        Try
            If lbChonMS.Text <> Trim("Chọn tập tin Văn kiện tác chiến 2D MicroStation (*.dgn)") Then
                fileMs = OpenFileDialog1.FileName
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            If chebOpenMS.Checked = True And cbMuiChieu.SelectedIndex = 0 Then
                MsgBox("Hãy chọn hệ tọa độ của tập tin MicroStation ...")
                Exit Sub
            End If
            OpenFly(lbChonFlyChinh.Text)
            Try
                If chebOpen3Dbd.Checked = True And lbChon3Dbd.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
                    Frm3Dbd.Instance.Show()

                End If
                If chebOpen3DA.Checked = True And lbChon3DA.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
                    Frm3DA.Instance.Show()
                End If
                If chebOpenMS.Checked = True Then
                    OpenDGN()
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        Catch
        End Try
    End Sub


#End Region

#Region "   Panel"
    Private Sub ClosePanel(mPanel As Panel)
        Try
            If mPanel.Visible = True Then
                mPanel.Visible = False
                If mPanel IsNot panelOpenVKTC Then
                    SetMouseHand()
                End If
            Else
                Exit Sub
            End If
        Catch
        End Try
    End Sub

    Private Sub CloseAllPanel()
        Try
            ' ClosePanel(panelSaveAS)
            ClosePanel(panelOpenVKTC)
            ClosePanel(panelMultiFlage)
            ClosePanel(panelGotoPoint)
            ClosePanel(panelVungHL)
            ClosePanel(panelCCDoitoado1)
            ClosePanel(panelTaoKichban)
            ClosePanel(panelTrinhbay1)
            ClosePanel(panelKhung)
            ClosePanel(panelLAN)
            ClosePanel(panelKHthuongdung)
            ClosePanel(panelVideo)
            Dim MSProcesses4 As Process() = Process.GetProcessesByName("SandImage")
            Array.ForEach(MSProcesses4, Sub(p As Process) p.Kill())
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub BbTieude_Click(sender As Object, e As EventArgs) Handles LbTieude.DoubleClick
        CloseAllPanel()
    End Sub

    Private Sub SPanel(mPanel As Panel)
        Try
            CloseAllPanel()
            toolKHTD.Items.Clear()
            libAddToolKHTD.Items.Clear()
            cbMuiChieu.Items.Clear()
            ClosePanel(pnTrinhchieu)
            Dim Xi As Integer
            If toolPK.Visible = True Or ToolDC.Visible = True Or ToolDC.Visible = True Or ToolCB.Visible = True Or ToolTCDT.Visible = True Or ToolMH.Visible = True Or ToolHH.Visible = True Or ToolHDTC.Visible = True Or ToolHQ.Visible = True Or
               ToolBB.Visible = True Or ToolTTG.Visible = True Or ToolPB.Visible = True Or ToolTTLL.Visible = True Or toolPK.Visible = True Or ToolLLVTDP.Visible = True Or ToolDBDV.Visible = True Or ToolBP.Visible = True Or ToolBLLD.Visible = True Or
               ToolHC.Visible = True Or toolSuachua.Visible = True Or ToolTI1.Visible = True Then
                Xi = menuMain.Height + 5
            Else
                Xi = Me.Height - (NumberLine() + 130)
            End If
            Dim TenHeTD As String = "Vn2000, 3 độ, KT=99 độ;Vn2000, 3 độ, KT=102 độ;Vn2000, 3 độ, KT=105 độ;Vn2000, 3 độ, KT=108 độ;Vn2000, 3 độ, KT=111 độ;Vn2000, 6 độ, múi 47 (KT=99 độ);Vn2000, 6 độ, múi 48 (KT=105 độ);Vn2000, 6 độ, múi 49 (KT=111 độ);WGS 84 (Độ);Hà Nội 72, Múi 47;Hà Nội 72, Múi 48;Hà Nội 72, Múi 49"
            Dim Crong As Integer = 0, PxPanel As Integer = 0
            Crong = mPanel.Width + 4
            PxPanel = Me.Width - Crong
            If mPanel.Name = "panelOpenVKTC" Or mPanel.Name = "panelSaveAS" Or mPanel.Name = "panelCCDoitoado1" Then
                mPanel.Location = New Point(Me.Width / 2 - mPanel.Width / 2, Me.Height / 2 - mPanel.Height / 2)
            ElseIf mPanel.Name = "panelTaoKichban" Or mPanel.Name = "panelLAN" Or mPanel.Name = "panelGotoPoint" Then 'Or mPanel.Name = "pnTrinhchieu"
                mPanel.Location = New Point(PxPanel, Me.Height - (mPanel.Height + 3))
            ElseIf mPanel.Name = "panelKHthuongdung" Then
                mPanel.Location = New Point(PxPanel, Xi)
                chebTheoNhomKHTD.Checked = False
                txtKHThuongdung.Text = ""
            Else
                mPanel.Location = New Point(PxPanel, menuMain.Height + 5)
            End If
            mPanel.Visible = True
            If mPanel.Visible = True Then
                LbTieude.Font = New System.Drawing.Font("microsoft sans serif", 11, FontStyle.Regular)
                LbTieude.AutoSize = True
                LbTieude.Text = ""
                LbTieude.Margin = New Padding(0, 5, 0, 2)
                mPanel.Controls.Add(LbTieude)
                LbTieude.ForeColor = Color.Black
                mPanel.BringToFront()
                If mPanel.Name = "panelGotoPoint" Then
                    CloseAllTool()
                    LbTieude.Text = " Tìm điểm theo tọa độ." & Space(60 - LbTieude.Text.Length)
                ElseIf mPanel.Name = "pnIPSaban" Then
                    LbTieude.Text = " IP Đối tượng sa bàn."
                ElseIf mPanel.Name = "panelPDF1" Then
                    LbTieude.Text = " Tạo tập tin *.PDF."
                ElseIf mPanel.Name = "panelTaoKichban" Then
                    LbTieude.Text = " Tạo Kịch bản trình chiếu Văn kiện tác chiến." & Space(110 - LbTieude.Text.Length)
                    CloseAllTool()
                    TxtEmpty()
                    libDanhsachTrC.Items.Clear()
                    liBDanhsachTrC2.Items.Clear()
                    cbHieuungCanh1.SelectedIndex = 0
                    cbTunhien.SelectedIndex = 0
                    cbPhimAmthanh.SelectedIndex = 0
                    cbHuDTchuyendong.SelectedIndex = 0
                    cbQsDoituong.SelectedIndex = 0
                    cbHuMH.SelectedIndex = 0
                    cbHuongDBDK.SelectedIndex = 0
                    cbVitriPhim.SelectedIndex = 0
                ElseIf mPanel.Name = "panelKHthuongdung" Then
                    MGiaidoan()
                    LbTieude.Text = "  Ký hiệu thường dùng." & Space(60 - LbTieude.Text.Length)
                    SAddTexttoListBox()
                ElseIf mPanel.Name = "panelSaveAS" Then
                    LbTieude.Text = " Đổi tên Văn kiện tác chiến." & Space(60 - LbTieude.Text.Length)
                    '  lbFolder.Text = LbTenFile.Text.Substring(0, LbTenFile.Text.LastIndexOf("\")) & "\"
                ElseIf mPanel.Name = "panelMultiFlage" Then
                    LbTieude.Text = " Tạo nhiều vị trí chỉ huy." & Space(60 - LbTieude.Text.Length)
                ElseIf mPanel.Name = "panelOpenVKTC" Then
                    LbTieude.Text = "  Mở các thành phần của Văn kiện tác chiến." & Space(100 - LbTieude.Text.Length)
                    LbTieude.BackColor = Color.DarkSlateGray
                    LbTieude.ForeColor = Color.White
                    LbTieude.Font = New System.Drawing.Font("microsoft sans serif", 12, FontStyle.Regular)
                    chebOpen3Dbd.Checked = False
                    chebOpenMS.Checked = False
                    chebOpen3DA.Checked = False
                    lbChonFlyChinh.Text = "Chọn tập tin Văn kiện tác chiến chính (*.fly)"
                    lbChon3Dbd.Text = "Chọn tập tin Văn kiện tác chiến 3D (*.fly)"
                    lbChon3DA.Text = "Chọn tập tin Văn kiện tác chiến 3D (*.fly)"
                    lbChonMS.Text = "Chọn tập tin Văn kiện tác chiến 2D MicroStation (*.dgn)"
                    cbMuiChieu.Items.Add("Chọn Hệ tọa độ của tập tin *.DGN")
                    For i As Integer = 0 To TenHeTD.Split(";").Length - 4
                        cbMuiChieu.Items.Add(TenHeTD.Split(";")(i))
                    Next
                    cbMuiChieu.SelectedIndex = 0
                    lbChonMS.Left = chebOpenMS.Left + chebOpenMS.Width - 5
                    lbChon3Dbd.Left = chebOpen3Dbd.Left + chebOpen3Dbd.Width - 5
                ElseIf mPanel.Name = "panelKhung" Then
                    XoaKhung(sgworldMain, "Khung")
                    LbTieude.Text = "  Tạo khung Văn kiện tác chiến." & Space(60 - LbTieude.Text.Length)
                    If Bd3D = False Then
                        Dim k1 As IPosition71 = sgworldMain.Navigate.GetPosition(AltitudeTypeCode.ATC_TERRAIN_RELATIVE)
                        k1.Distance = 60000
                        sgworldMain.Command.Execute(1054, 0)
                        sgworldMain.Navigate.JumpTo(k1)
                    End If
                    TxtTenKH.Text = "Khung"
                ElseIf mPanel.Name = "panelTrinhbay1" Then
                    LbTieude.Text = "  Trình bày Văn kiện tác chiến." & Space(100 - LbTieude.Text.Length)
                    XoaKhung(sgworldMain, "Trinh bay")

                ElseIf mPanel.Name = "panelLAN" Then
                    CloseAllTool()
                    liDTVKTC.Items.Clear()
                    SpanelLAN()
                ElseIf mPanel.Name = "panelVungHL" Then
                    LbTieude.Text = mota & Space(60 - LbTieude.Text.Length)
                ElseIf mPanel.Name = "panelCCDoitoado1" Then
                    LbTieude.Text = "Xử lý các tập tin MicroStation." & Space(60 - LbTieude.Text.Length)
                    cbHetoadocu.Items.Add("Chọn Hệ tọa độ cũ của tập tin *.DGN")
                    cbHetoadomoi.Items.Add("Chọn Hệ tọa độ mới của tập tin *.DGN")
                    For i As Integer = 0 To TenHeTD.Split(";").Length - 1
                        cbHetoadocu.Items.Add(TenHeTD.Split(";")(i))
                        cbHetoadomoi.Items.Add(TenHeTD.Split(";")(i))
                    Next
                    cbHetoadocu.SelectedIndex = 0
                    cbHetoadomoi.SelectedIndex = 0
                    chebChuyenToado.Checked = False
                    lbMs.Text = ""
                End If
                '  AddHandler mPanel.DoubleClick, AddressOf mPanel_MouseDoubleClick
            Else
                LbTieude.Dispose()
                If mPanel.Name = "panelKHthuongdung" Then
                    btnSaveCCKHTD.Enabled = False
                ElseIf mPanel.Name = "panelOpenVKTC" Then
                    lbChonFlyChinh.Text = "Chọn tập tin Văn kiện tác chiến chính (*.fly)"
                    'ElseIf mPanel.Name = "panelLAN" Then
                    '    sock.Client.Shutdown(SocketShutdown.Both)
                    ' DinhviBDT()
                End If
            End If

        Catch eX As Exception
            '   Exit Sub
        End Try
    End Sub

    Function NumberLine() As Integer
        Try
            Dim lines() As String = IO.File.ReadAllLines(PathData & "\config.ini")
            Dim sodong As Integer = lines.Count
            Dim mCao As Integer
            If (sodong Mod 9 = 0) Then
                mCao = 32 * sodong / 9
            Else
                mCao = (32 * sodong / 9) + 72
            End If
            NumberLine = mCao
        Catch
        End Try
    End Function

    Private Sub SpanelLAN()
        Try
            Me.networkConnection = New NetworkCommunication(Me.networkPort)
            AddHandler Me.networkConnection.ConnectedClient, AddressOf NetworkConnected
            AddHandler Me.networkConnection.IncomedMessage, AddressOf NetworkIncomedMessage
            LbTieude.Text = "  LAN - " & System.Environment.MachineName.ToString & "; " & Me.networkConnection.GetCurrentIP().ToString & Space(100 - LbTieude.Text.Length)
            txtServerIP.Text = Me.networkConnection.GetCurrentIP().ToString
        Catch
        End Try
    End Sub


    'Private Sub TxtTenFileTrC_TextChanged(sender As Object, e As EventArgs) Handles txtTenFileTrC.TextChanged
    '    If txtTenFileTrC.Text = "" Then
    '        BtnXuatVL.Text = "Mở Tập tin trình chiếu"
    '        'pnTrinhchieu.Visible = False
    '    Else
    '        BtnXuatVL.Text = "Xuất Sa bàn vật lý"
    '    End If
    'End Sub

    Private Sub Txt1000Km_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt1000Km.KeyPress
        Import_KeyPress(e, Chr(44))
    End Sub

    Private Sub TxtKinhtuyentruc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKinhtuyentruc.KeyPress
        Import_KeyPress(e, Chr(44))
    End Sub

    Private Sub TxtToado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtToado.KeyPress
        Import_KeyPress(e, Chr(44))
    End Sub
#End Region

#Region " Menu Click"

    Private Sub MnuAnh_DGN_Click(sender As Object, e As EventArgs) Handles mnuAnh_DGN.Click
        Try
            OpenFileDialog1.Title = "Tập tin *.tif"
            OpenFileDialog1.Multiselect = True
            OpenFileDialog1.Filter = "Tập tin *.tif (*.tif)|*.tif"
            OpenFileDialog1.ShowDialog()
            Dim FilesAttach As String() = OpenFileDialog1.FileNames
            For i As Integer = 0 To FilesAttach.Length - 1
                MS.CadInputQueue.SendKeyin("RASTER ATTACH " & FilesAttach(i) & "; execute")
            Next
        Catch
        End Try
    End Sub

    Private Sub MnuReferenceFile_Click(sender As Object, e As EventArgs) Handles mnuReferenceFile.Click
        Try
            OpenFileDialog1.Title = "Tập tin *.dgn"
            OpenFileDialog1.Multiselect = True
            OpenFileDialog1.Filter = "Tập tin *.dgn (*.dgn)|*.dgn"
            OpenFileDialog1.ShowDialog()
            Dim FilesAttach As String() = OpenFileDialog1.FileNames
            For i As Integer = 0 To FilesAttach.Length - 1
                MS.CadInputQueue.SendKeyin("REFERENCE ATTACH " & FilesAttach(i) & ", , , ,*)")
            Next
            ' REFColor()
        Catch
        End Try
    End Sub

    Private Sub MnuClose_Click(sender As Object, e As EventArgs)
        Try
            CloseAllTool()
            CloseAllPanel()
            CloseVKTC()
            AxTE3DWindow1.Visible = False
            mnuKHQS.Enabled = False
            mnuLuachon.Enabled = False
            mnuTienich.Enabled = False
            mnuSaveAs.Enabled = False
            ChebBangDT.Checked = False
            mnuOpenFly.Enabled = True
            mnuNew.Enabled = True
            mnuMicrostationData.Enabled = True
            '/////////////
            menuMain.Items.RemoveAt(6)
            menuMain.Items.Remove(LbTenFile)
            MenuClose.Items.Remove(LbToadoM)
            'MenuClose.Items.Remove(LbMaychinh)
        Catch
        End Try
    End Sub

    Private Sub MnuNew_Click(sender As Object, e As EventArgs) Handles mnuNew.Click
        Try
            'MReg()
            sgworldMain.Command.Execute(1002, 0) 'New
            sgworldMain.Command.Execute(1004, 0)
            sgworldMain.Project.Close()
            AxTE3DWindow1.Visible = False
        Catch
        End Try
    End Sub

    Private Sub MnuOpenFly_Click(sender As Object, e As EventArgs) Handles mnuOpenFly.Click
        Try
            MReg()
            SPanel(panelOpenVKTC)
        Catch
        End Try
    End Sub

    Private Sub MnuCloseSkyline_Click(sender As Object, e As EventArgs) Handles MnuCloseSkyline.Click
        Try
            PllVtNum = 0
            sgworldMain.Project.Close()
            AxTE3DWindow1.Visible = False
            AxTEInformationWindow1.Visible = False
            mnuKHQS.Enabled = False
            mnuLuachon.Enabled = False
            mnuTienich.Enabled = False
            mnuOpenFly.Enabled = True
            mnuSaveAs.Enabled = False
            menuMain.Items.RemoveAt(6)
            menuMain.Items.RemoveAt(6)
            MenuClose.Items.RemoveAt(3)

            MnuCloseSkyline.Enabled = False
            FrmTC.Instance.FRMS = False
            RMSBS = False
        Catch
        End Try
    End Sub

    Private Sub MnuDong_Click(sender As Object, e As EventArgs)
        Try
            ResetLogin()
            Me.Close()
            FrmSBVLM.Instance.Khoa_3Dmap(0)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ResetLogin()
        Try
            FrmSBVLM.Instance.GhiSettings("Tat3DmapTP")
            'FrmTC.Instance.Close()
            'FrmTC.Instance.FRMS = False
            'RMSBS = False
        Catch
        End Try
    End Sub
    Private Sub MenuClose_SizeChanged(sender As Object, e As EventArgs) Handles MenuClose.SizeChanged
        Try
            MenuClose.Location = New Point(Me.Width - (MenuClose.Width + 1), 0)
        Catch
        End Try
    End Sub

    Private Sub MnuMini_Click(sender As Object, e As EventArgs) Handles mnuMini.Click
        Try
            Me.WindowState = FormWindowState.Minimized
        Catch
        End Try
    End Sub

    Private Sub MnuMax_Click(sender As Object, e As EventArgs) Handles mnuMax.Click
        Try
            CloseAllTool()
            CloseAllPanel()
            Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
        Catch
        End Try
    End Sub

    Private Sub MnuMicrostationData_Click(sender As Object, e As EventArgs) Handles mnuMicrostationData.Click
        Try
            CopyUserConfig(PathData & "\RSC\dfltuser.cfg")
            SPanel(panelCCDoitoado1)
        Catch
        End Try
    End Sub

    Private Sub MnuSaveAs_Click(sender As Object, e As EventArgs) Handles mnuSaveAs.Click
        Try
            sgworldMain.Project.Save()
            sgworldMain.Command.Execute(1004, 0)
            If Bd3D = True Then
                sgworld3DBd.Project.Save()
                sgworld3DBd.Command.Execute(1004, 0)
            End If

            If A3D = True Then
                sgworld3DA.Project.Save()
                sgworld3DA.Command.Execute(1004, 0)
            End If

            If mMicrostation = True Then
                SaveFileDialog1.ShowDialog()
                MS.ActiveDesignFile.SaveAs(SaveFileDialog1.FileName, True)
            End If
        Catch
        End Try
    End Sub

    Private Sub MnuBB_Click(sender As Object, e As EventArgs) Handles mnuBB.Click
        MToolstrip(ToolBB, "Sở Chỉ huy, Vị trí Chỉ huy", -24, 30)
    End Sub

    Private Sub MnuHDTC_Click(sender As Object, e As EventArgs) Handles mnuHDTC.Click
        MToolstrip(ToolHDTC, "Vũ khí, Công sự TĐ, Hành động tác chiến", 41, 2)
    End Sub

    Private Sub MnuQuanbaoTrinhsat_Click(sender As Object, e As EventArgs) Handles mnuQuanbaoTrinhsat.Click
        MToolstrip(ToolQBTS, "Trinh sát, Quân báo", 44, 36)
    End Sub

    Private Sub MnuDC_Click(sender As Object, e As EventArgs) Handles mnuDC.Click
        MToolstrip(ToolDC, "Đặc công", 57, 54)
    End Sub

    Private Sub MnuTTG_Click(sender As Object, e As EventArgs) Handles mnuTTG.Click
        MToolstrip(ToolTTG, "Tăng, Thiết giáp", 60, 44)
    End Sub

    Private Sub MnuPB_Click(sender As Object, e As EventArgs) Handles mnuPB.Click
        MToolstrip(ToolPB, "Pháo binh", 0, 52)
    End Sub

    Private Sub MnuCB_Click(sender As Object, e As EventArgs) Handles mnuCB.Click
        MToolstrip(ToolCB, "Công binh", -50, 52)
    End Sub

    Private Sub MnuTTLL_Click(sender As Object, e As EventArgs) Handles mnuTTLL.Click
        MToolstrip(ToolTTLL, "Thông tin liên lạc", -72, 42)
    End Sub

    Private Sub MnuHH_Click(sender As Object, e As EventArgs) Handles mnuHH.Click
        MToolstrip(ToolHH, "Hóa học", -2, 56)
    End Sub

    Private Sub MnuTCDT_Click(sender As Object, e As EventArgs) Handles mnuTCDT.Click
        MToolstrip(ToolTCDT, "Tác chiến điện tử", 12, 42)
    End Sub

    Private Sub MnuTcKGMang_Click(sender As Object, e As EventArgs) Handles mnuTcKGMang.Click
        MToolstrip(ToolKGM, "Tác chiến không gian mạng", -50, 24)
    End Sub

    Private Sub MnuCoyeu_Click(sender As Object, e As EventArgs) Handles mnuCoyeu.Click
        MToolstrip(ToolCY, "Cơ yếu", 60, 58)
    End Sub

    Private Sub MnuPKKQ_Click(sender As Object, e As EventArgs) Handles mnuPKKQ.Click
        MToolstrip(toolPK, "Phòng không, Không quân", -45, 26)
    End Sub

    Private Sub MnuHQ_Click(sender As Object, e As EventArgs) Handles mnuHQ.Click
        MToolstrip(ToolHQ, "Hải quân", -19, 54)
    End Sub

    Private Sub MnuBP_Click(sender As Object, e As EventArgs) Handles mnuBP.Click
        MToolstrip(ToolBP, "Biên phòng", -3, 50)
    End Sub

    Private Sub MnuLLVTDP_Click(sender As Object, e As EventArgs) Handles mnuLLVTDP.Click
        MToolstrip(ToolLLVTDP, "Lực lượng Vũ trang địa phương", 40, 20)
    End Sub

    Private Sub MnuDBDV_Click(sender As Object, e As EventArgs) Handles mnuDBDV.Click
        MToolstrip(ToolDBDV, "Dự bị động viên", 87, 44)
    End Sub

    Private Sub MnuBLLD_Click(sender As Object, e As EventArgs) Handles mnuBLLD.Click
        MToolstrip(ToolBLLD, "Bạo loạn lật đổ", 35, 44)
    End Sub

    Private Sub MnuTuyenTruyen_Click(sender As Object, e As EventArgs) Handles mnuTuyenTruyen.Click
        MToolstrip(ToolTTruyen, "Tuyên truyền đặc biệt", 100, 34)
    End Sub

    Private Sub MnuCuuhoCuunan_Click(sender As Object, e As EventArgs) Handles mnuCuuhoCuunan.Click
        MToolstrip(ToolCH, "Cứu hộ - Cứu nạn", 40, 40)
    End Sub

    Private Sub MnuHC_Click(sender As Object, e As EventArgs) Handles mnuHC.Click
        MToolstrip(ToolHC, "Hậu cần", -33, 56)
    End Sub

    Private Sub MnuKythuat_Click(sender As Object, e As EventArgs) Handles mnuKythuat.Click
        MToolstrip(ToolKT, "Kỹ thuật", 37, 56)
    End Sub

    Private Sub MnuMH_Click(sender As Object, e As EventArgs) Handles mnuMH.Click
        MToolstrip(ToolMH, "Mô hình 3D", 46, 50)
    End Sub

    Private Sub MnuDTDohoa_Click(sender As Object, e As EventArgs) Handles mnuDTDohoa.Click
        MToolstrip(ToolTI1, "Các đối tượng cơ bản", 198, 34)
    End Sub

    Private Sub MnuSuaDT_Click(sender As Object, e As EventArgs) Handles mnuSuaDT.Click
        MToolstrip(toolSuachua, "Sửa Đối tượng", 52, 46)
    End Sub

    Private Sub MnuPDF_Click(sender As Object, e As EventArgs) Handles mnuPDF.Click
        Try
            Lenhve = "pdf"
            TrinhbayVK()
        Catch
        End Try
    End Sub

    Private Sub TlPDF_Click(sender As Object, e As EventArgs)
        Try
            Lenhve = "pdf"
            D23timer.Start()
            D23timer.Interval = 100
            lenhveMS = Lenhve
        Catch
        End Try
    End Sub

    Private Sub MnuGotoPoint_Click(sender As Object, e As EventArgs) Handles mnuGotoPoint.Click
        SPanel(panelGotoPoint)
    End Sub

    Private Sub MnuKyhieuthuongdung_Click(sender As Object, e As EventArgs) Handles mnuKyhieuthuongdung.Click
        SPanel(panelKHthuongdung)
    End Sub

    Private Sub MnuTaoKB_Click(sender As Object, e As EventArgs) Handles mnuTaoKB.Click
        SPanel(panelTaoKichban)
    End Sub

    Private Sub MnuTrinhchieu_Click(sender As Object, e As EventArgs) Handles mnuTrinhchieu.Click
        BangKichBan.kichbanSBS()
        FrmSBVLM.Instance.trangkichban1()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TrinhchieuPN()
    End Sub
    Private Sub MnuTrogiup_Click(sender As Object, e As EventArgs) Handles mnuTrogiup.Click
        'Help1()
        ' SendImage()

        ' SendImage(Image.FromFile("C:\3D\vktc.jpg"))
        '  Tobase64()
        Dim filePath As String = Path.Combine(folderPath1, "Hướng dẫn sử dụng phần mềm 3Dmap_XLA.pdf")
        If File.Exists(filePath) Then
            Process.Start(filePath)
        Else
            MessageBox.Show("Không tìm thấy tệp PDF!")
        End If
    End Sub

    Private Phim As IPresentation71
    Private Sub MnEnd_Click(sender As Object, e As EventArgs)
        Try
            Phim.StopRecord()
        Catch ex As Exception
            GoTo phim
        End Try
phim:
        sgworldMain.Command.Execute(1116, 0)
        sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("114"))
    End Sub

    Private Sub MnStart_Click(sender As Object, e As EventArgs)
        Try
            CloseAllTool()
            CloseAllPanel()
            Phim = sgworldMain.Creator.CreatePresentation("", "114")
            System.Threading.Thread.Sleep(10)
            sgworldMain.ProjectTree.SelectItem(sgworldMain.ProjectTree.FindItem("114"))
            Phim.StartRecord()
        Catch
        End Try
    End Sub

    Private Sub MnuMang_Click(sender As Object, e As EventArgs) Handles mnuMang.Click
        SPanel(panelLAN)
    End Sub

    Private Sub MnuQuetDT_Click(sender As Object, e As EventArgs) Handles mnuQuetDT.Click
        Try
            ScanGroup()
            sgworldMain.Project.Save()
            If FrmTC.Instance.FRMS = True Then
                FrmTC.Instance.Open3DBD1()
            End If
        Catch
        End Try
    End Sub

#End Region

    Private Sub Help1()
        Try
            Dim HelpProvider As New HelpProvider With {.HelpNamespace = PathData & "\Huong dan su dung Dimap3D.chm"}
            Help.ShowHelp(Me, HelpProvider.HelpNamespace)
        Catch
        End Try
    End Sub

#End Region
#Region "Panel Ky hieu thuong dung"
    Private Sub ChebTheoNhomKHTD_CheckedChanged(sender As Object, e As EventArgs) Handles chebTheoNhomKHTD.CheckedChanged
        Try
            If chebTheoNhomKHTD.Checked = True Then
                txtKHThuongdung.Enabled = False
                Dim k0 As String = sgworldMain.ProjectTree.GetNextItem("", ItemCode.SELECTED)
                txtKHThuongdung.Text = CheckTheonhom(k0, chebTheoNhomKHTD) ' sgworldMain.ProjectTree.GetItemName(k0)
            Else
                txtKHThuongdung.Enabled = True
                txtKHThuongdung.Text = ""
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ToolKHTD_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles toolKHTD.ItemClicked
        Try
            Dim ChuoiIten As String = String.Empty, Chuoi As String
            Dim tenItem As String = e.ClickedItem.Name
            Dim mIndex As Integer = 0
            For i As Integer = 0 To libAddToolKHTD.Items.Count - 1
                Chuoi = libAddToolKHTD.Items.Item(i).ToString
                If Chuoi.Split(";")(1) & "1" = tenItem Then
                    ChuoiIten = Chuoi
                    mIndex = i
                End If
            Next
            If chebXoaCC.Checked = False Then
                If txtKHThuongdung.Text = "" Then
                    MouseHook1.Dispose()
                    txtKHThuongdung.BackColor = Color.GreenYellow
                    MsgBox("Hãy nhập tên ký hiệu...", MsgBoxStyle.Critical, "Chú ý...")
                    txtKHThuongdung.BackColor = Color.White
                    Lenhve = ""
                    Lenhsua = ""
                    Lenhve2 = ""
                    Exit Sub
                Else
                    If chebTheoNhomKHTD.Checked = True Then
                        SetMouseArrow()
                        MPathTQ()
                        GroupBac2Main = Gr03(sgworldMain, pathTQ.Split("\")(0), pathTQ.Split("\")(1), txtKHThuongdung.Text)
                        textKH = txtKHThuongdung.Text
                    Else
                        ChebTQ(txtKHThuongdung.Text, chebTheoNhomKHTD)
                    End If
                End If

                Lenhve = ChuoiIten.Split(";")(2)
                loaiKH = ChuoiIten.Split(";")(3)
            Else
                Select Case MessageBox.Show("Bạn muốn xóa công cụ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case System.Windows.Forms.DialogResult.OK
                        toolKHTD.Items.RemoveByKey(tenItem)
                        toolKHTD.Update()
                        libAddToolKHTD.Items.RemoveAt(mIndex)
                        btnSaveCCKHTD.Enabled = True
                        chebXoaCC.Checked = False
                    Case System.Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        Catch
        End Try
    End Sub

    Private Sub SAddToolStripItem(cToolstrip As ToolStrip, nameItem As String)
        Try
            If panelKHthuongdung.Visible = False Then
                Exit Sub
            Else
                Dim mTenTool As String = nameItem & "1"
                Dim listKHTD As String
                Dim tens As New List(Of String)
                For i As Integer = 0 To toolKHTD.Items.Count - 1
                    Dim ten As String = toolKHTD.Items.Item(i).Name
                    tens.Add(ten)
                Next
                If tens.Contains(mTenTool) = True Then
                    MsgBox("Công cụ này đã có!....")
                    Exit Sub
                Else
                    Dim item As ToolStripItem = New ToolStripButton() With {.DisplayStyle = ToolStripItemDisplayStyle.Image, .ImageScaling = ToolStripItemImageScaling.None, .ToolTipText = mota}
                    For Each c As ToolStripItem In cToolstrip.Items
                        If c.Name.Contains(nameItem) Then
                            If c.GetType Is GetType(ToolStripButton) Then
                                Dim cToolStripButton As ToolStripButton = DirectCast(c, ToolStripButton)
                                item.Image = cToolStripButton.Image
                                ' item.ToolTipText =
                            End If
                        End If
                    Next
                    item.AutoSize = False
                    item.Size = New Size(32, 32)
                    item.Name = nameItem & "1"
                    toolKHTD.Items.Add(item)
                    toolKHTD.Update()
                    listKHTD = cToolstrip.Name & ";" & nameItem & ";" & Lenhve & ";" & loaiKH & ";" & mota
                    libAddToolKHTD.Items.Add(listKHTD)
                    btnSaveCCKHTD.Enabled = True
                    libAddToolKHTD.Update()
                    Lenhve = ""
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub SAddTexttoListBox()
        Try
            Dim lines() As String = IO.File.ReadAllLines(PathData & "\config.ini")
            libAddToolKHTD.Items.AddRange(lines)
            SAddListBoxtoToolStrip()
        Catch
        End Try
    End Sub

    Private Sub SAddListBoxtoToolStrip()
        Try
            For i As Integer = 0 To libAddToolKHTD.Items.Count - 1
                Dim cToolstrip As ToolStrip = Me.Controls.Find(libAddToolKHTD.Items.Item(i).Split(";")(0), True).FirstOrDefault()
                For Each c As ToolStripItem In cToolstrip.Items
                    If c.Name.Contains(libAddToolKHTD.Items.Item(i).Split(";")(1)) Then
                        If c.GetType Is GetType(ToolStripButton) Then
                            Dim item As ToolStripItem = New ToolStripButton() With {.DisplayStyle = ToolStripItemDisplayStyle.Image, .ImageScaling = ToolStripItemImageScaling.None, .AutoSize = False, .Size = New Size(32, 32), .ToolTipText = libAddToolKHTD.Items.Item(i).Split(";")(4)}
                            Dim tbCast As ToolStripButton = DirectCast(c, ToolStripButton)
                            item.Image = tbCast.Image
                            item.Name = libAddToolKHTD.Items.Item(i).Split(";")(1) & "1"
                            toolKHTD.Items.Add(item)
                            toolKHTD.Update()
                        End If
                    Else
                        'c.Enabled = False
                    End If
                Next
            Next
        Catch
        End Try
    End Sub

    Private Sub BtnSaveToolstripButton_Click(sender As Object, e As EventArgs) Handles btnSaveCCKHTD.Click
        Try
            Dim ALPHAVAL As String = PathData & "\config.ini"
            Using SW As New IO.StreamWriter(ALPHAVAL, False)
                For Each itm As String In Me.libAddToolKHTD.Items
                    SW.WriteLine(itm)
                Next
            End Using
            panelKHthuongdung.Visible = False
            btnSaveCCKHTD.Enabled = False
        Catch
        End Try
    End Sub

    Private Sub ToolKHTD_SizeChanged(sender As Object, e As EventArgs) Handles toolKHTD.SizeChanged
        Try
            panelKHthuongdung.Height = btnSaveCCKHTD.Top + btnSaveCCKHTD.Height + toolKHTD.Height + 6
        Catch
        End Try
    End Sub

#End Region
#Region "   Xu ly DGN"

    Private Sub BtnDoitoado_Click(sender As Object, e As EventArgs) Handles btnDoitoado.Click
        Try
            btnChonFileMs.Visible = False
            LbTieude.Text = "Xử lý các tập tin MicroStation." & "..đang thực hiện...                         " '& Space(10 - LbTieude.Text.Length)
            Dim oAL As ApplicationObjectConnector
            oAL = New ApplicationObjectConnector
            MS = oAL.Application
            MS.Visible = True
            MS.Width = 15
            MS.Height = 15
            MS.TopPosition = My.Computer.Screen.WorkingArea.Height + 100
            MS.LeftPosition = My.Computer.Screen.WorkingArea.Width + 100 '
            Dim dgnNameS() As String = OpenFileDialog1.FileNames
            For i As Integer = 0 To dgnNameS.Length - 1
                MS.OpenDesignFile(dgnNameS(i), False, MsdV7Action.msdV7ActionUpgradeToV8)
                MS.CadInputQueue.SendKeyin("ct= " & PathData & "\RSC\2D3D.tbl")
                MS.CadInputQueue.SendKeyin("reference detach all")
                MS.CadInputQueue.SendKeyin("DELETE UNUSED LEVELS")
                MS.CadInputQueue.SendCommand("fit view extended")
                MS.CadInputQueue.SendCommand("Save Settings")
                MS.CommandState.StartDefaultCommand()
                If chebChuyenToado.Checked = True Then
                    MS.CadInputQueue.SendKeyin("geocoordinate assign " & ChonHTD(cbHetoadocu))
                    MS.CadInputQueue.SendKeyin("geocoordinate assign reproject " & ChonHTD(cbHetoadomoi))
                End If
                MS.ActiveDesignFile.Close()
                'If i = dgnNameS.Length - 2 Then
                '    LbTieude.Text = "Xử lý các tập tin MicroStation." & "...chuẩn bị xong...                             " '& Space(10 - LbTieude.Text.Length)
                'End If
                If i = dgnNameS.Length - 1 Then
                    Dim MSProcesses As Process() = Process.GetProcessesByName("ustation")
                    Array.ForEach(MSProcesses, Sub(p As Process) p.Kill())
                    System.Threading.Thread.Sleep(5000)
                    btnChonFileMs.Visible = True
                    lbMs.Text = ""
                    panelCCDoitoado1.Visible = False
                    XoaMs()
                End If
            Next
        Catch
        End Try
    End Sub

    Function ChonHTD(comBo As ComboBox) As String
        Try
            Dim mHetoado As String = String.Empty
            Select Case comBo.SelectedIndex
                Case 1
                    mHetoado = "vn2000 3d 99"
                Case 2
                    mHetoado = "vn2000 3d 102"
                Case 3
                    mHetoado = "vn2000 3d 105"
                Case 4
                    mHetoado = "vn2000 3d 108"
                Case 5
                    mHetoado = "vn2000 3d 111"
                Case 6
                    mHetoado = "vn2000 6d KT99"
                Case 7
                    mHetoado = "vn2000 6d KT105"
                Case 8
                    mHetoado = "vn2000 6d KT111"
                Case 9
                    mHetoado = "WGS 84"
                Case 10
                    mHetoado = "HN72-47"
                Case 11
                    mHetoado = "HN72-48"
                Case 12
                    mHetoado = "HN72-49"
            End Select
            ChonHTD = mHetoado
        Catch
        End Try
    End Function

    Private Sub SMicroStation(tenLevel As String, mPriority As Integer)
        Try
            MS.CadInputQueue.SendKeyin("Level set priority " & mPriority.ToString & " level-spec Level " & tenLevel)
        Catch
        End Try
    End Sub

    Private Sub CbHetoadomoi_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHetoadomoi.SelectedIndexChanged
        Try
            If cbHetoadocu.SelectedIndex > 0 Then
                btnDoitoado.Enabled = True
            Else
                btnDoitoado.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub LbMs_TextChanged(sender As Object, e As EventArgs) Handles lbMs.TextChanged
        Try
            If lbMs.Text = "" Then
                btnDoitoado.Enabled = False
            Else
                btnDoitoado.Enabled = True
            End If
        Catch
        End Try
    End Sub

    Private Sub ChebChuyenToado_CheckedChanged(sender As Object, e As EventArgs) Handles chebChuyenToado.CheckedChanged
        Try
            If chebChuyenToado.Checked = True Then
                Label5.Enabled = True
                Label32.Enabled = True
                cbHetoadocu.Enabled = True
                cbHetoadomoi.Enabled = True
            Else
                Label5.Enabled = False
                Label32.Enabled = False
                cbHetoadocu.Enabled = False
                cbHetoadomoi.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnChonFileMs_Click(sender As Object, e As EventArgs) Handles btnChonFileMs.Click
        Try
            OpenFileDialog1.Multiselect = True
            OpenFileDialog1.Title = "Mở các tập tin *.dgn"
            OpenFileDialog1.Filter = "Tập tin *.dgn (*.dgn)|*.dgn|Tất cả (*.*)|*.*"
            OpenFileDialog1.ShowDialog()
            lbMs.Text = OpenFileDialog1.FileName
        Catch
        End Try
    End Sub
#End Region
#Region "  Tao kich ban"

    Private Sub CbHuDTchuyendong_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbHuDTchuyendong.SelectedIndexChanged
        Try
            If cbHuDTchuyendong.SelectedIndex = 3 Then
                cbHuongDBDK.Enabled = True
            Else
                cbHuongDBDK.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtEmpty()
        Try
            txtTencanh.Text = ""
            TextBox2.Text = ""
            txtDTNhapnhay.Text = ""
            txtMTCD.Text = ""
            txtDTChuyendong1.Text = ""
            txtDTAn.Text = ""
            txtPhim.Text = ""
            txtBaocao.Text = ""
            txtDTQuay.Text = ""
        Catch
        End Try
    End Sub

    Private Sub Btn_taotrinhchieu_Click(sender As Object, e As EventArgs) Handles btn_taotrinhchieu.Click
        Try
            TaoTrinhchieu()
            TxtEmpty()
        Catch
        End Try
    End Sub

    Private Sub Btn_Suatrinhchieu_Click(sender As Object, e As EventArgs) Handles btn_Suatrinhchieu.Click
        OpenFileTrC(1)
    End Sub
    Private Sub Btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        Try
            Dim LuuFile As New SaveFileDialog With {.Filter = "Tập tin Text (*txt) | *.txt"}
            If LuuFile.ShowDialog() = DialogResult.OK Then
                Using SW As New IO.StreamWriter(LuuFile.FileName, True)
                    For Each itm As String In Me.liBDanhsachTrC2.Items
                        SW.WriteLine(Encrypt(itm, PassKey))
                    Next
                End Using
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LibDanhsachTrC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles libDanhsachTrC.SelectedIndexChanged
        Try
            If libDanhsachTrC.SelectedIndex >= 0 Then
                btn_save.Enabled = True
                SubSeletCanh()
            End If
            SelectListBox1()
        Catch
        End Try
    End Sub

    Public Sub SelectListBox1()
        Try
            For i As Integer = 0 To libDanhsachTrC.Items.Count - 1
                If libDanhsachTrC.GetSelected(i) Then
                    liBDanhsachTrC2.SetSelected(i, True)
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Try
            TopHieuung()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Btn_Xoacanh_Click(sender As Object, e As EventArgs) Handles btn_Xoacanh.Click
        Try
            libDanhsachTrC.Items.RemoveAt(libDanhsachTrC.SelectedIndex)
            liBDanhsachTrC2.Items.RemoveAt(liBDanhsachTrC2.SelectedIndex)
        Catch
        End Try
    End Sub

    Private Sub Btn_Chaythu_Click(sender As Object, e As EventArgs) Handles btn_Chaythu.Click
        TopHieuung()
        Try
            MTChuyendong(dongTrinhchieu.Split(";")(2))
            MTChuyendong1(dongTrinhchieu.Split(";")(2))
            FlytoPoint()
            Nhapnhay()
            ObjectHide()
            DinamicObject()
            HuMohinh()
            MTunhien()
            Baocao()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LiBDanhsachTrC2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles liBDanhsachTrC2.SelectedIndexChanged
        Try
            For i As Integer = 0 To liBDanhsachTrC2.Items.Count - 1
                If liBDanhsachTrC2.GetSelected(i) Then
                    dongTrinhchieu = liBDanhsachTrC2.Text
                    '  bienNDTrinhchieu = dongTrinhchieu.Split(";")
                    txtTencanh.Text = dongTrinhchieu.Split(";")(0).Split(",")(0)  'Canh trinh chieu
                    TextBox2.Text = dongTrinhchieu.Split(";")(1) 'Toa do trinh chieu
                    txtMTCD.Text = dongTrinhchieu.Split(";")(2)
                    txtDTNhapnhay.Text = dongTrinhchieu.Split(";")(3)  'Doi tuong nhap nhay
                    txtDTAn.Text = dongTrinhchieu.Split(";")(4) 'DT an
                    txtDTChuyendong1.Text = dongTrinhchieu.Split(";")(5)  'DT chuyen dong
                    txtPhim.Text = dongTrinhchieu.Split(";")(6).Split("_")(0) 'DT Mutimedia  
                    txtDTQuay.Text = dongTrinhchieu.Split(";")(7)
                    txtBaocao.Text = dongTrinhchieu.Split(";")(8)
                    'Moi
                    If dongTrinhchieu.Split(";")(0).Split(".")(1) <> "" Then
                        cbHieuungCanh1.SelectedIndex = Val(dongTrinhchieu.Split(";")(0).Split(".")(1))
                    Else
                        cbHieuungCanh1.SelectedIndex = 0
                    End If
                    If dongTrinhchieu.Split(";")(5) <> "" Then
                        cbPhimAmthanh.SelectedIndex = Val(dongTrinhchieu.Split(";")(5).Split("_")(1))
                    Else
                        cbPhimAmthanh.SelectedIndex = 0
                    End If
                    If dongTrinhchieu.Split(";")(6) <> "" Then
                        If Not cbHuDTchuyendong.SelectedIndex = 3 Then
                            cbHuDTchuyendong.SelectedIndex = 0
                        End If
                    Else

                    End If
                    If dongTrinhchieu.Split(";")(8) <> "" Then
                        txtBaocao.Text = dongTrinhchieu.Split(";")(8)
                    End If
                    If dongTrinhchieu.Split(";")(7) <> "" Then
                        cbHuMH.SelectedIndex = Val(dongTrinhchieu.Split(";")(7).Split(".")(1))
                    Else
                        cbHuMH.SelectedIndex = 0
                    End If
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub Btn_SelectMedia_Click(sender As Object, e As EventArgs) Handles btn_SelectMedia.Click
        Try
            Select Case cbPhimAmthanh.SelectedIndex
                Case 0
                    OpenFileDialog1.Filter = "(avi,mp4)|*.avi;*.mp4|Tập tin Phim|*.*"
                    OpenFileDialog1.Title = "Tập tin Phim"
                    OpenFileDialog1.ShowDialog()
                    txtPhim.Text = OpenFileDialog1.FileName' fileVideo
                Case 1
                    OpenFileDialog1.Filter = "(mp3,wav|*.mp3;*.wav|Tập tin âm thanh|*.*"
                    OpenFileDialog1.Title = "Tập tin âm thanh"
                    OpenFileDialog1.ShowDialog()
                    txtPhim.Text = OpenFileDialog1.FileName' fileVideo
                Case 2
                    Lenhve = "phimdiahinh"
                    sgworldMain.Command.Execute(1070, 0)
            End Select
        Catch
        End Try
    End Sub

    Private Sub Btn_DTNN_Click(sender As Object, e As EventArgs) Handles btn_DTNN.Click
        Try
            Lenhve = "chonDTnhapnhay"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub BtnChonDTQuay_Click(sender As Object, e As EventArgs) Handles btnDTQuay.Click
        Try
            Lenhve = "radaquay"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub BtnDTan_Click(sender As Object, e As EventArgs) Handles btnDTan.Click
        Try
            Lenhve = "chonDTan"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub BtnDTChuyendong_Click(sender As Object, e As EventArgs) Handles btnDTChuyendong1.Click
        Try
            Lenhve = "chonDTchuyendong"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub Btn_MTCDong_Click(sender As Object, e As EventArgs) Handles btn_MTCDong.Click
        Try
            Lenhve = "chonMTchuyendong"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub SubSeletCanh()
        Try
            Dim i As Integer = libDanhsachTrC.SelectedIndex
            If libDanhsachTrC.GetSelected(i) = True Then
                btn_Chaythu.Enabled = True
                btn_Close.Enabled = True
                btn_Xoacanh.Enabled = True
                btnUp.Enabled = True
                btnDown.Enabled = True
            Else
                btn_Chaythu.Enabled = False
                btn_Close.Enabled = False
                btn_Xoacanh.Enabled = False
                btnUp.Enabled = False
                btnDown.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        UpdateSence(1)
    End Sub

    Private Sub BtnDown_Click(sender As Object, e As EventArgs) Handles btnDown.Click
        UpdateSence(-1)
    End Sub

    Private Sub UpdateSence(soTT As Integer)
        Try
            If libDanhsachTrC.SelectedIndex >= 1 Then
                Dim az As Integer = libDanhsachTrC.Items.IndexOf(libDanhsachTrC.SelectedItem)
                Dim strinput As String = libDanhsachTrC.SelectedItem.ToString
                Dim Item As Object = libDanhsachTrC.Items.Item(az)
                Dim index As Integer = libDanhsachTrC.Items.IndexOf(Item) + soTT
                libDanhsachTrC.Items.Remove(libDanhsachTrC.SelectedItem)
                libDanhsachTrC.Items.Insert(index, strinput)
                libDanhsachTrC.EndUpdate()

                Dim az1 As Integer = liBDanhsachTrC2.Items.IndexOf(liBDanhsachTrC2.SelectedItem)
                Dim strinput1 As String = liBDanhsachTrC2.SelectedItem.ToString
                Dim Item1 As Object = liBDanhsachTrC2.Items.Item(az)
                liBDanhsachTrC2.Items.Remove(liBDanhsachTrC2.SelectedItem)
                liBDanhsachTrC2.Items.Insert(index, strinput1)
                liBDanhsachTrC2.EndUpdate()
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtTencanh_TextChanged(sender As Object, e As EventArgs) Handles txtTencanh.TextChanged
        Try
            If txtTencanh.Text <> "" Then
                btn_taotrinhchieu.Enabled = True
            Else
                btn_taotrinhchieu.Enabled = False
            End If
        Catch
        End Try
    End Sub

#End Region
#Region "    Trinh chieu"
    Dim videoTrC As ITerrainVideo71 = Nothing
    Public Sub Multimedia()
        Try
            If dongTrinhchieu.Split(";")(5) = "" Then
                Exit Sub
            Else
                Dim BienDTPhim As String = dongTrinhchieu.Split(";")(5).Split("_")(0)
                If dongTrinhchieu.Split(";")(5).Split("_")(1) = "2" Then
                    videoTrC = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(BienDTPhim))
                    videoTrC.Visibility.Show = True
                    videoTrC.Volume = 100
                    videoTrC.PlayVideo()
                ElseIf dongTrinhchieu.Split(";")(5).Split("_")(1) = "1" Then
                    Audio(BienDTPhim)
                ElseIf dongTrinhchieu.Split(";")(5).Split("_")(1) = "0" Then
                    panelVideo.Width = 1 / 3 * My.Computer.Screen.WorkingArea.Width
                    panelVideo.Height = 0.4 * My.Computer.Screen.WorkingArea.Height
                    panelVideo.Top = 2
                    If dongTrinhchieu.Split(";")(5).Split("_")(2) = "0" Then
                        panelVideo.Left = 2
                    ElseIf dongTrinhchieu.Split(";")(5).Split("_")(2) = "1" Then
                        panelVideo.Left = My.Computer.Screen.WorkingArea.Width - (panelVideo.Width + 2)
                    End If
                    panelVideo.Visible = True
                End If
            End If
        Catch
        End Try
    End Sub

    Public Sub FlytoPoint()
        Dim Vitri2D() As String, Vitri3Dbd() As String = Enumerable.Empty(Of String).ToArray, Vitri3Da() As String = Enumerable.Empty(Of String).ToArray
        Try
            If Bd3D = False Then
                Vitri2D = dongTrinhchieu.Split(";")(1).Split(",")
            Else
                Vitri2D = dongTrinhchieu.Split(";")(1).Split("_")(0).Split(",")
                Vitri3Dbd = dongTrinhchieu.Split(";")(1).Split("_")(1).Split(",")
                If A3D = True Then
                    Vitri3Da = dongTrinhchieu.Split(";")(1).Split("_")(2).Split(",")
                End If
            End If
            Dim mP2D As IPosition71 = Nothing
            mP2D = sgworldMain.Creator.CreatePosition(Val(Vitri2D(0)), Val(Vitri2D(1)), Val(Vitri2D(2)), 2, Val(Vitri2D(3)), Val(Vitri2D(4)))
            If Bd3D = False Then
                sgworldMain.Navigate.JumpTo(mP2D)
                HuManhinh(sgworldMain, mP2D)
            Else
                sgworldMain.Navigate.JumpTo(mP2D)
                Dim mP3Dbd As IPosition71 = sgworld3DBd.Creator.CreatePosition(Val(Vitri3Dbd(0)), Val(Vitri3Dbd(1)), Val(Vitri3Dbd(2)), 2, Val(Vitri3Dbd(3)), Val(Vitri3Dbd(4)))
                sgworld3DBd.Navigate.JumpTo(mP3Dbd)
                HuManhinh(sgworld3DBd, mP3Dbd)
                If A3D = True Then
                    Dim mP3DA As IPosition71 = sgworld3DA.Creator.CreatePosition(Val(Vitri3Da(0)), Val(Vitri3Da(1)), Val(Vitri3Da(2)), 2, Val(Vitri3Da(3)), Val(Vitri3Da(4)))
                    sgworld3DA.Navigate.JumpTo(mP3DA)
                    HuManhinh(sgworld3DA, mP3DA)
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub HuManhinh(sgworldK As SGWorld71, mP2D As IPosition71)
        Try
            If mP2D Is Nothing Then
                Throw New ArgumentNullException(NameOf(mP2D))
            End If
            If Not dongTrinhchieu.Split(";")(0).Split(".")(1) = "" Then
                Select Case Val(dongTrinhchieu.Split(";")(0).Split(".")(1))
                    Case 0
                        sgworldK.Command.Execute(1057, 0)
                    Case 1
                        sgworldK.Command.Execute(1057, 1)
                End Select
            End If
        Catch
        End Try
    End Sub

    Public Sub ObjectHide() 'Hoan chinh
        Try
            If dongTrinhchieu.Split(";")(4) = "" Then
                Exit Sub
            Else
                Dim bienDTTat() As String = dongTrinhchieu.Split(";")(4).Split(",")
                For i As Integer = 0 To bienDTTat.Length - 1
                    If bienDTTat(i) <> "" Then
                        sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(bienDTTat(i)), False)
                        If Bd3D = True Then
                            sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(bienDTTat(i)), False)
                        End If
                        If A3D = True Then
                            sgworld3DA.ProjectTree.SetVisibility(sgworld3DA.ProjectTree.FindItem(bienDTTat(i)), False)
                        End If
                    Else
                        Exit Sub
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Public Sub AnDT(Path As String) 'Hoan chinh
        Try
            If Path = "" Then
                Exit Sub
            Else
                Dim bienDTTat() As String = Path.Split(",")
                For i As Integer = 0 To bienDTTat.Length - 1
                    ''   MsgBox(bienDTTat(i))
                    If bienDTTat(i) <> "" Then
                        sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(bienDTTat(i)), False)
                        If Bd3D = True Then
                            sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(bienDTTat(i)), False)
                        End If
                    Else
                        Exit Sub
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Public Sub HienDTan(Path As String) 'Hoan chinh
        Try
            If Path = "" Then
                Exit Sub
            Else
                Dim bienDTTat() As String = Path.Split(",")
                For i As Integer = 0 To bienDTTat.Length - 1
                    If bienDTTat(i) <> "" Then
                        sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(bienDTTat(i)), True)
                        If Bd3D = True Then
                            sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(bienDTTat(i)), True)
                        End If
                    Else
                        Exit Sub
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Public Sub DinamicObject()
        Try
            If dongTrinhchieu.Split(";")(6) = "" Then
                Exit Sub
            Else
                solan = 0
                timerDTCD = 0
                If dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then
                    DBDK(sgworldMain)
                    System.Threading.Thread.Sleep(200)
                End If
                Dim grDTchuyendong As String '= dongTrinhchieu.Split(";")(6).Split(".")(0)
                If dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then
                    grDTchuyendong = System.Environment.MachineName & "\TempTrC\DBDK"
                Else
                    grDTchuyendong = dongTrinhchieu.Split(";")(6).Split(".")(0)
                End If
                Dim huCanh3D As String = dongTrinhchieu.Split(";")(6).Split(".")(1)
                If Bd3D = False Then
                    DTChuyendong(sgworldMain, grDTchuyendong)
                Else
                    DTChuyendong(sgworldMain, grDTchuyendong)
                    DTChuyendong(sgworld3DBd, grDTchuyendong)
                    If A3D = True Then
                        DTChuyendong(sgworld3DA, grDTchuyendong)
                    End If
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub DTChuyendong(mSgworld As SGWorld71, grDTchuyendong As String)
        Try
            eCD.Clear()
            Dim k0 = mSgworld.ProjectTree.FindItem(grDTchuyendong)
            Dim k2 As ITerrainDynamicObject71 = Nothing
            Dim tenDT As String = String.Empty
            If (mSgworld.ProjectTree.IsGroup(k0)) Then
                k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                While Not (k0 = Nothing)
                    Dim obj = mSgworld.ProjectTree.GetObject(k0)
                    tenDT = sgworldMain.ProjectTree.GetItemName(obj.ID)
                    'MsgBox(tenDT)
                    If obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                        If dongTrinhchieu.Split(";")(6).Split(".")(1) = "2" Then 'Or dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then
                            eCD.Add(dongTrinhchieu.Split(";")(6).Split(".")(0) & "\" & tenDT)
                        ElseIf dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then
                            eCD.Add(System.Environment.MachineName & "\TempTrC\DBDK\DBDK1CQ1")
                            eCD.Add(System.Environment.MachineName & "\TempTrC\DBDK\DBDK1CQ2")
                        End If
                    ElseIf obj.ObjectType = ObjectTypeCode.OT_DYNAMIC Then
                        k2 = obj
                        k2.Position.Distance = 35000 * Tyle
                        k2.RestartRoute(0)
                        If dongTrinhchieu.Split(";")(6).Split(".")(2) <> "0" Then
                            mSgworld.Navigate.FlyTo(k2, Val(dongTrinhchieu.Split(";")(6).Split(".")(2)) + 5)
                            Console.WriteLine(Val(dongTrinhchieu.Split(";")(6).Split(".")(2)) + 5)
                        End If
                        If dongTrinhchieu.Split(";")(6).Split(".")(1) = "1" Then
                            eCD.Add(dongTrinhchieu.Split(";")(6).Split(".")(0) & "\" & tenDT)
                        End If
                    End If
                    k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                End While
            Else
            End If
            Dim k21 As String = PathData & "\Sounds\" & "00" & Trim(k2.Tooltip.Text.Split(":")(0).Split(",")(1)) & ".wav"
            My.Computer.Audio.Play(k21, AudioPlayMode.BackgroundLoop)
            If dongTrinhchieu.Split(";")(6).Split(".")(1) = "1" Or dongTrinhchieu.Split(";")(6).Split(".")(1) = "2" Or dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then
                DTCDTimer.Start()
                If dongTrinhchieu.Split(";")(6).Split(".")(1) = "2" Or dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then
                    DTCDTimer.Interval = 1
                Else
                    DTCDTimer.Interval = 1000
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub DBDK(mSgworld As SGWorld71) 'Tuyet
        Try
            If solan = 1 Then
                Exit Sub
            Else
                Dim KOBJ As ITerrainLabel71 = Nothing
                Dim k0 = mSgworld.ProjectTree.FindItem(dongTrinhchieu.Split(";")(6).Split(".")(0).Split("/")(0))
                If (mSgworld.ProjectTree.IsGroup(k0)) Then
                    k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                    While Not (k0 = Nothing)
                        Dim obj = mSgworld.ProjectTree.GetObject(k0)
                        If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                            KOBJ = obj
                            Exit While
                        End If
                        k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                    End While
                End If
                Dim Xm As Double = KOBJ.Position.X
                Dim Ym As Double = KOBJ.Position.Y
                Dim Pdb As IPosition71 = mSgworld.Creator.CreatePosition(Xm, Ym, 0, 2, 90, 0, 0, 0)
                Dim Dcao() As Double = {2000, 2000, 20, 3000, 3000, 3000}
                Dim Vtoc() As Double = {5000, 400, 60, 300, 2000, 5000}
                Dim Kcach() As Double = {15000, 1000, 0, 500, 1000, 15000}
                Dim WaypointTrt() As IRouteWaypoint71 = Nothing
                Dim mYaw As Double
                Select Case dongTrinhchieu.Split(";")(6).Split(".")(0).Split("/")(1)
                    Case "0"
                        mYaw = 90
                    Case "1"
                        mYaw = 270
                End Select
                For k As Integer = 0 To Dcao.Count - 1
                    Dim P1k As IPosition71 = Pdb.Move(Kcach(k), mYaw, 0)
                    ReDim Preserve WaypointTrt(0 To Dcao.Count - 1)
                    WaypointTrt(k) = mSgworld.Creator.CreateRouteWaypoint(P1k.X, P1k.Y, Dcao(k), Vtoc(k), 0, 0, 0, "")
                Next
                Dim DT3 As ITerrainDynamicObject71 = mSgworld.Creator.CreateDynamicObject(WaypointTrt, DynamicMotionStyle.MOTION_HOVER, DYNAMIC_3D_MODEL, PathData & "\XPL\Truc thang van tai.xpl2", Tyle * 200, 2, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", "DBDK"), "DBDK1") '  Gr03(sgworldK, System.Environment.MachineName, "TempTrC", "Dan" & SoTT.ToString)
                DT3.Acceleration = 1000
                DT3.Tooltip.Text = TxtTenKH.Text & ", " & "3" & ":" & DT3.Waypoints.Count.ToString
                Dim ten As String = sgworldMain.ProjectTree.GetItemName(DT3.ID)
                Dim Pk As IPosition71 = mSgworld.Creator.CreatePosition(WaypointTrt(5).X, WaypointTrt(5).Y, 0, 2, 0, 0, 0, 0)
                Dim MH As ITerrainModel71 = CrCQTrT(Pk, PathData & "\XPL\CQ1.xpl2", 130 * Tyle, ten & "CQ1")
                MH.Attachment.AttachTo(DT3.ID, 0, 540 * Tyle, 300 * Tyle, 0, 0, 0)
                Dim MH1 As ITerrainModel71 = CrCQTrT(Pk, PathData & "\XPL\CQ1.xpl2", 140 * Tyle, ten & "CQ2")
                MH1.Attachment.AttachTo(DT3.ID, 0, -460 * Tyle, 200 * Tyle, 0, 0, 0)
                DT3.RestartRoute(0)
                solan += 1
            End If
        Catch
        End Try
    End Sub

    Private Function MEffect(mHU As String) As String
        Try
            Dim effnew As String = String.Empty
            If mHU = "KhoiMB" Then
                effnew = "$$PARTICLE$$UserDefine: <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='201' Texture='WhiteSmokeLight.png'>
<Emitter Rate='38' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='3' Time='1' Initial='1' />
<Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='1' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='3.51' /><Speed Value='0.19' />
<Color Value='20,255,255,255' /><Size Value='1.4,1.4' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.44' FadeOut='0.09' MaxFade='0.26' /></ParticleEmitter>
<ParticleEmitter ID='ring' NumParticles='91' Texture='WhiteSmokeLight.png'><Emitter Rate='38' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' />
<Cycle Value='1' /><Sort Value='1' /><Rotation Speed='3' Time='1' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='1' OverrideRotation='0' />
<Position Value='0, 0, 0' /><Life Value='2.44' /><Speed Value='0.19' /><Color Value='20,32,32,32' /><Size Value='1.1,1.1' /><Drag Value='0' /><Blend Type='Add' />
<Fade FadeIn='0.23' FadeOut='0.06' MaxFade='0.07' /></ParticleEmitter></Particle>"
            ElseIf mHU = "KhoiXE" Then
                effnew = "$$PARTICLE$$UserDefine: <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='130' Texture='Fire.png'>
<Emitter Rate='13' Shape='Ring' SpeedShape='Ring' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='1' Time='2' Initial='0' />
<Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='3.06' /><Speed Value='1.41' />
<Color Value='20,255,255,255' /><Size Value='2.4,2.4' /><Drag Value='1' /><Blend Type='' /><Fade FadeIn='0.47' FadeOut='0.65' MaxFade='0.28' /></ParticleEmitter>
<ParticleEmitter ID='ring' NumParticles='62' Texture='CampFireBrightSmall.png'><Emitter Rate='8' Shape='Disc' SpeedShape='Disc' Scale='0.6,0.7,0.6' Speed='1,1,1' />
<Cycle Value='1' /><Sort Value='1' /><Render Value='Billboard' /><Gravity Value='0, 2, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' />
<Life Value='1.12' /><Speed Value='1' /><Color Value='20,255,255,255' /><Size Value='2.1,2.1' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.16' FadeOut='0.15' MaxFade='0.07' />
</ParticleEmitter></Particle>"
            ElseIf mHU = "DAN" Then
                effnew = "$$PARTICLE$$UserDefine: <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='575' Texture='WhiteSmokeLight.png'><Emitter Rate='602' Shape='Sphere' SpeedShape='Sphere' Scale='0,0,0' Speed='1,0.51,1' />
<Cycle Value='1' /><Sort Value='1' /><Rotation Speed='2' Time='1' Initial='0' /><Render Value='Billboard' /><Gravity Value='0, 0, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='6.25' /><Speed Value='3.28' />
<Color Value='20,200,170,160' /><Size Value='4,4' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.13' FadeOut='0.06' MaxFade='0.17' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='572' Texture='Dust.png'><Emitter Rate='602' Shape='Sphere' SpeedShape='Sphere' Scale='0,0,0' Speed='1,0.76,1' />
<Cycle Value='1' /><Sort Value='1' /><Rotation Speed='2' Time='3' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, -1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='6.25' />
<Speed Value='3.28' /><Color Value='20,210,170,145' /><Size Value='4.1,4.1' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.22' FadeOut='0.3' MaxFade='0.14' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='26' Texture='fire.png'>
<Emitter Rate='597' Shape='Disc' SpeedShape='Disc' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Render Value='Billboard' /><Gravity Value='0, -1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' />
<Life Value='6.25' /><Speed Value='1.56' /><Color Value='20,128,128,255' /><Size Value='3.3,3.3' /><Drag Value='1' /><Blend Type='Add' /><Fade FadeIn='0.2' FadeOut='0' MaxFade='0.8' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='572' Texture='Dust.png'>
<Emitter Rate='602' Shape='Cone' SpeedShape='Cone' Scale='0,1,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='1' Time='3' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, -1, 0' /><Force Value='0' OverrideRotation='0' />
<Position Value='0, 0, 0' /><Life Value='6.25' /><Speed Value='3.75' /><Color Value='20,210,170,145' /><Size Value='4.1,4.1' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.22' FadeOut='0.3' MaxFade='0.13' />
</ParticleEmitter></Particle>"
            ElseIf mHU = "BOM" Then
                effnew = "$$PARTICLE$$UserDefine: <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='77' Texture='CampFireBrightSmall.png'>
            <Emitter Rate='18' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='1' Time='1' Initial='1' />
            <Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='3.06' /><Speed Value='1' />
            <Color Value='20,255,255,255' /><Size Value='3.8,3.8' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.13' FadeOut='0.08' MaxFade='0.42' /></ParticleEmitter>
            <ParticleEmitter ID='ring' NumParticles='35' Texture='CampFireBrightSmall.png'><Emitter Rate='147' Shape='Cone' SpeedShape='Cone' Scale='0.1,0.1,0' Speed='1,1,1' />
            <Cycle Value='1' /><Sort Value='1' /><Rotation Speed='2' Time='2' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, -1, 0' /><Force Value='0' OverrideRotation='0' />_
            <Position Value='0, 0, 0' /><Life Value='1.56' /><Speed Value='8.62' /><Color Value='20,255,255,255' /><Size Value='2.2,2.2' /><Drag Value='7' /><Blend Type='Add' />
            <Fade FadeIn='0.1' FadeOut='0.62' MaxFade='0.13' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='74' Texture='GraySmoke.png'><Emitter Rate='43' Shape='Cone' SpeedShape='Cone' Scale='0.1,0.1,0' Speed='1,1,1' />
            <Cycle Value='1' /><Sort Value='1' /><Rotation Speed='3' Time='2' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' />
            <Position Value='0, 0, 0' /><Life Value='2.84' /><Speed Value='4' /><Color Value='20,255,255,255' /><Size Value='2.2,2.2' /><Drag Value='2' /><Blend Type='Add' />
            <Fade FadeIn='0.23' FadeOut='0.5' MaxFade='0.15' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='74' Texture='FireThin.png'><Emitter Rate='295' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' />
            <Cycle Value='1' /><Sort Value='1' /><Rotation Speed='1' Time='1' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' />
            <Position Value='0, 0, 0' /><Life Value='2.25' /><Speed Value='2.44' /><Color Value='20,255,192,255' /><Size Value='1.8,1.8' /><Drag Value='4' /><Blend Type='Add' />
            <Fade FadeIn='0.2' FadeOut='0.5' MaxFade='0.06' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='100' Texture='Fire.png'><Emitter Rate='271' Shape='Cone' SpeedShape='Cone' Scale='0,0.6,0' Speed='1,1,1' />
            <Cycle Value='1' /><Sort Value='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' />
            <Life Value='3.51' /><Speed Value='2.64' /><Color Value='20,255,255,255' /><Size Value='2.8,2.8' /><Drag Value='1' /><Blend Type='Add' /><Fade FadeIn='0.5' FadeOut='0.5' MaxFade='0.1' />
            </ParticleEmitter></Particle>"
            ElseIf mHU = "DanPK" Then
                effnew = "$$PARTICLE$$UserDefine:  <?xml version='1.0' encoding='UTF-8'?>  <Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='65' Texture='C:\Program Files\Skyline\TerraExplorer Pro\Tools\ParticleEditor\ParticleImages\CampFire.png'>
<Emitter Rate='1000' Shape='ShellSphere' SpeedShape='ShellSphere' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='3' Time='1' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, -2, 0' />
<Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='0.56' /><Speed Value='14.06' /><Color Value='20,255,30,5' /><Size Value='0.4,0.4' /><Drag Value='2' /><Blend Type='' /><Fade FadeIn='0' FadeOut='0' MaxFade='1' />
</ParticleEmitter><ParticleEmitter ID='ring' NumParticles='35' Texture='smoke.png'><Emitter Rate='1000' Shape='Sphere' SpeedShape='Sphere' Scale='1,1,1' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='3' Time='1' Initial='1' />
<Render Value='Billboard' /><Gravity Value='0, 0, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='3.28' /><Speed Value='14.06' /><Color Value='20,255,64,255' /><Size Value='3.7,3.7' />
<Drag Value='2' /><Blend Type='' /><Fade FadeIn='0' FadeOut='0.75' MaxFade='0.01' /></ParticleEmitter></Particle>"
                'ElseIf mHU = "BOM2" Then
                '    effnew = "$$PARTICLE$$UserDefine: <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='575' Texture='WhiteSmokeLight.png'><Emitter Rate='602' Shape='Sphere' SpeedShape='Sphere' Scale='0,0,0' Speed='1,0.51,1' />
                '    <Cycle Value ='1' /><Sort Value='1' /><Rotation Speed='2' Time='1' Initial='0' /><Render Value='Billboard' /><Gravity Value='0, 0, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='6.25' />
                '    <Speed Value='3.28'/> < Color Value='20,200,170,160' /><Size Value='4,4' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.13' FadeOut='0.06' MaxFade='0.17' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='572' Texture='Dust.png'>
                '    <Emitter Rate ='602' Shape='Sphere' SpeedShape='Sphere' Scale='0,0,0' Speed='1,0.76,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='2' Time='3' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, -1, 0' />
                '    <Force Value='0' OverrideRotation='0'/> < Position Value='0, 0, 0' /><Life Value='6.25' /><Speed Value='3.28' /><Color Value='20,210,170,145' /><Size Value='4.1,4.1' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.22' FadeOut='0.3' MaxFade='0.14' />
                '    </ParticleEmitter><ParticleEmitter ID='ring' NumParticles='26' Texture='fire.png'><Emitter Rate='597' Shape='Disc' SpeedShape='Disc' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Render Value='Billboard' />
                '    <Gravity Value ='0, -1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='6.25' /><Speed Value='1.56' /><Color Value='20,128,128,255' /><Size Value='3.3,3.3' /><Drag Value='1' /><Blend Type='Add' />
                '    <Fade FadeIn='0.2' FadeOut='0' MaxFade='0.8'/></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='572' Texture='Dust.png'><Emitter Rate='602' Shape='Cone' SpeedShape='Cone' Scale='0,1,0' Speed='1,1,1' /><Cycle Value='1' />
                '    <Sort Value ='1' /><Rotation Speed='1' Time='3' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, -1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='6.25' /><Speed Value='3.75' />
                '    <Color Value='20,210,170,145'/> < Size Value='4.1,4.1' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.22' FadeOut='0.3' MaxFade='0.13' /></ParticleEmitter></Particle>"
                '        ElseIf mHU = "Bom3" Then
                '            effnew = "$$PARTICLE$$UserDefine: <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='23' Texture='fire.png'><Emitter Rate='63' Shape='ShellCone' SpeedShape='ShellCone' Scale='0,0,0' Speed='0.4,0.4,0.4' />
                '<Cycle Value='1' /><Sort Value='1' /><Rotation Speed='1' Time='10' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, 0, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='1.56' />
                '<Speed Value='0.39' /><Color Value='20,255,255,255' /><Size Value='0.4,0.4' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.58' FadeOut='0.51' MaxFade='0.55' /></ParticleEmitter></Particle>"

                '        ElseIf mHU = "TENLUA" Then
                '            effnew = "$$PARTICLE$$UserDefine:  <?xml version='1.0' encoding='UTF-8'?><Particle ID='Custom'><ParticleEmitter ID='ring' NumParticles='80' Texture='BlackSmoke.png'><Emitter Rate='13' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' />
                '<Cycle Value='1' /><Sort Value='1' /><Rotation Speed='3' Time='1' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='3.75' />
                '<Speed Value='0.19' /><Color Value='20,255,255,255' /><Size Value='2.3,2.3' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.56' FadeOut='0.6' MaxFade='0.25' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='100' Texture='FireThin.png'>
                '<Emitter Rate='13' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' />
                '<Life Value='2.64' /><Speed Value='0.14' /><Color Value='20,255,255,255' /><Size Value='1.5,1.5' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.5' FadeOut='0.26' MaxFade='0.79' /></ParticleEmitter><ParticleEmitter ID='ring' NumParticles='100' Texture='BlackSmoke.png'>
                '<Emitter Rate='18' Shape='Cone' SpeedShape='Cone' Scale='0,0,0' Speed='1,1,1' /><Cycle Value='1' /><Sort Value='1' /><Rotation Speed='1' Time='1' Initial='1' /><Render Value='Billboard' /><Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' />
                '<Position Value='0, 0, 0' /><Life Value='2.06' /><Speed Value='0.39' /><Color Value='20,255,255,255' /><Size Value='1,1' /><Drag Value='0' /><Blend Type='' /><Fade FadeIn='0.19' FadeOut='0.19' MaxFade='0.1' /></ParticleEmitter>
                '<ParticleEmitter ID='ring' NumParticles='100' Texture='CampFireBrightSmall.png'><Emitter Rate='23' Shape='Cone' SpeedShape='Cone' Scale='1,1,1' Speed='0.1,0.1,0.1' /><Cycle Value='1' /><Sort Value='1' /><Render Value='Billboard' />
                '<Gravity Value='0, 1, 0' /><Force Value='0' OverrideRotation='0' /><Position Value='0, 0, 0' /><Life Value='2.64' /><Speed Value='0.39' /><Color Value='20,255,255,255' /><Size Value='2,2' /><Drag Value='0' /><Blend Type='Add' />
                '<Fade FadeIn='0.53' FadeOut='0.55' MaxFade='0.18' /></ParticleEmitter></Particle>"
            End If
            MEffect = effnew
        Catch
        End Try
    End Function

    Private Sub DTCDTimer_Tick(sender As Object, e As EventArgs) Handles DTCDTimer.Tick
        Try
            timerDTCD += 1
            Dim Q1, Q2, Q3 As ITerrainDynamicObject71
            If dongTrinhchieu.Split(";")(6).Split(".")(1) = "1" Then 'May bay nem bom
                Try
                    For i As Integer = 0 To eCD.Count - 1
                        If Bd3D = False Then
                            Q1 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(eCD(i)))
                            MBom(sgworldMain, Q1)
                        Else
                            Q1 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(eCD(i)))
                            MBom(sgworldMain, Q1)
                            Q2 = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem(eCD(i)))
                            MBom(sgworld3DBd, Q2)
                            If A3D = True Then
                                Q3 = sgworld3DA.ProjectTree.GetObject(sgworld3DA.ProjectTree.FindItem(eCD(i)))
                                MBom(sgworld3DA, Q3)
                            End If
                        End If
                    Next
                Catch ex As Exception
                    Exit Try
                End Try
            ElseIf dongTrinhchieu.Split(";")(6).Split(".")(1) = "2" Or dongTrinhchieu.Split(";")(6).Split(".")(1) = "3" Then ' Or dongTrinhchieu.Split(";")(6).Split(".")(1) = "3"
                Dim Q4, Q5, Q6 As ITerrainModel71
                For i As Integer = 0 To eCD.Count - 1
                    'MsgBox(eCD(i))
                    If Bd3D = False Then
                        Q4 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(eCD(i)))
                        Q4.Attachment.DeltaYaw = Q4.Attachment.DeltaYaw + 20
                    Else
                        Q4 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(eCD(i)))
                        Q4.Attachment.DeltaYaw = Q4.Attachment.DeltaYaw + 20
                        Q5 = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem(eCD(i)))
                        If A3D = True Then
                            Q6 = sgworld3DA.ProjectTree.GetObject(sgworld3DA.ProjectTree.FindItem(eCD(i)))
                            Q6.Attachment.DeltaYaw = Q4.Attachment.DeltaYaw + 20
                        End If
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub MBom(mSgworld As SGWorld71, k2 As ITerrainDynamicObject71)
        Try
            Dim tenDT As String = mSgworld.ProjectTree.GetItemName(k2.ID)
            Dim mTG As Double = 0.0
            Dim Pb As IPosition71 = mSgworld.Creator.CreatePosition(k2.Waypoints.GetWaypoint(k2.Waypoints.Count - 1).X, k2.Waypoints.GetWaypoint(k2.Waypoints.Count - 1).Y, 0, 2, 0, 0, 0, 0)

            For i As Integer = 0 To k2.Waypoints.Count - 2
                Dim KC1 As Double = mSgworld.CoordServices.GetDistance(k2.Waypoints.GetWaypoint(i).X, k2.Waypoints.GetWaypoint(i).Y, k2.Waypoints.GetWaypoint(i + 1).X, k2.Waypoints.GetWaypoint(i + 1).Y)
                Dim TG1 As Double = KC1 / k2.Waypoints.GetWaypoint(i).Speed
                mTG += TG1
            Next
            Dim Pb1 As IPosition71 = Pb.Move(1000, 60, 0)
            Dim Pb2 As IPosition71 = Pb.Move(-1000, -60, 0)
            If timerDTCD >= mTG - 3 Then
                For i As Integer = 0 To 60 Step 3
                    Dim Pn As IPosition71 = Pb.Move((i * 400 * Tyle) - (i * 300 * Tyle), i * 20, 0)
                    Pn.Altitude = k2.Waypoints.GetWaypoint(k2.Waypoints.Count - 1).Altitude + (i * 15)
                    CrEffect(mSgworld, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", "PhK" & i.ToString), Pn, "DanPK", "PhK" & i.ToString, Tyle * 250.0)
                Next
            End If
            If timerDTCD >= mTG Then
                CrEffect(mSgworld, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", tenDT & "1"), Pb, "BOM", tenDT & "1", Tyle * 600.0)
                CrEffect(mSgworld, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", tenDT & "2"), Pb1, "BOM", tenDT & "2", Tyle * 600.0)
                CrEffect(mSgworld, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", tenDT & "3"), Pb2, "BOM", tenDT & "3", Tyle * 600.0)
                My.Computer.Audio.Play(PathData & "\Sounds\016.wav", AudioPlayMode.BackgroundLoop)
            End If

            If timerDTCD >= mTG + 1 Then
                Dim MBRoi As ITerrainDynamicObject71 = mSgworld.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(eCD(eCD.Count - 1)))
                CrEffect(mSgworld, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", tenDT & "Roi"), Pb, "BOM", tenDT & "Roi", Tyle * 250.0).Attachment.AttachTo(MBRoi.ID, 0, 0, 0, 0, 0, 0)
            End If
        Catch
        End Try
    End Sub

    Public Function CrEffect(mSgworld As SGWorld71, gr As String, Pb As IPosition71, effectName As String, tenDT As String, sScale As Double) As ITerrainEffect71
        Try
            Dim k0 = mSgworld.ProjectTree.FindItem(System.Environment.MachineName & "\TempTrC\" & mSgworld.ProjectTree.GetItemName(gr) & "\" & tenDT)
            If String.IsNullOrEmpty(k0) = True Then
                Dim eff As ITerrainEffect71 = mSgworld.Creator.CreateEffect(Pb, MEffect(effectName), gr, tenDT)
                eff.SmallestVisibleSize = 0
                eff.Scale = sScale * Tyle
                CrEffect = eff
            Else
                Exit Function
            End If
        Catch
        End Try
    End Function

    Private Sub TimerMohinh_Tick(sender As Object, e As EventArgs) Handles TimerMohinh.Tick
        Try
            TGian += 1
            Dim Pmt As IPosition71, Pmt2 As IPosition71, Pmt3 As IPosition71
            If dongTrinhchieu.Split(";")(7).Split(".")(1) = "1" Or dongTrinhchieu.Split(";")(7).Split(".")(1) = "2" Then
                '   TimerMohinh.Interval = 1000 * TGbay(dongTrinhchieu.Split(";")(7).Split(".")(1))
                Dim Muctieu As ITerraExplorerObject71 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(dongTrinhchieu.Split(";")(7).Split(".")(0).Split(",")(1)))
                Pmt = sgworldMain.Creator.CreatePosition(Muctieu.Position.X, Muctieu.Position.Y, Muctieu.Position.Altitude, 2, 0, 0, 0, 0)
                Dim mCD As List(Of IPosition71) = ToadoBan(sgworldMain)

                For j As Integer = 0 To mCD.Count - 1
                    Dim Pn As IPosition71 = Pmt.Move((j * 600 * Tyle) - (j * 200 * Tyle), j * 60, 0)
                    If Bd3D = False Then
                        Dan(sgworldMain, mCD(j), Pn, j.ToString)
                    Else
                        Dan(sgworldMain, mCD(j), Pn, j.ToString)
                        Pmt2 = sgworld3DBd.Creator.CreatePosition(Pn.X, Pn.Y, Pn.Altitude, 2, 0, 0, 0, 0)
                        mCD = ToadoBan(sgworld3DBd)
                        Dan(sgworld3DBd, mCD(j), Pmt2, j.ToString)
                        If A3D = True Then
                            Pmt3 = sgworld3DA.Creator.CreatePosition(Pn.X, Pn.Y, Pn.Altitude, 2, 0, 0, 0, 0)
                            mCD = ToadoBan(sgworld3DA)
                            Dan(sgworld3DA, mCD(j), Pmt3, j.ToString)
                        End If
                    End If
                Next
            End If
            If dongTrinhchieu.Split(";")(7).Split(".")(1) = "3" Then 'QUAY
                Dim BienDTQuay() As String = dongTrinhchieu.Split(";")(7).Split(".")(0).Split(",")
                Dim Q1, Q2, Q3 As ITerrainModel71
                For i As Integer = 0 To BienDTQuay.Length - 1
                    If BienDTQuay(i) <> "" Then
                        If Bd3D = False Then
                            Q1 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(BienDTQuay(i)))
                            Q1.Position.Yaw = Q1.Position.Yaw + 5
                        Else
                            Q1 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(BienDTQuay(i)))
                            Q1.Position.Yaw = Q1.Position.Yaw + 5
                            Q2 = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem(BienDTQuay(i)))
                            Q2.Position.Yaw = Q2.Position.Yaw + 5
                            If A3D = True Then
                                Q3 = sgworld3DA.ProjectTree.GetObject(sgworld3DA.ProjectTree.FindItem(BienDTQuay(i)))
                                Q3.Position.Yaw = Q3.Position.Yaw + 5
                            End If
                        End If
                    Else
                        Exit Sub
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Function ToadoBan(mSgworld As SGWorld71) As List(Of IPosition71)
        Try
            Dim Ban As String = dongTrinhchieu.Split(";")(7).Split(".")(0).Split(",")(0)
            Dim Muctieu As String = dongTrinhchieu.Split(";")(7).Split(".")(0).Split(",")(1)
            Dim grDTBan As String = Ban.Split("\")(0) & "\" & Ban.Split("\")(1) & "\" & Ban.Split("\")(2) 'dongTrinhchieu.Split(";")(7).Split(".")(0).Split("\")(0) & "\" & dongTrinhchieu.Split(";")(7).Split(".")(0).Split("\")(1)
            Dim k0 = mSgworld.ProjectTree.FindItem(grDTBan)
            Dim mCD As New List(Of IPosition71)
            If (mSgworld.ProjectTree.IsGroup(k0)) Then
                k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                While Not (k0 = Nothing)
                    Dim obj As ITerraExplorerObject71 = mSgworld.ProjectTree.GetObject(k0)
                    If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                        Dim DT As ITerrainLabel71 = obj
                        If DT.ImageFileName <> "" Then
                            mCD.Add(DT.Position)
                        End If
                    ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
                        Dim DT As ITerrainPolygon71 = obj
                        If DT.Terrain.DrawOrder = 3 Then
                            mCD.Add(DT.Position)
                        End If
                    ElseIf obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                        mCD.Add(obj.Position)
                    End If
                    k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                End While
            End If
            ToadoBan = mCD
        Catch
        End Try
    End Function

    Private Sub Dan(sgworldK As SGWorld71, Pban As IPosition71, Pmt As IPosition71, SoTT As Integer) ', TenPhao As String)
        Try
            Dim Kc As Double = sgworldMain.CoordServices.GetDistance(Pban.X, Pban.Y, Pmt.X, Pmt.Y)
            Dim WaypointDan() As IRouteWaypoint71 = Nothing
            Dim Dcao() As Double = Nothing, Kcach() As Double = Nothing, Vtoc() As Double = Nothing

            If dongTrinhchieu.Split(";")(7).Split(".")(1) = "1" Then
                Dcao = {10, Kc / 15, Kc / 12, Kc / 15, -200}
                Kcach = {0, Kc / 4, Kc / 2, 3 / 4 * Kc, Kc}
                Vtoc = {15000, 15000, 15000, 15000, 15000}
                fileModel = PathData & "\XPL\Dan Phao.xpl2"
            ElseIf dongTrinhchieu.Split(";")(7).Split(".")(1) = "2" Then
                Dcao = {0, 8000, 8000, 8000, 8000, 1500, -300}
                Kcach = {0, 500, Kc / 50, Kc / 50 + 5000, Kc / 50 + 8000, Kc - 5000, Kc}
                Vtoc = {100, 300, 15000, 15000, 15000, 15000, 15000}
                fileModel = PathData & "\XPL\TLHanhtrinh.xpl2"
            End If

            For k As Integer = 0 To Dcao.Count - 1
                Dim P1k As IPosition71 = Pban.Move(Kcach(k), FGoc(Pmt, Pban) - 0.5, 0)
                ReDim Preserve WaypointDan(0 To Dcao.Count - 1)
                WaypointDan(k) = sgworldK.Creator.CreateRouteWaypoint(P1k.X, P1k.Y, Dcao(k), Vtoc(k), 0, 0, 0, "")
            Next
            Dim DanPhao As ITerrainDynamicObject71
            Dim k0 = sgworldK.ProjectTree.FindItem(System.Environment.MachineName & "\TempTrC\Dan" & SoTT.ToString & "\" & "1")
            If String.IsNullOrEmpty(k0) = True Then
                DanPhao = sgworldK.Creator.CreateDynamicObject(WaypointDan, MOTION_AIRPLANE, DYNAMIC_3D_MODEL, fileModel, Tyle * 400, 2, Gr03(sgworldK, System.Environment.MachineName, "TempTrC", "Dan" & SoTT.ToString), "1") '  Gr03(sgworldK, System.Environment.MachineName, "TempTrC", "Dan" & SoTT.ToString)
                If dongTrinhchieu.Split(";")(7).Split(".")(1) = "2" Then
                    DanPhao.Acceleration = WaypointDan(3).Speed
                Else
                    DanPhao.Acceleration = WaypointDan(1).Speed
                End If
                DanPhao.CircularRoute = CircularRouteType.CRT_JUMP_TO_START
                DanPhao.RestartRoute(0)
                If dongTrinhchieu.Split(";")(7).Split(".")(1) = "2" Then
                    CrEffect(sgworldK, Gr03(sgworldK, System.Environment.MachineName, "TempTrC", "KHOI" & SoTT.ToString), Pban, "KhoiMB", "Khoi", Tyle * 1600.0).Attachment.AttachTo(DanPhao.ID, 10, 0, 0, 0, 0, 0)
                End If
            Else
                DanPhao = sgworldK.ProjectTree.GetObject(k0)
                DanPhao.RestartRoute(0)
            End If

            Dim mTG As Double = 0.0
            Dim Pb As IPosition71 = sgworldK.Creator.CreatePosition(DanPhao.Waypoints.GetWaypoint(DanPhao.Waypoints.Count - 1).X, DanPhao.Waypoints.GetWaypoint(DanPhao.Waypoints.Count - 1).Y, 0, 2, 0, 0, 0, 0)

            For i As Integer = 0 To DanPhao.Waypoints.Count - 2
                Dim KC1 As Double = sgworldK.CoordServices.GetDistance(DanPhao.Waypoints.GetWaypoint(i).X, DanPhao.Waypoints.GetWaypoint(i).Y, DanPhao.Waypoints.GetWaypoint(i + 1).X, DanPhao.Waypoints.GetWaypoint(i + 1).Y)
                Dim TG1 As Double = KC1 / DanPhao.Waypoints.GetWaypoint(i).Speed
                mTG += TG1
            Next
            If TGian >= mTG Then
                NoTQ(sgworldK, Pmt)
                My.Computer.Audio.Play(PathData & "\Sounds\016.wav", AudioPlayMode.BackgroundLoop)
                TimerMohinh.Stop()
            End If
        Catch
        End Try
    End Sub

    Private Sub NoTQ(mSgworld As SGWorld71, Pmt As IPosition71)
        Try
            Dim mCD As List(Of IPosition71) = ToadoBan(sgworldMain)
            Dim Pn(mCD.Count) As IPosition71
            For i As Integer = 0 To mCD.Count - 1
                Pn(i) = Pmt.Move((i * 600 * Tyle) - (i * 200 * Tyle), i * 60, 0)
                Pn(i).Altitude = Pmt.Altitude * 1.2
                CrEffect(mSgworld, Gr03(mSgworld, System.Environment.MachineName, "TempTrC", "NO" & i.ToString), Pn(i), "DAN", "NO" & i.ToString, 400 * Tyle)
            Next
        Catch
        End Try
    End Sub

    Private Sub GrDTChuyendong(mSgworld As SGWorld71)
        Try
            Dim M1 As String = dongTrinhchieu.Split(";")(7).Split(".")(0).Split(",")(1) '.Substring(0, '.Split("\")(1) '& "\" & dongTrinhchieu.Split(";")(7).Split(".")(0).Split("\")(1)
            ' Dim count As Integer = M1.Count(Function(x) x = "\")
            Dim grDTBan As String = M1.Split("\")(0) & "\" & M1.Split("\")(1) & "\" & M1.Split("\")(2)
            Dim k0 = mSgworld.ProjectTree.FindItem(grDTBan)
            If (mSgworld.ProjectTree.IsGroup(k0)) Then
                k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                While Not (k0 = Nothing)
                    Dim obj = mSgworld.ProjectTree.GetObject(k0)
                    If obj.ObjectType = ObjectTypeCode.OT_DYNAMIC Then
                        Dim k As ITerrainDynamicObject71 = obj
                        k.RestartRoute(0)
                        Dim tenDT As String = mSgworld.ProjectTree.GetItemName(k.ID)
                        eCD.Add(grDTBan & "\" & tenDT)
                    End If
                    k0 = mSgworld.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                End While
            End If
        Catch
        End Try
    End Sub

    Public Sub HuMohinh() 'Khong sua
        Try
            If dongTrinhchieu.Split(";")(7) = "" Then
                Exit Sub
            Else
                If dongTrinhchieu.Split(";")(7).Split(".")(1) = "1" Or dongTrinhchieu.Split(";")(7).Split(".")(1) = "2" Then
                    eCD.Clear()
                    GrDTChuyendong(sgworldMain)
                End If
                TimerMohinh.Start()
                If dongTrinhchieu.Split(";")(7).Split(".")(1) = "3" Then
                    TimerMohinh.Interval = 1
                Else
                    TimerMohinh.Interval = 1000
                End If

            End If
        Catch
        End Try
    End Sub

    Public Sub DeleteHU()
        Try
            sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\TempTrC"))
            If Bd3D = True Then
                sgworld3DBd.ProjectTree.DeleteItem(sgworld3DBd.ProjectTree.FindItem(System.Environment.MachineName & "\TempTrC"))
            End If
            If A3D = True Then
                sgworld3DA.ProjectTree.DeleteItem(sgworld3DA.ProjectTree.FindItem(System.Environment.MachineName & "TempTrC"))
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Sub lenhnhapnhay(data As String)
        Try
            Lenhve = "NNtructiep3"
            If txtNnTrt.Text = "" Then
                txtNnTrt.Text = data
            Else
                txtNnTrt.Text = txtNnTrt.Text & "," & data
            End If
        Catch
        End Try
    End Sub

    Private Sub Trinhchieu()
        TopHieuung()
        Try
            TGian = 0
            FlytoPoint()
            MTChuyendong1(dongTrinhchieu.Split(";")(2))
            MTChuyendong(dongTrinhchieu.Split(";")(2))

            Nhapnhay()
            ObjectHide()
            DinamicObject()
            HuMohinh()
            MTunhien()
            Multimedia()
            Baocao()
            BtTrinhchieu()

        Catch ex As Exception
            ' Exit Try
        End Try
        txtTTTrC.SelectAll()
        txtTTTrC.Focus()
    End Sub

    Private Sub Audio(newFileVideo As String)
        Try
            Dim exp As String = newFileVideo.Substring(newFileVideo.Length - 3)
            Dim playCommand As String = "play audiofile from 0"
            mciSendString("open """ & newFileVideo & """ type mpegvideo alias audiofile", "", 0, 0)
            mciSendString(playCommand & " REPEAT", Nothing, 0, 0)
        Catch
        End Try
    End Sub

    Public Sub TopHieuung()
        Try
            sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Temp"))
            lbBaocao.Text = ""
            lbBaocao.Visible = False
            If Not Lenhve = "NNtructiep3" Then
                HienthitoanboDT()
            End If
            DeleteHU()
            TimerMohinh.Stop()
            TiTructiep.Stop()
            TiKichban.Stop()
            MTtimer.Stop()
            MTtimer1.Stop()
            DTCDTimer.Stop()
            StopTunhien()
            StopMultimedia()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub StopMultimedia()
        Try
            If videoTrC.PlayStatus = VideoPlayStatus.VPS_PLAY Then
                videoTrC.Visibility.Show = False
                videoTrC.Volume = 0
            End If
        Catch ex As Exception
            Exit Try
        End Try
        Try
            mciSendString("close audiofile", Nothing, 0, IntPtr.Zero)
        Catch ex As Exception
            Exit Try
        End Try
        Try
            If panelVideo.Visible = True Then
                panelVideo.Visible = False
            End If
        Catch ex As Exception
            Exit Try
        End Try
        My.Computer.Audio.Stop()
    End Sub

    Private Sub StopTunhien()
        Try
            For i As Integer = 2206 To 2208
                If Bd3D = False Then
                    sgworldMain.Command.Execute(i, 0) 'mua
                    sgworldMain.Command.Execute(2211, 0) 'mua
                Else
                    sgworldMain.Command.Execute(i, 0) 'mua
                    sgworld3DBd.Command.Execute(i, 0) 'mua
                    sgworldMain.Command.Execute(2211, 0) 'mua
                    sgworld3DBd.Command.Execute(2211, 0) 'mua
                End If
                If A3D = True Then
                    sgworld3DA.Command.Execute(i, 0) 'mua
                    sgworld3DA.Command.Execute(2211, 0) 'mua
                End If
            Next
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Function Vitritrinhchieu() As String
        Try
            Dim vitri As String
            Dim mPoint3DA As IPosition71, mPoint3Dbd As IPosition71
            Dim Chuoi3DA As String = String.Empty, Chuoi3Dbd As String = String.Empty
            If A3D = True Then
                mPoint3DA = sgworld3DA.Navigate.GetPosition(AltitudeTypeCode.ATC_TERRAIN_RELATIVE)
                Chuoi3DA = "_" & mPoint3DA.X.ToString & "," & mPoint3DA.Y.ToString & "," & mPoint3DA.Altitude.ToString & "," & mPoint3DA.Yaw.ToString & "," & mPoint3DA.Pitch
            End If
            If Bd3D = True Then
                mPoint3Dbd = sgworld3DBd.Navigate.GetPosition(AltitudeTypeCode.ATC_TERRAIN_RELATIVE)
                Chuoi3Dbd = "_" & mPoint3Dbd.X.ToString & "," & mPoint3Dbd.Y.ToString & "," & mPoint3Dbd.Altitude.ToString & "," & mPoint3Dbd.Yaw.ToString & "," & mPoint3Dbd.Pitch
            End If
            mPoint = sgworldMain.Navigate.GetPosition(AltitudeTypeCode.ATC_TERRAIN_RELATIVE)
            vitri = mPoint.X.ToString & "," & mPoint.Y.ToString & "," & mPoint.Altitude.ToString & "," & mPoint.Yaw.ToString & "," & mPoint.Pitch & Chuoi3Dbd & Chuoi3DA
            Vitritrinhchieu = vitri
        Catch
        End Try
    End Function

    Public Sub HienthitoanboDT() 'Tot
        Try
            sgworldMain.Navigate.Stop()
            sgworldMain.ProjectTree.SetVisibility("", True)
            If Bd3D = True Then
                sgworld3DBd.Navigate.Stop()
                sgworld3DBd.ProjectTree.SetVisibility("", True)
                If A3D = True Then
                    sgworld3DA.Navigate.Stop()
                    sgworld3DA.ProjectTree.SetVisibility("", True)
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Baocao() 'Hoan chinh
        Try
            If dongTrinhchieu.Split(";")(9) = "" Then
                lbBaocao.Visible = False
                Exit Sub
            Else
                lbBaocao.Left = 3
                lbBaocao.Top = AxTE3DWindow1.Height - lbBaocao.Height
                lbBaocao.Text = dongTrinhchieu.Split(";")(9)
                lbBaocao.Visible = True
            End If
        Catch
        End Try
    End Sub

    Public Sub MTunhien()
        Try
            If dongTrinhchieu.Split(";")(8) <> "" Then
                If Bd3D = False Then
                    sgworldMain.Command.Execute(Val(dongTrinhchieu.Split(";")(8)) + 2205, 1)
                Else
                    sgworldMain.Command.Execute(Val(dongTrinhchieu.Split(";")(8)) + 2205, 1)
                    sgworld3DBd.Command.Execute(Val(dongTrinhchieu.Split(";")(8)) + 2205, 1)
                    If A3D = True Then
                        sgworld3DA.Command.Execute(Val(dongTrinhchieu.Split(";")(8)) + 2205, 1)
                    End If
                End If
            Else
                Exit Sub
            End If
        Catch
        End Try
    End Sub

#Region "    Mui ten chuyen dong"

    Private ReadOnly lisTD As New List(Of String)
    Private KieuTrCMuiten As Boolean = False

    Public Function MPMT(ByVal TDO As String) As String 'As List(Of IPosition71)
        Try
            Dim ChuoiToado1() As String = TDO.Substring(0, TDO.Length - 1).Split(":")
            Dim xyOUT As String = String.Empty
            slan = False
            For i As Integer = 0 To ChuoiToado1.Count - 1
                PllVtNum = i
                Dim mPk1 As IPosition71 = sgworldMain.Creator.CreatePosition(Val(ChuoiToado1(i).Split(",")(0)), Val(ChuoiToado1(i).Split(",")(1)), 0, 2, 0, 0, 0, 0) ', 0, 0, 0, 0)
                ReDim Preserve PllPts(0 To PllVtNum)
                P.X = mPk1.X
                P.Y = mPk1.Y
                P.Z = 0 'sgworldMain.Terrain.GetGroundHeightInfo(PosPixel.X, PosPixel.Y, AccuracyLevel.ACCURACY_NORMAL, True).Position.Altitude
                PllPts(PllVtNum) = P
            Next
            If PllVtNum >= 2 Then
                Dim Plg2() As Point3D '= Nothing
                ReDim Plg2(0 To 0)
                Tyle = 0.01
                NoisuyDuongdon(PllPts, Plg2)
                For i As Integer = 0 To Plg2.Count / 2 - 1
                    If i >= 1 And i <= Plg2.Count / 2 - 1 Then
                        xyOUT = xyOUT & Plg2(i).X.ToString & "," & Plg2(i).Y.ToString & ":"
                    End If
                    If i = Plg2.Count / 2 - 1 Then
                        slan = True
                    End If
                Next
            End If
            MPMT = xyOUT
        Catch
        End Try
    End Function

    Function PathMT() As String()
        Try
            Dim mMT() As String
            Dim mt As String
            Dim MuitenCD As String
            If KieuTrCMuiten = True Then
                MuitenCD = txtNnTrt.Text
            Else
                MuitenCD = dongTrinhchieu.Split(";")(2)
            End If

            If MuitenCD.Contains(",") Then
                mt = MuitenCD
            Else
                mt = MuitenCD.Replace(".", ",.") '& "."
            End If
            mMT = mt.Split(".")(0).Split(",")
            Return mMT
        Catch
        End Try
    End Function

    Public Sub MTChuyendong1(XkPath As String)
        Try
            If XkPath = "" Then
                Exit Sub
            Else
                lisTD.Clear()
                For i As Integer = 0 To PathMT.Count - 1
                    If PathMT(i) <> "" Then
                        Dim k3 As ITerrainPolygon71 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(PathMT(i) & "\" & PathMT(i).Split("\")(2) & "1"))
                        Dim text As String = Decrypt(k3.Tooltip.Text, PassKey)
                        Dim index As Integer = text.IndexOf("-"c)
                        If index >= 0 Then
                            index = text.IndexOf("-"c, index + 1)
                        End If
                        Dim TDO As String = If(index >= 0, text.Substring(index + 1), "")
                        Lenhve = text.Split("-")(0)
                        Dim TDO1 As String = String.Empty, ChuoiToado2 As String
                        If Lenhve = "muithuyeu" Or Lenhve = "muiTCngan" Then
                            TDO1 = TDO.Split(":")(0)
                            TDO = TDO.Split(":")(0) & ":" & TDO
                        ElseIf Lenhve = "muiChuyeu" Then

                            Dim TDOd As String = TDO.Split(":")(0) & ":" & TDO.Split(":")(1)
                            KCDuoiMT = Math.Sqrt((Val(TDOd.Split(":")(0).Split(",")(0)) - Val(TDOd.Split(":")(1).Split(",")(0))) ^ 2 + (Val(TDOd.Split(":")(0).Split(",")(1)) - Val(TDOd.Split(":")(1).Split(",")(1))) ^ 2)
                            Dim X As String = ((Val(TDOd.Split(":")(0).Split(",")(0)) + Val(TDOd.Split(":")(1).Split(",")(0))) / 2).ToString
                            Dim Y As String = ((Val(TDOd.Split(":")(0).Split(",")(1)) + Val(TDOd.Split(":")(1).Split(",")(1))) / 2).ToString

                            TDO1 = X & "," & Y
                            TDO = TDO1 & ":" & TDO.Replace(TDOd, "").Remove(0, 1)
                        End If
                        Dim td As String = MPMT(TDO)
                        If Lenhve = "muiChuyeu" Then
                            ChuoiToado2 = (TDO1 & ":" & TDO1 & ":" & td.Substring(0, td.Length - 1)) '.Split(":") '.Split(":")
                        Else
                            ChuoiToado2 = (TDO1 & ":" & td.Substring(0, td.Length - 1)) '.Split(":") '.Split(":")
                        End If
                        If Lenhve = "muiTCngan" Then
                            Dim TDOd As String = ChuoiToado2.Split(":")(2) & ":" & ChuoiToado2.Split(":")(3) & ":" & ChuoiToado2.Split(":")(4) ' & ":" & ChuoiToado2.Split(":")(5) & ":" & ChuoiToado2.Split(":")(6) & ":" & ChuoiToado2.Split(":")(7)
                            ChuoiToado2 = ChuoiToado2.Replace(TDOd, "").Replace("::", ":") '.Remove(0, 1)
                        End If
                        lisTD.Add(ChuoiToado2)
                    End If
                Next
                MouseHook1.Dispose()
                PllVtNum = 0
                soDiem = 0
                ReDim PllPts(0 To 0)
                cPlg1 = Nothing
                cPlg2 = Nothing
                MTtimer1.Start()
                MTtimer1.Interval = 100
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub MTtimer1_Tick(sender As Object, e As EventArgs) Handles MTtimer1.Tick
        Try
            MouseHook1.RemoveHook()
            TGian += 1
            Dim MuitenCD As String, GianCachThg As Double
            If KieuTrCMuiten = True Then
                MuitenCD = txtNnTrt.Text
            Else
                MuitenCD = dongTrinhchieu.Split(";")(2).Split(".")(0)
            End If
            GianCachThg = 2
            sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(MuitenCD), False)
            Dim k2 As ITerrainPolygon71 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(MuitenCD & "\" & MuitenCD.Split("\")(2) & "1"))
            MauMT = k2.FillStyle.Color
            Dim text As String = Decrypt(k2.Tooltip.Text, PassKey)
            Lenhve = text.Split("-")(0)
            Tyle = Val(text.Split("-")(1))
            Dim ChuoiToado() As String = lisTD(0).Split(":")
            For Each element As String In ChuoiToado
                Console.WriteLine(element)
            Next
            If (TGian Mod GianCachThg = 0) Then
                PllVtNum += 1
                For j As Integer = PllVtNum To ChuoiToado.Count - 1
                    mPoint = sgworldMain.Creator.CreatePosition(Val(ChuoiToado(PllVtNum).Split(",")(0)), Val(ChuoiToado(PllVtNum).Split(",")(1)), 0, 2, 0, 0, 0, 0) ', 0, 0, 0, 0)
                    MuitenTQ(GroupBac2Main)
                    If PllVtNum = ChuoiToado.Count - 1 Then
                        If TGian >= 50 Then
                            MTtimer1.Stop()
                            KieuTrCMuiten = False
                        End If
                        sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(MuitenCD), True)
                        sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Temp"))
                        Lenhve = ""
                        MouseHook1.InstallHook()
                        PllVtNum = 0
                        ReDim PllPts(0 To 0)
                        cPlg1 = Nothing
                        cPlg2 = Nothing
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Public Sub MTChuyendong(XkPath As String)
        Try
            If Bd3D = True Then
                If XkPath = "" Then
                    Exit Sub
                Else
                    lisTD.Clear()
                    For i As Integer = 0 To PathMT.Count - 1
                        If PathMT(i) <> "" Then
                            Dim k3 As ITerrainPolygon71 = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem(PathMT(i) & "\" & PathMT(i).Split("\")(2) & "1"))
                            Dim text As String = Decrypt(k3.Tooltip.Text, PassKey)
                            Dim TDO As String = text.Split("-")(2)
                            Lenhve = text.Split("-")(0)
                            Dim TDO1 As String = String.Empty, ChuoiToado2 As String
                            If Lenhve = "muithuyeu" Or Lenhve = "muiTCngan" Then
                                TDO1 = TDO.Split(":")(0)
                                TDO = TDO.Split(":")(0) & ":" & TDO
                            ElseIf Lenhve = "muiChuyeu" Then
                                Dim TDOd As String = TDO.Split(":")(0) & ":" & TDO.Split(":")(1)
                                KCDuoiMT = Math.Sqrt((Val(TDOd.Split(":")(0).Split(",")(0)) - Val(TDOd.Split(":")(1).Split(",")(0))) ^ 2 + (Val(TDOd.Split(":")(0).Split(",")(1)) - Val(TDOd.Split(":")(1).Split(",")(1))) ^ 2)
                                Dim X As String = ((Val(TDOd.Split(":")(0).Split(",")(0)) + Val(TDOd.Split(":")(1).Split(",")(0))) / 2).ToString
                                Dim Y As String = ((Val(TDOd.Split(":")(0).Split(",")(1)) + Val(TDOd.Split(":")(1).Split(",")(1))) / 2).ToString
                                TDO1 = X & "," & Y
                                TDO = TDO1 & ":" & TDO.Replace(TDOd, "").Remove(0, 1)
                            End If
                            Dim td As String = MPMT(TDO)
                            If Lenhve = "muiChuyeu" Then
                                ChuoiToado2 = (TDO1 & ":" & TDO1 & ":" & td.Substring(0, td.Length - 1)) '.Split(":") '.Split(":")
                            Else
                                ChuoiToado2 = (TDO1 & ":" & td.Substring(0, td.Length - 1)) '.Split(":") '.Split(":")
                            End If
                            If Lenhve = "muiTCngan" Then
                                Dim TDOd As String = ChuoiToado2.Split(":")(2) & ":" & ChuoiToado2.Split(":")(3) & ":" & ChuoiToado2.Split(":")(4) ' & ":" & ChuoiToado2.Split(":")(5) & ":" & ChuoiToado2.Split(":")(6) & ":" & ChuoiToado2.Split(":")(7)
                                ChuoiToado2 = ChuoiToado2.Replace(TDOd, "").Replace("::", ":") '.Remove(0, 1)
                            End If
                            lisTD.Add(ChuoiToado2)
                        End If
                    Next
                    MouseHook1.Dispose()
                    PllVtNum = 0
                    soDiem = 0
                    ReDim PllPts(0 To 0)
                    cPlg1 = Nothing
                    cPlg2 = Nothing
                    MTtimer.Start()
                    MTtimer.Interval = 100
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub MTtimer_Tick(sender As Object, e As EventArgs) Handles MTtimer.Tick
        Try
            MouseHook1.RemoveHook()
            TGian += 1
            Dim MuitenCD As String, GianCachThg As Double
            If KieuTrCMuiten = True Then
                MuitenCD = txtNnTrt.Text
            Else
                MuitenCD = dongTrinhchieu.Split(";")(2).Split(".")(0)
            End If
            GianCachThg = 2
            sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(MuitenCD), False)
            Dim k2 As ITerrainPolygon71 = sgworld3DBd.ProjectTree.GetObject(sgworld3DBd.ProjectTree.FindItem(MuitenCD & "\" & MuitenCD.Split("\")(2) & "1"))
            MauMT = k2.FillStyle.Color
            Dim text As String = Decrypt(k2.Tooltip.Text, PassKey)
            Lenhve = text.Split("-")(0)
            Tyle = Val(text.Split("-")(1))
            Dim ChuoiToado() As String = lisTD(0).Split(":")
            If (TGian Mod GianCachThg = 0) Then
                PllVtNum += 5
                For j As Integer = PllVtNum To ChuoiToado.Count - 1
                    mPoint = sgworld3DBd.Creator.CreatePosition(Val(ChuoiToado(PllVtNum).Split(",")(0)), Val(ChuoiToado(PllVtNum).Split(",")(1)), 0, 2, 0, 0, 0, 0) ', 0, 0, 0, 0)
                    MuitenTQ1(GroupBac2Main)
                    If PllVtNum = ChuoiToado.Count - 1 Then
                        If TGian >= 50 Then
                            MTtimer.Stop()
                            KieuTrCMuiten = False
                        End If
                        sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(MuitenCD), True)
                        sgworld3DBd.ProjectTree.DeleteItem(sgworld3DBd.ProjectTree.FindItem("Temp"))
                        Lenhve = ""
                        MouseHook1.InstallHook()
                        PllVtNum = 0
                        ReDim PllPts(0 To 0)
                        cPlg1 = Nothing
                        cPlg2 = Nothing
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

#End Region


#Region "  Nhay Doi tuong, ket noi sa ban VL"
    Public Sub DCaoT()
        Try
            If DoCao_met < 5000.0 Then
                DoCao_met += 5000.0
            Else
                DoCao_met += 10000.0
            End If
            Bay()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub DCaoC()
        Try
            If DoCao_met < 1000.0 Then
                DoCao_met -= 0.0
            Else
                DoCao_met -= 5000.0
            End If
            Bay()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GNghiengC()
        Try
            If GocNghieng <= 80 Then
                GocNghieng += 10
            End If
            Bay()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GNghiengT()
        Try
            If GocNghieng > 10 Then
                GocNghieng -= 10
            End If
            Bay()
        Catch ex As Exception
        End Try
    End Sub

    Public Function ToadoSB_WGS84(txt As String) As IPosition71
        Try
            TyleSaban()
            SVn2000(MaxMinPointKhung(0))
            Dim Xvn As Double = xVN2000 + Val(txt.Split(",")(0)) * TyleSBVL
            Dim Yvn As Double = yVN2000 + Val(txt.Split(",")(1)) * TyleSBVL
            If (P.X).ToString() < 0 Then
                ConvertXYtoBL(Xvn, Yvn, -81, 6)
                Dim Pto As IPosition71 = sgworldMain.Creator.CreatePosition(_L, _B, 0, 2, 0, Val(-GocNghieng.ToString()), 0, Val(DoCao_met.ToString()))
                ToadoSB_WGS84 = Pto
            Else
                Dim Pk As IPosition71 = Vn200WGS84(Xvn, Yvn, 105, 6, Val(-GocNghieng.ToString()), Val(DoCao_met.ToString()))
                ToadoSB_WGS84 = Pk
            End If
        Catch ex As Exception
        End Try
    End Function
    Public CheDoBay = 0
    Private Sub bt_fly_TextChanged(sender As Object, e As EventArgs) Handles bt_fly.TextChanged
        Try
            If bt_fly.Text = 0 Then
                CheDoBay = 0
            ElseIf bt_fly.Text = 1 Then
                CheDoBay = 1
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Public Sub TxtFly_TextChanged(sender As Object, e As EventArgs) Handles TxtFly.TextChanged
        Bay()
    End Sub
    Public Sub Bay()
        Try
            sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(TxtFly.Text), ActionCode.AC_FLYTO)
            If TTChuThap = 1 Then
                Dim position71 As IPosition71 = sgworldMain.Creator.CreatePosition(ToaXCT, ToaYCT, 1, AltitudeTypeCode.ATC_ON_TERRAIN, 0, -0, 0, 300000)
                Dim ChuThap = sgworldMain.ProjectTree.FindItem("Chu Thap")
                If ChuThap <> "" Then
                    sgworldMain.ProjectTree.SetVisibility(ChuThap, True)
                    pChuthap.Position = position71
                Else
                    Dim duongdan As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\chuthap.gif")
                    Dim labelStyle71 As ILabelStyle71 = sgworldMain.Creator.CreateLabelStyle(SGLabelStyle.LS_DEFAULT)
                    labelStyle71.Scale = 20
                    labelStyle71.LockMode = LabelLockMode.LM_AXIS
                    labelStyle71.PivotAlignment = "Center, Center"
                    labelStyle71.LimitScreenSize = True
                    pChuthap = sgworldMain.Creator.CreateImageLabel(position71, duongdan, labelStyle71, String.Empty, "Chu Thap")
                End If
            ElseIf TTChuThap = 0 Then
                Dim ChuThap = sgworldMain.ProjectTree.FindItem("Chu Thap")
                sgworldMain.ProjectTree.SetVisibility(ChuThap, False)
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub tb_truyentoado_TextChanged(sender As Object, e As EventArgs) Handles tb_truyentoado.TextChanged
        Try
            Dim inputText As String = tb_truyentoado.Text
            Dim values As String() = inputText.Split(","c)

            Dim vido As String = values(0).Trim()
            Dim kinhdo As String = values(1).Trim()
            Dim gocnghieng As String = values(2).Trim()
            Dim docao As String = values(3).Trim()
            If CheDoBay = 0 Then
                sgworldMain.Navigate.FlyTo(sgworldMain.Creator.CreatePosition(vido, kinhdo, docao, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, gocnghieng, 0, 0), ActionCode.AC_FLYTO)
            ElseIf CheDoBay = 1 Then
                sgworldMain.Navigate.FlyTo(sgworldMain.Creator.CreatePosition(vido, kinhdo, docao, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, gocnghieng, 0, 0), ActionCode.AC_JUMP)
            End If
            tb_truyentoado.Text = ""
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Public Sub doico(data As String, link As String)
        Try
            Dim TimCo As Object = sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & "GD1" & "\" & data & "\" & data)
            If Not String.IsNullOrEmpty(TimCo) Then
                sgworldMain.ProjectTree.DeleteItem(TimCo)
                Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(ToadoSB_WGS84(bt_flyccd.Text), tenco & vbCrLf & vbCrLf, link, fLabelStyleMain, sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & "GD1" & "\" & data), data)
            End If
        Catch
        End Try
    End Sub
    Private Sub bt_ccd1_TextChanged(sender As Object, e As EventArgs) Handles bt_ccd1.TextChanged
        Try
            'Dim ChuThap1 = sgworldMain.ProjectTree.FindItem("Chu Thap")
            'If ChuThap1 <> "" Then
            '    sgworldMain.ProjectTree.SetVisibility(ChuThap1, False)
            '    TTChuThap = 1
            '    chuthap.Text = "mở chữ thập"
            'End If
            Dim searchText As String = tb_mau.Text
            Dim baseDirectory As String = AppDomain.CurrentDomain.BaseDirectory
            Dim folderName1 As String = "Data"
            folderPath1 = Path.Combine(baseDirectory, folderName1)
            xmlFilePath = Path.Combine(folderPath1, "CoCoDong.xml")
            Dim xmlDoc As New XmlDocument()
            xmlDoc.Load(xmlFilePath)
            Dim danhSachCoNode As XmlNode = xmlDoc.SelectSingleNode("DanhSachCo")
            Dim danhSachCoNode1 As XmlNode = xmlDoc.SelectSingleNode("DanhSachCo")
            If danhSachCoNode IsNot Nothing Then
                Dim nodeList As XmlNodeList = danhSachCoNode.SelectNodes("SoCo")
                Dim numberAfterC As String = searchText.Substring(1)
                For Each node As XmlNode In nodeList
                    Dim idAttribute As XmlAttribute = node.Attributes("ID")
                    If idAttribute IsNot Nothing AndAlso idAttribute.Value = numberAfterC Then
                        Dim dataNode As XmlNode = node.SelectSingleNode("Data")
                        If dataNode IsNot Nothing Then
                            Dim dataValue As String = dataNode.InnerText
                            tbck = dataValue
                            Exit For
                        End If
                    End If
                Next
            End If
            If danhSachCoNode1 IsNot Nothing Then
                Dim nodeList As XmlNodeList = danhSachCoNode1.SelectNodes("SoCo")
                Dim numberAfterC As String = searchText.Substring(1)
                For Each node As XmlNode In nodeList
                    Dim idAttribute As XmlAttribute = node.Attributes("ID")
                    If idAttribute IsNot Nothing AndAlso idAttribute.Value = numberAfterC Then
                        Dim dataNode As XmlNode = node.SelectSingleNode("TenCo")
                        If dataNode IsNot Nothing Then
                            Dim dataValue As String = dataNode.InnerText
                            tenco = dataValue
                            Exit For
                        End If
                    End If
                Next
            End If
            Dim mts_0 As Object = sgworldMain.ProjectTree.FindItem(System.Environment.MachineName)
            If String.IsNullOrEmpty(mts_0) Then
                Dim mts As Object = sgworldMain.ProjectTree.CreateGroup(System.Environment.MachineName)
                Dim mts1 As Object = sgworldMain.ProjectTree.CreateGroup("GD1", mts)
                Dim mts2 As Object = sgworldMain.ProjectTree.CreateGroup(tb_mau.Text, mts1)
                Dim TimCo As Object = sgworldMain.ProjectTree.FindItem(tb_mau.Text)
                Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(ToadoSB_WGS84(bt_flyccd.Text), tenco & vbCrLf & vbCrLf, tbck, fLabelStyleMain, mts2, tb_mau.Text)
                If CheDoBay = 0 Then
                    sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(bt_flyccd.Text), ActionCode.AC_FLYTO)
                ElseIf CheDoBay = 1 Then
                    sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(bt_flyccd.Text), ActionCode.AC_JUMP)
                End If
            Else
                Dim TimCo As Object = sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & "GD1" & "\" & tb_mau.Text & "\" & tb_mau.Text)
                If Not String.IsNullOrEmpty(TimCo) Then
                    sgworldMain.ProjectTree.DeleteItem(TimCo)
                    Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(ToadoSB_WGS84(bt_flyccd.Text), tenco & vbCrLf & vbCrLf, tbck, fLabelStyleMain, sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & "GD1" & "\" & tb_mau.Text), tb_mau.Text)
                    If CheDoBay = 0 Then
                        sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(bt_flyccd.Text), ActionCode.AC_FLYTO)
                    ElseIf CheDoBay = 1 Then
                        sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(bt_flyccd.Text), ActionCode.AC_JUMP)
                    End If
                Else
                    Dim mts2 As Object = sgworldMain.ProjectTree.CreateGroup(tb_mau.Text, sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & "GD1"))
                    Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(ToadoSB_WGS84(bt_flyccd.Text), tenco & vbCrLf & vbCrLf, tbck, fLabelStyleMain, mts2, tb_mau.Text)
                    If CheDoBay = 0 Then
                        sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(bt_flyccd.Text), ActionCode.AC_FLYTO)
                    ElseIf CheDoBay = 1 Then
                        sgworldMain.Navigate.FlyTo(ToadoSB_WGS84(bt_flyccd.Text), ActionCode.AC_JUMP)
                    End If
                End If
            End If
            'TxtFly.Text = bt_flyccd.Text
            sgworldMain.Project.Save()
        Catch ex As Exception

            Exit Sub
        End Try
    End Sub

    Private Sub GhiToado()
        Try
            If Lenhve <> "" Then
                TyleSaban()
                Dim Pgoc As IPosition71 = MaxMinPointKhung(0)
                Dim dx As Double = mPointClick.X - Pgoc.X
                Dim dy As Double = mPointClick.Y - Pgoc.Y
                Dim ata As Double = Math.Atan(dx / dy)
                Dim Yy As String = Math.Abs(FKc(Pgoc, mPointClick) * Math.Sin(ata)) / TyleSBVL.ToString
                Dim Xx As String = Math.Abs(FKc(Pgoc, mPointClick) * Math.Cos(ata)) / TyleSBVL.ToString
                FrmSBVLM.Instance.TxtLaser.Text = Yy & "," & Xx.ToString
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub BtTrucTiep(Trangthai As String)
        Try
            Dim K As String = ""
            If txtNnTrt.Text <> "" Then
                If txtNnTrt.Text.Contains(",") Then
                    For i As Integer = 0 To txtNnTrt.Text.Split(",").Count - 1
                        Dim Chan As Integer = System.Convert.ToInt16(txtNnTrt.Text.Split(",")(i).Split("_").Last) - 1
                        If K = "" Then
                            K = Chan.ToString & Trangthai
                        Else
                            K = K & "," & Chan.ToString & Trangthai
                        End If
                    Next
                Else
                    Dim Chan As Integer = System.Convert.ToInt16(txtNnTrt.Text.Split("_").Last) - 1
                    K = Chan.ToString & Trangthai
                End If
            End If
        Catch
        End Try
        'FrmSBVL.TxTBit.Text = K
    End Sub

    Private Sub BtTrinhchieu()
        Try
            Dim K As String = ""
            Dim Trangthai As String
            For i As Integer = 2 To dongTrinhchieu.Split(";").Count - 1
                If dongTrinhchieu.Split(";")(i) <> "" Then
                    If i = 4 Then
                        Trangthai = "0"
                    Else
                        Trangthai = "2"
                    End If
                    Try
                        If i <> 5 Or i <> 8 Or i <> 9 Then
                            If dongTrinhchieu.Split(";")(i).Contains(",") Then
                                For j As Integer = 0 To dongTrinhchieu.Split(";")(i).Split(",").Count - 1
                                    Dim Chan As String = dongTrinhchieu.Split(";")(i).Split(",")(j).Split("_").Last
                                    If K = "" Then
                                        K = Chan.ToString & Trangthai
                                    Else
                                        K = K & "," & Chan.ToString & Trangthai
                                    End If
                                Next
                            Else
                                Dim Chan As String = dongTrinhchieu.Split(";")(i).Split("_").Last
                                K = Chan.ToString & Trangthai
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                End If
            Next
            FrmSBVLM.Instance.TxtTrinhchieu.Text = K
        Catch
        End Try
    End Sub

    Private PdtNhay As New List(Of IPosition71)

    Private Sub SNhay(sP As IPosition71)
        Try
            ' sgworldMain.Navigate.JumpTo(sP)
            TiTructiep.Start()
            TiTructiep.Interval = 50
        Catch
        End Try
    End Sub

    Private Sub TxtNnTrt_TextChanged(sender As Object, e As EventArgs) Handles txtNnTrt.TextChanged
        TopHieuung()
        Try
            If Lenhve = "NNtructiep" Or Lenhve = "NNtructiep2" Or Lenhve = "NNtructiep3" Then
                Dim DTs As New List(Of ITerraExplorerObject71)
                If txtNnTrt.Text.Contains(",") Then
                    PdtNhay.Clear()
                    Dim X, Y As Double
                    For i As Integer = 0 To txtNnTrt.Text.Split(",").Count - 1
                        NnTructiep(txtNnTrt.Text.Split(",")(i))
                        X += PdtNhay(i).X
                        Y += PdtNhay(i).Y
                    Next
                    Dim Pnhay As IPosition71 = sgworldMain.Creator.CreatePosition(X / txtNnTrt.Text.Split(",").Count, Y / txtNnTrt.Text.Split(",").Count, 0, 2, 0, 340, 30, 15000)
                    SNhay(Pnhay)
                Else
                    NnTructiep(txtNnTrt.Text)
                End If
                If FileAmthanh <> "" Then
                    My.Computer.Audio.Play(FileAmthanh, AudioPlayMode.BackgroundLoop)
                End If
                sgworldMain.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT, "", True)
            End If
            If Lenhve = "NNtructiep3" Then
                BtTrucTiep("2")
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            ''  If Lenhve = "NNtructiep3" Then
            BtTrucTiep("2")
            '' End If
        End Try
    End Sub

    Private Sub NnTructiep(Path As String)
        Try
            Dim sP As IPosition71
            Dim k0 = sgworldMain.ProjectTree.FindItem(Path)
            If (sgworldMain.ProjectTree.IsGroup(k0)) Then
                k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                While Not (k0 = Nothing)
                    Dim obj = sgworldMain.ProjectTree.GetObject(k0)
                    If obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                        Dim k2 As ITerrainModel71 = obj
                        Dim tenDT As String = sgworldMain.ProjectTree.GetItemName(obj.ID)
                        If tenDT.Contains("CQ") Or tenDT.Contains("CQ1") Or tenDT.Contains("CQ2") Then
                            TimerTrT.Start()
                            TimerTrT.Interval = 1
                            GoTo Dynamic
                        Else
                            sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 30000 * Tyle)
                            If txtNnTrt.Text.Contains(",") Then
                                PdtNhay.Add(sP)
                            Else
                                SNhay(sP)
                            End If
                        End If
Dynamic:            ElseIf obj.ObjectType = ObjectTypeCode.OT_DYNAMIC Then
                        Dim k2 As ITerrainDynamicObject71 = obj
                        k2.RestartRoute(0)
                        Dim Sodiem As Integer = k2.Waypoints.Count - 1
                        Dim Sp1 As IPosition71 = sgworldMain.Creator.CreatePosition(k2.Waypoints.GetWaypoint(Sodiem).X, k2.Waypoints.GetWaypoint(Sodiem).Y, k2.Position.Altitude + 1000, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 60, 0)
                        sP = sgworldMain.Creator.CreatePosition(k2.Waypoints.GetWaypoint(0).X, k2.Waypoints.GetWaypoint(0).Y, 2000, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 20000 * Tyle)
                        sP.Yaw = FGoc(Sp1, sP)
                        'sgworldMain.Navigate.JumpTo(sP)
                        sgworldMain.Navigate.Stop()
                        FileAmthanh = PathData & "\Sounds\" & "00" & Trim(k2.Tooltip.Text.Split(":")(0).Split(",")(1)) & ".wav"
                    ElseIf obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                        Dim k2 As ITerrainLabel71 = obj
                        sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 25000 * Tyle)
                        If txtNnTrt.Text.Contains(",") Then
                            PdtNhay.Add(sP)
                        Else
                            SNhay(sP)
                        End If
                    ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then
                        Dim k2 As ITerrainPolyline71 = obj
                        Dim ST() As String = k2.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
                        Dim Kp1 As IPosition71 = Nothing, Kp2 As IPosition71 = Nothing

                        For i As Integer = 0 To ST.Count - 1
                            If i = 0 Then
                                Kp1 = sgworldMain.Creator.CreatePosition(Val(ST(i).Split(" ")(1)), Val(ST(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                            ElseIf i = ST.Count - 1 Then
                                Kp2 = sgworldMain.Creator.CreatePosition(Val(ST(i).Split(" ")(1)), Val(ST(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                            End If
                        Next
                        sP = sgworldMain.Creator.CreatePosition(0.5 * (Kp1.X + Kp2.X), 0.5 * (Kp1.Y + Kp2.Y), 0, 2, 0, 340, 30, FKc(Kp1, Kp2))
                        SNhay(sP)
                        If txtNnTrt.Text.Contains(",") Then
                            PdtNhay.Add(sP)
                        Else
                            SNhay(sP)
                        End If
                    ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
                        Dim k2 As ITerrainPolygon71 = obj
                        Try
                            If k2.Tooltip.Text.Substring(0, 10) = "een4NC7n9k" Or k2.Tooltip.Text = "Mui tien cong" Or k2.Tooltip.Text.Substring(0, 10) = "p94dKTH2jed" Or k2.Tooltip.Text = "mui tan cong thu yeu" Then '"mui tan cong thu yeu"p94dKTH2jed
                                Dim text As String = Decrypt(k2.Tooltip.Text, PassKey)
                                Dim Toado As String = text.Split("-")(2)
                                Dim S1 As String = Toado.Split(":")(0)
                                Dim S2 As String = Toado.Split(":")(Toado.Split(":").Count - 2)
                                Dim Kp1 As IPosition71 = sgworldMain.Creator.CreatePosition(Val(S1.Split(",")(0)), Val(S1.Split(",")(1)), 0, 2, 0, 0, 0, 0)
                                Dim Kp2 As IPosition71 = sgworldMain.Creator.CreatePosition(Val(S2.Split(",")(0)), Val(S2.Split(",")(1)), 0, 2, 0, 0, 0, 0)
                                sP = sgworldMain.Creator.CreatePosition(0.5 * (Kp1.X + Kp2.X), 0.5 * (Kp1.Y + Kp2.Y), 0, 2, FGoc(Kp2, Kp1), -20, 0, 1.5 * FKc(Kp1, Kp2))
                                'sgworldMain.Navigate.JumpTo(sP)
                                KieuTrCMuiten = True
                                'MTChuyendong(Path)
                                'MTChuyendong1(Path)
                            ElseIf k2.Tooltip.Text = "Đại liên" Or k2.Tooltip.Text = "Trung liên" Or k2.Tooltip.Text = "Súng B40" Or k2.Tooltip.Text = "Súng B41" Or k2.Tooltip.Text = "Công sự" Then
                                sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 6000 * Tyle)
                                SNhay(sP)
                            Else
                                sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 30000 * Tyle)
                                SNhay(sP)
                            End If

                        Catch eX As Exception
                            ''  Finally
                        End Try
                        '   SNhay(sP)
                    End If
                    k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                End While
            End If
        Catch
        End Try
    End Sub

    Private Sub TiTructiep_Tick(sender As Object, e As EventArgs) Handles TiTructiep.Tick
        Try
            TGian += 1
            NhayDT(txtNnTrt.Text, TiTructiep)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub TimerTrT_Tick(sender As Object, e As EventArgs) Handles TimerTrT.Tick
        TGian += 1
        Try
            Dim k0 = sgworldMain.ProjectTree.FindItem(txtNnTrt.Text)
            If (sgworldMain.ProjectTree.IsGroup(k0)) Then
                k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                While Not (k0 = Nothing)
                    Dim obj = sgworldMain.ProjectTree.GetObject(k0)
                    If obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                        Dim Qc As ITerrainModel71 = obj
                        Qc.Attachment.DeltaYaw = Qc.Attachment.DeltaYaw + 20
                    End If
                    k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                End While
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub TxtGroup_TextChanged(sender As Object, e As EventArgs) Handles txtGroup.TextChanged
        Try
            'If Lenhve = "DTdichuyen" Then
            '    TxtDTdichuyen.Text = XoaLap(txtGroup.Text)
            'End If
            FrmSBVLM.Instance.TxtDTmoi.Text = txtGroup.Text

            ''  TxtFly.Text = txtGroup.Text
        Catch
        End Try
    End Sub

    Public Sub Nhapnhay()
        Try
            If dongTrinhchieu.Split(";")(3) <> "" Then
                TiKichban.Start()
                TiKichban.Interval = 50
            End If
        Catch
        End Try
    End Sub

    Private Sub TiKichban_Tick(sender As System.Object, e As EventArgs) Handles TiKichban.Tick
        Try
            TGian += 1
            NhayDT(dongTrinhchieu.Split(";")(3), TiKichban)
        Catch ex As Exception
            ' Exit Sub
        End Try
    End Sub

    Private Sub NhayDT(txt As String, mTimer As System.Windows.Forms.Timer)
        Try
            If txt = "" Then
                mTimer.Enabled = False
                Exit Sub
            Else
                Dim DTNhapnhay() As String = Trim(txt).Split(",")
                For i As Integer = 0 To DTNhapnhay.Length - 1
                    If (TGian Mod todonhay = 0) Then
                        sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(DTNhapnhay(i)), True)
                        If Bd3D = True Then
                            sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(DTNhapnhay(i)), True)
                            If A3D = True Then
                                sgworld3DA.ProjectTree.SetVisibility(sgworld3DA.ProjectTree.FindItem(DTNhapnhay(i)), True)
                            End If
                        End If
                    End If
                Next

                For i As Integer = 0 To DTNhapnhay.Length - 1
                    If (TGian Mod todonhay * 2 = 0) Then
                        sgworldMain.ProjectTree.SetVisibility(sgworldMain.ProjectTree.FindItem(DTNhapnhay(i)), False)
                        If Bd3D = True Then
                            sgworld3DBd.ProjectTree.SetVisibility(sgworld3DBd.ProjectTree.FindItem(DTNhapnhay(i)), False)
                            If A3D = True Then
                                sgworld3DA.ProjectTree.SetVisibility(sgworld3DA.ProjectTree.FindItem(DTNhapnhay(i)), False)
                            End If
                        End If
                    End If
                Next

            End If
        Catch
        End Try
    End Sub

#End Region
    Private keyPressCount As Integer = 0
    Public todonhay = 11
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        Try
            If keyData = Keys.Down Then
                If RMSBS = True Then
                    tb_TrinhChieu.Text = "KB+"
                End If
                Return True
            ElseIf keyData = Keys.Up Then
                If RMSBS = True Then
                    tb_TrinhChieu.Text = "KB-"
                End If
                Return True
            End If

            Return MyBase.ProcessCmdKey(msg, keyData)
        Catch
        End Try
    End Function
    Private Sub AxTE3DWindow1_PreviewKeyDown_1(sender As Object, e As PreviewKeyDownEventArgs) Handles AxTE3DWindow1.PreviewKeyDown
        Try
            If (e.KeyCode = Keys.A) Then
                mnuBB.PerformClick()
            ElseIf (e.KeyCode = Keys.B) Then
                mnuHDTC.PerformClick()
            ElseIf (e.KeyCode = Keys.C) Then
                sgworldMain.Command.Execute(1031, 0)
                'mnuQuanbaoTrinhsat.PerformClick()
            ElseIf (e.KeyCode = Keys.D) Then
                mnuDC.PerformClick()
            ElseIf (e.KeyCode = Keys.E) Then
                mnuTTG.PerformClick()
            ElseIf (e.KeyCode = Keys.G) Then
                mnuPB.PerformClick()
            ElseIf (e.KeyCode = Keys.H) Then
                mnuCB.PerformClick()
            ElseIf (e.KeyCode = Keys.I) Then
                mnuTTLL.PerformClick()
            ElseIf (e.KeyCode = Keys.K) Then
                mnuHH.PerformClick()
            ElseIf (e.KeyCode = Keys.M) Then
                mnuTCDT.PerformClick()
            ElseIf (e.KeyCode = Keys.N) Then
                mnuTcKGMang.PerformClick()
            ElseIf (e.KeyCode = Keys.L) Then
                mnuCoyeu.PerformClick()
            ElseIf (e.KeyCode = Keys.O) Then
                mnuPKKQ.PerformClick()
            ElseIf (e.KeyCode = Keys.P) Then
                mnuHQ.PerformClick()
            ElseIf (e.KeyCode = Keys.Q) Then
                mnuBP.PerformClick()
            ElseIf (e.KeyCode = Keys.R) Then
                mnuLLVTDP.PerformClick()
            ElseIf (e.KeyCode = Keys.S) Then
                mnuDBDV.PerformClick()
            ElseIf (e.KeyCode = Keys.T) Then
                mnuBLLD.PerformClick()
            ElseIf (e.KeyCode = Keys.U) Then
                mnuTuyenTruyen.PerformClick()
            ElseIf (e.KeyCode = Keys.V) Then
                mnuCuuhoCuunan.PerformClick()
            ElseIf (e.KeyCode = Keys.X) Then
                sgworldMain.Command.Execute(1032, 0)
                'mnuHC.PerformClick()
            ElseIf (e.KeyCode = Keys.Y) Then
                mnuKythuat.PerformClick()
            ElseIf (e.KeyCode = Keys.F1) Then
                mnuKyhieuthuongdung.PerformClick()
            ElseIf (e.KeyCode = Keys.F2) Then
                mnuMH.PerformClick()
            ElseIf (e.KeyCode = Keys.F3) Then
                mnuDTDohoa.PerformClick()
            ElseIf (e.KeyCode = Keys.F4) Then
                mnuSuaDT.PerformClick()
            ElseIf (e.KeyCode = Keys.F5) Then
                mnuGotoPoint.PerformClick()
            ElseIf (e.KeyCode = Keys.F6) Then
                If mMicrostation = True Then
                    mnuReferenceFile.PerformClick()
                End If
            ElseIf (e.KeyCode = Keys.F7) Then
                If mMicrostation = True Then
                    mnuAnh_DGN.PerformClick()
                End If
            ElseIf (e.KeyCode = Keys.F8) Then
                If mMicrostation = True Then
                    mnuPDF.PerformClick()
                End If
            ElseIf (e.KeyCode = Keys.F10) Then
                mnuTaoKB.PerformClick()
            ElseIf (e.KeyCode = Keys.F11) Then
                'BangKichBan.kichbanSBS()
            ElseIf (e.KeyCode = Keys.F12) Then
                mnuMang.PerformClick()

            ElseIf (e.KeyCode = Keys.Enter) Then
                If cbTa_DP.SelectedIndex = 0 Then
                    cbTa_DP.SelectedIndex = 1
                ElseIf cbTa_DP.SelectedIndex = 1 Then
                    cbTa_DP.SelectedIndex = 0
                End If
            ElseIf (e.KeyCode = Keys.Escape) Then
                AxTE3DWindow1.Focus()
                Lenhve = ""
                Lenhsua = ""
                lenhveMS = ""
                Lenhve2D = ""
                If Me.MouseHook1.State = 1 Then
                    Me.MouseHook1.Dispose()
                Else
                    Me.MouseHook1.InstallHook()
                End If
                If mMicrostation = True Then
                    mMicrostation = False
                End If
                btnCloseTrC.PerformClick()
            ElseIf (e.KeyCode = Keys.D1) Then
                cbGiaidoan.SelectedIndex = 0
            ElseIf (e.KeyCode = Keys.D2) Then
                cbGiaidoan.SelectedIndex = 1
            ElseIf (e.KeyCode = Keys.D3) Then
                cbGiaidoan.SelectedIndex = 2
            ElseIf (e.KeyCode = Keys.D4) Then
                cbGiaidoan.SelectedIndex = 3
            ElseIf (e.KeyCode = Keys.D5) Then
                cbGiaidoan.SelectedIndex = 4
            ElseIf (e.KeyCode = Keys.D6) Then
                cbGiaidoan.SelectedIndex = 5
            ElseIf (e.KeyCode = Keys.Alt) Then
                sgworldMain.Command.Execute(2100, 0)
            ElseIf (e.KeyCode = Keys.D7) Then
                cbGiaidoan.SelectedIndex = 6
            ElseIf (e.KeyCode = Keys.Tab) Then
                sgworldMain.Command.Execute(1065, 0)
                If Bd3D = True Then
                    sgworld3DBd.Command.Execute(1065, 0)
                End If
                If A3D = True Then
                    sgworld3DA.Command.Execute(1065, 0)
                End If
            ElseIf (e.KeyCode = Keys.Space) Then
                If Lenhve = "NNtructiep" Or Lenhve = "TatDt" Then
                    PathtoTxt()
                    txtNnTrt.Text = XoaLap(txtGroup.Text)
                End If
                If Lenhve = "DTdichuyen" Then
                    PathtoTxt()
                    BienEmpty()
                    BienEmpty()
                End If
            ElseIf (e.KeyCode = 188) Then 'Phim (,<) DI CHUYEN DOI TUONG THEO DT TREN SA BAN VAT LY
                Try
                    DieuKhienCo.Text = ""
                    txtGroup.Text = ""
                    'FrmVL.LiDT.SelectedItems.Clear()
                    sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem("Dchuyen"))
                Catch ex As Exception
                    Exit Try
                End Try
                HotKey("DTdichuyen")
            ElseIf (e.KeyCode = 190) Then 'Phim (.>)tat DT THEO DANH SACH
                TopHieuung()
                If txtGroup.Text <> "" Then
                    txtNnTrt.Text = txtGroup.Text
                    AnDT(txtNnTrt.Text)
                ElseIf txtNnTrt.Text <> "" Then
                    AnDT(txtNnTrt.Text)
                    'TXarduino(txtGroup.Text, "An")
                Else
                    HotKey("TatDt")
                End If
                BtTrucTiep("0")
            ElseIf (e.KeyCode = 191) Then 'Phim (/?) hIEN DT AN
                TopHieuung()
                If txtGroup.Text <> "" Then
                    txtNnTrt.Text = txtGroup.Text
                    HienDTan(txtNnTrt.Text)
                ElseIf txtNnTrt.Text <> "" Then
                    HienDTan(txtNnTrt.Text)
                    'TXarduino(txtGroup.Text, "Hien")
                End If
                BtTrucTiep("1")
            ElseIf (e.KeyCode = 20) Then 'Phim (cAP LOCK) FrmVL

            ElseIf (e.KeyCode = Keys.D8) Then
                If Bd3D = False Then
                    sgworldMain.Command.Execute(1054, 0) '2D
                End If
            ElseIf (e.KeyCode = Keys.D9) Then
                If Bd3D = False Then
                    sgworldMain.Command.Execute(1052, 0) '2D
                End If
            ElseIf (e.KeyCode = Keys.D0) Then
                sgworldMain.Command.Execute(1021, 0)
                If Bd3D = True Then
                    sgworld3DBd.Command.Execute(1021, 0) 'Select
                End If
                If A3D = True Then
                    sgworld3DA.Command.Execute(1021, 0) 'Select
                End If
            ElseIf (e.KeyCode = Keys.F) Then
                File.Delete(folderPath1 & "\Doituong.xml")
                ScanGroup()
                sgworldMain.Project.Save()
                If FrmTC.Instance.FRMS = True Then
                    FrmTC.Instance.Open3DBD1()
                End If
            ElseIf (e.KeyCode = Keys.J) Then
                Nen += 1
                If Nen = 1 Then
                    AnhVT()
                ElseIf Nen = 2 Then
                    Anh74TinhThanh()
                    Nen = 0
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub HotKey(Lenh As String)
        Try
            TopHieuung()
            ChebBangDT.Checked = False
            pathTQ = ""
            txtNnTrt.Text = ""
            Lenhve = Lenh
            sgworldMain.Command.Execute(1021, 0)
        Catch
        End Try
    End Sub

    Private Sub AnhVT()
        Try
            Dim id As String = sgworldMain.ProjectTree.FindItem("AnhVT")
            If String.IsNullOrWhiteSpace(id) Or String.IsNullOrEmpty(id) Then
                sgworldMain.ProjectTree.LoadFlyLayer(PathData & "\AnhVT.fly",)
            Else
                sgworldMain.ProjectTree.DeleteItem(id)
            End If
        Catch
        End Try
    End Sub
    Private Sub Anh74TinhThanh()
        Try
            Dim id As String = sgworldMain.ProjectTree.FindItem("Hanh Chinh")
            If String.IsNullOrWhiteSpace(id) Or String.IsNullOrEmpty(id) Then
                sgworldMain.ProjectTree.LoadFlyLayer(PathData & "\Hanh Chinh.fly",)
            Else
                sgworldMain.ProjectTree.DeleteItem(id)
            End If
        Catch
        End Try
    End Sub
    Private Sub Nentrinhdien()
        Try
            Dim id As String = sgworldMain.ProjectTree.FindItem("Trinhchieu")
            If String.IsNullOrWhiteSpace(id) Or String.IsNullOrEmpty(id) Then
                sgworldMain.ProjectTree.LoadFlyLayer(PathData & "\Trinhchieu.fly",)
            End If
            sgworldMain.Command.Execute(1054, 0)
        Catch
        End Try
    End Sub

#Region "  Giao dien Trinh chieu"

    Private Sub BtnOpenTrC_Click(sender As Object, e As EventArgs) Handles BtnOpenTrC.Click
        TrinhchieuPN()
    End Sub

    Private Sub CbPhimAmthanh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPhimAmthanh.SelectedIndexChanged
        Try
            If cbPhimAmthanh.SelectedIndex = 0 Then
                cbVitriPhim.Enabled = True
            Else
                cbVitriPhim.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub PnTrinhchieu_VisibleChanged(sender As Object, e As EventArgs) Handles pnTrinhchieu.VisibleChanged
        Try
            If pnTrinhchieu.Visible = False Then
                ChebBangDT.Checked = True
                menuMain.Visible = True
                MenuClose.Visible = True
                TopHieuung()
                pnLogo.Visible = True
            End If

            If pnTrinhchieu.Visible = True Then
                '  File.Delete(PathData1 & "\TrtSabanVL.txt")
                ChebBangDT.Checked = False
                menuMain.Visible = False
                MenuClose.Visible = False
                pnLogo.Visible = False
                CloseAllPanel()
                CloseAllTool()
            End If

            If Bd3D = True Then
                Bdt3Dbd_3DA(Frm3Dbd.Instance.AxTEInformationWindowEx1, Frm3Dbd.Instance.AxTE3DWindowEx1)
            End If
            If A3D = True Then
                Bdt3Dbd_3DA(Frm3DA.Instance.AxTEInformationWindowEx2, Frm3DA.Instance.AxTE3DWindowEx2)
            End If
        Catch
        End Try
    End Sub

    Public Sub TrinhchieuPN()
        Try
            txtTenFileTrC.Text = ""
            OpenFileTrC(2)
            If motrinhchieu = True Then
                pnTrinhchieu.Visible = True
                If Bd3D = True Then
                    Frm3Dbd.Instance.MenuClose.Visible = False
                End If
                If A3D = True Then
                    Frm3DA.Instance.MenuClose.Visible = False
                End If
            End If
        Catch
        End Try
    End Sub


    Public Sub LisTrinhchieu()
        Try
            dongTrinhchieu = LisTrC.Text
            ' txtSoTTTrC.Text = (1 + LisTrC.SelectedIndex).ToString
        Catch
        End Try
    End Sub
    Private Sub LisTrC_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles LisTrC.SelectedIndexChanged
        LisTrinhchieu()
    End Sub

    Private Sub OpenFileTrC(STT As Integer)
        Try
            Dim OpenFile As New OpenFileDialog With {.Filter = "Tập tin Text (*txt) | *.txt", .Multiselect = True}
            If OpenFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                'Me.WindowState = FormWindowState.Normal
                'Me.FormBorderStyle = FormBorderStyle.None
                'Me.Bounds = Screen.PrimaryScreen.Bounds
                motrinhchieu = True
                Dim TextFile As New StreamReader(OpenFile.FileName, True)
                Dim Line As String = TextFile.ReadLine()
                menuMain.Visible = False
                While (String.IsNullOrEmpty(Line) = False)
                    Dim Text As String = Decrypt(Line, PassKey)
                    Dim Mang1() As String = Text.Split(";")
                    If STT = 1 Then
                        libDanhsachTrC.Items.Add(Mang1(0))
                        liBDanhsachTrC2.Items.Add(Text)
                    ElseIf STT = 2 Then
                        LisTrC.Items.Add(Text)
                    End If
                    Line = TextFile.ReadLine()
                End While
                FrmSBVLM.Instance.TB_tencanh.Text = Path.GetFileName(OpenFile.FileName)
                TextFile.Close()
            Else
                motrinhchieu = False
                FrmSBVLM.Instance.thoatkichban()
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtTTTrC_TextChanged(sender As Object, e As EventArgs) Handles txtTTTrC.TextChanged
        Try
            LisTrC.SelectedIndex = Val(txtTTTrC.Text) - 1
            Trinhchieu()
            If IsConnected() = True Then
                SendTrinhchieu(dongTrinhchieu)
            End If
            FrmSBVLM.Instance.TB_socanh.Text = txtTTTrC.Text
        Catch
        End Try
    End Sub

    Private Sub PanelVideo_VisibleChanged(sender As Object, e As EventArgs) Handles panelVideo.VisibleChanged
        Try
            If panelVideo.Visible = True Then
                Dim BienDTPhim As String = dongTrinhchieu.Split(";")(5).Split("_")(0)
                BienDTPhim = Chr(34) & BienDTPhim & Chr(34) 'Quotes around
                Dim retVal As Integer = mciSendString("open " & BienDTPhim & " type mpegvideo Alias movie parent " & panelVideo.Handle.ToInt32 & " style child", 0, 0, 0) 'opens it to the movie window
                Dim Width, Height As Integer 'Declareations for the size and pos.
                Width = panelVideo.Size.Width 'changes the width
                Height = panelVideo.Size.Height 'changes the height...
                retVal = mciSendString("Resume movie", 0, 0, 0) 'i chose resume instead of play because it will play when paused...
                retVal = mciSendString("put movie window at " & 0 & " " & 0 & " " & Width & " " & Height, 0, 0, 0) 'alignes the movie window...
                retVal = mciSendString("play movie repeat", 0&, 0, 0)
            Else
                mciSendString("close movie", 0, 0, 0)
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnTien_Click(sender As Object, e As EventArgs) Handles btnTien.Click
        Try
            tb_TrinhChieu.Text = "KB+"
            Me.Refresh()
        Catch ex As Exception
            Exit Try
        End Try
        If IsConnected() = True Then
            SendTrinhchieu(dongTrinhchieu)
        End If
    End Sub

    Private Sub BtnDung_Click(sender As Object, e As EventArgs) Handles btnDung.Click
        If IsConnected() = True Then
            SendTrinhchieu("0")
        End If
    End Sub

    Private Sub BtnLui_Click(sender As Object, e As EventArgs) Handles btnLui.Click
        Try
            tb_TrinhChieu.Text = "KB-"
            Me.Refresh()
        Catch eX As Exception
            Exit Try
        End Try
        If IsConnected() = True Then
            SendTrinhchieu(dongTrinhchieu)
        End If
    End Sub

    Private Sub BtnCloseTrC_Click(sender As Object, e As EventArgs) Handles btnCloseTrC.Click
        Try
            If motrinhchieu = False Then

                txtTenFileTrC.Text = ""
                LisTrC.Items.Clear()
                If Bd3D = True Then
                    Frm3Dbd.Instance.MenuClose.Visible = True
                End If
                If A3D = True Then
                    Frm3DA.Instance.MenuClose.Visible = True
                End If
                TopHieuung()
                pnTrinhchieu.Visible = False
            End If
        Catch
        End Try
    End Sub

#End Region

#End Region
    Private Sub CrFlage()
        Try
            If Lenhve = "veco" Then
                If cbTa_DP.SelectedIndex = 1 Then
                    fLabelStyleMain.PivotAlignment = "Bottom,left"
                    If cbChieuKH.SelectedIndex = 1 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,Right"
                    Else
                        fLabelStyleMain.PivotAlignment = "Bottom,left"
                    End If
                Else
                    fLabelStyleMain.PivotAlignment = "Bottom,Right"
                    If cbChieuKH.SelectedIndex = 1 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,left"
                    Else
                        fLabelStyleMain.PivotAlignment = "Bottom,Right"
                    End If
                End If
                fLabelStyleMain.TextAlignment = "Center, Center"
                If Bd3D = False Then
                    mThumuc = "\2X\"
                    m2X = ""
                Else
                    mThumuc = "\2XD2\"
                    m2X = "2"
                End If

                'If loaiKH = "1100003" Or loaiKH = "1100004" Or loaiKH = "1100005" Or loaiKH = "1100006" Or loaiKH = "1100007" Or loaiKH = "1100008" Or loaiKH = "1100009" Or loaiKH = "1100010" Then
                '    If cbTa_DP.SelectedIndex = 1 Then
                '        loaiKH = loaiKH.Substring(1, loaiKH.Length - 1)
                '    End If
                'End If

                If loaiKH = "130000" Or loaiKH = "1200001" Or loaiKH = "130001" Or loaiKH = "100008" Or loaiKH = "1100008" Or loaiKH = "2000015" Or
                           loaiKH = "2000115" Or loaiKH = "130014" Or loaiKH = "280114" Or loaiKH = "140007" Or loaiKH = "130006" Or loaiKH = "130007" Or
                           loaiKH = "100009" Or loaiKH = "1100009" Or loaiKH = "130008" Or loaiKH = "130015" Or loaiKH = "280115" Or loaiKH = "140008" Or
                           loaiKH = "130009" Or loaiKH = "100010" Or loaiKH = "1100010" Or loaiKH = "280116" Or loaiKH = "140009" Or loaiKH = "130010" Or
                           loaiKH = "130011" Or loaiKH = "130016" Or loaiKH = "130013" Or loaiKH = "130012" Then
                    mThumuc = "\2X\"
                    m2X = ""
                    fLabelStyleMain.PivotAlignment = "Bottom,Center"
                    If loaiKH = "130000" Or loaiKH = "1200001" Or loaiKH = "130001" Then
                        If cbChieuKH.SelectedIndex = 0 Then
                            textKH += "  "
                            fLabelStyleMain.TextAlignment = "Bottom, Right"
                        Else
                            textKH += "     "
                            fLabelStyleMain.TextAlignment = "Bottom, left"
                        End If
                    Else
                        ChieuKH = ""
                        textKH = "           " & textKH
                        fLabelStyleMain.TextAlignment = "Bottom, left"
                    End If
                Else
                    If cbChieuKH.SelectedIndex = 1 Or cbTa_DP.SelectedIndex = 1 Then
                        textKH += "   "
                    Else
                        textKH = "   " & textKH
                    End If
                End If

            ElseIf Lenhve = "Taungam" Then
                If TxtGhichuKH.Text <> "" Then
                    textKH = TxtGhichuKH.Text
                    fLabelStyleMain.FontSize *= 0.5
                Else
                    textKH = ""
                End If
                fLabelStyleMain.TextAlignment = "Center, Center"
                fLabelStyleMain.PivotAlignment = "Bottom,Center"
                If loaiKH = "2000115" Or loaiKH = "2000015" Or loaiKH = "20015" Or loaiKH = "2120033" Or loaiKH = "212032a" Or loaiKH = "2120031" Or
                    loaiKH = "2110012" Or loaiKH = "2110011" Or loaiKH = "2110021" Or loaiKH = "2130035" Or loaiKH = "1200029" Or loaiKH = "2130037" Or
                    loaiKH = "2130045" Or loaiKH = "2130046" Or loaiKH = "2130042" Or loaiKH = "2130044" Or loaiKH = "2130043" Or loaiKH = "31002" Or
                    loaiKH = "1300012" Or loaiKH = "1300019" Or loaiKH = "1200029" Or loaiKH = "1200019" Or loaiKH = "1200020" Or loaiKH = "1200028" Or
                    loaiKH = "1200028" Or loaiKH = "1200038" Or loaiKH = "1200039" Or loaiKH = "1200041" Or loaiKH = "1200040" Or
                    loaiKH = "1200030" Or loaiKH = "1200036" Or loaiKH = "2130036" Or loaiKH = "260005" Or loaiKH = "260006" Or loaiKH = "250015" Or
                    loaiKH = "250023" Or loaiKH = "610011" Or loaiKH = "610010" Or loaiKH = "610015" Or loaiKH = "270001" Or loaiKH = "270002" Or
                    loaiKH = "271001" Or loaiKH = "271003" Or loaiKH = "270004" Or loaiKH = "270005" Or loaiKH = "270006" Or loaiKH = "270008" Or
                    loaiKH = "270009" Or loaiKH = "270011" Or loaiKH = "270014" Or loaiKH = "270017" Or loaiKH = "270020" Or loaiKH = "270021" Or
                    loaiKH = "270022" Or loaiKH = "270239" Or loaiKH = "270023" Or loaiKH = "270240" Or loaiKH = "270273" Or loaiKH = "270238" Or
                    loaiKH = "270235" Or loaiKH = "270236" Or loaiKH = "270294" Or loaiKH = "270295" Or loaiKH = "270296" Or loaiKH = "270297" Or
                    loaiKH = "270298" Or loaiKH = "270299" Or loaiKH = "270248" Or loaiKH = "270249" Or loaiKH = "270250" Or loaiKH = "270251" Or
                    loaiKH = "270253" Or loaiKH = "270254" Or loaiKH = "270260" Or loaiKH = "270261" Or loaiKH = "270263" Or loaiKH = "270264" Or
                    loaiKH = "270265" Or loaiKH = "270267" Or loaiKH = "270277" Or loaiKH = "270279" Or loaiKH = "270280" Or loaiKH = "270281" Or
                    loaiKH = "280005" Or loaiKH = "280006" Or loaiKH = "280017" Or loaiKH = "280018" Or loaiKH = "280018" Or loaiKH = "280024" Or
                    loaiKH = "280025" Or loaiKH = "280028" Or loaiKH = "280027" Or loaiKH = "280029" Or loaiKH = "280026" Or loaiKH = "280026" Or
                    loaiKH = "280039" Or loaiKH = "280040" Or loaiKH = "280041" Or loaiKH = "280042" Or loaiKH = "280043" Or loaiKH = "280046" Or
                    loaiKH = "280047" Or loaiKH = "290015" Or loaiKH = "290016" Or loaiKH = "290011" Or loaiKH = "290012" Or loaiKH = "290013" Or
                    loaiKH = "290014" Or loaiKH = "290010" Or loaiKH = "218017" Or loaiKH = "218023" Or loaiKH = "218025" Or loaiKH = "218026" Or
                    loaiKH = "218027" Or loaiKH = "218042" Or loaiKH = "218051" Or loaiKH = "218056" Or loaiKH = "218057" Or loaiKH = "218058" Or
                    loaiKH = "218059" Or loaiKH = "218061" Or loaiKH = "261003" Or loaiKH = "261004" Or loaiKH = "261005" Or loaiKH = "261006" Or
                    loaiKH = "261007" Or loaiKH = "261008" Or loaiKH = "261009" Or loaiKH = "261010" Or loaiKH = "250006" Or loaiKH = "251014" Or
                    loaiKH = "240011" Or loaiKH = "280000" Or loaiKH = "250017" Or loaiKH = "250018" Or loaiKH = "280003" Or
                    loaiKH = "280003" Or loaiKH = "280003b" Or loaiKH = "280005" Or loaiKH = "280005b" Or loaiKH = "280010" Or
                    loaiKH = "610021" Or loaiKH = "610022" Or loaiKH = "a1200029" Then
                    ChieuKH = ChieuKH
                Else
                    ChieuKH = ""
                End If

                If loaiKH = "260005" Or loaiKH = "260006" Or loaiKH = "260010" Or loaiKH = "260007" Or loaiKH = "260008" Or loaiKH = "260009" Or loaiKH = "260011" Then
                    textKH = "ĐC"
                ElseIf loaiKH = "260012" Or loaiKH = "260013" Or loaiKH = "260014" Then
                    textKH = "                 ĐCbđ"
                ElseIf loaiKH = "250020" Then
                    textKH = "TG"
                ElseIf loaiKH = "270241" Then
                    textKH = "CĐ"
                End If
                mThumuc = "\2X\"
                m2X = ""
            End If
            fileImage = PathLabel(mThumuc, loaiKH, ChieuKH, mP, m2X, Ta_Doiphuong, tenGiaidoan)
            Dim mPk As IPosition71 = Nothing
            If chebVeKH.Checked = True Then
                mPk = TDo4_o9()
            Else
                mPk = mPointClick
            End If
            'MsgBox(fileImage)
            Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(mPk, textKH, fileImage, fLabelStyleMain, GroupBac2Main, tenKH)
            mText.Tooltip.Text = mota
            mText.Position.Altitude = -0.25 * fLabelStyleMain.Scale
            mText.Position.AltitudeType = 2
            If chebVeKH.Checked = True Then
                ZoomLAND(sgworldMain, mText)
                'ZoomTQ(sgworldMain)
            End If
            mLabelArray.Add(mText)
            SendLabel(mText)
            SLenhve3DMs()
        Catch ex As Exception
        End Try
    End Sub
#Region ".....Vẽ nhieu So chi huy"

    Private Sub PanelMultiFlage_VisibleChanged(sender As Object, e As EventArgs) Handles panelMultiFlage.VisibleChanged
        Try
            If panelMultiFlage.Visible = True Then
                Dim dvNhieuSCH As String = String.Empty
                If cbTa_DP.SelectedIndex = 0 Then
                    dvNhieuSCH = "Chọn đơn vị,Tiểu đoàn,Trung đoàn,Lữ đoàn,Sư đoàn,Quân đoàn,Quân chủng,Quân khu,Bộ BTTM"
                Else
                    dvNhieuSCH = "Chọn đơn vị,Tiểu đoàn,Trung đoàn,Lữ đoàn,Sư đoàn,Quân đoàn,Tập đoàn quân"
                End If
                For i As Integer = 0 To 4
#Disable Warning IDE0017 ' Simplify object initialization
                    chebHL(i) = New CheckBox With {.AutoSize = True, .Text = "Đơn vị Kỹ thuật.", .Location = New System.Drawing.Point(6, 36 + (i * 25))}
#Enable Warning IDE0017 ' Simplify object initialization
                    chebHL(i).FlatStyle = FlatStyle.System
                    panelMultiFlage.Controls.Add(chebHL(i))
                    AddHandler chebHL(i).CheckedChanged, AddressOf ChebHL_CheckedChanged
#Disable Warning IDE0017 ' Simplify object initialization
                    cbNhieuSCH(i) = New ComboBox With {.Size = New System.Drawing.Size(100, 21), .Location = New System.Drawing.Point(6 + chebHL(i).Width, 30 + (i * 25))}
#Enable Warning IDE0017 ' Simplify object initialization
                    cbNhieuSCH(i).FlatStyle = FlatStyle.System
                    For j As Integer = 0 To dvNhieuSCH.Split(",").Length - 1
                        cbNhieuSCH(i).Items.Insert(j, dvNhieuSCH.Split(",")(j))
                    Next
                    cbNhieuSCH(i).SelectedIndex = 0
                    panelMultiFlage.Controls.Add(cbNhieuSCH(i))
                    AddHandler cbNhieuSCH(i).SelectedIndexChanged, AddressOf CbFlageS_SelectedIndexChanged

                    lbNhieuSCH(i) = New Label With {.AutoSize = True, .Text = "Phiên hiệu:", .Margin = New Padding(0, 5, 0, 0), .Location = New System.Drawing.Point(4 + cbNhieuSCH(i).Left + cbNhieuSCH(i).Width, 33 + (i * 25))}
                    panelMultiFlage.Controls.Add(lbNhieuSCH(i))

#Disable Warning IDE0017 ' Simplify object initialization
                    txtDT(i) = New TextBox With {.Size = New System.Drawing.Size(65, 21), .Location = New System.Drawing.Point(2 + lbNhieuSCH(i).Left + lbNhieuSCH(i).Width, 30 + (i * 25))}
#Enable Warning IDE0017 ' Simplify object initialization
                    txtDT(i).BorderStyle = BorderStyle.FixedSingle '= FlatStyle.Flat
                    panelMultiFlage.Controls.Add(txtDT(i))
                    txtDT(i).Enabled = False
                    txtDT(i).TextAlign = HorizontalAlignment.Center
                Next
                panelMultiFlage.Top = Me.menuMain.Height + 10
                panelMultiFlage.Left = Me.Width - (panelMultiFlage.Width + 5)
            Else
                For i As Integer = 0 To 4
                    panelMultiFlage.Controls.Remove(cbNhieuSCH(i))
                    panelMultiFlage.Controls.Remove(chebHL(i))
                    panelMultiFlage.Controls.Remove(txtDT(i))
                    panelMultiFlage.Controls.Remove(lbNhieuSCH(i))
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub CbFlageS_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            For i As Integer = 0 To 4
                If cbNhieuSCH(i).SelectedIndex > 0 Then
                    txtDT(i).Enabled = True
                    txtDT(i).Focus()
                Else
                    txtDT(i).Enabled = False
                    txtDT(i).Text = ""
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub VenhieuSCH()
        Try
            VeCoTang1()
            For i As Integer = 3 To 0 Step -1
                VeCoTQ(cbNhieuSCH(i), chebHL(i), 0.044 - (i * 0.00925), 4800 - (i * 1000), txtDT(i).Text)
            Next
            SLenhve3DMs()
            panelMultiFlage.Visible = False
        Catch
        End Try
    End Sub

    Private Sub VeCoTang1()
        Try
            If cbNhieuSCH(4).SelectedIndex > 0 Then
                fLabelStyleMain.PivotAlignment = "Bottom,Left"
                If chebHL(4).Checked = True Then
                    Select Case cbNhieuSCH(4).SelectedIndex
                        Case 1
                            loaiKH = "1100007"
                        Case 2
                            loaiKH = "1100006"
                        Case 3
                            loaiKH = "1100005"
                        Case 4
                            loaiKH = "1100004"
                        Case 5
                            loaiKH = "1100003"
                    End Select
                Else
                    Select Case cbNhieuSCH(4).SelectedIndex
                        Case 1
                            loaiKH = "100007"   'tieu doan
                        Case 2
                            loaiKH = "100006"   'trung doam
                        Case 3
                            loaiKH = "100005"  'lu doan
                        Case 4
                            loaiKH = "100004"   'su doan, vung hai quan
                        Case 5
                            loaiKH = "1000003" ' quan doan, binh chung
                        Case 6
                            loaiKH = "1000002"   'quan chung
                        Case 7
                            loaiKH = "1000001"   'quna khu
                        Case 8
                            loaiKH = "1000000"   'quna khu
                    End Select
                End If
                fLabelStyleMain.TextAlignment = "center,center"
                fLabelStyleMain.PivotAlignment = "Bottom,right"
                If cbChieuKH.SelectedIndex = 1 Then
                    fLabelStyleMain.PivotAlignment = "Bottom,Left"
                    '    tenKH = txtDT(4).Text & "     "
                    'Else
                    '    tenKH = "     " & txtDT(4).Text
                End If
                If cbTa_DP.SelectedIndex = 1 Then
                    fLabelStyleMain.PivotAlignment = "Bottom,Left"
                    If cbChieuKH.SelectedIndex = 1 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,right"
                    End If
                    'If cbChieuKH.SelectedIndex = 1 Then
                    '    tenKH = "     " & txtDT(4).Text
                    'Else
                    '    tenKH = txtDT(4).Text & "     "
                    'End If
                Else
                End If
                Dim Pchu As String, mTDP As String, mGD As String
                If chebHL(4).Checked = True Then
                    mTDP = "1"
                    mGD = "1.mkx"
                    Pchu = "P"
                Else
                    mTDP = Ta_Doiphuong
                    mGD = tenGiaidoan
                    Pchu = ""
                End If
                SCoNhSCH(mPointClick, txtDT(4).Text, Pchu, mTDP, mGD, 0, 0)
            End If
        Catch
        End Try
    End Sub

    Private Sub VeCoTQ(cbNhieuco As ComboBox, cbKT As CheckBox, dy As Double, chieuCao As Double, txtSohieu As String)
        Try
            If cbNhieuco.SelectedIndex > 0 Then
                Select Case cbNhieuco.SelectedIndex
                    Case 1
                        loaiKH = "910007"   'tieu doan
                    Case 2
                        loaiKH = "910006"   'trung doam
                    Case 3
                        loaiKH = "910005"  'lu doan
                    Case 4
                        loaiKH = "910004"   'su doan, vung hai quan
                    Case 5
                        loaiKH = "910003" ' quan doan, binh chung
                    Case 6
                        loaiKH = "910002"   'quan chung
                    Case 7
                        loaiKH = "910001"   'quna khu
                    Case 8
                        loaiKH = "910000"   'BTTM
                End Select

                Dim Pchu As String, mTDP As String, mGD As String
                If cbKT.Checked = True Then
                    mTDP = "1"
                    mGD = "1.mkx"
                    Pchu = "P"
                Else
                    mTDP = Ta_Doiphuong
                    mGD = tenGiaidoan
                    Pchu = ""
                End If
                Dim p As IPosition71 '= sgworldMain.Creator.CreatePosition(mPointClick.X, mPointClick.Y, 0, 2, 0, 0, 0, 0)
                If Bd3D = False Then
                    p = sgworldMain.Creator.CreatePosition(mPointClick.X, mPointClick.Y, chieuCao * Tyle, 2, 0, 0, 0, 0)
                Else
                    p = sgworldMain.Creator.CreatePosition(mPointClick.X, mPointClick.Y + dy * Tyle, 0, 2, 0, 0, 0, 0)
                End If
                SCoNhSCH(p, txtSohieu, Pchu, mTDP, mGD, dy, chieuCao)
            End If
        Catch
        End Try
    End Sub

    Private Sub SCoNhSCH(P As IPosition71, Sohieu As String, Pchu As String, mTDP As String, mGD As String, dy As Double, chieuCao As Double)
        Try
            If loaiKH <> "" Then
                If Bd3D = False Then
                    fileImage = PathData & "\2X\" & ChieuKH & Pchu & loaiKH & mTDP & mGD
                Else
                    fileImage = PathData & "\2XD2\" & ChieuKH & Pchu & "2" & loaiKH & mTDP & mGD
                End If
                'MsgBox(fileImage)
                fLabelStyleMain.TextAlignment = "center,center"
                fLabelStyleMain.PivotAlignment = "Bottom,right"
                If cbTa_DP.SelectedIndex = 1 Then
                    fLabelStyleMain.PivotAlignment = "Bottom,Left"
                    If cbChieuKH.SelectedIndex = 1 Then
                        fLabelStyleMain.PivotAlignment = "Bottom,right"
                    End If
                End If
                If cbChieuKH.SelectedIndex = 1 Then
                    fLabelStyleMain.PivotAlignment = "Bottom,Left"
                End If
                '   fLabelStyleMain.TextColor = mauDen
                fLabelStyleMain.Scale = fLabelStyleMain.Scale
                If loaiKH = "910001" Or loaiKH = "910007" Or loaiKH = "1000001" Then
                    If cbChieuKH.SelectedIndex = 1 Or cbTa_DP.SelectedIndex = 1 Then
                        Sohieu += "      "
                    Else
                        Sohieu = "      " & Sohieu
                    End If
                End If
                Dim sLabel As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(P, Sohieu, fileImage, fLabelStyleMain, GroupBac2Main, Trim(Sohieu))
                sLabel.Position.Altitude = P.Altitude
                Dim MMota As String = mota & "," & dy.ToString & "," & (chieuCao * Tyle).ToString
                sLabel.Tooltip.Text = MMota
                mLabelArray.Add(sLabel)
                SendLabel(sLabel)
            End If
        Catch
        End Try
    End Sub

    Private Sub ChebHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If panelMultiFlage.Visible = True Then
                For i As Integer = 0 To 4
                    If chebHL(i).Checked = True Then
                        If cbNhieuSCH(i).Items.Count = 9 Then
                            cbNhieuSCH(i).Items.RemoveAt(8)
                            cbNhieuSCH(i).Items.RemoveAt(7)
                        End If
                    Else
                        If cbNhieuSCH(i).Items.Count < 9 Then
                            cbNhieuSCH(i).Items.Insert(7, "Quân khu")
                            cbNhieuSCH(i).Items.Insert(8, "Bộ BTTM")
                        End If
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnChonvitri_Click(sender As Object, e As EventArgs) Handles btnChonvitri.Click
        SetMouseArrow()
    End Sub


#End Region
#Region ".... KHQS"

    Private Sub NewTool(SLve As String, Mtl As String, e As ToolStripItemClickedEventArgs)
        Try
            Dim ret As Boolean = IsNumeric(Mtl.Chars(2))
            If ret = True Then
                STaungam(SLve, Mtl.Replace("tl", ""))
            Else
                STaungam("", Mtl.Replace("tl", ""))
            End If
            mota = e.ClickedItem.ToolTipText.Split(".")(0)
        Catch
        End Try
    End Sub

    Private Sub ToolBB_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolBB.ItemClicked
        Try
            mauKT = False

            If e.ClickedItem.Name = "tl1100003" Or e.ClickedItem.Name = "tl1100004" Or e.ClickedItem.Name = "tl1100005" Or e.ClickedItem.Name = "tl280111" Or e.ClickedItem.Name = "tl140001" Or e.ClickedItem.Name = "tl1100006" Or
              e.ClickedItem.Name = "tl280112" Or e.ClickedItem.Name = "tl140002" Or e.ClickedItem.Name = "tl1100007" Or e.ClickedItem.Name = "tl280113" Or e.ClickedItem.Name = "tl140003" Or e.ClickedItem.Name = "tl1100008" Or
              e.ClickedItem.Name = "tl130014" Or e.ClickedItem.Name = "tl280114" Or e.ClickedItem.Name = "tl140007" Or e.ClickedItem.Name = "tl1100009" Or e.ClickedItem.Name = "tl130015" Or e.ClickedItem.Name = "tl280115" Or
              e.ClickedItem.Name = "tl140008" Or e.ClickedItem.Name = "tl1100010" Or e.ClickedItem.Name = "tl280116" Or e.ClickedItem.Name = "tl140009" Or e.ClickedItem.Name = "tl130016" Then
                mauKT = True
            Else
                mauKT = False
            End If

            NewTool("veco", e.ClickedItem.Name, e)

            If e.ClickedItem.Name = "tlVenhieuco" Then
                If Dkien = True Then
                    SetMouseHand()
                    SPanel(panelMultiFlage)
                End If
            End If

            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolBB, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#Region "....Hanh dong tac chien"

    Private Sub ToolHDTC_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolHDTC.ItemClicked
        Try
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            If e.ClickedItem.Name = "tltrandiachongtang" Or e.ClickedItem.Name = "tl82020" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlHQbangMB" Or e.ClickedItem.Name = "tlHQbangTau" Or e.ClickedItem.Name = "tlHQbangxelua" Or e.ClickedItem.Name = "tlHQbangoto" Or e.ClickedItem.Name = "tlhanhquanbo" Then
                If cbLoaiBChanhquanHDTC.SelectedIndex = 0 Or cbLoaiKHQS_HDTC.SelectedIndex = 0 Then
                    MsgBox("Chọn Quân, Binh chủng và Đơn vị hành quân....!!!")
                    Exit Sub
                End If
            End If

            If e.ClickedItem.Name = "tlDHPNBB" Or e.ClickedItem.Name = "tlKvPNthenchot" Or e.ClickedItem.Name = "tlDHPNBBXT" Then
                If cbLoaiKHQS_HDTC.SelectedIndex = 0 Then
                    MsgBox("Hãy chọn đơn vị triển khai phòng thủ....!!!")
                    Exit Sub
                ElseIf cbLoaiKHQS_HDTC.SelectedIndex = 1 Or cbLoaiKHQS_HDTC.SelectedIndex = 2 Or cbLoaiKHQS_HDTC.SelectedIndex = 3 Then
                    MsgBox("Đội hình phòng ngự của trung đoàn, lữ đoàn, sư đoàn hãy thực hiện thủ công...!")
                    Exit Sub
                End If
            End If

            If e.ClickedItem.Name = "tlTuyenTrKTcBobinh" Or e.ClickedItem.Name = "tlTuyenTrKTcBobinhXetang" Or e.ClickedItem.Name = "tlTuyenTrKTcBBtruocXT" Or e.ClickedItem.Name = "tlTuyenTrKTcXTtruocBB" Then
                If cbLoaiKHQS_HDTC.SelectedIndex = 0 Then
                    MsgBox("Hãy chọn đơn vị triển khai tiến công....!!!")
                    Exit Sub
                End If
            End If

            If e.ClickedItem.Name = "tlDoihinhBBTamdung" Then
                cbLoaiKHQS_HDTC.SelectedIndex = 5
                cbKieuTrKTiencong.SelectedIndex = 1
            End If

            If e.ClickedItem.Name = "tlGit2140000" Then
                TyleX = 1000
            Else
                TyleX = 5000
            End If

            DorongVung = 1000
            TyleY = 300
            NewTool("Taungam", e.ClickedItem.Name, e)
            SAddToolStripItem(ToolHDTC, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#Region "   Mui ten"

    Private isFinishedChuYeu As Boolean = False
    Private TDMuiten As String = String.Empty
    Private MauMT As IColor71 = Nothing

    Private Sub MuitenTQ(mGroupBac2 As String)
        Try
            CreatePoint3D()
            If PllVtNum >= 2 Then
                If Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Then
                    tempGroup = Gr01(sgworldMain, "Temp") ' sgworldMain.ProjectTree.FindItem("Temp")
                    CrMT(tempGroup)
                Else
                    CrMT(mGroupBac2)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub MuitenTQ1(mGroupBac2 As String)
        Try
            CreatePoint3D()
            If PllVtNum >= 2 Then
                If Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Then
                    tempGroup = Gr01(sgworld3DBd, "Temp") ' sgworldMain.ProjectTree.FindItem("Temp")
                    CrMT1(tempGroup)
                Else
                    CrMT1(mGroupBac2)
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub CreateArrowFor3D()
        Try
            If isFinishedChuYeu Then
                If Lenhve = "muiteincongthuyeu" Then
                    Dim cRingD As ILinearRing = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(DTtoArray(sgworldMain, cPlg2))
                    Dim mGeoD As IGeometry = sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRingD, Nothing)
                    Dim liD As New List(Of IPosition71) ' = GeoToList(mGeoD)
                    Dim soDau As Integer, soCuoi As Integer
                    If cbChieuMuiThuyeu.SelectedIndex = 0 Then
                        soDau = 3
                        soCuoi = GeoToList(mGeoD).Count / 2 - 1
                    Else
                        soDau = GeoToList(mGeoD).Count / 2 + 2
                        soCuoi = GeoToList(mGeoD).Count - 2
                    End If
                    For i As Integer = soDau To soCuoi
                        liD.Add(GeoToList(mGeoD)(i))
                    Next
                    sgworldMain.Creator.DeleteObject(cPlg2.ID)
                    cPlg2 = sgworldMain.Creator.CreatePolygonFromArray(ListtoAarray(liD), mau2, mau2, 2, GroupBac2Main, tenKH & "2")
                    cPlg2.Tooltip.Text = "mui tan cong thu yeu"
                End If
                SendVung(cPlg1)
                mRegionArray.Add(cPlg1)
                If Not Lenhve = "muiteincongthuyeu" Then
                    SendVung(cPlg2)
                    mRegionArray.Add(cPlg2)
                End If
                SLenhve3DMs()
                isFinishedChuYeu = False
            End If
        Catch
        End Try
    End Sub
    Public Sub CrMT(ByVal mGroupBac2 As String)
        Try
            If Not Lenhve = "muithuyeu" And Not Lenhve = "muithuyeu2" And Not Lenhve = "muiTCngan" And Not Lenhve = "muiTCngan2" And Not Lenhve = "muiChuyeu" And Not Lenhve = "muiChuyeu2" Then
                mau = mau
            Else
                mau = MauMT
            End If
            Dim polys As List(Of ITerrainPolygon71) = RegionMT(PllPts, mGroupBac2, mau, mau2)
            If cPlg1 Is Nothing Then
                cPlg1 = polys(0)
            Else
                sgworldMain.Creator.DeleteObject(cPlg1.ID)
                cPlg1 = polys(0)
            End If

            If cPlg2 Is Nothing Then
                cPlg2 = polys(1)
            Else
                sgworldMain.Creator.DeleteObject(cPlg2.ID)
                cPlg2 = polys(1)
            End If
        Catch
        End Try
    End Sub
    Public Sub CrMT1(ByVal mGroupBac2 As String)
        Try
            If Not Lenhve = "muithuyeu" And Not Lenhve = "muithuyeu2" And Not Lenhve = "muiTCngan" And Not Lenhve = "muiTCngan2" And Not Lenhve = "muiChuyeu" And Not Lenhve = "muiChuyeu2" Then
                mau = mau
            Else
                mau = MauMT
            End If
            Dim polys As List(Of ITerrainPolygon71) = RegionMT1(PllPts, mGroupBac2, mau, mau2)
            If cPlg1 Is Nothing Then
                cPlg1 = polys(0)
            Else
                sgworld3DBd.Creator.DeleteObject(cPlg1.ID)
                cPlg1 = polys(0)
            End If

            If cPlg2 Is Nothing Then
                cPlg2 = polys(1)
            Else
                sgworld3DBd.Creator.DeleteObject(cPlg2.ID)
                cPlg2 = polys(1)
            End If
        Catch
        End Try
    End Sub
    Private Function RegionMT(ByVal PllPts() As Point3D, ByVal mGroupBac2 As String, ByVal mau As IColor71, ByVal mau2 As IColor71) 'As List(Of ITerrainPolygon71)
        Try
            Dim result As New List(Of ITerrainPolygon71) '= New List(Of ITerrainPolygon71)()
            Dim cVerticesArray() As Double = Nothing
            Dim cVerticesArray2() As Double = Nothing
            Dim Plg1() As Point3D '= Nothing
            Dim Plg2() As Point3D '= Nothing
            ReDim Plg1(0 To 0)
            ReDim Plg2(0 To 0)
            If Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                KCDuoiMT = (Tyle * 25.0) / 2400
            End If
            If Lenhve = "muitiencongchuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                NoisuyMTChuyeu(PllPts, Plg1, Plg2)
            ElseIf Lenhve = "muiteincongthuyeu" Or Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Then
                NoisuyMTThuyeu(PllPts, Plg1, Plg2)
            ElseIf Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then  'Lenhve = "GioituyenHrKGCC" 
                NoisuyDuongdon(PllPts, Plg2)
            End If
            If True Then
                ReDim Preserve cVerticesArray(0 To (Plg1.Length - 1) * 3 - 1)
                ReDim Preserve cVerticesArray2(0 To (Plg2.Length - 1) * 3 - 1)

                Dim i1 As Integer
                For i1 = 0 To Plg1.Length - 2
                    cVerticesArray(i1 * 3) = Plg1(i1 + 1).X
                    cVerticesArray(i1 * 3 + 1) = Plg1(i1 + 1).Y
                    cVerticesArray(i1 * 3 + 2) = 0.0
                Next i1
                For i1 = 0 To Plg2.Length - 2
                    cVerticesArray2(i1 * 3) = Plg2(i1 + 1).X
                    cVerticesArray2(i1 * 3 + 1) = Plg2(i1 + 1).Y
                    cVerticesArray2(i1 * 3 + 2) = 0.0
                Next i1
                Try
                    Dim cRing As ILinearRing = Nothing, cRing2 As ILinearRing = Nothing
                    Dim vung1 As ITerrainPolygon71 = Nothing, vung2 As ITerrainPolygon71 = Nothing
                    If Lenhve = "muitiencongchuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                        cRing = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray)
                        cRing2 = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray2)
                    ElseIf Lenhve = "muiteincongthuyeu" Or Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Then
                        cRing = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray2)
                        cRing2 = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray)
                    ElseIf Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then 'Or Lenhve = "GioituyenHrCD" Then 'Or Lenhve = "GioituyenHrKGCC" 
                        cRing2 = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray2)
                    End If
                    If Not Lenhve = "duongdon" And Not Lenhve = "hangraobungnhung" Then 'And Not Lenhve = "GioituyenHrKGCC" And Not 
                        Dim cPolygonGeometry As IGeometry = sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing, Nothing)
                        vung1 = sgworldMain.Creator.CreatePolygon(cPolygonGeometry, mau, mau, 2, mGroupBac2, tenKH & "1")
                        vung1.LineStyle.Width = 0
                        vung1.LineStyle.Color.SetAlpha(0)
                        vung1.Tooltip.Text = mota
                        vung1.Terrain.DrawOrder = 2
                    End If
                    Dim cPolygonGeometry2 As IGeometry = sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing2, Nothing)
                    If Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                        vung2 = sgworldMain.Creator.CreatePolygon(cPolygonGeometry2, mau2, mau2, 2, mGroupBac2, tenKH & "2")
                    Else
                        vung2 = sgworldMain.Creator.CreatePolygon(cPolygonGeometry2, mau2, mau2, 2, mGroupBac2, tenKH & "2")
                    End If
                    vung2.FillStyle.Color.SetAlpha(0.4)
                    vung2.LineStyle.Color.SetAlpha(0.4)
                    vung2.Tooltip.Text = "Mui tien cong"
                    vung2.LineStyle.Width = 0
                    vung2.Terrain.DrawOrder = 1
                    If Lenhve = "muitiencongchuyeu" Then
                        Console.WriteLine("muiChuyeu" & "-" & Tyle.ToString & "-" & TDMuiten.ToString)
                        vung1.Tooltip.Text = Encrypt("muiChuyeu" & "-" & Tyle.ToString & "-" & TDMuiten, PassKey)
                    ElseIf Lenhve = "muiteincongthuyeu" Then
                        vung1.Tooltip.Text = Encrypt("muithuyeu" & "-" & Tyle.ToString & "-" & TDMuiten, PassKey)
                    ElseIf Lenhve = "muitiencongCYngan" Then
                        vung1.Tooltip.Text = Encrypt("muiTCngan" & "-" & Tyle.ToString & "-" & TDMuiten, PassKey)
                    End If
                    result.Add(vung1)
                    result.Add(vung2)
                Catch ex As Exception
                End Try
            End If
            Return result
        Catch
        End Try
    End Function
    Private Function RegionMT1(ByVal PllPts() As Point3D, ByVal mGroupBac2 As String, ByVal mau As IColor71, ByVal mau2 As IColor71) 'As List(Of ITerrainPolygon71)
        Try
            Dim result As New List(Of ITerrainPolygon71) '= New List(Of ITerrainPolygon71)()
            Dim cVerticesArray() As Double = Nothing
            Dim cVerticesArray2() As Double = Nothing
            Dim Plg1() As Point3D '= Nothing
            Dim Plg2() As Point3D '= Nothing
            ReDim Plg1(0 To 0)
            ReDim Plg2(0 To 0)
            If Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                KCDuoiMT = (Tyle * 25.0) / 2400
            End If
            If Lenhve = "muitiencongchuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                NoisuyMTChuyeu(PllPts, Plg1, Plg2)
            ElseIf Lenhve = "muiteincongthuyeu" Or Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Then
                NoisuyMTThuyeu(PllPts, Plg1, Plg2)
            ElseIf Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then  'Lenhve = "GioituyenHrKGCC" 
                NoisuyDuongdon(PllPts, Plg2)
            End If
            If True Then
                ReDim Preserve cVerticesArray(0 To (Plg1.Length - 1) * 3 - 1)
                ReDim Preserve cVerticesArray2(0 To (Plg2.Length - 1) * 3 - 1)
                Dim i1 As Integer
                For i1 = 0 To Plg1.Length - 2
                    cVerticesArray(i1 * 3) = Plg1(i1 + 1).X
                    cVerticesArray(i1 * 3 + 1) = Plg1(i1 + 1).Y
                    cVerticesArray(i1 * 3 + 2) = 0.0
                Next i1
                For i1 = 0 To Plg2.Length - 2
                    cVerticesArray2(i1 * 3) = Plg2(i1 + 1).X
                    cVerticesArray2(i1 * 3 + 1) = Plg2(i1 + 1).Y
                    cVerticesArray2(i1 * 3 + 2) = 0.0
                Next i1
                Try
                    Dim cRing As ILinearRing = Nothing, cRing2 As ILinearRing = Nothing
                    Dim vung1 As ITerrainPolygon71 = Nothing, vung2 As ITerrainPolygon71 = Nothing
                    If Lenhve = "muitiencongchuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                        cRing = sgworld3DBd.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray)
                        cRing2 = sgworld3DBd.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray2)
                    ElseIf Lenhve = "muiteincongthuyeu" Or Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Then
                        cRing = sgworld3DBd.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray2)
                        cRing2 = sgworld3DBd.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray)
                    ElseIf Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then 'Or Lenhve = "GioituyenHrCD" Then 'Or Lenhve = "GioituyenHrKGCC" 
                        cRing2 = sgworld3DBd.Creator.GeometryCreator.CreateLinearRingGeometry(cVerticesArray2)
                    End If
                    If Not Lenhve = "duongdon" And Not Lenhve = "hangraobungnhung" Then 'And Not Lenhve = "GioituyenHrKGCC" And Not 
                        Dim cPolygonGeometry As IGeometry = sgworld3DBd.Creator.GeometryCreator.CreatePolygonGeometry(cRing, Nothing)
                        vung1 = sgworld3DBd.Creator.CreatePolygon(cPolygonGeometry, mau, mau, 2, mGroupBac2, tenKH & "1")
                        vung1.LineStyle.Width = 0
                        vung1.LineStyle.Color.SetAlpha(0)
                        vung1.Tooltip.Text = mota
                        vung1.Terrain.DrawOrder = 2
                    End If
                    Dim cPolygonGeometry2 As IGeometry = sgworld3DBd.Creator.GeometryCreator.CreatePolygonGeometry(cRing2, Nothing)
                    If Lenhve = "muithuyeu" Or Lenhve = "muithuyeu2" Or Lenhve = "muiChuyeu" Or Lenhve = "muiChuyeu2" Or Lenhve = "muiTCngan" Or Lenhve = "muiTCngan2" Then
                        vung2 = sgworld3DBd.Creator.CreatePolygon(cPolygonGeometry2, mau2, mau2, 2, mGroupBac2, tenKH & "2")
                    Else
                        vung2 = sgworld3DBd.Creator.CreatePolygon(cPolygonGeometry2, mau2, mau2, 2, mGroupBac2, tenKH & "2")
                    End If
                    vung2.FillStyle.Color.SetAlpha(0.4)
                    vung2.LineStyle.Color.SetAlpha(0.4)
                    vung2.Tooltip.Text = "Mui tien cong"
                    vung2.LineStyle.Width = 0
                    vung2.Terrain.DrawOrder = 1
                    If Lenhve = "muitiencongchuyeu" Then
                        vung1.Tooltip.Text = Encrypt("muiChuyeu" & "-" & Tyle.ToString & "-" & TDMuiten, PassKey)
                    ElseIf Lenhve = "muiteincongthuyeu" Then
                        vung1.Tooltip.Text = Encrypt("muithuyeu" & "-" & Tyle.ToString & "-" & TDMuiten, PassKey)
                    ElseIf Lenhve = "muitiencongCYngan" Then
                        vung1.Tooltip.Text = Encrypt("muiTCngan" & "-" & Tyle.ToString & "-" & TDMuiten, PassKey)
                    End If
                    result.Add(vung1)
                    result.Add(vung2)
                Catch ex As Exception
                End Try
            End If
            Return result
        Catch
        End Try
    End Function
    Public Sub DuoiMT()
        Try
            If PllVtNum = 2 Then
                KCDuoiMT = Math.Sqrt((PllPts(1).X - PllPts(2).X) ^ 2 + (PllPts(1).Y - PllPts(2).Y) ^ 2)
                Dim P As New Point3D()
                P.X = (PllPts(1).X + PllPts(2).X) / 2.0
                P.Y = (PllPts(1).Y + PllPts(2).Y) / 2.0
                P.Z = 0.0
                ReDim PllPts(0 To 1)
                PllPts(1) = P
            End If
            PllVtNum = 1

        Catch
        End Try
    End Sub

#End Region

#End Region

    Private Sub ToolQBTS_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolQBTS.ItemClicked
        Try
            If e.ClickedItem.Name = "tl250013" Or e.ClickedItem.Name = "tl25b0013" Or e.ClickedItem.Name = "tl250014" Or e.ClickedItem.Name = "tl25b0014" Or e.ClickedItem.Name = "tl250015" Or e.ClickedItem.Name = "tl280000" Or
           e.ClickedItem.Name = "tl250017" Or e.ClickedItem.Name = "tl250018" Or e.ClickedItem.Name = "tlKVTrinhsatSCN" Or e.ClickedItem.Name = "tlKVTrinhsatSN" Or e.ClickedItem.Name = "tlChieusauTS" Or e.ClickedItem.Name = "tl250024" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlChieusauTS" Then
                If TxtGhichuKH.Text = "" Then
                    TxtGhichuKH.Text = "2000"
                End If
            End If

            If e.ClickedItem.Name = "tlMBchupanhTS" Then
                cbLoaiMB.SelectedIndex = 8
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolQBTS, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolDC_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolDC.ItemClicked
        Try
            mauKT = False
            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolDC, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolTTG_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolTTG.ItemClicked
        Try
            mauKT = False

            If e.ClickedItem.Name = "tlXTchuyenPngu" Or e.ClickedItem.Name = "tlXTPngutrongTD" Then
                cbLoaiKHQS_HDTC.SelectedIndex = 7
            End If

            If e.ClickedItem.Name = "tlTuyenbanXT" Or e.ClickedItem.Name = "tlXTTiencong" Then
                cbKieuTrKTiencong.SelectedIndex = 1
                cbLoaiKHQS_HDTC.SelectedIndex = 5
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolTTG, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#Region "....Pháo binh"

    Private Sub CbLoaiTrandia_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbLoaiTrandia.SelectedIndex > 0 Then
            cbLoaiTrandiaPK.SelectedIndex = 0
        End If
    End Sub

    Private Sub CbLoaiTrandiaPK_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cbLoaiTrandiaPK.SelectedIndex > 0 Then
            cbLoaiTrandia.SelectedIndex = 0
        End If
    End Sub

    Private Sub CreateModelPBMoi()
        Try
            Dim Goc2 As Double
            Dim P01 As IPosition71 = Nothing, P2 As IPosition71 = Nothing
            If loaiKH = "241BB5" Or loaiKH = "241BB4" Or loaiKH = "241TH0" Or loaiKH = "241TH8" Or loaiKH = "241TH4" Then
                cbLoaiTrandia.SelectedIndex = 0
                P01 = sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
                P2 = sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.Crea
                Goc2 = FGoc(P01, P2)
            Else
                Goc2 = Phuongvi * 180.0 / Math.PI
            End If

            fileModel = PathData & "\XPL\" & loaiKH & Ta_Doiphuong & ".xpl2"
            Dim mLine1 As ITerrainPolyline71 '= Nothing
            Dim mILineString As ILineString = sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(PllVts)
            Dim cPolygonGeometry As IGeometry = sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(mILineString)
            mLine1 = sgworldMain.Creator.CreatePolyline(cPolygonGeometry, Nothing, 2, tempGroup, "Temp1")
            mLine1.LineStyle.Width = 3
            Dim P(10) As IPosition71
            Dim P1 As IPosition71 = Nothing
            Dim lists1 As New List(Of IPosition71)
            Dim KC As Double = 0, KC2 As Double = 0
            Dim k1 As ITerrainPolyline71 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem("Temp\Temp1"))
            Dim ST1() As String = k1.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")

            For j As Integer = 1 To ST1.Count - 2
                P(j) = sgworldMain.Creator.CreatePosition(Val(ST1(j).Split(" ")(1)), Val(ST1(j).Split(" ")(2)), 0, 2, 0, 0, 0, 0)
                P1 = sgworldMain.Creator.CreatePosition(Val(ST1(1).Split(" ")(1)), Val(ST1(1).Split(" ")(2)), 0, 2, 0, 0, 0, 0)
                lists1.Add(P(j))
                lists1.Add(P(j))
                If Lenhve = "Coi160" Or Lenhve = "Coi82" Or Lenhve = "Coi120" Then
                    If cbLoaiTrandia.SelectedIndex = 5 Or cbLoaiTrandia.SelectedIndex = 6 Or cbLoaiTrandia.SelectedIndex = 7 Or cbLoaiTrandia.SelectedIndex = 8 Then
                        SCoi(P(j), Goc2 + 180 + 15)
                    Else
                        SCoi(P(j), Goc2 + 180)
                    End If
                ElseIf Lenhve = "Phaophanluccotrung" Or Lenhve = "PhaophanlucKyhieuchung" Or Lenhve = "Phaophanluccolon" Then
                    Phanluc(P(j), Goc2 + 180)
                ElseIf Lenhve = "mohinhPB" Then
                    If loaiKH = "241TH0" Or loaiKH = "241TH8" Or loaiKH = "241TH4" Then 'Or loaiKH = "241005" Or loaiKH = "241004" Or loaiKH = "2410a8" Then
                        CrModel(P(j), fileModel, Tyle * 0.22, tenKH)
                        Dim TQ As New List(Of Double)({150.0, 180, 85.0, 90, 150.0, 0, 85.0, 270, 150.0, 180, 155.24, 165.07, 155.24, 194.93})
                        Dim LiC As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, P(j), 3.0, 270 + MkGoc(P01, P2) * 180 / Math.PI)
                        FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
                        LiC.RemoveRange(4, 3)
                        Dim Geo As IGeometry = ListtoGeo(LiC).SpatialOperator.buffer(-Dorongduong)
                        FDuongList(GeoToList(Geo), 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
                    Else
                        CrModel(P(j), fileModel, Tyle * 0.25, tenKH)
                        If loaiKH = "241BB5" Or loaiKH = "241BB4" Then
                            Dim Pk As IPosition71 = P(j).Move(Dorongduong * 6.2, Goc2, 0)
                            TDTenluaCC(Pk, Goc2, Dorongduong * 2.5, Dorongduong * 0.96, mau, mau2)
                        ElseIf loaiKH = "2410059" Then
                            cbLoaiTrandia.SelectedIndex = 0
                            Dim Pm As IPosition71 = P(j).Move(15 * Tyle, 90 - Goc2, 0)
                            If ST1.Count > 3 Then
                                MCircleTQ(Pm, 140, 4294967295, Dorongduong * 0.9, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
                            Else
                                MCircleTQ(Pm, 180 - Dorongduong / Tyle, 4294967295, Dorongduong * 0.9, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
                                MCircleTQ(Pm, 180, 4294967295, Dorongduong * 0.9, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
                            End If
                        End If

                    End If
                ElseIf Lenhve = "TaungamPB" Then
                    If loaiKH = "280114" Then
                        fLabelStyleMain.Scale = Tyle * 4.0
                    Else
                        fLabelStyleMain.Scale = Tyle * 6.0
                    End If
                    fLabelStyleMain.PivotAlignment = "Bottom, Center"
                    fileImage = PathLabel("\2X\", loaiKH, ChieuKH, mP, "", Ta_Doiphuong, tenGiaidoan)
                    Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(P(j), "", fileImage, fLabelStyleMain, GroupBac2Main, tenKH)
                    mLabelArray.Add(mText)
                    SendLabel(mText)
                ElseIf Lenhve = "tenluaB72" Or Lenhve = "tenluaPhagot" Then
                    Dim P3 As IPosition71 = P(j).Move(-180 * Tyle, 90 - Goc2, 0)
                    Phagot(P3, Goc2)
                    GoTo KT
                End If

                If cbLoaiTrandia.SelectedIndex > 0 Or cbLoaiTrandiaPK.SelectedIndex > 0 Then
                    Dim hesoTyle As Double = Tyle * 8.0
                    Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI - 3.5
                    Dim pChu As IPosition71 = P(j).Move(70 * hesoTyle, 0 - Goc1, 0)
                    If cbLoaiTrandia.SelectedIndex = 1 Or cbLoaiTrandia.SelectedIndex = 2 Or cbLoaiTrandiaPK.SelectedIndex = 1 Or cbLoaiTrandiaPK.SelectedIndex = 2 Then
                        TrandiaDaidoi(P(j), pChu, Goc1)
                        KC = Dorongduong * 6
                        KC2 = Dorongduong * 5
                    ElseIf cbLoaiTrandia.SelectedIndex = 3 Or cbLoaiTrandia.SelectedIndex = 4 Or cbLoaiTrandiaPK.SelectedIndex = 3 Or cbLoaiTrandiaPK.SelectedIndex = 4 Then
                        TrandiaDaidoi(P(j), pChu, Goc1)
                        KC = Dorongduong * 7
                        KC2 = Dorongduong * 6
                    ElseIf cbLoaiTrandia.SelectedIndex = 5 Or cbLoaiTrandia.SelectedIndex = 6 Or cbLoaiTrandia.SelectedIndex = 7 Or cbLoaiTrandia.SelectedIndex = 8 Or
                   cbLoaiTrandiaPK.SelectedIndex = 5 Or cbLoaiTrandiaPK.SelectedIndex = 6 Or cbLoaiTrandiaPK.SelectedIndex = 7 Or cbLoaiTrandiaPK.SelectedIndex = 8 Then
                        TrandiaTrungdoi(P(j), pChu, Goc1)
                        KC = Dorongduong * 7
                        KC2 = Dorongduong * 6
                    End If
                End If
            Next

            lists1.Add(P1)
            If cbLoaiTrandia.SelectedIndex > 0 Or cbLoaiTrandiaPK.SelectedIndex > 0 Then
                SDuongNoi(lists1, KC, KC2)
            End If
KT:
            SLenhve3DMs()
        Catch
        End Try
    End Sub

    Private Sub SDuongNoi(lists1 As List(Of IPosition71), kc As Double, kc2 As Double) 'kO SUA
        Try
            Dim sLan As Integer
            If lists1.Count = 3 Then
                sLan = 3
            Else
                sLan = 2
            End If
            Dim goc As Double
            If lists1.Count < 2 Then
                Exit Sub
            Else
                For i As Integer = 0 To lists1.Count - sLan
                    Dim P1 As IPosition71, P2 As IPosition71
                    Dim mP(8) As IPosition71
                    P1 = sgworldMain.Creator.CreatePosition(lists1(i).X, lists1(i).Y, 0, 2, 0, 0, 0, 0)
                    P2 = sgworldMain.Creator.CreatePosition(lists1(i + 1).X, lists1(i + 1).Y, 0, 2, 0, 0, 0, 0)
                    goc = FGoc(P2, P1)
                    mP(1) = P1.Move(kc, goc - 90, 0)
                    mP(2) = P2.Move(kc, goc - 90, 0)
                    mP(5) = P1.Move(kc2, goc - 90, 0)
                    mP(6) = P2.Move(kc2, goc - 90, 0)
                    If sLan >= 3 Then
                        mP(3) = P1.Move(kc, goc - 270, 0)
                        mP(4) = P2.Move(kc, goc - 270, 0)
                        mP(7) = P1.Move(kc2, goc - 270, 0)
                        mP(8) = P2.Move(kc2, goc - 270, 0)
                    ElseIf sLan = 2 Then
                        mP(3) = P1.Move(kc, goc - 90, 0)
                        mP(4) = P2.Move(kc, goc - 90, 0)
                        mP(7) = P1.Move(kc2, goc - 90, 0)
                        mP(8) = P2.Move(kc2, goc - 90, 0)
                    End If
                    Dim lists2 As New List(Of IPosition71) From {mP(1), mP(2)}
                    Dim lists3 As New List(Of IPosition71) From {mP(3), mP(4)}
                    Dim lists4 As New List(Of IPosition71) From {mP(5), mP(6)}
                    Dim lists5 As New List(Of IPosition71) From {mP(7), mP(8)}
                    'lists2.Add(mP(1))
                    'lists2.Add(mP(2))
                    'lists3.Add(mP(3))
                    'lists3.Add(mP(4))
                    'lists4.Add(mP(5))
                    'lists4.Add(mP(6))
                    'lists5.Add(mP(7))
                    'lists5.Add(mP(8))
                    FDuongList(lists2, 4294967295, "", 0, 0, mau, Dorongduong * 0.75, False, 2, 0, -3) ' 2, False, 2)
                    FDuongList(lists3, 4294967295, "", 0, 0, mau, Dorongduong * 0.75, False, 2, 0, -3) ' 2, False, 2)
                    FDuongList(lists4, 4294967295, "", 0, 0, mau2, Dorongduong * 0.75, False, 2, 0, -3) ' 2, False, 2)
                    FDuongList(lists5, 4294967295, "", 0, 0, mau2, Dorongduong * 0.75, False, 2, 0, -3) ' 2, False, 2)
                    'lists2.Clear()
                    'lists3.Clear()
                    'lists4.Clear()
                    'lists5.Clear()
                Next
                '  goc = 0
            End If
        Catch
        End Try
    End Sub

    Private Sub ToolPB_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolPB.ItemClicked
        Try
            If e.ClickedItem.Name = "tltenluacocanhtamgan" Or e.ClickedItem.Name = "tltenluacocanhtamtrung" Or e.ClickedItem.Name = "tltenluacocanhtamxa" Or e.ClickedItem.Name = "tltenluacocanhtamgan2Ranh" Or e.ClickedItem.Name = "tltenluacocanhtamtrung2Ranh" Or
         e.ClickedItem.Name = "tltenluacocanhtamxa2Ranh" Or e.ClickedItem.Name = "tltenluacocanhhatnhan" Or e.ClickedItem.Name = "tlTLChongngamNBC" Then
                mauKT = False
            Else
                mauKT = True
            End If

            If e.ClickedItem.Name = "tl240001" Or e.ClickedItem.Name = "tl240002" Or e.ClickedItem.Name = "tl240003" Or e.ClickedItem.Name = "tl241031" Or e.ClickedItem.Name = "tl241032" Or e.ClickedItem.Name = "tl241033" Then
                If cbLoaiTrandia.SelectedIndex = 0 Then
                    NewTool("Taungam", e.ClickedItem.Name, e)
                Else
                    NewTool("TaungamPB", e.ClickedItem.Name, e)
                End If

            ElseIf e.ClickedItem.Name = "tl250001" Or e.ClickedItem.Name = "tl240011" Or e.ClickedItem.Name = "tl241034" Or e.ClickedItem.Name = "tl241035" Or e.ClickedItem.Name = "tl241036" Or e.ClickedItem.Name = "tl241037" Or e.ClickedItem.Name = "tl240013" Or e.ClickedItem.Name = "tl240012" Then
                NewTool("Taungam", e.ClickedItem.Name, e)
            Else
                NewTool("mohinhPB", e.ClickedItem.Name, e)
            End If

            'If e.ClickedItem.Name = "tlBanCSphanchiaGioituyen" Then
            '    If TxtGhichuKH.Text = "" Then
            '        TxtGhichuKH.Text = "p"
            '    End If
            'End If
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolPB, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#End Region

    Private Sub ToolCB_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolCB.ItemClicked
        Try
            If e.ClickedItem.Name = "tlDDgnguytrangLuoi" Or e.ClickedItem.Name = "tlDDgdichphahoai" Or e.ClickedItem.Name = "tlDDgdichphahoaiMB" Or e.ClickedItem.Name = "tlDDGngapnuoc" Or
            e.ClickedItem.Name = "tlDDgVongtranh" Or e.ClickedItem.Name = "tlDDgCoDichmatdat" Or e.ClickedItem.Name = "tlPhacau" Or e.ClickedItem.Name = "tlPhaduong" Or e.ClickedItem.Name = "tlcuamoBB" Then
                mauKT = False
            Else
                mauKT = True
            End If

            If e.ClickedItem.Name.Contains("tlGit") Then
                DorongVung = 645
                TyleX = 345
                TyleY = 200
            End If

            If e.ClickedItem.Name = "tlGit2140049" Then
                DorongVung = 645
                TyleX = 90
                TyleY = 200
            End If

            If e.ClickedItem.Name = "tlKvVatcan" Then
                cbLoaiTrandia.SelectedIndex = 1
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolCB, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolTTLL_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolTTLL.ItemClicked
        Try
            If e.ClickedItem.Name = "tlGit21400" Or e.ClickedItem.Name = "tl270278" Or e.ClickedItem.Name = "tl270282" Or e.ClickedItem.Name = "tl270283" Or e.ClickedItem.Name = "tl270284" Or e.ClickedItem.Name = "tl270285" Or e.ClickedItem.Name = "tl270286" Or
           e.ClickedItem.Name = "tlcapnguondien" Or e.ClickedItem.Name = "tl270287" Or e.ClickedItem.Name = "tl270288" Or e.ClickedItem.Name = "tl270289" Or e.ClickedItem.Name = "tl270290" Or e.ClickedItem.Name = "tl270291" Or e.ClickedItem.Name = "tl270292" Or e.ClickedItem.Name = "tl270293" Then
                mauKT = False
            Else
                mauKT = True
            End If

            If e.ClickedItem.Name.Contains("tlGit") Then
                DorongVung = 645
                TyleX = 345
                TyleY = 200
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolTTLL, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolHH_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolHH.ItemClicked
        Try
            If e.ClickedItem.Name = "tlKvTrSHHBangMB" Or e.ClickedItem.Name = "tlkvtstrenkhong" Or e.ClickedItem.Name = "tl610027" Or e.ClickedItem.Name = "tl610028" Or
           e.ClickedItem.Name = "tl610029" Or e.ClickedItem.Name = "tlKvVKHatnhanno" Or e.ClickedItem.Name = "tlkvvkhatnhanno" Or e.ClickedItem.Name = "tl610024" Or
           e.ClickedItem.Name = "tlDgVongtranh" Or e.ClickedItem.Name = "tlDgTieudoc" Or e.ClickedItem.Name = "tlAntoanHatnhan" Or e.ClickedItem.Name = "tl610030" Then
                mauKT = False
            Else
                mauKT = True
            End If


            If e.ClickedItem.Name = "tlKvTrSHHBangMB" Or e.ClickedItem.Name = "" Or e.ClickedItem.Name = "tlTrTbiHH" Or e.ClickedItem.Name = "tlkvtsmatdat" Or e.ClickedItem.Name = "tlkvtstrenkhong" Or e.ClickedItem.Name = "tlmucbucxa" Then
                If TxtGhichuKH.Text = "" Then
                    If e.ClickedItem.Name = "tlKvTrSHHBangMB" Then
                        TxtGhichuKH.Text = "3000"
                    ElseIf e.ClickedItem.Name = "tlTrTbiHH" Then
                        TxtGhichuKH.Text = "50"
                    ElseIf e.ClickedItem.Name = "tlkvtsmatdat" Then
                        TxtGhichuKH.Text = "bTs/dHH5/8.00~10.00-05.11"
                    ElseIf e.ClickedItem.Name = "tlkvtstrenkhong" Then
                        TxtGhichuKH.Text = "2Mi28/8.00~10.00-05.11"
                    ElseIf e.ClickedItem.Name = "tlmucbucxa" Then
                        TxtGhichuKH.Text = "50/8.00~10.00"
                    End If
                End If
            End If

            If e.ClickedItem.Name = "tl610025" Or e.ClickedItem.Name = "tl610026" Then
                NewTool("mohinhPB", e.ClickedItem.Name, e)
            Else
                NewTool("Taungam", e.ClickedItem.Name, e)
            End If

            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolHH, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolTCDT_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolTCDT.ItemClicked
        Try
            If e.ClickedItem.Name = "tlGioihanvungTrSDientuSN" Or e.ClickedItem.Name = "tlGioihanvungTrSdienttuSCNVHF" Or e.ClickedItem.Name = "tlGioihanvungTrSdientuSCNUHF" Or e.ClickedItem.Name = "tlGioihanvungTrSDTsieucaotan" Or e.ClickedItem.Name = "tl280038" Or e.ClickedItem.Name = "tl280040" Or e.ClickedItem.Name = "tl280044" Or
            e.ClickedItem.Name = "tlKvhoatdongMBTcdt" Or e.ClickedItem.Name = "tl280032" Or e.ClickedItem.Name = "tl280034" Or e.ClickedItem.Name = "tl280041" Or e.ClickedItem.Name = "tl280036" Or e.ClickedItem.Name = "tl280037" Or e.ClickedItem.Name = "tlGihanVungcheap" Or e.ClickedItem.Name = "tlCheapDTvaoMtieu" Or e.ClickedItem.Name = "tl280039" Then
                mauKT = False
            Else
                mauKT = True
            End If

            If e.ClickedItem.Name = "tlGihanVungcheap" Or e.ClickedItem.Name = "tlKvNhieutieucuc" Or e.ClickedItem.Name = "tlKvhoatdongMBTcdt" Then
                If TxtGhichuKH.Text = "" Then
                    If e.ClickedItem.Name = "tlGihanVungcheap" Then
                        TxtGhichuKH.Text = "SN,30"
                    ElseIf e.ClickedItem.Name = "tlKvNhieutieucuc" Then
                        TxtGhichuKH.Text = "1000"
                    ElseIf e.ClickedItem.Name = "tlKvhoatdongMBTcdt" Then
                        cbLoaiMB.SelectedIndex = 11
                        TxtGhichuKH.Text = "2000"
                    End If

                End If
            End If

            If e.ClickedItem.Name = "tl280114cu" Then
                NewTool("TaungamPB", e.ClickedItem.Name, e)
                cbLoaiTrandia.SelectedIndex = 1
            Else
                NewTool("Taungam", e.ClickedItem.Name, e)
            End If

            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolTCDT, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolKGM_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolKGM.ItemClicked
        Try
            mauKT = False
            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolKGM, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolCY_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolCY.ItemClicked
        Try
            mauKT = False

            If e.ClickedItem.Name = "tl70001" Or e.ClickedItem.Name = "tl70002" Or e.ClickedItem.Name = "tl70003" Or e.ClickedItem.Name = "tl70004" Or e.ClickedItem.Name = "tlLLVuotcap" Then
                mauKT = True
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolCY, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#Region "...Không quân"
    Private Sub ToolPK_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles toolPK.ItemClicked
        Try
            If e.ClickedItem.Name = "tl2110000" Or e.ClickedItem.Name = "tl2110001" Or e.ClickedItem.Name = "tl2110002" Or e.ClickedItem.Name = "tl2110003" Or e.ClickedItem.Name = "tl2110023" Or e.ClickedItem.Name = "tl2110012" Or e.ClickedItem.Name = "tl2110004" Or e.ClickedItem.Name = "tlKvBaoveMtieu" Or e.ClickedItem.Name = "tl2120035" Or
           e.ClickedItem.Name = "tl2110024" Or e.ClickedItem.Name = "tl2110005" Or e.ClickedItem.Name = "tl2110006" Or e.ClickedItem.Name = "tl2110007" Or e.ClickedItem.Name = "tl211b0005" Or e.ClickedItem.Name = "tl2110009" Or e.ClickedItem.Name = "tl2110017" Or e.ClickedItem.Name = "tl2110011" Or e.ClickedItem.Name = "tl2110008" Or
           e.ClickedItem.Name = "tl2110019" Or e.ClickedItem.Name = "tl2110013" Or e.ClickedItem.Name = "tl2110020" Or e.ClickedItem.Name = "tlKvCamban" Or e.ClickedItem.Name = "tl2110035" Or e.ClickedItem.Name = "tl2110014" Or e.ClickedItem.Name = "tl2110015" Or e.ClickedItem.Name = "tl2110028" Or e.ClickedItem.Name = "tl2120037" Or
           e.ClickedItem.Name = "tl2110021" Or e.ClickedItem.Name = "tl2110016" Or e.ClickedItem.Name = "tl2110016a" Or e.ClickedItem.Name = "tl2110022" Or e.ClickedItem.Name = "tl2110022a" Or e.ClickedItem.Name = "tl2110025" Or e.ClickedItem.Name = "tl2110026" Or e.ClickedItem.Name = "tlCulyhoatdongDaidanduonggan" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlGit2140015" Then
                DorongVung = 1000
                TyleX = 1200
                TyleY = 300
            End If


            If e.ClickedItem.Name = "tlkhongquandanhbien" Or e.ClickedItem.Name = "tlBkinhMB" Or e.ClickedItem.Name = "tlDaihiepdong" Or e.ClickedItem.Name = "tlhanhlangbay" Or e.ClickedItem.Name = "tlmaybaychivien" Or e.ClickedItem.Name = "tlDiemchuanBancanPK" Or e.ClickedItem.Name = "tlHuongTcKQ" Or e.ClickedItem.Name = "tlTuyengiaoNvu" Or e.ClickedItem.Name = "tlKvBandoclaptieudoan" Or e.ClickedItem.Name = "tlKvBanDoclapDaidoi" Or e.ClickedItem.Name = "tlKvBanTTrTieudoan" Or e.ClickedItem.Name = "tlKvBanTTrDaidoi" Or e.ClickedItem.Name = "tlHuongTCThuyeuKQchendich" Or e.ClickedItem.Name = "tlHuongTCChuyeuKQchendich" Then
                If TxtGhichuKH.Text = "" Then
                    If e.ClickedItem.Name = "tlDaihiepdong" Or e.ClickedItem.Name = "tlhanhlangbay" Or e.ClickedItem.Name = "tlmaybaychivien" Then
                        TxtGhichuKH.Text = "2000"
                    ElseIf e.ClickedItem.Name = "tlkhongquandanhbien" Then
                        TxtGhichuKH.Text = "ĐĐB"
                    ElseIf e.ClickedItem.Name = "tlHuongTCThuyeuKQchendich" Or e.ClickedItem.Name = "tlHuongTCChuyeuKQchendich" Then
                        TxtGhichuKH.Text = "12MB"
                    ElseIf e.ClickedItem.Name = "tlDiemchuanBancanPK" Then
                        TxtGhichuKH.Text = "4"
                    ElseIf e.ClickedItem.Name = "tlHuongTcKQ" Then
                        TxtGhichuKH.Text = "500"
                    ElseIf e.ClickedItem.Name = "tlTuyengiaoNvu" Then
                        TxtGhichuKH.Text = "H = 3000 m"
                    ElseIf e.ClickedItem.Name = "tlKvBandoclaptieudoan" Or e.ClickedItem.Name = "tlKvBanDoclapDaidoi" Then
                        TxtGhichuKH.Text = "1,0,0"
                    ElseIf e.ClickedItem.Name = "tlKvBanTTrTieudoan" Or e.ClickedItem.Name = "tlKvBanTTrDaidoi" Then
                        TxtGhichuKH.Text = "1,2,3"
                    ElseIf e.ClickedItem.Name = "tlBkinhMB" Then
                        TxtGhichuKH.Text = "10000"
                    End If
                End If
            End If

            If e.ClickedItem.Name = "tlVungHoaluc" Or e.ClickedItem.Name = "tlCulyhoatdongDaidanduonggan" Or e.ClickedItem.Name = "tlNoiVunhHL" Then
                mota = e.ClickedItem.ToolTipText.Split(".")(0)
                If Dkien = True Then
                    SPanel(panelVungHL)
                End If

            End If

            If e.ClickedItem.Name = "tl2110000" Or e.ClickedItem.Name = "tl2110001" Or e.ClickedItem.Name = "tl2110002" Or e.ClickedItem.Name = "tl2110003" Or e.ClickedItem.Name = "tl2110005" Or e.ClickedItem.Name = "tl2110006" Or e.ClickedItem.Name = "tl2110007" Or e.ClickedItem.Name = "tl211b0005" Or e.ClickedItem.Name = "tl2110004" Or e.ClickedItem.Name = "tl2110023" Or e.ClickedItem.Name = "tl2110012" Or e.ClickedItem.Name = "tl2110024" Then
                If cbLoaiTrandiaPK.SelectedIndex = 0 Then
                    NewTool("Taungam", e.ClickedItem.Name, e)
                Else
                    NewTool("TaungamPB", e.ClickedItem.Name, e)
                End If
            Else
                If Not e.ClickedItem.Name = "tlVungHoaluc" And Not e.ClickedItem.Name = "tlCulyhoatdongDaidanduonggan" And Not e.ClickedItem.Name = "tlNoiVunhHL" Then
                    NewTool("Taungam", e.ClickedItem.Name, e)
                End If
            End If

            If e.ClickedItem.Name = "tlBkinhMB" Or e.ClickedItem.Name = "tlkhongquandanhbien" Or e.ClickedItem.Name = "tlDaihiepdong" Or e.ClickedItem.Name = "tlhanhlangbay" Or e.ClickedItem.Name = "tlmaybaychivien" Or e.ClickedItem.Name = "tlmaybayhoatdong" Or e.ClickedItem.Name = "tlkvtrucban" Then
                If cbLoaiMB.SelectedIndex = 0 Then
                    TxtGhichuKH.Text = ""
                    MouseHook1.Dispose()
                    MsgBox("Hãy chọn loại máy bay!....")
                    Exit Sub
                End If
            End If

            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(toolPK, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#Region "   Vung Hoa luc"

    Private Sub TxtGocQuet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGocQuet.KeyPress
        Import_KeyPress(e, Chr(46))
    End Sub

    Private Sub TxtDocaoPK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocaoPK.KeyPress
        Import_KeyPress(e, Chr(46))
    End Sub

    Private Sub TxtTamPK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTamPK.KeyPress
        Import_KeyPress(e, Chr(46))
    End Sub

    Private Sub TxtGoctrenPK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGoctrenPK.KeyPress
        Import_KeyPress(e, Chr(46))
    End Sub

    Private Sub TxtGocduoiPK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGocduoiPK.KeyPress
        Import2_KeyPress(e, Chr(46), Chr(45))
    End Sub

    Private Sub BtnDTHL_Click(sender As Object, e As EventArgs) Handles btnDTHL.Click
        Try
            If txtDocaoPK.Text = "" Or txtTamPK.Text = "" Or txtGoctrenPK.Text = "" Or txtGocduoiPK.Text = "" Or txtGocQuet.Text = "" Then
                MsgBox("Chưa đủ các thông số.")
                Exit Sub
            Else
                STaungam("vunghoaluc", "")
                sgworldMain.Command.Execute(1070, 0)
            End If
        Catch
        End Try
    End Sub

    Private Sub VungHoaluc()
        Try
            If solan = 1 Then
                Exit Sub
            Else
                If txtGroup.Text = "" Then
                    MsgBox("Chưa có đối tượng được chọn")
                    Exit Sub
                Else
                    VongHL()
                End If
                If IsConnected() Then
                    Dim mess As New NetworkMessage With {.Command = "vungHL", .Parameters = New List(Of String) From {System.Environment.MachineName, Bd3D, cbTa_DP.SelectedIndex.ToString, Giaidoan, Lenhve,
                        loaiKH, tenKH, Tyle, txtGroup.Text, txtDocaoPK.Text, txtTamPK.Text, txtGoctrenPK.Text, txtGocduoiPK.Text, txtGocQuet.Text, chebVeHL.Checked.ToString, mota, mau.ToABGRColor, mau2.ToABGRColor}}
                    SendMessage(mess)
                End If
                SLenhve3DMs()
            End If
        Catch
        End Try
    End Sub

    Private Sub VungHoalucNET(mauDuong As IColor71, mauVung As IColor71)
        Try
            If txtGroup.Text = "" Then
                MsgBox("Chưa có đối tượng được chọn")
                Exit Sub
            Else
                VongHL()
            End If
            SLenhve3DMs()
        Catch
        End Try
    End Sub

#End Region

#End Region

#Region "    Hai quan"

    Private Sub ToolHQ_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolHQ.ItemClicked
        Try

            If e.ClickedItem.Name = "tl2130040" Or e.ClickedItem.Name = "tl2130041" Or e.ClickedItem.Name = "" Or e.ClickedItem.Name = "tl2130038" Or e.ClickedItem.Name = "tl2130039" Or e.ClickedItem.Name = "tlGit2140017" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlGit2140018" Or e.ClickedItem.Name = "tlGit2140019" Or e.ClickedItem.Name = "tlGit2140020" Or e.ClickedItem.Name = "tlGit2140021" Or e.ClickedItem.Name = "tlGit2140022" Then
                DorongVung = 1000
                TyleX = 2800
                TyleY = 300
            ElseIf e.ClickedItem.Name = "tlGit2140023" Or e.ClickedItem.Name = "tlGit2140024" Or e.ClickedItem.Name = "tlGit2140025" Then
                DorongVung = 1000
                TyleX = 1000
                TyleY = 300
            ElseIf e.ClickedItem.Name = "tlGit2140016" Or e.ClickedItem.Name = "tlGit2140017" Then
                DorongVung = 1000
                TyleX = 2000
                TyleY = 310
            End If

            If e.ClickedItem.Name = "tlkvXuaduoi" Or e.ClickedItem.Name = "tlkvTochucDoihinh" Or e.ClickedItem.Name = "tlKvTamdung" Or e.ClickedItem.Name = "tlKvTapket" Or e.ClickedItem.Name = "tlKvDoiTu" Or e.ClickedItem.Name = "tlKvCodong" Or e.ClickedItem.Name = "tlkvbaidobo" Or e.ClickedItem.Name = "tltuyenTochucDoihinh" Or e.ClickedItem.Name = "tltuyenTKdobo" Or e.ClickedItem.Name = "tltuyenXPdobo" Or e.ClickedItem.Name = "tltuyenPTdobo" Or
               e.ClickedItem.Name = "tldanhhuongchuyeuHQ" Or e.ClickedItem.Name = "tldanhhuongthuyeuHQ" Or e.ClickedItem.Name = "tlBkinhTu" Or e.ClickedItem.Name = "tlTuyentucanhgioi" Or e.ClickedItem.Name = "tlLuongraquet" Then
                If TxtGhichuKH.Text = "" Then
                    If e.ClickedItem.Name = "tldanhhuongchuyeuHQ" Or e.ClickedItem.Name = "tldanhhuongthuyeuHQ" Then
                        TxtGhichuKH.Text = "3,9"
                    ElseIf e.ClickedItem.Name = "tlLuongraquet" Then
                        TxtGhichuKH.Text = "1000"
                    ElseIf e.ClickedItem.Name = "tlBkinhTu" Or e.ClickedItem.Name = "tlTuyentucanhgioi" Then
                        TxtGhichuKH.Text = "5000"
                    ElseIf e.ClickedItem.Name = "tlkvbaidobo" Or e.ClickedItem.Name = "tltuyenTochucDoihinh" Or e.ClickedItem.Name = "tltuyenTKdobo" Or e.ClickedItem.Name = "tltuyenXPdobo" Or e.ClickedItem.Name = "tltuyenPTdobo" Then
                        TxtGhichuKH.Text = "4"
                    ElseIf e.ClickedItem.Name = "tlkvTochucDoihinh" Or e.ClickedItem.Name = "tlKvTamdung" Or e.ClickedItem.Name = "tlKvTapket" Or e.ClickedItem.Name = "tlKvDoiTu" Or e.ClickedItem.Name = "tlKvCodong" Then
                        TxtGhichuKH.Text = "1,4,5,8"
                        cbTauHQ.SelectedIndex = 1
                    ElseIf e.ClickedItem.Name = "tlkvXuaduoi" Then
                        TxtGhichuKH.Text = "10"
                    End If
                End If

            End If

            If e.ClickedItem.Name = "tlHQhanhquan" Then
                If cbKHbiendoitauhanhquan.SelectedIndex = 0 Then
                    MouseHook1.Dispose()
                    MsgBox("Chọn đơn vị tàu đi biển!")
                    Exit Sub
                End If
            End If

            If e.ClickedItem.Name = "tlkvXuaduoi" Or e.ClickedItem.Name = "tlLuongraquet" Or e.ClickedItem.Name = "tlBkinhTu" Or e.ClickedItem.Name = "tlTuyentucanhgioi" Or e.ClickedItem.Name = "tlHQhanhquan" Then
                If cbTauHQ.SelectedIndex = 0 Then
                    TxtGhichuKH.Text = ""
                    MouseHook1.Dispose()
                    MsgBox("Hãy chọn loại tàu!....")
                    Exit Sub
                End If
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolHQ, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub TxtSodiemtrentuyen_KeyPress(sender As Object, e As KeyPressEventArgs)
        Import_KeyPress(e, Chr(8))
    End Sub

#End Region

    Private Sub ToolBP_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolBP.ItemClicked
        Try
            If e.ClickedItem.Name = "tl1200042" Or e.ClickedItem.Name = "tl1200043" Or 'e.ClickedItem.Name = "tl1200025" Or
            e.ClickedItem.Name = "tl1200035" Or e.ClickedItem.Name = "tl1200036" Or e.ClickedItem.Name = "" Or e.ClickedItem.Name = "tl1200037" Or e.ClickedItem.Name = "tl1200026" Or e.ClickedItem.Name = "tl1200028" Or
            e.ClickedItem.Name = "tl1200038" Or e.ClickedItem.Name = "tl1200039" Or e.ClickedItem.Name = "tl1200041" Or e.ClickedItem.Name = "tl1200040" Then
                cbTa_DP.SelectedIndex = 1
            ElseIf e.ClickedItem.Name = "tl1200125" Or e.ClickedItem.Name = "tl1200225" Or e.ClickedItem.Name = "tl1200325" Or e.ClickedItem.Name = "tl1200425" Or e.ClickedItem.Name = "tl1200525" Or e.ClickedItem.Name = "tl1200030" Or e.ClickedItem.Name = "tl1200031" Or e.ClickedItem.Name = "tl1200032" Then
                cbTa_DP.SelectedIndex = 0
            End If

            If e.ClickedItem.Name = "tlGit2140031" Or e.ClickedItem.Name = "tlGit2140032" Or e.ClickedItem.Name = "tlGit2140033" Or e.ClickedItem.Name = "tl1200044" Or e.ClickedItem.Name = "tl1200046" Or e.ClickedItem.Name = "tl1200125" Or e.ClickedItem.Name = "tl1200225" Or e.ClickedItem.Name = "tl1200325" Or
               e.ClickedItem.Name = "tl1200425" Or e.ClickedItem.Name = "tl1200525" Or e.ClickedItem.Name = "tl2130036" Or e.ClickedItem.Name = "tl1200030" Or e.ClickedItem.Name = "tl1200031" Or e.ClickedItem.Name = "tl1200032" Or e.ClickedItem.Name = "tlDbanMtuy" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlGit2140026" Or e.ClickedItem.Name = "tlGit2140027" Or e.ClickedItem.Name = "tlGit2140028" Or e.ClickedItem.Name = "tlGit2140029" Or e.ClickedItem.Name = "tlGit2140030" Or e.ClickedItem.Name = "tlGit2140031" Or e.ClickedItem.Name = "tlGit2140032" Or e.ClickedItem.Name = "tlGit2140033" Then
                DorongVung = 1000
                If e.ClickedItem.Name = "tlGit2140026" Or e.ClickedItem.Name = "tlGit2140027" Or e.ClickedItem.Name = "tlGit2140028" Or e.ClickedItem.Name = "tlGit2140029" Then
                    TyleY = 320
                Else
                    TyleY = 300
                End If

                If e.ClickedItem.Name = "tlGit2140028" Or e.ClickedItem.Name = "tlGit2140029" Or e.ClickedItem.Name = "tlGit2140030" Or e.ClickedItem.Name = "tlGit2140031" Or e.ClickedItem.Name = "tlGit2140032" Or e.ClickedItem.Name = "tlGit2140033" Then
                    TyleX = 1000
                Else
                    TyleX = 2800
                End If
            End If

            If e.ClickedItem.Name = "tlTauBPkiemtra" Or e.ClickedItem.Name = "tlTauBPbatgiu" Or e.ClickedItem.Name = "tlTauBPapgiai" Or e.ClickedItem.Name = "tltramxulytauNN" Then
                If cbTauKtraBatgiuApgiai.SelectedIndex = 0 Then
                    TxtGhichuKH.Text = ""
                    MouseHook1.Dispose()
                    MsgBox("Hãy chọn loại tàu!....")
                    Exit Sub
                End If
            End If

            If e.ClickedItem.Name = "tlDbanMtuy" Or e.ClickedItem.Name = "tlDiaban" Then
                If TxtGhichuKH.Text = "" Then
                    MouseHook1.Dispose()
                    MsgBox("Hãy chọn loại đối tượng hoặc địa bàn!....")
                    Exit Sub
                End If
            End If


            If e.ClickedItem.Name = "tl1200003" Or e.ClickedItem.Name = "tl1200002" Or e.ClickedItem.Name = "tl1200004" Or e.ClickedItem.Name = "tl1200010" Or e.ClickedItem.Name = "tl1200011" Then
                NewTool("veco", e.ClickedItem.Name, e)
            Else
                NewTool("Taungam", e.ClickedItem.Name, e)
            End If

            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolBP, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolLLVTDP_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolLLVTDP.ItemClicked
        Try
            If e.ClickedItem.Name = "tlCongNongLamtruongCD" Or e.ClickedItem.Name = "tlkhusotannhandan" Or e.ClickedItem.Name = "tlkhusotanCQXN" Or e.ClickedItem.Name = "tlkhudancumoi" Or e.ClickedItem.Name = "tl1300013" Or e.ClickedItem.Name = "tl1300014" Or e.ClickedItem.Name = "tlbanphongno" Or e.ClickedItem.Name = "tlTrDChongmin" Or e.ClickedItem.Name = "tl1300018" Or e.ClickedItem.Name = "tl1300017" Or e.ClickedItem.Name = "tl1300016" Then
                mauKT = True
            Else
                mauKT = False
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolLLVTDP, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolDBDV_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolDBDV.ItemClicked
        Try
            If e.ClickedItem.Name = "tlMayxuc" Or e.ClickedItem.Name = "tlMaykhoanBetong" Or e.ClickedItem.Name = "tlMaycatBT" Or e.ClickedItem.Name = "tlXePhaBT" Or e.ClickedItem.Name = "tlXecancau" Or
           e.ClickedItem.Name = "tlMaytimchatno" Or e.ClickedItem.Name = "tlKVPhanlucham" Or e.ClickedItem.Name = "tlKhusotanNDBaoLut" Or e.ClickedItem.Name = "tlDexungyeu" Or e.ClickedItem.Name = "tlCaubicuontroi" Or
           e.ClickedItem.Name = "tlCaubisap" Or e.ClickedItem.Name = "tlNhabisap" Or e.ClickedItem.Name = "tlGiongLoc" Or e.ClickedItem.Name = "tlBao" Or e.ClickedItem.Name = "tlKVbitran" Or e.ClickedItem.Name = "tlDatsatlo" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlTrTiepnhanQNDB" Or e.ClickedItem.Name = "tlTrtiepnhanPTKT" Or e.ClickedItem.Name = "tlTrNhan_GiaoDB" Then
                If TxtGhichuKH.Text = "" Then
                    TxtGhichuKH.Text = "200"
                End If
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolDBDV, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolBLLD_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolBLLD.ItemClicked
        Try
            If e.ClickedItem.Name = "tlTrTTBLLD" Or e.ClickedItem.Name = "tlKvGiaututhi" Or e.ClickedItem.Name = "tlLLKhacphucHauquaBLLD" Or e.ClickedItem.Name = "tlMuctieuHH" Or e.ClickedItem.Name = "tlVatchuongngai" Or e.ClickedItem.Name = "tlDiemgiauchatno" Or e.ClickedItem.Name = "tlGit2140034" Or e.ClickedItem.Name = "tlTrXulyHH" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlGit2140047" Or e.ClickedItem.Name = "tlGit2140034" Then
                If e.ClickedItem.Name = "tlGit2140047" Then
                    DorongVung = 1000
                    TyleX = 600
                    TyleY = 310
                Else
                    DorongVung = 1300
                    TyleX = 400
                    TyleY = 400
                End If
                TyleY = 310
            End If

            If e.ClickedItem.Name = "tl251001" Or e.ClickedItem.Name = "tl251002" Then
                cbTa_DP.SelectedIndex = 1
                NewTool("veco", e.ClickedItem.Name, e)
            Else
                NewTool("Taungam", e.ClickedItem.Name, e)
            End If

            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolBLLD, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolTTruyen_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolTTruyen.ItemClicked
        Try
            If e.ClickedItem.Name = "tl70017" Or e.ClickedItem.Name = "tl70018" Or e.ClickedItem.Name = "tl70019" Or e.ClickedItem.Name = "tl70020" Then
                mauKT = True
            Else
                mauKT = False
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolTTruyen, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolCH_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolCH.ItemClicked
        Try
            If Not e.ClickedItem.Name = "tlXeCuuhoa" And Not e.ClickedItem.Name = "tlTauchuachay" And Not e.ClickedItem.Name = "tl261001" And Not e.ClickedItem.Name = "tl261003" And Not e.ClickedItem.Name = "tl261004" And Not e.ClickedItem.Name = "tlTauCuunan" And Not e.ClickedItem.Name = "tlTaubinan" And Not e.ClickedItem.Name = "tl261011" And Not e.ClickedItem.Name = "tl261012" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tl261017" Or e.ClickedItem.Name = "tl261018" Or e.ClickedItem.Name = "tl261019" Or e.ClickedItem.Name = "tl261020" Or e.ClickedItem.Name = "tl261021" Then
                cbTa_DP.SelectedIndex = 0
                cbGiaidoan.SelectedIndex = 0
            End If

            If e.ClickedItem.Name = "tlGit2140048" Then
                DorongVung = 1300
                TyleX = 400
                TyleY = 400
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolCH, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolHC_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolHC.ItemClicked
        Try
            If e.ClickedItem.Name = "tl218019" Or e.ClickedItem.Name = "tl218020" Or e.ClickedItem.Name = "tl218021" Or e.ClickedItem.Name = "tl218070" Or e.ClickedItem.Name = "tl218071" Or e.ClickedItem.Name = "tl218072" Or e.ClickedItem.Name = "tl218023" Or e.ClickedItem.Name = "tl218024" Or
           e.ClickedItem.Name = "tl218073" Or e.ClickedItem.Name = "tlGit2140043" Or e.ClickedItem.Name = "tl218074" Or e.ClickedItem.Name = "tlGit2140044" Or e.ClickedItem.Name = "tlGit2140045" Or e.ClickedItem.Name = "tl218080" Then
                mauKT = True
            Else
                mauKT = False
            End If

            If e.ClickedItem.Name = "tlGit2140043" Or e.ClickedItem.Name = "tlGit2140044" Or e.ClickedItem.Name = "tlGit2140045" Then
                DorongVung = 1000
                TyleX = 1600
                TyleY = 320
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolHC, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

    Private Sub ToolKT_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolKT.ItemClicked
        Try
            mauKT = False
            NewTool("Taungam", e.ClickedItem.Name, e)
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            SAddToolStripItem(ToolTTruyen, e.ClickedItem.Name)
        Catch
        End Try
    End Sub

#Region "    Tien ich"

#Region "...Đối tượng khac"

#Region "   Cac kieu duong"

    Public TyleX As Double = 0
    Public TyleY As Double = 0
    Private DorongVung As Double = 0
    Public soDiem As Integer = 0
    Private points As New List(Of Point3D)

    Private Sub CacKieuDuong()
        Try
            If Not Lenhve = "Gioituyen" Then
                DTDuong()
            Else
                DuongdangVung()
                LineDTDuong()
            End If
            SLenhve3DMs()
        Catch
        End Try
    End Sub

    Public Sub DuongdangVung()

        '  If Not loaiKH = "2140009" And Not loaiKH = "2140010" And Not loaiKH = "2140011" And Not loaiKH = "2140012" And Not loaiKH = "2140013" And Not loaiKH = "2140014" And Not loaiKH = "2140046" Then
        Try
            Dim line As New LineBusiness(points(0).X, points(0).Y, points(1).X, points(1).Y)
            Dim polygones As List(Of Point3D) = line.CreateParalellPolyline(points, Tyle * DorongVung)
            Dim mPolygon As ITerrainPolygon71 = Nothing
            For i As Integer = 0 To points.Count - 2 Step 1
                Dim tempPolypone As New List(Of Point3D) From {points(i), points(i + 1), polygones(i + 1), polygones(i)}
                Dim cArray1(tempPolypone.Count * 3 - 1) As Double
                For j As Integer = 0 To tempPolypone.Count - 1
                    cArray1(j * 3) = tempPolypone(j).X / 360000
                    cArray1(j * 3 + 1) = tempPolypone(j).Y / 360000
                    cArray1(j * 3 + 2) = 0
                Next
                mPolygon = RegionTextures(PathData & "\Textures\" & loaiKH & Ta_Doiphuong & ".gif", cArray1, Tyle * TyleX, Tyle * TyleY, GroupBac2Main, tenKH)
            Next
            If IsConnected() Then
                Dim mess As New NetworkMessage With {.Command = "Gioituyen", .Parameters = New List(Of String) From {System.Environment.MachineName, Bd3D, Giaidoan, Lenhve,
                    loaiKH, tenKH, Tyle, DorongVung, ListPoints(points), mPolygon.FillStyle.Texture.FileName, mPolygon.FillStyle.Texture.ScaleX, mPolygon.FillStyle.Texture.ScaleY,
                    mPolygon.Tooltip.Text, mauKT.ToString, cbTa_DP.SelectedIndex.ToString, cbChieuKH.SelectedIndex.ToString, "khong"}}
                SendMessage(mess)
            End If
            points = New List(Of Point3D)()
        Catch ex As Exception
        End Try
        'Else
        '    Dim liP As List(Of IPosition71) = ArrayDoubleToListP(PllVts)
        '    For i As Integer = 0 To liP.Count - 2
        '        LineTTLL(liP(i), liP(i + 1))
        '    Next
        'End If
    End Sub

    Private Sub LineTTLL(P1 As IPosition71, P2 As IPosition71)
        Try
            Dim K1 As IPosition71 = Nothing, K2 As IPosition71 = Nothing, K3 As IPosition71 = Nothing, K4 As IPosition71 = Nothing,
            K11 As IPosition71 = Nothing, K12 As IPosition71 = Nothing, K21 As IPosition71 = Nothing, K22 As IPosition71 = Nothing,
            K31 As IPosition71 = Nothing, K32 As IPosition71 = Nothing, K41 As IPosition71 = Nothing, K42 As IPosition71 = Nothing, Pt1 As IPosition71 = Nothing, Pt2 As IPosition71 = Nothing

            If Lenhve = "capdachien" Or Lenhve = "capquang" Or Lenhve = "capdongtruc" Or Lenhve = "capnguondien" Then
                K1 = P1.Move(Dorongduong * 16, FGoc(P1, P2) + 180, 0)
                K2 = P1.Move(Dorongduong * 20, FGoc(P1, P2) + 180, 0)
                K3 = P2.Move(-Dorongduong * 16, FGoc(P1, P2) + 180, 0)
                K4 = P2.Move(-Dorongduong * 20, FGoc(P1, P2) + 180, 0)

                If Lenhve = "capdachien" Or Lenhve = "capdongtruc" Or Lenhve = "capnguondien" Then
                    K11 = K1.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                    K12 = K1.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)
                    K21 = K2.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                    K22 = K2.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)

                    K31 = K3.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                    K32 = K3.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)
                    K41 = K4.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                    K42 = K4.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)

                    If Lenhve = "capdongtruc" Then
                        Dim K5 As IPosition71 = P1.Move(Dorongduong * 18, FGoc(P1, P2) + 180, 0)
                        Dim K6 As IPosition71 = P2.Move(-Dorongduong * 18, FGoc(P1, P2) + 180, 0)
                        Dim LiV1 As List(Of IPosition71) = LiPCircle(K5, Dorongduong * 6, 0, 10)
                        Dim LiV2 As List(Of IPosition71) = LiPCircle(K6, Dorongduong * 6, 0, 10)
                        FDuongList(LiV1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        FDuongList(LiV2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    End If

                ElseIf Lenhve = "capquang" Then
                    K11 = K1.Move(Dorongduong * 4.5, FGoc(P1, P2) + 45, 0)
                    K12 = K1.Move(Dorongduong * 4.5, FGoc(P1, P2) + 315, 0)
                    K21 = K2.Move(Dorongduong * 4.5, FGoc(P1, P2) + 45, 0)
                    K22 = K2.Move(Dorongduong * 4.5, FGoc(P1, P2) + 315, 0)

                    K31 = K3.Move(Dorongduong * 4.5, FGoc(P1, P2) + 135, 0)
                    K32 = K3.Move(Dorongduong * 4.5, FGoc(P1, P2) + 225, 0)
                    K41 = K4.Move(Dorongduong * 4.5, FGoc(P1, P2) + 135, 0)
                    K42 = K4.Move(Dorongduong * 4.5, FGoc(P1, P2) + 225, 0)
                End If
            ElseIf Lenhve = "capliendai" Then
                K1 = P1.Move(Dorongduong * 16, FGoc(P1, P2) + 180, 0)
                K2 = P1.Move(Dorongduong * 20, FGoc(P1, P2) + 180, 0)
                K3 = P2.Move(-Dorongduong * 16, FGoc(P1, P2) + 180, 0)
                K4 = P2.Move(-Dorongduong * 20, FGoc(P1, P2) + 180, 0)

                K11 = K1.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                K12 = K1.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)
                K21 = K2.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                K22 = K2.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)

                K31 = K3.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                K32 = K3.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)
                K41 = K4.Move(Dorongduong * 4, FGoc(P1, P2) + 90, 0)
                K42 = K4.Move(Dorongduong * 4, FGoc(P1, P2) + 270, 0)

                Pt1 = P1.Move(Dorongduong * 9, FGoc(P1, P2) + 180, 0)
                Pt2 = P2.Move(-Dorongduong * 9, FGoc(P1, P2) + 180, 0)
                Dim M1 As IPosition71 = P1.Move(Dorongduong * 5, FGoc(P1, P2) + 90, 0)
                Dim M2 As IPosition71 = P1.Move(Dorongduong * 5, FGoc(P1, P2) + 270, 0)
                Dim M3 As IPosition71 = Pt1.Move(Dorongduong * 3, FGoc(P1, P2) + 270, 0)
                Dim M4 As IPosition71 = Pt1.Move(Dorongduong * 3, FGoc(P1, P2) + 90, 0)
                Dim liM As New List(Of IPosition71) From {M1, M2, M3, M4, M1}
                FDuongList(liM, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Dim N1 As IPosition71 = P2.Move(Dorongduong * 5, FGoc(P1, P2) + 90, 0)
                Dim N2 As IPosition71 = P2.Move(Dorongduong * 5, FGoc(P1, P2) + 270, 0)
                Dim N3 As IPosition71 = Pt2.Move(Dorongduong * 3, FGoc(P1, P2) + 270, 0)
                Dim N4 As IPosition71 = Pt2.Move(Dorongduong * 3, FGoc(P1, P2) + 90, 0)
                Dim liN As New List(Of IPosition71) From {N1, N2, N3, N4, N1}
                FDuongList(liN, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            ElseIf Lenhve = "lienlacViba" Or Lenhve = "lienlacVT" Then
                K1 = P1.Move(Dorongduong * 12, FGoc(P1, P2) + 180, 0)
                K3 = P2.Move(-Dorongduong * 12, FGoc(P1, P2) + 180, 0)
                Dim liMt1 As List(Of IPosition71) = Muiten(P1, K1, FGoc(P1, K1), 0.6, 1.0)
                Dim liMt2 As List(Of IPosition71) = Muiten(P2, K3, FGoc(P2, K3), 0.6, 1.0)
                Dim LiMTC As New List(Of IPosition71)
                AddPointToList(LiMTC, liMt1, 4, 6)
                AddPointToList(LiMTC, liMt1, 0, 3)
                AddPointToList(LiMTC, liMt2, 4, 6)
                AddPointToList(LiMTC, liMt2, 0, 3)
                FVungList(LiMTC, 4294967295, 0, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 1)
                Dim Pd1 As IPosition71 = CenterPoint(LiMTC(1), LiMTC(5))
                Dim Pd2 As IPosition71 = CenterPoint(LiMTC(8), LiMTC(12))
                DemCau(Pd1, Pd2)

                If Lenhve = "lienlacViba" Then
                    K2 = P1.Move(Dorongduong * 20, FGoc(P1, P2) + 180, 0)
                    K4 = P2.Move(-Dorongduong * 20, FGoc(P1, P2) + 180, 0)
                    K21 = K2.Move(Dorongduong * 5, FGoc(P1, P2) + 90, 0)
                    K22 = K2.Move(Dorongduong * 5, FGoc(P1, P2) + 270, 0)
                    Dim Kt As IPosition71 = K2.Move(Dorongduong * 4, FGoc(P1, P2) + 180, 0)
                    Dim Tt As New List(Of IPosition71) From {K21, Kt, K22}
                    FVungList(Curveline(Tt, 6), 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 1)
                    K41 = K4.Move(Dorongduong * 5, FGoc(P1, P2) + 90, 0)
                    K42 = K4.Move(Dorongduong * 5, FGoc(P1, P2) + 270, 0)
                    Dim Ks As IPosition71 = K4.Move(-Dorongduong * 4, FGoc(P1, P2) + 180, 0)
                    Dim Ts As New List(Of IPosition71) From {K41, Ks, K42}
                    FVungList(Curveline(Ts, 6), 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 1)
                End If
            End If

            Dim liC As List(Of IPosition71)
            If Not Lenhve = "lienlacViba" And Not Lenhve = "lienlacVT" Then
                If Lenhve = "capliendai" Then
                    liC = New List(Of IPosition71) From {Pt1, K1, K11, K1, K12, K1, K2, K21, K2, K22, K2, K3, K31, K3, K32, K3, K4, K41, K4, K42, K4, Pt2}
                Else
                    liC = New List(Of IPosition71) From {P1, K1, K11, K1, K12, K1, K2, K21, K2, K22, K2, K3, K31, K3, K32, K3, K4, K41, K4, K42, K4, P2}
                End If
                FDuongList(liC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                If Lenhve = "capliendai" Then
                    DemCau(Pt1, Pt2)
                Else
                    DemCau(P1, P2)
                End If
            End If
        Catch
        End Try
    End Sub

    Public Function RegionTextures(TextureFile As String, cArray() As Double, ScaleX As Double, ScaleY As Double, Gr As String, tenDT As String) As ITerrainPolygon71
        Try
            Dim mPolygon As ITerrainPolygon71 = sgworldMain.Creator.CreatePolygonFromArray(cArray, Nothing, Nothing, 2, Gr, tenDT)
            mPolygon.FillStyle.Texture.FileName = TextureFile
            mPolygon.FillStyle.Texture.ScaleX = ScaleX
            mPolygon.FillStyle.Texture.ScaleY = ScaleY
            mPolygon.FillStyle.Texture.RotateAngle = 0
            mPolygon.FillStyle.Texture.TilingMethod = TilingMethodCode.TM_METERS_PER_TILE
            mPolygon.LineStyle.Color.SetAlpha(0)
            mPolygon.Tooltip.Text = mota

            mRegionArray.Add(mPolygon)
            RegionTextures = mPolygon
        Catch
        End Try
    End Function

    Private Sub LineDTDuong() 'grB2 As String)
        Try
            tempGroup = Gr01(sgworldMain, "Temp")
            Dim mLineTemp As ITerrainPolyline71 = sgworldMain.Creator.CreatePolylineFromArray(PllVts, mau, 2, tempGroup, "Temp")
            mLineTemp.LineStyle.Width = 0
            mLineTemp.Spline = True
            mLineArray.Add(mLineTemp)
            SendLineMs(mLineTemp)
        Catch
        End Try
    End Sub

    Public Sub StempLine()
        Try
            Dim lists1 As New List(Of IPosition71)
            tempGroup = Gr01(sgworldMain, "Temp")
            Dim mPlg As ITerrainPolyline71
            If soDiem > 0 Then
                lists1.Add(mPos)
                lists1.Add(mPoint)
            End If
            If lists1.Count = 2 Then
                Dim cArray1(lists1.Count * 3 - 1) As Double
                For j As Integer = 0 To lists1.Count - 1
                    cArray1(j * 3) = lists1(j).X
                    cArray1(j * 3 + 1) = lists1(j).Y
                    cArray1(j * 3 + 2) = 0
                Next
                Dim mILineString As ILineString = sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cArray1)
                Dim cPolygonGeometry As IGeometry = sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(mILineString)
                mPlg = sgworldMain.Creator.CreatePolyline(cPolygonGeometry, sgworldMain.Creator.CreateColor(255, 150, 0, 255), 2, tempGroup, "Temp")
                mPlg.LineStyle.Width = Tyle * 100
            End If
            soDiem += 1
        Catch
        End Try
    End Sub

    Private Sub DTDuong()
        Try
            Dim LiP As List(Of IPosition71) = ArrayDoubleToListP(PllVts)
            If Lenhve = "Doituongduong" Then
                Dim mDuong As ITerrainPolyline71
                If ChebTheoGD.Checked = False Then
                    mDuong = FDuongList(LiP, 4294967295, "", 0, 0, sgworldMain.Creator.CreateColor(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B, 255), Val(txtChieucaochu.Text), False, 2, 0, 2) ' 2, False, 2)jiii
                Else
                    mDuong = FDuongList(LiP, 4294967295, "", 0, 0, mau, Val(txtChieucaochu.Text), False, 2, 0, 2) ' 2, False, 2)jiii
                End If
                If ChebTron.Checked = True Then
                    mDuong.Spline = True
                End If
            ElseIf Lenhve = "giaothonghao" Or Lenhve = "Doituongduong" Or Lenhve = "Gioituyen" Or Lenhve = "LLTructiep" Or Lenhve = "LLthuongxuyen2" Or Lenhve = "cuma" Then
                FDuongList(LiP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
                If Lenhve = "cuma" Then
                    Dauchuthap(LiP(0), FGoc(LiP(0), LiP(1)), mau, 2.5)
                    Dauchuthap(LiP(1), FGoc(LiP(0), LiP(1)), mau, 2.5)
                    DemCau(LiP(1), LiP(0))
                End If

            ElseIf Lenhve = "LLVuotcap" Then
                FDuongList(LiP, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
            ElseIf Lenhve = "LLHiepdong" Then
                FDuongList(LiP, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
            Else
                If Not Lenhve = "LLThuongxuyen" And Not Lenhve = "LLKhongthuongxuyen" And Not Lenhve = "capdachien" And Not Lenhve = "capquang" And Not Lenhve = "capdongtruc" And Not Lenhve = "capnguondien" And Not Lenhve = "capliendai" And Not Lenhve = "lienlacVT" And Not Lenhve = "lienlacViba" Then
                    FDuongList(LiP, 4294967295, "", 0, 0, mauNau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
                End If

                For i As Integer = 0 To LiP.Count - 2
                    Dim P As IPosition71 = CenterPoint(LiP(i), LiP(i + 1)) ' sgworldMain.Creator.CreatePosition(0.5 * (liP(i).X + liP(i + 1).X), 0.5 * (liP(i).Y + liP(i + 1).Y), 0, 2, 0, 0, 0, 0)
                    If Lenhve = "Giaothonghaoconap" Or Lenhve = "DDgnguytrangLuoi" Or Lenhve = "Phaduong" Or Lenhve = "Duongcothhacanh" Or Lenhve = "DDbotrimin" Then
                        Dim Kc, GocN As Double
                        If Lenhve = "Giaothonghaoconap" Then
                            GocN = 105
                            Kc = Dorongduong * 3
                        ElseIf Lenhve = "Phaduong" Or Lenhve = "Duongcothhacanh" Or Lenhve = "DDbotrimin" Then
                            GocN = 90
                            Kc = Dorongduong * 5
                        Else
                            GocN = 90
                            Kc = Dorongduong * 3
                        End If
                        Dim K1 As IPosition71 = P.Move(Kc * 2, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K2 As IPosition71 = P.Move(-Kc * 2, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim pc1 As IPosition71 = P.Move(Kc, FGoc(LiP(i), LiP(i + 1)) + GocN, 0)
                        Dim pc2 As IPosition71 = P.Move(Kc, FGoc(LiP(i), LiP(i + 1)) + 180 + GocN, 0)

                        Dim K11 As IPosition71 = K1.Move(Kc, FGoc(LiP(i), LiP(i + 1)) + GocN, 0)
                        Dim K12 As IPosition71 = K1.Move(Kc, FGoc(LiP(i), LiP(i + 1)) + 180 + GocN, 0)
                        Dim K21 As IPosition71 = K2.Move(Kc, FGoc(LiP(i), LiP(i + 1)) + GocN, 0)
                        Dim K22 As IPosition71 = K2.Move(Kc, FGoc(LiP(i), LiP(i + 1)) + 180 + GocN, 0)

                        If Lenhve = "Giaothonghaoconap" Then
                            Dim liK As New List(Of IPosition71) From {K12, K22, K21, pc2, K12, pc1, K21, K11, K12}
                            FDuongList(liK, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        ElseIf Lenhve = "Phaduong" Or Lenhve = "Duongcothhacanh" Or Lenhve = "DDbotrimin" Then
                            Dim Ks11 As IPosition71 = P.Move(Dorongduong * 6, FGoc(LiP(i), LiP(i + 1)), 0)
                            Dim Ks21 As IPosition71 = P.Move(-Dorongduong * 6, FGoc(LiP(i), LiP(i + 1)), 0)
                            Dim liK As New List(Of IPosition71) From {K22, K21, K11, K12, K22, K21}
                            If Lenhve = "Phaduong" Then
                                Dauchuthap(P, FGoc(LiP(i), LiP(i + 1)), mau, 1.5)
                                Dauchuthap(Ks11, FGoc(LiP(i), LiP(i + 1)), mau, 1.5)
                                Dauchuthap(Ks21, FGoc(LiP(i), LiP(i + 1)), mau, 1.5)
                                FDuongList(liK, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                            ElseIf Lenhve = "DDbotrimin" Then
                                FDuongList(liK, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                                MCircleTQ(P, Dorongduong * 2.5, 4294967295, Dorongduong * 1.5, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
                                MCircleTQ(Ks11, Dorongduong * 2.5, 4294967295, Dorongduong * 1.5, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
                                MCircleTQ(Ks21, Dorongduong * 2.5, 4294967295, Dorongduong * 1.5, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)

                            Else
                                MCircleTQ(P, Dorongduong * 7, 4294967295, Dorongduong * 1.5, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
                                MakeText(P, 0, fLabelStyleMain.Scale, 90 + FGoc(LiP(i), LiP(i + 1)), "T", "", mauRedBlue, 0, 0, 2, 2)
                                FDuongList(liK, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                            End If
                        ElseIf Lenhve = "DDgnguytrangLuoi" Then
                            Dim S1 As IPosition71 = K21.Move(FKc(K1, K2) / 3, FGoc(K1, K2), 0)
                            Dim S2 As IPosition71 = K22.Move(FKc(K1, K2) / 3, FGoc(K1, K2), 0)
                            Dim S3 As IPosition71 = K22.Move(2 / 3 * FKc(K1, K2), FGoc(K1, K2), 0)
                            Dim S4 As IPosition71 = K21.Move(2 / 3 * FKc(K1, K2), FGoc(K1, K2), 0)
                            Dim liKXanh As New List(Of IPosition71) From {S1, S2, S3, S4, K11, K1, K2}
                            FDuongList(liKXanh, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                            Dim liK As New List(Of IPosition71) From {K22, K21, K11, K12, K22}
                            FDuongList(liK, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                        End If
                    ElseIf Lenhve = "DDgdichphahoai" Then
                        Dim K1 As IPosition71 = P.Move(Dorongduong * 16, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K2 As IPosition71 = P.Move(-Dorongduong * 16, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dauchuthap(P, FGoc(LiP(i), LiP(i + 1)), mau3, 2.5)
                        Dauchuthap(K1, FGoc(LiP(i), LiP(i + 1)), mau3, 2.5)
                        Dauchuthap(K2, FGoc(LiP(i), LiP(i + 1)), mau3, 2.5)
                    ElseIf Lenhve = "DDgVongtranh" Then
                        Dim K1 As IPosition71 = P.Move(Dorongduong * 25, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K2 As IPosition71 = P.Move(-Dorongduong * 25, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim p1 As IPosition71 = P.Move(Dorongduong * 10, FGoc(LiP(i), LiP(i + 1)) + 90 + (i * 180), 0)
                        Dim liKXanh As List(Of IPosition71) = LiCrube3Point(K1, p1, K2)
                        FDuongList(liKXanh, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    ElseIf Lenhve = "DDGngapnuoc" Then
                        Dim TQ As New List(Of Double)({17.1, 0.00, 18.25, 25.18, 21.08, 45.37, 24.42, 60.32, 27.35, 71.78, 29.31, 81.32, 30.0, 90.0, 29.31, 98.68, 27.35, 108.22, 24.42, 119.68, 21.08, 134.63, 18.25, 154.82, 17.1, 180.0, 18.25, 205.18, 21.08, 227.75, 24.42, 240.32, 27.35, 251.78, 29.31, 261.32, 30.0, 270.0, 29.31, 278.68, 27.35, 288.22, 24.42, 299.68, 21.08, 314.63, 18.25, 334.84, 17.1, 360.0})
                        Dim LiS1 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, P, 40.0 * Tyle, 25 + MkGoc(LiP(i), LiP(i + 1)) * 180 / Math.PI)
                        FDuongList(LiS1, 4294967295, "", 0, 0, mauH2O, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
                        Dim LiS1con As New List(Of IPosition71) From {LiS1(8), LiS1(4), LiS1(3), LiS1(9), LiS1(10), LiS1(2), LiS1(1), LiS1(11), LiS1(12), LiS1(24), LiS1(23), LiS1(13), LiS1(14), LiS1(22), LiS1(21), LiS1(15), LiS1(16), LiS1(20)}
                        FDuongList(LiS1con, 4294967295, "", 0, 0, mauH2O, Dorongduong * 1.2, False, 2, 0, 2) ' 2, False, 2)
                    ElseIf Lenhve = "DDgCoDichmatdat" Then
                        Dim K1 As IPosition71 = P.Move(Dorongduong * 30, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K2 As IPosition71 = P.Move(-Dorongduong * 30, FGoc(LiP(i), LiP(i + 1)), 0)
                        KvMBTuantieu(K1, K2)
                    ElseIf Lenhve = "DDgdichphahoaiMB" Then
                        Dim K1 As IPosition71 = P.Move(-Dorongduong * 8, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim P2 As IPosition71 = P.Move(Dorongduong * 5, 45.0 + FGoc(LiP(i), LiP(i + 1)), 0)
                        DanP(P, 90 + FGoc(LiP(i), LiP(i + 1)), mau3, mau4, "CN")
                        DanP(P2, 90 + FGoc(LiP(i), LiP(i + 1)), mau3, mau4, "CN")
                        loaiKH = "2120031"
                        If cbTa_DP.SelectedIndex = 0 Then
                            Ta_Doiphuong = 2
                        Else
                            Ta_Doiphuong = 1
                        End If
                        tenGiaidoan = "2.mkx"
                        fileImage = PathLabel("\2X\", loaiKH, ChieuKH, mP, m2X, Ta_Doiphuong, tenGiaidoan)
                        Dim M2 As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(K1, "", fileImage, fLabelStyleMain, GroupBac2Main, tenKH)
                        mLabelArray.Add(M2)
                    ElseIf Lenhve = "LLThuongxuyen" Or Lenhve = "LLKhongthuongxuyen" Then
                        Dim LiMT1 As List(Of IPosition71) = Muiten(LiP(i + 1), LiP(i), FGoc(LiP(i + 1), LiP(i)), 0.45, 1.0)
                        If Lenhve = "LLKhongthuongxuyen" Then
                            LiMT1.RemoveRange(6, 1)
                        End If
                        FVungList(LiMT1, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
                    ElseIf Lenhve = "DgVongtranh" Or Lenhve = "DgTieudoc" Then
                        Dim p1 As IPosition71 = P.Move(Dorongduong * 3, FGoc(LiP(i), LiP(i + 1)) + 90 + (i * 180), 0)
                        Dim p2 As IPosition71 = P.Move(Dorongduong * 13, FGoc(LiP(i), LiP(i + 1)) + 90 + (i * 180), 0)
                        Dim K1 As IPosition71 = P.Move(Dorongduong * 13, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K11 As IPosition71 = P.Move(Dorongduong * 26, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K2 As IPosition71 = P.Move(-Dorongduong * 13, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim K21 As IPosition71 = P.Move(-Dorongduong * 26, FGoc(LiP(i), LiP(i + 1)), 0)
                        Dim TQ As New List(Of Double)({17.1, 0.00, 18.25, 25.18, 21.08, 45.37, 24.42, 60.32, 27.35, 71.78, 29.31, 81.32, 30.0, 90.0, 29.31, 98.68, 27.35, 108.22, 24.42, 119.68, 21.08, 134.63, 18.25, 154.82, 17.1, 180.0, 18.25, 205.18, 21.08, 227.75, 24.42, 240.32, 27.35, 251.78, 29.31, 261.32, 30.0, 270.0, 29.31, 278.68, 27.35, 288.22, 24.42, 299.68, 21.08, 314.63, 18.25, 334.84, 17.1, 360.0})
                        Dim LiS1 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, p1, 40.0 * Tyle, 10 + MkGoc(LiP(i), LiP(i + 1)) * 180 / Math.PI)
                        If Lenhve = "DgVongtranh" Then
                            Dim Dvong As List(Of IPosition71) = LiCrube3Point(K11, p2, K21)
                            FDuongList(Dvong, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                            Dim LiMT1 As List(Of IPosition71) = Muiten(Dvong(5), Dvong(0), FGoc(Dvong(5), Dvong(0)), 0.6, 1.0)
                            FVungList(LiMT1, 4294967295, 0.0, mau2, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
                            Dim LiMT2 As List(Of IPosition71) = Muiten(Dvong(19), Dvong(24), FGoc(Dvong(19), Dvong(24)), 0.6, 1.0)
                            FVungList(LiMT2, 4294967295, 0.0, mau2, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
                            FVungList(LiS1, 4294967295, Dorongduong, mauChu, 1, mauHH, 0, "", 0, 0, 0, False, 2, 4)
                            FVungList(LiS1, 4294967295, 0, mauChu, 1, mauHH, 1, "", 0, 0, 0, False, 2, 2)
                        Else
                            Dim LiMT1 As List(Of IPosition71) = Muiten(K1, K11, FGoc(LiP(i + 1), LiP(i)), 0.6, 1.0)
                            FVungList(LiMT1, 4294967295, 0.0, mau2, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
                            Dim LiMT2 As List(Of IPosition71) = Muiten(K2, K21, FGoc(LiP(i), LiP(i + 1)), 0.6, 1.0)
                            FVungList(LiMT2, 4294967295, 0.0, mau2, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
                            FVungList(LiS1, 4294967295, 0, mauChu, 0, mauHH, 1, "", 0, 0, 0, False, 2, 1)
                            FVungList(LiS1, 4294967295, Dorongduong, mauChu, 1, mauHH, 0, "", 0, 0, 0, False, 2, 1)
                        End If
                    ElseIf Lenhve = "capdachien" Or Lenhve = "capquang" Or Lenhve = "capdongtruc" Or Lenhve = "capnguondien" Or Lenhve = "capliendai" Or Lenhve = "lienlacVT" Or Lenhve = "lienlacViba" Then
                        LineTTLL(LiP(i), LiP(i + 1))
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

#End Region

    Private Sub TlMau1_Click(sender As Object, e As EventArgs) Handles tlMau1.Click
        Try
            Me.ColorDialog1.ShowDialog()
            tlMau1.BackColor = ColorDialog1.Color
        Catch
        End Try
    End Sub

    Private Sub TlMau2_Click(sender As Object, e As EventArgs) Handles tlMau2.Click
        Try
            Me.ColorDialog2.ShowDialog()
            tlMau2.BackColor = ColorDialog2.Color
        Catch
        End Try
    End Sub

    Private Sub TlMau1_BackColorChanged(sender As Object, e As EventArgs) Handles tlMau1.BackColorChanged
        ColorDialog1.Color = tlMau1.BackColor
    End Sub

    Private Sub TlMau2_BackColorChanged(sender As Object, e As EventArgs) Handles tlMau2.BackColorChanged
        ColorDialog2.Color = tlMau2.BackColor
    End Sub

    Private Sub LbFont_Click(sender As Object, e As EventArgs) Handles lbFont.Click
        Try
            Me.FontDialog1.ShowDialog()
            lbFont.Font = FontDialog1.Font
            lbFont.Text = FontDialog1.Font.Name
            txtNoidungchu.Font = FontDialog1.Font
            lbFont.Font = New System.Drawing.Font(FontDialog1.Font.Name, 10, FontStyle.Regular)
            lbFont.Size = New Size(140, 18)
        Catch
        End Try
    End Sub

    Private Sub ChebTheoGD_CheckedChanged(sender As Object, e As EventArgs) Handles ChebTheoGD.CheckedChanged
        Try
            If ChebTheoGD.Checked = True Then
                tlMau1.Enabled = False
                tlMau2.Enabled = False
                txtChieucaochu.Enabled = False
                txtChieucaochu.Text = ""
                tlMau1.BackColor = ToolTI1.BackColor
                tlMau2.BackColor = ToolTI1.BackColor
            Else
                tlMau1.Enabled = True
                tlMau2.Enabled = True
                txtChieucaochu.Enabled = True
                txtChieucaochu.Text = "50"
                tlMau1.BackColor = Color.Red
                tlMau2.BackColor = Color.Blue
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtChieucaochut_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChieucaochu.KeyPress
        Import_KeyPress(e, Chr(8))
    End Sub

    Private Sub DTChu()
        Try
            If ChebTheoGD.Checked = False Then
                If txtChieucaochu.Text <> "" Then
                    MsgBox("Hãy chọn chiều cao chữ")
                    Exit Sub
                Else
                    MakeText(mPointClick, 0, Val(txtChieucaochu.Text) * Tyle, 0, txtNoidungchu.Text, "", sgworldMain.Creator.CreateColor(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B, 255), 0, 0, 2, 2)
                End If
            Else
                MakeText(mPointClick, 0, 9, 0, txtNoidungchu.Text, "", sgworldMain.Creator.CreateColor(0, 0, 0, 0), 0, 0, 2, 2)
                'MakeText(mPointClick, 0, Val(txtChieucaochu.Text) * Tyle, 0, txtNoidungchu.Text, "", mau, 0, 0, 2, 2)
            End If
        Catch
        End Try
    End Sub

    Public Sub DuongSS()
        Try
            Dim khoangCach As Double
            Dim line1 As New List(Of Point3D), line2 As New List(Of Point3D)
            Dim liP, LiD1, LiD2 As New List(Of IPosition71)
            If Lenhve = "KvTrSHHBangMB" Then
                For i As Integer = 0 To (PllVts.Count / 3) - 2
                    Dim P As IPosition71 = sgworldMain.Creator.CreatePosition(PllVts(i * 3), PllVts(i * 3 + 1), 0, 2, 0, 0, 0, 0)
                    liP.Add(P)
                Next
            End If

            If ChebTheoGD.Checked = True Then
                khoangCach = Dorongduong * 3.4
            ElseIf Lenhve = "KvTrSHHBangMB" Then
                khoangCach = 1.65 * Val(TxtGhichuKH.Text)
            Else
                khoangCach = 1.7 * Val(txtChieucaochu.Text)
            End If

            For j As Integer = 0 To points.Count - 1
                If (j = points.Count - 1) Then
                    Dim line As New LineBusiness(points(j).X, points(j).Y, points(j - 1).X, points(j - 1).Y)
                    Dim newPoints As List(Of Point3D) = line.Create2Points(points(j), points(j - 1), khoangCach)

                    If (line.SameSide(line1(line1.Count - 1), newPoints(0), line2(line2.Count - 1), newPoints(1))) Then
                        line1.Add(newPoints(0))
                        line2.Add(newPoints(1))
                    Else
                        line1.Add(newPoints(1))
                        line2.Add(newPoints(0))
                    End If
                Else
                    Dim line As New LineBusiness(points(j).X, points(j).Y, points(j + 1).X, points(j + 1).Y)
                    Dim newPoints As List(Of Point3D) = line.Create2Points(points(j), points(j + 1), khoangCach)
                    If line1.Count = 0 Then
                        line1.Add(newPoints(0))
                        line2.Add(newPoints(1))
                    Else
                        If (line.SameSide(line1(line1.Count - 1), newPoints(0), line2(line2.Count - 1), newPoints(1))) Then
                            line1.Add(newPoints(0))
                            line2.Add(newPoints(1))
                        Else
                            line1.Add(newPoints(1))
                            line2.Add(newPoints(0))
                        End If
                    End If
                End If
            Next

            Dim cArray1(line1.Count * 3 - 1) As Double
            Dim cArray2(line2.Count * 3 - 1) As Double
            For i As Integer = 0 To line1.Count - 1
                cArray1(i * 3) = line1(i).X / 360000
                cArray1(i * 3 + 1) = line1(i).Y / 360000
                cArray1(i * 3 + 2) = 0
                cArray2(i * 3) = line2(i).X / 360000
                cArray2(i * 3 + 1) = line2(i).Y / 360000
                cArray2(i * 3 + 2) = 0
            Next

            For i As Integer = 0 To (cArray1.Count / 3) - 1
                Dim P1 As IPosition71 = sgworldMain.Creator.CreatePosition(cArray1(i * 3), cArray1(i * 3 + 1), 0, 2, 0, 0, 0, 0)
                LiD1.Add(P1)
                Dim P2 As IPosition71 = sgworldMain.Creator.CreatePosition(cArray2(i * 3), cArray2(i * 3 + 1), 0, 2, 0, 0, 0, 0)
                LiD2.Add(P2)
            Next
            points = New List(Of Point3D)()

            If Lenhve = "KvTrSHHBangMB" Then
                Dim Kp1 As IPosition71 = liP(0).Move(Dorongduong * 20, 180 + FGoc(liP(1), liP(0)), 0)
                Dim Kp2 As IPosition71 = liP(liP.Count - 1).Move(Dorongduong * 20, 180 + FGoc(liP(liP.Count - 2), liP(liP.Count - 1)), 0)
                Dim LiPCur As List(Of IPosition71) = Curveline(liP, 6)
                Dim LiD1Cur As List(Of IPosition71) = Curveline(LiD1, 6)
                Dim LiD2Cur As List(Of IPosition71) = Curveline(LiD2, 6)
                LiPCur.Add(Kp2)
                LiPCur.Reverse()
                LiPCur.Add(Kp1)
                LiD2Cur.Reverse()
                UniCruve(LiD1Cur, LiD2Cur)
                Dim Geo1 As IGeometry = ListtoGeo(LiD1Cur)
                Dim Geo2 As IGeometry = Geo1.SpatialOperator.buffer(-Dorongduong * 2)
                LiD1Cur.Add(LiD1Cur(0))
                FDuongList(LiPCur, 4294967295, "", 0, 0, mauNau, Dorongduong * 2.0, False, 2, 0, 3)
                FDuongList(LiD1Cur, 4294967295, "", 0, 0, mau, Dorongduong * 2.0, False, 2, 0, 2)
                FDuongList(GeoToList(Geo2), 4294967295, "", 0, 0, mau2, Dorongduong * 2.0, False, 2, 0, 1)
            Else
                If ChebTheoGD.Checked = True Then
                    FDuongList(LiD1, 4294967295, "", 0, 0, mau, Dorongduong * 2.0, False, 2, 0, 2)
                    FDuongList(LiD2, 4294967295, "", 0, 0, mau2, Dorongduong * 2.0, False, 2, 0, 1)
                Else
                    FDuongList(LiD1, 4294967295, "", 0, 0, sgworldMain.Creator.CreateColor(ColorDialog1.Color.R, ColorDialog1.Color.G, ColorDialog1.Color.B, 255), Val(txtChieucaochu.Text), False, 2, 0, 2)
                    FDuongList(LiD2, 4294967295, "", 0, 0, sgworldMain.Creator.CreateColor(ColorDialog2.Color.R, ColorDialog2.Color.G, ColorDialog2.Color.B, 255), Val(txtChieucaochu.Text), False, 2, 0, 1)
                End If
            End If

            SLenhve3DMs()
        Catch
        End Try
    End Sub

    Private Sub Chenanh()
        Try
            Dim chu As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(mPointClick, "", OpenFileDialog1.FileName, fLabelStyleMain, GroupBac2Main, tenKH)
            chu.Style.LimitScreenSize = False
            chu.Style.Scale = 1
            mLineArray.Add(chu)
            SLenhve3DMs()
        Catch
        End Try
    End Sub

    Private Sub Shape()
        Try
            OpenFileDialog1.Title = "Mở tập tin *.shp"
            OpenFileDialog1.Filter = "Tập tin TEXT (*.shp) | *.shp"
            OpenFileDialog1.ShowDialog()
            Dim mShapFile As String = OpenFileDialog1.FileName
            Dim t1 As String = String.Format("FileName={0};TEPlugName=OGR;", mShapFile)
            Dim mShap As IFeatureLayer71 = sgworldMain.Creator.CreateFeatureLayer(mShapFile.Split("\")(mShapFile.Split("\").Count - 1).Split(".")(0), t1)
            mShap.DataSourceInfo.Attributes.ImportAll = True
            mShap.Streaming = True
            mShap.Refresh()
            sgworldMain.Project.Save()
        Catch
        End Try
    End Sub

    Private Sub ToolTI_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolTI1.ItemClicked
        Try
            mauKT = False
            If e.ClickedItem.Name = "tlTrinhbay" Then
                cbTa_DP.SelectedIndex = 0
                MouseHook1.Dispose()
                Dim k0 = sgworldMain.ProjectTree.FindItem("Trinh bay\Khung")
                If String.IsNullOrEmpty(k0) = True Then
                    MsgBox("Chưa có khung Văn kiện tác chiến...!")
                    Exit Sub
                Else
                    SPanel(panelTrinhbay1)
                End If
            ElseIf e.ClickedItem.Name = "tlvekhung" Then
                MouseHook1.Dispose()
                SPanel(panelKhung)
            End If

            If e.ClickedItem.Name = "tlLayer" Then
                sgworldMain.Command.Execute(1013, 2)
            End If

            If e.ClickedItem.Name = "tlConvertSHP" Then
                Shape()
            End If

            If e.ClickedItem.Name = "tlmoveGroup" Or e.ClickedItem.Name = "tlcopyGroup" Or e.ClickedItem.Name = "tlrotateGroup" Then
                SetMouseArrow()
            End If

            NewTool("Taungam", e.ClickedItem.Name, e)

            If Not e.ClickedItem.Name = "tlConvertSHP" And Not e.ClickedItem.Name = "tlMau1" And Not e.ClickedItem.Name = "tlMau2" And Not e.ClickedItem.Name = "lbFont" And Not e.ClickedItem.Name = "tlmoveGroup" And Not e.ClickedItem.Name = "tlrotateGroup" Then
                ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            End If
        Catch
        End Try
    End Sub

#Region " Ve khung"

    Private Sub Khung()
        Try
            Dim lists1 As New List(Of IPosition71)
            Dim P1, P2, P3, P4 As IPosition71
            If chebKhungtheodiem.Checked = True Then
                P1 = sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
                P2 = sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(4), 0, 2, 0, 0, 0, 0)
                P3 = sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
                P4 = sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(1), 0, 2, 0, 0, 0, 0)
            Else
                P1 = sgworldMain.Creator.CreatePosition(Val(txtToadoTraiduoi.Text.Split(",")(0)), Val(txtToadoTraiduoi.Text.Split(",")(1)), 0, 2, 0, 0, 0, 0)
                P4 = sgworldMain.Creator.CreatePosition(Val(txtToadoPhaitren.Text.Split(",")(0)), Val(txtToadoTraiduoi.Text.Split(",")(1)), 0, 2, 0, 0, 0, 0)
                P3 = sgworldMain.Creator.CreatePosition(Val(txtToadoPhaitren.Text.Split(",")(0)), Val(txtToadoPhaitren.Text.Split(",")(1)), 0, 2, 0, 0, 0, 0)
                P2 = sgworldMain.Creator.CreatePosition(Val(txtToadoTraiduoi.Text.Split(",")(0)), Val(txtToadoPhaitren.Text.Split(",")(1)), 0, 2, 0, 0, 0, 0)
            End If
            lists1.Add(P1)
            lists1.Add(P2)
            lists1.Add(P3)
            lists1.Add(P4)
            GroupBac2Main = Gr02(sgworldMain, "Trinh bay", "Khung")
            Dim mRegion As ITerrainPolygon71 = FVungList(lists1, 4294967295, Dorongduong * 4, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
            SLenhve3DMs()
            panelKhung.Visible = False
            MouseHook1.Dispose()
            chebKhungtheodiem.Checked = False
            If Bd3D = False Then
                sgworldMain.Command.Execute(1052, 0)
            End If
        Catch
        End Try
    End Sub

    Private Sub TxtToadoTraiduoi_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtToadoTraiduoi.MouseDown
        txtToadoTraiduoi.Text = ""
    End Sub

    Private Sub TxtToadoPhaitren_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles txtToadoPhaitren.MouseDown
        txtToadoPhaitren.Text = ""
    End Sub

    Private Sub TxtToadoPhaitren_TextChanged(sender As Object, e As EventArgs) Handles txtToadoPhaitren.TextChanged
        StatusbtnKhung()
    End Sub

    Private Sub TxtToadoTraiduoi_TextChanged(sender As Object, e As EventArgs) Handles txtToadoTraiduoi.TextChanged
        StatusbtnKhung()
    End Sub

    Private Sub ChebKhungtheodiem_CheckedChanged(sender As Object, e As EventArgs) Handles chebKhungtheodiem.CheckedChanged
        Try
            If chebKhungtheodiem.Checked = True Then
                txtToadoTraiduoi.Text = "Kinh độ, Vĩ độ"
                txtToadoPhaitren.Text = "Kinh độ, Vĩ độ"
                txtToadoTraiduoi.Enabled = False
                txtToadoPhaitren.Enabled = False
                btnKhung.Enabled = True
            Else
                txtToadoTraiduoi.Enabled = True
                txtToadoPhaitren.Enabled = True
                StatusbtnKhung()
            End If
        Catch
        End Try
    End Sub

    Private Sub StatusbtnKhung()
        Try
            If txtToadoTraiduoi.Text = "Kinh độ, Vĩ độ" Or txtToadoPhaitren.Text = "Kinh độ, Vĩ độ" Then
                btnKhung.Enabled = False
            ElseIf txtToadoTraiduoi.Text <> "Kinh độ, Vĩ độ" And txtToadoPhaitren.Text <> "Kinh độ, Vĩ độ" Then
                btnKhung.Enabled = True
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnKhung_Click(sender As Object, e As EventArgs) Handles btnKhung.Click
        Try
            Lenhve = "vekhung"
            If chebKhungtheodiem.Checked = False Then
                Khung()
            Else
                SetMouseArrow()
                MouseHook1.InstallHook()
            End If
        Catch
        End Try
    End Sub
#End Region


#Region "   Trinh bay"
    Public kcY As New Double

    Private Sub PanelTrinhbay1_VisibleChanged(sender As Object, e As EventArgs) Handles panelTrinhbay1.VisibleChanged
        Try
            If panelTrinhbay1.Visible = True Then
                txtTenVK.Text = "QUYẾT TÂM"
                txtNoidungVK.Text = "CHIẾN ĐẤU TIẾN CÔNG ..."
                txtDiadiem.Text = "SỞ CHỈ HUY ĐIỂM CAO...."
                txtBanso.Text = "Bản số 1"
                txtThoigianPheduyet.Text = "12.00 - N-2"
                txtChucvuPhechuan.Text = "SƯ ĐOÀN TRƯỞNG"
                txtHotenPhechuan.Text = "Đại tá Nguyễn Văn A"
                txtChucvuLap.Text = "TRUNG ĐOÀN TRƯỞNG"
                txtHotenLap.Text = "Trung tá Nguyễn Văn B"
                cbGiaidoan.SelectedIndex = 0
                TxtTenKH.Text = "Trinh bay"
                MaxMinPointKhung()
            End If
        Catch
        End Try
    End Sub

    Public Function MaxMinPointKhung() As List(Of IPosition71)
        Try
            listBoxX.Items.Clear()
            listBoxY.Items.Clear()
            Dim Pkhung As New List(Of IPosition71)
            Dim k1 As ITerrainPolygon71 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem("Trinh bay\Khung\Khung")) ' "Trinh bay"
            Dim ST1() As String = k1.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("((", "").Replace("((", "").Replace("))", "").Split(",")
            For i As Integer = 0 To ST1.Count - 1
                listBoxX.Items.Add(ST1(i).Split(" ")(1))
                listBoxY.Items.Add(ST1(i).Split(" ")(2))
            Next
            Dim p1 As IPosition71 = sgworldMain.Creator.CreatePosition(MinValue(listBoxX), MinValue(listBoxY), 0, 2, 0, 0, 0, 0)
            Pkhung.Add(p1)
            Dim p2 As IPosition71 = sgworldMain.Creator.CreatePosition(MaxValue(listBoxX), MaxValue(listBoxY), 0, 2, 0, 0, 0, 0)
            Pkhung.Add(p2)
            MaxMinPointKhung = Pkhung
        Catch
        End Try
    End Function

    Public Function MaxValue(List As ListBox) As Double
        Try
            MaxValue = CDbl(List.Items.Item(0))
            For N As Long = 0 To List.Items.Count - 1
                If CDbl(List.Items.Item(N)) > MaxValue Then MaxValue = CDbl(List.Items.Item(N))
            Next
        Catch
        End Try
    End Function

    Private Function MinValue(List As ListBox) As Double
        Try
            MinValue = CDbl(List.Items.Item(0))
            For N As Long = 0 To List.Items.Count - 1
                If CDbl(List.Items.Item(N)) < MinValue Then MinValue = CDbl(List.Items.Item(N))
            Next
        Catch
        End Try
    End Function

    Private Sub BtnTrinhbay_Click(sender As Object, e As EventArgs) Handles btnTrinhbay.Click
        Try
            TrinhbayVK()
            panelTrinhbay1.Visible = False
            SLenhve3DMs()
            If Bd3D = False Then
                sgworldMain.Command.Execute(1052, 0)
            End If
        Catch
        End Try
    End Sub

    Private Sub TrinhbayVK()

        listBoxX.Items.Clear()
        listBoxY.Items.Clear()
        Dim Xmax, Ymax, Xmin, Ymin As Double
        Try
            fLabelStyleMain.Bold = False
            fLabelStyleMain.TextAlignment = "Center, Center"
            fLabelStyleMain.BackgroundColor.SetAlpha(0)
            fLabelStyleMain.TextColor = mauDen
            fLabelStyleMain.LockMode = LabelLockMode.LM_AXIS
            Xmax = MaxMinPointKhung(1).X
            Xmin = MaxMinPointKhung(0).X
            Ymax = MaxMinPointKhung(1).Y
            Ymin = MaxMinPointKhung(0).Y
            Dim ChieucaoTenVK As Double = sgworldMain.CoordServices.GetDistance(Xmax, Ymax, Xmin, Ymin) / 1800 ''2150
            Dim p1 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmin, Ymax, 0, 2, 0, 0, 0, 0)
            Dim p2 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmax, Ymax, 0, 2, 0, 0, 0, 0)
            Dim p4 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmin, Ymin, 0, 2, 0, 0, 0, 0)
            If Lenhve = "pdf" Then
                TaoFene()
            ElseIf Lenhve = "Trinhbay" Then
                'If Lenhve = "trinhbay" Then
                GroupBac2Main = Gr02(sgworldMain, "Trinh bay", "Trinh bay")
                fLabelStyleMain.Scale = ChieucaoTenVK
                kcY = ChieucaoTenVK / 950
                '  kcY = ChieucaoTenVK / 1000
                MChuNDVK((Xmax + Xmin) * 0.5, Ymax - kcY, txtTenVK.Text, "TenVK")
                ''Noi dung VK
                fLabelStyleMain.Scale = ChieucaoTenVK / 1.5
                MChuNDVK((Xmax + Xmin) * 0.5, Ymax - kcY * 1.4, txtNoidungVK.Text, "NoidungVK")
                'Do mat
                fLabelStyleMain.Scale = ChieucaoTenVK / 3
                MChuNDVK(Xmax - kcY, Ymax - kcY * 1.55, txtMat.Text, "Toimat")
                '"PHÊ CHUẨN
                MChuNDVK(Xmin + kcY, Ymax - kcY * 1.65, "PHÊ CHUẨN", "Phechuan")
                ''Dia diem
                fLabelStyleMain.Scale = ChieucaoTenVK / 4
                MChuNDVK((Xmax + Xmin) * 0.5, Ymax - kcY * 1.75, txtDiadiem.Text, "DiadiemVK")
                ''Ban so
                MChuNDVK(Xmax - kcY, Ymax - kcY * 1.75, txtBanso.Text, "Banso")
                ''Thoi gian
                MChuNDVK(Xmin + kcY, Ymax - kcY * 1.85, txtThoigianPheduyet.Text, "Thoigian")
                'chuc vu phe chuan
                MChuNDVK(Xmin + kcY, Ymax - kcY * 2.05, txtChucvuPhechuan.Text, "ChucvuPhechuan")
                'Ho ten phe chuan
                MChuNDVK(Xmin + kcY, Ymax - kcY * 2.8, txtHotenPhechuan.Text, "HotenPhechuan")
                'Ben duoi Nguoi lap VK
                MChuNDVK((Xmax + Xmin) * 0.5, Ymin + kcY, txtChucvuLap.Text, "ChucvuBC")
                ''Ho va ten bao cao
                MChuNDVK((Xmax + Xmin) * 0.5, Ymin + kcY / 5.0, txtHotenLap.Text, "HotenBC")
                'Chu dan
                MChuNDVK(Xmax - kcY * 1.7, Ymin + kcY / 1.2, "CHÚ DẪN", "Chudan")
                If chebChudan1.Checked = True Then
                    MChuTB(Xmax, kcY, Ymin, 1, 1.5)
                End If
                If chebChudan2.Checked = True Then
                    MChuTB(Xmax, kcY, Ymin, 2, 2.0)
                End If
                If chebChudan3.Checked = True Then
                    MChuTB(Xmax, kcY, Ymin, 3, 3.0)
                End If
                If chebChudan4.Checked = True Then
                    MChuTB(Xmax, kcY, Ymin, 4, 6.0)
                End If
            End If
        Catch ex As Exception
            MsgBox("Chưa có khung Văn kiện tác chiến...!")
            Exit Sub
        End Try

    End Sub

    Private Sub MChuTB(mXmax As Double, mkcY As Double, mYmin As Double, mGiaidoan As Integer, sochia As Double)
        Try
            Dim P4 As IPosition71 = sgworldMain.Creator.CreatePosition(mXmax - mkcY * 2.3, mYmin + mkcY / sochia, 0, 2, 0, 0, 0, 0)
            Dim mLabel As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(P4, "Giai đoạn " & mGiaidoan.ToString & ":", "", fLabelStyleMain, GroupBac2Main, "ChudanGD4")
            mLabel.Position.Altitude = 0
            mLabel.Position.AltitudeType = 2
            mLabelArray.Add(mLabel)
            SubDuongChudan(mLabel, mau, mau3, mau2, mau4, kcY)
        Catch
        End Try
    End Sub

    Private Sub MChuNDVK(mX As Double, mY As Double, mTxt1 As String, mTxt2 As String)
        Try
            Dim P4 As IPosition71 = sgworldMain.Creator.CreatePosition(mX, mY, 0, 2, 0, 0, 0, 0)
            Dim mLabel As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(P4, mTxt1, "", fLabelStyleMain, GroupBac2Main, mTxt2)
            mLabel.Position.Altitude = 0
            mLabel.Position.AltitudeType = 2
            mLabelArray.Add(mLabel)
        Catch
        End Try
    End Sub

    Private Sub SubDuongChudan(mText As ITerrainLabel71, Mau1 As IColor71, Mau2 As IColor71, Mau3 As IColor71, Mau4 As IColor71, dy As Double) ', M1 As ITerrainPolyline71, M2 As ITerrainPolyline71, M3 As ITerrainPolyline71, M4 As ITerrainPolyline71)
        Try
            Dim lists1 As New List(Of IPosition71)
            Dim lists2 As New List(Of IPosition71)
            Dim lists3 As New List(Of IPosition71)
            Dim lists4 As New List(Of IPosition71)
            Dim Pc As IPosition71 = sgworldMain.Creator.CreatePosition(mText.Position.X, mText.Position.Y, 0, 2, 0, 0, 0, 0)
            Dim pChudan1 As IPosition71 = Pc.Move(10000 * dy, 0, 0)
            Dim pChudan2 As IPosition71 = pChudan1.Move(Dorongduong * 3, 180, 0)
            Dim p11 As IPosition71 = pChudan1.Move(50000 * dy, 90, 0)
            Dim p12 As IPosition71 = pChudan1.Move(110000.0 * dy, 90.0, 0)
            Dim p13 As IPosition71 = pChudan1.Move(115000.0 * dy, 90.0, 0)
            Dim p14 As IPosition71 = pChudan1.Move(175000.0 * dy, 90.0, 0)

            Dim p21 As IPosition71 = pChudan2.Move(50000 * dy, 90, 0)
            Dim p22 As IPosition71 = pChudan2.Move(110000.0 * dy, 90.0, 0)
            Dim p23 As IPosition71 = pChudan2.Move(115000.0 * dy, 90.0, 0)
            Dim p24 As IPosition71 = pChudan2.Move(175000.0 * dy, 90.0, 0)
            lists1.Add(p11)
            lists1.Add(p12)
            lists2.Add(p13)
            lists2.Add(p14)
            lists3.Add(p21)
            lists3.Add(p22)
            lists4.Add(p23)
            lists4.Add(p24)
            FDuongList(lists1, 4294967295, "", 0, 0, Mau1, Dorongduong * 3, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lists2, 4294967295, "", 0, 0, Mau2, Dorongduong * 3, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lists3, 4294967295, "", 0, 0, Mau3, Dorongduong * 3, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lists4, 4294967295, "", 0, 0, Mau4, Dorongduong * 3, False, 2, 0, 2) ' 2, False, 2)
        Catch
        End Try
    End Sub


#End Region

#End Region

#Region "...Sửa DT, Group"

    Private Sub SuaVungDuong()
        Try
            If txtGroup.Text = "" Then ' Or txtGroup.Text.Count(Function(x) x = ",") <> 1 Or txtGroup.Text.Split(",")(0) = txtGroup.Text.Split(",")(1) Then
                MsgBox("Chưa chọn đối tượng để thực hiện", MsgBoxStyle.OkOnly, "Thông báo")
                Exit Sub
            Else
                If Lenhve = "catvung2" Or Lenhve = "catvung" Or Lenhve = "giaovung" Or Lenhve = "gopvung" Or Lenhve = "gopvung2" Or Lenhve = "vungtoduong" Then '
                    Suavung(sgworldMain, Lenhve)
                ElseIf Lenhve = "catduong" Or Lenhve = "noiduong" Or Lenhve = "duongtovung" Then
                    Suaduong(sgworldMain, Lenhve)
                End If
                SLenhve3DMs()
            End If
        Catch
        End Try
    End Sub

    Private Sub ToolSuachua_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles toolSuachua.ItemClicked
        Try
            mota = ""
            TiTructiep.Stop()
            If e.ClickedItem.Name <> "tlXoaGrtheoDT" Or e.ClickedItem.Name <> "nDTnhay" Or e.ClickedItem.Name <> "tlXoaGroup2" Then
                SetMouseArrow()
            End If
            If e.ClickedItem.Name <> "nDTnhay" Then
                HienthitoanboDT()
            End If
            NewTool("Taungam", e.ClickedItem.Name, e)
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

#End Region

#Region "  Tien ich"
    Private Sub ChieudaiDT()
        Try
            Dim k0 = sgworldMain.ProjectTree.GetNextItem("", ItemCode.SELECTED)
            Dim t123 As ITerrainPolyline71 = sgworldMain.ProjectTree.GetObject(k0)
            Dim ST1() As String = t123.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
            Dim lists1 As New List(Of IPosition71)
            For i As Integer = 0 To ST1.Count - 1
                Dim p As IPosition71 = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, 2, 0, 0, 0, 0)
                lists1.Add(p)
            Next
            Dim KC As Double = 0

            For i As Integer = 0 To lists1.Count - 2
                KC += sgworldMain.CoordServices.GetDistance(lists1(i).X, lists1(i).Y, lists1(i + 1).X, lists1(i + 1).Y)
            Next
            Dim Km As Double = KC / 1000
            MsgBox("Chiều dài đối tượng là " & KC.ToString.Split(".")(0).ToString & KC.ToString.Split(".")(1).Substring(0, 3) & " m, hoặc " & Km.ToString.Split(".")(0) & "," & Km.ToString.Split(".")(1).Substring(0, 3) & " km")
        Catch
        End Try
    End Sub

    Private Sub KC2diem()
        Try
            Dim chieucao As Double = sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
            Dim Km As Double = chieucao / 1000
            MsgBox("Khoảng cách giữa hai điểm là " & chieucao.ToString.Split(".")(0) & "." & chieucao.ToString.Split(".")(1).Substring(0, 3) & " mét, hoặc " & Km.ToString.Split(".")(0) & "." & Km.ToString.Split(".")(1).Substring(0, 3) & " kilomet")
        Catch
        End Try
    End Sub

    Private Sub TinhDientich()
        Try
            Dim k0 = sgworldMain.ProjectTree.GetNextItem("", ItemCode.SELECTED)
            Dim t123 As ITerrainPolygon71 = sgworldMain.ProjectTree.GetObject(k0)
            Dim mChuoi = t123.Geometry
            Dim TinhDT As Double = sgworldMain.Analysis.MeasureTerrainArea(mChuoi)
            Dim DT As Double = TinhDT / 100.0
            Dim DT2 As Double = DT / 10000.0
            Dim TinhChuvi As Double = sgworldMain.Analysis.MeasureTerrainPerimeter(mChuoi)
            MsgBox("Diện tích đối tượng là " & DT.ToString.Split(".")(0) & "." & DT.ToString.Split(".")(1).Substring(0, 3) & " mét vuông, hoặc " & DT2.ToString.Split(".")(0) & "." & DT2.ToString.Split(".")(1).Substring(0, 3) & " kilomet vuông," & vbCrLf & "Chu vi đối tượng là " & TinhChuvi.ToString.Split(".")(0) & "." & TinhChuvi.ToString.Split(".")(1).Substring(0, 3) & "mét, hoặc " & (TinhChuvi / 1000).ToString.Split(".")(0) & "." & (TinhChuvi / 1000).ToString.Split(".")(1).Substring(0, 3) & " kilomet")
        Catch
        End Try
    End Sub

    Private Sub MnuKc2D_Click(sender As Object, e As EventArgs) Handles mnuKc2D.Click
        Try
            Lenhve = "khoangcach2d"
            SetMouseArrow()
        Catch
        End Try
    End Sub

    Private Sub MnuChieudaiDuong_Click(sender As Object, e As EventArgs) Handles mnuChieudaiDuong.Click
        Try
            Lenhve = "Chieudaiduonghanhquan"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub MnuDientich_Click(sender As Object, e As EventArgs) Handles mnuDientich.Click
        Try
            Lenhve = "dientichDT"
            sgworldMain.Command.Execute(1070, 0)
        Catch
        End Try
    End Sub

    Private Sub MnuGocPv_Click(sender As Object, e As EventArgs) Handles mnuGocPv.Click
        Try
            Lenhve = "phuongvi"
            mota = "Góc phương vị"
            tenKH = "Góc phương vị"
            SetMouseArrow()
        Catch
        End Try
    End Sub

    Public Sub VideoOnTerrain()
        Try
            Dim mVideo As ITerrainVideo71 = sgworldMain.Creator.CreateVideoOnTerrain(OpenFileDialog1.FileName, mPointClick, GroupBac2Main, tenKH)
            mVideo.Terrain.DrawOrder = 0
            mVideo.MaximumProjectionDistance = 7000
            mVideo.Position.AltitudeType = 2
            mVideo.Position.Altitude = Tyle * mVideo.MaximumProjectionDistance
            mVideo.PlayVideoOnStartup = False
            If Bd3D = True Then
                mVideo.Position.Pitch = -90
                mVideo3D = mVideo
                SLenhve3DMs()
            Else
                mVideo.Position.Pitch = 0
            End If
            mVideo.PlayVideo()
        Catch
        End Try
    End Sub

    Private Sub BtnTimdiem_Click(sender As Object, e As EventArgs) Handles btnTimdiem.Click
        TimWGS84()
    End Sub

    Private Sub VePhuongvi()
        Try
            GroupBac2Main = Gr02(sgworldMain, Giaidoan, tenKH)
            Dim P1 As IPosition71 = sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
            Dim P2 As IPosition71 = sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai
            Dim Pc As IPosition71 = CenterPoint(P1, P2)
            Dim goc As Double = FGoc(P2, P1)
            Dim SDO As String, PHUT1 As String, Phut2 As String = String.Empty, GIAY1 As String, giay2 As String = String.Empty
            SDO = goc.ToString.Split(".")(0)
            PHUT1 = ((goc - Val(SDO)) * 60).ToString.Split(".")(0)
            If PHUT1.Length = 1 Then Phut2 = "0" & PHUT1
            If PHUT1.Length = 2 Then Phut2 = PHUT1
            GIAY1 = (((goc - Val(SDO)) * 60 - Val(PHUT1)) * 60).ToString.Split(".")(0).ToString
            If GIAY1.Length = 1 Then giay2 = "0" & GIAY1
            If GIAY1.Length = 2 Then giay2 = GIAY1
            Dim sodo As String = SDO & "d" & Phut2 & "'" & giay2 & "''"
            Dim Khoangcach As Double = FKc(P1, P2)
            FVungList(Muiten(P2, P1, FGoc(P1, P2), 0.5, 1.0), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
            fLabelStyleMain.PivotAlignment = ("bottom,center")
            fLabelStyleMain.LockMode = LabelLockMode.LM_AXIS_TEXTUP
            Dim t1 As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(Pc, sodo, "", fLabelStyleMain, GroupBac2Main, tenKH)
            t1.Position.Yaw = goc - 90.0
            fLabelStyleMain.PivotAlignment = ("top,center")
            Dim t2 As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(Pc, Khoangcach.ToString.Split(".")(0) & "." & Khoangcach.ToString.Split(".")(1).Substring(0, 3) & "m", "", fLabelStyleMain, GroupBac2Main, tenKH)
            t2.Position.Yaw = goc - 90.0
        Catch
        End Try
    End Sub

#End Region

#Region "...Mo hinh 3D"

    Private Sub CbLoaiMohinh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLoaiMohinh.SelectedIndexChanged
        Try
            If cbLoaiMohinh.SelectedIndex = 0 Then
                txtDocao.Enabled = False
                txtVantoc.Enabled = False
                txtKCDT.Enabled = False
            ElseIf cbLoaiMohinh.SelectedIndex > 0 Then
                txtDocao.Enabled = True
                txtVantoc.Enabled = True
                If cbLoaiMohinh.SelectedIndex > 2 Then
                    txtKCDT.Enabled = True
                Else
                    txtKCDT.Enabled = False
                End If
            End If
            If cbLoaiMohinh.SelectedIndex = 1 Or cbLoaiMohinh.SelectedIndex = 2 Then
                txtKCDT.Text = "1"
            Else
                txtKCDT.Text = ""
            End If
        Catch
        End Try
    End Sub

    Private Sub ChonlenhMH()
        Try
            Select Case cbLoaiMohinh.SelectedIndex
                Case 0
                    Lenhve = "mohinh"
                    SetMouseArrow()
                Case 1
                    Lenhve = "dtChuyendongMH"
                    mTempLine = True
                    SetMouseArrow()
                Case 2
                    Lenhve = "1DTchuyendontheoduong"
                Case 3
                    Lenhve = "2DTchuyendongngang"
                Case 4
                    Lenhve = "2DTchuyendondoc"
                Case 5
                    Lenhve = "3DTchuyendonTG"
                Case 6
                    Lenhve = "3DTchuyendonTG1"
                Case 7
                    Lenhve = "3DTchuyendonNgang"
                Case 8
                    Lenhve = "3DTchuyendondoc"
            End Select
            If cbLoaiMohinh.SelectedIndex > 1 Then
                Lenhsua = "chonDuongtaoChuoi"
                sgworldMain.Command.Execute(1070, 0)
            End If
        Catch
        End Try
    End Sub

    Public FileAmthanh As String = ""
    Private Sub LoaiDTCD()
        Try
            If txtDocao.Text = "0" Then
                loaiDTchuyendong = MOTION_GROUND_VEHICLE
            Else
                loaiDTchuyendong = MOTION_HOVER
                If loaiKH = "Mi-28.xpl2" Or loaiKH = "Tructhangvutrang.xpl2" Or loaiKH = "Tructhangvantai.xpl2" Then
                    loaiDTchuyendong = MOTION_HELICOPTER
                ElseIf loaiKH = "Su-30.xpl2" Or loaiKH = "F22.xpl2" Or loaiKH = "F16.xpl2" Or loaiKH = "Su-22.xpl2" Or loaiKH = "Su-22.xpl2" Or loaiKH = "B52.xpl2" Or loaiKH = "MaybaydothamHQ.xpl2" Or loaiKH = "UAV2.xpl2" Or loaiKH = "747.xpl2" Then
                    loaiDTchuyendong = MOTION_AIRPLANE
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub NhieuMohinh()
        Try
            If Not Lenhve = "dtChuyendongMH" And Not Lenhve = "mohinhnguoidung" Then
                If txtGroup.Text = "" Then
                    MsgBox("Chưa có đối tượng đường được chọn")
                    Exit Sub
                Else
                    NWay()
                End If
            End If
            If Lenhve = "2DTchuyendongngang" Then
                DTCD = FDTChuyendong(WaypointArr1, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr2, "2mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "dtChuyendongMH" Or Lenhve = "mohinhnguoidung" Then
                ReDim Preserve WaypointArr(WaypointArr.Length - 2)
                DTCD = FDTChuyendong(WaypointArr, "mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "1DTchuyendontheoduong" Then
                DTCD = FDTChuyendong(WaypointArr1a, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "2DTchuyendondoc" Then
                DTCD = FDTChuyendong(WaypointArr1a, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr3, "2mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "3DTchuyendonTG" Then
                DTCD = FDTChuyendong(WaypointArr1a, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr4, "2mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr5, "3mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "3DTchuyendonTG1" Then
                DTCD = FDTChuyendong(WaypointArr3, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr4, "2mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr5, "3mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "3DTchuyendonNgang" Then
                DTCD = FDTChuyendong(WaypointArr1, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr1a, "2mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr2, "3mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            ElseIf Lenhve = "3DTchuyendondoc" Then
                DTCD = FDTChuyendong(WaypointArr1a, "1mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr3, "2mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
                DTCD = FDTChuyendong(WaypointArr6, "3mh")
                mMotionModelArray.Add(DTCD)
                SendDTCD(DTCD)
            End If
            txtGroup.Text = ""
            fileModel = ""
            SLenhve3DMs()
        Catch
        End Try
    End Sub

    Public Function FDTChuyendong(WaypointArrP() As IRouteWaypoint71, soTT As String) As ITerrainDynamicObject71
        Try
            If Lenhve = "mohinhnguoidung" Then
                fileModel = OpenFileDialog1.FileName
            Else
                fileModel = PathData & "\XPL\" & loaiKH
            End If
            LoaiDTCD()
            Dim DT3 As ITerrainDynamicObject71 = sgworldMain.Creator.CreateDynamicObject(WaypointArrP, loaiDTchuyendong, DYNAMIC_3D_MODEL, fileModel, Tyle * 200.0, mAltitudeType, GroupBac2Main, tenKH & soTT)
            DT3.Position.Distance = 8000.0
            DT3.Acceleration = Val(txtVantoc.Text) * 5
            DT3.Tooltip.Text = TxtTenKH.Text & ", " & FileAmthanh & ":" & DT3.Waypoints.Count.ToString   '.G etWaypoint(2).X.ToString & ", " & DT3.Waypoints.GetWaypoint(2).Y.ToString & ", " & DT3.Waypoints.GetWaypoint(2).Altitude.ToString & ", " & DT3.Waypoints.GetWaypoint(2).Speed.ToString
            Dim ten As String = sgworldMain.ProjectTree.GetItemName(DT3.ID)
            If loaiDTchuyendong = MOTION_AIRPLANE Then DT3.CircularRoute = CircularRouteType.CRT_MOVE_TO_START
            If loaiDTchuyendong = MOTION_GROUND_VEHICLE Then DT3.CircularRoute = CircularRouteType.CRT_STOP_AT_THE_END
            If loaiKH = "Tructhangvutrang.xpl2" Or loaiKH = "Mi28.xpl2" Then
                Dim Pk As IPosition71 = sgworldMain.Creator.CreatePosition(WaypointArrP(0).X, WaypointArrP(0).Y, 0, 2, 0, 0, 0, 0)
                Dim MH As ITerrainModel71 = CrModel(Pk, PathData & "\XPL\CQ1.xpl2", 250 * Tyle, ten & "CQ")
                MH.Attachment.AttachTo(DT3.ID, 0, 0, 30 * Tyle, 0, 0, 0)
            ElseIf loaiKH = "TructhangVantai.xpl2" Then
                Dim Pk As IPosition71 = sgworldMain.Creator.CreatePosition(WaypointArrP(0).X, WaypointArrP(0).Y, 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0)
                Dim MH As ITerrainModel71 = CrModel(Pk, PathData & "\XPL\CQ1.xpl2", 130 * Tyle, ten & "CQ1")
                MH.Attachment.AttachTo(DT3.ID, 0, 540 * Tyle, 300 * Tyle, 0, 0, 0)
                Dim MH1 As ITerrainModel71 = CrModel(Pk, PathData & "\XPL\CQ1.xpl2", 140 * Tyle, ten & "CQ2")
                MH1.Attachment.AttachTo(DT3.ID, 0, -460 * Tyle, 200 * Tyle, 0, 0, 0)
            Else
                Dim Pk As IPosition71 = sgworldMain.Creator.CreatePosition(WaypointArrP(0).X, WaypointArrP(0).Y, 0, 2, 0, 0, 0, 0)
                Dim effnew As String = String.Empty
                If DT3.MotionStyle = DynamicMotionStyle.MOTION_GROUND_VEHICLE Then
                    effnew = MEffect("KhoiXE")
                ElseIf DT3.MotionStyle = DynamicMotionStyle.MOTION_AIRPLANE Then
                    effnew = MEffect("KhoiMB")
                End If
                Dim eff As ITerrainEffect71 = sgworldMain.Creator.CreateEffect(Pk, effnew, GroupBac2Main, tenKH & "Khoi")
                eff.Scale = 200 * Tyle
                eff.Attachment.AttachTo(DT3.ID, 0, 400 * Tyle, 0, 0, 0, 0)
            End If
            FDTChuyendong = DT3
        Catch
        End Try
    End Function

    Private Sub NWay()
        Try
            Dim k1 As ITerrainPolyline71
            If cbLoaiMohinh.SelectedIndex >= 2 Then
                If txtVantoc.Text = "" Then
                    MsgBox("Hãy chọn van toc đối tượng !")
                    Exit Sub
                ElseIf txtKCDT.Text = "" Then
                    MsgBox("Hãy chọn khoảng cách giữa các đối tượng !")
                    Exit Sub
                Else
                    Dim Kc As Double = Val(txtKCDT.Text) * 2.0
                    k1 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem(txtGroup.Text))
                    Dim ST1() As String = k1.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
                    Dim LiP As New List(Of IPosition71)
                    For i As Integer = 0 To ST1.Count - 1
                        Dim Pk As IPosition71 = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, 2, 0, 0, 0, 0)
                        LiP.Add(Pk)
                        If i = ST1.Count - 1 Then
                            Dim Pk1 As IPosition71 = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, 2, 0, 0, 0, 0)
                            LiP.Add(Pk1)
                        End If
                    Next

                    For i As Integer = 0 To LiP.Count - 2
                        Dim P1, P2, P3, P4, P5, P6 As IPosition71
                        Dim GocPV As Double
                        Dim dx As Double = LiP(i).X - LiP(i + 1).X
                        Dim dy As Double = LiP(i).Y - LiP(i + 1).Y
                        Dim goc = Math.Atan(Math.Abs(dy / dx)) '* 180 / Math.PI
                        If (dx > 0) And (dy >= 0) Then GocPV = goc
                        If (dx < 0) And (dy >= 0) Then GocPV = Math.PI - goc ' Anfa + Math.PI / 2.0# 'Goc thu tu 
                        If (dx < 0) And (dy <= 0) Then GocPV = goc + Math.PI 'Goc thu ba
                        If (dx > 0) And (dy <= 0) Then GocPV = Math.PI * 2.0 - goc '- Math.PI 'Goc thu tu ba *
                        GocPV *= 180 / Math.PI
                        P1 = LiP(i).Move(Kc * Tyle, 0.0 - GocPV, 0)
                        P2 = LiP(i).Move(Kc * Tyle, 180.0 - GocPV, 0)
                        P3 = LiP(i).Move(-2.0 * Kc * Tyle, 270 - GocPV, 0)
                        P4 = LiP(i).Move(Kc * Tyle, 45 - GocPV, 0)
                        P5 = LiP(i).Move(Kc * Tyle, 135 - GocPV, 0)
                        P6 = LiP(i).Move(2.0 * Kc * Tyle, 270 - GocPV, 0)
                        ReDim Preserve WaypointArr1a(0 To LiP.Count - 2)
                        WaypointArr1a(i) = sgworldMain.Creator.CreateRouteWaypoint(LiP(i).X, LiP(i).Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                        ReDim Preserve WaypointArr1(0 To LiP.Count - 2)
                        WaypointArr1(i) = sgworldMain.Creator.CreateRouteWaypoint(P1.X, P1.Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                        ReDim Preserve WaypointArr2(0 To LiP.Count - 2)
                        WaypointArr2(i) = sgworldMain.Creator.CreateRouteWaypoint(P2.X, P2.Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                        ReDim Preserve WaypointArr3(0 To LiP.Count - 2)
                        WaypointArr3(i) = sgworldMain.Creator.CreateRouteWaypoint(P3.X, P3.Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                        ReDim Preserve WaypointArr4(0 To LiP.Count - 2)
                        WaypointArr4(i) = sgworldMain.Creator.CreateRouteWaypoint(P4.X, P4.Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                        ReDim Preserve WaypointArr5(0 To LiP.Count - 2)
                        WaypointArr5(i) = sgworldMain.Creator.CreateRouteWaypoint(P5.X, P5.Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                        ReDim Preserve WaypointArr6(0 To LiP.Count - 2)
                        WaypointArr6(i) = sgworldMain.Creator.CreateRouteWaypoint(P6.X, P6.Y, Val(txtDocao.Text), 15.0 * Val(txtVantoc.Text), 0, 0, 0, tenKH)
                    Next
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub CreateModel()
        Try
            Dim Goc1 As Double = Phuongvi * 180 / Math.PI
            fileModel = PathData & "\XPL\" & loaiKH
            CrModel(mPointClick.Move(0.0 * Tyle, 90 - Goc1, 0), fileModel, Tyle * 200, tenKH)
            SLenhve3DMs()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub TxtVantoc_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVantoc.KeyPress
        Import_KeyPress(e, Chr(8))
    End Sub

    Private Sub TxtDocao_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocao.KeyPress
        Import_KeyPress(e, Chr(8))
    End Sub

    Private Sub TxtKCDT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKCDT.KeyPress
        Import_KeyPress(e, Chr(8))
    End Sub

    Private Sub ToolMH_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolMH.ItemClicked
        Try
            ChebTQ(TxtTenKH.Text, ChebTheoNhom)
            ChonlenhMH()
            If e.ClickedItem.Name = "tlXTT54" Or e.ClickedItem.Name = "tlXetang" Or e.ClickedItem.Name = "tlXeloinuoc" Or e.ClickedItem.Name = "tlM113" Or e.ClickedItem.Name = "tlXeQSbanhhoi" Or e.ClickedItem.Name = "tlXevantai" Or
                 e.ClickedItem.Name = "tlXequansu" Or e.ClickedItem.Name = "tlXethongtin" Or e.ClickedItem.Name = "tlCano" Or e.ClickedItem.Name = "tlTauDobo" Or e.ClickedItem.Name = "tlTauphongloi" Or e.ClickedItem.Name = "tlTauKhtruc" Or
                 e.ClickedItem.Name = "tlTaungam" Or e.ClickedItem.Name = "tlTauSbay" Or e.ClickedItem.Name = "tlTauPhao" Or e.ClickedItem.Name = "tlTauphao2" Or e.ClickedItem.Name = "tlTauTL1" Or e.ClickedItem.Name = "tlTauTL2" Or
                 e.ClickedItem.Name = "tlTauBenhvien" Or e.ClickedItem.Name = "tlTauVantai" Or e.ClickedItem.Name = "tlTauKiemngu" Or e.ClickedItem.Name = "tlNhagianDon" Or e.ClickedItem.Name = "tlNhagianDoi" Or e.ClickedItem.Name = "tlGiankhoan" Or
                 e.ClickedItem.Name = "tlS300" Or e.ClickedItem.Name = "tlTenluaDatdoiDat" Or e.ClickedItem.Name = "tlCoi82S" Or e.ClickedItem.Name = "tlPhao105" Or e.ClickedItem.Name = "tlPhaobanthang" Or e.ClickedItem.Name = "tlPhao175" Or e.ClickedItem.Name = "tlPhaoPK12Ly7" Or
                 e.ClickedItem.Name = "tlPhaoPK57" Or e.ClickedItem.Name = "tlPhaophongkhong" Or e.ClickedItem.Name = "tlTenluaSAM3" Or e.ClickedItem.Name = "tlRadar" Then
                txtDocao.Text = "0"
            End If

            If e.ClickedItem.Name = "tlXTT54" Or e.ClickedItem.Name = "tlXetang" Or e.ClickedItem.Name = "tlXeloinuoc" Or e.ClickedItem.Name = "tlM113" Or e.ClickedItem.Name = "tlXeQSbanhhoi" Or e.ClickedItem.Name = "tlXevantai" Then
                FileAmthanh = "1"
            ElseIf e.ClickedItem.Name = "tlSu22" Or e.ClickedItem.Name = "tlF16" Or e.ClickedItem.Name = "tlF22" Then
                FileAmthanh = "6"
            ElseIf e.ClickedItem.Name = "tlB52" Or e.ClickedItem.Name = "Tu160" Then
                FileAmthanh = "7"
            ElseIf e.ClickedItem.Name = "tlUAV2" Then
                FileAmthanh = "2"
            ElseIf e.ClickedItem.Name = "tlCano" Or e.ClickedItem.Name = "tlTauDobo" Or e.ClickedItem.Name = "tlTauphongloi" Or e.ClickedItem.Name = "tlTauKhtruc" Or e.ClickedItem.Name = "tlTaungam" Or e.ClickedItem.Name = "tlTauSbay" Or
                  e.ClickedItem.Name = "tlTauPhao" Or e.ClickedItem.Name = "tlTauphao2" Or e.ClickedItem.Name = "tlTauTL1" Or e.ClickedItem.Name = "tlTauTL2" Or e.ClickedItem.Name = "tlTauBenhvien" Or e.ClickedItem.Name = "tlTauVantai" Or
                  e.ClickedItem.Name = "tlTauKiemngu" Or e.ClickedItem.Name = "tlTauKiemngu2" Then
                FileAmthanh = "11"
            End If

            If e.ClickedItem.Name = "tlMi28" Or e.ClickedItem.Name = "tlTructhangvutrang" Or e.ClickedItem.Name = "tlTructhangvantai" Then
                FileAmthanh = "3"
                If cbLoaiMohinh.SelectedIndex = 0 Then
                    loaiKH = e.ClickedItem.Name.Replace("tl", "") & "1" & ".xpl2"
                Else
                    loaiKH = e.ClickedItem.Name.Replace("tl", "") & ".xpl2"
                End If
            Else
                loaiKH = e.ClickedItem.Name.Replace("tl", "") & ".xpl2"
            End If
            mota = e.ClickedItem.ToolTipText
            If e.ClickedItem.Name = "tlChenMohinh" Then
                OpenFileDialog1.Title = "Chọn mô hình"
                OpenFileDialog1.Filter = "Tập tin XPL2 (*xpl2) | *.xpl2|Tập tin dae (*.dae)|*.dae|Tập tin 3Ds (*.3Ds)|*.3Ds"
                OpenFileDialog1.ShowDialog()
                Lenhve = "mohinhnguoidung"
                mota = "Mô hình người dùng"
                mTempLine = True
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub


#End Region

#End Region

#End Region
#Region "   Chon DT and Goup"

    Private Sub MPathTQ() 'Chuan khong chinh
        Try
            Dim mPath As String = String.Empty
            Dim k0 = sgworldMain.ProjectTree.GetNextItem(String.Empty, ItemCode.SELECTED)
            If String.IsNullOrEmpty(k0) = False Then
                Dim grB1 As String
                Try
                    grB1 = sgworldMain.ProjectTree.GetItemName(sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.PARENT))
                Catch ex As Exception
                    grB1 = sgworldMain.ProjectTree.GetItemName(sgworldMain.ProjectTree.GetNextItem(String.Empty, ItemCode.SELECTED))
                    mPath = grB1
                    GoTo KT
                End Try
                Dim layer As Integer = 1
                Dim grB2 As String = sgworldMain.ProjectTree.GetItemName(k0)
                While grB1 <> ""
                    k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.PARENT)
                    If k0 = "" Then
                        Exit While
                    End If
                    grB1 = sgworldMain.ProjectTree.GetItemName(k0)
                    grB2 = grB1 & "\" & grB2  '& ",   " & kName
                    layer += 1
                End While
                mPath = grB2
            End If
KT:
            If Lenhve = "catvung2" Or Lenhve = "catvung" Or Lenhve = "giaovung" Or Lenhve = "gopvung" Or Lenhve = "gopvung2" Or Lenhve = "vungtoduong" Or Lenhve = "catduong" Or Lenhve = "noiduong" Or Lenhve = "DTdichuyen" Or
        Lenhve = "duongtovung" Or Lenhve = "XoaGrtheoDT" Or Lenhve = "chonDTnhapnhay" Or Lenhve = "chonDTan" Or Lenhve = "chonMTchuyendong" Or Lenhve = "chonDTchuyendong" Or Lenhve = "NNtructiep" Or Lenhve = "TatDt" Then
                Dim sTT As Integer = mPath.Substring(mPath.LastIndexOf("\")).Split("\")(1).Length + 1
                mPath = mPath.Substring(0, mPath.Length - sTT)
            End If
            If Not pathTQ.Contains("\") Then
                pathTQ = ""
            End If
            If pathTQ = "" Then
                pathTQ = mPath
            Else
                pathTQ = pathTQ & "," & mPath
            End If
            pathTQ = XoaLap(pathTQ)
        Catch
        End Try
    End Sub

    Private pathTQ As String = String.Empty
    Private Sub PathtoTxt()
        Try
            MPathTQ()
            If Lenhve = "chonDTnhapnhay" Then
                txtDTNhapnhay.Text = pathTQ
            ElseIf Lenhve = "chonDTan" Then
                txtDTAn.Text = pathTQ
            ElseIf Lenhve = "chonMTchuyendong" Then
                txtMTCD.Text = pathTQ
            ElseIf Lenhve = "DTdichuyen" Then
                If txtGroup.Text = "" Then
                    txtGroup.Text = pathTQ
                Else
                    txtGroup.Text = txtGroup.Text & "," & pathTQ
                End If
            ElseIf Lenhve = "NNtructiep" Or Lenhve = "TatDt" Then
                If txtGroup.Text = "" Then
                    txtGroup.Text = pathTQ
                Else
                    txtGroup.Text = txtGroup.Text & "," & pathTQ
                End If
            ElseIf Lenhve = "chonDTchuyendong" Then
                If cbHuDTchuyendong.SelectedIndex = 3 Then
                    txtDTChuyendong1.Text = pathTQ & "/" & cbHuongDBDK.SelectedIndex.ToString
                Else
                    txtDTChuyendong1.Text = pathTQ
                End If
                'txtDTChuyendong1.Text = pathTQ
            ElseIf Lenhve = "radaquay" Then
                txtDTQuay.Text = pathTQ
            ElseIf Lenhve = "phimdiahinh" Then
                txtPhim.Text = pathTQ
            ElseIf Lenhve = "vunghoaluc" Or Lenhve = "XoaGroup2" Or Lenhve = "XoaGrtheoDT" Or Lenhve = "catvung" Or Lenhve = "chuyenDTNet" Or Lenhve = "thuoctinh" Or Lenhsua = "chonDuongtaoChuoi" Or
               Lenhve = "vungtoduong" Or Lenhve = "duongtovung" Or Lenhve = "gopvung" Or Lenhve = "giaovung" Or Lenhve = "catduong" Or Lenhve = "noiduong" Or Lenhve = "catvung2" Or Lenhve = "gopvung2" Or
               Lenhve = "chuyenGroupNet" Or Lenhve = "chuyenGroup" Or Lenhve = "thuoctinh" Or Lenhve = "moveGroup" Or Lenhve = "copyGroup" Or Lenhve = "rotateGroup" Then
                txtGroup.Text = pathTQ
                If Lenhve = "moveGroup" Or Lenhve = "copyGroup" Or Lenhve = "rotateGroup" Then
                    txtGroup.Text = txtGroup.Text.Split(",")(0)
                End If
            End If
            pathTQ = ""
            sgworldMain.ProjectTree.SelectItem("", 0, 0)
        Catch
        End Try
    End Sub

    Public Function XoaLap(inputString As String) As String
        Try
            Dim Chuoi As New List(Of String), Chuoi2 As New List(Of String)
            For i As Integer = 0 To inputString.Split(",").Count - 1
                If Not Chuoi.Contains(inputString.Split(",")(i)) Then
                    Chuoi.Add(inputString.Split(",")(i))
                End If
            Next
            Dim chuoira As String = ""
            For i As Integer = 0 To Chuoi.Count - 1
                If chuoira = "" Then
                    chuoira = Chuoi(i)
                Else
                    chuoira = chuoira & "," & Chuoi(i)
                End If
            Next
            XoaLap = chuoira
        Catch
        End Try
    End Function

    Private Sub SubXoaGroup() 'ChuoiDT As String)
        Try
            XoaGr(sgworldMain, txtGroup.Text)
            SLenhve3DMs()
        Catch
        End Try
    End Sub

#Region "     Scan DT"
    Public Sub ScanGroup()
        Try
            File.Delete(folderPath1 & "\Doituong.xml")
            Dim grB0 = sgworldMain.ProjectTree.GetNextItem(String.Empty, ItemCode.ROOT)
            If sgworldMain.ProjectTree.GetItemName(grB0) = sgworldMain.ProjectTree.HiddenGroupName Then
                grB0 = sgworldMain.ProjectTree.GetNextItem(grB0, ItemCode.[NEXT])
            End If
            ScanB1(grB0)
        Catch ex As Exception
        End Try
    End Sub
    Dim TenGD3 As String = String.Empty
    Private Function ScanB1(B1 As String) As String
        Try
            Dim i As Integer = 0
            While String.IsNullOrEmpty(B1) = False
                If sgworldMain.ProjectTree.IsGroup(B1) Then
                    ScanB2(B1)
                End If
                i += 1
                B1 = sgworldMain.ProjectTree.GetNextItem(B1, ItemCode.[NEXT])
            End While
        Catch
        End Try
    End Function

    Private Sub ScanB2(grB1 As String)
        Try
            Dim Ten As String
            Dim TenB1 = sgworldMain.ProjectTree.GetItemName(grB1)
            Dim B2 = sgworldMain.ProjectTree.GetNextItem(grB1, ItemCode.CHILD)
            While Not (B2 = Nothing)
                Dim TenGD As String = String.Empty
                If sgworldMain.ProjectTree.IsGroup(B2) Then
                    Dim tenB2 As String = sgworldMain.ProjectTree.GetItemName(B2)
                    Ten = TenB1 & "\" & tenB2
                    TenGD = TenGD & "," & Ten
                    ScanB3(B2, TenGD)
                End If
                B2 = sgworldMain.ProjectTree.GetNextItem(B2, ItemCode.NEXT)
            End While
        Catch
        End Try
    End Sub
    Private Sub ScanB3(current As String, TenGD2 As String)
        Try
            Dim B3 = sgworldMain.ProjectTree.GetNextItem(current, ItemCode.CHILD)
            While Not (B3 = Nothing)
                If sgworldMain.ProjectTree.IsGroup(B3) Then
                    Dim tenB3 As String = sgworldMain.ProjectTree.GetItemName(B3)
                    Dim count As Integer = TenGD2.Count(Function(x) x = "\")
                    If tenB3 <> "" Then
                        If count = 1 Then
                            Dim TenGD3 As String = (TenGD2 & "\" & tenB3).Replace(",", "")
                            DB_DoiTuong(TenGD3)
                        End If
                    End If
                End If
                B3 = sgworldMain.ProjectTree.GetNextItem(B3, ItemCode.NEXT)
            End While
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DB_DoiTuong(data As String)
        Try
            Dim filePath As String = Path.Combine(folderPath1, "DoiTuong.xml")
            Dim xmlDoc1 As New XmlDocument()
            If Not File.Exists(filePath) Then
                Dim rootElement1 As XmlElement = xmlDoc1.CreateElement("DuLieu")
                xmlDoc1.AppendChild(rootElement1) ' Tạo các phần tử con cho mỗi dòng trong tệp txt
            Else
                xmlDoc1.Load(filePath)
            End If
            Dim index As Integer = data.IndexOf("_")
            If index <> -1 Then
                Dim numberStr As String = data.Substring(index + 1)
                Dim number As Integer
                If Integer.TryParse(numberStr, number) Then
                    Dim bitElement As XmlElement = xmlDoc1.CreateElement("Ten")
                    bitElement.SetAttribute("ID", number.ToString())
                    Dim nameElement As XmlElement = xmlDoc1.CreateElement("Data")
                    nameElement.InnerText = data
                    bitElement.AppendChild(nameElement)
                    Dim rootElement1 As XmlElement = xmlDoc1.DocumentElement
                    rootElement1.AppendChild(bitElement)
                    xmlDoc1.Save(filePath)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

#End Region
#End Region
#Region "...NetWork"
    Private networkConnection As NetworkCommunication = Nothing
    Public isNetworkConnected As Boolean = False
    Private Delegate Sub WriteValue(value As NetworkMessage)
    Private veduong As String = String.Empty

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If btnConnect.Text = "Kết nối" Then
                liDTVKTC.Items.Clear()
                Me.networkConnection.GetCurrentIP()
                Me.networkConnection.StartServer()
                Me.isNetworkConnected = True
                Me.networkConnection.RequestConnect(Me.txtServerIP.Text)
                If IsConnected() = True Then
                    txtServerIP.Enabled = False
                    btnStartServer.Enabled = False
                    MessageBox.Show("Kết nối thành công tới máy chủ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    btnConnect.Text = "Ngắt kết nối"
                    LbMaychinh.Text = LbMaychinh.Text
                    panelLAN.Visible = False
                End If
            Else
                Me.networkConnection.StopServer()
            End If
        Catch ex As Exception
            MsgBox("Địa chỉ IP của máy chính không đúng!")
            Exit Sub
        End Try
    End Sub

    Private Sub TxtServerIP_TextChanged(sender As Object, e As EventArgs) Handles txtServerIP.TextChanged
        Try
            If txtServerIP.Text = Me.networkConnection.GetCurrentIP() Then
                btnStartServer.Enabled = True
                Me.btnConnect.Enabled = False
            Else
                btnConnect.Enabled = True
                Me.btnStartServer.Enabled = False
            End If
        Catch
        End Try
    End Sub

    Private Sub BtnStartServer_Click(sender As Object, e As EventArgs) Handles btnStartServer.Click
        Try
            Me.networkConnection.StartServer()
            Me.networkConnection.IsServer = True
            Me.networkConnection.ServerIP = Me.networkConnection.GetCurrentIP()
            Me.isNetworkConnected = True
            txtServerIP.Enabled = False
            btnConnect.Enabled = False
            Label39.Enabled = False
            liDTVKTC.Items.Clear()
        Catch
        End Try
    End Sub

    Private Sub NetworkConnected(sender As Object, e As EventArgs)
        Try
            Dim mess As NetworkMessage = sender
            Dim alert As String = mess.ClientIP
            Dim values(1) As Object
            mess.Command = alert.ToString
            If IsConnected() = True Then
                btnConnect.Enabled = False
                'LbMaychinh.Text = "Máy chính"
                'liDTVKTC.Items.Add(System.Environment.MachineName & "  <=>  " & mess.ClientIP)
                btnStartServer.BackColor = Color.LawnGreen
            Else
                btnConnect.Enabled = True
                'LbMaychinh.Text = LbMaychinh.Text
                panelLAN.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace)
            'MsgBox("Chưa có Máy chính hoặc IP chưa đúng?", MsgBoxStyle.Critical, "Chú ý...")
            Exit Sub
        End Try
    End Sub

    Public Function IsConnected() As Boolean
        Return Me.isNetworkConnected
    End Function

    Public Sub SendMessage(ByVal mess As NetworkMessage)
        Try
            If (String.IsNullOrEmpty(mess.ClientIP)) Then
                mess.ClientIP = Me.networkConnection.GetCurrentIP()
            End If
            Me.networkConnection.SendMessage(mess)
        Catch
        End Try
    End Sub

    Private Sub UpdateValue(value As NetworkMessage)
        Try
            If Me.isNetworkConnected = True Then
                If value.Command = "" Then
                    Exit Sub
                Else
                    If value.Command = "veco" Or value.Command = "Taungam" Or value.Command = "transLABEL" Or value.Command = "TaungamPB" Or value.Command = "venhieuSCH" Then
                        SCreateLabelnet(value.Parameters)
                    ElseIf value.Command = "ModelMotionNet" Or value.Command = "transDYNAMIC" Then
                        SCreateMotionModelNet(value.Parameters)
                    ElseIf value.Command = "ModelNet" Or value.Command = "transMODEL" Then
                        SCreateModelNet(value.Parameters)
                    ElseIf value.Command = "LineNet" Then
                        SCreateLineNet(value.Parameters)
                        If mMicrostation = True Then
                            CreateLineNetMs(value.Parameters)
                        End If
                    ElseIf value.Command = "vungNet" Or value.Command = "vunghoaluc" Then
                        SCreateVungNet(value.Parameters)
                    ElseIf value.Command = "VeRanhgioi" Then
                        RanhgioiNet(value.Parameters)
                    ElseIf value.Command = "trinhchieu" Then
                        TrCNet(value.Parameters)
                    ElseIf value.Command = "trcDTuong" Then
                        '  CreateTrCDT(value.Parameters)
                        'ElseIf value.Command = "Qsat" Then
                        '    CreateQsat(value.Parameters)
                    ElseIf value.Command = "vungHL" Then
                        CreateVungHL(value.Parameters)
                        'ElseIf value.Command = "hangraoKG" Then
                        '    CreateHRKG(value.Parameters)
                    End If
                    Me.Refresh()
                    value.Command = ""
                    Lenhve = ""
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub NetworkIncomedMessage(sender As Object, e As EventArgs)
        Try
            Dim mess As NetworkMessage = sender
            Dim values(1) As Object
            values(0) = mess.Command
            If (Me.txtGhichuMang Is Nothing) Then
                Me.txtGhichuMang = New TextBox()
            End If
            Me.txtGhichuMang.Invoke(New WriteValue(AddressOf UpdateValue), mess)
        Catch
        End Try
    End Sub

    Public Function SerializeMultiPoints(points As Double()) As String
        Try
            Dim ser As New JavaScriptSerializer()
            Dim sb As New StringBuilder()
            ser.Serialize(points, sb)
            Return sb.ToString()
        Catch
        End Try
    End Function

    Public Function ListPoints(points As List(Of Point3D)) As String
        Try
            Dim ser As New JavaScriptSerializer()
            Dim sb As New StringBuilder()
            ser.Serialize(points, sb)
            Return sb.ToString()
        Catch
        End Try
    End Function

    Public Function DeserializeMultiPointsDouble(data As String) As Double()
        Try
            Dim points() As Double '= New Double(10000) {}
            Dim ser As New JavaScriptSerializer()
            points = ser.Deserialize(Of Double())(data)
            Return points
        Catch
        End Try
    End Function

    Private Sub tb_truyenvitri_TextChanged(sender As Object, e As EventArgs) Handles tb_truyenvitri.TextChanged
        Try
            If tb_truyenvitri.InvokeRequired Then
                tb_truyenvitri.Invoke(Sub() FrmSBVLM.Instance.tb_truyenvitri.Text = tb_truyenvitri.Text)
            Else
                FrmSBVLM.Instance.tb_truyenvitri.Text = tb_truyenvitri.Text
            End If
        Catch
        End Try

    End Sub

    Private Sub cb_maychieu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_maychieu.SelectedIndexChanged
        Try
            Select Case cb_maychieu.SelectedIndex
                Case 0
                    FrmSBVLM.Instance.ShowTC()
                    Bd3D = True
                Case 1
                    FrmSBVLM.Instance.ThoatTC()
            End Select
        Catch
        End Try
    End Sub

    Private Sub pnLogo_DoubleClick(sender As Object, e As EventArgs) Handles pnLogo.DoubleClick
        Try
            If menuMain.Visible = True Then
                menuMain.Visible = False
                MenuClose.Visible = False
                ChebBangDT.Checked = False
            Else
                menuMain.Visible = True
                MenuClose.Visible = True
                ChebBangDT.Checked = True
            End If
        Catch
        End Try
    End Sub

    Public Function DeserializeMultiPointsList(data As String) As List(Of Point3D)
        Try
            Dim points As List(Of Point3D) '= New List(Of Point3D)()
            Dim ser As New JavaScriptSerializer()
            points = ser.Deserialize(Of List(Of Point3D))(data)
            Return points
        Catch
        End Try
    End Function

    Private Sub PrChung(mess As NetworkMessage, mCommand As String)
        Try
            mess.Command = mCommand
            If Lenhve = "dtChuyendongMH" Or Lenhve = "2DTchuyendongngang" Or Lenhve = "2DTchuyendondoc" Or Lenhve = "3DTchuyendonTG" Or Lenhve = "3DTchuyendonTG1" Or Lenhve = "3DTchuyendonNgang" Or Lenhve = "3DTchuyendondoc" Or Lenhve = "mohinhnguoidung" Then
                mota = TxtTenKH.Text & ", " & FileAmthanh
            Else
                mota = mota
            End If
            mess.Parameters = New List(Of String) From {System.Environment.MachineName, Bd3D, Lenhve, Giaidoan, cbTa_DP.SelectedIndex.ToString,
            cbChieuKH.SelectedIndex.ToString, Tyle, mauKT.ToString, loaiKH, tenKH, mota}
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub GetParameter(sgworldK As SGWorld71, ByVal para As List(Of String))
        Try
            tenMayNet = para(0)
            Bd3D = para(1)
            Lenhve = para(2)
            GiaidoanNet = para(3)
            mKHTa_DP = para(4)
            mChieuKH = para(5)
            Tyle = para(6)
            '   mChechMauxam = para(7)
            loaiKH = para(8)
            tenKH = para(9)
            mota = para(10)
            GroupBac2Main = Gr03(sgworldK, tenMayNet, GiaidoanNet, tenKH)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

#Region "   Label"
    Private Sub AddLabel(mess As NetworkMessage, mText As ITerrainLabel71)
        Try
            mess.Parameters.Add(mText.Text) '11
            mess.Parameters.Add(mText.ImageFileName) '12
            mess.Parameters.Add(mText.Style.TextColor.abgrColor) '13
            mess.Parameters.Add(mText.Style.Scale) '14
            mess.Parameters.Add(mText.Style.PivotAlignment) '15
            mess.Parameters.Add(mText.Style.FontSize) '16
            mess.Parameters.Add(mText.Style.TextAlignment) '17
            mess.Parameters.Add(mText.Style.LockMode) '18
            mess.Parameters.Add(mText.Position.X) '19
            mess.Parameters.Add(mText.Position.Y) '20
            mess.Parameters.Add(mText.Position.Altitude) '21
            mess.Parameters.Add(mText.Tooltip.Text) '21
        Catch
        End Try
    End Sub

    Public Sub SendLabel(mLabel As ITerrainLabel71)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage()
                PrChung(mess, Lenhve)
                AddLabel(mess, mLabel)
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub SCreateLabelnet(ByVal paraLebel As List(Of String))
        Try
            GetParameter(sgworldMain, paraLebel)
            fLabelStyleMain.TextColor.abgrColor = paraLebel(13)
            fLabelStyleMain.Scale = paraLebel(14)
            fLabelStyleMain.PivotAlignment = paraLebel(15)
            fLabelStyleMain.FontSize = paraLebel(16)
            fLabelStyleMain.TextAlignment = paraLebel(17)
            fLabelStyleMain.LockMode = paraLebel(18)
            Dim cThumuc As String = "", x2 As String = "", mtenGiaidoan As String
#Disable Warning IDE0059 ' Unnecessary assignment of a value
            Dim dsKH As New List(Of String)
#Enable Warning IDE0059 ' Unnecessary assignment of a value
            dsKH = MLoaiKH(paraLebel(12))
            mP = dsKH(0)
            ChieuKH = dsKH(1)
            loaiKH = dsKH(2)
            Ta_Doiphuong = dsKH(3)
            mtenGiaidoan = dsKH(4)
            If Lenhve = "veco" Or Lenhve = "venhieuSCH" Then
                If Bd3D = False Then
                    cThumuc = "\2X\"
                    x2 = ""
                Else
                    cThumuc = "\2XD2\"
                    x2 = "2"
                End If
            ElseIf Lenhve = "Taungam" Or Lenhve = "TaungamPB" Then
                cThumuc = "\2X\"
                x2 = ""
                'ElseIf Lenhve = "venhieuSCH" Then
                '    If Bd3D = False Then
                '        cThumuc = "\2X\"
                '        x2 = ""
                '    Else
                '        cThumuc = "\2XD2\"
                '        x2 = "2"
                '    End If
            End If
            If Lenhve = "Doituongchu" Then
                fileImage = ""
            Else
                fileImage = PathLabel(cThumuc, loaiKH, ChieuKH, mP, x2, Ta_Doiphuong, mtenGiaidoan)
            End If
            Dim Pk As IPosition71 = sgworldMain.Creator.CreatePosition(System.Convert.ToDouble(paraLebel(19)), System.Convert.ToDouble(paraLebel(20)), 0, 2, 0, 0, 0, 0)
            Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(Pk, paraLebel(11), fileImage, fLabelStyleMain, GroupBac2Main, tenKH)
            If Lenhve = "venhieuSCH" Then
                mText.Tooltip.Text = paraLebel(22)
            Else
                mText.Tooltip.Text = mota
            End If


            mText.Position.Altitude = System.Convert.ToDouble(paraLebel(21))
            mText.Position.AltitudeType = 2
            mNetwork = True
            mLabelArray.Add(mText)
            SLenhve3DMs()
            ZoomLAND(sgworldMain, mText)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "  Vung"
    Public Sub SendVung(cRegion As ITerrainPolygon71)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage
                PrChung(mess, "vungNet")
                AddVung(mess, cRegion)
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub AddVung(mess As NetworkMessage, cRegion As ITerrainPolygon71)
        Try
            Dim lists1 As New List(Of IPosition71)
            Dim p(10000) As IPosition71
            Dim ST1() As String = cRegion.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")
            For i As Integer = 1 To ST1.Count - 1
                p(i) = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 150000, 2, 0, 0, 0, 0)
                lists1.Add(p(i))
            Next
            Dim cArray1(lists1.Count * 3 - 1) As Double
            For i As Integer = 0 To lists1.Count - 1
                cArray1(i * 3) = lists1(i).X
                cArray1(i * 3 + 1) = lists1(i).Y
                cArray1(i * 3 + 2) = 0
            Next
            mess.Parameters.Add(cRegion.LineStyle.Color.ToABGRColor) '11
            mess.Parameters.Add(cRegion.LineStyle.Color.GetAlpha) '12
            mess.Parameters.Add(cRegion.LineStyle.Pattern) '13
            mess.Parameters.Add(cRegion.LineStyle.Width) '14
            mess.Parameters.Add(cRegion.FillStyle.Color.ToABGRColor) '15
            mess.Parameters.Add(cRegion.FillStyle.Color.GetAlpha) '16
            mess.Parameters.Add(cRegion.Terrain.DrawOrder) '17 
            mess.Parameters.Add(SerializeMultiPoints(cArray1)) '18 
            mess.Parameters.Add(cRegion.FillStyle.Texture.FileName) '19
            mess.Parameters.Add(cRegion.FillStyle.Texture.ScaleX) '20
            mess.Parameters.Add(cRegion.FillStyle.Texture.ScaleY) '21
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub SCreateVungNet(ByVal paraVung As List(Of String))
        Try
            GetParameter(sgworldMain, paraVung)
            Dim cArray1() As Double = DeserializeMultiPointsDouble(paraVung(18))
            Dim cRing As ILinearRing = sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cArray1)
            Dim cPolygonGeometry As IGeometry = sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing, Nothing)
            mau.FromABGRColor(paraVung(11))
            mau2.FromABGRColor(paraVung(15))
            Dim cPolygon As ITerrainPolygon71 = sgworldMain.Creator.CreatePolygon(cPolygonGeometry, mau, mau2, 2, GroupBac2Main, tenKH)
            cPolygon.LineStyle.Color.SetAlpha(paraVung(12))
            cPolygon.LineStyle.Pattern = paraVung(13)
            cPolygon.LineStyle.Width = Val(paraVung(14))
            cPolygon.FillStyle.Color.SetAlpha(paraVung(16))
            cPolygon.Terrain.DrawOrder = Val(paraVung(17))
            cPolygon.FillStyle.Texture.FileName = paraVung(19)
            cPolygon.FillStyle.Texture.ScaleX = paraVung(20)
            cPolygon.FillStyle.Texture.ScaleY = paraVung(21)
            cPolygon.Tooltip.Text = mota
            mNetwork = True
            mRegionArray.Add(cPolygon)
            SLenhve3DMs()
            ZoomLAND(sgworldMain, cPolygon)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
#End Region

#Region "   Duong"
    Public Sub SendLine(cLine As ITerrainPolyline71)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage
                PrChung(mess, "LineNet")
                AddLine(mess, cLine)
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub AddLine(mess As NetworkMessage, cLine As ITerrainPolyline71)
        Try
            Dim lists1 As New List(Of IPosition71)
            Dim p(10000) As IPosition71
            Dim MaDT As String
            Dim ST1() As String = cLine.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
            If Lenhve = "hangraobungnhung" Then
                MaDT = "HRKG"
            Else
                MaDT = ""
            End If
            For i As Integer = 0 To ST1.Count - 1
                If MaDT = "HRKG" Then
                    p(i) = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 150000, 2, 0, 0, 0, 0)
                Else
                    p(i) = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 150000, 2, 0, 0, 0, 0)
                End If
                lists1.Add(p(i))
            Next
            Dim cArray1(lists1.Count * 3 - 1) As Double
            For i As Integer = 0 To lists1.Count - 1
                cArray1(i * 3) = lists1(i).X
                cArray1(i * 3 + 1) = lists1(i).Y
                cArray1(i * 3 + 2) = lists1(i).Altitude
            Next
            mess.Parameters.Add(cLine.LineStyle.Color.ToABGRColor) '11
            mess.Parameters.Add(cLine.LineStyle.Color.GetAlpha) '12
            mess.Parameters.Add(cLine.LineStyle.Pattern) '13
            mess.Parameters.Add(cLine.LineStyle.Width) '14
            mess.Parameters.Add(cLine.Terrain.DrawOrder) '15
            mess.Parameters.Add(SerializeMultiPoints(cArray1)) '16
            mess.Parameters.Add(cLine.Spline) '17
            mess.Parameters.Add(MaDT) '18
        Catch
        End Try
    End Sub

    Private Sub SCreateLineNet(ByVal paraLine As List(Of String))
        Try
            GetParameter(sgworldMain, paraLine)
            mau.FromABGRColor(paraLine(11))
            Dim cArray1() As Double = DeserializeMultiPointsDouble(paraLine(16))
            Dim cRing As ILineString = sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cArray1)
            Dim cLine As ITerrainPolyline71 '= sgworldMain.Creator.CreatePolyline(cRing, mau, 2, GroupBac2Main, tenKH)
            If paraLine(18) = "HRKG" Then
                cLine = sgworldMain.Creator.CreatePolyline(cRing, mau, 4, GroupBac2Main, tenKH)
            Else
                cLine = sgworldMain.Creator.CreatePolyline(cRing, mau, 2, GroupBac2Main, tenKH)
            End If
            cLine.LineStyle.Color.SetAlpha(paraLine(12))
            cLine.LineStyle.Pattern = System.Convert.ToUInt32(paraLine(13))
            cLine.LineStyle.Width = paraLine(14)
            cLine.Terrain.DrawOrder = paraLine(15)
            cLine.Spline = paraLine(17).ToString
            cLine.Tooltip.Text = mota
            mNetwork = True
            If paraLine(18) = "HRKG" Then
                mLineArrayHR.Add(cLine)
            Else
                mLineArray.Add(cLine)
            End If
            SLenhve3DMs()
            ZoomLAND(sgworldMain, cLine)
            If Bd3D = True Then
                cLine.Position.AltitudeType = 2
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Public Sub SendLineMs(cLineMs As ITerrainPolyline71)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage
                PrChung(mess, "LineNet")
                AddLineMs(mess, cLineMs)
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub AddLineMs(mess As NetworkMessage, cLine As ITerrainPolyline71)
        Try
            Dim lists1 As New List(Of IPosition71)
            Dim p(10000) As IPosition71
            Dim ST1() As String = cLine.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
            For i As Integer = 0 To ST1.Count - 1
                p(i) = sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 150000, 2, 0, 0, 0, 0)
                lists1.Add(p(i))
            Next
            Dim cArray1(lists1.Count * 3 - 1) As Double
            For i As Integer = 0 To lists1.Count - 1
                cArray1(i * 3) = lists1(i).X
                cArray1(i * 3 + 1) = lists1(i).Y
                cArray1(i * 3 + 2) = lists1(i).Altitude
            Next
            mess.Parameters.Add(cLine.LineStyle.Color.ToABGRColor) '11
            mess.Parameters.Add(SerializeMultiPoints(cArray1)) '12
        Catch
        End Try
    End Sub

    Private Sub CreateLineNetMs(ByVal paraLineMs As List(Of String))
        Try
            GetParameter(sgworldMain, paraLineMs)
            mau.FromABGRColor(paraLineMs(11))
            Dim cArray1() As Double = DeserializeMultiPointsDouble(paraLineMs(12))
            Dim cRing As ILineString = sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cArray1)
            Dim cLine As ITerrainPolyline71 = sgworldMain.Creator.CreatePolyline(cRing, mau, 2, Gr01(sgworldMain, "Temp"), tenKH)
            cLine.Spline = True
            mLineArray.Add(cLine)
            ' cLine.FillStyle.Color.SetAlpha(0.2)
        Catch
        End Try
    End Sub
#End Region

#Region "   Model"

    Public Sub SendModel(cModel As ITerrainModel71)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage
                PrChung(mess, "ModelNet")
                AddModel(mess, cModel)
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub AddModel(mess As NetworkMessage, cModel As ITerrainModel71)
        Try
            mess.Parameters.Add(cModel.Position.X) '11
            mess.Parameters.Add(cModel.Position.Y) '12
            mess.Parameters.Add(cModel.Position.Altitude) '13
            mess.Parameters.Add(cModel.ModelFileName) '14
            mess.Parameters.Add(cModel.ScaleFactor) '15
            mess.Parameters.Add(cModel.Position.Yaw) '16
            mess.Parameters.Add(cModel.Position.Pitch) '17
        Catch
        End Try
    End Sub

    Private Sub SCreateModelNet(ByVal paraModel As List(Of String))
        Try
            GetParameter(sgworldMain, paraModel)
            Dim cPoint As IPosition71 = sgworldMain.Creator.CreatePosition(System.Convert.ToDouble(paraModel(11)), System.Convert.ToDouble(paraModel(12)), System.Convert.ToDouble(paraModel(12)), 2, System.Convert.ToDouble(paraModel(15)), 0, 0, 0)
            fileModel = PathData & "\XPL\" & paraModel(14).Split("\")(paraModel(14).Split("\").Count - 1) 'fileModel.Substring(fileModel.LastIndexOf("\")).Split("\")(1)
            Dim cModel As ITerrainModel71 = sgworldMain.Creator.CreateModel(cPoint, fileModel, System.Convert.ToDouble(paraModel(15)), ModelTypeCode.MT_NORMAL, GroupBac2Main, tenKH)
            cModel.Position.Yaw = System.Convert.ToDouble(paraModel(16))
            cModel.Position.Pitch = System.Convert.ToDouble(paraModel(17))
            cModel.Tooltip.Text = mota
            mNetwork = True
            mModelArray.Add(cModel)
            ZoomLAND(sgworldMain, cModel)
            SLenhve3DMs()
        Catch
        End Try
    End Sub


#End Region

#Region "   DT chuyen dong"
    Public Sub SendDTCD(cMotionModel As ITerrainDynamicObject71)
        Try
            If (IsConnected()) Then
                Dim mess As New NetworkMessage
                PrChung(mess, "ModelMotionNet")
                AddMotionModel(mess, cMotionModel)
                SendMessage(mess)
            End If
        Catch
        End Try

    End Sub

    Private Sub AddMotionModel(mess As NetworkMessage, cMotionModel As ITerrainDynamicObject71)
        Try
            Dim lists1 As New List(Of IPosition71)
            Dim p(50000) As IPosition71
            For i As Integer = 0 To cMotionModel.Waypoints.Count - 1
                p(i) = sgworldMain.Creator.CreatePosition(cMotionModel.Waypoints.GetWaypoint(i).X, cMotionModel.Waypoints.GetWaypoint(i).Y, 150000, 2, 0, 0, 0, 0)
                lists1.Add(p(i))
            Next
            Dim cArray1(lists1.Count * 3 - 1) As Double
            For i As Integer = 0 To lists1.Count - 1
                cArray1(i * 3) = lists1(i).X
                cArray1(i * 3 + 1) = lists1(i).Y
                cArray1(i * 3 + 2) = lists1(i).Altitude
            Next
            mess.Parameters.Add(cMotionModel.FileName) '11
            mess.Parameters.Add(cMotionModel.TurnSpeed) '12
            mess.Parameters.Add(cMotionModel.ScaleFactor) '13
            mess.Parameters.Add(cMotionModel.CircularRoute) '14
            mess.Parameters.Add(cMotionModel.MotionStyle) '15
            mess.Parameters.Add(cMotionModel.ObjectType) '16
            mess.Parameters.Add(cMotionModel.Acceleration) '17
            mess.Parameters.Add(SerializeMultiPoints(cArray1)) '18
            mess.Parameters.Add(cMotionModel.Waypoints.GetWaypoint(1).Speed) '19
            mess.Parameters.Add(FileAmthanh) '20
        Catch
        End Try
    End Sub

    Private Sub SCreateMotionModelNet(ByVal paraMotionModel As List(Of String))
        Try
            GetParameter(sgworldMain, paraMotionModel)
            Dim cArray1() As Double = DeserializeMultiPointsDouble(paraMotionModel(18))
            Dim WaypointArrAB() As IRouteWaypoint71 = Enumerable.Empty(Of IRouteWaypoint71).ToArray
            For i As Integer = 0 To cArray1.Length / 3 - 1
                ReDim Preserve WaypointArrAB(0 To cArray1.Length / 3 - 1)
                WaypointArrAB(i) = sgworldMain.Creator.CreateRouteWaypoint(cArray1(i * 3), cArray1(i * 3 + 1), cArray1(i * 3 + 2), paraMotionModel(19), 0, 0, 0, tenKH)
            Next
            fileModel = PathData & "\XPL\" & paraMotionModel(11).Split("\")(paraMotionModel(11).Split("\").Count - 1) 'fileModel.Substring(cFile.LastIndexOf("\")).Split("\")(1)
            Dim DT As ITerrainDynamicObject71 = sgworldMain.Creator.CreateDynamicObject(WaypointArrAB, paraMotionModel(15), DYNAMIC_3D_MODEL, fileModel, System.Convert.ToDouble(paraMotionModel(13)), 2, GroupBac2Main, tenKH & "mh")
            DT.CircularRoute = paraMotionModel(14)
            DT.TurnSpeed = paraMotionModel(12)
            DT.Acceleration = paraMotionModel(17)
            DT.Tooltip.Text = mota.Replace("mh", "") & "," & paraMotionModel(20)
            DT.FileName = fileModel
            mNetwork = True
            mMotionModelArray.Add(DT)
            SLenhve3DMs()
            sgworldMain.Navigate.FlyTo(DTCD, ActionCode.AC_FOLLOWBEHINDANDABOVE)
        Catch
        End Try
    End Sub


#End Region

    Private Sub RanhgioiNet(ByVal paramsRG As List(Of String))
        Try
            veduong = paramsRG(16)
            Dim Gr As String = Gr03(sgworldMain, paramsRG(0), paramsRG(2), paramsRG(5))
            Dim lPoints As List(Of Point3D) = DeserializeMultiPointsList(paramsRG(8))
#Disable Warning IDE0059 ' Unnecessary assignment of a value
            Dim TextureFile As String = paramsRG(9)
#Enable Warning IDE0059 ' Unnecessary assignment of a value
            Dim line As New LineBusiness(lPoints(0).X, lPoints(0).Y, lPoints(1).X, lPoints(1).Y)
            Dim polygones As List(Of Point3D) = line.CreateParalellPolyline(lPoints, paramsRG(6) * paramsRG(7))
            For i As Integer = 0 To lPoints.Count - 2 Step 1
                Dim tempPolypone As New List(Of Point3D) From {lPoints(i), lPoints(i + 1), polygones(i + 1), polygones(i)}
                Dim cArray1(tempPolypone.Count * 3 - 1) As Double
                For j As Integer = 0 To tempPolypone.Count - 1
                    cArray1(j * 3) = tempPolypone(j).X / 360000
                    cArray1(j * 3 + 1) = tempPolypone(j).Y / 360000
                    cArray1(j * 3 + 2) = 0
                Next
                TextureFile = PathData + "\Textures" & paramsRG(9).Substring(paramsRG(9).LastIndexOf("\")) 'TextureFile.Substring(TextureFile.LastIndexOf("\"))
                Dim mPolygon As ITerrainPolygon71 = RegionTextures(TextureFile, cArray1, paramsRG(10), paramsRG(11), Gr, paramsRG(5))
                GiaidoanNet = paramsRG(2)
                loaiKH = paramsRG(4)
                tenKH = paramsRG(5)
                '   mChechMauxam = paramsRG(13)
                mKHTa_DP = paramsRG(14)
                mChieuKH = paramsRG(15)
                mNetwork = True
                mRegionArray.Add(mPolygon)
                Lenhve = paramsRG(3)
                SLenhve3DMs()
            Next
        Catch
        End Try
    End Sub

    Public Sub SendTrinhchieu(dongTC As String)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage With {.Command = "trinhchieu", .Parameters = New List(Of String) From {dongTC}}
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub TrCNet(ByVal paraTrinhchieu As List(Of String))
        Try
            dongTrinhchieu = paraTrinhchieu(0)
            If dongTrinhchieu = "0" Then
                TopHieuung()
            Else
                Try
                    Trinhchieu()
                Catch ex As Exception
                    Exit Sub
                Finally
                    Multimedia()
                End Try
            End If
        Catch
        End Try
    End Sub

    Private Sub SendTrCDT(dongTC As String)
        Try
            If IsConnected() = True Then
                Dim mess As New NetworkMessage With {.Command = "trcDTuong", .Parameters = New List(Of String) From {""}}
                SendMessage(mess)
            End If
        Catch
        End Try
    End Sub

    Private Sub CreateVungHL(ByVal paraVungHL As List(Of String))
        Try
            tenMayNet = paraVungHL(0)
            Bd3D = paraVungHL(1)
            GiaidoanNet = paraVungHL(3)
            Lenhve = paraVungHL(4)
            loaiKH = paraVungHL(5)
            tenKH = paraVungHL(6)
            mNetwork = True
            txtGroup.Text = paraVungHL(8)
            txtDocaoPK.Text = paraVungHL(9)
            txtTamPK.Text = paraVungHL(10)
            txtGoctrenPK.Text = paraVungHL(11)
            txtGocduoiPK.Text = paraVungHL(12)
            txtGocQuet.Text = paraVungHL(13)
            chebVeHL.Checked = paraVungHL(14)
            mota = paraVungHL(15)
            mau.FromABGRColor(paraVungHL(16))
            mau2.FromABGRColor(paraVungHL(17))
            VungHoalucNET(mau, mau2)
        Catch
        End Try
    End Sub



#End Region
#Region "SaBanVL"
    Public todoco = 25000
    Private Sub tb_DTMSBVL_TextChanged(sender As Object, e As EventArgs) Handles tb_DTMSBVL.TextChanged
        Try
            If tb_DTMSBVL.Text <> "" Then
                Dim values As String() = tb_DTMSBVL.Text.Split(","c) ' Tách chuỗi dữ liệu thành hai phần dựa vào dấu gạch dưới
                Dim part0 As String = values(0)
                Dim part1 As String = values(1)
                Dim ToadoSB As String = part0 & "," & part1
                Dim SbPoint As IPosition71 = ToadoSB_WGS84(ToadoSB)
                Dim TimTenCo As String = sgworldMain.ProjectTree.FindItem("ChuThap")
                Dim Dchuyen As String = sgworldMain.ProjectTree.FindItem("Dchuyen")
                If Dchuyen <> "" Then
                    sgworldMain.ProjectTree.DeleteItem(Dchuyen)
                End If
                If TimTenCo <> "" Then
                    If (sgworldMain.ProjectTree.IsGroup(TimTenCo)) Then
                        TimTenCo = sgworldMain.ProjectTree.GetNextItem(TimTenCo, ItemCode.CHILD)
                        Try
                            Dim pa1 As IPosition71 '', pa2 As IPosition71
                            Dim k2 = Nothing
                            Dim obj = sgworldMain.ProjectTree.GetObject(TimTenCo)
                            If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                                k2 = obj
                            End If
                            pa1 = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 0, 0, 0)
                            ReDim Preserve WaypointArr1(0 To 1)
                            WaypointArr1(0) = sgworldMain.Creator.CreateRouteWaypoint(pa1.X, pa1.Y, 0, todoco, 0, 0, 0, 0)
                            WaypointArr1(1) = sgworldMain.Creator.CreateRouteWaypoint(SbPoint.X, SbPoint.Y, 0, todoco, 0, 0, 0, 0)
                            Dim DT3 As ITerrainDynamicObject71 = sgworldMain.Creator.CreateDynamicObject(WaypointArr1, DynamicMotionStyle.MOTION_MANUAL, DynamicObjectType.DYNAMIC_3D_MODEL, "", Tyle * 200.0, mAltitudeType, Gr02(sgworldMain, "Dchuyen", "Temp"), "mhao")
                            k2.Attachment.AttachTo(DT3.ID, 0, 0, 0, 0, 0, 0)
                            DT3.Position.Distance = 50000
                            DT3.CircularRoute = CircularRouteType.CRT_STOP_AT_THE_END
                            DT3.Acceleration = 200
                            DT3.RestartRoute(0)
                            sgworldMain.Navigate.FlyTo(DT3, ActionCode.AC_FOLLOWBEHINDANDABOVE)
                        Catch
                        End Try
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub DieuKhienCo_TextChanged(sender As Object, e As EventArgs) Handles DieuKhienCo1.TextChanged
        Try
            Dim TimTenCo As String = sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\" & "GD1" & "\" & DieuKhienCo1.Text)
            If TimTenCo <> "" Then
                Lenhve = "NNtructiep"
                If txtNnTrt.Text = "" Then
                    txtNnTrt.Text = System.Environment.MachineName & "\" & "GD1" & "\" & DieuKhienCo1.Text
                Else
                    txtNnTrt.Text = txtNnTrt.Text & "," & System.Environment.MachineName & "\" & "GD1" & "\" & DieuKhienCo1.Text
                End If
            ElseIf TimTenCo = "" Then
                txtNnTrt.Text = ""
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Remote KichBan"
    Private Sub tb_TrinhChieu_TextChanged(sender As Object, e As EventArgs) Handles tb_TrinhChieu.TextChanged
        Try
            If tb_TrinhChieu.Text = "KB+" Then
                Try
                    If LisTrC.SelectedIndex < LisTrC.Items.Count - 1 Then
                        LisTrC.SelectedIndex = LisTrC.SelectedIndex + 1
                        txtTTTrC.Text = (LisTrC.SelectedIndex + 1).ToString()
                        Lenhve = "trinhchieu"
                        Trinhchieu()
                    End If
                    Me.Refresh()
                Catch ex As Exception
                    Exit Try
                End Try
                If IsConnected() = True Then
                    SendTrinhchieu(dongTrinhchieu)
                End If
            End If
            If tb_TrinhChieu.Text = "KB-" Then
                Try
                    If LisTrC.SelectedIndex < LisTrC.Items.Count - 1 Or LisTrC.SelectedIndex = LisTrC.Items.Count - 1 Then
                        LisTrC.SelectedIndex = LisTrC.SelectedIndex - 1
                        txtTTTrC.Text = (LisTrC.SelectedIndex + 1).ToString
                        ''FrmSBVL.tb_SKB.Text = txtTTTrC.Text
                        Lenhve = "trinhchieu"
                        Trinhchieu()
                    End If
                    Me.Refresh()
                Catch ex As Exception
                    Exit Try
                End Try
                If IsConnected() = True Then
                    SendTrinhchieu(dongTrinhchieu)
                End If
            End If
            tb_TrinhChieu.Text = ""
        Catch
        End Try
    End Sub
    Public Sub HuongBac()
        sgworldMain.Command.Execute(1056, 0) '1056 = mã cho chức năng bắc nam
    End Sub
    Private Sub tb_BN_TextChanged(sender As Object, e As EventArgs) Handles tb_BN.TextChanged
        Try
            sgworldMain.Command.Execute(1056, 0) '1056 = mã cho chức năng bắc nam
            tb_BN.Text = ""
        Catch
        End Try
    End Sub
#End Region
#Region "Lấy tọa độ liên tục"
    Private Sub LayToaDoSBVL()
        Try
            While True
                Dim currentPos = sgworldMain.Navigate.GetPosition(AltitudeTypeCode.ATC_ON_TERRAIN)
                Dim vido = currentPos.X
                Dim kinhdo = currentPos.Y
                Dim DoCao_met = currentPos.Altitude
                Dim GocNghieng = currentPos.Pitch
                tb_truyenvitri.Text = vido.ToString() + "," + kinhdo.ToString() + "," + GocNghieng.ToString() + "," + DoCao_met.ToString()
                Thread.Sleep(100)
                'Console.WriteLine(tb_truyenvitri.Text)
            End While
        Catch
        End Try
    End Sub
#End Region
#Region "Di Chuyển"
    Private Sub FrmMain_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        Try
            If panelOpenVKTC.Visible = False Then
                xpos1 = Control.MousePosition.X - Me.Location.X
                ypos1 = Control.MousePosition.Y - Me.Location.Y
                If Me.WindowState = FormWindowState.Maximized Then
                    Me.WindowState = FormWindowState.Normal
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub FrmMain_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        Try
            If panelOpenVKTC.Visible = False Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    newpoint = Control.MousePosition
                    newpoint.X -= (xpos1)
                    newpoint.Y -= (ypos1)
                    Me.Location = newpoint
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub FrmMain_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        Try
            If Me.WindowState <> FormWindowState.Maximized Then
                Me.WindowState = FormWindowState.Maximized
            Else
                Me.WindowState = FormWindowState.Normal
            End If
        Catch
        End Try
    End Sub
#End Region
#Region "Chia màn hình"
    Private Sub ChiaManHinh()
        Try
            Me.Location = New Point(0, 0)
            Me.Size = New Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height)
        Catch
        End Try
    End Sub
#End Region
#Region "Chuthap"
    Private Sub ChuThap1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chuthap.SelectedIndexChanged
        Try
            Dim ChuThap1 = sgworldMain.ProjectTree.FindItem("Chu Thap")
            If ChuThap1 <> "" Then
                Select Case chuthap.SelectedIndex
                    Case 0
                        TTChuThap = 0
                        sgworldMain.ProjectTree.SetVisibility(ChuThap1, False)
                    Case 1
                        TTChuThap = 1
                        sgworldMain.ProjectTree.SetVisibility(ChuThap1, True)
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public TTChuThap = 0
#End Region
#Region "Python"
    Public Shared Event ValueChanged2 As EventHandler(Of String)
    Public Shared Property ReturnedValue2 As String
    Private Shared Bam2 As String = ""
    Public Shared Sub ShowfrmMain()
        Try
            Dim form As New FrmMain()
            AddHandler FrmMain.ValueChanged2, Sub(sender, value)
                                                  ReturnedValue2 = value
                                              End Sub
            form.ShowDialog()
            ReturnedValue2 = Bam2
        Catch
        End Try
    End Sub
    Public Shared Sub SBSThoat()
        Instance.Close()
    End Sub
#End Region
#Region "ToaDoCuba"
    Public a_WGS84 As Double = 6378137.0
    Public e1_84 As Double = 1 / 298.257223563 * (2 - 1 / 298.257223563)
    Public e2_84 As Double = (1 / 298.257223563 * (2 - 1 / 298.257223563)) / Math.Pow((1 - 1 / 298.257223563), 2)
    Public Sub ConvertBLtoXY(vido As Double, kinhdo As Double, kinhtuyentruc As Double, muichieu As Double)
        Dim heso_a0, heso_a2, heso_a4, heso_a6, heso_a8, heso_m0, heso_m2, heso_m4, heso_m6, heso_m8 As Double
        Dim round As Integer = 3
        Dim X As Double = 0
        Dim Y As Double = 0
        heso_m0 = a_WGS84 * (1 - e1_84)
        heso_m2 = (3 * e1_84 * heso_m0) / 2
        heso_m4 = (5 * e1_84 * heso_m2) / 4
        heso_m6 = (7 * e1_84 * heso_m4) / 6
        heso_m8 = (9 * e1_84 * heso_m6) / 8

        heso_a0 = heso_m0 + heso_m2 / 2 + (3 * heso_m4) / 8 + (5 * heso_m6) / 16 + (35 * heso_m8) / 128
        heso_a2 = heso_m2 / 2 + heso_m4 / 2 + (15 * heso_m6) / 32 + (7 * heso_m8) / 16
        heso_a4 = heso_m4 / 8 + (3 * heso_m6 / 16) + (7 * heso_m8) / 32
        heso_a6 = heso_m6 / 32 + heso_m8 / 16
        heso_a8 = heso_m8 / 128

        Dim Xo As Double = heso_a0 * vido - (heso_a2 * Math.Sin(2 * vido)) / 2 + (heso_a4 * Math.Sin(4 * vido)) / 4 - (heso_a6 * Math.Sin(6 * vido)) / 6 + (heso_a8 * Math.Sin(8 * vido)) / 8

        Dim hieuso_l As Double = kinhdo - kinhtuyentruc

        Dim heso_N As Double = a_WGS84 / Math.Sqrt(1 - e1_84 * Math.Sin(vido) * Math.Sin(vido))
        Dim e2_2_WGS84 As Double = e1_84 / (1 - e1_84)
        Dim heso_eta As Double = Math.Sqrt(e2_2_WGS84 * Math.Pow(Math.Cos(vido), 2))

        Dim heso1_A2, heso1_A4, heso1_A6, heso1_A8, heso_B1, heso_B3, heso_B5, heso_B7 As Double

        heso1_A2 = (heso_N * Math.Sin(vido) * Math.Cos(vido)) / 2
        heso1_A4 = heso_N * Math.Sin(vido) * Math.Pow(Math.Cos(vido), 3) * (5 - Math.Pow(Math.Tan(vido), 2) + 9 * Math.Pow(heso_eta, 2) + 4 * Math.Pow(heso_eta, 4)) / 24
        heso1_A6 = heso_N * Math.Sin(vido) * Math.Pow(Math.Cos(vido), 5) * (61 - 58 * Math.Pow(Math.Tan(vido), 2) + Math.Pow(Math.Tan(vido), 4) + 270 * Math.Pow(heso_eta, 2) - 330 * Math.Pow(heso_eta, 2) * Math.Pow(Math.Tan(vido), 2)) / 720
        heso1_A8 = heso_N * Math.Sin(vido) * Math.Pow(Math.Cos(vido), 7) * (1385 - 311 * Math.Pow(Math.Tan(vido), 2) + 543 * Math.Pow(Math.Tan(vido), 4) - Math.Pow(Math.Tan(vido), 6)) / 40320

        heso_B1 = heso_N * Math.Cos(vido)
        heso_B3 = heso_N * Math.Pow(Math.Cos(vido), 3) * (1 - Math.Pow(Math.Tan(vido), 2) + Math.Pow(heso_eta, 2)) / 6
        heso_B5 = heso_N * Math.Pow(Math.Cos(vido), 5) * (5 - 18 * Math.Pow(Math.Tan(vido), 2) + Math.Pow(Math.Tan(vido), 4) + 14 * Math.Pow(heso_eta, 2) - 58 * Math.Pow(heso_eta, 2) * Math.Pow(Math.Tan(vido), 2)) / 120
        heso_B7 = heso_N * Math.Pow(Math.Cos(vido), 7) * (61 - 479 * Math.Pow(Math.Tan(vido), 2) + 179 * Math.Pow(Math.Tan(vido), 4) - Math.Pow(Math.Tan(vido), 6)) / 5040

        X = Xo + heso1_A2 * Math.Pow(hieuso_l, 2) + heso1_A4 * Math.Pow(hieuso_l, 4) + heso1_A6 * Math.Pow(hieuso_l, 6) + heso1_A8 * Math.Pow(hieuso_l, 8)
        Y = heso_B1 * hieuso_l + heso_B3 * Math.Pow(hieuso_l, 3) + heso_B5 * Math.Pow(hieuso_l, 5) + heso_B7 * Math.Pow(hieuso_l, 7)

        If muichieu = 6 Then
            X = X * 0.9996
            Y = Y * 0.9996 + 500000
        Else
            X = X * 0.9999
            Y = Y * 0.9999 + 500000
        End If
        X = Math.Round(X, round)
        Y = Math.Round(Y, round)
        yVN2000 = Y
        xVN2000 = X
        Dim kmX As Double = X - 2491151
        Dim X0 As String
        If kmX > 0 Then
            If kmX < 10000 AndAlso kmX > 1000 Then
                X0 = $"0{System.Convert.ToInt32(kmX.ToString().Substring(0, 1))}"
            ElseIf kmX < 1000 Then
                X0 = "00"
            Else
                X0 = $"{System.Convert.ToInt32(kmX.ToString().Substring(0, 2))}"
            End If

        ElseIf kmX < 0 AndAlso kmX > -99999 Then
            kmX = kmX + 100000
            If kmX > 1000 Then
                X0 = $"{System.Convert.ToInt32(kmX.ToString().Substring(0, 2))}"
            Else
                X0 = $"{System.Convert.ToInt32(kmX.ToString().Substring(0, 1))}"
            End If
        ElseIf kmX < -100000 Then
            kmX = kmX + 10000000
            X0 = $"{System.Convert.ToInt32(kmX.ToString().Substring(2, 2))}"
        End If
        Dim kmY As String = System.Convert.ToInt32(Y.ToString.Substring(1, 2))
        If kmY < 10 Then
            kmY = $"0{kmY}"
        End If

        If luachon = 0 Then
            LbToadoM.Text = X0 + " " + kmY.ToString()
        End If
        If luachon = 1 Then
            Dim cX As String
            If kmX < 10000 AndAlso kmX > 1000 Then
                cX = $"{System.Convert.ToInt32(kmX.ToString().Substring(1, 3))}"
            ElseIf kmX > 100 AndAlso kmX < 1000 Then
                cX = $"{System.Convert.ToInt32(kmX.ToString().Substring(0, 3))}"
            ElseIf kmX > 10000 Then
                cX = $"{System.Convert.ToInt32(kmX.ToString().Substring(2, 3))}"
            Else
                cX = "00"
            End If
            Dim cY As String = $"{System.Convert.ToInt32(Y.ToString().Substring(3, 3))}"
            Dim dx As Integer = 360, dy As Integer = 340
            Dim o9 As String = String.Empty
            If 0 < cX And cX < dx Then
                If 0 < cY And cY < dy Then
                    o9 = "7"
                ElseIf dy < cY And cY < dy * 2 Then
                    o9 = "6"
                ElseIf 2 * dy < cY And cY < dy * 3 Then
                    o9 = "5"
                End If
            ElseIf dx < cX And cX < dx * 2 Then
                If 0 < cY And cY < dy Then
                    o9 = "8"
                ElseIf dy < cY And cY < dy * 2 Then
                    o9 = "9"
                ElseIf 2 * dy < cY And cY < dy * 3 Then
                    o9 = "4"
                End If
            ElseIf 2 * dx < cX And cX < dx * 3 Then
                If 0 < cY And cY < dy Then
                    o9 = "1"
                ElseIf dy < cY And cY < dy * 2 Then
                    o9 = "2"
                ElseIf 2 * dy < cY And cY < dy * 3 Then
                    o9 = "3"
                End If
            End If
            LbToadoM.Text = X0 & kmY.ToString() & " " + o9
        End If
    End Sub

    Private _a_WGS84 As Double = 6378137.0
    Private _e1_84 As Double = 1 / 298.257223563 * (2 - 1 / 298.257223563)
    Private _e2_84 As Double = (1 / 298.257223563 * (2 - 1 / 298.257223563)) / Math.Pow((1 - 1 / 298.257223563), 2)
    Dim _B As Double = 0
    Dim _L As Double = 0
    Public Function ConvertXYtoBL(_x As Double, _y As Double, kinhtuyentruc As Double, muichieu As Double) As IPosition71
        If muichieu = 6 Then
            _x = _x / 0.9996
            _y = (_y - 500000) / 0.9996
        Else
            _x = _x / 0.9999
            _y = (_y - 500000) / 0.9999
        End If

        Dim a0, B, A1, A2, A4, A6 As Double
        a0 = 1 + 3 * _e1_84 / 4 + 45 * Math.Pow(_e1_84, 2) / 64 + 350 * Math.Pow(_e1_84, 3) / 512 + 11025 * Math.Pow(_e1_84, 4) / 16384

        B = _x / (_a_WGS84 * (1 - _e1_84) * a0)

        A1 = 0.5 * (3 * _e1_84 / 4 + 45 * Math.Pow(_e1_84, 2) / 64 + 350 * Math.Pow(_e1_84, 3) / 512 + 11025 * Math.Pow(_e1_84, 4) / 16384)

        A2 = -(63 * Math.Pow(_e1_84, 2) / 64 + 1108 * Math.Pow(_e1_84, 3) / 512 + 58239 * Math.Pow(_e1_84, 4) / 16384) / 3

        A4 = (604 * Math.Pow(_e1_84, 3) / 512 + 68484 * Math.Pow(_e1_84, 4) / 16384) / 3

        A6 = -(26328 * Math.Pow(_e1_84, 4)) / (3 * 16384)

        B = B + Math.Sin(2 * B) * (A1 + A2 * Math.Pow(Math.Sin(B), 2) + A4 * Math.Pow(Math.Sin(B), 4) + A6 * Math.Pow(Math.Sin(B), 6))

        Dim t As Double = Math.Tan(B)

        Dim eta As Double = _e2_84 * Math.Pow(Math.Cos(B), 2)

        Dim tam As Double = Math.Sqrt(1 - _e1_84 * Math.Pow(Math.Sin(B), 2))

        Dim N As Double = _a_WGS84 / tam

        Dim M As Double = _a_WGS84 * (1 - _e1_84) / Math.Pow(tam, 3)

        Dim l As Double = _y / (N * Math.Cos(B)) - Math.Pow(_y, 3) * (1 + 2 * Math.Pow(t, 2) + eta) / (6 * Math.Pow(N, 3) * Math.Cos(B)) +
        Math.Pow(_y, 5) * (5 + 28 * Math.Pow(t, 2) + 24 * Math.Pow(t, 4) + 6 * eta + 8 * eta * Math.Pow(t, 2)) / (120 * Math.Pow(N, 5) * Math.Cos(B))

        Dim Radian As Double = DOtoRADIAN(kinhtuyentruc)

        _L = RADIANtoDO(l + Radian)

        Dim _Bra As Double = B - (t * Math.Pow(_y, 2) / (2 * M * N) - t * Math.Pow(_y, 4) * (5 + 3 * Math.Pow(t, 2) + eta - 9 * eta * Math.Pow(t, 2)) /
       (24 * M * Math.Pow(N, 3)) - t * Math.Pow(_y, 6) * (61 + 90 * Math.Pow(t, 2) + 45 * Math.Pow(t, 4)) / (720 * M * Math.Pow(N, 5)))
        _B = RADIANtoDO(_Bra)
        ToaXCT = _L
        ToaYCT = _B
    End Function

    Public Function DOtoRADIAN(ByVal degree As Double) As Double
        Return degree * (Math.PI / 180)
    End Function

    Public Function RADIANtoDO(ByVal radian As Double) As Double
        Return radian * (180 / Math.PI)
    End Function

#End Region
End Class













'Function TdoVL_So() As IPosition71
'    Try
'        Dim TextFile As New StreamReader("C:\saban\sabantuongtac\tuongtacxy.txt", True)
'        Dim Line As String = TextFile.ReadLine()
'        If Line.Contains("|") Then
'            Dim Tuongtac As String = String.Empty
'            txtNnTrt.Text = ""
'            Lenhve = "NNtructiep3"
'            While (String.IsNullOrEmpty(Line) = False)
'                Dim Dt As String = Line.Replace("|", "\").Remove(Line.Length - 2, 2)
'                If Tuongtac = "" Then
'                    Tuongtac = Dt
'                Else
'                    Tuongtac = Tuongtac & "," & Dt
'                End If
'                Line = TextFile.ReadLine()
'            End While
'            TextFile.Close()
'            TdoVL_So = Nothing
'            txtNnTrt.Text = Tuongtac
'        ElseIf Line.Contains("_") Then
'            While (String.IsNullOrEmpty(Line) = False)
'                cbTylebando.SelectedIndex = System.Convert.ToInt16(Line.Split("_")(0))
'                cbGiaidoan.SelectedIndex = System.Convert.ToInt16(Line.Split("_")(1))
'                cbTa_DP.SelectedIndex = System.Convert.ToInt16(Line.Split("_")(2))
'                cbChieuKH.SelectedIndex = System.Convert.ToInt16(Line.Split("_")(3))
'                loaiKH = Line.Split("_")(4)
'                tenKH = Line.Split("_")(5)
'                Dim SText As String = tenKH
'                If loaiKH.Remove(loaiKH.Length - 2) = "100004" Or loaiKH = "1200001" Or loaiKH = "130001" Then
'                    If Line.Split("_")(3) = "1" Then
'                        SText &= "      "
'                    Else
'                        SText = "      " & SText
'                    End If
'                Else
'                    SText = SText
'                End If
'                fLabelStyleMain.TextAlignment = "Center, Center"
'                'textKH = TextFlage(loaiKH, Line.Split("_")(2), Line.Split("_")(3), tenKH)
'                Dim SbPoint As IPosition71 = sgworldMain.Creator.CreatePosition(Val(Line.Split("_")(6).Split(",")(0)), Val(Line.Split("_")(6).Split(",")(1)), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 10000 * Tyle)
'                fileImage = PathData & "\2X\" & loaiKH & ".mkx"
'                ''  MsgBox(fileImage)
'                GroupBac2Main = Gr03(sgworldMain, System.Environment.MachineName, "GD" & cbGiaidoan.SelectedIndex.ToString, tenKH & "_" & TtChan.ToString)
'                Dim mText As ITerrainLabel71 = sgworldMain.Creator.CreateLabel(SbPoint, SText, fileImage, fLabelStyleMain, GroupBac2Main, tenKH)
'                mText.Tooltip.Text = mota
'                mText.Position.Altitude = -0.25 * fLabelStyleMain.Scale
'                mText.Position.AltitudeType = 2
'                Line = TextFile.ReadLine()
'            End While
'            TextFile.Close()
'            TdoVL_So = Nothing
'        Else
'            Dim XY As New List(Of Double)
'            While (String.IsNullOrEmpty(Line) = False)
'                XY.Add(Line)
'                Line = TextFile.ReadLine()
'            End While
'            TextFile.Close()
'            Dim SbPoint As IPosition71 = sgworldMain.Creator.CreatePosition(XY(0), XY(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, XY(2), 0, XY(3))
'            TdoVL_So = SbPoint
'        End If
'    Catch ex As Exception
'        Exit Function
'        '  Finally
'        '  TextFile.Close()
'        ' txtNnTrt.Text = Tuongtac
'    End Try
'    'Tiep:
'    '        MsgBox(txtNnTrt.Text.Split(",").Count.ToString)
'End Function
'////////////////////////////////////////////
'Function TdoVL_So() As IPosition71
'    Dim ToadoXY As String = My.Computer.FileSystem.ReadAllText("C:\saban\sabantuongtac\tuongtacxy.txt")
'    Dim XY As New List(Of Double)
'    Dim TextFile As StreamReader = Nothing
'    Try
'        TextFile = New StreamReader("C:\saban\sabantuongtac\tuongtacxy.txt", True)
'        Dim Line As String = TextFile.ReadLine()
'        While (String.IsNullOrEmpty(Line) = False)
'            XY.Add(Line)
'            Line = TextFile.ReadLine()
'        End While
'        TextFile.Close()
'        Dim SbPoint As IPosition71 = sgworldMain.Creator.CreatePosition(XY(0), XY(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, XY(2), 0, XY(3))
'        TdoVL_So = SbPoint
'    Catch ex As Exception
'        Exit Function
'    Finally
'        TextFile.Close()
'    End Try
'End Function
'//////////////////Di chuyen1 dt tot
'If Lenhve = "DTdichuyen" Then
'    Dim pa1 As IPosition71, pa2 As IPosition71
'    Dim k2 = Nothing
'    Dim k0 = sgworldMain.ProjectTree.GetNextItem(sgworldMain.ProjectTree.FindItem(TxtDTdichuyen.Text), ItemCode.CHILD)
'    Dim obj = sgworldMain.ProjectTree.GetObject(k0)
'    If obj.ObjectType = ObjectTypeCode.OT_MODEL Then
'        k2 = obj
'    ElseIf obj.ObjectType = ObjectTypeCode.OT_LABEL Then
'        k2 = obj
'    ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
'        k2 = obj
'    End If
'    pa1 = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 0)
'    If ChebSabanVL.Checked = True Then
'        pa2 = TdoVL_So()
'    Else
'        pa2 = mPointClick
'    End If
'    ReDim Preserve WaypointArr1(0 To 1)
'    WaypointArr1(0) = sgworldMain.Creator.CreateRouteWaypoint(pa1.X, pa1.Y, 0, 2000, 0, 0, 0, "")
'    WaypointArr1(1) = sgworldMain.Creator.CreateRouteWaypoint(pa2.X, pa2.Y, 0, 2000, 0, 0, 0, "")
'    Dim DT3 As ITerrainDynamicObject71 = sgworldMain.Creator.CreateDynamicObject(WaypointArr1, DynamicMotionStyle.MOTION_GROUND_VEHICLE, DynamicObjectType.DYNAMIC_3D_MODEL, "", Tyle * 200.0, mAltitudeType, Gr02(sgworldMain, "Dchuyen", "Temp"), "mhao")
'    k2.Attachment.AttachTo(DT3.ID, 0, 0, 30 * Tyle, 0, 0, 0)
'    DT3.Position.Distance = 10000
'    DT3.CircularRoute = CircularRouteType.CRT_STOP_AT_THE_END
'    DT3.Acceleration = 200
'    DT3.RestartRoute(0)

' End If
'///////////////////////

'Try
'    Dim filePath As New System.IO.FileInfo("C:\saban\sabantuongtac\tuongtacxy.txt")
'    Dim PointSB As IPosition71 = Nothing
'    If filePath.Exists Then
'        Dim currentContent As String = File.ReadAllText(filePath.FullName)
'        If currentContent <> previousContent Then
'            previousContent = currentContent
'            Dim lines As String() = currentContent.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
'            If lines.Length > 0 Then
'                Dim XY As New List(Of Double)()
'                For Each line As String In lines
'                    MsgBox(line)
'                    Dim value As Double
'                    If Double.TryParse(line, value) Then
'                        XY.Add(value)
'                    End If
'                Next
'                If XY.Count >= 4 Then
'                    PointSB = sgworldMain.Creator.CreatePosition(XY(0), XY(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, XY(2), 0, XY(3))
'                End If
'            End If
'        End If
'    Else
'        Exit Function
'    End If
'    TdoVL_So = PointSB
'Catch ex As Exception
'    '   Exit Function
'End Try
'Private Sub WatcherTxtChanged(source As Object, e As FileSystemEventArgs)
'    Dim ToadoXY As String = My.Computer.FileSystem.ReadAllText("C:\saban\sabantuongtac\tuongtacxy.txt")
'    Dim XY As New List(Of Double)
'    Dim TextFile As StreamReader = Nothing
'    Try
'        TextFile = New StreamReader("C:\saban\sabantuongtac\tuongtacxy.txt", True)
'        Dim Line As String = TextFile.ReadLine()
'        While (String.IsNullOrEmpty(Line) = False)
'            XY.Add(Line)
'            Line = TextFile.ReadLine()
'        End While
'        TextFile.Close()
'        'Catch ex As Exception
'        'Finally
'        '    TextFile.Close()
'        'End Try
'        ' Dim SbPoint As IPosition71 = sgworldMain.Creator.CreatePosition(XY(0), XY(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, XY(2), 0)
'        Dim SbPoint As IPosition71 = sgworldMain.Creator.CreatePosition(XY(0), XY(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, XY(2), 0, XY(3))
'        sgworldMain.Navigate.FlyTo(SbPoint, ActionCode.AC_FLYTO)
'    Catch ex As Exception
'        Exit Sub
'    Finally
'        TextFile.Close()
'    End Try
'End Sub

'If Not Lenhve = "NNtructiep" Then
'    Dim Trangthai As String
'    For i As Integer = 2 To dongTrinhchieu.Split(";").Count - 1
'        If i = 4 Then
'            Trangthai = "1"
'        Else
'            Trangthai = "2"
'        End If
'        Try
'            Dim DtTat() As String = dongTrinhchieu.Split(";")(i).Split(",")
'            For j As Integer = 0 To DtTat.Count - 1
'                Dim Chan As String = DtTat(j).Split("_").Last
'                Dim Sochan As Integer
'                If Chan.Contains(".") Then
'                    Sochan = System.Convert.ToInt32(Chan.Split(".")(0))
'                End If
'                Goc.RemoveAt(Sochan)
'                MsgBox(Sochan.ToString)
'                Goc.Insert(Sochan, Trangthai)
'            Next
'        Catch ex As Exception
'        End Try
'    Next
'End If
'Private Sub XuatSB()
'    File.Delete("c:\saban\TrtSabanVL.txt")
'    Dim Goc, NN, Tat As New List(Of String)
'    For i As Integer = 0 To 319
'        Goc.Add("0")
'    Next
'    Dim TextFile As StreamReader = Nothing
'    OpenFileDialog1.Title = "Mở tập tin trình chiếu"
'    OpenFileDialog1.Filter = "Tập tin TEXT (*.txt) | *.txt"
'    OpenFileDialog1.ShowDialog()
'    LisTrC.Items.Clear()
'    If OpenFileDialog1.FileName <> "" Then
'        Try
'            TextFile = New StreamReader(OpenFileDialog1.FileName, True)
'            Dim w As New IO.StreamWriter("c:\saban" & "\TrtSabanVL.txt", FileMode.CreateNew)

'            Dim Line As String = TextFile.ReadLine()
'            While (String.IsNullOrEmpty(Line) = False)
'                If Line.Split(";")(3) <> "" Then
'                    Dim DtNN() As String = Line.Split(";")(3).Split(",")
'                    For i As Integer = 0 To DtNN.Count - 1
'                        Dim Chan As Integer = System.Convert.ToInt16(DtNN(i).Split("_").Last) - 1
'                        Goc.RemoveAt(Chan)
'                        Goc.Insert(Chan, "2")
'                    Next
'                End If

'                If Line.Split(";")(4) <> "" Then
'                    Dim DtNN() As String = Line.Split(";")(4).Split(",")
'                    For i As Integer = 0 To DtNN.Count - 1
'                        Dim Chan As Integer = System.Convert.ToInt16(DtNN(i).Split("_").Last) - 1
'                        Goc.RemoveAt(Chan)
'                        Goc.Insert(Chan, "1")
'                    Next
'                End If
'                Dim K As String = ""
'                For i As Integer = 0 To Goc.Count - 1
'                    K &= Goc(i)
'                Next
'                w.WriteLine(K)

'                Line = TextFile.ReadLine()
'            End While
'            w.Close()
'        Catch ex As Exception
'            MsgBox("Lỗi mở file")
'        Finally
'            TextFile.Close()
'        End Try
'    Else
'        Exit Sub
'    End If
'End Sub
'/////////////
'Function SabVl() As List(Of Integer)
'    Dim Goc, NN, Tat As New List(Of String)
'    For i As Integer = 0 To 319
'        Goc.Add("0")
'    Next
'    Dim K As String = ""
'    If dongTrinhchieu.Split(";")(3) <> "" Then
'        Dim DtNN() As String = dongTrinhchieu.Split(";")(3).Split(",")
'        For i As Integer = 0 To DtNN.Count - 1
'            Dim Chan As Integer = System.Convert.ToInt16(DtNN(i).Split("_").Last)
'            Goc.RemoveAt(Chan)
'            Goc.Insert(Chan, "2")
'        Next
'        'For i As Integer = 0 To DtNN.Count - 1
'        '    Dim Chan As Integer = System.Convert.ToInt16(Chanso(DtNN(i))) - 1
'        '    ' If Chan <> "" Then
'        '    Goc.RemoveAt(Chan)
'        '    Goc.Insert(Val(Chan), "2")
'        '    '  GoTo Tiep1
'        '    '  End If
'        '    'Tiep1:
'        'Next

'    End If

'    If dongTrinhchieu.Split(";")(4) <> "" Then
'        Dim DtTat() As String = dongTrinhchieu.Split(";")(4).Split(",")
'        For i As Integer = 0 To DtTat.Count - 1
'            Dim Chan As Integer = System.Convert.ToInt16(DtTat(i).Split("_").Last)
'            Goc.RemoveAt(Chan)
'            Goc.Insert(Chan, "1")
'        Next
'    End If

'    If dongTrinhchieu.Split(";")(1) <> "" Then
'        Dim DtMT() As String = dongTrinhchieu.Split(";")(1).Split(",")
'        For i As Integer = 0 To DtMT.Count - 1
'            Dim Chan As Integer = System.Convert.ToInt16(DtMT(i).Split("_").Last)
'            Goc.RemoveAt(Chan)
'            Goc.Insert(Chan, "2")
'        Next
'    End If



'    '/////////////////// GHi
'    For i As Integer = 0 To Goc.Count - 1
'        K &= Goc(i)
'    Next

'    Try
'        Dim w As New IO.StreamWriter(PathData1 & "\TrtSabanVL.txt", FileMode.CreateNew)
'        w.WriteLine(K)
'        w.Close()
'    Catch ex As Exception
'        Exit Function
'    End Try

'End Function

'Function Chanso(Gr As String) As String
'    Dim Sochan As String
'    Dim k0 = sgworldMain.ProjectTree.FindItem(Gr)
'    If (sgworldMain.ProjectTree.IsGroup(k0)) Then
'        k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
'        '  While Not (k0 = Nothing)
'        Dim obj = sgworldMain.ProjectTree.GetObject(k0)
'        If obj.ObjectType = ObjectTypeCode.OT_MODEL Then
'            Dim k2 As ITerrainDynamicObject71 = Nothing
'            '  k2 = obj
'            Sochan = k2.Tooltip.Text.Split(",").Last
'        ElseIf obj.ObjectType = ObjectTypeCode.OT_DYNAMIC Then
'        ElseIf obj.ObjectType = ObjectTypeCode.OT_LABEL Then
'            Dim k2 As ITerrainLabel71 = obj
'            '  k2 = obj
'            Sochan = k2.Tooltip.Text.Split(",").Last
'            'MsgBox(Sochan.ToString)
'        ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then

'        ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then


'            Dim k2 As ITerrainPolygon71 = Nothing
'            '  k2 = obj
'            Sochan = k2.Tooltip.Text.Split(",").Last
'        End If
'        k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
'        '  End While
'    End If
'    Chanso = Sochan
'End Function

'Dim fsw As New FileSystemWatcher(), TenVl As String
'Private Sub WatcherTxtChanged(source As Object, e As FileSystemEventArgs)
'    Dim fileReader As String = My.Computer.FileSystem.ReadAllText("C:\saban\KBTOFLY.txt")
'    Dim liKieuTrChieu As String = fileReader.Split(",")(0)
'    Dim NoidungTrChieu As String = fileReader.Split(",")(1)
'    TenVl = ""
'    If liKieuTrChieu = "KB" Then
'        TenVl = NoidungTrChieu
'        D43timer.Start()
'        D43timer.Interval = 100
'        'If IsConnected() = True Then
'        '    SendTrinhchieu(dongTrinhchieu)
'        'End If
'    ElseIf liKieuTrChieu = "bd" Then
'    ElseIf liKieuTrChieu = "bd" Then

'    End If

'End Sub

'Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles D43timer.Tick
'    D43timer.Stop()
'    txtTTTrC.Text = TenVl
'End Sub

'Private Sub ChebDienthoai_CheckedChanged(sender As Object, e As EventArgs) Handles chebDienthoai.CheckedChanged
'    If chebDienthoai.Checked = True Then
'        fsw.Path = "C:\saban"
'        fsw.Filter = "KBTOFLY.txt"
'        fsw.NotifyFilter = NotifyFilters.LastWrite
'        fsw.EnableRaisingEvents = True
'        AddHandler fsw.Changed, New FileSystemEventHandler(AddressOf WatcherTxtChanged)
'    End If

'End Sub
'    Private Sub TxtSoTTTrC_TextChanged(sender As Object, e As EventArgs)
'        TopHieuung()
'        If txtSoTTTrC.Text.Contains("<") Then
'            If IsConnected() = True Then
'                SendTrCDT(txtSoTTTrC.Text)
'            End If
'            Quansat()

'        Else
'            Dim ret As Boolean
'            ret = IsNumeric(txtSoTTTrC.Text)
'            If (ret = True) Then
'                LisTrC.SelectedIndex = Val(txtSoTTTrC.Text) '- 1
'                Trinhchieu()
'                If IsConnected() = True Then
'                    SendTrinhchieu(dongTrinhchieu)
'                End If
'            Else
'                If IsConnected() = True Then
'                    SendTrCDT(txtSoTTTrC.Text)
'                End If
'                If txtSoTTTrC.Text = "tat" Then
'                    pnTrinhchieu.Visible = False
'                Else
'                    Dim k0 = sgworldMain.ProjectTree.FindItem(txtSoTTTrC.Text)
'                    Dim sP As IPosition71 = Nothing
'                    Dim tenAmthanh As String = String.Empty
'                    If (sgworldMain.ProjectTree.IsGroup(k0)) Then
'                        k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
'                        While Not (k0 = Nothing)
'                            Dim obj = sgworldMain.ProjectTree.GetObject(k0)
'                            If obj.ObjectType = ObjectTypeCode.OT_MODEL Then
'                                Dim k2 As ITerrainModel71 = obj
'                                Dim tenDT As String = sgworldMain.ProjectTree.GetItemName(obj.ID)
'                                If tenDT.Contains("CQ") Then
'                                    TimerTrT.Start()
'                                    TimerTrT.Interval = 1
'                                    GoTo Dynamic
'                                Else
'                                    sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 0)
'                                    sP.Distance = 17000
'                                    SNhay(sP)
'                                End If
'Dynamic:                    ElseIf obj.ObjectType = ObjectTypeCode.OT_DYNAMIC Then
'                                Dim k2 As ITerrainDynamicObject71 = Nothing
'                                k2 = obj
'                                k2.Position.Distance = 20000 * Tyle
'                                k2.RestartRoute(0)
'                                sgworldMain.Navigate.FlyTo(k2, 8)
'                                tenAmthanh = PathData & "\Sounds\" & "00" & Trim(k2.Tooltip.Text.Split(":")(0).Split(",")(1)) & ".wav"
'                            ElseIf obj.ObjectType = ObjectTypeCode.OT_LABEL Then
'                                Dim k2 As ITerrainLabel71 = obj
'                                sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 0)
'                                sP.Distance = 25000
'                                SNhay(sP)
'                            ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then
'                                Dim k2 As ITerrainPolyline = obj
'                                If k2.Tooltip.Text = "Khu vực nhảy dù." Or k2.Tooltip.Text = "Khu vực trú quân, tập kết" Or k2.Tooltip.Text = "Nhiệm vụ trước mắt" Or k2.Tooltip.Text = "Nhiệm vụ tiếp theo" Or k2.Tooltip.Text = "Đường hành quân" Or k2.Tooltip.Text = "Hàng rào thép gai bùng nhùng" Then
'                                    sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 0)
'                                    sP.Distance = 14000
'                                    SNhay(sP)
'                                End If

'                            ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
'                                Dim k2 As ITerrainPolygon71 = obj
'                                Try
'                                    If k2.Tooltip.Text.Substring(0, 10) = "een4NC7n9kGp" Or k2.Tooltip.Text.Substring(0, 10) = "p94dKTH2jed" Then
'                                        Dim text As String = Decrypt(k2.Tooltip.Text, PassKey)
'                                        Dim soDiem As Integer = Val(text.Split("-")(2).Split(":").Count)
'                                        Dim todoa As String = text.Split("-")(2)
'                                        ' MsgBox(soDiem.ToString)
'                                        Dim sP1 As IPosition71 = sgworldMain.Creator.CreatePosition(Val(todoa.Split(":")(1).Split(",")(0)), Val(todoa.Split(":")(1).Split(",")(1)), 0, 2, 0, 0, 0, 0)
'                                        Dim sP2 As IPosition71 = sgworldMain.Creator.CreatePosition(Val(todoa.Split(":")(soDiem - 2).Split(",")(0)), Val(todoa.Split(":")(soDiem - 2).Split(",")(1)), 0, 2, 0, 0, 0, 0)
'                                        sP = sgworldMain.Creator.CreatePosition(0.5 * (sP1.X + sP2.X), 0.5 * (sP1.Y + sP2.Y), 0, 2, 0, 340, 30, 0)
'                                        sP.Yaw = FGoc(sP1, sP2) '+ 180
'                                        sP.Distance = 1000 * sgworldMain.CoordServices.GetDistance(sP1.X, sP1.Y, sP2.X, sP2.Y)
'                                    ElseIf k2.Tooltip.Text = "Đại liên" Or k2.Tooltip.Text = "Trung liên" Or k2.Tooltip.Text = "Súng B40" Or k2.Tooltip.Text = "Súng B41" Or k2.Tooltip.Text = "Công sự" Then
'                                        sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 0)
'                                        sP.Distance = 3000
'                                    Else
'                                        sP = sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, 0, 2, 0, 340, 30, 0)
'                                        sP.Distance = 18000
'                                    End If
'                                    SNhay(sP)
'                                Catch eX As Exception
'                                Finally
'                                End Try
'                                '   SNhay(sP)
'                            End If
'                            k0 = sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
'                        End While
'                        'Else
'                        '    SNhay(sP)
'                        '    Dim obj = sgworldMain.ProjectTree.GetObject(k0)
'                        '    If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
'                        '        Dim k1 As ITerrainLabel71 = obj
'                        '        k1.Position.Distance = 15000
'                        '        k1.Position.Pitch = 340
'                        '        SNhay(k1.Position)
'                        '    End If
'                    End If
'                    If tenAmthanh <> "" Then
'                        My.Computer.Audio.Play(tenAmthanh, AudioPlayMode.BackgroundLoop)
'                    End If
'                End If
'            End If
'        End If

'        sgworldMain.Window.SetInputMode(MouseInputMode.MI_FREE_FLIGHT, "", True)
'    End Sub

'Private Sub Quansat()
'    listBoxX.Items.Clear()
'    listBoxY.Items.Clear()
'    Dim Xmax, Ymax, Xmin, Ymin As Double
'    Try
'        Dim k1 As ITerrainPolygon71 = sgworldMain.ProjectTree.GetObject(sgworldMain.ProjectTree.FindItem("Trinh bay\Khung\Khung")) ' "Trinh bay"
'        Dim ST1() As String = k1.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")
'        For i As Integer = 0 To ST1.Count - 1
'            listBoxX.Items.Add(ST1(i).Split(" ")(1))
'            listBoxX.Sorted = True
'            listBoxY.Items.Add(ST1(i).Split(" ")(2))
'            listBoxY.Sorted = True
'        Next
'        Xmax = Val(listBoxX.Items.Item(4))
'        Xmin = Val(listBoxX.Items.Item(0))
'        Ymax = Val(listBoxY.Items.Item(4))
'        Ymin = Val(listBoxY.Items.Item(0))
'        Dim p1 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmin, Ymax, 0, 2, 0, 0, 0, 0)
'        Dim p2 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmax, Ymax, 0, 2, 0, 0, 0, 0)
'        Dim p3 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmin, Ymax, 0, 2, 0, 0, 0, 0)
'        Dim p4 As IPosition71 = sgworldMain.Creator.CreatePosition(Xmin, Ymin, 0, 2, 0, 0, 0, 0)
'        Dim RongVK As Double = sgworldMain.CoordServices.GetDistance(p1.X, p1.Y, p2.X, p2.Y)
'        Dim CaoVK As Double = sgworldMain.CoordServices.GetDistance(p1.X, p1.Y, p4.X, p4.Y)
'        'If txtSoTTTrC.Text.Split("<")(0) = "Thu" Then
'        '    sgworldMain.Navigate.ZoomIn(-1000)
'        'ElseIf txtSoTTTrC.Text.Split("<")(0) = "Phong" Then
'        '    sgworldMain.Navigate.ZoomIn(1000)
'        'ElseIf txtSoTTTrC.Text.Split("<")(0) = "Xoay" Then
'        '    sgworldMain.Command.Execute(1057, 0)
'        'ElseIf txtSoTTTrC.Text.Split("<")(0) = "Dung" Then
'        '    sgworldMain.Navigate.Stop()
'        'ElseIf txtSoTTTrC.Text.Split("<")(0) = "A_B0" Or txtSoTTTrC.Text.Split("<")(0) = "A_B1" Or txtSoTTTrC.Text.Split("<")(0) = "A_B2" Then
'        '    Dim CP1 As String = txtSoTTTrC.Text.Split("<")(1) & "<" & txtSoTTTrC.Text.Split("<")(2) & "<" & txtSoTTTrC.Text.Split("<")(3) & "<" & txtSoTTTrC.Text.Split("<")(4)
'        '    Dim CP2 As String = txtSoTTTrC.Text.Split("<")(1) & "<" & txtSoTTTrC.Text.Split("<")(2) & "<" & txtSoTTTrC.Text.Split("<")(5) & "<" & txtSoTTTrC.Text.Split("<")(6)
'        '    Dim pa1 As IPosition71 = MPointTrc(CP1, RongVK, CaoVK, p1)
'        '    Dim pa2 As IPosition71 = MPointTrc(CP2, RongVK, CaoVK, p1)
'        '    ReDim Preserve WaypointArr1(0 To 1)
'        '    WaypointArr1(0) = sgworldMain.Creator.CreateRouteWaypoint(pa1.X, pa1.Y, 1000, 1000, 0, 0, 0, "")
'        '    WaypointArr1(1) = sgworldMain.Creator.CreateRouteWaypoint(pa2.X, pa2.Y, 1000, 1000, 0, 0, 0, "")
'        '    Dim k0 = sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\TempTrC\mhao")
'        '    If String.IsNullOrEmpty(k0) = False Then
'        '        sgworldMain.ProjectTree.DeleteItem(sgworldMain.ProjectTree.FindItem(System.Environment.MachineName & "\TempTrC\mhao"))
'        '    End If
'        '    Dim DT3 As ITerrainDynamicObject71 = sgworldMain.Creator.CreateDynamicObject(WaypointArr1, DynamicMotionStyle.MOTION_AIRPLANE, DynamicObjectType.DYNAMIC_3D_MODEL, "", Tyle * 200.0, mAltitudeType, Gr02(sgworldMain, System.Environment.MachineName, "TempTrC"), "mhao") '.DYNAMIC_VIRTUALPathData & "\XPL\" & "UAV2.xpl2"
'        '    DT3.Position.Distance = 10000
'        '    DT3.Acceleration = 200
'        '    DT3.RestartRoute(0)
'        '    If txtSoTTTrC.Text.Split("<")(0) = "A_B0" Then
'        '        sgworldMain.Navigate.FlyTo(DT3)
'        '    ElseIf txtSoTTTrC.Text.Split("<")(0) = "A_B1" Then
'        '        sgworldMain.Navigate.FlyTo(DT3, ActionCode.AC_FOLLOWLEFT)
'        '    ElseIf txtSoTTTrC.Text.Split("<")(0) = "A_B2" Then
'        '        sgworldMain.Navigate.FlyTo(DT3, ActionCode.AC_FOLLOWRIGHT)
'        '    End If
'        'Else
'        '    Dim pa As IPosition71 = MPointTrc(txtSoTTTrC.Text, RongVK, CaoVK, p1)  'mPointTrc(ChuoiAndroi As String, RongVK As Double, CaoVK As Double, P As IPosition71)
'        '    pa.Distance = 50000 * Tyle
'        '    pa.Pitch = 320
'        '    sgworldMain.Navigate.FlyTo(pa, ActionCode.AC_FLYTO)
'        'End If
'    Catch ex As Exception

'    End Try
'End Sub

'Function MPointTrc(ChuoiAndroi As String, rongVK As Double, caoVK As Double, P As IPosition71) As IPosition71
'    Dim rongAnh As Double = System.Convert.ToDouble(ChuoiAndroi.Split("<")(0)) * 0.000264583333
'    Dim caoAnh As Double = System.Convert.ToDouble(ChuoiAndroi.Split("<")(1)) * 0.000264583333
'    Dim Xa As Double = System.Convert.ToDouble(ChuoiAndroi.Split("<")(2))
'    Dim Ya As Double = System.Convert.ToDouble(ChuoiAndroi.Split("<")(3))
'    Dim cheoAnh As Double = Math.Sqrt(rongAnh ^ 2 + caoAnh ^ 2)
'    Dim cheoVK As Double = Math.Sqrt(rongVK ^ 2 + caoVK ^ 2)
'    Dim Hesothuphong As Double = 1 / 3 * (rongVK / rongAnh + caoVK / caoAnh + cheoVK / cheoAnh)
'    Dim pz As MicroStationDGN.Point3d = ToadoVN2000(P)
'    Dim Pa As MicroStationDGN.Point3d '= ToadoVN2000(P)
'    ' 0.000264583333
'    Pa.X = pz.X + (Val(Trim(txtThamsoToadoX.Text)) / (caoAnh / rongAnh)) * (Xa * 0.000264583333 * Hesothuphong)
'    Pa.Y = pz.Y - (Val(Trim(txtThamsoToadoY.Text)) / (caoAnh / rongAnh)) * (Ya * 0.000264583333 * Hesothuphong)
'    Dim KtTruc As Double
'    If 102.0 < P.X And P.X < 108.0 Then KtTruc = 105.0
'    If 108.0 <= P.X And P.X < 118.0 Then KtTruc = 111.0
'    Chuyendoi_XYZVN2000_to_BLHWGS84(Pa.Y, Pa.X, 0, B84, L84, H84, KtTruc, 6)
'    Dim Px As IPosition71 = sgworldMain.Creator.CreatePosition(L84, B84, 0, 2, 0, -60, 0, 0)
'    Px.Distance = 15000
'    MPointTrc = Px
'End Function