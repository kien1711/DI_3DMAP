Imports TerraExplorerX
'Imports TerraExplorerX.AltitudeTypeCode
'Imports TerraExplorerX.ActionCode
Module mdlBaoloanlatdo

    Public Sub MuctieuBLLD()
        Dim lists1 As New List(Of IPosition71), lists2 As New List(Of IPosition71), lists3 As New List(Of IPosition71),
            lists4 As New List(Of IPosition71), lists6 As New List(Of IPosition71), lists7 As New List(Of IPosition71)
        Dim k(30) As IPosition71
        Dim Goc1 As Double = 90 + Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Tyle * 3.0

        k(1) = frmMain.mPointClick.Move(90.0 * hesoTyle, 0.0 - Goc1, 0)
        k(2) = frmMain.mPointClick.Move(313.21 * hesoTyle, 73.3 - Goc1, 0)
        k(3) = frmMain.mPointClick.Move(313.21 * hesoTyle, 106.7 - Goc1, 0)
        k(4) = frmMain.mPointClick.Move(90.0 * hesoTyle, 180.0 - Goc1, 0)
        k(5) = frmMain.mPointClick.Move(302.65 * hesoTyle, 82.41 - Goc1, 0)
        k(6) = frmMain.mPointClick.Move(89.44 * hesoTyle, 63.43 - Goc1, 0)
        k(7) = frmMain.mPointClick.Move(89.44 * hesoTyle, 116.57 - Goc1, 0)
        k(8) = frmMain.mPointClick.Move(223.61 * hesoTyle, 100.3 - Goc1, 0)
        k(9) = frmMain.mPointClick.Move(223.57 * hesoTyle, 79.75 - Goc1, 0)
        k(10) = frmMain.mPointClick.Move(302.63 * hesoTyle, 82.44 - Goc1, 0)

        k(11) = k(4).Move(-Dorongduong * 1.2, 225.0 - Goc1, 0)
        k(12) = k(1).Move(-Dorongduong * 1.2, 315.0 - Goc1, 0)
        k(13) = k(2).Move(-Dorongduong * 1.2, 45.0 - Goc1, 0)
        k(14) = k(3).Move(-Dorongduong * 1.2, 135.0 - Goc1, 0)

        k(15) = frmMain.mPointClick.Move(40.0 * hesoTyle, 0.0 - Goc1, 0)
        k(16) = frmMain.mPointClick.Move(302.65 * hesoTyle, 82.41 - Goc1, 0)
        k(17) = frmMain.mPointClick.Move(302.65 * hesoTyle, 97.59 - Goc1, 0)
        k(18) = frmMain.mPointClick.Move(40.0 * hesoTyle, 180.0 - Goc1, 0)

        k(19) = frmMain.mPointClick.Move(90.0 * hesoTyle, 0.0 - Goc1, 0)
        k(20) = frmMain.mPointClick.Move(150.0 * hesoTyle, 53.13 - Goc1, 0)
        k(21) = frmMain.mPointClick.Move(313.21 * hesoTyle, 106.7 - Goc1, 0)
        k(22) = frmMain.mPointClick.Move(201.25 * hesoTyle, 116.57 - Goc1, 0)
        lists3.Add(k(1))
        lists3.Add(k(2))
        For i As Integer = 5 To 10
            lists3.Add(k(i))
        Next
        lists3.Add(k(3))
        lists3.Add(k(4))
        Dim filePastern As String = String.Empty
        If Lenhve = "CongNongLamtruongCD" Then
            Dim P1 As IPosition71 = k(4).Move(Dorongduong * 0.9, 225.0 - Goc1, 0)
            Dim P2 As IPosition71 = k(1).Move(Dorongduong * 0.9, 315.0 - Goc1, 0)
            Dim P3 As IPosition71 = k(2).Move(Dorongduong * 0.9, 45.0 - Goc1, 0)
            Dim P4 As IPosition71 = k(3).Move(Dorongduong * 0.9, 135.0 - Goc1, 0)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
            CongSu(P1, Goc1, 45, mau)
            CongSu(P2, Goc1, 135, mau)
            CongSu(P3, Goc1, 225, mau)
            CongSu(P4, Goc1, 315, mau)
        ElseIf Lenhve = "khusotanBaolut" Or Lenhve = "khusotannhandan" Or Lenhve = "khugiaututhi" Then
            If Lenhve = "khusotanBaolut" Then
                filePastern = "H2O.gif"
            Else
                filePastern = "langCD.gif"
            End If
            If Lenhve = "khugiaututhi" Then
                vung = FVungPoint(k, 19, 22, 3284386755, Dorongduong, frmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, frmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, filePastern, 12.0 * Tyle, 12.0 * Tyle, 0, False, 2, 2)
            Else
                vung = FVungPoint(k, 19, 22, 4294967295, Dorongduong, mauXanh, 1, mau2, 0, filePastern, 12.0 * Tyle, 12.0 * Tyle, 0, False, 2, 2)
            End If
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
        ElseIf Lenhve = "khusotanCQXN" Then
            lists6.Add(k(2))
            lists6.Add(k(3))
            lists6.Add(k(20))
            lists7.Add(k(22))
            lists7.Add(k(4))
            lists7.Add(k(1))
            filePastern = "langCD.gif"
            vung = FVungList(lists6, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 0, False, 2, 2)
            vung = FVungList(lists7, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 0, False, 2, 2)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
        ElseIf Lenhve = "kvemsanLL" Then
            If frmMain.cbTa_DP.SelectedIndex = 0 Then
                filePastern = "NenDo.gif"
            Else
                filePastern = "NenXanh.gif"
            End If
            vung = FVungPoint(k, 15, 18, 4294967295, Dorongduong, mau, 1, mau, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 90, False, 2, 2)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau, 1, mau, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
        ElseIf Lenhve = "muctieuDachiem" Then
            If frmMain.cbTa_DP.SelectedIndex = 0 Then
                filePastern = "NenXanh.gif"
            Else
                filePastern = "NenDo.gif"
            End If
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 135, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 1, 1, 0, False, 2, 1)
            vung = FVungPoint(k, 6, 9, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "muctieuHH" Then
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, FrmMain.sgworldMain.Creator.CreateColor(255, 255, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 135, False, 2, 2)
            vung = FVungPoint(k, 6, 9, 4294967295, Dorongduong, mau3, 1, mau3, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 135, False, 2, 2)
        ElseIf Lenhve = "muctieuDKchiem" Or Lenhve = "muctiechatno" Then
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 1, 1, 0, False, 2, 1)
            vung = FVungPoint(k, 6, 9, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            If Lenhve = "muctiechatno" Then
                Dim P12 As IPosition71 = frmMain.mPointClick.Move(150.0 * hesoTyle, 90.0 - Goc1, 0)
                MCircleTQ(P12, 250, 4294967295, Dorongduong, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            End If
        ElseIf Lenhve = "muctieuBLLD" Or Lenhve = "noigiamcontin" Then
            If frmMain.cbTa_DP.SelectedIndex = 0 Then
                filePastern = "NenXanh.gif"
            Else
                filePastern = "NenDo.gif"
            End If
            vung = FVungList(lists3, 4294967295, 0, mau, 0, mau, 1, filePastern, Tyle * 14.0, Tyle * 14.0, 135, False, 2, 2)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 1, 1, 0, False, 2, 1)
            vung = FVungPoint(k, 6, 9, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            If Lenhve = "noigiamcontin" Then
                Dim P12 As IPosition71 = frmMain.mPointClick.Move(150.0 * hesoTyle, 90.0 - Goc1, 0)
                MCircleTQ(P12, 250, 4294967295, Dorongduong, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            End If
        ElseIf Lenhve = "MatcuA2" Then
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 1, 1, 0, False, 2, 1)
            mText = FLabel(frmMain.mPointClick, 150, Tyle * 4, 0, "A2", "", mau3, 1, 0, 2, 2)
        ElseIf Lenhve = "hamchong" Or Lenhve = "baicocchongtang" Then
            Dim M(5) As IPosition71
            M(1) = frmMain.mPointClick.Move(64.01 * hesoTyle, 51.36 - Goc1, 0)
            M(2) = frmMain.mPointClick.Move(155.22 * hesoTyle, 75.1 - Goc1, 0)
            M(3) = frmMain.mPointClick.Move(253.15 * hesoTyle, 80.95 - Goc1, 0)
            M(4) = frmMain.mPointClick.Move(203.96 * hesoTyle, 101.31 - Goc1, 0)
            M(5) = frmMain.mPointClick.Move(107.7 * hesoTyle, 111.8 - Goc1, 0)
            If Lenhve = "baicocchongtang" Then
                loaiKH = "Coc"
            Else
                loaiKH = "Chong"
            End If
            For i As Integer = 1 To 5
                FLabel(M(i), 0, FrmMain.fLabelStyleMain.Scale, 0, "", loaiKH, mau, 0, 0, 0, 2)
            Next
            If Lenhve = "hamchong" Then
                vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
                vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
            End If

        ElseIf Lenhve = "baiminchongtau" Then
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
            MinChongtau(frmMain.mPointClick.Move(90 * hesoTyle, 90.0 - Goc1, 0), Goc1, mauDen)
            MinChongtau(frmMain.mPointClick.Move(200 * hesoTyle, 90.0 - Goc1, 0), Goc1, mauDen)
        ElseIf Lenhve = "luoinguytrang" Then
            If frmMain.cbTa_DP.SelectedIndex = 0 Then
                filePastern = "Cross1.gif"
            Else
                filePastern = "Cross2.gif"
            End If
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, filePastern, Tyle * 4.0, Tyle * 2.0, 90, False, 2, 1)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "tamnguytrang" Then
            filePastern = "CrossG.gif"
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, filePastern, Tyle * 4.0, Tyle * 2.0, 90, False, 2, 1)
        End If
        SLenhve3DMs()
    End Sub

    Private Sub CongSu(P1 As IPosition71, Goc1 As Double, Sogia As Double, Mau As IColor71)
        Dim TQ As New List(Of Double)({})
        FVungPoint(ArrayPoint(TQ, P1, 4.0, Goc1 + Sogia), 0, 17, 4294967295, 0, Mau, 0, Mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Private Sub MinChongtau(P1 As IPosition71, Goc1 As Double, Mau As IColor71)
        Dim TQ As New List(Of Double)({100.0, 0.0, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 100.0, 89.89, 50.0, 89.94, 50.0, 75.0, 50.0, 60.0, 50.0, 45.0, 50.0, 30.0, 50.0, 15.0, 50.0, 0.0, 50.0, 345.0, 50.0, 330.0, 50.0, 315.0, 50.0, 300.0, 50.0, 285.0, 50.0, 270.0, 50.0, 255.0, 50.0, 240.0, 50.0, 225.0, 50.0, 210.0, 50.0, 195.0, 50.0, 180.0, 50.0, 165.0, 50.0, 150.0, 50.0, 135.0, 50.0, 120.0, 50.0, 105.0, 50.0, 90.0, 100.0, 90.0, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 165.6, 217.15, 142.01, 224.76, 100.0, 211.17, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 328.61, 141.78, 315.14, 165.6, 322.85})
        FVungPoint(ArrayPoint(TQ, P1, 1.2, Goc1 + 180), 0, 51, 4294967295, 0, Mau, 0, Mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

End Module
