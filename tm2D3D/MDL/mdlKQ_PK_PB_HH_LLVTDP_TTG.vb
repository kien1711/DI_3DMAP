Imports TerraExplorerX

Module mdlKhongquan

#Region "    Khongquan"

    Public Sub Doboduongkhong()
        Dim pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 50, 2, 0, 0, 0, 0) '
        If Lenhve = "doboduongkhong" Then
            loaiKH = "2120029"
        ElseIf Lenhve = "doboduongkhongTrT" Then
            loaiKH = "2120018a"
            'ElseIf Lenhve = "SungBBbanMB" Then
            '    loaiKH = "2110000"
        Else
            loaiKH = "2120028"
        End If
        fileImage = PathData & "\2X\" & loaiKH & Ta_Doiphuong & tenGiaidoan
        FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom, Center"
        FrmMain.Instance.mPoint.AltitudeType = 2
        Dim sP As IPosition71
        If Lenhve = "SungBBbanMB" Then
            sP = FrmMain.Instance.mPointClick
        Else
            sP = pc
        End If
        Dim Doituong = FrmMain.Instance.sgworldMain.Creator.CreateLabel(sP, "", fileImage, FrmMain.Instance.fLabelStyleMain, GroupBac2Main, tenKH)
        Doituong.Position.AltitudeType = 2
        Doituong.Position.Altitude = Tyle * 0.2
        Doituong.Tooltip.Text = mota
        mLabelArray.Add(Doituong)
        If Lenhve = "doboduongkhong" Or Lenhve = "doboduongkhongTrT" Or Lenhve = "Tieptebangdu" Then
            Dim Khoangcach As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
            Dim Goc1 As Double = Phuongvi * 180 / Math.PI '- Math.PI
            Dim hesoTyle As Double = Khoangcach / 290.0
            Dim TQ As New List(Of Double)({77.755, 13.8, 88.368, 28.9, 106.206, 38.7, 118.95, 44.0, 129.657, 49.7, 138.079, 55.7, 144.029, 61.9, 147.38, 68.2, 148.062, 74.6, 146.061, 80.9, 141.417, 87.2, 134.231, 93.3, 124.658, 99.2, 115.113, 104.1, 106.163, 109.6, 97.981, 115.9, 84.844, 131.5, 77.823, 150.6, 78.607, 171.1, 86.984, 189.6, 93.446, 197.5, 105.894, 209.4, 117.026, 220.4, 126.521, 230.8, 134.138, 240.9, 139.703, 250.7, 143.09, 260.4, 144.227, 270.0, 143.09, 279.6, 139.703, 289.3, 134.138, 299.1, 126.521, 309.2, 114.894, 318.8, 101.989, 329.1, 88.14, 340.5, 77.039, 358.5})
            FDuong(ArrayPointPlus(TQ, pc, hesoTyle, -1 * Dorongduong, Goc1), 0, 14, 4294967295, "", 0, 0, mau2, Dorongduong, True, 2, 0, 1) ', False) 
            FDuong(ArrayPointPlus(TQ, pc, hesoTyle, -1 * Dorongduong, Goc1), 15, 25, 4294967295, "", 0, 0, mau2, Dorongduong, True, 2, 0, 1) ', False) 
            FDuong(ArrayPointPlus(TQ, pc, hesoTyle, -1 * Dorongduong, Goc1), 26, 35, 4294967295, "", 0, 0, mau2, Dorongduong, True, 2, 0, 1) ', False) 
            Dim TQ1 As New List(Of Double)({77.755, 13.8, 88.368, 28.9, 106.206, 38.7, 118.95, 44.0, 129.657, 49.7, 138.079, 55.7, 144.029, 61.9, 147.38, 68.2, 148.062, 74.6, 146.061, 80.9, 141.417, 87.2, 134.231, 93.3, 124.658, 99.2, 115.113, 104.1, 106.163, 109.6, 97.981, 115.9, 84.844, 131.5, 77.823, 150.6, 78.607, 171.1, 86.984, 189.6, 93.446, 197.5, 105.894, 209.4, 117.026, 220.4, 126.521, 230.8, 134.138, 240.9, 139.703, 250.7, 143.09, 260.4, 144.227, 270.0, 143.09, 279.6, 139.703, 289.3, 134.138, 299.1, 126.521, 309.2, 114.894, 318.8, 101.989, 329.1, 88.14, 340.5, 77.039, 358.5})
            FDuong(ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1), 0, 14, 4294967295, "", 0, 0, mau, Dorongduong, True, 2, 0, 2) ', False) 
            FDuong(ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1), 15, 25, 4294967295, "", 0, 0, mau, Dorongduong, True, 2, 0, 2) ', False) 
            FDuong(ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1), 26, 35, 4294967295, "", 0, 0, mau, Dorongduong, True, 2, 0, 2) ', False)
            'Else
            '    MCircleTQ(FrmMain.Instance.mPointClick, Dorongduong * 12, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            '    MCircleTQ(FrmMain.Instance.mPointClick, Dorongduong * 10, 4294967295, Dorongduong, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, 1)

        End If
        SLenhve3DMs()
    End Sub

#Region "     Huong Tien cong KQ"

    Dim KYaw As Double, Soluot As Integer
    Public Sub HuongTCKQuan()
        Soluot = 0
        Hesodichchuyen = 0
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim G1 As Double = FGoc(P1, P2)
        Dim G2 As Double = FGoc(P1, P3)
        Dim KC As Double = FKc(P1, P3)
        Dim Ps As IPosition71 = CenterPoint(P1, P3)
        Dim Pc As IPosition71 = Ps.Move(FKc(P1, P3) / 10, FGoc(P1, Ps), 0)
        Dim GYaw, Heso As Double

        If G1 > G2 Then
            GYaw = FGoc(P1, P3) + 270
            KYaw = 270
        Else
            GYaw = FGoc(P1, P3) + 90
            KYaw = 90
        End If

        If FrmMain.Instance.soDiem = 7 Then
            Heso = 2
        ElseIf FrmMain.Instance.soDiem = 9 Then
            Heso = 1.7
        ElseIf FrmMain.Instance.soDiem = 11 Then
            Heso = 1.2
        End If

        Dim mRong As Double = Val(FrmMain.Instance.TxtGhichuKH.Text) / 2
        Dim Pc1 As IPosition71 = Pc.Move(FKc(P1, P3) / 8, GYaw, 0)
        Dim Pc4 As IPosition71 = Pc1.Move(-mRong * 7 / 8, FGoc(Pc1, Pc), 0)
        Dim Pd1 As IPosition71 = P1.Move(mRong, GYaw, 0)
        Dim Pd6 As IPosition71 = P1.Move(-mRong, GYaw, 0)
        Dim LiMT As List(Of IPosition71) = Muiten(P3, Pd1, FGoc(P3, Pc1), Heso, 1.0)
        LiMT.RemoveRange(3, 2)
        Dim LiD1 As List(Of IPosition71) = Point4(Pd1, Pd6)
        Dim LiD2 As List(Of IPosition71) = Point4(Pc1, Pc4)
        Dim GeoC As List(Of IGeometry) = MuiTCKQ(P1, P3, LiD1(0), LiD1(2), LiD1(3), mRong, Heso)

        Dim Kc11 As Double = FKc(LiD1(0), LiD2(0))

        If FrmMain.Instance.soDiem = 7 Then
            FVungList(GeoToList(GeoC(0)), 4294967295, 0.0, mau, 0, mau, 2, "", 0, 0, 0, False, 2, 1)
            FVungList(GeoToList(GeoC(1)), 4294967295, 0.0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        ElseIf FrmMain.Instance.soDiem = 9 Or FrmMain.Instance.soDiem = 11 Then
            Dim Pch As IPosition71 = CenterPoint(LiMT(1), LiMT(2))
            Dim LiN1 As List(Of IPosition71) = LiCrube3Point(LiMT(3), LiD2(0), LiD1(0)) 'LiT22
            Dim LiN2 As List(Of IPosition71) = LiCrube3Point(LiMT(2), LiD2(2), LiD1(2)) 'LiT21
            Dim LiN3 As List(Of IPosition71) = LiCrube3Point(Pch, LiD2(3), LiD1(3)) 'LiT23
            Dim LiN11, LiN21, LiN31 As New List(Of IPosition71)
            UniCruve(LiN11, LiN1)
            UniCruve(LiN21, LiN2)
            UniCruve(LiN31, LiN3)
            Dim P4 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(9), PllVts(10), 0, 2, 0, 0, 0, 0) 'Diem giua
            Dim KcM2 As Double = FKc(P3, P4)
            Dim Pg1, Pg2, Pg3 As IPosition71
            Dim i As Double
            i = 1.0 - KcM2 / Kc11
            Dim k As Integer '= System.Convert.ToInt16(i)

            If i > 0 Then
                If i < 0.2 Then
                    k = 10
                ElseIf i > 0.2 And i < 0.3 Then
                    k = 11
                ElseIf i > 0.3 And i < 0.4 Then
                    k = 13
                ElseIf i > 0.4 And i < 0.5 Then
                    k = 14
                ElseIf i > 0.5 And i < 0.6 Then
                    k = 15
                Else
                    k = 17
                End If
            Else
                k = 17 + (Math.Abs(i) * 10)
            End If

            If k > 22 Then
                Exit Sub
            Else
                Pg1 = LiN11(k)
                Pg2 = LiN21(k)
                Pg3 = LiN31(k)
            End If

            Dim GeoC1 As List(Of IGeometry) = MuiTCKQ(Pg1, P4, Pg1, Pg2, Pg3, Val(FrmMain.Instance.TxtGhichuKH.Text) / 3, Heso)
            Dim IGeo1 As IGeometry = GeoC(0).SpatialOperator.Union(GeoC1(0))
            Dim IGeo2 As IGeometry = GeoC(1).SpatialOperator.Union(GeoC1(1))
            If FrmMain.Instance.soDiem = 9 Then
                FVungList(GeoToList(IGeo1), 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(GeoToList(IGeo2), 4294967295, 0.0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
            End If

            If FrmMain.Instance.soDiem = 11 Then
                Dim P5 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(12), PllVts(13), 0, 2, 0, 0, 0, 0) 'Diem giua
                Dim KcM3 As Double = FKc(P3, P5)
                k += 3
                Pg1 = LiN11(k)
                Pg2 = LiN21(k)
                Pg3 = LiN31(k)
                Dim GeoC2 As List(Of IGeometry) = MuiTCKQ(Pg1, P5, Pg1, Pg2, Pg3, Val(FrmMain.Instance.TxtGhichuKH.Text) / 6, Heso)
                Dim IGeo11 As IGeometry = IGeo1.SpatialOperator.Union(GeoC2(0))
                Dim IGeo21 As IGeometry = IGeo2.SpatialOperator.Union(GeoC2(1))
                FVungList(GeoToList(IGeo11), 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(GeoToList(IGeo21), 4294967295, 0.0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
            End If
        End If
        SLenhve3DMs()
    End Sub

    Function Point4(p1 As IPosition71, p2 As IPosition71) As List(Of IPosition71)
        Dim Pdc As IPosition71 = CenterPoint(p1, p2)
        Dim Pd1 As IPosition71 = Pdc.Move(FKc(p1, p2) * 1 / 6, FGoc(p1, p2), 0)
        Dim Pd2 As IPosition71 = Pdc.Move(FKc(p1, p2) * 1 / 6, FGoc(p1, p2) + 180, 0)
        Dim Li As New List(Of IPosition71) From {p1, Pd1, Pd2, p2}
        'For i As Integer = 0 To Li.Count - 1
        '    FrmMain.Instance.sgworldMain.Creator.CreateLabel(Li(i), i.ToString, "", Nothing, "", i.ToString)
        'Next
        Point4 = Li
    End Function

    Function MuiTCKQ(p1 As IPosition71, p3 As IPosition71, Ph0 As IPosition71, Ph2 As IPosition71, Ph3 As IPosition71, SRong As Double, Heso As Double) As List(Of IGeometry)
        Dim Ps As IPosition71 = CenterPoint(p1, p3)
        Dim Pc As IPosition71 = Ps.Move(FKc(p1, p3) / 10, FGoc(p1, Ps), 0)
        If Soluot = 2 Then
            Hesodichchuyen = 2
        End If
        Dim Pc1 As IPosition71 = Pc.Move(FKc(p1, p3) / (8 + Hesodichchuyen), KYaw + FGoc(p1, Ps), 0)
        Dim Pc4 As IPosition71 = Pc1.Move(-SRong * (7 + (Hesodichchuyen * 3)) / 8, FGoc(Pc1, Pc), 0)
        Dim Pd1 As IPosition71 = p1.Move(SRong, FGoc(p1, Ps), 0)

        Dim LiMT As List(Of IPosition71) = Muiten(p3, Pd1, FGoc(p3, Pc1), Heso, 1.0)
        LiMT.RemoveRange(3, 2)
        Dim LiD2 As List(Of IPosition71) = Point4(Pc1, Pc4)
        Dim Pch As IPosition71
        Dim LiN1, LiN2 As List(Of IPosition71)
        If KYaw = 90 Then
            LiN1 = LiCrube3Point(LiMT(2), LiD2(0), Ph0) 'LiT22
            LiN2 = LiCrube3Point(LiMT(3), LiD2(2), Ph2) 'LiT21
            Pch = CenterPoint(LiMT(3), LiMT(4))
        Else
            LiN1 = LiCrube3Point(LiMT(3), LiD2(0), Ph0) 'LiT22
            LiN2 = LiCrube3Point(LiMT(2), LiD2(2), Ph2) 'LiT21
            Pch = CenterPoint(LiMT(1), LiMT(2))
        End If
        Dim LiN3 As List(Of IPosition71) = LiCrube3Point(Ph3, LiD2(3), Pch) 'LiT23
        Dim LiC1 As New List(Of IPosition71)
        AddPointToList(LiC1, LiMT, 0, 1)
        UniCruve(LiN3, LiN2)
        If KYaw = 90 Then
            LiN2.Reverse()
            UniCruve(LiC1, LiN1)
            UniCruve(LiC1, LiN2)
        Else
            LiN1.Reverse()
            UniCruve(LiC1, LiN2)
            UniCruve(LiC1, LiN1)
        End If
        LiC1.Add(LiMT(4))
        Dim GeoT As New List(Of IGeometry) From {ListtoGeo(LiC1), ListtoGeo(LiN3)}
        MuiTCKQ = GeoT
        Soluot += 1
    End Function

#End Region

    Public Sub TcKQ_HQ()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0)
        Dim Goc1 As Double = FGoc(P1, P2)
        Dim Goc2 As Double = FGoc(P3, P2)
        Dim Mt1 As IPosition71 = Nothing, Mt2 As IPosition71
        Dim Rongnet As Double

        If Lenhve = "HuongTCChuyeuKQchendich" Then
            Rongnet = Dorongduong * 2.5
        Else
            Rongnet = Dorongduong * 1.5
        End If

        Dim LiXanh, LiDo As New List(Of IPosition71)

        If Lenhve = "HuongTCChuyeuKQchendich" Or Lenhve = "HuongTCThuyeuKQchendich" Or Lenhve = "HQhanhquan" Then
            Mt2 = P2
            Dim liXanhDuoi As List(Of IPosition71) = P4Ngang(P2, P1, 0, 60 * Dorongduong, Dorongduong * 8.0, Rongnet)
            Dim liXanhMt As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 10.0, Dorongduong * 11.0, Rongnet)
            LiXanh = New List(Of IPosition71) From {liXanhDuoi(1), liXanhMt(2), liXanhMt(1), Mt2, liXanhMt(4), liXanhMt(3), liXanhDuoi(4), liXanhDuoi(1)}
            If Lenhve = "HuongTCChuyeuKQchendich" Or Lenhve = "HuongTCThuyeuKQchendich" Then
                Dim PdXanh As IPosition71 = CenterPoint(LiXanh(6), LiXanh(7))
                Dim PChu As IPosition71 = CenterPoint(LiXanh(3), PdXanh)
                MakeText(PChu, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, Goc1 + 90, FrmMain.Instance.TxtGhichuKH.Text, "", mau3, 0, 0, 2, 2)

            Else
                Dim Pduoi As IPosition71 = CenterPoint(LiXanh(6), LiXanh(7))
                Dim Pduoi1 As IPosition71 = Pduoi.Move(Dorongduong * 40.0, Goc1, 0)
                Dim Pduoi2 As IPosition71 = P2.Move(Dorongduong * 40.0, 180 + Goc1, 0)
                Dim Pd1 As IPosition71 = CenterPoint(Pduoi1, Pduoi)
                Dim Pd2 As IPosition71 = CenterPoint(Pduoi2, P2)
                '///////////////
                Dim LiP1 As List(Of IPosition71) = ThreePoint(Pd1, 90 + FGoc(P1, P2), Dorongduong * 3)
                Dim LiP2 As List(Of IPosition71) = ThreePoint(Pd2, 90 + FGoc(P1, P2), Dorongduong * 3)
                Dim LiV1 As New List(Of IPosition71) From {Pduoi1, LiP1(2)}
                Dim LiV2 As New List(Of IPosition71) From {Pduoi, LiP1(1)}
                Dim LiV3 As New List(Of IPosition71) From {P2, LiP2(2)}
                Dim LiV4 As New List(Of IPosition71) From {Pduoi2, LiP2(1)}
                FDuongList(LiV1, 4294967295, "", 0, 0, mau, Rongnet, False, 2, 0, 2)
                FDuongList(LiV2, 4294967295, "", 0, 0, mau, Rongnet, False, 2, 0, 2)
                FDuongList(LiV3, 4294967295, "", 0, 0, mau, Rongnet, False, 2, 0, 2)
                FDuongList(LiV4, 4294967295, "", 0, 0, mau, Rongnet, False, 2, 0, 2)
                Dauchuthap(LiP1(0), FGoc(P1, P2), mau, 2)
                Dauchuthap(LiP2(0), FGoc(P1, P2), mau, 2)
                FlagHaiquan(P2)
                PointHQ = Pduoi.Move(Dorongduong * 25.0, 180 + Goc1, 0)
                GocHQ = 90 + (MkGoc(P1, P2) * 180 / Math.PI)
                TauHaiquan()
            End If
        ElseIf Lenhve = "khongquandanhbien" Or Lenhve = "danhhuongchuyeuHQ" Or Lenhve = "danhhuongthuyeuHQ" Then
            Mt1 = P2.Move(Dorongduong * 5.5, Goc1, 0)
            Mt2 = P2.Move(Dorongduong * 5.5, Goc2, 0)
            Dim liXanhDuoi As List(Of IPosition71) = P4Ngang(P2, P3, 0, Dorongduong * 70.0, Dorongduong * 8.0, Rongnet)
            Dim liXanhMt As List(Of IPosition71) = P4Ngang(P2, P3, 0, Dorongduong * 15.0, Dorongduong * 11.0, Rongnet)
            LiXanh = New List(Of IPosition71) From {liXanhDuoi(1), liXanhMt(2), liXanhMt(1), Mt2, liXanhMt(4), liXanhMt(3), liXanhDuoi(4), liXanhDuoi(1)}
            Dim liDoDuoi As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 100.0, Dorongduong * 21.0, Rongnet)
            Dim liDoMt1 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 25.0, Dorongduong * 9.0, Rongnet)
            Dim liDoMt2 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 27.0, Dorongduong * 11.0, Rongnet)
            LiDo = New List(Of IPosition71) From {liDoDuoi(1), liDoMt1(2), liDoMt2(1), Mt1, liDoMt2(4), liDoMt1(3), liDoDuoi(4)}
        ElseIf Lenhve = "HuongTCChuyeuKQchienthuat" Or Lenhve = "HuongTCThuyeuKQchienthuat" Then
            Dim Dodai As Double = FKc(P1, P2) / 2
            Dim Dodai1 As Double = Dodai + Dorongduong * 4
            Dim Dodai2 As Double = Dodai - Dorongduong * 4
            Dim liXD1, liXD2, liXD3 As List(Of IPosition71)
            If Lenhve = "HuongTCChuyeuKQchienthuat" Then
                liXD1 = P4Ngang(P1, P2, 0, 0, Dorongduong * 7.5, Rongnet)
                liXD3 = P4Ngang(P1, P2, 0, Dodai1, Dodai2 / FKc(P1, P2) * Dorongduong * 7.5, Rongnet)
                liXD2 = P4Ngang(P1, P2, 0, Dodai2, Dodai1 / FKc(P1, P2) * Dorongduong * 7.5, Rongnet)
                Dim liXMt1 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 18.0, Dorongduong * 4.5, Rongnet)
                Dim liXMt2 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 23.0, Dorongduong * 5.5, Rongnet)
                Dim LiXa1 As New List(Of IPosition71) From {liXD1(4), liXD2(4), liXD2(1), liXD1(1), liXD1(4)}
                Dim LiXa2 As New List(Of IPosition71) From {liXD3(4), liXMt1(2), liXMt2(1), P2, liXMt2(4), liXMt1(3), liXD3(1), liXD3(4)}
                FDuongList(LiXa1, 4294967295, "", 0, 0, mau3, Rongnet, False, 2, 0, 2)
                FDuongList(LiXa2, 4294967295, "", 0, 0, mau3, Rongnet, False, 2, 0, 2)
                Dim Ggeo1 As IGeometry = ListtoGeo(LiXa1).SpatialOperator.buffer(-Rongnet)
                Dim Ggeo2 As IGeometry = ListtoGeo(LiXa2).SpatialOperator.buffer(-Rongnet)
                FDuongList(GeoToList(Ggeo1), 4294967295, "", 0, 0, mau4, Rongnet, False, 2, 0, 1) ' 2, False, 2)
                FDuongList(GeoToList(Ggeo2), 4294967295, "", 0, 0, mau4, Rongnet, False, 2, 0, 1) ' 2, False, 2)
            Else
                liXD1 = P4Ngang(P1, P2, 0, 0, Dorongduong * 5.0, Rongnet)
                liXD3 = P4Ngang(P1, P2, 0, Dodai1, Dorongduong * 5.0, Rongnet)
                liXD2 = P4Ngang(P1, P2, 0, Dodai2, Dorongduong * 5.0, Rongnet)
                Dim liXMt1 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 18.0, Dorongduong * 5.0, Rongnet)
                Dim liXMt2 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 23.0, Dorongduong * 5.5, Rongnet)
                Dim LiXa1 As New List(Of IPosition71) From {liXD1(3), liXD2(3), liXD2(2), liXD1(2)}
                Dim LiXa2 As New List(Of IPosition71) From {liXD3(3), liXMt1(2), liXMt2(1), P2, liXMt2(4), liXMt1(3), liXD3(2)}

                Dim LiXdem1 As New List(Of IPosition71) From {liXD1(2), liXD2(2), liXD2(1), liXD1(1)}
                Dim LiXdem2 As New List(Of IPosition71) From {liXD3(2), liXMt1(3), liXMt2(4), liXD3(1)}
                FVungList(LiXa1, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXa2, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXdem1, 4294967295, 0, mau, 0, mau4, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXdem2, 4294967295, 0, mau, 0, mau4, 1, "", 0, 0, 0, False, 2, 2)

            End If

        ElseIf Lenhve = "tuyenPHkoLTnho" Or Lenhve = "tuyenPHkoLTlon" Or Lenhve = "tuyenPHLTnho" Or Lenhve = "tuyenPHLTLon" Then
            Dim Dodai As Double = FKc(P1, P2)
            Dim Dodai1 As Double = (2 / 3 * Dodai) + (Dorongduong * 10)
            Dim Dodai2 As Double = (2 / 3 * Dodai) - (Dorongduong * 10)
            Dim Dodai3 As Double = (1 / 3 * Dodai) + (Dorongduong * 10)
            Dim Dodai4 As Double = (1 / 3 * Dodai) - (Dorongduong * 10)
            Dim liXD3, liXD4, liXD5, liXD6 As New List(Of IPosition71)

            If Lenhve = "tuyenPHkoLTlon" Or Lenhve = "tuyenPHLTLon" Then
                Dim liXD1 As List(Of IPosition71) = P4Ngang(P1, P2, 0, 0, Dorongduong * 8.0, Rongnet)
                liXD3 = P4Ngang(P2, P1, 0, Dodai1, Dodai1 / FKc(P1, P2) * Dorongduong * 10.0, Rongnet)
                liXD4 = P4Ngang(P2, P1, 0, Dodai2, Dodai2 / FKc(P1, P2) * Dorongduong * 10.0, Rongnet)
                liXD5 = P4Ngang(P2, P1, 0, Dodai3, Dodai3 / FKc(P1, P2) * Dorongduong * 10.0, Rongnet)
                liXD6 = P4Ngang(P2, P1, 0, Dodai4, Dodai4 / FKc(P1, P2) * Dorongduong * 10.0, Rongnet)
                Dim liXMt1 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 18.0, Dorongduong * 4.5, Rongnet)
                Dim liXMt2 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 23.0, Dorongduong * 5.5, Rongnet)
                Dim LiXa1 As New List(Of IPosition71) From {liXD1(4), liXD3(1), liXD3(4), liXD1(1), liXD1(4)}
                Dim LiXa2 As New List(Of IPosition71) From {liXD4(1), liXD5(1), liXD5(4), liXD4(4), liXD4(1)}
                Dim LiXa3 As New List(Of IPosition71) From {liXD6(1), liXMt1(2), liXMt2(1), P2, liXMt2(4), liXMt1(3), liXD6(4), liXD6(1)}
                FDuongList(LiXa1, 4294967295, "", 0, 0, mau3, Rongnet, False, 2, 0, 2)
                FDuongList(LiXa2, 4294967295, "", 0, 0, mau3, Rongnet, False, 2, 0, 2)
                FDuongList(LiXa3, 4294967295, "", 0, 0, mau3, Rongnet, False, 2, 0, 2)
                Dim Ggeo1 As IGeometry = ListtoGeo(LiXa1).SpatialOperator.buffer(-Rongnet)
                Dim Ggeo2 As IGeometry = ListtoGeo(LiXa2).SpatialOperator.buffer(-Rongnet)
                Dim Ggeo3 As IGeometry = ListtoGeo(LiXa3).SpatialOperator.buffer(-Rongnet)
                FDuongList(GeoToList(Ggeo1), 4294967295, "", 0, 0, mau4, Rongnet, False, 2, 0, 1) ' 2, False, 2)
                FDuongList(GeoToList(Ggeo2), 4294967295, "", 0, 0, mau4, Rongnet, False, 2, 0, 1) ' 2, False, 2)
                FDuongList(GeoToList(Ggeo3), 4294967295, "", 0, 0, mau4, Rongnet, False, 2, 0, 1) ' 2, False, 2)
            ElseIf Lenhve = "tuyenPHkoLTnho" Or Lenhve = "tuyenPHLTnho" Then
                Dim liXD1 As List(Of IPosition71) = P4Ngang(P1, P2, 0, 0, Dorongduong * 5.0, Rongnet)
                liXD3 = P4Ngang(P2, P1, 0, Dodai1, Dorongduong * 5.0, Rongnet)
                liXD4 = P4Ngang(P2, P1, 0, Dodai2, Dorongduong * 5.0, Rongnet)
                liXD5 = P4Ngang(P2, P1, 0, Dodai3, Dorongduong * 5.0, Rongnet)
                liXD6 = P4Ngang(P2, P1, 0, Dodai4, Dorongduong * 5.0, Rongnet)
                Dim liXMt1 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 18.0, Dorongduong * 5.0, Rongnet)
                Dim liXMt2 As List(Of IPosition71) = P4Ngang(P2, P1, 0, Dorongduong * 23.0, Dorongduong * 5.5, Rongnet)

                Dim LiXa1 As New List(Of IPosition71) From {liXD1(3), liXD3(2), liXD3(3), liXD1(2)}
                Dim LiXa2 As New List(Of IPosition71) From {liXD4(2), liXD5(2), liXD5(3), liXD4(3)}
                Dim LiXa3 As New List(Of IPosition71) From {liXD6(2), liXMt1(2), liXMt2(1), P2, liXMt2(4), liXMt1(3), liXD6(3)}
                FVungList(LiXa1, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXa2, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXa3, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)

                Dim LiXdem1 As New List(Of IPosition71) From {liXD1(2), liXD3(3), liXD3(4), liXD1(1)}
                Dim LiXdem2 As New List(Of IPosition71) From {liXD4(3), liXD5(3), liXD5(4), liXD4(4)}
                Dim LiXdem3 As New List(Of IPosition71) From {liXD6(3), LiXa3(5), LiXa3(4), liXD6(4)}
                FVungList(LiXdem1, 4294967295, 0, mau, 0, mau4, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXdem2, 4294967295, 0, mau, 0, mau4, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiXdem3, 4294967295, 0, mau, 0, mau4, 1, "", 0, 0, 0, False, 2, 2)
            End If

            If Lenhve = "tuyenPHkoLTnho" Or Lenhve = "tuyenPHkoLTlon" Then
                Dim liCir1 As List(Of IPosition71) = Ns3Point(liXD3(0), liXD4(0))
                Dim liCir2 As List(Of IPosition71) = Ns3Point(liXD5(0), liXD6(0))
                MCircleTQ(liCir1(0), 250 * Tyle, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(liCir1(1), 250 * Tyle, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(liCir1(2), 250 * Tyle, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(liCir2(0), 250 * Tyle, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(liCir2(1), 250 * Tyle, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(liCir2(2), 250 * Tyle, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
            End If
        End If

        If Lenhve = "HQhanhquan" Or Lenhve = "HuongTCChuyeuKQchendich" Or Lenhve = "HuongTCThuyeuKQchendich" Or Lenhve = "khongquandanhbien" Or Lenhve = "danhhuongchuyeuHQ" Or Lenhve = "danhhuongthuyeuHQ" Then
            Dim Ggeo1 As IGeometry = ListtoGeo(LiXanh).SpatialOperator.buffer(-Rongnet)
            If Lenhve = "HQhanhquan" Then
                FDuongList(LiXanh, 4294967295, "", 0, 0, mau, Rongnet, False, 2, 0, 4) ' 2, False, 2)
                FDuongList(GeoToList(Ggeo1), 4294967295, "", 0, 0, mau2, Rongnet, False, 2, 0, 3) ' 2, False, 2)
            Else
                FDuongList(LiXanh, 4294967295, "", 0, 0, mau3, Rongnet, False, 2, 0, 4) ' 2, False, 2)
                FDuongList(GeoToList(Ggeo1), 4294967295, "", 0, 0, mau4, Rongnet, False, 2, 0, 3) ' 2, False, 2)
            End If

        End If

        If LiDo.Count > 0 Then
            Dim Ggeo2 As IGeometry = ListtoGeo(LiDo).SpatialOperator.buffer(-Rongnet)
            Dim liDoDuoi As List(Of IPosition71) = GeoToList(Ggeo2)
            liDoDuoi.RemoveRange(29, 1)
            FDuongList(LiDo, 4294967295, "", 0, 0, mau, Rongnet, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(liDoDuoi, 4294967295, "", 0, 0, mau2, Rongnet, False, 2, 0, 3) ' 2, False, 2)

            If Lenhve = "khongquandanhbien" Or Lenhve = "danhhuongchuyeuHQ" Or Lenhve = "danhhuongthuyeuHQ" Then
                Dim LiCr As List(Of IPosition71) = LiPCircle(P2, Dorongduong * 5, 0, 10)
                Dim LiCr2 As List(Of IPosition71) = LiPCircle(P2, Dorongduong * 10, 0, 10)
                Dim LiCr3 As List(Of IPosition71) = LiPCircle(P2, Dorongduong * 8.5, 0, 10)
                LiCr2.Add(LiCr2(0))
                LiCr3.Add(LiCr3(0))
                FDuongList(LiCr2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(LiCr3, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 0) ' 2, False, 2)
                Dim PdXanh As IPosition71 = CenterPoint(LiXanh(6), LiXanh(7))
                Dim PChu As IPosition71 = CenterPoint(LiXanh(3), PdXanh)


                If Lenhve = "danhhuongchuyeuHQ" Then
                    Dim Phq1 As IPosition71 = LiDo(3).Move(Dorongduong * 5.0, Goc1, 0)
                    Dim Phq2 As IPosition71 = LiDo(3).Move(Dorongduong * 22.0, Goc1, 0)
                    Dim LiMT1 As List(Of IPosition71) = Muiten(Phq1, Phq2, 180 + Goc1, 0.6, 3.0)
                    FVungList(LiMT1, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 3)
                ElseIf Lenhve = "khongquandanhbien" Then
                    Dim Pk As IPosition71 = Mt1.Move(Dorongduong * 55.0, Goc1, 0)
                    MB(Pk, (MkGoc(P2, P1) * 180.0 / Math.PI) - 180, 3.0)
                    MakeText(PChu, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, Goc2 + 90, FrmMain.Instance.TxtGhichuKH.Text, "", mau3Chu, 0, 0, 2, 2)
                End If

                If Lenhve = "khongquandanhbien" Or Lenhve = "danhhuongchuyeuHQ" Then
                    If Lenhve = "danhhuongchuyeuHQ" Then
                        FVungList(LiCr, 4294967295, Dorongduong * 1.5, mau, 1, mauTrang, 1, "", 0, 0, 0, False, 2, 2)
                    Else
                        FVungList(LiCr, 4294967295, Dorongduong * 1.5, mau, 1, mauTrang, 0, "", 0, 0, 0, False, 2, 2)
                    End If

                End If

                If Lenhve = "danhhuongchuyeuHQ" Or Lenhve = "danhhuongthuyeuHQ" Then
                    MakeText(PChu, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, Goc2 + 90, "ĐĐB Số 2", "", mau3Chu, 0, 0, 2, 2)
                    Dim LiX As New List(Of IPosition71) From {LiCr2(8), LiCr2(17), LiCr2(19), LiCr2(6), LiCr2(4), LiCr2(21), LiCr2(23), LiCr2(2), LiCr2(0), LiCr2(25), LiCr2(28), LiCr2(33)}
                    FDuongList(LiX, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.5, False, 2, 0, 0) ' 2, False, 2)
                    Dim Pt2 As IPosition71 = Mt1.Move(Dorongduong * 100.0, Goc1, 0)
                    GocHQ = 90 + (MkGoc(P1, P2) * 180 / Math.PI)
                    Dim LiTau As String = Trim(FrmMain.Instance.TxtGhichuKH.Text)
                    FrmMain.Instance.cbTauHQ.SelectedIndex = System.Convert.ToInt32(LiTau.Split(",")(0))
                    PointHQ = Mt1.Move(Dorongduong * 55.0, Goc1, 0)
                    TauHaiquan()
                    FrmMain.Instance.cbTauHQ.SelectedIndex = System.Convert.ToInt32(LiTau.Split(",")(1))
                    PointHQ = Mt1.Move(Dorongduong * 85.0, Goc1, 0)
                    TauHaiquan()
                Else
                    Dim LiX As New List(Of IPosition71) From {LiCr2(1), LiCr(1), LiCr(2), LiCr(3), LiCr(4), LiCr(5), LiCr(6), LiCr2(6), LiCr2(7), LiCr2(8), LiCr2(9), LiCr2(10), LiCr2(11), LiCr(11), LiCr(12), LiCr(13), LiCr(14), LiCr(15), LiCr(16), LiCr2(16), LiCr2(17), LiCr2(18), LiCr2(19), LiCr2(20), LiCr2(21),
                    LiCr(21), LiCr(22), LiCr(23), LiCr(24), LiCr(25), LiCr(26), LiCr2(26), LiCr2(27), LiCr2(28), LiCr2(29), LiCr2(30), LiCr2(31), LiCr(31)}
                    FDuongList(LiX, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 0) ' 2, False, 2)
                End If
            End If
        End If

        SLenhve3DMs()
    End Sub

    Private Sub FlagHaiquan(P As IPosition71)
        Select Case FrmMain.Instance.cbKHbiendoitauhanhquan.SelectedIndex
            Case 1 'Su doan
                loaiKH = "100004"   'su doan, vung hai quan
                If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 Or FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                    textKH = FrmMain.Instance.TxtTenKH.Text & "    "
                Else
                    textKH = "    " & FrmMain.Instance.TxtTenKH.Text
                End If
                If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 And FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                    textKH = "    " & FrmMain.Instance.TxtTenKH.Text
                End If
            Case 2 'lu doan
                loaiKH = "100005"  'lu doan
                If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 Or FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                    textKH = FrmMain.Instance.TxtTenKH.Text
                Else
                    textKH = "   " & FrmMain.Instance.TxtTenKH.Text
                End If
                If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 And FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                    textKH = "   " & FrmMain.Instance.TxtTenKH.Text
                End If
            Case 3 'Trung doan
                loaiKH = "100006"   'trung doam
                textKH = FrmMain.Instance.TxtTenKH.Text
            Case 4 'Tieu doan
                loaiKH = "100007"   'tieu doan
                If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 Or FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                    textKH = FrmMain.Instance.TxtTenKH.Text & "       "
                Else
                    textKH = "       " & FrmMain.Instance.TxtTenKH.Text
                End If
                If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 And FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                    textKH = "       " & FrmMain.Instance.TxtTenKH.Text
                End If
        End Select

        If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
            FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom,left"
            If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 Then
                FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom,Right"
            Else
                FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom,left"
            End If
        Else
            FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom,Right"
            If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 Then
                FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom,left"
            Else
                FrmMain.Instance.fLabelStyleMain.PivotAlignment = "Bottom,Right"
            End If
        End If
        FrmMain.Instance.fLabelStyleMain.Bold = False
        FrmMain.Instance.fLabelStyleMain.TextAlignment = "center,center"
        FrmMain.Instance.fLabelStyleMain.Scale = FrmMain.Instance.fLabelStyleMain.Scale
        'FrmMain.Instance.textKH = "    " & txtBobinh.Text
        If Bd3D = False Then
            If mauKT = True Then
                fileImage = PathData & "\2X\" & "P" & ChieuKH & loaiKH & Ta_Doiphuong & tenGiaidoan
            Else
                fileImage = PathData & "\2X\" & ChieuKH & loaiKH & Ta_Doiphuong & tenGiaidoan
            End If
        Else
            If mauKT = True Then
                fileImage = PathData & "\2XD2\" & "P" & ChieuKH & "2" & loaiKH & Ta_Doiphuong & tenGiaidoan
            Else
                fileImage = PathData & "\2XD2\" & ChieuKH & "2" & loaiKH & Ta_Doiphuong & tenGiaidoan
            End If
        End If
        Dim Doituong = FrmMain.Instance.sgworldMain.Creator.CreateLabel(P, textKH, fileImage, FrmMain.Instance.fLabelStyleMain, GroupBac2Main, Trim(tenKH))
        Doituong.Tooltip.Text = mota
        Doituong.Position.Altitude = -0.25 * FrmMain.Instance.fLabelStyleMain.Scale
        Doituong.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
        FrmMain.Instance.fLabelStyleMain.Scale = FrmMain.Instance.fLabelStyleMain.Scale
        mLabelArray.Add(Doituong)
    End Sub

    Function P4Ngang(P2 As IPosition71, P1 As IPosition71, G1 As Double, Kc As Double, Kc1 As Double, Rongnet As Double) As List(Of IPosition71)
        Dim Dx As Double
        If Lenhve = "HuongTCChuyeuKQchendich" Then
            Dx = 1.0
        Else
            Dx = 2.0
        End If
        Dim KP As IPosition71 = P2.Move(Kc, G1 + FGoc(P1, P2), 0)
        Dim K1 As IPosition71 = KP.Move(Kc1, 90 + FGoc(P1, P2), 0)
        Dim K2 As IPosition71 = KP.Move(Kc1 - Rongnet * Dx, 90 + FGoc(P1, P2), 0)
        Dim K3 As IPosition71 = KP.Move(Kc1 - Rongnet * Dx, 270 + FGoc(P1, P2), 0)
        Dim K4 As IPosition71 = KP.Move(Kc1, 270 + FGoc(P1, P2), 0)
        Dim liN As New List(Of IPosition71) From {KP, K1, K2, K3, K4}

        'For i As Integer = 0 To liN.Count - 1
        '    FrmMain.Instance.sgworldMain.Creator.CreateLabel(liN(i), i.ToString, "", Nothing, "", i.ToString)
        'Next

        P4Ngang = liN
    End Function

    Function Ns3Point(p1 As IPosition71, P2 As IPosition71) As List(Of IPosition71)
        Dim K1 As IPosition71 = CenterPoint(p1, P2)
        Dim K2 As IPosition71 = CenterPoint(K1, P2)
        Dim K3 As IPosition71 = CenterPoint(p1, K1)
        Dim LiN As New List(Of IPosition71) From {K1, K2, K3, p1, P2}
        Ns3Point = LiN
        For i As Integer = 0 To LiN.Count - 1
            FrmMain.Instance.sgworldMain.Creator.CreateLabel(LiN(i), i.ToString, "", Nothing, "", i.ToString)
        Next
    End Function

    Function PDuoi(P1 As IPosition71, Goc As Double, Kc As Double) As List(Of IPosition71)
        Dim Ps1 As IPosition71 = P1.Move(Kc, 90 + Goc, 0)
        Dim Ps2 As IPosition71 = P1.Move(Dorongduong / 1000, 90 + Goc, 0)
        Dim Ps3 As IPosition71 = P1.Move(Dorongduong / 1000, 270 + Goc, 0)
        Dim Ps4 As IPosition71 = P1.Move(Kc, 270 + Goc, 0)
        Dim LiC As New List(Of IPosition71) From {Ps1, Ps2, Ps3, Ps4}
        PDuoi = LiC
        'For i As Integer = 0 To LiC.Count - 1
        '    FrmMain.Instance.sgworldMain.Creator.CreateLabel(LiC(i), i.ToString, "", Nothing, "", i.ToString)
        'Next
    End Function

    Public Sub KhuvucGiaochien()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai =  FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim Pc As IPosition71 = CenterPoint(P1, P2)
        Dim P1t As IPosition71 = P1.Move(Dorongduong * 35, FGoc(P1, P2), 0)
        Dim P1c As IPosition71 = P1.Move(Dorongduong * 4, FGoc(P1, P2), 0)
        Dim P2t As IPosition71 = P2.Move(Dorongduong * 35, 180 + FGoc(P1, P2), 0)
        Dim P2c As IPosition71 = P2.Move(Dorongduong * 4, 180 + FGoc(P1, P2), 0)
        ''////////////
        Dim LiMT1 As List(Of IPosition71) = Muiten(P1, P1t, FGoc(P2, P1), 0.8, 1.0)
        Dim LiMT2 As List(Of IPosition71) = Muiten(P2, P2t, FGoc(P1, P2), 0.8, 1.0)
        FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
        FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 1)
        DemMTk(LiMT1, mau2, 1.5)
        DemMTk(LiMT2, mau4, 1.5)
        Ns5Point(2, Pc, P1c, P2c, Dorongduong * 5)
        mau = mau3
        mau2 = mau4
        Ns5Point(2, Pc, P2c, P1c, Dorongduong * 5)
        SLenhve3DMs()
    End Sub

    Public Sub KhuvucTrucban()
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 0 Then
            MsgBox("Hãy chọn loại máy bay!....")
            Exit Sub
        Else
            Dim k(50) As IPosition71
            Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
            Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
            Dim Pt3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0) 'Diem giua
            Dim chieucao As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y)
            Dim chieurong As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P2.X, P2.Y, Pt3.X, Pt3.Y)
            Dim Pc12 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P1.X + P2.X), 0.5 * (P1.Y + P2.Y), 0, 2, 0, 0, 0, 0) 'Diem giua

            Dim Goc1 As Double = FGoc(P1, P2)
            Dim Goc2 As Double = Goc1 + 180
            Dim P3 As IPosition71 = P2.Move(chieurong, 270 + Goc1, 0)
            Dim P4 As IPosition71 = P1.Move(chieurong, 270 + Goc1, 0)
            Dim Bk As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y) / 25
            For i As Integer = 1 To 10
                k(i) = P1.Move(Bk, 60.0 + (i * 30) + Goc2, 0)
            Next
            For i As Integer = 11 To 20
                k(i) = P2.Move(Bk, 180 - (11 - i) * 30 + Goc2, 0)
            Next
            For i As Integer = 21 To 30
                k(i) = P3.Move(Bk, 270 - (21 - i) * 30 + Goc2, 0)
            Next
            For i As Integer = 31 To 40
                k(i) = P4.Move(Bk, 0 - (31 - i) * 30 + Goc2, 0)
            Next
            Dim liP As New List(Of IPosition71)
            For i As Integer = 1 To 40
                liP.Add(k(i))
            Next
            Dim Geo As IGeometry = ListtoGeo(liP).SpatialOperator.buffer(-2 * Dorongduong)
            FVungList(liP, 4294967295, Dorongduong * 2, mau, 1, mau, 0, "", 1, 1, 0, False, 2, 2)
            FVungList(GeoToList(Geo), 4294967295, Dorongduong * 2, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
            Dim Pm1 As IPosition71 = Pc12.Move(Dorongduong * 35, FGoc(P1, P2) + 270, 0)
            Dim Pm2 As IPosition71 = Pc12.Move(chieurong - Dorongduong * 35, FGoc(P1, P2) + 270, 0)
            KvMBTuantieu(Pm1, Pm2)
            SLenhve3DMs()
        End If
    End Sub

#Region "    Khu vuc may bay hoat dong"

    Public Sub KvMB()
        Dim p1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim p2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai
        KvMBTuantieu(p1, p2)
        SLenhve3DMs()
    End Sub

    Public Function DMuiten(P1 As IPosition71, P2 As IPosition71, Goc As Double, Drong As Double, d As Double) As List(Of IPosition71)
        Dim Pc As IPosition71 = CenterPoint(P1, P2)
        Dim Goc2 As Double = Goc + 270 ' 270 + MkGoc(liP1(0), liP1(42))
        Dim mt1 As IPosition71 = Pc.Move(Drong * 2, 110 - Goc2, 0)
        Dim Mt2 As IPosition71 = Pc.Move(d + Drong * 7, -10 - Goc2, 0)
        Dim Mt3 As IPosition71 = Pc.Move(Drong * 2, 230 - Goc2, 0)
        Dim liP12 As New List(Of IPosition71) From {P2, mt1, Mt2, Mt3, P1}
        DMuiten = liP12
    End Function

    Public Sub MB(P1 As IPosition71, Goc As Double, hesoTyle As Double)
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 1 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 2 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 7 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 8 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 21 Then
            Dim TQ As New List(Of Double)({346.76, 87.52, 346.76, 92.48, 168.14, 264.88, 154.86, 253.51, 366.44, 270, 154.86, 286.49, 168.14, 275.12})
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            Dim TQDem As New List(Of Double)({154.86, 286.49, 168.14, 275.12, 346.76, 87.52, 349.22, 82.77})
            FVungPoint(ArrayPoint(TQDem, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        End If
        'Canh ngang
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 1 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 2 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 7 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 8 Then
            Dim TQcanh As New List(Of Double)({214.16, 323.98, 198.01, 331.02, 198.01, 208.98, 214.16, 216.02})
            FVungPoint(ArrayPoint(TQcanh, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 8 Then
                Dim TQ As New List(Of Double)({15.52, 42.14, 90.6, 6.6, 247.37, 68.66, 247.37, 111.34, 90.6, 173.4, 15.89, 139.05, 42.16, 106.54, 72.34, 146.04, 209.2, 106.67, 209.2, 73.33, 72.34, 33.96, 42.02, 74.1})
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            End If
        End If
        'Duoi ngang
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 1 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 7 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 8 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 9 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 10 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 11 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 12 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 13 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 14 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 15 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 16 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 Then
            Dim TQDuoi As New List(Of Double)({328.13, 74.66, 357.15, 75.93, 357.15, 104.07, 328.13, 105.34})
            FVungPoint(ArrayPoint(TQDuoi, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        'Van tai
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 19 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 23 Then 'Van tai
            Dim TQDuoi As New List(Of Double)({316.8, 87.29, 319.62, 81.91, 408.92, 83.68, 408.92, 96.32, 319.62, 98.09, 316.8, 92.71, 376.74, 92.28, 376.74, 87.72})
            FVungPoint(ArrayPoint(TQDuoi, P1, hesoTyle, Goc), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        'Hinh tron
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 2 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 6 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 17 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 18 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 22 Then
            Dim P As IPosition71 = P1.Move(190.0 * hesoTyle, 90 - Goc, 0)
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 3 Then
                MCircleTQ(P, 300 * Tyle, 4294967295, Dorongduong * 2.0, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
            Else
                MCircleTQ(P, 300 * Tyle, 4294967295, Dorongduong * 2.0, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            End If
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 18 Then
                Dim Pb As IPosition71 = P1.Move(-130.0 * hesoTyle, 90 - Goc, 0)
                MCircleTQ(Pb, 300 * Tyle, 4294967295, Dorongduong * 2.0, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 22 Then
                Dim Pb As IPosition71 = P1.Move(-180.0 * hesoTyle, 90 - Goc, 0)
                MCircleTQ(Pb, 300 * Tyle, 4294967295, Dorongduong * 2.0, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            End If

        End If
        'Truc thang
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 20 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 21 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 22 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 23 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 Then
            Dim Pa As IPosition71
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 21 Then
                Pa = P1.Move(-40.0 * hesoTyle, 90 - Goc, 0)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 Then
                Pa = P1.Move(-125.0 * hesoTyle, 90 - Goc, 0)
            Else
                Pa = P1.Move(-135.0 * hesoTyle, 90 - Goc, 0)
            End If
            CQTructhang(Pa, Goc, hesoTyle)

        End If
        'Hai vach ngan
        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 6 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 11 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 12 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 13 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 14 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 15 Or
           FrmMain.Instance.cbLoaiMB.SelectedIndex = 16 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 17 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 18 Then
            Dim TQDem As New List(Of Double)({177.77, 265.16, 316.79, 92.71, 316.79, 87.29, 177.77, 274.84, 182.51, 283.94, 319.48, 82.09})
            FVungPoint(ArrayPoint(TQDem, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQDem, P1, hesoTyle, Goc), 2, 5, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        End If

        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 9 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 10 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 11 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 12 Then
            Dim TQ As New List(Of Double)({374.87, 292.46, 347.4, 294.35, 347.4, 245.65, 374.87, 247.54, 320.25, 296.57, 293.72, 299.18, 293.72, 240.82, 320.25, 243.43, 267.93, 302.31, 243.1, 306.1, 243.1, 233.9, 267.93, 237.67, 346.76, 92.48, 197.01, 265.63, 197.01, 274.37, 346.76, 87.52, 319.48, 82.09, 201.3, 282.62})
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 9 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                Dim TQ1 As New List(Of Double)({346.76, 92.48, 138.28, 263.77, 126.38, 249.64, 316.44, 270, 126.38, 290.36, 138.28, 276.23, 346.76, 87.52, 349.22, 82.77, 126.38, 290.36})
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 5, 8, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 10 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                Dim TQ1 As New List(Of Double)({347.76, 92.48, 78.91, 259.04, 73.17, 233.07, 256.44, 270, 73.17, 306.93, 78.91, 280.96, 346.6, 87.52, 349.22, 82.77, 73.17, 306.93})
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 5, 8, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 5 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 11 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 12 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 8, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 12, 15, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 14, 17, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
                If FrmMain.Instance.cbLoaiMB.SelectedIndex = 11 Then
                    Dim TQ2 As New List(Of Double)({236.78, 236.06, 215.38, 245.79, 191.62, 250.76, 173.36, 259.24, 166.72, 270, 173.36, 280.76, 191.62, 289.24, 215.38, 294.21, 236.78, 303.94, 205.74, 302.14, 171.43, 296.34, 146.15, 285.47, 136.53, 270, 146.15, 254.53, 171.43, 243.66, 205.74, 239.04})
                    FVungPoint(ArrayPoint(TQ2, P1, hesoTyle, Goc), 0, 15, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)

                ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 12 Then
                    Dim TQ2 As New List(Of Double)({215.37, 86.01, 211.66, 83.3, 210.95, 80.39, 213.3, 77.55, 218.5, 75.05, 226.06, 73.08, 235.36, 71.74, 245.72, 71.06, 256.47, 70.99, 267, 71.47, 271.88, 71.95, 279.72, 73.35, 346.76, 87.52, 299.86, 87.13, 257.79, 77.8, 255.49, 77.75, 248.56, 78.19, 243.33, 79.33, 241.08, 80.94, 242.39, 82.62, 248.73, 84.91, 255.66, 86.64})
                    FVungPoint(ArrayPoint(TQ2, P1, hesoTyle, Goc), 0, 15, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)
                End If
            End If
        End If

        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 4 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 13 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 14 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 19 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 20 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 22 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 23 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 Then 'Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 Then '
            Dim TQ As New List(Of Double)({374.87, 292.46, 347.4, 294.35, 347.4, 245.65, 374.87, 247.54, 320.25, 296.57, 293.72, 299.18, 293.72, 240.82, 320.25, 243.43, 346.76, 92.48, 256.88, 266.65, 256.88, 273.35, 346.76, 87.52, 319.48, 82.09, 260.18, 279.3})
            If Not FrmMain.Instance.cbLoaiMB.SelectedIndex = 23 And Not FrmMain.Instance.cbLoaiMB.SelectedIndex = 22 And Not FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 And Not FrmMain.Instance.cbLoaiMB.SelectedIndex = 20 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            End If
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 8, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 10, 13, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 3 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 14 Then
                Dim TQ1 As New List(Of Double)({188.76, 293.41, 188.76, 66.59, 178.97, 75.44, 178.97, 284.56, 188.76, 113.41, 188.76, 246.59, 178.97, 255.44, 178.97, 104.56, 164.1, 270, 232.2, 251.87, 220.96, 242.75, 243.1, 233.9, 266.25, 254.4, 196.44, 270, 266.25, 285.6, 243.1, 306.1, 220.96, 297.25, 232.51, 287.94})
                If FrmMain.Instance.cbLoaiMB.SelectedIndex = 14 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 19 Then
                    FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                    FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                Else
                    FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 8, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                End If
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 13 Then
                Dim TQ2 As New List(Of Double)({48.76, 72.08, 44.68, 23.72, 80.31, 36.5, 84.85, 22.62, 72.76, 25.23, 117.39, 3.2, 113.36, 32.14, 105.43, 27.76, 103.89, 51.96, 65.47, 51.87, 80.79, 79.3, 110.52, 82.2, 90.81, 63.23, 128.3, 59.79, 123.69, 50.71, 115.79, 55.87, 136.35, 30.73, 156.35, 52.12, 145.93, 50.26, 158.44, 66.17, 121.52, 70.57, 143.28, 83.99})
                FVungPoint(ArrayPoint(TQ2, P1, hesoTyle, Goc), 0, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ2, P1, hesoTyle, Goc), 11, 21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 24 Then
                Dim TQ2 As New List(Of Double)({272.14, 270, 326.67, 266.33, 319.81, 267.97, 382.18, 268.23, 358.21, 274.14, 407.08, 273.59, 385.05, 277.14, 312.38, 278.92, 338.31, 271.81, 317.86, 271.95, 327.47, 273.6})
                FVungPoint(ArrayPoint(TQ2, P1, hesoTyle, Goc), 0, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            End If
        End If

        If FrmMain.Instance.cbLoaiMB.SelectedIndex = 6 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 15 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 16 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 17 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 18 Then        'MB nem bom chien luoc
            Dim TQ As New List(Of Double)({293.72, 240.82, 293.72, 299.18, 267.93, 302.31, 267.93, 237.69, 243.1, 233.9, 243.1, 306.1, 219.58, 310.71, 219.58, 229.29, 197.81, 223.61, 197.81, 316.39, 178.44, 323.38, 178.44, 216.62, 129.87, 228.17, 280.61, 252.02, 280.93, 248.8, 353.76, 258.32, 265.19, 260.97, 272.84, 258.03, 112.12, 239.68, 112.12, 300.32, 272.84, 281.97, 265.19, 279.03, 353.76, 281.68, 280.93, 291.2, 280.61, 287.98, 129.87, 311.83, 278.46, 247.06, 311.49, 254.12, 299.87, 254.04, 307.06, 257.34, 326.66, 249.45, 351.66, 260.12, 347.52, 265.48, 325.64, 258.74, 311.12, 266.34, 283.81, 256.56, 276.41, 258.88, 82, 224.39, 289.35, 281.21, 289.92, 277.76, 361.95, 286.83, 275.71, 290.35, 282.72, 287.07, 54.15, 233.99, 346.76, 92.48, 48.8, 252.1, 48.8, 287.9, 346.76, 87.52, 349.35, 82.6, 64.66, 314.1})
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 15 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 17 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 18 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 8, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            Else
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 8, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            End If
            ' Dim TQ1 As New List(Of Double)({177.49, 263.67, 200.86, 257.96, 302.64, 279.45, 308.16, 276.34, 364.33, 288.03, 276.08, 287.15, 287.66, 284.49, 346.76, 92.48, 226.93, 266.21, 226.93, 273.79, 346.76, 87.52, 349.35, 82.6, 230.87, 281.24})

            Dim TQ1 As New List(Of Double)({177.49, 263.67, 200.86, 257.96, 302.64, 279.45, 308.16, 276.34, 364.33, 288.03, 276.08, 287.15, 287.66, 284.49, 346.76, 92.48, 226.93, 266.21, 226.93, 273.79, 346.76, 87.52, 349.35, 82.6, 230.87, 281.24, 199.89, 270, 303.54, 253.41, 293.77, 261.34, 242.32, 270, 293.77, 279.98, 303.54, 287.91})
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 6 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 16 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 18 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 17 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 44, 47, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 46, 49, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            Else
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 7, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 9, 12, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            End If
            If FrmMain.Instance.cbLoaiMB.SelectedIndex = 6 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 12, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 19, 25, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 15 Or FrmMain.Instance.cbLoaiMB.SelectedIndex = 16 Then
                FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 26, 36, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                If FrmMain.Instance.cbLoaiMB.SelectedIndex = 16 Then
                    FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc), 37, 43, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 15 Then
                    FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                End If
            ElseIf FrmMain.Instance.cbLoaiMB.SelectedIndex = 17 Then
                FVungPoint(ArrayPoint(TQ1, P1, hesoTyle, Goc), 13, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            End If
        End If

    End Sub

    Private Sub CQTructhang(P1a As IPosition71, Goc As Double, hesoTyle As Double)
        Dim TQcQ As New List(Of Double)({17.87, 270, 173.87, 322.12, 173.87, 332.02, 27.59, 0, 173.87, 27.98, 173.87, 37.88, 17.87, 90, 173.87, 142.12, 173.87, 152.02, 27.59, 180, 173.87, 207.98, 173.87, 217.88})
        FVungPoint(ArrayPoint(TQcQ, P1a, hesoTyle, Goc), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Public Sub KvMBTuantieu(p1 As IPosition71, p2 As IPosition71)
        Dim Pc As IPosition71 = CenterPoint(p1, p2)
        Dim Kc As Double = FKc(p1, p2)
        Dim BK As Double, Drong As Double, Khoanglui As Double

        If Lenhve = "maybayhoatdong" Or Lenhve = "kvtrucban" Then
            Drong = Dorongduong * 2.5
            BK = FKc(p1, p2) / 9
            Khoanglui = Dorongduong * 40
        ElseIf Lenhve = "maybaychivien" Or Lenhve = "KvhoatdongMBTcdt" Then
            Drong = Dorongduong * 2.5
            BK = Val(FrmMain.Instance.TxtGhichuKH.Text) / 2
            Khoanglui = Dorongduong * 70
        ElseIf Lenhve = "KvNhieutieucuc" Then
            Drong = Dorongduong * 2.0
            BK = Val(FrmMain.Instance.TxtGhichuKH.Text) / 2
            Khoanglui = 0
        ElseIf Lenhve = "toanTSsucsao" Then
            Drong = Dorongduong * 1.2
            BK = FKc(p1, p2) / 13
            Khoanglui = Dorongduong * 6
        ElseIf Lenhve = "tauBPtuantra" Then
            Drong = Dorongduong * 1.2
            BK = FKc(p1, p2) / 13
            Khoanglui = Dorongduong * 12
        Else
            Drong = Dorongduong * 1.2
            BK = FKc(p1, p2) / 13
            Khoanglui = BK
        End If

        Dim Pc1 As IPosition71 = p1.Move(BK, FGoc(p1, p2) + 180, 0)
        Dim Pc2 As IPosition71 = p2.Move(BK, FGoc(p1, p2), 0)
        Dim LiP1 As List(Of IPosition71) = PointOnCircle(Pc1, BK, 35 + MkGoc(p1, p2) * 180.0 / Math.PI)
        Dim LiP2 As List(Of IPosition71) = PointOnCircle(Pc2, BK, 205 + MkGoc(p1, p2) * 180.0 / Math.PI)
        Dim LiP3 As List(Of IPosition71) = PointOnCircle(Pc1, BK - Drong, 35 + MkGoc(p1, p2) * 180.0 / Math.PI)
        Dim LiP4 As List(Of IPosition71) = PointOnCircle(Pc2, BK - Drong, 205 + MkGoc(p1, p2) * 180.0 / Math.PI)
        Dim LiP5 As List(Of IPosition71) = PointOnCircle(Pc1, BK - Drong * 1.8, 35 + MkGoc(p1, p2) * 180.0 / Math.PI)
        Dim LiP6 As List(Of IPosition71) = PointOnCircle(Pc2, BK - Drong * 1.8, 205 + MkGoc(p1, p2) * 180.0 / Math.PI)

        If Lenhve = "maybaychivien" Or Lenhve = "KvhoatdongMBTcdt" Or Lenhve = "KvNhieutieucuc" Then
            LiP1.RemoveRange(0, 4)
            LiP3.RemoveRange(0, 4)
            LiP5.RemoveRange(0, 4)
            LiP1.RemoveRange(18, 1)
            LiP3.RemoveRange(18, 1)
            LiP5.RemoveRange(18, 1)

            LiP2.RemoveRange(0, 2)
            LiP4.RemoveRange(0, 2)
            LiP6.RemoveRange(0, 2)
            LiP2.RemoveRange(19, 2)
            LiP4.RemoveRange(19, 2)
            LiP6.RemoveRange(19, 2)

            Dim LiP1a As List(Of IPosition71) = CpointMBchivien(LiP1(0), LiP2(18), Khoanglui)
            Dim LiP3a As List(Of IPosition71) = CpointMBchivien(LiP3(0), LiP4(18), Khoanglui)
            Dim LiP4a As List(Of IPosition71) = CpointMBchivien(LiP5(0), LiP6(18), Khoanglui)

            Dim LiP1b As List(Of IPosition71) = CpointMBchivien(LiP1(17), LiP2(0), Khoanglui)
            Dim LiP3b As List(Of IPosition71) = CpointMBchivien(LiP3(17), LiP4(0), Khoanglui)
            Dim LiP4b As List(Of IPosition71) = CpointMBchivien(LiP5(17), LiP6(0), Khoanglui)

            LiP1.Add(LiP1b(1))
            LiP1.Reverse()
            LiP1.Add(LiP1a(1))
            LiP3.Add(LiP3b(1))
            LiP3.Reverse()
            LiP3.Add(LiP3a(1))
            LiP5.Add(LiP4b(1))
            LiP5.Reverse()
            LiP5.Add(LiP4a(1))

            LiP2.Add(LiP1a(0))
            LiP2.Reverse()
            LiP2.Add(LiP1b(0))

            LiP4.Add(LiP3a(0))
            LiP4.Reverse()
            LiP4.Add(LiP3b(0))

            LiP6.Add(LiP4a(0))
            LiP6.Reverse()
            LiP6.Add(LiP4b(0))
            LiP3.Reverse()
            If Lenhve = "KvNhieutieucuc" Then
                LiP2.RemoveRange(20, 1)
                UniCruve(LiP1, LiP2)
                LiP1.Add(LiP1(0))
                LiP4.RemoveRange(20, 1)
                LiP4.Reverse()
                UniCruve(LiP3, LiP4)
                LiP3.Add(LiP3(0))
                FDuongList(LiP1, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 2)
                FDuongList(LiP3, 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 2)

                Dim Kcs As Double = FKc(LiP3(22), LiP3(37))
                Dim Psc As IPosition71 = CenterPoint(LiP3(1), LiP3(21))
                Dim Psc1 As IPosition71 = LiP3(22).Move(1 / 4 * Kcs, 270 + FGoc(p1, p2), 0)
                Dim Psc2 As IPosition71 = LiP3(22).Move(3 / 4 * Kcs, 270 + FGoc(p1, p2), 0)
                Dim Psc3 As IPosition71 = LiP3(17).Move(1 / 4 * Kcs, 270 + FGoc(p1, p2), 0)
                Dim Psc4 As IPosition71 = LiP3(17).Move(3 / 4 * Kcs, 270 + FGoc(p1, p2), 0)
                Dauchuthap(Psc, 45 + FGoc(p1, p2), mau, 2.5)
                Dauchuthap(Psc1, 45 + FGoc(p1, p2), mau, 2.5)
                Dauchuthap(Psc2, 45 + FGoc(p1, p2), mau, 2.5)
                Dauchuthap(Psc3, 45 + FGoc(p1, p2), mau, 2.5)
                Dauchuthap(Psc4, 45 + FGoc(p1, p2), mau, 2.5)
            Else
                UniCruve(LiP1, LiP3)
                UniCruve(LiP5, LiP3)
                LiP4.Reverse()
                UniCruve(LiP2, LiP4)
                UniCruve(LiP6, LiP4)
                FVungList(LiP1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(LiP5, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(LiP2, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(LiP6, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2)
            End If

            If Not Lenhve = "KvNhieutieucuc" Then
                MB(LiP3a(2), (MkGoc(LiP3a(0), LiP3a(1)) * 180.0 / Math.PI) - 180, 4.0)
                MB(LiP3b(2), (MkGoc(LiP3a(0), LiP3a(1)) * 180.0 / Math.PI), 4.0)
            End If
        Else
            LiP1.RemoveRange(0, 2)
            LiP3.RemoveRange(0, 2)
            LiP5.RemoveRange(0, 2)
            LiP2.RemoveRange(0, 1)
            LiP4.RemoveRange(0, 1)
            LiP6.RemoveRange(0, 1)
            Dim PK1 As IPosition71 = CenterPoint(LiP1(0), LiP4(0))
            Dim PK2 As IPosition71 = CenterPoint(LiP3(0), LiP2(0))
            '////////////////////////////
            If Lenhve = "toTSsucsao" Or Lenhve = "tuantraBP" Or Lenhve = "toTSDPsucsao" Or Lenhve = "DDgCoDichmatdat" Or Lenhve = "trinhsatKGM" Then
                If Lenhve = "DDgCoDichmatdat" Then
                    MCircleTQ(Pc, BK * 2, 4294967295, Dorongduong * 1.2, mau3, 1, mau3, 0, "", 0, 0, 0, False, 2, 2)
                ElseIf Lenhve = "trinhsatKGM" Then
                    MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(p1, p2), "tsM", "", mauChu, 1, 0, 0, 2)
                    MCircleTQ(Pc, BK * 2, 4294967295, Dorongduong * 1.2, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                    MCircleTQ(Pc, 2 * BK - (Dorongduong * 2), 4294967295, Dorongduong * 1.2, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 1)
                Else
                    MCircleTQ(Pc, BK * 2, 4294967295, Dorongduong * 1.2, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                    MCircleTQ(Pc, 2 * BK - (Dorongduong * 2), 4294967295, Dorongduong * 1.2, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 1)
                End If

            ElseIf Lenhve = "maybayhoatdong" Or Lenhve = "kvtrucban" Then
                MB(Pc, (MkGoc(LiP1(0), LiP4(0)) * 180.0 / Math.PI) - 180, 4.0)
            ElseIf Lenhve = "toanTSsucsao" Then
                Dim Pts As IPosition71 = Pc.Move(Dorongduong * 6, FGoc(LiP1(0), LiP4(0)) + 180, 0)
                Dim TQ As New List(Of Double)({9.55, 0.0, 103.7, 0.0, 109.56, 15.89, 124.99, 35.22, 148.71, 52.05, 176.51, 65.23, 206.23, 75.96, 236.59, 85.08, 253.54, 90.0, 236.59, 94.92, 206.23, 104.04, 176.51, 114.77, 148.71, 127.95, 124.99, 144.78, 109.56, 164.11, 103.7, 180.0, 9.35, 0.0, 31.42, 72.69, 81.04, 158.27, 98.94, 137.02, 125.02, 120.14, 154.17, 107.76, 181.08, 98.81, 200.37, 93.14, 213.21, 90.0, 198.33, 86.31, 184.41, 82.04, 154.17, 72.24, 125.02, 59.86, 98.94, 42.98, 81.04, 21.73, 31.48, 72.34})
                Dim liT1 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, Pts, 3.0, MkGoc(LiP1(0), LiP4(0)) * 180.0 / Math.PI)
                Dim TQ1 As New List(Of Double)({31.42, 72.69, 81.04, 158.27, 98.94, 137.02, 125.02, 120.14, 154.17, 107.76, 181.08, 98.81, 200.37, 93.14, 213.21, 90.0, 198.33, 86.31, 184.41, 82.04, 154.17, 72.24, 125.02, 59.86, 98.94, 42.98, 81.04, 21.73, 31.48, 72.34, 55.82, 80.15, 73.18, 48.73, 79.44, 53.18, 107.75, 68.84, 137.82, 79.71, 168.17, 88.27, 174.2, 90.0, 168.17, 91.73, 137.82, 100.29, 107.75, 111.16, 79.44, 126.82, 73.18, 131.27, 55.79, 80.35})
                Dim liT2 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ1, Pts, 3.0, MkGoc(LiP1(0), LiP4(0)) * 180.0 / Math.PI)
                FVungList(liT1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(liT2, 4294967295, 0, mau, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            ElseIf Lenhve = "tauBPtuantra" Then
                Dim Pts As IPosition71 = Pc.Move(Dorongduong * 12, FGoc(LiP1(0), LiP4(0)) + 180, 0)
                Dim TQ As New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51})
                Dim liT1 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, Pts, 3.0, MkGoc(LiP1(0), LiP4(0)) * 180.0 / Math.PI)
                Dim TQ1 As New List(Of Double)({97.91, 34.75, 368.88, 77.4, 482.81, 90.0, 368.88, 102.6, 85.85, 159.55, 85.85, 20.51, 97.85, 34.71, 78.1, 134.49, 364.14, 98.64, 439.95, 90.0, 364.14, 81.36, 78.17, 45.56})
                Dim liT2 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ1, Pts, 3.0, MkGoc(LiP1(0), LiP4(0)) * 180.0 / Math.PI)
                FVungList(liT1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(liT2, 4294967295, 0, mau, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            End If
            Dim PK11 As IPosition71 = PK1.Move(Khoanglui, FGoc(LiP1(0), LiP4(0)), 0)
            Dim PK12 As IPosition71 = PK1.Move(Khoanglui, 180 + FGoc(LiP1(0), LiP4(0)), 0)
            Dim PK21 As IPosition71 = PK2.Move(Khoanglui, FGoc(LiP2(0), LiP3(0)), 0)
            Dim PK22 As IPosition71 = PK2.Move(Khoanglui, 180 + FGoc(LiP2(0), LiP3(0)), 0)
            LiP1.Reverse()
            LiP2.Reverse()
            LiP3.Reverse()
            LiP4.Reverse()
            LiP5.Reverse()
            LiP6.Reverse()
            LiP1.Add(PK11)
            LiP2.Add(PK21)
            LiP3.Add(PK22)
            LiP4.Add(PK12)
            LiP5.Add(PK22)
            LiP6.Add(PK12)
            Dim K1 As IPosition71 = LiP1(0).Move(Dorongduong * 0.2, FGoc(LiP1(0), LiP1(1)), 0)
            Dim K2 As IPosition71 = LiP2(0).Move(Dorongduong * 0.2, FGoc(LiP2(0), LiP2(1)), 0)
            Dim MT1 As List(Of IPosition71) = DMuiten(LiP1(0), LiP3(0), 270 + MkGoc(K1, LiP3(0)) * 180.0 / Math.PI, Drong, BK / 12)
            Dim MT2 As List(Of IPosition71) = DMuiten(LiP2(0), LiP4(0), 270 + MkGoc(K2, LiP4(0)) * 180.0 / Math.PI, Drong, BK / 12)
            LiP1.Reverse()
            LiP1.Add(K1)
            LiP2.Reverse()
            LiP2.Add(K2)
            MT1.Reverse()
            MT2.Reverse()
            LiP5.Reverse()
            LiP6.Reverse()
            UniCruve(LiP1, MT1)
            UniCruve(LiP2, MT2)
            UniCruve(LiP1, LiP3)
            UniCruve(LiP5, LiP3)
            UniCruve(LiP2, LiP4)
            UniCruve(LiP6, LiP4)
            If Lenhve = "DDgCoDichmatdat" Then
                FVungList(LiP1, 4294967295, 0, mau, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(LiP2, 4294967295, 0, mau, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
            Else
                FVungList(LiP1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(LiP2, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
                FVungList(LiP5, 4294967295, 0, mau, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
                FVungList(LiP6, 4294967295, 0, mau, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
            End If

        End If
    End Sub

    Function CpointMBchivien(P1 As IPosition71, P2 As IPosition71, Khoanglui As Double) As List(Of IPosition71)
        Dim Pm As IPosition71 = CenterPoint(P1, P2)
        Dim Pm1 As IPosition71 = Pm.Move(Khoanglui / 2, 180 + FGoc(P1, P2), 0)
        Dim Pm2 As IPosition71 = Pm.Move(Khoanglui / 2, FGoc(P1, P2), 0)
        Dim LmP As New List(Of IPosition71) From {Pm1, Pm2, Pm}
        CpointMBchivien = LmP
    End Function

    Function PointOnCircle(P As IPosition71, Bankinh As Double, Goc As Double) As List(Of IPosition71)
        Dim liP As New List(Of IPosition71)
        For i As Integer = 0 To 22
            Dim K As IPosition71 = P.Move(Bankinh, i * 10 - Goc, 0)
            liP.Add(K)
        Next
        PointOnCircle = liP
    End Function

#End Region

    Public Sub HoalucKQ()
        Dim p2 As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 9, 115.0, 0)
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 9, 295.0, 0)
        If Lenhve = "KvBandoclaptieudoan" Or Lenhve = "KvBanTTrTieudoan" Then
            DanP(FrmMain.Instance.mPointClick, 0, mau, mau2, "")
            MakeText(FrmMain.Instance.mPointClick, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(0), "", mauChu, 0, 0, 2, 2)
            If Lenhve = "KvBanTTrTieudoan" Then
                DanP(P1, 0, mau, mau2, "")
                DanP(p2, 0, mau, mau2, "")
                MakeText(P1, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(1), "", mauChu, 0, 0, 2, 2)
                MakeText(p2, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(2), "", mauChu, 0, 0, 2, 2)
            End If

        Else
            HLPhongkhong(FrmMain.Instance.mPointClick)
            MakeText(FrmMain.Instance.mPointClick, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(0), "", mauChu, 0, 0, 2, 2)
            If Lenhve = "KvBanTTrDaidoi" Then
                HLPhongkhong(P1)
                HLPhongkhong(p2)
                MakeText(P1, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(1), "", mauChu, 0, 0, 2, 2)
                MakeText(p2, 0.0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(2), "", mauChu, 0, 0, 2, 2)
            End If
        End If
        SLenhve3DMs()
    End Sub

    Private Sub HLPhongkhong(P As IPosition71)
        Dim LiV As List(Of IPosition71) = LiPCircle(P, Dorongduong * 4, 0, 10)
        LiV.Add(LiV(0))
        Dim MGeo As IGeometry = ListtoGeo(LiV).SpatialOperator.buffer(-Dorongduong * 1.5)
        FDuongList(LiV, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(GeoToList(MGeo), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
    End Sub

#End Region

#Region "    Phaobinh"

    Public Sub Phanluc(P1 As IPosition71, Goc1 As Double)
        Dim Pk(40) As IPosition71
        Dim mD As Double = 0
        If Lenhve = "PhaophanlucKyhieuchung" Then
            mD = -50
        ElseIf Lenhve = "Phaophanluccotrung" Then
            mD = -60
        ElseIf Lenhve = "Phaophanluccolon" Then
            mD = -90
        End If
        Dim P As IPosition71 = P1.Move(mD * Tyle, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({100.0, 0.0, 104.4, 343.3, 161.03, 332.24, 125.99, 323.47, 65.95, 332.94, 65.95, 207.06, 125.99, 216.53, 161.03, 207.76, 104.4, 196.7, 197.23, 120.47, 170.66, 95.04, 185.61, 94.64, 190.39, 103.67, 219.66, 101.82, 219.66, 78.18, 190.39, 76.33, 185.61, 85.36, 170.66, 84.96, 197.23, 59.53, 100.0, 0.06, 70.0, 0.08, 156.52, 63.43, 156.52, 116.57, 70.0, 180.0, 72.8, 15.95, 70.0, 0.0, 70.0, 180.0, 156.52, 116.57, 156.52, 63.43, 72.83, 16.02, 53.89, 21.9, 130.0, 67.38, 130.0, 112.62, 53.85, 158.2, 234.36, 101.07, 263.87, 99.82, 263.87, 80.18, 234.36, 78.93})
        If Lenhve = "PhaophanlucKyhieuchung" Then
            Dim listsPoint As New List(Of IPosition71)
            For i As Integer = 0 To 11
                listsPoint.Add(ArrayPoint(TQ, P, 1.6, Goc1)(i))
            Next
            For i As Integer = 16 To 23
                listsPoint.Add(ArrayPoint(TQ, P, 1.6, Goc1)(i))
            Next
            FVungList(listsPoint, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        Else
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
            If Lenhve = "Phaophanluccolon" Then
                FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 34, 37, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
            End If
        End If
        FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 24, 33, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub SCoi(P1 As IPosition71, Goc1 As Double)
        Dim P As IPosition71
        If Lenhve = "Coi160" Then
            P = P1.Move(-20 * Tyle, 90 - Goc1, 0)
        Else
            P = P1
        End If
        Goc1 -= 20
        Dim TQ As New List(Of Double)({100.0, 0.0, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 100.0, 89.89, 70.0, 89.94, 70.0, 75.0, 70.0, 60.0, 70.0, 45.0, 70.0, 30.0, 70.0, 15.0, 70.0, 0.0, 70.0, 345.0, 70.0, 330.0, 70.0, 315.0, 70.0, 300.0, 70.0, 285.0, 70.0, 270.0, 70.0, 255.0, 70.0, 240.0, 70.0, 225.0, 70.0, 210.0, 70.0, 195.0, 70.0, 180.0, 70.0, 165.0, 70.0, 150.0, 70.0, 135.0, 70.0, 120.0, 70.0, 105.0, 70.0, 90.0, 100.0, 90.0, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 165.6, 217.15, 142.01, 224.76, 100.0, 211.17, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 328.61, 141.78, 315.14, 165.6, 322.85, 70.0, 0.0, 70.0, 15.0, 70.0, 30.0, 70.0, 45.0, 70.0, 60.0, 70.0, 75.0, 70.0, 89.89, 50.0, 89.94, 50.0, 75.0, 50.0, 60.0, 50.0, 45.0, 50.0, 30.0, 50.0, 15.0, 50.0, 0.0, 50.0, 345.0, 50.0, 330.0, 50.0, 315.0, 50.0, 300.0, 50.0, 285.0, 50.0, 270.0, 50.0, 255.0, 50.0, 240.0, 50.0, 225.0, 50.0, 210.0, 50.0, 195.0, 50.0, 180.0, 50.0, 165.0, 50.0, 150.0, 50.0, 135.0, 50.0, 120.0, 50.0, 105.0, 50.0, 90.0, 70.0, 90.0, 70.0, 105.0, 70.0, 120.0, 70.0, 135.0, 70.0, 150.0, 70.0, 165.0, 70.0, 180.0, 70.0, 195.0, 70.0, 210.0, 70.0, 225.0, 70.0, 240.0, 70.0, 255.0, 70.0, 270.0, 70.0, 285.0, 70.0, 300.0, 70.0, 315.0, 70.0, 330.0, 70.0, 345.0, 128.06, 51.34, 152.64, 58.39, 152.64, 121.61, 128.06, 128.66, 158.65, 59.72, 185.17, 64.4, 185.17, 115.6, 158.65, 120.28, 191.51, 65.31, 219.13, 68.59, 219.13, 111.41, 191.51, 114.69})
        FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 0, 51, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        If Lenhve = "Coi160" Then
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 102, 105, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 106, 109, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 110, 113, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "Coi120" Then
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 102, 105, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 106, 109, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "Coi82" Then
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 102, 105, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        End If
        FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 52, 101, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub TenluaCocanh()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai =  FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim Goc As Double = 270 + MkGoc(P1, P2) * 180 / Math.PI
        Dim Srong As Double
        Dim Pk As IPosition71 = P2.Move(Dorongduong * 2, FGoc(P1, P2), 0)
        If Lenhve.Contains("2Ranh") Then
            Dim Pk1 As IPosition71 = P2.Move(Dorongduong * 3.2, 90 + FGoc(P1, P2), 0)
            Dim Pk11 As IPosition71 = Pk1.Move(Dorongduong * 20, FGoc(P1, P2), 0)
            Dim Pk2 As IPosition71 = P2.Move(Dorongduong * 3.2, 270 + FGoc(P1, P2), 0)
            Dim Pk21 As IPosition71 = Pk2.Move(Dorongduong * 20, FGoc(P1, P2), 0)
            TenluaCC(Pk11, Pk1, Goc, Lenhve)
            TenluaCC(Pk21, Pk2, Goc, Lenhve)
            Srong = Dorongduong * 6.0
        Else
            TenluaCC(P1, P2, Goc, Lenhve)
            Srong = Dorongduong * 3.0
        End If
        TDTenluaCC(Pk, FGoc(P1, P2), Srong, Dorongduong, mauChu, mauXam)
        SLenhve3DMs()
    End Sub

    Private Sub TenluaCC(P1 As IPosition71, P2 As IPosition71, Goc As Double, mSlenh As String)
        Dim LiC As List(Of IPosition71) = TLcoccanh(P2, Goc)
        Dim Geo As IGeometry = ListtoGeo(LiC)
        Dim LiD As New List(Of IPosition71)
        AddPointToList(LiD, LiC, 0, 3)
        FVungList(LiD, 4294967295, 0.0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        Dim Pg1, Pg2, Pg3 As IPosition71
        Dim LiCap1, LiCap2, LiCap3 As New List(Of IPosition71)
        If mSlenh = "tenluacocanhtamxa" Or Lenhve = "tenluacocanhtamxa2Ranh" Then
            Pg1 = P2.Move(Dorongduong * 2, 180 + FGoc(P1, P2), 0)
            Pg2 = P2.Move(Dorongduong * 4.8, 180 + FGoc(P1, P2), 0)
            Pg3 = P2.Move(Dorongduong * 7.5, 180 + FGoc(P1, P2), 0)
            Dim GeoC1 As IGeometry = Geo.SpatialOperator.Union(CapTenlusCC(Pg1, Goc))
            Dim GeoC2 As IGeometry = GeoC1.SpatialOperator.Union(CapTenlusCC(Pg2, Goc))
            Dim GeoC3 As IGeometry = GeoC2.SpatialOperator.Union(CapTenlusCC(Pg3, Goc))
            LiC.Clear()
            LiC = GeoToList(GeoC3)
        ElseIf mSlenh = "tenluacocanhtamgan" Or Lenhve = "tenluacocanhtamgan2Ranh" Then
            Pg2 = P2.Move(Dorongduong * 5.0, 180 + FGoc(P1, P2), 0)
            Dim GeoC1 As IGeometry = Geo.SpatialOperator.Union(CapTenlusCC(Pg2, Goc))
            LiC.Clear()
            LiC = GeoToList(GeoC1)
        ElseIf mSlenh = "tenluacocanhtamtrung" Or Lenhve = "tenluacocanhtamtrung2Ranh" Then
            Pg1 = P2.Move(Dorongduong * 3.4, 180 + FGoc(P1, P2), 0)
            Pg2 = P2.Move(Dorongduong * 6.2, 180 + FGoc(P1, P2), 0)
            Dim GeoC1 As IGeometry = Geo.SpatialOperator.Union(CapTenlusCC(Pg1, Goc))
            Dim GeoC2 As IGeometry = GeoC1.SpatialOperator.Union(CapTenlusCC(Pg2, Goc))
            LiC.Clear()
            LiC = GeoToList(GeoC2)
        End If
        FVungList(LiC, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)

        'If Not Lenhve.Contains("2Ranh") Then
        '    TDTenluaCC(P2, FGoc(P1, P2), Dorongduong * 10)
        'End If
    End Sub

    Function TLcoccanh(P As IPosition71, Goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({131.81, 19.49, 144.02, 5.98, 183.36, 175.31, 236.53, 169.29, 285.23, 165.85, 278.78, 172.79, 216.57, 180, 278.78, 187.21, 285.23, 194.15, 183.36, 184.69, 144.02, 354.02, 131.81, 340.51, 276.57, 0})
        Dim LiC As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, P, 2.5, Goc)
        TLcoccanh = LiC
    End Function

    Function CapTenlusCC(P As IPosition71, Goc As Double) As IGeometry
        Dim TQ As New List(Of Double)({56.04, 74.48, 56.04, 105.52, 56.04, 255.5, 56.04, 284.5})
        Dim Geeo As IGeometry = ListtoGeo(ArrayDoubleToListPoint(TQ, P, 3.0, Goc))
        CapTenlusCC = Geeo
    End Function

    Public Sub Tenluacocanhhatnhan()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({80.0, 0.07, 80.0, 15.0, 80.0, 30.0, 80.0, 45.0, 80.0, 60.0, 80.0, 75.0, 80.0, 79.12, 169.8, 84.93, 156.46, 73.68, 302.47, 90.0, 156.46, 106.32, 169.8, 95.07, 80.0, 100.88, 80.0, 120.0, 80.0, 135.0, 80.0, 150.0, 80.0, 165.0, 80.0, 180.0, 80.0, 195.0, 80.0, 210.0, 80.0, 225.0, 80.0, 240.0, 80.0, 255.0, 80.0, 259.12, 157.56, 264.54, 260.19, 254.45, 253.11, 262.05, 190.67, 270.0, 253.11, 277.95, 260.19, 285.55, 157.56, 275.46, 80.0, 280.88, 80.0, 285.0, 80.0, 300.0, 80.0, 315.0, 80.0, 330.0, 80.0, 345.0, 80.0, 0.0, 49.74, 360.0, 49.74, 345.0, 49.74, 330.0, 49.74, 315.0, 49.74, 300.0, 49.74, 285.0, 49.74, 270.0, 49.74, 255.0, 49.74, 240.0, 49.74, 225.0, 49.74, 210.0, 49.74, 195.0, 49.74, 180.0, 49.74, 165.0, 49.74, 150.0, 49.74, 135.0, 49.74, 120.0, 49.74, 105.0, 49.74, 90.0, 49.74, 75.0, 49.74, 60.0, 49.74, 45.0, 49.74, 30.0, 49.74, 15.0, 49.74, 0.12, 49.74, 0.12, 49.74, 15.0, 49.74, 30.0, 49.74, 45.0, 49.74, 60.0, 49.74, 75.0, 49.74, 90.0, 49.74, 105.0, 49.74, 120.0, 49.74, 135.0, 49.74, 150.0, 49.74, 165.0, 49.74, 180.0, 49.74, 195.0, 49.74, 210.0, 49.74, 225.0, 49.74, 240.0, 49.74, 255.0, 49.74, 270.0, 49.74, 285.0, 49.74, 300.0, 49.74, 315.0, 49.74, 330.0, 49.74, 345.0, 49.74, 0.0, 29.57, 0.0, 29.57, 330.0, 29.57, 300.0, 29.57, 270.0, 29.57, 240.0, 29.57, 210.0, 29.57, 180.0, 29.57, 150.0, 29.57, 120.0, 29.57, 90.0, 29.57, 60.0, 29.57, 30.0, 29.57, 0.12})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 62, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 63, 100, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub B72xe()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({205.65, 313.59, 205.57, 226.43, 321.9, 116.12, 455.13, 90.0, 321.95, 63.87, 185.02, 320.03, 163.16, 313.25, 299.62, 68.09, 408.91, 90.0, 299.58, 111.89, 163.16, 226.8, 185.02, 320.01})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.8, Goc1), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Phagot(FrmMain.Instance.mPointClick, Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub Phagot(P As IPosition71, Goc1 As Double)
        If Lenhve = "tenluaB72" Or Lenhve = "tenluaB72xe" Then
            Dim TQ1 As New List(Of Double)({90.97, 180.0, 201.68, 116.81, 180.54, 94.42, 225.44, 93.54, 225.58, 85.91, 180.72, 84.9, 201.73, 63.16, 104.43, 29.3, 79.63, 39.92, 161.96, 67.85, 161.92, 112.12, 67.95, 153.8, 68.04, 26.16, 79.63, 39.86, 104.43, 29.25, 91.07, 0.0, 37.5, 0.0, 87.31, 330.11, 63.09, 316.41, 7.5, 0.0, 7.5, 180.0, 62.59, 224.03, 87.31, 209.89, 37.5, 180.0})
            FVungPoint(ArrayPoint(TQ1, P, 2.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        ElseIf Lenhve = "tenluaPhagot" Then
            Dim TQ2 As New List(Of Double)({90.97, 180.0, 201.68, 116.81, 180.54, 94.42, 225.44, 93.54, 225.58, 85.91, 180.72, 84.9, 201.73, 63.16, 104.43, 29.3, 79.63, 39.92, 161.96, 67.85, 161.92, 112.12, 67.95, 153.8, 68.04, 26.16, 79.63, 39.86, 104.43, 29.25, 91.07, 0.0, 37.5, 0.0, 87.31, 330.11, 63.09, 316.41, 17.26, 330.34, 46.02, 289.02, 46.02, 250.98, 17.34, 210.12, 62.59, 224.03, 87.31, 209.89, 37.5, 180.0})
            FVungPoint(ArrayPoint(TQ2, P, 2.0, Goc1), 0, 25, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        End If
        Dim TQ As New List(Of Double)({79.63, 39.92, 161.96, 67.85, 161.92, 112.12, 67.95, 153.8, 68.04, 26.16, 79.63, 39.86, 64.8, 128.08, 135.05, 107.21, 135.08, 72.74, 64.94, 51.9, 79.63, 39.92})
        FVungPoint(ArrayPoint(TQ, P, 2.0, Goc1), 0, 10, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub TLChongngamNBC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(30.0 * Tyle * 2.0, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({10.0, 0.29, 30.0, 0.19, 60.0, 0.1, 108.17, 56.31, 91.24, 80.54, 296.37, 87.1, 280.47, 80.98, 429.32, 90.0, 280.47, 99.02, 296.37, 92.9, 91.24, 99.46, 108.17, 123.69, 67.08, 206.57, 67.08, 333.43, 60.0, 0.0, 30.0, 180.0, 67.08, 116.57, 67.08, 63.43, 30.0, 0.19, 67.08, 63.43, 67.08, 116.57, 30.0, 180.0, 10.0, 0.0, 22.36, 63.43, 22.36, 116.57, 41.23, 104.04, 41.23, 75.96, 10.0, 0.29})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 18, 27, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        MakeText(P1, 0, Tyle * 2.0, Goc1, "N", "", mau, 1, 0, 0, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TLNguloiTudan()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({152.34, 48.97, 155.28, 33.16, 136.77, 18.11, 123.52, 35.94, 100.0, 0.0, 100.0, 180.0, 123.52, 144.06, 136.77, 161.89, 155.28, 146.84, 152.34, 131.03, 276.13, 111.23, 299.29, 108.83, 319.36, 105.73, 335.63, 102.16, 347.61, 98.27, 354.93, 94.18, 357.39, 90.0, 354.93, 85.82, 347.61, 81.73, 335.63, 77.84, 319.36, 74.27, 299.29, 71.17, 276.13, 68.77, 152.42, 49.0, 134.65, 58.68, 264.84, 74.67, 283.56, 76.26, 298.44, 78.32, 310.64, 80.87, 319.69, 83.74, 325.26, 86.82, 327.13, 90.0, 325.26, 93.18, 319.69, 96.26, 310.64, 99.13, 298.44, 101.68, 283.56, 103.74, 264.84, 105.33, 76.16, 156.8, 76.16, 23.2, 134.57, 58.66, 125.33, 66.49, 70.71, 45.0, 70.71, 135.0, 258.98, 101.13, 274.43, 100.05, 285.42, 98.65, 294.53, 96.83, 301.34, 94.72, 305.54, 92.41, 306.96, 90.0, 305.54, 87.59, 301.34, 85.28, 294.53, 83.17, 285.42, 81.35, 274.43, 79.95, 258.98, 78.87, 125.43, 66.51})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.2, Goc1), 0, 40, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.2, Goc1), 24, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TLNguloiTudanNBC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({152.34, 48.97, 155.28, 33.16, 136.77, 18.11, 123.52, 35.94, 100.0, 0.0, 100.0, 180.0, 123.52, 144.06, 136.77, 161.89, 155.28, 146.84, 152.34, 131.03, 276.13, 111.23, 299.29, 108.83, 319.36, 105.73, 335.63, 102.16, 347.61, 98.27, 354.93, 94.18, 357.39, 90.0, 354.93, 85.82, 347.61, 81.73, 335.63, 77.84, 319.36, 74.27, 299.29, 71.17, 276.13, 68.77, 152.42, 49.0, 134.65, 58.68, 264.84, 74.67, 283.56, 76.26, 298.44, 78.32, 310.64, 80.87, 319.69, 83.74, 325.26, 86.82, 327.13, 90.0, 325.26, 93.18, 319.69, 96.26, 310.64, 99.13, 298.44, 101.68, 283.56, 103.74, 264.84, 105.33, 92.2, 139.4, 92.2, 40.4, 134.57, 58.66, 125.33, 66.49, 94.34, 57.99, 94.34, 122.01, 258.98, 101.13, 274.43, 100.05, 285.42, 98.65, 294.53, 96.83, 301.34, 94.72, 305.54, 92.41, 306.96, 90.0, 305.54, 87.59, 301.34, 85.28, 294.53, 83.17, 285.42, 81.35, 274.43, 79.95, 258.98, 78.87, 125.43, 66.51})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.2, Goc1), 0, 40, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.2, Goc1), 24, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TenluaCCtuMB()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P As IPosition71 = FrmMain.Instance.mPointClick.Move(187.35 * Tyle * 2.0, 270 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({158.07, 275.45, 75.47, 78.54, 76.33, 64.45, 79.91, 51.18, 84.45, 41.33, 91.8, 30.25, 100.66, 20.55, 277.35, 90.0, 97.47, 156.86, 88.55, 145.21, 81.52, 136.54, 79.04, 125.27, 76.26, 113.17, 75.47, 101.46, 158.07, 264.55})
        Dim TQ2 As New List(Of Double)({33.54, 120.0, 33.54, 150.0, 33.54, 180.0, 33.54, 210.0, 33.54, 240.0, 33.54, 270.0, 33.54, 300.0, 33.54, 330.0, 33.54, 0.0, 33.54, 30.0, 33.54, 60.0})
        Dim TQ3 As New List(Of Double)({75.47, 101.46, 76.26, 113.17, 174.95, 260.13, 167.0, 261.36, 160.43, 263.39, 158.07, 264.55})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, FrmMain.Instance.mPointClick, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, FrmMain.Instance.mPointClick, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 25, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 26, 31, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TenluachongRADA()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P As IPosition71 = FrmMain.Instance.mPointClick.Move(187.35 * Tyle * 2.0, 270 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({33.54, 116.73, 33.54, 120.0, 33.54, 150.0, 33.54, 180.0, 33.54, 210.0, 33.54, 240.0, 33.54, 270.0, 33.54, 300.0, 33.54, 330.0, 33.54, 0.0, 33.54, 30.0, 33.54, 60.0, 33.54, 63.27})
        Dim TQ2 As New List(Of Double)({30.13, 60.14, 110.13, 13.73, 160.96, 358.27, 163.61, 10.48, 127.97, 26.02, 190.96, 52.97, 195.39, 47.75, 294.83, 70.17, 160.07, 64.62, 174.55, 60.86, 101.86, 33.44, 58.1, 75.04, 153.19, 84.38, 147.99, 77.76, 277.35, 90.0, 147.99, 102.25, 153.19, 95.62, 58.1, 104.96, 101.86, 146.56, 174.55, 119.14, 160.07, 115.38, 294.83, 109.83, 195.39, 132.26, 190.96, 127.03, 127.97, 153.98, 163.62, 169.52, 160.96, 181.73, 110.14, 166.27, 30.13, 119.86, 160.96, 358.27, 110.13, 13.73, 110.14, 166.27, 160.96, 181.73})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, FrmMain.Instance.mPointClick, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 41, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 42, 45, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub BanChieusang()
        If Lenhve = "BanCSphanchiaGioituyen" Then
            Dim LiP As List(Of IPosition71) = ArrayDoubleToListP(PllVts)
            Dim liV As New List(Of IPosition71)
            For i As Integer = 0 To LiP.Count - 2
                Dim liF1 As List(Of IPosition71) = Rau34(LiP(i), 8.0, 90 + FGoc(LiP(i), LiP(i + 1)), mau, 1, Lenhve)
                FDuongList(liF1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Dim Geo As IGeometry = ListtoGeo(liF1).SpatialOperator.buffer(-Dorongduong * 1.5)
                FDuongList(GeoToList(Geo), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Dim Geo1 As IGeometry = ListtoGeo(liF1).SpatialOperator.buffer(Dorongduong * 2.5)
                Dim liK As New List(Of IPosition71)
                AddPointToList(liK, GeoToList(Geo1), 29, 66)
                liK.Reverse()
                UniCruve(liV, liK)
            Next
            FDuongList(liV, 4294967295, "", 0, 0, mauRedBlue, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        Else
            Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
            Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
            Dim LiK1, LiK2 As List(Of IPosition71)
            If Lenhve = "tuyenbanCS" Or Lenhve = "TSTiengdong" Then
                If Lenhve = "tuyenbanCS" Then
                    LiK1 = Rau34(P1, 8, 90 + FGoc(P1, P2), mau, 1, Lenhve)
                    LiK2 = Rau34(P2, 8, 90 + FGoc(P1, P2), mau, 1, Lenhve)
                Else
                    LiK1 = Rau34(P1, 8, 90 + FGoc(P1, P2), mau, 0, Lenhve)
                    LiK2 = Rau34(P2, 8, 90 + FGoc(P1, P2), mau, 0, Lenhve)
                End If
                LiK1.RemoveRange(LiK1.Count - 1, 1)
                LiK2.RemoveRange(0, 1)
                UniCruve(LiK1, LiK2)
                FDuongList(LiK1, 4294967295, "", 0, 0, mau, Dorongduong * 1.7, False, 2, 0, 2) ' 2, False, 2)
                Dim LiD1 As List(Of IPosition71) = DemChieusang(P1, 6.5, 90 + FGoc(P1, P2))
                Dim LiD2 As List(Of IPosition71) = DemChieusang(P2, 6.5, 90 + FGoc(P1, P2))
                UniCruve(LiD1, LiD2)
                FDuongList(LiD1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
            ElseIf Lenhve = "BanChsangChihuongTC" Then
                Dim Kc As Double = FKc(P1, P2) / 4
                Dim Dp1 As IPosition71 = P1.Move(Dorongduong * 7, 90 + FGoc(P1, P2), 0)
                Dim Dp2 As IPosition71 = P1.Move(Dorongduong * 7, 270 + FGoc(P1, P2), 0)
                CongsuTQ(270 + MkGoc(P1, P2) * 180 / Math.PI, Dp1)
                CongsuTQ(90 + MkGoc(P1, P2) * 180 / Math.PI, Dp2)
                Dim Pcs1 As IPosition71 = P2.Move(Kc * 0.75, FGoc(P1, P2), 0)
                Dim Pcs2 As IPosition71 = P2.Move(2 * Kc, FGoc(P1, P2), 0)
                LiK1 = Rau34(Pcs1, 8, 90 + FGoc(P2, P1), mau, 1, Lenhve)
                LiK2 = Rau34(Pcs2, 8, 90 + FGoc(P2, P1), mau, 1, Lenhve)
                Dim LiMT1 As List(Of IPosition71) = Muiten(P1, LiK2(14), FGoc(P1, P2), 0.7, 1.0)
                FVungList(LiMT1, 4294967295, 0.0, mau, 0, mauRedBlue, 1, "", 0, 0, 0, False, 2, 1)
                FDuongList(LiK1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(LiK2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Dim Geo1 As IGeometry = ListtoGeo(LiK1).SpatialOperator.buffer(-Dorongduong * 1.5)
                Dim Geo2 As IGeometry = ListtoGeo(LiK2).SpatialOperator.buffer(-Dorongduong * 1.5)
                FDuongList(GeoToList(Geo1), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(GeoToList(Geo2), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                'Dim Pv11 As IPosition71 = CenterPoint(LiK1(31), LiK1(32))
                Dim LiD1 As New List(Of IPosition71) From {LiK1(14), LiK2(31)}
                FDuongList(LiD1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Dim LiD2 As New List(Of IPosition71) From {LiK1(31), P2}
                FDuongList(LiD2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                DemCau(LiK2(31), LiK1(14))
                DemCau(LiK1(31), P2)
            ElseIf Lenhve = "GiHanNvuTCDT" Then
                Dim TQ As New List(Of Double)({0.00, 0, 12.43, 270, 199.11, 312.47, 180.2, 285.21, 275.97, 296.07, 274.37, 292.31, 393.14, 304.07, 256.87, 305.24, 267.76, 302.16, 214.52, 298.89, 249.53, 319.88, 30.0, 0})
                Dim TQ1 As New List(Of Double)({0.00, 0, 12.43, 90, 199.11, 47.53, 180.2, 74.79, 275.97, 63.93, 274.37, 67.69, 393.14, 55.93, 256.87, 54.76, 267.76, 57.84, 214.52, 61.11, 249.53, 40.12, 30.0, 0})
                FVungList(ArDisAgreetoLiPoint(TQ, P1, 3.0, 180 + MkGoc(P1, P2) * 180 / Math.PI), 4294967295, 0, mau, 0, mauRedBlue, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(ArDisAgreetoLiPoint(TQ1, P2, 3.0, 180 + MkGoc(P1, P2) * 180 / Math.PI), 4294967295, 0, mau, 0, mauRedBlue, 1, "", 0, 0, 0, False, 2, 2)
                Dim LiC As New List(Of IPosition71) From {P1, P2}
                FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong * 1.7, False, 2, 0, 2) ' 2, False, 2)
                DemCau(P2, P1)
            End If
        End If
        SLenhve3DMs()
    End Sub

    Function DemChieusang(Pc As IPosition71, Dx As Double, Goc As Double) As List(Of IPosition71)
        Dx *= Dorongduong
        Dim LiCircleC1 As List(Of IPosition71) = LiPCircle(Pc, Dx, Goc, 10)
        Dim LiC As New List(Of IPosition71)
        AddPointToList(LiC, LiCircleC1, 32, 35)
        AddPointToList(LiC, LiCircleC1, 0, 14)
        DemChieusang = LiC
    End Function

    Public Sub DanP(P As IPosition71, Goc As Double, Smau As IColor71, Smau2 As IColor71, KieuDan As String)
        Dim Kc As Double, G As List(Of Double)
        If Lenhve = "hoalucCN" Or KieuDan = "CN" Then
            G = New List(Of Double) From {63.43, 116.57, 243.43, 296.57}
            Kc = Dorongduong * 7
        Else
            G = New List(Of Double) From {45.0, 135.0, 225.0, 315.0}
            Kc = Dorongduong * 5
        End If

        Dim LiK As New List(Of IPosition71)
        For i As Integer = 0 To G.Count - 1
            Dim Pi As IPosition71 = P.Move(Kc, Goc + G(i), 0)
            LiK.Add(Pi)
        Next
        LiK.Add(LiK(0))
        LiK.Add(LiK(1))
        Dim GeoD As IGeometry = ListtoGeo(LiK).SpatialOperator.buffer(-Dorongduong * 1.5)
        FDuongList(LiK, 4294967295, "", 0, 0, Smau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(GeoToList(GeoD), 4294967295, "", 0, 0, Smau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
    End Sub

    Public Sub HoalucPB(P As IPosition71)
        Dim P2 As IPosition71 = P.Move(Dorongduong * 5, 45.0, 0)
        DanP(FrmMain.Instance.mPointClick, 0, mau, mau2, "")
        DanP(P2, 0, mau, mau2, "")
        SLenhve3DMs()
    End Sub


#End Region

#Region " TangThietgiap"

    Public Sub DemXT(P As IPosition71, hesoTyle As Double, Goc As Double)
        Dim TQ As New List(Of Double)({54.08, 90.1, 163.04, 113.09, 245.9, 90.0, 163.05, 66.91, 54.08, 89.8, 90.14, 89.8, 155.21, 75.1, 209.85, 90.02, 155.2, 104.9, 90.14, 90.0})
        FVungPoint(ArrayPoint(TQ, P, hesoTyle / Tyle, Goc), 0, 9, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub XT1(P As IPosition71, hesoTyle As Double, Goc As Double)
        Dim TQ As New List(Of Double)({0.0, 0.0, 180.28, 56.3, 300.0, 90.0, 180.28, 123.7, 0.1, 180.1, 54.88, 90.0, 163.04, 113.09, 245.9, 90.0, 163.04, 66.91, 54.08, 89.8})
        FVungPoint(ArrayPoint(TQ, P, hesoTyle / Tyle, Goc), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Public Function XTchinh(P As IPosition71, hesoTyle As Double, Goc As Double) As ITerrainPolygon71
        Dim TQ As New List(Of Double)({0.0, 0.0, 180.28, 56.3, 300.0, 90.0, 180.28, 123.7, 0.1, 180.1, 54.88, 90.0, 163.04, 113.09, 245.9, 90.0, 163.04, 66.91, 54.08, 89.8})
        FVungPoint(ArrayPoint(TQ, P, hesoTyle / Tyle, Goc), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Function

    Public Function XTDem(P As IPosition71, hesoTyle As Double, Goc As Double) As ITerrainPolygon71
        Dim TQ As New List(Of Double)({54.08, 90.1, 163.04, 113.09, 245.9, 90.0, 163.05, 66.91, 54.08, 89.8, 90.14, 89.8, 155.21, 75.1, 209.85, 90.02, 155.2, 104.9, 90.14, 90.0})
        FVungPoint(ArrayPoint(TQ, P, hesoTyle / Tyle, Goc), 0, 9, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Function


    Public Function LiPXTn(P As IPosition71, hesoTyle As Double, Goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({150, 0, 100, 90, 63.94, 90, 95.92, 0, 63.94, 270, 95.92, 180, 63.94, 90.02, 100, 90.01, 150, 180, 100, 270})
        Dim LiP As New List(Of IPosition71)
        ArraytoList(LiP, ArrayPointPlus(TQ, P, hesoTyle, 0, Goc + 90))
        LiPXTn = LiP
    End Function

    Public Function LiPXTnDem(P As IPosition71, hesoTyle As Double, Goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({95.92, 0, 63.93, 90, 39.91, 90, 59.86, 0, 39.91, 270, 59.86, 180, 38.89, 90.03, 63.93, 90.02, 95.92, 180, 63.94, 270})
        Dim LiP As New List(Of IPosition71)
        ArraytoList(LiP, ArrayPointPlus(TQ, P, hesoTyle, 0, Goc + 90))
        LiPXTnDem = LiP
    End Function

    Public Function LiPXTdoc(P As IPosition71, hesoTyle As Double, Goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({150.0, 0.00, 100.0, 90.0, 149.97, 179.99, 95.89, 179.99, 63.93, 90.0, 95.92, 0.00, 63.94, 270.0, 95.92, 180.0, 150.0, 180.0, 100.0, 270.0})
        Dim LiP As New List(Of IPosition71)
        ArraytoList(LiP, ArrayPointPlus(TQ, P, hesoTyle, 0, Goc + 90))
        LiPXTdoc = LiP
    End Function

    Public Function LiPXTdocDem(P As IPosition71, hesoTyle As Double, Goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({95.92, 0.00, 63.94, 90.0, 95.89, 179.99, 59.83, 179.98, 39.89, 90.0, 59.86, 0.00, 39.91, 270.0, 59.86, 180.0, 95.92, 180.0, 63.94, 270.0})
        Dim LiP As New List(Of IPosition71)
        ArraytoList(LiP, ArrayPointPlus(TQ, P, hesoTyle, 0, Goc + 90))
        LiPXTdocDem = LiP
    End Function

    Public Sub Xetang()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim hesoTyle As Double
        If Lenhve = "ThapphaoXT" Then
            hesoTyle = Tyle * 2.5
            Dim TQ As New List(Of Double)({130.01, 0.0, 133.41, 347.01, 133.41, 193.0, 354.68, 111.5, 354.68, 68.5, 130.01, 0.04, 100.01, 0.06, 316.23, 71.56, 316.22, 108.43, 99.99, 180.0})
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "xetangbaccau" Then
            hesoTyle = Tyle * 3.5
            Dim TQ As New List(Of Double)({128.0, 0.0, 326.17, 66.9, 316.6, 71.9, 98.0, 0.0, 98.0, 180.0, 315.6, 108.1, 326.17, 113.1, 128.0, 180.0})
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 4, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "xetanghangnhe" Then
            hesoTyle = Tyle * 4.0
            Dim TQ As New List(Of Double)({142.18, 77.9, 163.75, 79.5, 163.75, 100.5, 142.18, 102.1})
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "toQStrenXT" Then
            hesoTyle = Tyle * 3.0
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(150 * hesoTyle, 90 - Goc1, 0)
            Dim Goc2 As Double = Goc1 - 98
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 - 278
                End If
            End If
            'hesoTyle = Tyle * 3.0
            Dim TQ As New List(Of Double)({30.0, 180.0, 42.43, 225.0, 30.0, 270.0, 164.23, 270.0, 174.85, 290.07, 147.03, 294.08, 137.54, 282.6, 30.0, 0.0})
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle / Tyle, Goc2), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "xetanghangtrung" Then
            hesoTyle = Tyle * 4.0
        ElseIf Lenhve = "xetanghangnang" Then
            hesoTyle = Tyle * 4.0
            Dim Pc As IPosition71 = FrmMain.Instance.mPointClick.Move(150 * hesoTyle, 90.0 - Goc1, 0)
            MCircleTQ(Pc, 100, 4294967295, Dorongduong * 0.9, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "xetangromooc" Then
            hesoTyle = Tyle * 4.0
            Dim TQ As New List(Of Double)({27.1, 123.4, 25.5, 234.19, 33.24, 245.75, 40.52, 255.81, 47.16, 265.11, 53.03, 273.99, 58.01, 282.6, 62.03, 291.06, 64.99, 299.41, 66.86, 307.71, 67.6, 315.97, 67.19, 324.22, 65.64, 332.5, 62.99, 340.84, 36.02, 324.97, 37.46, 319.6, 37.35, 313.89, 35.7, 308.64, 32.77, 304.77, 29.1, 303.46, 25.59, 306.11, 27.19, 56.31})
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "tangcancau" Then
            hesoTyle = Tyle * 4.0
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(150 * hesoTyle, 90 - Goc1, 0)
            Dim Goc2 As Double = Goc1 - 90
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 - 270
                End If
            End If
            Dim TQ As New List(Of Double)({21.52, 180.0, 171.73, 310.8, 200.17, 319.5, 182.13, 326.7, 159.61, 321.2, 21.52, 0.0})
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle / Tyle, Goc2), 0, 5, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "TangchoBB" Then
            hesoTyle = Tyle * 4.0
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(180.28 * hesoTyle, 56.31 - Goc1, 0)
            Dim Goc2 As Double = Goc1 + 90
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 + 270
                    P1 = FrmMain.Instance.mPointClick.Move(180.28 * hesoTyle, 123.69 - Goc1, 0)
                End If
            End If
            Dim TQ As New List(Of Double)({150.0, 0.0, 152.97, 11.31, 152.97, 168.69, 150.0, 180.0})
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle / Tyle, Goc2), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "TangHong" Then
            hesoTyle = Tyle * 4.0
            Dim TQ As New List(Of Double)({262.77, 71.35, 283.8, 76.56, 98.29, 148.73, 70.21, 160.03})
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "TangbiTieudiet" Then
            hesoTyle = Tyle * 4.0
            Dim TQ As New List(Of Double)({70.52, 20.65, 98.76, 31.71, 151.97, 83.19, 263.62, 71.42, 284.67, 76.6, 177.93, 90.0, 284.67, 103.4, 263.62, 108.59, 151.96, 96.81, 98.76, 148.29, 70.52, 159.35, 123.85, 90.0})
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 11, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 4)
        ElseIf Lenhve = "tangsalay" Then
            hesoTyle = Tyle * 4.0
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(180.28 * hesoTyle, 123.69 - Goc1, 0)
            Dim Goc2 As Double = Goc1 - 90
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 - 270
                    P1 = FrmMain.Instance.mPointClick.Move(180.28 * hesoTyle, 56.31 - Goc1, 0)
                End If
            End If
            Dim TQ As New List(Of Double)({104.93, 181.09, 61.1, 248.25, 54.17, 257.87, 51.65, 270.0, 54.64, 283.28, 61.11, 291.77, 104.95, 358.91, 150.01, 359.24, 89.66, 284.89, 80.29, 278.99, 76.71, 270.0, 79.74, 261.76, 89.65, 255.13, 150.0, 180.76})
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle / Tyle, Goc2), 0, 13, 4294967295, 0, mau, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        ElseIf Lenhve = "tangmaccan" Then
            hesoTyle = Tyle * 4.0
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(198.49 * hesoTyle, 130.91 - Goc1, 0)
            Dim Goc2 As Double = Goc1 + 90
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 + 270
                    P1 = FrmMain.Instance.mPointClick.Move(198.49 * hesoTyle, 49.09 - Goc1, 0)
                End If
            End If
            Dim TQ As New List(Of Double)({150.0, 0.0, 152.97, 11.31, 152.97, 168.69, 150.0, 180.0})
            FVungPoint(ArrayPoint(TQ, P1, hesoTyle / Tyle, Goc2), 0, 3, 4294967295, 0, mau, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        End If
        DemXT(FrmMain.Instance.mPointClick, hesoTyle, Goc1)
        XT1(FrmMain.Instance.mPointClick, hesoTyle, Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub Tangloinuoc()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({109.17, 55.64, 178.37, 55.9, 297.7, 90.0, 178.37, 124.1, 3.07, 180.0, 51.53, 180.0, 58.41, 208.09, 55.72, 330.43, 48.47, 0.0, 1.53, 0.0, 109.07, 55.64, 112.78, 71.07, 51.78, 90.0, 160.95, 113.41, 243.42, 90.0, 160.95, 66.59, 112.87, 71.07, 119.54, 80.36, 153.0, 74.88, 207.56, 90.0, 153.0, 105.12, 87.84, 90.0, 119.45, 80.38})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 4.0, Goc1), 0, 16, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 4.0, Goc1), 11, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        If Lenhve = "xeTSPT76" Then
            MakeText(FrmMain.Instance.mPointClick, 60, FrmMain.Instance.fLabelStyleMain.Scale, Goc1, "TS", "", mauChu, 0, 0, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub Tangquetmin()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({180.31, 56.34, 297.69, 89.7, 301.86, 80.47, 343.84, 81.64, 340.93, 86.22, 325.96, 86.04, 325.96, 93.96, 340.93, 93.78, 343.84, 98.36, 301.85, 99.53, 297.69, 90.3, 180.26, 123.69, 0.0, 0.0, 180.27, 56.31, 163.05, 66.91, 54.08, 90.0, 163.04, 113.09, 245.9, 90.0, 163.09, 66.93, 155.23, 75.11, 209.85, 90.0, 155.2, 104.9, 90.12, 90.0, 155.21, 75.1})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 4.0, Goc1), 0, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 4.0, Goc1), 14, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Tanguidat()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({0.0, 0.0, 180.28, 56.3, 297.81, 89.72, 300.41, 87.27, 308.17, 84.97, 317.86, 83.51, 325.81, 82.76, 339.67, 83.79, 333.5, 84.44, 323.68, 86.29, 318.37, 88.7, 318.37, 91.3, 323.69, 93.7, 333.51, 95.56, 339.69, 96.21, 325.83, 97.23, 317.58, 96.57, 308.19, 95.02, 300.42, 92.72, 297.81, 90.28, 180.28, 123.7, 0.01, 90.01, 54.1, 90.01, 163.04, 113.09, 245.9, 90.0, 163.05, 66.91, 54.08, 90.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 4.0, Goc1), 0, 26, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemXT(FrmMain.Instance.mPointClick, Tyle * 4.0, Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub Thietgiap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim hesoTyle As Double = Tyle * 3.0
        Dim Pk As IPosition71
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Pc1 As IPosition71 = Pc.Move(-150.0 * hesoTyle, 90.0 - Goc1, 0)
        If Lenhve = "caucogioi" Then
            Pk = Pc1
        Else
            Pk = FrmMain.Instance.mPointClick
        End If

        If Lenhve = "toQStrenTG" Then
            Dim lists3 As New List(Of IPosition71)
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(150 * hesoTyle, 90 - Goc1, 0)
            Dim Goc2 As Double = Goc1 - 98
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 - 278
                End If
            End If
            Dim TQ1 As New List(Of Double)({30.0, 180.0, 42.43, 225.0, 30.0, 270.0, 164.23, 270.0, 174.85, 290.07, 147.03, 294.08, 137.54, 282.6, 30.0, 0.0})
            FVungPoint(ArrayPoint(TQ1, P1, 3.0, Goc2), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "PhaoPKtuhanh" Then
            Dim lists3 As New List(Of IPosition71), lists4 As New List(Of IPosition71), lists5 As New List(Of IPosition71)
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(150 * hesoTyle, 90 - Goc1, 0)
            Dim Goc2 As Double = Goc1 - 270
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 - 90
                End If
            End If
            Dim TQ2 As New List(Of Double)({57.27, 282.09, 12.08, 6.74, 20.17, 7.35, 56.0, 90.0, 20.17, 187.35, 12.08, 173.26, 57.27, 257.91, 52.69, 292.13, 65.67, 311.82, 47.6, 337.11, 27.02, 317.11, 52.69, 247.87, 27.02, 222.89, 47.6, 202.89, 65.67, 228.18})
            FVungPoint(ArrayPoint(TQ2, P1, 3.0, Goc1), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ2, P1, 3.0, Goc1), 7, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ2, P1, 3.0, Goc1), 11, 14, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "PhaoPKtuhanhR" Then
            Dim lists3 As New List(Of IPosition71), lists4 As New List(Of IPosition71), lists5 As New List(Of IPosition71), lists6 As New List(Of IPosition71)
            Dim P1 As IPosition71 = FrmMain.Instance.mPointClick.Move(150 * hesoTyle, 90 - Goc1, 0)
            Dim GocXoay As Double = 54.4
            Dim Goc2 As Double = Goc1 - 270
            Dim Goc3 As Double = 270
            If Goc1 > 90 Then
                If Goc1 < 270 Then
                    Goc2 = Goc1 - 90
                    GocXoay = 125.61
                    Goc3 = 180
                End If
            End If
            Dim TQ3 As New List(Of Double)({57.27, 282.09, 12.08, 6.74, 20.17, 7.35, 56.0, 90.0, 20.17, 187.35, 12.08, 173.26, 57.27, 257.91, 52.69, 292.13, 65.67, 311.82, 47.6, 337.11, 27.02, 317.11, 52.69, 247.87, 27.02, 222.89, 47.6, 202.89, 65.67, 228.18})
            ArrayPoint(TQ3, P1, 3.0, Goc2)
            FVungPoint(ArrayPoint(TQ3, P1, 3.0, Goc2), 0, 6, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ3, P1, 3.0, Goc2), 7, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ3, P1, 3.0, Goc2), 11, 14, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            Dim P2 As IPosition71 = FrmMain.Instance.mPointClick.Move(170.07 * hesoTyle, GocXoay - Goc1, 0)
            Dim k(100) As IPosition71
            k(61) = P2.Move(28.36 * hesoTyle, Goc3 + 75.03 - Goc2, 0)
            k(62) = P2.Move(55.98 * hesoTyle, Goc3 + 217.62 - Goc2, 0)
            k(63) = P2.Move(59.08 * hesoTyle, Goc3 + 213.51 - Goc2, 0)
            k(64) = P2.Move(66.36 * hesoTyle, Goc3 + 209.06 - Goc2, 0)
            k(65) = P2.Move(74.8 * hesoTyle, Goc3 + 207.15 - Goc2, 0)
            k(66) = P2.Move(83.55 * hesoTyle, Goc3 + 207.19 - Goc2, 0)
            k(67) = P2.Move(92.03 * hesoTyle, Goc3 + 208.63 - Goc2, 0)
            k(68) = P2.Move(86.21 * hesoTyle, Goc3 + 223.78 - Goc2, 0)
            k(69) = P2.Move(81.43 * hesoTyle, Goc3 + 224.3 - Goc2, 0)
            k(70) = P2.Move(77.76 * hesoTyle, Goc3 + 226.56 - Goc2, 0)
            k(71) = P2.Move(76.37 * hesoTyle, Goc3 + 230.0 - Goc2, 0)
            k(72) = P2.Move(77.76 * hesoTyle, Goc3 + 233.44 - Goc2, 0)
            k(73) = P2.Move(81.43 * hesoTyle, Goc3 + 235.7 - Goc2, 0)
            k(74) = P2.Move(86.21 * hesoTyle, Goc3 + 236.22 - Goc2, 0)
            k(75) = P2.Move(92.03 * hesoTyle, Goc3 + 251.37 - Goc2, 0)
            k(76) = P2.Move(83.55 * hesoTyle, Goc3 + 252.81 - Goc2, 0)
            k(77) = P2.Move(74.8 * hesoTyle, Goc3 + 252.85 - Goc2, 0)
            k(78) = P2.Move(66.36 * hesoTyle, Goc3 + 250.94 - Goc2, 0)
            k(79) = P2.Move(59.08 * hesoTyle, Goc3 + 246.49 - Goc2, 0)
            k(80) = P2.Move(55.98 * hesoTyle, Goc3 + 242.38 - Goc2, 0)
            k(81) = P2.Move(28.36 * hesoTyle, Goc3 + 24.97 - Goc2, 0)
            FVungPoint(k, 61, 81, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "xechobobinh" Or Lenhve = "xeTSBMP" Then
            Dim TQ11 As New List(Of Double)({111.8, 26.57, 128.06, 38.66, 128.06, 141.34, 111.8, 153.43})
            FVungPoint(ArrayPoint(TQ11, Pk, 3.0, Goc1), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            If Lenhve = "xeTSBMP" Then
                MakeText(FrmMain.Instance.mPointClick, 60, FrmMain.Instance.fLabelStyleMain.Scale, Goc1, "TS", "", mauChu, 0, 0, 2, 2)
            End If
        ElseIf Lenhve = "thietgiaploinuoc" Then
            Dim TQ12 As New List(Of Double)({15.0, 0.0, 33.54, 296.57, 54.08, 326.31, 75.0, 306.87, 75.0, 233.13, 54.08, 213.69, 33.54, 243.43, 15.0, 180.0})
            FVungPoint(ArrayPoint(TQ12, Pk, 3.0, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "Xeraimin" Then
            Dim P1 As IPosition71 = Pk.Move(99.0 * hesoTyle, 90.0 - Goc1, 0)
            Dim P2 As IPosition71 = Pk.Move(171.0 * hesoTyle, 90.0 - Goc1, 0)
            MCircleTQ(P1, 40, 4294967295, Dorongduong * 0.8, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P2, 40, 4294967295, Dorongduong * 0.8, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "XeBAT" Then
            MakeText(FrmMain.Instance.mPointClick, 60, FrmMain.Instance.fLabelStyleMain.Scale, Goc1, "BAT", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "xeTScanhgioi" Then
            MakeText(FrmMain.Instance.mPointClick, 60, FrmMain.Instance.fLabelStyleMain.Scale, Goc1, "TS", "", mauChu, 0, 0, 2, 2)
        End If

        Dim TQ As New List(Of Double)({0.01, 0.0, 100.0, 0.0, 228.43, 64.0, 249.2, 67.5, 266.92, 71.5, 281.15, 75.8, 291.55, 80.4, 297.88, 85.2, 300.0, 90.0, 297.88, 94.8, 291.55, 99.6, 281.15, 104.2, 266.92, 108.5, 249.2, 112.5, 228.43, 116.0, 100.0, 180.0, 0.0, 180.0, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 76.16, 23.2, 30.0, 89.99, 55.0, 89.99, 71.06, 50.7, 205.36, 77.3, 226.8, 80.4, 239.95, 84.8, 244.56, 90.0, 239.95, 95.2, 226.8, 99.6, 207.49, 102.7, 71.06, 129.3, 55.0, 90.0})

        If Lenhve = "PhaoPKtuhanhR" Or Lenhve = "XeBAT" Or Lenhve = "PhaoPKtuhanh" Or Lenhve = "caucogioi" Or Lenhve = "Xeraimin" Then
            FVungPoint(ArrayPoint(TQ, Pk, 3.0, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, Pk, 3.0, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        FVungPoint(ArrayPoint(TQ, Pk, 3.0, Goc1), 17, 44, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Function Emsan1(P As IPosition71, Hesotyle As Double, Goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({106.09, 99.61, 79.8, 108.61, 68.12, 95.55, 56.19, 80.13, 44.94, 60.58, 36.11, 34.13, 32.56, 0.00, 36.11, 325.87, 44.94, 299.42, 56.19, 279.87, 68.12, 264.45, 79.8, 251.39, 106.09, 260.39, 94.16, 275.13, 82.55, 291.94, 72.39, 311.59, 65.2, 334.54, 60.75, 346.09, 114.01, 352.44, 62.56, 0.00, 114.01, 7.56, 60.75, 13.91, 65.2, 25.46, 72.39, 48.41, 82.55, 68.06, 94.16, 84.87})
        Dim LiP As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, P, Hesotyle, Goc)
        Emsan1 = LiP
    End Function

    Public Sub XTtiencong()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim Kc As Double = FKc(P1, P2)
        Dim LiXT As List(Of IPosition71) = LiPXTn(P2, 1.5, MkGoc(P2, P1) * 180 / Math.PI)
        Dim LiXTd As List(Of IPosition71) = LiPXTnDem(P2, 1.5, MkGoc(P2, P1) * 180 / Math.PI)
        Dim Pt As IPosition71 = LiXT(3).Move(Dorongduong, 270 + FGoc(P2, P1), 0)
        Dim Pp As IPosition71 = LiXT(3).Move(Dorongduong, 90 + FGoc(P2, P1), 0)
        Dim Mt As IPosition71
        If Lenhve = "OneXTTc" Then
            Mt = LiXT(3).Move(Dorongduong * 18, 180 + FGoc(P2, P1), 0)
        ElseIf Lenhve = "XTBantructiep" Then
            Mt = LiXT(3).Move(Dorongduong * 30, 180 + FGoc(P2, P1), 0)
        Else
            Mt = LiXT(3).Move(Dorongduong * 25, 180 + FGoc(P2, P1), 0)
        End If
        Dim LiMT As List(Of IPosition71) = Muiten(Mt, P2, 180 + FGoc(P2, P1), 0.4, 1.0)
        If Lenhve = "OneXTTc" Then
            Dim liMt2 As New List(Of IPosition71) From {Pt, LiMT(5), LiMT(6), LiMT(0), LiMT(1), LiMT(2), Pp}
            Dim GeoC As IGeometry = ListtoGeo(LiXT).SpatialOperator.Union(ListtoGeo(liMt2))
            FVungList(GeoToList(GeoC), 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "XTPhuckich" Then
            Dim Pk As IPosition71 = P2.Move(Dorongduong * 7, FGoc(P1, P2), 0)
            Phuckich1(Pk)
        ElseIf Lenhve = "XTBantructiep" Or Lenhve = "DaiTrSPB" Then
            Dim Md As IPosition71 = LiXT(3).Move(Dorongduong * 5, 180 + FGoc(P2, P1), 0)
            'CongsuTQ(MkGoc(P1, P2) * 180 / Math.PI, Md)
            Dim MdS As IPosition71 = LiXT(3).Move(Dorongduong * 7, 180 + FGoc(P2, P1), 0)
            Dim Mt1 As IPosition71 = Mt.Move(Dorongduong * 15, 90 + FGoc(P2, P1), 0)
            Dim Mt2 As IPosition71 = Mt.Move(Dorongduong * 15, 270 + FGoc(P2, P1), 0)
            Dim Md1 As IPosition71 = MdS.Move(Dorongduong * 2, 90 + FGoc(Md, Mt1), 0)
            Dim Md2 As IPosition71 = MdS.Move(Dorongduong * 2, 270 + FGoc(Md, Mt2), 0)
            Dim Md3 As IPosition71 = MdS.Move(Dorongduong, 180 + FGoc(P2, P1), 0)
            Dim LiMT1 As List(Of IPosition71) = Muiten(Mt1, Md1, FGoc(Mt1, Md1), 0.6, 1.0)
            Dim LiMT2 As List(Of IPosition71) = Muiten(Mt2, Md2, FGoc(Mt2, Md2), 0.6, 1.0)
            Dim LiMT3 As List(Of IPosition71) = Muiten(Mt, Md3, FGoc(P1, P2), 0.6, 1.0)
            If Lenhve = "XTBantructiep" Then
                CongsuTQ(MkGoc(P1, P2) * 180 / Math.PI, Md)
                FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
                FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
                FVungList(LiMT3, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            Else
                FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
                FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
                FVungList(LiMT3, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            End If
        ElseIf Lenhve = "BanchanDidong" Or Lenhve = "DaiBanchinh" Then
            Dim Psp As IPosition71 = P2.Move(Dorongduong * 5, 90 + FGoc(P1, P2), 0)
            Dim Pst As IPosition71 = P2.Move(Dorongduong * 5, 270 + FGoc(P1, P2), 0)
            Dim Pk1 As IPosition71
            If Lenhve = "DaiBanchinh" Then
                Pk1 = P2.Move(Dorongduong * 35, FGoc(P1, P2), 0)
            Else
                Pk1 = P2.Move(Dorongduong * 30, FGoc(P1, P2), 0)
            End If
            Dim Pkp As IPosition71, Pkt As IPosition71
            If Lenhve = "DaiBanchinh" Then
                Pkp = Pk1.Move(Dorongduong * 17, 90 + FGoc(P1, P2), 0)
                Pkt = Pk1.Move(Dorongduong * 17, 270 + FGoc(P1, P2), 0)
                Dim Pkp1 As IPosition71 = Pk1.Move(Dorongduong * 25, 90 + FGoc(P1, P2), 0)
                Dim LiMT3 As List(Of IPosition71) = Muiten(Pkp1, Psp, FGoc(Pkp1, Psp), 0.6, 1.0)
                FVungList(LiMT3, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            Else
                Pkp = Pk1.Move(Dorongduong * 5, 90 + FGoc(P1, P2), 0)
                Pkt = Pk1.Move(Dorongduong * 5, 270 + FGoc(P1, P2), 0)
            End If
            Dim LiMT1 As List(Of IPosition71) = Muiten(Pkp, Psp, FGoc(Pkp, Psp), 0.6, 1.0)
            Dim LiMT2 As List(Of IPosition71) = Muiten(Pkt, Pst, FGoc(Pkt, Pst), 0.6, 1.0)
            FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            Dim LiN As New List(Of IPosition71) From {Pst, Psp}
            If Lenhve = "BanchanDidong" Then
                Dim Psp1 As IPosition71 = Psp.Move(Dorongduong * 4, FGoc(P1, P2), 0)
                Dim Psp2 As IPosition71 = Psp.Move(Dorongduong * 8, FGoc(P1, P2), 0)
                Dim Pst1 As IPosition71 = Pst.Move(Dorongduong * 4, FGoc(P1, P2), 0)
                Dim Pst2 As IPosition71 = Pst.Move(Dorongduong * 8, FGoc(P1, P2), 0)
                LiN.Add(Psp1)
                LiN.Add(Pst1)
                LiN.Add(Pst2)
                LiN.Add(Psp2)
                FDuongList(LiN, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            Else
                FDuongList(LiN, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            End If
        End If
        If Not Lenhve = "OneXTTc" And Not Lenhve = "DaiTrSPB" And Not Lenhve = "DaiBanchinh" And Not Lenhve = "BanchanDidong" Then
            FVungList(LiXT, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If
        If Not Lenhve = "DaiTrSPB" And Not Lenhve = "DaiBanchinh" And Not Lenhve = "BanchanDidong" Then
            FVungList(LiXTd, 4294967295, 0.0, mau2, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        End If
        SLenhve3DMs()
    End Sub

    Function DaiTrungdoi(P1 As IPosition71, P2 As IPosition71, G2 As Double, Heso As Double) As List(Of IPosition71)
        Dim P11 As IPosition71 = P1.Move(-Dorongduong * Heso, G2 + 90, 0)
        Dim P12 As IPosition71 = P1.Move(-Dorongduong * Heso * 2, G2 + 90, 0)
        Dim P31 As IPosition71 = P2.Move(-Dorongduong * Heso, G2 + 90, 0)
        Dim P32 As IPosition71 = P2.Move(-Dorongduong * Heso * 2, G2 + 90, 0)
        Dim liD1 As New List(Of IPosition71) From {P1, P11, P31, P2}
        Dim D1 As IGeometry = ListtoGeo(liD1)
        Dim D2 As IGeometry = ListtoGeo(GachDoihnhTC(P1, P11, 2, 2, 90))
        Dim D3 As IGeometry = ListtoGeo(GachDoihnhTC(P2, P31, 2, 2, -90))
        Dim GeoChinh1 As IGeometry = D1.SpatialOperator.Union(D2)
        Dim GeoChinh2 As IGeometry = GeoChinh1.SpatialOperator.Union(D3)
        Dim liCu As List(Of IPosition71) = GeoToList(GeoChinh2)
        Dim liMoi As New List(Of IPosition71) From {liCu(17), liCu(16), liCu(15), liCu(14), liCu(12), liCu(8), liCu(7), liCu(6), liCu(5), liCu(4), liCu(3)}
        DaiTrungdoi = liMoi
    End Function

#End Region

#Region "   LucluongVTDP"

    Function FPoint(P1 As IPosition71, Kc As Double, cGoc As Double, kGoc As Double) As IPosition71
        Dim cP1 As IPosition71 = P1.Move(Kc / 2, cGoc + kGoc, 0)
        FPoint = cP1
    End Function

    Private Sub CancuHP(p1 As IPosition71, p2 As IPosition71)
        Dim Pc1 = p2.Move(Dorongduong * 4, FGoc(p1, p2), 0)
        Dim Pp1 = Pc1.Move(Dorongduong * 4.5, 90 + FGoc(p1, p2), 0)
        Dim Pp2 = Pc1.Move(Dorongduong * 4.5, 270 + FGoc(p1, p2), 0)
        Dauchuthap(Pp1, FGoc(p1, p2), mau, 1.6)
        Dauchuthap(Pp2, FGoc(p1, p2), mau, 1.6)
        FDuongList(LiPCircle(Pc1, Dorongduong * 1.5, MkGoc(p1, p2), 15), 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
    End Sub

    Public Sub Banphongno()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({0.0, 0.0, 283.65, 65.0, 271.21, 62.09, 391.61, 66.87, 274.19, 73.93, 284.8, 70.15, 60.53, 90.0, 284.8, 109.85, 273.71, 106.73, 391.61, 113.13, 271.4, 118.59, 283.65, 115.0, 179.61, 45.9, 247.75, 59.7, 247.75, 120.3, 150.55, 146.13, 150.55, 33.87, 179.56, 45.88, 163.15, 52.2, 147.85, 47.44, 147.85, 132.56, 213.74, 117.89, 213.74, 62.11, 163.15, 52.2, 151.72, 58.18, 186.9, 64.66, 186.9, 115.34, 151.71, 121.82})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 12, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 18, 27, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HamBimatNBC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({138.45, 71.66, 72.77, 53.24, 70.16, 51.93, 61.74, 48.68, 51.69, 46.27, 43.19, 46.38, 34.66, 50.66, 28.61, 61.48, 27.4, 112.77, 33.34, 124.79, 41.45, 129.79, 52.06, 130.47, 63.92, 127.89, 73.92, 124.1, 206.21, 101.66, 215.05, 100.76, 221.59, 99.79, 229.52, 98.02, 235.06, 96.06, 238.12, 94.05, 238.81, 91.38, 239.01, 87.26, 237.95, 85.21, 234.68, 83.25, 229.09, 81.34, 221.28, 79.63, 210.22, 78.15, 199.13, 77.37, 138.45, 71.67, 133.49, 79.84, 195.74, 83.09, 202.5, 83.32, 210.61, 84.13, 214.76, 84.97, 217.36, 85.81, 218.6, 86.54, 218.98, 87.32, 218.77, 91.03, 218.58, 92.91, 217.47, 93.62, 214.99, 94.46, 210.85, 95.3, 208.2, 95.67, 203.1, 96.09, 64.8, 109.15, 60.32, 109.64, 52.23, 108.19, 47.5, 104.35, 46.14, 101.51, 45.44, 98.02, 46.36, 76.08, 49.48, 70.09, 52.7, 68.33, 54.88, 67.79, 60.09, 67.66, 63.75, 68.32, 133.47, 79.84, 11.11, 11.11, 71.98, 51.76, 220.67, 78.35, 235.9, 81.54, 239.01, 87.26, 212.98, 101.25, 184.9, 102.99, 228.55, 80.35, 220.37, 78.6, 201.78, 77.54, 157.05, 105.34, 129.58, 108.69, 176.31, 75.7, 148.65, 72.96, 102.79, 113.8, 77.38, 122.38, 121.49, 68.99, 95.23, 62.79, 53.58, 132.13, 39.24, 132.73, 27.42, 115.67})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 56, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        Dim TQ1 As New List(Of Double)({148.26, 62.46, 206.05, 70.57, 222.09, 72.26, 236.33, 74.61, 248.11, 77.42, 256.89, 80.54, 262.28, 83.83, 264.05, 87.2, 263.86, 91.74, 262.65, 95.23, 257.54, 98.64, 248.76, 101.87, 236.73, 104.78, 225.83, 106.63, 215.86, 107.93, 89.38, 138.05, 76.1, 145.96, 61.88, 154.04, 46.99, 162.23, 31.63, 170.37, 15.95, 177.86, 16.79, 1.03, 28.42, 4.85, 43.57, 12.5, 58.21, 20.65, 72.15, 28.88, 85.17, 37.02, 89.22, 39.79, 148.19, 62.44, 138.45, 71.66, 72.77, 53.24, 70.16, 51.93, 61.74, 48.68, 51.69, 46.27, 43.19, 46.38, 34.66, 50.66, 28.61, 61.48, 27.4, 112.77, 33.34, 124.79, 41.45, 129.79, 52.06, 130.47, 63.92, 127.89, 73.92, 124.1, 62.09, 99.68, 202.22, 92.96, 206.21, 101.66, 215.05, 100.76, 221.59, 99.79, 229.52, 98.02, 235.06, 96.06, 238.12, 94.05, 238.81, 91.38, 239.01, 87.26, 237.95, 85.21, 234.68, 83.25, 229.09, 81.34, 221.28, 79.63, 210.22, 78.15, 199.13, 77.37, 138.45, 71.67})
        FVungPoint(ArrayPoint(TQ1, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 59, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        If Lenhve = "hambimatNBC" Then
            Dim TQ2 As New List(Of Double)({71.98, 51.76, 220.67, 78.35, 235.9, 81.54, 239.01, 87.26, 212.98, 101.25, 184.9, 102.99, 228.55, 80.35, 220.37, 78.6, 201.78, 77.54, 157.05, 105.34, 129.58, 108.69, 176.31, 75.7, 148.65, 72.96, 102.79, 113.8, 77.38, 122.38, 121.49, 68.99, 95.23, 62.79, 53.58, 132.13, 39.24, 132.73, 27.42, 115.67})
            FVungPoint(ArrayPoint(TQ2, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 19, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "hambimat" Then
        End If
        SLenhve3DMs()
    End Sub

    Public Sub HamngamDPNBC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({30.0, 0.0, 150.0, 0.0, 283.02, 57.99, 261.96, 66.37, 299.04, 69.44, 325.0, 59.49, 377.92, 64.11, 365.82, 68.34, 338.12, 66.47, 318.94, 76.4, 251.45, 72.65, 241.87, 82.87, 182.48, 80.54, 182.48, 99.46, 371.21, 94.64, 374.83, 99.21, 161.55, 111.8, 161.55, 68.2, 218.4, 74.05, 241.87, 60.26, 123.69, 14.04, 67.08, 26.57, 108.17, 56.31, 150.0, 143.13, 388.97, 107.97, 399.25, 112.07, 161.55, 158.2, 67.08, 63.43})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 27, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemHamngam(Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub HamngamDP()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({30.0, 0.0, 150.0, 0.0, 283.02, 57.99, 241.87, 82.87, 182.48, 80.54, 182.48, 99.46, 371.21, 94.64, 374.83, 99.21, 161.55, 111.8, 161.55, 68.2, 218.4, 74.05, 241.87, 60.26, 123.69, 14.04, 67.08, 26.57, 108.17, 56.31, 150.0, 143.13, 388.97, 107.97, 399.25, 112.07, 161.55, 158.2, 67.08, 63.43})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 19, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemHamngam(Goc1)
        SLenhve3DMs()
    End Sub

    Private Sub DemHamngam(Goc As Double)
        Dim k(21) As IPosition71
        Dim TQ As New List(Of Double)({374.83, 99.21, 161.55, 111.8, 161.55, 68.2, 218.4, 74.05, 241.87, 60.26, 123.69, 14.04, 67.08, 26.57, 108.17, 56.31, 150.0, 143.13, 388.97, 107.97, 382.0, 104.4, 149.16, 129.56, 143.0, 53.53, 101.24, 32.91, 109.77, 30.07, 207.97, 62.82, 203.59, 65.32, 151.16, 55.78, 151.16, 124.22, 379.64, 102.94})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc), 0, 19, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub KhudancuMOI()
        Dim mTextture As String = ""
        If Lenhve = "baiminHQ" Then
            mTextture = "Red.gif"
        ElseIf Lenhve = "KvBaoveMtieu" Then
            mTextture = "Brown.gif"
        ElseIf Lenhve = "KvCamban" Then
            mTextture = "Black.gif"
        ElseIf Lenhve = "KvXamcu" Or Lenhve = "khudancumoi" Then
            mTextture = "Green.gif"
        End If

        If mTextture <> "" Then
            If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
                mTextture = "Blue.gif"
            End If
        End If

        Dim LiP As List(Of IPosition71) = ArrayDoubleToListP(PllVts)
        Dim Geo As IGeometry = ListtoGeo(LiP).SpatialOperator.buffer(-Dorongduong * 1.5)

        Dim Smau As IColor71
        If Lenhve = "KvXamcu" Then
            Smau = mauXanh
        Else
            Smau = mau
        End If

        If mTextture <> "" Then
            FVungList(GeoToList(Geo), 4294967295, 0, mau2, 0, Smau, 1, mTextture, 50.0, 50.0, 135.0, False, 2, 2)
        End If

        If Lenhve = "Doituongvung" Then
            If FrmMain.Instance.ChebTron.Checked = True Then
                FVungList(LiP, 4294967295, Dorongduong * 1.5, Smau, 1, mau2, 1, "", 0, 0, 0, True, 2, 1)
            Else
                FVungList(LiP, 4294967295, Dorongduong * 1.5, Smau, 1, mau2, 1, "", 0, 0, 0, False, 2, 1)
            End If

        ElseIf Lenhve = "khudancumoi" Or Lenhve = "baiminHQ" Or Lenhve = "KvCamban" Or Lenhve = "KvXamcu" Or Lenhve = "KvBaoveMtieu" Then
            FVungList(LiP, 4294967295, Dorongduong * 1.5, Smau, 1, Smau, 0, "", 0, 0, 0, False, 2, 1)
            FVungList(GeoToList(Geo), 4294967295, Dorongduong * 1.5, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 1)
            'Else
        ElseIf Lenhve = "CumANQP" Then
            FVungList(LiP, 4294967295, Dorongduong * 1.5, Smau, 1, Smau, 0, "", 0, 0, 0, False, 2, 3)
            LiP.Add(LiP(0))
            LiP.Add(LiP(1))

            For i As Integer = 0 To LiP.Count - 3
                Dim gocK As Double = FGoc(LiP(i), LiP(i + 1))
                Dim kc As Double = FKc(LiP(i + 1), LiP(i))
                Dim cP1 As IPosition71 = LiP(i).Move(kc / 4, gocK - 180, 0)
                Dim cP2 As IPosition71 = LiP(i + 1).Move(kc / 4, gocK - 0, 0)
                Dim gocK1 As Double = FGoc(LiP(i + 1), LiP(i + 2))
                Dim kc1 As Double = FKc(LiP(i + 1), LiP(i + 2))
                Dim cP3 As IPosition71 = LiP(i + 1).Move(kc1 / 4, gocK1 - 180, 0)
                Dim lists2 As New List(Of IPosition71) From {cP2, LiP(i + 1), cP3}
                VungANQP(lists2)
                DgANQP(LiP(i + 1))
            Next

            FVungList(GeoToList(Geo), 4294967295, Dorongduong * 1.5, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 1)
        ElseIf Lenhve = "Langchiendau" Then
            LgChiendauTQ(LiP)
        ElseIf Lenhve = "Cumlangchiendau" Then
            Dim Pc As IPosition71 = PcenterFormLiP(LiP)
            For i As Integer = 0 To LiP.Count - 1
                Dim Pk1 As IPosition71 = LiP(i).Move(Dorongduong * 30, 35 + FGoc(Pc, LiP(i)), 0)
                Dim Pk2 As IPosition71 = LiP(i).Move(Dorongduong * 30, 325 + FGoc(Pc, LiP(i)), 0)
                Dim liH As New List(Of IPosition71) From {LiP(i), Pk2, Pk1}
                LgChiendauTQ(liH)
                '////////////////
                LiP.Add(LiP(0))
                Dim Pv1 As IPosition71 = LiP(i).Move(Dorongduong * 35, 325 + FGoc(Pc, LiP(i)), 0)
                Dim Pv2 As IPosition71 = LiP(i + 1).Move(Dorongduong * 35, 35 + FGoc(Pc, LiP(i + 1)), 0)
                Dim Pvc As IPosition71 = CenterPoint(Pv1, Pv2)
                Dim Pm1 As IPosition71 = Pvc.Move(FKc(Pv1, Pv2) / 12, 270 + FGoc(Pv1, Pv2), 0)
                Dim Pm2 As IPosition71 = Pvc.Move(FKc(Pv1, Pv2) / 12, 90 + FGoc(Pv1, Pv2), 0)
                Dim liS As New List(Of IPosition71) From {Pv1, Pm1, Pv2} ', Pm2, Pv1}
                Dim LiPDg As New List(Of IPosition71)
                For j As Integer = 0 To liS.Count - 1
                    Dim Ps1 As IPosition71 = liS(j).Move(Dorongduong * 1.5, FGoc(Pc, liS(j)), 0)
                    LiPDg.Add(Ps1)
                Next
                FDuongList(liS, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, True, 2, 0, 2)
                FDuongList(LiPDg, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, True, 2, 0, 1) ' 2, False, 2)
            Next

        End If
        SLenhve3DMs()
    End Sub

    Private Sub LiPLangCD(LiK As List(Of IPosition71), P1 As IPosition71, P2 As IPosition71, Pc As IPosition71, I As Integer)
        Dim Dx, Dy As Double
        If Lenhve = "Langchiendau" Then
            If I = 0 Then
                Dx = 6.0
            Else
                Dx = 8.0
            End If
            Dy = 10.0
        Else
            Dx = 6.0
            Dy = 4.0
        End If
        If Lenhve = "Langchiendau" Then
            Dx += FKc(P1, P2) / 900
            Dy -= FKc(P1, P2) / 1000
        End If
        Dim Ps1 As IPosition71 = P1.Move(Dorongduong * Dx, FGoc(Pc, P1), 0)
        Dim Pkc As IPosition71 = CenterPoint(P1, P2)
        Dim P11 As IPosition71 = Ps1.Move(Dorongduong * Dy, 90 + FGoc(Pc, P1), 0)
        Dim P12 As IPosition71 = Ps1.Move(Dorongduong * Dy, 270 + FGoc(Pc, P1), 0)
        Dim Pk1 As IPosition71 = Pkc.Move(FKc(P1, P2) / 15, 270 + FGoc(P1, P2), 0)
        LiK.Add(P11)
        LiK.Add(P12)
        LiK.Add(Pk1)
    End Sub

    Private Sub LgChiendauTQ(LiCD As List(Of IPosition71))
        Dim Pck As IPosition71 = PcenterFormLiP(LiCD)
        Dim liV As New List(Of IPosition71)
        For j As Integer = 0 To LiCD.Count - 1
            CongsuTQ(180.0 + (MkGoc(Pck, LiCD(j)) * 180 / Math.PI), LiCD(j))
            LiCD.Add(LiCD(0))
            LiPLangCD(liV, LiCD(j), LiCD(j + 1), Pck, j)
        Next
        FVungList(liV, 4294967295, Dorongduong * 1.5, mauXanh, 1, mau2, 0, "", 0, 0, 0, True, 2, 1)
    End Sub

    Function PathAnh(Khieu As String) As String
        Dim PatA As String
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 0 Then
            PatA = "P" & Khieu
        Else
            PatA = Khieu
        End If
        PathAnh = PatA
    End Function

    Function PcenterFormLiP(LiP As List(Of IPosition71)) As IPosition71
        Dim mX1, mY1 As Double
        For i As Integer = 0 To LiP.Count - 1
            mX1 += LiP(i).X
            mY1 += LiP(i).Y
        Next
        Dim X As Double = mX1 / LiP.Count
        Dim Y As Double = mY1 / LiP.Count
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(X, Y, 0, 2, 0, 0, 0, 0)
        PcenterFormLiP = Pc
    End Function

    Public Sub KvPhongthu()
        solan = 0
        Dim liChung As List(Of IPosition71) = ArrayDoubleToListP(PllVts)
        Dim Pc As IPosition71 = PcenterFormLiP(liChung) ' FrmMain.Instance.sgworldMain.Creator.CreatePosition(X, Y, 0, 2, 0, 0, 0, 0)
        liChung.Add(liChung(0))
        Dim LiT, LiF As New List(Of IPosition71)

        If Lenhve = "KvDichmoiden" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "82017", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KvKhotrandau" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "218021", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KvTautrandau" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "980000", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KVTrinhsatSCN" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", PathAnh("250014"), mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KVTrinhsatSN" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", PathAnh("250013"), mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KvHoaluc" Then
            DanP(Pc, 0, mau, mau2, "CN")
        ElseIf Lenhve = "KvBvMtieuBangGnhieungoinoVT" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", PathAnh("280026"), mauChu, 1, 0, 0, 2) '
        ElseIf Lenhve = "KvCamTbVTD" Then '
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", PathAnh("270001"), mauChu, 1, 0, 0, 2) '
        ElseIf Lenhve = "KvKho" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "218034", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KvBdCongnghe" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "410001", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "CCCDBP" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "1200010", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "CumCN" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "218064", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "KvKT" Then
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "KvKT", "82006", mauChu, 1, 0, 0, 2)
        End If

        For i As Integer = 0 To liChung.Count - 2
            Dim Dx As Double
            Dim Gock As Double = MkGoc(Pc, liChung(i)) * 180 / Math.PI
            If Lenhve = "khuvucphongthuthenchot" Then
                Dx = Dorongduong * 8
                If Lenhve = "khuvucphongthuthenchot" Then
                    CongsuTQ(MkGoc(liChung(i), Pc) * 180 / Math.PI, liChung(i))
                End If
            ElseIf Lenhve = "KvDichmoiden" Then
                Dx = Dorongduong * 5
            ElseIf Lenhve = "cancuhauphuong" Or Lenhve = "cancuchiendau" Or Lenhve = "khuvucphongthutrongdiem" Or Lenhve = "CCCDBP" Then
                CancuHP(Pc, liChung(i))
                If Lenhve = "cancuchiendau" Or Lenhve = "khuvucphongthutrongdiem" Then
                    Dim Pd As IPosition71 = liChung(i).Move(Dorongduong * 12, FGoc(Pc, liChung(i)), 0)
                    CongsuTQ(MkGoc(liChung(i), Pc) * 180 / Math.PI, Pd)
                End If
                Dx = Dorongduong * 9.0
            ElseIf Lenhve = "khuvucphaigiu" Or Lenhve = "MTCanbaove" Then
                Dim Pd As IPosition71 = liChung(i).Move(Dorongduong * 3, FGoc(Pc, liChung(i)), 0)
                Dx = Dorongduong * 8
                Dim Pd1 As IPosition71 = Pd.Move(Dorongduong * 6, FGoc(Pc, liChung(i)), 0)
                Dim Pd2 As IPosition71 = Pd.Move(Dorongduong * 6, 90 + FGoc(Pc, liChung(i)), 0)
                Dim Pd3 As IPosition71 = Pd.Move(Dorongduong * 6, 270 + FGoc(Pc, liChung(i)), 0)
                Dim Pd4 As IPosition71 = Pd.Move(Dorongduong * 4, 180 + FGoc(Pc, liChung(i)), 0)

                Dim Pd5 As IPosition71 = Pd2.Move(Dorongduong * 4, 180 + FGoc(Pc, liChung(i)), 0)
                Dim Pd6 As IPosition71 = Pd3.Move(Dorongduong * 4, 180 + FGoc(Pc, liChung(i)), 0)
                Dim LiDg As List(Of IPosition71) ' From {Pd1, Pd2, Pd5, Pd2, Pd, Pd4, Pd, Pd3, Pd6, Pd3, Pd1}
                If Lenhve = "khuvucphaigiu" Then
                    LiDg = New List(Of IPosition71) From {Pd1, Pd2, Pd5, Pd2, Pd, Pd4, Pd, Pd3, Pd6, Pd3, Pd1}
                Else
                    LiDg = New List(Of IPosition71) From {Pd1, Pd2, Pd, Pd3, Pd1}
                End If
                FDuongList(LiDg, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            Else
                Dx = Dorongduong / 3
            End If

            If Dx = Dorongduong / 3 Then
                Dim LiH As List(Of IPosition71) = Ns5Point(liChung.Count - 1, Pc, liChung(i), liChung(i + 1), Dx)
                LiH.RemoveRange(LiH.Count - 1, 1)
                LiH.RemoveRange(0, 1)
                AddPointToList(LiT, LiH, 0, LiH.Count - 1)
            Else
                Dim LiKv As List(Of IPosition71) = Ns5Point(liChung.Count - 1, Pc, liChung(i), liChung(i + 1), Dx)
                AddPointToList(LiF, LiKv, 0, LiKv.Count - 1)
            End If
        Next

        If LiF.Count > 0 Then
            If Lenhve = "khuvucphongthuthenchot" Then
                Dim Pb1 As IPosition71 = LiF(8).Move(Dorongduong * 10, FGoc(Pc, LiF(8)), 0)
                Dim Pb2 As IPosition71 = LiF(25).Move(Dorongduong * 10, FGoc(Pc, LiF(25)), 0)
                Dim Pb3 As IPosition71 = LiF(53).Move(Dorongduong * 10, FGoc(Pc, LiF(53)), 0)
                Dim LiB1 As New List(Of IPosition71) From {LiF(7), LiF(8), LiF(9), Pb1}
                Dim LiB2 As New List(Of IPosition71) From {LiF(24), LiF(25), LiF(26), Pb2}
                Dim LiB3 As New List(Of IPosition71) From {LiF(49), LiF(50), LiF(51), LiF(52), LiF(53), LiF(54), LiF(55), LiF(56), Pb3}
                FVungList(LiB1, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
                FVungList(LiB2, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
                FVungList(LiB3, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            End If

        End If

        If LiT.Count > 0 Then
            LiT.Add(LiT(0))
            Dim GeoT As IGeometry = ListtoGeo(LiT).SpatialOperator.buffer(-Dorongduong * 1.5)
            If Lenhve = "KvLanchiem" Or Lenhve = "KVNgapnuoc" Or Lenhve = "KvBiphahuyHN" Then
                FDuongList(GeoToList(GeoT), 4294967295, "", 0, 0, mau4, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                FDuongList(LiT, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            ElseIf Lenhve = "KvTRanhchap" Or Lenhve = "KvXamcanh" Then
                FDuongList(GeoToList(GeoT), 4294967295, "", 0, 0, mau4, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                FDuongList(LiT, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            Else
                FDuongList(GeoToList(GeoT), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                FDuongList(LiT, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            End If '

            If Lenhve = "KvBiphahuyHN" Then
                Dim GeoT1 As IGeometry = ListtoGeo(LiT).SpatialOperator.buffer(-Dorongduong * 12)
                FDuongList(GeoToList(GeoT1), 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
            End If
            'KVCatvui
            If Lenhve = "KVCatvui" Or Lenhve = "KvCamTbVTD" Or Lenhve = "KvBvMtieuBangGnhieungoinoVT" Or Lenhve = "KvLanchiem" Or Lenhve = "KVNgapnuoc" Or Lenhve = "KVCatvui" Or Lenhve = "KvXamcanh" Or Lenhve = "KvTRanhchap" Then
                Dim TenGif As String = ""
                If Lenhve = "KVNgapnuoc" Then
                    TenGif = "Nuoc.gif"
                ElseIf Lenhve = "KvLanchiem" Then
                    If FrmMain.Instance.cbTa_DP.SelectedIndex = 0 Then
                        TenGif = "Blue.gif"
                    Else
                        TenGif = "Red.gif"
                    End If
                ElseIf Lenhve = "KvCamTbVTD" Or Lenhve = "KvBvMtieuBangGnhieungoinoVT" Then
                    If FrmMain.Instance.cbTa_DP.SelectedIndex = 0 Then
                        TenGif = "Black.gif"
                    Else
                        TenGif = "Blue.gif"
                    End If
                ElseIf Lenhve = "KvXamcanh" Then
                    TenGif = "Xamcanh.gif"
                ElseIf Lenhve = "KvTRanhchap" Then
                    TenGif = "Green.gif"
                ElseIf Lenhve = "KVCatvui" Then
                    TenGif = "cat.gif"
                End If

                FVungList(LiT, 4294967295, 0, mau, 0, mau, 1, TenGif, 25.0 / Tyle, 25.0 / Tyle, 0, False, 2, -1)
            End If
            '
            If Lenhve = "KvCamTbVTD" Or Lenhve = "KvBvMtieuBangGnhieungoinoVT" Then
                Dim Pf As IPosition71 = Pc.Move(Dorongduong * 10, 0, 0)
                Mask(Pf, 0, Dorongduong * 24, Dorongduong * 24)
            End If

        End If

        SLenhve3DMs()

    End Sub

    Function Ns5Point(sodiem As Integer, PcK As IPosition71, P1 As IPosition71, P2 As IPosition71, Khoangho As Double) As List(Of IPosition71)
        Dim Gpp1, GPc2, Gpp2, Kpc1, Kpc2, Kpc3 As Double
        If solan < sodiem - 1 Then
            Gpp1 = 170
            Gpp2 = 10.0
            GPc2 = 30.0
            Kpc1 = 0.25
            Kpc2 = 0.35
            Kpc3 = 0.35
        Else
            Gpp2 = 40.0
            Gpp1 = 140.0
            GPc2 = 10.0
            Kpc1 = 0.04
            Kpc2 = 0.435
            Kpc3 = 0.35
        End If

        Dim Kc As Double = FKc(P1, P2)
        Dim Goc As Double = FGoc(P1, P2)
        Dim Pc As IPosition71 = CenterPoint(P1, P2)

        Dim Pc1 As IPosition71 = Pc.Move(Kpc1 * Kc, 90.0 + Goc, 0)
        Dim Pcs As IPosition71 = Pc1.Move(0.1 * Kc, Goc, 0)
        Dim Pc2 As IPosition71 = Pc.Move(Kpc2 * Kc, GPc2 + Goc, 0)
        Dim Pc3 As IPosition71 = Pc.Move(Kpc3 * Kc, 150.0 + Goc, 0)
        Dim Pc31 As IPosition71 = Pc.Move(0.2 * Kc, 125.0 + Goc, 0)
        '////////
        Dim Pp1 As IPosition71 = P1.Move(Khoangho, Gpp1 + FGoc(P1, Pc1), 0)
        Dim Pp2 As IPosition71 = P2.Move(Khoangho, Gpp2 + FGoc(Pc1, P2), 0)
        '////////////
        Dim Pc21 As IPosition71 = Pc.Move(0.35 * Kc, 20.0 + Goc, 0)
        Dim Pc22 As IPosition71 = Pc.Move(0.23 * Kc, 25.0 + Goc, 0)
        '///////////
        Dim LiN As List(Of IPosition71)
        If solan < sodiem - 1 Then
            LiN = New List(Of IPosition71) From {Pp1, Pc2, Pc1, Pc3, Pp2}
        Else
            LiN = New List(Of IPosition71) From {Pp1, Pc2, Pc21, Pc22, Pcs, Pc1, Pc31, Pc3, Pp2}
        End If

        If Lenhve = "khuvucphongthutrongdiem" Then
            Vong2(PcK, LiN, Dorongduong * 12, mau, 2)
        End If
        Dim LiNCur As List(Of IPosition71) = Curveline(LiN, 4)

        If Khoangho <> Dorongduong / 3 Then
            If Lenhve = "KvDichmoiden" Then
                FDuongList(LiNCur, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Vong2(PcK, LiN, Dorongduong * 1.5, mau4, 1)
            Else
                FDuongList(LiNCur, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Vong2(PcK, LiN, Dorongduong * 1.5, mau2, 1)
            End If

        End If

        If Not Lenhve = "kvgiaochien" Then
            solan += 1
        End If
        Ns5Point = LiNCur
    End Function

    Private Sub Vong2(Pc As IPosition71, LiP As List(Of IPosition71), Kc As Double, sMau As IColor71, Orer As Double)
        Dim LiN1 As New List(Of IPosition71)
        For i As Integer = 0 To LiP.Count - 1
            Dim P As IPosition71 = LiP(i).Move(Kc, FGoc(Pc, LiP(i)), 0)
            LiN1.Add(P)
        Next
        Dim LiNCur As List(Of IPosition71) = Curveline(LiN1, 4)
        FDuongList(LiNCur, 4294967295, "", 0, 0, sMau, Dorongduong * 1.5, False, 2, 0, Orer) ' 2, False, 2)
    End Sub

    Private Sub VungANQP(lists2 As List(Of IPosition71))
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(lists2(0).X, lists2(0).Y, 0, 2, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(lists2(1).X, lists2(1).Y, 0, 2, 0, 0, 0, 0)
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(lists2(2).X, lists2(2).Y, 0, 2, 0, 0, 0, 0)
        Dim Pc As IPosition71 = CenterPoint(P1, P3)
        Dim goc As Double = MkGoc(Pc, P2) * 180.0 / Math.PI + 180
        Dim kc As Double = FKc(P2, Pc)
        Dim P4 As IPosition71 = Pc.Move(kc, 270 - goc, 0)
        Dim lists3 As New List(Of IPosition71) From {P1, P2, P3, P4}
        FVungList(lists3, 4294967295, Dorongduong, mauXanh, 1, mauXanh, 1, "Green.gif", 10.0 / Tyle, 10.0 / Tyle, 60, False, 2, 1)
    End Sub

    Private Sub DgANQP(P As IPosition71)
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(P.X, P.Y + 0.005 * Tyle, 0, 2, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(P.X, P.Y - 0.005 * Tyle, 0, 2, 0, 0, 0, 0)
        Dim lists3 As New List(Of IPosition71) From {P2, P1}
        FDuongList(lists3, 4294967295, "", 0, 0, mau, Dorongduong * 1.6, True, 2, 0, 2) ' 2, False, 2)
    End Sub

#End Region

End Module



'Public Sub XetangLuu()
'    Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
'    Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
'    Dim Kc As Double = FKc(P1, P2)
'    Dim SizeXt As Double
'    If Lenhve = "ThapphaoXT" Then
'        SizeXt = Dorongduong * 4
'    Else
'        SizeXt = Dorongduong * 6
'    End If
'    Dim LiP1 As List(Of IPosition71) = ThreePoint(P2, FGoc(P1, P2), SizeXt)
'    Dim LiP2 As List(Of IPosition71) = ThreePoint(P2, 90 + FGoc(P1, P2), SizeXt * 1.7)
'    Dim LiXt As New List(Of IPosition71) From {LiP1(1), LiP2(1), LiP1(2), LiP2(2), LiP1(1)}
'    Dim GeoXT As IGeometry = ListtoGeo(LiXt).SpatialOperator.buffer(-Dorongduong * 1.5)
'    If Lenhve = "ThapphaoXT" Then
'        Dim LiPx2 As List(Of IPosition71) = ThreePoint(P2, 90 + FGoc(P1, P2), SizeXt * 1.7 + Dorongduong * 1.5)
'        Dim LiPtp1 As List(Of IPosition71) = ThreePoint(LiPx2(1), FGoc(P1, P2), SizeXt + Dorongduong * 1.5)
'        Dim LiPtp2 As List(Of IPosition71) = ThreePoint(LiPx2(2), FGoc(P1, P2), SizeXt + Dorongduong * 1.5)
'        Dim LiTp1 As New List(Of IPosition71) From {LiPtp1(1), LiPtp1(2), LiPtp2(2), LiPtp2(1), LiPtp1(1)}
'        FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    ElseIf Lenhve = "xetangbaccau" Then
'        Dim LiPtp1 As List(Of IPosition71) = ThreePoint(LiXt(0), 90 + FGoc(P1, P2), SizeXt * 1.7)
'        Dim LiPtp2 As List(Of IPosition71) = ThreePoint(LiXt(2), 90 + FGoc(P1, P2), SizeXt * 1.7)
'        Dim LiTp1 As New List(Of IPosition71) From {LiPtp1(1), LiPtp1(2)}
'        Dim LiTp2 As New List(Of IPosition71) From {LiPtp2(1), LiPtp2(2)}
'        FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'        FDuongList(LiTp2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    ElseIf Lenhve = "xetanghangnhe" Then
'        Dim LiPtp1 As List(Of IPosition71) = ThreePoint(P2, FGoc(P1, P2), SizeXt / 4)
'        Dim LiTp1 As New List(Of IPosition71) From {LiPtp1(1), LiPtp1(2)}
'        FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    ElseIf Lenhve = "xetanghangnang" Then
'        MCircleTQ(P2, 100, 4294967295, Dorongduong, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
'    ElseIf Lenhve = "xetangloinuoc" Or Lenhve = "xetangquetmin" Then
'        Dim LiPtp1, LiTp1 As List(Of IPosition71)
'        If Lenhve = "xetangloinuoc" Then
'            LiPtp1 = ThreePoint(LiXt(1), FGoc(P1, P2), SizeXt / 2.5)
'            LiTp1 = New List(Of IPosition71) From {LiPtp1(1), LiPtp1(2)}
'        Else
'            LiPtp1 = ThreePoint(LiXt(3), FGoc(P1, P2), SizeXt / 2.5)
'            Dim P3 As IPosition71 = P2.Move(Dorongduong * 2 + SizeXt * 1.7, FGoc(P1, P2), 0)
'            Dim LiPtp2 As List(Of IPosition71) = ThreePoint(P3, FGoc(P1, P2), SizeXt / 2.5)
'            LiTp1 = New List(Of IPosition71) From {LiPtp2(1), LiPtp1(1), LiPtp1(2), LiPtp2(2)}
'        End If
'        FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    ElseIf Lenhve = "Tanguidat" Then
'        Dim P3 As IPosition71 = P2.Move(Dorongduong * 3 + SizeXt * 1.7, FGoc(P1, P2), 0)
'        Dim LiPx2 As List(Of IPosition71) = LiPCircle(P3, Dorongduong * 3, FGoc(P1, P2), 10)
'        Dim LiPUi As New List(Of IPosition71)
'        AddPointToList(LiPUi, LiPx2, 15, 30)
'        FDuongList(LiPUi, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    ElseIf Lenhve = "xetangromooc" Then
'        Dim P3 As IPosition71 = LiXt(1).Move(Dorongduong * 4, FGoc(P2, P1), 0)
'        Dim P31 As IPosition71 = P3.Move(Dorongduong * 2, 90 + FGoc(P2, P1), 0)
'        Dim LiPx2 As List(Of IPosition71) = LiPCircle(P31, Dorongduong * 2, FGoc(P1, P2), 10)
'        Dim LiPUi As New List(Of IPosition71)
'        AddPointToList(LiPUi, LiPx2, 15, 30)
'        LiPUi.Reverse()
'        LiPUi.Add(LiXt(1))
'        FDuongList(LiPUi, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    ElseIf Lenhve = "TangchoBB" Or Lenhve = "tangmaccan" Then
'        Dim LiPtp1 As List(Of IPosition71)
'        If FGoc(P1, P2) > 90 And FGoc(P1, P2) < 180 Then
'            If Lenhve = "TangchoBB" Then
'                LiPtp1 = ThreePoint(LiXt(2), 90 + FGoc(P1, P2), SizeXt * 1.7)
'            Else
'                LiPtp1 = ThreePoint(LiXt(0), 90 + FGoc(P1, P2), SizeXt * 1.7)
'            End If
'        Else
'            If Lenhve = "TangchoBB" Then
'                LiPtp1 = ThreePoint(LiXt(0), 90 + FGoc(P1, P2), SizeXt * 1.7)
'            Else
'                LiPtp1 = ThreePoint(LiXt(2), 90 + FGoc(P1, P2), SizeXt * 1.7)
'            End If
'        End If
'        Dim LiTp1 As New List(Of IPosition71) From {LiPtp1(1), LiPtp1(2)}
'        If Lenhve = "TangchoBB" Then
'            FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
'        Else
'            FDuongList(LiTp1, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
'        End If


'    ElseIf Lenhve = "TangbiTieudiet" Or Lenhve = "TangHong" Then
'        Dim LiXThong1 As List(Of IPosition71) = ThreePoint(P2, 60 + FGoc(P1, P2), SizeXt * 1.3)
'        Dim LiTp1 As New List(Of IPosition71) From {LiXThong1(1), LiXThong1(2)}
'        If Lenhve = "TangHong" Then
'            FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'        Else
'            FDuongList(LiTp1, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
'            Dim LiXThong2 As List(Of IPosition71) = ThreePoint(P2, 120 + FGoc(P1, P2), SizeXt * 1.3)
'            Dim LiTp2 As New List(Of IPosition71) From {LiXThong2(1), LiXThong2(2)}
'            FDuongList(LiTp2, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
'        End If


'    ElseIf Lenhve = "tangsalay" Then
'        Dim LiPx2 As List(Of IPosition71) = LiPCircle(P2, Dorongduong * 1.5, FGoc(P1, P2), 10)
'        Dim LiXThong1 As List(Of IPosition71) = ThreePoint(P2, 60 + FGoc(P1, P2), SizeXt * 1.3)
'        Dim LiXThong2 As List(Of IPosition71) = ThreePoint(P2, 120 + FGoc(P1, P2), SizeXt * 1.3)
'        'Dim LiTp1 As New List(Of IPosition71) From {LiXThong1(1), LiXThong1(2)}
'        'FDuongList(LiTp1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'        Dim LiPUi As New List(Of IPosition71)
'        AddPointToList(LiPUi, LiPx2, 5, 22)
'        LiPUi.Add(LiXThong1(1))
'        LiPUi.Reverse()
'        LiPUi.Add(LiXThong2(2))
'        FDuongList(LiPUi, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
'        'ElseIf Lenhve = "" Then
'        'ElseIf Lenhve = "" Then
'        'ElseIf Lenhve = "" Then
'        'ElseIf Lenhve = "" Then
'        'ElseIf Lenhve = "" Then
'        'ElseIf Lenhve = "" Then

'        'ElseIf Lenhve = "" Then



'    End If
'    FDuongList(LiXt, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
'    FDuongList(GeoToList(GeoXT), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
'    SLenhve3DMs()
'End Sub

