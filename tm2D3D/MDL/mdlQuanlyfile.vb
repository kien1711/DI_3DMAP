Imports System.IO
Imports TerraExplorerX

Module mdlQuanlyfile

#Region " Bien"
    Public loaiKH As String = String.Empty, fileImage As String = String.Empty, tenGiaidoan As String = String.Empty, tenMayNet As String = String.Empty,
           fileModel As String = String.Empty, ChieuKH As String = String.Empty, Lenhve As String = String.Empty,
           Lenhsua As String = String.Empty, ChuoiDT As String = String.Empty, Lenhve2 As String = String.Empty, Lenhve2D2 As String = String.Empty, lenhveMS2 As String = String.Empty,
           tenKH As String = String.Empty, textKH As String = String.Empty, Giaidoan As String = String.Empty, GiaidoanNet As String = String.Empty,
            mota As String = String.Empty, Ta_Doiphuong As String = String.Empty,
           file3Dbd As String = String.Empty, file3DA As String = String.Empty, fileMs As String = String.Empty, filebt As String = String.Empty, 'file2D As String = String.Empty,
           mChechmau2 As String = String.Empty, mKHTa_DP As String = String.Empty, mChieuKH As String = String.Empty,
           Lenhve2D As String = String.Empty, lenhveMS As String = String.Empty, mP As String = String.Empty,' mBd3D As String = String.Empty,
           GroupBac2Main As String = String.Empty, GroupBac23DBd As String = String.Empty, GroupBac23DA As String = String.Empty, tempGroup As String = String.Empty
    Public ComputerName As String = String.Empty, TenGrB2 As String = String.Empty
    Public mTylebando As Integer = 0, mMuichieu As Integer = 0, current As Integer = 0, hesofont As Integer = 1.0
    Public ChuGhichu As Boolean = False, Bd3D As Boolean = False, A3D As Boolean = False, mMicrostation As Boolean = False, mChebNhom As Boolean = False, mNetwork As Boolean = False ' mXoaLevel As Boolean = False,
    Public KTTU As Double = 0, Dorongduong As Double = 0, Tyle As Double = 0, TyleSBVL As Double = 0, Phuongvi As Double = 0, Phuongvi1 As Double = 0,
          xVN2000 As Double = 0, yVN2000 As Double = 0, hVN2000 As Double = 0, B84 As Double = 0, L84 As Double = 0, H84 As Double = 0, xWGS84 As Double = 0, yWGS84 As Double = 0
    Public mau As IColor71 = Nothing, mau2 As IColor71 = Nothing, mau3 As IColor71 = Nothing, mau4 As IColor71 = Nothing, mauXanh As IColor71 = Nothing, mauRedBlue As IColor71 = Nothing, mauNau As IColor71 = Nothing, mauHH As IColor71 = Nothing, mauChu As IColor71 = Nothing, mauH2O As IColor71 = Nothing, mauXam As IColor71 = Nothing, mauDen As IColor71 = Nothing, mau3Chu As IColor71 = Nothing, mauTrang As IColor71 = Nothing
    Public PllVts() As Double, mArPoint() As Double
    Public PathData1 As String = Application.StartupPath
    Public PathData As String = Application.StartupPath & "\Data"
    Public mVideo3D As ITerrainVideo71
    Public sgworld3DBd As SGWorld71, sgworld3DA As SGWorld71
    Public coCell1 As ITerraExplorerObject71 = Nothing
    Public mRegionArray As New List(Of ITerrainPolygon71), mLineArray As New List(Of ITerrainPolyline71), mLineNoiArray As New List(Of ITerrainPolyline71), mLabelArray As New List(Of ITerrainLabel71), mModelArray As New List(Of ITerrainModel71),
           mMotionModelArray As New List(Of ITerrainDynamicObject71), mRectangleArray As New List(Of ITerrainRectangle71), mEfectArray As New List(Of ITerrainEffect71), mLineArrayHR As New List(Of ITerrainPolyline71)
    Public DTCD As ITerrainDynamicObject71 = Nothing
    Public myScreens() As Screen = Screen.AllScreens
    Public mPointMS1 As IPosition71 = Nothing
    Public mPointMS2 As IPosition71 = Nothing
    Public mThumuc As String = String.Empty, m2X As String = String.Empty
    Public mPZoom As IPosition71 = Nothing
    Public mauKT As Boolean = False

    Public bienDTTat() As String
    Public bienDTNhapnhay() As String
    Public textTrinhchieu As String = String.Empty, dongTrinhchieu As String = String.Empty
    Public slan As Boolean = False

    Public TDMuiten As String = String.Empty
    Public MauMT As IColor71 = Nothing
    Public xoaDTcat As Boolean = False
    'new
    Public PllVtNum As Integer = 0
    Public PllVtNum1 As Integer = 0
    Public PllPts() As Point3D
    Public PllPts1() As Point3D
    Public cPlg1 As ITerrainPolygon71 = Nothing, cPlg2 As ITerrainPolygon71 = Nothing, cPlgBD1 As ITerrainPolygon71 = Nothing, cPlgBD2 As ITerrainPolygon71 = Nothing
    Public cPlg11 As ITerrainPolygon71 = Nothing, cPlg21 As ITerrainPolygon71 = Nothing, cPlgBD11 As ITerrainPolygon71 = Nothing, cPlgBD21 As ITerrainPolygon71 = Nothing
    Public solan As Integer = 0
    Public PointHQ As IPosition71 = Nothing, GocHQ As Double = 0
    Public TdXY As New List(Of Double)
    Public Dkien As Boolean = False
    Public PassKey As String = "*Vinhkhang#PhucKhanh!!<!!>/"
    Public ToadoSB As String = String.Empty


#End Region

    Public Function SLabelStyleTQ(sgworldK As SGWorld71) As ILabelStyle71
        Dim fLabelStyleTQ As ILabelStyle71
        fLabelStyleTQ = sgworldK.Creator.CreateLabelStyle(SGLabelStyle.LS_DEFAULT)
        fLabelStyleTQ.LimitScreenSize = False
        fLabelStyleTQ.SmallestVisibleSize = 0
        fLabelStyleTQ.LineToGroundLength = 0
        fLabelStyleTQ.FontName = "UTM Cafeta"
        ' fLabelStyleTQ.FontName = "Arial Narrow" '"Calibri"  '"Arial Narrow" ' "Tahoma" ' "UTM HelvetIns"
        If Lenhve = "Doituongchu" Then
            fLabelStyleTQ.Scale = 9.0
        Else
            fLabelStyleTQ.Scale = Tyle * 6.0
        End If
        fLabelStyleTQ.FontSize = 72.0
        SLabelStyleTQ = fLabelStyleTQ
    End Function

    Public Sub TaoTrinhchieu()
        Dim mManhinh As String, mPhim As String, mDTChuyendong As String, mModel As String, mMuiTen As String, mTunhien As String

        If FrmMain.Instance.txtMTCD.Text <> "" Then
            mMuiTen = FrmMain.Instance.txtMTCD.Text & "." & FrmMain.Instance.txtTGMTChay.Text
        Else
            mMuiTen = ""
        End If

        If FrmMain.Instance.txtDTChuyendong1.Text <> "" Then
            mDTChuyendong = FrmMain.Instance.txtDTChuyendong1.Text & "." & FrmMain.Instance.cbHuDTchuyendong.SelectedIndex.ToString & "." & FrmMain.Instance.cbQsDoituong.SelectedIndex.ToString
        Else
            mDTChuyendong = ""
        End If
        If FrmMain.Instance.txtDTQuay.Text <> "" Then
            mModel = FrmMain.Instance.txtDTQuay.Text & "." & FrmMain.Instance.cbHuMH.SelectedIndex.ToString
        Else
            mModel = ""
        End If

        If FrmMain.Instance.txtPhim.Text <> "" Then
            mPhim = FrmMain.Instance.txtPhim.Text & "_" & FrmMain.Instance.cbPhimAmthanh.SelectedIndex.ToString & "_" & FrmMain.Instance.cbVitriPhim.SelectedIndex.ToString '& FrmMain.Instance.txtKTPhim.Text '"1,30x40" '
        Else
            mPhim = ""
        End If

        If FrmMain.Instance.cbTunhien.SelectedIndex > 0 Then
            mTunhien = FrmMain.Instance.cbTunhien.SelectedIndex
        Else
            mTunhien = ""
        End If

        If FrmMain.Instance.cbHieuungCanh1.SelectedIndex > 0 Then
            mManhinh = FrmMain.Instance.cbHieuungCanh1.SelectedIndex - 1
            '   mManhinh = "." & FrmMain.Instance.cbHieuungCanh1.SelectedIndex - 1
        Else
            mManhinh = ""
        End If
        'dongTrinhchieu = FrmMain.Instance.txtTencanh.Text & "." & FrmMain.Instance.cbHieuungCanh1.SelectedIndex.ToString & ";" & bienVitritrinhchieu & ";" & mMTChuyendong & ";" & FrmMain.Instance.txtDTNhapnhay.Text & ";" &
        '  dongTrinhchieu = FrmMain.Instance.txtTencanh.Text & mManhinh & ";" & FrmMain.Instance.Vitritrinhchieu & ";" & mMuiTen & ";" & FrmMain.Instance.txtDTNhapnhay.Text & ";" & FrmMain.Instance.txtDTAn.Text & ";" & mPhim & ";" & mDTChuyendong & ";" & mModel & ";" & mTunhien & ";" & FrmMain.Instance.txtBaocao.Text 'chuan
        '-----------------------0---------------------------------------------------1-----------------------2-----------------------3---------------------------------4---------------------5-----------------6-----------------7----------------8----------------------9--------------
        dongTrinhchieu = FrmMain.Instance.txtTencanh.Text & "." & mManhinh & ";" & FrmMain.Instance.Vitritrinhchieu & ";" & mMuiTen & ";" & FrmMain.Instance.txtDTNhapnhay.Text & ";" & FrmMain.Instance.txtDTAn.Text & ";" & mPhim & ";" & mDTChuyendong & ";" & mModel & ";" & mTunhien & ";" & FrmMain.Instance.txtBaocao.Text 'chuan

        FrmMain.Instance.liBDanhsachTrC2.Items.Add(dongTrinhchieu)
        Dim DanhsachCacDT() = dongTrinhchieu.Split(";")
        FrmMain.Instance.libDanhsachTrC.Items.Add(DanhsachCacDT(0))
        textTrinhchieu = textTrinhchieu & dongTrinhchieu & vbCrLf
        FrmMain.Instance.libDanhsachTrC.SelectedIndex = 0
        ' MsgBox(dongTrinhchieu)
    End Sub

    Public Sub SOpen(sgworldK As SGWorld71, sogiaY As Double)
        Dim mPointView As IPosition71
        Dim State As String '= String.Empty
        Try
            Dim TextFile As StreamReader = Nothing
            TextFile = New StreamReader(PathData & "\State.ini", True)
            State = TextFile.ReadLine()
            TextFile.Close()
            Dim mPitch As Double = 340, Y As Double = Val(State.Split(";")(0).Split(",")(1)), mAtututde As Double = 15000 * Tyle
            Y -= 0.025
            If Bd3D = True Then
                If sgworldK Is FrmMain.Instance.sgworldMain Then
                    mAtututde *= 2
                End If
            End If
            Y += sogiaY
            mPointView = sgworldK.Creator.CreatePosition(Val(State.Split(";")(0).Split(",")(0)), Y, mAtututde, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, mPitch, 0, 0) ', 0, 5000)
            FrmMain.Instance.cbGiaidoan.SelectedIndex = Val(State.Split(";")(1))
            FrmMain.Instance.cbTylebando.SelectedIndex = Val(State.Split(";")(2))
            FrmMain.Instance.cbTa_DP.SelectedIndex = Val(State.Split(";")(3))
            FrmMain.Instance.cbChieuKH.SelectedIndex = Val(State.Split(";")(4))
            FrmMain.Instance.cbHienthiToado.SelectedIndex = Val(State.Split(";")(5))
            sgworldK.DateTime.FixedLocalTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 13, 0, 0)
        Catch ex As Exception
            mPointView = sgworldK.Creator.CreatePosition(108.2, 13.2, 5000, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) ', 0, 5000)
            FrmMain.Instance.cbGiaidoan.SelectedIndex = 1
            FrmMain.Instance.cbTylebando.SelectedIndex = 2
            FrmMain.Instance.cbTa_DP.SelectedIndex = 0
            FrmMain.Instance.cbChieuKH.SelectedIndex = 0
            FrmMain.Instance.cbHienthiToado.SelectedIndex = 1
        End Try
        mPointView.Distance = 10000
        sgworldK.Navigate.JumpTo(mPointView)
    End Sub

    Public Sub LenhTD()
        If Lenhve = "" Then
            Exit Sub
        Else
            If Lenhve = "dtChuyendongMH" Or Lenhve = "mohinhnguoidung" Then
                FrmMain.Instance.CreateArrayWaypoint()
            Else
                FrmMain.Instance.CreateArrayVector()
            End If
        End If
        FrmMain.Instance.Tinhgoc()
    End Sub

    Public Sub Mausac()
        mauTrang = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 255, 255, 255)
        mauDen = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 0, 255)
        mauH2O = FrmMain.Instance.sgworldMain.Creator.CreateColor(30, 144, 255, 255)
        mauXanh = FrmMain.Instance.sgworldMain.Creator.CreateColor(86, 255, 67, 255)
        mauHH = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 239, 12, 255)
        mauNau = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 100, 0, 255)
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 0 Then
            mauChu = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 0, 255)
            mauXam = FrmMain.Instance.sgworldMain.Creator.CreateColor(145, 145, 145, 255)
            mauRedBlue = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 0, 0, 255)
            mau = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 0, 0, 255)
            mau3 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 255, 255)
            mau3Chu = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 255, 255)
            Select Case FrmMain.Instance.cbGiaidoan.SelectedIndex
                Case 0
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 100, 255, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 255, 255, 255)
                Case 1
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 255, 0, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 180, 255, 255)
                Case 2
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(234, 193, 23, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(30, 144, 255, 255)
                Case 3
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(248, 116, 49, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(67, 110, 238, 255)
                Case 4
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(241, 96, 27, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(24, 116, 205, 255)
                Case 5
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(168, 255, 0, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 155, 155, 255)
                Case 6
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(50, 180, 100, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(50, 180, 100, 255)
            End Select
            FrmMain.Instance.fLabelStyleMain.TextColor = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 0, 255)
            FrmMain.Instance.fLabelStyleMain.BackgroundColor = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 0, 255)
        End If

        If mauKT = True Then
            mau = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 0, 255)
            mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(145, 145, 145, 255)
            mP = "P"
            tenGiaidoan = "1.mkx"
        Else
            mau = mau
            mau2 = mau2
            mP = ""
            tenGiaidoan = tenGiaidoan
        End If

        If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
            mP = ""
            mauChu = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 255, 255)
            mauRedBlue = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 255, 255)
            mau = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 255, 255)
            mau3 = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 0, 0, 255)
            mau3Chu = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 0, 255)
            Select Case FrmMain.Instance.cbGiaidoan.SelectedIndex
                Case 0
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 255, 255, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 100, 255, 255)
                Case 1
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 180, 255, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 255, 0, 255)
                Case 2
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(30, 144, 255, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(234, 193, 23, 255)
                Case 3
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(67, 110, 238, 255)
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(248, 116, 49, 255)
                Case 4
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(241, 96, 27, 255)
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(24, 116, 205, 255)
                Case 5
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(168, 255, 0, 255)
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 155, 155, 255)
                Case 6
                    mau4 = FrmMain.Instance.sgworldMain.Creator.CreateColor(50, 180, 100, 255)
                    mau2 = FrmMain.Instance.sgworldMain.Creator.CreateColor(50, 180, 100, 255)
            End Select
            mauXam = mau2
        End If
        FrmMain.Instance.fLabelStyleMain.TextColor = mauChu
        FrmMain.Instance.fLabelStyleMain.BackgroundColor = mauChu
        FrmMain.Instance.fLabelStyleMain.BackgroundColor.SetAlpha(0)
        '  MsgBox(mauTrang.ToRGBColor.ToString())
    End Sub

#Region "    Group"

    Public Function Gr01(sgworldK As SGWorld71, tenGR As String) As String
        Dim id As String = sgworldK.ProjectTree.FindItem(tenGR)
        If String.IsNullOrWhiteSpace(id) Or String.IsNullOrEmpty(id) Then
            sgworldK.ProjectTree.CreateGroup(tenGR)
        End If

        Dim mGr As String = sgworldK.ProjectTree.FindItem(tenGR)
        Gr01 = mGr
    End Function

    Public Function Gr02(sgworldK As SGWorld71, grB1 As String, tenGR As String) As String
        Gr01(sgworldK, grB1)
        Dim grB2m As String = sgworldK.ProjectTree.FindItem(grB1 & "\" & tenGR)
        If String.IsNullOrWhiteSpace(grB2m) Or String.IsNullOrEmpty(grB2m) Then
            sgworldK.ProjectTree.CreateGroup(tenGR, sgworldK.ProjectTree.FindItem(grB1))
        End If
        Dim mGr As String = sgworldK.ProjectTree.FindItem(grB1 & "\" & tenGR)
        Gr02 = mGr
    End Function

    Public Function Gr03(sgworldK As SGWorld71, grB1 As String, grB2 As String, tenGR As String) As String
        Gr01(sgworldK, grB1)
        Gr02(sgworldK, grB1, grB2)
        Dim grB3m As String = sgworldK.ProjectTree.FindItem(grB1 & "\" & grB2 & "\" & tenGR)
        If String.IsNullOrWhiteSpace(grB3m) Or String.IsNullOrEmpty(grB3m) Then
            sgworldK.ProjectTree.CreateGroup(tenGR, sgworldK.ProjectTree.FindItem(grB1 & "\" & grB2))
        End If
        Dim mGr As String = sgworldK.ProjectTree.FindItem(grB1 & "\" & grB2 & "\" & tenGR)
        Gr03 = mGr
    End Function

    Public Function Gr04(sgworldK As SGWorld71, grB1 As String, grB2 As String, grB3 As String, tenGR As String) As String
        Gr01(sgworldK, grB1)
        Gr02(sgworldK, grB1, grB2)
        Gr03(sgworldK, grB1, grB2, grB3)
        Dim grB4m As String = sgworldK.ProjectTree.FindItem(grB1 & "\" & grB2 & "\" & grB3 & "\" & tenGR)
        If String.IsNullOrWhiteSpace(grB4m) Or String.IsNullOrEmpty(grB4m) Then
            sgworldK.ProjectTree.CreateGroup(tenGR, sgworldK.ProjectTree.FindItem(grB1 & "\" & grB2 & "\" & grB3))
        End If
        Dim mGr As String = sgworldK.ProjectTree.FindItem(grB1 & "\" & grB2 & "\" & grB3 & "\" & tenGR)
        Gr04 = mGr
    End Function

    Public Function ChonGrB2_DT(sgworldK As SGWorld71, DT As ITerraExplorerObject71) As String
        Dim mGr As String = sgworldK.ProjectTree.GetNextItem(DT.ID, ItemCode.PARENT)
        ChonGrB2_DT = mGr
    End Function

    Public Sub XoaGrB2_DT(sgworldK As SGWorld71, DT As ITerraExplorerObject71)
        sgworldK.ProjectTree.DeleteItem(ChonGrB2_DT(sgworldK, DT))
    End Sub

    Public Sub XoaGr(sgworldK As SGWorld71, ChuoiDT As String)
        If ChuoiDT = "" Then
            MsgBox("Chưa có Group được chọn!!!...", MsgBoxStyle.Critical, "Chú ý...")
            Lenhve = ""
            Exit Sub
        Else
            sgworldK.ProjectTree.DeleteItem(sgworldK.ProjectTree.FindItem(ChuoiDT))
        End If
    End Sub

#End Region

#Region "    Tran dia"
    Public Sub TrandiaDaidoi(K3 As IPosition71, pChu As IPosition71, Goc As Double)
        pChu.Yaw = 0
        Dim ghichu As String = String.Empty
        Try
            MCircleTQ(K3, 360 - Dorongduong / Tyle, 4294967295, Dorongduong * 0.9, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, -1)
            If FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 1 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 1 Then
                MCircleTQ(K3, 360, 4294967295, Dorongduong * 0.9, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 2 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 2 Then
                MARCTQ(K3, 360, Goc, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 360, Goc + 90, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 360, Goc + 180, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 360, Goc + 270, 4294967295, Dorongduong * 0.9, mau, 2)
                ghichu = "db"
            ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 3 Then
                MCircleTQ(K3, 360, 4294967295, Dorongduong * 0.9, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                MARCTQ(K3, 428, Goc, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 428, Goc + 120, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 428, Goc + 240, 4294967295, Dorongduong * 0.9, mau, 2)
                ghichu = "lt"
            ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 4 Then
                MARCTQ(K3, 360, Goc, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 360, Goc + 120, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 360, Goc + 240, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 428, Goc, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 428, Goc + 120, 4294967295, Dorongduong * 0.9, mau, 2)
                MARCTQ(K3, 428, Goc + 240, 4294967295, Dorongduong * 0.9, mau, 2)
                ghichu = "gi"
            End If
            If Not Lenhve = "TaungamPB" And ghichu <> "" Then
                MakeText(pChu, 0, FrmMain.Instance.fLabelStyleMain.Scale * 0.8, 0, "      " & ghichu, "", mau, 1, 1, 1, 2)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub TrandiaTrungdoi(K3 As IPosition71, pChu As IPosition71, Goc1 As Double)
        Dim ghichu As String = String.Empty
        Dim hesoTyle As Double = Tyle * 8.3
        pChu.Yaw = 0
        Dim pTrandia(30) As IPosition71
        Try
            pTrandia(1) = K3.Move(41.5 * hesoTyle, 9.9 + Goc1, 0)
            pTrandia(2) = K3.Move(58.22 * hesoTyle, 45 + Goc1, 0)
            pTrandia(3) = K3.Move(41.5 * hesoTyle, 80.1 + Goc1, 0)
            pTrandia(4) = K3.Move(42.5 * hesoTyle, 99.9 + Goc1, 0)
            pTrandia(5) = K3.Move(58.22 * hesoTyle, 135 + Goc1, 0)
            pTrandia(6) = K3.Move(41.5 * hesoTyle, 170.1 + Goc1, 0)
            pTrandia(7) = K3.Move(41.5 * hesoTyle, 189.9 + Goc1, 0)
            pTrandia(8) = K3.Move(58.22 * hesoTyle, 225 + Goc1, 0)
            pTrandia(9) = K3.Move(41.5 * hesoTyle, 260.1 + Goc1, 0)
            pTrandia(10) = K3.Move(41.5 * hesoTyle, 279.9 + Goc1, 0)
            pTrandia(11) = K3.Move(58.22 * hesoTyle, 315 + Goc1, 0)
            pTrandia(12) = K3.Move(41.5 * hesoTyle, 350.1 + Goc1, 0)

            pTrandia(13) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 9.9 + Goc1, 0)
            pTrandia(14) = K3.Move(1.65 * Dorongduong + 55.2 * hesoTyle, 45 + Goc1, 0)
            pTrandia(15) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 80.1 + Goc1, 0)
            pTrandia(16) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 99.9 + Goc1, 0)
            pTrandia(17) = K3.Move(1.65 * Dorongduong + 55.2 * hesoTyle, 135 + Goc1, 0)
            pTrandia(18) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 170.1 + Goc1, 0)
            pTrandia(19) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 189.9 + Goc1, 0)
            pTrandia(20) = K3.Move(1.65 * Dorongduong + 55.2 * hesoTyle, 225 + Goc1, 0)
            pTrandia(21) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 260.1 + Goc1, 0)
            pTrandia(22) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 279.9 + Goc1, 0)
            pTrandia(23) = K3.Move(1.65 * Dorongduong + 55.2 * hesoTyle, 315 + Goc1, 0)
            pTrandia(24) = K3.Move(1.65 * Dorongduong + 36.5 * hesoTyle, 350.1 + Goc1, 0)

            pTrandia(25) = K3.Move(58.22 * hesoTyle - Dorongduong * 0.8, 45 + Goc1, 0)
            pTrandia(26) = K3.Move(58.22 * hesoTyle - Dorongduong * 0.8, 135 + Goc1, 0)
            pTrandia(27) = K3.Move(58.22 * hesoTyle - Dorongduong * 0.8, 225 + Goc1, 0)
            pTrandia(28) = K3.Move(58.22 * hesoTyle - Dorongduong * 0.8, 315 + Goc1, 0)
            pTrandia(29) = K3.Move(58.22 * hesoTyle - Dorongduong * 0.8, 45 + Goc1, 0)
            Dim liTdiaTrDoi As New List(Of IPosition71)() From {pTrandia(2), pTrandia(5), pTrandia(8), pTrandia(11), pTrandia(2)}
            FDuong(pTrandia, 25, 29, 4294967295, "", 0, 0, mau2, Dorongduong * 0.8, False, 2, 0, -1) ', False) ' duong =

            If FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 5 Then
                FDuongList(liTdiaTrDoi, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2) ' 2, False, 2)
            ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 6 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 6 Then
                FDuong(pTrandia, 1, 3, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 4, 6, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 7, 9, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 10, 12, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                ghichu = "db"
            ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 7 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 7 Then
                FDuong(pTrandia, 13, 15, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 16, 18, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 19, 21, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 22, 24, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuongList(liTdiaTrDoi, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                ghichu = "lt"
            ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 8 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 8 Then
                FDuong(pTrandia, 1, 3, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 4, 6, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 7, 9, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 10, 12, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 13, 15, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 16, 18, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 19, 21, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                FDuong(pTrandia, 22, 24, 4294967295, "", 0, 0, mau, Dorongduong * 0.8, False, 2, 0, 2)
                ghichu = "gi"
            End If
            If Not Lenhve = "TaungamPB" And ghichu <> "" Then
                MakeText(pChu, 0, FrmMain.Instance.fLabelStyleMain.Scale * 0.8, 0, "      " & ghichu, "", mau, 1, 1, 1, 2)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub TDTenluaCC(P As IPosition71, Goc As Double, Rong As Double, Rongduong As Double, Cmau As IColor71, Cmau2 As IColor71)
        Try
            Dim Pc As IPosition71 = P.Move(Rong * 2, 180 + Goc, 0)
            Dim Pt As IPosition71 = P.Move(Rong, 90 + Goc, 0)
            Dim Pp As IPosition71 = P.Move(Rong, 270 + Goc, 0)
            Dim Pt1 As IPosition71 = Pt.Move(Dorongduong * 2, 45 + FGoc(Pt, Pp), 0)
            Dim Pp1 As IPosition71 = Pp.Move(Dorongduong * 2, 135 + FGoc(Pt, Pp), 0)
            Dim LiCo As New List(Of IPosition71) From {Pc, Pt1, Pt, Pp, Pp1}
            Dim Geo As IGeometry = ListtoGeo(LiCo).SpatialOperator.buffer(-1.0 * Rongduong)
            Dim LiD As List(Of IPosition71) = GeoToList(Geo)
            LiD.RemoveRange(LiD.Count - 1, 1)
            LiD.RemoveRange(0, 1)
            Dim Pk1 As IPosition71 = LiD(2).Move(Dorongduong * 1.5, FGoc(LiD(3), LiD(2)), 0)
            Dim Pk2 As IPosition71 = LiD(1).Move(Dorongduong * 1.5, FGoc(LiD(0), LiD(1)), 0)
            LiD.Add(Pk1)
            LiD.Reverse()
            LiD.Add(Pk2)
            LiCo.RemoveRange(0, 1)
            FDuongList(LiCo, 4294967295, "", 0, 0, Cmau, Rongduong, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(LiD, 4294967295, "", 0, 0, Cmau2, Rongduong, False, 2, 0, 2) ' 2, False, 2)
        Catch ex As Exception
        End Try
    End Sub

#End Region

#Region "     Vung HL"

    Public Sub VongHL()
        TdXY.Clear()
        Dim Phl2D As IPosition71 ', PhlA3D As IPosition71, PhlBd3D As IPosition71
        Dim DT As ITerraExplorerObject71 = FrmMain.Instance.sgworldMain.ProjectTree.GetObject(FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text))
        TdXY.Add(DT.Position.X)
        TdXY.Add(DT.Position.y)
        Phl2D = FrmMain.Instance.sgworldMain.Creator.CreatePosition(DT.Position.X, DT.Position.Y, Val(Trim(FrmMain.Instance.txtDocaoPK.Text)), AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0)
        Dim liHL As List(Of IPosition71) = LiPVungQS(Phl2D, 1000 * Val(FrmMain.Instance.txtTamPK.Text), Val(FrmMain.Instance.txtDocaoPK.Text), Val(FrmMain.Instance.txtGocduoiPK.Text))
        Dim Geo As IGeometry = ListtoGeo(liHL).SpatialOperator.buffer(-Dorongduong * 4)
        Dim mauDuong As IColor71
        If mota = "Vùng Hỏa lực" Or mota = "Vùng Dẫn đường" Then
            mauDuong = mau
        Else mauDuong = mauXanh
        End If

        FVungList(liHL, 4294967295, Dorongduong * 4, mauDuong, 1, mauDuong, 0.25, "", 0, 0, 0, False, 2, 2)
        FVungList(GeoToList(Geo), 4294967295, Dorongduong * 4, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)

        If FrmMain.Instance.chebVeHL.Checked = True Then
            VungHL3D(FrmMain.Instance.sgworldMain)
        End If
        FrmMain.Instance.panelVungHL.Visible = False
    End Sub

    Function LiPVungQS(pk As IPosition71, Bankinh As Double, h As Double, Gd As Double) As List(Of IPosition71)
        'Qua chuan khong can chinh
        Dim mList, mList1 As New List(Of IPosition71)
        Dim pos As IPosition71
        pk.Altitude += h
        pk.ChangeAltitudeType(3)
        Dim M1 As I3DViewshed71 = FrmMain.Instance.sgworldMain.Analysis.Create3DViewshed(pk, 360, 90, Bankinh, GroupBac2Main, tenKH) ' SGWorld.ProjectTree.HiddenGroupID, SGLang.i18n("Text25"));
        M1.Quality = 2
        FrmMain.Instance.sgworldMain.Analysis.StartViewshedVisibilityQuery(M1.ID)
        For mYaw As Double = 0 To 360 Step Val(Trim(FrmMain.Instance.txtGocQuet.Text))
            mList.Clear()
            For mPitch As Double = -20 To Gd Step Val(Trim(FrmMain.Instance.txtGocQuet.Text))
                pos = pk.Move(Bankinh, mYaw, mPitch)
                pos.ChangeAltitudeType(3)
                Dim PointVisible = FrmMain.Instance.sgworldMain.Analysis.QueryVisibilityDistance(pos)
                If PointVisible <= Bankinh Then ' AndAlso PointVisible > 5 Then '
                    If mPitch = Gd + 1 Then
                        pos = pk.Move(PointVisible, mYaw, mPitch)
                        pos.ChangeAltitudeType(3)
                        mList.Add(pos)
                    End If
                    pos = pk.Move(PointVisible, mYaw, mPitch)
                    pos.ChangeAltitudeType(3)
                    mList.Add(pos)
                End If
            Next
            mList1.Add(mList(mList.Count - 1))
        Next
        FrmMain.Instance.sgworldMain.Creator.DeleteObject(M1.ID)
        LiPVungQS = mList1
    End Function

    Public Sub VungHL3D(sgworldK As SGWorld71)
        Dim pk As IPosition71 = sgworldK.Creator.CreatePosition(TdXY(0), TdXY(1), Val(Trim(FrmMain.Instance.txtDocaoPK.Text)), AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0)
        Dim mList1, mList2 As New List(Of IPosition71)
        Dim pos As IPosition71
        pk.Altitude += Val(FrmMain.Instance.txtDocaoPK.Text)
        For mPitch As Double = Val(Trim(FrmMain.Instance.txtGocduoiPK.Text)) To Val(Trim(FrmMain.Instance.txtGoctrenPK.Text)) Step Val(Trim(FrmMain.Instance.txtGocQuet.Text))
            For mYaw As Double = 0 To 360 Step Val(Trim(FrmMain.Instance.txtGocQuet.Text))
                pos = pk.Move(Val(Trim(FrmMain.Instance.txtTamPK.Text) * 1000), mYaw, mPitch)
                pos.ChangeAltitudeType(3)
                mList1.Add(pos)
                If mPitch = Val(Trim(FrmMain.Instance.txtGocduoiPK.Text)) Then
                    mList2.Add(pos)
                    mList2.Add(pk)
                End If
            Next
        Next
        Dim mGroupB2 As String
        If tenMayNet = "" Then
            mGroupB2 = Gr03(sgworldK, System.Environment.MachineName, Giaidoan, tenKH & "3D")
        Else
            mGroupB2 = Gr03(sgworldK, tenMayNet, GiaidoanNet, tenKH & "3D")
        End If
        Dim mauDuong As IColor71
        If mota = "Vùng Hỏa lực" Or mota = "Vùng Dẫn đường" Then
            mauDuong = mau
        Else
            mauDuong = mauXanh
        End If

        CrVungHL(sgworldK, mList1, mauNau, mauDuong, Dorongduong * 4, mGroupB2, tenKH & "3D1")
        CrVungHL(sgworldK, mList2, mauNau, mauDuong, Dorongduong * 4, mGroupB2, tenKH & "3D2")
    End Sub

    Private Sub CrVungHL(sgworldK As SGWorld71, mList As List(Of IPosition71), colorLine As IColor71, colorFill As IColor71, mRong As Double, mGroupB2 As String, Ten As String)
        Dim cPolygon2 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygonFromArray(ListtoAarray(mList), colorLine, colorFill, AltitudeTypeCode.ATC_TERRAIN_ABSOLUTE, mGroupB2, Ten)
        cPolygon2.LineStyle.Pattern = 3284386755
        cPolygon2.LineStyle.Width = mRong
        cPolygon2.FillStyle.Color.SetAlpha(0.05)
        cPolygon2.Terrain.DrawOrder = 2
        cPolygon2.Tooltip.Text = mota
    End Sub


#End Region

#Region "   Duong"

    Public Function FDuong(fPoint() As IPosition71, i1 As Integer, i2 As Integer, mLineStylePattern As UInteger, mTexture As String, mXscale As Double, mYscale As Double, mauDuong As IColor71, Dorong As Double, mSpline As Boolean, mATC As Integer, mDocao As Double, mOrder As Double) As ITerrainPolyline71
        Dim listsPoint As New List(Of IPosition71)()
        For j As Integer = i1 To i2
            listsPoint.Add(fPoint(j))
        Next
        Dim mLine As ITerrainPolyline71 = FDuongArray(ListtoAarray(listsPoint), mLineStylePattern, mTexture, mXscale, mYscale, mauDuong, Dorong, mSpline, mATC, mDocao, mOrder)
        FDuong = mLine
    End Function

    Public Function FDuongList(listsPoint As List(Of IPosition71), mLineStylePattern As UInteger, mTexture As String, mXscale As Double, mYscale As Double, mauDuong As IColor71, Dorong As Double, mSpline As Boolean, mATC As Integer, mDocao As Double, mOrder As Double) ' As ITerrainPolyline71
        Dim mLine As ITerrainPolyline71 = FDuongArray(ListtoAarray(listsPoint), mLineStylePattern, mTexture, mXscale, mYscale, mauDuong, Dorong, mSpline, mATC, mDocao, mOrder)
        ' listsPoint.Clear()
        FDuongList = mLine
    End Function

    Public Function FDuongArray(pVts() As Double, mLineStylePattern As UInteger, mTexture As String, mXscale As Double, mYscale As Double, mauDuong As IColor71, Dorong As Double, mSpline As Boolean, mATC As Integer, mDocao As Double, mOrder As Double) As ITerrainPolyline71
        Dim mLine As ITerrainPolyline71 = FrmMain.Instance.sgworldMain.Creator.CreatePolylineFromArray(pVts, mauDuong, mATC, GroupBac2Main, tenKH)
        LineTQ(mLine, mLineStylePattern, mTexture, mXscale, mYscale, mauDuong, Dorong, mSpline, mATC, mDocao, mOrder)
    End Function

    Private Sub LineTQ(mLine As ITerrainPolyline71, mLineStylePattern As UInteger, mTexture As String, mXscale As Double, mYscale As Double, mauDuong As IColor71, Dorong As Double, mSpline As Boolean, mATC As Integer, mDocao As Double, mOrder As Double)
        mLine.LineStyle.Pattern = mLineStylePattern
        mLine.Position.AltitudeType = mATC
        mLine.Position.Altitude = mDocao
        mLine.FillStyle.Texture.FileName = mTexture
        mLine.FillStyle.Texture.ScaleX = mXscale
        mLine.FillStyle.Texture.ScaleY = mYscale
        mLine.LineStyle.Width = Dorong
        mLine.LineStyle.Color = mauDuong
        mLine.Terrain.DrawOrder = mOrder

        mLine.Spline = mSpline
        mLine.Tooltip.Text = mota
        LineStyle(mLine)
        If FrmMain.Instance.ChebTron.Checked = True Then
            mLine.Spline = True
        End If
        If Lenhve = "hangraobungnhung" Then
            mLineArrayHR.Add(mLine)
            If Bd3D = True Then
                mLine.Position.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
            End If
        Else
            mLineArray.Add(mLine)
        End If
        FrmMain.Instance.SendLine(mLine)
    End Sub

#End Region

#Region "   Vung"

    Public Function VungFormGeo(Geo As IGeometry, mLineStylePattern As UInteger, Dorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Double, mauVung As IColor71, mSetAlphaVung As Double, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double) As ITerrainPolygon71
        Dim ThutuDT As String
        If mauVung Is mau2 Or mauVung Is mau4 Then
            ThutuDT = "2"
        Else
            ThutuDT = "1"
        End If
        Dim mRegion As ITerrainPolygon71 = FrmMain.Instance.sgworldMain.Creator.CreatePolygon(Geo, mauDuong, mauVung, mATC, GroupBac2Main, tenKH & ThutuDT)
        DefindReGion(mRegion, mLineStylePattern, Dorongduong, mauDuong, mSetAlphaDuong, mauVung, mSetAlphaVung, filePaternVung, xScale, yScale, mRotate, Tron, mATC, mOrder)
    End Function

    Function DefindReGion(mRegion As ITerrainPolygon71, mLineStylePattern As UInteger, Dorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Double, mauVung As IColor71, mSetAlphaVung As Double, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double) As ITerrainPolygon71
        Try
            mRegion.Tooltip.Text = mota
            mRegion.Position.AltitudeType = mATC
            mRegion.LineStyle.Pattern = mLineStylePattern
            mRegion.LineStyle.Width = Dorongduong
            mRegion.LineStyle.Color = mauDuong
            mRegion.LineStyle.Color.SetAlpha(mSetAlphaDuong)
            mRegion.FillStyle.Color = mauVung
            mRegion.FillStyle.Color.SetAlpha(mSetAlphaVung)
            mRegion.Spline = Tron
            mRegion.Terrain.DrawOrder = mOrder
            If filePaternVung <> "" Then
                mRegion.FillStyle.Texture.FileName = PathData & "\Textures\" & filePaternVung
                mRegion.FillStyle.Texture.ScaleX = xScale
                mRegion.FillStyle.Texture.ScaleY = yScale
                mRegion.FillStyle.Texture.RotateAngle = mRotate
                mRegion.FillStyle.Texture.TilingMethod = TilingMethodCode.TM_TILES_PER_AXIS
            End If
            DefindReGion = mRegion
            mRegionArray.Add(mRegion)
            FrmMain.Instance.SendVung(mRegion)
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Public Function FVungPoint(fPoint() As IPosition71, i1 As Integer, i2 As Integer, mLineStylePattern As UInteger, Dorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Double, mauVung As IColor71, mSetAlphaVung As Double, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double)
        Dim listsPoint As New List(Of IPosition71)
        For j As Integer = i1 To i2
            listsPoint.Add(fPoint(j))
        Next
        Dim mRegion As ITerrainPolygon71 = FVungList(listsPoint, mLineStylePattern, Dorongduong, mauDuong, mSetAlphaDuong, mauVung, mSetAlphaVung, filePaternVung, xScale, yScale, mRotate, Tron, mATC, mOrder)
        FVungPoint = mRegion
    End Function

    Public Function FVungList(listsPoint As List(Of IPosition71), mLineStylePattern As UInteger, Dorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Double, mauVung As IColor71, mSetAlphaVung As Double, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double) 'As ITerrainPolygon71
        Dim ThutuDT As String = ""
        If mauVung Is mau2 Or mauVung Is mau4 Then
            If Not Lenhve = "Doituongvung" Then
                ThutuDT = "2"
            End If
        Else
            If Not Lenhve = "vekhung" Then
                ThutuDT = "1"
            End If
        End If

        'Dim TenDT As String = ""
        'If Not Lenhve = "vekhung" And Not Lenhve = "Trinhbay" Then
        '    TenDT = tenKH & "_" & FrmMain.Instance.TxtSochan.Text & ThutuDT
        'Else
        '    TenDT = tenKH
        'End If

        Dim mRegion As ITerrainPolygon71 = FrmMain.Instance.sgworldMain.Creator.CreatePolygonFromArray(ListtoAarray(listsPoint), mauDuong, mauVung, mATC, GroupBac2Main, tenKH & ThutuDT)
        DefindReGion(mRegion, mLineStylePattern, Dorongduong, mauDuong, mSetAlphaDuong, mauVung, mSetAlphaVung, filePaternVung, xScale, yScale, mRotate, Tron, mATC, mOrder)
        FVungList = mRegion
    End Function

    Public Function ListtoAarray(listsPoint As List(Of IPosition71)) As Double()
        Dim cArray(listsPoint.Count * 3 - 1) As Double
        For i As Integer = 0 To listsPoint.Count - 1
            cArray(i * 3) = listsPoint(i).X
            cArray(i * 3 + 1) = listsPoint(i).Y
            cArray(i * 3 + 2) = listsPoint(i).Altitude
        Next
        ListtoAarray = cArray
    End Function

    Public Sub LineStyle(Dtuong As ITerraExplorerObject71)
        Try
            Select Case FrmMain.Instance.cbKieuduong.SelectedIndex
                Case 0
                    Dtuong.LineStyle.Pattern = 4294967295
                Case 1
                    Dtuong.LineStyle.Pattern = 4293922815
                Case 2
                    Dtuong.LineStyle.Pattern = 4278190335
                Case 3
                    Dtuong.LineStyle.Pattern = 4027576335
                Case 4
                    Dtuong.LineStyle.Pattern = 3284386755
                Case 5
                    Dtuong.LineStyle.Pattern = 2576980377
                Case 6
                    Dtuong.LineStyle.Pattern = 2863311530
                Case 7
                    Dtuong.LineStyle.Pattern = 4278288639
                Case 8
                    Dtuong.LineStyle.Pattern = 4278989055
            End Select
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


#End Region

    Public Function MakeText(P As IPosition71, Kc As Double, mScale As Double, Goc As Double, Text As String, cloaiKH As String, mColor As IColor71, mLockMode As Integer, mAltitude As Double, mAltitudeType As Integer, mOrder As Double) As ITerrainLabel71
        Dim cText As ITerrainLabel71, P1 As IPosition71
        If Kc <> 0 Then
            P1 = P.Move(Kc * mScale, 90 - Goc, 0)
        Else
            P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(P.X, P.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 5000)
        End If
        If cloaiKH = "82017" Then
            tenGiaidoan = "1.mkx"
        End If

        If cloaiKH <> "" Then
            If Lenhve = "hamchong" Or Lenhve = "baicocchongtang" Or Lenhve = "tuyenRMbangTrT" Or Lenhve = "kvcophandong" Then
                fileImage = PathData & "\Textures\" & cloaiKH & Ta_Doiphuong & ".gif"
            Else
                fileImage = PathData & "\2X\" & cloaiKH & Ta_Doiphuong & tenGiaidoan
            End If
        Else
            fileImage = ""
        End If
        ' MsgBox(fileImage)
        If Lenhve = "Doituongchu" Or cloaiKH <> "" Then
            FrmMain.Instance.fLabelStyleMain.TextColor = mauChu
            FrmMain.Instance.fLabelStyleMain.BackgroundColor = mauChu
            FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom, Center"
            FrmMain.Instance.fLabelStyleMain.LockMode = LabelLockMode.LM_DECAL
        Else
            FrmMain.Instance.fLabelStyleMain.TextColor = mColor
            FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Center, Center"
            FrmMain.Instance.fLabelStyleMain.LockMode = LabelLockMode.LM_AXIS
            FrmMain.Instance.fLabelStyleMain.BackgroundColor = mColor
        End If
        FrmMain.Instance.fLabelStyleMain.Scale = mScale
        FrmMain.Instance.fLabelStyleMain.LockMode = mLockMode
        FrmMain.Instance.fLabelStyleMain.BackgroundColor.SetAlpha(0)
        'If cloaiKH <> "" Then
        '    FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom, Center"
        '    FrmMain.Instance.fLabelStyleMain.LockMode = LabelLockMode.LM_DECAL
        'Else
        '    FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Center, Center"
        '    FrmMain.Instance.fLabelStyleMain.LockMode = LabelLockMode.LM_AXIS
        'End If
        '  MsgBox(cloaiKH & ",,,,," & fileImage)
        '' FrmMain.Instance.fLabelStyleMain.TextAlignment = "Center, Center"
        cText = FrmMain.Instance.sgworldMain.Creator.CreateLabel(P1, Text, fileImage, FrmMain.Instance.fLabelStyleMain, GroupBac2Main, tenKH)
        cText.Position.AltitudeType = mAltitudeType
        cText.Position.Altitude = mAltitude
        cText.Position.Yaw = Goc
        cText.Tooltip.Text = mota
        cText.Terrain.DrawOrder = mOrder
        cText.Style.LimitScreenSize = False
        MakeText = cText
        mLabelArray.Add(cText)
        FrmMain.Instance.SendLabel(cText)
    End Function

    Public Sub MCircleTQ(P1 As IPosition71, bKinh As Double, mLineStylePattern As UInteger, mDorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Integer, mauVung As IColor71, mSetAlphaVung As Integer, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double)
        Dim liP As New List(Of IPosition71)
        Dim hesoTyle As Double = Tyle * bKinh
        For i As Integer = 0 To 35
            Dim Pk As IPosition71 = P1.Move(hesoTyle, i * 10, 0)
            liP.Add(Pk)
        Next
        If Lenhve = "KvVatcan" Or Lenhve = "ovatcan" Then
            If mauDuong Is mau Then
                Dim LiT As New List(Of IPosition71) From {liP(6), liP(16), liP(17), liP(18), liP(4), liP(3), liP(2), liP(20), liP(21), liP(22), liP(0), liP(35), liP(34), liP(24)}
                FDuongList(LiT, 4294967295, "", 0, 0, mau, Dorongduong * 0.75, False, 2, 0, 4)
            End If
        End If
        FVungList(liP, mLineStylePattern, mDorongduong, mauDuong, mSetAlphaDuong, mauVung, mSetAlphaVung, filePaternVung, xScale, yScale, mRotate, Tron, mATC, mOrder)
        If Lenhve = "ovatcan" Then
            SLenhve3DMs()
        End If
    End Sub

    Public Function LiPCircle(P1 As IPosition71, bKinh As Double, Goc As Double, dGoc As Integer) As List(Of IPosition71)
        Dim liP As New List(Of IPosition71)
        Dim hesoTyle As Double = bKinh
        For i As Integer = 0 To 360 / dGoc - 1
            Dim Pk As IPosition71 = P1.Move(hesoTyle, (Goc - 45) + (i * dGoc), 0)
            liP.Add(Pk)
        Next
        LiPCircle = liP
    End Function

    Public Sub MARCTQ(P1 As IPosition71, bKinh As Double, Goc As Double, mLineStylePattern As UInteger, mDorongduong As Double, mauDuong As IColor71, mOrder As Double)
        Dim k(60) As IPosition71
        Dim hesoTyle As Double = Tyle * bKinh
        Dim i1 As Integer = 0, i2 As Integer = 0
        For i As Integer = 0 To 60
            k(i) = P1.Move(hesoTyle, i * 6 + Goc, 0)
        Next
        If FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 2 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 2 Then
            i1 = 1
            i2 = 14
        ElseIf FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiTrandia.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiTrandiaPK.SelectedIndex = 4 Then
            i1 = 1
            i2 = 19
        End If
        FDuong(k, i1, i2, mLineStylePattern, "", 0, 0, mauDuong, mDorongduong, False, 2, 0, mOrder) ', False) 
    End Sub

    Public Function CrModel(P As IPosition71, NameModel As String, mScale As Double, ten As String) As ITerrainModel71
        Dim Goc2 As Double = Phuongvi * 180.0 / Math.PI
        Dim MH As ITerrainModel71 = FrmMain.Instance.sgworldMain.Creator.CreateModel(P, NameModel, mScale, ModelTypeCode.MT_NORMAL, GroupBac2Main, ten)
        MH.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE

        MH.Position.Altitude = -0.25 * FrmMain.Instance.fLabelStyleMain.Scale
        '  MH.Position.Altitude = Tyle * 10
        MH.Position.Pitch = 0
        MH.Tooltip.Text = mota
        If Lenhve = "mohinhPB" Then
            MH.Position.Yaw = 90 - Goc2
        End If
        mModelArray.Add(MH)
        FrmMain.Instance.SendModel(MH)
        CrModel = MH
    End Function

    Public Function CrCQTrT(P As IPosition71, NameModel As String, mScale As Double, ten As String) As ITerrainModel71
        Dim MH As ITerrainModel71 = FrmMain.Instance.sgworldMain.Creator.CreateModel(P, NameModel, mScale, ModelTypeCode.MT_NORMAL, Gr03(FrmMain.Instance.sgworldMain, System.Environment.MachineName, "TempTrC", "DBDK"), ten)
        MH.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
        MH.Position.Altitude = Tyle * 10
        MH.Position.Pitch = 0
        CrCQTrT = MH
    End Function


#Region "    Sua Doi tuong"

    Public Sub Shape_Polyline()
        If FrmMain.Instance.txtGroup.Text = "" Then
            MsgBox("Chưa có Group được chọn!")
            Exit Sub
        Else

            'If FrmMain.Instance.TxtTenKH.Text = "" Then
            '    MsgBox("Hãy nhập góc quay của group!")
            '    Exit Sub
            'Else
            Dim k0 = FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text)
            'Dim GD As String = FrmMain.Instance.txtGroup.Text.Split("\")(1)
            'Dim TenDT As String = FrmMain.Instance.txtGroup.Text.Split("\")(2)
            'GroupBac2Main = Gr03(FrmMain.Instance.sgworldMain, System.Environment.MachineName, GD, TenDT & "1")
            'Dim P1, Pk2, Pm As IPosition71
            'P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
            Try
                If (FrmMain.Instance.sgworldMain.ProjectTree.IsGroup(k0)) Then
                    k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                    While Not (k0 = Nothing)
                        Dim obj = FrmMain.Instance.sgworldMain.ProjectTree.GetObject(k0)

                        If obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then
                            Dim k2 As ITerrainPolyline71 = obj
                            Dim lists1 As New List(Of IPosition71)
                            Dim ST1() As String = k2.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",") ' k2.Geometry.Clone.Wks.ExportToWKT().Replace("LINESTRING", "").Replace("(", "").Replace(")", "").Split(",")
                            For i As Integer = 0 To ST1.Count - 1
                                Dim Pk As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                lists1.Add(Pk)
                            Next
                        ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
                            Dim lists1 As New List(Of IPosition71)
                            Dim k2 As ITerrainPolygon71 = obj
                            Dim ST1() As String = k2.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")

                            For i As Integer = 0 To ST1.Count - 1
                                Dim Pk As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                lists1.Add(Pk)
                            Next
                        End If
                        k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                    End While
                Else
                End If

            Catch ex As Exception
            End Try
            ''  FrmMain.Instance.sgworldMain.ProjectTree.DeleteItem(FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text))
            '' End If
        End If


    End Sub

    Function PV_ScaleRotateGroup(Pk2 As IPosition71, Pk1 As IPosition71) As Double
        Dim dx, dy, Pv, G1 As Double
        dx = Pk2.X - Pk1.X
        dy = Pk2.Y - Pk1.Y
        If dx = 0.0 Then
            If dx = 0.0 Then
                Pv = 0.0
            ElseIf dy = 0.0 And dx > 0 Then
                Pv = Math.PI / 2.0#
            ElseIf dy = 0.0 And dx < 0 Then
                Pv = Math.PI * 3.0 / 2.0#
            End If
        End If
        G1 = Math.Atan(Math.Abs(dy / dx)) '* 180 / Math.PI
        If (dx > 0) And (dy >= 0) Then Pv = G1 * 180 / Math.PI
        If (dx < 0) And (dy >= 0) Then Pv = (Math.PI - G1) * 180 / Math.PI ' Anfa + Math.PI / 2.0# 'Goc thu tu 
        If (dx < 0) And (dy <= 0) Then Pv = (G1 + Math.PI) * 180 / Math.PI 'Goc thu ba
        If (dx > 0) And (dy <= 0) Then Pv = (Math.PI * 2.0 - G1) * 180 / Math.PI '- Math.PI 'Goc thu tu ba *
        PV_ScaleRotateGroup = Pv
    End Function

    Public Sub RotateGroupTQ()

        If FrmMain.Instance.txtGroup.Text = "" Then
            MsgBox("Chưa có Group được chọn!")
            Exit Sub
        Else

            If FrmMain.Instance.TxtTenKH.Text = "" Then
                MsgBox("Hãy nhập góc quay của group!")
                Exit Sub
            Else
                Dim k0 = FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text)
                Dim GD As String = FrmMain.Instance.txtGroup.Text.Split("\")(1)
                Dim TenDT As String = FrmMain.Instance.txtGroup.Text.Split("\")(2)
                GroupBac2Main = Gr03(FrmMain.Instance.sgworldMain, System.Environment.MachineName, GD, TenDT & "1")
                Dim P1, Pk2, Pm As IPosition71
                P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
                Try
                    If (FrmMain.Instance.sgworldMain.ProjectTree.IsGroup(k0)) Then
                        k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                        While Not (k0 = Nothing)
                            Dim obj = FrmMain.Instance.sgworldMain.ProjectTree.GetObject(k0)
                            If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                                Dim k2 As ITerrainLabel71 = obj
                                FrmMain.Instance.fLabelStyleMain.Scale = k2.Style.Scale
                                FrmMain.Instance.fLabelStyleMain.TextAlignment = k2.Style.TextAlignment
                                FrmMain.Instance.fLabelStyleMain.TextColor = k2.Style.TextColor
                                FrmMain.Instance.fLabelStyleMain.PivotAlignment = k2.Style.PivotAlignment
                                FrmMain.Instance.fLabelStyleMain.FontSize = k2.Style.FontSize
                                Pk2 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, k2.Position.Altitude, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                Dim KC As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, Pk2.X, Pk2.Y)
                                Dim PV As Double = PV_ScaleRotateGroup(Pk2, P1)
                                Pm = P1.Move(KC, 90 - PV + Val(FrmMain.Instance.TxtTenKH.Text), 0)
                                Dim k3 As ITerrainLabel71 = FrmMain.Instance.sgworldMain.Creator.CreateLabel(Pm, TenDT & "1", k2.ImageFileName, FrmMain.Instance.fLabelStyleMain, GroupBac2Main, TenDT & "1")
                                k3.Tooltip.Text = k2.Tooltip.Text
                                k3.Position.AltitudeType = k2.Position.AltitudeType
                                k3.Position.Altitude = k2.Position.Altitude

                            ElseIf obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                                Dim k2 As ITerrainModel71 = obj
                                Pk2 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(k2.Position.X, k2.Position.Y, k2.Position.Altitude, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                Dim KC As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, Pk2.X, Pk2.Y)
                                Dim PV As Double = PV_ScaleRotateGroup(Pk2, P1)
                                Dim k3 As ITerrainModel71 = Nothing
                                Pm = P1.Move(KC, 90 - PV + Val(FrmMain.Instance.TxtTenKH.Text), 0)
                                k3 = FrmMain.Instance.sgworldMain.Creator.CreateModel(Pm, k2.ModelFileName, k2.ScaleFactor, ModelTypeCode.MT_NORMAL, GroupBac2Main, TenDT & "1")
                                k3.Tooltip.Text = k2.Tooltip.Text
                                k3.Position.AltitudeType = k2.Position.AltitudeType
                                k3.Position.Altitude = k2.Position.Altitude

                            ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then
                                Dim P(5000) As IPosition71
                                Dim K(5000) As IPosition71
                                Dim lists1 As New List(Of IPosition71)
                                Dim k2 As ITerrainPolyline71 = obj
                                P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)

                                Dim kc(5000) As Double
                                Dim dMove(5000) As Double
                                Dim dx(5000) As Double
                                Dim dy(5000) As Double
                                Dim G1(5000) As Double
                                Dim PV(5000) As Double
                                Dim ST1() As String = k2.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",") ' k2.Geometry.Clone.Wks.ExportToWKT().Replace("LINESTRING", "").Replace("(", "").Replace(")", "").Split(",")
                                For i As Integer = 0 To ST1.Count - 1
                                    P(i) = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                    PV(i) = PV_ScaleRotateGroup(P(i), P1)
                                    kc(i) = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P(i).X, P(i).Y)
                                    K(i) = P1.Move(kc(i), 90 - PV(i) + Val(FrmMain.Instance.TxtTenKH.Text), 0)
                                    lists1.Add(K(i))
                                Next
                                Dim cArray1(lists1.Count * 3 - 1) As Double
                                For i As Integer = 0 To lists1.Count - 1
                                    cArray1(i * 3) = lists1(i).X
                                    cArray1(i * 3 + 1) = lists1(i).Y
                                    cArray1(i * 3 + 2) = 0
                                Next
                                Dim cRing1 As ILineString = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cArray1)
                                Dim geo1 As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cRing1)
                                Dim cPolyLINE = FrmMain.Instance.sgworldMain.Creator.CreatePolyline(geo1, k2.LineStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, GroupBac2Main, TenDT & "1")
                                cPolyLINE.Tooltip.Text = k2.Tooltip.Text
                                cPolyLINE.LineStyle.Pattern = k2.LineStyle.Pattern
                                cPolyLINE.LineStyle.Width = k2.LineStyle.Width
                                cPolyLINE.LineStyle.Color.SetAlpha(k2.LineStyle.Color.GetAlpha)
                                cPolyLINE.Position.AltitudeType = k2.Position.AltitudeType
                                cPolyLINE.Position.Altitude = k2.Position.Altitude
                            ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
                                Dim P(50000) As IPosition71
                                Dim K(5000) As IPosition71
                                Dim lists1 As New List(Of IPosition71)
                                Dim k2 As ITerrainPolygon71 = obj
                                Dim kc(5000) As Double
                                Dim kc1(5000) As Double
                                Dim dMove(5000) As Double
                                Dim dx(5000) As Double
                                Dim dy(5000) As Double
                                Dim G1(5000) As Double
                                Dim PV(5000) As Double
                                P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                Dim ST1() As String = k2.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")

                                For i As Integer = 0 To ST1.Count - 1
                                    P(i) = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)), Val(ST1(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                    PV(i) = PV_ScaleRotateGroup(P(i), P1)
                                    kc(i) = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P(i).X, P(i).Y)
                                    K(i) = P1.Move(kc(i), 90 - PV(i) + Val(FrmMain.Instance.TxtTenKH.Text), 0)
                                    lists1.Add(K(i))
                                Next
                                Dim cArray1(lists1.Count * 3 - 1) As Double
                                For i As Integer = 0 To lists1.Count - 1
                                    cArray1(i * 3) = lists1(i).X
                                    cArray1(i * 3 + 1) = lists1(i).Y
                                    cArray1(i * 3 + 2) = 0
                                Next
                                Dim cRing1 As ILinearRing = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cArray1)
                                Dim geo1 As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing1, Nothing)
                                Dim cPolygon = FrmMain.Instance.sgworldMain.Creator.CreatePolygon(geo1, k2.LineStyle.Color, k2.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, GroupBac2Main, TenDT & "1")
                                cPolygon.LineStyle.Width = k2.LineStyle.Width
                                cPolygon.Tooltip.Text = k2.Tooltip.Text
                                cPolygon.LineStyle.Pattern = k2.LineStyle.Pattern
                                cPolygon.FillStyle.Color.SetAlpha(k2.FillStyle.Color.GetAlpha)
                                cPolygon.LineStyle.Color.SetAlpha(k2.LineStyle.Color.GetAlpha)
                                cPolygon.Position.AltitudeType = k2.Position.AltitudeType
                                cPolygon.ExtendToGround = k2.ExtendToGround
                                cPolygon.Position.Altitude = k2.Position.Altitude
                                cPolygon.Terrain.DrawOrder = k2.Terrain.DrawOrder
                            End If
                            k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                        End While
                    Else
                    End If
                    mPointMS1 = P1
                Catch ex As Exception
                End Try
                FrmMain.Instance.sgworldMain.ProjectTree.DeleteItem(FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text))
            End If
        End If
    End Sub

    Public Sub CopyGroupTQ()
        If FrmMain.Instance.txtGroup.Text = "" Then
            MsgBox("Chưa có Group được chọn!")
            Exit Sub
        Else
            If FrmMain.Instance.TxtTenKH.Text = "" Then
                MsgBox("Hãy nhập tên đối tượng mới!")
                Exit Sub
            Else
                Try
                    Dim k0 = FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text)
                    Dim TyleX As Double = 0, TyleY As Double = 0
                    Dim GD As String = FrmMain.Instance.txtGroup.Text.Split("\")(1)
                    GroupBac2Main = Gr03(FrmMain.Instance.sgworldMain, System.Environment.MachineName, GD, FrmMain.Instance.TxtTenKH.Text)
                    Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
                    Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
                    TyleX = P2.X - P1.X
                    TyleY = P2.Y - P1.Y
                    If (FrmMain.Instance.sgworldMain.ProjectTree.IsGroup(k0)) Then
                        k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                        While Not (k0 = Nothing)
                            Dim obj = FrmMain.Instance.sgworldMain.ProjectTree.GetObject(k0)
                            If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                                Dim k2 As ITerrainLabel71 = obj
                                FrmMain.Instance.fLabelStyleMain.Scale = k2.Style.Scale
                                FrmMain.Instance.fLabelStyleMain.TextAlignment = k2.Style.TextAlignment
                                FrmMain.Instance.fLabelStyleMain.TextColor = k2.Style.TextColor
                                FrmMain.Instance.fLabelStyleMain.PivotAlignment = k2.Style.PivotAlignment
                                FrmMain.Instance.fLabelStyleMain.FontSize = k2.Style.FontSize
                                Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(k2.Position.X + TyleX, k2.Position.Y + TyleY, k2.Position.Altitude, k2.Position.AltitudeType, k2.Position.Yaw, 0, 0, 5000)
                                Dim k3 As ITerrainLabel71 = FrmMain.Instance.sgworldMain.Creator.CreateLabel(P3, FrmMain.Instance.TxtTenKH.Text, k2.ImageFileName, FrmMain.Instance.fLabelStyleMain, GroupBac2Main, FrmMain.Instance.TxtTenKH.Text)
                                k3.Tooltip.Text = k2.Tooltip.Text
                                k3.Position.AltitudeType = k2.Position.AltitudeType
                                k3.Position.Altitude = k2.Position.Altitude
                                k3.Style.FontSize = k2.Style.FontSize
                                k3.Style.FontName = k2.Style.FontName
                                k3.Style.TextColor = k2.Style.TextColor
                                k3.Terrain.DrawOrder = k2.Terrain.DrawOrder
                            ElseIf obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                                Dim k2 As ITerrainModel71 = obj
                                Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(k2.Position.X + TyleX, k2.Position.Y + TyleY, k2.Position.Altitude, k2.Position.AltitudeType, k2.Position.Yaw, 0, 0, 5000)
                                Dim k3 As ITerrainModel71 = FrmMain.Instance.sgworldMain.Creator.CreateModel(P3, k2.ModelFileName, k2.ScaleFactor, ModelTypeCode.MT_NORMAL, GroupBac2Main, FrmMain.Instance.TxtTenKH.Text)
                                k3.Position.X = k2.Position.X + TyleX
                                k3.Position.Y = k2.Position.Y + TyleY
                                k3.Tooltip.Text = k2.Tooltip.Text
                                k3.Position.Yaw = k2.Position.Yaw
                                k3.Position.Pitch = k2.Position.Pitch
                                k3.Position.Roll = k2.Position.Roll
                                k3.Position.AltitudeType = k2.Position.AltitudeType
                                k3.Position.Altitude = k2.Position.Altitude
                                k3.Terrain.DrawOrder = k2.Terrain.DrawOrder
                            ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then
                                Dim lists1 As New List(Of IPosition71)
                                Dim k2 As ITerrainPolyline71 = obj
                                Dim ST1() As String = k2.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",") ' k2.Geometry.Clone.Wks.ExportToWKT().Replace("LINESTRING", "").Replace("(", "").Replace(")", "").Split(",")

                                For i As Integer = 0 To ST1.Count - 1
                                    Dim M1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)) + TyleX, Val(ST1(i).Split(" ")(2)) + TyleY, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                    lists1.Add(M1)
                                Next
                                Dim cArray1(lists1.Count * 3 - 1) As Double
                                For i As Integer = 0 To lists1.Count - 1
                                    cArray1(i * 3) = lists1(i).X
                                    cArray1(i * 3 + 1) = lists1(i).Y
                                    cArray1(i * 3 + 2) = 0
                                Next
                                Dim cRing1 As ILineString = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cArray1)
                                Dim geo1 As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLineStringGeometry(cRing1)
                                Dim cPolyLINE = FrmMain.Instance.sgworldMain.Creator.CreatePolyline(geo1, k2.LineStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, GroupBac2Main, FrmMain.Instance.TxtTenKH.Text)
                                cPolyLINE.LineStyle.Pattern = k2.LineStyle.Pattern
                                cPolyLINE.LineStyle.Width = k2.LineStyle.Width
                                cPolyLINE.Position.AltitudeType = k2.Position.AltitudeType
                                cPolyLINE.Position.Altitude = k2.Position.Altitude
                                cPolyLINE.Terrain.DrawOrder = k2.Terrain.DrawOrder
                                lists1.Clear()
                            ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
                                Dim lists1 As New List(Of IPosition71)
                                Dim k2 As ITerrainPolygon71 = obj
                                Dim ST1() As String = k2.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")

                                For i As Integer = 0 To ST1.Count - 1
                                    Dim M1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST1(i).Split(" ")(1)) + TyleX, Val(ST1(i).Split(" ")(2)) + TyleY, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                                    lists1.Add(M1)
                                Next
                                Dim cArray1(lists1.Count * 3 - 1) As Double
                                For i As Integer = 0 To lists1.Count - 1
                                    cArray1(i * 3) = lists1(i).X
                                    cArray1(i * 3 + 1) = lists1(i).Y
                                    cArray1(i * 3 + 2) = 0
                                Next
                                Dim cRing1 As ILinearRing = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cArray1)
                                Dim geo1 As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing1, Nothing)
                                Dim cPolygon = FrmMain.Instance.sgworldMain.Creator.CreatePolygon(geo1, k2.LineStyle.Color, k2.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, GroupBac2Main, FrmMain.Instance.TxtTenKH.Text)
                                cPolygon.LineStyle.Pattern = k2.LineStyle.Pattern
                                cPolygon.LineStyle.Width = k2.LineStyle.Width
                                cPolygon.FillStyle.Color.SetAlpha(k2.FillStyle.Color.GetAlpha)
                                cPolygon.LineStyle.Color.SetAlpha(k2.LineStyle.Color.GetAlpha)
                                cPolygon.Position.AltitudeType = k2.Position.AltitudeType
                                cPolygon.ExtendToGround = k2.ExtendToGround
                                cPolygon.Position.Altitude = k2.Position.Altitude
                                cPolygon.Terrain.DrawOrder = k2.Terrain.DrawOrder
                                lists1.Clear()

                            End If
                            k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)

                        End While
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Public Sub MoveGroupTQ()

        If FrmMain.Instance.txtGroup.Text = "" Then
            MsgBox("Chưa có Group được chọn!")
            Exit Sub
        Else
            Try
                Dim k0 = FrmMain.Instance.sgworldMain.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text)
                Dim TyleX As Double = 0, TyleY As Double = 0
                Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                TyleX = P2.X - P1.X
                TyleY = P2.Y - P1.Y
                If (FrmMain.Instance.sgworldMain.ProjectTree.IsGroup(k0)) Then
                    k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.CHILD)
                    While Not (k0 = Nothing)
                        Dim obj = FrmMain.Instance.sgworldMain.ProjectTree.GetObject(k0)
                        ' tenDT = sgworldMain.ProjectTree.GetItemName(obj.ID)
                        If obj.ObjectType = ObjectTypeCode.OT_LABEL Then
                            Dim k2 As ITerrainLabel71 = obj
                            k2.Position.X = k2.Position.X + TyleX
                            k2.Position.Y = k2.Position.Y + TyleY
                        ElseIf obj.ObjectType = ObjectTypeCode.OT_MODEL Then
                            Dim k2 As ITerrainModel71 = obj
                            k2.Position.X = k2.Position.X + TyleX
                            k2.Position.Y = k2.Position.Y + TyleY
                        ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYLINE Then
                            Dim k2 As ITerrainPolyline71 = obj
                            k2.Position.X = k2.Position.X + TyleX
                            k2.Position.Y = k2.Position.Y + TyleY
                            k2.Position.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
                            k2.Position.Altitude = 0
                        ElseIf obj.ObjectType = ObjectTypeCode.OT_POLYGON Then
                            Dim k2 As ITerrainPolygon71 = obj
                            k2.Position.X = k2.Position.X + TyleX
                            k2.Position.Y = k2.Position.Y + TyleY
                            k2.Position.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
                            k2.Position.Altitude = 0
                        End If
                        k0 = FrmMain.Instance.sgworldMain.ProjectTree.GetNextItem(k0, ItemCode.NEXT)
                    End While
                Else
                End If
                mPointMS1 = P1
                mPointMS2 = P2
                P1 = Nothing
                P2 = Nothing
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Function DTtoList(sgworldK As SGWorld71, DT As ITerraExplorerObject71) As List(Of IPosition71)
        Dim mLists As New List(Of IPosition71)
        Dim ST() As String = Enumerable.Empty(Of String).ToArray
        If DT.ObjectType = ObjectTypeCode.OT_POLYLINE Then
            ST = DT.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
        ElseIf DT.ObjectType = ObjectTypeCode.OT_POLYGON Then
            ST = DT.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")
        End If
        For i As Integer = 0 To ST.Count - 1
            Dim K As IPosition71 = sgworldK.Creator.CreatePosition(Val(ST(i).Split(" ")(1)), Val(ST(i).Split(" ")(2)), Val(ST(i).Split(" ")(3)), 2, 0, 0, 0, 0)
            mLists.Add(K)
        Next
        DTtoList = mLists
    End Function

    Function DTtoArray(sgworldK As SGWorld71, DT As ITerraExplorerObject71) As Double()
        Dim mLists As New List(Of IPosition71)
        Dim ST() As String = Enumerable.Empty(Of String).ToArray
        If DT.ObjectType = ObjectTypeCode.OT_POLYLINE Then
            ST = DT.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
        ElseIf DT.ObjectType = ObjectTypeCode.OT_POLYGON Then
            ST = DT.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")
        End If
        For i As Integer = 0 To ST.Count - 1
            Dim k As IPosition71 = sgworldK.Creator.CreatePosition(Val(ST(i).Split(" ")(1)), Val(ST(i).Split(" ")(2)), Val(ST(i).Split(" ")(3)), AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0)
            mLists.Add(k)
        Next
        Dim cArray(mLists.Count * 3 - 1) As Double
        For j As Integer = 0 To mLists.Count - 1
            cArray(j * 3) = mLists(j).X
            cArray(j * 3 + 1) = mLists(j).Y
            cArray(j * 3 + 2) = mLists(j).Altitude
        Next
        DTtoArray = cArray
    End Function

    Function GeoformDT(sgworldK As SGWorld71, DT As ITerraExplorerObject71) As IGeometry
        Dim mGeo As IGeometry 'Or Lenhve = "KvDoiTu"
        If Lenhve = "vungtoduong" Or Lenhve = "catduong" Or Lenhve = "noiduong" Or
           Lenhve = "KVdongquan" Or Lenhve = "giaothonghao" Or Lenhve = "Duonghanhquan" Or Lenhve = "Doituongduong" Or Lenhve = "duongbienphong" Or Lenhve = "LineNet" Or
           Lenhve = "tuyendanhchan" Or Lenhve = "kvtsmatdat" Or Lenhve = "kvtstrenkhong" Or Lenhve = "kvTapket" Or Lenhve = "kvTochucDoihinh" Or Lenhve = "kvCodong" Or
           Lenhve = "kvTuantieu" Or Lenhve = "veduongsongsong" Or Lenhve = "kvTamdung" Or Lenhve = "vetNXdudoan" Or Lenhve = "vetNXthucte" Or Lenhve = "KvDoiTu" Or
           Lenhve = "doboduongkhong" Or Lenhve = "kvkhoinguytrang" Or Lenhve = "tuyenkhoinguytrang" Or Lenhve = "kvVaybat" Or Lenhve = "kvTKHHdukien" Or Lenhve = "catduong" Or Lenhve = "noiduong" Then
            Dim cRing As ILineString = sgworldK.Creator.GeometryCreator.CreateLineStringGeometry(DTtoArray(sgworldK, DT))
            mGeo = sgworldK.Creator.GeometryCreator.CreateLineStringGeometry(cRing)
        Else
            Dim cRing As ILinearRing = sgworldK.Creator.GeometryCreator.CreateLinearRingGeometry(DTtoArray(sgworldK, DT))
            mGeo = sgworldK.Creator.GeometryCreator.CreatePolygonGeometry(cRing, 0)
        End If
        GeoformDT = mGeo
    End Function

    Public Sub SXoaDTCat(sgworldK As SGWorld71)
        If xoaDTcat = True Then
            If Not Lenhve = "vungtoduong" And Not Lenhve = "duongtovung" Then
                sgworldK.ProjectTree.DeleteItem(sgworldK.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text.Split(",")(1))) ' & "\" & FrmMain.Instance.txtGroup.Text.Split(",")(1).Split("\")(2)))
            End If
        End If
    End Sub

    Public Sub Suavung(sgworldK As SGWorld71, MLenh As String)
        Dim NhomBicat As String, NhomCat As String = ""
        Dim geoBiCat As IGeometry, geoCat As IGeometry = Nothing
        Dim BiCat As ITerrainPolygon71 = Nothing, Cat As ITerrainPolygon71 = Nothing
        If FrmMain.Instance.txtGroup.Text.Contains(",") Then
            NhomBicat = FrmMain.Instance.txtGroup.Text.Split(",")(0)
            NhomCat = FrmMain.Instance.txtGroup.Text.Split(",")(1)
            If Not MLenh = "gopvung2" Then
                Cat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomCat & "\" & NhomCat.Split("\")(2)))
                geoCat = GeoformDT(sgworldK, Cat)
            End If
        Else
            NhomBicat = FrmMain.Instance.txtGroup.Text '.Split(",")(0).Split("\")(0) & "\" & FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(1) & "\" & FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(2)
            BiCat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2)))
        End If
        If MLenh = "catvung" Then
            BiCat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2)))
            geoBiCat = GeoformDT(sgworldK, BiCat)
            Dim geoKQ As IGeometry = geoBiCat.SpatialOperator.Difference(geoCat)
            Dim cPolygon1 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ, BiCat.LineStyle.Color, BiCat.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name) 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon1.Tooltip.Text = BiCat.Tooltip.Text
            sgworldK.ProjectTree.DeleteItem(BiCat.ID)
        ElseIf MLenh = "catvung2" Then
            Dim BiCat1 As ITerrainPolygon71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2) & "1"))
            Dim BiCat2 As ITerrainPolygon71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2) & "2"))
            Dim geoBiCat1 As IGeometry = GeoformDT(sgworldK, BiCat1)
            Dim geoBiCat2 As IGeometry = GeoformDT(sgworldK, BiCat2)
            Dim geoKQ1 As IGeometry = geoBiCat1.SpatialOperator.Difference(geoCat)
            Dim cPolygon1 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ1, BiCat1.LineStyle.Color, BiCat1.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat1), BiCat1.TreeItem.Name) 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon1.LineStyle.Width = BiCat1.LineStyle.Width
            cPolygon1.LineStyle.Color.SetAlpha(BiCat1.LineStyle.Color.GetAlpha)
            cPolygon1.Tooltip.Text = BiCat1.Tooltip.Text
            Dim geoKQ2 As IGeometry = geoBiCat2.SpatialOperator.Difference(geoCat)
            Dim cPolygon2 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ2, BiCat2.LineStyle.Color, BiCat2.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat2), BiCat2.TreeItem.Name) 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon2.LineStyle.Width = BiCat2.LineStyle.Width
            cPolygon2.LineStyle.Color.SetAlpha(BiCat2.LineStyle.Color.GetAlpha)
            cPolygon2.Tooltip.Text = BiCat2.Tooltip.Text
            sgworldK.ProjectTree.DeleteItem(BiCat1.ID)
            sgworldK.ProjectTree.DeleteItem(BiCat2.ID)
        ElseIf MLenh = "gopvung" Then
            BiCat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2)))
            geoBiCat = GeoformDT(sgworldK, BiCat)
            Dim geoKQ As IGeometry = geoBiCat.SpatialOperator.Union(geoCat)
            Dim cPolygon1 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ, BiCat.LineStyle.Color, BiCat.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name) 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon1.Tooltip.Text = BiCat.Tooltip.Text
            sgworldK.ProjectTree.DeleteItem(BiCat.ID)
        ElseIf MLenh = "gopvung2" Then
            Dim BiCat1 As ITerrainPolygon71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2) & "1"))
            Dim BiCat2 As ITerrainPolygon71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2) & "2"))
            Dim geoBiCat1 As IGeometry = GeoformDT(sgworldK, BiCat1)
            Dim geoBiCat2 As IGeometry = GeoformDT(sgworldK, BiCat2)

            Dim Cat1 As ITerrainPolygon71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomCat & "\" & NhomCat.Split("\")(2) & "1"))
            Dim Cat2 As ITerrainPolygon71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomCat & "\" & NhomCat.Split("\")(2) & "2"))
            Dim geoCat1 As IGeometry = GeoformDT(sgworldK, Cat1)
            Dim geoCat2 As IGeometry = GeoformDT(sgworldK, Cat2)

            Dim geoKQ1 As IGeometry = geoBiCat1.SpatialOperator.Union(geoCat1)
            Dim cPolygon1 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ1, BiCat1.LineStyle.Color, BiCat1.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat1), NhomBicat.Split("\")(2) & "1") 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon1.LineStyle.Width = BiCat1.LineStyle.Width
            cPolygon1.LineStyle.Color.SetAlpha(BiCat1.LineStyle.Color.GetAlpha)
            cPolygon1.Tooltip.Text = BiCat1.Tooltip.Text
            Dim geoKQ2 As IGeometry = geoBiCat2.SpatialOperator.Union(geoCat2)
            Dim cPolygon2 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ2, BiCat2.LineStyle.Color, BiCat2.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat2), NhomBicat.Split("\")(2) & "2") 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon2.LineStyle.Width = BiCat2.LineStyle.Width
            cPolygon2.LineStyle.Color.SetAlpha(BiCat2.LineStyle.Color.GetAlpha)
            cPolygon2.Tooltip.Text = BiCat2.Tooltip.Text
            sgworldK.ProjectTree.DeleteItem(BiCat1.ID)
            sgworldK.ProjectTree.DeleteItem(BiCat2.ID)
            sgworldK.ProjectTree.DeleteItem(Cat1.ID)
            sgworldK.ProjectTree.DeleteItem(Cat2.ID)
        ElseIf MLenh = "giaovung" Then
            BiCat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2)))
            geoBiCat = GeoformDT(sgworldK, BiCat)
            Dim geoKQ As IGeometry = geoBiCat.SpatialOperator.Intersection(geoCat)
            Dim cPolygon2 As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(geoKQ, BiCat.LineStyle.Color, BiCat.FillStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name) 'FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1)) ' FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\").Length - 1))
            cPolygon2.Tooltip.Text = BiCat.Tooltip.Text
            sgworldK.ProjectTree.DeleteItem(BiCat.ID)
            sgworldK.ProjectTree.DeleteItem(Cat.ID)
        ElseIf MLenh = "vungtoduong" Then
            Dim mLine As ITerrainPolyline71 = sgworldK.Creator.CreatePolylineFromArray(DTtoArray(sgworldK, BiCat), BiCat.LineStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name)
            mLine.LineStyle.Color = BiCat.LineStyle.Color
            mLine.LineStyle.Pattern = BiCat.LineStyle.Pattern
            mLine.LineStyle.Width = BiCat.LineStyle.Width
            mLine.Tooltip.Text = BiCat.Tooltip.Text
            sgworldK.ProjectTree.DeleteItem(BiCat.ID)
        End If
        SXoaDTCat(sgworldK)
    End Sub

    Public Sub Suaduong(sgworldK As SGWorld71, MLenh As String)
        Try
            Dim NhomBicat As String, NhomCat As String = ""
            Dim BiCat As ITerrainPolyline71, Cat As ITerrainPolygon71
            Dim geoCat As IGeometry, geoBiCat As IGeometry = Nothing
            If FrmMain.Instance.txtGroup.Text.Contains(",") Then
                NhomBicat = FrmMain.Instance.txtGroup.Text.Split(",")(0)
                NhomCat = FrmMain.Instance.txtGroup.Text.Split(",")(1)
                BiCat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2)))
                geoBiCat = GeoformDT(sgworldK, BiCat)
            Else
                NhomBicat = FrmMain.Instance.txtGroup.Text
                BiCat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomBicat & "\" & NhomBicat.Split("\")(2)))
            End If

            If MLenh = "catduong" Then
                Cat = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(NhomCat & "\" & NhomCat.Split("\")(2)))
                geoCat = GeoformDT(sgworldK, Cat)
                Dim geoKQ As IMultiLineString = geoBiCat.SpatialOperator.Difference(geoCat)
                For i As Integer = 0 To geoKQ.Count.ToString - 1
                    If i Mod 2 = 0 Then
                        Dim mLine As ITerrainPolyline71 = sgworldK.Creator.CreatePolyline(geoKQ(i), BiCat.LineStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name)
                        mLine.Tooltip.Text = BiCat.Tooltip.Text
                        mLineArray.Add(mLine)
                    End If
                Next
                sgworldK.Creator.DeleteObject(BiCat.ID)
            ElseIf MLenh = "noiduong" Then
                Dim DT As ITerrainPolyline71
                Dim mLists As New List(Of IPosition71)
                Dim k(5000) As IPosition71
                Dim ST() As String
                For i As Integer = 0 To FrmMain.Instance.txtGroup.Text.Split(",").Length - 1
                    DT = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text.Split(",")(i) & "\" & FrmMain.Instance.txtGroup.Text.Split(",")(i).Split("\")(2)))
                    ST = DT.Geometry.Wks.ExportToWKT().Replace("LINESTRING Z", "").Replace("(", "").Replace(")", "").Split(",")
                    For j As Integer = 0 To ST.Count - 1
                        k(j) = sgworldK.Creator.CreatePosition(Val(ST(j).Split(" ")(1)), Val(ST(j).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
                        mLists.Add(k(j))
                    Next
                Next
                Dim cArray(mLists.Count * 3 - 1) As Double
                For j As Integer = 0 To mLists.Count - 1
                    cArray(j * 3) = mLists(j).X
                    cArray(j * 3 + 1) = mLists(j).Y
                    cArray(j * 3 + 2) = 0
                Next
                Dim cRing As ILineString = sgworldK.Creator.GeometryCreator.CreateLineStringGeometry(cArray)
                Dim mGeo As IGeometry = sgworldK.Creator.GeometryCreator.CreateLineStringGeometry(cRing)
                Dim mLine As ITerrainPolyline71 = sgworldK.Creator.CreatePolyline(mGeo, BiCat.LineStyle.Color, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name)
                mLine.LineStyle.Color = BiCat.LineStyle.Color
                mLine.LineStyle.Pattern = BiCat.LineStyle.Pattern
                mLine.LineStyle.Width = BiCat.LineStyle.Width
                mLine.Tooltip.Text = BiCat.Tooltip.Text
                mLineArray.Add(mLine)
            ElseIf MLenh = "duongtovung" Then
                Dim cPolygon As ITerrainPolygon71 = sgworldK.Creator.CreatePolygonFromArray(DTtoArray(sgworldK, BiCat), BiCat.LineStyle.Color, mau2, AltitudeTypeCode.ATC_ON_TERRAIN, ChonGrB2_DT(sgworldK, BiCat), BiCat.TreeItem.Name)
                cPolygon.LineStyle.Color = BiCat.LineStyle.Color
                cPolygon.LineStyle.Pattern = BiCat.LineStyle.Pattern
                cPolygon.LineStyle.Width = BiCat.LineStyle.Width
                cPolygon.Tooltip.Text = BiCat.Tooltip.Text
                sgworldK.ProjectTree.DeleteItem(BiCat.ID)
            End If
            SXoaDTCat(sgworldK)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

#End Region

    Public Sub SLenhve3DMs()
        FrmMain.Instance.D23timer.Start()
        FrmMain.Instance.D23timer.Interval = 100
        If Bd3D = True Then
            Lenhve2D = Lenhve
        End If
        If mMicrostation = True Then
            If Lenhve <> "mohinh" Or Lenhve <> "mohinhnguoidung" Or Lenhve <> "dtChuyendongMH" Or Lenhve <> "MHNDchuyendong" Or Lenhve <> "chonDuongtaoChuoiND" Or Lenhve <> "2DTchuyendondoc" Or Lenhve <> "2DTchuyendongngang" Or Lenhve <> "3DTchuyendonTG" Or Lenhve <> "3DTchuyendonTG1" Or Lenhve <> "3DTchuyendonNgang" Or Lenhve <> "3DTchuyendondoc" Then
                lenhveMS = Lenhve
            End If
        End If
    End Sub

    Public Sub ZoomTQ(sgworldK As SGWorld71)
        Dim goc As Double
        If sgworldK Is FrmMain.Instance.sgworldMain Then
            goc = 270
        Else
            goc = 340
        End If

        Dim P1 As IPosition71 = sgworldK.Creator.CreatePosition(FrmMain.Instance.mPointClick.X, FrmMain.Instance.mPointClick.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, goc, 0, 0)
        P1.Distance = 2000 / Tyle
        ' P1.Pitch = -25
        sgworldK.Navigate.FlyTo(P1, ActionCode.AC_FLYTO)
    End Sub

    Public Sub ZoomLAND(sgworldK As SGWorld71, DT As ITerraExplorerObject71)
        Dim goc As Double
        If Bd3D = False Then
            goc = 340
        Else
            If sgworldK Is FrmMain.Instance.sgworldMain Then
                goc = 270
            Else
                goc = 340
            End If
        End If
        If DT.ObjectType = ObjectTypeCode.OT_LABEL Or DT.ObjectType = ObjectTypeCode.OT_IMAGE_LABEL Or DT.ObjectType = ObjectTypeCode.OT_MODEL Then
            goc = goc
        Else
            goc = 270
        End If
        ' Dim P1 As IPosition71 = DT.Position
        mPZoom = sgworldK.Creator.CreatePosition(DT.Position.X, DT.Position.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, goc, 0, 0)
        mPZoom.Distance = 6000
        sgworldK.Navigate.JumpTo(mPZoom)
    End Sub

    Public Function MkGoc(P1 As IPosition71, P2 As IPosition71) As Double
        Dim goc As Double, goc1 As Double = 0
        Dim dx As Double, dy As Double
        dx = P1.X - P2.X
        dy = P1.Y - P2.Y
        If dx = 0.0 Then
            If dy = 0.0 Then
                Phuongvi = 0.0
            ElseIf dy > 0.0 Then
                Phuongvi = Math.PI / 2.0#
            ElseIf dy < 0.0 Then
                Phuongvi = Math.PI * 3.0 / 2.0#
            End If
        End If
        goc = Math.Atan(Math.Abs(dy / dx)) '* 180 / Math.PI
        If (dx > 0) And (dy >= 0) Then goc1 = goc
        If (dx < 0) And (dy >= 0) Then goc1 = Math.PI - goc ' Anfa + Math.PI / 2.0# 'Goc thu tu 
        If (dx < 0) And (dy <= 0) Then goc1 = goc + Math.PI 'Goc thu ba
        If (dx > 0) And (dy <= 0) Then goc1 = Math.PI * 2.0 - goc '- Math.PI 'Goc thu tu ba *
        MkGoc = goc1
    End Function

    Public Function PathLabel(mThumuc As String, mLoaiKH As String, mChieuKH As String, cP As String, cx2 As String, mTa_Doiphuong As String, mtenGiaidoan As String) As String
        Dim Mfile As String = PathData & mThumuc & mChieuKH & cP & cx2 & mLoaiKH & mTa_Doiphuong & mtenGiaidoan
        Dim Kthumuc As String
        If Bd3D = False Then
            Kthumuc = "\2X\"
        Else
            Kthumuc = "\2XD2\"
        End If
        If loaiKH = "261012" Or loaiKH = "261011" Or loaiKH = "261017" Or loaiKH = "261018" Or loaiKH = "261019" Or loaiKH = "261020" Or loaiKH = "261021" Then
            Kthumuc = "\2X\"
        End If
        If loaiKH = "261012" Or loaiKH = "261011" Or loaiKH = "261017" Or loaiKH = "261018" Or loaiKH = "261019" Or loaiKH = "261020" Or loaiKH = "261021" Or Lenhve = "DHPNBB" Or Lenhve = "muctieuthenchot" Or Lenhve = "DHPNBBXT" Then
            Mfile = PathData & Kthumuc & mChieuKH & mLoaiKH & mTa_Doiphuong & mtenGiaidoan '".mkx"
        End If
        PathLabel = Mfile
    End Function

    Public Function FGoc(P1 As IPosition71, P2 As IPosition71) As Double 'Tinh Phuong vi rat chuan, Khong sua
        Dim dx, dy, ta, ata, g12 As Double
        Dim goc As Double = 0
        If P2.X <> 0 Or P2.Y <> 0 Then
            dx = P1.X - P2.X
            dy = P1.Y - P2.Y
        Else
            Exit Function
        End If
        ta = dy / dx
        ata = Math.Atan(ta) * 180 / Math.PI
        g12 = Math.Abs(ata)
        If dx > 0 And dy > 0 Then goc = 90 - g12
        If dx > 0 And dy < 0 Then goc = 90.0 + g12
        If dx < 0 And dy < 0 Then goc = 270.0 - g12
        If dx < 0 And dy > 0 Then goc = 270.0 + g12
        FGoc = goc
    End Function

    Public Function MLoaiKH(mFile As String) As List(Of String)
        Dim dsKH As New List(Of String)
        If mFile = "" Then
            Exit Function
        Else
            Dim cP As String, tenGDFile As String, cMKX As String, cTa_Dp As String, cLoaiKH As String,
                mThumuc As String, tenFile As String, mChieuKH As String = String.Empty
            mThumuc = mFile.Split("\")(mFile.Split("\").Count - 2) '(paraLebel(11).Length - 1)
            cTa_Dp = mFile.Split(".")(0).Substring(mFile.Split(".")(0).Length - 2, 1)
            tenGDFile = mFile.Split(".")(0).Substring(mFile.Split(".")(0).Length - 1, 1)
            tenFile = mFile.Substring(mFile.LastIndexOf("\")).Split("\")(1)
            If tenFile.Contains("P") Then
                tenFile = tenFile.Replace("P", "")
                cP = "P"
                cMKX = "1.mkx"
            Else
                cP = ""
                cMKX = tenGDFile & ".mkx"
            End If
            If tenFile.Contains("N") Then
                tenFile = tenFile.Replace("N", "")
                mChieuKH = "N"
            End If
            If mThumuc = "2XD2" Then
                tenFile = tenFile.Substring(1)
            ElseIf mThumuc = "2X" Then
                tenFile = tenFile
            End If
            cLoaiKH = Mid(tenFile, 1, tenFile.Count - 6)
            dsKH.Add(cP)
            dsKH.Add(mChieuKH)
            dsKH.Add(cLoaiKH)
            dsKH.Add(cTa_Dp)
            dsKH.Add(cMKX)
        End If
        MLoaiKH = dsKH
    End Function

    Function TDo4_o9() As IPosition71
        Dim td As String = Trim(FrmMain.Instance.txtToado.Text)
        Dim mP As IPosition71 = Nothing
        If td <> "" Then
            Dim XVn As Double, YVn As Double
            Dim xKm1 As Integer = 0, yKm1 As Integer = 0,
                mDelta As Integer = 0, m09 As Integer, m09x As Integer = 0, m09y As Integer = 0, m666 As Integer = 666, m333 As Integer = 333
            Dim x1000 As Integer = System.Convert.ToInt32(FrmMain.Instance.txt1000Km.Text.Split(",")(0) & "00000")
            Dim y1000 As Integer = System.Convert.ToInt32(FrmMain.Instance.txt1000Km.Text.Split(",")(1) & "00000")
            Dim xKm As Integer = System.Convert.ToInt32(td.Substring(0, 2) & "000")
            Dim yKm As Integer = System.Convert.ToInt32(td.Substring(2, 2) & "000")

            If td.Length = 4 Then
                mDelta = 500
                m09x = 0
                m09y = 0
            ElseIf td.Length = 5 Then
                mDelta = 175
            End If

            If FrmMain.Instance.cbTylebando.SelectedIndex = 3 Then
                m666 *= 2
                m333 *= 2
                mDelta *= 2
                If (Val(xKm) / 1000 Mod 2 = 0) Then
                    xKm = xKm
                    xKm1 = xKm
                Else
                    xKm1 += 1000
                End If
                If (Val(yKm) / 1000 Mod 2 = 0) Then
                    yKm = yKm
                    yKm1 = yKm
                Else
                    yKm1 += 1000
                End If
            ElseIf FrmMain.Instance.cbTylebando.SelectedIndex = 0 Or FrmMain.Instance.cbTylebando.SelectedIndex = 1 Or FrmMain.Instance.cbTylebando.SelectedIndex = 2 Then
                xKm1 = xKm
                yKm1 = yKm
                mDelta = mDelta
            End If

            m09 = Val(td.Substring(4, 1))
            Select Case m09
                Case 1
                    m09x = m666
                    m09y = 0
                Case 2
                    m09x = m666
                    m09y = m333
                Case 3
                    m09x = m666
                    m09y = m666
                Case 4
                    m09x = m333
                    m09y = m666
                Case 5
                    m09x = 0
                    m09y = m666
                Case 6
                    m09x = 0
                    m09y = m333
                Case 7
                    m09x = 0
                    m09y = 0
                Case 8
                    m09x = m333
                    m09y = 0
                Case 9
                    m09x = m333
                    m09y = m333
            End Select

            XVn = x1000 + xKm1 + m09x + mDelta
            YVn = y1000 + yKm1 + m09y + mDelta
            Chuyendoi_XYZVN2000_to_BLHWGS84(XVn, YVn, 0, B84, L84, H84, Val(FrmMain.Instance.txtKinhtuyentruc.Text.Split(",")(0)), Val(FrmMain.Instance.txtKinhtuyentruc.Text.Split(",")(1)))
            mP = FrmMain.Instance.sgworldMain.Creator.CreatePosition(L84, B84, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            mP.Distance = 5000

        End If
        Return mP
        TDo4_o9 = mP
    End Function

    Public Function ArrayPoint3D() As Point3D()
        Dim pMMain() As Point3D = Enumerable.Empty(Of Point3D) '.ToArray
        Dim ST() As String = cPlg2.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")
        For i As Integer = 0 To (ST.Count / 2 - 1)
            Dim mPk1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST(i).Split(" ")(1)), Val(ST(i).Split(" ")(2)), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim K As New Point3D
            ReDim Preserve pMMain(0 To (ST.Count / 2 - 1))
            K.X = mPk1.X
            K.Y = mPk1.Y
            K.Z = 0 ' sgworldMain.Terrain.GetGroundHeightInfo(K.X, K.Y, AccuracyLevel.ACCURACY_NORMAL, True).Position.Altitude
            pMMain(i) = K
        Next
        ArrayPoint3D = pMMain
    End Function

    Public Function ArrayPoint(TQ As List(Of Double), P As IPosition71, heso As Double, Goc As Double) As IPosition71()
        Dim k(TQ.Count / 2) As IPosition71
        Dim kc As New List(Of Double), GC As New List(Of Double)
        For i As Integer = 0 To TQ.Count - 1
            If i Mod 2 = 0 Then
                kc.Add(TQ(i))
            Else
                GC.Add(TQ(i))
            End If
        Next
        For i As Integer = 0 To kc.Count - 1
            k(i) = P.Move(kc(i) * Tyle * heso, GC(i) - Goc, 0)
        Next
        ArrayPoint = k
    End Function

    Public Function ArrayDoubleToListPoint(TQ As List(Of Double), P As IPosition71, heso As Double, Goc As Double) As List(Of IPosition71)
        Dim k(TQ.Count / 2) As IPosition71
        Dim kc As New List(Of Double), GC As New List(Of Double), Li As New List(Of IPosition71)
        For i As Integer = 0 To TQ.Count - 1
            If i Mod 2 = 0 Then
                kc.Add(TQ(i))
            Else
                If Lenhve = "sanbaygia" Then
                    GC.Add(TQ(i) + 45)
                Else
                    GC.Add(TQ(i))
                End If

            End If
        Next
        For i As Integer = 0 To kc.Count - 1
            k(i) = P.Move(kc(i) * Tyle * heso, GC(i) - Goc, 0)
            Li.Add(k(i))
        Next
        ArrayDoubleToListPoint = Li
    End Function

    Public Function ArrayPointPlus(TQ As List(Of Double), P As IPosition71, heso As Double, kcLui As Double, Goc As Double) As IPosition71()
        Dim k(TQ.Count / 2) As IPosition71
        Dim kc As New List(Of Double), GC As New List(Of Double)
        For i As Integer = 0 To TQ.Count - 1
            If i Mod 2 = 0 Then
                kc.Add(TQ(i))
            Else
                GC.Add(TQ(i))
            End If
        Next
        For i As Integer = 0 To kc.Count - 1
            k(i) = P.Move(kcLui + (kc(i) * heso), GC(i) - Goc, 0)
        Next
        ArrayPointPlus = k
    End Function

    Public Function ArrayPoint2(TQ As List(Of Double), P As IPosition71, heso As Double, Goc1 As Double, Goc2 As Double) As IPosition71()
        Dim k(TQ.Count / 2) As IPosition71
        Dim kc As New List(Of Double), GC As New List(Of Double)
        For i As Integer = 0 To TQ.Count - 1
            If i Mod 2 = 0 Then
                kc.Add(TQ(i))
            Else
                GC.Add(TQ(i))
            End If
        Next
        '    MsgBox(kc.Count.ToString)
        For i As Integer = 0 To kc.Count - 1
            k(i) = P.Move(kc(i) * Tyle * heso, (180.0 - GC(i)) - 0.0 - Goc2, 0)
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 + 270
                    k(i) = P.Move(kc(i) * Tyle * heso, GC(i) - 0.0 - Goc2, 0)
                End If
            End If
        Next
        ArrayPoint2 = k
    End Function

    Public Function ArrayPoint3(TQ As List(Of Double), P As IPosition71, heso As Double, Goc As Double) As IPosition71()
        Dim k(TQ.Count / 2) As IPosition71
        Dim kc As New List(Of Double), GC As New List(Of Double)
        For i As Integer = 0 To TQ.Count - 1
            If i Mod 2 = 0 Then
                kc.Add(TQ(i))
            Else
                GC.Add(TQ(i))
            End If
        Next
        For i As Integer = 0 To kc.Count - 1
            k(i) = P.Move(kc(i) * heso, GC(i) - Goc, 0)
        Next
        ArrayPoint3 = k
    End Function

    Public Function ArraytoList(Li As List(Of IPosition71), Ar As IPosition71()) As List(Of IPosition71)
        For i As Integer = 0 To Ar.ToList.Count - 2
            Li.Add(Ar(i))
        Next
        ArraytoList = Li
    End Function

    Public Function ArrayDoubleToListP(cArray() As Double) As List(Of IPosition71)
        Dim Li As New List(Of IPosition71)
        For i As Integer = 0 To cArray.Length / 3 - 2
            Dim P As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(cArray(i * 3), cArray((i * 3) + 1), 0, 2, 0, 0, 0, 0)
            Li.Add(P)
        Next
        ArrayDoubleToListP = Li
    End Function

    Public Function ArDisAgreetoLiPoint(TQ As List(Of Double), P As IPosition71, heso As Double, Goc As Double) As List(Of IPosition71)
        Dim LiP As New List(Of IPosition71), kc As New List(Of Double), GC As New List(Of Double)
        Dim k(TQ.Count / 2) As IPosition71
        For i As Integer = 0 To TQ.Count - 1
            If i Mod 2 = 0 Then
                kc.Add(TQ(i))
            Else
                GC.Add(TQ(i))
            End If
        Next
        For i As Integer = 0 To kc.Count - 1
            k(i) = P.Move(kc(i) * Tyle * heso, GC(i) - Goc, 0)
            LiP.Add(k(i))
        Next
        ArDisAgreetoLiPoint = LiP
    End Function

    Public Function ListtoGeo(Li As List(Of IPosition71)) As IGeometry
        Dim cArray(Li.Count * 3 - 1) As Double
        For j As Integer = 0 To Li.Count - 1
            cArray(j * 3) = Li(j).X
            cArray(j * 3 + 1) = Li(j).Y
            cArray(j * 3 + 2) = Li(j).Altitude
        Next
        Dim cRing As ILinearRing = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(cArray)
        Dim cPolygonGeometry As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing, Nothing)
        ListtoGeo = cPolygonGeometry
    End Function

    Public Sub XoaKhung(sgworldK As SGWorld71, tenXoa As String)
        Try
            Dim k0 = sgworldK.ProjectTree.FindItem("Trinh bay\" & tenXoa)
            If String.IsNullOrEmpty(k0) = False Then
                sgworldK.ProjectTree.DeleteItem(sgworldK.ProjectTree.FindItem("Trinh bay\" & tenXoa))
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Function GeoToList(IGeo As IGeometry) As List(Of IPosition71)
        Try
            Dim liPoint As New List(Of IPosition71)
            Dim ST() As String = IGeo.Wks.ExportToWKT().Replace("POLYGON Z", "").Replace("((", "").Replace("))", "").Split(",")
            For i = 0 To ST.Length - 2
                Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Val(ST(i).Split(" ")(1)), Val(ST(i).Split(" ")(2)), Val(ST(i).Split(" ")(3)), 2, 0, 0, 0, 0)
                liPoint.Add(P1)
            Next
            GeoToList = liPoint
        Catch ex As Exception
        End Try
    End Function

    Public Sub HoldRegion(li1 As List(Of IPosition71), li2 As List(Of IPosition71), Group As String, mLineStylePattern As UInteger, Dorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Double, mauVung As IColor71, mSetAlphaVung As Double, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double, TTDoituong As String)
        Dim geo1 As IGeometry = ListtoGeo(li1)
        Dim geo2 As IGeometry = ListtoGeo(li2)
        Dim HoldGeo As IGeometry = geo1.SpatialOperator.Difference(geo2)
        Dim mRegion As ITerrainPolygon71 = FrmMain.Instance.sgworldMain.Creator.CreatePolygon(HoldGeo, mauDuong, mauVung, mATC, Group, tenKH & TTDoituong)
        DefindReGion(mRegion, mLineStylePattern, Dorongduong, mauDuong, mSetAlphaDuong, mauVung, mSetAlphaVung, filePaternVung, xScale, yScale, mRotate, Tron, mATC, mOrder)
    End Sub

    Public Function FKc(P1 As IPosition71, P2 As IPosition71) As Double
        Dim khoangcach As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y)
        FKc = khoangcach
    End Function

    Public Function CenterPoint(P1 As IPosition71, P2 As IPosition71) As IPosition71
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P1.X + P2.X), 0.5 * (P1.Y + P2.Y), 0, 2, 0, 0, 0, 0)
        CenterPoint = Pc
    End Function

    Public Function ThreePoint(p1 As IPosition71, Goc As Double, Dx As Double) As List(Of IPosition71)
        Dim Pt As IPosition71 = p1.Move(Dx, 90 + Goc, 0)
        Dim Pp As IPosition71 = p1.Move(Dx, 270 + Goc, 0)
        Dim LiP As New List(Of IPosition71) From {p1, Pt, Pp}
        ThreePoint = LiP
        'For i As Integer = 0 To LiP.Count - 1
        '    FrmMain.Instance.sgworldMain.Creator.CreateLabel(LiP(i), i.ToString, "", Nothing, "", i.ToString)
        'Next
    End Function

#Region "   Curve"

    Public Function Curveline(liP As List(Of IPosition71), SoDoan As Double) As List(Of IPosition71) 'Khong sua
        Dim Plg1() As Point3D
        ReDim Plg1(0 To 0)
        Dim SplPsNum As Long
        Dim Pn As Point3D
        PllVtNum = 1
        For i As Integer = 0 To liP.Count - 1
            ReDim Preserve PllPts(0 To PllVtNum)
            Pn.X = liP(i).X
            Pn.Y = liP(i).Y
            Pn.Z = 0 'sgworldMain.Terrain.GetGroundHeightInfo(PosPixel.X, PosPixel.Y, AccuracyLevel.ACCURACY_NORMAL, True).Position.Altitude
            PllPts(PllVtNum) = Pn
            PllVtNum += 1
        Next
        SplineMt(PllPts, PllPts.Length - 1, SoDoan, Plg1, SplPsNum)
        Dim PK As New List(Of IPosition71)
        For i As Integer = 0 To Plg1.Length - 2
            Dim PL As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(Plg1(i + 1).X, Plg1(i + 1).Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            PK.Add(PL)
        Next
        Curveline = PK
    End Function

    Public Function Muiten(P1 As IPosition71, P2 As IPosition71, Goc As Double, Heso As Double, Rongduoi As Double) As List(Of IPosition71)
        Dim pk As IPosition71
        Dim Rongco As Double, RongMT As Double
        If Lenhve = "muitiencongkep" Or Lenhve = "Muithocsau" Then
            If Lenhve = "muitiencongkep" Then
                pk = P2
            Else
                pk = P1.Move(-Dorongduong * 8 * Heso, Goc, 0)
            End If
            Rongco = Heso * Dorongduong / 2
            RongMT = Heso * Dorongduong / 2
        Else
            pk = P1.Move(-Dorongduong * 13 * Heso, Goc, 0)
            Rongco = Heso * Dorongduong
            RongMT = Heso * Dorongduong
        End If
        Dim mt1 As IPosition71 = pk.Move(RongMT * 4, Goc - 240, 0)
        Dim mt2 As IPosition71 = pk.Move(RongMT * 4, Goc - 120, 0)
        Dim mt21 As IPosition71 = pk.Move(Rongco, Goc - 90, 0)
        Dim mt11 As IPosition71 = pk.Move(Rongco, Goc - 270, 0)

        Dim mt3 As IPosition71 = P2.Move(Rongco * Rongduoi, Goc - 90, 0)
        Dim mt4 As IPosition71 = P2.Move(Rongco * Rongduoi, Goc - 270, 0)
        Dim liPiont1 As New List(Of IPosition71) From {P1, mt2, mt21, mt3, mt4, mt11, mt1}

        If Lenhve = "muitiencongkep" Then
            liPiont1.RemoveRange(2, 1)
            liPiont1.RemoveRange(4, 1)
        End If
        Muiten = liPiont1
        'For i As Integer = 0 To liPiont1.Count - 1
        '    FrmMain.Instance.sgworldMain.Creator.CreateLabel(liPiont1(i), i.ToString, "", Nothing, "", i.ToString)
        'Next
    End Function

    Public Sub DemMTk(LiMT As List(Of IPosition71), Smau As IColor71, Heso As Double)
        Dim Ps As IPosition71 = LiMT(4).Move(Dorongduong * Heso, 180 + FGoc(LiMT(3), LiMT(4)), 0)
        Dim Ps1 As IPosition71 = CenterPoint(LiMT(5), LiMT(6))
        Dim LiMTDem As New List(Of IPosition71) From {LiMT(4), LiMT(5), Ps1, Ps}
        FVungList(LiMTDem, 4294967295, 0, Smau, 0, Smau, 1, "", 0, 0, 0, False, 2, 1)
    End Sub

    Public Function LiCrube3Point(P1 As IPosition71, P2 As IPosition71, P3 As IPosition71) As List(Of IPosition71)
        Dim LiP As New List(Of IPosition71) From {P1, P2, P3}
        Dim LiCurve As List(Of IPosition71) = Curveline(LiP, 12)
        LiCrube3Point = LiCurve
    End Function

    Public Function UniCruve(Added As List(Of IPosition71), BiAdd As List(Of IPosition71)) As List(Of IPosition71)
        For i As Integer = 0 To BiAdd.Count - 1
            Added.Add(BiAdd(i))
        Next
        UniCruve = Added
    End Function

    Public Function AddPointToList(Added As List(Of IPosition71), BiAdd As List(Of IPosition71), Dau As Integer, Cuoi As Integer) As List(Of IPosition71)
        For i As Integer = Dau To Cuoi
            Added.Add(BiAdd(i))
        Next
        AddPointToList = Added
    End Function

    Public Sub Dauchuthap(P As IPosition71, Goc As Double, Smau As IColor71, Heso As Double)
        Dim K1 As IPosition71 = P.Move(Dorongduong * Heso, Goc, 0)
        Dim K2 As IPosition71 = P.Move(-Dorongduong * Heso, Goc, 0)
        Dim p1 As IPosition71 = K1.Move(Dorongduong * Heso, Goc + 90, 0)
        Dim p2 As IPosition71 = K1.Move(Dorongduong * Heso, Goc + 270, 0)
        Dim p3 As IPosition71 = K2.Move(Dorongduong * Heso, Goc + 90, 0)
        Dim p4 As IPosition71 = K2.Move(Dorongduong * Heso, Goc + 270, 0)
        Dim liKXanh As New List(Of IPosition71) From {p1, P, p2, P, p3, P, p4}
        FDuongList(liKXanh, 4294967295, "", 0, 0, Smau, Dorongduong * 1.5, False, 2, 0, 6) ' 2, False, 2)
    End Sub

    Public Function Rau34(Pc As IPosition71, Dx As Double, Goc As Double, SMau As IColor71, Sk As Integer, Lenh As String) As List(Of IPosition71)
        Dx *= Dorongduong
        Dim LiCircleC1 As List(Of IPosition71) = LiPCircle(Pc, Dx, Goc, 10)
        Dim LiC As New List(Of IPosition71)
        AddPointToList(LiC, LiCircleC1, 32, 35)
        AddPointToList(LiC, LiCircleC1, 0, 14)
        Dim GeiC1 As IGeometry = ListtoGeo(LiC).SpatialOperator.buffer(Dorongduong * 3)
        Dim LiN As List(Of IPosition71) = GeoToList(GeiC1)
        Dim LD1 As New List(Of IPosition71) From {LiC(3), LiN(14)}
        Dim LD2 As New List(Of IPosition71) From {LiC(6), LiN(20)}
        Dim LD3 As New List(Of IPosition71) From {LiC(9), LiN(26)}
        Dim LD4 As New List(Of IPosition71) From {LiC(12), LiN(32)}
        Dim LD5 As New List(Of IPosition71) From {LiC(15), LiN(38)}

        If Sk = 0 Then
            FDuongList(LD2, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
            FDuongList(LD4, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
        ElseIf Sk = 1 Then
            FDuongList(LD1, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
            FDuongList(LD2, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
            FDuongList(LD4, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
            FDuongList(LD5, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
        ElseIf Sk = 2 Then
            FDuongList(LD2, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
            FDuongList(LD3, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
            FDuongList(LD4, 4294967295, "", 0, 0, SMau, Dorongduong * 1.5, False, 2, 0, 2)
        End If

        If Lenh = "tuyenbanCS" Or Lenh = "TSTiengdong" Then
            Rau34 = LiC
        Else
            LiCircleC1.Add(LiCircleC1(0))
            Rau34 = LiCircleC1
        End If
    End Function

    Public Function Rangcua(P1 As IPosition71, P2 As IPosition71, SCao As Double, SGiancach As Double, GocXoay As Double, Nghieng As Integer) As List(Of IPosition71)
        Dim Pk1 As IPosition71 = P1.Move(SCao, GocXoay + FGoc(P1, P2), 0)
        Dim Pk2 As IPosition71 = P2.Move(SCao, GocXoay + FGoc(P1, P2), 0)
        Dim LiCsPhai As List(Of IPosition71) = CauNgamLine(Pk1, Pk2, SGiancach)
        Dim LiCsGiua As List(Of IPosition71) = CauNgamLine(P1, P2, SGiancach)
        Dim LiCaungam As New List(Of IPosition71)
        For j As Integer = 1 To LiCsPhai.Count - 1 Step 2
            LiCaungam.Add(LiCsGiua(j))
            LiCaungam.Add(LiCsPhai(j + Nghieng))
            LiCaungam.Add(LiCsGiua(j))
        Next
        FDuongList(LiCaungam, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
        Dim LisP As New List(Of IPosition71) From {LiCaungam(0), LiCaungam(LiCaungam.Count - 1)}
        Rangcua = LisP
    End Function

    Function CauNgamLine(p1 As IPosition71, p2 As IPosition71, RongCau As Double) As List(Of IPosition71)
        Dim Kc1 As Double
        Dim LiCs As New List(Of IPosition71)
        For i As Integer = 0 To 1000
            Kc1 = i * RongCau
            Dim Pk As IPosition71 = p1.Move(Kc1, FGoc(p1, p2) + 180, 0)
            LiCs.Add(Pk)
            If Kc1 + RongCau > FKc(p1, p2) Then
                CauNgamLine = LiCs
                Exit For
            End If
        Next
    End Function

#End Region

    Public Sub Mask(P As IPosition71, Goc As Double, Srong As Double, SDai As Double)
        Dim P1 As IPosition71 = P.Move(SDai / 2, Goc, 0)
        Dim P11 As IPosition71 = P1.Move(Srong / 2, 90 + Goc, 0)
        Dim P12 As IPosition71 = P1.Move(Srong / 2, 270 + Goc, 0)
        Dim P2 As IPosition71 = P.Move(SDai / 2, 180 + Goc, 0)
        Dim P21 As IPosition71 = P2.Move(Srong / 2, 90 + Goc, 0)
        Dim P22 As IPosition71 = P2.Move(Srong / 2, 270 + Goc, 0)
        Dim LiMask As New List(Of IPosition71) From {P11, P12, P22, P21}
        FVungList(LiMask, 4294967295, 0, mau, 0, mauTrang, 1, "", 0, 0, 0, False, 2, 0)
    End Sub
End Module





