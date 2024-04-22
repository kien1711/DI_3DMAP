Imports TerraExplorerX

Module mdlHaiquan

    Public Sub DemTau(P As IPosition71, Goc As Double)
        Dim TQ As New List(Of Double)({97.91, 34.75, 368.88, 77.4, 482.81, 90.0, 368.88, 102.6, 85.85, 159.55, 85.85, 20.51, 97.85, 34.71, 78.1, 134.49, 364.14, 98.64, 439.95, 90.0, 364.14, 81.36, 78.17, 45.56})
        FVungPoint(ArrayPoint(TQ, P, 3.0, Goc), 0, 11, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub TauHaiquan()
        Dim Goc1 As Double, P As IPosition71
        Dim liTauD, liT3 As List(Of IPosition71), liTauC As New List(Of IPosition71)
        Dim TQ, TQdem As New List(Of Double), TQt3 As List(Of Double)

        If Lenhve.Contains("tau") Or Lenhve.Contains("TNgam") Then
            P = FrmMain.Instance.mPointClick
            Goc1 = Phuongvi * 180.0 / Math.PI
        Else
            P = PointHQ
            Goc1 = GocHQ + 90
        End If

        If Lenhve = "TauBPapgiai" Or Lenhve = "TauBPbatgiu" Then
            mau = mau3
            mau2 = mau4
        ElseIf Lenhve = "TauBPkiemtra" Or Lenhve = "tramxulyTNn" Then
            mau = mauXanh
            mau2 = mau4
        End If

        If Lenhve = "tauPhongloinho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 12 Or Lenhve = "tauPhongloilon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 13 Then
            FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 0
        End If

        If Lenhve = "tausanbay" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 1 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 1 Then
            TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 339.67, 103.7, 330.31, 92.48, 33.32, 115.39, 33.32, 64.61, 360.29, 87.73, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 360.29, 87.71, 330.32, 87.5, 339.67, 76.3, 85.89, 20.51})
        ElseIf Lenhve = "tausanbayChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 2 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 2 Then
            TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 14.29, 180.0, 57.83, 255.7, 63.99, 251.44, 71.15, 249.48, 78.66, 249.29, 86.0, 250.43, 92.75, 252.55, 98.64, 255.35, 103.42, 258.64, 106.95, 262.26, 109.1, 266.08, 109.83, 270.0, 109.1, 273.92, 106.95, 277.74, 103.42, 281.36, 98.64, 284.65, 92.75, 287.45, 86.0, 289.57, 78.66, 290.71, 71.75, 290.52, 63.99, 288.56, 57.91, 284.4, 14.29, 0.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 339.67, 103.7, 330.31, 92.48, 33.32, 115.39, 33.32, 64.61, 360.29, 87.73, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 360.29, 87.71, 330.32, 87.5, 339.67, 76.3, 85.89, 20.51})
        ElseIf Lenhve = "tautuanduonghangnhe" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 3 Or Lenhve = "TauTuanduongchongtaungam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 37 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 3 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 37 Then
            TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 109.98, 42.99, 109.91, 136.97, 92.09, 150.75, 92.17, 29.22, 85.89, 20.51})
            If Lenhve = "TauTuanduongchongtaungam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 37 Then
                liTauC = ArrayDoubleToListPoint(TQ, P, 3.0, Goc1)
                Chongngam(liTauC, P, Goc1)
                TQ.Clear()
            End If
        ElseIf Lenhve = "tautuanduonghangnang" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 4 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 4 Then
            TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 144.47, 56.16, 144.41, 123.8, 120.64, 131.76, 120.71, 48.21, 109.98, 42.99, 109.91, 136.97, 92.09, 150.75, 92.17, 29.22, 85.89, 20.51})
        ElseIf Lenhve = "taukhutruc" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 5 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 5 Then
            TQ = New List(Of Double)({125.83, 13.84, 500.0, 90.0, 130.0, 180.0, 130.0, 0.0, 125.83, 13.79, 96.01, 161.79, 380.78, 90.0, 96.02, 18.27})
        ElseIf Lenhve = "tauhove" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 6 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 6 Then
            If FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 0 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 3 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 5 Then
                TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 74.68, 156.31, 162.14, 90.04, 194.9, 90.03, 195.64, 94.97, 107.97, 138.16, 328.0, 104.2, 195.84, 94.97, 195.1, 90.03, 227.87, 90.03, 377.24, 101.24, 482.81, 90.0, 377.31, 78.76, 227.87, 89.97, 195.1, 89.97, 195.84, 85.04, 328.0, 75.8, 107.97, 41.84, 195.64, 85.04, 194.9, 89.97, 162.14, 89.96, 74.67, 23.77})
            ElseIf FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 1 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 2 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 4 Then
                TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 74.68, 156.31, 116.17, 102.58, 137.36, 112.22, 107.97, 138.16, 328.0, 104.2, 267.93, 101.18, 277.78, 95.23, 377.31, 101.24, 482.81, 90.0, 377.31, 78.71, 277.78, 84.77, 267.93, 78.82, 328.0, 75.8, 107.97, 41.84, 137.36, 67.78, 116.17, 77.42, 74.67, 23.77})
            End If
        ElseIf Lenhve = "tauphaonho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 7 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 7 Then
            If FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 0 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 3 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 5 Then
                TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 461.22, 91.95, 33.32, 115.39, 33.32, 64.61, 461.07, 88.21, 368.88, 77.4, 85.85, 20.51})
            ElseIf FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 1 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 2 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 4 Then
                TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 33.32, 64.61, 90.38, 80.91, 90.38, 99.09, 33.32, 115.39, 85.85, 159.55, 368.88, 102.6, 461.22, 91.95, 300.67, 92.72, 300.67, 87.28, 461.07, 88.21, 368.88, 77.4, 85.85, 20.51})
            End If
        ElseIf Lenhve = "tauphaolon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 8 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 8 Then
            If FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 0 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 3 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 5 Then
                TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 461.22, 91.95, 76.35, 100.78, 76.35, 79.22, 461.07, 88.21, 368.88, 77.4, 109.98, 42.99, 109.91, 136.97, 92.17, 150.78, 92.17, 29.22, 85.89, 20.51})
            ElseIf FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 1 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 2 Or FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 4 Then
                TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 461.22, 91.95, 300.67, 92.72, 300.67, 87.28, 461.07, 88.21, 368.88, 77.4, 109.98, 42.99, 76.35, 79.22, 96.42, 81.48, 96.42, 98.52, 76.35, 100.78, 109.91, 136.97, 92.17, 150.78, 92.17, 29.22, 85.89, 20.51})
            End If
        ElseIf Lenhve = "tautenluanho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 9 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 9 Or Lenhve = "tauChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 36 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 36 Or Lenhve = "taulaikeo" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 17 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 17 Or Lenhve = "tautieutu" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 19 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 19 Or Lenhve = "tauthaloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 30 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 30 Or
               Lenhve = "tauthaluoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 31 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 31 Or Lenhve = "taupharaoloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 29 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 29 Or Lenhve = "tauquetNoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 28 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 28 Or Lenhve = "tauhuanluyen" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 18 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 18 Or Lenhve = "tauMtieu" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 16 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 16 Then
            TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51})
            If Lenhve = "tauquetNoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 28 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 28 Or Lenhve = "taupharaoloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 29 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 29 Or Lenhve = "tauthaloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 30 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 30 Or Lenhve = "tauhuanluyen" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 18 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 18 Then
                liTauC = ArrayDoubleToListPoint(TQ, P, 3.0, Goc1)
                Dim Ps As IPosition71 = CenterPoint(P, liTauC(9))
                If Lenhve = "taupharaoloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 29 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 29 Or Lenhve = "tauthaloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 30 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 30 Then
                    MCircleTQ(Ps, Dorongduong * 4, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                ElseIf Lenhve = "tauquetNoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 28 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 28 Then
                    MakeText(Ps, 0, 2 / 3 * FrmMain.Instance.fLabelStyleMain.Scale, 90 + FGoc(P, liTauC(9)), "bi", "", mauChu, 0, 0, 2, 2)
                ElseIf Lenhve = "tauhuanluyen" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 18 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 18 Then
                    MakeText(Ps, 0, 2 / 3 * FrmMain.Instance.fLabelStyleMain.Scale, 90 + FGoc(P, liTauC(9)), "HL", "", mauChu, 0, 0, 2, 2)
                End If
                liTauC.Clear()
            End If
            If Lenhve = "tauChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 36 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 36 Or Lenhve = "taulaikeo" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 17 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 17 Or Lenhve = "tauquetNoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 28 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 28 Or Lenhve = "taupharaoloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 29 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 29 Then
                liTauC = ArrayDoubleToListPoint(TQ, P, 3.0, Goc1)
                Chongngam(liTauC, P, Goc1)
                TQ.Clear()
            ElseIf Lenhve = "tautieutu" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 19 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 19 Then
                TQt3 = New List(Of Double)({163.74, 73.76, 241.89, 79.09, 253.26, 79.94, 263.41, 81.34, 271.82, 83.16, 278.11, 85.28, 281.98, 87.59, 283.3, 90.0, 281.98, 92.41, 278.11, 94.72, 271.82, 96.84, 263.41, 98.66, 253.26, 100.06, 241.89, 100.91, 163.74, 106.24, 158.0, 95.73, 238.04, 93.8, 245.79, 93.19, 251.31, 91.8, 253.3, 90.0, 251.31, 88.2, 245.79, 86.81, 238.04, 86.2, 158.0, 84.27})
                liT3 = ArrayDoubleToListPoint(TQt3, P, 3.0, Goc1)
                FVungList(liT3, 4294967295, 0, mau, 0, mauChu, 1, "", 0, 0, 0, False, 2, 2)
            ElseIf Lenhve = "tauthaluoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 31 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 31 Then
                TQt3 = New List(Of Double)({68.6, 21.37, 89.03, 16.31, 96.17, 27.32, 71.4, 56.53, 113.68, 41.27, 126.09, 47.34, 115.1, 69.99, 150.23, 55.34, 166.34, 59.09, 156.36, 65.89, 121.33, 90.0, 156.36, 114.11, 166.34, 120.91, 150.23, 124.66, 115.1, 110.01, 126.09, 132.66, 113.68, 138.73, 71.4, 123.47, 96.17, 152.68, 89.03, 163.69, 68.6, 158.63, 46.36, 90.1, 72.78, 90.07, 90.19, 111.59, 94.97, 90.0, 90.19, 68.41, 72.75, 90.0, 46.38, 90.0})
                liT3 = ArrayDoubleToListPoint(TQt3, P, 3.0, Goc1)
                FVungList(liT3, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            End If
        ElseIf Lenhve = "tauten2Ong" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 10 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 10 Or Lenhve = "tauPhongloinho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 12 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 12 Then
            TQ = New List(Of Double)({125.83, 13.84, 500.0, 90.0, 130.0, 180.0, 15.0, 180.0, 62.8, 256.18, 64.18, 253.22, 77.38, 242.45, 94.65, 237.67, 113.27, 236.82, 131.68, 238.33, 148.92, 241.27, 136.97, 252.44, 126.37, 251.59, 115.61, 251.97, 105.5, 253.92, 97.03, 257.71, 91.31, 263.27, 89.27, 270.0, 91.31, 276.73, 97.03, 282.29, 105.5, 286.08, 115.61, 288.03, 126.37, 288.41, 136.97, 287.56, 148.92, 298.73, 131.68, 301.67, 113.27, 303.18, 94.65, 302.33, 77.38, 297.55, 64.18, 286.78, 62.8, 283.82, 15.0, 0.0, 130.0, 0.0, 125.83, 13.79, 96.01, 161.79, 380.78, 90.0, 96.02, 18.27})
        ElseIf Lenhve = "tauten4Ong" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 11 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 11 Or Lenhve = "tauPhongloilon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 13 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 13 Then
            TQ = New List(Of Double)({125.83, 13.84, 500.0, 90.0, 130.0, 180.0, 15.0, 180.0, 21.21, 225.0, 47.43, 198.43, 63.64, 225.0, 47.43, 251.57, 62.8, 256.18, 64.18, 253.22, 77.38, 242.45, 94.65, 237.67, 113.27, 236.82, 131.68, 238.33, 148.92, 241.27, 136.97, 252.44, 126.37, 251.59, 115.61, 251.97, 105.5, 253.92, 97.03, 257.71, 91.31, 263.27, 89.27, 270.0, 91.31, 276.73, 97.03, 282.29, 105.5, 286.08, 115.61, 288.03, 126.37, 288.41, 136.97, 287.56, 148.92, 298.73, 131.68, 301.67, 113.27, 303.18, 94.65, 302.33, 77.38, 297.55, 64.18, 286.78, 62.8, 283.82, 47.43, 288.43, 63.64, 315.0, 47.43, 341.57, 21.21, 315.0, 15.0, 0.0, 130.0, 0.0, 125.83, 13.79, 96.01, 161.79, 380.78, 90.0, 96.02, 18.27})
        ElseIf Lenhve = "tautuantieu" Or Lenhve = "tautuantieuTS" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 14 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 14 Or Lenhve = "tauTuantieuChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 38 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 38 Then
            TQ = New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 102.4, 141.77, 65.9, 152.53, 38.35, 127.55, 141.17, 124.74, 189.13, 115.17, 33.1, 65.85, 57.66, 31.59, 238.51, 109.71, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 318.04, 75.35, 455.52, 92.25, 429.72, 94.74, 266.76, 72.45, 215.48, 68.08, 404.18, 97.62, 380.42, 100.79, 166.85, 61.18, 122.01, 48.75, 341.94, 103.57, 290.34, 106.04, 88.97, 25.29, 85.89, 20.51})
            If Lenhve = "tauTuantieuChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 38 Then
                liTauC = ArrayDoubleToListPoint(TQ, P, 3.0, Goc1)
                Chongngam(liTauC, P, Goc1)
                TQ.Clear()
            End If
        ElseIf Lenhve = "tauxuongdobo" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 15 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 15 Then
            TQ = New List(Of Double)({114.57, 15.43, 386.14, 73.38, 414.01, 79.57, 529.96, 81.87, 529.97, 98.14, 413.93, 100.46, 386.14, 106.62, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 121.97, 131.15, 37.39, 125.37, 36.37, 56.95, 157.58, 120.7, 196.2, 114.21, 68.48, 26.44, 85.84, 20.81, 96.78, 33.99, 236.49, 109.89, 366.91, 102.66, 397.61, 96.51, 496.68, 95.2, 496.67, 84.81, 440.89, 84.15, 485.67, 90.0, 441.17, 95.81, 397.98, 96.44, 442.22, 90.0, 367.07, 77.37, 324.66, 75.65, 420.86, 92.81, 400.78, 95.92, 282.78, 73.47, 241.45, 70.54, 382.0, 99.35, 366.79, 102.64, 361.52, 102.82, 201.02, 66.41, 162.14, 60.26, 310.3, 104.55, 277.47, 106.81, 126.28, 50.43, 86.03, 20.76})
        ElseIf Lenhve = "taudoboKCH" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 32 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 32 Or Lenhve = "taudoboNHO" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 33 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 33 Or Lenhve = "taudoboVUA" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 34 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 34 Or Lenhve = "taudoboLon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 35 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 35 Or Lenhve = "taudemkhongkhi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 40 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 40 Then
            TQ = New List(Of Double)({114.57, 15.43, 386.14, 73.38, 414.01, 79.57, 529.96, 81.87, 529.97, 98.14, 413.93, 100.46, 386.14, 106.62, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 92.17, 150.78, 92.08, 29.25, 109.87, 43.05, 109.98, 137.01, 122.26, 131.14, 122.18, 48.9, 146.16, 56.63, 146.19, 123.39, 366.91, 102.66, 397.61, 96.51, 496.68, 95.2, 496.67, 84.81, 440.89, 84.15, 485.67, 90.0, 441.17, 95.81, 397.98, 96.44, 442.22, 90.0, 366.91, 77.34, 86.03, 20.76})
        ElseIf Lenhve = "TNgam500" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 20 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 20 Or Lenhve = "TNgam1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 21 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 21 Or Lenhve = "TNgam5000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 22 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 22 Or Lenhve = "TNgamNT1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 24 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 24 Or Lenhve = "TNgamNT3000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 25 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 25 Or Lenhve = "TNgamNT5000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 26 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 26 Then
            TQ = New List(Of Double)({110.44, 0.00, 118.34, 21.05, 165.98, 14.84, 176.06, 24.32, 132.11, 33.28, 148.76, 42.06, 172.21, 35.36, 191.14, 42.71, 170.32, 49.57, 364.82, 72.38, 504.44, 102.65, 132.15, 146.69, 108.33, 137.95, 341.1, 103.64, 444.08, 100.44, 341.1, 76.36, 152.58, 58.18, 152.53, 121.79, 128.01, 128.88, 128.07, 51.09, 108.29, 42.03, 108.22, 137.94, 90.89, 152.12, 90.98, 27.85, 85.85, 20.45, 85.85, 159.55, 108.29, 137.97, 132.11, 146.72, 110.44, 180.0})
        ElseIf Lenhve = "tauphongloicanhngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 39 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 39 Then
            TQ = New List(Of Double)({125.83, 13.84, 219.65, 69.63, 243.51, 57.73, 269.36, 61.14, 245.7, 73.77, 500.0, 90.0, 245.7, 106.23, 269.36, 118.86, 243.51, 122.27, 219.65, 110.37, 130.0, 180.0, 15.0, 180.0, 62.8, 256.18, 64.18, 253.22, 77.38, 242.45, 94.65, 237.67, 113.27, 236.82, 131.68, 238.33, 148.92, 241.27, 136.97, 252.44, 126.37, 251.59, 115.61, 251.97, 105.5, 253.92, 97.03, 257.71, 91.31, 263.27, 89.27, 270.0, 91.31, 276.73, 97.03, 282.29, 105.5, 286.08, 115.61, 288.03, 126.37, 288.41, 136.97, 287.56, 148.92, 298.73, 131.68, 301.67, 113.27, 303.18, 94.65, 302.33, 77.38, 297.55, 64.18, 286.78, 62.8, 283.82, 15.0, 0.0, 130.0, 0.0, 125.83, 13.79, 96.01, 161.79, 380.78, 90.0, 96.02, 18.27})
        ElseIf Lenhve = "tauTLHatnhan" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 23 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 23 Then
            TQ = New List(Of Double)({142.29, 39.09, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 142.23, 39.06, 120.43, 131.91, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 120.5, 48.12})
            TQt3 = New List(Of Double)({138.23, 73.78, 180.25, 86.47, 275.72, 87.7, 263.48, 82.9, 374.03, 90.0, 263.48, 97.08, 275.72, 92.3, 180.25, 93.53, 138.23, 106.22, 133.36, 95.57, 154.91, 90.0, 133.36, 84.43})
            liT3 = ArrayDoubleToListPoint(TQt3, P, 3.0, Goc1)
            FVungList(liT3, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If

        'Dem
        If Lenhve = "taukhutruc" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 5 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 5 Or Lenhve = "tauphongloicanhngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 39 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 39 Then
            TQdem = New List(Of Double)({101.03, 33.05, 380.78, 90.0, 96.01, 161.79, 96.01, 18.27, 100.99, 33.0, 80.57, 136.95, 281.43, 90.0, 80.62, 43.12})
        ElseIf Lenhve = "tauten2Ong" Or Lenhve = "tauPhongloinho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 10 Or FrmMain.Instance.cbTauHQ.SelectedIndex = 12 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 10 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 12 Then
            TQdem = New List(Of Double)({101.03, 33.05, 380.78, 90.0, 96.01, 161.79, 96.01, 18.27, 100.99, 33.0, 80.57, 136.95, 281.43, 90.0, 80.62, 43.12})
        ElseIf Lenhve = "tauten4Ong" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 11 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 11 Or Lenhve = "tauPhongloilon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 13 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 13 Then
            TQdem = New List(Of Double)({101.03, 33.05, 380.78, 90.0, 96.01, 161.79, 96.01, 18.27, 100.99, 33.0, 80.57, 136.95, 281.43, 90.0, 80.62, 43.12})
        ElseIf Lenhve = "tauxuongdobo" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 15 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 15 Then
            TQdem = New List(Of Double)({97.56, 34.46, 366.91, 77.34, 442.22, 90.0, 366.91, 102.66, 85.85, 159.55, 85.85, 20.45, 97.45, 34.36, 78.1, 135.23, 352.35, 99.05, 406.02, 90.0, 352.35, 80.95, 78.24, 44.87})
        ElseIf Lenhve = "taudoboKCH" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 32 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 32 Or Lenhve = "taudoboNHO" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 33 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 33 Or Lenhve = "taudoboVUA" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 34 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 34 Or Lenhve = "taudoboLon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 35 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 35 Or Lenhve = "taudemkhongkhi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 40 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 40 Then
            TQdem = New List(Of Double)({97.56, 34.46, 366.91, 77.34, 442.22, 90.0, 366.91, 102.66, 85.85, 159.55, 85.85, 20.45, 97.45, 34.36, 78.1, 135.23, 352.35, 99.05, 406, 90.0, 352.35, 80.95, 78.24, 44.87})
        ElseIf Lenhve = "TNgam500" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 20 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 20 Or Lenhve = "TNgam1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 21 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 21 Or Lenhve = "TNgam5000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 22 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 22 Or Lenhve = "TNgamNT1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 24 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 24 Or Lenhve = "TNgamNT3000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 25 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 25 Or Lenhve = "TNgamNT5000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 26 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 26 Then
            TQdem = New List(Of Double)({85.85, 20.45, 341.1, 76.36, 444.08, 100.44, 341.1, 103.64, 100.39, 143.25, 78.43, 130.03, 305.67, 99.5, 384.58, 97.54, 319.26, 80.91, 305.67, 80.5, 78.39, 49.95, 100.35, 142.28, 85.85, 159.55})
        ElseIf Lenhve = "TauTLHatnhan" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 23 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 23 Then
            TQdem = New List(Of Double)({140.11, 54.96, 368.88, 77.4, 482.81, 90.0, 368.88, 102.6, 120.43, 131.91, 120.43, 48.09, 140.03, 54.94, 127.32, 115.81, 356.88, 98.94, 437.18, 90.0, 356.88, 81.06, 127.41, 64.1})
        Else
            DemTau(P, Goc1)
        End If

        'TRang bi
        If Lenhve = "TauTuantieuChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 39 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 39 Or Lenhve = "tautuanduonghangnhe" Or Lenhve = "tautuanduonghangnang" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 3 Or FrmMain.Instance.cbTauHQ.SelectedIndex = 4 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 3 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 4 Then
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 145.29, 244.75, 525.67, 244.75, 259.03)
        ElseIf Lenhve = "taukhutruc" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 5 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 5 Then
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 58.4, 115.0, 499.0, 115.0, 251.73)
        ElseIf Lenhve = "tauhove" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 6 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 6 Then
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 103.3, 195.1, 525.67, 195.1, 259.03)
        ElseIf Lenhve = "tauphaonho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 7 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 7 Then
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 105.0, 215.0, 525.67, 215.0, 259.03)
        ElseIf Lenhve = "tauphaolon" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 8 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 8 Then
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 105.0, 215.0, 525.67, 215.0, 259.03)
        ElseIf Lenhve = "tautenluanho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 9 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 9 Or Lenhve = "tauChongngam" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 36 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 36 Then
            If Lenhve = "tautenluanho" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 9 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 9 Then
                FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 1
            End If
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 145.29, 244.75, 525.67, 244.75, 259.03)
        ElseIf Lenhve = "tauten2Ong" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 10 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 10 Or Lenhve = "tauten4Ong" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 11 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 11 Then
            FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 1
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 58.4, 115.0, 499.0, 115.0, 251.73)
        ElseIf Lenhve = "tauMtieu" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 16 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 16 Then
            FrmMain.Instance.cbTenluahaiquan.SelectedIndex = 5
            TLRDMT(P, Goc1, Tyle * 3.0, mau, 145.29, 244.75, 525.67, 244.75, 259.03)
        End If

        If TQ.Count > 0 Then
            liTauC = ArrayDoubleToListPoint(TQ, P, 3.0, Goc1)
            If Lenhve = "taudoboVUA" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 34 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 34 Then
                liTauC.RemoveRange(15, 4)
            ElseIf Lenhve = "taudoboKCH" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 32 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 32 Or Lenhve = "taudoboNHO" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 33 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 33 Or Lenhve = "taudemkhongkhi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 40 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 40 Then
                liTauC.RemoveRange(11, 8)

                If Lenhve = "taudoboNHO" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 33 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 33 Then
                    Dim NHO As New List(Of Double)({87.48, 162.13, 120.33, 90.0, 87.48, 17.87})
                    Dim LiNHO As List(Of IPosition71) = ArrayDoubleToListPoint(NHO, P, 3.0, Goc1)
                    Dim Geo As IGeometry = ListtoGeo(LiNHO).SpatialOperator.Union(ListtoGeo(liTauC))
                    liTauC.Clear()
                    liTauC = GeoToList(Geo)
                ElseIf Lenhve = "taudemkhongkhi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 40 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 40 Then
                    Dim Pks As IPosition71 = CenterPoint(liTauC(1), liTauC(7))
                    Dim ps1 As IPosition71 = Pks.Move(Dorongduong * 2.5, 270 + FGoc(P, liTauC(19)), 0)
                    Dim ps2 As IPosition71 = Pks.Move(Dorongduong * 2.5, 90 + FGoc(P, liTauC(19)), 0)
                    MCircleTQ(ps1, Dorongduong * 2.5, 4294967295, Dorongduong * 1.2, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                    MCircleTQ(ps2, Dorongduong * 2.5, 4294967295, Dorongduong * 1.2, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                End If

            ElseIf Lenhve = "TNgam500" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 20 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 20 Or Lenhve = "TNgamNT1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 24 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 24 Then
                liTauC.RemoveRange(16, 8)
            ElseIf Lenhve = "TNgam1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 21 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 21 Or Lenhve = "TNgamNT3000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 25 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 25 Then
                liTauC.RemoveRange(16, 4)
            End If

            If Lenhve = "TNgamNT1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 24 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 24 Or Lenhve = "TNgamNT3000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 25 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 25 Or Lenhve = "TNgamNT5000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 26 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 26 Then
                liTauC.RemoveRange(14, 1)
            End If
            FVungList(liTauC, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
        End If

        If TQdem.Count > 0 Then
            liTauD = ArrayDoubleToListPoint(TQdem, P, 3.0, Goc1)
            If Lenhve = "TNgamNT1000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 24 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 24 Or Lenhve = "TNgamNT3000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 25 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 25 Or Lenhve = "TNgamNT5000" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 26 Or FrmMain.Instance.cbTauKtraBatgiuApgiai.SelectedIndex = 26 Then
                liTauD.RemoveRange(7, 2)
                liTauD.RemoveRange(2, 1)
            End If
            FVungList(liTauD, 4294967295, 0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        End If

        If Lenhve = "tautuantieuTS" Then
            Dim Pc As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 12, FGoc(liTauC(3), liTauC(4)), 0)
            MakeText(Pc, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(liTauC(3), liTauC(4)), "TS", "", mauChu, 0, 0, 2, 4)
        ElseIf Lenhve = "Luongraquet" Then
            Dim TQv As New List(Of Double)({0.0, 0.0, 65.81, 270.0, 128.56, 210.8, 307.24, 248.9, 307.24, 291.1, 128.25, 329.2, 65.81, 270.0})
            Dim LiV1 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQv, P, 3.0, Goc1)

            Dim GeoV As IGeometry = ListtoGeo(LiV1).SpatialOperator.buffer(-Dorongduong * 1.5)
            Dim LiVd1 As List(Of IPosition71) = GeoToList(GeoV)
            LiVd1.RemoveRange(0, 1)
            FDuongList(LiV1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(LiVd1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
        End If

        SLenhve3DMs()
    End Sub

    Private Sub Chongngam(liTauC As List(Of IPosition71), P As IPosition71, Goc As Double)
        Dim Geo As IGeometry = ListtoGeo(liTauC)
        Dim TQChongngam As List(Of Double)
        If Lenhve = "taulaikeo" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 17 Then
            TQChongngam = New List(Of Double)({15.0, 164.25, 27.28, 236.64, 36.74, 227.12, 49.66, 224.61, 62.61, 226.25, 74.93, 229.87, 86.21, 234.55, 96.17, 239.86, 104.61, 245.55, 111.34, 251.49, 116.25, 257.58, 119.23, 263.77, 120.23, 270, 119.23, 276.23, 116.25, 282.42, 87.88, 276.45, 89.97, 270, 87.88, 263.55, 81.9, 257.95, 72.95, 254.3, 62.73, 254.18, 54.04, 259.48, 50.49, 270, 54.04, 280.52, 62.73, 285.82, 72.95, 285.7, 15.0, 15.75})
        ElseIf Lenhve = "tauquetNoi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 28 Then
            TQChongngam = New List(Of Double)({87.48, 162.13, 120.33, 90.0, 75.22, 90.0, 50.22, 143.16, 50.21, 36.68, 75.18, 89.98, 120.29, 89.99, 87.48, 17.87})
        ElseIf Lenhve = "taupharaoloi" Or FrmMain.Instance.cbTauHQ.SelectedIndex = 29 Then
            TQChongngam = New List(Of Double)({87.48, 162.13, 120.33, 90.0, 87.48, 17.87})
        Else
            TQChongngam = New List(Of Double)({15.0, 164.25, 27.28, 236.64, 36.74, 227.12, 49.66, 224.65, 62.61, 226.25, 74.93, 229.87, 86.21, 234.55, 96.17, 239.86, 104.61, 245.55, 111.34, 251.49, 116.25, 257.58, 119.23, 263.77, 120.23, 270, 119.23, 276.23, 116.25, 282.42, 111.34, 288.51, 104.61, 294.45, 96.17, 300.14, 86.58, 305.22, 73.23, 285.61, 81.9, 282.05, 87.88, 276.45, 89.97, 270, 87.88, 263.55, 81.9, 257.95, 72.95, 254.3, 62.73, 254.18, 54.04, 259.48, 50.49, 270, 54.04, 280.52, 62.73, 285.82, 72.95, 285.7, 86.21, 305.45, 74.93, 310.13, 62.61, 313.75, 49.66, 315.39, 36.74, 312.88, 27.28, 303.36, 15.0, 15.75})
        End If
        Dim LiCngam As List(Of IPosition71) = ArrayDoubleToListPoint(TQChongngam, P, 3.0, Goc)
        Dim GeoC As IGeometry = Geo.SpatialOperator.Union(ListtoGeo(LiCngam))
        FVungList(GeoToList(GeoC), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
        liTauC.Clear()
    End Sub

    Private Sub TLRDMT(Pk As IPosition71, goc1 As Double, hesoTyle As Double, Mau As IColor71, kc1 As Double, kc2 As Double, kc3 As Double, kc4 As Double, kc5 As Double) 'TL Doi khong, Doi hai, Muc tieu, Trc thang
        Dim kc As Double = 0
        Dim liG As New List(Of IPosition71), TQ As List(Of Double)
        Select Case FrmMain.Instance.cbTenluahaiquan.SelectedIndex
            Case 1
                kc = kc1
            Case 2
                kc = kc2
            Case 3
                kc = kc3
            Case 4
                kc = kc4
            Case 5
                kc = kc5
        End Select

        Select Case FrmMain.Instance.cbTenluahaiquan.SelectedIndex
            Case 0
                Exit Sub
            Case 1 'TL Doi hai
                Dim P As IPosition71 = Pk.Move(kc * hesoTyle, 90 - goc1, 0)
                TQ = New List(Of Double)({29.05, 0.0, 33.29, 71.34, 129.71, 85.29, 124.31, 80.31, 194.9, 90.0, 124.31, 99.69, 129.71, 94.71, 33.29, 108.66, 29.05, 180.0, 4.39, 180.0, 7.52, 90.0, 4.39, 0.0})
                liG = ArrayDoubleToListPoint(TQ, P, 3.0, goc1)
            Case 2  'TL Doi khong
                Dim P As IPosition71 = Pk.Move(kc * hesoTyle, 90 - goc1, 0)
                Dim Goc2 As Double = goc1 + 90
                If goc1 > 90 Then
                    If goc1 < 270 Then
                        Goc2 = goc1 + 270
                    End If
                End If
                TQ = New List(Of Double)({73.42, 90.0, 20.96, 177.1, 13.2, 143.79, 38.91, 254.11, 54.52, 223.34, 45.55, 209.49, 64.66, 200.29, 95.23, 230.44, 83.44, 241.63, 70.6, 235.84, 70.6, 304.16, 83.44, 298.37, 95.23, 309.56, 64.66, 339.71, 45.55, 330.51, 54.52, 316.66, 38.91, 285.89, 13.2, 36.21, 20.96, 2.9})
                liG = ArrayDoubleToListPoint(TQ, P, 3.0, Goc2)
            Case 3  'Ra da
                Dim P As IPosition71 = Pk.Move(kc * hesoTyle, 90 - goc1, 0)
                Dim Goc2 As Double = goc1 + 90
                If goc1 > 90 Then
                    If goc1 < 270 Then
                        Goc2 = goc1 + 270
                    End If
                End If
                TQ = New List(Of Double)({10.5, 0.0, 102.09, 84.1, 105.19, 74.88, 96.06, 70.26, 106.24, 58.33, 119.93, 67.04, 121.24, 65.62, 107.99, 56.86, 122.32, 47.66, 148.11, 64.95, 139.83, 73.65, 123.21, 66.65, 121.96, 68.05, 138.95, 74.93, 134.78, 84.56, 123.86, 81.65, 127.98, 106.75, 140.08, 107.4, 148.74, 116.01, 126.81, 116.32, 128.29, 117.62, 150.2, 117.13, 162.18, 124.49, 115.29, 128.75, 102.31, 118.49, 125.34, 117.7, 123.86, 116.37, 100.8, 116.87, 92.62, 103.87, 105.19, 105.12, 102.09, 95.9, 10.5, 180.0})
                liG = ArrayDoubleToListPoint(TQ, P, 3.0, Goc2)
            Case 4  'Truc thang
                Dim P As IPosition71 = Pk.Move(kc * hesoTyle, 90 - goc1, 0)
                Dim Goc2 As Double = goc1 + 90
                If goc1 > 90 Then
                    If goc1 < 270 Then
                        Goc2 = goc1 + 270
                    End If
                End If
                TQ = New List(Of Double)({75.73, 277.97, 13.03, 323.68, 66.47, 328.76, 57.75, 349.8, 23.46, 26.49, 64.81, 28.73, 79.37, 44.27, 32.01, 67.67, 43.9, 61.33, 56.21, 64.36, 66.28, 71.47, 72.76, 80.38, 75.0, 90.0, 72.76, 99.62, 66.28, 108.53, 56.21, 115.64, 43.9, 118.67, 32.01, 112.33, 79.37, 135.73, 64.82, 151.27, 23.46, 153.51, 57.75, 190.2, 66.47, 211.24, 13.03, 216.32, 75.73, 262.03})
                liG = ArrayDoubleToListPoint(TQ, P, 3.0, Goc2)
            Case 5  'Muc tieu
                Dim GocXoay As Double = 48.85
                Dim P1 As IPosition71 = Pk.Move(kc * hesoTyle, GocXoay - goc1, 0)
                Dim Goc2 As Double = goc1 + 90
                If goc1 > 90 Then
                    If goc1 < 270 Then
                        Goc2 = goc1 + 270
                        GocXoay = 131.15
                        P1 = Pk.Move(kc * hesoTyle, GocXoay - goc1, 0)
                    End If
                End If
                TQ = New List(Of Double)({62.49, 279.67, 30.87, 290.04, 30.87, 300.0, 30.87, 315.0, 30.87, 330.0, 30.87, 345.0, 30.87, 0.0, 9.69, 0.0, 9.69, 330.0, 9.69, 300.0, 9.69, 270.0, 9.69, 240.0, 9.69, 210.0, 9.69, 180.0, 9.69, 150.0, 9.69, 120.0, 9.69, 90.0, 9.69, 60.0, 9.69, 30.0, 9.69, 0.59, 30.87, 0.19, 30.87, 15.0, 30.87, 30.0, 30.87, 45.0, 30.87, 60.0, 30.87, 75.0, 30.87, 90.0, 30.87, 105.0, 30.87, 120.0, 30.87, 135.0, 30.87, 150.0, 30.87, 165.0, 30.87, 180.0, 30.87, 195.0, 30.87, 210.0, 30.87, 225.0, 30.87, 240.0, 30.87, 249.96, 62.49, 260.33})
                liG = ArrayDoubleToListPoint(TQ, P1, 3.0, Goc2)
        End Select
        FVungList(liG, 4294967295, 0, Mau, 0, Mau, 1, "", 0, 0, 0, False, 2, 4)
    End Sub

    Public Sub TauVT()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({100.25, 45.75, 149.34, 50.15, 197.73, 54.58, 244.94, 59.01, 290.69, 63.43, 334.7, 67.86, 376.72, 72.29, 416.49, 76.72, 453.77, 81.14, 488.34, 85.57, 520.0, 90.0, 488.34, 94.43, 453.77, 98.86, 416.49, 103.28, 376.72, 107.71, 334.7, 112.14, 290.69, 116.57, 244.94, 120.99, 197.73, 125.42, 149.34, 129.85, 100.06, 134.28, 50.18, 138.7, 0.0, 0.0, 50.18, 41.3, 100.06, 45.72, 99.95, 63.03, 56.48, 73.38, 39.93, 90.0, 56.48, 106.62, 99.95, 116.97, 145.41, 118.23, 190.74, 116.78, 235.26, 114.19, 278.54, 111.02, 320.25, 107.52, 360.12, 103.81, 397.88, 99.95, 433.3, 96.01, 466.16, 91.99, 480.07, 90.0, 466.16, 88.01, 433.3, 83.99, 397.88, 80.05, 360.12, 76.19, 320.25, 72.48, 278.54, 68.98, 235.26, 65.81, 190.74, 63.22, 145.41, 61.77, 100.15, 63.02, 106.75, 73.43, 146.83, 71.6, 188.43, 70.77, 229.9, 71.85, 270.56, 73.94, 309.93, 76.64, 347.67, 79.72, 383.49, 83.06, 417.13, 86.58, 446.22, 90.0, 417.13, 93.42, 383.49, 96.94, 347.67, 100.28, 309.93, 103.36, 270.56, 106.06, 229.9, 108.15, 188.43, 109.23, 146.83, 108.4, 106.56, 103.51, 73.78, 90.0, 106.56, 73.47, 133.96, 57.18, 178.83, 59.88, 218.75, 62.45, 254.07, 65.08, 286.45, 67.64, 315.7, 70.29, 343.02, 72.83, 360.12, 75.43, 393.92, 78.05, 417.75, 80.7, 440.73, 83.23, 462.44, 86.01, 419.24, 98.35, 379.37, 102.64, 438.3, 83.72, 414.97, 81.16, 343.89, 106.15, 310.77, 109.23, 391.24, 78.55, 360.23, 75.94, 279.08, 112.06, 248.41, 114.32, 338.93, 73.36, 312.34, 70.89, 218.22, 116.4, 188.32, 118.37, 282.95, 68.26, 250.15, 65.8, 158.44, 119.55, 128.47, 120.1, 214.21, 63.33, 173.39, 61.07, 98.38, 119.73, 68.25, 115.18})
        If Lenhve = "TauVTnuocngoai" Then
            mau = mauXanh
        Else
            mau = mau
        End If
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 49, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 25, 70, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        If Lenhve = "TauVTquansu" Or Lenhve = "TauVTnuocngoai" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 71, 104, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "vantaitauthuyen" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 106, 109, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "TauQuany" Or Lenhve = "TauBanhvien" Then
            Benhven(Goc1)
        ElseIf Lenhve = "TauhoNuoc" Or Lenhve = "TauhodauDS" Then
            Nuoc(Goc1)
        ElseIf Lenhve = "TauhodauQS" Then
            Chodau(Goc1)
        End If
        SLenhve3DMs()
    End Sub

    Private Sub Chodau(Goc As Double)
        Dim TQ As New List(Of Double)({32.7, 62.7, 85.11, 79.85, 133.96, 57.18, 178.83, 59.88, 118.28, 82.71, 151.6, 84.32, 218.75, 62.45, 254.07, 65.08, 185.01, 85.35, 218.46, 86.06, 286.45, 67.64, 314.09, 70.29, 251.93, 86.59, 285.41, 86.99, 343.02, 72.92, 368.8, 75.4, 318.91, 87.3, 352.42, 87.56, 393.32, 78.05, 417.49, 80.7, 385.93, 87.77, 419.45, 87.95, 442.25, 83.23, 462.44, 86.01, 452.97, 88.1, 490.23, 88.25, 490.23, 91.75, 32.7, 117.3})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc), 0, 27, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
    End Sub

    Private Sub Benhven(Goc As Double)
        Dim TQ As New List(Of Double)({215.52, 86.01, 245.46, 86.5, 249.1, 79.59, 278.66, 80.71, 275.41, 86.88, 305.37, 87.18, 305.37, 92.82, 275.41, 93.12, 278.66, 99.29, 249.1, 100.41, 245.46, 93.5, 215.52, 93.99, 224.41, 71.02, 340.91, 77.64, 340.91, 102.36, 200.74, 111.32, 200.74, 68.68, 224.22, 71.0, 217.37, 102.76, 311.72, 98.86, 311.72, 81.14, 217.56, 77.25})
        If Lenhve = "TauQuany" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc), 12, 21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
    End Sub

    Private Sub Nuoc(Goc As Double)
        Dim TQ As New List(Of Double)({55.19, 74.23, 467.13, 88.16, 480.07, 90.0, 467.13, 91.84, 55.19, 105.77, 39.93, 90.0})
        If Lenhve = "TauhoNuoc" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc), 0, 5, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc), 0, 5, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
    End Sub

    Public Sub TauDanhcaVutrang()
        Dim k(100) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Tyle * 3.0
        If Lenhve = "TauDanhcaNN" Then
            mau = mauXanh
        Else
            mau = mau
        End If
        KHTauDanhca(FrmMain.Instance.mPointClick, Goc1, mau, mau2)
        SLenhve3DMs()
    End Sub

    Public Sub TauDanhcaDansu()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({160.07, 46.37, 396.72, 73.84, 496.7, 90.0, 396.72, 106.16, 159.92, 133.68, 0.0, 0.0, 159.92, 46.32, 150.91, 57.79, 43.44, 90.0, 150.91, 122.21, 377.68, 102.3, 453.26, 90.0, 377.68, 77.7, 151.08, 57.83, 148.63, 68.1, 363.25, 81.22, 417.06, 90.0, 363.25, 98.78, 148.45, 111.93, 79.64, 90.0, 148.45, 68.07})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 13, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 7, 20, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub CanoHQ()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({52.29, 0.0, 103.7, 0.0, 109.56, 15.89, 124.99, 35.22, 148.71, 52.05, 176.51, 65.23, 206.23, 75.96, 236.59, 85.08, 253.54, 90.0, 236.59, 94.92, 206.23, 104.04, 176.51, 114.77, 148.71, 127.95, 124.99, 144.78, 109.56, 164.11, 103.7, 180.0, 52.09, 0.0, 60.11, 29.94, 81.04, 158.27, 98.94, 137.02, 125.02, 120.14, 154.17, 107.76, 181.08, 98.81, 200.37, 93.14, 213.21, 90.0, 192.28, 84.57, 168.1, 102.51, 154.03, 107.71, 133.08, 115.73, 170.1, 78.03, 154.17, 72.24, 148.69, 70.45, 106.22, 130.54, 98.88, 136.88, 86.41, 148.83, 127.8, 61.44, 125.02, 59.86, 107.48, 50.19, 46.92, 139.94, 43.4, 44.09, 89.8, 34.93, 81.04, 21.73, 60.28, 29.85})
        Dim LiT As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)
        If Lenhve = "Canotrinhsat" Then
            Dim Pk As IPosition71 = LiT(8).Move(Dorongduong * 8, FGoc(LiT(24), LiT(8)), 0)
            MakeText(Pk, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(LiT(8), LiT(24)), "TS", "", mauChu, 1, 0, 0, 2)
        End If
        If Lenhve = "canoDS" Then
            LiT.RemoveRange(26, 3)
            LiT.RemoveRange(29, 3)
            LiT.RemoveRange(32, 2)
        ElseIf Lenhve = "canoBMKT" Then
            Dim LiDuong As New List(Of IPosition71) From {LiT(20), LiT(36)}
            FDuongList(LiDuong, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        End If
        FVungList(LiT, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
        Dim TQdem As New List(Of Double)({31.42, 72.69, 81.04, 158.27, 98.94, 137.02, 125.02, 120.14, 154.17, 107.76, 181.08, 98.81, 200.37, 93.14, 213.21, 90.0, 198.33, 86.31, 184.41, 82.04, 154.17, 72.24, 125.02, 59.86, 98.94, 42.98, 81.04, 21.73, 31.48, 72.34, 55.82, 80.15, 73.18, 48.73, 79.44, 53.18, 107.75, 68.84, 137.82, 79.71, 168.17, 88.27, 174.2, 90.0, 168.17, 91.73, 137.82, 100.29, 107.75, 111.16, 79.44, 126.82, 73.18, 131.27, 55.79, 80.35})
        FVungPoint(ArrayPoint(TQdem, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 27, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Xuongcheotay()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({142.52, 57.57, 184.44, 62.04, 225.45, 66.5, 265.11, 70.96, 303.2, 75.41, 339.47, 79.85, 373.72, 84.29, 413.52, 90.0, 373.72, 95.71, 339.47, 100.15, 303.2, 104.59, 265.11, 109.04, 225.45, 113.5, 184.44, 117.96, 142.33, 122.46, 99.37, 127.0, 76.88, 128.77, 116.77, 211.09, 90.38, 221.3, 41.63, 132.38, 0.0, 0.0, 41.63, 47.62, 90.38, 318.16, 116.77, 328.91, 76.88, 51.23, 99.37, 53.0, 142.33, 57.54, 137.78, 69.74, 99.84, 70.45, 63.86, 76.88, 43.95, 90.0, 63.86, 103.12, 95.79, 90.0, 64.05, 77.01, 100.02, 70.55, 171.54, 90.0, 99.84, 109.55, 137.78, 110.26, 176.89, 108.71, 215.23, 106.13, 252.44, 102.99, 288.24, 99.53, 322.39, 95.86, 354.65, 92.04, 369.57, 90.0, 354.65, 87.96, 322.39, 84.14, 288.24, 80.47, 252.44, 77.01, 215.23, 73.87, 176.89, 71.29, 137.98, 69.75, 137.78, 69.74, 99.84, 70.45, 63.86, 76.88, 43.95, 90.0, 63.86, 103.12, 99.84, 109.55, 137.78, 110.26, 176.89, 108.71, 215.23, 106.13, 252.44, 102.99, 288.24, 99.53, 322.39, 95.86, 354.65, 92.04, 369.57, 90.0, 354.65, 87.96, 322.39, 84.14, 288.24, 80.47, 252.44, 77.01, 215.23, 73.87, 176.89, 71.29, 137.98, 69.75, 139.14, 80.12, 174.35, 79.43, 209.65, 80.47, 244.22, 82.48, 277.66, 85.88, 309.67, 88.06, 326.91, 90.0, 309.67, 91.94, 277.66, 94.92, 244.22, 97.52, 209.65, 99.53, 174.35, 100.57, 138.94, 99.88, 104.55, 95.74, 86.61, 90.0, 104.55, 84.26, 138.94, 80.12})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 51, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 52, 89, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub MinNeoDay()
        Dim Goc1 As Double = 270
        If Lenhve = "thuyloiday" Then
            MinDay(FrmMain.Instance.mPointClick, Goc1, 0)
        Else
            MinNeo(FrmMain.Instance.mPointClick, Goc1, 0)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub MinNeo(P As IPosition71, goc As Double, goc1 As Double)
        If Lenhve = "tuyenthuyloineo" Then
            goc1 += 90
        End If
        Dim Pk As IPosition71 = P.Move(Dorongduong * 6, goc1, 0)
        Dim TQ As New List(Of Double)({56.04, 0.0, 56.04, 15.0, 56.04, 30.0, 56.04, 45.0, 56.04, 60.0, 56.04, 74.51, 179.85, 84.9, 195.38, 66.47, 214.05, 68.63, 258.76, 76.34, 253.97, 81.9, 206.17, 75.2, 204.18, 77.49, 252.92, 83.79, 251.45, 89.54, 200.23, 84.58, 199.61, 86.99, 251.52, 91.46, 253.43, 97.19, 199.88, 94.26, 200.69, 96.66, 254.63, 99.08, 259.83, 104.6, 205.17, 103.7, 207.33, 105.97, 262.08, 106.38, 270.32, 111.54, 215.68, 112.45, 197.17, 114.69, 179.73, 94.67, 56.04, 105.49, 56.04, 120.0, 56.04, 135.0, 56.04, 150.0, 56.04, 165.0, 56.04, 180.0, 56.04, 195.0, 56.04, 210.0, 56.04, 225.0, 56.04, 240.0, 56.04, 255.0, 56.04, 270.0, 56.04, 285.0, 56.04, 300.0, 56.04, 315.0, 56.04, 330.0, 56.04, 345.0, 56.04, 359.95, 26.08, 359.95, 26.08, 330.0, 26.08, 300.0, 26.08, 270.0, 26.08, 240.0, 26.08, 210.0, 26.08, 180.0, 26.08, 150.0, 26.08, 120.0, 26.08, 90.0, 26.08, 60.0, 26.08, 30.0, 26.08, 0.0, 14.21, 0.0, 14.21, 30.0, 14.21, 60.0, 14.21, 90.0, 14.21, 120.0, 14.21, 150.0, 14.21, 180.0, 14.21, 210.0, 14.21, 240.0, 14.21, 270.0, 14.21, 300.0, 14.21, 330.0})
        FVungPoint(ArrayPoint(TQ, Pk, 3.0, goc), 0, 60, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pk, 3.0, goc), 61, 72, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub MinDay(P As IPosition71, goc As Double, goc1 As Double)
        If Lenhve = "tuyenthuyloiday" Then
            goc1 += 90
        End If
        Dim Pk As IPosition71 = P.Move(Dorongduong * 2, goc1, 0)
        Dim TQ As New List(Of Double)({56.04, 0.0, 56.04, 15.0, 56.04, 30.0, 56.04, 45.0, 56.04, 60.0, 56.04, 74.51, 61.05, 75.78, 97.47, 37.39, 110.9, 45.7, 144.76, 65.27, 136.13, 74.99, 94.96, 56.71, 90.6, 61.17, 134.19, 78.48, 131.49, 89.35, 81.47, 76.97, 79.99, 82.87, 131.67, 93.03, 135.39, 103.79, 80.85, 100.98, 82.88, 106.72, 137.64, 107.21, 147.14, 116.67, 93.36, 121.77, 98.07, 125.97, 151.11, 119.53, 165.07, 127.2, 114.79, 136.25, 101.87, 144.48, 61.05, 104.22, 56.04, 105.49, 56.04, 120.0, 56.04, 135.0, 56.04, 150.0, 56.04, 165.0, 56.04, 180.0, 56.04, 195.0, 56.04, 210.0, 56.04, 225.0, 56.04, 240.0, 56.04, 255.0, 56.04, 270.0, 56.04, 285.0, 56.04, 300.0, 56.04, 315.0, 56.04, 330.0, 56.04, 345.0, 56.04, 359.95, 26.08, 359.95, 26.08, 330.0, 26.08, 300.0, 26.08, 270.0, 26.08, 240.0, 26.08, 210.0, 26.08, 180.0, 26.08, 150.0, 26.08, 120.0, 26.08, 90.0, 26.08, 60.0, 26.08, 30.0, 26.08, 0.0, 14.21, 0.0, 14.21, 30.0, 14.21, 60.0, 14.21, 90.0, 14.21, 120.0, 14.21, 150.0, 14.21, 180.0, 14.21, 210.0, 14.21, 240.0, 14.21, 270.0, 14.21, 300.0, 14.21, 330.0})
        FVungPoint(ArrayPoint(TQ, Pk, 3.0, goc), 0, 60, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, Pk, 3.0, goc), 61, 72, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub Thuyloitroi()
        Dim TQ As New List(Of Double)({56.04, 0.0, 56.04, 15.0, 56.04, 30.0, 56.04, 45.0, 56.04, 60.0, 56.04, 74.51, 160.97, 84.61, 160.97, 95.18, 56.04, 105.49, 56.04, 120.0, 56.04, 135.0, 56.04, 150.0, 56.04, 165.0, 56.04, 180.0, 56.04, 195.0, 56.04, 210.0, 56.04, 225.0, 56.04, 240.0, 56.04, 254.55, 160.97, 264.61, 160.97, 275.39, 56.04, 285.67, 56.04, 300.0, 56.04, 315.0, 56.04, 330.0, 56.04, 345.0, 56.04, 359.95, 26.08, 359.95, 26.08, 330.0, 26.08, 300.0, 26.08, 270.0, 26.08, 240.0, 26.08, 210.0, 26.08, 180.0, 26.08, 150.0, 26.08, 120.0, 26.08, 90.0, 26.08, 60.0, 26.08, 30.0, 26.08, 0.0, 14.21, 0.0, 14.21, 30.0, 14.21, 60.0, 14.21, 90.0, 14.21, 120.0, 14.21, 150.0, 14.21, 180.0, 14.21, 210.0, 14.21, 240.0, 14.21, 270.0, 14.21, 300.0, 14.21, 330.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, 0), 0, 39, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, 0), 40, 51, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub ThuyloiAngten()
        Dim TQ As New List(Of Double)({56.04, 0.0, 56.04, 15.0, 56.04, 30.0, 56.04, 45.0, 56.04, 60.0, 56.04, 74.51, 139.25, 83.81, 129.28, 76.75, 228.0, 90.0, 129.28, 103.25, 139.43, 96.22, 56.04, 105.49, 56.04, 120.0, 56.04, 135.0, 56.04, 150.0, 56.04, 165.0, 56.04, 180.0, 56.04, 195.0, 56.04, 210.0, 56.04, 225.0, 56.04, 240.0, 56.04, 254.55, 139.25, 263.76, 129.28, 256.86, 228.0, 270.0, 129.28, 282.88, 139.43, 276.03, 56.04, 285.67, 56.04, 300.0, 56.04, 315.0, 56.04, 330.0, 56.04, 345.0, 56.04, 359.95, 26.08, 359.95, 26.08, 330.0, 26.08, 300.0, 26.08, 270.0, 26.08, 240.0, 26.08, 210.0, 26.08, 180.0, 26.08, 150.0, 26.08, 120.0, 26.08, 90.0, 26.08, 60.0, 26.08, 30.0, 26.08, 0.0, 14.21, 0.0, 14.21, 30.0, 14.21, 60.0, 14.21, 90.0, 14.21, 120.0, 14.21, 150.0, 14.21, 180.0, 14.21, 210.0, 14.21, 240.0, 14.21, 270.0, 14.21, 300.0, 14.21, 330.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, 90), 0, 45, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, 90), 46, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Xuongkhonoi()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({100.25, 45.75, 149.34, 50.15, 197.73, 54.58, 244.94, 59.01, 290.69, 63.43, 334.7, 67.86, 376.72, 72.29, 416.49, 76.72, 453.77, 81.14, 488.34, 85.57, 520.0, 90.0, 488.34, 94.43, 453.77, 98.86, 416.49, 103.28, 376.72, 107.71, 334.7, 112.14, 290.69, 116.57, 244.94, 120.99, 197.73, 125.42, 149.34, 129.85, 100.06, 134.28, 50.18, 138.7, 0.0, 0.0, 50.18, 41.3, 100.06, 45.72, 99.95, 63.03, 56.48, 73.38, 39.93, 90.0, 56.48, 106.62, 68.77, 110.81, 95.68, 90.0, 68.83, 69.27, 98.3, 63.33, 144.52, 90.0, 97.08, 116.57, 99.95, 116.97, 145.41, 118.23, 190.74, 116.78, 235.26, 114.19, 278.54, 111.02, 320.25, 107.52, 360.12, 103.81, 397.88, 99.95, 433.3, 96.01, 466.16, 91.99, 480.07, 90.0, 466.16, 88.01, 456.36, 86.93, 424.32, 90.0, 456.27, 93.06, 434.41, 95.83, 375.48, 90.0, 435.34, 84.27, 433.3, 83.99, 397.88, 80.05, 360.12, 76.19, 320.25, 72.48, 278.54, 68.98, 235.26, 65.81, 190.74, 63.22, 145.41, 61.77, 100.15, 63.02, 99.95, 63.03, 56.48, 73.38, 39.93, 90.0, 56.48, 106.62, 99.95, 116.97, 145.41, 118.23, 190.74, 116.78, 235.26, 114.19, 278.54, 111.02, 320.25, 107.52, 360.12, 103.81, 397.88, 99.95, 433.3, 96.01, 466.16, 91.99, 480.07, 90.0, 466.16, 88.01, 433.3, 83.99, 397.88, 80.05, 360.12, 76.19, 320.25, 72.48, 278.54, 68.98, 235.26, 65.81, 190.74, 63.22, 145.41, 61.77, 100.15, 63.02, 106.75, 73.43, 146.83, 71.6, 188.43, 70.77, 229.9, 71.85, 270.56, 73.94, 309.93, 76.64, 347.67, 79.72, 383.49, 83.06, 417.13, 86.58, 446.22, 90.0, 417.13, 93.42, 383.49, 96.94, 347.67, 100.28, 309.93, 103.36, 270.56, 106.06, 229.9, 108.15, 188.43, 109.23, 146.83, 108.4, 106.56, 103.51, 73.78, 90.0, 106.56, 73.47})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 61, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 62, 107, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TNkinhTV()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim Goc2 As Double = Goc1 + 90
        Dim P As IPosition71 = FrmMain.Instance.mPointClick.Move(240 * Tyle * 3.0, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({239.89, 180.0, 252.87, 161.56, 224.62, 159.14, 212.03, 171.84, 202.14, 171.44, 207.32, 164.62, 178.57, 162.06, 172.53, 169.95, 211.95, 8.14, 209.82, 0, 241.19, 185.95, 239.89, 180.0, 209.82, 0.0, 211.3, 353.21})
        If Lenhve = "tnKTVkoRo" Then
            FVungPoint(ArrayPoint2(TQ, P, 3.0, Goc1, Goc2), 0, 9, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint2(TQ, P, 3.0, Goc1, Goc2), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        FVungPoint(ArrayPoint2(TQ, P, 3.0, Goc1, Goc2), 10, 13, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TNchongTN()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim Goc2 As Double = Goc1 + 90
        Dim P As IPosition71 = FrmMain.Instance.mPointClick.Move(280 * Tyle * 3.0, 90 - Goc1, 0)
        Dim P1 As IPosition71 = P.Move(159.94 * Tyle * 3.0, 174.62 - Goc2, 0)
        Dim TQ As New List(Of Double)({227.32, 180.0, 229.32, 172.48, 40.72, 47.46, 163.33, 110.32, 295.23, 148.75, 254.16, 173.22, 229.36, 172.48, 227.39, 180.0, 282.39, 180.0, 336.59, 147.03, 301.82, 142.64, 334.53, 135.81, 313.72, 131.99, 278.57, 138.89, 271.12, 137.5, 288.6, 133.84, 268.69, 129.22, 249.82, 132.85, 187.67, 102.58, 70.57, 25.16, 118.28, 14.69, 124.26, 18.19, 134.69, 21.16, 146.65, 22.53, 159.06, 22.53, 171.09, 21.45, 162.85, 12.09, 152.97, 11.9, 144.79, 9.76, 140.94, 6.11, 142.8, 2.19, 149.69, -0.59, 159.29, -1.48, 168.8, -0.52, 175.86, 1.78, 178.97, 4.81, 177.49, 7.95, 171.71, 10.59, 162.94, 12.08, 171.17, 21.43, 182.05, 19.56, 191.45, 17.07, 198.9, 14.15, 204.14, 10.95, 206.99, 7.58, 207.34, 4.15, 205.19, 0.75, 200.62, -2.51, 193.76, -5.52, 184.88, -8.14, 174.31, -10.22, 162.53, -11.56, 150.15, -11.89, 137.97, -10.94, 126.98, -8.44, 118.37, -4.25, 114.41, 0, 229.32, 172.48, 40.72, 47.46, 163.33, 110.32, 295.23, 148.75, 254.16, 173.22, 229.36, 172.48, 233.94, 166.4, 261.02, 150.59, 145.99, 118.61, 58.47, 109.85, 233.84, 166.4})
        FVungPoint(ArrayPoint2(TQ, P, 3.0, Goc1, Goc2), 0, 56, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint2(TQ, P, 3.0, Goc1, Goc2), 57, 67, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub '

    Public Sub Xuaduoi()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
        PointHQ = P2
        GocHQ = 270 + (MkGoc(P1, P2) * 180 / Math.PI)
        TauHaiquan()
        Dim Pmt As IPosition71 = P2.Move(Dorongduong * 28, FGoc(P1, P2), 0)
        Dim LiV As List(Of IPosition71) = MTCong(Pmt, (MkGoc(P1, P2) * 180 / Math.PI))
        FVungList(LiV, 4294967295, 0, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        Dim Pt1 As IPosition71 = LiV(10).Move(Dorongduong * 10, 180 + FGoc(P1, P2), 0)
        Dim Pt2 As IPosition71 = Pt1.Move(Dorongduong * 6, 270 + FGoc(P1, P2), 0)
        FrmMain.Instance.cbTauHQ.SelectedIndex = System.Convert.ToInt32(FrmMain.Instance.TxtGhichuKH.Text)
        PointHQ = Pt2
        mau = mau3
        mau2 = mau4
        Dim Pmt2 As IPosition71 = Pt2.Move(Dorongduong * 28, FGoc(P1, P2), 0)
        Dim LiV2 As List(Of IPosition71) = MTCong(Pmt2, (MkGoc(P1, P2) * 180 / Math.PI))
        FVungList(LiV2, 4294967295, 0, mau, 1, mau3, 1, "", 0, 0, 0, False, 2, 2)
        TauHaiquan()
        SLenhve3DMs()
    End Sub

    Public Sub KHTauDanhca(P As IPosition71, Goc1 As Double, mauT3 As IColor71, mauT4 As IColor71)
        Dim TQ As New List(Of Double)({160.07, 46.37, 396.72, 73.84, 496.7, 90.0, 396.72, 106.16, 159.92, 133.68, 0.0, 0.0, 159.92, 46.32, 150.91, 57.79, 104.4, 63.02, 240.45, 109.49, 200.03, 113.65, 76.12, 69.53, 43.44, 90.0, 150.91, 122.21, 377.68, 102.3, 453.26, 90.0, 377.68, 77.7, 329.01, 75.85, 428.78, 93.17, 408.82, 96.24, 287.08, 73.73, 245.69, 70.89, 390.17, 99.62, 377.56, 102.27, 365.89, 102.67, 205.14, 66.91, 166.05, 61.09, 323.65, 104.36, 281.77, 106.55, 133.49, 59.4, 151.08, 57.83, 150.91, 57.79, 43.44, 90.0, 150.91, 122.21, 377.68, 102.3, 453.26, 90.0, 377.68, 77.7, 151.08, 57.83, 148.63, 68.1, 363.25, 81.22, 417.06, 90.0, 363.25, 98.78, 148.45, 111.93, 79.64, 90.0, 148.45, 68.07})
        FVungPoint(ArrayPoint(TQ, P, 3.0, Goc1), 0, 30, 4294967295, 0, mauT3, 0, mauT3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, P, 3.0, Goc1), 31, 44, 4294967295, 0, mauT4, 0, mauT4, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

#Region "        Ellipse, Circle, Rectanggle, Brigde"

    Public Sub Ellipse()
        FrmMain.Instance.fLabelStyleMain.Scale = SLabelStyleTQ(FrmMain.Instance.sgworldMain).Scale
        Dim Pm As IPosition71, P1 As IPosition71 = Nothing, P2 As IPosition71 = Nothing
        Dim Kc, Goc As Double
        If Lenhve = "ellipse" Or Lenhve = "danhcatgiaothong" Or Lenhve = "KvTuantieu" Or Lenhve = "kvVaybat" Or Lenhve = "Tauchuachay" Then 'Or Lenhve = "KnNguytrangcongTrSrada"
            P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
            P2 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
            Pm = CenterPoint(P1, P2)
            Goc = FGoc(P1, P2)
            Kc = FKc(P1, P2) / 2
            If Lenhve = "danhcatgiaothong" Or Lenhve = "Tauchuachay" Then
                Kc = 300.0
                Pm = FrmMain.Instance.mPointClick
            End If
        Else
            If Lenhve = "KnNguytrangcongTrSrada" Then
                Kc = 450.0
            Else

                Kc = 400.0
            End If
            Pm = FrmMain.Instance.mPointClick
            Goc = 90
        End If

        Dim Ps1 As IPosition71 = Pm.Move(Kc, 0 + Goc, 0)
        Dim Ps2 As IPosition71 = Pm.Move(Kc, 180 + Goc, 0)
        Dim LiN As List(Of IPosition71) = PointKhungEllipse(Ps1, Ps2)
        Dim LiS As List(Of IPosition71) = Curveline(LiN, 12)
        LiS.RemoveRange(96, 1)
        LiS.RemoveRange(0, 1)
        LiS.Add(LiS(0))

        Dim GeoD As IGeometry = ListtoGeo(LiS).SpatialOperator.buffer(-Dorongduong * 1.5)
        If Lenhve = "KvCoBLchongdoi" Or Lenhve = "KvBLHH" Or Lenhve = "kvvksinhhoc" Or Lenhve = "KVgayroi" Or Lenhve = "MatcuBLLD" Or Lenhve = "KvCanxoadauvet" Or Lenhve = "KvBLLD" Or Lenhve = "KvBaoloanVTr" Or Lenhve = "KvDukienBLkhongVTr" Or Lenhve = "Matcu" Then
            FDuongList(LiS, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, True, 2, 0, 3) ' 2, False, 2)
            If Lenhve = "KvBLHH" Then
                FVungList(GeoToList(GeoD), 4294967295, Dorongduong * 1.5, mau4, 1, mauHH, 1, "", 0, 0, 0, False, 2, 3)
            Else
                FDuongList(GeoToList(GeoD), 4294967295, "", 0, 0, mau4, Dorongduong * 1.5, True, 2, 0, 3) ' 2, False, 2)
            End If
        Else

            If Lenhve = "KvTuantieu" Or Lenhve = "kvVaybat" Then
                Dim LiT As New List(Of IPosition71)
                AddPointToList(LiT, LiS, 2, 92)
                Dim Ps As IPosition71 = LiT(0).Move(Dorongduong * 40, 180 + FGoc(LiT(0), LiT(LiT.Count - 1)), 0)
                LiT.Add(Ps)
                Dim GeoD1 As IGeometry = ListtoGeo(LiT).SpatialOperator.buffer(-Dorongduong * 1.5)
                Dim LiTd As List(Of IPosition71) = GeoToList(GeoD1)
                LiTd.RemoveRange(0, 1)
                FDuongList(LiT, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, True, 2, 0, 3) ' 2, False, 2)
                FDuongList(LiTd, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, True, 2, 0, 0) ' 2, False, 2)
                PointHQ = LiT(0).Move(Dorongduong * 8, 180 + FGoc(LiT(0), LiT(LiT.Count - 1)), 0)
                GocHQ = 90 + (MkGoc(LiT(0), LiT(LiT.Count - 1)) * 180 / Math.PI)
                TauHaiquan()
                If Lenhve = "kvVaybat" Then
                    PointHQ = CenterPoint(P1, P2).Move(-Dorongduong * 10, FGoc(P1, P2), 0)
                    GocHQ = 270 + (MkGoc(P1, P2) * 180 / Math.PI)
                    mau = mau3
                    mau2 = mau4
                    FrmMain.Instance.cbTauHQ.SelectedIndex = System.Convert.ToInt32(FrmMain.Instance.TxtGhichuKH.Text)
                    TauHaiquan()
                End If

            Else
                FDuongList(LiS, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                FDuongList(GeoToList(GeoD), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 0) ' 2, False, 2)
            End If

        End If

        If Lenhve = "danhcatgiaothong" Or Lenhve = "Tauchuachay" Then
            Dim Pk1 As IPosition71 = Pm.Move(5 * Dorongduong, FGoc(P1, P2), 0)
            Dim Pk2 As IPosition71 = Pm.Move(5 * Dorongduong, FGoc(P1, P2) + 180, 0)
            If Lenhve = "danhcatgiaothong" Then
                MCircleTQ(Pm, Dorongduong * 3.0, 4294967295, 0, mauChu, 0, mauChu, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(Pk1, Dorongduong * 3.0, 4294967295, 0, mau, 0, mauChu, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(Pk2, Dorongduong * 3.0, 4294967295, 0, mau, 0, mauChu, 1, "", 0, 0, 0, False, 2, 2)
            Else
                MCircleTQ(Pk1, Dorongduong * 3.0, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(Pk2, Dorongduong * 3.0, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                MakeText(Pm, 0, FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "CC", loaiKH, mauChu, 0, 0, 0, 2)
            End If
        ElseIf Lenhve = "KVgayroi" Or Lenhve = "KvMTkoDemat" Then
            Dim LiGayroi As New List(Of IPosition71) From {LiS(49), LiS(74), LiS(75), LiS(76), LiS(77), LiS(78), LiS(79), LiS(80), LiS(42), LiS(41), LiS(40), LiS(39), LiS(38), LiS(37), LiS(86), LiS(87), LiS(88), LiS(89), LiS(90), LiS(91), LiS(32), LiS(31), LiS(30), LiS(29), LiS(28), LiS(27), LiS(26), LiS(2)}
            If Lenhve = "KVgayroi" Then
                FDuongList(LiGayroi, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
            Else
                FDuongList(LiGayroi, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
            End If
        ElseIf Lenhve = "KnNguytrangcongTrSrada" Then
            Dim Pd1 As IPosition71 = CenterPoint(LiS(93), LiS(23))
            Dim Pd2 As IPosition71 = CenterPoint(LiS(35), LiS(80))
            RauHinhV(Pd1, Goc, 1.5, 0)
            RauHinhV(Pd2, Goc, 1.5, 0)
        ElseIf Lenhve = "TrTiepnhanQNDB" Or Lenhve = "TrtiepnhanPTKT" Or Lenhve = "TrNhan_GiaoDB" Or Lenhve = "TrTbiHH" Then
            Dim LiPcon As New List(Of IPosition71) From {LiS(11), LiS(58)}
            FDuongList(LiPcon, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 2) ' 2, False, 2)
            Dim Pk1 As IPosition71 = CenterPoint(FrmMain.Instance.mPointClick, LiS(35))
            If Lenhve = "TrtiepnhanPTKT" Then
                MakeText(Pk1, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "PTKT", loaiKH, mauChu, 0, 0, 0, 2)
            ElseIf Lenhve = "TrTbiHH" Then
                MakeText(Pk1, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "TBKTHH", loaiKH, mauChu, 0, 0, 0, 2)
            Else
                MakeText(Pk1, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "QNDB", loaiKH, mauChu, 0, 0, 0, 2)
            End If
            Dim Pk2 As IPosition71 = CenterPoint(FrmMain.Instance.mPointClick, LiS(82))
            MakeText(Pk2, 0, FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, FrmMain.Instance.TxtGhichuKH.Text, loaiKH, mauChu, 0, 0, 0, 2)
            If Lenhve = "TrNhan_GiaoDB" Then
                MCircleTQ(FrmMain.Instance.mPointClick, Dorongduong * 16.0, 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            End If
        ElseIf Lenhve = "Bieutinh" Or Lenhve = "KvDukienBLkhongVTr" Or Lenhve = "KvBaoloanVTr" Or Lenhve = "KvCanxoadauvet" Or Lenhve = "KvBLHH" Then
            Dim LiPcon As New List(Of IPosition71) From {LiS(45), LiS(71), LiS(72), LiS(73), LiS(74), LiS(75), LiS(76), LiS(40), LiS(39), LiS(38), LiS(37), LiS(36), LiS(35), LiS(81), LiS(82), LiS(83), LiS(84), LiS(85), LiS(86), LiS(30), LiS(29), LiS(28), LiS(27), LiS(26), LiS(25), LiS(92)}
            If Lenhve = "Bieutinh" Then
                FDuongList(LiPcon, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            ElseIf Lenhve = "KvBLHH" Then
                FDuongList(LiPcon, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            Else
                FDuongList(LiPcon, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            End If
        ElseIf Lenhve = "KvBLLD" Then
            MakeText(FrmMain.Instance.mPointClick, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "A2", loaiKH, mau3, 0, 0, 0, 2)
        ElseIf Lenhve = "Matcu" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "mc/A2", loaiKH, mau3, 0, 0, 0, 2)
        ElseIf Lenhve = "KvCanxoadauvet" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, 270 + Goc, "tt", loaiKH, mauChu, 0, 0, 0, 2)
        ElseIf Lenhve = "kvnganchanChotgiu" Or Lenhve = "kvvksinhhoc" Or Lenhve = "muctieuphaibaove" Then
            Dim Pl1 As IPosition71 = CenterPoint(LiS(33), LiS(61))
            Dim Pl2 As IPosition71 = CenterPoint(LiS(58), LiS(83))
            Dim Pl3 As IPosition71 = CenterPoint(LiS(14), LiS(81))
            Dim Pl4 As IPosition71 = CenterPoint(LiS(9), LiS(37))
            Dim LiPcon1, LiPcon2, LiPcon3, LiPcon4 As New List(Of IPosition71)
            AddPointToList(LiPcon1, LiS, 41, 53)
            LiPcon1.Add(Pl1)
            AddPointToList(LiPcon2, LiS, 64, 78)
            LiPcon2.Add(Pl2)
            AddPointToList(LiPcon3, LiS, 88, 94)
            AddPointToList(LiPcon3, LiS, 0, 5)
            LiPcon3.Add(Pl3)
            AddPointToList(LiPcon4, LiS, 17, 31)
            LiPcon4.Add(Pl4)
            Dim SMau As IColor71
            If Lenhve = "kvnganchanChotgiu" Or Lenhve = "muctieuphaibaove" Then
                SMau = mau
            Else
                SMau = mauNau
            End If
            FVungList(LiPcon1, 4294967295, 0, mau, 0, SMau, 1, "", 0, 0, 0, False, 2, 4)
            FVungList(LiPcon2, 4294967295, 0, mau, 0, SMau, 1, "", 0, 0, 0, False, 2, 4)
            FVungList(LiPcon3, 4294967295, 0, mau, 0, SMau, 1, "", 0, 0, 0, False, 2, 4)
            FVungList(LiPcon4, 4294967295, 0, mau, 0, SMau, 1, "", 0, 0, 0, False, 2, 4)
        ElseIf Lenhve = "KvCoBLchongdoi" Then

        End If

        If Lenhve = "KvBaoloanVTr" Then
            Dim GeoT1 As IGeometry = ListtoGeo(LiS).SpatialOperator.buffer(-Dorongduong * 5.0)
            FDuongList(GeoToList(GeoT1), 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub ChieusauTrS()
        LiDay.Clear()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Kc As Double = FKc(P1, P2)

        Dim Pm1 As IPosition71 = P1.Move(3 / 8 * Val(FrmMain.Instance.TxtGhichuKH.Text), 270 + FGoc(P1, P2), 0)
        Dim Pm2 As IPosition71 = P1.Move(3 / 8 * Val(FrmMain.Instance.TxtGhichuKH.Text), 90 + FGoc(P1, P2), 0)

        Dim Pd1 As IPosition71 = P2.Move(1 / 5 * Kc, 0 + FGoc(P1, P2), 0)
        Dim LiT1 As List(Of IPosition71) = Ns2Point(P1, Pd1)
        Dim Pd2 As IPosition71 = P2.Move(2.3 / 4 * Kc, 0 + FGoc(P1, P2), 0)
        Dim LiT2 As List(Of IPosition71) = Ns2Point(P1, Pd2)
        Dim Pd3 As IPosition71 = P2.Move(3 / 4 * Kc, 0 + FGoc(P1, P2), 0)
        Dim LiT3 As List(Of IPosition71) = Ns2Point(P1, Pd3)

        VongTrS(LiT1(0), LiT1(1), FKc(P2, Pd1), FGoc(P1, P2), 1)
        VongTrS(LiT2(0), LiT2(1), FKc(Pd2, Pd1), FGoc(P1, P2), 2)
        VongTrS(LiT3(0), LiT3(1), FKc(Pd3, Pd1), FGoc(P1, P2), 3)

        Dim LiK1 As New List(Of IPosition71) From {Pm1, LiDay(4)}
        Dim LiK2 As New List(Of IPosition71) From {Pm2, LiDay(5)}
        FDuongList(LiK1, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(LiK2, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 2) ' 2, False, 2)
        SLenhve3DMs()
    End Sub

    Function Ns2Point(P1 As IPosition71, P2 As IPosition71) As List(Of IPosition71)
        Dim Kc As Double
        If Lenhve = "hambetong" Or Lenhve = "hamphao" Or Lenhve = "hamVK" Then
            Kc = 10 * Dorongduong
        Else
            Kc = 1 / 2 * Val(FrmMain.Instance.TxtGhichuKH.Text)
        End If
        Dim Pm1 As IPosition71 = P2.Move(Kc, 270 + FGoc(P1, P2), 0)
        Dim Pm2 As IPosition71 = P2.Move(Kc, 90 + FGoc(P1, P2), 0)
        Dim LiN As New List(Of IPosition71) From {Pm1, Pm2}
        Ns2Point = LiN
    End Function

    Function PointKhungEllipse(P1 As IPosition71, P2 As IPosition71) As List(Of IPosition71)
        Dim Goc As Double
        If Lenhve = "ellipse" Or Lenhve = "ChieusauTS" Or Lenhve = "danhcatgiaothong" Or Lenhve = "Tauchuachay" Or Lenhve = "KvTuantieu" Or Lenhve = "kvVaybat" Then
            Goc = FGoc(P1, P2)
        Else
            Goc = 270
        End If
        Dim Pc As IPosition71 = CenterPoint(P1, P2)
        Dim Pk1 As IPosition71 = CenterPoint(P1, Pc)
        Dim Pk2 As IPosition71 = CenterPoint(Pc, P2)
        Dim Pk2s As IPosition71 = CenterPoint(Pk2, P2)
        Dim Pk1s As IPosition71 = CenterPoint(Pk1, P1)
        Dim Kc As Double = FKc(P1, P2) / 4
        Dim dF As Double
        If Lenhve = "KvTuantieu" Or Lenhve = "kvVaybat" Then
            dF = 1.6
        Else
            dF = 1.3
        End If

        Dim Pc1 As IPosition71 = Pc.Move(Kc * dF, 90 + Goc, 0)
        Dim Pc2 As IPosition71 = Pc.Move(Kc * dF, 270 + Goc, 0)
        Dim Pk11 As IPosition71 = Pk1s.Move(dF * 2 / 3 * Kc, 90 + Goc, 0)
        Dim Pk12 As IPosition71 = Pk1s.Move(dF * 2 / 3 * Kc, 270 + Goc, 0)
        Dim Pk21 As IPosition71 = Pk2s.Move(dF * 2 / 3 * Kc, 90 + Goc, 0)
        Dim Pk22 As IPosition71 = Pk2s.Move(dF * 2 / 3 * Kc, 270 + Goc, 0)
        Dim LiN As List(Of IPosition71)
        If Lenhve = "ChieusauTS" Then
            LiN = New List(Of IPosition71) From {Pk22, P2, Pk21, Pc1, Pk11, P1, Pk12}
        Else
            LiN = New List(Of IPosition71) From {Pc2, Pk22, P2, Pk21, Pc1, Pk11, P1, Pk12, Pc2}
        End If
        PointKhungEllipse = LiN
    End Function

    Private ReadOnly LiDay As New List(Of IPosition71)
    Function VongTrS(P1 As IPosition71, P2 As IPosition71, Kdc As Double, Goc As Double, STT As Integer) As List(Of IPosition71)
        Dim Kc As Double = FKc(P1, P2) / 4
        Dim LiN As List(Of IPosition71) = PointKhungEllipse(P1, P2)
        LiDay.Add(LiN(4))
        LiDay.Add(LiN(2))
        Dim LiS As List(Of IPosition71) = Curveline(LiN, 12)
        Dim Geo1 As IGeometry = ListtoGeo(LiS)
        Dim Geo2 As IGeometry = Geo1.SpatialOperator.buffer(-Dorongduong * 2)
        Dim LiD As List(Of IPosition71) = GeoToList(Geo2)
        LiD.RemoveRange(71, 1)
        LiD.RemoveRange(0, 1)

        Dim LiC1, LiC2, LiC3, LiD1, LiD2, LiD3 As New List(Of IPosition71)
        AddPointToList(LiC1, LiS, 0, 28)
        AddPointToList(LiC2, LiS, 32, 40)
        AddPointToList(LiC3, LiS, 44, 72)

        '//////////
        AddPointToList(LiD1, LiD, 0, 28)
        AddPointToList(LiD2, LiD, 32, 40)
        AddPointToList(LiD3, LiD, 44, 70)

        Dim Pday1 As IPosition71 = Nothing, Pday2 As IPosition71 = Nothing
        If STT = 1 Then
            Pday1 = LiS(0).Move(Kdc - (2 / 3 * Kc), 180 + Goc, 0)
            Pday2 = LiS(72).Move(Kdc - (2 / 3 * Kc), 180 + Goc, 0)
        ElseIf STT = 2 Then
            Pday2 = LiDay(0)
            Pday1 = LiDay(1)
            Dauchuthap(LiS(30), FGoc(P1, P2), mau, 1.5)
            Dauchuthap(LiS(42), FGoc(P1, P2), mau, 1.5)
        ElseIf STT = 3 Then
            Pday2 = LiDay(2)
            Pday1 = LiDay(3)
            MCircleTQ(LiS(30), Dorongduong * 4, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(LiS(42), Dorongduong * 4, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            LiD3.Reverse()
            LiD3.RemoveRange(0, 22)
            LiD1.RemoveRange(0, 23)

            LiC3.Reverse()
            LiC3.RemoveRange(0, 23)
            LiC1.RemoveRange(0, 23)
            LiC3.Reverse()
        End If

        LiC3.Add(Pday2)
        LiC1.Reverse()
        LiC1.Add(Pday1)
        FDuongList(LiC1, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 3) ' 2, False, 2)
        FDuongList(LiC2, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 3) ' 2, False, 2)
        FDuongList(LiC3, 4294967295, "", 0, 0, mau, Dorongduong * 2, False, 2, 0, 3) ' 2, False, 2)

        FDuongList(LiD1, 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 1) ' 2, False, 2)
        FDuongList(LiD2, 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 1) ' 2, False, 2)
        FDuongList(LiD3, 4294967295, "", 0, 0, mau2, Dorongduong * 2, False, 2, 0, 1) ' 2, False, 2)
    End Function

#Region "     CauTQ"

    Public Sub CauTQ()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai =  FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim Pc As IPosition71 = CenterPoint(P1, P2)
        Dim CRong As Double

        If Lenhve = "hanhlangbay" Or Lenhve = "Daihiepdong" Or Lenhve = "Luongraquet" Then
            CRong = Val(FrmMain.Instance.TxtGhichuKH.Text) / 2
        ElseIf Lenhve = "diadao" Or Lenhve = "Caubicuontroi" Or Lenhve = "Caugiabangmatphanxa" Or Lenhve = "caucogioi" Or Lenhve = "CaugoCaubetong" Or Lenhve = "Causat" Or Lenhve = "Caungam" Or Lenhve = "Cautreo" Or Lenhve = "Cautre" Or Lenhve = "CauPMP" Or Lenhve = "Caubidanhpha" Or Lenhve = "Dexungyeu" Or Lenhve = "Dengapnuoc" Or Lenhve = "Devo" Or Lenhve = "KVPhanlucham" Then
            CRong = 130 * Tyle
        ElseIf Lenhve = "Caugiabangmatphanxa" Or Lenhve = "hambetong" Or Lenhve = "BenloiOto" Or Lenhve = "BenloiXT" Or Lenhve = "BenvuotBangthuyen" Or Lenhve = "BenvuotsongPha" Or Lenhve = "BenPhatuhanh" Then
            CRong = 300 * Tyle
        ElseIf Lenhve = "BenvuotsongnhieuPT" Then
            CRong = 500 * Tyle
        Else
            CRong = 100 * Tyle
        End If

        Dim Goc1 As Double = MkGoc(P1, P2) * 180.0 / Math.PI
        Dim P11 As IPosition71 = P1.Move(CRong, 0 - Goc1, 0)
        Dim P12 As IPosition71 = P1.Move(CRong, 180 - Goc1, 0)
        Dim P21 As IPosition71 = P2.Move(CRong, 0 - Goc1, 0)
        Dim P22 As IPosition71 = P2.Move(CRong, 180 - Goc1, 0)

        Dim t1 As IPosition71 = Nothing, t2 As IPosition71 = Nothing, t3 As IPosition71 = Nothing, t4 As IPosition71 = Nothing

        If Lenhve = "tuyenVCkhongno" Or Lenhve = "tuyenVChonhop" Or Lenhve = "tuyenRMhonhop" Or Lenhve = "tuyenRMbangTrT" Or Lenhve = "tuyenTochucDoihinh" Or Lenhve = "tuyenkhoinguytrang" Or Lenhve = "Moibayhongngoai" Then
            t1 = P2.Move(Dorongduong * 4, 90 + FGoc(P1, P2), 0)
            t2 = P2.Move(Dorongduong * 4, 270 + FGoc(P1, P2), 0)
            t3 = P1.Move(Dorongduong * 4, 90 + FGoc(P1, P2), 0)
            t4 = P1.Move(Dorongduong * 4, 270 + FGoc(P1, P2), 0)
        End If

        If Lenhve = "Daihiepdong" Or Lenhve = "Luongraquet" Then
            Dim LiP12 As List(Of IPosition71) = PointDaihiepdong(P12, 180, 135, 270, Goc1)
            Dim LiP11 As List(Of IPosition71) = PointDaihiepdong(P11, 0, 225, 90, Goc1)
            Dim LiP22 As List(Of IPosition71) = PointDaihiepdong(P22, 180, 225, 90, Goc1)
            Dim LiP21 As List(Of IPosition71) = PointDaihiepdong(P21, 0, 135, 270, Goc1)
            Dim liRectangle As New List(Of IPosition71) From {LiP11(4), LiP12(4), LiP22(4), LiP21(4)}
            FVungList(liRectangle, 4294967295, 0, mau, 0, mau, 1, "Red.gif", 50.0, 50.0, 135.0, False, 2, -1)
            If Lenhve = "Daihiepdong" Then
                LiP11.RemoveRange(4, 1)
                LiP12.RemoveRange(4, 1)
                LiP22.RemoveRange(4, 1)
                LiP21.RemoveRange(4, 1)
                Dim liCurveP11 As List(Of IPosition71) = Curveline(LiP11, 12)
                Dim liCurveP12 As List(Of IPosition71) = Curveline(LiP12, 12)
                Dim liCurveP22 As List(Of IPosition71) = Curveline(LiP22, 12)
                Dim liCurveP21 As List(Of IPosition71) = Curveline(LiP21, 12)
                liCurveP11.Reverse()
                liCurveP12.Reverse()
                UniCruve(liCurveP21, liCurveP11)
                UniCruve(liCurveP22, liCurveP12)
                Dim GeoT As IGeometry = ListtoGeo(liCurveP21)
                Dim GeoP As IGeometry = ListtoGeo(liCurveP22)
                Dim GeoTd As IGeometry = GeoT.SpatialOperator.buffer(-Dorongduong * 1.5)
                Dim GeoPd As IGeometry = GeoP.SpatialOperator.buffer(-Dorongduong * 1.5)
                Dim LiGeoTd As List(Of IPosition71) = GeoToList(GeoTd)
                Dim LiGeoPd As List(Of IPosition71) = GeoToList(GeoPd)
                LiGeoTd.RemoveRange(0, 1)
                LiGeoTd.RemoveRange(LiGeoTd.Count - 1, 1)
                LiGeoPd.RemoveRange(0, 1)
                LiGeoPd.RemoveRange(LiGeoPd.Count - 1, 1)
                Dim LD1 As New List(Of IPosition71), LD2 As New List(Of IPosition71)
                UniCruve(LD1, LiGeoTd)
                UniCruve(LD2, LiGeoPd)
                FDuongList(LD1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2)
                FDuongList(LD2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) '
                FDuongList(liCurveP21, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                FDuongList(liCurveP22, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) '
            Else
                Dim LiCC1 As New List(Of IPosition71) From {liRectangle(0), liRectangle(3)}
                Dim LiCC2 As New List(Of IPosition71) From {liRectangle(1), liRectangle(2)}
                FDuongList(LiCC1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                FDuongList(LiCC2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                DemCau(LiCC1(1), LiCC1(0))
                DemCau(LiCC2(0), LiCC2(1))
            End If

        ElseIf Lenhve = "Dexungyeu" Or Lenhve = "Dengapnuoc" Or Lenhve = "Devo" Then
            Dim Sgiancach As Double
            If Lenhve = "Dexungyeu" Then
                Sgiancach = CRong * 2
            Else
                Sgiancach = CRong
            End If

            If Lenhve = "Dengapnuoc" Then
                Dauchuthap(Pc, FGoc(P1, P2), mauH2O, 5.0)
            ElseIf Lenhve = "Devo" Then
                Dim TQ As New List(Of Double)({17.1, 0.00, 18.25, 25.18, 21.08, 45.37, 24.42, 60.32, 27.35, 71.78, 29.31, 81.32, 30.0, 90.0, 29.31, 98.68, 27.35, 108.22, 24.42, 119.68, 21.08, 134.63, 18.25, 154.82, 17.1, 180.0, 18.25, 205.18, 21.08, 227.75, 24.42, 240.32, 27.35, 251.78, 29.31, 261.32, 30.0, 270.0, 29.31, 278.68, 27.35, 288.22, 24.42, 299.68, 21.08, 314.63, 18.25, 334.84, 17.1, 360.0})
                Dim LiS1 As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, Pc, 40.0 * Tyle, 25 + MkGoc(P1, P2) * 180 / Math.PI)
                FDuongList(LiS1, 4294967295, "", 0, 0, mauH2O, Dorongduong, False, 2, 0, 6) ' 2, False, 2)
                Dim LiS1con As New List(Of IPosition71) From {LiS1(8), LiS1(4), LiS1(3), LiS1(9), LiS1(10), LiS1(2), LiS1(1), LiS1(11), LiS1(12), LiS1(24), LiS1(23), LiS1(13), LiS1(14), LiS1(22), LiS1(21), LiS1(15), LiS1(16), LiS1(20)}
                FDuongList(LiS1con, 4294967295, "", 0, 0, mauH2O, Dorongduong * 1.2, False, 2, 0, 6) ' 2, False, 2)
            End If
            Dim Li1 As List(Of IPosition71) = Rangcua(P11, P21, CRong, Sgiancach, 270, 0)
            Dim Li2 As List(Of IPosition71) = Rangcua(P12, P22, CRong, Sgiancach, 90, 0)
            DemCau(Li1(1), Li1(0))
            DemCau(Li2(0), Li2(1))
        ElseIf Lenhve = "Manchanchongrada" Then
            Dim LiD As New List(Of IPosition71) From {P1, P2}
            FDuongList(LiD, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
            Dim Pr1 As IPosition71 = Pc.Move(FKc(P1, P2) / 4, FGoc(P1, P2), 0)
            Dim Pr2 As IPosition71 = Pc.Move(FKc(P1, P2) / 4, 180 + FGoc(P1, P2), 0)
            RauHinhV(Pc, MkGoc(P2, P1) * 180 / Math.PI, 2, 1)
            RauHinhV(Pr1, MkGoc(P2, P1) * 180 / Math.PI, 2, 1)
            RauHinhV(Pr2, MkGoc(P2, P1) * 180 / Math.PI, 2, 1)
            DemCau(P2, P1)

        ElseIf Lenhve = "tuyenVCkhongno" Or Lenhve = "tuyenVChonhop" Or Lenhve = "tuyenRMhonhop" Or Lenhve = "tuyenRMbangTrT" Or Lenhve = "Moibayhongngoai" Then

            If Lenhve = "tuyenVCkhongno" Then
                Dim d1 As IPosition71 = P2.Move(1 / 4 * FKc(P1, P2), FGoc(P1, P2), 0)
                Dim d2 As IPosition71 = P2.Move(2 / 4 * FKc(P1, P2), FGoc(P1, P2), 0)
                Dim d3 As IPosition71 = P2.Move(3 / 4 * FKc(P1, P2), FGoc(P1, P2), 0)
                Dim Lic As New List(Of IPosition71) From {t1, t2, P2, P1, t3, t4}
                FDuongList(Lic, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                Dauchuthap(d1, FGoc(P1, P2), mau, 2.5)
                Dauchuthap(d2, FGoc(P1, P2), mau, 2.5)
                Dauchuthap(d3, FGoc(P1, P2), mau, 2.5)
                DemCau(P2, P1)
            Else
                Dim d1 As IPosition71 = P2.Move(1 / 3 * FKc(P1, P2), FGoc(P1, P2), 0)
                Dim d2 As IPosition71 = P2.Move(2 / 3 * FKc(P1, P2), FGoc(P1, P2), 0)
                Dim d11 As IPosition71 = d1.Move(Dorongduong * 5, FGoc(P1, P2), 0)
                Dim d12 As IPosition71 = d1.Move(Dorongduong * 5, 180 + FGoc(P1, P2), 0)
                Dim d13 As IPosition71 = d1.Move(Dorongduong * 8.5, 180 + FGoc(P1, P2), 0)
                Dim d21 As IPosition71 = d2.Move(Dorongduong * 5, FGoc(P1, P2), 0)
                Dim d22 As IPosition71 = d2.Move(Dorongduong * 5, 180 + FGoc(P1, P2), 0)
                Dim d23 As IPosition71 = d2.Move(Dorongduong * 8.5, 180 + FGoc(P1, P2), 0)

                If Lenhve = "tuyenVChonhop" Or Lenhve = "tuyenRMhonhop" Then
                    Dim Lic As New List(Of IPosition71) From {d11, d23}
                    FDuongList(Lic, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                    Dim Lic2 As New List(Of IPosition71) From {t3, t4, P1, d21}
                    FDuongList(Lic2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                    Dim Lic3 As New List(Of IPosition71) From {t1, t2, P2, d13}
                    FDuongList(Lic3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                    DemCau(d11, d23)
                    DemCau(P2, d13)
                    DemCau(d21, P1)
                    MCircleTQ(d22, 6.5 * Dorongduong, 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                    If Lenhve = "tuyenVChonhop" Then
                        MCircleTQ(d12, 6.5 * Dorongduong, 4294967295, Dorongduong * 1.5, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
                        Dauchuthap(d11, FGoc(P1, P2), mau, 2.5)
                        Dauchuthap(d21, FGoc(P1, P2), mau, 2.5)
                    Else
                        MCircleTQ(d12, 6.5 * Dorongduong, 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
                        MCircleTQ(d11, 6.5 * Dorongduong, 4294967295, Dorongduong * 1.5, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
                        MCircleTQ(d21, 6.5 * Dorongduong, 4294967295, Dorongduong * 1.5, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
                    End If

                ElseIf Lenhve = "tuyenRMbangTrT" Or Lenhve = "Moibayhongngoai" Then
                    Dim Dx As Double
                    If Lenhve = "tuyenRMbangTrT" Then
                        Dx = Dorongduong * 3.5
                    Else
                        Dx = Dorongduong * 5.5
                    End If
                    Dim d15 As IPosition71 = d1.Move(Dx, FGoc(P1, P2), 0)
                    Dim d16 As IPosition71 = d1.Move(Dx, 180 + FGoc(P1, P2), 0)
                    Dim d25 As IPosition71 = d2.Move(Dx, FGoc(P1, P2), 0)
                    Dim d26 As IPosition71 = d2.Move(Dx, 180 + FGoc(P1, P2), 0)

                    Dim Lic3 As New List(Of IPosition71) From {d15, d26}
                    FDuongList(Lic3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                    DemCau(d15, d26)
                    Dim Lic1 As New List(Of IPosition71) From {t1, t2, P2, d16}
                    FDuongList(Lic1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                    DemCau(P2, d16)
                    Dim Lic2 As New List(Of IPosition71) From {t3, t4, P1, d25}
                    FDuongList(Lic2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                    DemCau(d25, P1)
                    Dim LiCircleC1 As List(Of IPosition71) = LiPCircle(d2, Dx, Phuongvi * 180 / Math.PI, 10)
                    Dim LiCircleC2 As List(Of IPosition71) = LiPCircle(d1, Dx, Phuongvi * 180 / Math.PI, 10)
                    LiCircleC1.Add(LiCircleC1(0))
                    If Lenhve = "tuyenRMbangTrT" Then
                        FDuongList(LiCircleC1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4)
                        FVungList(LiCircleC2, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
                        MakeText(Pc, 1.0, Tyle * 6, 0, "", "TructhangRaimin", mau3, 0, 500 * Tyle, 2, 4)
                    Else
                        Dim LiK1 As List(Of IPosition71) = Rau34(d1, 7.0, 90 + FGoc(P1, P2), mau, 2, Lenhve)
                        Dim LiK2 As List(Of IPosition71) = Rau34(d2, 7.0, 90 + FGoc(P1, P2), mau, 2, Lenhve)
                        FDuongList(LiK1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                        FDuongList(LiK2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                        Dim Geo1 As IGeometry = ListtoGeo(LiK1).SpatialOperator.buffer(-Dorongduong * 1.5)
                        Dim Geo2 As IGeometry = ListtoGeo(LiK2).SpatialOperator.buffer(-Dorongduong * 1.5)
                        FDuongList(GeoToList(Geo1), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                        FDuongList(GeoToList(Geo2), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                    End If

                End If

            End If

        ElseIf Lenhve = "DiemchuanBancanPK" Or Lenhve = "kvbaidobo" Or Lenhve = "tuyenTochucDoihinh" Or Lenhve = "tuyenTKdobo" Or Lenhve = "tuyenXPdobo" Or Lenhve = "tuyenPTdobo" Or Lenhve = "tuyenkhoinguytrang" Then
            Dim SoKhoang As Double
            Dim LiSoD As New List(Of IPosition71)

            If Lenhve = "kvbaidobo" Then
                SoKhoang = Val(FrmMain.Instance.TxtGhichuKH.Text) - 1.0
                LiSoD.Add(P1)
            Else
                SoKhoang = Val(FrmMain.Instance.TxtGhichuKH.Text) + 1
            End If

            Dim Kc As Double = FKc(P1, P2) / SoKhoang

            For i As Integer = 1 To SoKhoang - 1
                Dim Goc As Double = 180 + FGoc(P1, P2) '+ (0.5 * i))
                Dim Pk As IPosition71
                If Lenhve = "tuyenTochucDoihinh" Then
                    Dim P1k As IPosition71 = P1.Move(Dorongduong * 3.5, FGoc(P1, P2) + 270, 0) ' FGoc(P1, P2) + 270
                    Pk = P1k.Move(i * Kc, Goc, 0)
                ElseIf Lenhve = "tuyenTKdobo" Or Lenhve = "tuyenXPdobo" Then
                    Dim P1k As IPosition71 = P1.Move(Dorongduong * 0.8, FGoc(P1, P2) + 270, 0)
                    Pk = P1k.Move(i * Kc, Goc, 0)
                Else
                    Pk = P1.Move(i * Kc, Goc, 0)
                End If
                LiSoD.Add(Pk)
            Next

            If Lenhve = "kvbaidobo" Then
                LiSoD.Add(P2)
            End If

            Dim KhoangChu As Double = 0, KhoangDiem As Double

            For i As Integer = 0 To LiSoD.Count - 1
                If Lenhve = "kvbaidobo" Then
                    Hvuong(LiSoD(i), 9.0, 180 + MkGoc(P1, P2) * 180.0 / Math.PI)
                    KhoangChu = Dorongduong * 4
                    KhoangDiem = Dorongduong * 1.5
                ElseIf Lenhve = "tuyenTochucDoihinh" Or Lenhve = "tuyenTKdobo" Or Lenhve = "tuyenXPdobo" Then
                    CNhat(LiSoD(i), 9.5, 180 + MkGoc(P1, P2) * 180.0 / Math.PI, mauChu)
                    KhoangDiem = Dorongduong * 0.1
                    If Lenhve = "tuyenTKdobo" Or Lenhve = "tuyenXPdobo" Then
                        KhoangChu = -Dorongduong * 10
                    Else
                        KhoangChu = Dorongduong * 3
                    End If
                ElseIf Lenhve = "DiemchuanBancanPK" Then
                    KhoangChu = Dorongduong * 4
                    MCircleTQ(LiSoD(i), 5.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                End If
                If Not Lenhve = "tuyenPTdobo" And Not Lenhve = "tuyenkhoinguytrang" Then
                    Dim Pchu As IPosition71 = LiSoD(i).Move(KhoangChu, FGoc(P1, P2) + 270, 0)
                    MakeText(Pchu, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2) + 90, (i + 1).ToString, "", mauChu, 1, 0, 0, 2)
                End If
            Next

            If Lenhve = "tuyenTKdobo" Then
                Tamgiac(P1, 15.0, 180 + MkGoc(P1, P2) * 180.0 / Math.PI)
                Tamgiac(P2, 15.0, 180 + MkGoc(P1, P2) * 180.0 / Math.PI)
            ElseIf Lenhve = "tuyenXPdobo" Then
                Hvuong(P1, 12.0, 180 + MkGoc(P1, P2) * 180.0 / Math.PI)
                Hvuong(P2, 12.0, 180 + MkGoc(P1, P2) * 180.0 / Math.PI)
            ElseIf Lenhve = "tuyenPTdobo" Then
                MCircleTQ(P1, 3.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                MCircleTQ(P2, 3.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            ElseIf Lenhve = "tuyenkhoinguytrang" Then
                Dim Ps1 As IPosition71 = Pc.Move(FKc(P1, P2) / 8, FGoc(P1, P2), 0)
                Dim Ps2 As IPosition71 = Pc.Move(FKc(P1, P2) / 8, 180 + FGoc(P1, P2), 0)
                RauHinhV(Ps1, MkGoc(P2, P1) * 180 / Math.PI, 2, 1)
                RauHinhV(Ps2, MkGoc(P2, P1) * 180 / Math.PI, 2, 1)
            End If

            Dim Lic As List(Of IPosition71)

            If Lenhve = "tuyenTochucDoihinh" Or Lenhve = "tuyenkhoinguytrang" Then
                Lic = New List(Of IPosition71) From {t1, t2, P2, P1, t3, t4}
            Else
                If Lenhve = "kvbaidobo" Or Lenhve = "tuyenXPdobo" Or Lenhve = "tuyenTKdobo" Then
                    Dim Ps1 As IPosition71 = P1.Move(Dorongduong * 2, FGoc(P1, P2), 0) ' FGoc(P1, P2) + 270
                    Dim Ps2 As IPosition71 = P2.Move(Dorongduong * 2, 180 + FGoc(P1, P2), 0) ' FGoc(P1, P2) + 270
                    Lic = New List(Of IPosition71) From {Ps2, Ps1}
                    DemCau(Ps2, Ps1)
                Else
                    Lic = New List(Of IPosition71) From {P2, P1}
                End If
            End If

            FDuongList(Lic, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)

            If Not Lenhve = "kvbaidobo" Then
                DemCau(P2, P1)
            End If
        Else
            If Not Lenhve = "diadao" And Not Lenhve = "hambetong" And Not Lenhve = "TuyenchuyentiepChuy" And Not Lenhve = "Dexungyeu" And Not Lenhve = "Dengapnuoc" And Not Lenhve = "Devo" And Not Lenhve = "cuamoBB" And Not Lenhve = "cuamoXT" And Not Lenhve = "tuyenthoay" And Not Lenhve = "tuyendanhchan" And Not Lenhve = "TuyenMBcatcanh" And Not Lenhve = "tuyenbancodinh" And Not Lenhve = "Cautreo" And Not Lenhve = "Cautre" And Not Lenhve = "BenloiBB" And Not Lenhve = "BenloiOto" And Not Lenhve = "BenloiXT" And Not Lenhve = "BenvuotBangthuyen" And Not Lenhve = "BenvuotsongPha" And Not Lenhve = "BenPhatuhanh" And Not Lenhve = "BenvuotsongnhieuPT" And Not Lenhve = "KVPhanlucham" And Not Lenhve = "tuyenthuyloineo" And Not Lenhve = "tuyenthuyloiday" Then
                '  If Lenhve = "Caubidanhpha" Or Lenhve = "Caubicuontroi" Or Lenhve = "Phacau" Or Lenhve = "hanhlangbay" Or Lenhve = "Daihiepdong" Then
                Dim li1 As List(Of IPosition71) = Mocau(P11, 3.0, 90 + (MkGoc(P11, P12) * 180.0 / Math.PI)) 'good
                Dim li2 As List(Of IPosition71) = Mocau1(P12, 3.0, 270 + (MkGoc(P11, P12) * 180.0 / Math.PI))
                Dim li3 As List(Of IPosition71) = Mocau(P22, 3.0, 90 + (MkGoc(P22, P21) * 180.0 / Math.PI)) 'good
                Dim li4 As List(Of IPosition71) = Mocau1(P21, 3.0, 270 + (MkGoc(P22, P21) * 180.0 / Math.PI))
                Dim LiP1 As New List(Of IPosition71) From {li1(0), P11, P21, li4(0)}
                Dim LiP2 As New List(Of IPosition71) From {li2(0), P12, P22, li3(0)}
                If Lenhve = "Caubidanhpha" Or Lenhve = "Caubicuontroi" Or Lenhve = "Phacau" Then
                    Dim Pc1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P11.X + P21.X), 0.5 * (P11.Y + P21.Y), 0, 2, 0, 0, 0, 0)
                    Dim Pc2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (P12.X + P22.X), 0.5 * (P12.Y + P22.Y), 0, 2, 0, 0, 0, 0)

                    Dim Pc11 As IPosition71 = Pc1.Move(CRong * 2, 90 - Goc1, 0)
                    Dim Pc12 As IPosition71 = Pc1.Move(CRong * 2, 270 - Goc1, 0)
                    Dim Pc13 As IPosition71 = Pc1.Move(CRong, 90 - Goc1, 0)
                    Dim Pc14 As IPosition71 = Pc1.Move(CRong, 270 - Goc1, 0)

                    Dim Pc21 As IPosition71 = Pc2.Move(CRong * 2, 90 - Goc1, 0)
                    Dim Pc22 As IPosition71 = Pc2.Move(CRong * 2, 270 - Goc1, 0)
                    Dim Pc23 As IPosition71 = Pc2.Move(CRong, 90 - Goc1, 0)
                    Dim Pc24 As IPosition71 = Pc2.Move(CRong, 270 - Goc1, 0)

                    Dim Lk1 As New List(Of IPosition71) From {li1(0), P11, Pc11}
                    Dim Lk2 As New List(Of IPosition71) From {li4(0), P21, Pc12}
                    Dim Lk3 As New List(Of IPosition71) From {li2(0), P12, Pc21}
                    Dim Lk4 As New List(Of IPosition71) From {li3(0), P22, Pc22}
                    If Not Lenhve = "Phacau" Then
                        FDuongList(Lk1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
                        FDuongList(Lk2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) '
                        FDuongList(Lk3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) '
                        FDuongList(Lk4, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) '
                    Else
                        FDuongList(LiP1, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        FDuongList(LiP2, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    End If
                    If Lenhve = "Caubicuontroi" Then
                        Dauchuthap(Pc, FGoc(P1, P2), mau, 6)
                    ElseIf Lenhve = "Phacau" Then
                        Dauchuthap(Pc, FGoc(P1, P2), mau, 6)
                    Else
                        Dauchuthap(Pc, FGoc(P1, P2), mau3, 6)
                    End If
                Else
                    If Lenhve = "hanhlangbay" Or Lenhve = "Daihiepdong" Then
                        FDuongList(LiP1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        FDuongList(LiP2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    Else
                        FDuongList(LiP1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        FDuongList(LiP2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    End If
                End If

                Dim LiP1D As New List(Of IPosition71) From {li1(3), li4(3)}
                Dim LiP2D As New List(Of IPosition71) From {li2(3), li3(3)}
                If Lenhve = "hanhlangbay" Or Lenhve = "Daihiepdong" Then
                    FDuongList(LiP1D, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                    FDuongList(LiP2D, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                Else
                    FDuongList(LiP1D, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                    FDuongList(LiP2D, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
                End If

            End If

        End If

        If Lenhve = "hanhlangbay" Or Lenhve = "Daihiepdong" Then
            MB(Pc, Goc1 - 180, 3.0)
            Mask(Pc, FGoc(P1, P2), Dorongduong * 18, Dorongduong * 45)
        ElseIf Lenhve = "Luongraquet" Then
            PointHQ = Pc.Move(Dorongduong * 6, 180 + FGoc(P1, P2), 0)
            GocHQ = Goc1 + 270
            TauHaiquan()
            Mask(Pc, FGoc(P1, P2), Dorongduong * 15, Dorongduong * 48)
        ElseIf Lenhve = "Caugiabangmatphanxa" Then
            RauHinhV(Pc, 90 + MkGoc(P1, P2) * 180 / Math.PI, 1.5, 0)
        ElseIf Lenhve = "caucogioi" Then
            Dim Pd1 As IPosition71 = Pc.Move(Dorongduong * 6, 270 - Goc1, 0)
            Dim TQ As New List(Of Double)({0.01, 0.0, 100.0, 0.0, 228.43, 64.0, 249.2, 67.5, 266.92, 71.5, 281.15, 75.8, 291.55, 80.4, 297.88, 85.2, 300.0, 90.0, 297.88, 94.8, 291.55, 99.6, 281.15, 104.2, 266.92, 108.5, 249.2, 112.5, 228.43, 116.0, 100.0, 180.0, 0.0, 180.0, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 76.16, 23.2, 30.0, 89.99})
            FVungPoint(ArrayPoint(TQ, Pd1, 3.0, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        ElseIf Lenhve = "Causat" Then
            Dim LiCsPhai As List(Of IPosition71) = Causat(P11, P21)
            Dim LiCsTrai As List(Of IPosition71) = Causat(P12, P22)
            Dim LiCausat As New List(Of IPosition71) From {LiCsPhai(0), LiCsTrai(1), LiCsPhai(2), LiCsTrai(3), LiCsPhai(4)}
            FDuongList(LiCausat, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        ElseIf Lenhve = "Caungam" Then
            Rangcua(P11, P21, CRong, 2 / 3 * CRong, 90, 0)
        ElseIf Lenhve = "Cautreo" Then
            Dim LP As New List(Of IPosition71) From {P11, P21}
            Dim LP1 As New List(Of IPosition71) From {P12, P22}
            FDuongList(LP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(LP1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            MCircleTQ(P11, 3.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, -1)
            MCircleTQ(P12, 3.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, -1)
            MCircleTQ(P21, 3.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, -1)
            MCircleTQ(P22, 3.5 * Dorongduong, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, -1)
            Dim LMo1 As List(Of IPosition71) = CauTreo(P1, Goc1, CRong * 2)
            FDuongList(LMo1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            Dim LMo2 As List(Of IPosition71) = CauTreo(P2, Goc1 - 180, CRong * 2)
            FDuongList(LMo2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        ElseIf Lenhve = "TuyenchuyentiepChuy" Or Lenhve = "cuamoBB" Or Lenhve = "cuamoXT" Or Lenhve = "Cautre" Or Lenhve = "BenloiBB" Or Lenhve = "tuyenbancodinh" Or Lenhve = "tuyenthoay" Or Lenhve = "tuyendanhchan" Or Lenhve = "TuyenMBcatcanh" Or Lenhve = "tuyenthuyloineo" Or Lenhve = "tuyenthuyloiday" Then
            Dim Pk1 As IPosition71 = P1.Move(-CRong, 90 - Goc1, 0)
            Dim Pk2 As IPosition71 = P2.Move(-CRong, 270 - Goc1, 0)
            Dim li1 As List(Of IPosition71) = CauTreo(P1, Goc1, CRong)
            Dim li2 As List(Of IPosition71) = CauTreo(P2, Goc1, CRong)
            Dim LP As New List(Of IPosition71) From {Pk1, li1(1), li1(0), li1(3), li1(2), Pk1, Pk2, li2(0), li2(1), li2(2), li2(3), Pk2}
            If Lenhve = "Cautre" Then
                FDuongList(LP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            ElseIf Lenhve = "BenloiBB" Or Lenhve = "tuyenbancodinh" Or Lenhve = "tuyenthoay" Or Lenhve = "tuyenthuyloineo" Or Lenhve = "tuyenthuyloiday" Then
                Dim LiC As New List(Of IPosition71) From {LP(1), LP(4), LP(5), LP(11), LP(7), LP(10)}
                FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                If Lenhve = "tuyenthuyloineo" Or Lenhve = "tuyenthuyloiday" Then
                    Dim GocMin As Double = 90 + MkGoc(P1, P2) * 180 / Math.PI
                    Dim Pn1 As IPosition71 = P1.Move(Dorongduong * 10, 180 + FGoc(P1, P2), 0)
                    Dim Pn3 As IPosition71 = P2.Move(Dorongduong * 10, FGoc(P1, P2), 0)
                    Dim Pn2 As IPosition71 = CenterPoint(Pn1, Pn3)
                    FrmMain.Instance.sgworldMain.Creator.CreateLabel(Pn1, "Pn1", "", Nothing, "", "Pn1")
                    FrmMain.Instance.sgworldMain.Creator.CreateLabel(Pn3, "Pn3", "", Nothing, "", "Pn3")

                    If Lenhve = "tuyenthuyloiday" Then
                        MinDay(Pn1, GocMin, FGoc(P1, P2))
                        MinDay(Pn2, GocMin, FGoc(P1, P2))
                        MinDay(Pn3, GocMin, FGoc(P1, P2))
                    Else
                        MinNeo(Pn1, GocMin, FGoc(P1, P2))
                        MinNeo(Pn2, GocMin, FGoc(P1, P2))
                        MinNeo(Pn3, GocMin, FGoc(P1, P2))
                    End If
                End If
            ElseIf Lenhve = "tuyendanhchan" Or Lenhve = "TuyenMBcatcanh" Then
                Dim LiC As New List(Of IPosition71) From {LP(3), LP(5), LP(11), LP(9)}
                FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            ElseIf Lenhve = "cuamoBB" Or Lenhve = "cuamoXT" Then
                Dim LiC As New List(Of IPosition71) From {LP(2), LP(5), LP(3), LP(5), LP(11), LP(9), LP(11), LP(8)}
                FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            ElseIf Lenhve = "TuyenchuyentiepChuy" Then
                Dim LiC As New List(Of IPosition71) From {LP(5), LP(2), LP(3), LP(5), LP(11), LP(9), LP(8), LP(11)}
                FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            End If
            If Lenhve = "tuyendanhchan" Or Lenhve = "TuyenMBcatcanh" Then
                DemCau(LP(5), LP(11))
            Else
                DemCau(LP(11), LP(5))
            End If

        ElseIf Lenhve = "diadao" Or Lenhve = "hambetong" Or Lenhve = "BenloiOto" Or Lenhve = "BenloiXT" Or Lenhve = "BenvuotBangthuyen" Or Lenhve = "BenvuotsongPha" Or Lenhve = "BenPhatuhanh" Or Lenhve = "BenvuotsongnhieuPT" Or Lenhve = "KVPhanlucham" Then
            If Lenhve = "diadao" Then
                Dim C1 As IPosition71 = CenterPoint(P11, P21)
                Dim C11 As IPosition71 = C1.Move(CRong * 6, 315 + FGoc(P1, P2), 0)
                Dim C2 As IPosition71 = CenterPoint(P12, P22)
                Dim C21 As IPosition71 = CenterPoint(P12, C2)
                Dim C211 As IPosition71 = C21.Move(CRong * 6, 45 + FGoc(P1, P2), 0)
                Dim C22 As IPosition71 = CenterPoint(C2, P22)
                Dim C221 As IPosition71 = C22.Move(CRong * 6, 45 + FGoc(P1, P2), 0)
                Dim LiP1 As List(Of IPosition71) = ThreePoint(C1, FGoc(P11, P12), CRong * 1.5)
                Dim LiP2 As List(Of IPosition71) = ThreePoint(C21, FGoc(P11, P12), CRong * 1.5)
                Dim LiP3 As List(Of IPosition71) = ThreePoint(C22, FGoc(P11, P12), CRong * 1.5)
                Dim LiP4 As List(Of IPosition71) = ThreePoint(C11, FGoc(P11, P12), CRong * 1.5)
                Dim LiP5 As List(Of IPosition71) = ThreePoint(C211, FGoc(P11, P12), CRong * 1.5)
                Dim LiP6 As List(Of IPosition71) = ThreePoint(C221, FGoc(P11, P12), CRong * 1.5)

                Dim LiD1 As New List(Of IPosition71) From {P11, LiP1(1), LiP4(1)}
                Dim LiD2 As New List(Of IPosition71) From {P21, LiP1(2), LiP4(2)}
                Dim LiD3 As New List(Of IPosition71) From {P12, LiP2(1), LiP5(1)}
                Dim LiD4 As New List(Of IPosition71) From {LiP5(2), LiP2(2), LiP3(1), LiP6(1)}
                Dim LiD5 As New List(Of IPosition71) From {P22, LiP3(2), LiP6(2)}
                FDuongList(LiD1, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                FDuongList(LiD2, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                FDuongList(LiD3, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                FDuongList(LiD4, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                FDuongList(LiD5, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                DemCau(P11, P21)
                DemCau(P12, P22)
            Else
                Dim li1 As List(Of IPosition71) = CauTreo(P1, Goc1, CRong)
                Dim li2 As List(Of IPosition71) = CauTreo(P2, Goc1, CRong)
                Dim Pk1 As IPosition71 = P11.Move(-CRong, 90 - Goc1, 0)
                Dim Pk2 As IPosition71 = P12.Move(-CRong, 90 - Goc1, 0)
                Dim Pk3 As IPosition71 = P21.Move(-CRong, 270 - Goc1, 0)
                Dim Pk4 As IPosition71 = P22.Move(-CRong, 270 - Goc1, 0)
                Dim LP As New List(Of IPosition71) From {Pk1, Pk3}
                Dim LP1 As New List(Of IPosition71) From {Pk2, Pk4}
                FDuongList(LP, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
                FDuongList(LP1, 2576980377, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)

                If Lenhve = "hambetong" Then
                    TDTenluaCC(P2, FGoc(P2, P1), CRong + Dorongduong * 2, Dorongduong * 1.5, mau, mau2)
                ElseIf Lenhve = "KVPhanlucham" Then
                    Dim Pn1 As IPosition71 = Pc.Move(Dorongduong * 7, FGoc(P1, P2), 0)
                    Dim Pn11 As IPosition71 = Pn1.Move(Dorongduong * 30, 45 + FGoc(P1, P2), 0)
                    Dim Pn111 As IPosition71 = Pn11.Move(Dorongduong * 2, 180 + FGoc(P1, P2), 0)
                    Dim Pn12 As IPosition71 = CenterPoint(Pn1, Pn11)
                    Dim Pn121 As IPosition71 = Pn12.Move(Dorongduong * 2, 180 + FGoc(P1, P2), 0)
                    Dim Pn2 As IPosition71 = Pc.Move(Dorongduong * 7, 180 + FGoc(P1, P2), 0)
                    Dim Pn21 As IPosition71 = Pn2.Move(Dorongduong * 30, 135 + FGoc(P1, P2), 0)
                    Dim Pn211 As IPosition71 = Pn21.Move(Dorongduong * 2, FGoc(P1, P2), 0)
                    Dim Pn22 As IPosition71 = CenterPoint(Pn2, Pn21)
                    Dim Pn221 As IPosition71 = Pn22.Move(Dorongduong * 2, FGoc(P1, P2), 0)
                    Dim LiL As New List(Of IPosition71) From {Pn1, Pn11, Pn111, Pn121, Pn221, Pn211, Pn21, Pn2}
                    FVungList(LiL, 4294967295, 0, mauH2O, 0, mauH2O, 1, "", 0, 0, 0, False, 2, 3)
                Else
                    Dim LN1 As New List(Of IPosition71) From {li1(1), li1(2)}
                    Dim LN2 As New List(Of IPosition71) From {li2(0), li2(3)}
                    FDuongList(LN1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                    FDuongList(LN2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                End If

                If Lenhve = "BenloiXT" Or Lenhve = "BenvuotBangthuyen" Or Lenhve = "BenvuotsongPha" Or Lenhve = "BenPhatuhanh" Or Lenhve = "BenvuotsongnhieuPT" Then
                    Dim Sogia As Double
                    Dim Pf1 As IPosition71, Pf2 As IPosition71
                    If Lenhve = "BenvuotsongnhieuPT" Then
                        Sogia = 4 * Dorongduong
                        Pf1 = P1.Move(200 * Tyle, 270 - Goc1, 0)
                        Pf2 = P2.Move(200 * Tyle, 90 - Goc1, 0)
                    Else
                        Sogia = 2 * Dorongduong
                        Pf1 = P1.Move(100 * Tyle, 270 - Goc1, 0)
                        Pf2 = P2.Move(100 * Tyle, 90 - Goc1, 0)
                    End If
                    Dim Ps1 As IPosition71 = Pf1.Move(CRong - Sogia, 0 - Goc1, 0)
                    Dim Ps2 As IPosition71 = Pf1.Move(CRong - Sogia, 180 - Goc1, 0)
                    Dim Ph1 As IPosition71 = Pf2.Move(CRong - Sogia, 0 - Goc1, 0)
                    Dim Ph2 As IPosition71 = Pf2.Move(CRong - Sogia, 180 - Goc1, 0)

                    Dim C1 As New List(Of IPosition71) From {Pk1, Ps1, Ps2, Pk2}
                    Dim C2 As New List(Of IPosition71) From {Pk3, Ph1, Ph2, Pk4}
                    Dim C11 As List(Of IPosition71) = Curveline(C1, 6)
                    Dim C21 As List(Of IPosition71) = Curveline(C2, 6)
                    FDuongList(C11, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    FDuongList(C21, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                    '//////////////////////////////////
                    If Lenhve = "BenvuotBangthuyen" Or Lenhve = "BenvuotsongPha" Then
                        Dim Pm1 As IPosition71 = CenterPoint(li1(1), Pk2)
                        Dim Pm2 As IPosition71 = CenterPoint(li2(0), Pk4)
                        Dim Pm3 As IPosition71 = CenterPoint(Pm1, Pm2)
                        If Lenhve = "BenvuotBangthuyen" Then
                            Dim Pm4 As IPosition71 = Pm3.Move(Dorongduong * 2, 90 - Goc1, 0)
                            Dim Pm5 As IPosition71 = Pm3.Move(Dorongduong * 2, 270 - Goc1, 0)
                            Dim Pm6 As IPosition71 = Pm3.Move(Dorongduong * 3, 180 - Goc1, 0)
                            Dim M1 As New List(Of IPosition71) From {Pm1, Pm4, Pm6, Pm5, Pm4, Pm2}
                            FDuongList(M1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        Else
                            Dim Pd1 As IPosition71 = Pm3.Move(Dorongduong * 8, 90 - Goc1, 0)
                            Dim Pd2 As IPosition71 = Pm3.Move(Dorongduong * 8, 270 - Goc1, 0)
                            Dim Pd3 As IPosition71 = Pm3.Move(Dorongduong * 5, 90 - Goc1, 0)
                            Dim Pd4 As IPosition71 = Pm3.Move(Dorongduong * 5, 270 - Goc1, 0)
                            Dim Pd5 As IPosition71 = Pm3.Move(Dorongduong * 4, 90 - Goc1, 0)
                            Dim Pd6 As IPosition71 = Pm3.Move(Dorongduong * 4, 270 - Goc1, 0)
                            '////////////
                            Dim Pn1 As IPosition71 = Pd5.Move(Dorongduong * 3, 180 - Goc1, 0)
                            Dim Pn2 As IPosition71 = Pd6.Move(Dorongduong * 3, 180 - Goc1, 0)
                            Dim M1 As New List(Of IPosition71) From {Pd2, Pd4, Pn2, Pn1, Pd3, Pd4, Pd1}
                            FDuongList(M1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                        End If
                    ElseIf Lenhve = "BenloiXT" Then
                        FVungList(LiPXTdoc(Pc, 1.2, Goc1), 4294967295, 0.0, mauRedBlue, 0, mauRedBlue, 1, "", 0, 0, 0, False, 2, 3)
                    ElseIf Lenhve = "BenPhatuhanh" Then
                        Dim TQ As New List(Of Double)({318.0, 73.56, 371.08, 75.96, 371.08, 104.04, 108.17, 146.31, 61.85, 104.04, 33.54, 116.57, 54.08, 146.31, 45.0, 180.0, 45.0, 0.0, 54.08, 33.69, 33.54, 63.43, 61.85, 75.96, 108.17, 33.69, 317.94, 73.56, 310.81, 78.87, 108.17, 56.31, 108.17, 123.69, 335.41, 100.3, 329.88, 92.61, 91.34, 99.45, 91.34, 80.55, 329.88, 87.39, 335.41, 79.7, 310.85, 78.87})
                        Dim Pd1 As IPosition71 = Pc.Move(Dorongduong * 6, 270 - Goc1, 0)
                        FVungPoint(ArrayPoint(TQ, Pd1, 2.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 4)
                    ElseIf Lenhve = "BenvuotsongnhieuPT" Then
                        Dim Pd1 As IPosition71 = Pc.Move(Dorongduong * 4, 270 - Goc1, 0)
                        Dim Pq1 As IPosition71 = Pd1.Move(Dorongduong * 3.0, 0 - Goc1, 0)
                        Dim Pq2 As IPosition71 = Pd1.Move(Dorongduong * 4, 180 - Goc1, 0)
                        Dim TQ1 As New List(Of Double)({318.0, 73.56, 371.08, 75.96, 371.08, 104.04, 108.17, 146.31, 61.85, 104.04, 33.54, 116.57, 54.08, 146.31, 45.0, 180.0, 45.0, 0.0, 54.08, 33.69, 33.54, 63.43, 61.85, 75.96, 108.17, 33.69, 317.94, 73.56, 310.81, 78.87, 108.17, 56.31, 108.17, 123.69, 335.41, 100.3, 329.88, 92.61, 91.34, 99.45, 91.34, 80.55, 329.88, 87.39, 335.41, 79.7, 310.85, 78.87})
                        FVungPoint(ArrayPoint(TQ1, Pq2, 2.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 4)
                        Dim TQ As New List(Of Double)({0.01, 0.0, 100.0, 0.0, 228.43, 64.0, 249.2, 67.5, 266.92, 71.5, 281.15, 75.8, 291.55, 80.4, 297.88, 85.2, 300.0, 90.0, 297.88, 94.8, 291.55, 99.6, 281.15, 104.2, 266.92, 108.5, 249.2, 112.5, 228.43, 116.0, 100.0, 180.0, 0.0, 180.0, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 76.16, 23.2, 30.0, 89.99})
                        FVungPoint(ArrayPoint(TQ, Pq1, 2.0, Goc1), 0, 33, 4294967295, 0, mauRedBlue, 0, mauRedBlue, 1, "", 1, 1, 0, False, 2, 3)
                    End If
                End If

                If Lenhve = "hambetong" Then
                    DemCau(Pk4, Pk2)
                    DemCau(Pk1, Pk3)
                Else
                    DemCau(Pk2, Pk4)
                    DemCau(Pk3, Pk1)
                End If

            End If
        ElseIf Lenhve = "CauPMP" Then
            CauPMP(P11, P21, 270)
            CauPMP(P12, P22, 90)
            '  ElseIf Lenhve = "Caubidanhpha" Then
        End If

        SLenhve3DMs()
    End Sub

    Private Sub Hvuong(P As IPosition71, Heso As Double, Goc As Double)
        Dim TQ As New List(Of Double)({15.0, 270.0, 29.99, 329.99, 29.99, 30.01, 15.0, 90.0})
        FVungList(ArDisAgreetoLiPoint(TQ, P, Heso, Goc), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
    End Sub

    Private Sub Tamgiac(P As IPosition71, Heso As Double, Goc As Double)
        Dim TQ As New List(Of Double)({15.0, 270.0, 26.0, 0.00, 15.0, 90.0})
        FVungList(ArDisAgreetoLiPoint(TQ, P, Heso, Goc), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
    End Sub

    Private Sub CNhat(P As IPosition71, Heso As Double, Goc As Double, KMau As IColor71)
        Dim TQ As New List(Of Double)({7.5, 270.0, 45.56, 350.3, 45.56, 9.47, 7.5, 90.0})
        FVungList(ArDisAgreetoLiPoint(TQ, P, Heso, Goc), 4294967295, 0, KMau, 0, KMau, 1, "", 0, 0, 0, False, 2, 3)
    End Sub

    Public Sub DemCau(p1 As IPosition71, p2 As IPosition71)
        FrmMain.Instance.cbKieuduong.SelectedIndex = 0
        Dim Pd2 As IPosition71 = p1.Move(Dorongduong * 1.5, 90 + FGoc(p1, p2), 0)
        Dim Pd3 As IPosition71 = p2.Move(Dorongduong * 1.5, 90 + FGoc(p1, p2), 0)
        Dim K1 As New List(Of IPosition71) From {Pd2, Pd3}
        FDuongList(K1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
    End Sub

    Function PointDaihiepdong(p As IPosition71, Sogiaogoc1 As Double, Sogiaogoc2 As Double, Sogiaogoc3 As Double, Goc1 As Double) As List(Of IPosition71)
        Dim P1 As IPosition71 = p.Move(Dorongduong * 9, Sogiaogoc1 - Goc1, 0)
        Dim P2 As IPosition71 = p.Move(Dorongduong * 6, FGoc(p, P1) + Sogiaogoc2, 0)
        Dim P21 As IPosition71 = P2.Move(Dorongduong * 2.5, FGoc(p, P1), 0)
        Dim P22 As IPosition71 = P2.Move(Dorongduong * 2.5, FGoc(p, P1) + 180, 0)
        Dim P3 As IPosition71 = p.Move(Dorongduong * 8, FGoc(p, P1) + Sogiaogoc3, 0)
        Dim LiP As New List(Of IPosition71) From {P1, P22, P21, p, P3}
        PointDaihiepdong = LiP
    End Function

    Function CauPMP(p1 As IPosition71, p2 As IPosition71, Sgoc As Double) As List(Of IPosition71)
        Dim LiC As New List(Of IPosition71), Li23 As New List(Of IPosition71), LiK As New List(Of IPosition71)
        For i As Integer = 1 To 6
            Dim Pk1 As IPosition71 = p1.Move(i * FKc(p1, p2) / 6, FGoc(p1, p2) + 180, 0)
            LiC.Add(Pk1)
        Next
        For i As Integer = 0 To LiC.Count - 1
            Dim Pk1 As IPosition71 = LiC(i).Move(300 * Tyle, FGoc(p1, p2) + Sgoc, 0)
            LiK.Add(Pk1)
            Dim Pk3 As IPosition71 = LiC(i).Move(Dorongduong * 2, FGoc(p1, p2), 0)
            Li23.Add(Pk3)
            Dim Pk2 As IPosition71 = LiC(i).Move(Dorongduong * 2, FGoc(p1, p2) + 180, 0)
            Li23.Add(Pk2)
        Next
        Dim liP As New List(Of IPosition71) From {Li23(0), LiK(0), LiK(1), Li23(3), Li23(6), LiK(3), LiK(4), Li23(9)}
        FDuongList(liP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
    End Function

    Function Mocau(p As IPosition71, Heso As Double, goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({78.03, 213.69, 65.32, 186.38, 55.0, 180.67, 34.03, 152.01, 36.06, 90.0})
        Dim Lp As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, p, Heso, goc)
        Mocau = Lp
    End Function

    Function Mocau1(p As IPosition71, Heso As Double, goc As Double) As List(Of IPosition71)
        Dim TQ As New List(Of Double)({78.03, 146.31, 65.32, 173.62, 55.0, 179.33, 34.03, 207.99, 36.06, 270.0})
        Dim Lp As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, p, Heso, goc)
        Mocau1 = Lp
    End Function

    Function Causat(p1 As IPosition71, p2 As IPosition71) As List(Of IPosition71)
        Dim Pk1 As IPosition71 = p1.Move(FKc(p1, p2) / 4, FGoc(p1, p2) + 180, 0)
        Dim Pk2 As IPosition71 = p1.Move(FKc(p1, p2) / 2, FGoc(p1, p2) + 180, 0)
        Dim Pk3 As IPosition71 = p1.Move(3 / 4 * FKc(p1, p2), FGoc(p1, p2) + 180, 0)
        Dim LiCs As New List(Of IPosition71) From {p1, Pk1, Pk2, Pk3, p2}
        Causat = LiCs
    End Function

    Function CauTreo(P As IPosition71, Goc As Double, RongCau As Double) As List(Of IPosition71)
        Dim Heso As Double
        If Lenhve = "Cautre" Then
            Heso = 1.0
        ElseIf Lenhve = "BenloiOto" Or Lenhve = "BenloiXT" Or Lenhve = "BenloiBB" Then
            Heso = 2.0
        Else
            Heso = 1.5
        End If
        Dim Pk1 As IPosition71 = P.Move(RongCau, 90 - Goc, 0)
        Dim Pk2 As IPosition71 = P.Move(RongCau, 270 - Goc, 0)
        Dim Pk11 As IPosition71 = Pk1.Move(RongCau * Heso, 0 - Goc, 0)
        Dim Pk12 As IPosition71 = Pk1.Move(RongCau * Heso, 180 - Goc, 0)
        Dim Pk21 As IPosition71 = Pk2.Move(RongCau * Heso, 0 - Goc, 0)
        Dim Pk22 As IPosition71 = Pk2.Move(RongCau * Heso, 180 - Goc, 0)
        Dim LP As New List(Of IPosition71) From {Pk11, Pk21, Pk22, Pk12}
        CauTreo = LP
    End Function

#End Region

#Region "    Khu vuc Tau HQ"
    Private Sub TCDoihinh(P1 As IPosition71, P2 As IPosition71, P3 As IPosition71, P4 As IPosition71, Goc1 As Double)
        Dim K1 As IPosition71 = P1.Move(500 * Tyle, 270 - Goc1, 0)
        Dim K2 As IPosition71 = P1.Move(500 * Tyle, 0 - Goc1, 0)
        Dim Li1 As New List(Of IPosition71) From {K1, P1, K2}
        FVungList(Li1, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, True, 2, 4)
        Dim K3 As IPosition71 = P2.Move(500 * Tyle, 90 - Goc1, 0)
        Dim K4 As IPosition71 = P2.Move(500 * Tyle, 0 - Goc1, 0)
        Dim Li2 As New List(Of IPosition71) From {K3, P2, K4}
        FVungList(Li2, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, True, 2, 4)
        Dim K5 As IPosition71 = P3.Move(500 * Tyle, 270 - Goc1, 0)
        Dim K6 As IPosition71 = P3.Move(500 * Tyle, 180 - Goc1, 0)
        Dim Li3 As New List(Of IPosition71) From {K5, P3, K6}
        FVungList(Li3, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, True, 2, 4)
        Dim K7 As IPosition71 = P4.Move(500 * Tyle, 90 - Goc1, 0)
        Dim K8 As IPosition71 = P4.Move(500 * Tyle, 180 - Goc1, 0)
        Dim Li4 As New List(Of IPosition71) From {K7, P4, K8}
        FVungList(Li4, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, True, 2, 4)
    End Sub

    Private Sub Tamdung(P1 As IPosition71, P2 As IPosition71, P3 As IPosition71, P4 As IPosition71, Goc1 As Double)
        Dim Kf As Double = 550 * Tyle
        Dim Lip1, Lip2, Lip3, Lip4 As New List(Of IPosition71)
        For i As Integer = 1 To 7
            Dim K1 As IPosition71 = P1.Move(Kf, (255 + (i * 15)) - Goc1, 0)
            Lip1.Add(K1)
        Next
        FDuongList(Lip1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
        For i As Integer = 8 To 14
            Dim K1 As IPosition71 = P2.Move(Kf, (210 - (i * 15)) - Goc1, 0)
            Lip2.Add(K1)
        Next
        FDuongList(Lip2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
        For i As Integer = 15 To 21
            Dim K1 As IPosition71 = P3.Move(Kf, (135 - (i * 15)) - Goc1, 0)
            Lip3.Add(K1)
        Next
        FDuongList(Lip3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
        For i As Integer = 22 To 28
            Dim K1 As IPosition71 = P4.Move(Kf, (120 + (i * 15)) - Goc1, 0)
            Lip4.Add(K1)
        Next
        FDuongList(Lip4, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2)
    End Sub

    Private Sub Doitau(P1 As IPosition71, P2 As IPosition71, P3 As IPosition71, P4 As IPosition71, Goc1 As Double)
        Dim k12 As IPosition71 = CenterPoint(P1, P2)
        Dim k13 As IPosition71 = CenterPoint(P1, P3)
        Dim k24 As IPosition71 = CenterPoint(P2, P4)
        Dim k34 As IPosition71 = CenterPoint(P3, P4)
        Dim k121 As IPosition71 = k12.Move(400 * Tyle, 180.0 - Goc1, 0)
        Dim k131 As IPosition71 = k13.Move(400 * Tyle, 90.0 - Goc1, 0)
        Dim k241 As IPosition71 = k24.Move(400 * Tyle, 270.0 - Goc1, 0)
        Dim k341 As IPosition71 = k34.Move(400 * Tyle, 0.0 - Goc1, 0)
        Dim lists1 As New List(Of IPosition71) From {k12, k121}
        Dim lists2 As New List(Of IPosition71) From {k13, k131}
        Dim list3 As New List(Of IPosition71) From {k24, k241}
        Dim list4 As New List(Of IPosition71) From {k34, k341}
        FDuongList(lists1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(lists2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(list3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(list4, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
    End Sub

    Private Sub Cdong(P1 As IPosition71, P2 As IPosition71, Goc1 As Double)
        Dim K As IPosition71 = CenterPoint(P1, P2)
        Dim k1 As IPosition71 = K.Move(150 * Tyle, 90 - Goc1, 0)
        Dim k2 As IPosition71 = K.Move(150 * Tyle, 270 - Goc1, 0)

        Dim M1 As IPosition71 = k1.Move(250 * Tyle, 0 - Goc1, 0)
        Dim M2 As IPosition71 = k1.Move(250 * Tyle, 180 - Goc1, 0)
        Dim M3 As IPosition71 = k2.Move(250 * Tyle, 0 - Goc1, 0)
        Dim M4 As IPosition71 = k2.Move(250 * Tyle, 180 - Goc1, 0)
        Dim lists1 As New List(Of IPosition71) From {M1, M2}
        Dim lists2 As New List(Of IPosition71) From {M3, M4}
        FDuongList(lists1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(lists2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
    End Sub

#End Region

    Public Sub HCN()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Khoangcach2 As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(PllVts(3), PllVts(4), PllVts(6), PllVts(7))
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = P1.Move(Khoangcach2, 0 - Goc1, 0)
        Dim P4 As IPosition71 = P2.Move(Khoangcach2, 0 - Goc1, 0)
        Dim liC As New List(Of IPosition71) From {P1, P2, P4, P3, P1}
        Dim geo1 As IGeometry = ListtoGeo(liC)
        Dim geo2 As IGeometry = geo1.SpatialOperator.buffer(-1 * Dorongduong * 1.2)
        Dim liD As List(Of IPosition71) = GeoToList(geo2)

        If Lenhve = "kvTKHHdukien" Then
            FVungList(liC, 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 4)
            FVungList(liD, 4294967295, Dorongduong * 1.5, mau2, 1, mauHH, 1, "", 0, 0, 0, False, 2, 3)
        ElseIf Not Lenhve = "hinhchunhat" Then
            FVungList(liC, 4294967295, Dorongduong * 1.5, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 4)
            FVungList(liD, 4294967295, Dorongduong * 1.5, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 3)
        End If

        If Lenhve = "hinhchunhat" Then
            If FrmMain.Instance.ChebTheoGD.Checked = True Then
                FVungList(liC, 4294967295, Dorongduong * 1.5, mau, 1, mau2, 1, "", 0, 0, 0, True, 2, 3)
            Else
                If FrmMain.Instance.txtChieucaochu.Text <> "" Then
                    FVungList(liC, 4294967295, Val(FrmMain.Instance.txtChieucaochu.Text), FrmMain.Instance.sgworldMain.Creator.CreateColor(FrmMain.Instance.ColorDialog1.Color.R, FrmMain.Instance.ColorDialog1.Color.G, FrmMain.Instance.ColorDialog1.Color.B, 255), 1, FrmMain.Instance.sgworldMain.Creator.CreateColor(FrmMain.Instance.ColorDialog1.Color.R, FrmMain.Instance.ColorDialog1.Color.G, FrmMain.Instance.ColorDialog1.Color.B, 255), 1, "", 0, 0, 0, False, 2, 4)
                Else
                    MsgBox("Hãy chọn lực nét")
                    Exit Sub
                End If
            End If
        ElseIf Lenhve = "MBchupanhTS" Then
            Dim P5 As IPosition71 = CenterPoint(P1, P4) 'FrmMain.Instance.sgworldMain.Creator.CreatePosition((P1.X + P2.X) * 0.5, (P1.Y + P2.Y) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
            Dim P51 As IPosition71 = P5.Move(Khoangcach2 / 2 + (Dorongduong * 10), FGoc(P1, P2) + 90, 0)
            Dim P52 As IPosition71 = P5.Move(Khoangcach2 / 2 + (Dorongduong * 10), FGoc(P1, P2) + 270, 0)
            Dim liDiemgiua As New List(Of IPosition71) From {P51, P52}
            FDuongList(liDiemgiua, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4)
            MB(P5, (MkGoc(P51, P52) * 180.0 / Math.PI) - 180, 3.5)
        ElseIf Lenhve = "kvkhoinguytrang" Then
            Dim kc As Double = FKc(liC(0), liC(3))
            Dim Goc As Double = FGoc(liC(0), liC(3))
            Dim Pc1 As IPosition71 = CenterPoint(liC(0), liC(3))
            Dim Pc2 As IPosition71 = CenterPoint(liC(1), liC(2))
            Dim Ps11 As IPosition71 = Pc1.Move(kc / 8, Goc, 0)
            Dim Ps12 As IPosition71 = Pc1.Move(kc / 8, 180 + Goc, 0)
            Dim Ps21 As IPosition71 = Pc2.Move(kc / 8, Goc, 0)
            Dim Ps22 As IPosition71 = Pc2.Move(kc / 8, 180 + Goc, 0)
            RauHinhV(Ps11, MkGoc(liC(0), liC(3)) * 180 / Math.PI, 2, 1)
            RauHinhV(Ps12, MkGoc(liC(0), liC(3)) * 180 / Math.PI, 2, 1)
            RauHinhV(Ps21, 180 + MkGoc(liC(0), liC(3)) * 180 / Math.PI, 2, 1)
            RauHinhV(Ps22, 180 + MkGoc(liC(0), liC(3)) * 180 / Math.PI, 2, 1)
        ElseIf Lenhve = "kvTochucDoihinh" Then
            TCDoihinh(P1, P2, P3, P4, Goc1)
        ElseIf Lenhve = "KvTamdung" Then
            Tamdung(P1, P2, P3, P4, Goc1)
        ElseIf Lenhve = "KvDoiTu" Then
            Doitau(P1, P2, P3, P4, Goc1)
        ElseIf Lenhve = "KvCodong" Then
            Cdong(P1, P2, Goc1 + 180)
            Cdong(P1, P3, Goc1 + 90)
            Cdong(P4, P2, Goc1 + 90)
            Cdong(P4, P3, Goc1)
        End If

        If Lenhve = "kvTochucDoihinh" Or Lenhve = "KvTamdung" Or Lenhve = "KvDoiTu" Or Lenhve = "KvCodong" Or Lenhve = "KvTapket" Then
            Dim geTi As IGeometry = ListtoGeo(liC).SpatialOperator.buffer(-1 * Dorongduong * 25)
            Dim liT As List(Of IPosition71) = GeoToList(geTi)
            Dim LiTau As String = Trim(FrmMain.Instance.TxtGhichuKH.Text)
            For i As Integer = 0 To LiTau.Split(",").Count - 1
                If LiTau.Split(",")(i) <> "0" Then
                    PointHQ = liT(i).Move(Dorongduong * 12, 270 + FGoc(liC(3), liC(2)), 0)
                    GocHQ = (MkGoc(liC(2), liC(3)) * 180 / Math.PI)
                    FrmMain.Instance.cbTauHQ.SelectedIndex = System.Convert.ToInt32(LiTau.Split(",")(i))
                    TauHaiquan()
                End If
            Next
            'For i As Integer = 0 To liT.Count - 1
            '    FrmMain.Instance.sgworldMain.Creator.CreateLabel(liT(i), i.ToString, "", Nothing, "", i.ToString)
            'Next
        End If

        SLenhve3DMs()
    End Sub

    Public Sub DTRectangle()
        Dim Goc1 As Double '= 270 + (Phuongvi * 180 / Math.PI)
        If Lenhve = "baiminchongtau" Or Lenhve = "tramxulyTNn" Then
            Goc1 = 180 + (Phuongvi * 180 / Math.PI)
        Else
            Goc1 = 270 + (Phuongvi * 180 / Math.PI)
        End If
        Dim hesoTyle As Double = 5.0 * Tyle
        Dim Crong, Sdai As Double
        If Lenhve = "tramxulyTNn" Then
            Crong = 140.0
            Sdai = 240.0 ' 280.0
        Else
            Crong = 70.0
            Sdai = 144.45
        End If
        Dim p1 As IPosition71 = FrmMain.Instance.mPointClick.Move(Crong * hesoTyle, 90.0 - Goc1, 0)
        Dim p2 As IPosition71 = FrmMain.Instance.mPointClick.Move(Crong * hesoTyle, 270.0 - Goc1, 0)
        Dim p3 As IPosition71 = CenterPoint(p1, p2)
        Dim k1 As IPosition71 = FrmMain.Instance.mPointClick.Move(Sdai * hesoTyle, 64.61 - Goc1, 0)
        Dim k2 As IPosition71 = FrmMain.Instance.mPointClick.Move(Sdai * hesoTyle, 115.39 - Goc1, 0)
        Dim k3 As IPosition71 = FrmMain.Instance.mPointClick.Move(Sdai * hesoTyle, 244.61 - Goc1, 0)
        Dim k4 As IPosition71 = FrmMain.Instance.mPointClick.Move(Sdai * hesoTyle, 295.39 - Goc1, 0)

        Dim LiChinh As New List(Of IPosition71) From {k1, k2, k3, k4}
        Dim k6 As IPosition71 = k1.Move(Dorongduong * 1.5, 225 - Goc1, 0)
        Dim k7 As IPosition71 = k2.Move(Dorongduong * 1.5, 315 - Goc1, 0)
        Dim k8 As IPosition71 = k3.Move(Dorongduong * 1.5, 45 - Goc1, 0)
        Dim k9 As IPosition71 = k4.Move(Dorongduong * 1.5, 135 - Goc1, 0)

        'Dim Mgeo As IGeometry = ListtoGeo(LiChinh).SpatialOperator.buffer(-Dorongduong * 1.5)
        Dim LiDem As New List(Of IPosition71) From {k6, k7, k8, k9}

        If Lenhve = "MTBLLDDachiem" Or Lenhve = "MuctieuChatno" Or Lenhve = "MTBLLDDukienchiem" Or Lenhve = "MuctieuBLLDCtr" Or Lenhve = "Giamgiucontin" Or Lenhve = "MtieuA2" Then
            FVungList(LiChinh, 4294967295, Dorongduong * 1.2, mau3, 1, mau3, 0, "", 0, 0, 0, False, 2, 4)
        Else
            FVungList(LiChinh, 4294967295, Dorongduong * 1.2, mau, 1, mau, 0, "", 0, 0, 0, False, 2, 4)
        End If


        If Lenhve = "NoilotLL" Or Lenhve = "KvTTrHoalucphandoi" Or Lenhve = "khusotannhandan" Or Lenhve = "KvGiaututhi" Or Lenhve = "khusotanCQXN" Or Lenhve = "KhusotanNDBaoLut" Or Lenhve = "hamchong" Or Lenhve = "baicocchongtang" Or Lenhve = "baiminhoahoc" Or Lenhve = "baiminlua" Or Lenhve = "baiminBB" Or Lenhve = "baiminHonHop" Or Lenhve = "baiminchongtangHTD" Or Lenhve = "baiminchongtangVTD" Or Lenhve = "CongNongLamtruongCD" Then
            FVungList(LiDem, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 3)
        ElseIf Lenhve = "MTBLLDDachiem" Or Lenhve = "MuctieuChatno" Or Lenhve = "NoilotLL" Or Lenhve = "MTBLLDDukienchiem" Or Lenhve = "MuctieuBLLDCtr" Or Lenhve = "Giamgiucontin" Or Lenhve = "MtieuA2" Then
            FVungList(LiDem, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 0, 0, 0, False, 2, 3)
        ElseIf Lenhve = "MuctieuHH" Or Lenhve = "baiminhoahocNo" Then
            FVungList(LiDem, 4294967295, Dorongduong, mau2, 1, mauHH, 1, "", 0, 0, 0, False, 2, 3)
        ElseIf Lenhve = "luoinguytrang" Or Lenhve = "tamnguytrang" Or Lenhve = "baiminchongtau" Or Lenhve = "tramxulyTNn" Then
            FVungList(LiDem, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 0, 0, 0, False, 2, 3)
        End If


        If Lenhve = "baiminhoahoc" Or Lenhve = "baiminlua" Or Lenhve = "baiminhoahocNo" Then
            MinHH(p1, Goc1 + 270, mau)
            MinHH(p2, Goc1 + 270, mau)
            If Lenhve = "baiminlua" Then
                MCircleTQ(p1, 120, 4294967295, 0, Nothing, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(195, 0, 0, 255), 1, "", 0, 0, 0, False, 2, 3)
                MCircleTQ(p2, 120, 4294967295, 0, Nothing, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(195, 0, 0, 255), 1, "", 0, 0, 0, False, 2, 3)
            Else
                MCircleTQ(p1, 120, 4294967295, 0, Nothing, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 0, 0, 0, False, 2, 3)
                MCircleTQ(p2, 120, 4294967295, 0, Nothing, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 0, 0, 0, False, 2, 3)
            End If
            MCircleTQ(p1, 60, 4294967295, 0, Nothing, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
            MCircleTQ(p2, 60, 4294967295, 0, Nothing, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
        ElseIf Lenhve = "baiminBB" Then
            MCircleTQ(p1, 100, 4294967295, Dorongduong, mau, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(p2, 100, 4294967295, Dorongduong, mau, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(p3, 100, 4294967295, Dorongduong, mau, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "baiminHonHop" Then
            MCircleTQ(p1, 100, 4294967295, Dorongduong, mau, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(p3, 100, 4294967295, Dorongduong, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(p2, 100, 4294967295, Dorongduong, mau, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "baiminchongtau" Then
            SCoi(p1, Goc1 + 20)
            SCoi(p2, Goc1 + 20)
        ElseIf Lenhve = "hamchong" Or Lenhve = "baicocchongtang" Then
            Dim filePastern As String
            If Lenhve = "hamchong" Then
                filePastern = "Chong"
            Else
                filePastern = "Coc"
            End If
            MakeText(p1, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", filePastern, mauChu, 1, 0, 0, 2)
            MakeText(p2, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", filePastern, mauChu, 1, 0, 0, 2)
            MakeText(p3, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "", filePastern, mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "baiminchongtangHTD" Or Lenhve = "baiminchongtangVTD" Then
            MCircleTQ(p1, 100, 4294967295, Dorongduong, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(p2, 100, 4294967295, Dorongduong, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(p3, 100, 4294967295, Dorongduong, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "CongNongLamtruongCD" Then
            Dim S1 As IPosition71 = k1.Move(Dorongduong * 2.0, 45 - Goc1, 0)
            Dim S2 As IPosition71 = k2.Move(Dorongduong * 2.0, 135 - Goc1, 0)
            Dim S3 As IPosition71 = k3.Move(Dorongduong * 2.0, 225 - Goc1, 0)
            Dim S4 As IPosition71 = k4.Move(Dorongduong * 2.0, 315 - Goc1, 0)
            CongsuTQ(MkGoc(S1, k1) * 180 / Math.PI, S1)
            CongsuTQ(MkGoc(S2, k2) * 180 / Math.PI, S2)
            CongsuTQ(MkGoc(S3, k3) * 180 / Math.PI, S3)
            CongsuTQ(MkGoc(S4, k4) * 180 / Math.PI, S4)
        ElseIf Lenhve = "KhusotanNDBaoLut" Or Lenhve = "khusotannhandan" Or Lenhve = "khusotanCQXN" Or Lenhve = "KvGiaututhi" Then
            Dim M1 As IPosition71 = k6.Move(FKc(k6, k9) / 2, FGoc(k9, k6), 0)
            Dim M2 As IPosition71 = k7.Move(FKc(k6, k9) / 2, FGoc(k9, k6), 0)
            If Lenhve = "KhusotanNDBaoLut" Or Lenhve = "khusotannhandan" Or Lenhve = "KvGiaututhi" Then
                Dim LiS As New List(Of IPosition71) From {k9, M1, k7, M2, k9}
                Dim LiM1 As List(Of IPosition71) = AddPointKhusotan(M1, k7)
                Dim LiM2 As List(Of IPosition71) = AddPointKhusotan(k9, M2)
                Dim LiSL As New List(Of IPosition71) From {LiM1(2), LiM2(2), LiM2(0), LiM1(0), LiM1(1), LiM2(1)}

                If Lenhve = "KhusotanNDBaoLut" Then
                    FDuongList(LiS, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2)
                    FDuongList(LiSL, 4294967295, "", 0, 0, mau4, Dorongduong, False, 2, 0, 1)
                ElseIf Lenhve = "KvGiaututhi" Then
                    FDuongList(LiS, 4294967295, "", 0, 0, mauXanh, Dorongduong, False, 2, 0, 2)
                    FDuongList(LiSL, 4294967295, "", 0, 0, mauXanh, Dorongduong, False, 2, 0, 1)
                Else
                    FDuongList(LiS, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2)
                    FDuongList(LiSL, 4294967295, "", 0, 0, mauXanh, Dorongduong, False, 2, 0, 1)
                End If
            Else
                Dim LiS1 As New List(Of IPosition71) From {k9, M2, k8}
                Dim LiS2 As New List(Of IPosition71) From {k7, M1, k6}
                FDuongList(LiS1, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2)
                FDuongList(LiS2, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2)

                Dim LiM1 As List(Of IPosition71) = AddPointKhusotan(M1, k7)
                Dim LiM2 As List(Of IPosition71) = AddPointKhusotan(k6, k7)
                Dim LiSL1 As New List(Of IPosition71) From {LiM1(2), LiM2(2), LiM2(0), LiM1(0), LiM1(1), LiM2(1)}
                FDuongList(LiSL1, 4294967295, "", 0, 0, mauXanh, Dorongduong, False, 2, 0, 1)

                Dim LiM3 As List(Of IPosition71) = AddPointKhusotan(k9, M2)
                Dim LiM4 As List(Of IPosition71) = AddPointKhusotan(k9, k8)
                Dim LiSL2 As New List(Of IPosition71) From {LiM3(2), LiM4(2), LiM4(0), LiM3(0), LiM3(1), LiM4(1)}
                FDuongList(LiSL2, 4294967295, "", 0, 0, mauXanh, Dorongduong, False, 2, 0, 1)
            End If

        ElseIf Lenhve = "MuctieuChatno" Or Lenhve = "Giamgiucontin" Or Lenhve = "MtieuA2" Then
            Dim Pcc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (k6.X + k8.X), 0.5 * (k6.Y + k8.Y), 0, 2, 0, 0, 0, 0)
            If Lenhve = "MuctieuChatno" Or Lenhve = "Giamgiucontin" Then
                MCircleTQ(Pcc, 50, 4294967295, Dorongduong, mau3, 1, mau, 0, "", 0, 0, 0, False, 2, 2)
            Else
                MakeText(Pcc, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(k6, k7), "A2", loaiKH, mau3, 0, 0, 0, 2)
            End If
        ElseIf Lenhve = "MuctieuHH" Or Lenhve = "MTBLLDDachiem" Or Lenhve = "MuctieuChatno" Or Lenhve = "MTBLLDDukienchiem" Or Lenhve = "MuctieuBLLDCtr" Or Lenhve = "Giamgiucontin" Then
            If Not Lenhve = "MuctieuHH" Then
                Dim LiM1 As List(Of IPosition71) = AddPoinMuctieuBLLD(k9, k6)
                Dim LiM2 As List(Of IPosition71) = AddPoinMuctieuBLLD(k7, k8)
                Dim LiSL1 As New List(Of IPosition71) From {LiM1(0), LiM1(2), LiM1(3), LiM2(6), LiM2(5), LiM1(4), LiM1(5), LiM2(4), LiM2(3), LiM1(6), LiM2(3), LiM2(2), LiM2(0)}
                FDuongList(LiSL1, 4294967295, "", 0, 0, mau3, Dorongduong * 1.2, False, 2, 0, 0)
            End If
            Dim k61 As IPosition71 = k1.Move(Dorongduong * 4, 225 - Goc1, 0)
            Dim k71 As IPosition71 = k2.Move(Dorongduong * 4, 315 - Goc1, 0)
            Dim k81 As IPosition71 = k3.Move(Dorongduong * 4, 45 - Goc1, 0)
            Dim k91 As IPosition71 = k4.Move(Dorongduong * 4, 135 - Goc1, 0)
            Dim LiMT As New List(Of IPosition71) From {k61, k71, k81, k91, k61}
            If Lenhve = "MuctieuHH" Then
                FDuongList(LiMT, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 4)
            ElseIf Lenhve = "MuctieuBLLDCtr" Or Lenhve = "Giamgiucontin" Then
                FVungList(LiMT, 4294967295, Dorongduong * 1.2, mau3, 1, mauTrang, 1, "", 0, 0, 0, False, 2, 3)
            Else
                FDuongList(LiMT, 4294967295, "", 0, 0, mau3, Dorongduong * 1.2, False, 2, 0, 4)
            End If
        ElseIf Lenhve = "NoilotLL" Then
            Dim M1 As IPosition71 = k6.Move(1 / 4 * FKc(k6, k7) + Dorongduong, FGoc(k7, k6), 0)
            Dim M2 As IPosition71 = k7.Move(1 / 4 * FKc(k6, k7) + Dorongduong, FGoc(k6, k7), 0)
            Dim M3 As IPosition71 = k9.Move(1 / 4 * FKc(k6, k7) + Dorongduong, FGoc(k7, k6), 0)
            Dim M4 As IPosition71 = k8.Move(1 / 4 * FKc(k6, k7) + Dorongduong, FGoc(k6, k7), 0)
            Dim LiM1 As List(Of IPosition71) = AddPoinMuctieuBLLD(M3, M1)
            Dim LiM2 As List(Of IPosition71) = AddPoinMuctieuBLLD(M4, M2)
            Dim LiMT As New List(Of IPosition71) From {M3, M1, LiM1(1), LiM2(1), LiM2(2), LiM1(2), LiM1(3), LiM2(3), LiM2(4), LiM1(4), LiM1(5), LiM2(5), M2, M1, M2, M4}
            FDuongList(LiMT, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 4)
        ElseIf Lenhve = "tamnguytrang" Or Lenhve = "luoinguytrang" Then
            Dim LiM1 As List(Of IPosition71) = AddPoinMuctieuBLLD(k9, k6)
            Dim LiM2 As List(Of IPosition71) = AddPoinMuctieuBLLD(k7, k8)
            Dim LiSL1 As New List(Of IPosition71) From {LiM1(0), LiM2(3), LiM2(2), LiM1(1), LiM1(2), LiM2(1), LiM1(2), LiM1(3), LiM2(0), k7, LiM2(4), LiM1(5), LiM1(4), LiM2(5)}
            If Lenhve = "luoinguytrang" Then
                FDuongList(LiSL1, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 4)
            Else
                FDuongList(LiSL1, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.2, False, 2, 0, 3)
            End If
        ElseIf Lenhve = "tramxulyTNn" Then
            Dim Pday As IPosition71 = CenterPoint(LiChinh(0), LiChinh(1))
            Dim PTren As IPosition71 = CenterPoint(LiChinh(2), LiChinh(3))
            PointHQ = Pday.Move(Dorongduong * 7, FGoc(PTren, Pday), 0)
            GocHQ = 270 + (MkGoc(PTren, Pday) * 180 / Math.PI)
            TauHaiquan()
        End If

        If Lenhve = "baiminchongtangHTD" Then
            Dim p4 As IPosition71 = FrmMain.Instance.mPoint.Move(250.0 * hesoTyle, 180 - Goc1, 0)
            Dim liD As New List(Of IPosition71) From {p1, p4, p2}
            FDuongList(liD, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 4)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub DT_Circle()
        Dim LiP, LiP2 As List(Of IPosition71)
        Dim Bankinh, Goc As Double
        Dim P1 As IPosition71 = Nothing, P2 As IPosition71 = Nothing
        FrmMain.Instance.fLabelStyleMain.Scale = SLabelStyleTQ(FrmMain.Instance.sgworldMain).Scale

        If Lenhve = "ovatcan" Or Lenhve = "TrandiaBtcdt" Or Lenhve = "TrandiaCtcdt" Then
            MCircleTQ(FrmMain.Instance.mPointClick, 380, 4294967295, Dorongduong * 0.9, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(FrmMain.Instance.mPointClick, 380 - Dorongduong / Tyle, 4294967295, Dorongduong * 0.9, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, -1)
            If Lenhve = "TrandiaBtcdt" Or Lenhve = "TrandiaCtcdt" Then
                If Lenhve = "TrandiaBtcdt" Then
                    loaiKH = "P280114"
                Else
                    loaiKH = "P280115"
                End If
                MakeText(FrmMain.Instance.mPointClick, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 0, "", loaiKH, mau, 1, 0, 0, 2)
                GoTo Het
            End If
        ElseIf Lenhve = "choneotau" Then
            MCircleTQ(FrmMain.Instance.mPointClick, Dorongduong * 12.0, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(FrmMain.Instance.mPointClick, Dorongduong * 10.0, 4294967295, Dorongduong, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, -1)
            GoTo Het
        ElseIf Lenhve = "mucbucxa" Then
            Dim liV As List(Of IPosition71) = LiPCircle(FrmMain.Instance.mPointClick, Dorongduong * 5, 0, 10)
            FVungList(liV, 4294967295, Dorongduong * 1.5, mau4, 1, mau3, 1, "", 0, 0, 0, False, 2, 4)
            MakeText(FrmMain.Instance.mPointClick, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mau, 1, 0, 0, 4)
        End If

        If Lenhve = "hamphao" Or Lenhve = "ToSCCodong" Or Lenhve = "SungBBbanMB" Or Lenhve = "tocodongdiettang" Or Lenhve = "dontho" Or Lenhve = "donthuy" Or Lenhve = "coilui" Or Lenhve = "toTSDQTV" Or Lenhve = "toTrSHHCodong" Or Lenhve = "toTrSDieutra" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTrsTrongdich" Or Lenhve = "todaccong" Or Lenhve = "tohoahoc" Or Lenhve = "tocongtacBP" Or Lenhve = "TuyengiaoNvu" Or Lenhve = "hinhtron" Or Lenhve = "tamnhiemxa" Or Lenhve = "kvvkhatnhanno" Or Lenhve = "GioihanvungTrSDientuSN" Or Lenhve = "GioihanvungTrSdienttuSCNVHF" Or Lenhve = "GioihanvungTrSdientuSCNUHF" Or Lenhve = "GioihanvungTrSDTsieucaotan" Or Lenhve = "AntoanHatnhan" Or Lenhve = "GioiHanHatnhan" Or Lenhve = "GihanVungcheap" Or Lenhve = "HiepdongKQPK" Then
            P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
            P2 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
            Goc = FGoc(P2, P1)
        ElseIf Lenhve = "BkinhTu" Or Lenhve = "BkinhMB" Or Lenhve = "hamVK" Then
            P2 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
            P1 = P2.Move(Val(FrmMain.Instance.TxtGhichuKH.Text), 180, 0)
            Goc = 0
        ElseIf Lenhve = "Tuyentucanhgioi" Then
            P1 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
            P2 = P1.Move(Val(FrmMain.Instance.TxtGhichuKH.Text), 0, 0)
            Goc = 0
        End If

        If Lenhve = "TrTTrQuanDB" Or Lenhve = "TrTTrPTKT" Or Lenhve = "TrCMDBtinh" Or Lenhve = "baihacanh" Or Lenhve = "HiepdongKQPK" Then
            Bankinh = Dorongduong * 6.5
        ElseIf Lenhve = "sanbaytrenbien" Or Lenhve = "sanbaygia" Or Lenhve = "sanbaydachien" Or Lenhve = "sanbayvuotcap" Or Lenhve = "sanbaycap1" Or Lenhve = "sanbaycap2" Or Lenhve = "sanbaycap3" Then
            Bankinh = Dorongduong * 8.0
        ElseIf Lenhve = "ToSCCodong" Or Lenhve = "SungBBbanMB" Or Lenhve = "SungBBbanMB" Or Lenhve = "tocodongdiettang" Or Lenhve = "dontho" Or Lenhve = "donthuy" Or Lenhve = "coilui" Or Lenhve = "toTSDQTV" Or Lenhve = "toTrSHHCodong" Or Lenhve = "toTrSDieutra" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTrsTrongdich" Or Lenhve = "todaccong" Or Lenhve = "tohoahoc" Or Lenhve = "DbanMtuy" Or Lenhve = "Diaban" Or Lenhve = "tocongtacBP" Then
            Bankinh = Dorongduong * 5.5
        ElseIf Lenhve = "hamphao" Or Lenhve = "hamVK" Then
            Bankinh = Dorongduong * 14
        Else
            Bankinh = FKc(P1, P2)
        End If

        Dim Smau1, Smau2 As IColor71
        If Lenhve = "tamnhiemxa" Then
            Smau1 = mau3
            Smau2 = mau4
        ElseIf Lenhve = "TuyengiaoNvu" Then
            Smau1 = mauNau
            Smau2 = mau2
        Else
            Smau1 = mau
            Smau2 = mau2
        End If

        If Lenhve = "GioihanvungTrSDientuSN" Or Lenhve = "GioihanvungTrSdienttuSCNVHF" Or Lenhve = "GioihanvungTrSdientuSCNUHF" Or Lenhve = "GioihanvungTrSDTsieucaotan" Or Lenhve = "AntoanHatnhan" Or Lenhve = "GioiHanHatnhan" Or Lenhve = "GihanVungcheap" Then
            LiP = LiPCircle(P1, Bankinh, Goc, 5)
            LiP2 = LiPCircle(P1, Bankinh - Dorongduong * 1.5, Goc, 5)
        ElseIf Lenhve = "hinhtron" Or Lenhve = "tamnhiemxa" Or Lenhve = "kvvkhatnhanno" Or Lenhve = "TuyengiaoNvu" Then
            LiP = LiPCircle(P1, Bankinh, 0, 5)
            LiP2 = LiPCircle(P1, Bankinh - Dorongduong * 1.5, 0, 5)
        ElseIf Lenhve = "BkinhTu" Or Lenhve = "BkinhMB" Then
            LiP = LiPCircle(P1, Bankinh, 0, 10)
            LiP2 = LiPCircle(P1, Bankinh - Dorongduong * 1.5, 0, 10)
        ElseIf Lenhve = "Tuyentucanhgioi" Then
            LiP = LiPCircle(P2, Bankinh, 0, 10)
            LiP2 = LiPCircle(P2, Bankinh - Dorongduong * 1.5, 0, 10)
            'ElseIf Lenhve = "ToSCCodong" Or Lenhve = "SungBBbanMB" Or Lenhve = "tocodongdiettang" Or Lenhve = "dontho" Or Lenhve = "donthuy" Or Lenhve = "coilui" Or Lenhve = "toTSDQTV" Or Lenhve = "toTrSDieutra" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTrsTrongdich" Or Lenhve = "todaccong" Or Lenhve = "tohoahoc" Or Lenhve = "tocongtacBP" Or Lenhve = "toTrSHHCodong" Or Lenhve = "DbanMtuy" Or Lenhve = "Diaban" Or Lenhve = "DoituongS" Then
            '    LiP = LiPCircle(FrmMain.Instance.mPointClick, Bankinh, Goc, 10)
            '    LiP2 = LiPCircle(FrmMain.Instance.mPointClick, Bankinh - Dorongduong * 1.5, Goc, 10)
        ElseIf Lenhve = "hamphao" Then
            LiP = LiPCircle(P2, Bankinh, Goc + 180, 10)
            LiP2 = LiPCircle(P2, Bankinh - Dorongduong * 1.5, Goc + 180, 10)
        ElseIf Lenhve = "HiepdongKQPK" Then
            LiP = LiPCircle(P2, Bankinh, Goc, 10)
            LiP2 = LiPCircle(P2, Bankinh - Dorongduong * 1.5, Goc, 10)
            Dim LiV1 = LiPCircle(P2, Bankinh * 1.5, Goc + 45, 10)
            Dim LiV2 = LiPCircle(P2, Bankinh * 5.0, Goc + 45, 10)
            Dim Liv As New List(Of IPosition71), LiS1 As New List(Of IPosition71), LiS2 As New List(Of IPosition71)
            AddPointToList(Liv, LiV1, 1, 9)
            Liv.Add(LiV2(9))
            AddPointToList(Liv, LiV1, 9, 18)
            Liv.Add(LiV2(18))
            AddPointToList(Liv, LiV1, 18, 27)
            Liv.Add(LiV2(27))
            AddPointToList(Liv, LiV1, 27, 35)
            Liv.Add(LiV1(0))
            Liv.Add(LiV2(0))
            Liv.Add(LiV1(0))
            Liv.Add(LiV1(1))
            LiP.Add(LiP(0))
            LiP2.Add(LiP2(0))
            FDuongList(Liv, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(LiP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(LiP2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            Dim Lama As String = "I,II,III,IV"
            For i As Integer = 0 To 3
                Dim Ps1 As IPosition71 = P2.Move(Dorongduong * 15, i * 90 + FGoc(P1, P2) + 45, 0)
                MakeText(Ps1, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, Lama.Split(",")(i), "", mauChu, 1, 0, 0, 4)
            Next
            AddPointToList(LiS1, LiP, 16, 29)
            AddPointToList(LiS2, LiP, 34, 35)
            AddPointToList(LiS2, LiP, 0, 11)
            FVungList(LiS1, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 4)
            FVungList(LiS2, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 4)
        Else
            LiP = LiPCircle(FrmMain.Instance.mPointClick, Bankinh, 0, 10)
            LiP2 = LiPCircle(FrmMain.Instance.mPointClick, Bankinh - Dorongduong * 1.5, 0, 10)
        End If



        If Lenhve = "TrTTrQuanDB" Or Lenhve = "TrTTrPTKT" Or Lenhve = "TrCMDBtinh" Or Lenhve = "baihacanh" Then
            Dim Pk As IPosition71 = CenterPoint(FrmMain.Instance.mPointClick, LiP(5)) 'FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (FrmMain.Instance.mPointClick.X + LiP(0).X), 0.5 * (FrmMain.Instance.mPointClick.Y + LiP(0).Y), 0, 2, 0, 0, 0, 0)
            Dim Pk1 As IPosition71 = CenterPoint(FrmMain.Instance.mPointClick, LiP(23)) ' FrmMain.Instance.sgworldMain.Creator.CreatePosition(0.5 * (FrmMain.Instance.mPointClick.X + LiP(18).X), 0.5 * (FrmMain.Instance.mPointClick.Y + LiP(18).Y), 0, 2, 0, 0, 0, 0)
            '    FrmMain.Instance.fLabelStyleMain.Scale = SLabelStyleTQ(FrmMain.Instance.sgworldMain).Scale
            If Lenhve = "TrTTrQuanDB" Then
                Dim LiCon As New List(Of IPosition71) From {LiP(14), LiP(32)}
                FDuongList(LiCon, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 2) ' 2, False, 2)
                MakeText(Pk, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 0, "QNDB", "", mauChu, 1, 0, 0, 2)
                MakeText(Pk1, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "TrTTrPTKT" Then
                Dim LiCon As New List(Of IPosition71) From {LiP(14), LiP(32)}
                FDuongList(LiCon, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 2) ' 2, False, 2)
                MakeText(Pk, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 0, "PTKT", "", mauChu, 1, 0, 0, 2)
                MakeText(Pk1, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "baihacanh" Then
                MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, 0, "T", "", mauRedBlue, 1, 0, 0, 2)
            ElseIf Lenhve = "TrCMDBtinh" Then
                Dim LiCon1 As New List(Of IPosition71) From {LiP(13), LiP(33)}
                Dim LiCon2 As New List(Of IPosition71) From {LiP(15), LiP(31)}
                FDuongList(LiCon1, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(LiCon2, 4294967295, "", 0, 0, mau, Dorongduong * 1.2, False, 2, 0, 2) ' 2, False, 2)jiii
                MakeText(Pk, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 0, "bvDC", "", mauChu, 1, 0, 0, 2)
                MakeText(Pk1, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mauChu, 1, 0, 0, 2)
            End If

        ElseIf Lenhve = "SungBBbanMB" Then
            MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 0, "", "2110000", mauChu, 1, 0, 0, 2)
        ElseIf Lenhve = "DbanMtuy" Or Lenhve = "Diaban" Then
            MakeText(FrmMain.Instance.mPointClick, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mauChu, 1, 0, 0, 2)
        End If

        If Lenhve = "ToSCCodong" Or Lenhve = "tocodongdiettang" Or Lenhve = "dontho" Or Lenhve = "donthuy" Or Lenhve = "coilui" Or Lenhve = "toTSDQTV" Or Lenhve = "toTrSDieutra" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTrsTrongdich" Or Lenhve = "todaccong" Or Lenhve = "tohoahoc" Or Lenhve = "tocongtacBP" Or Lenhve = "toTrSHHCodong" Then
            Dim Pmt As IPosition71 = P2.Move(Dorongduong * 20, FGoc(P1, P2), 0)
            Dim Pmt1 As IPosition71 = P2.Move(Dorongduong * 5, FGoc(P1, P2), 0)
            Dim LiMT1 As List(Of IPosition71) = Muiten(Pmt, Pmt1, FGoc(P1, P2), 0.7, 1.0)
            FVungList(LiMT1, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 42)

            If Lenhve = "tohoahoc" Or Lenhve = "toTrSHHCodong" Then
                MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 180 + Goc, "HH", "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "todaccong" Then
                MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 180 + Goc, "ĐC", "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "tocongtacBP" Or Lenhve = "dacnhiemBP" Then
                MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 180 + Goc, "BP", "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "toTrsTrongdich" Or Lenhve = "toTSDQTV" Or Lenhve = "toTSDN" Or Lenhve = "toTrSDieutra" Then
                MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 180 + Goc, "TS", "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "dontho" Or Lenhve = "donthuy" Then
                MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 180 + Goc, "ĐT", "", mauChu, 1, 0, 0, 2)
            ElseIf Lenhve = "ToSCCodong" Then
                MakeText(P2, 0, 3 / 4 * FrmMain.Instance.fLabelStyleMain.Scale, 180 + Goc, "SCVK", "", mauChu, 1, 0, 0, 2)

            End If


        End If

        If Lenhve = "tocodongdiettang" Or Lenhve = "dontho" Or Lenhve = "donthuy" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTSDQTV" Or Lenhve = "toTrsTrongdich" Or Lenhve = "coilui" Then
            Dim liTSDN As New List(Of IPosition71)
            If Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Then 'dacnhiemBP
                AddPointToList(liTSDN, LiP, 0, 18)
                FVungList(liTSDN, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
            ElseIf Lenhve = "toTSDQTV" Then
                liTSDN.Add(LiP(17))
                AddPointToList(liTSDN, LiP, 0, 30)
                liTSDN.Add(LiP(17))
                FVungList(liTSDN, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
            ElseIf Lenhve = "coilui" Then
                CoiLui(FrmMain.Instance.mPointClick, MkGoc(P1, P2) * 180 / Math.PI, mauChu, 35.0)
            ElseIf Lenhve = "toTrsTrongdich" Then
                Dim LiG As New List(Of IPosition71) From {LiP(21), LiP(33), LiP(34), LiP(35), LiP(0), LiP(18), LiP(17), LiP(16), LiP(15), LiP(3)}
                FDuongList(LiG, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
            ElseIf Lenhve = "dontho" Or Lenhve = "donthuy" Then
                Dim liB1 As New List(Of IPosition71) From {LiP(4), LiP2(4)}
                Dim liB2 As New List(Of IPosition71) From {LiP(28), LiP2(28)}
                Dim liB3 As New List(Of IPosition71) From {LiP(16), LiP2(16)}
                FDuongList(liB1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
                FDuongList(liB2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
                FDuongList(liB3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)jiii
                If Lenhve = "donthuy" Then
                    FVungList(LiP2, 4294967295, 0, mau, 0, mauH2O, 1, "", 0, 0, 0, False, 2, 3)
                End If
            ElseIf Lenhve = "tocodongdiettang" Then
                Diettang(LiP(26), LiP(28))
                Diettang(LiP(34), LiP(0))
                Diettang(LiP(9), LiP(11))
                Diettang(LiP(17), LiP(19))
                Dim TQtang As New List(Of Double)({8.29, 90.0, 3.61, 119.16, 3.99, 103.02, 0.91, 169.9, 3.15, 177.09, 3.42, 203.06, 1.61, 236.18, 3.91, 256.71, 8.16, 244.91, 7.53, 258.89, 5.54, 270.0, 7.5, 280.13, 8.04, 293.18, 3.85, 279.0, 1.47, 294.2, 3.15, 334.83, 2.86, 3.21, 0.62, 14.87, 3.93, 81.18, 3.48, 65.09})
                Dim LicK As List(Of IPosition71) = ArrayDoubleToListPoint(TQtang, P2, 32.0, MkGoc(P1, P2) * 180 / Math.PI)
                FVungList(LicK, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
            End If
        End If

        LiP.Add(LiP(0))
        LiP2.Add(LiP2(0))

        If Lenhve = "sanbaytrenbien" Or Lenhve = "sanbaygia" Or Lenhve = "sanbaydachien" Or Lenhve = "sanbayvuotcap" Or Lenhve = "sanbaycap1" Or Lenhve = "sanbaycap2" Or Lenhve = "sanbaycap3" Then
            Dim TQ As New List(Of Double)({75.0, 0.0, 75.0, 15.0, 75.0, 30.0, 75.0, 45.0, 75.0, 60.0, 75.0, 75.0, 60.0, 75.0, 60.0, 285.0, 60.0, 270, 60.0, 255.0, 60.0, 105.0, 60.0, 90.0, 60.0, 75.1, 75.0, 75.08, 75.0, 90.0, 75.0, 105.0, 75.0, 120.0, 75.0, 135.0, 75.0, 150.0, 75.0, 165.0, 75.0, 180.0, 75.0, 195.0, 75.0, 210.0, 75.0, 225.0, 75.0, 240.0, 75.0, 255.0, 75.0, 270.0, 75.0, 285.0, 75.0, 300.0, 75.0, 315.0, 75.0, 330.0, 75.0, 345.0, 128, 45, 128, 135, 128, 225, 128, 315})
            Dim liT As New List(Of IPosition71)
            If Lenhve = "sanbaydachien" Then
                AddPointToList(liT, ArrayDoubleToListPoint(TQ, FrmMain.Instance.mPointClick, 4.5, 90), 0, 5)
                AddPointToList(liT, ArrayDoubleToListPoint(TQ, FrmMain.Instance.mPointClick, 4.5, 90), 13, 31)
            Else
                AddPointToList(liT, ArrayDoubleToListPoint(TQ, FrmMain.Instance.mPointClick, 4.5, 90), 0, 31)
            End If

            FVungList(liT, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 4)
            If Not Lenhve = "sanbaytrenbien" And Not Lenhve = "sanbaygia" And Not Lenhve = "sanbaydachien" And Not Lenhve = "sanbaycap3" Then
                FDuongList(LiP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                FDuongList(LiP2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            End If
            If Lenhve = "sanbayvuotcap" Or Lenhve = "sanbaycap1" Then
                Dim liSB As List(Of IPosition71) = LiPCircle(FrmMain.Instance.mPointClick, Dorongduong * 11, Goc, 5)
                liSB.Add(liSB(0))
                FDuongList(liSB, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                If Lenhve = "sanbayvuotcap" Then
                    Dim liSB1 As List(Of IPosition71) = LiPCircle(FrmMain.Instance.mPointClick, Dorongduong * 14, Goc, 5)
                    liSB1.Add(liSB1(0))
                    FDuongList(liSB1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
                End If

            End If

            If Lenhve = "sanbaytrenbien" Then
                Dim Pb1 As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 9.5, 45, 0)
                Dim Pb2 As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 9.5, 135, 0)
                Dim Pb3 As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 9.5, 225, 0)
                Dim Pb4 As IPosition71 = FrmMain.Instance.mPointClick.Move(Dorongduong * 9.5, 315, 0)
                Dim lisf As New List(Of IPosition71) From {Pb1, Pb2, Pb3, Pb4, Pb1}
                FDuongList(lisf, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            End If

        End If

        If Lenhve = "hinhtron" Then
            FDuongList(LiP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4)
        ElseIf Lenhve = "hamphao" Or Lenhve = "hamVK" Then
            Dim liHamC, liHamD As New List(Of IPosition71)
            AddPointToList(liHamC, LiP, 30, 36)
            AddPointToList(liHamC, LiP, 0, 15)
            AddPointToList(liHamD, LiP2, 29, 36)
            AddPointToList(liHamD, LiP2, 0, 16)
            Dim Pp As IPosition71 = liHamC(22).Move(Dorongduong * 5, 90 + FGoc(P1, P2), 0)
            Dim Pt As IPosition71 = liHamC(0).Move(Dorongduong * 5, 270 + FGoc(P1, P2), 0)
            Dim Pdp As IPosition71 = liHamD(24).Move(Dorongduong * 5, 90 + FGoc(P1, P2), 0)
            Dim Pdt As IPosition71 = liHamD(0).Move(Dorongduong * 5, 270 + FGoc(P1, P2), 0)
            If Lenhve = "hamVK" Then
                Dim Pp1 As IPosition71 = liHamC(22).Move(Dorongduong * 2, 270 + FGoc(P1, P2), 0)
                Dim Pt1 As IPosition71 = liHamC(0).Move(Dorongduong * 2, 90 + FGoc(P1, P2), 0)
                Dim LiD1 As New List(Of IPosition71) From {liHamC(0), Pt1, liHamC(6)}
                Dim LiD2 As New List(Of IPosition71) From {liHamC(22), Pp1, liHamC(16)}
                FDuongList(LiD1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(LiD2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            End If
            liHamC.Add(Pp)
            liHamC.Reverse()
            liHamC.Add(Pt)
            liHamD.Add(Pdp)
            liHamD.Reverse()
            liHamD.Add(Pdt)
            FDuongList(liHamC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(liHamD, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
        ElseIf Lenhve = "kvvkhatnhanno" Then
            FDuongList(LiP, 4294967295, "", 0, 0, Smau1, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(LiP2, 4294967295, "", 0, 0, Smau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)jiii
            FVungList(LiPCircle(P1, Dorongduong * 10, 0, 10), 4294967295, 0, Smau1, 0, Smau1, 1, "", 0, 0, 0, False, 2, 3)
        ElseIf Lenhve = "DbanMtuy" Or Lenhve = "ToSCCodong" Or Lenhve = "SungBBbanMB" Or Lenhve = "tocodongdiettang" Or Lenhve = "TrTTrQuanDB" Or Lenhve = "TrCMDBtinh" Or Lenhve = "TrTTrPTKT" Or Lenhve = "DbanMtuy" Or Lenhve = "baihacanh" Or Lenhve = "toTSDQTV" Or Lenhve = "toTrSDieutra" Or Lenhve = "toTSDN" Or Lenhve = "dacnhiemBP" Or Lenhve = "toTrsTrongdich" Or Lenhve = "todaccong" Or Lenhve = "tohoahoc" Or Lenhve = "tocongtacBP" Or Lenhve = "toTrSHHCodong" Or Lenhve = "coilui" Or Lenhve = "dontho" Or Lenhve = "donthuy" Then
            FDuongList(LiP, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(LiP2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
        ElseIf Lenhve = "Diaban" Then
            FDuongList(LiP, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(LiP2, 4294967295, "", 0, 0, mau4, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
        ElseIf Lenhve = "TuyengiaoNvu" Then
            Dim Cli, Dli As New List(Of IPosition71)
            AddPointToList(Cli, LiP, 29, LiP.Count - 1)
            AddPointToList(Cli, LiP, 0, 26)
            AddPointToList(Dli, LiP2, 29, LiP2.Count - 1)
            AddPointToList(Dli, LiP2, 0, 26)

            FDuongList(Cli, 4294967295, "", 0, 0, Smau1, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(Dli, 4294967295, "", 0, 0, Smau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)jiii
            MakeText(LiP(27), 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mau, 1, 0, 0, 4)
        ElseIf Lenhve = "AntoanHatnhan" Then
            Dim LiP3 As List(Of IPosition71) = LiPCircle(P1, Bankinh - Dorongduong * 10, Goc, 5)
            Dim LiM As List(Of IPosition71) = FourPoint(LiP, 7, 12, 3)
            Dim LiC As New List(Of IPosition71) From {LiM(12), LiM(13)}
            AddPointToList(LiC, LiP, 0, 6)
            LiC.Add(LiM(4))
            LiC.Add(LiM(0))
            LiC.Add(LiP3(7))
            LiC.Add(LiM(1))
            LiC.Add(LiM(6))
            AddPointToList(LiC, LiP, 8, 11)
            LiC.Add(LiM(5))
            LiC.Add(LiM(2))
            LiC.Add(LiP3(12))
            LiC.Add(LiM(3))
            LiC.Add(LiM(7))
            AddPointToList(LiC, LiP, 13, 18)
            LiC.Add(LiM(14))
            LiC.Add(LiM(15))
            FDuongList(LiC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            Dim liD1, liD2, liD3 As New List(Of IPosition71)
            AddPointToList(liD1, LiP2, 0, 6)
            liD1.Add(LiM(8))
            liD2.Add(LiM(9))
            AddPointToList(liD2, LiP2, 8, 11)
            liD2.Add(LiM(11))
            liD3.Add(LiM(10))
            AddPointToList(liD3, LiP2, 13, 18)
            FDuongList(liD1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            FDuongList(liD2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            FDuongList(liD3, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
        ElseIf Lenhve = "GioiHanHatnhan" Then
            Dim LiP3 As List(Of IPosition71) = LiPCircle(P1, Bankinh - Dorongduong * 10, Goc, 5)
            Dim LiM As List(Of IPosition71) = FourPoint(LiP3, 7, 11, 3)
            Dim liC As New List(Of IPosition71)
            AddPointToList(liC, LiP, 0, 7)
            liC.Add(LiM(0))
            liC.Add(LiP(7))
            liC.Add(LiM(1))
            AddPointToList(liC, LiP, 7, 11)
            liC.Add(LiM(2))
            liC.Add(LiP(11))
            liC.Add(LiM(3))
            AddPointToList(liC, LiP, 11, 18)
            FDuongList(liC, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            Dim liD1 As New List(Of IPosition71)
            AddPointToList(liD1, LiP2, 0, 18)
            FDuongList(liD1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.2, False, 2, 0, 3) ' 2, False, 2)
        ElseIf Lenhve = "GioihanvungTrSDientuSN" Or Lenhve = "GioihanvungTrSdienttuSCNVHF" Or Lenhve = "GioihanvungTrSDTsieucaotan" Then
            Dim liC1, liC2, liC3, liD1, liD2, liD3 As New List(Of IPosition71)
            Dim LiM As List(Of IPosition71) = FourPoint(LiP, 7, 12, 5)
            AddPointToList(liC1, LiP, 0, 6)
            liC1.Add(LiM(0))
            liC2.Add(LiM(1))
            AddPointToList(liC2, LiP, 8, 11)
            liC2.Add(LiM(2))
            liC3.Add(LiM(3))
            AddPointToList(liC3, LiP, 13, 18)
            FDuongList(liC1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(liC2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(liC3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            AddPointToList(liD1, LiP2, 0, 6)
            liD1.Add(LiM(8))
            liD2.Add(LiM(9))
            AddPointToList(liD2, LiP2, 8, 11)
            liD2.Add(LiM(11))
            liD3.Add(LiM(10))
            AddPointToList(liD3, LiP2, 13, 18)
            FDuongList(liD1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            FDuongList(liD2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            FDuongList(liD3, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            If Lenhve = "GioihanvungTrSdienttuSCNVHF" Then
                Dauchuthap(LiP(7), FGoc(LiP(5), LiP(7)), mau, 2.5)
                Dauchuthap(LiP(12), FGoc(LiP(12), LiP(13)), mau, 2.5)
            ElseIf Lenhve = "GioihanvungTrSDTsieucaotan" Then
                MCircleTQ(LiP(7), Dorongduong * 4, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
                MCircleTQ(LiP(12), Dorongduong * 4, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
            End If
        ElseIf Lenhve = "GioihanvungTrSdientuSCNUHF" Then
            Dim liC1 As New List(Of IPosition71), liC2 As New List(Of IPosition71), liC3 As New List(Of IPosition71)
            Dim liD1 As New List(Of IPosition71), liD2 As New List(Of IPosition71), liD3 As New List(Of IPosition71)
            Dim LiM As List(Of IPosition71) = FourPoint(LiP, 6, 12, 3.0)
            AddPointToList(liC1, LiP, 0, 5)
            liC1.Add(LiM(4))
            liC2.Add(LiM(6))
            AddPointToList(liC2, LiP, 7, 11)
            liC2.Add(LiM(5))
            liC3.Add(LiM(7))
            AddPointToList(liC3, LiP, 13, 18)
            FDuongList(liC1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(liC2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)
            FDuongList(liC3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4) ' 2, False, 2)

            AddPointToList(liD1, LiP2, 0, 5)
            liD1.Add(LiM(8))
            liD2.Add(LiM(9))
            AddPointToList(liD2, LiP2, 7, 11)
            liD2.Add(LiM(11))
            liD3.Add(LiM(10))
            AddPointToList(liD3, LiP2, 13, 18)
            FDuongList(liD1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            FDuongList(liD2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            FDuongList(liD3, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 3) ' 2, False, 2)
            Dauchuthap(LiM(0), FGoc(LiP(6), LiP(7)), mau, 2.5)
            Dauchuthap(LiM(1), FGoc(LiP(6), LiP(7)), mau, 2.5)
            Dauchuthap(LiM(2), FGoc(LiP(12), LiP(13)), mau, 2.5)
            Dauchuthap(LiM(3), FGoc(LiP(12), LiP(13)), mau, 2.5)
        ElseIf Lenhve = "tamnhiemxa" Then
            FVungList(LiPCircle(P1, Bankinh, 0, 10), 4294967295, Dorongduong * 1.5, Smau1, 1, Smau1, 0, "", 0, 0, 0, False, 2, 4)
            FVungList(LiPCircle(P1, Bankinh - Dorongduong * 1.5, 0, 10), 4294967295, Dorongduong * 1.5, Smau2, 1, Smau2, 0, "", 0, 0, 0, False, 2, 1)
            FVungList(LiPCircle(P1, Bankinh * 0.6, 0, 10), 4294967295, Dorongduong * 1.5, mauXanh, 1, Smau1, 0, "", 0, 0, 0, False, 2, 3)
            FVungList(LiPCircle(P1, Bankinh * 0.3, 0, 10), 4294967295, Dorongduong * 1.5, mauNau, 1, Smau1, 0, "", 0, 0, 0, False, 2, 3)
            FVungList(LiPCircle(P1, Bankinh * 0.07, 0, 10), 4294967295, Dorongduong * 1.5, mauChu, 1, Smau1, 0, "", 0, 0, 0, False, 2, 3)
        ElseIf Lenhve = "BkinhTu" Or Lenhve = "BkinhMB" Then
            Dim LiC, LiD As New List(Of IPosition71)
            Dim kC As Double = FKc(P1, P2) / 20
            AddPointToList(LiC, LiP, 5, LiP.Count - 1)
            AddPointToList(LiC, LiP, 0, 4)
            AddPointToList(LiD, LiP2, 5, LiP2.Count - 1)
            AddPointToList(LiD, LiP2, 0, 4)
            Dim PkC As IPosition71 = CenterPoint(LiC(0), LiC(36))
            Dim Pk1 As IPosition71 = CenterPoint(PkC, LiC(36))
            Dim Pk2 As IPosition71 = CenterPoint(PkC, LiC(0))
            Dim Pk11 As IPosition71 = Pk1.Move(kC, Goc, 0)
            Dim Pk12 As IPosition71 = Pk1.Move(kC, 180 + Goc, 0)
            Dim Pk21 As IPosition71 = Pk2.Move(kC, Goc, 0)
            Dim Pk22 As IPosition71 = Pk2.Move(kC, 180 + Goc, 0)

            Dim lIn1 As New List(Of IPosition71) From {Pk11, LiC(36), Pk12, LiC(36)}
            Dim lIn2 As New List(Of IPosition71) From {Pk21, LiC(0), Pk22, LiC(0)}
            AddPointToList(LiC, lIn1, 0, 3)
            LiC.Reverse()
            AddPointToList(LiC, lIn2, 0, 3)
            FDuongList(LiC, 4294967295, "", 0, 0, Smau1, Dorongduong * 2.5, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(LiD, 4294967295, "", 0, 0, Smau2, Dorongduong * 2.5, False, 2, 0, 3) ' 2, False, 2)jiii
            If Lenhve = "BkinhMB" Then
                MB(PkC, (MkGoc(P1, P2) * 180.0 / Math.PI), 4.0)
            ElseIf Lenhve = "BkinhTu" Then
                PointHQ = P2.Move(Dorongduong * 12, 180, 0)
                GocHQ = 0
                TauHaiquan()
            End If

        ElseIf Lenhve = "Tuyentucanhgioi" Then
            Dim LiC, LiD As New List(Of IPosition71)
            AddPointToList(LiC, LiP, 13, 32)
            AddPointToList(LiD, LiP2, 13, 32)
            Dim Pp As IPosition71 = LiC(1).Move(FKc(P1, P2) / 5, 90, 0)
            Dim Pp1 As IPosition71 = Pp.Move(Dorongduong * 1.5, 180, 0)
            Dim Pt As IPosition71 = LiC(18).Move(FKc(P1, P2) / 5, 270, 0)
            Dim Pt1 As IPosition71 = Pt.Move(Dorongduong * 1.5, 180, 0)
            LiC.Add(Pt)
            LiC.Reverse()
            LiC.Add(Pp)
            LiD.Add(Pt1)
            LiD.Reverse()
            LiD.Add(Pp1)
            FDuongList(LiC, 4294967295, "", 0, 0, Smau1, Dorongduong * 2.5, False, 2, 0, 4)
            FDuongList(LiD, 4294967295, "", 0, 0, Smau2, Dorongduong * 2.5, False, 2, 0, 3)
            PointHQ = P1.Move(Dorongduong * 6, 0, 0)
            GocHQ = Goc
            TauHaiquan()
        ElseIf Lenhve = "GihanVungcheap" Then
            Dim Cli1, Cli2, Dli1, Dli2 As New List(Of IPosition71)
            AddPointToList(Cli1, LiP, 66, LiP.Count - 1)
            AddPointToList(Cli1, LiP, 0, 6)
            AddPointToList(Cli2, LiP, 12, 24)
            Cli1.Reverse()
            AddPointToList(Dli1, LiP2, 66, LiP.Count - 1)
            AddPointToList(Dli1, LiP2, 0, 6)
            AddPointToList(Dli2, LiP2, 12, 24)
            Dim Pc As IPosition71 = CenterPoint(Cli1(0), Cli2(0))
            Dim Ps1 As IPosition71 = Pc.Move(0.5 * FKc(Cli1(0), Cli2(0)) - Dorongduong * 2, 90 + FGoc(P1, P2), 0)
            Dim Ps2 As IPosition71 = Pc.Move(0.5 * FKc(Cli1(0), Cli2(0)) - Dorongduong * 2, 270 + FGoc(P1, P2), 0)
            Dim Pm1 As IPosition71 = Pc.Move(0.3 * FKc(Cli1(0), Cli2(0)), FGoc(P1, P2), 0)
            Dim Pm2 As IPosition71 = Pc.Move(0.5 * FKc(Cli1(0), Cli2(0)), FGoc(P1, P2), 0)
            Dim Pm21 As IPosition71 = Pm2.Move(0.2 * FKc(Cli1(0), Cli2(0)), 90 + FGoc(P1, P2), 0)
            Dim Pm22 As IPosition71 = Pm2.Move(0.2 * FKc(Cli1(0), Cli2(0)), 270 + FGoc(P1, P2), 0)
            Dim Pm3 As IPosition71 = Pc.Move(FKc(Cli1(0), Cli2(0)), FGoc(P1, P2), 0)
            Dim LiMT1 As List(Of IPosition71) = Muiten(Ps2, Pm22, 180 + FGoc(Pm22, Ps2), 0.85, 1.0)
            Dim LiMT2 As List(Of IPosition71) = Muiten(Ps1, Pm21, 180 + FGoc(Pm21, Ps1), 0.85, 1.0)
            FVungList(LiMT1, 4294967295, 0, Smau1, 0, Smau1, 1, "", 0, 0, 0, False, 2, 4)
            FVungList(LiMT2, 4294967295, 0, Smau1, 0, Smau1, 1, "", 0, 0, 0, False, 2, 4)
            Dim LiK As New List(Of IPosition71) From {Pm3, Pm1, Pm21, Pm1, Pm22}
            FDuongList(LiK, 4294967295, "", 0, 0, Smau1, Dorongduong * 2, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(Cli1, 4294967295, "", 0, 0, Smau1, Dorongduong * 2, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(Cli2, 4294967295, "", 0, 0, Smau1, Dorongduong * 2, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(Dli1, 4294967295, "", 0, 0, Smau2, Dorongduong * 2, False, 2, 0, 4) ' 2, False, 2)jiii
            FDuongList(Dli2, 4294967295, "", 0, 0, Smau2, Dorongduong * 2, False, 2, 0, 4) ' 2, False, 2)jiii
            Dim Pm31 As IPosition71 = Pm3.Move(0.15 * FKc(Cli1(0), Cli2(0)), 90 + FGoc(P1, P2), 0)
            Dim Pm32 As IPosition71 = Pm3.Move(0.15 * FKc(Cli1(0), Cli2(0)), 270 + FGoc(P1, P2), 0)
            MakeText(Pm31, 0, FrmMain.Instance.fLabelStyleMain.Scale, Goc, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(0), "", mauChu, 1, 0, 0, 4)
            MakeText(Pm32, 0, FrmMain.Instance.fLabelStyleMain.Scale, Goc, FrmMain.Instance.TxtGhichuKH.Text.Split(",")(1), "", mauChu, 1, 0, 0, 4)
        End If

Het:
        SLenhve3DMs()
    End Sub

    Private Sub Diettang(p1 As IPosition71, p2 As IPosition71)
        Dim Pc As IPosition71 = CenterPoint(p1, p2)
        Dim Pg1 As IPosition71 = Pc.Move(Dorongduong * 4, 90 + FGoc(p1, p2), 0)
        Dim LiG As New List(Of IPosition71) From {p1, p2, Pg1}
        FVungList(LiG, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 4)
    End Sub

    Function FourPoint(liC As List(Of IPosition71), Dau As Integer, Cuoi As Integer, Heso As Double) As List(Of IPosition71)
        Dim D1 As IPosition71 = liC(Dau).Move(Dorongduong * Heso, FGoc(liC(Dau), liC(Dau + 1)), 0)
        Dim D2 As IPosition71 = liC(Dau).Move(Dorongduong * Heso, 180 + FGoc(liC(Dau), liC(Dau + 1)), 0)
        Dim C1 As IPosition71 = liC(Cuoi).Move(Dorongduong * Heso, FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)
        Dim C2 As IPosition71 = liC(Cuoi).Move(Dorongduong * Heso, 180 + FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)
        '//////
        Dim D3 As IPosition71 = liC(Dau).Move(Dorongduong * Heso * 2.5, FGoc(liC(Dau - 1), liC(Dau)), 0)
        Dim D4 As IPosition71 = liC(Dau).Move(Dorongduong * Heso * 2.5, 180 + FGoc(liC(Dau), liC(Dau + 1)), 0)
        Dim C3 As IPosition71 = liC(Cuoi).Move(Dorongduong * Heso * 2.5, FGoc(liC(Cuoi - 1), liC(Cuoi)), 0)
        Dim C4 As IPosition71 = liC(Cuoi).Move(Dorongduong * Heso * 2.5, 180 + FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)

        Dim T1 As IPosition71, T2 As IPosition71, S1 As IPosition71, S2 As IPosition71
        If Lenhve = "GioihanvungTrSdientuSCNUHF" Then
            T1 = D3.Move(Dorongduong * 1.2, 270 + FGoc(liC(Dau), liC(Dau + 1)), 0)
            T2 = D4.Move(Dorongduong * 1.2, 270 + FGoc(liC(Dau), liC(Dau + 1)), 0)
            S1 = C3.Move(Dorongduong * 1.2, 270 + FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)
            S2 = C4.Move(Dorongduong * 1.2, 270 + FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)
        Else
            T1 = D1.Move(Dorongduong * 1.2, 270 + FGoc(liC(Dau), liC(Dau + 1)), 0)
            T2 = D2.Move(Dorongduong * 1.2, 270 + FGoc(liC(Dau), liC(Dau + 1)), 0)
            S1 = C2.Move(Dorongduong * 1.2, 270 + FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)
            S2 = C1.Move(Dorongduong * 1.2, 270 + FGoc(liC(Cuoi), liC(Cuoi + 1)), 0)
        End If
        '////////////
        Dim V11 As IPosition71 = liC(0).Move(Dorongduong * 3, 90 + FGoc(liC(0), liC(1)), 0)
        Dim V12 As IPosition71 = liC(0).Move(Dorongduong * 3, 270 + FGoc(liC(0), liC(1)), 0)
        Dim V21 As IPosition71 = liC(18).Move(Dorongduong * 3, 90 + FGoc(liC(17), liC(18)), 0)
        Dim V22 As IPosition71 = liC(18).Move(Dorongduong * 3, 270 + FGoc(liC(17), liC(18)), 0)
        Dim LiC1 As New List(Of IPosition71) From {D1, D2, C1, C2, D3, C3, D4, C4, T1, T2, S1, S2, V11, V12, V21, V22}
        FourPoint = LiC1
    End Function

#End Region

End Module







