Imports TerraExplorerX
'Imports TerraExplorerX.AltitudeTypeCode
'Imports TerraExplorerX.ActionCode
Module mdlBaoloanlatdo

#Region "    Bobinh"
    Public Sub Trunglien()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({90.0 * Tyle, 0.0, 102.96 * Tyle, 29.1, 55.9 * Tyle, 63.4, 495.63 * Tyle, 87.1, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 495.63 * Tyle, 92.9, 55.9 * Tyle, 116.6, 102.96 * Tyle, 150.9, 90.0 * Tyle, 180.0, 50.0 * Tyle, 0.0, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 50.0 * Tyle, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 10, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 11, 15, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Dailien()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({25.0 * Tyle, 0.0, 206.31 * Tyle, 83.0, 206.82 * Tyle, 81.3, 208.87 * Tyle, 72.7, 212.18 * Tyle, 64.3, 216.71 * Tyle, 56.0, 222.34 * Tyle, 47.9, 228.87 * Tyle, 40.1, 263.88 * Tyle, 48.5, 261.59 * Tyle, 55.3, 259.67 * Tyle, 62.1, 258.14 * Tyle, 69.1, 257.03 * Tyle, 76.0, 256.36 * Tyle, 83.0, 256.01 * Tyle, 84.4, 495.63 * Tyle, 87.1, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 495.63 * Tyle, 92.9, 256.01 * Tyle, 95.6, 256.36 * Tyle, 97.0, 257.03 * Tyle, 104.0, 258.14 * Tyle, 110.9, 259.67 * Tyle, 117.9, 263.88 * Tyle, 131.5, 228.87 * Tyle, 139.9, 222.31 * Tyle, 132.1, 216.71 * Tyle, 124.0, 208.87 * Tyle, 107.3, 206.82 * Tyle, 98.7, 206.31 * Tyle, 97.0, 25.0 * Tyle, 180.0, 50.0 * Tyle, 0.0, 167.76 * Tyle, 72.7, 228.87 * Tyle, 40.1, 256.31 * Tyle, 78.8, 472.65 * Tyle, 83.9, 670.0 * Tyle, 90.0, 472.65 * Tyle, 96.1, 256.31 * Tyle, 101.2, 228.87 * Tyle, 139.9, 167.76 * Tyle, 107.3, 50.0 * Tyle, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 32, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 33, 43, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Phongluu()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.009, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 577.71, 87.4, 577.71, 92.6, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 50.0, 0.0, 50.0, 330.0, 50.0, 300.0, 50.0, 270.0, 50.0, 240.0, 50.0, 210.0, 50.0, 180.0, 50.0, 150.0, 50.0, 120.0, 50.0, 90.0, 50.0, 60.0, 50.0, 30.0, 50.0, 0.009, 100.0, 59.991, 579.3, 85.04, 579.3, 94.94, 100.0, 119.91})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 38, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 39, 42, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub B40()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.009, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 169.56, 81.26, 208.53, 53.514, 250.49, 60.337, 219.11, 83.257, 577.71, 87.4, 577.71, 92.6, 219.11, 96.824, 250.49, 120.093, 208.53, 126.954, 169.56, 98.82, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 50.0, 0.0, 50.0, 330.0, 50.0, 300.0, 50.0, 270.0, 50.0, 240.0, 50.0, 210.0, 50.0, 180.0, 50.0, 150.0, 50.0, 120.0, 50.0, 90.0, 50.0, 60.0, 50.0, 30.0, 50.0, 0.009, 100.0, 59.991, 579.3, 85.04, 579.3, 94.94, 100.0, 119.91})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 46, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 47, 50, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub B41()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({100.0, 0.009, 100.0, 15.0, 100.0, 30.0, 100.0, 45.0, 100.0, 60.0, 100.0, 75.0, 169.56, 81.26, 208.53, 53.514, 250.49, 60.337, 219.11, 83.257, 577.71, 87.4, 577.71, 92.6, 219.11, 96.824, 250.49, 120.093, 208.53, 126.954, 169.56, 98.82, 100.0, 105.0, 100.0, 120.0, 100.0, 135.0, 100.0, 150.0, 100.0, 165.0, 100.0, 180.0, 100.0, 195.0, 100.0, 210.0, 100.0, 225.0, 100.0, 240.0, 100.0, 255.0, 100.0, 270.0, 100.0, 285.0, 100.0, 300.0, 100.0, 315.0, 100.0, 330.0, 100.0, 345.0, 100.0, 0.0, 100.0, 59.991, 579.3, 85.04, 579.3, 94.94, 100.0, 119.91})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 34, 37, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Coi60()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI + 180
        Dim TQ As New List(Of Double)({250.0, 0.02, 250.0, 15.0, 250.0, 30.0, 250.0, 45.0, 250.0, 60.0, 250.0, 75.0, 250.0, 90.0, 250.0, 105.0, 250.0, 120.0, 250.0, 135.0, 250.0, 150.0, 250.0, 165.0, 250.0, 180.0, 416.0, 216.905, 359.19, 224.107, 250.0, 210.0, 250.0, 225.0, 250.0, 240.0, 250.0, 255.0, 250.0, 270.0, 250.0, 285.0, 250.0, 300.0, 250.0, 315.0, 250.0, 330.0, 359.19, 315.893, 416.33, 323.095, 250.0, 0.0, 174.35, 0.0, 174.35, 330.0, 174.35, 315.0, 174.35, 300.0, 174.35, 285.0, 174.35, 270.0, 174.35, 255.0, 174.35, 240.0, 174.35, 225.0, 174.35, 210.0, 174.35, 195.0, 174.35, 180.0, 174.35, 165.0, 174.35, 150.0, 174.35, 135.0, 174.35, 120.0, 174.35, 105.0, 174.35, 90.0, 174.35, 75.0, 174.35, 60.0, 174.35, 45.0, 174.35, 30.0, 174.35, 15.0, 174.35, 0.02, 123.92, 0.02, 123.92, 30.0, 123.92, 60.0, 123.92, 90.0, 123.92, 120.0, 123.92, 150.0, 123.92, 180.0, 123.92, 210.0, 123.92, 240.0, 123.92, 270.0, 123.92, 300.0, 123.92, 330.0, 123.92, 0.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 50, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 27, 63, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Congsuhoakhikhongnap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({225.0, 0.015, 503.12, 63.435, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 503.12, 116.565, 225.0, 180.0, 225.0, 0.0, 175.57, 19.983, 175.57, 160.017, 423.47, 112.932, 423.47, 67.068, 175.59, 20.001, 159.49, 41.202, 365.27, 70.821, 365.27, 109.179, 159.45, 138.814, 159.45, 41.186})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Congsuhoakhiconap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({225.0, 0.015, 503.12, 63.435, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 503.12, 116.565, 225.0, 180.0, 225.0, 0.0, 175.57, 19.983, 175.57, 160.017, 423.47, 112.932, 423.47, 67.068, 175.59, 20.001, 159.49, 41.202, 365.27, 70.821, 365.27, 109.179, 159.45, 138.814, 159.45, 41.186, 387.12, 64.772, 423.47, 67.068, 408.81, 72.553, 194.21, 148.169, 175.57, 160.017, 134.16, 153.435})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 23, 28, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Hamkhongconap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({345.0, 0.001, 567.03, 52.524, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 567.03, 127.476, 345.0, 180.0, 345.0, 0.0, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 483.04, 53.842, 291.25, 11.89, 261.96, 23.63, 420.27, 55.176, 420.27, 124.824, 261.96, 156.371, 261.96, 23.629})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Hamconap()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({345.0, 0.001, 567.03, 52.524, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 567.03, 127.476, 345.0, 180.0, 345.0, 0.0, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 483.04, 53.842, 291.25, 11.89, 261.96, 23.63, 420.27, 55.176, 420.27, 124.824, 261.96, 156.371, 261.96, 23.629, 455.51, 51.268, 483.04, 53.842, 450.31, 60.005, 300.31, 161.626, 291.25, 168.111, 232.98, 165.076})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 13, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 23, 28, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub HamNBC()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({345.0, 0.001, 567.03, 52.524, 451.0, 86.186, 480.94, 86.424, 488.36, 79.38, 577.06, 81.027, 570.79, 86.987, 540.83, 86.82, 540.83, 93.18, 451.0, 93.814, 567.03, 127.476, 345.0, 180.0, 345.0, 0.0, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 291.25, 11.89, 291.25, 11.889, 291.25, 168.111, 483.04, 126.158, 402.48, 120.997, 420.27, 124.824, 261.96, 156.371, 232.35, 26.866})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 16, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 17, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HamkiencochongNBC()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({250.0, 0.001, 353.55, 45.0, 279.51, 63.435, 1007.78, 82.875, 1030.78, 104.036, 790.57, 108.435, 760.35, 99.462, 125.0, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 7, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub HamdachienchongNBC()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim fileName As String '= String.Empty
        If FrmMain.cbTa_DP.SelectedIndex = 1 Then
            fileName = "BTVTr.gif"
        Else
            fileName = "BTkoVTr.gif"
        End If
        Dim TQ As New List(Of Double)({250.0, 0.001, 353.55, 45.0, 279.51, 63.435, 1007.78, 82.875, 1030.78, 104.036, 790.57, 108.435, 760.35, 99.462, 125.0, 180.0, 250.0, 0.0, 199.25, 17.526, 88.46, 137.291, 812.6, 94.588, 831.99, 103.201, 959.01, 101.427, 942.24, 86.044, 200.81, 71.114, 268.7, 45.0, 199.25, 17.524, 178.04, 38.155, 197.99, 45.0, 140.8, 83.884, 890.13, 89.034, 900.94, 98.94, 871.32, 99.246, 860.13, 90.999, 111.02, 97.765, 178.04, 38.157})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 9, 26, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 1.25, Goc1), 9, 17, 4294967295, 0, mau2, 0, mau2, 1, fileName, 2.0 * Tyle, 2.0 * Tyle, 45, False, 2, 2)
        SLenhve3DMs()
    End Sub
#End Region


#Region "    Baolaolatdo"
    Public Sub MuctieuBLLD()
        Dim lists1 As New List(Of IPosition71), lists2 As New List(Of IPosition71), lists3 As New List(Of IPosition71),
            lists4 As New List(Of IPosition71), lists6 As New List(Of IPosition71), lists7 As New List(Of IPosition71)
        Dim k(30) As IPosition71
        Dim Goc1 As Double = 90 + Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Tyle * 3.0

        k(1) = FrmMain.mPointClick.Move(90.0 * hesoTyle, 0.0 - Goc1, 0)
        k(2) = FrmMain.mPointClick.Move(313.21 * hesoTyle, 73.3 - Goc1, 0)
        k(3) = FrmMain.mPointClick.Move(313.21 * hesoTyle, 106.7 - Goc1, 0)
        k(4) = FrmMain.mPointClick.Move(90.0 * hesoTyle, 180.0 - Goc1, 0)
        k(5) = FrmMain.mPointClick.Move(302.65 * hesoTyle, 82.41 - Goc1, 0)
        k(6) = FrmMain.mPointClick.Move(89.44 * hesoTyle, 63.43 - Goc1, 0)
        k(7) = FrmMain.mPointClick.Move(89.44 * hesoTyle, 116.57 - Goc1, 0)
        k(8) = FrmMain.mPointClick.Move(223.61 * hesoTyle, 100.3 - Goc1, 0)
        k(9) = FrmMain.mPointClick.Move(223.57 * hesoTyle, 79.75 - Goc1, 0)
        k(10) = FrmMain.mPointClick.Move(302.63 * hesoTyle, 82.44 - Goc1, 0)

        k(11) = k(4).Move(-Dorongduong * 1.2, 225.0 - Goc1, 0)
        k(12) = k(1).Move(-Dorongduong * 1.2, 315.0 - Goc1, 0)
        k(13) = k(2).Move(-Dorongduong * 1.2, 45.0 - Goc1, 0)
        k(14) = k(3).Move(-Dorongduong * 1.2, 135.0 - Goc1, 0)

        k(15) = FrmMain.mPointClick.Move(40.0 * hesoTyle, 0.0 - Goc1, 0)
        k(16) = FrmMain.mPointClick.Move(302.65 * hesoTyle, 82.41 - Goc1, 0)
        k(17) = FrmMain.mPointClick.Move(302.65 * hesoTyle, 97.59 - Goc1, 0)
        k(18) = FrmMain.mPointClick.Move(40.0 * hesoTyle, 180.0 - Goc1, 0)

        k(19) = FrmMain.mPointClick.Move(90.0 * hesoTyle, 0.0 - Goc1, 0)
        k(20) = FrmMain.mPointClick.Move(150.0 * hesoTyle, 53.13 - Goc1, 0)
        k(21) = FrmMain.mPointClick.Move(313.21 * hesoTyle, 106.7 - Goc1, 0)
        k(22) = FrmMain.mPointClick.Move(201.25 * hesoTyle, 116.57 - Goc1, 0)
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
                vung = FVungPoint(k, 19, 22, 3284386755, Dorongduong, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, filePastern, 12.0 * Tyle, 12.0 * Tyle, 0, False, 2, 2)
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
            If FrmMain.cbTa_DP.SelectedIndex = 0 Then
                filePastern = "NenDo.gif"
            Else
                filePastern = "NenXanh.gif"
            End If
            vung = FVungPoint(k, 15, 18, 4294967295, Dorongduong, mau, 1, mau, 0, filePastern, Tyle * 14.0, Tyle * 14.0, 90, False, 2, 2)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau, 1, mau, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 1)
        ElseIf Lenhve = "muctieuDachiem" Then
            If FrmMain.cbTa_DP.SelectedIndex = 0 Then
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
                Dim P12 As IPosition71 = FrmMain.mPointClick.Move(150.0 * hesoTyle, 90.0 - Goc1, 0)
                MCircleTQ(P12, 250, 4294967295, Dorongduong, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            End If
        ElseIf Lenhve = "muctieuBLLD" Or Lenhve = "noigiamcontin" Then
            If FrmMain.cbTa_DP.SelectedIndex = 0 Then
                filePastern = "NenXanh.gif"
            Else
                filePastern = "NenDo.gif"
            End If
            vung = FVungList(lists3, 4294967295, 0, mau, 0, mau, 1, filePastern, Tyle * 14.0, Tyle * 14.0, 135, False, 2, 2)
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 1, 1, 0, False, 2, 1)
            vung = FVungPoint(k, 6, 9, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            If Lenhve = "noigiamcontin" Then
                Dim P12 As IPosition71 = FrmMain.mPointClick.Move(150.0 * hesoTyle, 90.0 - Goc1, 0)
                MCircleTQ(P12, 250, 4294967295, Dorongduong, mau3, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            End If
        ElseIf Lenhve = "MatcuA2" Then
            vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mau3, 1, mau3, 0, "", 1, 1, 0, False, 2, 2)
            vung = FVungPoint(k, 11, 14, 4294967295, Dorongduong, mau4, 1, mau4, 0, "", 1, 1, 0, False, 2, 1)
            mText = FLabel(FrmMain.mPointClick, 150, Tyle * 4, 0, "A2", "", mau3, 1, 0, 2, 2)
        ElseIf Lenhve = "hamchong" Or Lenhve = "baicocchongtang" Then
            Dim M(5) As IPosition71
            M(1) = FrmMain.mPointClick.Move(64.01 * hesoTyle, 51.36 - Goc1, 0)
            M(2) = FrmMain.mPointClick.Move(155.22 * hesoTyle, 75.1 - Goc1, 0)
            M(3) = FrmMain.mPointClick.Move(253.15 * hesoTyle, 80.95 - Goc1, 0)
            M(4) = FrmMain.mPointClick.Move(203.96 * hesoTyle, 101.31 - Goc1, 0)
            M(5) = FrmMain.mPointClick.Move(107.7 * hesoTyle, 111.8 - Goc1, 0)
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
            MinChongtau(FrmMain.mPointClick.Move(90 * hesoTyle, 90.0 - Goc1, 0), Goc1, mauDen)
            MinChongtau(FrmMain.mPointClick.Move(200 * hesoTyle, 90.0 - Goc1, 0), Goc1, mauDen)
        ElseIf Lenhve = "luoinguytrang" Then
            If FrmMain.cbTa_DP.SelectedIndex = 0 Then
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

#End Region


#Region "    BienPhong"
    Public Sub CanoBP()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({114.16, 28.84, 223.61, 63.43, 243.55, 67.06, 260.52, 71.19, 274.11, 75.64, 284.03, 80.32, 290.06, 85.13, 292.08, 90.0, 290.06, 94.87, 284.03, 99.68, 274.11, 104.36, 260.52, 108.81, 243.55, 112.94, 223.61, 116.57, 100.0, 180.0, 100.0, 0.0, 114.13, 28.81, 89.02, 36.16, 76.16, 23.2, 76.16, 156.8, 208.97, 109.57, 224.51, 107.18, 237.44, 104.31, 247.9, 101.04, 255.58, 97.5, 260.27, 93.79, 261.85, 90.0, 260.27, 86.21, 255.58, 82.5, 247.9, 78.96, 237.44, 75.69, 224.51, 72.82, 208.97, 70.43, 89.06, 38.18, 71.09, 50.73, 199.45, 76.96, 210.64, 78.36, 219.54, 80.14, 226.83, 82.29, 232.23, 84.72, 235.54, 87.32, 236.65, 90.0, 235.54, 92.68, 232.23, 95.28, 226.83, 97.71, 219.54, 99.86, 210.64, 101.64, 199.45, 103.04, 71.06, 129.29, 76.16, 23.2, 103.28, 47.33, 135.62, 81.6, 204.35, 70.04, 220.66, 72.22, 234.95, 75.13, 157.13, 90.0, 234.85, 104.87, 220.66, 107.78, 204.35, 109.96, 135.62, 98.4, 103.28, 132.67, 76.16, 156.8, 111.19, 90.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 17, 48, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 49, 62, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HuongxamnhapCY()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({0.0, 0.0, 245.15, 70.44, 217.85, 79.18, 576.86, 81.63, 573.24, 84.62, 166.72, 88.29, 180.23, 80.02, 90.8, 90.0, 180.22, 99.45, 166.73, 91.24, 572.72, 94.79, 576.03, 97.78, 217.93, 100.31, 245.3, 109.03, 573.24, 84.62, 166.72, 88.29, 180.23, 80.02, 90.8, 90.0, 180.22, 99.45, 166.73, 91.24, 572.72, 94.79, 571.39, 92.78, 304.41, 90.0, 571.71, 86.63})
        Dim TQ2 As New List(Of Double)({20.0, 0.0, 233.95, 0.0, 235.86, 7.31, 265.64, 6.48, 308.65, 328.78, 283.43, 325.63, 267.64, 330.94, 131.53, 278.75, 101.98, 281.31, 254.42, 336.86, 247.25, 341.12, 82.46, 284.04, 53.85, 291.8, 239.23, 347.94, 235.86, 352.69, 36.06, 303.69, 20.0, 180.0, 233.95, 180.0, 235.86, 172.5, 265.64, 173.37, 308.65, 211.81, 283.43, 215.06, 267.64, 209.69, 131.53, 261.25, 101.98, 258.69, 254.42, 203.68, 247.25, 199.33, 82.46, 255.96, 53.85, 248.2, 239.23, 192.37, 235.86, 187.5, 36.06, 236.31})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 13, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 14, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ2, FrmMain.mPointClick, 3.0, Goc1), 0, 15, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ2, FrmMain.mPointClick, 3.0, Goc1), 16, 31, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub HuongxamnhapTY()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim TQ As New List(Of Double)({0.0, 0.0, 218.49, 76.71, 194.93, 86.23, 235.7, 86.71, 269.42, 86.39, 303.29, 85.5, 337.61, 84.29, 373.12, 82.68, 404.78, 81.1, 440.03, 79.09, 469.18, 77.32, 543.61, 71.76, 579.0, 78.32, 490.77, 82.44, 456.63, 84.42, 421.83, 86.36, 383.4, 88.28, 349.95, 90.0, 308.17, 91.5, 275.8, 92.59, 235.86, 93.42, 194.61, 93.68, 218.2, 103.1, 194.93, 86.23, 235.7, 86.71, 269.42, 86.39, 303.29, 85.5, 337.61, 84.29, 373.12, 82.68, 404.78, 81.1, 440.03, 79.09, 469.18, 77.32, 543.61, 71.76, 527.48, 67.8, 456.05, 73.87, 428.73, 75.88, 396.43, 77.8, 365.41, 79.52, 332.38, 81.16, 299.8, 82.46, 267.53, 83.38, 236.7, 83.79, 201.25, 83.43, 20.0, 0.0, 233.95, 0.0, 235.86, 7.31, 265.64, 6.48, 308.65, 328.78, 283.43, 325.63, 267.64, 330.94, 131.53, 278.75, 101.98, 281.31, 254.42, 336.86, 247.25, 341.12, 82.46, 284.04, 53.85, 291.8, 239.23, 347.94, 235.86, 352.69, 36.06, 303.69, 20.0, 180.0, 233.95, 180.0, 235.86, 172.5, 265.64, 173.37, 308.65, 211.81, 283.43, 215.06, 267.64, 209.69, 131.53, 261.25, 101.98, 258.69, 254.42, 203.68, 247.25, 199.33, 82.46, 255.96, 53.85, 248.2, 239.23, 192.37, 235.86, 187.5, 36.06, 236.31})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 22, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 23, 42, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 43, 58, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 59, 74, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Dayquayve()
        Dim Goc1 As Double = Math.PI - (Phuongvi * 180.0 / Math.PI - 270)
        Dim TQ As New List(Of Double)({73.0, 90.0, 158.43, 139.1, 132.09, 140.7, 303.16, 164.0, 329.69, 165.5, 353.67, 167.7, 373.75, 170.4, 388.87, 173.4, 398.25, 176.6, 401.41, 179.9, 398.18, 183.2, 388.74, 186.4, 373.56, 189.4, 353.42, 192.1, 329.4, 194.3, 302.84, 195.8, 131.36, 218.9, 157.59, 220.5, 73.0, 270.0, 127.03, 199.5, 119.82, 211.4, 297.66, 192.1, 322.04, 191.0, 342.38, 189.3, 359.15, 187.2, 371.39, 184.8, 378.7, 182.4, 381.12, 179.9, 378.75, 177.4, 371.49, 175.0, 359.3, 172.6, 342.75, 170.5, 322.27, 168.8, 297.91, 167.7, 120.44, 148.1, 127.53, 160.0, 119.82, 211.4, 297.66, 192.1, 322.04, 191.0, 342.38, 189.3, 359.15, 187.2, 371.39, 184.8, 378.7, 182.4, 381.12, 179.9, 378.75, 177.4, 371.49, 175.0, 359.3, 172.6, 342.75, 170.5, 322.27, 168.8, 297.91, 167.7, 120.44, 148.1, 125.72, 157.8, 294.62, 170.7, 317.13, 171.5, 334.31, 172.8, 348.15, 174.5, 357.81, 176.3, 363.22, 178.2, 364.9, 179.9, 363.18, 181.7, 357.73, 183.5, 348.04, 185.3, 334.16, 187.0, 316.96, 188.3, 294.43, 189.1, 125.13, 201.8})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, -Goc1), 0, 35, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, -Goc1), 36, 65, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub PhuckichBP()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI + 270
        Dim p1 As IPosition71 = FrmMain.mPointClick.Move(310 * Tyle * 2.5, 0 - Goc1, 0)
        Dim TQ As New List(Of Double)({122.5, 90.0, 194.46, 128.0, 167.85, 127.5, 216.44, 142.1, 241.98, 148.9, 264.32, 155.5, 282.67, 161.8, 296.31, 167.9, 304.7, 173.9, 307.5, 179.9, 304.58, 185.8, 296.07, 191.8, 282.3, 198.0, 263.84, 204.3, 241.38, 210.8, 215.72, 217.7, 166.93, 232.2, 193.44, 231.7, 122.5, 270.0, 150.91, 217.5, 151.61, 227.6, 202.26, 213.6, 226.47, 207.5, 247.57, 201.6, 264.65, 195.9, 277.14, 190.5, 284.73, 185.1, 286.02, 181.9, 102.72, 185.3, 123.37, 193.8, 0.0, 0.0, 123.65, 165.6, 102.83, 174.1, 286.06, 177.9, 284.83, 174.6, 277.36, 169.3, 264.97, 163.8, 248.0, 158.1, 227.01, 152.2, 202.9, 146.1, 152.48, 132.1, 151.78, 142.1, 151.61, 227.6, 202.26, 213.6, 226.47, 207.5, 247.57, 201.6, 264.65, 195.9, 277.14, 190.5, 284.73, 185.1, 286.02, 181.9, 269.87, 182.0, 268.88, 184.5, 262.14, 189.2, 250.8, 194.1, 234.99, 199.2, 215.16, 204.6, 192.32, 209.9, 150.67, 219.5, 286.06, 177.9, 284.83, 174.6, 277.36, 169.3, 264.97, 163.8, 248.0, 158.1, 227.01, 152.2, 202.9, 146.1, 152.48, 132.1, 151.55, 140.2, 192.91, 149.8, 215.65, 155.2, 235.37, 160.5, 251.09, 165.6, 262.33, 170.6, 268.98, 175.3, 269.91, 177.8})
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 0, 41, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 42, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 58, 73, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub NganchanBP()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI + 270
        Dim p1 As IPosition71 = FrmMain.mPointClick.Move(310 * Tyle * 2.5, 0 - Goc1, 0)
        Dim TQ As New List(Of Double)({122.5, 90.0, 194.46, 128.0, 167.85, 127.5, 216.44, 142.1, 241.98, 148.9, 264.32, 155.5, 282.67, 161.8, 296.31, 167.9, 304.7, 173.9, 307.5, 179.9, 304.58, 185.8, 296.07, 191.8, 282.3, 198.0, 263.84, 204.3, 241.38, 210.8, 215.72, 217.7, 166.93, 232.2, 193.44, 231.7, 122.5, 270.0, 150.91, 217.5, 151.61, 227.6, 202.26, 213.6, 226.47, 207.5, 247.57, 201.6, 264.65, 195.9, 277.14, 190.5, 284.73, 185.1, 286.02, 181.9, 102.72, 185.3, 123.37, 193.8, 0.0, 0.0, 123.65, 165.6, 102.83, 174.1, 286.06, 177.9, 284.83, 174.6, 277.36, 169.3, 264.97, 163.8, 248.0, 158.1, 227.01, 152.2, 202.9, 146.1, 152.48, 132.1, 151.78, 142.1, 151.61, 227.6, 202.26, 213.6, 226.47, 207.5, 247.57, 201.6, 264.65, 195.9, 277.14, 190.5, 284.73, 185.1, 286.02, 181.9, 269.87, 182.0, 268.88, 184.5, 262.14, 189.2, 250.8, 194.1, 234.99, 199.2, 215.16, 204.6, 192.32, 209.9, 150.67, 219.5, 286.06, 177.9, 284.83, 174.6, 277.36, 169.3, 264.97, 163.8, 248.0, 158.1, 227.01, 152.2, 202.9, 146.1, 152.48, 132.1, 151.55, 140.2, 192.91, 149.8, 215.65, 155.2, 235.37, 160.5, 251.09, 165.6, 262.33, 170.6, 268.98, 175.3, 269.91, 177.8, 316.8, 155.2, 335.06, 156.6, 334.6, 203.2, 316.32, 204.6})
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 0, 41, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 42, 57, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 58, 73, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, p1, 2.5, Goc1), 74, 77, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TauBPbatgiu()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({114.47, 15.25, 376.56, 72.94, 525.67, 90.0, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51, 74.67, 23.77, 85.89, 20.51, 107.97, 41.84, 195.64, 85.03, 328.0, 75.8, 368.88, 77.4, 377.24, 78.71, 227.87, 90.0, 377.24, 101.24, 368.88, 102.6, 328.0, 104.2, 195.84, 94.96, 107.97, 138.16, 85.85, 159.55, 74.68, 156.31, 162.14, 90.0, 750, 90.0, 575, 90.0})
        ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)
        Dim Bankinh As Double = FrmMain.sgworldMain.CoordServices.GetDistance(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(2).X, ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(2).Y, ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(28).X, ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(28).Y) * 2.0
        MCircleTQ(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(28), Bankinh, 4294967295, Dorongduong, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemTau(FrmMain.mPointClick, Goc1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 12, 27, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 2)
        KHTauDanhca(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(29), Goc1, mau3, mau4)
        SLenhve3DMs()
    End Sub

    Public Sub TauBPKiemtra()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({114.47, 15.25, 376.56, 72.94, 503.39, 88.29, 621.25, 88.62, 613.93, 87.07, 746.02, 90.0, 613.98, 92.89, 621.26, 91.38, 503.39, 91.71, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51, 1110.85, 84.33, 1140.7, 84.48, 1140.7, 95.59, 1110.85, 95.75, 74.67, 23.77, 85.89, 20.51, 107.97, 41.84, 195.64, 85.03, 328.0, 75.8, 368.88, 77.4, 377.24, 78.71, 227.87, 90.0, 377.24, 101.24, 368.88, 102.6, 328.0, 104.2, 195.84, 94.96, 107.97, 138.16, 85.85, 159.55, 74.68, 156.31, 162.14, 90.0, 766.0, 90.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 22, 37, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 18, 21, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemTau(FrmMain.mPointClick, Goc1)
        KHTauDanhca(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(38), Goc1, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), mau4)
        SLenhve3DMs()
    End Sub

    Public Sub TauBPApgiai()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({114.47, 15.25, 376.56, 72.94, 503.39, 88.29, 525.88, 88.37, 546.07, 88.45, 569.95, 88.34, 590.63, 88.05, 613.14, 87.58, 633.96, 86.96, 653.78, 86.26, 672.6, 85.43, 694.53, 84.34, 672.88, 83.14, 804.66, 80.35, 706.11, 87.52, 703.0, 85.44, 681.89, 86.66, 660.56, 87.79, 642.34, 88.62, 617.84, 89.6, 597.21, 90.27, 572.66, 90.93, 549.39, 91.36, 525.88, 91.63, 503.39, 91.71, 376.56, 107.06, 110.44, 180.0, 110.44, 0.0, 114.44, 15.2, 85.85, 159.55, 368.88, 102.6, 482.81, 90.0, 368.88, 77.4, 85.85, 20.51, 74.67, 23.77, 85.89, 20.51, 107.97, 41.84, 195.64, 85.03, 328.0, 75.8, 368.88, 77.4, 377.24, 78.71, 227.87, 90.0, 377.24, 101.24, 368.88, 102.6, 328.0, 104.2, 195.84, 94.96, 107.97, 138.16, 85.85, 159.55, 74.68, 156.31, 162.14, 90.0, 820.0, 80.35})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 33, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemTau(FrmMain.mPointClick, Goc1)
        vung = FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 34, 49, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 2)
        KHTauDanhca(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1)(50), Goc1, mau3, mau4)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenXamnhap()
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai
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
        FVungPoint(liP1.ToArray, 10, 13, 4294967295, 0, mau4, 0, mau4, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub
#End Region


#Region "    Congbinh"

#Region "   Hang rao"
    Public Sub Hangrao(sgworldK As SGWorld71, bk As Double)
        FrmMain.TinhGoc2()
        If Lenhve = "hangraobungnhung" Then
            HrKemgai(sgworldK, GroupBac2Main, ArrayPoint3D(sgworldK, cPlg2), Tyle * 0.0008125)
            '  hrKemgai2(sgworldK, frmMain.pMHP, bk, mRelativeTeerain)
            'ElseIf Lenhve = "hangraocaydo" Then
            '    HrCacloai(sgworldK, GroupBac2Main, ArrayPoint3D(sgworldK, cPlg2), Tyle * 0.00125)
            '    hrCaydo(sgworldK, frmMain.pMHP, bk, mRelativeTeerain)
            'ElseIf Lenhve = "hangraokemgaicococ" Then
            '    hrKGcoc(sgworldK, frmMain.pMHP, bk, mRelativeTeerain)
        End If

    End Sub

    Public Sub HrKemgai(sgworldK As SGWorld71, gr As String, pMHTimPSet() As Point3D, bk As Double)
        Dim mpk As New List(Of IPosition71), mpk2 As New List(Of IPosition71)  'hr(i).Z * 120000
        Dim hr() As Point3D = NsHRKG(pMHTimPSet, bk, bk)
        For i As Integer = 1 To hr.Count - 1
            Dim pHR As IPosition71 = sgworldK.Creator.CreatePosition(hr(i).X, hr(i).Y, hr(i).Z * 120000, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0)
            mpk.Add(pHR)
        Next
        LineList(sgworldK, gr, mpk, 4294967295, "", 0, 0, mauDen, Dorongduong * 0.5, True, 4, Tyle * 160, 2)

        'Dim hr1 = nsHRKG(pMHTimPSet, bk - (bk / 15), bk)
        'For i As Integer = 1 To hr1.Count - 1
        '    Dim pHR As IPosition71 = frmMain.sgworldMain.Creator.CreatePosition(hr1(i).X, hr1(i).Y, hr1(i).Z * 120000, AltitudeTypeCode.ATC_3DML_RELATIVE, 0, 0, 0, 0)
        '    pHR.AltitudeType = AltitudeTypeCode.ATC_3DML_RELATIVE '.ATC_3DML_RELATIVE
        '    mpk2.Add(pHR)
        'Next
        'fDuongList(mpk2, 4294967295, "", 0, 0, mauXam, Dorongduong / 6, True, 4, Tyle * 160, 1) ' 2, False, 2)
    End Sub

    'Private Sub HrCacloai(sgworldK As SGWorld71, gr As String, pMHTimPSet() As Point3D, bk As Double)
    '    Dim mpk As List(Of IPosition71) = New List(Of IPosition71), mpk1 As List(Of IPosition71) = New List(Of IPosition71),
    '        mpk2 As List(Of IPosition71) = New List(Of IPosition71), mpGIN As List(Of IPosition71) = New List(Of IPosition71), mPv As List(Of Double) = New List(Of Double)
    '    Dim hr = NsHRKG(pMHTimPSet, bk, bk / 2)
    '    Dim K As Double = hr(1).Z
    '    For i As Integer = 1 To hr.Count - 1
    '        If hr(i).Z = K Then
    '            Dim pHR As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(hr(i).X, hr(i).Y, 0, AltitudeTypeCode.ATC_3DML_RELATIVE, 0, 0, 0, 0)
    '            '   FrmMain.sgworldMain.Creator.CreateLabel(pHR, i.ToString, "", Nothing, "", i.ToString)
    '            mpk.Add(pHR)
    '        End If
    '    Next
    '    'MsgBox(mpk.Count.ToString)
    '    'Dim i2 As Integer = System.Convert.ToInt32(mpk.Count / 15)
    '    'Dim i3 As Integer = System.Convert.ToInt32(mpk.Count - mpk.Count / 15) - i2
    '    'MsgBox(i2.ToString & ",,,,," & i3.ToString)
    '    'mpk.RemoveRange(0, i2)
    '    'mpk.RemoveRange(i3, i2)
    '    'MsgBox(mpk.Count.ToString & ",,,,," & i2.ToString & ",,,,," & i3.ToString)
    '    Dim Kc As Double = 4 * FrmMain.sgworldMain.CoordServices.GetDistance(mpk(0).X, mpk(0).Y, mpk(1).X, mpk(1).Y)
    '    Dim hesoCao As Double
    '    If Lenhve = "hangraocaydo" Then
    '        hesoCao = 100.0
    '        For i As Integer = 0 To mpk.Count - 2
    '            mPv.Add(FGoc(mpk(i), mpk(i + 1)))
    '            If (i Mod 4 = 0) Then
    '                pHRCay(sgworldK, mpk1, mpk(i), Kc, mPv(i))
    '            End If
    '        Next
    '        FDuongList(mpk1, 4294967295, "", 0, 0, mauDen, Dorongduong, False, 4, Tyle * hesoCao, 2) ' 2, False, 2)
    '    End If


    'If Lenhve = "hangraokemgaicococ" Then
    '    hesoCao = 100.0
    '    If Bd3D = True Then
    '        For i As Integer = 0 To mpk.Count - 2
    '            mPv.Add(FGoc(mpk(i), mpk(i + 1)))
    '            If (i Mod 8 = 0) Then
    '                pHRCoc2D(sgworldK, mpk(i), mpk2, Kc * 1.5, mPv(i))
    '            End If
    '        Next

    '        For i As Integer = 0 To mpk2.Count - 2
    '            mpk1.Add(mpk2(i))
    '            pHRcocKG(sgworldK, mpk2(i), mpk2(i + 1), mpk1, 80 * Tyle, 90, 0)
    '        Next
    '    Else
    '        Dim mpk3 As List(Of IPosition71) = New List(Of IPosition71)
    '        For i As Integer = 0 To mpk.Count - 1
    '            If (i Mod 2 = 0) Then
    '                mpk3.Add(mpk(i))
    '            End If
    '        Next

    '        For i As Integer = 0 To mpk3.Count - 1
    '            Dim mAltitude As Double ', mAltitudeType As Integer
    '            If (i Mod 2 = 0) Then
    '                mAltitude = 0
    '            Else
    '                mAltitude = Tyle * 200
    '            End If
    '            Dim P As IPosition71 = sgworldK.Creator.CreatePosition(mpk3(i).X, mpk3(i).Y, mAltitude, AltitudeTypeCode.ATC_3DML_RELATIVE, 0, 0, 90, 0)
    '            P.AltitudeType = AltitudeTypeCode.ATC_3DML_RELATIVE
    '            mpk2.Add(P)
    '        Next

    '        For i As Integer = 0 To mpk2.Count - 2
    '            mpk1.Add(mpk2(i))
    '            pHRcocKG(sgworldK, mpk2(i), mpk2(i + 1), mpk1, 50 * Tyle, 0, 90)
    '        Next
    '    End If
    '    FDuongList(mpk1, 4294967295, "", 0, 0, mauDen, Dorongduong / 5, False, 4, Tyle * hesoCao, 2) ' 2, False, 2)
    'End If


    'If Lenhve = "hangraokemgaivuongchan" Then
    '    hesoCao = 150.0
    '    For i As Integer = 0 To mpk.Count - 1
    '        If (i Mod 3 = 0) Then
    '            mpk2.Add(mpk(i))
    '        End If
    '    Next
    '    pHRVuongchan(sgworldK, mpk2, mpk1, Kc, 0)
    'End If

    'TrangtriHR(mpGIN, 0, i2 - 1)
    'TrangtriHR(mpGIN, i3, mpGIN.Count - 1)
    ' End Sub

    'Private Sub pHRCay(sgworldK As SGWorld71, mpkG1 As List(Of IPosition71), pG1 As IPosition71, Kc As Double, Pv As Double)
    '    Dim Yaw1, Yaw2, Pitch1, Pitch2 As Double ', Yaw2 As Double, Pitch1 As Double, Pitch2 As Double
    '    If Bd3D = True Then
    '        Pitch1 = 0
    '        Pitch2 = 0
    '        Yaw1 = 210
    '        Yaw2 = 150
    '        Kc = Kc '* 1.5
    '    Else
    '        Pitch1 = 160
    '        Pitch2 = 200
    '        Yaw1 = 0
    '        Yaw2 = 0

    '    End If
    '    Dim pGHR1 As IPosition71 = pG1.Move(Kc, Yaw1 + Pv, Pitch1) 'On
    '    Dim pGHR2 As IPosition71 = pG1.Move(Kc, Yaw2 + Pv, Pitch2) '3D on
    '    If Pv > 0 Then
    '        mpkG1.Add(pG1)
    '        mpkG1.Add(pGHR1)
    '        mpkG1.Add(pG1)
    '        mpkG1.Add(pGHR2)
    '        mpkG1.Add(pG1)
    '    End If
    '    'mpkG1(0).Altitude = 0
    '    'mpkG1(mpkG1.Count - 1).Altitude = 0
    'End Sub

    'Private Sub pHRCoc2D(sgworldK As SGWorld71, Pk As IPosition71, liPointOUT As List(Of IPosition71), Kc As Double, Pv As Double)
    '    Dim Pc1 As IPosition71 = Pk.Move(Kc, 135 + Pv, 0)
    '    Pc1.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
    '    liPointOUT.Add(Pk)
    '    liPointOUT.Add(Pc1)
    'End Sub

    'Private Sub pHRcocKG(sgworldK As SGWorld71, P1 As IPosition71, P2 As IPosition71, liPointOUT As List(Of IPosition71), Kc As Double, mYaw As Double, mPich As Double)
    '    Dim Pc As IPosition71 = sgworldK.Creator.CreatePosition((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2, (P1.Altitude + P2.Altitude) / 2, AltitudeTypeCode.ATC_3DML_RELATIVE, 0, 0, 0, 0)
    '    liPointOUT.Add(Pc)
    '    For J As Integer = 0 To 3
    '        Dim Pc1 As IPosition71 = Pc.Move(Kc, (mYaw * J), (mPich * J))
    '        liPointOUT.Add(Pc1)
    '        liPointOUT.Add(Pc)
    '    Next
    '    liPointOUT.Add(Pc)
    'End Sub

    'Private Sub pHRVuongchan(sgworldK As SGWorld71, liPIN As List(Of IPosition71), liPOUT As List(Of IPosition71), Kc As Double, Pv As Double)
    '    Dim liNgang1 As List(Of IPosition71) = New List(Of IPosition71), liNgang2 As List(Of IPosition71) = New List(Of IPosition71)
    '    For i As Integer = 0 To liPIN.Count - 2
    '        Dim lisDung As List(Of IPosition71) = New List(Of IPosition71)
    '        lisDung.Add(liPIN(i))
    '        Dim Pc3 As IPosition71 = liPIN(i).Move(Kc, 0, 90)
    '        Dim Pc2 As IPosition71 = liPIN(i).Move(Kc * 3 / 4, 0, 90)
    '        Dim Pc22 As IPosition71 = liPIN(i + 1).Move(Kc * 3 / 4, 0, 90)
    '        Dim Pc1 As IPosition71 = liPIN(i).Move(Kc / 8, 0, 90)
    '        Dim Pc11 As IPosition71 = liPIN(i + 1).Move(Kc / 8, 0, 90)

    '        liNgang1.Add(Pc1)
    '        pHRcocKG(sgworldK, Pc1, Pc11, liNgang1, Kc / 6, 0, 90)

    '        pHRcocKG(sgworldK, liPIN(i), Pc3, lisDung, Kc / 4, 0, 90)
    '        liNgang2.Add(Pc2)
    '        pHRcocKG(sgworldK, Pc2, Pc22, liNgang2, Kc / 6, 0, 90)

    '        lisDung.Add(Pc3)
    '        ' lisDung.Add(liPIN(i))
    '        fDuongList(lisDung, 4294967295, "", 0, 0, mauDen, Dorongduong / 4, False, 4, Tyle * 120, 2) ' 2, False, 2)
    '    Next


    '    '  

    '    fDuongList(liNgang1, 4294967295, "", 0, 0, mauDen, Dorongduong / 4, False, 4, Tyle * 100, 2) ' 2, False, 2)
    '    fDuongList(liNgang2, 4294967295, "", 0, 0, mauDen, Dorongduong / 4, False, 4, Tyle * 200, 2) ' 2, False, 2)

    'End Sub


    'Private Sub TrangtriHR(liPointIN As List(Of IPosition71), i1 As Integer, i2 As Integer)
    '    Dim mpka As List(Of IPosition71) = New List(Of IPosition71), mpk1a As List(Of IPosition71) = New List(Of IPosition71),
    '        mpk2a As List(Of IPosition71) = New List(Of IPosition71), mPv As List(Of Double) = New List(Of Double), mpk3a As List(Of IPosition71) = New List(Of IPosition71)
    '    For i As Integer = i1 To i2 Step 2
    '        '   Dim Pc As IPosition71 = sgworldK.Creator.CreatePosition((liPointIN(i).X + liPointIN(i + 1).X) / 2, (liPointIN(i).Y + liPointIN(i + 1).Y) / 2, (liPointIN(i).Altitude + liPointIN(i + 1).Altitude) / 2, AltitudeTypeCode.ATC_3DML_RELATIVE, 0, 0, 90, 0)
    '        Dim Pc1 As IPosition71 = liPointIN(i).Move(70 * Tyle, 90, 0)
    '        Pc1.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
    '        mpka.Add(Pc1)
    '        Dim Pc2 As IPosition71 = liPointIN(i + 1).Move(70 * Tyle, 270, 0)
    '        Pc2.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
    '        mpka.Add(Pc2)
    '    Next
    '    mpka.Add(liPointIN(i2 + 1))
    '    For i As Integer = i1 To i2 Step 2
    '        Dim Pc1 As IPosition71 = liPointIN(i).Move(70 * Tyle, 270, 0)
    '        Pc1.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
    '        mpk1a.Add(Pc1)
    '        Dim Pc2 As IPosition71 = liPointIN(i + 1).Move(70 * Tyle, 90, 0)
    '        Pc2.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
    '        mpk1a.Add(Pc2)
    '    Next
    '    For i As Integer = mpk1a.Count - 1 To 0 Step -1
    '        mpka.Add(mpk1a(i))
    '    Next
    '    fDuongList(mpka, 4294967295, "", 0, 0, mauDen, Dorongduong / 2, False, 2, Tyle * 100, 2) ' 2, False, 2)
    '    ' fDuongList(mpk1a, 4294967295, "", 0, 0, mauDen, Dorongduong / 2, False, 2, Tyle * 100, 2) ' 2, False, 2)
    'End Sub

#End Region

    Public Sub KhitaivuotsongPMP()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(120.93 * 3.0 * Tyle, 98.17 - Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.mPoint.Move(240.91 * 3.0 * Tyle, 94.09 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({90.64, 42.1, 101.65, 52.12, 115.34, 58.73, 131.75, 63.42, 150.61, 66.58, 173.82, 68.53, 197.8, 69.27, 212.17, 72.22, 228.81, 74.53, 246.37, 76.12, 264.58, 77.08, 283.22, 77.52, 305.25, 77.54, 333.72, 76.86, 361.39, 75.58, 371.08, 104.04, 90.0, 180.0, 90.55, 6.34, 90.59, 42.04, 70.6, 59.23, 57.29, 40.83, 67.87, 152.14, 333.73, 100.36, 325.37, 82.54, 300.22, 83.31, 278.24, 83.64, 259.52, 83.57, 240.93, 83.08, 222.64, 82.08, 204.87, 80.46, 188.72, 78.21, 165.06, 78.51, 141.38, 77.84, 121.33, 76.19, 102.99, 73.19, 86.03, 68.07, 70.68, 59.29, 61.66, 80.24, 79.75, 85.04, 98.7, 87.26, 117.89, 88.08, 138.29, 88.05, 161.94, 87.33, 184.93, 86.17, 202.21, 87.66, 220.59, 88.61, 239.21, 89.06, 257.91, 89.11, 276.58, 88.86, 299.54, 88.17, 303.88, 96.61, 67.86, 121.05, 61.56, 80.21})
        Dim TQ2 As New List(Of Double)({32.0, 0.0, 32.0, 30.0, 32.0, 60.0, 32.0, 90.0, 32.0, 120.0, 32.0, 150.0, 32.0, 180.0, 32.0, 210.0, 32.0, 240.0, 32.0, 270.0, 32.0, 300.0, 32.0, 330.0, 32.0, 359.9, 7.0, 359.0, 7.0, 330.0, 7.0, 300.0, 7.0, 270.0, 7.0, 240.0, 7.0, 210.0, 7.0, 180.0, 7.0, 150.0, 7.0, 120.0, 7.0, 90.0, 7.0, 60.0, 7.0, 30.0, 7.0, 0.0})
        Dim TQ3 As New List(Of Double)({32.0, 0.0, 32.0, 30.0, 32.0, 60.0, 32.0, 90.0, 32.0, 120.0, 32.0, 150.0, 32.0, 180.0, 32.0, 210.0, 32.0, 240.0, 32.0, 270.0, 32.0, 300.0, 32.0, 330.0, 32.0, 359.9, 7.0, 359.0, 7.0, 330.0, 7.0, 300.0, 7.0, 270.0, 7.0, 240.0, 7.0, 210.0, 7.0, 180.0, 7.0, 150.0, 7.0, 120.0, 7.0, 90.0, 7.0, 60.0, 7.0, 30.0, 7.0, 0.0})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, FrmMain.mPointClick, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P2, 3.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 36, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 19, 52, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(liP1.ToArray, 53, 78, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 79, 104, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub KhitaivuotsongTPP()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({105.53, 31.48, 250.98, 68.99, 265.57, 71.87, 282.67, 75.53, 297.91, 79.0, 316.31, 83.51, 332.76, 88.24, 347.23, 92.99, 360.23, 98.16, 371.08, 104.04, 90.0, 180.0, 90.0, 0.0, 105.48, 31.43, 81.39, 42.51, 67.08, 26.57, 67.08, 153.43, 332.99, 100.38, 325.71, 97.22, 314.46, 93.31, 301.68, 89.4, 286.74, 85.6, 270.41, 81.82, 252.17, 78.2, 236.16, 75.28, 81.46, 42.56, 65.28, 57.58, 226.24, 81.1, 236.9, 82.84, 253.23, 85.8, 267.92, 89.0, 281.36, 92.28, 289.34, 94.54, 296.41, 96.78, 65.19, 122.47})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 24, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 13, 33, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub XuongBBDL10()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({214.85, 65.24, 284.6, 71.57, 360.0, 90.0, 284.6, 108.43, 127.28, 135.0, 0.0, 0.0, 127.28, 45.0, 214.77, 65.22, 204.02, 72.9, 118.71, 59.64, 42.43, 90.0, 118.71, 120.36, 175.57, 109.98, 175.54, 70.05, 203.99, 72.92, 204.02, 107.1, 264.47, 103.11, 317.57, 90.0, 264.47, 76.89, 204.07, 72.9, 204.02, 72.9, 118.71, 59.64, 42.43, 90.0, 118.71, 120.36, 264.47, 103.11, 317.57, 90.0, 264.47, 76.89, 204.07, 72.9, 198.13, 79.83, 249.68, 81.94, 282.22, 90.0, 249.68, 98.06, 118.09, 107.24, 77.78, 90.0, 118.09, 72.76, 198.13, 79.83})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 19, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 20, 35, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Phatuhanh()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({318.0, 73.56, 371.08, 75.96, 371.08, 104.04, 108.17, 146.31, 61.85, 104.04, 33.54, 116.57, 54.08, 146.31, 45.0, 180.0, 45.0, 0.0, 54.08, 33.69, 33.54, 63.43, 61.85, 75.96, 108.17, 33.69, 317.94, 73.56, 310.81, 78.87, 108.17, 56.31, 108.17, 123.69, 335.41, 100.3, 329.88, 92.61, 91.34, 99.45, 91.34, 80.55, 329.88, 87.39, 335.41, 79.7, 310.85, 78.87, 310.81, 78.87, 108.17, 56.31, 108.17, 123.69, 335.41, 100.3, 335.41, 79.7, 310.85, 78.87, 307.0, 96.55, 120.21, 106.93, 120.21, 73.07, 306.99, 83.45})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 23, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 24, 33, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Xeloinuocbanhxich()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({105.53, 31.48, 223.72, 66.28, 276.59, 77.47, 276.59, 102.67, 223.72, 113.72, 90.0, 180.0, 90.0, 0.0, 105.48, 31.43, 81.39, 42.51, 67.08, 26.57, 67.08, 153.43, 184.83, 108.94, 184.79, 71.09, 207.08, 73.19, 212.56, 74.48, 212.59, 105.55, 243.44, 99.64, 243.44, 80.36, 207.13, 73.16, 81.46, 42.56, 81.39, 42.51, 67.08, 26.57, 67.08, 153.43, 207.13, 105.55, 243.44, 99.64, 243.44, 80.36, 207.13, 73.16, 81.46, 42.56, 65.28, 57.58, 195.92, 79.71, 216.42, 83.43, 216.42, 96.57, 195.92, 100.29, 65.19, 122.47})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 19, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 20, 33, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Duonghambetong()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({90.0, 0.0, 260.98, 69.82, 252.21, 76.24, 60.0, 0.0, 60.0, 180.0, 257.24, 103.76, 261.01, 110.17, 90.0, 180.0, 288.44, 56.31, 316.23, 71.57, 316.23, 108.43, 288.44, 123.69, 267.25, 116.1, 283.85, 107.97, 283.85, 72.03, 267.25, 63.9, 60.0, 0.0, 252.21, 76.24, 260.95, 69.82, 256.32, 69.44, 267.25, 63.9, 283.85, 72.03, 283.85, 107.97, 267.25, 116.1, 256.32, 110.56, 261.01, 110.17, 252.24, 103.76, 60.0, 180.0, 35.0, 180.0, 247.49, 98.13, 247.45, 81.87, 35.0, 0.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 3, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 16, 31, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 4, 7, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 8, 15, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Hamphao()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({161.94, 8.88, 169.19, 18.97, 141.16, 22.93, 156.59, 35.33, 169.91, 46.96, 180.66, 58.08, 188.56, 68.88, 193.38, 79.49, 195.0, 90.0, 193.38, 100.51, 188.56, 111.12, 180.66, 121.92, 169.91, 133.04, 156.59, 144.67, 141.16, 157.07, 169.19, 161.03, 161.94, 171.12, 103.08, 165.96, 114.13, 151.19, 129.66, 139.11, 141.59, 128.9, 151.65, 118.92, 158.86, 109.17, 163.24, 99.55, 164.72, 90.0, 163.24, 80.45, 158.86, 70.83, 151.65, 61.08, 141.78, 51.1, 129.76, 40.96, 114.13, 28.81, 103.08, 14.04, 161.94, 8.88, 160.0, 0.0, 100.0, 0.0, 79.06, 18.43, 93.01, 36.25, 108.17, 47.3, 119.15, 56.03, 127.92, 64.61, 134.3, 73.12, 138.18, 81.57, 139.48, 90.0, 138.18, 98.43, 134.3, 106.88, 127.92, 115.39, 119.15, 123.97, 108.42, 132.46, 93.01, 143.75, 77.35, 161.14, 100.0, 180.0, 160.0, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 32, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 16, 51, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub HamVK()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({141.78, 51.1, 129.48, 40.92, 114.17, 28.86, 141.19, 22.97, 156.59, 35.33, 169.91, 46.96, 180.66, 58.08, 188.56, 68.88, 193.38, 79.49, 195.0, 90.0, 193.38, 100.51, 188.56, 111.12, 180.66, 121.92, 169.91, 133.04, 156.59, 144.67, 141.16, 157.07, 114.13, 151.19, 129.66, 139.04, 141.59, 129.02, 104.65, 148.29, 169.19, 161.03, 161.94, 171.12, 64.1, 157.05, 156.03, 112.23, 158.86, 109.17, 163.24, 99.55, 164.75, 90.0, 163.24, 80.45, 158.86, 70.83, 156.03, 67.77, 64.1, 22.95, 161.94, 8.88, 169.19, 18.97, 104.65, 31.71, 161.94, 171.12, 103.08, 165.96, 114.13, 151.19, 129.66, 139.11, 141.59, 128.9, 151.65, 118.92, 158.86, 109.17, 163.24, 99.55, 164.72, 90.0, 163.24, 80.45, 158.86, 70.83, 151.65, 61.08, 141.78, 51.1, 129.76, 40.96, 114.13, 28.81, 103.08, 14.04, 161.94, 8.88, 160.0, 0.0, 100.0, 0.0, 79.06, 18.43, 93.01, 36.25, 108.17, 47.3, 119.15, 56.03, 127.92, 64.61, 134.3, 73.12, 138.18, 81.57, 139.48, 90.0, 138.18, 98.43, 134.3, 106.88, 127.92, 115.39, 119.15, 123.97, 108.42, 132.46, 93.01, 143.75, 77.35, 161.14, 100.0, 180.0, 160.0, 180.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 33, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 34, 69, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Mindinhhuong()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({69.74, 270.0, 132.87, 53.19, 119.19, 43.2, 218.19, 60.93, 111.45, 71.85, 130.77, 63.32, 5.3, 270.0, 130.14, 116.69, 111.47, 108.18, 218.21, 119.08, 119.22, 136.82, 133.54, 126.75, 69.74, 0.0, 69.74, 15.0, 69.74, 30.0, 69.74, 45.0, 69.74, 60.0, 69.74, 75.0, 69.74, 90.0, 69.74, 105.0, 69.74, 120.0, 69.74, 135.0, 69.74, 150.0, 69.74, 165.0, 69.74, 180.0, 69.74, 195.0, 69.74, 210.0, 69.74, 225.0, 69.74, 240.0, 69.74, 255.0, 69.74, 270.0, 69.74, 285.0, 69.74, 300.0, 69.74, 315.0, 69.74, 330.0, 69.74, 345.0, 69.74, 359.9, 39.7, 359.9, 39.7, 340.0, 39.7, 320.0, 39.7, 300.0, 39.7, 280.0, 39.7, 260.0, 39.7, 240.0, 39.7, 220.0, 39.7, 200.0, 39.7, 180.0, 39.7, 160.0, 39.7, 140.0, 39.7, 120.0, 39.7, 100.0, 39.7, 80.0, 39.7, 60.0, 39.7, 40.0, 39.7, 20.0, 39.7, 0.0, 14.7, 0.0, 14.7, 30.0, 14.7, 60.0, 14.7, 90.0, 14.7, 120.0, 14.7, 150.0, 14.7, 180.0, 14.7, 210.0, 14.7, 240.0, 14.7, 270.0, 14.7, 300.0, 14.7, 330.0, 14.7, 359.9})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 0, 11, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 37, 68, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 3.0, Goc1), 12, 55, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub MinChongtang()
        MCircleTQ(FrmMain.mPointClick, 120, 4294967295, Dorongduong * 0.8, mauDen, 1, mauDen, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub MinBobinh()
        MCircleTQ(FrmMain.mPointClick, 120, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub OminChongtang()
        Dim k(130) As IPosition71
        Dim Goc1 As Double = 0
        Dim hesothuphong As Double = 20.0 * Tyle
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(7.5 * hesothuphong, 150.0 + Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.mPoint.Move(7.5 * hesothuphong, 270.0 + Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.mPoint.Move(7.5 * hesothuphong, 30.0 + Goc1, 0)
        MCircleTQ(FrmMain.mPointClick, 360, 4294967295, Dorongduong, mauDen, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(FrmMain.mPointClick, 360 - Dorongduong / Tyle, 4294967295, Dorongduong * 0.9, mau2, 1, Nothing, 0, "", 0, 0, 0, False, 2, 1)
        MCircleTQ(P1, Dorongduong / Tyle, 4294967295, Dorongduong, mauDen, 1, mauDen, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(P2, Dorongduong / Tyle, 4294967295, Dorongduong, mauDen, 1, mauDen, 2, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(P3, Dorongduong / Tyle, 4294967295, Dorongduong, mauDen, 1, mauDen, 2, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Baimin()
        Dim k(70) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim hesoTyle As Double = Tyle * 3.0
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(75 * hesoTyle, 90.0 - Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.mPoint.Move(150 * hesoTyle, 90.0 - Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.mPoint.Move(225 * hesoTyle, 90.0 - Goc1, 0)
        k(1) = FrmMain.mPoint.Move(66.47 * hesoTyle, 0.0 - Goc1, 0)
        k(2) = FrmMain.mPoint.Move(307.27 * hesoTyle, 77.51 - Goc1, 0)
        k(3) = FrmMain.mPoint.Move(307.27 * hesoTyle, 102.6 - Goc1, 0)
        k(4) = FrmMain.mPoint.Move(66.47 * hesoTyle, 180.0 - Goc1, 0)

        k(5) = k(1).Move(Dorongduong * 1.2, 135.0 - Goc1, 0)
        k(6) = k(2).Move(Dorongduong * 1.2, 225.0 - Goc1, 0)
        k(7) = k(3).Move(Dorongduong * 1.2, 315.0 - Goc1, 0)
        k(8) = k(4).Move(Dorongduong * 1.2, 45.0 - Goc1, 0)
        If Lenhve = "baiminBB" Then
            MCircleTQ(P1, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P2, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P3, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 1, "", 0, 0, 0, False, 2, 2)
        ElseIf Lenhve = "baiminHonHop" Then
            MCircleTQ(P1, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P2, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mauDen, 1, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P3, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
        Else
            MCircleTQ(P1, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P2, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(P3, 54, 4294967295, Dorongduong * 0.8, mauDen, 1, mau2, 0, "", 0, 0, 0, False, 2, 2)
        End If
        vung = FVungPoint(k, 1, 4, 4294967295, Dorongduong, mauDen, 1, mauDen, 0, "", 1, 1, 0, False, 2, 2)
        vung = FVungPoint(k, 5, 8, 4294967295, Dorongduong, mau2, 1, mau2, 0, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Cuamo()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim TQ1 As New List(Of Double)({59.35, 104.64, 31.26, 118.68, 95.07, 206.61, 60.21, 225.0, 0.0, 0.0, 60.21, 315.0, 95.07, 333.39, 31.26, 61.33, 59.35, 75.36})
        Dim TQ2 As New List(Of Double)({59.35, 284.64, 31.26, 298.68, 95.07, 26.61, 60.21, 45.0, 0.0, 0.0, 60.21, 135.0, 95.07, 153.39, 31.26, 241.33, 59.35, 255.36, 69.98, 304.86, 40.08, 356.53, 31.26, 298.68, 59.35, 284.64})
        Dim TQ3 As New List(Of Double)({59.35, 75.36, 31.26, 61.33, 40.07, 3.47, 69.98, 55.14})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P2, 3.0, Goc1))
        If Lenhve = "cuamoXT" Then
            vung = FVungPoint(liP1.ToArray, 0, 17, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        Else
            vung = FVungPoint(liP1.ToArray, 0, 17, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        vung = FVungPoint(liP1.ToArray, 18, 25, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub Cuma()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim TQ1 As New List(Of Double)({84.1, 100.27, 47.43, 108.43, 122.07, 124.99, 90.64, 140.56, 31.26, 151.33, 75.23, 202.06, 98.99, 225.0, 0.0, 0.0, 98.99, 315.0, 75.23, 338.5, 31.26, 28.68, 91.14, 39.43, 122.07, 55.01, 47.43, 71.57, 84.1, 79.73})
        Dim TQ2 As New List(Of Double)({84.1, 280.27, 47.43, 288.43, 122.07, 304.99, 90.64, 320.56, 31.26, 331.33, 75.53, 22.06, 98.99, 45.0, 0.0, 0.0, 98.99, 135.0, 75.23, 158.5, 31.26, 208.68, 90.63, 219.43, 122.07, 235.01, 47.43, 251.57, 84.1, 259.73, 91.92, 295.8, 80.62, 299.74, 47.43, 288.43, 84.1, 280.27})
        Dim TQ3 As New List(Of Double)({84.1, 79.73, 47.43, 71.57, 80.62, 60.26, 91.92, 64.2})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P2, 3.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 29, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 30, 37, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenVCkhongno()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P3 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P4 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (P3.X + P1.X), 0.5 * (P3.Y + P1.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P5 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (P3.X + P2.X), 0.5 * (P3.Y + P2.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim TQ1 As New List(Of Double)({71.59, 102.09, 33.54, 116.57, 67.08, 153.43, 60.0, 180.0, 60.0, 0.0, 67.08, 26.57, 33.54, 63.43, 71.59, 77.91})
        Dim TQ2 As New List(Of Double)({71.59, 282.09, 33.54, 296.57, 67.08, 333.43, 60.0, 0.0, 60.0, 180.0, 67.08, 206.57, 33.54, 243.43, 71.59, 257.91, 80.62, 299.74, 50.0, 323.13, 33.54, 296.57, 71.59, 282.09})
        Dim TQ3 As New List(Of Double)({71.59, 77.91, 33.54, 63.43, 50.0, 36.87, 80.62, 60.26})
        Dim TQ4 As New List(Of Double)({21.21, 0.0, 61.85, 30.96, 61.85, 59.04, 21.21, 90.0, 61.85, 120.96, 61.85, 149.04, 21.21, 180.0, 61.85, 210.96, 61.85, 239.04, 21.21, 270.0, 61.85, 300.96, 61.85, 329.04})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P3, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P4, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P5, 3.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 15, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 16, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(liP1.ToArray, 24, 35, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 36, 47, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 48, 59, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenVCHonhop()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim Khoangcach1 As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai = frmmain.sgworld.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P5 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(0.5 * (Pc.X + P1.X), 0.5 * (Pc.Y + P1.Y), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
        Dim P3 As IPosition71 = P1.Move(Khoangcach1 / 3 - 100, 270 - Goc1, 0)
        Dim P4 As IPosition71 = P2.Move(Khoangcach1 / 3 + 100, 90 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({33.54, 116.57, 67.08, 153.43, 60.0, 180.0, 60.0, 0.0, 67.08, 26.57, 33.54, 63.43})
        Dim TQ2 As New List(Of Double)({147.64, 275.83, 166.76, 281.0, 152.03, 290.42, 112.68, 280.85, 95.02, 303.93, 65.83, 298.9, 89.45, 270.0, 65.83, 241.1, 95.02, 236.07, 112.68, 259.15, 152.03, 249.58, 166.76, 259.0, 147.64, 264.17, 53.0, 0.0, 53.0, 15.0, 53.0, 30.0, 53.0, 45.0, 53.0, 60.0, 53.0, 73.51})
        Dim TQ3 As New List(Of Double)({147.64, 275.83, 166.76, 281.0, 152.03, 290.42, 112.68, 280.85, 95.02, 303.93, 65.83, 298.9, 89.45, 270.0, 65.83, 241.1, 95.02, 236.07, 112.68, 259.15, 152.03, 249.58, 166.76, 259.0, 147.64, 264.17})
        Dim TQ47 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 135.0, 53.0, 150.0, 53.0, 165.0, 53.0, 180.0, 53.0, 195.0, 53.0, 210.0, 53.0, 225.0, 53.0, 240.0, 53.0, 255.0, 53.0, 270.0, 53.0, 285.0, 53.0, 300.0, 53.0, 315.0, 53.0, 330.0, 53.0, 345.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0})
        'Dim TQ4 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 135.0, 53.0, 150.0, 53.0, 165.0, 53.0, 180.0, 53.0, 195.0, 53.0, 210.0, 53.0, 225.0, 53.0, 240.0, 53.0, 255.0, 53.0, 270.0, 53.0, 285.0, 53.0, 300.0, 53.0, 315.0, 53.0, 330.0, 53.0, 345.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0})
        Dim TQ5 As New List(Of Double)({53.0, 0.0, 53.0, 15.0, 53.0, 30.0, 53.0, 45.0, 53.0, 60.0, 53.0, 73.51})
        Dim TQ6 As New List(Of Double)({33.54, 296.57, 67.08, 333.43, 60.0, 0.0, 60.0, 180.0, 67.08, 206.57, 33.54, 243.43})
        ' Dim TQ7 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 135.0, 53.0, 150.0, 53.0, 165.0, 53.0, 180.0, 53.0, 195.0, 53.0, 210.0, 53.0, 225.0, 53.0, 240.0, 53.0, 255.0, 53.0, 270.0, 53.0, 285.0, 53.0, 300.0, 53.0, 315.0, 53.0, 330.0, 53.0, 345.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0})
        Dim TQ8 As New List(Of Double)({33.54, 63.43, 50.0, 36.87})
        Dim TQ9 As New List(Of Double)({50.0, 323.13, 33.54, 296.57})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P4, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P3, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ47, P4, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ5, P3, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ6, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ47, P3, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ8, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ9, P1, 3.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 18, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 19, 68, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 69, 111, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 112, 115, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub
    Public Sub TuyenRaiminHonhop()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim Khoangcach1 As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P31 As IPosition71 = P1.Move(Khoangcach1 / 3.3, 270 - Goc1, 0)
        Dim P32 As IPosition71 = P31.Move(115 * Tyle * 3.0, 270 - Goc1, 0)
        Dim P34 As IPosition71 = P2.Move(Khoangcach1 / 3.3, 90 - Goc1, 0)
        Dim P33 As IPosition71 = P34.Move(115 * Tyle * 3.0, 90 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({33.54, 116.57, 67.08, 153.43, 60.0, 180.0, 60.0, 0.0, 67.08, 26.57, 33.54, 63.43})
        '   Dim TQ2 As New List(Of Double)({53.0, 286.49, 53.0, 300.0, 53.0, 320.0, 53.0, 340.0, 53.0, 0.0, 53.0, 20.0, 53.0, 40.0, 53.0, 60.0, 53.0, 80.0, 53.0, 100.0, 53.0, 120.0, 53.0, 140.0, 53.0, 160.0, 53.0, 180.0, 53.0, 200.0, 53.0, 220.0, 53.0, 240.0, 53.0, 253.51})
        Dim TQ24 As New List(Of Double)({53.0, 286.49, 53.0, 300.0, 53.0, 320.0, 53.0, 340.0, 53.0, 0.0, 53.0, 20.0, 53.0, 40.0, 53.0, 60.0, 53.0, 80.0, 53.0, 100.0, 53.0, 120.0, 53.0, 140.0, 53.0, 160.0, 53.0, 180.0, 53.0, 200.0, 53.0, 220.0, 53.0, 240.0, 53.0, 253.51})
        Dim TQ3 As New List(Of Double)({53.0, 0.0, 53.0, 15.0, 53.0, 30.0, 53.0, 45.0, 53.0, 60.0, 53.0, 73.51})
        '  Dim TQ4 As New List(Of Double)({53.0, 286.49, 53.0, 300.0, 53.0, 320.0, 53.0, 340.0, 53.0, 0.0, 53.0, 20.0, 53.0, 40.0, 53.0, 60.0, 53.0, 80.0, 53.0, 100.0, 53.0, 120.0, 53.0, 140.0, 53.0, 160.0, 53.0, 180.0, 53.0, 200.0, 53.0, 220.0, 53.0, 240.0, 53.0, 253.51})
        '   Dim TQ5 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 135.0, 53.0, 150.0, 53.0, 165.0, 53.0, 180.0, 53.0, 195.0, 53.0, 210.0, 53.0, 225.0, 53.0, 240.0, 53.0, 255.0, 53.0, 270.0, 53.0, 285.0, 53.0, 300.0, 53.0, 315.0, 53.0, 330.0, 53.0, 345.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0})
        Dim TQ6 As New List(Of Double)({53.0, 0.0, 53.0, 15.0, 53.0, 30.0, 53.0, 45.0, 53.0, 60.0, 53.0, 73.51})
        Dim TQ7 As New List(Of Double)({33.54, 296.57, 67.08, 333.43, 60.0, 0.0, 60.0, 180.0, 67.08, 206.57, 33.54, 243.43})
        '  Dim TQ8 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 135.0, 53.0, 150.0, 53.0, 165.0, 53.0, 180.0, 53.0, 195.0, 53.0, 210.0, 53.0, 225.0, 53.0, 240.0, 53.0, 255.0, 53.0, 270.0, 53.0, 285.0, 53.0, 300.0, 53.0, 315.0, 53.0, 330.0, 53.0, 345.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0})
        Dim TQ58 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 135.0, 53.0, 150.0, 53.0, 165.0, 53.0, 180.0, 53.0, 195.0, 53.0, 210.0, 53.0, 225.0, 53.0, 240.0, 53.0, 255.0, 53.0, 270.0, 53.0, 285.0, 53.0, 300.0, 53.0, 315.0, 53.0, 330.0, 53.0, 345.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0})

        Dim TQ9 As New List(Of Double)({33.54, 63.43, 50.0, 36.87})
        Dim TQ10 As New List(Of Double)({50.0, 323.13, 33.54, 296.57})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ24, P34, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P33, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ24, P32, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ58, P33, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ6, P31, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ7, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ58, P31, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ9, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ10, P1, 3.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 23, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 122, 125, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(liP1.ToArray, 79, 121, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 24, 78, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TuyenRaiminBangTrT()
        Dim k(80) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = Tyle * 3.0
        Dim Khoangcach1 As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(0), PllVts(1), PllVts(3), PllVts(4))
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P3 As IPosition71 = P1.Move(Khoangcach1 / 3.3, 270 - Goc1, 0)
        Dim P4 As IPosition71 = P2.Move(Khoangcach1 / 3.3, 90 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({33.54, 116.57, 67.08, 153.43, 60.0, 180.0, 60.0, 0.0, 67.08, 26.57, 33.54, 63.43})
        Dim TQ2 As New List(Of Double)({53.0, 286.49, 53.0, 300.0, 53.0, 320.0, 53.0, 340.0, 53.0, 0.0, 53.0, 20.0, 53.0, 40.0, 53.0, 60.0, 53.0, 73.51})
        Dim TQ3 As New List(Of Double)({53.0, 286.49, 53.0, 300.0, 53.0, 320.0, 53.0, 340.0, 53.0, 359.9, 22.74, 359.9, 22.74, 330.0, 22.74, 300.0, 22.74, 270.0, 22.74, 240.0, 22.74, 210.0, 22.74, 180.0, 22.74, 150.0, 22.74, 120.0, 22.74, 90.0, 22.74, 60.0, 22.74, 30.0, 22.74, 0.0, 53.0, 0.0, 53.0, 20.0, 53.0, 40.0, 53.0, 60.0, 53.0, 73.51})
        Dim TQ4 As New List(Of Double)({33.54, 296.57, 67.08, 333.43, 60.0, 0.0, 60.0, 180.0, 67.08, 206.57, 33.54, 243.43})
        Dim TQ5 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 140.0, 53.0, 160.0, 53.0, 180.0, 53.0, 200.0, 53.0, 220.0, 53.0, 240.0, 53.0, 253.51})
        Dim TQ6 As New List(Of Double)({53.0, 106.49, 53.0, 120.0, 53.0, 140.0, 53.0, 160.0, 53.0, 180.0, 53.0, 200.0, 53.0, 220.0, 53.0, 240.0, 53.0, 253.51})
        Dim TQ7 As New List(Of Double)({33.54, 63.43, 50.0, 36.87})
        Dim TQ8 As New List(Of Double)({50.0, 323.13, 33.54, 296.57})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P4, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P3, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P1, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ5, P3, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ6, P4, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ7, P2, 3.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ8, P1, 3.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 61, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 62, 65, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        loaiKH = "TructhangRaimin"
        mText = FLabel(Pc, 0, FrmMain.fLabelStyleMain.Scale, 0, "", loaiKH, mau, 0, 0, 0, 2)
        SLenhve3DMs()
    End Sub

    Public Sub Tramcapnuoc()
        Dim Goc1 As Double = 0.0
        Dim k(24) As IPosition71
        Dim hesoTyle As Double = 3.0 * Tyle
        For i As Integer = 1 To 12
            k(i) = FrmMain.mPointClick.Move(30.0 * hesoTyle, 30 * (i - 1) + Goc1, 0)
        Next
        k(13) = FrmMain.mPointClick.Move(120.0 * hesoTyle, 45.0 - Goc1, 0)
        k(14) = FrmMain.mPointClick.Move(120.0 * hesoTyle, 135.0 - Goc1, 0)
        k(15) = FrmMain.mPointClick.Move(120.0 * hesoTyle, 225.0 - Goc1, 0)
        k(16) = FrmMain.mPointClick.Move(120.0 * hesoTyle, 315.0 - Goc1, 0)
        k(17) = k(13).Move(Dorongduong * 1.2, 225.0 - Goc1, 0)
        k(18) = k(14).Move(Dorongduong * 1.2, 315.0 - Goc1, 0)
        k(19) = k(15).Move(Dorongduong * 1.2, 45.0 - Goc1, 0)
        k(20) = k(16).Move(Dorongduong * 1.2, 135.0 - Goc1, 0)
        vung = FVungPoint(k, 13, 16, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        vung = FVungPoint(k, 17, 20, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        vung = FVungPoint(k, 1, 12, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(0, 0, 255, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(0, 0, 255, 255), 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

#End Region


#Region "    DacCong"

    Public Sub DoiDC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ1 As New List(Of Double)({98.96, 54.6, 122.47, 59.01, 145.34, 63.43, 167.35, 67.86, 188.36, 72.29, 208.24, 76.72, 226.88, 81.14, 246.46, 86.28, 323.99, 87.17, 317.16, 84.07, 429.06, 90.0, 317.12, 95.87, 323.99, 92.83, 246.46, 93.72, 226.88, 98.86, 208.24, 103.28, 188.36, 107.71, 167.35, 112.14, 145.34, 116.57, 122.47, 120.99, 98.86, 125.42, 74.67, 129.85, 50.03, 134.28, 25.09, 138.7, 0.0, 0.0, 25.09, 41.3, 50.03, 45.72, 74.67, 50.15, 98.86, 54.58, 94.18, 72.3, 73.81, 73.53, 54.27, 78.95, 40.79, 90.0, 54.27, 101.05, 73.81, 106.47, 94.18, 107.7, 114.57, 106.91, 134.61, 105.03, 154.03, 102.5, 172.67, 99.55, 190.37, 96.31, 207.0, 92.88, 219.21, 90.0, 207.0, 87.12, 190.37, 83.69, 172.67, 80.45, 154.03, 77.5, 134.61, 74.97, 114.57, 73.09, 94.28, 72.3, 97.56, 87.2, 113.8, 85.69, 130.37, 85.67, 146.77, 86.66, 162.72, 88.33, 174.32, 90.0, 162.72, 91.67, 146.77, 93.34, 130.37, 94.33, 113.8, 94.31, 97.46, 92.79, 85.68, 90.0, 97.46, 87.21})
        Dim TQ2 As New List(Of Double)({53.73, 78.02, 94.18, 107.7, 114.57, 106.91, 134.61, 105.03, 139.26, 104.36, 83.41, 72.87, 94.28, 72.3, 115.85, 73.23, 173.59, 99.36, 190.37, 96.31, 199.33, 94.37, 154.12, 77.12, 134.87, 74.56, 115.25, 72.65, 94.36, 71.7, 73.65, 72.76})
        Dim TQ3 As New List(Of Double)({54.5, 77.74, 54.5, 102.26, 74.15, 107.34, 73.81, 73.53, 93.21, 72.35, 93.47, 108.35, 115.9, 107.37, 115.9, 72.63, 93.57, 71.66, 74.15, 72.66})
        If Lenhve = "doihoahoc" Or Lenhve = "doiKPHQ" Or Lenhve = "doicongbinh" Then
            vung = FVungPoint(ArrayPoint(TQ1, FrmMain.mPointClick, 2.5, Goc1), 0, 49, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        Else
            vung = FVungPoint(ArrayPoint(TQ1, FrmMain.mPointClick, 2.5, Goc1), 0, 49, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        FVungPoint(ArrayPoint(TQ1, FrmMain.mPointClick, 2.5, Goc1), 29, 62, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)

        If Lenhve = "doicongtacBP" Then
            mText = FLabel(FrmMain.mPointClick, 130.0, Tyle * 2.5, Goc1, "BP", "", mauDen, 0, 0, 2, 2)
        ElseIf Lenhve = "doidaccong" Or Lenhve = "doidaccongnuoc" Or Lenhve = "DChoatrang" Or Lenhve = "doidaccongTC" Then
            mText = FLabel(FrmMain.mPointClick, 130.0, Tyle * 2.5, Goc1, "ĐC", "", mauDen, 0, 0, 2, 2)
        ElseIf Lenhve = "doihoahoc" Then
            mText = FLabel(FrmMain.mPointClick, 130.0, Tyle * 2.5, Goc1, "HH", "", mauDen, 0, 0, 2, 2)
        ElseIf Lenhve = "doicongbinh" Then
            mText = FLabel(FrmMain.mPointClick, 130.0, Tyle * 2.5, Goc1, "CB", "", mauDen, 0, 0, 2, 2)
        ElseIf Lenhve = "doiTShonhop" Or Lenhve = "luonsau" Then
            mText = FLabel(FrmMain.mPointClick, 130.0, Tyle * 2.5, Goc1, "TS", "", mauDen, 0, 0, 2, 2)
        End If
        If Lenhve = "doidaccongnuoc" Then
            FVungPoint(ArrayPoint(TQ2, FrmMain.mPointClick, 2.5, Goc1), 0, 15, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "DChoatrang" Then
            FVungPoint(ArrayPoint(TQ3, FrmMain.mPointClick, 2.5, Goc1), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "doidaccongTC" Then
            TC(FrmMain.mPoint, Goc1)
        ElseIf Lenhve = "doiTShonhop" Or Lenhve = "luonsau" Then
            Lsau(FrmMain.mPointClick, Goc1)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub TC(P As IPosition71, Goc As Double)
        Dim TQ As New List(Of Double)({254.6, 86.4, 255.79, 85.12, 256.77, 83.83, 257.55, 82.54, 258.24, 81.26, 258.83, 80.01, 259.31, 78.8, 259.7, 77.65, 259.99, 76.56, 260.2, 75.54, 260.4, 74.21, 260.48, 73.09, 266.49, 74.46, 271.7, 75.95, 274.58, 77.01, 277.0, 78.11, 278.93, 79.24, 280.37, 80.4, 281.31, 81.57, 281.73, 82.75, 281.64, 83.83, 281.05, 85.11, 279.55, 86.72, 279.55, 93.28, 279.46, 94.02, 279.62, 95.22, 280.12, 96.41, 280.96, 97.58, 282.09, 98.71, 283.49, 99.78, 285.1, 100.79, 286.86, 101.72, 288.69, 102.56, 291.38, 103.63, 293.89, 104.5, 285.51, 104.03, 277.6, 103.28, 272.77, 102.61, 268.37, 101.8, 264.47, 100.87, 261.14, 99.83, 258.45, 98.7, 256.45, 97.48, 255.18, 96.21, 254.65, 94.91, 254.9, 93.6})
        FVungPoint(ArrayPoint(TQ, P, 2.5, Goc), 0, 45, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub Lsau(P As IPosition71, Goc1 As Double)
        Dim TQ As New List(Of Double)({110.04, 108.55, 143.31, 104.14, 104.59, 70.45, 137.72, 75.28, 177.1, 101.4, 196.62, 100.25, 203.34, 96.79, 170.74, 77.48, 84.61, 64.07, 73.64, 68.41})
        FVungPoint(ArrayPoint(TQ, P, 2.5, Goc1), 0, 9, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 3)
    End Sub

    Public Sub DemTS(P1 As IPosition71, hesoTyle As Double, Goc1 As Double)
        Dim TQ As New List(Of Double)({44.74, 359.67, 44.74, 330.0, 44.74, 300.0, 44.74, 270.0, 44.74, 240.0, 44.74, 210.0, 44.74, 180.0, 44.74, 150.0, 44.74, 120.0, 44.74, 90.0, 44.74, 60.0, 44.74, 30.0, 44.74, 0.0, 24.57, 0.0, 24.57, 40.0, 24.57, 80.0, 24.57, 120.0, 24.57, 160.0, 24.57, 200.0, 24.57, 240.0, 24.57, 280.0, 24.57, 320.0, 24.57, 359.21})
        FVungPoint(ArrayPoint(TQ, P1, hesoTyle, Goc1), 0, 22, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub MuiDC()
        Dim k(110) As IPosition71
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({85.09, 40.35, 158.98, 65.93, 176.72, 69.4, 189.34, 72.88, 199.54, 76.81, 207.02, 81.06, 211.63, 85.66, 281.18, 86.74, 274.55, 83.14, 411.67, 90.0, 274.51, 96.78, 281.18, 93.26, 211.63, 94.34, 207.02, 98.94, 199.54, 103.19, 189.34, 107.12, 176.72, 110.6, 158.98, 114.07, 64.85, 180.0, 64.85, 0.0, 85.03, 40.3, 65.11, 57.64, 45.98, 40.72, 45.98, 139.28, 147.36, 103.68, 160.99, 101.81, 168.42, 100.1, 174.55, 97.94, 179.11, 95.46, 181.92, 92.78, 182.87, 90.0, 181.92, 87.22, 179.11, 84.54, 174.55, 82.06, 168.42, 79.9, 160.99, 78.19, 147.36, 76.32, 65.19, 57.68, 55.96, 79.86, 141.89, 86.02, 153.4, 87.12, 156.53, 88.37, 157.65, 90.0, 156.53, 91.63, 155.18, 92.32, 151.3, 93.26, 141.89, 93.98, 55.88, 100.15, 46.23, 39.15, 93.43, 111.9, 130.11, 105.54, 77.01, 63.09, 112.85, 72.01, 164.28, 101.03, 168.42, 100.1, 174.55, 97.94, 179.11, 95.46, 181.92, 92.83, 149.55, 76.13, 55.36, 258.87, 81.99, 247.1, 88.78, 256.18, 102.01, 251.78, 118.59, 264.83, 107.43, 270.0, 118.59, 275.17, 102.01, 288.22, 88.78, 283.82, 81.99, 292.9, 55.36, 281.13, 65.0, 270.0, 15.0, 180.0, 52.2, 253.3, 52.2, 286.7, 15.0, 0.0})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 37, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 21, 47, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        If Lenhve = "muidaccongnuoc" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 48, 58, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "muidaccongcodong" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 59, 70, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 71, 74, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        If Lenhve = "muidaccongTC" Then
            Dim P3 As IPosition71 = FrmMain.mPointClick.Move(-60 * Tyle, 90 - Goc1, 0)
            TC(P3, Goc1)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub ToDC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(75.0 * Tyle * 2.5, 90.0 - Goc1, 0)
        Dim TQ As New List(Of Double)({75.0, 0.0, 75.0, 15.0, 75.0, 30.0, 75.0, 45.0, 75.0, 60.0, 75.0, 75.0, 75.0, 77.58, 136.06, 84.13, 130.95, 76.62, 260.31, 90.0, 131.43, 104.09, 136.31, 96.78, 75.0, 104.35, 75.0, 105.0, 75.0, 120.0, 75.0, 135.0, 75.0, 150.0, 75.0, 175.0, 75.0, 180.0, 75.0, 195.0, 75.0, 210.0, 75.0, 225.0, 75.0, 240.0, 75.0, 255.0, 75.0, 270.0, 75.0, 285.0, 75.0, 300.0, 75.0, 315.0, 75.0, 330.0, 75.0, 345.0, 75.0, 359.82, 44.74, 359.67, 44.74, 330.0, 44.74, 300.0, 44.74, 270.0, 44.74, 240.0, 44.74, 210.0, 44.74, 180.0, 44.74, 150.0, 44.74, 120.0, 44.74, 90.0, 44.74, 60.0, 44.74, 30.0, 44.74, 0.0, 44.74, 340.77, 44.74, 109.23, 44.74, 120.0, 44.74, 135.0, 44.74, 150.0, 44.74, 160.77, 44.74, 289.23, 44.74, 300.0, 44.74, 315.0, 44.74, 330.0})
        If Lenhve = "tohoahoc" Then
            FVungPoint(ArrayPoint(TQ, P1, 2.5, Goc1), 0, 43, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(ArrayPoint(TQ, P1, 2.5, Goc1), 0, 43, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        ' FVungPoint(ArrayPoint(TQ, P1, 2.5, Goc1), 31, 53, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 1)
        FVungPoint(ArrayPoint(TQ, P1, 2.5, Goc1), 31, 53, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        If Lenhve = "todaccongnuoc" Then
            FVungPoint(ArrayPoint(TQ, P1, 2.5, Goc1), 44, 53, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        DemTS(P1, Tyle * 2.5, Goc1)
        Dim mChu As String = String.Empty
        If Lenhve = "tocongtacBP" Then
            mChu = "BP"
        ElseIf Lenhve = "todaccong" Or Lenhve = "todaccongnuoc" Then
            mChu = "ĐC"
        ElseIf Lenhve = "tohoahoc" Then
            mChu = "HH"
        End If
        FLabel(FrmMain.mPointClick, 75.0, Tyle * 2.5, Goc1, mChu, "", mauDen, 0, 0, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub DaccongTCTauNGam()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({110.73, 54.05, 187.57, 69.72, 195.4, 64.21, 222.8, 67.57, 215.96, 72.48, 225.52, 73.25, 235.92, 66.25, 263.65, 68.88, 246.46, 86.28, 254.6, 86.4, 255.79, 85.12, 256.77, 83.83, 257.55, 82.54, 258.24, 81.26, 258.83, 80.01, 259.31, 78.8, 259.7, 77.65, 259.99, 76.56, 260.2, 75.54, 260.4, 74.21, 260.48, 73.09, 266.49, 74.46, 271.7, 75.95, 274.58, 77.01, 277.0, 78.11, 278.93, 79.24, 280.37, 80.4, 281.31, 81.57, 281.73, 82.75, 281.64, 83.83, 281.05, 85.11, 279.55, 86.72, 323.99, 87.17, 317.16, 84.07, 429.06, 90.0, 317.12, 95.87, 323.99, 92.83, 279.55, 93.28, 279.46, 94.02, 279.62, 95.22, 280.12, 96.41, 280.96, 97.58, 282.09, 98.71, 283.49, 99.78, 285.1, 100.79, 286.86, 101.72, 288.69, 102.56, 291.38, 103.63, 293.89, 104.5, 285.51, 104.03, 277.6, 103.28, 272.77, 102.61, 268.37, 101.8, 264.47, 100.87, 261.14, 99.83, 258.45, 98.7, 256.45, 97.48, 255.18, 96.21, 254.65, 94.91, 254.9, 93.6, 246.46, 93.72, 254.39, 104.8, 65.0, 180.0, 83.5, 38.88, 110.65, 54.02, 96.14, 68.65, 80.66, 64.28, 56.57, 128.22, 218.76, 99.21, 218.76, 80.79, 96.23, 68.67, 90.2, 83.63, 191.21, 87.0, 191.21, 93.0, 82.09, 97.0, 90.1, 83.63})
        FLabel(FrmMain.mPointClick, 130.0, Tyle * 2.5, Goc1, "ĐC", "", mauDen, 0, 0, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 70, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 65, 75, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub DCTC()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({246.46, 86.28, 254.6, 86.4, 255.79, 85.12, 256.77, 83.83, 257.55, 82.54, 258.24, 81.26, 258.83, 80.01, 259.31, 78.8, 259.7, 77.65, 259.99, 76.56, 260.2, 75.54, 260.4, 74.21, 260.48, 73.09, 266.49, 74.46, 271.7, 75.95, 274.58, 77.01, 277.0, 78.11, 278.93, 79.24, 280.37, 80.4, 281.31, 81.57, 281.73, 82.75, 281.64, 83.83, 281.05, 85.11, 279.55, 86.72, 323.99, 87.17, 317.16, 84.07, 429.06, 90.0, 317.12, 95.87, 323.99, 92.83, 279.55, 93.28, 279.46, 94.02, 279.62, 95.22, 280.12, 96.41, 280.96, 97.58, 282.09, 98.71, 283.49, 99.78, 285.1, 100.79, 286.86, 101.72, 288.69, 102.56, 291.38, 103.63, 293.89, 104.5, 285.51, 104.03, 277.6, 103.28, 272.77, 102.61, 268.37, 101.8, 264.47, 100.87, 261.14, 99.83, 258.45, 98.7, 256.45, 97.48, 255.18, 96.21, 254.65, 94.91, 254.9, 93.6, 246.46, 93.72, 258.25, 90.0, 110.6, 54.01, 218.16, 72.67, 258.25, 90.0, 218.16, 107.33, 90.04, 136.21, 12.31, 90.0, 90.04, 43.79, 110.52, 53.98, 96.0, 68.62, 84.65, 65.58, 50.16, 90.0, 84.65, 114.42, 196.62, 100.25, 220.4, 90.0, 196.62, 79.75, 96.09, 68.64, 90.05, 83.62, 181.45, 86.84, 188.86, 90.0, 181.45, 93.16, 89.95, 96.38, 81.7, 90.0, 89.95, 83.62})
        FLabel(FrmMain.mPointClick, 140.0, Tyle * 2.5, Goc1, "ĐC", "", mauDen, 0, 0, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 53, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        If Lenhve = "DCTCbangTauNN" Then
            FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 54, 69, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255), 1, "", 1, 1, 0, False, 2, 2)
            Lsau(FrmMain.mPoint, Goc1)
        Else
            vung = FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 54, 69, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        End If
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 62, 76, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub TSTKbatTB() 'good                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       /Public Sub subLuonsau()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(2.74 * 38.0 * Tyle, 90.0 - Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.mPoint.Move(16.71 * 38.0 * Tyle, 90.0 - Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.mPoint.Move(12.41 * 38.0 * Tyle, 90.0 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({5.24, 165.5, 9.78, 112.5, 10.05, 158.0, 8.5, 150.0, 8.5, 165.0, 8.5, 180.0, 8.5, 195.0, 8.5, 210.0, 8.5, 225.0, 8.5, 240.0, 8.5, 255.0, 8.5, 270.0, 8.5, 285.0, 8.5, 300.0, 8.5, 315.0, 8.5, 330.0, 8.5, 345.0, 8.5, 0.0, 8.5, 15.0, 8.5, 30.0, 10.05, 22.0, 9.78, 69.9, 5.24, 14.5, 6.48, 30.0, 6.48, 15.0, 6.48, 0.0, 6.48, 345.0, 6.48, 330.0, 6.48, 315.0, 6.48, 300.0, 6.48, 285.0, 6.48, 270.0, 6.48, 255.0, 6.48, 240.0, 6.48, 225.0, 6.48, 210.0, 6.48, 195.0, 6.48, 180.0, 6.48, 165.0, 6.48, 150.0, 6.48, 30.0, 6.48, 15.0, 6.48, 0.0, 6.48, 345.0, 6.48, 330.0, 6.48, 315.0, 6.48, 300.0, 6.48, 285.0, 6.48, 270.0, 6.48, 255.0, 6.48, 240.0, 6.48, 225.0, 6.48, 210.0, 6.48, 195.0, 6.48, 180.0, 6.48, 165.0, 6.48, 150.0, 5.24, 165.5, 5.27, 180.0, 5.27, 195.0, 5.27, 210.0, 5.27, 225.0, 5.27, 240.0, 5.27, 255.0, 5.27, 270.0, 5.27, 285.0, 5.27, 300.0, 5.27, 315.0, 5.27, 330.0, 5.27, 345.0, 5.27, 0.0, 5.24, 14.5})
        Dim TQ2 As New List(Of Double)({5.47, 330.0, 5.47, 345.0, 5.47, 0.0, 5.47, 15.0, 5.47, 30.0, 5.47, 45.0, 5.47, 60.0, 5.47, 75.0, 5.47, 90.0, 5.47, 105.0, 5.47, 120.0, 5.47, 135.0, 5.47, 150.0, 5.47, 165.0, 5.47, 180.0, 5.47, 195.0, 5.47, 210.0, 3.46, 210.0, 3.46, 195.0, 3.46, 180.0, 3.46, 165.0, 3.46, 150.0, 3.46, 135.0, 3.46, 120.0, 3.46, 105.0, 3.46, 90.0, 3.46, 75.0, 3.46, 60.0, 3.46, 45.0, 3.46, 30.0, 3.46, 15.0, 3.46, 0.0, 3.46, 345.0, 3.46, 330.0})
        Dim TQ3 As New List(Of Double)({1.5, 0, 1.5, 30, 1.5, 60, 1.5, 90, 1.5, 120, 1.5, 150, 1.5, 180, 1.5, 210, 1.5, 240, 1.5, 270, 1.5, 300, 1.5, 330})
        Dim TQ4 As New List(Of Double)({7.48, 300.9, 7.59, 316.2, 2.49, 90, 7.46, 223.6, 7.34, 239.1, 0.97, 270})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 38.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 38.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P3, 38.0, Goc1))
        ArraytoList(liP1, ArrayPoint(TQ4, P2, 38.0, Goc1))
        FVungPoint(liP1.ToArray, 0, 39, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 40, 71, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        If Lenhve = "TSTKbatTB" Then
            FVungPoint(liP1.ToArray, 72, 106, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(liP1.ToArray, 106, 117, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "TSbatcocTB" Then
            FVungPoint(liP1.ToArray, 72, 106, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(liP1.ToArray, 106, 117, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        Else
            FVungPoint(liP1.ToArray, 72, 106, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
            FVungPoint(liP1.ToArray, 106, 117, 4294967295, 0, mau3, 0, mau3, 1, "", 1, 1, 0, False, 2, 2)
        End If

        SLenhve3DMs()
    End Sub

    Public Sub ToanTSDN() 'good                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       /Public Sub subLuonsau()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim TQ As New List(Of Double)({103.89, 123.47, 88.6, 135.38, 74.9, 150.2, 64.23, 169.04, 60.18, 180.0, 60.18, 0.0, 64.23, 10.96, 74.9, 29.8, 88.6, 44.62, 103.89, 56.53, 119.86, 66.47, 135.97, 75.12, 154.0, 84.04, 231.37, 86.03, 225.08, 81.62, 336.29, 90.0, 225.03, 98.28, 231.37, 93.97, 154.0, 95.96, 135.97, 104.88, 119.86, 113.53, 103.89, 123.46, 82.63, 110.27, 98.68, 102.25, 114.44, 95.22, 126.43, 90.0, 114.44, 84.78, 98.68, 77.75, 82.73, 69.63, 41.28, 147.75, 51.03, 133.16, 66.55, 120.05, 82.63, 110.28, 70.04, 93.89, 55.02, 98.91, 45.12, 102.29, 60.7, 81.72, 74.86, 87.9, 81.55, 90.0, 70.03, 93.88})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 32, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 22, 39, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        SLenhve3DMs()
    End Sub

    Public Sub ToTSDN()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(75.0 * Tyle * 2.5, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({75.0, 30.02, 75.0, 45.0, 75.0, 60.0, 75.0, 75.0, 75.0, 77.58, 136.06, 84.13, 130.95, 76.62, 260.31, 90.0, 130.95, 104.09, 136.31, 96.78, 75.0, 105.0, 75.0, 120.0, 75.0, 135.0, 75.0, 150.0, 75.0, 175.0, 75.0, 180.0, 75.0, 195.0, 75.0, 210.0, 75.0, 225.0, 75.0, 240.0, 75.0, 255.0, 75.0, 270.0, 75.0, 285.0, 75.0, 300.0, 75.0, 315.0, 75.0, 330.0, 75.0, 345.0, 75.0, 0.0, 75.0, 30.0, 44.74, 30.0, 44.74, 210.0, 44.74, 190.0, 44.74, 170.0, 44.74, 150.0, 44.74, 130.0, 44.74, 110.0, 44.74, 90.0, 44.74, 70.0, 44.74, 50.0, 44.74, 30.03})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 39, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemTS(P1, Tyle * 2.5, Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub ToTSDQTV()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(75.0 * Tyle * 2.5, 90 - Goc1, 0)
        Dim TQ As New List(Of Double)({75.0, 30.02, 75.0, 45.0, 75.0, 60.0, 75.0, 75.0, 75.0, 77.58, 136.06, 84.13, 130.95, 76.62, 260.31, 90.0, 130.95, 104.09, 136.31, 96.78, 75.0, 105.0, 75.0, 120.0, 75.0, 135.0, 75.0, 150.0, 75.0, 175.0, 75.0, 180.0, 75.0, 195.0, 75.0, 210.0, 75.0, 225.0, 75.0, 240.0, 75.0, 255.0, 75.0, 270.0, 75.0, 285.0, 75.0, 300.0, 75.0, 315.0, 75.0, 330.0, 75.0, 345.0, 75.0, 0.0, 75.0, 30.0, 44.74, 30.0, 44.74, 255.0, 44.74, 240.0, 44.74, 220.0, 44.74, 200.0, 44.74, 180.0, 44.74, 160.0, 44.74, 150.0, 44.74, 30.03, 24.57, 30.08, 24.57, 60.0, 24.57, 90.0, 24.57, 120.0, 24.57, 150.0, 24.57, 180.0, 24.57, 210.0, 24.57, 240.0, 24.57, 270.0, 24.57, 298.62})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 39, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        DemTS(P1, Tyle * 2.5, Goc1)
        SLenhve3DMs()
    End Sub

    Public Sub KVchupanh()
        Dim list1 As New List(Of IPosition71), list2 As New List(Of IPosition71), list3 As New List(Of IPosition71)
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim chieurong As Double = FrmMain.sgworldMain.CoordServices.GetDistance(PllVts(3), PllVts(4), PllVts(6), PllVts(7))
        Dim p1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim p2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P3 As IPosition71 = p1.Move(chieurong, 180 - Goc1, 0)
        Dim P4 As IPosition71 = p2.Move(chieurong, 180.0 - Goc1, 0)
        Dim p11 As IPosition71 = p1.Move(2.3 * Dorongduong * Tyle, 225 - Goc1, 0)
        Dim p21 As IPosition71 = p2.Move(2.3 * Dorongduong * Tyle, 135 - Goc1, 0)
        Dim p31 As IPosition71 = P3.Move(2.3 * Dorongduong * Tyle, 315 - Goc1, 0)
        Dim p41 As IPosition71 = P4.Move(2.3 * Dorongduong * Tyle, 45 - Goc1, 0)
        Dim P5 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((p1.X + p2.X) * 0.5, (p1.Y + p2.Y) * 0.5, 50, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P6 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((P3.X + P4.X) * 0.5, (P3.Y + P4.Y) * 0.5, 50, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P7 As IPosition71 = P5.Move(chieurong / 5, 0 - Goc1, 0)
        Dim P8 As IPosition71 = P6.Move(chieurong / 5, 180 - Goc1, 0)
        Dim P9 As IPosition71 = P5.Move(chieurong / 2, 180 - Goc1, 0)
        list1.Add(p1)
        list1.Add(p2)
        list1.Add(P4)
        list1.Add(P3)
        list1.Add(p1)

        list2.Add(p11)
        list2.Add(p21)
        list2.Add(p41)
        list2.Add(p31)
        list2.Add(p11)

        list3.Add(P7)
        list3.Add(P8)
        mText = FLabel(P9, 0, FrmMain.fLabelStyleMain.Scale * 1.5, Goc1 + 90, "", loaiKH, mau, 1, 1, 1, 2)
        FDuongList(list1, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
        FDuongList(list2, 4294967295, "", 0, 0, mau2, Dorongduong, False, 2, 0, 1) ' 2, False, 2)
        FDuongList(list3, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
        SLenhve3DMs()
    End Sub
#End Region


#Region "    Dubidongvien"

    Public Sub TramTTrung()
        Dim lists1 As New List(Of IPosition71), lists2 As New List(Of IPosition71)
        Dim k(20) As IPosition71
        Dim Kt, Kd As IPosition71
        k(1) = FrmMain.mPointClick.Move(Tyle * 411, 90, 0)
        k(2) = FrmMain.mPointClick.Move(Tyle * 411, 270, 0)
        k(3) = FrmMain.mPointClick.Move(Tyle * 500 / 3, 0, 0)
        k(4) = FrmMain.mPointClick.Move(Tyle * 500 / 3, 180, 0)
        Kt = FrmMain.mPointClick.Move(Tyle * 410 / 8, 0, 0)
        Kd = FrmMain.mPointClick.Move(Tyle * 410 / 8, 180, 0)
        k(5) = Kt.Move(Tyle * 430 - Dorongduong / 2, 90, 0)
        k(6) = Kt.Move(Tyle * 430 - Dorongduong / 2, 270, 0)
        k(7) = Kd.Move(Tyle * 431 - Dorongduong / 2, 90, 0)
        k(8) = Kd.Move(Tyle * 431 - Dorongduong / 2, 270, 0)
        k(9) = Kt.Move(Tyle * 410 / 4, 0, 0)
        k(10) = Kd.Move(Tyle * 410 / 4, 0, 0)
        If Lenhve = "tramtaptrungPTKT" Or Lenhve = "kvttllDongvien" Or Lenhve = "tramtaptrungQNDB" Then
            lists1.Add(k(1))
            lists1.Add(k(2))
        ElseIf Lenhve = "tramtaptrungQNDBcm" Then
            lists1.Add(k(5))
            lists1.Add(k(6))
            lists2.Add(k(7))
            lists2.Add(k(8))
        End If

        Dim mTextture As String, xyScale As Double
        If Lenhve = "daisuquan" Then
            mTextture = "langCD.gif"
            xyScale = 5
        ElseIf Lenhve = "ovatcan" Then
            If FrmMain.cbTa_DP.SelectedIndex = 1 Then
                mTextture = "Haiquannen2.gif"
            Else
                mTextture = "Nenden.gif"
            End If
            xyScale = 7
        Else
            mTextture = ""
            xyScale = 0
        End If

        Dim mauT1 As IColor71, mauT2 As IColor71
        If Lenhve = "diaban" Or Lenhve = "caulacboPD" Or Lenhve = "dienngingo" Or Lenhve = "mucbucxa" Then
            mauT1 = mau3
            mauT2 = mau4
        ElseIf Lenhve = "ovatcan" Or Lenhve = "chuongngaivat" Then
            mauT1 = mauDen
            mauT2 = mauXam
        ElseIf Lenhve = "daisuquan" Then
            mauT1 = FrmMain.sgworldMain.Creator.CreateColor(56, 216, 0, 255)
            mauT2 = FrmMain.sgworldMain.Creator.CreateColor(145, 145, 145, 255)
        Else
            mauT1 = mau
            mauT2 = mau2
        End If
        Dim BkINH As Double
        If Lenhve = "mucbucxa" Then
            BkINH = 100
        Else
            BkINH = 360
        End If
        MCircleTQ(FrmMain.mPointClick, BkINH, 4294967295, Dorongduong * 1.2, mauT1, 1, Nothing, 0, mTextture, xyScale, xyScale, 45, False, 2, 2)
        MCircleTQ(FrmMain.mPointClick, BkINH - Dorongduong / Tyle, 4294967295, Dorongduong * 1.2, mauT2, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
        k(4).Yaw = 0
        If Lenhve = "tramtaptrungPTKT" Then
            mText = FLabel(k(3), 0, FrmMain.fLabelStyleMain.Scale / 2, 0, "PTKT", "", mauDen, 1, 0, 0, 2)
            mText = FLabel(k(4), 0, FrmMain.fLabelStyleMain.Scale, 0, FrmMain.TxtGhichuKH.Text, "", mauDen, 1, 0, 0, 2)
            FDuongList(lists1, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 1) ' 2, False, 2)
        ElseIf Lenhve = "tramtaptrungQNDBcm" Then
            FDuongList(lists1, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
            FDuongList(lists2, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 2) ' 2, False, 2)
            mText = FLabel(k(4), 0, FrmMain.fLabelStyleMain.Scale / 2, 0, FrmMain.TxtGhichuKH.Text, "", mauDen, 1, 0, 0, 2)
            mText = FLabel(k(9), 0, FrmMain.fLabelStyleMain.Scale, 0, "QNDBcm", "", mauDen, 1, 0, 0, 2)
        ElseIf Lenhve = "tramtaptrungQNDB" Then
            mText = FLabel(k(3), 0, FrmMain.fLabelStyleMain.Scale / 2, 0, "QNDB", "", mauDen, 1, 0, 0, 2)
            mText = FLabel(k(4), 0, FrmMain.fLabelStyleMain.Scale, 0, FrmMain.TxtGhichuKH.Text, "", mauDen, 1, 0, 0, 2)
            FDuongList(lists1, 4294967295, "", 0, 0, mau, Dorongduong, False, 2, 0, 1) ' 2, False, 2)
        ElseIf Lenhve = "caulacboPD" Then
            mText = FLabel(FrmMain.mPointClick, 0, FrmMain.fLabelStyleMain.Scale / 2, 0, "A2", "", mauDen, 1, 0, 0, 2)
        ElseIf Lenhve = "diemnong" Then
            MCircleTQ(FrmMain.mPointClick, 250, 4294967295, Dorongduong * 1.2, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            MCircleTQ(FrmMain.mPointClick, 50, 4294967295, Dorongduong * 1.2, mau, 1, Nothing, 0, "", 0, 0, 0, False, 2, 2)
            mText = FLabel(FrmMain.mPointClick, 0, FrmMain.fLabelStyleMain.Scale / 2, 0, "?", "", mauDen, 1, 0, 0, 2)
        End If
        SLenhve3DMs()
    End Sub

    Public Sub XeCuuhoa()
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(110.0 * Tyle * 2.5, 90.0 - Goc1, 0)
        Dim TQ As New List(Of Double)({0.01, 0.0, 100.0, 0.0, 228.43, 64.0, 249.2, 67.5, 266.92, 71.5, 281.15, 75.8, 291.55, 80.4, 297.88, 85.2, 300.0, 90.0, 297.88, 94.8, 291.55, 99.6, 281.15, 104.2, 266.92, 108.5, 249.2, 112.5, 228.43, 116.0, 100.0, 180.0, 0.0, 180.0, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 214.37, 109.04, 186.27, 112.05, 186.3, 67.93, 76.16, 23.2, 30.0, 89.99, 30.0, 90.0, 76.16, 156.8, 214.4, 109.06, 230.85, 106.77, 244.29, 104.03, 255.19, 100.85, 263.21, 97.39, 268.11, 93.74, 269.76, 90.0, 268.11, 86.26, 263.21, 82.61, 255.19, 79.15, 244.29, 75.97, 230.85, 73.23, 214.4, 70.94, 76.16, 23.2, 30.0, 89.99, 55.0, 89.99, 71.06, 50.7, 205.36, 77.3, 226.8, 80.4, 239.95, 84.8, 244.56, 90.0, 239.95, 95.2, 226.8, 99.6, 207.49, 102.7, 71.06, 129.3, 55.0, 90.0})
        Dim TQ1 As New List(Of Double)({25, 0, 25, -30, 25, -60, 25, -90, 25, -120, 25, -150, 25, -180, 25, -210, 25, -240, 25, -270, 25, -300, 25, -330})
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 0, 36, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ, FrmMain.mPointClick, 2.5, Goc1), 37, 64, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ1, P1, 2.5, Goc1), 0, 11, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Public Sub TauChuachay()
        Dim Goc1 As Double = Phuongvi * 180.0 / Math.PI
        Dim P1 As IPosition71 = FrmMain.mPoint.Move(173.3 * Tyle * 3.0, 90.0 - Goc1, 0)
        Dim P2 As IPosition71 = FrmMain.mPoint.Move(346.4 * Tyle * 3.0, 90.0 - Goc1, 0)
        Dim P3 As IPosition71 = FrmMain.mPoint.Move(259.85 * Tyle * 3.0, 90.0 - Goc1, 0)
        Dim TQ1 As New List(Of Double)({100.25, 45.75, 149.34, 50.15, 197.73, 54.58, 244.94, 59.01, 290.69, 63.43, 334.7, 67.86, 376.72, 72.29, 416.49, 76.72, 453.77, 81.14, 488.34, 85.57, 520.0, 90.0, 488.34, 94.43, 453.77, 98.86, 416.49, 103.28, 376.72, 107.71, 334.7, 112.14, 290.69, 116.57, 244.94, 120.99, 197.73, 125.42, 149.34, 129.85, 100.06, 134.28, 50.18, 138.7, 0.0, 0.0, 50.18, 41.3, 100.06, 45.72, 99.95, 63.03, 56.48, 73.38, 39.93, 90.0, 56.48, 106.62, 99.95, 116.97, 145.41, 118.23, 190.74, 116.78, 235.26, 114.19, 278.54, 111.02, 320.25, 107.52, 360.12, 103.81, 397.88, 99.95, 433.3, 96.01, 466.16, 91.99, 480.07, 90.0, 466.16, 88.01, 433.3, 83.99, 397.88, 80.05, 360.12, 76.19, 320.25, 72.48, 278.54, 68.98, 235.26, 65.81, 190.74, 63.22, 145.41, 61.77, 100.15, 63.02, 106.75, 73.43, 146.83, 71.6, 188.43, 70.77, 229.9, 71.85, 270.56, 73.94, 309.93, 76.64, 347.67, 79.72, 383.49, 83.06, 417.13, 86.58, 446.22, 90.0, 417.13, 93.42, 383.49, 96.94, 347.67, 100.28, 309.93, 103.36, 270.56, 106.06, 229.9, 108.15, 188.43, 109.23, 146.83, 108.4, 106.56, 103.51, 73.78, 90.0, 106.56, 73.47})
        FVungPoint(ArrayPoint(TQ1, FrmMain.mPointClick, 3.0, Goc1), 0, 49, 4294967295, 0, mau, 0, mau, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(ArrayPoint(TQ1, FrmMain.mPointClick, 3.0, Goc1), 25, 70, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        MCircleTQ(P1, 50, 4294967295, Dorongduong * 1.2, mauDen, 1, mauDen, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(P2, 50, 4294967295, Dorongduong * 1.2, mauDen, 1, mauDen, 1, "", 0, 0, 0, False, 2, 2)
        MCircleTQ(P3, 50, 4294967295, Dorongduong * 1.2, mauDen, 1, mauDen, 1, "", 0, 0, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub

    Private Sub Cau(P2 As IPosition71, P1 As IPosition71)
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim TQ1 As New List(Of Double)({4.38, 0.0, 9.49, 332.0, 13.16, 340.2, 8.38, 0.0})
        Dim TQ2 As New List(Of Double)({8.38, 0.0, 13.23, 19.7, 9.49, 28.0, 4.38, 0.0, 4.38, 180.0, 9.49, 152.0, 13.16, 160.2, 8.38, 180.0})
        Dim TQ3 As New List(Of Double)({8.38, 173.9, 13.23, 193.6, 9.49, 201.9, 4.38, 180.0})
        Dim liP1 As New List(Of IPosition71)
        ArraytoList(liP1, ArrayPoint(TQ1, P2, 3.0, -Goc1))
        ArraytoList(liP1, ArrayPoint(TQ2, P1, 3.0, -Goc1))
        ArraytoList(liP1, ArrayPoint(TQ3, P2, 20.0, -Goc1))
        FVungPoint(liP1.ToArray, 0, 7, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 2, 5, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        FVungPoint(liP1.ToArray, 8, 15, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        FVungPoint(liP1.ToArray, 10, 13, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
    End Sub

    Public Sub Sap_Cuontroi()
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim goc2 As Double = Goc1 - 2.5
        Dim hesoTyle As Double = 20.0 * Tyle
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim TQ As New List(Of Double)({8.55, 304.9, 11.5, 322.5, 2.12, 0.0, 11.5, 37.5, 8.55, 55.1, 2.12, 90.0, 8.55, 124.9, 11.5, 142.5, 2.12, 180.0, 11.5, 217.5, 8.55, 235.1, 2.12, 270.0, 11.5, 37.5, 8.55, 55.1, 11.5, 217.5, 8.55, 235.1})
        If Lenhve = "caubitroi" Then
            FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1 + 90), 0, 11, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        ElseIf Lenhve = "causap" Then
            FVungPoint(ArrayPoint(TQ, Pc, 40.0, Goc1 + 90), 12, 15, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        End If
        Cau(P2, P1)
    End Sub

    Public Sub Dephanlucham()
        Dim k(40) As IPosition71
        Dim Goc1 As Double = Math.PI - Phuongvi * 180.0 / Math.PI
        Dim hesoTyle As Double = 20.0 * Tyle
        Dim Pc As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition((PllVts(0) + PllVts(3)) * 0.5, (PllVts(1) + PllVts(4)) * 0.5, 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem giua
        Dim P1 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai
        Dim P2 As IPosition71 = FrmMain.sgworldMain.Creator.CreatePosition(PllVts(3), PllVts(4), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben phai =  frmMain.sgworldMain.Creator.CreatePosition(PllVts(0), PllVts(1), 0, AltitudeTypeCode.ATC_PIVOT_RELATIVE, 0, 0, 0, 0) 'Diem ben trai

        k(1) = P1.Move(8.38 * hesoTyle, 0.0 + Goc1, 0)
        k(2) = P1.Move(4.38 * hesoTyle, 0.0 + Goc1, 0)

        k(3) = P2.Move(4.38 * hesoTyle, 0.0 + Goc1, 0)
        k(4) = P2.Move(8.38 * hesoTyle, 0.0 + Goc1, 0)

        k(5) = P2.Move(4.38 * hesoTyle, 180.0 + Goc1, 0)
        k(6) = P2.Move(8.38 * hesoTyle, 180.0 + Goc1, 0)

        k(7) = P1.Move(8.38 * hesoTyle, 180.0 + Goc1, 0)
        k(8) = P1.Move(4.38 * hesoTyle, 180.0 + Goc1, 0)
        Dim goc2 As Double = Goc1 - 2.5
        hesoTyle *= 2.0
        k(11) = Pc.Move(23.94 * hesoTyle, 326.3 + goc2, 0)
        k(12) = Pc.Move(22.36 * hesoTyle, 333.0 + goc2, 0)
        k(13) = Pc.Move(12.99 * hesoTyle, 324.7 + goc2, 0)
        k(14) = Pc.Move(12.99 * hesoTyle, 35.3 + goc2, 0)
        k(15) = Pc.Move(22.36 * hesoTyle, 27.0 + goc2, 0)
        k(16) = Pc.Move(23.94 * hesoTyle, 33.7 + goc2, 0)
        k(17) = Pc.Move(7.33 * hesoTyle, 107.4 + goc2, 0)
        k(18) = Pc.Move(7.33 * hesoTyle, 252.6 + goc2, 0)

        'k(20) = Pc.Move(15.46 * hesothuphong, 327.9 + goc2, 0)
        'k(21) = Pc.Move(15.46 * hesothuphong, 32.1 + goc2, 0)
        'k(22) = Pc.Move(12.99 * hesothuphong, 35.3 + goc2, 0)
        'k(23) = Pc.Move(12.99 * hesothuphong, 324.7 + goc2, 0)
        vung = FVungPoint(k, 1, 4, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        vung = FVungPoint(k, 20, 23, 4294967295, 0, mau2, 0, mau2, 1, "", 1, 1, 0, False, 2, 1)
        vung = FVungPoint(k, 6, 9, 4294967295, 0, mauDen, 0, mauDen, 1, "", 1, 1, 0, False, 2, 2)
        vung = FVungPoint(k, 11, 18, 4294967295, 0, FrmMain.sgworldMain.Creator.CreateColor(0, 255, 255, 255), 0, FrmMain.sgworldMain.Creator.CreateColor(0, 255, 255, 255), 1, "", 1, 1, 0, False, 2, 2)
        SLenhve3DMs()
    End Sub
#End Region

End Module
