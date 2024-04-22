Imports TerraExplorerX
Module mdlKhongquan

#Region "    Khongquan"
    Public Sub Sanbay()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({75.0, 0.0, 75.0, 15.0, 75.0, 30.0, 75.0, 45.0, 75.0, 60.0, 75.0, 75.0, 60.0, 75.0, 60.0, 285.0, 60.0, 270, 60.0, 255.0, 60.0, 105.0, 60.0, 90.0, 60.0, 75.1, 75.0, 75.08, 75.0, 90.0, 75.0, 105.0, 75.0, 120.0, 75.0, 135.0, 75.0, 150.0, 75.0, 165.0, 75.0, 180.0, 75.0, 195.0, 75.0, 210.0, 75.0, 225.0, 75.0, 240.0, 75.0, 255.0, 75.0, 270.0, 75.0, 285.0, 75.0, 300.0, 75.0, 315.0, 75.0, 330.0, 75.0, 345.0, 128, 45, 128, 135, 128, 225, 128, 315})
        Dim lists1 As New List(Of IPosition71)
        If Lenhve = "sanbaydachien" Then
            For i As Integer = 0 To 5
                lists1.Add(ArrayPoint(TQ, FrmMain.mPointClick, 4.0, Goc1)(i))
            Next

            For i As Integer = 13 To 31
                lists1.Add(ArrayPoint(TQ, FrmMain.mPointClick, 4.0, Goc1)(i))
            Next
        Else
            For i As Integer = 0 To 31
                lists1.Add(ArrayPoint(TQ, FrmMain.mPointClick, 4.0, Goc1)(i))
            Next
        End If
        FVungList(lists1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        If Lenhve = "sanbayvuotcap" Then
            MCircleTQ(FrmMain.mPointClick, 380, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(FrmMain.mPointClick, 380 + (1.5 * Dorongduong) / Tyle, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(FrmMain.mPointClick, 380 + (3.0 * Dorongduong) / Tyle, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "sanbaycap1" Then
            MCircleTQ(FrmMain.mPointClick, 380, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(FrmMain.mPointClick, 380 + (1.5 * Dorongduong) / Tyle, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "sanbaycap2" Then
            MCircleTQ(FrmMain.mPointClick, 380, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "sanbaytrenbien" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 4.0, Goc1), 32, 35, 4294967295, Dorongduong, mau, 1, mau, 0, "", 1, 1, 0, False, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub Hanhlangbay()
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai
        Dim Khoangcach As Double = FrmMain.sgworldMain.CoordServices.GetDistance3D(P1, P2)
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Khoangcach / 154.66
        Dim TQ As New List(Of Double)({72.8, 282.72, 80.49, 286.11, 82.21, 289.85, 72.16, 286.11, 72.16, 73.89, 82.25, 70.08, 80.5, 73.86, 72.77, 77.28, 72.76, 257.32, 72.76, 102.68, 80.48, 106.1, 82.23, 109.89, 72.15, 106.07, 72.15, 253.93, 82.23, 250.11, 80.48, 253.9, 29.21, 273.54, 14.47, 82.84, 13.13, 69.81, 32.22, 90.0, 13.28, 111.89, 14.53, 98.8, 29.24, 265.64, 29.21, 273.54, 29.5, 278.84, 13.13, 69.81, 14.47, 82.84})
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, Goc1), 8, 15, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, Goc1), 16, 22, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, Goc1), 23, 26, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Baihacanh()
        Dim Goc1 As Double = 0
        Dim TQ As New List(Of Double)({21.02, 41.8, 17.61, 52.7, 10.97, 13.2, 19.48, 172.6, 19.48, 184.4, 10.97, 346.8, 17.61, 307.3, 21.02, 318.2})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 12.0, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        MCircleTQ(FrmMain.mPointClick, 360, 4294967295, Dorongduong * 0.9, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(FrmMain.mPointClick, 360 - Dorongduong / Tyle, 4294967295, Dorongduong * 0.9, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Doboduongkhong()
        Dim k(100) As IPosition71
        Dim Khoangcach As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 50, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI '- Math.PI
        Dim hesoTyle As Double = Khoangcach / 290.0

        k(37) = pc.Move(-1.0 * Dorongduong + 77.755 * hesoTyle, 13.8 - Goc1, 0)
        k(38) = pc.Move(-1.0 * Dorongduong + 88.368 * hesoTyle, 28.9 - Goc1, 0)
        k(39) = pc.Move(-1.0 * Dorongduong + 106.206 * hesoTyle, 38.7 - Goc1, 0)
        k(40) = pc.Move(-1.0 * Dorongduong + 118.95 * hesoTyle, 44.0 - Goc1, 0)
        k(41) = pc.Move(-1.0 * Dorongduong + 129.657 * hesoTyle, 49.7 - Goc1, 0)
        k(42) = pc.Move(-1.0 * Dorongduong + 138.079 * hesoTyle, 55.7 - Goc1, 0)
        k(43) = pc.Move(-1.0 * Dorongduong + 144.029 * hesoTyle, 61.9 - Goc1, 0)
        k(44) = pc.Move(-1.0 * Dorongduong + 147.38 * hesoTyle, 68.2 - Goc1, 0)
        k(45) = pc.Move(-1.0 * Dorongduong + 148.062 * hesoTyle, 74.6 - Goc1, 0)
        k(46) = pc.Move(-1.0 * Dorongduong + 146.061 * hesoTyle, 80.9 - Goc1, 0)
        k(47) = pc.Move(-1.0 * Dorongduong + 141.417 * hesoTyle, 87.2 - Goc1, 0)
        k(48) = pc.Move(-1.0 * Dorongduong + 134.231 * hesoTyle, 93.3 - Goc1, 0)
        k(49) = pc.Move(-1.0 * Dorongduong + 124.658 * hesoTyle, 99.2 - Goc1, 0)
        k(50) = pc.Move(-1.0 * Dorongduong + 115.113 * hesoTyle, 104.1 - Goc1, 0)
        k(51) = pc.Move(-1.0 * Dorongduong + 106.163 * hesoTyle, 109.6 - Goc1, 0)

        k(52) = pc.Move(-1.0 * Dorongduong + 97.981 * hesoTyle, 115.9 - Goc1, 0)
        k(53) = pc.Move(-1.0 * Dorongduong + 84.844 * hesoTyle, 131.5 - Goc1, 0)
        k(54) = pc.Move(-1.0 * Dorongduong + 77.823 * hesoTyle, 150.6 - Goc1, 0)
        k(55) = pc.Move(-1.0 * Dorongduong + 78.607 * hesoTyle, 171.1 - Goc1, 0)
        k(56) = pc.Move(-1.0 * Dorongduong + 86.984 * hesoTyle, 189.6 - Goc1, 0)
        k(57) = pc.Move(-1.0 * Dorongduong + 93.446 * hesoTyle, 197.5 - Goc1, 0)
        k(58) = pc.Move(-1.0 * Dorongduong + 105.894 * hesoTyle, 209.4 - Goc1, 0)
        k(59) = pc.Move(-1.0 * Dorongduong + 117.026 * hesoTyle, 220.4 - Goc1, 0)
        k(60) = pc.Move(-1.0 * Dorongduong + 126.521 * hesoTyle, 230.8 - Goc1, 0)
        k(61) = pc.Move(-1.0 * Dorongduong + 134.138 * hesoTyle, 240.9 - Goc1, 0)
        k(62) = pc.Move(-1.0 * Dorongduong + 139.703 * hesoTyle, 250.7 - Goc1, 0)

        k(63) = pc.Move(-1.0 * Dorongduong + 143.09 * hesoTyle, 260.4 - Goc1, 0)
        k(64) = pc.Move(-1.0 * Dorongduong + 144.227 * hesoTyle, 270.0 - Goc1, 0)
        k(65) = pc.Move(-1.0 * Dorongduong + 143.09 * hesoTyle, 279.6 - Goc1, 0)
        k(66) = pc.Move(-1.0 * Dorongduong + 139.703 * hesoTyle, 289.3 - Goc1, 0)
        k(67) = pc.Move(-1.0 * Dorongduong + 134.138 * hesoTyle, 299.1 - Goc1, 0)
        k(68) = pc.Move(-1.0 * Dorongduong + 126.521 * hesoTyle, 309.2 - Goc1, 0)
        k(69) = pc.Move(-1.0 * Dorongduong + 114.894 * hesoTyle, 318.8 - Goc1, 0)
        k(70) = pc.Move(-1.0 * Dorongduong + 101.989 * hesoTyle, 329.1 - Goc1, 0)
        k(71) = pc.Move(-1.0 * Dorongduong + 88.14 * hesoTyle, 340.5 - Goc1, 0)
        k(72) = pc.Move(-1.0 * Dorongduong + 77.039 * hesoTyle, 358.5 - Goc1, 0)
        FDuong(k, 37, 51, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        FDuong(k, 52, 62, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        FDuong(k, 63, 72, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        loaiKH = "2120029"
        fileImage = PathData & "\2X\" & loaiKH & Ta_Doiphuong & tenGiaidoan
        FrmMain.fLabelStyleMain.PivotAlignment = "Bottom, Center"
        FrmMain.mPoint.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
        Dim Doituong = FrmMain.sgworldMain.Creator.CreateLabel(pc, "", fileImage, FrmMain.fLabelStyleMain, GroupBac2Main, tenKH)
        Doituong.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
        Doituong.Position.Altitude = Tyle * 0.2
        Doituong.Tooltip.Text = mota
        mLabelArray.Add(Doituong)


        Dim TQ1 As New List(Of Double)({77.755, 13.8, 88.368, 28.9, 106.206, 38.7, 118.95, 44.0, 129.657, 49.7, 138.079, 55.7, 144.029, 61.9, 147.38, 68.2, 148.062, 74.6, 146.061, 80.9, 141.417, 87.2, 134.231, 93.3, 124.658, 99.2, 115.113, 104.1, 106.163, 109.6, 97.981, 115.9, 84.844, 131.5, 77.823, 150.6, 78.607, 171.1, 86.984, 189.6, 93.446, 197.5, 105.894, 209.4, 117.026, 220.4, 126.521, 230.8, 134.138, 240.9, 139.703, 250.7, 143.09, 260.4, 144.227, 270.0, 143.09, 279.6, 139.703, 289.3, 134.138, 299.1, 126.521, 309.2, 114.894, 318.8, 101.989, 329.1, 88.14, 340.5, 77.039, 358.5})
        'Dim TQ2 As New List(Of Double)({77.755, 13.8, 88.368, 28.9, 106.206, 38.7, 118.95, 44.0, 129.657, 49.7, 138.079, 55.7, 144.029, 61.9, 147.38, 68.2, 148.062, 74.6, 146.061, 80.9, 141.417, 87.2, 134.231, 93.3, 124.658, 99.2, 115.113, 104.1, 106.163, 109.6, 97.981, 115.9, 84.844, 131.5, 77.823, 150.6, 78.607, 171.1, 86.984, 189.6, 93.446, 197.5, 105.894, 209.4, 117.026, 220.4, 126.521, 230.8, 134.138, 240.9, 139.703, 250.7, 143.09, 260.4, 144.227, 270.0, 143.09, 279.6, 139.703, 289.3, 134.138, 299.1, 126.521, 309.2, 114.894, 318.8, 101.989, 329.1, 88.14, 340.5, 77.039, 358.5})
        ''ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1)
        ''ArrayPoint4(TQ2, pc, -Dorongduong, hesoTyle / Tyle, Goc1)
        ''For i As Integer = 0 To ArrayPoint4(TQ2, pc, -Dorongduong, hesoTyle / Tyle, Goc1).Count - 1
        ''    ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1).ToList.Add(ArrayPoint4(TQ2, pc, -Dorongduong, hesoTyle / Tyle, Goc1)(i))
        ''Next
        '' ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1).Union(ArrayPoint4(TQ2, pc, -Dorongduong, hesoTyle / Tyle, Goc1))
        FDuong(ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1), 0, 14, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ', False) 
        FDuong(ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1), 15, 25, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ', False) 
        FDuong(ArrayPoint(TQ1, pc, hesoTyle / Tyle, Goc1), 26, 35, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ', False) 
        'FDuong(ArrayPoint4(TQ2, pc, -Dorongduong * hesoTyle / Tyle, hesoTyle / Tyle, Goc1), 0, 14, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        'FDuong(ArrayPoint4(TQ2, pc, -Dorongduong * hesoTyle / Tyle, hesoTyle / Tyle, Goc1), 15, 25, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        'FDuong(ArrayPoint4(TQ2, pc, -Dorongduong * hesoTyle / Tyle, hesoTyle / Tyle, Goc1), 26, 35, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        'SLenhve3DMs()
    End Sub

    Public Sub HuongTCKQchienluoc()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({34.45, 0.0, 246.36, 81.96, 252.31, 75.2, 313.17, 90.0, 253.38, 104.74, 247.46, 98.0, 160.33, 102.41, 158.18, 98.16, 258.03, 94.99, 259.69, 98.18, 295.63, 90.0, 258.53, 81.88, 256.92, 84.99, 25.46, 28.12, 25.46, 151.88, 158.18, 98.16, 160.32, 102.41, 34.45, 180.0, 158.18, 98.16, 258.03, 94.99, 259.69, 98.18, 295.63, 90.0, 258.53, 81.88, 256.92, 84.99, 25.46, 28.12, 25.46, 151.88, 158.18, 98.16, 157.07, 94.55, 25.28, 119.51, 25.28, 60.49, 263.35, 87.29, 263.54, 86.52, 281.02, 90.0, 263.65, 93.86, 263.35, 92.71, 157.08, 94.55})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 18, 35, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HuongTCKQchienthuat()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({35.96, 0.0, 113.91, 76.58, 111.73, 82.6, 25.84, 27.67, 25.87, 152.36, 111.77, 97.54, 113.98, 103.56, 35.96, 180.0, 111.73, 82.6, 25.84, 27.67, 25.87, 152.36, 111.77, 97.54, 110.9, 92.4, 25.08, 118.7, 25.05, 61.42, 110.89, 87.75, 131.76, 79.14, 222.25, 85.64, 213.54, 80.7, 329.29, 90.0, 214.19, 99.45, 222.57, 94.5, 131.82, 101.0, 130.06, 95.79, 244.21, 90.83, 237.91, 93.57, 286.82, 90.0, 237.73, 86.54, 244.36, 89.32, 130.03, 84.35, 129.43, 88.78, 194.39, 90.0, 129.43, 91.37})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 16, 29, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 8, 15, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 23, 32, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HuongTCKQchienthuat2()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({9.14, 0.0, 141.63, 86.3, 141.63, 93.7, 9.14, 180.0, 162.3, 86.77, 242.6, 87.84, 234.67, 85.48, 326.56, 90.0, 235.1, 94.53, 242.82, 92.16, 162.3, 93.23, 9.14, 180.0, 141.63, 93.7, 142.21, 96.37, 18.56, 180.0, 162.3, 93.23, 242.82, 92.16, 238.91, 93.32, 162.77, 95.41})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 0, 3, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 4, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 11, 14, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 9.0, Goc1), 15, 18, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TcKQHQ()
        Dim Goc1 As Double, Goc2 As Double, Goc3 As Double
        FrmMain.Tinhgoc3()
        Goc1 = Math.PI - (Phuongvi * 180.0 / Math.PI - 270)
        Goc3 = Math.PI - (Phuongvi1 * 180.0 / Math.PI - 270)
        Dim Khoangcach1 As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim p2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim hesoTyle As Double = Khoangcach1 / 790.0
        Dim Pchu As IPosition71 = p2.Move(290.0 * hesoTyle, 0.0 + Goc3, 0)
        Dim TQ1 As New List(Of Double)({-59.2, 0.0, 325.48, 158.89, 285.35, 168.18, 798.01, 171.36, 797.03, 172.51, 257.08, 171.21, 285.73, 162.75, 96.67, 180.0, 285.87, 196.7, 257.13, 188.23, 795.97, 186.89, 798.06, 188.04, 285.42, 191.26, 325.61, 200.54, 797.03, 172.51, 257.08, 171.21, 285.73, 162.75, 96.67, 180.0, 285.87, 196.7, 257.13, 188.23, 795.97, 186.89, 794.54, 185.95, 234.83, 185.25, 254.84, 192.71, 128.02, 180.0, 254.69, 166.76, 234.79, 174.21, 795.47, 173.44, 308.65, 180.0, 393.17, 176.94, 380.1, 178.73, 410.98, 178.83, 412.45, 175.02, 429.18, 175.22, 427.77, 178.88, 517.45, 179.07, 517.45, 180.93, 427.77, 181.12, 429.18, 184.78, 412.45, 184.98, 410.98, 181.17, 380.1, 181.27, 393.17, 183.06})
        Dim TQ2 As New List(Of Double)({59.48, 0.0, 251.09, 23.06, 216.42, 13.43, 564.25, 5.11, 562.0, 0.15, 544.52, 0.16, 545.51, 3.44, 186.93, 10.1, 202.71, 16.4, 94.41, 0.0, 202.54, 343.09, 187.85, 348.92, 545.72, 356.21, 544.52, 359.54, 562.01, 359.55, 564.55, 354.55, 217.21, 345.72, 250.95, 336.38, 544.52, 0.16, 545.51, 3.44, 186.93, 10.1, 202.71, 16.4, 94.41, 0.0, 202.54, 343.09, 187.85, 348.92, 545.72, 356.21, 544.52, 359.54, 532.56, 359.52, 533.11, 357.41, 168.18, 351.76, 171.7, 349.83, 118.29, 0.0, 171.87, 9.71, 167.21, 7.14, 532.97, 2.23, 532.56, 0.18})
        Dim TQ3 As New List(Of Double)({103.0, 0.0, 103.0, 15.0, 103.0, 30.0, 103.0, 45.0, 103.0, 60.0, 103.0, 75.0, 103.0, 90.0, 103.0, 105.0, 103.0, 120.0, 103.0, 135.0, 103.0, 150.0, 103.0, 165.0, 103.0, 180.0, 103.0, 195.0, 103.0, 210.0, 103.0, 225.0, 103.0, 240.0, 103.0, 255.0, 103.0, 270.0, 103.0, 285.0, 103.0, 300.0, 103.0, 315.0, 103.0, 330.0, 103.0, 345.0, 103.0, 359.45, 86.95, 359.48, 86.95, 345.0, 86.95, 330.0, 86.95, 315.0, 86.95, 300.0, 86.95, 285.0, 86.95, 270.0, 86.95, 255.0, 86.95, 240.0, 86.95, 225.0, 86.95, 210.0, 86.95, 195.0, 86.95, 180.0, 86.95, 165.0, 86.95, 150.0, 86.95, 135.0, 86.95, 120.0, 86.95, 105.0, 86.95, 90.0, 86.95, 75.0, 86.95, 60.0, 86.95, 45.0, 86.95, 30.0, 86.95, 15.0, 86.95, 0.0, 60.0, 0.0, 60.0, 25.0, 60.0, 50.0, 60.0, 75.0, 60.0, 100.0, 60.0, 125.0, 60.0, 150.0, 60.0, 175.0, 60.0, 200.0, 60.0, 225.0, 60.0, 250.0, 60.0, 275.0, 60.0, 300.0, 60.0, 325.0, 60.0, 350.0, 60.0, 359.46, 45.0, 359.48, 45.0, 340.0, 45.0, 310.0, 45.0, 280.0, 45.0, 250.0, 45.0, 220.0, 45.0, 190.0, 45.0, 160.0, 45.0, 130.0, 45.0, 100.0, 45.0, 70.0, 45.0, 40.0, 45.0, 10.0, 45.0, 0.0})
        Dim TQ4 As New List(Of Double)({89.93, 6.3, 89.93, 15.0, 89.93, 30.0, 89.93, 45.0, 89.93, 60.0, 89.93, 75.0, 89.93, 90.0, 89.93, 98.86, 89.93, 171.19, 89.93, 180.0, 89.93, 195.0, 89.93, 210.0, 89.93, 225.0, 89.93, 240.0, 89.93, 255.0, 89.93, 270.0, 89.93, 285.0, 89.93, 300.0, 89.93, 315.0, 89.93, 330.0, 89.93, 345.0, 89.93, 351.16, 86.43, 281.41, 86.34, 265.21, 58.37, 297.72, 58.16, 263.25, 86.31, 249.65, 86.52, 237.01, 58.34, 242.97, 58.66, 225.0, 87.0, 225.0, 86.47, 213.47, 58.41, 207.79, 58.16, 186.75, 86.31, 200.35, 86.26, 186.24, 86.18, 83.8, 86.21, 69.68, 58.07, 83.31, 58.3, 62.25, 86.36, 56.55, 86.89, 45.0, 58.56, 45.0, 58.3, 27.7, 86.37, 33.42, 86.21, 20.32, 58.07, 6.69, 58.34, 332.18, 135.04, 180.0, 203.24, 175.25, 194.06, 178.37, 288.64, 176.98, 288.58, 182.81, 194.15, 181.27, 203.47, 184.38})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, p2, hesoTyle / Tyle, -Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, p2, hesoTyle / Tyle, -Goc3))
        ArraytoList(liP1, ArrayPoint(TQ3, p2, hesoTyle / Tyle, -Goc2))
        ArraytoList(liP1, ArrayPoint(TQ4, p2, hesoTyle / Tyle, -Goc1))
        FVungPoint(liP1.ToArray, 0, 13, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 14, 27, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(liP1.ToArray, 43, 60, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 61, 78, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 79, 128, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 159, 206, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        If Lenhve = "danhhuongchuyeu" Then
            FVungPoint(liP1.ToArray, 207, 213, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(liP1.ToArray, 129, 158, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "khongquandanhbien" Then
            FVungPoint(liP1.ToArray, 28, 42, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(liP1.ToArray, 129, 158, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            mText = FLabel(Pchu, 0.0, hesoTyle, Goc2, "ĐĐB", "", mau3, 0, 0, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub KvGiaochien()
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim Khoangcach As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim hesoTyle As Double = Khoangcach / 500.0
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({236.48, 273.0, 216.86, 278.0, 184.43, 287.3, 153.84, 299.0, 127.11, 314.4, 107.71, 334.9, 100.38, 0.1, 107.71, 25.3, 127.11, 45.8, 153.84, 61.1, 184.43, 72.8, 200.41, 78.0, 202.49, 76.6, 225.9, 85.5, 191.45, 79.5, 196.78, 79.0, 180.73, 74.0, 149.82, 62.4, 122.59, 47.0, 102.62, 26.1, 94.99, 0.0, 102.62, 333.9, 122.59, 313.0, 149.82, 297.6, 180.73, 286.0, 213.35, 276.9, 232.74, 272.0, 230.74, 271.4, 211.3, 276.3, 178.61, 285.4, 147.55, 296.8, 120.07, 312.2, 99.78, 333.3, 91.98, 0.0, 99.78, 26.7, 120.07, 47.8, 147.55, 63.2, 178.61, 74.6, 261.1, 270.0, 301.19, 268.6, 298.61, 269.5, 360.25, 269.6, 360.25, 270.4, 298.64, 270.5, 301.19, 271.4, 360.25, 270.4, 360.32, 271.2, 298.64, 270.5, 236.48, 93.0, 216.86, 98.0, 184.43, 107.3, 153.84, 119.0, 127.11, 134.4, 107.71, 154.9, 100.38, -179.9, 107.71, -154.7, 127.11, -134.2, 153.84, -118.9, 184.43, -107.2, 200.41, -102.0, 202.49, -103.4, 225.9, -94.5, 191.45, -100.5, 196.78, -101.0, 180.73, -106.0, 149.82, -117.6, 122.59, -133.0, 102.62, -153.9, 94.99, -180.0, 102.62, 153.9, 122.59, 133.0, 149.82, 117.6, 180.73, 106.0, 213.35, 96.9, 232.74, 92.0, 230.74, 91.4, 211.3, 96.3, 178.61, 105.4, 147.55, 116.8, 120.07, 132.2, 99.78, 153.3, 91.98, -180.0, 99.78, -153.3, 120.07, -132.2, 147.55, -116.8, 178.61, -105.4, 261.1, 90.0, 301.19, 88.6, 298.61, 89.5, 360.25, 89.6, 360.25, 90.4, 298.64, 90.5, 301.19, 91.4, 360.25, 90.4, 360.32, 91.2, 298.64, 90.5})
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 0, 26, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 38, 44, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 15, 37, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 45, 47, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 48, 74, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 86, 92, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 63, 85, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, Pc, hesoTyle / Tyle, -Goc1), 93, 95, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Khuvucmaybayhoatdong()

#Region " Vong tuan tieu chinh"
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim pC As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim p1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim p2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai
        Dim Bk As Double '= FrmMain.sgworldMain.CoordServices.GetDistance(p1.X, p1.Y, p2.X, p2.Y) / 10
        Dim Drong As Double
        If Lenhve = "maybayhoatdong" Or Lenhve = "maybaychivien" Then
            Drong = Dorongduong * 2.0
            Bk = FrmMain.sgworldMain.CoordServices.GetDistance(p1.X, p1.Y, p2.X, p2.Y) / 10
        Else
            Drong = Dorongduong '* 0.8
            Bk = FrmMain.sgworldMain.CoordServices.GetDistance(p1.X, p1.Y, p2.X, p2.Y) / 15
        End If

        Dim mChia As Double
        If Lenhve = "maybaychivien" Then
            mChia = 1.6
        Else
            mChia = 2.0
        End If

        Dim t1 As IPosition71 = p1.Move(Bk, 270 - Goc1, 0)
        Dim t2 As IPosition71 = p2.Move(Bk, 90 - Goc1, 0)

        Dim k1(40) As IPosition71, k11(40) As IPosition71, k12(40) As IPosition71, K2(40) As IPosition71, K21(40) As IPosition71, K22(40) As IPosition71
        Dim liP1 As New List(Of IPosition71), liP11 As New List(Of IPosition71), liP12 As New List(Of IPosition71), liP22 As New List(Of IPosition71)
        Dim LiTQ1 As New List(Of IPosition71)
        Dim LiChivien1 As New List(Of IPosition71), LiChivien11 As New List(Of IPosition71), LiChivien12 As New List(Of IPosition71),
            LiChivien2 As New List(Of IPosition71), LiChivien21 As New List(Of IPosition71), LiChivien22 As New List(Of IPosition71)

        Dim Pk1 As IPosition71 = t1.Move(Bk, 345 - Goc1, 0)
        liP1.Add(Pk1)
        Pk1 = t1.Move(Bk - Drong, 345 - Goc1, 0)
        liP11.Add(Pk1)

        For i As Integer = 0 To 18
            k1(i) = t1.Move(Bk, i * 10 - Goc1, 0) 't1.Move(kC / 10, I * 10 - Goc1, 0)
            liP1.Add(k1(i))
            LiChivien1.Add(k1(i))
            k11(i) = t1.Move(Bk - Drong, i * 10 - Goc1, 0) 't1.Move(kC / 10, I * 10 - Goc1, 0)
            liP11.Add(k11(i))
            LiChivien11.Add(k11(i))
            k12(i) = t1.Move(Bk - Drong * mChia, i * 10 - Goc1, 0) 't1.Move(kC / 10, I * 10 - Goc1, 0)
            liP12.Add(k12(i))
            LiChivien12.Add(k12(i))
        Next

        Pk1 = t1.Move(Bk, 195 - Goc1, 0)
        liP1.Add(Pk1)
        Pk1 = t1.Move(Bk - Drong, 195 - Goc1, 0)
        liP11.Add(Pk1)
        Dim Pk12 As IPosition71 = t1.Move(Bk - Drong * mChia, 195 - Goc1, 0)
        liP12.Add(Pk12)

        Dim Pk2 As IPosition71 = t2.Move(Bk, 15 - Goc1, 0)
        liP11.Add(Pk2)
        Pk2 = t2.Move(Bk - Drong, 15 - Goc1, 0)
        liP1.Add(Pk2)
        Dim Pk21 As IPosition71 = t2.Move(Bk - Drong * mChia, 15 - Goc1, 0)
        liP22.Add(Pk21)

        For i As Integer = 18 To 0 Step -1
            K2(i) = t2.Move(Bk, (180 + i * 10) - Goc1, 0) 't1.Move(kC / 10, I * 10 - Goc1, 0)
            liP11.Add(K2(i))
            LiChivien2.Add(K2(i))
            K21(i) = t2.Move(Bk - Drong, (180 + i * 10) - Goc1, 0) 't1.Move(kC / 10, I * 10 - Goc1, 0)
            liP1.Add(K21(i))
            LiChivien21.Add(K21(i))
            K22(i) = t2.Move(Bk - Drong * 2.0, (180 + i * 10) - Goc1, 0) 't1.Move(kC / 10, I * 10 - Goc1, 0)
            liP22.Add(K22(i))
            LiChivien22.Add(K22(i))
        Next

        If Lenhve = "maybaychivien" Then
            LiChivien1.Reverse()
            LiChivien11.Reverse()
            LiChivien12.Reverse()
            For i As Integer = 0 To 18
                LiChivien1.Add(LiChivien2(i))
                LiChivien11.Add(LiChivien21(i))
                LiChivien12.Add(LiChivien22(i))
            Next
            Dim Chivien1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (LiChivien1(0).X + LiChivien1(37).X), 0.5 * (LiChivien1(0).Y + LiChivien1(37).Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim Chivien2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (LiChivien11(0).X + LiChivien11(37).X), 0.5 * (LiChivien11(0).Y + LiChivien11(37).Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim Chivien3 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (LiChivien12(0).X + LiChivien12(37).X), 0.5 * (LiChivien12(0).Y + LiChivien12(37).Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim V1 As IPosition71 = LiChivien1(0).Move(Bk, 270 - Goc1, 0)
            Dim V2 As IPosition71 = LiChivien11(0).Move(Bk, 270 - Goc1, 0)
            Dim V3 As IPosition71 = LiChivien12(0).Move(Bk, 270 - Goc1, 0)
            Dim C1 As IPosition71 = LiChivien1(37).Move(Bk, 90 - Goc1, 0)
            Dim C2 As IPosition71 = LiChivien11(37).Move(Bk, 90 - Goc1, 0)
            Dim C3 As IPosition71 = LiChivien12(37).Move(Bk, 90 - Goc1, 0)
            LiChivien1.Add(C1)
            LiChivien11.Add(C2)
            LiChivien12.Add(C3)

            LiChivien1.Reverse()
            LiChivien11.Reverse()
            LiChivien12.Reverse()
            LiChivien1.Add(V1)
            LiChivien11.Add(V2)
            LiChivien12.Add(V3)

            LiChivien11.Reverse()
            For i As Integer = 0 To 39
                LiChivien1.Add(LiChivien11(i))
                LiChivien12.Add(LiChivien11(i))
            Next
            FVungList(LiChivien1, 4294967295, 0, Nothing, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungList(LiChivien12, 4294967295, 0, Nothing, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)

            Dim F1 As IPosition71 = Chivien1.Move(Drong * 3, 270 - Goc1, 0)
            Dim F2 As IPosition71 = Chivien2.Move(Drong * 3, 270 - Goc1, 0)

            Dim D1 As IPosition71 = F1.Move(Drong, 90 - Goc1, 0)
            Dim D2 As IPosition71 = F2.Move(Drong, 90 - Goc1, 0)
            Dim D3 As IPosition71 = F1.Move(Drong * 2, 90 - Goc1, 0)
            Dim D4 As IPosition71 = F2.Move(Drong * 2, 90 - Goc1, 0)
            Dim D5 As IPosition71 = F1.Move(Drong * 4, 90 - Goc1, 0)
            Dim D6 As IPosition71 = F2.Move(Drong * 4, 90 - Goc1, 0)

            Dim PT1 As IPosition71 = D1.Move(Drong * 4, 180 - Goc1, 0)
            Dim PT2 As IPosition71 = D2.Move(Drong * 4, 0 - Goc1, 0)
            Dim PT3 As IPosition71 = D3.Move(Drong * 4, 180 - Goc1, 0)
            Dim PT4 As IPosition71 = D4.Move(Drong * 4, 0 - Goc1, 0)

            Dim K111 As IPosition71 = Chivien1.Move(Drong * 13, 270 - Goc1, 0)
            Dim K211 As IPosition71 = Chivien2.Move(Drong * 13, 270 - Goc1, 0)

            Dim LiMT As List(Of IPosition71) = DMuiten(D5, D6, Goc1 + 170.0, Drong, Drong)
            LiMT.Reverse()
            LiMT.Add(D3)
            LiMT.Add(PT3)
            LiMT.Add(PT1)
            LiMT.Add(D1)
            LiMT.Add(K111)
            LiMT.Add(K211)
            LiMT.Add(D2)
            LiMT.Add(PT2)
            LiMT.Add(PT4)
            LiMT.Add(D4)
            FVungList(LiMT, 4294967295, 0, Nothing, 0, mau, 1, "", 1, 1, 0, False, 2, 2)

            Dim T121 As IPosition71 = PT1.Move(Drong, 270 - Goc1, 0)
            Dim T41 As IPosition71 = PT2.Move(Drong, 270 - Goc1, 0)
            Dim LiDemMB As New List(Of IPosition71) From
                {PT1, T121, T41, PT2}
            FVungList(LiDemMB, 4294967295, 0, Nothing, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)

        End If 'May bay chi v'en

        Pk2 = t2.Move(Bk, 165 - Goc1, 0)
            liP11.Add(Pk2)
            Pk2 = t2.Move(Bk - Drong, 165 - Goc1, 0)
            liP1.Add(Pk2)
            Dim LiD1 As List(Of IPosition71) = DMuiten(liP1(0), liP11(0), Goc1, Drong, Bk / 12)
            Dim LiD2 As List(Of IPosition71) = DMuiten(liP11(41), liP1(41), Goc1 + 180, Drong, Bk / 12)
            For i As Integer = LiD1.Count - 1 To 0 Step -1
                LiTQ1.Add(LiD1(i))
            Next

            For i As Integer = 0 To liP1.Count - 1
                LiTQ1.Add(liP1(i))
            Next

            For i As Integer = LiD2.Count - 1 To 0 Step -1
                LiTQ1.Add(LiD2(i))
            Next

            For i As Integer = liP11.Count - 1 To 0 Step -1
                LiTQ1.Add(liP11(i))
            Next

            Dim liP3 As New List(Of IPosition71), liP4 As New List(Of IPosition71)
            For i As Integer = 0 To 20
                liP3.Add(liP11(i))
            Next
            For i As Integer = liP1.Count - 1 To 21 Step -1
                liP4.Add(liP1(i))
            Next

            Dim LiTQ2 As New List(Of IPosition71)
            For i As Integer = 0 To liP3.Count - 1
                LiTQ2.Add(liP3(i))
            Next
            For i As Integer = 0 To liP22.Count - 1
                LiTQ2.Add(liP22(i))
            Next
            For i As Integer = 0 To liP4.Count - 1
                LiTQ2.Add(liP4(i))
            Next

            For i As Integer = liP12.Count - 1 To 0 Step -1
                LiTQ2.Add(liP12(i))
            Next
            Dim mRing1 As IGeometry = FrmMain.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(ListtoAarray(LiTQ1))
            Dim geo1 As IGeometry = FrmMain.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(mRing1, Nothing)
            Dim mRing2 As IGeometry = FrmMain.sgworldMain.Creator.GeometryCreator.CreateLinearRingGeometry(ListtoAarray(LiTQ2))
            Dim geo2 As IGeometry = FrmMain.sgworldMain.Creator.GeometryCreator.CreatePolygonGeometry(mRing2, Nothing)
#End Region

        liP22.Reverse()
        liP11.Reverse()
        Dim liDm1 As New List(Of IPosition71), liDm2 As New List(Of IPosition71)
            For i As Integer = 0 To 20
                liDm1.Add(liP11(i))
                liDm2.Add(liP1(i))
            Next
        Dim P11 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (liDm2(20).X + liP4(20).X), 0.5 * (liDm2(20).Y + liP4(20).Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P21 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (liP3(20).X + liDm1(20).X), 0.5 * (liP3(20).Y + liDm1(20).Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)

        Dim DuoiV1 As IPosition71, DuoiV2 As IPosition71, DuoiV3 As IPosition71, DuoiV4 As IPosition71
        Dim fileGif As String
        If Lenhve = "toTSsucsao" Or Lenhve = "tuantraBP" Or Lenhve = "toTSDPsucsao" Then
            DuoiV1 = P11.Move(0.75 * Bk, 105 - Goc1, 0)
            DuoiV2 = P21.Move(0.75 * Bk, 105 - Goc1, 0)
            DuoiV3 = P11.Move(0.75 * Bk, 285 - Goc1, 0)
            DuoiV4 = P21.Move(0.75 * Bk, 285 - Goc1, 0)

            If Lenhve = "tuantraBP" Then
                fileGif = "LangCD.gif"
            ElseIf Lenhve = "toTSDPsucsao" Then
                fileGif = "NenDo.gif"
            Else
                fileGif = ""
            End If
            Dim Pc1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (P11.X + P21.X), 0.5 * (P11.Y + P21.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            MCircleTQ(Pc1, Bk * 1.5, 4294967295, Dorongduong * 0.9, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(Pc1, 1.5 * Bk - (Drong * 2), 4294967295, Dorongduong * 0.9, mau2, 1, mau2, 0, fileGif, 5 * Tyle, 5 * Tyle, 60, False, 2, 1)
        ElseIf Lenhve = "toanTSsucsao" Then
            DuoiV1 = P11.Move(97 * Tyle * 3.0, 105 - Goc1, 0)
            DuoiV2 = P21.Move(97 * Tyle * 3.0, 105 - Goc1, 0)
            DuoiV3 = P11.Move(97 * Tyle * 3.0, 285 - Goc1, 0)
            DuoiV4 = P21.Move(97 * Tyle * 3.0, 285 - Goc1, 0)
            Dim TQ As New List(Of Double)({9.55, 0.0, 103.7, 0.0, 109.56, 15.89, 124.99, 35.22, 148.71, 52.05, 176.51, 65.23, 206.23, 75.96, 236.59, 85.08, 253.54, 90.0, 236.59, 94.92, 206.23, 104.04, 176.51, 114.77, 148.71, 127.95, 124.99, 144.78, 109.56, 164.11, 103.7, 180.0, 9.35, 0.0, 31.42, 72.69, 81.04, 158.27, 98.94, 137.02, 125.02, 120.14, 154.17, 107.76, 181.08, 98.81, 200.37, 93.14, 213.21, 90.0, 198.33, 86.31, 184.41, 82.04, 154.17, 72.24, 125.02, 59.86, 98.94, 42.98, 81.04, 21.73, 31.48, 72.34})
            Dim Pc11 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (P11.X + P21.X), 0.5 * (P11.Y + P21.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim Pc2 As IPosition71 = Pc11.Move(350 * Tyle, 285 - Goc1, 0)
            FVungPoint(ArrayPoint(TQ, Pc2, 3.0, Goc1 - 14), 0, 31, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            Dim TQ1 As New List(Of Double)({31.42, 72.69, 81.04, 158.27, 98.94, 137.02, 125.02, 120.14, 154.17, 107.76, 181.08, 98.81, 200.37, 93.14, 213.21, 90.0, 198.33, 86.31, 184.41, 82.04, 154.17, 72.24, 125.02, 59.86, 98.94, 42.98, 81.04, 21.73, 31.48, 72.34, 55.82, 80.15, 73.18, 48.73, 79.44, 53.18, 107.75, 68.84, 137.82, 79.71, 168.17, 88.27, 174.2, 90.0, 168.17, 91.73, 137.82, 100.29, 107.75, 111.16, 79.44, 126.82, 73.18, 131.27, 55.79, 80.35})
            FVungPoint(ArrayPoint(TQ1, Pc2, 3.0, Goc1 - 14.5), 0, 27, 4294967295, 0, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
        ElseIf Lenhve = "tauBPtuantra" Then
            fileGif = "LangCD.gif"
            DuoiV1 = P11.Move(250 * Tyle * 3.0, 105 - Goc1, 0)
            DuoiV2 = P21.Move(250 * Tyle * 3.0, 105 - Goc1, 0)
            DuoiV3 = P11.Move(250 * Tyle * 3.0, 285 - Goc1, 0)
            DuoiV4 = P21.Move(250 * Tyle * 3.0, 285 - Goc1, 0)
            Dim Pc11 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (P11.X + P21.X), 0.5 * (P11.Y + P21.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim Pc2 As IPosition71 = Pc11.Move(750.0 * Tyle, 285 - Goc1, 0)
            'Dim Pc2 As IPosition71 = Pc11.Move(Val(FrmMain.txtGroup.Text) * Tyle, 285 - Goc1, 0)
            Dim TQ As New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51})
            FVungPoint(ArrayPoint(TQ, Pc2, 3.0, Goc1 - 14.5), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            Dim TQ1 As New List(Of Double)({97.91, 34.75, 368.88, 77.4, 482.81, 90.0, 368.88, 102.6, 85.85, 159.55, 85.85, 20.51, 97.85, 34.71, 78.1, 134.49, 364.14, 98.64, 439.95, 90.0, 364.14, 81.36, 78.17, 45.56})
            FVungPoint(ArrayPoint(TQ1, Pc2, 3.0, Goc1 - 14.5), 0, 11, 4294967295, 0, mauXanh, 0, mauXanh, 1, "", 1, 1, 0, False, 2, 1)
            FVungPoint(ArrayPoint(TQ1, Pc2, 3.0, Goc1 - 14.5), 7, 11, 4294967295, 0, mauXanh, 1, mauXanh, 1, fileGif, 10 * Tyle, 10 * Tyle, 60, False, 2, 1)
        Else
            DuoiV1 = P11.Move(Drong * 20, 105 - Goc1, 0)
            DuoiV2 = P21.Move(Drong * 20, 105 - Goc1, 0)
            DuoiV3 = P11.Move(Drong * 18, 285 - Goc1, 0)
            DuoiV4 = P21.Move(Drong * 18, 285 - Goc1, 0)
            End If

        Dim DuoiMT1 As IPosition71 = P11.Move(Drong * 12, 285 - Goc1, 0)
        Dim DuoiMT2 As IPosition71 = P21.Move(Drong * 12, 285 - Goc1, 0)

        Dim Ca1 As IPosition71 = P11.Move(Drong * 2, 105 - Goc1, 0)
        Dim Ca2 As IPosition71 = P21.Move(Drong * 2, 105 - Goc1, 0)
        Dim Ca3 As IPosition71 = P11.Move(Drong * 3, 105 - Goc1, 0)
        Dim Ca4 As IPosition71 = P21.Move(Drong * 3, 105 - Goc1, 0)

        Dim T11 As IPosition71 = Ca4.Move(Drong * 5, 15 - Goc1, 0)
        Dim T12 As IPosition71 = Ca2.Move(Drong * 5, 15 - Goc1, 0)
        Dim T3 As IPosition71 = Ca3.Move(Drong * 5, 195 - Goc1, 0)
        Dim T4 As IPosition71 = Ca1.Move(Drong * 5, 195 - Goc1, 0)

        Dim C5 As IPosition71 = P11.Move(Drong * 6, 105 - Goc1, 0)
        Dim C6 As IPosition71 = P21.Move(Drong * 6, 105 - Goc1, 0)
        Dim LiMB As List(Of IPosition71) = DMuiten(C5, C6, Goc1 + 154.7, Drong, 0)
        LiMB.Add(Ca4)
        LiMB.Add(T11)
        LiMB.Add(T12)
        LiMB.Add(Ca2)
        LiMB.Add(DuoiMT2)
        LiMB.Add(DuoiMT1)
        LiMB.Add(Ca1)
        LiMB.Add(T4)
        LiMB.Add(T3)
        LiMB.Add(Ca3)
        liP4.Add(DuoiV3)
        liDm1.Add(DuoiV4)
        liDm2.Add(DuoiV1)
        liP3.Add(DuoiV2)
        If Lenhve = "maybayhoatdong" Then
            FVungList(LiMB, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
            Dim T121 As IPosition71 = T12.Move(Drong, 285 - Goc1, 0)
            Dim T41 As IPosition71 = T4.Move(Drong, 285 - Goc1, 0)
            Dim LiDemMB As New List(Of IPosition71) From {T4, T41, T121, T12}
            FVungList(LiDemMB, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        End If

        Dim LiD11 As List(Of IPosition71) = DMuiten(liDm1(0), liP4(0), Goc1 + 180, Drong, Bk / 12)
        Dim LiD21 As List(Of IPosition71) = DMuiten(liDm2(0), liP3(0), Goc1, Drong, Bk / 12)
        For i As Integer = 0 To 21
            LiD11.Add(liP4(i))
            LiD21.Add(liP3(i))
        Next
        liDm1.Reverse()
            liDm2.Reverse()
        For i As Integer = 0 To 21
            LiD11.Add(liDm1(i))
            LiD21.Add(liDm2(i))
        Next
        FVungList(LiD11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungList(LiD21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        liP22.Reverse()
        liP12.Reverse()
        For i As Integer = 0 To 19
            liP4.Add(liP22(i))
            liP3.Add(liP12(i))
        Next
        FVungList(liP4, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungList(liP3, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Function DMuiten(P1 As IPosition71, P2 As IPosition71, Goc As Double, Drong As Double, d As Double) As List(Of IPosition71)
        Dim liP12 As New List(Of IPosition71)
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (P1.X + P2.X), 0.5 * (P1.Y + P2.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim Goc2 As Double = Goc + 90 ' 270 + MkGoc(liP1(0), liP1(42))
        liP12.Add(P1)
        Dim mt1 As IPosition71 = Pc.Move(Drong * 2, 110 - Goc2, 0)
        liP12.Add(mt1)
        Dim Mt2 As IPosition71 = Pc.Move(d + Drong * 7, -10 - Goc2, 0)
        liP12.Add(Mt2)
        Dim Mt3 As IPosition71 = Pc.Move(Drong * 2, 230 - Goc2, 0)
        liP12.Add(Mt3)
        liP12.Add(P2)
        DMuiten = liP12
    End Function

    Public Sub KhuvucTrucban()
        Dim k(50) As IPosition71
        Dim chieucao As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim chieurong As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(3), PllVts(4), PllVts(6), PllVts(7))
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim Goc1 As Double = FGoc(P1, P2)
        Dim Goc2 As Double = Goc1 + 180
        Dim P3 As IPosition71 = P2.Move(chieurong, 270 + Goc1, 0)
        Dim P4 As IPosition71 = P1.Move(chieurong, 270 + Goc1, 0)
        Dim Bk As Double = FrmMain.sgworldMain.CoordServices.GetDistance(P1.X, P1.Y, P2.X, P2.Y) / 25
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
        vung = FVungPoint(k, 1, 40, 4294967295, Dorongduong * 2, mau, 1, mau, 0, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Tuyendanhchan()
        Dim lists1 As New List(Of IPosition71), lists2 As New List(Of IPosition71)
        Dim k(4) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = 20 * Tyle
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 500, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 500, 0, 0, 0) 'Diem giua
        Dim p3 As IPosition71 = P1.Move(15 * hesoTyle, 45 - Goc1, 0)
        Dim p4 As IPosition71 = P2.Move(15 * hesoTyle, 315 - Goc1, 0)
        lists1.Add(p3)
        lists1.Add(P1)
        lists1.Add(P2)
        lists1.Add(p4)
        k(1) = p3.Move(1.2 * Dorongduong, 270 - Goc1, 0)
        k(2) = P1.Move(1.0 * Dorongduong, 330 - Goc1, 0)
        k(3) = P2.Move(1.0 * Dorongduong, 30 - Goc1, 0)
        k(4) = p4.Move(1.2 * Dorongduong, 90 - Goc1, 0)
        FDuongList(lists1, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
        FDuong(k, 1, 4, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ', False) 
        SLenhve3DMs()
    End Sub

#End Region

#Region "   PHongKhong"
    Public Sub TuyenPhathienlientucLON()
        Dim Khoangcach As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Khoangcach / 729.17
        Dim pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({179.83, 259.24, 368.01, 262.19, 368.01, 277.81, 179.83, 280.76, 178.06, 277.18, 355.33, 276.08, 355.33, 263.92, 178.06, 262.82, 177.16, 265.74, 345.45, 265.39, 345.45, 274.61, 177.16, 274.26, 92.31, 286.89, 81.16, 78.81, 81.16, 101.19, 92.31, 253.11, 89.69, 260.04, 75.43, 93.59, 75.43, 86.41, 89.69, 279.96, 88.5, 273.55, 0.0, 0.0, 88.58, 265.74, 176.31, 86.61, 260.5, 88.6, 236.38, 83.93, 364.57, 90.0, 236.38, 96.07, 260.5, 91.4, 176.31, 93.39})
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 0, 7, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 12, 19, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 23, 29, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 4, 11, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 16, 22, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenPhathienlientucNHO()
        Dim k(40) As IPosition71
        Dim Khoangcach As Double = (Math.Sqrt((PllVts(0) - PllVts(3)) ^ 2 + (PllVts(1) - PllVts(4)) ^ 2)) * 110952
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Khoangcach / 729.17
        Dim pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim TQ As New List(Of Double)({364.74, 268.43, 364.74, 271.57, 176.95, 273.24, 176.95, 266.76, 88.9, 263.54, 88.9, 276.46, 80.24, 82.84, 80.24, 97.16, 176.31, 86.61, 255.68, 87.76, 236.38, 83.93, 364.57, 90.0, 236.38, 96.07, 255.68, 92.24, 176.31, 93.25, 365.46, 266.08, 364.74, 268.43, 176.95, 266.76, 178.12, 262.68, 90.94, 256.26, 88.9, 263.54, 80.24, 97.16, 81.98, 103.79, 176.95, 95.95, 176.28, 93.39, 255.68, 92.24, 245.89, 94.08})
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 0, 3, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 4, 7, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 8, 14, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 15, 18, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 19, 22, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 23, 26, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenPhathienKolientucNHO()
        Dim Khoangcach As Double = (Math.Sqrt((PllVts(0) - PllVts(3)) ^ 2 + (PllVts(1) - PllVts(4)) ^ 2)) * 110952
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Khoangcach / 729.17
        Dim pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim p1 As IPosition71 = pc.Move(158.58 * hesoTyle, 270 - Goc1, 0)
        Dim p2 As IPosition71 = pc.Move(132.5 * hesoTyle, 270 - Goc1, 0)
        Dim p3 As IPosition71 = pc.Move(105.42 * hesoTyle, 270 - Goc1, 0)
        Dim p4 As IPosition71 = pc.Move(98.71 * hesoTyle, 90 - Goc1, 0)
        Dim p5 As IPosition71 = pc.Move(127.81 * hesoTyle, 90 - Goc1, 0)
        Dim p6 As IPosition71 = pc.Move(156.9 * hesoTyle, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({364.74, 268.43, 364.74, 271.57, 176.95, 273.24, 176.95, 266.76, 88.9, 263.54, 88.9, 276.46, 80.24, 82.84, 80.24, 97.16, 176.31, 86.61, 255.68, 87.76, 236.38, 83.93, 364.57, 90.0, 236.38, 96.07, 255.68, 92.24, 176.31, 93.25, 365.46, 266.08, 364.74, 268.43, 176.95, 266.76, 178.12, 262.68, 90.94, 256.26, 88.9, 263.54, 80.24, 97.16, 81.98, 103.79, 176.95, 95.95, 176.28, 93.39, 255.68, 92.24, 245.89, 94.08})
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 0, 3, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 4, 7, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 8, 14, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 15, 18, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 19, 22, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 23, 26, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        MCircleTQ(p1, 150, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p2, 150, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p3, 150, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p4, 150, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p5, 150, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p6, 150, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenPhathienKolientucLON()
        Dim Khoangcach As Double = (Math.Sqrt((PllVts(0) - PllVts(3)) ^ 2 + (PllVts(1) - PllVts(4)) ^ 2)) * 110952
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Khoangcach / 729.17
        Dim pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim p1 As IPosition71 = pc.Move(158.58 * hesoTyle, 270 - Goc1, 0)
        Dim p2 As IPosition71 = pc.Move(132.5 * hesoTyle, 270 - Goc1, 0)
        Dim p3 As IPosition71 = pc.Move(105.42 * hesoTyle, 270 - Goc1, 0)
        Dim p4 As IPosition71 = pc.Move(98.71 * hesoTyle, 90 - Goc1, 0)
        Dim p5 As IPosition71 = pc.Move(127.81 * hesoTyle, 90 - Goc1, 0)
        Dim p6 As IPosition71 = pc.Move(156.9 * hesoTyle, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({179.83, 259.24, 368.01, 262.19, 368.01, 277.81, 179.83, 280.76, 178.06, 277.18, 355.33, 276.08, 355.33, 263.92, 178.06, 262.82, 177.16, 265.74, 345.45, 265.39, 345.45, 274.61, 177.16, 274.26, 92.31, 286.89, 81.16, 78.81, 81.16, 101.19, 92.31, 253.11, 89.69, 260.04, 75.43, 93.59, 75.43, 86.41, 89.69, 279.96, 88.5, 273.55, 0.0, 0.0, 88.58, 265.74, 176.31, 86.61, 260.5, 88.6, 236.38, 83.93, 364.57, 90.0, 236.38, 96.07, 260.5, 91.4, 176.31, 93.39})
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 0, 7, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 12, 19, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 23, 29, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 4, 11, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, pc, hesoTyle / Tyle, Goc1), 16, 22, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        MCircleTQ(p1, 100, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p2, 100, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p3, 100, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p4, 100, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p5, 100, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(p6, 100, 4294967295, Dorongduong * 0.9, mau3, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
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
            FVungList(listsPoint, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        Else
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 0, 23, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
            If Lenhve = "Phaophanluccolon" Then
                FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 34, 37, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
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
        FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 0, 51, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        If Lenhve = "Coi160" Then
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 102, 105, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 106, 109, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 110, 113, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        ElseIf Lenhve = "Coi120" Then
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 102, 105, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
            FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 106, 109, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        ElseIf Lenhve = "Coi82" Then
            vung = FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 102, 105, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        End If
        vung = FVungPoint(ArrayPoint(TQ, P, 1.6, Goc1), 52, 101, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)

    End Sub

    Private Sub STLCCTamgan(P As IPosition71, Goc As Double)
        Dim TQ As New List(Of Double)({0.0, 0.0, 40.87, 300.26, 65.62, 327.46, 37.0, 66.08, 88.92, 80.29, 104.13, 57.32, 130.4, 64.45, 118.6, 82.73, 294.04, 87.08, 278.18, 80.91, 426.99, 90.0, 278.18, 99.09, 294.04, 92.92, 118.6, 97.27, 130.4, 115.36, 104.13, 122.47, 88.92, 99.71, 37.0, 113.92, 65.62, 212.54, 40.87, 239.74})
        FVungPoint(ArrayPoint(TQ, P, 2.0, Goc), 0, 19, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Public Sub Tenluacocanhtamgan()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        If FrmMain.cbLoaiTrandia.SelectedIndex = 9 Then
            Dim K3 As IPosition71 = FrmMain.mPointClick.Move(190 * Tyle * 2.0, 90.0 - Goc1, 0)
            SubTDTL_MD(0, K3, Goc1, mau2)
            SubTDTL_MD(Dorongduong, K3, Goc1, mau)
        Else
            STDTLCC(Goc1)
        End If
        If Lenhve = "tenluacocanhtamgan2Ranh" Then
            Dim K2 As IPosition71 = FrmMain.mPointClick.Move(60 * Tyle * 2.0, 180 - Goc1, 0)
            STLCCTamgan(K2, Goc1)
            Dim K1 As IPosition71 = FrmMain.mPointClick.Move(-60 * Tyle * 2.0, 180 - Goc1, 0)
            STLCCTamgan(K1, Goc1)
        Else
            STLCCTamgan(FrmMain.mPointClick, Goc1)
        End If
        SLenhve3DMs()
    End Sub

    Private Sub STLCCTamtrung(P As IPosition71, Goc As Double)
        Dim TQ As New List(Of Double)({0.0, 0.0, 40.87, 300.26, 65.62, 327.46, 37.0, 66.08, 65.88, 76.84, 85.59, 48.55, 109.89, 58.96, 95.34, 80.95, 106.91, 81.93, 119.87, 62.02, 147.03, 67.52, 136.68, 83.7, 294.04, 87.08, 278.18, 80.91, 426.99, 90.0, 278.18, 99.09, 294.04, 92.92, 136.68, 96.3, 147.03, 112.32, 119.87, 117.78, 106.91, 98.07, 95.34, 99.05, 109.89, 120.44, 85.59, 130.78, 65.88, 103.16, 37.0, 113.92, 65.62, 212.54, 40.87, 239.74})
        FVungPoint(ArrayPoint(TQ, P, 2.0, Goc), 0, 27, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
    End Sub

    Public Sub Tenluacocanhtamtrung()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        If FrmMain.cbLoaiTrandia.SelectedIndex = 9 Then
            Dim K3 As IPosition71 = FrmMain.mPointClick.Move(190 * Tyle * 2.0, 90.0 - Goc1, 0)
            SubTDTL_MD(0, K3, Goc1, mau2)
            SubTDTL_MD(Dorongduong, K3, Goc1, mau)
        Else
            STDTLCC(Goc1)
        End If
        If Lenhve = "tenluacocanhtamtrung2Ranh" Then
            Dim K2 As IPosition71 = FrmMain.mPointClick.Move(60 * Tyle * 2.0, 180 - Goc1, 0)
            STLCCTamtrung(K2, Goc1)
            Dim K1 As IPosition71 = FrmMain.mPointClick.Move(-60 * Tyle * 2.0, 180 - Goc1, 0)
            STLCCTamtrung(K1, Goc1)
        Else
            STLCCTamtrung(FrmMain.mPointClick, Goc1)
        End If
        SLenhve3DMs()
    End Sub

    Private Sub STLCCTamxa(P As IPosition71, Goc As Double)
        Dim TQ As New List(Of Double)({0.0, 0.0, 40.87, 300.26, 65.62, 327.46, 37.0, 66.08, 48.33, 71.92, 72.95, 39.04, 94.75, 53.27, 77.41, 78.83, 88.92, 80.29, 104.13, 57.32, 130.4, 64.45, 118.6, 82.73, 129.31, 83.34, 140.11, 66.44, 168.04, 70.53, 159.14, 84.59, 294.04, 87.08, 278.18, 80.91, 426.99, 90.0, 278.18, 99.09, 294.04, 92.92, 159.14, 95.41, 168.04, 109.47, 140.11, 113.56, 129.31, 96.66, 118.6, 97.27, 130.4, 115.36, 104.13, 122.47, 88.92, 99.71, 77.41, 101.17, 94.75, 126.08, 72.95, 140.3, 48.33, 108.08, 37.0, 113.92, 65.62, 212.54, 40.87, 239.74})
        FVungPoint(ArrayPoint(TQ, P, 2.0, Goc), 0, 35, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
    End Sub

    Public Sub Tenluacocanhtamxa()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        If FrmMain.cbLoaiTrandia.SelectedIndex = 9 Then
            Dim K3 As IPosition71 = FrmMain.mPointClick.Move(190 * Tyle * 2.0, 90.0 - Goc1, 0)
            SubTDTL_MD(0, K3, Goc1, mau2)
            SubTDTL_MD(Dorongduong, K3, Goc1, mau)
        Else
            STDTLCC(Goc1)
        End If
        If Lenhve = "tenluacocanhtamxa2Ranh" Then
            Dim K2 As IPosition71 = FrmMain.mPointClick.Move(60 * Tyle * 2.0, 180 - Goc1, 0)
            STLCCTamxa(K2, Goc1)
            Dim K1 As IPosition71 = FrmMain.mPointClick.Move(-60 * Tyle * 2.0, 180 - Goc1, 0)
            STLCCTamxa(K1, Goc1)
        Else
            STLCCTamxa(FrmMain.mPointClick, Goc1)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub STDTLCC(Goc As Double)
        Dim TQ As New List(Of Double)({225.91, 57.44, 237.94, 67.01, 237.94, 112.99, 225.91, 122.56, 201.41, 121.22, 210.88, 113.05, 210.88, 66.95, 201.41, 58.78, 181.91, 60.11, 189.24, 66.89, 189.24, 113.11, 181.91, 119.89})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.0, Goc), 4, 11, 4294967295, 0, mauXam, 0, mauXam, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.0, Goc), 0, 7, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
    End Sub

    Public Sub Tenluacocanhhatnhan()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({80.0, 0.07, 80.0, 15.0, 80.0, 30.0, 80.0, 45.0, 80.0, 60.0, 80.0, 75.0, 80.0, 79.12, 169.8, 84.93, 156.46, 73.68, 302.47, 90.0, 156.46, 106.32, 169.8, 95.07, 80.0, 100.88, 80.0, 120.0, 80.0, 135.0, 80.0, 150.0, 80.0, 165.0, 80.0, 180.0, 80.0, 195.0, 80.0, 210.0, 80.0, 225.0, 80.0, 240.0, 80.0, 255.0, 80.0, 259.12, 157.56, 264.54, 260.19, 254.45, 253.11, 262.05, 190.67, 270.0, 253.11, 277.95, 260.19, 285.55, 157.56, 275.46, 80.0, 280.88, 80.0, 285.0, 80.0, 300.0, 80.0, 315.0, 80.0, 330.0, 80.0, 345.0, 80.0, 0.0, 49.74, 360.0, 49.74, 345.0, 49.74, 330.0, 49.74, 315.0, 49.74, 300.0, 49.74, 285.0, 49.74, 270.0, 49.74, 255.0, 49.74, 240.0, 49.74, 225.0, 49.74, 210.0, 49.74, 195.0, 49.74, 180.0, 49.74, 165.0, 49.74, 150.0, 49.74, 135.0, 49.74, 120.0, 49.74, 105.0, 49.74, 90.0, 49.74, 75.0, 49.74, 60.0, 49.74, 45.0, 49.74, 30.0, 49.74, 15.0, 49.74, 0.12, 49.74, 0.12, 49.74, 15.0, 49.74, 30.0, 49.74, 45.0, 49.74, 60.0, 49.74, 75.0, 49.74, 90.0, 49.74, 105.0, 49.74, 120.0, 49.74, 135.0, 49.74, 150.0, 49.74, 165.0, 49.74, 180.0, 49.74, 195.0, 49.74, 210.0, 49.74, 225.0, 49.74, 240.0, 49.74, 255.0, 49.74, 270.0, 49.74, 285.0, 49.74, 300.0, 49.74, 315.0, 49.74, 330.0, 49.74, 345.0, 49.74, 0.0, 29.57, 0.0, 29.57, 330.0, 29.57, 300.0, 29.57, 270.0, 29.57, 240.0, 29.57, 210.0, 29.57, 180.0, 29.57, 150.0, 29.57, 120.0, 29.57, 90.0, 29.57, 60.0, 29.57, 30.0, 29.57, 0.12})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.0, Goc1), 0, 62, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.0, Goc1), 63, 100, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub B72xe()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({205.65, 313.59, 205.57, 226.43, 321.9, 116.12, 455.13, 90.0, 321.95, 63.87, 185.02, 320.03, 163.16, 313.25, 299.62, 68.09, 408.91, 90.0, 299.58, 111.89, 163.16, 226.8, 185.02, 320.01})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.8, Goc1), 0, 11, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        Phagot(FrmMain.mPointClick, Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub Phagot(P As IPosition71, Goc1 As Double)
        If Lenhve = "tenluaB72" Or Lenhve = "tenluaB72xe" Then
            Dim TQ1 As New List(Of Double)({90.97, 180.0, 201.68, 116.81, 180.54, 94.42, 225.44, 93.54, 225.58, 85.91, 180.72, 84.9, 201.73, 63.16, 104.43, 29.3, 79.63, 39.92, 161.96, 67.85, 161.92, 112.12, 67.95, 153.8, 68.04, 26.16, 79.63, 39.86, 104.43, 29.25, 91.07, 0.0, 37.5, 0.0, 87.31, 330.11, 63.09, 316.41, 7.5, 0.0, 7.5, 180.0, 62.59, 224.03, 87.31, 209.89, 37.5, 180.0})
            FVungPoint(ArrayPoint(TQ1, P, 2.0, Goc1), 0, 23, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        ElseIf Lenhve = "tenluaPhagot" Then
            Dim TQ2 As New List(Of Double)({90.97, 180.0, 201.68, 116.81, 180.54, 94.42, 225.44, 93.54, 225.58, 85.91, 180.72, 84.9, 201.73, 63.16, 104.43, 29.3, 79.63, 39.92, 161.96, 67.85, 161.92, 112.12, 67.95, 153.8, 68.04, 26.16, 79.63, 39.86, 104.43, 29.25, 91.07, 0.0, 37.5, 0.0, 87.31, 330.11, 63.09, 316.41, 17.26, 330.34, 46.02, 289.02, 46.02, 250.98, 17.34, 210.12, 62.59, 224.03, 87.31, 209.89, 37.5, 180.0})
            FVungPoint(ArrayPoint(TQ2, P, 2.0, Goc1), 0, 25, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        End If
        Dim TQ As New List(Of Double)({79.63, 39.92, 161.96, 67.85, 161.92, 112.12, 67.95, 153.8, 68.04, 26.16, 79.63, 39.86, 64.8, 128.08, 135.05, 107.21, 135.08, 72.74, 64.94, 51.9, 79.63, 39.92})
        FVungPoint(ArrayPoint(TQ, P, 2.0, Goc1), 0, 10, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub TLChongngamNBC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPointClick.Move(30.0 * Tyle * 2.0, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({10.0, 0.29, 30.0, 0.19, 60.0, 0.1, 108.17, 56.31, 91.24, 80.54, 296.37, 87.1, 280.47, 80.98, 429.32, 90.0, 280.47, 99.02, 296.37, 92.9, 91.24, 99.46, 108.17, 123.69, 67.08, 206.57, 67.08, 333.43, 60.0, 0.0, 30.0, 180.0, 67.08, 116.57, 67.08, 63.43, 30.0, 0.19, 67.08, 63.43, 67.08, 116.57, 30.0, 180.0, 10.0, 0.0, 22.36, 63.43, 22.36, 116.57, 41.23, 104.04, 41.23, 75.96, 10.0, 0.29})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.0, Goc1), 0, 18, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.0, Goc1), 18, 27, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FLabel(P1, 0, Tyle * 2.0, Goc1, "N", "", mauDen, 1, 0, 0, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TLNguloiTudan()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({152.34, 48.97, 155.28, 33.16, 136.77, 18.11, 123.52, 35.94, 100.0, 0.0, 100.0, 180.0, 123.52, 144.06, 136.77, 161.89, 155.28, 146.84, 152.34, 131.03, 276.13, 111.23, 299.29, 108.83, 319.36, 105.73, 335.63, 102.16, 347.61, 98.27, 354.93, 94.18, 357.39, 90.0, 354.93, 85.82, 347.61, 81.73, 335.63, 77.84, 319.36, 74.27, 299.29, 71.17, 276.13, 68.77, 152.42, 49.0, 134.65, 58.68, 264.84, 74.67, 283.56, 76.26, 298.44, 78.32, 310.64, 80.87, 319.69, 83.74, 325.26, 86.82, 327.13, 90.0, 325.26, 93.18, 319.69, 96.26, 310.64, 99.13, 298.44, 101.68, 283.56, 103.74, 264.84, 105.33, 76.16, 156.8, 76.16, 23.2, 134.57, 58.66, 125.33, 66.49, 70.71, 45.0, 70.71, 135.0, 258.98, 101.13, 274.43, 100.05, 285.42, 98.65, 294.53, 96.83, 301.34, 94.72, 305.54, 92.41, 306.96, 90.0, 305.54, 87.59, 301.34, 85.28, 294.53, 83.17, 285.42, 81.35, 274.43, 79.95, 258.98, 78.87, 125.43, 66.51})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.2, Goc1), 0, 40, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.2, Goc1), 24, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TLNguloiTudanNBC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({152.34, 48.97, 155.28, 33.16, 136.77, 18.11, 123.52, 35.94, 100.0, 0.0, 100.0, 180.0, 123.52, 144.06, 136.77, 161.89, 155.28, 146.84, 152.34, 131.03, 276.13, 111.23, 299.29, 108.83, 319.36, 105.73, 335.63, 102.16, 347.61, 98.27, 354.93, 94.18, 357.39, 90.0, 354.93, 85.82, 347.61, 81.73, 335.63, 77.84, 319.36, 74.27, 299.29, 71.17, 276.13, 68.77, 152.42, 49.0, 134.65, 58.68, 264.84, 74.67, 283.56, 76.26, 298.44, 78.32, 310.64, 80.87, 319.69, 83.74, 325.26, 86.82, 327.13, 90.0, 325.26, 93.18, 319.69, 96.26, 310.64, 99.13, 298.44, 101.68, 283.56, 103.74, 264.84, 105.33, 92.2, 139.4, 92.2, 40.4, 134.57, 58.66, 125.33, 66.49, 94.34, 57.99, 94.34, 122.01, 258.98, 101.13, 274.43, 100.05, 285.42, 98.65, 294.53, 96.83, 301.34, 94.72, 305.54, 92.41, 306.96, 90.0, 305.54, 87.59, 301.34, 85.28, 294.53, 83.17, 285.42, 81.35, 274.43, 79.95, 258.98, 78.87, 125.43, 66.51})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.2, Goc1), 0, 40, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.2, Goc1), 24, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TenluaCCtuMB()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P As IPosition71 = FrmMain.mPointClick.Move(187.35 * Tyle * 2.0, 270 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({158.07, 275.45, 75.47, 78.54, 76.33, 64.45, 79.91, 51.18, 84.45, 41.33, 91.8, 30.25, 100.66, 20.55, 277.35, 90.0, 97.47, 156.86, 88.55, 145.21, 81.52, 136.54, 79.04, 125.27, 76.26, 113.17, 75.47, 101.46, 158.07, 264.55})
        Dim TQ2 As New List(Of Double)({33.54, 120.0, 33.54, 150.0, 33.54, 180.0, 33.54, 210.0, 33.54, 240.0, 33.54, 270.0, 33.54, 300.0, 33.54, 330.0, 33.54, 0.0, 33.54, 30.0, 33.54, 60.0})
        Dim TQ3 As New List(Of Double)({75.47, 101.46, 76.26, 113.17, 174.95, 260.13, 167.0, 261.36, 160.43, 263.39, 158.07, 264.55})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, FrmMain.mPointClick, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, FrmMain.mPointClick, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 25, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 26, 31, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TenluachongRADA()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P As IPosition71 = FrmMain.mPointClick.Move(187.35 * Tyle * 2.0, 270 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({33.54, 116.73, 33.54, 120.0, 33.54, 150.0, 33.54, 180.0, 33.54, 210.0, 33.54, 240.0, 33.54, 270.0, 33.54, 300.0, 33.54, 330.0, 33.54, 0.0, 33.54, 30.0, 33.54, 60.0, 33.54, 63.27})
        Dim TQ2 As New List(Of Double)({30.13, 60.14, 110.13, 13.73, 160.96, 358.27, 163.61, 10.48, 127.97, 26.02, 190.96, 52.97, 195.39, 47.75, 294.83, 70.17, 160.07, 64.62, 174.55, 60.86, 101.86, 33.44, 58.1, 75.04, 153.19, 84.38, 147.99, 77.76, 277.35, 90.0, 147.99, 102.25, 153.19, 95.62, 58.1, 104.96, 101.86, 146.56, 174.55, 119.14, 160.07, 115.38, 294.83, 109.83, 195.39, 132.26, 190.96, 127.03, 127.97, 153.98, 163.62, 169.52, 160.96, 181.73, 110.14, 166.27, 30.13, 119.86, 160.96, 358.27, 110.13, 13.73, 110.14, 166.27, 160.96, 181.73})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, FrmMain.mPointClick, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 41, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 42, 45, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenTStiengdong()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai
        Dim TQ1 As New List(Of Double)({68.39, 282.67, 68.7, 285.0, 68.7, 300.0, 68.7, 302.33, 99.83, 306.36, 99.83, 323.64, 68.7, 327.67, 68.7, 345.0, 68.7, 0.0, 68.7, 15.0, 68.7, 30.0, 99.83, 36.36, 99.83, 53.64, 68.7, 57.67, 68.7, 75.0, 68.7, 90.0, 68.7, 102.67, 38.11, 113.18, 38.11, 90.0, 38.11, 60.0, 38.11, 30.0, 38.11, 0.0, 38.11, 330.0, 38.11, 300.0, 38.11, 270.0, 38.11, 255.0, 38.11, 246.82})
        Dim TQ2 As New List(Of Double)({38.11, 113.18, 38.11, 90.0, 38.11, 60.0, 38.11, 30.0, 38.11, 0.0, 38.11, 330.0, 38.11, 300.0, 38.11, 270.0, 38.11, 246.82, 68.7, 257.33, 68.7, 270.0, 68.7, 285.0, 68.7, 300.0, 68.7, 302.33, 99.83, 306.36, 99.83, 323.64, 68.7, 327.67, 68.7, 345.0, 68.7, 0.0, 68.7, 15.0, 68.7, 30.0, 68.7, 32.33, 99.83, 36.36, 99.83, 53.64, 68.7, 57.67, 68.7, 67.42, 68.7, 77.33})
        Dim TQ3 As New List(Of Double)({68.7, 102.67, 68.7, 119.77})
        Dim TQ4 As New List(Of Double)({68.7, 238.38, 68.7, 257.33})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P2, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P2, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 53, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 54, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenbanCodinh()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai
        Dim TQ1 As New List(Of Double)({21.12, 314.0, 47.39, 341.41, 47.39, 18.28, 47.39, 161.72, 47.39, 198.59, 21.12, 225.25})
        Dim TQ2 As New List(Of Double)({21.12, 135.25, 47.39, 161.72, 47.39, 198.59, 47.39, 341.41, 47.39, 18.28, 21.12, 44.75})
        Dim TQ3 As New List(Of Double)({47.39, 198.59, 21.12, 225.25})
        Dim TQ4 As New List(Of Double)({21.12, 135.25, 47.39, 161.72})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P2, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P2, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 11, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 12, 15, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenBanCS()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai
        Dim TQ1 As New List(Of Double)({70.0, 90.08, 70.0, 105.0, 90.17, 105.0, 90.17, 120.0, 70.0, 120.0, 70.0, 135.0, 70.0, 150.0, 90.17, 150.0, 90.17, 165.0, 70.0, 165.0, 70.0, 180.0, 70.0, 195.0, 90.17, 195.0, 90.17, 210.0, 70.0, 210.0, 70.0, 225.0, 70.0, 240.0, 90.17, 240.0, 90.17, 255.0, 70.0, 255.0, 70.0, 270.0, 70.0, 285.0, 70.0, 300.0, 70.0, 315.0, 70.0, 330.0, 70.0, 345.0, 70.0, 0.0, 70.0, 15.0, 70.0, 30.0, 70.0, 45.0, 70.0, 60.0, 70.0, 75.0, 70.0, 90.0, 44.78, 90.0, 44.78, 75.0, 44.78, 60.0, 44.78, 45.0, 44.78, 30.0, 44.78, 15.0, 44.78, 0.0, 44.78, 345.0, 44.78, 330.0, 44.78, 315.0, 44.78, 300.0, 44.78, 285.0, 44.78, 270.0, 44.78, 255.0, 44.78, 240.0, 44.78, 225.0, 44.78, 210.0, 44.78, 195.0, 44.78, 180.0, 44.78, 165.0, 44.78, 150.0, 44.78, 135.0, 44.78, 120.0, 44.78, 105.0, 44.78, 90.08})
        Dim TQ2 As New List(Of Double)({70.0, 90.08, 70.0, 105.0, 90.17, 105.0, 90.17, 120.0, 70.0, 120.0, 70.0, 135.0, 70.0, 150.0, 90.17, 150.0, 90.17, 165.0, 70.0, 165.0, 70.0, 180.0, 70.0, 195.0, 90.17, 195.0, 90.17, 210.0, 70.0, 210.0, 70.0, 225.0, 70.0, 240.0, 90.17, 240.0, 90.17, 255.0, 70.0, 255.0, 70.0, 270.0, 70.0, 285.0, 70.0, 300.0, 70.0, 315.0, 70.0, 330.0, 70.0, 345.0, 70.0, 0.0, 70.0, 15.0, 70.0, 30.0, 70.0, 45.0, 70.0, 60.0, 70.0, 75.0, 70.0, 90.0, 44.78, 90.0, 44.78, 75.0, 44.78, 60.0, 44.78, 45.0, 44.78, 30.0, 44.78, 15.0, 44.78, 0.0, 44.78, 345.0, 44.78, 330.0, 44.78, 315.0, 44.78, 300.0, 44.78, 285.0, 44.78, 270.0, 44.78, 255.0, 44.78, 240.0, 44.78, 225.0, 44.78, 210.0, 44.78, 195.0, 44.78, 180.0, 44.78, 165.0, 44.78, 150.0, 44.78, 135.0, 44.78, 120.0, 44.78, 105.0, 44.78, 90.08})
        Dim TQ3 As New List(Of Double)({70.0, 270.0, 70.0, 295.57})
        Dim TQ4 As New List(Of Double)({70.0, 64.43, 70.0, 90.0})
        Dim TQ5 As New List(Of Double)({70.0, 270.0, 70.0, 255.0})
        Dim TQ6 As New List(Of Double)({70.0, 105.0, 70.0, 90.0})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P2, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P2, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ5, P1, 2.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ6, P2, 2.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 58, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 58, 115, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 116, 119, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(liP1.ToArray, 120, 123, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KhoangbanV()
        Dim TQ As New List(Of Double)({128.16, 290.56, 128.16, 249.44, 63.64, 225.0, 128.16, 200.56, 128.16, 159.44, 54.08, 123.69, 30.0, 180.0, 75.0, 180.0, 87.41, 210.91, 63.57, 224.61, 54.08, 213.69, 42.43, 225.0, 54.08, 236.23, 63.5, 225.0, 87.41, 239.09, 75.0, 270.0, 30.0, 270.0, 54.03, 326.27, 44.93, 0.0, 0.0, 0.0, 75.0, 90.0, 167.71, 153.43, 167.71, 206.57, 106.07, 225.0, 167.71, 243.43, 167.71, 296.57, 75.0, 0.0, 45.0, 0.0, 97.08, 281.89, 97.08, 258.11, 58.52, 250.02, 58.52, 199.98, 97.08, 191.89, 97.08, 168.11, 58.52, 160.02, 58.48, 199.85, 58.48, 250.15, 58.49, 289.89, 36.0, 303.56, 42.43, 225.0, 54.08, 123.69, 128.16, 159.44, 128.16, 200.56, 63.64, 225.0, 128.16, 249.44, 128.16, 290.56, 54.08, 326.31, 36.06, 303.69})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.5, 0), 0, 27, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.5, 0), 28, 47, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KhoangbanCN()
        Dim TQ As New List(Of Double)({153.05, 308.37, 153.05, 231.63, 105.12, 205.35, 224.56, 191.56, 224.56, 168.44, 54.08, 123.69, 30.0, 180.0, 125.0, 180.0, 132.82, 199.76, 105.08, 205.3, 99.62, 197.53, 42.43, 225.0, 54.08, 236.31, 105.08, 205.37, 120.96, 218.32, 75.0, 270.0, 30.0, 270.0, 99.53, 342.46, 94.9, 0.0, 0.0, 0.0, 75.0, 90.0, 261.01, 163.3, 261.01, 196.7, 145.77, 210.96, 195.26, 230.19, 195.26, 309.81, 125.0, 0.0, 95.0, 0.0, 118.0, 306.38, 118.0, 233.62, 72.8, 195.95, 196.02, 185.86, 196.02, 174.14, 58.52, 160.02, 58.52, 199.98, 72.7, 195.97, 88.94, 218.2, 88.94, 321.8, 76.07, 336.77, 42.43, 225.0, 54.84, 123.69, 224.56, 168.44, 224.56, 191.56, 105.12, 205.35, 153.05, 231.63, 153.05, 308.37, 99.62, 342.47, 76.16, 336.8})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.5, 90), 0, 27, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.5, 90), 28, 47, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub
#End Region

#Region " TangThietgiap"

#End Region

End Module
