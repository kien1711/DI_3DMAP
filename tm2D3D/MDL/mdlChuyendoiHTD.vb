Module mdlChuyendoiHTD

    Public dX As Double, dY As Double, dZ As Double, eX As Double, eY As Double, eZ As Double, dm As Double
    Public e, a, p, c, D, g, k As Double
    Public t, Q, h, w, gL, tb As Double
    Public U, v, sB, cB, n As Double
    Public Pii, r, ao, bo, Z As Double
    Public XG0 As Double, YG0 As Double, Xgt As Double, Ygt As Double
    Public TGX As Double, TGY As Double, TGZ As Double
    Public X20002, Y20002, D_X, D_Y As Double
    Public Delta_X, Delta_Y, Sum_X, Sum_Y As Double
    Const k6 = 0.9996
    Const k3 = 0.9999

    Public Sub BL_XY_2000(ByVal pB As Double, ByVal pL As Double, ByVal Lo As Double, ByRef pX As Double, ByRef pY As Double, ByVal pZone As Integer)
        Dim b As Double, l As Double, xVn As Double, yVn As Double
        ao = 6378137.0#
        bo = 6356752.314245
        r = 6378137.0#

        b = pB
        l = pL
        gL = Lo / 180 * Math.PI

        e = Math.Sqrt((ao ^ 2 - bo ^ 2) / ao ^ 2)
        a = 1 + (3 / 4) * e ^ 2 + (45 / 64) * e ^ 4 + (175 / 256) * e ^ 6 + (11025 / 16384) * e ^ 8
        p = (3 / 4) * e ^ 2 + (15 / 16) * e ^ 4 + (525 / 512) * e ^ 6 + (2205 / 2048) * e ^ 8
        c = (15 / 64) * e ^ 4 + (105 / 256) * e ^ 6 + (2205 / 4096) * e ^ 8
        D = (35 / 512) * e ^ 6 + (315 / 2048) * e ^ 8
        g = (315 / 16384) * e ^ 8

        sB = Math.Sin(b)
        cB = Math.Cos(b)

        n = r / (Math.Sqrt(1 - (e ^ 2) * (sB ^ 2)))
        t = (e ^ 2 / (1 - e ^ 2)) * cB ^ 2
        Q = l - gL
        w = sB / cB

        xVn = r * (1 - e ^ 2) * (a * b - (p / 2) * Math.Sin(2 * b) + (c / 4) * Math.Sin(4 * b) - (D / 6) * Math.Sin(6 * b) + (g / 8) * Math.Sin(8 * b))
        xVn = xVn + (n / 2) * Q ^ 2 * sB * cB + (5 - w ^ 2 + 9 * t + 4 * t ^ 2) * (n / 24) * Q ^ 4 * sB * cB ^ 3
        xVn += (61 - 58 * w ^ 2 + w ^ 4 + 270 * t - 330 * t * w ^ 2) * (n / 720) * Q ^ 6 * sB * cB ^ 5
        yVn = n * Q * cB + (1 - w ^ 2 + t) * (n / 6) * Q ^ 3 * cB ^ 3 + (5 - 18 * w ^ 6 + 14 * t - 58 * t * w ^ 2 + 13 * t ^ 2 - 64 * t ^ 2 * w ^ 2) * (n / 120) * Q ^ 5 * cB ^ 5
        If pZone = 6 Then
            xVn = xVn * k6 - 110 '123
            yVn = yVn * k6 + 500000 + 188 '223
        Else
            If pZone = 3 Then
                xVn = xVn * k3 - 110 '123
                yVn = yVn * k3 + 500000 + 188 '223
            End If
        End If
        pX = xVn
        pY = yVn
    End Sub

    Public Sub XY_BL_2000(ByVal pX As Double, ByVal pY As Double, ByRef pB As Double, ByRef pL As Double, ByRef pL0 As Double, ByVal pZone As Integer)
        Dim b As Double, l As Double, xVn As Double, yVn As Double
        xVn = pX
        yVn = pY
        ao = 6378137.0#
        bo = 6356752.314245
        r = 6378137.0#

        'Call Long_Center
        Dim L0 As Double
        L0 = pL0
        L0 = L0 / 180 * Math.PI

        e = Math.Sqrt((ao ^ 2 - bo ^ 2) / ao ^ 2)
        a = 1 + 3 / 4 * e ^ 2 + 45 / 64 * e ^ 4 + 175 / 256 * e ^ 6 + 11025 / 16384 * e ^ 8
        p = 3 / 4 * e ^ 2 + 15 / 16 * e ^ 4 + 525 / 512 * e ^ 6 + 2205 / 2048 * e ^ 8
        c = 15 / 64 * e ^ 4 + 105 / 256 * e ^ 6 + 2205 / 4096 * e ^ 8
        D = 35 / 512 * e ^ 6 + 315 / 2048 * e ^ 8
        g = 315 / 16384 * e ^ 8

        If pZone = 6 Then
            'If frmMain.txtSogiaDxDy.Text = "" Then
            U = xVn / k6 + 116.52
            v = (yVn - 500000) / k6 - 196.39675 '196.39675
            'Else
            '    U = xVn / k6 + Val(frmMain.txtSogiaDxDy.Text.Split(",")(0))
            '    v = (yVn - 500000) / k6 - Val(frmMain.txtSogiaDxDy.Text.Split(",")(1)) '196.39675
            'End If

        Else
            If pZone = 3 Then
                'If frmMain.txtSogiaDxDy.Text = "" Then
                U = xVn / k3 + 116.52 ' 116.52
                v = (yVn - 500000) / k3 - 196.39675 '196.39675
                'Else
                '    U = xVn / k3 + Val(frmMain.txtSogiaDxDy.Text.Split(",")(0)) ' 116.52
                '    v = (yVn - 500000) / k3 - Val(frmMain.txtSogiaDxDy.Text.Split(",")(1)) '196.39675
                'End If

            End If
        End If
        k = 0.0#
100:
        n = U / (r * (1 - e ^ 2)) + p / 2 * Math.Sin(2 * k) - c / 4 * Math.Sin(4 * k) + D / 6 * Math.Sin(6 * k) - g / 8 * Math.Sin(8 * k)
        n /= a
        t = Math.Abs(n - k)
        k = n
        If t >= 0.000000001 Then GoTo 100
        sB = Math.Sin(k)
        cB = Math.Cos(k)
        w = sB / cB
        n = r / (Math.Sqrt(1 - e ^ 2 * sB ^ 2))
        n = v / n
        t = e ^ 2 / (1 - e ^ 2) * cB ^ 2

        b = k - (1 + t) * w * n ^ 2 / 2 + (5 + 3 * w ^ 2 + 6 * t - 6 * t * w ^ 2) * w * n ^ 4 / 24 - (61 + 90 * w ^ 2 + 45 * w ^ 4) * w * n ^ 6 / 720
        'B = 180 * B / Math.PI
        l = L0 + n / cB - (1 + 2 * w ^ 2 + t) * n ^ 3 / (6 * cB) + (5 + 28 * w ^ 2 + 24 * w ^ 4 + 6 * t + 8 * t * w ^ 2) * n ^ 5 / (120 * cB)
        'L = 180 * L / Math.PI
        pB = b
        pL = l

    End Sub

    Public Sub HTDTracDia_to_HTDVuongGocKhongGian(ByVal pB As Double, ByVal pL As Double, ByVal pH As Double, ByRef pX As Double, ByRef pY As Double, ByRef pZ As Double)
        Dim a_btl As Double, b_btn As Double
        Dim n As Double
        a_btl = 6378137.0#
        b_btn = 6356752.314245
        e = Math.Sqrt((a_btl ^ 2 - b_btn ^ 2) / a_btl ^ 2)
        n = a_btl / Math.Sqrt(1 - (e ^ 2) * (Math.Sin(pB)) ^ 2)
        pX = (n + pH) * Math.Cos(pB) * Math.Cos(pL)
        pY = (n + pH) * Math.Cos(pB) * Math.Sin(pL)
        'pZ = (((b_btn / a_btl) ^ 2) * N + pH) *Math.Sin(pB)
        pZ = (n * (1 - e ^ 2) + pH) * Math.Sin(pB)
    End Sub

    Public Sub HTDVuongGocKhongGian_1_to_2(ByVal pdX As Double, ByVal pdY As Double, ByVal pdZ As Double, ByVal peX As Double, ByVal peY As Double, ByVal peZ As Double, ByVal pdm As Double, ByVal pX1 As Double, ByVal pY1 As Double, ByVal pZ1 As Double, ByRef pX2 As Double, ByRef pY2 As Double, ByRef pZ2 As Double)
        pX2 = pdX + (pX1 + peX * pY1 - peY * pZ1) + pdm * pX1
        pY2 = pdY + (-peZ * pX1 + pY1 + peZ * pZ1) + pdm * pY1
        pZ2 = pdZ + (peY * pX1 + peX * pY1 + pZ1) + pdm * pZ1
    End Sub

    Public Sub HTDVuongGocKhongGian_to_HTDTracDia(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByRef pB As Double, ByRef pL As Double, ByRef pH As Double)
        Dim a_btl As Double, b_btn As Double, e1 As Double, E_vh As Double, K_B As Double, K_H As Double
        a_btl = 6378137.0#
        b_btn = 6356752.314245
        e = Math.Sqrt((a_btl ^ 2 - b_btn ^ 2) / a_btl ^ 2)
        e1 = Math.Sqrt((e ^ 2) / (1 - e ^ 2))
        E_vh = pX ^ 2 + pY ^ 2 + (1 + e1 ^ 2) * pZ ^ 2
        'TINH TRUC TIEP
        K_H = Math.Sqrt(E_vh) / Math.Sqrt(E_vh + (e1 ^ 2) * (1 + e1 ^ 2) * (pZ ^ 2))
        pH = K_H * (Math.Sqrt(E_vh) - a_btl)
        K_B = (1 + e1 ^ 2) * (1 - (e1 ^ 2) * K_H * pH / E_vh)
        pB = Math.Atan(K_B * pZ / Math.Sqrt(pX ^ 2 + pY ^ 2))
        pL = Math.Atan(pY / pX) + Math.PI
        'Console.WriteLine("pX1 " + pX.ToString())
        'Console.WriteLine("pY1 " + pY.ToString())
    End Sub

    Public Sub Chuyendoi_XYZVN2000_to_BLHWGS84(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByRef pB As Double, ByRef pL As Double, ByRef pH As Double, ByVal pL0 As Double, ByVal pZone As Integer)
        Dim x1 As Double, y1 As Double, Z1 As Double
        Dim B1 As Double, L1 As Double, H1 As Double
        Dim x2 As Double, y2 As Double, Z2 As Double
        Dim B2 As Double, L2 As Double, H2 As Double
        'Dim dX1 As Double, dY1 As Double, dZ1 As Double, eX1 As Double, eY1 As Double, eZ1 As Double, dm1 As Double
        dX = -191.90441429
        dY = -39.30318279
        dZ = -111.45032835
        eX = -0.00928836 / 3600.0 / 180.0 * Math.PI
        eY = 0.01975479 / 3600.0 / 180.0 * Math.PI
        eZ = -0.00427372 / 3600.0 / 180.0 * Math.PI
        ' dm = -0.0187831
        dm = -0.0000000187831
        XY_BL_2000(pX, pY, B1, L1, pL0, pZone)
        H1 = pZ
        HTDTracDia_to_HTDVuongGocKhongGian(B1, L1, H1, x1, y1, Z1)
        HTDVuongGocKhongGian_1_to_2(dX, dY, dZ, eX, eY, eZ, dm, x1, y1, Z1, x2, y2, Z2)
        HTDVuongGocKhongGian_to_HTDTracDia(x2, y2, Z2, B2, L2, H2)
        B2 = B2 / Math.PI * 180
        L2 = L2 / Math.PI * 180
        pB = B2
        pL = L2
        pH = H2
    End Sub

    Public Sub XYZVN2000_to_BLHWGS84(ByVal XYZ As Point3D, ByRef BLH As Point3D, ByVal pL0 As Double, ByVal pZone As Integer)
        Chuyendoi_XYZVN2000_to_BLHWGS84(XYZ.Y, XYZ.X, XYZ.Z, BLH.Y, BLH.X, BLH.Z, pL0, pZone)
    End Sub

    Public Sub Chuyendoi_BLHWGS84_to_XYZVN2000(ByVal pB As Double, ByVal pL As Double, ByVal pH As Double, ByRef pX As Double, ByRef pY As Double, ByRef pZ As Double, ByVal pL0 As Double, ByVal pLoaiMuichieu As Integer)
        Dim x1 As Double, y1 As Double, Z1 As Double
        Dim B1 As Double, L1 As Double, H1 As Double
        Dim x2 As Double, y2 As Double, Z2 As Double
        Dim B2 As Double, L2 As Double, H2 As Double
        ' Dim dX1 As Double, dY1 As Double, dZ1 As Double, eX1 As Double, eY1 As Double, eZ1 As Double, dm1 As Double
        dX = 191.90441429
        dY = 39.30318279
        dZ = 111.45032835
        'dm = -0.0187831
        dm = -0.0000000187831
        eX = 0.00928836 / 3600.0 / 180.0 * Math.PI
        eY = -0.01975479 / 3600.0 / 180.0 * Math.PI
        eZ = 0.00427372 / 3600.0 / 180.0 * Math.PI

        B1 = pB
        L1 = pL
        H1 = pH
        'Trac dia WGS84 to Vuong goc khong gian WGS84
        HTDTracDia_to_HTDVuongGocKhongGian(B1, L1, H1, x1, y1, Z1)
        'Vuong goc khong gian WGS84 to vuong goc khong gian VN2000
        HTDVuongGocKhongGian_1_to_2(dX, dY, dZ, eX, eY, eZ, dm, x1, y1, Z1, x2, y2, Z2)
        'Vuong goc khong gian VN2000 to trac dia VN2000
        HTDVuongGocKhongGian_to_HTDTracDia(x2, y2, Z2, B2, L2, H2)
        'BL VN2000 to XY VN2000
        BL_XY_2000(B2, L2, pL0, pX, pY, pLoaiMuichieu)
        pZ = H2
    End Sub

    Public Sub Chuyendoi_BLHWGS84_to_BLHVN2000(ByVal pB As Double, ByVal pL As Double, ByVal pH As Double, ByRef pB2000 As Double, ByRef pL2000 As Double, ByRef pH2000 As Double)
        Dim x1 As Double, y1 As Double, Z1 As Double
        Dim B1 As Double, L1 As Double, H1 As Double
        Dim x2 As Double, y2 As Double, Z2 As Double
        Dim B2 As Double, L2 As Double, H2 As Double

        eX = eX / 3600 / 180 * Math.PI
        eY = eY / 3600 / 180 * Math.PI
        eZ = eZ / 3600 / 180 * Math.PI

        B1 = pB / 180 * Math.PI  'Do_phut_to_Radian(pB)
        L1 = pL / 180 * Math.PI 'Do_phut_to_Radian(pL)
        H1 = pH
        'Trac dia WGS84 to Vuong goc khong gian WGS84
        HTDTracDia_to_HTDVuongGocKhongGian(B1, L1, H1, x1, y1, Z1)
        'Vuong goc khong gian WGS84 to vuong goc khong gian VN2000
        HTDVuongGocKhongGian_1_to_2(dX, dY, dZ, eX, eY, eZ, dm, x1, y1, Z1, x2, y2, Z2)
        'Vuong goc khong gian VN2000 to trac dia VN2000
        HTDVuongGocKhongGian_to_HTDTracDia(x2, y2, Z2, B2, L2, H2)

        pB2000 = B2 / Math.PI * 180
        pL2000 = L2 / Math.PI * 180
        pH2000 = H2

    End Sub

#Disable Warning IDE0060 ' Remove unused parameter
    Public Sub Chuyendoi_BLHWGS84_to_XYZWGS84(ByVal pB As Double, ByVal pL As Double, ByVal pH As Double, ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByVal pL0 As Double, ByVal pLoaiMuichieu As Integer)
#Enable Warning IDE0060 ' Remove unused parameter
        BL_XY_2000(pB, pL, pL0, pX, pY, pLoaiMuichieu)
#Disable Warning IDE0059 ' Unnecessary assignment of a value
        pZ = pH
#Enable Warning IDE0059 ' Unnecessary assignment of a value
    End Sub

    Public Sub BLHWGS84_to_XYZVN2000(ByVal BLH As Point3D, ByRef XYZ As Point3D, ByVal pL0 As Double, ByVal pLoaiMuichieu As Integer)
        Chuyendoi_BLHWGS84_to_XYZVN2000(BLH.X, BLH.Y, BLH.Z, XYZ.Y, XYZ.X, XYZ.Z, pL0, pLoaiMuichieu)
    End Sub

    Public Sub BLHWGS84_to_XYZWGS84(ByVal BLH As Point3D, ByVal XYZ As Point3D, ByVal pL0 As Double, ByVal pLoaiMuichieu As Integer)
        Chuyendoi_BLHWGS84_to_XYZWGS84(BLH.X, BLH.Y, BLH.Z, XYZ.Y, XYZ.X, XYZ.Z, pL0, pLoaiMuichieu)
    End Sub

End Module




