Imports TerraExplorerX

Module mdlHDTC

#Region "   Hanh quan"

    Public Sub SAnhDVHQ(mlve As String, sgworldK As SGWorld71, mGroup As String, mLabelStyle As ILabelStyle71)
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim anhDonviHQ As String, TaDoiphuong As String
        Dim anhDonvi As String = ""
        Dim mAnhDV As String = String.Empty
        If mlve = "hanhquanbo" Then
            mAnhDV = "BB,Tang,TG,Phao,Tenlua,Coi"
        ElseIf mlve = "HQbangoto" Then
            mAnhDV = "oto,Tang_oto,TG_oto,Phao_oto,TL_oto,Coi_oto"
        ElseIf mlve = "HQbangxelua" Then
            mAnhDV = "xelua,Tang_xelua,TG_xelua,Phao_xelua,TL_xelua,Coi_xelua"
        ElseIf mlve = "HQbangTau" Then
            mAnhDV = "tau,Tang_tau,TG_tau,Phao_tau,TL_tau,Coi_tau"
        ElseIf mlve = "HQbangMB" Then
            mAnhDV = "maybay,Tang_maybay,TG_maybay,Phao_maybay,TL_maybay,coi_maybay"
        End If
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
            TaDoiphuong = "2.gif"
        Else
            TaDoiphuong = ".gif"
        End If
        Select Case FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex
            Case 1
                anhDonvi = mAnhDV.Split(",")(0)
            Case 2
                anhDonvi = mAnhDV.Split(",")(1)
            Case 3
                anhDonvi = mAnhDV.Split(",")(2)
            Case 4
                anhDonvi = mAnhDV.Split(",")(3)
            Case 5
                anhDonvi = mAnhDV.Split(",")(4)
            Case 6
                anhDonvi = mAnhDV.Split(",")(5)
        End Select
        anhDonviHQ = PathData & "\Symbols\" & anhDonvi & TaDoiphuong
        KyhieuHQ(sgworldK, anhDonviHQ, Goc1, mGroup, mLabelStyle)
        KHdonviHQ(sgworldK, Goc1, mGroup, mLabelStyle)
    End Sub

    Public Sub KyhieuHQ(sgworldK As SGWorld71, anhDonviHQ As String, Goc1 As Double, mGroup As String, mLabelStyle As ILabelStyle71)
        mLabelStyle.PivotAlignment = "Bottom,LEFT"
        mLabelStyle.LockMode = LabelLockMode.LM_AXIS
        mLabelStyle.Scale = Tyle * 6.0
        Dim P As IPosition71 = sgworldK.Creator.CreatePosition(FrmMain.Instance.mPointClick.X, FrmMain.Instance.mPointClick.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim Doituong As ITerrainLabel71 = sgworldK.Creator.CreateLabel(P, "", anhDonviHQ, mLabelStyle, mGroup, tenKH)
        Doituong.Position.Yaw = Goc1 + 180
        Doituong.Position.Pitch = 90
        Doituong.Tooltip.Text = mota
        Doituong.Position.Roll = 180
        Doituong.Position.AltitudeType = 2
    End Sub

    Public Sub KHdonviHQ(sgworldK As SGWorld71, Goc1 As Double, mGroup As String, mLabelStyle As ILabelStyle71)
        Dim Ten As String = String.Empty
        Dim Chieucao As Integer = 0
        mLabelStyle.TextAlignment = "Center,Center"
        mLabelStyle.PivotAlignment = "Bottom,Center"
        mLabelStyle.Scale = Tyle * 6.0
        If mauKT = True Then
            tenGiaidoan = "1.mkx"
        Else
        End If
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
            mLabelStyle.PivotAlignment = "Bottom,left"
        Else
            mLabelStyle.PivotAlignment = "Bottom,Right"
        End If
        mLabelStyle.TextColor = mau
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 1 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 2 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 3 Then
            Select Case FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex
                Case 1
                    loaiKH = "100004"   'su doan
                    Ten = tenKH
                    Chieucao = 300
                Case 2
                    loaiKH = "100005"  'lu doan
                    Ten = tenKH
                    Chieucao = 300
                Case 3
                    loaiKH = "100006"   'trung doam
                    Ten = tenKH
                    Chieucao = 300
                Case 4
                    loaiKH = "100007"   'tieu doan
                    Ten = tenKH
                    Chieucao = 300
                Case 5
                    loaiKH = "100088"  'Dai doi
                    Ten = ""
                    Chieucao = 120
                Case 6
                    loaiKH = "100089"   'tieu doan
                    Ten = ""
                    Chieucao = 120
            End Select
        ElseIf FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            Select Case FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex
                Case 1 'Su doan
                    loaiKH = "1100004"
                    Ten = tenKH
                    Chieucao = 300
                Case 2 'lu doan
                    loaiKH = "1100005"
                    Ten = tenKH
                    Chieucao = 300
                Case 3 'Trung doan
                    loaiKH = "1100006"
                    Ten = tenKH
                    Chieucao = 300
                Case 4 'Tieu
                    loaiKH = "1100007"
                    Ten = tenKH
                    Chieucao = 300
                Case 5 'Dai doi
                    Ten = ""
                    loaiKH = "1100088"
                    Chieucao = 120
                Case 6 'Trung doi
                    Ten = ""
                    loaiKH = "1100089"
                    Chieucao = 120
            End Select
        End If
        fileImage = PathData & "\2X\" & ChieuKH & loaiKH & Ta_Doiphuong & tenGiaidoan
        Dim P3 As IPosition71 = FrmMain.Instance.mPointClick.Move(2000.0 * Tyle, 90.0 + Goc1, 0)
        P3.Altitude = 0
        Dim Doituong = sgworldK.Creator.CreateLabel(P3, Ten, fileImage, mLabelStyle, mGroup, tenKH)
        Doituong.Position.Yaw = Goc1 + 180
        Doituong.Position.Pitch = 90
        Doituong.Tooltip.Text = mota
        Doituong.Position.Roll = 180
        Doituong.Position.Altitude = Chieucao * Tyle
        Doituong.Position.AltitudeType = 2
    End Sub

    Public Sub HQbo()
        Dim k(10) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = 3.0 * Tyle
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * hesoTyle, 88.35 - Goc1, 0)
        If Bd3D = False Then
            SAnhDVHQ(Lenhve, FrmMain.Instance.sgworldMain, GroupBac2Main, FrmMain.Instance.fLabelStyleMain)
        End If
        k(1) = FrmMain.Instance.mPointClick.Move(18.0 * hesoTyle, 0.0 - Goc1, 0)
        k(2) = FrmMain.Instance.mPointClick.Move(713.84 * hesoTyle, 88.56 - Goc1, 0)
        k(3) = FrmMain.Instance.mPointClick.Move(689.25 * hesoTyle, 85.61 - Goc1, 0)
        k(4) = FrmMain.Instance.mPointClick.Move(900.0 * hesoTyle, 90.0 - Goc1, 0)
        k(5) = FrmMain.Instance.mPointClick.Move(689.25 * hesoTyle, 94.39 - Goc1, 0)
        k(6) = FrmMain.Instance.mPointClick.Move(713.84 * hesoTyle, 91.44 - Goc1, 0)
        k(7) = FrmMain.Instance.mPointClick.Move(18.0 * hesoTyle, 180.0 - Goc1, 0)
        Select Case FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex
            Case 1
                KhHQ2D(Goc1, 3.0 * Tyle, P1)
            Case 2
                TangHQ()
                Exit Sub
            Case 3
                TGHQ()
                Exit Sub
            Case 4
                PhaoHQ()
                Exit Sub
            Case 5
                TLHQ()
                Exit Sub
            Case 6
                KhHQ2D(Goc1, hesoTyle, P1)
                Dim Goc2 As Double = Goc1 + 180
                KHCoi(Goc2, hesoTyle, P1)
        End Select
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            FVungPoint(k, 1, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(k, 1, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If

        SLenhve3DMs()
    End Sub

    Public Sub HQOto()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI

        Dim P2 As IPosition71 = FrmMain.Instance.mPointClick.Move(446.5 * 3.0 * Tyle, 96.65 - Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.Instance.mPointClick.Move(133.42 * 3.0 * Tyle, 113.88 - Goc1, 0)
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * 3.0 * Tyle, 88.35 - Goc1, 0)
        If Bd3D = False Then
            SAnhDVHQ(Lenhve, FrmMain.Instance.sgworldMain, GroupBac2Main, FrmMain.Instance.fLabelStyleMain)
        End If
        Dim TQ1 As New List(Of Double)({18.0, 0.0, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44})
        Dim TQ2 As New List(Of Double)({37.06, 13.75, 37.0, 30.0, 37.0, 45.0, 37.0, 60.0, 37.0, 75.0, 37.0, 90.0, 37.0, 105.0, 37.0, 120.0, 37.0, 135.0, 37.0, 150.0, 37.0, 165.0, 37.0, 180.0, 6.9, 180.0, 6.9, 150.0, 6.9, 120.0, 6.9, 90.0, 6.9, 60.0, 6.9, 30.0, 6.9, 0.0, 6.9, 330.0, 6.9, 300.0, 6.9, 270.0, 6.9, 240.0, 6.9, 210.0, 6.9, 180.83, 37.0, 180.15, 37.0, 195.0, 37.0, 210.0, 37.0, 225.0, 37.0, 240.0, 37.0, 255.0, 37.0, 270.0, 37.0, 285.0, 37.0, 300.0, 37.0, 315.0, 37.0, 330.0, 37.0, 346.25})
        Dim TQ3 As New List(Of Double)({37.06, 13.75, 37.0, 30.0, 37.0, 45.0, 37.0, 60.0, 37.0, 75.0, 37.0, 90.0, 37.0, 105.0, 37.0, 120.0, 37.0, 135.0, 37.0, 150.0, 37.0, 165.0, 37.0, 180.0, 6.9, 180.0, 6.9, 150.0, 6.9, 120.0, 6.9, 90.0, 6.9, 60.0, 6.9, 30.0, 6.9, 0.0, 6.9, 330.0, 6.9, 300.0, 6.9, 270.0, 6.9, 240.0, 6.9, 210.0, 6.9, 180.83, 37.0, 180.15, 37.0, 195.0, 37.0, 210.0, 37.0, 225.0, 37.0, 240.0, 37.0, 255.0, 37.0, 270.0, 37.0, 285.0, 37.0, 300.0, 37.0, 315.0, 37.0, 330.0, 37.0, 346.25})
        Dim liP As New List(Of IPosition71)
        'liP = ArraytoList(ArrayPoint(TQ1, FrmMain.Instance.mPointClick, 3.0, Goc1))
        'liP = ArraytoList(ArrayPoint(TQ2, P2, 3.0, Goc1))
        'liP = ArraytoList(ArrayPoint(TQ3, P3, 3.0, Goc1))
        For i As Integer = 0 To ArrayPoint(TQ1, P2, 3.0, Goc1).ToList.Count - 2
            liP.Add(ArrayPoint(TQ1, FrmMain.Instance.mPointClick, 3.0, Goc1)(i))
        Next
        For i As Integer = 0 To ArrayPoint(TQ2, P2, 3.0, Goc1).ToList.Count - 2
            liP.Add(ArrayPoint(TQ2, P2, 3.0, Goc1)(i))
        Next
        For i As Integer = 0 To ArrayPoint(TQ3, P3, 3.0, Goc1).ToList.Count - 2
            liP.Add(ArrayPoint(TQ3, P3, 3.0, Goc1)(i))
        Next
        Dim k As IPosition71 = FrmMain.Instance.mPointClick.Move(18.0 * 3.0 * Tyle, 180.0 - Goc1, 0)
        liP.Add(k)
        KhHQ2D(Goc1, 3.0 * Tyle, P1)
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            FVungList(liP, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungList(liP, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub HQXelua()
        Dim k(40) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = 3.0 * Tyle
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * hesoTyle, 88.35 - Goc1, 0)
        If Bd3D = False Then
            SAnhDVHQ(Lenhve, FrmMain.Instance.sgworldMain, GroupBac2Main, FrmMain.Instance.fLabelStyleMain)
        End If
        KhHQ2D(Goc1, hesoTyle, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 18.0, 180.0, 97.85, 37.15, 118.41, 48.8, 90.89, 78.58, 115.5, 81.03, 138.2, 55.64, 163.85, 61.57, 145.21, 82.88, 170.04, 83.92, 186.21, 65.24, 213.82, 68.61, 199.9, 84.83, 224.81, 85.41, 237.28, 70.81, 265.79, 72.93, 259.51, 101.73, 230.22, 103.25, 224.81, 94.59, 199.9, 95.17, 205.96, 104.84, 177.13, 107.33, 170.04, 96.08, 145.21, 97.12, 153.45, 110.11, 124.7, 114.82, 115.5, 98.97, 90.8, 101.42, 103.54, 120.64, 79.22, 132.42})
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 7, 34, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HQTau()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * 3.0 * Tyle, 88.35 - Goc1, 0)
        If Bd3D = False Then
            SAnhDVHQ(Lenhve, FrmMain.Instance.sgworldMain, GroupBac2Main, FrmMain.Instance.fLabelStyleMain)
        End If
        KhHQ2D(Goc1, 3.0 * Tyle, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 66.7, 74.13, 81.98, 64.97, 102.54, 61.59, 125.93, 61.75, 150.51, 63.82, 175.02, 66.88, 163.9, 78.9, 144.91, 78.11, 211.2, 94.54, 198.7, 96.83, 182.28, 98.99, 112.69, 80.77, 103.54, 84.08, 99.45, 87.29, 99.4, 91.96, 103.41, 95.21, 112.59, 98.57, 126.89, 100.78, 144.64, 101.39, 163.81, 100.65, 181.69, 99.01, 198.75, 96.86, 211.3, 94.56, 219.18, 92.46, 222.65, 90.88, 222.68, 88.79, 219.24, 87.21, 211.5, 85.21, 198.9, 82.77, 182.63, 80.59, 164.08, 78.91, 175.13, 66.9, 198.34, 70.44, 219.3, 74.23, 236.86, 78.11, 250.1, 82.03, 258.34, 85.94, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 257.69, 94.01, 249.93, 97.68, 236.59, 101.58, 218.95, 105.44, 197.91, 109.21, 174.54, 112.73, 149.95, 115.74, 125.32, 117.73, 101.93, 117.77, 81.44, 114.2, 67.36, 105.5, 18.0, 180.0})
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 54, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 54, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If

        SLenhve3DMs()
    End Sub

    Public Sub HQMB()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(680 * 3.0 * Tyle, 88.35 - Goc1, 0)
        If Bd3D = False Then
            SAnhDVHQ(Lenhve, FrmMain.Instance.sgworldMain, GroupBac2Main, FrmMain.Instance.fLabelStyleMain)
        End If
        KhHQ2D(Goc1, 3.0 * Tyle, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 63.48, 73.53, 92.76, 41.01, 119.51, 54.15, 102.66, 109.34, 168.34, 101.65, 168.34, 78.35, 102.76, 70.68, 119.6, 54.18, 212.72, 70.79, 201.68, 84.88, 253.27, 85.92, 264.24, 72.95, 293.05, 74.67, 293.34, 105.53, 264.56, 107.27, 253.27, 94.2, 201.68, 95.12, 212.72, 109.21, 92.76, 138.99, 63.48, 106.47, 18.0, 180.0, 317.23, 75.87, 346.4, 77.08, 338.11, 86.95, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 18.0, 180.0, 338.11, 93.05, 346.64, 103.1, 317.5, 104.32})
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 22, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 22, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub TangHQ()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * 3.0 * Tyle, 88.35 - Goc1, 0)
        KhHQ2D(Goc1, 3.0 * Tyle, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 94.36, 79.0, 170.98, 68.6, 160.81, 81.88, 122.78, 90.0, 161.28, 99.22, 195.63, 90.0, 160.9, 81.91, 171.05, 68.64, 226.48, 85.44, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 231.16, 94.47, 172.15, 112.37, 89.75, 101.57, 18.0, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TGHQ()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * 3.0 * Tyle, 88.35 - Goc1, 0)
        KhHQ2D(Goc1, 3.0 * Tyle, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 93.24, 78.87, 104.26, 61.34, 134.15, 68.12, 125.64, 97.78, 208.08, 94.69, 217.61, 94.14, 221.42, 93.65, 227.07, 92.05, 228.84, 90.53, 228.59, 88.94, 224.64, 87.06, 217.61, 85.86, 208.08, 85.31, 125.74, 82.23, 134.24, 68.13, 215.43, 76.58, 230.68, 78.02, 241.46, 79.76, 250.34, 81.95, 256.95, 84.46, 259.19, 86.02, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 259.19, 93.98, 256.95, 95.54, 250.34, 98.05, 241.46, 100.24, 230.68, 101.98, 215.43, 103.42, 104.26, 118.66, 93.24, 101.13, 18.0, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 35, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub PhaoHQ()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * 3.0 * Tyle, 88.35 - Goc1, 0)
        KhHQ2D(Goc1, Tyle * 3.0, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 84.57, 77.71, 98.04, 57.44, 124.37, 64.9, 124.37, 115.1, 98.04, 122.56, 84.68, 102.65, 18.0, 180.0, 147.39, 69.02, 175.74, 72.53, 168.59, 83.87, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 168.59, 96.13, 175.74, 107.47, 147.39, 110.98, 193.98, 70.3, 302.01, 77.5, 296.96, 83.16, 186.02, 79.04, 186.02, 100.96, 296.96, 96.84, 302.01, 102.5, 193.98, 109.7})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 19, 22, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 23, 26, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 8, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TLHQ()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(623.88 * 3.0 * Tyle, 88.35 - Goc1, 0)
        KhHQ2D(Goc1, 3.0 * Tyle, P1)
        Dim TQ As New List(Of Double)({18.0, 0.0, 84.57, 77.71, 98.04, 57.44, 124.37, 64.9, 124.37, 115.1, 98.04, 122.56, 84.68, 102.65, 18.0, 180.0, 170.97, 72.02, 199.72, 74.68, 193.47, 84.66, 713.84, 88.56, 689.25, 85.61, 900.0, 90.0, 689.25, 94.39, 713.84, 91.44, 193.47, 95.34, 199.72, 105.32, 170.97, 107.98, 220.93, 38.31, 180.14, 66.55, 172.26, 61.49, 172.57, 118.71, 147.96, 124.07, 147.59, 56.14, 130.17, 56.59})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 8, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 19, 25, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Private Sub KHCoi(mGoc As Double, HesoTyle As Double, p1 As IPosition71)
        Dim TQ As New List(Of Double)({293.44, 90.0, 295.32, 96.47, 255.92, 97.49, 271.35, 98.36, 285.37, 99.92, 297.3, 102.0, 362.76, 115.01, 330.44, 117.65, 312.99, 114.93, 312.05, 115.73, 305.21, 118.41, 295.42, 120.8, 283.08, 122.8, 268.76, 124.26, 253.18, 124.99, 237.26, 124.82, 232.84, 124.48, 238.83, 129.95, 212.53, 136.19, 195.11, 108.46, 200.87, 104.16, 211.13, 100.77, 224.99, 98.54, 185.45, 100.34, 182.44, 90.0, 237.94, 90.0, 246.62, 105.25, 234.45, 107.0, 228.12, 110.15, 229.83, 113.68, 238.97, 116.34, 252.48, 117.38, 266.39, 116.72, 277.16, 114.77, 282.39, 112.06, 281.0, 109.18, 273.27, 106.71, 260.83, 105.23, 246.73, 105.24, 238.05, 90.0})
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 0, 39, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Private Sub KhHQ2D(mGoc As Double, HesoTyle As Double, p1 As IPosition71)
        Dim lists2 As New List(Of IPosition71), lists3 As New List(Of IPosition71)
        Dim k(100) As IPosition71
        Dim Goc2 As Double = mGoc + 180
        'Dim Am As Integer = 1
        'If mGoc > 90 Then
        '    If mGoc < 270 Then
        '        'Goc2 = mGoc - 270
        '        '  Goc2 = mGoc - 90
        '        Goc2 = mGoc
        '        ' Goc2 = mGoc + 90
        '        ' Goc2 = mGoc + 270
        '        ' Goc2 = mGoc + 360
        '        Am = -1
        '    End If
        'End If

        Select Case FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex
            Case 1 'Su doan
                Dim TQ As New List(Of Double)({385.0, 180.0, 440.0, 180.0, 622.25, 135.0, 452.26, 136.86, 491.93, 116.57, 222.04, 172.23, 30.0, 90.0, 0.0, 0.0, 384.9, 180.0, 386.07, 175.54, 251.79, 173.16, 436.44, 124.95, 421.77, 141.48, 544.13, 138.89, 411.1, 175.82, 386.17, 175.54, 386.17, 175.54, 411.1, 175.82, 544.13, 138.89, 421.77, 141.48, 436.44, 124.95, 255.98, 167.59, 55.0, 90.0, 30.0, 90.0, 386.07, 175.54, 388.81, 171.87, 280.45, 168.69, 399.07, 133.56, 398.74, 145.85, 481.52, 143.09})
                For i As Integer = 0 To 15
                    lists2.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
                For i As Integer = 16 To 29
                    lists3.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
            Case 2 'Lu doan
                Dim TQ As New List(Of Double)({385.0, 180.0, 440.0, 180.0, 622.25, 135.0, 372.23, 126.23, 222.04, 172.23, 30.0, 90.0, 0.0, 0.0, 384.9, 180.0, 386.07, 175.54, 251.79, 173.16, 378.19, 131.38, 562.71, 136.77, 411.1, 175.82, 386.17, 175.54, 386.17, 175.54, 411.1, 175.82, 562.71, 136.77, 378.19, 131.38, 255.98, 167.59, 55.0, 90.0, 30.0, 90.0, 386.07, 175.54, 388.81, 171.87, 280.45, 168.69, 385.42, 136.41, 513.58, 139.45})
                For i As Integer = 0 To 13
                    lists2.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
                For i As Integer = 14 To 25
                    lists3.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
            Case 3 'Trung doan
                Dim TQ As New List(Of Double)({385.0, 180.0, 440.0, 180.0, 622.25, 135.0, 491.93, 116.57, 222.04, 172.23, 30.0, 90.0, 0.0, 0.0, 384.9, 180.0, 386.07, 175.54, 251.79, 173.16, 480.21, 121.37, 579.83, 135.0, 411.1, 175.82, 386.17, 175.54, 386.17, 175.54, 411.1, 175.82, 579.83, 135.0, 480.21, 121.37, 255.98, 167.59, 55.0, 90.0, 30.0, 90.0, 386.07, 175.54, 388.81, 171.87, 280.45, 168.69, 473.13, 125.54, 544.47, 135.0})
                For i As Integer = 0 To 13
                    lists2.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
                For i As Integer = 14 To 25
                    lists3.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next

            Case 4 'Tieu doan
                Dim TQ As New List(Of Double)({376.35, 180.0, 440.0, 180.0, 441.02, 176.1, 550.0, 126.87, 222.04, 172.23, 30.0, 90.0, 0.0, 0.0, 375.25, 180.0, 377.44, 175.44, 252.85, 173.19, 462.63, 135.51, 410.04, 175.8, 377.54, 175.44, 377.54, 175.44, 410.04, 175.8, 462.63, 135.51, 263.57, 167.96, 55.0, 90.0, 30.0, 90.0, 377.44, 175.44, 380.25, 171.68, 288.94, 169.03, 400.96, 145.39, 380.35, 171.69})
                For i As Integer = 0 To 12
                    lists2.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
                For i As Integer = 13 To 23
                    lists3.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next

            Case 5 'Dai doi
                Dim TQ As New List(Of Double)({0.0, 0.0, 60.0, 180.0, 67.08, 153.43, 30.0, 90.0, 55.0, 90.0, 81.39, 137.49, 104.04, 125.22, 128.22, 41.52, 110.64, 29.81, 65.73, 56.79, 46.86, 39.81, 100.58, 17.35, 96.0, 0.0, 30.0, 90.0, 67.08, 153.43, 81.39, 137.49, 55.0, 90.0, 85.0, 90.0, 104.04, 125.22, 125.3, 118.61, 146.0, 48.89, 128.22, 41.52, 92.31, 67.05, 65.73, 56.79, 110.64, 29.81, 100.58, 17.35})
                For i As Integer = 0 To 12
                    lists2.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
                For i As Integer = 13 To 25
                    lists3.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
            Case 6 'Trung doi
                Dim TQ As New List(Of Double)({0.0, 0.0, 60.0, 180.0, 67.08, 153.43, 100.58, 17.35, 96.0, 0.0, 30.0, 90.0, 67.08, 153.43, 81.39, 137.49, 110.64, 29.81, 100.58, 17.35})
                For i As Integer = 0 To 4
                    lists2.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
                For i As Integer = 5 To 9
                    lists3.Add(ArrayPoint(TQ, p1, 3.0, Goc2)(i))
                Next
        End Select
        If Lenhve = "HQbangoto" Or Lenhve = "HQbangxelua" Or Lenhve = "HQbangTau" Or Lenhve = "HQbangMB" Then
            Select Case FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex
                Case 2
                    KHTang(Goc2, HesoTyle, p1)
                Case 3
                    KHTG(Goc2, HesoTyle, p1)
                Case 4
                    KHPhao(Goc2, HesoTyle, p1)
                Case 5
                    KHTL(Goc2, HesoTyle, p1)
                Case 6
                    KHCoi(Goc2, HesoTyle, p1)
            End Select
        End If '
        If FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiBChanhquanHDTC.SelectedIndex = 6 Then
            FVungList(lists2, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungList(lists2, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        FVungList(lists3, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        Dim kChu As IPosition71
        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
            kChu = p1.Move(150.0 * HesoTyle, 84.0 - Goc2, 0)
        Else
            kChu = p1.Move(353.0 * HesoTyle, 157.0 - Goc2, 0)
        End If
        MakeText(kChu, 0, Tyle * 6, 0, tenKH, "", mau, 4, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 2)
        SLenhve3DMs()
    End Sub

    Private Sub KHTang(mGoc As Double, HesoTyle As Double, p1 As IPosition71)
        Dim TQ As New List(Of Double)({143.28, 116.99, 232.22, 90.0, 235.45, 99.5, 200.96, 108.88, 249.48, 111.44, 281.89, 103.34, 235.56, 99.51, 232.32, 90.02, 342.78, 100.93, 266.16, 119.25})
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Private Sub KHTG(mGoc As Double, HesoTyle As Double, p1 As IPosition71)
        Dim TQ As New List(Of Double)({336.77, 90.0, 364.62, 112.57, 241.09, 125.5, 223.46, 127.93, 205.97, 129.28, 187.78, 129.45, 170.09, 128.07, 154.49, 124.75, 142.89, 119.33, 137.17, 112.26, 138.44, 104.7, 146.46, 98.12, 159.73, 93.45, 176.28, 90.86, 196.28, 90.0, 303.67, 90.0, 305.46, 96.2, 201.16, 99.44, 180.23, 102.31, 170.77, 107.65, 172.68, 113.91, 185.12, 118.46, 203.28, 119.98, 225.45, 118.33, 322.06, 109.4, 303.77, 90.0})
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 0, 25, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Private Sub KHPhao(mGoc As Double, HesoTyle As Double, p1 As IPosition71)
        Dim TQ As New List(Of Double)({105.62, 139.79, 177.75, 107.13, 172.54, 112.58, 313.85, 102.19, 309.37, 97.43, 339.14, 96.77, 357.51, 109.61, 329.41, 111.36, 321.16, 107.22, 185.52, 120.83, 201.81, 122.68, 190.43, 97.54, 295.36, 94.86, 299.4, 100.59, 196.63, 106.24, 216.01, 119.08, 312.47, 109.64, 323.79, 114.64, 232.08, 125.57})
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 0, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 11, 14, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 15, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Private Sub KHTL(mGoc As Double, HesoTyle As Double, p1 As IPosition71)
        Dim TQ As New List(Of Double)({268.03, 90.0, 296.83, 90.0, 318.84, 111.41, 328.27, 108.81, 350.47, 126.31, 275.29, 112.61, 292.21, 113.47, 227.04, 92.78, 257.01, 92.46, 271.08, 108.7, 242.86, 110.97, 306.97, 92.06, 336.95, 91.87, 347.81, 104.47, 318.85, 105.82})
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 7, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 3.0, mGoc), 11, 14, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

#End Region

    Public Sub Chotchan()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim Goc1 As Double = MkGoc(P2, P1) * 180 / Math.PI
        ChotBB(P2, Goc1, 20.0)
    End Sub

    Private Sub ChotBB(P As IPosition71, Goc As Double, Mscale As Double)
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI + 180
        Dim TQ As New List(Of Double)({3.03, 7.5, 8.7, 7.5, 17.24, 15.0, 25.49, 22.5, 24.0, 33.9, 16.67, 32.3, 9.5, 39.9, 5.13, 90.0, 9.5, 140.1, 16.67, 147.1, 24.0, 146.1, 25.49, 157.5, 17.24, 165.0, 8.7, 172.5, 3.03, 172.5, 8.26, 248.7, 8.26, 291.3, 24.0, 33.9, 16.67, 32.3, 9.5, 39.9, 5.13, 90.0, 9.5, 140.1, 16.67, 147.1, 24.0, 146.1, 23.55, 135.6, 17.4, 133.2, 12.01, 120.9, 9.5, 90.0, 12.01, 59.1, 17.4, 46.8, 23.55, 44.4})
        FVungPoint(ArrayPoint(TQ, P, Mscale, Goc), 0, 16, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)

        FVungPoint(ArrayPoint(TQ, P, Mscale, Goc), 17, 30, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub DHBaovay()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim Goc1 As Double = MkGoc(P1, P2) * 180 / Math.PI
        If Lenhve = "vayep" Then
            Vayep(P2, Goc1, 20.0)
        Else
            Dim K1 As IPosition71 = P2.Move(Dorongduong * 25, Goc1 + 60, 0)
            Dim K3 As IPosition71 = P2.Move(Dorongduong * 10, Goc1 + 60, 0)
            Vayep(K1, MkGoc(K3, K1) * 180 / Math.PI, 25.0)
            CongsuTQ(MkGoc(K1, K3) * 180 / Math.PI, K3)
            Dim M1 As IPosition71 = P2.Move(Dorongduong * 25, Goc1 + 300, 0)
            Dim M3 As IPosition71 = P2.Move(Dorongduong * 10, Goc1 + 300, 0)
            Vayep(M1, MkGoc(M3, M1) * 180 / Math.PI, 25.0)
            CongsuTQ(MkGoc(M1, M3) * 180 / Math.PI, M3)
            Dim N1 As IPosition71 = P2.Move(-Dorongduong * 25, Goc1, 0)
            Dim N3 As IPosition71 = P2.Move(-Dorongduong * 10, Goc1, 0)
            Vayep(N1, MkGoc(N3, N1) * 180 / Math.PI, 25.0)
            CongsuTQ(MkGoc(N1, N3) * 180 / Math.PI, N3)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub Vayep(P As IPosition71, Goc As Double, Mscale As Double)
        Dim TQ As New List(Of Double)({0.0, 0.0, 8.7, 7.5, 17.24, 15.0, 25.49, 22.5, 24.0, 33.9, 16.67, 32.3, 9.5, 39.9, 6.29, 61.5, 16.74, 79.7, 16.74, 100.3, 6.29, 118.5, 9.5, 140.1, 16.67, 147.1, 24.0, 146.1, 25.49, 157.5, 17.24, 165.0, 8.7, 172.5, 24.0, 33.9, 16.67, 32.3, 9.5, 39.9, 5.13, 90.0, 9.5, 140.1, 16.67, 147.1, 24.0, 146.1, 23.55, 135.6, 17.4, 133.2, 12.01, 120.9, 9.5, 90.0, 12.01, 59.1, 17.4, 46.8, 23.55, 44.4})
        FVungPoint(ArrayPoint(TQ, P, Mscale, Goc), 0, 16, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, P, Mscale, Goc), 17, 30, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Trandiachongtang()
        Dim lists1 As New List(Of IPosition71)
        Dim Goc1 As Double = 270 + Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({23.26, 270.0, 20.1, 276.9, 19.65, 283.9, 18.91, 290.8, 17.89, 297.8, 15.9, 304.8, 13.82, 312.5, 11.69, 319.5, 9.51, 331.3, 8.28, 346.6, 11.0, 0.0, 8.28, 13.4, 9.51, 28.7, 11.69, 40.5, 13.82, 47.5, 15.9, 55.2, 17.89, 62.2, 18.91, 69.2, 19.65, 76.1, 20.1, 83.1, 23.25, 90.0, 20.1, 96.9, 19.65, 103.9, 18.91, 110.8, 17.89, 117.8, 15.22, 127.3, 12.98, 135.7, 10.25, 146.1, 8.28, 166.6, 11.0, 180.0, 8.28, 193.4, 10.25, 213.9, 12.98, 224.3, 15.22, 232.7, 17.24, 239.9, 18.91, 249.2, 19.65, 256.1, 18.05, 256.1, 17.21, 249.2, 15.07, 239.9, 12.92, 232.7, 10.13, 224.3, 8.22, 213.9, 6.73, 193.4, 6.5, 180.0, 6.73, 166.6, 8.22, 146.1, 10.13, 135.7, 12.92, 127.3, 15.76, 117.8, 17.21, 110.8, 18.05, 103.9, 18.56, 96.9, 18.74, 90.0, 18.56, 83.1, 18.05, 76.1, 17.21, 69.2, 15.76, 62.2, 13.65, 55.2, 11.11, 47.5, 9.24, 40.5, 7.65, 28.7, 6.73, 13.4, 6.5, 0.0, 6.73, 346.6, 7.65, 331.3, 9.23, 319.5, 11.11, 312.5, 13.65, 304.8, 15.76, 297.8, 17.21, 290.8, 18.05, 283.9, 18.56, 276.9, 18.74, 270.0, 18.56, 263.05, 18.05, 256.14, 16.44, 256.14, 17.01, 263.1, 17.23, 270.0, 17.01, 276.9, 16.44, 283.9, 15.51, 290.8, 13.31, 297.8, 10.69, 304.8, 8.35, 312.5, 6.96, 319.5, 5.84, 331.3, 5.17, 346.6, 5.0, 0.0, 5.17, 13.4, 5.84, 28.7, 6.96, 40.5, 8.35, 47.5, 10.69, 55.2, 13.37, 62.2, 15.51, 69.2, 16.44, 76.1, 17.01, 83.1, 17.23, 90.0, 17.01, 96.9, 16.44, 103.9, 15.51, 110.8, 13.37, 117.8, 9.65, 127.3, 7.55, 135.7, 6.24, 146.1, 5.17, 166.6, 5.0, 180.0, 5.17, 193.4, 6.24, 213.9, 7.55, 224.3, 9.65, 232.7, 12.67, 239.9, 15.51, 249.2, 16.44, 256.11, 19.58, 256.13, 20.1, 263.1, 7.0, 285.54, 7.28, 248.01, 8.33, 250.92, 7.86, 237.68, 9.57, 243.96, 10.2, 254.52, 11.8, 249.14, 13.52, 251.9, 12.1, 256.99, 13.21, 258.1, 13.36, 284.67, 11.15, 287.67, 11.7, 294.82, 10.36, 298.3, 9.73, 290.36, 7.61, 296.64, 7.0, 285.6, 11.58, 279.36, 11.49, 263.88, 8.34, 261.56, 8.46, 282.84, 10.89, 65.17, 12.26, 68.1, 11.39, 93.0, 12.39, 92.76, 12.55, 99.62, 11.56, 100.44, 11.64, 102.37, 13.68, 109.38, 12.17, 111.9, 11.23, 108.96, 10.95, 114.49, 9.5, 118.53, 10.19, 104.16, 10.1, 101.98, 9.13, 103.28, 8.9, 93.84, 9.9, 93.45, 8.5, 69.71, 9.92, 72.72, 9.48, 90.31, 7.98, 90.37, 12.23, 76.16, 13.69, 77.67, 13.37, 90.32, 11.87, 90.37})
        For i As Integer = 0 To 75
            lists1.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1)(i))
        Next
        lists1.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1)(115))
        lists1.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1)(116))
        FVungList(lists1, 4294967295, 0, mauChu, 0, mauChu, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1), 117, 137, 4294967295, 0, mauChu, 0, mauChu, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1), 138, 154, 4294967295, 0, mauChu, 0, mauChu, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1), 155, 158, 4294967295, 0, mauChu, 0, mauChu, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1), 159, 162, 4294967295, 0, mauChu, 0, mauChu, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 30.0, Goc1), 37, 114, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
        SLenhve3DMs()
    End Sub

    Public Sub Muitiencongkep()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 500, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 500, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 500, 0, 0, 0) 'Diem giua
        Dim Pc12 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((P1.X + P2.X) * 0.5, (P1.Y + P2.Y) * 0.5, 0, 2, 500, 0, 0, 0) 'Diem giua
        Dim kcP1P2 As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y) / 12 '1210
        Dim Goc As Double = FGoc(P3, Pc12)
        Dim P31 As IPosition71 = P3.Move(Dorongduong * 3, Goc + 180, 0)
        Dim P32 As IPosition71 = P3.Move(Dorongduong * 5, Goc + 180, 0)
        'Phai
        Dim GocP As Double = FGoc(P3, P2) - 20
        Dim P2MT As IPosition71 = P2.Move(Dorongduong * 7, GocP, 0)
        Dim Pc2p As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((P2MT.X + P3.X) * 0.5, (P2MT.Y + P3.Y) * 0.5, 0, 2, 500, 0, 0, 0) 'Diem giua
        Dim KcP As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P2MT.X, P2MT.Y, P3.X, P3.Y) / 6
        Dim PpP As IPosition71 = Pc2p.Move(KcP - Dorongduong, GocP + 270, 0)
        Dim PpP1 As IPosition71 = Pc2p.Move(KcP - Dorongduong * 4, GocP + 270, 0)
        Dim PpP2 As IPosition71 = Pc2p.Move(KcP - Dorongduong * 6, GocP + 270, 0)
        'Trai
        Dim GocT As Double = FGoc(P3, P1) + 15
        Dim P1MT As IPosition71 = P1.Move(Dorongduong * 7, GocT, 0)
        Dim liMTtrai As List(Of IPosition71) = Muiten(P1, P1MT, GocT + 180, 1.0, 1.0)
        Dim liMTphai As List(Of IPosition71) = Muiten(P2, P2MT, GocP + 180, 1.0, 1.0)
        Dim Pc1t As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((P1MT.X + P3.X) * 0.5, (P1MT.Y + P3.Y) * 0.5, 0, 2, 500, 0, 0, 0) 'Diem giua
        Dim KcT As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1MT.X, P1MT.Y, P3.X, P3.Y) / 6
        Dim PtT As IPosition71 = Pc1t.Move(KcT - Dorongduong, GocT + 90, 0)
        Dim PtT1 As IPosition71 = Pc1t.Move(KcT - Dorongduong * 4, GocT + 90, 0)
        Dim PtT2 As IPosition71 = Pc1t.Move(KcT - Dorongduong * 6, GocT + 90, 0)
        'LiPoint
        Dim liD1 As New List(Of IPosition71) From {liMTphai(3), PpP, P3, PtT, liMTtrai(2)}
        Dim liTD1Curve As List(Of IPosition71) = Curveline(liD1, 12) ' From {P1, PtT, Pt}
        Dim liD2 As New List(Of IPosition71) From {liMTtrai(3), PtT1, P31, PpP1, liMTphai(2)}
        Dim liTD2Curve As List(Of IPosition71) = Curveline(liD2, 12) ' From {P1, PtT, Pt}
        Dim liD3 As New List(Of IPosition71) From {liMTphai(2), PpP2, P32, PtT2, liMTtrai(3)}
        Dim liTD3Curve As List(Of IPosition71) = Curveline(liD3, 12) ' From {P1, PtT, Pt}
        UniCruve(liTD1Curve, liTD2Curve)
        UniCruve(liTD3Curve, liTD2Curve)
        Dim GeoMT_Trai As IGeometry = ListtoGeo(liMTtrai)
        Dim GeoMT_Phai As IGeometry = ListtoGeo(liMTphai)
        Dim GeoDem As IGeometry = ListtoGeo(liTD3Curve)
        Dim Geo1 As IGeometry = ListtoGeo(liTD1Curve)
        Dim GeoChinh As IGeometry = GeoMT_Trai.SpatialOperator.Union(Geo1)
        Dim GeoChinh1 As IGeometry = GeoChinh.SpatialOperator.Union(GeoMT_Phai)
        VungFormGeo(GeoChinh1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        VungFormGeo(GeoDem, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Sucsaotruylung() 'good
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({45.44, 55.13, 39.47, 75.75, 35.7, 100.13, 35.31, 126.71, 37.93, 152.11, 43.3, 173.98, 50.16, 192.23, 57.64, 207.7, 65.13, 221.26, 72.23, 233.53, 78.67, 244.93, 84.23, 255.72, 88.75, 266.11, 91.73, 261.58, 104.48, 285.12, 76.32, 265.09, 83.21, 267.6, 78.52, 257.08, 73.11, 246.67, 66.81, 235.68, 59.81, 223.86, 52.38, 210.75, 44.86, 195.66, 37.82, 177.5, 32.16, 154.91, 29.13, 127.56, 29.75, 98.5, 33.79, 72.59, 39.81, 52.05, 35.75, 49.17, 30.96, 65.09, 27.18, 84.27, 25.04, 106.73, 25.05, 130.66, 27.21, 153.1, 31.0, 172.26, 38.33, 193.72, 46.65, 210.35, 55.1, 224.08, 63.22, 236.1, 70.69, 247.05, 77.29, 257.32, 37.614, 248.7, 32.961, 274.3, 32.007, 303.3, 35.112, 330.9, 41.213, 353.8, 48.91, 12.2, 57.187, 27.5, 65.407, 40.7, 73.157, 52.5, 80.155, 63.6, 86.193, 74.0, 91.116, 84.1, 94.81, 93.9, 98.165, 90.0, 108.523, 112.4, 82.493, 92.4, 89.146, 95.1, 85.325, 85.1, 80.549, 75.5, 74.677, 65.4, 67.847, 54.9, 60.238, 43.5, 52.099, 30.8, 43.787, 16.1, 35.887, 358.0, 29.417, 334.4, 26.005, 304.2, 27.064, 272.0, 31.889, 245.3, 27.77, 241.9, 23.686, 263.3, 21.75, 289.3, 22.599, 316.3, 25.932, 339.7, 30.854, 358.3, 36.578, 13.2, 42.923, 26.3, 45.484, 29.8, 54.5, 43.3, 63.134, 55.1, 71.077, 65.7, 78.112, 75.7, 84.077, 85.3})
        FVungPoint(ArrayPoint(TQ, Pc, 20.0, Goc1), 42, 70, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 20.0, Goc1), 58, 84, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        If Lenhve = "quanlon" Or Lenhve = "QuanlonDP" Then
            FVungPoint(ArrayPoint(TQ, Pc, 20.0, Goc1), 0, 28, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, Pc, 20.0, Goc1), 16, 41, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        Else
            FVungPoint(ArrayPoint(TQ, Pc, 20.0, Goc1), 0, 28, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, Pc, 20.0, Goc1), 16, 41, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub Tiencong_Dung() 'good
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({21.52, 270.0, 21.41, 271.5, 20.98, 274.5, 20.3, 277.2, 19.38, 279.7, 18.27, 281.7, 17.03, 283.0, 3.96, 345.4, 15.43, 352.5, 17.26, 353.6, 18.97, 355.9, 20.49, 359.0, 21.76, 2.7, 22.74, 6.8, 23.41, 11.1, 23.75, 15.5, 23.75, 20.0, 23.4, 24.4, 22.73, 28.7, 24.43, 27.9, 19.69, 54.2, 20.11, 21.7, 20.92, 26.4, 21.47, 23.0, 21.74, 19.5, 21.74, 16.0, 21.47, 12.5, 20.95, 9.2, 20.19, 6.2, 19.22, 3.6, 18.07, 1.5, 16.8, 0.2, 15.3, 0.0, 3.96, 14.6, 17.03, 77.0, 18.27, 78.3, 19.38, 80.3, 20.3, 82.8, 20.98, 85.5, 21.41, 88.5, 21.52, 90.0, 19.24, 90.0, 19.2, 88.9, 18.65, 86.2, 17.77, 84.3, 16.71, 83.6, 16.71, 276.4, 17.73, 275.7, 18.65, 273.8, 19.19, 271.2, 19.24, 270.0, 21.81, 320.9, 23.43, 317.9, 24.71, 323.3, 25.59, 328.8, 25.63, 329.5, 27.61, 328.8, 27.96, 332.9, 26, 333.8, 26.07, 334.4, 26.13, 340.1, 25.76, 345.8, 23.82, 344.7, 24.13, 339.8, 24.08, 334.9, 23.67, 330.1, 22.9, 325.4, 29.17, 31.3, 29.75, 36.2, 29.87, 41.2, 29.82, 41.8, 31.8, 42.3, 31.56, 45.9, 29.57, 45.6, 29.54, 46.1, 28.77, 51.0, 27.56, 55.6, 25.91, 53.2, 26.93, 49.4, 27.59, 45.3, 27.87, 41.0, 27.77, 36.8, 27.28, 32.6})
        ArrayPoint(TQ, FrmMain.Instance.mPointClick, 45.0, Goc1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 45.0, Goc1), 0, 50, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 45.0, Goc1), 41, 50, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 45.0, Goc1), 51, 66, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 45.0, Goc1), 67, 82, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Tiencong_Quaylai() 'good
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({21.52, 270.0, 21.41, 271.5, 20.98, 274.5, 20.3, 277.2, 19.38, 279.7, 18.27, 281.7, 17.03, 283.0, 4.0, 345.4, 20.18, 344.6, 24.63, 346.1, 26.75, 347.4, 28.68, 349.6, 30.34, 352.4, 31.66, 355.6, 32.6, 359.2, 33.13, 2.0, 33.24, 6.7, 32.91, 10.4, 32.17, 14.1, 31.02, 17.5, 29.52, 20.5, 27.72, 23.0, 25.68, 24.8, 17.08, 27.7, 18.33, 31.7, 7.29, 30.8, 18.04, 16.1, 16.91, 21.0, 25.22, 20.4, 26.81, 19.3, 28.24, 17.4, 29.44, 15.1, 30.36, 12.5, 30.96, 9.5, 31.22, 6.5, 31.14, 3.4, 30.71, 0.4, 29.95, 357.6, 28.89, 355.1, 27.58, 353.0, 26.06, 351.5, 24.03, 350.7, 19.91, 350.3, 4.0, 16.7, 17.03, 77.0, 18.27, 78.3, 19.38, 80.3, 20.3, 82.8, 20.98, 85.5, 21.41, 88.5, 21.52, 90.0, 19.24, 90.0, 19.2, 88.9, 18.65, 86.2, 17.77, 84.3, 16.71, 83.6, 16.71, 276.4, 17.73, 275.7, 18.65, 273.8, 19.19, 271.2, 19.24, 270.0})
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1 + 90), 0, 60, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1 + 90), 50, 60, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()

    End Sub

    Public Sub Tiencong_VeXP() 'good
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({21.52, 270.0, 21.41, 271.5, 20.98, 274.5, 20.3, 277.2, 19.38, 279.7, 18.27, 281.7, 17.03, 283.0, 17.03, 77.0, 18.27, 78.3, 19.38, 80.3, 20.3, 82.8, 20.98, 85.5, 21.41, 88.5, 21.52, 90.0, 19.24, 90.0, 19.2, 88.9, 18.65, 86.2, 17.77, 84.3, 16.71, 83.6, 16.71, 276.4, 17.73, 275.7, 18.65, 273.8, 19.19, 271.2, 19.24, 270.0, 2.96, 345.6, 12.84, 344.8, 15.01, 346.0, 17.07, 348.5, 18.91, 351.7, 20.45, 355.4, 21.64, 359.4, 22.43, 3.7, 22.8, 8.1, 22.75, 12.8, 22.3, 17.5, 21.46, 22.4, 20.3, 27.2, 18.86, 32.0, 15.48, 40.5, 12.67, 49.3, 7.97, 105.9, 9.34, 98.9, 12.51, 157.5, 4.41, 95.4, 5.97, 107.5, 11.48, 41.6, 14.52, 33.8, 17.5, 27.3, 18.74, 23.5, 19.72, 19.5, 20.4, 15.7, 20.75, 12.0, 20.79, 8.6, 20.52, 5.5, 19.96, 2.5, 19.07, 359.6, 17.86, 357.0, 16.37, 354.9, 14.68, 353.7, 12.83, 353.8, 3.13, 23.7})
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1), 24, 59, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1), 13, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()

    End Sub

    Public Sub Donlong()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI + 90
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
        Dim TQ As New List(Of Double)({10.61, 270.0, 10.61, 0.0, 10.61, 90.0, 8.75, 104.0, 7.5, 98.1, 8.49, 90.0, 6.85, 73.8, 5.58, 81.3, 4.85, 66.8, 6.26, 61.7, 6.07, 36.5, 4.59, 33.7, 5.1, 16.9, 6.46, 23.2, 7.77, 5.5, 6.53, 6.6, 6.53, 353.4, 7.77, 354.5, 6.46, 336.8, 5.1, 343.1, 4.59, 326.3, 6.07, 323.5, 6.26, 298.3, 4.85, 293.2, 5.58, 278.7, 6.85, 286.2, 8.49, 270.0, 7.5, 261.9, 8.75, 256.0, 4.2, 0.0, 2.83, 148.2, 1.6, 161.2, 9.62, 175.6, 9.62, 184.4, 1.6, 198.8, 2.83, 211.8, 10.61, 270.0, 10.61, 0.0, 10.61, 90.0, 11.34, 86.4, 12.02, 0.0, 11.34, 273.6})
        FVungPoint(ArrayPoint(TQ, P1, 40.0, Goc1), 0, 28, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, P1, 40.0, Goc1), 36, 41, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, P1, 40.0, Goc1), 29, 35, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Vaylan()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.mPoint.Move(50 * Tyle, 270 - Goc1, 0)
        Dim TQ As New List(Of Double)({21.3, 296.6, 20.88, 300.5, 8.16, 275.3, 8.16, 84.7, 20.88, 59.5, 21.82, 67.1, 20.44, 68.7, 19.88, 64.7, 17.37, 67.7, 18.0, 72.2, 16.68, 74.5, 15.99, 69.8, 13.59, 74.6, 14.39, 79.8, 13.19, 83.5, 12.31, 78.1, 10.27, 85.8, 11.52, 86.3, 11.52, 93.7, 10.27, 94.2, 12.31, 101.9, 13.19, 96.5, 14.39, 100.2, 13.59, 105.4, 15.99, 110.2, 16.68, 105.5, 18.0, 107.8, 17.37, 112.3, 19.88, 115.3, 20.44, 111.3, 21.82, 112.9, 20.88, 120.5, 8.16, 95.3, 8.16, 264.7, 20.88, 239.5, 21.3, 243.4, 9.5, 270.0, 21.71, 293.6, 21.3, 296.6, 9.5, 270.0, 21.3, 243.4, 21.71, 246.4, 11.19, 270.0, 10.27, 85.8, 19.88, 64.7, 20.32, 67.9, 11.19, 90.0, 20.32, 112.1, 19.88, 115.3, 10.27, 94.2})
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1), 0, 36, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1), 37, 42, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1), 43, 49, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Phuckich()
        Phuckich1(FrmMain.Instance.mPointClick)
        SLenhve3DMs()
    End Sub

    Public Sub Phuckich1(P As IPosition71)
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim TQ As New List(Of Double)({8.0, 0.0, 7.53, 12.83, 7.08, 26.53, 6.68, 41.18, 6.37, 56.78, 6.17, 70.38, 18.94, 66.75, 17.48, 61.58, 28.41, 68.18, 17.94, 78.53, 19.1, 72.76, 6.1, 90.0, 19.1, 107.24, 17.94, 101.47, 28.41, 111.82, 17.48, 118.42, 18.94, 113.25, 6.17, 109.62, 6.37, 123.22, 6.68, 138.82, 7.08, 153.47, 7.53, 167.17, 8.0, 180.0, 6.05, 180.0, 5.61, 172.48, 5.15, 158.78, 4.73, 143.68, 4.39, 127.03, 4.17, 108.96, 4.09, 90.0, 4.17, 71.04, 4.39, 52.97, 4.73, 36.32, 5.15, 21.22, 5.61, 7.52, 5.85, 0.0, 3.88, 0.0, 3.48, 11.48, 3.03, 26.65, 2.65, 44.69, 2.38, 66.08, 2.28, 90.0, 2.38, 113.92, 2.65, 135.31, 3.03, 153.35, 3.48, 168.49, 3.88, 180.0})
        Dim LiT As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, P, 35.0, MkGoc(P1, P2) * 180 / Math.PI)
        Dim LiC, LiD As New List(Of IPosition71)
        AddPointToList(LiC, LiT, 0, 35)
        AddPointToList(LiD, LiT, 23, 46)
        If Not Lenhve = "TsatBangChiendau" Then
            FVungList(LiC, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
        Else
            Dim Pc As IPosition71 = CenterPoint(P1, P2)
            LiC.RemoveRange(12, 5)
            LiC.RemoveRange(6, 5)
            Dim LiMT1 As List(Of IPosition71) = Muiten(P1, LiC(19), FGoc(P1, P2), 0.55, 1.0)
            Dim Pkich As New List(Of Double)({71.4, 90, 36.78, 90, 63.83, 0, 36.78, 270, 71.4, 270, 123.93, 0})
            '({71.4, 90, 79.14, 0, 71.4, 270, 111.8, 270, 123.93, 0, 111.8, 90})
            Dim LiPkich As List(Of IPosition71) = ArDisAgreetoLiPoint(Pkich, P1, 3.0, 270 + MkGoc(P1, P2) * 180 / Math.PI)
            Dim Pc1 As IPosition71 = Pc.Move(Dorongduong * 1.5, FGoc(P1, P2), 0)
            Dim Pc2 As IPosition71 = Pc.Move(-Dorongduong * 1.5, FGoc(P1, P2), 0)
            Dim LiGach1 As List(Of IPosition71) = FGach(Pc1, 90 + MkGoc(P1, P2) * 180 / Math.PI)
            Dim LiGach2 As List(Of IPosition71) = FGach(Pc2, 90 + MkGoc(P1, P2) * 180 / Math.PI)
            Dim Geo1 As IGeometry = ListtoGeo(LiC).SpatialOperator.Union(ListtoGeo(LiMT1))
            Dim Geo2 As IGeometry = Geo1.SpatialOperator.Union(ListtoGeo(LiGach1))
            Dim Geo3 As IGeometry = Geo2.SpatialOperator.Union(ListtoGeo(LiGach2))
            FVungList(LiPkich, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            FVungList(GeoToList(Geo3), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            MakeText(P2, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "TS", "", mauChu, 0, 0, 2, 2)
        End If

        FVungList(LiD, 4294967295, 0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
    End Sub

    Public Function FGach(Pc As IPosition71, Goc As Double) As List(Of IPosition71)
        Dim Pkich As New List(Of Double)({71.4, 90, 71.4, 270, 77.45, 292.79, 77.45, 67.21})
        Dim LiP As List(Of IPosition71) = ArDisAgreetoLiPoint(Pkich, Pc, 2.8, Goc)
        FGach = LiP
    End Function

    Public Sub CongsuTQ(Goc As Double, p1 As IPosition71)
        Dim TlE As Double
        If Lenhve = "CongNongLamtruongCD" Then
            TlE = 2.0
        ElseIf Lenhve = "XTBantructiep" Then
            TlE = 3.0
        Else
            TlE = 4.0
        End If
        Dim TQ As New List(Of Double)({86.93, 323.61, 105.5, 357.02, 76.99, 8.51, 64.99, 347.12, 41, 351.82, 14.1, 0, 32.22, 58.54, 32.23, 121.46, 14.1, 180, 41, 188.18, 64.99, 192.89, 76.98, 171.5, 105.48, 182.98, 86.92, 216.39, 57.2, 219.74, 32.47, 242.49, 32.48, 297.53, 57.21, 320.27, 86.93, 323.61, 88.86, 310.5, 66.06, 303.31, 50.35, 284.23, 50.34, 255.78, 66.05, 236.7, 88.85, 229.51})
        If Lenhve = "DhinhBaovaydich" Or Lenhve = "BanChsangChihuongTC" Then
            FVungPoint(ArrayPoint(TQ, p1, TlE, Goc), 0, 18, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 1)
        ElseIf Lenhve = "CongNongLamtruongCD" Then
            FVungPoint(ArrayPoint(TQ, p1, TlE, Goc), 0, 18, 4294967295, 0, mau, 0, mauRedBlue, 1, "", 1, 1, 0, False, 2, 1)
        Else
            FVungPoint(ArrayPoint(TQ, p1, TlE, Goc), 0, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)
        End If
        If Not Lenhve = "CongNongLamtruongCD" And Not Lenhve = "DhinhBaovaydich" And Not Lenhve = "XTBantructiep" And Not Lenhve = "BanChsangChihuongTC" Then
            FVungPoint(ArrayPoint(TQ, p1, TlE, Goc), 13, 24, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2)
        End If
    End Sub

    Public Sub DiemtuaTQ()
        Dim P01 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P02 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)

        Dim Goc2 As Double = MkGoc(P01, P02) * 180 / Math.PI
        Dim Goc3 As Double = FGoc(P01, P02)
        If Lenhve = "congsu" Then
            CongsuTQ(Goc2, P02)
        ElseIf Lenhve = "DiemtuaTrungdoi" Then
            CumPNTRungdoi(P02, Goc3)
        ElseIf Lenhve = "DiemtuaDaidoi" Then
            CumPNDaidoi(P02, Goc3)
        End If
        SLenhve3DMs()
    End Sub

    Private Sub CumPNTRungdoi(P As IPosition71, Goc As Double)
        Dim P1 As IPosition71 = P.Move(-Dorongduong * 8, Goc, 0)
        Dim P2 As IPosition71 = P.Move(Dorongduong * 8, Goc, 0)
        CongsuTQ(MkGoc(P2, P1) * 180 / Math.PI, P2)
        CongsuTQ(MkGoc(P1, P2) * 180 / Math.PI, P1)
        SLenhve3DMs()
    End Sub

    Private Sub CumPNDaidoi(P As IPosition71, Goc As Double)
        Dim K1 As IPosition71 = P.Move(Dorongduong * 12, Goc + 60, 0)
        Dim K2 As IPosition71 = P.Move(Dorongduong * 20, Goc + 60, 0)
        CongsuTQ(MkGoc(K2, K1) * 180 / Math.PI, K1)
        Dim M1 As IPosition71 = P.Move(Dorongduong * 12, Goc + 300, 0)
        Dim M2 As IPosition71 = P.Move(Dorongduong * 20, Goc + 300, 0)
        CongsuTQ(MkGoc(M2, M1) * 180 / Math.PI, M1)
        Dim P1 As IPosition71, P2 As IPosition71
        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or Lenhve = "DiemtuaDaidoi" Then
            P1 = P.Move(-Dorongduong * 12, Goc, 0)
            P2 = P.Move(-Dorongduong * 20, Goc, 0)
            CongsuTQ(MkGoc(P2, P1) * 180 / Math.PI, P1)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then
            P2 = P.Move(-Dorongduong * 12, Goc, 0)
            P1 = P.Move(-Dorongduong * 18, Goc, 0)
            CongsuTQ(MkGoc(P1, P2) * 180 / Math.PI, P1)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub CoiLui(P As IPosition71, Goc As Double, Gmau As IColor71, Heso As Double)
        Dim TQ As New List(Of Double)({3.54, 0.0, 5.43, 30.28, 4.28, 39.89, 3.51, 33.06, 3.55, 47.32, 3.58, 61.45, 3.6, 75.49, 3.6, 90.0, 3.6, 103.56, 3.6, 117.69, 3.6, 131.95, 3.46, 146.39, 4.22, 139.33, 5.37, 149.25, 3.22, 206.67, 3.18, 222.41, 3.15, 238.35, 3.13, 254.43, 3.12, 268.8, 4.1, 229.64, 5.22, 239.44, 5.23, 300.78, 4.11, 310.61, 3.12, 271.55, 3.14, 286.64, 3.17, 302.58, 3.22, 318.32, 3.27, 333.81, 3.54, 359.86, 1.87, 359.83, 1.87, 330.0, 1.87, 300.0, 1.87, 270.0, 1.87, 240.0, 1.87, 210.0, 1.87, 180.0, 1.87, 150.0, 1.87, 120.0, 1.87, 90.0, 1.87, 60.0, 1.87, 30.0, 1.87, 0.0})
        Dim Lic As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, P, Heso, Goc)
        FVungList(Lic, 4294967295, 0.0, mau2, 0, Gmau, 1, "", 0, 0, 0, False, 2, 2)
    End Sub

    Public Sub PNtiepxuc()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.mPoint.Move(50 * Tyle, 270 - Goc1, 0)
        Dim TQ As New List(Of Double)({12.8, 317.6, 11.56, 321.7, 10.63, 314.3, 10.03, 315.6, 7.89, 317.8, 7.25, 317.4, 7.08, 331.0, 5.58, 331.3, 5.74, 316.1, 3.81, 304.2, 3.07, 284.2, 1.56, 298.8, 1.56, 241.2, 3.07, 255.8, 3.81, 235.8, 5.74, 223.9, 5.58, 208.7, 7.08, 209.0, 7.25, 222.6, 7.89, 222.2, 10.03, 224.4, 10.63, 225.7, 11.56, 218.3, 12.79, 222.4, 11.45, 235.2, 9.73, 233.0, 7.96, 233.1, 6.28, 237.4, 4.94, 249.2, 4.39, 270.0, 4.94, 290.8, 6.28, 302.6, 7.96, 306.9, 9.73, 307.0, 11.45, 304.8, 11.1, 298.9, 9.66, 299.9, 8.22, 298.5, 6.92, 293.6, 5.96, 283.9, 5.6, 270.0, 5.96, 256.1, 6.92, 246.4, 8.22, 241.5, 9.66, 240.1, 11.1, 241.1, 12.8, 137.6, 11.56, 141.7, 10.63, 134.3, 10.03, 135.6, 7.89, 137.8, 7.25, 137.4, 7.08, 151.0, 5.58, 151.3, 5.74, 136.1, 3.81, 124.2, 3.07, 104.2, 1.56, 118.8, 1.56, 61.2, 3.07, 75.8, 3.81, 55.8, 5.74, 43.9, 5.58, 28.7, 7.08, 29.0, 7.25, 42.6, 7.89, 42.2, 10.03, 44.4, 10.63, 45.7, 11.56, 38.3, 12.79, 42.4, 11.45, 55.2, 9.73, 53.0, 7.96, 53.1, 6.28, 57.4, 4.94, 69.2, 4.39, 90.0, 4.94, 110.8, 6.28, 122.6, 7.96, 126.9, 9.73, 127.0, 11.45, 124.8, 11.1, 118.9, 9.66, 119.9, 8.22, 118.5, 6.92, 113.6, 5.96, 103.9, 5.6, 90.0, 5.96, 76.1, 6.92, 66.4, 8.22, 61.5, 9.66, 60.1, 11.1, 61.1})
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 0, 34, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 24, 45, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 46, 80, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 70, 91, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Tapkich()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.mPoint.Move(50 * Tyle, 270 - Goc1, 0)
        Dim TQ As New List(Of Double)({10.14, 242.5, 10.28, 250.9, 8.65, 252.7, 8.72, 256.9, 8.66, 266.2, 10.21, 267.0, 10.21, 275.4, 8.66, 276.1, 8.71, 285.4, 8.63, 289.7, 10.26, 291.5, 10.12, 299.9, 6.9, 299.3, 6.93, 284.6, 6.95, 270.0, 6.96, 255.4, 6.93, 243.0, 9.72, 149.7, 9.98, 158.4, 8.38, 161.1, 8.51, 165.4, 8.59, 174.8, 10.15, 174.7, 10.27, 183.1, 8.73, 184.7, 8.92, 193.8, 8.91, 197.9, 10.55, 198.9, 10.52, 207.1, 7.3, 208.3, 7.14, 194.3, 6.95, 180.0, 6.74, 165.3, 6.53, 152.4, 9.72, 329.7, 9.98, 338.4, 8.38, 341.1, 8.51, 345.4, 8.59, 354.8, 10.15, 354.7, 10.27, 3.1, 8.73, 4.7, 8.92, 13.8, 8.91, 17.9, 10.55, 18.9, 10.52, 27.1, 7.3, 28.3, 7.14, 14.3, 6.95, 360.0, 6.74, 345.3, 6.53, 332.4, 16.82, 104.7, 4.9, 90.0, 17.11, 72.0, 17.57, 67.9, 1.8, 90.0, 17.19, 108.8, 17.78, 113.7, 2.38, 270.0, 18.25, 63.1})
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 0, 16, 4294967295, 0, mau, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 17, 33, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 34, 50, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 51, 56, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, Pc, 45.0, Goc1), 54, 59, 4294967295, 0, mau3, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub DoihinhBbXPquaCuamo()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Goc As Double = FGoc(P1, P2)
        Dim KC As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P2.X, P2.Y, P3.X, P3.Y)
        Dim P21 As IPosition71 = P2.Move(KC, Goc + 275, 0)
        Dim Goc1 As Double = FGoc(P2, P21)
        Dim K1 As Double, K2 As Double
        If Goc < 180 Then
            K1 = 270
            K2 = 90
        Else
            K1 = 90
            K2 = 270
        End If
        Dim GeoMT As IGeometry = ListtoGeo(Muiten(P1, P2, Goc, 1, 1.0))
        Dim P4 As IPosition71 = P2.Move(-Dorongduong * 2, Goc, 0)
        Dim P5 As IPosition71 = P2.Move(-Dorongduong * 4, Goc, 0)
        Dim LiP2 As List(Of IPosition71) = Curveline(PointFormPDoihinh(KC, K1, K2, Goc, Goc1, P2), 12)
        Dim LiP4 As List(Of IPosition71) = Curveline(PointFormPDoihinh(KC, K1, K2, Goc, Goc1, P4), 12)
        Dim LiP5 As List(Of IPosition71) = Curveline(PointFormPDoihinh(KC, K1, K2, Goc, Goc1, P5), 12)
        LiP4.Reverse()
        UniCruve(LiP2, LiP4)
        UniCruve(LiP5, LiP4)
        Dim GeoChinh As IGeometry = GeoMT.SpatialOperator.Union(ListtoGeo(LiP2))
        FVungList(GeoToList(GeoChinh), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        FVungList(LiP5, 4294967295, 0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)

        SLenhve3DMs()
    End Sub

    Function PointFormPDoihinh(Kc As Double, K1 As Double, K2 As Double, Goc As Double, Goc1 As Double, P5 As IPosition71) As List(Of IPosition71)
        Dim P51 As IPosition71 = P5.Move(Kc, Goc + 275, 0)
        Dim P52 As IPosition71 = P5.Move(Kc, Goc + 95, 0)
        Dim P5c1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P5.X + P51.X), 0.5 * (P5.Y + P51.Y), 0, 2, 0, 0, 0, 0)
        Dim P5c2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P52.X + P5.X), 0.5 * (P52.Y + P5.Y), 0, 2, 0, 0, 0, 0)
        Dim P5c11 As IPosition71 = P5c1.Move(Kc / 6, Goc1 + K1, 0)
        Dim P5c21 As IPosition71 = P5c2.Move(Kc / 6, Goc1 + K2, 0)
        Dim liPiont2 As New List(Of IPosition71) From {P51, P5c11, P5, P5c21, P52}
        PointFormPDoihinh = liPiont2
    End Function

#Region "    Doi hinh trien khai Tc"


    Public Hesodichchuyen As Double
    ReadOnly GeoArray As New List(Of IGeometry)
    ReadOnly GeoBBXT As New List(Of IGeometry)
    Private liChinh As New List(Of IPosition71), liDemC As New List(Of IPosition71), liXtT As New List(Of IPosition71),
            liXtP As New List(Of IPosition71), liXtT1 As New List(Of IPosition71), liXtP1 As New List(Of IPosition71)

    Public Sub DoihinhTrkhaiTC()
        liXtT.Clear()
        liXtT1.Clear()
        liXtP.Clear()
        liXtP1.Clear()
        liChinh.Clear()
        liDemC.Clear()
        GeoArray.Clear()
        GeoBBXT.Clear()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim KC As Double = FKc(P1, P3) / 2
        Dim GYaw As Double
        Dim G1 As Double = FGoc(P1, P2)
        Dim G2 As Double = FGoc(P1, P3)

        If G1 > G2 Then
            GYaw = FGoc(P1, P3) + 270
        Else
            GYaw = FGoc(P1, P3) + 90
        End If

        'Cac diem giua
        Dim Pc As IPosition71 = CenterPoint(P1, P3)
        Dim Pc1 As IPosition71 = Pc.Move(-Dorongduong * 2, G2 + 90, 0)
        Dim Pc2 As IPosition71 = Pc1.Move(-Dorongduong * 2, G2 + 90, 0)
        Dim ChieudaiMuiTC As Double = 23 * Dorongduong

        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then 'Trung đội ...
            ChieudaiMuiTC = ChieudaiMuiTC
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Then 'Đại đội ...
            ChieudaiMuiTC += Dorongduong * 4
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then 'Tiểu đoàn ...
            ChieudaiMuiTC += Dorongduong * 8
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex > 0 And FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex < 4 Then 'Sư đoàn, Lữ đoàn,Trung đoàn
            If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                ChieudaiMuiTC *= 1.5
            Else
                ChieudaiMuiTC *= 4 / 5
            End If
        ElseIf Lenhve = "DoihinhBBTamdung" Or Lenhve = "TuyenbanXT" Then
            ChieudaiMuiTC = Dorongduong * 4
        End If

        Dim MT1 As IPosition71, MT2 As IPosition71

        If Lenhve = "TuyenTrKTcBBtruocXT" Then
            Dim K1 As IPosition71
            If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex > 0 And FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex < 4 Then
                If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                    ChieudaiMuiTC -= Dorongduong * 2.0
                    K1 = Pc.Move(-Dorongduong * 8, G2 + 90, 0)
                Else
                    ChieudaiMuiTC += Dorongduong * 20.0
                    K1 = Pc.Move(-Dorongduong * 20, G2 + 90, 0)
                End If
            Else
                ChieudaiMuiTC += Dorongduong * 16.0
                K1 = Pc.Move(-Dorongduong * 16, G2 + 90, 0)
            End If
            MT1 = K1.Move(ChieudaiMuiTC, GYaw, 0)
            MT2 = K1.Move(-Dorongduong, GYaw, 0)
        ElseIf Lenhve = "TuyenTrKTcXTtruocBB" Then
            Dim K1 As IPosition71
            If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                K1 = Pc.Move(Dorongduong * 10, G2 + 90, 0)
            Else
                K1 = Pc.Move(Dorongduong * 12, G2 + 90, 0)
            End If
            MT1 = K1.Move(ChieudaiMuiTC, GYaw, 0)
            MT2 = Pc
        ElseIf Lenhve = "XTTiencong" Then
            MT1 = Pc.Move(ChieudaiMuiTC, GYaw, 0)
            MT2 = Pc.Move(Dorongduong, GYaw, 0)
        Else
            MT1 = Pc.Move(ChieudaiMuiTC, GYaw, 0)
            MT2 = Pc.Move(-Dorongduong, GYaw, 0)
        End If

        Dim GeoMuiten As IGeometry = ListtoGeo(Muiten(MT1, MT2, GYaw, 1.0, 1.0))
        '///////////////
        Dim GeoCC1 As IGeometry = Nothing, GeoNgang1 As IGeometry, GeoNgang2 As IGeometry, GeoNgang3 As IGeometry  ' = NetNg

        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then 'Trung đội ...
            If Lenhve = "TuyenTrKTcXTtruocBB" Then
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 15, G2 + 270)
            ElseIf Lenhve = "TuyenTrKTcBBtruocXT" Then
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 6, G2 + 270)
            Else
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 5, G2 + 270)
            End If
            GeoCC1 = GeoMuiten.SpatialOperator.Union(GeoNgang1)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Then 'Đại đội ...
            If Lenhve = "TuyenTrKTcXTtruocBB" Then
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 15, G2 + 270)
                GeoNgang2 = NetNgangMT(Pc, -Dorongduong * 19, G2 + 270)
            Else
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 5, G2 + 270)
                GeoNgang2 = NetNgangMT(Pc, -Dorongduong * 9, G2 + 270)
            End If
            Dim GeoChinh4 As IGeometry = GeoMuiten.SpatialOperator.Union(GeoNgang1)
            GeoCC1 = GeoChinh4.SpatialOperator.Union(GeoNgang2)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then 'Tiểu đoàn ...
            If Lenhve = "TuyenTrKTcXTtruocBB" Then
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 15, G2 + 270)
                GeoNgang2 = NetNgangMT(Pc, -Dorongduong * 19, G2 + 270)
                GeoNgang3 = NetNgangMT(Pc, -Dorongduong * 23, G2 + 270)
            Else
                GeoNgang1 = NetNgangMT(Pc, -Dorongduong * 5, G2 + 270)
                GeoNgang2 = NetNgangMT(Pc, -Dorongduong * 9, G2 + 270)
                GeoNgang3 = NetNgangMT(Pc, -Dorongduong * 13, G2 + 270)
            End If
            Dim GeoChinh4 As IGeometry = GeoMuiten.SpatialOperator.Union(GeoNgang1)
            Dim GeoChinh5 As IGeometry = GeoChinh4.SpatialOperator.Union(GeoNgang2)
            GeoCC1 = GeoChinh5.SpatialOperator.Union(GeoNgang3)
        End If

        GeoXt(P1, P3)
        GeoLudoanBB(GeoMuiten, Pc, Pc1, Pc2, P1, P3, KC + Dorongduong / 2, G2)

        If Lenhve = "XTTiencong" Then
            GeoCC1 = GeoMuiten
            XTTancong(P1, P3)
        End If

        If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
            GeoTieudoan(GeoCC1, Pc, KC, 1, G2)
        Else
            If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then 'Or Lenhve = "DoihinhBBTamdung"
                GeoTieudoan(GeoCC1, Pc, KC, 1, G2)
            ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
                GeoDaidoiTrungdoi(GeoCC1, P1, P3, G2)
            End If
        End If

        If Lenhve = "DoihinhBBTamdung" Or Lenhve = "TuyenbanXT" Then
            GeoArray.Clear()
            Dim Dai As Double
            If Lenhve = "DoihinhBBTamdung" Then
                Dai = 12
            Else
                Dai = 16
            End If
            Dim Pk1 As IPosition71 = MT2.Move(Dorongduong, FGoc(MT1, MT2) + 90, 0)
            Dim Pk2 As IPosition71 = MT2.Move(Dorongduong, FGoc(MT1, MT2) + 270, 0)
            Dim Pk3 As IPosition71 = Pk1.Move(Dorongduong * Dai, FGoc(MT1, MT2), 0)
            Dim Pk4 As IPosition71 = Pk2.Move(Dorongduong * Dai, FGoc(MT1, MT2), 0)
            Dim liPk As New List(Of IPosition71) From {Pk1, Pk3, Pk4, Pk2}
            If Lenhve = "DoihinhBBTamdung" Then
                GeoCC1 = ListtoGeo(liPk)
                GeoTieudoan(GeoCC1, Pc, KC, 1, G2)
            Else
                Dim N1 As IGeometry = ListtoGeo(liPk).SpatialOperator.Union(NetNgangMT(Pc, -Dorongduong * 5, G2 + 270))
                GeoCC1 = N1.SpatialOperator.Union(NetNgangMT(Pc, -Dorongduong * 9, G2 + 270))
                GeoDaidoiTrungdoi(GeoCC1, P1, P3, G2)
            End If

        End If
        '/////////////////
        If Lenhve = "TuyenTrKTcBobinh" Or Lenhve = "DoihinhBBTamdung" Then
            FVungList(GeoToList(GeoArray(0)), 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            FVungList(GeoToList(GeoArray(1)), 4294967295, 0.0, mau2, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        ElseIf Lenhve = "TuyenTrKTcBobinhXetang" Or Lenhve = "TuyenbanXT" Or Lenhve = "XTTiencong" Then
            If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex > 3 And FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex < 7 Then
                Dim GeC As IGeometry = GeoCC1.SpatialOperator.Union(GeoArray(0))
                liChinh = GeoToList(GeC)
            Else
                liChinh = GeoToList(GeoArray(0))
            End If
            TiencongBBXT(liChinh, liXtT, liXtP, GroupBac2Main, 4294967295, Dorongduong, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
            TiencongBBXT(GeoToList(GeoArray(1)), liXtT1, liXtP1, GroupBac2Main, 4294967295, Dorongduong / 1.5, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "2")
        ElseIf Lenhve = "TuyenTrKTcBBtruocXT" Or Lenhve = "TuyenTrKTcXTtruocBB" Then
            Dim GeoC As IGeometry = GeoArray(0).SpatialOperator.Union(GeoBBXT(0))
            FVungList(GeoToList(GeoC), 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            FVungList(GeoToList(GeoArray(1)), 4294967295, 0.0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
            FVungList(GeoToList(GeoBBXT(1)), 4294967295, 0.0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        End If

        If Lenhve = "TuyenbanXT" Then
            Dim Ks As IPosition71 = Pc.Move(1.25 * FKc(liXtT(0), liXtP(0)), 270 + FGoc(P3, P1), 0)
            Dim Ks1 As IPosition71 = Ks.Move(FKc(liXtT(0), liXtP(0)), FGoc(P3, P1), 0)
            Dim Ks2 As IPosition71 = Ks.Move(FKc(liXtT(0), liXtP(0)), 180 + FGoc(P3, P1), 0)
            Dim LiMT1 As List(Of IPosition71) = Muiten(Ks2, liXtT(0), FGoc(Ks2, liXtT(0)), 0.7, 1.0)
            Dim LiMT2 As List(Of IPosition71) = Muiten(Ks1, liXtP(0), FGoc(Ks1, liXtP(0)), 0.7, 1.0)
            FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If

        SLenhve3DMs()
    End Sub

    Private Sub XTTancong(P1 As IPosition71, P3 As IPosition71)
        GeoXt(P1, P3)
        Dim Pc As IPosition71 = CenterPoint(P1, P3)
        Dim Pc1 As IPosition71 = Pc.Move(Dorongduong * 1.5, 270 + FGoc(P3, P1), 0)
        Dim Pc2 As IPosition71 = Pc.Move(Dorongduong * 1.5, 90 + FGoc(P3, P1), 0)
        '//////////
        Dim Ks1 As IPosition71 = liXtP(8).Move(FKc(liXtT(0), liXtP(0)) / 2, FGoc(P3, P1), 0)
        Dim Ks11 As IPosition71 = Ks1.Move(Dorongduong * 1.5, 90 + FGoc(P3, P1), 0)
        Dim Ks12 As IPosition71 = Ks1.Move(Dorongduong * 3, 90 + FGoc(P3, P1), 0)
        '//////////////
        Dim Ks2 As IPosition71 = liXtT(8).Move(FKc(liXtT(0), liXtP(0)) / 2, 180 + FGoc(P3, P1), 0)
        Dim Ks21 As IPosition71 = Ks2.Move(Dorongduong * 1.5, 90 + FGoc(P3, P1), 0)
        Dim Ks22 As IPosition71 = Ks2.Move(Dorongduong * 3, 90 + FGoc(P3, P1), 0)
        '//////////
        Dim Pt As IPosition71 = CenterPoint(liXtT(0), liXtT(8))
        Dim Pt1 As IPosition71 = Pt.Move(Dorongduong * 1.5, 90 + FGoc(P3, P1), 0)
        Dim Pt2 As IPosition71 = Pt.Move(Dorongduong * 3, 90 + FGoc(P3, P1), 0)
        '//////////////
        Dim Pp As IPosition71 = CenterPoint(liXtP(0), liXtP(8))
        Dim Pp1 As IPosition71 = Pp.Move(Dorongduong * 1.5, 90 + FGoc(P3, P1), 0)
        Dim Pp2 As IPosition71 = Pp.Move(Dorongduong * 3, 90 + FGoc(P3, P1), 0)
        '////////////
        Dim L1 As New List(Of IPosition71) From {Ks2, Pt, Pc1, Pp, Ks1}
        Dim L3 As New List(Of IPosition71) From {Ks22, Pt2, Pc2, Pp2, Ks12}
        Dim L2 As New List(Of IPosition71) From {Ks21, Pt1, Pc, Pp1, Ks11}
        Dim L1cur As List(Of IPosition71) = Curveline(L1, 12)
        Dim L2cur As List(Of IPosition71) = Curveline(L2, 12)
        Dim L3cur As List(Of IPosition71) = Curveline(L3, 12)
        L2cur.Reverse()
        UniCruve(L1cur, L2cur)
        UniCruve(L3cur, L2cur)
        GeoArray.Add(ListtoGeo(L1cur))
        GeoArray.Add(ListtoGeo(L3cur))
    End Sub

    Private Sub GeoXt(P1 As IPosition71, P3 As IPosition71)  'ai As List(Of IPosition71), XTphai As List(Of IPosition71)) As IGeometry
        If Lenhve = "TuyenTrKTcBBtruocXT" Or Lenhve = "TuyenTrKTcBobinhXetang" Or Lenhve = "TuyenTrKTcXTtruocBB" Or Lenhve = "TuyenbanXT" Or Lenhve = "XTTiencong" Then
            Dim Pc As IPosition71 = CenterPoint(P1, P3)
            Dim kc As Double = FKc(P1, P3)
            Dim Pk As IPosition71 = Nothing
            Dim GeoT As New List(Of IGeometry)
            If Lenhve = "TuyenTrKTcBobinhXetang" Or Lenhve = "TuyenbanXT" Or Lenhve = "XTTiencong" Then
                If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex > 3 And FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex < 7 Then
                    Pk = Pc.Move(Dorongduong, FGoc(P1, P3) + 270, 0)
                Else
                    If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                        Pk = Pc.Move(Dorongduong * 6, FGoc(P1, P3) + 90, 0)
                    Else
                        Pk = Pc.Move(Dorongduong * 8, FGoc(P1, P3) + 270, 0)
                    End If
                End If
            ElseIf Lenhve = "TuyenTrKTcBBtruocXT" Then
                If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex > 3 And FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex < 7 Then
                    Pk = Pc.Move(-Dorongduong * 14, FGoc(P1, P3) + 90, 0)
                Else
                    If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                        Pk = Pc.Move(-Dorongduong * 8, FGoc(P1, P3) + 90, 0)
                    Else
                        Pk = Pc.Move(-Dorongduong * 20, FGoc(P1, P3) + 90, 0)
                    End If
                End If
                GeoT = GeoXTBBTruocSau(Pk, kc / 4 - Dorongduong * 4, FGoc(P1, P3))
            ElseIf Lenhve = "TuyenTrKTcXTtruocBB" Then
                If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
                    Pk = Pc.Move(-Dorongduong * 8, FGoc(P1, P3) + 270, 0)
                Else
                    If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                        Pk = Pc.Move(-Dorongduong * 17, FGoc(P1, P3) + 270, 0)
                    Else
                        Pk = Pc.Move(-Dorongduong * 8, FGoc(P1, P3) + 270, 0)
                    End If
                End If
                GeoT = GeoXTBBTruocSau(Pk, kc / 4 - Dorongduong * 4, FGoc(P1, P3))
            End If
            Dim Pt As IPosition71 = Pk.Move(kc / 4, FGoc(P1, P3), 0)
            Dim Pp As IPosition71 = Pk.Move(kc / 4, FGoc(P1, P3) + 180, 0)
            '//////////////
            liXtT = LiPXTdoc(Pt, 1.5, 90.0 + MkGoc(P1, P3) * 180 / Math.PI)
            liXtP = LiPXTdoc(Pp, 1.5, 90.0 + MkGoc(P1, P3) * 180 / Math.PI)
            liXtT1 = LiPXTdocDem(Pt, 1.5, 90.0 + MkGoc(P1, P3) * 180 / Math.PI)
            liXtP1 = LiPXTdocDem(Pp, 1.5, 90.0 + MkGoc(P1, P3) * 180 / Math.PI)
            If Lenhve = "TuyenTrKTcBobinhXetang" Or Lenhve = "TuyenbanXT" Or Lenhve = "XTTiencong" Then
                'GeoBBXT.Add(ListtoGeoTQ(FrmMain.Instance.sgworldMain, liXtT))
                'GeoBBXT.Add(ListtoGeoTQ(FrmMain.Instance.sgworldMain, liXtP))
                'GeoBBXT.Add(ListtoGeoTQ(FrmMain.Instance.sgworldMain, liXtT1))
                'GeoBBXT.Add(ListtoGeoTQ(FrmMain.Instance.sgworldMain, liXtP1))
            Else
                Dim GXT As IGeometry = GeoT(0).SpatialOperator.Union(ListtoGeo(liXtT))
                Dim GXT1 As IGeometry = GXT.SpatialOperator.Union(ListtoGeo(liXtP))
                GeoBBXT.Add(GXT1)
                Dim GXTd As IGeometry = GeoT(1).SpatialOperator.Union(ListtoGeo(liXtT1))
                Dim GXTd1 As IGeometry = GXTd.SpatialOperator.Union(ListtoGeo(liXtP1))
                GeoBBXT.Add(GXTd1)
            End If
        Else
            Exit Sub
        End If
    End Sub

    Function GeoXTBBTruocSau(Pc As IPosition71, Kc As Double, Goc As Double) As List(Of IGeometry)
        Dim K1p As IPosition71 = Pc.Move(Kc, Goc + 180, 0)
        Dim K1t As IPosition71 = Pc.Move(Kc, Goc, 0)
        Dim Pc1 As IPosition71 = Pc.Move(Dorongduong * 2, Goc + 270, 0)

        Dim K2p As IPosition71 = Pc1.Move(Kc + Dorongduong * 2, Goc + 180, 0)
        Dim K2t As IPosition71 = Pc1.Move(Kc + Dorongduong * 2, Goc, 0)
        Dim Pc2 As IPosition71 = Pc.Move(Dorongduong * 4, Goc + 270, 0)
        Dim K3p As IPosition71 = Pc2.Move(Kc + (Dorongduong * 4), Goc + 180, 0)
        Dim K3t As IPosition71 = Pc2.Move(Kc + (Dorongduong * 4), Goc, 0)
        Dim liN1 As New List(Of IPosition71) From {K1t, K1p, K2p, K2t}
        Dim liN2 As New List(Of IPosition71) From {K2t, K2p, K3p, K3t}
        Dim Go As New List(Of IGeometry) From {ListtoGeo(liN1), ListtoGeo(liN2)}
        GeoXTBBTruocSau = Go
    End Function

#Region "    Lu doan"

    Function LiLudoanBB(Pc As IPosition71, Kc As Double, G2 As Double) As List(Of IPosition71)
        Dim GocKieu As Double, Dx As Double, Dy1 As Double, Dy2 As Double, Ks As Double
        If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
            GocKieu = 270.0
            Dx = Kc / 2
            Dy1 = -Dorongduong * 4
            Dy2 = -Dorongduong * 8
            Ks = -1
        Else
            GocKieu = 90.0
            Dx = Kc * 2 / 3
            Dy1 = -Dorongduong * 6
            Dy2 = -Dorongduong * 10
            Ks = 1
        End If
        Dim PTren As IPosition71 = Pc.Move(Dy1, G2 + GocKieu, 0)
        Dim Pday As IPosition71 = Pc.Move(Dy2, G2 + GocKieu, 0)
        Dim PdayT As IPosition71 = Pday.Move(Dx, G2 + 0, 0)
        Dim PdayP As IPosition71 = Pday.Move(Dx, G2 + 180, 0)
        Dim Ptd As IPosition71 = PTren.Move(Kc + (Ks * Hesodichchuyen * Dorongduong), G2 + 0, 0)
        Dim Ppd As IPosition71 = PTren.Move(Kc + (Ks * Hesodichchuyen * Dorongduong), G2 + 180, 0)
        Hesodichchuyen += 1.5
        Dim liK1 As New List(Of IPosition71) From {Ptd, PdayT, Pc, PdayP, Ppd}
        Dim liK1Curve As List(Of IPosition71) = Curveline(liK1, 12)
        LiLudoanBB = liK1Curve
    End Function

    Private Sub GeoLudoanBB(GeoMT As IGeometry, Pc As IPosition71, Pc1 As IPosition71, Pc2 As IPosition71, P1 As IPosition71, P3 As IPosition71, Kc As Double, G2 As Double)
        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex > 0 And FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex < 4 Then
            Dim liD1 As List(Of IPosition71) = LiLudoanBB(Pc, Kc, G2)
            Dim liD2 As List(Of IPosition71) = LiLudoanBB(Pc1, Kc, G2)
            Dim liD3 As List(Of IPosition71) = LiLudoanBB(Pc2, Kc, G2)
            liD2.Reverse()
            UniCruve(liD1, liD2)
            UniCruve(liD3, liD2)
            Dim Ptd As IPosition71 = P1.Move(-Dorongduong * 6, G2 + 90, 0)
            Dim Ptd1 As IPosition71 = Ptd.Move(-Dorongduong * 4, G2 + 120, 0)
            Dim Ppd As IPosition71 = P3.Move(-Dorongduong * 6, G2 + 90, 0)
            Dim Ppd1 As IPosition71 = Ppd.Move(-Dorongduong * 4, G2 + 60, 0)
            Dim GeoChinh3 As IGeometry
            If FrmMain.Instance.cbKieuTrKTiencong.SelectedIndex = 0 Then
                GeoChinh3 = GeoMT.SpatialOperator.Union(ListtoGeo(liD1))
            Else
                Dim GeoChinh1 As IGeometry = GeoMT.SpatialOperator.Union(ListtoGeo(liD1))
                Dim GeoChinh2 As IGeometry = GeoChinh1.SpatialOperator.Union(ListtoGeo(GachDoihnhTC(Ptd, Ptd1, 2, 3, -90)))
                GeoChinh3 = GeoChinh2.SpatialOperator.Union(ListtoGeo(GachDoihnhTC(Ppd, Ppd1, 2, 3, 90)))
            End If
            GeoArray.Add(GeoChinh3)
            GeoArray.Add(ListtoGeo(liD3))
        Else
            Exit Sub
        End If
        Hesodichchuyen = 0
    End Sub

#End Region

#Region "   Tieu doan"
    Private Sub GeoTieudoan(GeoCC1 As IGeometry, Pc As IPosition71, Kc As Double, Heso As Double, G2 As Double)
        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex >= 4 Or Lenhve = "DoihinhBBTamdung" Then
            Dim KhoangLui As Double = Dorongduong * 12.0
            Dim mk1 As IPosition71 = Pc.Move(Kc - (Dorongduong * Heso), G2 + 0, 0)
            Dim mk2 As IPosition71 = Pc.Move(Kc - (Dorongduong * Heso), G2, 180)
            Dim L1 As List(Of IPosition71) = LiPointTieudoan(mk1, mk2, Pc, KhoangLui, G2)
            Dim Pc1 As IPosition71 = Pc.Move(-Dorongduong * 2, G2 + 90, 0)
            Dim mk3 As IPosition71 = Pc1.Move(Kc - (Dorongduong * (Heso + 1.5)), G2 + 0, 0)
            Dim mk4 As IPosition71 = Pc1.Move(Kc - (Dorongduong * (Heso + 1.5)), G2, 180)
            Dim L2 As List(Of IPosition71) = LiPointTieudoan(mk3, mk4, Pc1, KhoangLui, G2)

            Dim Pc2 As IPosition71 = Pc1.Move(-Dorongduong * 2, G2 + 90, 0)
            Dim mk5 As IPosition71 = Pc2.Move(Kc - (Dorongduong * (Heso + 3.0)), G2 + 0, 0)
            Dim mk6 As IPosition71 = Pc2.Move(Kc - (Dorongduong * (Heso + 3.0)), G2, 180)
            Dim L3 As List(Of IPosition71) = LiPointTieudoan(mk5, mk6, Pc2, KhoangLui, G2)
            L2.Reverse()
            UniCruve(L1, L2)
            UniCruve(L3, L2)
            Dim GeoC As IGeometry = GeoCC1.SpatialOperator.Union(ListtoGeo(L1))
            Dim GeoD As IGeometry = ListtoGeo(L3)
            GeoArray.Add(GeoC)
            GeoArray.Add(GeoD)
        End If
    End Sub

    Function LiPointTieudoan(P1 As IPosition71, P3 As IPosition71, Pc As IPosition71, KhoangLui As Double, G2 As Double) As List(Of IPosition71)
        Dim L1 As List(Of IPosition71) = TieudoanCurve(P1, KhoangLui, G2, 180.0, 210.0)
        L1.RemoveRange(24, 1)
        L1.Add(Pc)
        Dim L2 As List(Of IPosition71) = TieudoanCurve(P3, KhoangLui, G2, 0.0, 330.0)
        L2.RemoveRange(24, 1)
        L2.Reverse()
        UniCruve(L1, L2)
        LiPointTieudoan = L1
    End Function

    Function TieudoanCurve(P1 As IPosition71, Kc As Double, Goc1 As Double, Goc2 As Double, Goc3 As Double) As List(Of IPosition71)
        Dim N1 As IPosition71 = P1.Move(Kc * 0.7, Goc1 + 270, 0)
        Dim N2 As IPosition71 = P1.Move(Kc, Goc1 + Goc2, 0)
        Dim N3 As IPosition71 = P1.Move(0.4 * Kc, Goc1 + Goc3, 0)
        Dim LiBBXT As List(Of IPosition71) = LiCrube3Point(N1, N3, N2)
        TieudoanCurve = LiBBXT
    End Function

    Function NetNgangMT(P1 As IPosition71, Kc As Double, Goc1 As Double) As IGeometry
        Dim N1 As IPosition71 = P1.Move(Kc, Goc1, 0)
        Dim N2 As IPosition71 = N1.Move(Dorongduong / 2, Goc1 + 90, 0)
        Dim Dai As Double
        If Lenhve = "TuyenbanXT" Or Lenhve = "TsatBangChiendau" Then
            Dai = 5
        Else
            Dai = 7
        End If
        Dim GeoN As IGeometry = ListtoGeo(GachDoihnhTC(N1, N2, 2, Dai, 90))
        NetNgangMT = GeoN
    End Function

#End Region

    Private Sub GeoDaidoiTrungdoi(GeoC As IGeometry, P1 As IPosition71, P3 As IPosition71, G2 As Double)
        Dim P11 As IPosition71 = P1.Move(-Dorongduong * 2, G2 + 90, 0)
        Dim P12 As IPosition71 = P1.Move(-Dorongduong * 4, G2 + 90, 0)
        Dim P31 As IPosition71 = P3.Move(-Dorongduong * 2, G2 + 90, 0)
        Dim P32 As IPosition71 = P3.Move(-Dorongduong * 4, G2 + 90, 0)
        Dim liD1 As New List(Of IPosition71) From {P1, P11, P31, P3}
        Dim D1 As IGeometry = ListtoGeo(liD1)
        Dim D2 As IGeometry = ListtoGeo(GachDoihnhTC(P1, P11, 2, 4, 90))
        Dim D3 As IGeometry = ListtoGeo(GachDoihnhTC(P3, P31, 2, 4, -90))
        Dim GeoChinh1 As IGeometry = GeoC.SpatialOperator.Union(D1)
        Dim GeoChinh2 As IGeometry = GeoChinh1.SpatialOperator.Union(D2)
        Dim GeoC1 As IGeometry = GeoChinh2.SpatialOperator.Union(D3)
        Dim liDem As New List(Of IPosition71) From {P31, P32, P12, P11}
        GeoArray.Add(GeoC1)
        GeoArray.Add(ListtoGeo(liDem))
    End Sub

    Public Function GachDoihnhTC(P1 As IPosition71, P2 As IPosition71, Rong As Double, Cao As Double, Goc1 As Double) As List(Of IPosition71)
        Dim K1 As IPosition71 = P1.Move(Dorongduong * Cao, FGoc(P1, P2), 0)
        Dim K2 As IPosition71 = P2.Move(Dorongduong * Cao, FGoc(P1, P2) + 180, 0)
        Dim K3 As IPosition71 = K1.Move(Dorongduong * Rong, FGoc(P1, P2) + Goc1, 0)
        Dim K4 As IPosition71 = K2.Move(Dorongduong * Rong, FGoc(P1, P2) + Goc1, 0)
        Dim liK As New List(Of IPosition71) From {K1, K3, K4, K2}
        GachDoihnhTC = liK
    End Function

    Private Sub TiencongBBXT(liChinh As List(Of IPosition71), liXTt As List(Of IPosition71), liXTp As List(Of IPosition71), Group As String, mLineStylePattern As UInteger, Dorongduong As Double, mauDuong As IColor71, mSetAlphaDuong As Double, mauVung As IColor71, mSetAlphaVung As Double, filePaternVung As String, xScale As Double, yScale As Double, mRotate As Double, Tron As Boolean, mATC As Integer, mOrder As Double, TTDoituong As String)
        Dim liCatT As New List(Of IPosition71) From {liXTt(0), liXTt(1), liXTt(2), liXTt(9)}
        Dim liCatP As New List(Of IPosition71) From {liXTp(0), liXTp(1), liXTp(2), liXTp(9)}
        Dim GCat1 As IGeometry = ListtoGeo(liCatT).SpatialOperator.buffer(-1 * Dorongduong * 1.2)
        Dim GCat2 As IGeometry = ListtoGeo(liCatP).SpatialOperator.buffer(-1 * Dorongduong * 1.2)
        Dim Cgeo1 As IGeometry = ListtoGeo(liChinh)
        Dim Cgeo2 As IGeometry = Cgeo1.SpatialOperator.Difference(GCat1)
        Dim Cgeo3 As IGeometry = Cgeo2.SpatialOperator.Difference(GCat2)
        Dim Cgeo4 As IGeometry = Cgeo3.SpatialOperator.Union(ListtoGeo(liXTt))
        Dim Cgeo5 As IGeometry = Cgeo4.SpatialOperator.Union(ListtoGeo(liXTp))
        Dim mRegion As ITerrainPolygon71 = FrmMain.Instance.sgworldMain.Creator.CreatePolygon(Cgeo5, mauDuong, mauVung, mATC, Group, tenKH & TTDoituong)
        DefindReGion(mRegion, mLineStylePattern, Dorongduong, mauDuong, mSetAlphaDuong, mauVung, mSetAlphaVung, filePaternVung, xScale, yScale, mRotate, Tron, mATC, mOrder)
    End Sub

#End Region

#Region "    Doi hinh Phong ngu"

    Public Sub DoihinhPN()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(1 / 3 * (P2.X + P1.X + P3.X), 1 / 3 * (P2.Y + P1.Y + P3.Y), 0, 2, 0, 0, 0, 0)
        Dim Pc12 As IPosition71 = CenterPoint(P1, P2)
        Dim Kc As Double = FKc(P1, P2) / 5
        Dim P21 As IPosition71 = Nothing, Pk31 As IPosition71 = Nothing, Pk61 As IPosition71 = Nothing

        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 7 Then
            P21 = P3.Move(-Dorongduong, FGoc(Pc12, P3) + 180, 0)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
            P21 = P3.Move(Dorongduong * 10, FGoc(Pc12, P3) + 180, 0)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then
            P21 = P3.Move(-Dorongduong * 2, FGoc(Pc12, P3) + 180, 0)
        End If

        Dim Pd As IPosition71 = P21.Move(Kc - Dorongduong * 4, FGoc(Pc12, P3), 0)

        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then
            Dim Pk1 As IPosition71 = P21.Move(Dorongduong * 8, FGoc(Pc12, P3) + 90, 0)
            Dim Pk2 As IPosition71 = P21.Move(Dorongduong * 8, FGoc(Pc12, P3) + 270, 0)
            Dim Pk3 As IPosition71 = P21.Move(Kc + Dorongduong, FGoc(Pc12, P3) + 65, 0)
            Dim Pk4 As IPosition71 = P21.Move(Kc + Dorongduong * 4, FGoc(Pc12, P3) + 40, 0)
            Dim Pk5 As IPosition71 = P21.Move(Kc + Dorongduong * 4, FGoc(Pc12, P3) + 320, 0)
            Dim Pk6 As IPosition71 = P21.Move(Kc + Dorongduong, FGoc(Pc12, P3) + 295, 0)
            '//////////////
            Dim liP As New List(Of IPosition71) From {Pk1, Pk3, Pk4, Pd, Pk5, Pk6, Pk2}
            Dim lP As List(Of IPosition71) = Curveline(liP, 12)
            Dim cRing As ILinearRing = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(ListtoAarray(lP))
            Dim G1 As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing, Nothing)
            Dim G2 As IGeometry = G1.SpatialOperator.buffer(Dorongduong * -2)
            FDuongList(GeoToList(G2), 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lP, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
            '////////////////////////
            Dim GocP2 As Double = MkGoc(P3, Pc12) * 180 / Math.PI
            CongsuTQ(MkGoc(P3, Pc12) * 180 / Math.PI, P3)
            CumPNDaidoi(P1, FGoc(P3, P1)) ' + 250)
            CumPNDaidoi(P2, FGoc(P3, P2))  ' + 290)
            '//////////////////////
            loaiKH = "100007"
            Pk31 = P21.Move(Kc + Dorongduong * 3, FGoc(Pc12, P3) + 65, 0)
            Pk61 = P21.Move(Kc + Dorongduong * 3, FGoc(Pc12, P3) + 295, 0)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Then
            CumPNDaidoi(P1, FGoc(P3, P1)) ' + 250)
            CumPNDaidoi(P2, FGoc(P3, P2))  ' + 290)
            CumPNDaidoi(P3, FGoc(P3, Pc12)) ' + 250)
            Pk31 = P21.Move(Dorongduong * 15, FGoc(Pc12, P3) + 65, 0)
            Pk61 = P21.Move(Dorongduong * 15, FGoc(Pc12, P3) + 295, 0)
            loaiKH = "100008"
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
            CumPNTRungdoi(P1, FGoc(P3, P1)) ' + 250)
            CumPNTRungdoi(P2, FGoc(P3, P2))  ' + 290)
            CumPNTRungdoi(P3, FGoc(P3, Pc)) ' + 250)
            Pk31 = P21.Move(Dorongduong * 9, FGoc(Pc12, P3) + 65, 0)
            Pk61 = P21.Move(Dorongduong * 9, FGoc(Pc12, P3) + 295, 0)
            loaiKH = "100009"
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 7 Or Lenhve = "XTchuyenPngu" Or Lenhve = "XTPngutrongTD" Then
            If Lenhve = "XTPngutrongTD" Then
                CongsuTQ(MkGoc(P1, P3) * 180 / Math.PI, P1)
                CongsuTQ(MkGoc(P2, P3) * 180 / Math.PI, P2)
                CongsuTQ(MkGoc(P3, Pc) * 180 / Math.PI, P3)
            Else
                ChotBB(P1, MkGoc(P3, P1) * 180 / Math.PI, 20.0)
                ChotBB(P2, MkGoc(P3, P2) * 180 / Math.PI, 20.0)  ' + 290)
                ChotBB(P3, MkGoc(Pc, P3) * 180 / Math.PI, 20.0) ' + 250)
            End If
            Pk31 = P21.Move(Dorongduong * 10, FGoc(Pc12, P3) + 65, 0)
            Pk61 = P21.Move(Dorongduong * 10, FGoc(Pc12, P3) + 295, 0)
            loaiKH = "100010"
        End If

        If Lenhve = "DHPNBBXT" Then
            Dim Pk1 As IPosition71, Pk2 As IPosition71, Pk3 As IPosition71 = Nothing
            Dim tyleXT As Double = 0
            If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Then
                Pk1 = P1.Move(-Dorongduong * 8.25, FGoc(P3, Pc12) - 32, 0)
                Pk2 = P2.Move(-Dorongduong * 8.25, FGoc(P3, Pc12) + 28, 0)
                Pk3 = P3.Move(-Dorongduong * 8.25, FGoc(P3, Pc12), 0)
                tyleXT = Tyle * 3.5
                XT1(Pk1, tyleXT, 32 + MkGoc(P3, Pc12) * 180 / Math.PI)
                XT1(Pk2, tyleXT, -28 + MkGoc(P3, Pc12) * 180 / Math.PI)
                DemXT(Pk1, tyleXT, 32 + MkGoc(P3, Pc12) * 180 / Math.PI)
                DemXT(Pk2, tyleXT, -28 + MkGoc(P3, Pc12) * 180 / Math.PI)
            ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
                Pk1 = P1.Move(-Dorongduong * 6.0, FGoc(P3, Pc12) - 30, 0)
                Pk2 = P2.Move(-Dorongduong * 6.0, FGoc(P3, Pc12) + 28, 0)
                Pk3 = P3.Move(-Dorongduong * 6.0, FGoc(P3, Pc12), 0)
                tyleXT = Tyle * 2.5
                XT1(Pk1, tyleXT, 30 + MkGoc(P3, Pc12) * 180 / Math.PI)
                XT1(Pk2, tyleXT, -28 + MkGoc(P3, Pc12) * 180 / Math.PI)
                DemXT(Pk1, tyleXT, 30 + MkGoc(P3, Pc12) * 180 / Math.PI)
                DemXT(Pk2, tyleXT, -28 + MkGoc(P3, Pc12) * 180 / Math.PI)
            ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then
                Pk1 = P1.Move(-Dorongduong * 12.25, FGoc(P3, Pc12) - 32, 0)
                Pk2 = P2.Move(-Dorongduong * 12.25, FGoc(P3, Pc12) + 24, 0)
                Pk3 = P3.Move(-Dorongduong * 20.25, FGoc(P3, Pc12), 0)
                tyleXT = Tyle * 3.5
                XT1(Pk1, tyleXT, 32 + MkGoc(P3, Pc12) * 180 / Math.PI)
                XT1(Pk2, tyleXT, -24 + MkGoc(P3, Pc12) * 180 / Math.PI)
                DemXT(Pk1, tyleXT, 32 + MkGoc(P3, Pc12) * 180 / Math.PI)
                DemXT(Pk2, tyleXT, -24 + MkGoc(P3, Pc12) * 180 / Math.PI)
            End If
            XT1(Pk3, tyleXT, MkGoc(P3, Pc12) * 180 / Math.PI)
            DemXT(Pk3, tyleXT, MkGoc(P3, Pc12) * 180 / Math.PI)
        ElseIf Lenhve = "KvPNthenchot" Then
            If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
                PNThenchot(P1, FGoc(P3, Pc12))
                PNThenchot(P2, FGoc(P3, Pc12))
                PNThenchot(P3, FGoc(P3, Pc12))
            ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then
                PNThenchot(P1, FGoc(P3, Pc12))
                PNThenchot(P2, FGoc(P3, Pc12))
                Dim kcDay As Double = FKc(Pk31, Pk61)
                Dim Pk3 As IPosition71 = P21.Move(Kc + Dorongduong, FGoc(Pc12, P3) + 65, 0)
                For i As Integer = 1 To (kcDay / (Dorongduong * 7)) - 1
                    Dim Ps1 As IPosition71 = Pk3.Move(-Dorongduong * 7 * i, FGoc(Pk31, Pk61), 0)
                    GachPNTehchot(Ps1, FGoc(P3, Pc12), Dorongduong * 7)
                Next
            End If
        ElseIf Lenhve = "XTchuyenPngu" Or Lenhve = "XTPngutrongTD" Then
            Dim Pk1 As IPosition71, Pk2 As IPosition71, Pk3 As IPosition71 = Nothing
            Pk1 = P1.Move(Dorongduong * 4.25, FGoc(P3, Pc12) - 32, 0)
            Pk2 = P2.Move(Dorongduong * 4.25, FGoc(P3, Pc12) + 24, 0)
            Pk3 = P3.Move(-Dorongduong * 20.25, FGoc(P3, Pc12), 0)
            XT1(Pk1, Tyle * 3.5, 32 + MkGoc(P3, Pc12) * 180 / Math.PI)
            XT1(Pk2, Tyle * 3.5, -24 + MkGoc(P3, Pc12) * 180 / Math.PI)
            DemXT(Pk1, Tyle * 3.5, 32 + MkGoc(P3, Pc12) * 180 / Math.PI)
            DemXT(Pk2, Tyle * 3.5, -24 + MkGoc(P3, Pc12) * 180 / Math.PI)
            XT1(Pk3, Tyle * 3.5, MkGoc(P3, Pc12) * 180 / Math.PI)
            DemXT(Pk3, Tyle * 3.5, MkGoc(P3, Pc12) * 180 / Math.PI)
        End If

        CanhDHPN(Pk31, P2, 270, 15)

        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 7 Then
            CanhDHPN(Pk61, P1, 90, -70)
        Else
            CanhDHPN(Pk61, P1, 90, -15)
        End If

        If Not Lenhve = "XTchuyenPngu" And Not Lenhve = "XTPngutrongTD" Then
            If loaiKH = "100007" Then
                FrmMain.Instance.fLabelStyleMain.TextAlignment = "Center,Center"
            Else
                FrmMain.Instance.fLabelStyleMain.TextAlignment = "Bottom,Right"
            End If
            textKH = "          " & tenKH
            fileImage = PathLabel(mThumuc, loaiKH, ChieuKH, mP, m2X, Ta_Doiphuong, tenGiaidoan)
            Dim M2 As ITerrainLabel71 = FrmMain.Instance.sgworldMain.Creator.CreateLabel(Pc, textKH, fileImage, FrmMain.Instance.fLabelStyleMain, GroupBac2Main, tenKH)
            mLabelArray.Add(M2)
        End If
        SLenhve3DMs()
    End Sub

    Private Sub CanhDHPN(P1 As IPosition71, P2 As IPosition71, Goc As Double, Goc1 As Double)
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(1 / 2 * (P1.X + P2.X), 1 / 2 * (P1.Y + P2.Y), 0, 2, 0, 0, 0, 0)
        Dim Kc As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y) / 5
        Dim Pc1 As IPosition71 = Pc.Move(Kc, FGoc(P1, P2) + Goc, 0)
        Dim Pk As IPosition71 ' = P2.Move(Dorongduong * 18, FGoc(P1, P2) + Goc + Goc1, 0)
        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
            Pk = P2.Move(Dorongduong * 10, FGoc(P1, P2) + Goc + Goc1 + 10, 0)
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 7 Then
            Pk = P2.Move(Dorongduong * 10, FGoc(P1, P2) + Goc + Goc1 + 30, 0)
        Else
            Pk = P2.Move(Dorongduong * 18, FGoc(P1, P2) + Goc + Goc1, 0)
        End If
        Dim liP As New List(Of IPosition71) From {P1, Pc1, Pk}
        Dim lP As List(Of IPosition71) = Curveline(liP, 12)
        FDuongList(lP, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
        Dim P11 As IPosition71 = P1.Move(Dorongduong * 5, FGoc(P1, P2) + 180, 0)
        Dim P21 As IPosition71 = Pk.Move(Dorongduong * 2, FGoc(P1, P2) - Goc, 0)
        Dim Pc2 As IPosition71 = Pc.Move(Kc - Dorongduong * 2, FGoc(P1, P2) + Goc, 0)
        Dim liP1 As New List(Of IPosition71) From {P11, Pc2, P21}
        Dim lP1 As List(Of IPosition71) = Curveline(liP1, 12)
        FDuongList(lP1, 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
    End Sub

    Private Sub PNThenchot(P1 As IPosition71, Goc As Double)
        If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 6 Then
            Dim Pk1 As IPosition71 = P1.Move(-Dorongduong * 5, Goc - 225, 0)
            Dim Pk2 As IPosition71 = P1.Move(Dorongduong * 5, Goc + 135, 0)
            Dim liP As New List(Of IPosition71) From {Pk1, P1, Pk2}
            For i As Integer = 0 To liP.Count - 1
                GachPNTehchot(liP(i), Goc, Dorongduong * 7)
            Next
        ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then
            Dim Pk1 As IPosition71 = P1.Move(-Dorongduong * 5, Goc - 225, 0)
            Dim Pk2 As IPosition71 = P1.Move(Dorongduong * 5, Goc + 135, 0)
            Dim Pk3 As IPosition71 = P1.Move(Dorongduong * 10, Goc + 135, 0)
            Dim liP As New List(Of IPosition71) From {Pk1, Pk2, P1, Pk3}
            For i As Integer = 0 To liP.Count - 1
                GachPNTehchot(liP(i), Goc, Dorongduong * 7)
            Next
        End If
    End Sub

    Private Sub GachPNTehchot(Pk1 As IPosition71, Goc As Double, Dodai As Double)
        Dim Pk11 As IPosition71 = Pk1.Move(Dodai, Goc + 45, 0)
        Dim Pk12 As IPosition71 = Pk1.Move(Dodai, Goc + 225, 0)
        Dim liP As New List(Of IPosition71) From {Pk11, Pk12}
        FDuongList(liP, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 0) ' 2, False, 2)
    End Sub

#End Region
    Public Sub Muithocsau()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Kc As Double = FKc(P1, P2)
        Dim Pc As IPosition71 = P1.Move(Kc / 2, FGoc(P2, P1), 0)
        Dim GYaw As Double
        If FrmMain.Instance.cbChieuMuiThuyeu.SelectedIndex = 0 Then
            GYaw = FGoc(P1, P2) + 270
        Else
            GYaw = FGoc(P1, P2) + 90
        End If
        Dim Pd As IPosition71 = Pc.Move(Kc / 20, GYaw, 0)
        Dim Pmt As IPosition71 = P1.Move(-Dorongduong * 8, FGoc(P1, Pd), 0)
        Dim diP1Pd As Double = FKc(Pmt, Pd)
        Dim pXTc As IPosition71 = Pd.Move(diP1Pd / 4, FGoc(P2, Pd), 0)

        Dim pXT3 As IPosition71 = pXTc.Move(Dorongduong * 5.1, FGoc(P2, Pd), 0)
        Dim pXT4 As IPosition71 = pXTc.Move(Dorongduong * 5.1, FGoc(P2, Pd) + 180, 0)
        Dim P21 As IPosition71 = P2.Move(Dorongduong, FGoc(P2, Pd) + 90, 0)
        Dim P22 As IPosition71 = P2.Move(Dorongduong, FGoc(P2, Pd) + 270, 0)

        Dim pXT31 As IPosition71 = pXT3.Move(Dorongduong, FGoc(P2, Pd) + 90, 0)
        Dim pXT32 As IPosition71 = pXT3.Move(Dorongduong, FGoc(P2, Pd) + 270, 0)

        Dim pXT41 As IPosition71 = pXT4.Move(Dorongduong, FGoc(P2, Pd) + 90, 0)
        Dim pXT42 As IPosition71 = pXT4.Move(Dorongduong, FGoc(P2, Pd) + 270, 0)
        Dim LiP1 As New List(Of IPosition71) From {pXT31, pXT32, P22, P21}
        Dim GLiP1 As IGeometry = ListtoGeo(LiP1)
        Dim Geo1 As IGeometry = GLiP1.SpatialOperator.Union(ListtoGeo(LiPXTn(pXTc, 1.5, MkGoc(pXTc, Pd) * 180 / Math.PI)))

        Dim Pc1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (Pmt.X + Pd.X), 0.5 * (Pmt.Y + Pd.Y), 0, 2, 0, 0, 0, 0)
        Dim P11 As IPosition71 = Pmt.Move(Dorongduong / 2, FGoc(Pd, P1) + 90, 0)
        Dim P12 As IPosition71 = Pmt.Move(Dorongduong / 2, FGoc(Pd, P1) + 270, 0)
        Dim Pk1 As IPosition71, Pk2 As IPosition71, Pk3 As IPosition71, pXT4d As IPosition71, pXT3d As IPosition71, P23 As IPosition71, P24 As IPosition71, P13 As IPosition71, pXT4d1 As IPosition71, pXT3d1 As IPosition71
        If FrmMain.Instance.cbChieuMuiThuyeu.SelectedIndex = 0 Then
            Pk1 = Pc1.Move(diP1Pd / 20, GYaw, 0)
            Pk2 = Pc1.Move(diP1Pd / 20 - Dorongduong * 2, GYaw, 0)
            Pk3 = Pc1.Move(diP1Pd / 20 - Dorongduong * 3, GYaw, 0)
            pXT4d = pXT4.Move(Dorongduong * 5.0, FGoc(P2, Pd) + 335, 0)
            pXT3d = pXT3.Move(Dorongduong * 5.0, FGoc(P2, Pd) + 210, 0)
            P23 = P2.Move(Dorongduong * 3, FGoc(P2, Pd) + 270, 0)
            P24 = P2.Move(Dorongduong, FGoc(P2, Pd) + 270, 0)
            P13 = Pmt.Move(Dorongduong / 2, FGoc(Pd, P1) + 270, 0)
            pXT4d1 = pXT4.Move(Dorongduong, FGoc(P2, Pd) + 270, 0)
            pXT3d1 = pXT3.Move(Dorongduong, FGoc(P2, Pd) + 270, 0)
        Else
            Pk2 = Pc1.Move(diP1Pd / 20, GYaw, 0)
            Pk1 = Pc1.Move(diP1Pd / 20 - Dorongduong * 2, GYaw, 0)
            Pk3 = Pc1.Move(diP1Pd / 20 - Dorongduong * 3, GYaw, 0)
            pXT4d = pXT4.Move(Dorongduong * 5.0, FGoc(P2, Pd) + 25, 0)
            pXT3d = pXT3.Move(Dorongduong * 5.0, FGoc(P2, Pd) + 150, 0)
            P23 = P2.Move(Dorongduong * 3, FGoc(P2, Pd) + 90, 0)
            P24 = P2.Move(Dorongduong, FGoc(P2, Pd) + 90, 0)
            P13 = Pmt.Move(Dorongduong / 2, FGoc(Pd, P1) + 90, 0)
            pXT4d1 = pXT4.Move(Dorongduong, FGoc(P2, Pd) + 90, 0)
            pXT3d1 = pXT3.Move(Dorongduong, FGoc(P2, Pd) + 90, 0)
        End If
        Dim liMT As List(Of IPosition71) = Muiten(P1, Pmt, FGoc(P1, Pd), 1.0, 1.0)
        Dim LpN1 As List(Of IPosition71) = LiCrube3Point(pXT42, Pk2, P12)
        Dim LpN2 As List(Of IPosition71) = LiCrube3Point(P11, Pk1, pXT41)
        'Dem
        Dim LiD As New List(Of IPosition71) From {P24, P23, pXT3d, pXT3d1}
        Dim geoDxt As IGeometry = ListtoGeo(LiD).SpatialOperator.Union(ListtoGeo(LiPXTnDem(pXTc, 1.5, MkGoc(pXTc, Pd) * 180 / Math.PI)))
        Dim LpD1 As List(Of IPosition71) = LiCrube3Point(P13, Pk3, pXT4d)
        UniCruve(LpD1, LpN1)
        Dim geoDem As IGeometry = geoDxt.SpatialOperator.Union(ListtoGeo(LpD1))
        UniCruve(LpN1, LpN2)
        Dim GeoMT As IGeometry = ListtoGeo(liMT)
        Dim C1 As IGeometry = GeoMT.SpatialOperator.Union(ListtoGeo(LpN1))
        Dim C2 As IGeometry = C1.SpatialOperator.Union(Geo1)
        FVungList(GeoToList(C2), 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        FVungList(GeoToList(geoDem), 4294967295, 0.0, mau2, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

End Module

'Public Sub Nhiemvutieptheo()
'    Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0,2, 0, 0, 0, 0) 'Diem giua
'    Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0,2, 0, 0, 0, 0) 'Diem giua
'    Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0,2, 0, 0, 0, 0) 'Diem giua
'    Dim KC As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P3.X, P3.Y) / 20
'    Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P1.X + P3.X), 0.5 * (P1.Y + P3.Y), 0, 2, 0, 0, 0, 0)
'    Dim GYaw As Double
'    Dim G1 As Double = FGoc(P1, P2)
'    Dim G2 As Double = FGoc(P1, P3)
'    If G1 > G2 Then
'        GYaw = FGoc(P1, P3) + 270
'    Else
'        GYaw = FGoc(P1, P3) + 90
'    End If
'    Dim PL1 As IPosition71 = Pc.Move(KC, GYaw, 0)
'    Dim MT1 As IPosition71 = PL1.Move(Dorongduong * 20, GYaw, 0)
'    Dim MT2 As IPosition71 = PL1.Move(-Dorongduong, GYaw, 0)
'    '//////////////
'    Dim GeoMT As IGeometry = ListtoGeo(Muiten(MT1, MT2, GYaw, 1))
'    Dim PL2 As IPosition71 = PL1.Move(-Dorongduong * 2, GYaw, 0)
'    Dim Pl3 As IPosition71 = PL2.Move(-Dorongduong * 2, GYaw, 0)
'    Dim LiP1 As List(Of IPosition71) = PointFormPNhiemvu(PL1, P1, P3, -Dorongduong * 2, GYaw)
'    Dim LiP2 As List(Of IPosition71) = PointFormPNhiemvu(PL2, P1, P3, -Dorongduong * 4, GYaw)
'    LiP2.Reverse()
'    UniCruve(LiP1, LiP2)
'    Dim GeoChinh As IGeometry = GeoMT.SpatialOperator.Union(ListtoGeo(LiP1))
'    VungFormGeo(GeoChinh, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
'    If Lenhve = "nhiemvutruocmat" Then 'Or Lenhve = "nhiemvutieptheo"
'        Dim LiP3 As List(Of IPosition71) = PointFormPNhiemvu(Pl3, P1, P3, -Dorongduong * 6, GYaw)
'        UniCruve(LiP3, LiP2)
'        Dim GeoDem As IGeometry = ListtoGeo(LiP3)
'        VungFormGeo(GeoDem, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2, "2")
'    Else
'        Dim PL4 As IPosition71 = PL2.Move(-Dorongduong * 2, GYaw, 0)
'        Dim LiP4 As List(Of IPosition71) = PointFormPNhiemvu(PL4, P1, P3, -Dorongduong * 6, GYaw)
'        Dim PL5 As IPosition71 = PL4.Move(-Dorongduong * 2, GYaw, 0)
'        Dim LiP5 As List(Of IPosition71) = PointFormPNhiemvu(PL5, P1, P3, -Dorongduong * 8, GYaw)
'        Dim PL6 As IPosition71 = PL5.Move(-Dorongduong * 2, GYaw, 0)
'        Dim LiP6 As List(Of IPosition71) = PointFormPNhiemvu(PL6, P1, P3, -Dorongduong * 10, GYaw)
'        LiP5.Reverse()
'        UniCruve(LiP4, LiP5)
'        UniCruve(LiP6, LiP5)
'        Dim GeoChinh2 As IGeometry = ListtoGeo(LiP4)
'        Dim GeoDem As IGeometry = ListtoGeo(LiP6)
'        VungFormGeo(GeoChinh2, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "3")
'        VungFormGeo(GeoDem, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2, "2")
'    End If
'    SLenhve3DMs()
'End Sub

'Function PointFormPNhiemvu(PL As IPosition71, P1 As IPosition71, P3 As IPosition71, Dorong As Double, GYaw As Double) As List(Of IPosition71)
'    Dim P11 As IPosition71 = P1.Move(Dorong, GYaw, 0)
'    Dim P31 As IPosition71 = P3.Move(Dorong, GYaw, 0)
'    Dim LiN As New List(Of IPosition71) From {P11, PL, P31}
'    Dim liN1 As List(Of IPosition71) = Curveline(LiN, 12)
'    PointFormPNhiemvu = liN1
'End Function
'VungFormGeo(Geo1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
'Dim kc = Math.Min(kcP2P3, kcP1P3) / 5
' FVungList(liD, 4294967295, 0.0, mau2, 0.5, mau2, 0.5, "", 0, 0, 0, False, 2, 1)
'FDuongList(LiP5, 4294967295, "", 0, 0, mau3, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
'FDuongList(LiP6, 4294967295, "", 0, 0, mau3, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
'FrmMain.Instance.fLabelStyleMain.TextColor = FrmMain.Instance.sgworldMain.Creator.CreateColor(0, 0, 255, 255)

'Public Sub DoihinhPN()
'    Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0,2, 0, 0, 0, 0) 'Diem giua
'    Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0,2, 0, 0, 0, 0) 'Diem giua
'    Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0,2, 0, 0, 0, 0) 'Diem giua
'    Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(1 / 3 * (P2.X + P1.X + P3.X), 1 / 3 * (P2.Y + P1.Y + P3.Y), 0, 2, 0, 0, 0, 0)
'    Dim Pc12 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(1 / 2 * (P1.X + P2.X), 1 / 2 * (P1.Y + P2.Y), 0, 2, 0, 0, 0, 0)
'    Dim Kc As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y) / 5
'    Dim P21 As IPosition71, Pk31 As IPosition71 = Nothing, Pk61 As IPosition71 = Nothing

'    If Lenhve = "DHPNBB" Or Lenhve = "DHPNBBXT" Then
'        P21 = P3.Move(Dorongduong * 10, FGoc(Pc12, P3) + 180, 0)
'    Else
'        P21 = P3.Move(-Dorongduong * 2, FGoc(Pc12, P3) + 180, 0)
'    End If

'    Dim Pd As IPosition71 = P21.Move(Kc - Dorongduong * 4, FGoc(Pc12, P3), 0)

'    If Lenhve = "CumPNtieudoan" Then
'        Dim Pk1 As IPosition71 = P21.Move(Dorongduong * 8, FGoc(Pc12, P3) + 90, 0)
'        Dim Pk2 As IPosition71 = P21.Move(Dorongduong * 8, FGoc(Pc12, P3) + 270, 0)
'        Dim Pk3 As IPosition71 = P21.Move(Kc + Dorongduong, FGoc(Pc12, P3) + 65, 0)
'        Dim Pk4 As IPosition71 = P21.Move(Kc + Dorongduong * 4, FGoc(Pc12, P3) + 40, 0)
'        Dim Pk5 As IPosition71 = P21.Move(Kc + Dorongduong * 4, FGoc(Pc12, P3) + 320, 0)
'        Dim Pk6 As IPosition71 = P21.Move(Kc + Dorongduong, FGoc(Pc12, P3) + 295, 0)
'        '//////////////
'        Dim liP As New List(Of IPosition71) From {Pk1, Pk3, Pk4, Pd, Pk5, Pk6, Pk2}
'        Dim lP As List(Of IPosition71) = Curveline(liP, 12)
'        Dim cRing As ILinearRing = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(ListtoAarray(lP))
'        Dim G1 As IGeometry = FrmMain.Instance.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(cRing, Nothing)
'        Dim G2 As IGeometry = G1.SpatialOperator.buffer(Dorongduong * -2)
'        FDuongList(GeoToList(G2), 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
'        FDuongList(lP, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
'        '////////////////////////
'        Dim GocP2 As Double = MkGoc(P3, Pc12) * 180 / Math.PI
'        CongsuTQ(MkGoc(P3, Pc12) * 180 / Math.PI, P3)
'        CumPNDaidoi(P1, FGoc(P3, P1)) ' + 250)
'        CumPNDaidoi(P2, FGoc(P3, P2))  ' + 290)
'        '//////////////////////
'        SLenhve3DMs()
'        Lenhve = "veco"
'        FrmMain.Instance.mPointClick = Pc
'        loaiKH = "100007"
'        Pk31 = P21.Move(Kc + Dorongduong * 3, FGoc(Pc12, P3) + 65, 0)
'        Pk61 = P21.Move(Kc + Dorongduong * 3, FGoc(Pc12, P3) + 295, 0)
'    ElseIf Lenhve = "DHPNBB" Or Lenhve = "DHPNBBXT" Then
'        CumPNDaidoi(P1, FGoc(P3, P1)) ' + 250)
'        CumPNDaidoi(P2, FGoc(P3, P2))  ' + 290)
'        CumPNDaidoi(P3, FGoc(P3, P1)) ' + 250)
'        If Lenhve = "DHPNBBXT" Then
'            Dim Pk1 As IPosition71 = P1.Move(-Dorongduong * 8.25, FGoc(P3, Pc12), 0)
'            Dim Pk2 As IPosition71 = P2.Move(-Dorongduong * 8.25, FGoc(P3, Pc12), 0)
'            Dim Pk3 As IPosition71 = P3.Move(-Dorongduong * 8.25, FGoc(P3, Pc12), 0)
'            XT1(Pk1, Tyle * 3.2, MkGoc(P3, Pc12) * 180 / Math.PI)
'            XT1(Pk2, Tyle * 3.2, MkGoc(P3, Pc12) * 180 / Math.PI)
'            XT1(Pk3, Tyle * 3.2, MkGoc(P3, Pc12) * 180 / Math.PI)
'            DemXT(Pk1, Tyle * 3.2, MkGoc(P3, Pc12) * 180 / Math.PI)
'            DemXT(Pk2, Tyle * 3.2, MkGoc(P3, Pc12) * 180 / Math.PI)
'            DemXT(Pk3, Tyle * 3.2, MkGoc(P3, Pc12) * 180 / Math.PI)
'        End If
'        Pk31 = P21.Move(Dorongduong * 15, FGoc(Pc12, P3) + 65, 0)
'        Pk61 = P21.Move(Dorongduong * 15, FGoc(Pc12, P3) + 295, 0)
'    ElseIf Lenhve = "muctieuthenchot" Then
'    End If

'    CanhDHPN(Pk31, P2, 270, 15)
'    CanhDHPN(Pk61, P1, 90, -15)
'    If Lenhve = "DHPNBB" Or Lenhve = "DHPNBBXT" Then
'        PNThenchot(P1, FGoc(P3, Pc12))
'        PNThenchot(P2, FGoc(P3, Pc12))
'        PNThenchot(P3, FGoc(P3, Pc12))
'    Else
'        PNThenchot(P1, FGoc(P3, Pc12))
'        PNThenchot(P2, FGoc(P3, Pc12))
'        Dim kcDay As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(Pk31.X, Pk31.Y, Pk61.X, Pk61.Y)
'        Dim Pk3 As IPosition71 = P21.Move(Kc + Dorongduong, FGoc(Pc12, P3) + 65, 0)
'        For i As Integer = 1 To (kcDay / (Dorongduong * 5)) - 1
'            Dim Ps1 As IPosition71 = Pk3.Move(-Dorongduong * 5 * i, FGoc(Pk31, Pk61), 0)
'            GachPNTehchot(Ps1, FGoc(P3, Pc12), Dorongduong * 7)
'        Next
'    End If

'End Sub





'FrmMain.Instance.sgworldMain.Creator.CreateLabel(Pday, "Pday", "", nothing, "", "Pday")
'If Lenhve = "TuyenTrKTcBobinh" Then
'PhanBb(GeoMuiten, GeoChinh, GeoCC1, Pc, Pc1, Pc2, P1, P3, P11, P31, P32, P12, KC, G2)


''If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 1 Then 'Sư đoàn, Lữ đoàn,Trung đoàn ...
''    LudoanBB(GeoMuiten, Pc, Pc1, Pc2, P1, P3, KC + Dorongduong / 2, G2)
''    Ms = 0
''ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then ' Đại đội, Trung đội...
''    GeoChinh = MtcBCBb(GeoCC1, P1, P11, P31, P3)
''    Dim liDem As New List(Of IPosition71) From {P31, P32, P12, P11}
''    Dim GeoDem As IGeometry = ListtoGeo(liDem)
''    liChinh = GeoToList(GeoChinh)
''    '    liDemC.Clear()
''    liDemC = GeoToList(GeoDem)
''    DoihinhTcongBB(FrmMain.Instance.sgworldMain, liChinh, GroupBac2Main, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
''    DoihinhTcongBB(FrmMain.Instance.sgworldMain, liDemC, GroupBac2Main, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "2")
''ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 2 Then 'Tiểu đoàn ...
''    Dim Geo1 As IGeometry = Bb_XtIgeo(Pc, KC, 0, G2)
''    Dim GeoTong As IGeometry = GeoCC1.SpatialOperator.Union(Geo1)
''    Dim GeoDem1 As IGeometry = Bb_XtIgeo(Pc1, KC, 1.5, G2)
''    liChinh = GeoToList(GeoTong)
''    '  liDemC.Clear()
''    liDemC = GeoToList(GeoDem1)
''    DoihinhTcongBB(FrmMain.Instance.sgworldMain, liChinh, GroupBac2Main, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
''    DoihinhTcongBB(FrmMain.Instance.sgworldMain, liDemC, GroupBac2Main, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "2")
''End If

'ElseIf Lenhve = "TuyenTrKTcBobinhXetang" Then
'PhanBbXt(GeoMuiten, GeoCC1, Pc, Pc1, Pc2, P1, P3, P11, P31, KC, G2)
''If FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 1 Then 'Sư đoàn, Lữ đoàn,Trung đoàn ...
''    LudoanBB(GeoMuiten, Pc, Pc1, Pc2, P1, P3, KC + Dorongduong / 2, G2)
''    Ms = 0
''ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 2 Then 'Tiểu đoàn ...
''    Dim Geo1 As IGeometry = Bb_XtIgeo(Pc, KC, 0, G2)
''    Dim GeoTong As IGeometry = GeoCC1.SpatialOperator.Union(Geo1)
''    liChinh = GeoToList(GeoTong)
''    DoihinhTcongBB_XT(FrmMain.Instance.sgworldMain, liChinh, liXtT1, liXtP1, liXtT2, liXtP2, GroupBac2Main, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
''    Dim GeoDem1 As IGeometry = Bb_XtIgeo(Pc1, KC, 1.5, G2)
''    '  VungFormGeo(GeoDem1, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 1, "1")
''    '  liDemC.Clear()
''    liDemC = GeoToList(GeoDem1)
''    DoihinhTcongBB_XT(FrmMain.Instance.sgworldMain, liDemC, liXtT2, liXtP2, liXtT3, liXtP3, GroupBac2Main, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "2")
''ElseIf FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiKHQS_HDTC.SelectedIndex = 4 Then ' Đại đội, Trung đội...
''    liChinh = GeoToList(MtcBCBb(GeoCC1, P1, P11, P31, P3))
''    DoihinhTcongBB_XT(FrmMain.Instance.sgworldMain, liChinh, liXtT1, liXtP1, liXtT2, liXtP2, GroupBac2Main, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
''    DoihinhTcongBB_XT(FrmMain.Instance.sgworldMain, liDemC, liXtT2, liXtP2, liXtT3, liXtP3, GroupBac2Main, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "2")
''Else
''    liChinh = GeoToList(GeoCC1)
''    DoihinhTcongBB_XT(FrmMain.Instance.sgworldMain, liChinh, liXtT1, liXtP1, liXtT2, liXtP2, GroupBac2Main, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "1")
''    DoihinhTcongBB_XT(FrmMain.Instance.sgworldMain, liDemC, liXtT2, liXtP2, liXtT3, liXtP3, GroupBac2Main, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "2")
''End If
'/////////////////
'Public Sub Giaotranhgiangco()
'    Dim Khoangcach As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
'    Dim Goc1 As Double = Phuongvi * 180 / Math.PI
'    Dim hesoTyle As Double = Khoangcach / 290.942 * Tyle
'    Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0,2, 0, 0, 0, 0) 'Diem giua
'    'Dim k(200) As IPosition71
'    'k(1) = Pc.Move(25.889 * hesoTyle, 63.8 - Goc1, 0)
'    'k(2) = Pc.Move(33.04 * hesoTyle, 314.6 - Goc1, 0)
'    'k(3) = Pc.Move(22.541 * hesoTyle, 314.8 - Goc1, 0)
'    'k(4) = Pc.Move(26.295 * hesoTyle, 308.1 - Goc1, 0)
'    'k(5) = Pc.Move(30.229 * hesoTyle, 302.5 - Goc1, 0)
'    'k(6) = Pc.Move(35.272 * hesoTyle, 295.1 - Goc1, 0)
'    'k(7) = Pc.Move(39.92 * hesoTyle, 288.1 - Goc1, 0)
'    'k(8) = Pc.Move(44.116 * hesoTyle, 281.2 - Goc1, 0)
'    'k(9) = Pc.Move(47.811 * hesoTyle, 274.4 - Goc1, 0)
'    'k(10) = Pc.Move(50.959 * hesoTyle, 267.8 - Goc1, 0)
'    'k(11) = Pc.Move(54.509 * hesoTyle, 258.9 - Goc1, 0)
'    'k(12) = Pc.Move(57.363 * hesoTyle, 250.3 - Goc1, 0)
'    'k(13) = Pc.Move(59.471 * hesoTyle, 241.8 - Goc1, 0)
'    'k(14) = Pc.Move(61.097 * hesoTyle, 234.1 - Goc1, 0)
'    'k(15) = Pc.Move(62.319 * hesoTyle, 226.5 - Goc1, 0)
'    'k(16) = Pc.Move(63.121 * hesoTyle, 218.9 - Goc1, 0)
'    'k(17) = Pc.Move(63.492 * hesoTyle, 211.4 - Goc1, 0)
'    'k(18) = Pc.Move(63.426 * hesoTyle, 203.9 - Goc1, 0)
'    'k(19) = Pc.Move(62.926 * hesoTyle, 196.4 - Goc1, 0)
'    'k(20) = Pc.Move(61.997 * hesoTyle, 188.8 - Goc1, 0)
'    'k(21) = Pc.Move(60.652 * hesoTyle, 181.2 - Goc1, 0)
'    'k(22) = Pc.Move(59.369 * hesoTyle, 173.9 - Goc1, 0)
'    'k(23) = Pc.Move(137.783 * hesoTyle, 94.8 - Goc1, 0)
'    'k(24) = Pc.Move(134.03 * hesoTyle, 91.2 - Goc1, 0)
'    'k(25) = Pc.Move(50.225 * hesoTyle, 176.5 - Goc1, 0)
'    'k(26) = Pc.Move(51.984 * hesoTyle, 183.0 - Goc1, 0)
'    'k(27) = Pc.Move(53.246 * hesoTyle, 190.1 - Goc1, 0)
'    'k(28) = Pc.Move(54.116 * hesoTyle, 197.2 - Goc1, 0)
'    'k(29) = Pc.Move(54.584 * hesoTyle, 204.2 - Goc1, 0)
'    'k(30) = Pc.Move(54.645 * hesoTyle, 211.2 - Goc1, 0)
'    'k(31) = Pc.Move(54.298 * hesoTyle, 218.3 - Goc1, 0)
'    'k(32) = Pc.Move(53.548 * hesoTyle, 225.3 - Goc1, 0)
'    'k(33) = Pc.Move(52.402 * hesoTyle, 232.4 - Goc1, 0)
'    'k(34) = Pc.Move(50.357 * hesoTyle, 239.8 - Goc1, 0)
'    'k(35) = Pc.Move(48.483 * hesoTyle, 247.2 - Goc1, 0)
'    'k(36) = Pc.Move(45.939 * hesoTyle, 254.7 - Goc1, 0)
'    'k(37) = Pc.Move(42.639 * hesoTyle, 262.7 - Goc1, 0)
'    'k(38) = Pc.Move(40.197 * hesoTyle, 267.5 - Goc1, 0)
'    'k(39) = Pc.Move(37.137 * hesoTyle, 272.5 - Goc1, 0)
'    'k(40) = Pc.Move(33.667 * hesoTyle, 277.4 - Goc1, 0)
'    'k(41) = Pc.Move(29.832 * hesoTyle, 281.8 - Goc1, 0)
'    'k(42) = Pc.Move(26.522 * hesoTyle, 285.0 - Goc1, 0)
'    'k(43) = Pc.Move(21.932 * hesoTyle, 288.5 - Goc1, 0)
'    'k(44) = Pc.Move(17.991 * hesoTyle, 291.5 - Goc1, 0)
'    'k(45) = Pc.Move(23.972 * hesoTyle, 270.0 - Goc1, 0)

'    'k(46) = Pc.Move(137.783 * hesoTyle, 94.8 - Goc1, 0)
'    'k(47) = Pc.Move(134.03 * hesoTyle, 91.2 - Goc1, 0)
'    'k(48) = Pc.Move(50.225 * hesoTyle, 176.5 - Goc1, 0)
'    'k(49) = Pc.Move(51.984 * hesoTyle, 183.0 - Goc1, 0)
'    'k(50) = Pc.Move(53.246 * hesoTyle, 190.1 - Goc1, 0)
'    'k(51) = Pc.Move(54.116 * hesoTyle, 197.2 - Goc1, 0)
'    'k(52) = Pc.Move(54.584 * hesoTyle, 204.2 - Goc1, 0)
'    'k(53) = Pc.Move(54.645 * hesoTyle, 211.2 - Goc1, 0)
'    'k(54) = Pc.Move(54.298 * hesoTyle, 218.3 - Goc1, 0)
'    'k(55) = Pc.Move(53.548 * hesoTyle, 225.3 - Goc1, 0)
'    'k(56) = Pc.Move(52.402 * hesoTyle, 232.4 - Goc1, 0)
'    'k(57) = Pc.Move(50.357 * hesoTyle, 239.8 - Goc1, 0)
'    'k(58) = Pc.Move(48.483 * hesoTyle, 247.2 - Goc1, 0)
'    'k(59) = Pc.Move(45.939 * hesoTyle, 254.7 - Goc1, 0)
'    'k(60) = Pc.Move(42.639 * hesoTyle, 262.7 - Goc1, 0)
'    'k(61) = Pc.Move(40.197 * hesoTyle, 267.5 - Goc1, 0)
'    'k(62) = Pc.Move(37.137 * hesoTyle, 272.5 - Goc1, 0)
'    'k(63) = Pc.Move(33.667 * hesoTyle, 277.4 - Goc1, 0)
'    'k(64) = Pc.Move(29.832 * hesoTyle, 281.8 - Goc1, 0)
'    'k(65) = Pc.Move(26.522 * hesoTyle, 285.0 - Goc1, 0)
'    'k(66) = Pc.Move(24.951 * hesoTyle, 286.3 - Goc1, 0)
'    'k(67) = Pc.Move(29.423 * hesoTyle, 279 - Goc1, 0)
'    'k(68) = Pc.Move(33.292 * hesoTyle, 271.7 - Goc1, 0)
'    'k(69) = Pc.Move(36.79 * hesoTyle, 264.3 - Goc1, 0)
'    'k(70) = Pc.Move(39.559 * hesoTyle, 256.9 - Goc1, 0)
'    'k(71) = Pc.Move(41.65 * hesoTyle, 249.5 - Goc1, 0)
'    'k(72) = Pc.Move(42.581 * hesoTyle, 243.1 - Goc1, 0)
'    'k(73) = Pc.Move(43.355 * hesoTyle, 236.8 - Goc1, 0)
'    'k(74) = Pc.Move(43.964 * hesoTyle, 230.5 - Goc1, 0)
'    'k(75) = Pc.Move(44.403 * hesoTyle, 224.3 - Goc1, 0)
'    'k(76) = Pc.Move(44.669 * hesoTyle, 218.1 - Goc1, 0)
'    'k(77) = Pc.Move(44.758 * hesoTyle, 211.9 - Goc1, 0)
'    'k(78) = Pc.Move(44.67 * hesoTyle, 205.8 - Goc1, 0)
'    'k(79) = Pc.Move(44.405 * hesoTyle, 199.6 - Goc1, 0)
'    'k(80) = Pc.Move(43.966 * hesoTyle, 193.4 - Goc1, 0)
'    'k(81) = Pc.Move(42.965 * hesoTyle, 186.7 - Goc1, 0)
'    'k(82) = Pc.Move(41.695 * hesoTyle, 180 - Goc1, 0)
'    'k(83) = Pc.Move(132.9 * hesoTyle, 90 - Goc1, 0)

'    'k(84) = Pc.Move(25.889 * hesoTyle, 243.8 - Goc1, 0)
'    'k(85) = Pc.Move(33.04 * hesoTyle, 134.6 - Goc1, 0)
'    'k(86) = Pc.Move(22.541 * hesoTyle, 134.8 - Goc1, 0)
'    'k(87) = Pc.Move(26.295 * hesoTyle, 128.1 - Goc1, 0)
'    'k(88) = Pc.Move(30.229 * hesoTyle, 122.5 - Goc1, 0)
'    'k(89) = Pc.Move(35.272 * hesoTyle, 115.1 - Goc1, 0)
'    'k(90) = Pc.Move(39.92 * hesoTyle, 108.1 - Goc1, 0)
'    'k(91) = Pc.Move(44.116 * hesoTyle, 101.2 - Goc1, 0)
'    'k(92) = Pc.Move(47.811 * hesoTyle, 94.4 - Goc1, 0)
'    'k(93) = Pc.Move(50.959 * hesoTyle, 87.8 - Goc1, 0)
'    'k(94) = Pc.Move(54.509 * hesoTyle, 78.9 - Goc1, 0)
'    'k(95) = Pc.Move(57.363 * hesoTyle, 70.3 - Goc1, 0)
'    'k(96) = Pc.Move(59.471 * hesoTyle, 61.8 - Goc1, 0)
'    'k(97) = Pc.Move(61.097 * hesoTyle, 54.1 - Goc1, 0)
'    'k(98) = Pc.Move(62.319 * hesoTyle, 46.5 - Goc1, 0)
'    'k(99) = Pc.Move(63.121 * hesoTyle, 38.9 - Goc1, 0)
'    'k(100) = Pc.Move(63.492 * hesoTyle, 31.4 - Goc1, 0)
'    'k(101) = Pc.Move(63.426 * hesoTyle, 23.9 - Goc1, 0)
'    'k(102) = Pc.Move(62.926 * hesoTyle, 16.4 - Goc1, 0)
'    'k(103) = Pc.Move(61.997 * hesoTyle, 8.8 - Goc1, 0)
'    'k(104) = Pc.Move(60.652 * hesoTyle, 1.2 - Goc1, 0)
'    'k(105) = Pc.Move(59.369 * hesoTyle, 353.9 - Goc1, 0)
'    'k(106) = Pc.Move(137.783 * hesoTyle, 274.8 - Goc1, 0)
'    'k(107) = Pc.Move(134.03 * hesoTyle, 271.2 - Goc1, 0)
'    'k(108) = Pc.Move(50.225 * hesoTyle, 356.5 - Goc1, 0)
'    'k(109) = Pc.Move(51.984 * hesoTyle, 3.0 - Goc1, 0)
'    'k(110) = Pc.Move(53.246 * hesoTyle, 10.1 - Goc1, 0)
'    'k(111) = Pc.Move(54.116 * hesoTyle, 17.2 - Goc1, 0)
'    'k(112) = Pc.Move(54.584 * hesoTyle, 24.2 - Goc1, 0)
'    'k(113) = Pc.Move(54.645 * hesoTyle, 31.2 - Goc1, 0)
'    'k(114) = Pc.Move(54.298 * hesoTyle, 38.3 - Goc1, 0)
'    'k(115) = Pc.Move(53.548 * hesoTyle, 45.3 - Goc1, 0)
'    'k(116) = Pc.Move(52.402 * hesoTyle, 52.4 - Goc1, 0)
'    'k(117) = Pc.Move(50.357 * hesoTyle, 59.8 - Goc1, 0)
'    'k(118) = Pc.Move(48.483 * hesoTyle, 67.2 - Goc1, 0)
'    'k(119) = Pc.Move(45.939 * hesoTyle, 74.7 - Goc1, 0)
'    'k(120) = Pc.Move(42.639 * hesoTyle, 82.7 - Goc1, 0)
'    'k(121) = Pc.Move(40.197 * hesoTyle, 87.5 - Goc1, 0)
'    'k(122) = Pc.Move(37.137 * hesoTyle, 92.5 - Goc1, 0)
'    'k(123) = Pc.Move(33.667 * hesoTyle, 97.4 - Goc1, 0)
'    'k(124) = Pc.Move(29.832 * hesoTyle, 101.8 - Goc1, 0)
'    'k(125) = Pc.Move(26.522 * hesoTyle, 105.0 - Goc1, 0)
'    'k(126) = Pc.Move(21.932 * hesoTyle, 108.5 - Goc1, 0)
'    'k(127) = Pc.Move(17.991 * hesoTyle, 111.5 - Goc1, 0)
'    'k(128) = Pc.Move(23.972 * hesoTyle, 90.0 - Goc1, 0)

'    'k(129) = Pc.Move(137.783 * hesoTyle, 274.8 - Goc1, 0)
'    'k(130) = Pc.Move(134.03 * hesoTyle, 271.2 - Goc1, 0)
'    'k(131) = Pc.Move(50.225 * hesoTyle, 356.5 - Goc1, 0)
'    'k(132) = Pc.Move(51.984 * hesoTyle, 3.0 - Goc1, 0)
'    'k(133) = Pc.Move(53.246 * hesoTyle, 10.1 - Goc1, 0)
'    'k(134) = Pc.Move(54.116 * hesoTyle, 17.2 - Goc1, 0)
'    'k(135) = Pc.Move(54.584 * hesoTyle, 24.2 - Goc1, 0)
'    'k(136) = Pc.Move(54.645 * hesoTyle, 31.2 - Goc1, 0)
'    'k(137) = Pc.Move(54.298 * hesoTyle, 38.3 - Goc1, 0)
'    'k(138) = Pc.Move(53.548 * hesoTyle, 45.3 - Goc1, 0)
'    'k(139) = Pc.Move(52.402 * hesoTyle, 52.4 - Goc1, 0)
'    'k(140) = Pc.Move(50.357 * hesoTyle, 59.8 - Goc1, 0)
'    'k(141) = Pc.Move(48.483 * hesoTyle, 67.2 - Goc1, 0)
'    'k(142) = Pc.Move(45.939 * hesoTyle, 74.7 - Goc1, 0)
'    'k(143) = Pc.Move(42.639 * hesoTyle, 82.7 - Goc1, 0)
'    'k(144) = Pc.Move(40.197 * hesoTyle, 87.5 - Goc1, 0)
'    'k(145) = Pc.Move(37.137 * hesoTyle, 92.5 - Goc1, 0)
'    'k(146) = Pc.Move(33.667 * hesoTyle, 97.4 - Goc1, 0)
'    'k(147) = Pc.Move(29.832 * hesoTyle, 101.8 - Goc1, 0)
'    'k(148) = Pc.Move(26.522 * hesoTyle, 105.0 - Goc1, 0)
'    'k(149) = Pc.Move(24.951 * hesoTyle, 106.3 - Goc1, 0)
'    'k(150) = Pc.Move(29.423 * hesoTyle, 99 - Goc1, 0)
'    'k(151) = Pc.Move(33.292 * hesoTyle, 91.7 - Goc1, 0)
'    'k(152) = Pc.Move(36.79 * hesoTyle, 84.3 - Goc1, 0)
'    'k(153) = Pc.Move(39.559 * hesoTyle, 76.9 - Goc1, 0)
'    'k(154) = Pc.Move(41.65 * hesoTyle, 69.5 - Goc1, 0)
'    'k(155) = Pc.Move(42.581 * hesoTyle, 63.1 - Goc1, 0)
'    'k(156) = Pc.Move(43.355 * hesoTyle, 56.8 - Goc1, 0)
'    'k(157) = Pc.Move(43.964 * hesoTyle, 50.5 - Goc1, 0)
'    'k(158) = Pc.Move(44.403 * hesoTyle, 44.3 - Goc1, 0)
'    'k(159) = Pc.Move(44.669 * hesoTyle, 38.1 - Goc1, 0)
'    'k(160) = Pc.Move(44.758 * hesoTyle, 31.9 - Goc1, 0)
'    'k(161) = Pc.Move(44.67 * hesoTyle, 25.8 - Goc1, 0)
'    'k(162) = Pc.Move(44.405 * hesoTyle, 19.6 - Goc1, 0)
'    'k(163) = Pc.Move(43.966 * hesoTyle, 13.4 - Goc1, 0)
'    'k(164) = Pc.Move(42.965 * hesoTyle, 6.7 - Goc1, 0)
'    'k(165) = Pc.Move(41.695 * hesoTyle, 360 - Goc1, 0)
'    'k(166) = Pc.Move(132.9 * hesoTyle, 270 - Goc1, 0)
'    'vung = FVungPoint(k, 1, 45, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
'    'vung = FVungPoint(k, 46, 83, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
'    'vung = FVungPoint(k, 84, 128, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
'    'vung = FVungPoint(k, 129, 166, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)



'    Dim TQ As New List(Of Double)({25.889, 63.8, 33.04, 314.6, 22.541, 314.8, 26.295, 308.1, 30.229, 302.5, 35.272, 295.1, 39.92, 288.1, 44.116, 281.2, 47.811, 274.4, 50.959, 267.8, 54.509, 258.9, 57.363, 250.3, 59.471, 241.8, 61.097, 234.1, 62.319, 226.5, 63.121, 218.9, 63.492, 211.4, 63.426, 203.9, 62.926, 196.4, 61.997, 188.8, 60.652, 181.2, 59.369, 173.9, 137.783, 94.8, 134.03, 91.2, 50.225, 176.5, 51.984, 183.0, 53.246, 190.1, 54.116, 197.2, 54.584, 204.2, 54.645, 211.2, 54.298, 218.3, 53.548, 225.3, 52.402, 232.4, 50.357, 239.8, 48.483, 247.2, 45.939, 254.7, 42.639, 262.7, 40.197, 267.5, 37.137, 272.5, 33.667, 277.4, 29.832, 281.8, 26.522, 285.0, 21.932, 288.5, 17.991, 291.5, 23.972, 270.0, 137.783, 94.8, 134.03, 91.2, 50.225, 176.5, 51.984, 183.0, 53.246, 190.1, 54.116, 197.2, 54.584, 204.2, 54.645, 211.2, 54.298, 218.3, 53.548, 225.3, 52.402, 232.4, 50.357, 239.8, 48.483, 247.2, 45.939, 254.7, 42.639, 262.7, 40.197, 267.5, 37.137, 272.5, 33.667, 277.4, 29.832, 281.8, 26.522, 285.0, 24.951, 286.3, 29.423, 279, 33.292, 271.7, 36.79, 264.3, 39.559, 256.9, 41.65, 249.5, 42.581, 243.1, 43.355, 236.8, 43.964, 230.5, 44.403, 224.3, 44.669, 218.1, 44.758, 211.9, 44.67, 205.8, 44.405, 199.6, 43.966, 193.4, 42.965, 186.7, 41.695, 180, 132.9, 90, 25.889, 243.8, 33.04, 134.6, 22.541, 134.8, 26.295, 128.1, 30.229, 122.5, 35.272, 115.1, 39.92, 108.1, 44.116, 101.2, 47.811, 94.4, 50.959, 87.8, 54.509, 78.9, 57.363, 70.3, 59.471, 61.8, 61.097, 54.1, 62.319, 46.5, 63.121, 38.9, 63.492, 31.4, 63.426, 23.9, 62.926, 16.4, 61.997, 8.8, 60.652, 1.2, 59.369, 353.9, 137.783, 274.8, 134.03, 271.2, 50.225, 356.5, 51.984, 3.0, 53.246, 10.1, 54.116, 17.2, 54.584, 24.2, 54.645, 31.2, 54.298, 38.3, 53.548, 45.3, 52.402, 52.4, 50.357, 59.8, 48.483, 67.2, 45.939, 74.7, 42.639, 82.7, 40.197, 87.5, 37.137, 92.5, 33.667, 97.4, 29.832, 101.8, 26.522, 105.0, 21.932, 108.5, 17.991, 111.5, 23.972, 90.0, 137.783, 274.8, 134.03, 271.2, 50.225, 356.5, 51.984, 3.0, 53.246, 10.1, 54.116, 17.2, 54.584, 24.2, 54.645, 31.2, 54.298, 38.3, 53.548, 45.3, 52.402, 52.4, 50.357, 59.8, 48.483, 67.2, 45.939, 74.7, 42.639, 82.7, 40.197, 87.5, 37.137, 92.5, 33.667, 97.4, 29.832, 101.8, 26.522, 105.0, 24.951, 106.3, 29.423, 99, 33.292, 91.7, 36.79, 84.3, 39.559, 76.9, 41.65, 69.5, 42.581, 63.1, 43.355, 56.8, 43.964, 50.5, 44.403, 44.3, 44.669, 38.1, 44.758, 31.9, 44.67, 25.8, 44.405, 19.6, 43.966, 13.4, 42.965, 6.7, 41.695, 360, 132.9, 270})

'    FVungPoint(ArrayPoint(TQ, Pc, hesoTyle, Goc1), 0, 44, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
'    FVungPoint(ArrayPoint(TQ, Pc, hesoTyle, Goc1), 45, 82, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
'    FVungPoint(ArrayPoint(TQ, Pc, hesoTyle, Goc1), 83, 127, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
'    FVungPoint(ArrayPoint(TQ, Pc, hesoTyle, Goc1), 128, 165, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
'    SLenhve3DMs()
'End Sub