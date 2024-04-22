Imports TerraExplorerX
Module mdlBaoloanlatdo

#Region "    Bobinh"
    Public Sub Trunglien()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({90.0 * Tyle, 0.0, 102.96 * Tyle, 29.1, 55.9 * Tyle, 63.4, 495.63 * Tyle, 87.1, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 495.63 * Tyle, 92.9, 55.9 * Tyle, 116.6, 102.96 * Tyle, 150.9, 90.0 * Tyle, 180.0, 50.0 * Tyle, 0.0, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 50.0 * Tyle, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 11, 15, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Dailien()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({25.0 * Tyle, 0.0, 206.31 * Tyle, 83.0, 206.82 * Tyle, 81.3, 208.87 * Tyle, 72.7, 212.18 * Tyle, 64.3, 216.71 * Tyle, 56.0, 222.34 * Tyle, 47.9, 228.87 * Tyle, 40.1, 263.88 * Tyle, 48.5, 261.59 * Tyle, 55.3, 259.67 * Tyle, 62.1, 258.14 * Tyle, 69.1, 257.03 * Tyle, 76.0, 256.36 * Tyle, 83.0, 256.01 * Tyle, 84.4, 495.63 * Tyle, 87.1, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 495.63 * Tyle, 92.9, 256.01 * Tyle, 95.6, 256.36 * Tyle, 97.0, 257.03 * Tyle, 104.0, 258.14 * Tyle, 110.9, 259.67 * Tyle, 117.9, 263.88 * Tyle, 131.5, 228.87 * Tyle, 139.9, 222.31 * Tyle, 132.1, 216.71 * Tyle, 124.0, 208.87 * Tyle, 107.3, 206.82 * Tyle, 98.7, 206.31 * Tyle, 97.0, 25.0 * Tyle, 180.0, 50.0 * Tyle, 0.0, 167.76 * Tyle, 72.7, 228.87 * Tyle, 40.1, 256.31 * Tyle, 78.8, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 256.31 * Tyle, 101.2, 228.87 * Tyle, 139.9, 167.76 * Tyle, 107.3, 50.0 * Tyle, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 32, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 33, 43, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Phongluu()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.009, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 577.71, 87.4, 577.71, 92.6, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 50.0, 0.0, 50.0, 330.0, 50.0, 300.0, 50.0, 270.0, 50.0, 240.0, 50.0, 210.0, 50.0, 180.0, 50.0, 150.0, 50.0, 120.0, 50.0, 90.0, 50.0, 60.0, 50.0, 30.0, 50.0, 0.009, 100.0, 59.991, 579.3, 85.04, 579.3, 94.94, 100.0, 119.91})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 38, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 39, 42, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub B40()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.009, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 169.56, 81.26, 208.53, 53.514, 250.49, 60.337, 219.11, 83.257, 577.71, 87.4, 577.71, 92.6, 219.11, 96.824, 250.49, 120.093, 208.53, 126.954, 169.56, 98.82, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 50.0, 0.0, 50.0, 330.0, 50.0, 300.0, 50.0, 270.0, 50.0, 240.0, 50.0, 210.0, 50.0, 180.0, 50.0, 150.0, 50.0, 120.0, 50.0, 90.0, 50.0, 60.0, 50.0, 30.0, 50.0, 0.009, 100.0, 59.991, 579.3, 85.04, 579.3, 94.94, 100.0, 119.91})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 46, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 47, 50, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub B41()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.009, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 169.56, 81.26, 208.53, 53.514, 250.49, 60.337, 219.11, 83.257, 577.71, 87.4, 577.71, 92.6, 219.11, 96.824, 250.49, 120.093, 208.53, 126.954, 169.56, 98.82, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 100.0, 59.991, 579.3, 85.04, 579.3, 94.94, 100.0, 119.91})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 34, 37, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Coi60()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI + 180
        SCoi(FrmMain.Instance.mPointClick, Goc1 + 15)
        SLenhve3DMs()
    End Sub

    Public Sub Congsuhoakhikhongnap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({225.0, 0.015, 503.12, 63.435, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 503.12, 116.565, 225.0, 180.0, 225.0, 0.0, 175.57, 19.983, 175.57, 160.017, 423.47, 112.932, 423.47, 67.068, 175.59, 20.001, 159.49, 41.202, 365.27, 70.821, 365.27, 109.179, 159.45, 138.814, 159.45, 41.186})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Congsuhoakhiconap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({225.0, 0.015, 503.12, 63.435, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 503.12, 116.565, 225.0, 180.0, 225.0, 0.0, 175.57, 19.983, 175.57, 160.017, 423.47, 112.932, 423.47, 67.068, 175.59, 20.001, 159.49, 41.202, 365.27, 70.821, 365.27, 109.179, 159.45, 138.814, 159.45, 41.186, 387.12, 64.772, 423.47, 67.068, 408.81, 72.553, 194.21, 148.169, 175.57, 160.017, 134.16, 153.435})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 23, 28, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Hamkhongconap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({345.0, 0.001, 567.03, 52.524, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 567.03, 127.476, 345.0, 180.0, 345.0, 0.0, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 483.04, 53.842, 291.25, 11.89, 261.96, 23.63, 420.27, 55.176, 420.27, 124.824, 261.96, 156.371, 261.96, 23.629})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Hamconap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({345.0, 0.001, 567.03, 52.524, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 567.03, 127.476, 345.0, 180.0, 345.0, 0.0, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 483.04, 53.842, 291.25, 11.89, 261.96, 23.63, 420.27, 55.176, 420.27, 124.824, 261.96, 156.371, 261.96, 23.629, 455.51, 51.268, 483.04, 53.842, 450.31, 60.005, 300.31, 161.626, 291.25, 168.111, 232.98, 165.076})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 23, 28, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub HamNBC()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({345.0, 0.001, 567.03, 52.524, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 567.03, 127.476, 345.0, 180.0, 345.0, 0.0, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 291.25, 11.89, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 402.48, 120.997, 420.27, 124.824, 261.96, 156.371, 232.35, 26.866})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 16, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 17, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HamkiencochongNBC()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({250.0, 0.001, 353.55, 45.0, 279.51, 63.435, 1007.78, 82.875, 1030.78, 104.036, 790.57, 108.435, 760.35, 99.462, 125.0, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub HamdachienchongNBC()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim fileName As String '= String.Empty
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Then
            fileName = "BTVTr.gif"
        Else
            fileName = "BTkoVTr.gif"
        End If
        Dim TQ As New List(Of Double)({250.0, 0.001, 353.55, 45.0, 279.51, 63.435, 1007.78, 82.875, 1030.78, 104.036, 790.57, 108.435, 760.35, 99.462, 125.0, 180.0, 250.0, 0.0, 199.25, 17.526, 88.46, 137.291, 812.6, 94.588, 831.99, 103.201, 959.01, 101.427, 942.24, 86.044, 200.81, 71.114, 268.7, 45.0, 199.25, 17.524, 178.04, 38.155, 197.99, 45.0, 140.8, 83.884, 890.13, 89.034, 900.94, 98.94, 871.32, 99.246, 860.13, 90.999, 111.02, 97.765, 178.04, 38.157})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 9, 26, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 1.25, Goc1), 9, 17, 4294967295, 0, mau2, 0, mau2, 1, fileName, 2.0 * Tyle, 2.0 * Tyle, 45, False, 2, 2)
        SLenhve3DMs()
    End Sub
#End Region

#Region "    BienPhong"
    Public Sub CanoBP()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({114.16, 28.84, 223.61, 63.43, 243.55, 67.06, 260.52, 71.19, 274.11, 75.64, 284.03, 80.32, 290.06, 85.13, 292.08, 90.0, 290.06, 94.87, 284.03, 99.68, 274.11, 104.36, 260.52, 108.81, 243.55, 112.94, 223.61, 116.57, 100.0, 180.0, 100.0, 0.0, 114.13, 28.81, 89.02, 36.16, 76.16, 23.2, 76.16, 156.8, 208.97, 109.57, 224.51, 107.18, 237.44, 104.31, 247.9, 101.04, 255.58, 97.5, 260.27, 93.79, 261.85, 90.0, 260.27, 86.21, 255.58, 82.5, 247.9, 78.96, 237.44, 75.69, 224.51, 72.82, 208.97, 70.43, 89.06, 38.18, 71.09, 50.73, 199.45, 76.96, 210.64, 78.36, 219.54, 80.14, 226.83, 82.29, 232.23, 84.72, 235.54, 87.32, 236.65, 90.0, 235.54, 92.68, 232.23, 95.28, 226.83, 97.71, 219.54, 99.86, 210.64, 101.64, 199.45, 103.04, 71.06, 129.29, 76.16, 23.2, 103.28, 47.33, 135.62, 81.6, 204.35, 70.04, 220.66, 72.22, 234.95, 75.13, 157.13, 90.0, 234.85, 104.87, 220.66, 107.78, 204.35, 109.96, 135.62, 98.4, 103.28, 132.67, 76.16, 156.8, 111.19, 90.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 17, 48, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 49, 62, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HuongXamnhap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({0.0, 0.0, 245.15, 70.44, 217.85, 79.18, 576.86, 81.63, 573.24, 84.62, 166.72, 88.29, 180.23, 80.02, 90.8, 90.0, 180.22, 99.45, 166.73, 91.24, 572.72, 94.79, 576.03, 97.78, 217.93, 100.31, 245.3, 109.03, 573.24, 84.62, 166.72, 88.29, 180.23, 80.02, 90.8, 90.0, 180.22, 99.45, 166.73, 91.24, 572.72, 94.79, 571.39, 92.78, 304.41, 90.0, 571.71, 86.63})
        Dim TQ2 As New List(Of Double)({20.0, 0.0, 233.95, 0.0, 235.86, 7.31, 265.64, 6.48, 308.65, 328.78, 283.43, 325.63, 267.64, 330.94, 131.53, 278.75, 101.98, 281.31, 254.42, 336.86, 247.25, 341.12, 82.46, 284.04, 53.85, 291.8, 239.23, 347.94, 235.86, 352.69, 36.06, 303.69, 20.0, 180.0, 233.95, 180.0, 235.86, 172.5, 265.64, 173.37, 308.65, 211.81, 283.43, 215.06, 267.64, 209.69, 131.53, 261.25, 101.98, 258.69, 254.42, 203.68, 247.25, 199.33, 82.46, 255.96, 53.85, 248.2, 239.23, 192.37, 235.86, 187.5, 36.06, 236.31})
        Dim TQ3 As New List(Of Double)({0.0, 0.0, 218.49, 76.71, 194.93, 86.23, 235.7, 86.71, 269.42, 86.39, 303.29, 85.5, 337.61, 84.29, 373.12, 82.68, 404.78, 81.1, 440.03, 79.09, 469.18, 77.32, 543.61, 71.76, 579.0, 78.32, 490.77, 82.44, 456.63, 84.42, 421.83, 86.36, 383.4, 88.28, 349.95, 90.0, 308.17, 91.5, 275.8, 92.59, 235.86, 93.42, 194.61, 93.68, 218.2, 103.1, 194.93, 86.23, 235.7, 86.71, 269.42, 86.39, 303.29, 85.5, 337.61, 84.29, 373.12, 82.68, 404.78, 81.1, 440.03, 79.09, 469.18, 77.32, 543.61, 71.76, 527.48, 67.8, 456.05, 73.87, 428.73, 75.88, 396.43, 77.8, 365.41, 79.52, 332.38, 81.16, 299.8, 82.46, 267.53, 83.38, 236.7, 83.79, 201.25, 83.43})
        If Lenhve = "huongxamnhapCY" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 13, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 14, 23, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        Else
            FVungPoint(ArrayPoint(TQ3, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 22, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ3, FrmMain.Instance.mPointClick, 3.0, Goc1), 23, 42, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        End If
        FVungPoint(ArrayPoint(TQ2, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 15, 4294967295, 0, mau, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ2, FrmMain.Instance.mPointClick, 3.0, Goc1), 16, 31, 4294967295, 0, mau, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub NganchanPhuckich()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0)
        Dim Goc As Double = FGoc(P1, P2)
        Dim lIPv1, lIPv2, lIPv3, LiMT1 As New List(Of IPosition71), LiMT2, LiMT3 As List(Of IPosition71),
            Pmt1 As IPosition71, Pmt2 As IPosition71, Pmt3 As IPosition71, Pc1 As IPosition71 ', Pc2 As IPosition71 = Nothing, Pc3 As IPosition71 = Nothing

        If Lenhve = "nganchanBP" Or Lenhve = "nganchandamdong" Then
            AddPointToList(lIPv1, LiPCircle(P2, Dorongduong * 12, Goc, 10), 34, 35)
            AddPointToList(lIPv1, LiPCircle(P2, Dorongduong * 12, Goc, 10), 0, 11)
            AddPointToList(lIPv2, LiPCircle(P2, Dorongduong * 10.5, Goc, 10), 34, 35)
            AddPointToList(lIPv2, LiPCircle(P2, Dorongduong * 10.5, Goc, 10), 0, 11)
            Pc1 = CenterPoint(lIPv1(6), lIPv1(7))
            Pmt1 = Pc1.Move(Dorongduong * 15, Goc, 0)
            LiMT1 = Muiten(Pmt1, Pc1, 180 + FGoc(P2, P1), 0.7, 1.0)
            FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
            Dim Pt As IPosition71 = lIPv1(13).Move(Dorongduong * 3, 90 + FGoc(P1, P2), 0)
            Dim Pp As IPosition71 = lIPv1(0).Move(Dorongduong * 3, 270 + FGoc(P1, P2), 0)
            Dim Pt1 As IPosition71 = lIPv2(13).Move(Dorongduong * 3, 90 + FGoc(P1, P2), 0)
            Dim Pp1 As IPosition71 = lIPv2(0).Move(Dorongduong * 3, 270 + FGoc(P1, P2), 0)
            lIPv1.Add(Pt)
            lIPv1.Reverse()
            lIPv1.Add(Pp)
            lIPv2.Add(Pt1)
            lIPv2.Reverse()
            lIPv2.Add(Pp1)
            FDuongList(lIPv1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lIPv2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        ElseIf Lenhve = "phuckichBP" Or Lenhve = "dayNquayve" Then
            Dim Srong, Sdai As Double
            If Lenhve = "dayNquayve" Then
                Srong = Dorongduong * 7.0
                Sdai = 20.0
            Else
                Srong = Dorongduong * 15.0
                Sdai = 15.0
            End If
            Dim pk As IPosition71 = P2.Move(Srong, FGoc(P1, P2), 0)
            AddPointToList(lIPv1, LiPCircle(pk, Srong, Goc, 10), 14, 31)
            AddPointToList(lIPv2, LiPCircle(pk, Srong - 1.5 * Dorongduong, Goc, 10), 14, 31)
            Pmt1 = lIPv1(0).Move(Dorongduong * Sdai, Goc, 0)
            Pmt2 = lIPv1(17).Move(Dorongduong * Sdai, Goc, 0)
            LiMT1 = Muiten(Pmt1, lIPv1(0), 180 + FGoc(P2, P1), 0.7, 1.0)
            LiMT2 = Muiten(Pmt2, lIPv1(17), 180 + FGoc(P2, P1), 0.7, 1.0)
            lIPv2.Add(LiMT2(5))
            lIPv2.Reverse()
            lIPv2.Add(LiMT1(2))
            If Lenhve = "phuckichBP" Then
                Pc1 = CenterPoint(lIPv1(8), lIPv1(9))
                Pmt3 = Pc1.Move(Dorongduong * 30, Goc, 0)
                LiMT3 = Muiten(Pmt3, Pc1, 180 + FGoc(P2, P1), 0.7, 1.0)
                FVungList(LiMT3, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                FDuongList(lIPv1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(lIPv2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
            Else
                FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                FVungList(LiMT2, 4294967295, 0.0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 2)
                FDuongList(lIPv1, 4294967295, "", 0, 0, mau3, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(lIPv2, 4294967295, "", 0, 0, mau4, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
            End If
        End If
        SLenhve3DMs()
    End Sub

    Public Sub KiemtraBatgiuApgiai()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQx As New List(Of Double)({74.67, 23.77, 85.89, 20.51, 107.97, 41.84, 195.64, 85.03, 328.0, 75.8, 368.88, 77.4, 377.24, 78.71, 227.87, 90.0, 377.24, 101.24, 368.88, 102.6, 328.0, 104.2, 195.84, 94.96, 107.97, 138.16, 85.85, 159.55, 74.68, 156.31, 162.14, 90.0})
        Dim TQ As New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51})
        Dim LiC As List(Of IPosition71) = ArDisAgreetoLiPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)
        FVungList(LiC, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        FVungList(ArDisAgreetoLiPoint(TQx, FrmMain.Instance.mPointClick, 3.0, Goc1), 4294967295, 0, mau, 0, mauXanh, 1, "", 0, 0, 0, False, 2, 3)
        Dim Pd As IPosition71 = CenterPoint(LiC(4), LiC(5))
        Dim MGoc As Double = FGoc(LiC(2), Pd)
        DemTau(FrmMain.Instance.mPointClick, Goc1)
        Dim Pmt1 As IPosition71
        If Lenhve = "TauBPkiemtra" Then
            Dim Ps As IPosition71 = LiC(2).Move(Dorongduong * 40, MGoc, 0)
            Dim Pst As IPosition71 = Ps.Move(Dorongduong * 8, 90 + MGoc, 0)
            Dim Psp As IPosition71 = Ps.Move(Dorongduong * 8, 270 + MGoc, 0)
            Dim LiF As New List(Of IPosition71) From {Pst, Psp}
            FDuongList(LiF, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            DemCau(Pst, Psp)
            Pmt1 = LiC(2).Move(Dorongduong * 13, MGoc, 0)
            Dim LiMT1 As List(Of IPosition71) = Muiten(Pmt1, LiC(2), MGoc, 0.65, 1.0)
            FVungList(LiMT1, 4294967295, 0.0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 6)
            PointHQ = Pmt1
            GocHQ = 270 + (MkGoc(Pmt1, LiC(2)) * 180 / Math.PI)
        ElseIf Lenhve = "TauBPbatgiu" Then
            Pmt1 = LiC(2).Move(Dorongduong * 17, MGoc, 0)
            PointHQ = Pmt1.Move(Dorongduong * 12, 180 + MGoc, 0)
            GocHQ = 270 + (MkGoc(Pmt1, LiC(2)) * 180 / Math.PI)
            Dim LiV As List(Of IPosition71) = LiPCircle(Pmt1, FKc(LiC(2), Pmt1), 0, 10)
            LiV.Add(LiV(0))
            Dim Mgeo As List(Of IPosition71) = GeoToList(ListtoGeo(LiV).SpatialOperator.buffer(-Dorongduong * 1.5))
            FDuongList(LiV, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 6) ' 2, False, 2)
            FDuongList(Mgeo, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 5) ' 2, False, 2)
        ElseIf Lenhve = "TauBPapgiai" Then
            Dim LiV As List(Of IPosition71) = MTCong(LiC(2), Goc1)
            PointHQ = LiV(10)
            GocHQ = 270 + (MkGoc(LiC(2), Pd) * 180 / Math.PI)
            FVungList(LiV, 4294967295, 0, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If
        '  FrmMain.Instance.sgworldMain.Creator.CreateLabel(Pmt1, "Pmt1", "", Nothing, "", "Pmt1")
        TauHaiquan()
        SLenhve3DMs()
    End Sub

    Function MTCong(P As IPosition71, Goc As Double) As List(Of IPosition71)
        Dim TQx As New List(Of Double)({3.22, 298.56, 1.5, 0.00, 2.87, 58.02, 4.97, 69.62, 7.38, 72.58, 12.04, 72.86, 14.25, 70.44, 16.65, 68.9, 18.78, 66.54, 16.64, 63.26, 26.65, 64.21, 19.3, 81.46, 19.96, 74.72, 17.58, 77.98, 15.17, 81.51, 12.72, 85.26, 10.27, 90.0, 7.79, 94.98, 5.34, 103.0, 2.99, 119.21, 1.5, 180.0, 3.22, 243.0})
        Dim LiC As List(Of IPosition71) = ArDisAgreetoLiPoint(TQx, P, 30.0, Goc)
        MTCong = LiC
    End Function

    Public Sub TuyenXamnhap()
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim Pc As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem ben phai
        Dim TQ1 As New List(Of Double)({1.5, 180.0, 4.96, 161.2, 17.96, 270.1, 5.02, 18.6, 1.5, 0.0})
        Dim TQ2 As New List(Of Double)({1.5, 0.0, 4.96, 341.2, 17.96, 90.1, 5.02, 198.6, 1.5, 180.0})
        Dim TQ3 As New List(Of Double)({1.5, 0.0, 3.23, 14.4})
        Dim TQ4 As New List(Of Double)({3.2, 345.5, 1.5, 0.0})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 32.0, -Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 32.0, -Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P2, 32.0, -Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P1, 32.0, -Goc1))
        FVungPoint(liP1.ToArray, 0, 9, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 10, 13, 4294967295, 0, mau2, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub
#End Region

#Region "    Congbinh"

    Public Sub HraoThuyloi()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(6), PllVts(7), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim KC As Double
        If Lenhve = "nhiemvutruocmat" Or Lenhve = "nhiemvutieptheo" Then
            KC = FKc(P1, P3) / 12
        Else
            KC = FKc(P1, P3) / 6
        End If
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
        Dim Pv As IPosition71 = Pc.Move(KC, GYaw, 0)

        Dim liGoc As New List(Of IPosition71) From {P1, Pv, P3}
        Dim LiCur As New List(Of IPosition71), LiD As New List(Of IPosition71)
        Dim LiC As New List(Of IPosition71)
        Dim LD1 As New List(Of IPosition71), LD2 As New List(Of IPosition71), LD3 As New List(Of IPosition71)
        Dim Pp As IPosition71, Pt As IPosition71
        If Lenhve = "HrNganthuyloi" Then
            LiCur = Curveline(liGoc, 6)
            Dim Geo1 As IGeometry = ListtoGeo(LiCur)
            Dim Geo2 As IGeometry = Geo1.SpatialOperator.buffer(Dorongduong * 1.5)
            LiD = GeoToList(Geo2)
            LiD.RemoveRange(0, 15)
            LiD.RemoveRange(24, 14)
            For i As Integer = 1 To LiCur.Count - 2
                If i Mod 2 = 0 Then
                    MCircleTQ(LiCur(i), Dorongduong * 6, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
                End If
            Next
            Pp = liGoc(0).Move(Dorongduong * 6, FGoc(liGoc(0), liGoc(1)) + 270, 0)
            Pt = liGoc(2).Move(Dorongduong * 6, FGoc(liGoc(2), liGoc(1)) + 90, 0)
            LiCur.Add(Pt)
            LiCur.Reverse()
            LiCur.Add(Pp)
        ElseIf Lenhve = "nhiemvutruocmat" Or Lenhve = "nhiemvutieptheo" Then
            LiCur = Curveline(liGoc, 12)
            Dim Geo1 As IGeometry = ListtoGeo(LiCur)
            Dim Geo2 As IGeometry = Geo1.SpatialOperator.buffer(Dorongduong * 1.5)
            Dim Geo3 As IGeometry = Geo1.SpatialOperator.buffer(Dorongduong * 4.0)
            LiD = GeoToList(Geo2)
            LiD.RemoveRange(0, 14)
            LiD.RemoveRange(48, 15)
            Dim lC1 As New List(Of IPosition71), lC2 As New List(Of IPosition71), lC3 As New List(Of IPosition71), lDi1 As New List(Of IPosition71), lDi2 As New List(Of IPosition71), lDi3 As New List(Of IPosition71)
            AddPointToList(lC1, LiD, 0, 14)
            AddPointToList(lC2, LiD, 16, 32)
            AddPointToList(lC3, LiD, 34, 47)
            '/////////
            AddPointToList(lDi1, LiCur, 0, 7)
            AddPointToList(lDi2, LiCur, 8, 16)
            AddPointToList(lDi3, LiCur, 17, 23)
            FDuongList(lC1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lC2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lC3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)

            FDuongList(lDi1, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lDi2, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lDi3, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)

            If Lenhve = "nhiemvutruocmat" Then
                Dim Mt As IPosition71 = LiD(24).Move(Dorongduong * 20, GYaw, 0)
                Dim LiMT As List(Of IPosition71) = Muiten(Mt, LiD(24), FGoc(Mt, LiD(24)), 1.0, 1.0)
                FVungList(LiMT, 4294967295, 0.0, mau2, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            ElseIf Lenhve = "nhiemvutieptheo" Then
                Dim LiC1 As List(Of IPosition71) = GeoToList(Geo3)
                LiC1.RemoveRange(0, 14)
                LiC1.RemoveRange(49, 16)
                Dim lM1 As New List(Of IPosition71), lM2 As New List(Of IPosition71), lM3 As New List(Of IPosition71)
                AddPointToList(lM1, LiC1, 0, 14)
                AddPointToList(lM2, LiC1, 16, 32)
                AddPointToList(lM3, LiC1, 34, 47)
                FDuongList(lM1, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(lM2, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                FDuongList(lM3, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
                Dim Mt As IPosition71 = LiC1(25).Move(Dorongduong * 20, GYaw, 0)
                Dim LiMT As List(Of IPosition71) = Muiten(Mt, LiC1(24), FGoc(Mt, LiC1(24)), 1.0, 1.0)
                FVungList(LiMT, 4294967295, 0.0, mau2, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            End If
        End If

        If Lenhve = "HrNganthuyloi" Then
            FDuongList(LiCur, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(LiD, 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 1) ' 2, False, 2)
        End If

        SLenhve3DMs()
    End Sub

    Public Function LiPtHangrao(pMHTimPSet() As Point3D, bk As Double) As List(Of IPosition71)
        Dim PtHangrao As New List(Of IPosition71), mpk As New List(Of IPosition71)
        Dim hr() As Point3D = NsHRKG(pMHTimPSet, bk, bk)
        For i As Integer = 1 To hr.Count - 1
            Dim pHR As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(hr(i).X, hr(i).Y, hr(i).Z * 120000, 2, 0, 0, 0, 0)
            PtHangrao.Add(pHR)
        Next
        LiPtHangrao = PtHangrao
    End Function

    Public Sub Phatuhanh()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({318.0, 73.56, 371.08, 75.96, 371.08, 104.04, 108.17, 146.31, 61.85, 104.04, 33.54, 116.57, 54.08, 146.31, 45.0, 180.0, 45.0, 0.0, 54.08, 33.69, 33.54, 63.43, 61.85, 75.96, 108.17, 33.69, 317.94, 73.56, 310.81, 78.87, 108.17, 56.31, 108.17, 123.69, 335.41, 100.3, 329.88, 92.61, 91.34, 99.45, 91.34, 80.55, 329.88, 87.39, 335.41, 79.7, 310.85, 78.87, 310.81, 78.87, 108.17, 56.31, 108.17, 123.69, 335.41, 100.3, 335.41, 79.7, 310.85, 78.87, 307.0, 96.55, 120.21, 106.93, 120.21, 73.07, 306.99, 83.45})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 24, 33, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Xeloinuocbanhxich()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({105.53, 31.48, 223.72, 66.28, 276.59, 77.47, 276.59, 102.67, 223.72, 113.72, 90.0, 180.0, 90.0, 0.0, 105.48, 31.43, 81.39, 42.51, 67.08, 26.57, 67.08, 153.43, 184.83, 108.94, 184.79, 71.09, 207.08, 73.19, 212.56, 74.48, 212.59, 105.55, 243.44, 99.64, 243.44, 80.36, 207.13, 73.16, 81.46, 42.56, 81.39, 42.51, 67.08, 26.57, 67.08, 153.43, 207.13, 105.55, 243.44, 99.64, 243.44, 80.36, 207.13, 73.16, 81.46, 42.56, 65.28, 57.58, 195.92, 79.71, 216.42, 83.43, 216.42, 96.57, 195.92, 100.29, 65.19, 122.47})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 19, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 20, 33, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Mindinhhuong()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({69.74, 270.0, 132.87, 53.19, 119.19, 43.2, 218.19, 60.93, 111.45, 71.85, 130.77, 63.32, 5.3, 270.0, 130.14, 116.69, 111.47, 108.18, 218.21, 119.08, 119.22, 136.82, 133.54, 126.75, 69.74, 0.0, 69.74, 15.0, 69.74, 30.0, 69.74, 45.0, 69.74, 60.0, 69.74, 75.0, 69.74, 90.0, 69.74, 105.0, 69.74, 120.0, 69.74, 135.0, 69.74, 150.0, 69.74, 165.0, 69.74, 180.0, 69.74, 195.0, 69.74, 210.0, 69.74, 225.0, 69.74, 240.0, 69.74, 255.0, 69.74, 270.0, 69.74, 285.0, 69.74, 300.0, 69.74, 315.0, 69.74, 330.0, 69.74, 345.0, 69.74, 359.9, 39.7, 359.9, 39.7, 340.0, 39.7, 320.0, 39.7, 300.0, 39.7, 280.0, 39.7, 260.0, 39.7, 240.0, 39.7, 220.0, 39.7, 200.0, 39.7, 180.0, 39.7, 160.0, 39.7, 140.0, 39.7, 120.0, 39.7, 100.0, 39.7, 80.0, 39.7, 60.0, 39.7, 40.0, 39.7, 20.0, 39.7, 0.0, 14.7, 0.0, 14.7, 30.0, 14.7, 60.0, 14.7, 90.0, 14.7, 120.0, 14.7, 150.0, 14.7, 180.0, 14.7, 210.0, 14.7, 240.0, 14.7, 270.0, 14.7, 300.0, 14.7, 330.0, 14.7, 359.9})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 37, 68, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 12, 55, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub MinChongtang()
        MCircleTQ(FrmMain.Instance.mPointClick, 120, 4294967295, Dorongduong * 0.8, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub MinBobinh()
        MCircleTQ(FrmMain.Instance.mPointClick, 120, 4294967295, Dorongduong * 0.8, mau, 1, mau2, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub OminChongtang()
        Dim k(130) As IPosition71
        Dim Goc1 As Double = 0
        Dim hesothuphong As Double = 20.0 * Tyle
        Dim P1 As IPosition71 = FrmMain.Instance.mPoint.Move(7.5 * hesothuphong, 150.0 + Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.mPoint.Move(7.5 * hesothuphong, 270.0 + Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.Instance.mPoint.Move(7.5 * hesothuphong, 30.0 + Goc1, 0)
        MCircleTQ(FrmMain.Instance.mPointClick, 360, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(FrmMain.Instance.mPointClick, 360 - Dorongduong / Tyle, 4294967295, Dorongduong * 0.9, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, 1)
        MCircleTQ(P1, Dorongduong / Tyle, 4294967295, Dorongduong, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(P2, Dorongduong / Tyle, 4294967295, Dorongduong, mau, 1, mau, 2, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(P3, Dorongduong / Tyle, 4294967295, Dorongduong, mau, 1, mau, 2, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

#End Region

#Region "    DacCong"

    Public Sub DoiDC()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Goc1 As Double
        If Lenhve = "emsan" Then
            Goc1 = Phuongvi * 180.0 / Math.PI
        Else
            Goc1 = 270 + Phuongvi * 180.0 / Math.PI
        End If
        Dim TQ1 As New List(Of Double)({105.9, 90.0, 110.91, 112.88, 124.74, 133.1, 144.96, 149.81, 169.33, 163.52, 197.19, 175.38, 209.07, 180.0, 197.19, 184.62, 169.33, 196.48, 144.96, 210.19, 124.74, 226.9, 110.91, 247.12, 105.9, 270.0, 110.91, 292.88, 124.74, 313.1, 144.96, 329.81, 169.33, 343.52, 197.19, 355.33, 209.07, 0.00, 297.76, 356.92, 291.04, 353.53, 428.26, 0.00, 291.0, 6.4, 297.76, 3.08, 197.19, 4.62, 169.33, 16.48, 144.96, 30.19, 124.74, 46.9, 110.91, 67.12, 105.9, 89.98, 76.17, 89.98, 81.86, 62.36, 97.87, 39.86, 120.06, 22.84, 145.69, 9.68, 169.67, 0.00, 145.69, 350.32, 120.06, 337.16, 97.87, 320.14, 81.86, 297.64, 75.79, 270.0, 81.86, 242.36, 97.87, 219.86, 120.06, 202.84, 145.69, 189.68, 169.67, 180.0, 145.69, 170.32, 120.06, 157.16, 97.87, 140.14, 81.86, 117.64, 75.79, 90.0})
        Dim TQ2 As New List(Of Double)({76.17, 89.98, 81.86, 62.36, 97.87, 39.86, 120.06, 22.84, 145.69, 9.68, 169.67, 0.00, 145.69, 350.32, 120.06, 337.16, 97.87, 320.14, 81.86, 297.64, 75.79, 270.0, 81.86, 242.36, 97.87, 219.86, 120.06, 202.84, 145.69, 189.68, 169.67, 180.0, 145.69, 170.32, 120.06, 157.16, 97.87, 140.14, 81.86, 117.64, 75.79, 90.0, 50.98, 90.0, 58.47, 125.18, 77.33, 149.64, 101.48, 165.92, 133.18, 180.0, 101.48, 194.08, 77.33, 210.36, 58.47, 234.82, 50.7, 270.0, 58.47, 305.18, 77.33, 329.64, 101.48, 345.92, 133.18, 0.00, 101.48, 14.08, 77.33, 30.36, 58.47, 54.82, 50.7, 89.97})
        Dim TQ3 As New List(Of Double)({141.92, 347.81, 110.72, 28.32, 97.83, 39.84, 88.04, 50.17, 122.11, 337.92, 103.93, 325.75, 76.65, 75.15, 75.79, 89.98, 75.85, 100.75, 88.66, 310.05, 82.54, 298.54, 78.23, 289.72, 83.57, 122.97, 97.36, 140.39, 75.39, 265.12, 81.19, 243.27, 82.54, 239.44, 113.76, 154.11, 118.68, 156.9, 132.44, 165.15, 100.96, 216.9, 97.63, 220.7, 82.15, 243.47, 76.81, 271.09, 83.49, 298.32, 99.86, 320.39, 122.19, 337.13})
        Dim Lic As List(Of IPosition71) = ArrayDoubleToListPoint(TQ1, FrmMain.Instance.mPointClick, 3.0, Goc1)
        Dim LiD As List(Of IPosition71) = ArrayDoubleToListPoint(TQ2, FrmMain.Instance.mPointClick, 3.0, Goc1)
        Dim LiG As List(Of IPosition71) = ArrayDoubleToListPoint(TQ3, FrmMain.Instance.mPointClick, 3.0, Goc1)
        Dim LiGach As List(Of IPosition71)
        If Lenhve = "DQTVcodong" Then
            LiGach = New List(Of IPosition71) From {Lic(5), Lic(7), Lic(17), Lic(24)}
            FVungList(LiGach, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If
        If Lenhve = "emsan" Then
            Lic.RemoveRange(19, 5)
        Else
            Lic.RemoveRange(18, 1)
        End If
        ' FVungList(Lic, 4294967295, 0, mau, 0, mau3, 1, "", 0, 0, 0, False, 2, 6, "")
        If Lenhve = "doidaccongnuoc" Then
            Dim Gei1 As IGeometry = ListtoGeo(Lic).SpatialOperator.Union(ListtoGeo(LiG))
            Lic.Clear()
            Lic = GeoToList(Gei1)
        ElseIf Lenhve = "toanTSDN" Then
            Lic.RemoveRange(38, 11)
            Lic.RemoveRange(2, 9)
            LiD.RemoveRange(23, 5)
            LiD.RemoveRange(12, 7)
        ElseIf Lenhve = "doiTShonhop" Or Lenhve = "luonsau" Then
            Dim LiG1 As New List(Of IPosition71)
            AddPointToList(LiG1, LiG, 5, 14)
            AddPointToList(LiG1, LiG, 23, 25)
            Dim Gei1 As IGeometry = ListtoGeo(Lic).SpatialOperator.Union(ListtoGeo(LiG1))
            Lic.Clear()
            Lic = GeoToList(Gei1)
        ElseIf Lenhve = "doidaccongTC" Then
            Dim GeoTC As IGeometry = DcongTC(FrmMain.Instance.mPointClick, Goc1)
            Dim Gei1 As IGeometry = ListtoGeo(Lic).SpatialOperator.Union(GeoTC)
            Lic.Clear()
            Lic = GeoToList(Gei1)
        ElseIf Lenhve = "DChoatrang" Then
            Dim TQHt As New List(Of Double)({76.85, 254.34, 76.85, 105.67, 81.8, 117.64, 85.72, 126.29, 85.77, 233.73, 97.87, 219.86, 100.7, 216.7, 100.66, 143.33, 120.1, 157.23, 120.21, 202.9, 100.88, 223, 85.64, 247.58})
            Dim LiHT As List(Of IPosition71) = ArrayDoubleToListPoint(TQHt, FrmMain.Instance.mPointClick, 3.0, Goc1)
            Dim Gei1 As IGeometry = ListtoGeo(Lic).SpatialOperator.Union(ListtoGeo(LiHT))
            Lic.Clear()
            Lic = GeoToList(Gei1)
        ElseIf Lenhve = "emsan" Then
            Dim LiMT As List(Of IPosition71) = Muiten(Lic(25), Lic(12), 180 + FGoc(Lic(12), Lic(25)), 0.4, 1.0)
            FVungList(LiMT, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "coiDKZlui" Then
            Dim PCoi As IPosition71 = FrmMain.Instance.mPointClick.Move(-Dorongduong * 3.5, 180 - Goc1, 0)
            Dim Pdkz As IPosition71 = FrmMain.Instance.mPointClick.Move(-Dorongduong * 0.8, 180 - Goc1, 0)
            Dim TQDKZ As New List(Of Double)({1.27, 322.05, 1.26, 217.95, 5.71, 259.91, 6.37, 241.9, 8.19, 248.51, 7.68, 262.52, 9.36, 263.87, 11.62, 255.04, 14.32, 257.91, 11.12, 270.0, 14.32, 282.09, 11.75, 284.8, 9.33, 276.15, 7.68, 277.48, 8.19, 291.49, 6.37, 298.1, 5.71, 280.09})
            Dim Lidkx As List(Of IPosition71) = ArrayDoubleToListPoint(TQDKZ, Pdkz, 25.0, Goc1 + 90)
            FVungList(Lidkx, 4294967295, 0, mau, 0, mauChu, 1, "", 0, 0, 0, False, 2, 2)
            CoiLui(PCoi, Goc1 + 90, mauChu, 30.0)
        ElseIf Lenhve = "KhacphucHauquaBLLD" Then
            Dim LiO As New List(Of IPosition71)
            AddPointToList(LiO, Lic, 29, 49)
            FVungList(LiO, 4294967295, 0, mau, 0, mauHH, 1, "", 0, 0, 0, False, 2, 0)
        End If

        FVungList(Lic, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        FVungList(LiD, 4294967295, 0, mau2, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)

        If Lenhve = "doicongtacBP" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "BP", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "doidaccong" Or Lenhve = "doidaccongnuoc" Or Lenhve = "DChoatrang" Or Lenhve = "doidaccongTC" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "ĐC", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "doihoahoc" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "HH", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "KhacphucHauquaBLLD" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "kp/A2", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "doicongbinh" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "CB", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "doiTShonhop" Or Lenhve = "toanTSDN" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "TS", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "DoiCtCoso" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "XDCS", "", mauChu, 0, 0, 2, 2)
        ElseIf Lenhve = "DQTVcodong" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "bDQ", "", mauChu, 0, 0, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub MuiDC()
        Dim k(110) As IPosition71
        Dim Goc1 As Double = 270 + Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({134.16, 231.5, 147.83, 314.74, 165.86, 322.3, 181.06, 329.85, 193.15, 337.39, 201.94, 344.93, 207.28, 352.47, 207.58, 355.58, 297.76, 356.92, 291.04, 353.53, 428.26, 0.00, 291.0, 6.4, 297.76, 3.08, 207.58, 4.42, 207.28, 7.53, 201.94, 15.07, 193.15, 22.61, 181.06, 30.15, 165.86, 37.7, 147.83, 45.26, 179.45, 144.19, 146.3, 174.12, 173.39, 175.04, 173.39, 184.96, 146.3, 185.88, 179.45, 215.81, 134.19, 231.49, 112.28, 221.91, 137.71, 213.0, 137.74, 147.01, 126.69, 36.3, 142.98, 30.33, 155.54, 24.59, 165.58, 18.61, 172.88, 12.48, 177.32, 6.26, 178.81, 0.00, 177.32, 353.74, 172.88, 347.52, 165.58, 341.39, 155.54, 335.41, 142.98, 329.67, 126.69, 323.7, 112.24, 221.93, 97.33, 210.91, 112.22, 333.54, 135.78, 341.59, 149.03, 350.44, 153.59, 0.00, 149.03, 9.56, 135.78, 18.41, 112.22, 26.46, 97.38, 149.1, 177.25, 174.94, 201.17, 169.45, 214.46, 174.32, 231.98, 170.86, 250.74, 176.43, 234.62, 180.0, 250.74, 183.57, 231.98, 189.14, 214.46, 185.68, 201.17, 190.55, 177.82, 184.84, 192.19, 180})
        Dim LiTong As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)
        Dim LiC As New List(Of IPosition71), LiD, LiDc, LiMT As New List(Of IPosition71)
        If Lenhve = "muidaccongcodong" Then
            AddPointToList(LiDc, LiTong, 53, 64)
            FVungList(LiDc, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If
        LiC = AddPointToList(LiC, LiTong, 0, 43)
        LiD = AddPointToList(LiD, LiTong, 27, 52)
        If Lenhve = "muidaccongnuoc" Or Lenhve = "muidaccong" Or Lenhve = "muidaccongTC" Then
            LiC.RemoveRange(21, 4)
        End If
        If Lenhve = "muidaccongnuoc" Or Lenhve = "muidaccongTC" Then
            Dim GeoTC, Geo As IGeometry
            If Lenhve = "muidaccongTC" Then
                GeoTC = DcongTC(FrmMain.Instance.mPointClick, Goc1)
            Else
                Dim Gach As New List(Of Double)({164.01, 147.4, 130.91, 42.45, 169.13, 344.68, 165.53, 341.39, 154.48, 335.01, 105.16, 50.76, 87.87, 67.96, 132.99, 326.28, 126.66, 323.72, 107.95, 316.0, 81.5, 90.4, 88.3, 112.71, 86.96, 300.47, 75.69, 278.01, 105.87, 129.71, 129.89, 141.17, 78.41, 252.91, 93.84, 233.0})
                Dim LiGach As List(Of IPosition71) = ArrayDoubleToListPoint(Gach, FrmMain.Instance.mPointClick, 3.0, Goc1)
                GeoTC = ListtoGeo(LiGach)
            End If
            Geo = ListtoGeo(LiC).SpatialOperator.Union(GeoTC)
            LiC.Clear()
            LiC = GeoToList(Geo)
        End If
        FVungList(LiC, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        FVungList(LiD, 4294967295, 0, mau2, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)
        MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(LiC(1), LiC(0)), "ĐC", "", mauChu, 0, 0, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub DaccongTC()
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Goc1 As Double = 270 + Phuongvi * 180.0 / Math.PI
        Dim TQ As List(Of Double)
        '({140.76, 48.24, 158.75, 138.59, 209.07, 180.0, 158.75, 221.41, 158.75, 318.59, 209.07, 0.00, 158.75, 41.41, 140.78, 48.23, 120.07, 38.65, 129.25, 35.47, 169.55, 0.00, 129.25, 324.53, 129.25, 215.47, 169.55, 180.0, 129.25, 144.53, 120.06, 38.66, 106.24, 28.07, 106.27, 151.93, 136.63, 180.0, 106.27, 208.07, 106.27, 331.93, 136.63, 0.00, 106.27, 28.07, 196.01, 355.32, 297.76, 356.92, 291.04, 353.53, 428.26, 0.00, 291.0, 6.4, 297.76, 3.08, 196.01, 4.68})

        If Lenhve = "DCTCbangTauNN" Or Lenhve = "DCTCbangTauDS" Or Lenhve = "xuongBBDL10" Or Lenhve = "XuongDemkhi" Then
            TQ = New List(Of Double)({140.76, 48.24, 158.75, 138.59, 209.07, 180.0, 158.75, 221.41, 158.75, 318.59, 209.07, 0.00, 158.75, 41.41, 140.78, 48.23, 120.07, 38.65, 129.25, 35.47, 169.55, 0.00, 129.25, 324.53, 129.25, 215.47, 169.55, 180.0, 129.25, 144.53, 120.06, 38.66, 106.24, 28.07, 106.27, 151.93, 136.63, 180.0, 106.27, 208.07, 106.27, 331.93, 136.63, 0.00, 106.27, 28.07, 196.01, 355.32, 297.76, 356.92, 291.04, 353.53, 428.26, 0.00, 291.0, 6.4, 297.76, 3.08, 196.01, 4.68})
        Else
            TQ = New List(Of Double)({187.74, 34.86, 227.68, 151.88, 154.43, 221.68, 157.23, 319.22, 175.84, 312.62, 197.39, 319.04, 181.01, 325.44, 206.42, 330.17, 237.55, 318.92, 260.91, 323.25, 209.51, 356.25, 297.64, 357.36, 290.79, 353.98, 428.27, 0.00, 291.27, 6.85, 297.89, 3.52, 209.87, 5.01, 235.0, 27.17, 187.76, 34.86, 172.38, 26.65, 195.04, 23.35, 193.26, 337.91, 119.75, 217.37, 174.29, 153.67, 172.36, 26.65, 162.7, 18.76, 130.03, 156.28, 91.72, 211.33, 161.28, 342.8})
        End If
        Dim LiTong As List(Of IPosition71) = ArrayDoubleToListPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)
        Dim LiC As New List(Of IPosition71), LiD, LiMT As New List(Of IPosition71)
        If Lenhve = "DCTCbangTauNN" Or Lenhve = "DCTCbangTauDS" Or Lenhve = "xuongBBDL10" Or Lenhve = "XuongDemkhi" Then
            LiC = AddPointToList(LiC, LiTong, 0, 15)
            LiD = AddPointToList(LiD, LiTong, 8, 22)
            LiMT = AddPointToList(LiMT, LiTong, 23, 29)
        Else
            LiC = AddPointToList(LiC, LiTong, 0, 25)
            LiD = AddPointToList(LiD, LiTong, 19, 28)
        End If

        Dim GeoTC As IGeometry = DcongTC(FrmMain.Instance.mPointClick, Goc1)
        If Lenhve = "DCTCbangTauNN" Then
            Dim Geo As IGeometry = ListtoGeo(LiMT).SpatialOperator.Union(GeoTC)
            FVungList(GeoToList(Geo), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
            Dim TGi As New List(Of Double)({120.77, 47.02, 148.14, 143.39, 149.65, 156.89, 103.17, 226.58, 83.69, 243.57, 141.29, 144.8, 115.51, 135.16, 75.03, 267.16, 80.66, 291.7, 94.73, 120.71, 82.78, 100.32, 98.14, 310.21, 122.5, 322.28, 83.57, 77.06, 96.76, 57.32, 133.63, 335.05, 145.82, 347.46})
            Dim LiGi As List(Of IPosition71) = ArrayDoubleToListPoint(TGi, FrmMain.Instance.mPointClick, 3.0, Goc1)
            Dim GeoG As IGeometry = ListtoGeo(LiGi).SpatialOperator.Union(ListtoGeo(LiC))
            LiC.Clear()
            LiC = GeoToList(GeoG)
        ElseIf Lenhve = "DCTCbangTauDS" Then
            Dim Geo As IGeometry = ListtoGeo(LiMT).SpatialOperator.Union(GeoTC)
            FVungList(GeoToList(Geo), 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1)
        ElseIf Lenhve = "xuongBBDL10" Or Lenhve = "XuongDemkhi" Then
            Dim Pc As IPosition71 = CenterPoint(LiC(2), LiC(5))
            Dim Gock As Double = FGoc(LiC(2), LiC(5))
            Dim Kc As Double
            If Lenhve = "xuongBBDL10" Then
                Kc = Dorongduong * 4
            Else
                Kc = Dorongduong * 2.5
            End If
            Dim Pk1 As IPosition71 = Pc.Move(Kc, 90 + Gock, 0)
            Dim Pk2 As IPosition71 = Pc.Move(Kc, 270 + Gock, 0)
            If Lenhve = "xuongBBDL10" Then
                Dim LiN As New List(Of IPosition71) From {Pk1, Pk2}
                FDuongList(LiN, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 4)
            Else
                MCircleTQ(Pk1, Dorongduong * 2.8, 4294967295, Dorongduong * 1.5, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 3)
                MCircleTQ(Pk2, Dorongduong * 2.8, 4294967295, Dorongduong * 1.5, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 3)
            End If
            '  FVungList(LiC, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 1, "")
        Else
            Dim Geo As IGeometry = ListtoGeo(LiC).SpatialOperator.Union(GeoTC)
            LiC.Clear()
            LiC = GeoToList(Geo)
        End If

        If Lenhve = "DCTCbangTauNN" Then
            FVungList(LiC, 4294967295, 0, mau, 0, mauXanh, 1, "", 0, 0, 0, False, 2, 2)
        Else
            FVungList(LiC, 4294967295, 0, mau, 0, mau, 1, "", 0, 0, 0, False, 2, 2)
        End If
        FVungList(LiD, 4294967295, 0, mau, 0, mau2, 1, "", 0, 0, 0, False, 2, 1)

        If Not Lenhve = "xuongBBDL10" And Not Lenhve = "XuongDemkhi" Then
            MakeText(FrmMain.Instance.mPointClick, 0, FrmMain.Instance.fLabelStyleMain.Scale, FGoc(P1, P2), "ĐC", "", mauChu, 0, 0, 2, 2)
        End If
        SLenhve3DMs()
    End Sub

    Function DcongTC(P As IPosition71, Goc1 As Double) As IGeometry
        Dim DcTC As New List(Of Double)({240.11, 334.86, 249.49, 337.18, 256.61, 341.28, 261.33, 344.73, 263.56, 348.25, 263.26, 351.78, 260.87, 7.45, 263.53, 10.96, 268.1, 14.18, 273.92, 16.93, 281.54, 19.58, 285.7, 20.75, 273.67, 20.34, 254.89, 18.67, 242.19, 16.32, 232.59, 13.15, 226.98, 9.34, 228.49, 351.29, 231.46, 347.3, 234.42, 343.52, 236.61, 340.1, 239.01, 336.52})
        Dim LiTC As List(Of IPosition71) = ArrayDoubleToListPoint(DcTC, P, 3.0, Goc1)
        Dim GeoTC As IGeometry = ListtoGeo(LiTC)
        DcongTC = GeoTC
    End Function

    Public Sub TrSbatTB() 'good                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       /Public Sub subLuonsau()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim P1 As IPosition71 = FrmMain.Instance.mPoint.Move(2.74 * 45.0 * Tyle, 90.0 - Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.Instance.mPoint.Move(16.71 * 45.0 * Tyle, 90.0 - Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.Instance.mPoint.Move(12.41 * 45.0 * Tyle, 90.0 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({5.24, 165.5, 9.78, 112.5, 10.05, 158.0, 8.5, 150.0, 8.5, 165.0, 8.5, 180.0, 8.5, 195.0, 8.5, 210.0, 8.5, 225.0, 8.5, 240.0, 8.5, 255.0, 8.5, 270.0, 8.5, 285.0, 8.5, 300.0, 8.5, 315.0, 8.5, 330.0, 8.5, 345.0, 8.5, 0.0, 8.5, 15.0, 8.5, 30.0, 10.05, 22.0, 9.78, 69.9, 5.24, 14.5, 6.48, 30.0, 6.48, 15.0, 6.48, 0.0, 6.48, 345.0, 6.48, 330.0, 6.48, 315.0, 6.48, 300.0, 6.48, 285.0, 6.48, 270.0, 6.48, 255.0, 6.48, 240.0, 6.48, 225.0, 6.48, 210.0, 6.48, 195.0, 6.48, 180.0, 6.48, 165.0, 6.48, 150.0, 6.48, 30.0, 6.48, 15.0, 6.48, 0.0, 6.48, 345.0, 6.48, 330.0, 6.48, 315.0, 6.48, 300.0, 6.48, 285.0, 6.48, 270.0, 6.48, 255.0, 6.48, 240.0, 6.48, 225.0, 6.48, 210.0, 6.48, 195.0, 6.48, 180.0, 6.48, 165.0, 6.48, 150.0, 5.24, 165.5, 5.27, 180.0, 5.27, 195.0, 5.27, 210.0, 5.27, 225.0, 5.27, 240.0, 5.27, 255.0, 5.27, 270.0, 5.27, 285.0, 5.27, 300.0, 5.27, 315.0, 5.27, 330.0, 5.27, 345.0, 5.27, 0.0, 5.24, 14.5})
        Dim TQ2 As New List(Of Double)({5.47, 330.0, 5.47, 345.0, 5.47, 0.0, 5.47, 15.0, 5.47, 30.0, 5.47, 45.0, 5.47, 60.0, 5.47, 75.0, 5.47, 90.0, 5.47, 105.0, 5.47, 120.0, 5.47, 135.0, 5.47, 150.0, 5.47, 165.0, 5.47, 180.0, 5.47, 195.0, 5.47, 210.0, 3.46, 210.0, 3.46, 195.0, 3.46, 180.0, 3.46, 165.0, 3.46, 150.0, 3.46, 135.0, 3.46, 120.0, 3.46, 105.0, 3.46, 90.0, 3.46, 75.0, 3.46, 60.0, 3.46, 45.0, 3.46, 30.0, 3.46, 15.0, 3.46, 0.0, 3.46, 345.0, 3.46, 330.0})
        Dim TQ3 As New List(Of Double)({1.5, 0, 1.5, 30, 1.5, 60, 1.5, 90, 1.5, 120, 1.5, 150, 1.5, 180, 1.5, 210, 1.5, 240, 1.5, 270, 1.5, 300, 1.5, 330})
        Dim TQ4 As New List(Of Double)({7.48, 300.9, 7.59, 316.2, 2.49, 90, 7.46, 223.6, 7.34, 239.1, 0.97, 270})
        Dim TQ5 As New List(Of Double)({0.0, 0.0, 7.83, 74.9, 6.57, 83.9, 20.97, 85.9, 20.97, 94.2, 6.57, 96.1, 7.83, 105.1})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 45.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 45.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P3, 45.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P2, 45.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ5, P2, 45.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 39, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 40, 71, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(liP1.ToArray, 72, 105, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        If Lenhve = "TSTKbatTB" Then
            FVungPoint(liP1.ToArray, 106, 117, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(liP1.ToArray, 118, 123, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "TSPKbatTB" Then
            FVungPoint(liP1.ToArray, 124, 130, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(liP1.ToArray, 106, 117, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        End If

        SLenhve3DMs()
    End Sub

#End Region

    '#Region "    Dubidongvien"

    '    'Public Sub XeCuuhoa()
    '    '    Dim Goc1 As Double = Phuongvi * 180 / Math.PI
    '    '    Dim P1 As IPosition71 = FrmMain.Instance.mPoint.Move(110.0 * Tyle * 2.5, 90.0 - Goc1, 0)
    '    '    Dim TQ As New List(Of Double)({0.01, 0.0, 100.0, 0.0, 228.43, 64.0, 249.2, 67.5, 266.92, 71.5, 281.15, 75.8, 291.55, 80.4, 297.88, 85.2, 300.0, 90.0, 297.88, 94.8, 291.55, 99.6, 281.15, 104.2, 266.92, 108.5, 249.2, 112.5, 228.43, 116.0, 100.0, 180.0, 0.0, 180.0, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 214.37, 109.04, 186.27, 112.05, 186.3, 67.93, 76.16, 23.2, 30.0, 89.99, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 76.16, 23.2, 30.0, 89.99, 55.0, 89.99, 71.06, 50.7, 205.36, 77.3, 226.8, 80.4, 239.95, 84.8, 244.56, 90.0, 239.95, 95.2, 226.8, 99.6, 207.49, 102.7, 71.06, 129.3, 55.0, 90.0})
    '    '    Dim TQ1 As New List(Of Double)({25, 0, 25, -30, 25, -60, 25, -90, 25, -120, 25, -150, 25, -180, 25, -210, 25, -240, 25, -270, 25, -300, 25, -330})
    '    '    FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 0, 36, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "")
    '    '    FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 2.5, Goc1), 37, 64, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2, "")
    '    '    FVungPoint(ArrayPoint(TQ1, P1, 2.5, Goc1), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "")
    '    '    SLenhve3DMs()
    '    'End Sub

    '    'Public Sub TauChuachay()
    '    '    Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
    '    '    Dim P1 As IPosition71 = FrmMain.Instance.mPoint.Move(173.3 * Tyle * 3.0, 90.0 - Goc1, 0)
    '    '    Dim P2 As IPosition71 = FrmMain.Instance.mPoint.Move(346.4 * Tyle * 3.0, 90.0 - Goc1, 0)
    '    '    Dim P3 As IPosition71 = FrmMain.Instance.mPoint.Move(259.85 * Tyle * 3.0, 90.0 - Goc1, 0)
    '    '    Dim TQ1 As New List(Of Double)({100.25, 45.75, 149.34, 50.15, 197.73, 54.58, 244.94, 59.01, 290.69, 63.43, 334.7, 67.86, 376.72, 72.29, 416.49, 76.72, 453.77, 81.14, 488.34, 85.57, 520.0, 90.0, 488.34, 94.43, 453.77, 98.86, 416.49, 103.28, 376.72, 107.71, 334.7, 112.14, 290.69, 116.57, 244.94, 120.99, 197.73, 125.42, 149.34, 129.85, 100.06, 134.28, 50.18, 138.7, 0.0, 0.0, 50.18, 41.3, 100.06, 45.72, 99.95, 63.03, 56.48, 73.38, 39.93, 90.0, 56.48, 106.62, 99.95, 116.97, 145.41, 118.23, 190.74, 116.78, 235.26, 114.19, 278.54, 111.02, 320.25, 107.52, 360.12, 103.81, 397.88, 99.95, 433.3, 96.01, 466.16, 91.99, 480.07, 90.0, 466.16, 88.01, 433.3, 83.99, 397.88, 80.05, 360.12, 76.19, 320.25, 72.48, 278.54, 68.98, 235.26, 65.81, 190.74, 63.22, 145.41, 61.77, 100.15, 63.02, 106.75, 73.43, 146.83, 71.6, 188.43, 70.77, 229.9, 71.85, 270.56, 73.94, 309.93, 76.64, 347.67, 79.72, 383.49, 83.06, 417.13, 86.58, 446.22, 90.0, 417.13, 93.42, 383.49, 96.94, 347.67, 100.28, 309.93, 103.36, 270.56, 106.06, 229.9, 108.15, 188.43, 109.23, 146.83, 108.4, 106.56, 103.51, 73.78, 90.0, 106.56, 73.47})
    '    '    FVungPoint(ArrayPoint(TQ1, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 49, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2, "")
    '    '    FVungPoint(ArrayPoint(TQ1, FrmMain.Instance.mPointClick, 3.0, Goc1), 25, 70, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1, "")
    '    '    MCircleTQ(P1, 50, 4294967295, Dorongduong * 1.2, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
    '    '    MCircleTQ(P2, 50, 4294967295, Dorongduong * 1.2, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
    '    '    MCircleTQ(P3, 50, 4294967295, Dorongduong * 1.2, mau, 1, mau, 1, "", 0, 0, 0, False, 2, 2)
    '    '    SLenhve3DMs()
    '    'End Sub

    '#End Region

#Region "    Hoahoc"

    Public Sub RauHinhV(P1 As IPosition71, Goc As Double, HesoDorong As Double, Vek As Integer)
        Dim TQ As New List(Of Double)({250.0, 26.57, 0.00, 0, 250.0, 333.43, 456.24, 14.18, 218.72, 0, 456.72, 345.81})
        Dim LiP As List(Of IPosition71), LiN1, LiN2 As New List(Of IPosition71)
        LiP = ArDisAgreetoLiPoint(TQ, P1, 1.2, 180 + Goc)
        AddPointToList(LiN1, LiP, 0, 2)
        FDuongList(LiN1, 4294967295, "", 0, 0, mau, Dorongduong * HesoDorong, False, 2, 0, 4)
        If Vek = 0 Then
            AddPointToList(LiN2, LiP, 3, 5)
            FDuongList(LiN2, 4294967295, "", 0, 0, mau, Dorongduong * HesoDorong, False, 2, 0, 4)
        End If
    End Sub

    Function AddPointKhusotan(M1 As IPosition71, M2 As IPosition71) As List(Of IPosition71)
        Dim S1 As IPosition71 = M1.Move(FKc(M1, M2) / 2, FGoc(M2, M1), 0)
        Dim S2 As IPosition71 = M1.Move(1 / 4 * FKc(M1, M2), FGoc(M2, M1), 0)
        Dim S3 As IPosition71 = M1.Move(3 / 4 * FKc(M1, M2), FGoc(M2, M1), 0)
        Dim LiS As New List(Of IPosition71) From {S1, S2, S3}
        AddPointKhusotan = LiS
    End Function

    Function AddPoinMuctieuBLLD(K1 As IPosition71, K2 As IPosition71) As List(Of IPosition71)
        Dim S1 As IPosition71 = K1.Move(1 / 5 * FKc(K1, K2), FGoc(K2, K1), 0)
        Dim S2 As IPosition71 = K1.Move(2 / 5 * FKc(K1, K2), FGoc(K2, K1), 0)
        Dim S3 As IPosition71 = K1.Move(3 / 5 * FKc(K1, K2), FGoc(K2, K1), 0)
        Dim S4 As IPosition71 = K1.Move(4 / 5 * FKc(K1, K2), FGoc(K2, K1), 0)
        Dim S5 As IPosition71 = K1.Move(1 / 5 * FKc(K1, K2), FGoc(K2, K1) + 90, 0)
        Dim S6 As IPosition71 = K1.Move(2 / 5 * FKc(K1, K2), FGoc(K2, K1) + 90, 0)
        Dim LiS As List(Of IPosition71) 'From {S5, K1, S1, S2, S3, S4, K2}
        If Lenhve = "luoinguytrang" Or Lenhve = "tamnguytrang" Then
            LiS = New List(Of IPosition71) From {S1, S2, S3, S4, S5, S6}
        Else
            LiS = New List(Of IPosition71) From {S5, K1, S1, S2, S3, S4, K2}
        End If
        AddPoinMuctieuBLLD = LiS
    End Function

    Public Sub MinHH(P As IPosition71, Goc As Double, cMau As IColor71)
        Dim TQ As New List(Of Double)({150.0, 0.02, 150.0, 15.0, 150.0, 30.0, 150.0, 45.0, 150.0, 60.0, 150.0, 75.0, 150.0, 90.0, 150.0, 105.0, 150.0, 120.0, 150.0, 135.0, 150.0, 150.0, 150.0, 165.0, 150.0, 180.0, 276.0, 216.905, 229.19, 224.107, 150.0, 210.0, 150.0, 225.0, 150.0, 240.0, 150.0, 255.0, 150.0, 270.0, 150.0, 285.0, 150.0, 300.0, 150.0, 315.0, 150.0, 330.0, 229.19, 315.893, 276.33, 323.095, 150.0, 0.0, 74.35, 0.0, 74.35, 330.0, 74.35, 315.0, 74.35, 300.0, 74.35, 285.0, 74.35, 270.0, 74.35, 255.0, 74.35, 240.0, 74.35, 225.0, 74.35, 210.0, 74.35, 195.0, 74.35, 180.0, 74.35, 165.0, 74.35, 150.0, 74.35, 135.0, 74.35, 120.0, 74.35, 105.0, 74.35, 90.0, 74.35, 75.0, 74.35, 60.0, 74.35, 45.0, 74.35, 30.0, 74.35, 15.0, 74.35, 0.02, 23.92, 0.02, 23.92, 30.0, 23.92, 60.0, 23.92, 90.0, 23.92, 120.0, 23.92, 150.0, 23.92, 180.0, 23.92, 210.0, 23.92, 240.0, 23.92, 270.0, 23.92, 300.0, 23.92, 330.0, 23.92, 0.0})
        FVungPoint(ArrayPoint(TQ, P, 1.25, Goc), 0, 50, 4294967295, 0, cMau, 0, cMau, 1, "", 1, 1, 0, False, 2, 3)
    End Sub

    Public Sub KVTapkichHHbangPhao()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({81.0, 0.0, 317.72, 56.76, 303.48, 52.78, 401.52, 61.25, 291.66, 63.64, 313.84, 60.94, 117.4, 46.37, 281.89, 73.3, 270.0, 89.98, 240.0, 89.98, 245.36, 78.0, 59.17, 30.47, 59.17, 149.53, 245.36, 102.0, 240.0, 90.0, 270.0, 90.0, 281.89, 106.7, 117.38, 133.64, 313.2, 119.08, 291.67, 116.37, 401.53, 118.76, 303.49, 127.23, 318.36, 123.22, 81.0, 180.0, 240.0, 89.98, 245.36, 78.0, 59.17, 30.47, 59.17, 149.53, 245.36, 102.0, 240.0, 90.0, 215.0, 90.0, 216.57, 96.9, 60.84, 115.3, 60.84, 64.7, 216.57, 83.1, 215.0, 89.97})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 24, 35, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 30, 35, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(255, 255, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KVTapkichHHbangCoi()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.0, 328.52, 53.98, 315.33, 50.03, 411.0, 58.93, 300.58, 60.39, 323.5, 58.0, 131.23, 40.36, 223.61, 63.43, 200.0, 89.98, 170.0, 89.98, 183.85, 67.62, 76.16, 23.2, 76.16, 156.8, 183.85, 112.38, 170.0, 90.0, 200.0, 90.0, 223.16, 116.57, 131.21, 139.65, 322.86, 122.03, 300.59, 119.62, 411.01, 121.08, 315.35, 129.98, 329.15, 125.99, 100.0, 180.0, 170.0, 89.98, 183.85, 67.62, 76.16, 23.2, 76.16, 156.8, 183.85, 112.38, 170.0, 90.0, 145.0, 90.0, 151.82, 107.24, 71.06, 129.29, 71.06, 50.71, 151.82, 72.76, 145.0, 89.99})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 24, 35, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 30, 35, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KVTapkichHHbangTL()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 90.0, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 152.42, 212.27, 128.87, 188.65, 125.86, 299.42, 125.57, 211.74, 141.02, 221.53, 134.54, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 212.03, 44.25, 203.37, 37.53, 289.92, 53.9, 179.17, 53.25, 203.59, 50.26, 100.0, 27.39, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 100.0, 89.94, 69.74, 89.94, 69.74, 75.0, 69.74, 60.0, 69.74, 45.0, 69.74, 30.0, 69.74, 15.0, 69.74, 0.0, 69.74, 345.0, 69.74, 330.0, 69.74, 315.0, 69.74, 300.0, 69.74, 285.0, 69.74, 270.0, 69.74, 255.0, 69.74, 240.0, 69.74, 225.0, 69.74, 210.0, 69.74, 195.0, 69.74, 180.0, 69.74, 165.0, 69.74, 150.0, 69.74, 135.0, 69.74, 120.0, 69.74, 105.0, 69.74, 90.0, 44.53, 90.0, 44.53, 105.0, 44.53, 120.0, 44.53, 135.0, 44.53, 150.0, 44.53, 165.0, 44.53, 180.0, 44.53, 195.0, 44.53, 210.0, 44.53, 225.0, 44.53, 240.0, 44.53, 255.0, 44.53, 270.0, 44.53, 285.0, 44.53, 300.0, 44.53, 315.0, 44.53, 330.0, 44.53, 345.0, 44.53, 0.0, 44.53, 15.0, 44.53, 30.0, 44.53, 45.0, 44.53, 60.0, 44.53, 75.0, 44.53, 89.94})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 59, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 34, 84, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 60, 84, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KVTapkichHHbangMB()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({68.49, 90.0, 74.81, 117.84, 89.86, 138.7, 107.04, 153.1, 122.61, 164.53, 235.81, 135.5, 211.07, 133.59, 321.04, 130.65, 239.96, 146.29, 247.34, 140.33, 135.0, 180.0, 131.6, 187.74, 121.82, 196.32, 107.04, 206.9, 89.86, 221.3, 74.81, 242.16, 68.49, 270.0, 74.81, 297.84, 89.86, 318.7, 107.04, 333.1, 121.82, 343.68, 131.6, 352.26, 135.0, 0.0, 238.35, 38.37, 232.11, 32.26, 311.83, 48.69, 202.07, 45.27, 227.56, 43.47, 122.72, 15.35, 107.04, 26.9, 89.86, 41.3, 74.81, 62.16, 68.48, 89.94, 43.43, 89.94, 47.44, 62.16, 58.62, 41.3, 73.49, 26.9, 90.24, 15.35, 102.28, 7.74, 109.17, 0.0, 102.28, 352.26, 89.09, 343.68, 73.49, 333.1, 58.62, 318.7, 47.44, 297.84, 43.43, 270.0, 47.44, 242.16, 58.62, 221.3, 73.49, 206.9, 89.09, 196.32, 102.28, 187.74, 109.17, 180.0, 102.28, 172.26, 90.24, 164.53, 73.49, 153.1, 58.62, 138.7, 47.44, 117.84, 43.43, 90.0, 23.38, 90.0, 25.55, 117.84, 32.93, 138.7, 43.0, 153.1, 58.11, 164.53, 71.67, 172.26, 86.39, 180.0, 71.67, 187.74, 56.93, 196.32, 43.0, 206.9, 32.93, 221.3, 25.55, 242.16, 23.39, 270.0, 25.55, 297.84, 32.93, 318.7, 43.0, 333.1, 56.93, 343.68, 71.67, 352.26, 86.39, 0.0, 71.67, 7.71, 58.26, 15.35, 43.0, 26.9, 32.93, 41.3, 25.55, 62.16, 23.38, 89.94})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 57, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 33, 82, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 58, 82, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KVTapkichHHdaXL()
        Dim lists4 As New List(Of IPosition71), lists5 As New List(Of IPosition71)
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.0, 328.52, 53.98, 315.33, 50.03, 411.0, 58.93, 300.58, 60.39, 323.5, 58.0, 131.23, 40.36, 223.61, 63.43, 200.0, 89.98, 170.0, 89.98, 183.85, 67.62, 76.16, 23.2, 76.16, 156.8, 183.85, 112.38, 170.0, 90.0, 200.0, 90.0, 223.16, 116.57, 131.21, 139.65, 322.86, 122.03, 300.59, 119.62, 411.01, 121.08, 315.35, 129.98, 329.15, 125.99, 100.0, 180.0, 170.0, 89.98, 183.85, 67.62, 76.16, 23.2, 76.16, 156.8, 183.85, 112.38, 170.0, 90.0, 145.0, 90.0, 151.82, 107.24, 71.06, 129.29, 71.06, 50.71, 151.82, 72.76, 145.0, 89.99})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 23, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 24, 35, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 30, 35, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        lists4.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)(10))
        lists4.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)(27))
        lists5.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)(26))
        lists5.Add(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1)(28))
        FDuongList(lists4, 4294967295, "", 0, 0, mau, Dorongduong * 1.6, False, 2, 0, 1)
        FDuongList(lists5, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 1)
        SLenhve3DMs()
    End Sub

    Public Sub KVsucoHH()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.0, 328.52, 53.98, 315.33, 50.03, 411.0, 58.93, 300.58, 60.39, 323.5, 58.0, 96.62, 28.19, 240.88, 84.73, 162.21, 84.35, 65.92, 27.07, 59.24, 149.58, 162.45, 84.39, 240.88, 84.76, 89.26, 156.08, 322.86, 122.03, 300.59, 119.62, 411.01, 121.08, 315.35, 129.98, 329.15, 125.99, 100.0, 180.0, 162.21, 84.35, 65.92, 27.07, 59.24, 149.58, 162.45, 84.39, 97.1, 83.62, 55.96, 100.63, 60.12, 66.18, 96.86, 83.56})
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 0, 19, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 20, 27, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.Instance.mPointClick, 3.0, Goc1), 25, 27, 4294967295, 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 0, FrmMain.Instance.sgworldMain.Creator.CreateColor(210, 210, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub VetNXDudoan()
        Dim Khoangcach As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim hesoTyle As Double = Khoangcach / 151.0
        Dim TQ As New List(Of Double)({8.0, 5.4, 43.25, 70.1, 43.4, 73.3, 43.52, 76.6, 43.61, 79.8, 43.66, 83.0, 43.68, 86.2, 43.68, 89.4, 43.63, 92.6, 43.56, 95.8, 43.46, 99.1, 43.32, 102.3, 43.16, 105.5, 42.96, 108.8, 8.0, 170.4, 43.25, 70.1, 76.2, 74.6, 77.22, 77.1, 78.05, 79.5, 78.69, 82.0, 79.14, 84.5, 79.4, 87.0, 79.46, 89.5, 79.33, 92.0, 79.01, 94.4, 78.5, 96.9, 77.79, 99.4, 76.9, 101.9, 75.82, 104.3, 42.96, 108.8, 76.2, 74.6, 109.33, 76.4, 111.15, 78.5, 112.65, 80.6, 113.81, 82.8, 114.63, 85.0, 115.11, 87.3, 115.25, 89.5, 115.03, 91.7, 114.47, 93.9, 113.57, 96.1, 112.33, 98.3, 110.76, 100.5, 108.86, 102.6, 75.82, 104.3, 109.33, 76.4, 142.51, 77.3, 145.12, 79.2, 147.27, 81.2, 148.94, 83.3, 150.13, 85.3, 150.83, 87.4, 151.03, 89.5, 150.73, 91.6, 149.94, 93.7, 148.66, 95.7, 146.89, 97.7, 144.65, 99.7, 141.95, 101.7, 108.86, 102.6, 0.0, 0.0, 151.03, 89.5})
        ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)
        Dim Kc As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(0).X, ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(0).Y, ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(14).X, ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(14).Y)
        MCircleTQ(FrmMain.Instance.mPointClick, Kc, 4294967295, Dorongduong * 1.6, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 4)
        MCircleTQ(FrmMain.Instance.mPointClick, Kc - Dorongduong * 3, 4294967295, Dorongduong * 1.6, mau4, 1, Nothing, 0, "", 0, 0, 0, False, 2, 3)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 30, 44, 4294967295, "", 0, 0, mau3, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 14, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 15, 29, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 30, 44, 4294967295, "", 0, 0, mauNau, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 45, 59, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 60, 61, 4294967295, "", 0, 0, mau3, Dorongduong * 1.6, False, 2, 0, 2)
        SLenhve3DMs()
    End Sub

    Public Sub VetNXThucte()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim Khoangcach As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim hesoTyle As Double = Khoangcach / 199.0
        Dim TQ As New List(Of Double)({15.45, 29.14, 22.53, 30.6, 26.04, 32.5, 43.19, 44.1, 63.43, 53.3, 86.02, 60.6, 109.75, 66.6, 133.2, 71.7, 154.87, 76.1, 173.35, 80.0, 187.41, 83.6, 196.12, 87.0, 198.91, 90.3, 195.58, 93.7, 186.37, 97.1, 171.89, 100.8, 153.11, 104.8, 131.29, 109.3, 107.84, 114.5, 84.27, 120.7, 61.99, 128.4, 42.17, 138.0, 25.5, 150.2, 22.59, 152.73, 15.45, 164.14, 15.32, 36.64, 22.49, 41.0, 32.48, 47.8, 48.87, 56.5, 67.35, 63.3, 86.91, 68.9, 106.32, 73.5, 124.35, 77.5, 139.8, 81.0, 151.66, 84.3, 159.12, 87.4, 161.71, 90.4, 159.24, 93.4, 151.89, 96.5, 140.16, 99.9, 124.84, 103.5, 106.96, 107.6, 87.71, 112.4, 68.36, 118.3, 50.1, 125.6, 33.97, 134.9, 22.51, 144.3, 15.36, 152.58, 15.45, 44.14, 22.68, 49.7, 34.03, 57.3, 46.97, 64.0, 60.69, 69.4, 74.32, 73.9, 86.98, 77.8, 97.84, 81.2, 106.17, 84.4, 111.41, 87.3, 113.21, 90.2, 111.46, 93.1, 106.27, 96.1, 97.99, 99.3, 87.19, 102.8, 74.59, 106.8, 61.03, 111.4, 47.4, 117.0, 34.56, 124.1, 22.49, 133.7, 15.32, 142.14, 15.32, 51.64, 22.52, 60.4, 26.43, 63.5, 34.04, 68.9, 41.59, 73.5, 48.59, 77.5, 54.59, 81.0, 59.2, 84.3, 62.1, 87.4, 63.1, 90.4, 62.15, 93.4, 59.29, 96.6, 54.74, 99.9, 48.79, 103.5, 41.84, 107.6, 34.36, 112.4, 26.83, 118.2, 22.56, 121.9, 15.36, 130.93})
        Dim Kc As Double = FrmMain.Instance.sgworldMain.CoordServices.GetDistance(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(0).X, ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(0).Y, ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(24).X, ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1)(24).Y)
        MCircleTQ(FrmMain.Instance.mPointClick, Kc, 4294967295, Dorongduong * 1.6, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 4)
        MCircleTQ(FrmMain.Instance.mPointClick, Kc - Dorongduong * 3, 4294967295, Dorongduong * 1.6, mau4, 1, Nothing, 0, "", 0, 0, 0, False, 2, 3)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 0, 24, 4294967295, "", 0, 0, mau3, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 25, 47, 4294967295, "", 0, 0, mauXanh, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 48, 68, 4294967295, "", 0, 0, mauNau, Dorongduong * 1.6, False, 2, 0, 2)
        FDuong(ArrayPoint(TQ, FrmMain.Instance.mPointClick, hesoTyle / Tyle, Goc1), 69, 87, 4294967295, "", 0, 0, mauChu, Dorongduong * 1.6, False, 2, 0, 2)
        SLenhve3DMs()
    End Sub

    Public Sub KVTSmatdat()
        Dim P2 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.Instance.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, 2, 0, 0, 0, 0) 'Diem giua
        Dim Kc As Double = 0.7 * FKc(P1, P2)
        Dim Pk1 As IPosition71 = P1.Move(Kc, FGoc(P2, P1) - 270, 0)
        Dim Pk2 As IPosition71 = P1.Move(Kc, FGoc(P2, P1) - 90, 0)
        Dim Pk3 As IPosition71 = P2.Move(Kc / 2, FGoc(P2, P1) - 90, 0)
        Dim Pk4 As IPosition71 = P2.Move(Kc / 2, FGoc(P2, P1) - 270, 0)
        Dim liPk As New List(Of IPosition71) From {Pk1, Pk2, Pk3, Pk4}
        Dim Geo As IGeometry = ListtoGeo(liPk).SpatialOperator.buffer(-Dorongduong * 2)
        liPk.Add(Pk1)
        FDuongList(liPk, 4294967295, "", 0, 0, mau, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(GeoToList(Geo), 4294967295, "", 0, 0, mau2, Dorongduong * 1.5, False, 2, 0, 2) ' 2, False, 2)
        Dim pc As IPosition71 = CenterPoint(P1, P2)
        MakeText(pc, 0, 0.75 * FrmMain.Instance.fLabelStyleMain.Scale, 0, FrmMain.Instance.TxtGhichuKH.Text, "", mauChu, 1, 0, 0, 2)
        SLenhve3DMs()
    End Sub

#End Region

End Module


