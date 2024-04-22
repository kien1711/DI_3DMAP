Module mdlVeMT ''Chuan khong can chinh
    Public KCDuoiMT As Double = 0
    Public ta, ata, g As Double

    Public Sub NoisuyMTChuyeu(ByVal pVts() As Point3D, ByRef PVtsKQ1() As Point3D, ByRef PVtsKQ2() As Point3D) ''Chuan, khong sua
        Dim SplPs() As Point3D
        Dim SplPsNum As Long
        ReDim SplPs(0 To 0)
        Dim Ps() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        ReDim Ps(0 To 0)
        Dim SPlPs1T() As Point3D, SPlPs1P() As Point3D, SPlPs2T() As Point3D, SPlPs2P() As Point3D, SPlPs3T() As Point3D, SPlPs3P() As Point3D
        Dim DauMT1(0 To 3) As Point3D, DauMT2(0 To 3) As Point3D, DauMT3(0 To 3) As Point3D
        Dim MTPs() As Point3D ', MTPsNum As Long = 0
        ReDim MTPs(0 To 0)

        ReDim SPlPs1T(0 To 0)
        ReDim SPlPs2T(0 To 0)
        ReDim SPlPs3T(0 To 0)
        ReDim SPlPs1P(0 To 0)
        ReDim SPlPs2P(0 To 0)
        ReDim SPlPs3P(0 To 0)

        Dim Bacco As Integer
        Bacco = 4
        Vmt(pVts, pVts.Length - 1, SplPs, SplPsNum)
        Dim KcDau As Double, KcDuoi As Double, DaiDuoi As Double
        Noi_suy_tham_so(SplPs, SplPsNum, KcDau, KcDuoi, DaiDuoi)
        Noisuy2canh(SplPs, SplPsNum, SPlPs1T, SPlPs1P, KcDau, KcDuoi, Bacco + 3.0, True)
        Noisuy2canh(SplPs, SplPsNum, SPlPs2T, SPlPs2P, KcDau * 2.0 / 5.0, KcDuoi - KcDau * 7.0 / 3.0, Bacco + 3.0, True)
        Noisuy2canh(SplPs, SplPsNum, SPlPs3T, SPlPs3P, KcDau / 5.0, KcDuoi - KcDau * 7.0, Bacco + 8, True)
        Dim PsT11() As Point3D, PsT11Num As Long = 0, PsT12() As Point3D, PsT12Num As Long = 0, PsT13() As Point3D, PsT13Num As Long = 0
        Dim PsP11() As Point3D, PsP11Num As Long = 0, PsP12() As Point3D, PsP12Num As Long = 0, PsP13() As Point3D, PsP13Num As Long = 0
        ReDim PsT11(0 To 0)
        ReDim PsT12(0 To 0)
        ReDim PsT13(0 To 0)
        ReDim PsP11(0 To 0)
        ReDim PsP12(0 To 0)
        ReDim PsP13(0 To 0)
        CopyMangdiem(SPlPs1T, SplPsNum, PsT11, PsT11Num)
        CopyMangdiem(SPlPs2T, SplPsNum, PsT12, PsT12Num)
        CopyMangdiem(SPlPs3T, SplPsNum, PsT13, PsT13Num)

        CopyMangdiem(SPlPs1P, SplPsNum, PsP11, PsP11Num)
        CopyMangdiem(SPlPs2P, SplPsNum, PsP12, PsP12Num)
        CopyMangdiem(SPlPs3P, SplPsNum, PsP13, PsP13Num)

        Cat_duong(PsT11, PsT11Num, 1, KcDau * 11.0#)
        Cat_duong(PsP11, PsP11Num, 1, KcDau * 11.0#)
        Cat_duong(PsT12, PsT12Num, 1, KcDau * 10.0#)
        Cat_duong(PsP12, PsP12Num, 1, KcDau * 10.0#)
        Cat_duong(PsT13, PsT13Num, 1, KcDau * 9.0#)
        Cat_duong(PsP13, PsP13Num, 1, KcDau * 9.0#)

        Dim DauTg1() As Point3D, DauTg2() As Point3D, DauNum As Long = 0
        ReDim DauTg2(0 To 0)

        Ve_dau_2(SplPs, SplPsNum, KcDau, DauMT1)
        ReDim DauTg1(0 To 5)

        DauTg1(1) = PsT11(PsT11Num)
        DauTg1(5) = PsP11(PsP11Num)
        DauTg1(2) = DauMT1(1)
        DauTg1(3) = DauMT1(2)
        DauTg1(4) = DauMT1(3)
        OffsetPolyline(DauTg1, 5, False, DauTg2, DauNum, KcDau / 1.5)

        DauMT2(1) = DauTg2(2)
        DauMT2(2) = DauTg2(3)
        DauMT2(3) = DauTg2(4)

        OffsetPolyline(DauTg1, 5, False, DauTg2, DauNum, KcDau * 2 / 1.5) ''* 2.0 / 1.8)
        DauMT3(1) = DauTg2(2)
        DauMT3(2) = DauTg2(3)
        DauMT3(3) = DauTg2(4)

        Dim PartDau1() As Point3D, PartDau1Num As Long = 0
        Dim PartDau2() As Point3D, PartDau2Num As Long = 0

        ReDim PartDau1(0 To 0)
        ReDim PartDau2(0 To 0)

        Tao_Part_DauMT(PsT11, PsT11Num, DauMT1, PsP11, PsP11Num, PsT12, PsT12Num, DauMT2, PsP12, PsP12Num, PartDau1, PartDau1Num)
        Tao_Part_DauMT(PsT12, PsT12Num, DauMT2, PsP12, PsP12Num, PsT13, PsT13Num, DauMT3, PsP13, PsP13Num, PartDau2, PartDau2Num)
#Disable Warning IDE0059 ' Simplify object initialization
        ReDim PVtsKQ1(0 To PartDau1Num + 5)
        ReDim PVtsKQ2(0 To PartDau2Num + 5)
        PVtsKQ1 = PartDau1
        PVtsKQ2 = PartDau2
    End Sub
#Disable Warning IDE0059
    Public Sub NoisuyMTThuyeu(ByVal pVts() As Point3D, ByRef PVtsKQ1() As Point3D, ByRef PVtsKQ2() As Point3D)
        Dim SplPs() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim SplPsNum As Long
        Dim SPlPs1T() As Point3D = Enumerable.Empty(Of Point3D).ToArray, SPlPs1P() As Point3D = Enumerable.Empty(Of Point3D).ToArray,
            SPlPs2T() As Point3D = Enumerable.Empty(Of Point3D).ToArray, SPlPs2P() As Point3D = Enumerable.Empty(Of Point3D).ToArray,
            SPlPs3T() As Point3D = Enumerable.Empty(Of Point3D).ToArray, SPlPs3P() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim DauMT1(0 To 3) As Point3D, DauMT2(0 To 3) As Point3D, DauMT3(0 To 3) As Point3D

        Dim KcDau As Double, KcDuoi As Double ', DaiDuoi As Double
        KcDau = 0.0001351936 * Tyle * 6.0 ' 3.5
        KcDuoi = KcDau '* 3.0
        Vmt(pVts, pVts.Length - 1, SplPs, SplPsNum)
        Noisuy2canh(SplPs, SplPsNum, SPlPs1T, SPlPs1P, KcDau, KcDuoi, 2, False)
        Noisuy2canh(SplPs, SplPsNum, SPlPs2T, SPlPs2P, KcDau * 2.0 / 3.0, KcDuoi * 0.4, 2, True)
        Noisuy2canh(SplPs, SplPsNum, SPlPs3T, SPlPs3P, KcDau / 3.0, KcDuoi * 7.0, 2, True)
        Dim PsT11() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsT12() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsT13() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim PsP11() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsP12() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsP13() As Point3D = Enumerable.Empty(Of Point3D).ToArray

        Dim PsT11Num As Long, PsP12Num As Long, PsT13Num As Long, PsP13Num As Long, PsP11Num As Long, PsT12Num As Long

        CopyMangdiem(SPlPs1T, SplPsNum, PsT11, PsT11Num)
        CopyMangdiem(SPlPs2T, SplPsNum, PsT12, PsT12Num)
        CopyMangdiem(SPlPs3T, SplPsNum, PsT13, PsT13Num)

        CopyMangdiem(SPlPs1P, SplPsNum, PsP11, PsP11Num)
        CopyMangdiem(SPlPs2P, SplPsNum, PsP12, PsP12Num)
        CopyMangdiem(SPlPs3P, SplPsNum, PsP13, PsP13Num)

        Cat_duong(PsT11, PsT11Num, 1, KcDau * 11.0#)
        Cat_duong(PsP11, PsP11Num, 1, KcDau * 11.0#)
        Cat_duong(PsT12, PsT12Num, 1, KcDau * 10.0#)
        Cat_duong(PsP12, PsP12Num, 1, KcDau * 10.0#)
        Cat_duong(PsT13, PsT13Num, 1, KcDau * 9.0#)
        Cat_duong(PsP13, PsP13Num, 1, KcDau * 9.0#)

        Dim DauTg1() As Point3D = Enumerable.Empty(Of Point3D).ToArray, DauTg2() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim DauNum As Long

        Ve_dau_2(SplPs, SplPsNum, KcDau, DauMT1)
        ReDim DauTg1(0 To 5)

        DauTg1(1) = PsT11(PsT11Num)
        DauTg1(5) = PsP11(PsP11Num)
        DauTg1(2) = DauMT1(1)
        DauTg1(3) = DauMT1(2)
        DauTg1(4) = DauMT1(3)
        OffsetPolyline(DauTg1, 5, False, DauTg2, DauNum, KcDau / 1.5)
        DauMT2(1) = DauTg2(2)
        DauMT2(2) = DauTg2(3)
        DauMT2(3) = DauTg2(4)


        OffsetPolyline(DauTg1, 5, False, DauTg2, DauNum, KcDau * 2.0 / 1.5)
        DauMT3(1) = DauTg2(2)
        DauMT3(2) = DauTg2(3)
        DauMT3(3) = DauTg2(4)

        Dim PartDau1() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PartDau2() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim PartDau1Num As Long, PartDau2Num As Long
        Tao_Part_DauMT(PsT11, PsT11Num, DauMT1, PsP11, PsP11Num, PsT12, PsT12Num, DauMT2, PsP12, PsP12Num, PartDau1, PartDau1Num)
        Dim PsTg1() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim PsTg1Num As Long
        Ghep_mang(PsT12, PsT12Num, 1, DauMT2, 3, 1, PsTg1, PsTg1Num)
        Ghep_mang(PsTg1, PsTg1Num, 1, PsP12, PsP12Num, -1, PartDau2, PartDau2Num)
        LineToPolygon(PartDau2, PartDau2Num)

        ReDim PVtsKQ1(0 To PartDau1Num + 1)
        ReDim PVtsKQ2(0 To PartDau2Num + 1)
        PVtsKQ1 = PartDau1
        PVtsKQ2 = PartDau2
    End Sub

    Public Sub NoisuyDuongdon(ByVal pVts() As Point3D, ByRef PVtsKQ2() As Point3D) 'ByRef PVtsKQ1() As Point3D,
        If slan = True Then
            Exit Sub
        Else
            Dim SplPs() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SplPsNum As Long
            Dim Ps() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SPlPs1T() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SPlPs1P() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SPlPs2T() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SPlPs2P() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SPlPs3T() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim SPlPs3P() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim DauMT1(0 To 3) As Point3D, DauMT2(0 To 3) As Point3D, DauMT3(0 To 3) As Point3D
            Dim KcDau As Double
            If Lenhve = "duongdon" Then
                KcDau = 0.0001351936 * Tyle * 6.0
            Else
                KcDau = 0.0001351936 * Tyle * 0.01
            End If
            Vmt(pVts, pVts.Length - 1, SplPs, SplPsNum)
            Noisuy2canh(SplPs, SplPsNum, SPlPs2T, SPlPs2P, KcDau, KcDau, 8, False)
            Dim PsT11() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsT12() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsT13() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsP11() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsP12() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsT12Num As Long, PsP12Num As Long 'PsT13Num As Long,PsP11Num As Long,
            CopyMangdiem(SPlPs2T, SplPsNum, PsT12, PsT12Num)
            CopyMangdiem(SPlPs2P, SplPsNum, PsP12, PsP12Num)
            Dim DauTg1() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PartDau1() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PartDau2() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsTg1() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PsTg2() As Point3D = Enumerable.Empty(Of Point3D).ToArray
            Dim PartDau2Num As Long = 0, PsTg1Num As Long = 0
            Ghep_mang(PsT12, PsT12Num, 1, DauMT2, 0, 1, PsTg1, PsTg1Num)
            Ghep_mang(PsTg1, PsTg1Num, 1, PsP12, PsP12Num, -1, PartDau2, PartDau2Num)
            LineToPolygon(PartDau2, PartDau2Num)
            ReDim PVtsKQ2(0 To PartDau2Num + 1)
            PVtsKQ2 = PartDau2
        End If
    End Sub

    Public Sub Vmt(ByVal pPs() As Point3D, ByVal pSd As Long, ByRef pSplPs() As Point3D, ByRef pSplPsNum As Long)
        If Lenhve = "muitiencongchuyeu" Or Lenhve = "muitiencongCYngan" Or Lenhve = "muiteincongthuyeu" Or Lenhve = "muiTCngan" Then
            SplineMt(pPs, pSd, 9, pSplPs, pSplPsNum)
        ElseIf Lenhve = "duongdon" Or Lenhve = "hangraobungnhung" Then ' Or Lenhve = "GioituyenHrCD" Or Lenhve = "GioituyenHrKGCC" 
            SplineMt(pPs, pSd, 6 / Tyle, pSplPs, pSplPsNum)
        Else
            SplineMt(pPs, pSd, 5, pSplPs, pSplPsNum)
        End If
        'SplineMt(pPs, pSd, 15, pSplPs, pSplPsNum)
    End Sub

#Disable Warning IDE0060 ' Simplify object initialization
    Public Sub Noi_suy_tham_so(ByVal pSplPs() As Point3D, ByVal pSplPsNum As Long, ByRef pRongDau As Double, ByRef pRongDuoi As Double, ByRef pDaiDuoi As Double)
        If Lenhve = "muitiencongCYngan" Then
            pRongDau = 0.00017
            pRongDuoi = pRongDau * 20
        Else
            pRongDau = KCDuoiMT / 25.0# ' D / 120.0#
            pRongDuoi = pRongDau * 13.0
        End If

        If Lenhve = "muitiencongCYngan" Then
            pDaiDuoi = pRongDuoi / 6.5
        Else
            pDaiDuoi = pRongDuoi
        End If
    End Sub
#Enable Warning IDE0060 ' Function doesn't return a value on all code paths
    Public Function Do_dai_polyline(ByVal pSplPs() As Point3D, ByVal pSplPsNum As Long) As Double
        Dim i As Long
        Dim D As Double
        D = 0
        For i = 1 To pSplPsNum - 1
            D += Tinh_canh(pSplPs(i), pSplPs(i + 1))
        Next i
        Return D
    End Function

    Public Function Tinh_canh(ByVal pP1 As Point3D, ByVal pP2 As Point3D) As Double
        Return Math.Sqrt((pP1.X - pP2.X) * (pP1.X - pP2.X) + (pP1.Y - pP2.Y) * (pP1.Y - pP2.Y))
    End Function

    '************************************************************************************
    'Noi suy 2 canh 2 ben cua duong tim
    '********************************************************************************************
    Public Sub Noisuy2canh(ByVal pPs() As Point3D, ByVal pSd As Long, ByRef pPsT() As Point3D, ByRef pPsP() As Point3D, ByVal pKcDau As Double, ByVal pKcDuoi As Double, ByVal pDoco As Integer, ByVal pDoiDoco As Boolean)
        Dim pv1 As Double
        Dim SplD As Double

        ReDim pPsT(0 To pSd)
        ReDim pPsP(0 To pSd)
        pv1 = TPv(pPs(2).X - pPs(1).X, pPs(2).Y - pPs(1).Y) + Math.PI / 2.0#
        TTd(pv1, pKcDuoi, pPsT(1).X, pPsT(1).Y)
        pPsT(1).X = pPsT(1).X + pPs(1).X
        pPsT(1).Y = pPsT(1).Y + pPs(1).Y

        pPsP(1).X = pPs(1).X * 2 - pPsT(1).X
        pPsP(1).Y = pPs(1).Y * 2 - pPsT(1).Y
        Dim l As Long, i As Long, Kc As Double ' t As Double,
        Dim HsCo As Integer
        If Lenhve = "muitiencongCYngan" Then
            HsCo = pDoco / 2
        Else
            HsCo = pDoco
        End If

        SplD = Do_dai_polyline(pPs, pSd)
        Dim D As Double
        D = 0
        Dim doco As Double
        'Dim IsGiamdoco As Boolean
        'IsGiamdoco = False
        Dim KcDau As Double, KcDuoi As Double
        KcDau = pKcDau
        KcDuoi = pKcDuoi
        Dim Ck As Integer
        Ck = 0
        For l = 2 To pSd - 1
            D += Tinh_canh(pPs(l - 1), pPs(l))

            If D > SplD / 6 And Ck < 1 And pDoiDoco Then
                HsCo = pDoco - 3
                KcDuoi = Kc
                Ck += 1
                D = Tinh_canh(pPs(l - 1), pPs(l))
            End If

            'doco = 1.0
            doco = 0.95
            If HsCo > 0 Then
                For i = 1 To HsCo
                    doco *= (SplD - D) / SplD
                Next i
            End If
            Kc = KcDau + (KcDuoi - KcDau) * doco
            TPg(pPs(l - 1).X, pPs(l - 1).Y, pPs(l).X, pPs(l).Y, pPs(l + 1).X, pPs(l + 1).Y, Kc, pPsT(l).X, pPsT(l).Y)
            pPsP(l).X = pPs(l).X * 2 - pPsT(l).X
            pPsP(l).Y = pPs(l).Y * 2 - pPsT(l).Y
        Next l
        pv1 = TPv(pPs(pSd - 1).X - pPs(pSd).X, pPs(pSd - 1).Y - pPs(pSd).Y) - Math.PI / 2.0#
        TTd(pv1, pKcDau, pPsT(pSd).X, pPsT(pSd).Y)
        pPsT(pSd).X = pPsT(pSd).X + pPs(pSd).X
        pPsT(pSd).Y = pPsT(pSd).Y + pPs(pSd).Y

        pPsP(pSd).X = pPs(pSd).X * 2 - pPsT(pSd).X
        pPsP(pSd).Y = pPs(pSd).Y * 2 - pPsT(pSd).Y
    End Sub

    Public Function TPv(ByVal X As Double, ByVal Y As Double) As Double
        'Dim ta, ata, g As Double
        ta = Y / X
        ata = Math.Atan(ta)
        g = ata
        If X < 0 Then
            g = Math.PI + ata
        End If

        If X > 0 And Y < 0 Then
            g = ata + Math.PI * 2.0#
        End If
        Return g
        ' MsgBox(TPv.ToString)
    End Function

    Public Sub TTd(ByVal pv As Double, ByVal Kc As Double, ByRef X As Double, ByRef Y As Double)
        X = Kc * Math.Cos(pv)
        Y = Kc * Math.Sin(pv)
    End Sub

    Public Sub TPg(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double, ByVal x3 As Double, ByVal y3 As Double, ByVal Kc As Double, ByRef X As Double, ByRef Y As Double)
        Dim pv1, pv3 As Double
        Dim pg As Double
        pv1 = TPv(x1 - x2, y1 - y2)
        pv3 = TPv(x3 - x2, y3 - y2)
        pg = (pv1 + pv3) / 2.0#
        If pv1 < pv3 Then
            pg += Math.PI
        End If
        If pg > 2 * Math.PI Then
            pg -= 2 * Math.PI
        End If
        'Dim g As Double
        g = Math.Abs(pv1 - pv3) / 2

        TTd(pg, Kc / Math.Abs(Math.Sin(g)), X, Y)
        X += x2
        Y += y2
    End Sub

    Public Sub OffsetPolyline(ByVal pPs() As Point3D, ByVal pSd As Long, ByVal pChieu As Boolean, ByRef pPsT() As Point3D, ByRef pPsTNum As Long, ByVal pKC As Double)
        Noisuycanhtrai(pPs, pSd, pChieu, pPsT, pPsTNum, pKC)
    End Sub

    Public Sub Noisuycanhtrai(ByVal pPs() As Point3D, ByVal pSd As Long, ByVal pChieu As Boolean, ByRef pPsT() As Point3D, ByRef pPsTNum As Long, ByVal pKC As Double)
        Dim pv1 As Double
        Dim PsNs() As Point3D
        ReDim PsNs(0 To pSd)
        ReDim pPsT(0 To pSd)
        pPsTNum = pSd
        pv1 = TPv(pPs(2).X - pPs(1).X, pPs(2).Y - pPs(1).Y) + Math.PI / 2.0#
        TTd(pv1, pKC, PsNs(1).X, PsNs(1).Y)
        PsNs(1).X = PsNs(1).X + pPs(1).X
        PsNs(1).Y = PsNs(1).Y + pPs(1).Y
        Dim l As Long
        Dim i As Long
        '  Dim t As Double = 1
        For l = 2 To pSd - 1
            TPg(pPs(l - 1).X, pPs(l - 1).Y, pPs(l).X, pPs(l).Y, pPs(l + 1).X, pPs(l + 1).Y, pKC, PsNs(l).X, PsNs(l).Y)
        Next l
        pv1 = TPv(pPs(pSd - 1).X - pPs(pSd).X, pPs(pSd - 1).Y - pPs(pSd).Y) - Math.PI / 2.0#
        TTd(pv1, pKC, PsNs(pSd).X, PsNs(pSd).Y)
        PsNs(pSd).X = PsNs(pSd).X + pPs(pSd).X
        PsNs(pSd).Y = PsNs(pSd).Y + pPs(pSd).Y

        If pChieu = True Then
            For i = 1 To pSd
                pPsT(i) = PsNs(i)
            Next i
        Else
            For i = 1 To pSd
                pPsT(i).X = pPs(i).X * 2 - PsNs(i).X
                pPsT(i).Y = pPs(i).Y * 2 - PsNs(i).Y
            Next i
        End If
    End Sub

    Public Sub Ve_dau_2(ByVal pSplPs() As Point3D, ByVal pSplPsNum As Long, ByVal pRongDau As Double, ByRef pDauMT() As Point3D)
        Dim pv1 As Double
        Dim NewP As Point3D, NewPT As Point3D, NewPP As Point3D, EndPId As Long
        Dim D As Double
        D = Do_dai_polyline(pSplPs, pSplPsNum)
        Tinh_diem_tren_Polyline(pSplPs, pSplPsNum, D - pRongDau * 6, EndPId, NewP)

        pv1 = TPv(pSplPs(EndPId + 1).X - NewP.X, pSplPs(EndPId + 1).Y - NewP.Y) + Math.PI / 2.0#
        TTd(pv1, pRongDau / 1.5, NewPT.X, NewPT.Y)

        pDauMT(2) = pSplPs(pSplPsNum)

        NewPT.X += NewP.X
        NewPT.Y += NewP.Y

        NewPP.X = NewP.X * 2 - NewPT.X
        NewPP.Y = NewP.Y * 2 - NewPT.Y

        pDauMT(1).X = NewPT.X * 2 - NewP.X
        pDauMT(1).Y = NewPT.Y * 2 - NewP.Y

        pDauMT(3).X = NewPP.X * 2 - NewP.X
        pDauMT(3).Y = NewPP.Y * 2 - NewP.Y

        pDauMT(1).X = -pDauMT(2).X + pDauMT(1).X * 2
        pDauMT(1).Y = -pDauMT(2).Y + pDauMT(1).Y * 2

        pDauMT(3).X = -pDauMT(2).X + pDauMT(3).X * 2
        pDauMT(3).Y = -pDauMT(2).Y + pDauMT(3).Y * 2
    End Sub

    Public Sub Tinh_diem_tren_Polyline(ByVal pSplPs() As Point3D, ByVal pSplPsNum As Long, ByVal pKC As Double, ByRef pEndPId As Long, ByRef pNewP As Point3D)
        Dim TongKC As Double
        Dim i As Long
        TongKC = 0
        i = 1
        While (TongKC < pKC)
            TongKC += Tinh_canh(pSplPs(i), pSplPs(i + 1))
            i += 1
        End While
        pEndPId = i - 1

        Dim D1, D2 As Double
        Dim D As Double
        D = 0
        For i = pEndPId + 1 To pSplPsNum - 1
            D += Tinh_canh(pSplPs(i), pSplPs(i + 1))
        Next i
        D2 = Do_dai_polyline(pSplPs, pSplPsNum) - pKC - D
        D1 = Tinh_canh(pSplPs(pEndPId), pSplPs(pEndPId + 1)) - D2
        'pNewP.X = (D2 * pSplPs(i - 1).X + D1 * pSplPs(i).X) / (D1 + D2)
        'pNewP.Y = (D2 * pSplPs(i - 1).Y + D1 * pSplPs(i).Y) / (D1 + D2)
        pNewP.X = pSplPs(pEndPId + 1).X - (pSplPs(pEndPId + 1).X - pSplPs(pEndPId).X) * D2 / (D1 + D2)
        pNewP.Y = pSplPs(pEndPId + 1).Y - (pSplPs(pEndPId + 1).Y - pSplPs(pEndPId).Y) * D2 / (D1 + D2)
    End Sub

    Public Sub CopyMangdiem(ByVal pPs() As Point3D, ByVal pPsNum As Long, ByRef pCopyPs() As Point3D, ByRef pCopyPsNum As Long)
        pCopyPsNum = pPsNum
        ReDim pCopyPs(0 To pCopyPsNum)
        Dim i As Long
        For i = 1 To pCopyPsNum
            pCopyPs(i) = pPs(i)
        Next i
    End Sub

    Public Sub Cat_duong(ByRef pPs() As Point3D, ByRef pPsNum As Long, ByVal pChieu As Integer, ByVal pKC As Double)
        Dim NewP As Point3D, EndPId As Long
        Dim Kc As Double
        Dim i As Long
        If pChieu > 0 Then
            Kc = Do_dai_polyline(pPs, pPsNum) - pKC
            Tinh_diem_tren_Polyline(pPs, pPsNum, Kc, EndPId, NewP)
            pPsNum = EndPId + 1
            pPs(EndPId + 1) = NewP
        End If

        If pChieu < 0 Then
            Kc = pKC
            Tinh_diem_tren_Polyline(pPs, pPsNum, Kc, EndPId, NewP)
            pPsNum = pPsNum - EndPId + 1
            pPs(1) = NewP
            If EndPId > 1 Then
                For i = 2 To pPsNum
                    pPs(i) = pPs(i + EndPId)
                Next i
            End If
        End If
    End Sub

    Public Sub Tao_Part_DauMT(ByRef pPs11() As Point3D, ByRef pPs11Num As Long, ByRef pDauMT1() As Point3D, ByRef pPs12() As Point3D, ByRef pPs12Num As Long, ByRef pPs21() As Point3D, ByRef pPs21Num As Long, ByRef pDauMT2() As Point3D, ByRef pPs22() As Point3D, ByRef pPs22Num As Long, ByRef pPart() As Point3D, ByRef pPartNum As Long)
        Dim PsTg1() As Point3D, PsTg1Num As Long = 0, PsTg2() As Point3D, PsTg2Num As Long = 0
        ReDim PsTg1(0 To 0)
        ReDim PsTg2(0 To 0)
        Ghep_mang(pPs11, pPs11Num, 1, pDauMT1, 3, 1, PsTg1, PsTg1Num)
        Ghep_mang(PsTg1, PsTg1Num, 1, pPs12, pPs12Num, -1, PsTg2, PsTg2Num)
        Ghep_mang(PsTg2, PsTg2Num, 1, pPs22, pPs22Num, 1, PsTg1, PsTg1Num)
        Ghep_mang(PsTg1, PsTg1Num, 1, pDauMT2, 3, -1, PsTg2, PsTg2Num)
        Ghep_mang(PsTg2, PsTg2Num, -1, pPs21, pPs21Num, 1, pPart, pPartNum)
        LineToPolygon(pPart, pPartNum)
    End Sub

    Public Sub Ghep_mang(ByVal pPs1() As Point3D, ByVal pPs1Num As Long, ByVal pChieu1 As Integer, ByVal pPs2() As Point3D, ByVal pPs2Num As Long, ByVal pChieu2 As Integer, ByRef pPs() As Point3D, ByRef pPsNum As Long)
        Dim i1 As Long, i2 As Long
        pPsNum = pPs1Num + pPs2Num
        ReDim pPs(0 To pPsNum)
        If pChieu1 < 0 Then
            i2 = 1
            For i1 = pPs1Num To 1 Step -1
                pPs(i2) = pPs1(i1)
                i2 += 1
            Next i1
        Else
            For i1 = 1 To pPs1Num
                pPs(i1) = pPs1(i1)
            Next i1
        End If

        If pChieu2 < 0 Then
            i2 = 1
            For i1 = pPs2Num To 1 Step -1
                pPs(i2 + pPs1Num) = pPs2(i1)
                i2 += 1
            Next i1
        Else
            For i1 = 1 To pPs2Num
                pPs(i1 + pPs1Num) = pPs2(i1)
            Next i1
        End If
    End Sub

    Public Sub LineToPolygon(ByRef LinePs() As Point3D, ByRef LinePsNum As Long)
        LinePsNum += 1
        ReDim Preserve LinePs(0 To LinePsNum)
        LinePs(LinePsNum) = LinePs(1)
    End Sub

    Public Function NsHRKG(ByVal pMHTimPSet() As Point3D, ByVal radius As Double, pitch As Double) As Point3D()
        'Tot khong chinh
        Dim pMHPSet() As Point3D = Enumerable.Empty(Of Point3D).ToArray
        Dim N As Integer
        Dim t As Double, a As Double, i1 As Double, j1 As Double, g As Double, sections As Double, offset As Double
        N = 0
        sections = 6
        offset = 10.0 * radius
        Dim i As Long '= 0
        a = 0.0#
        Dim tsc As Integer
        tsc = 1
        Dim V1 As Point3D, V2 As Point3D
        Dim V11 As Point3D, V12 As Point3D, V21 As Point3D, V22 As Point3D
        For i = 0 To pMHTimPSet.Count - 2
            V1 = pMHTimPSet(i)
            V1.Z *= tsc
            V2 = pMHTimPSet(i + 1)
            V2.Z *= tsc
            If (V2.X <> V1.X) Then
                t = Math.Atan((V2.Y - V1.Y) / (V2.X - V1.X))
                If ((V2.X - V1.X) < 0) Then
                    t += Math.PI
                End If
            Else
                t = 0
            End If

            If ((V2.X <> V1.X) Or (V2.Y <> V1.Y)) Then
                a = Math.Atan((V2.Z - V1.Z) / Math.Sqrt((V2.X - V1.X) * (V2.X - V1.X) + (V2.Y - V1.Y) * (V2.Y - V1.Y)))
            End If
            i1 = Math.Sqrt((V2.X - V1.X) * (V2.X - V1.X) + (V2.Y - V1.Y) * (V2.Y - V1.Y) + (V2.Z - V1.Z) * (V2.Z - V1.Z)) / (pitch / sections)
            ' j1 = 0
            For j1 = 0 To i1
                g = j1 * Math.PI * 2 / sections
                If (g > Math.PI * 2) Then
                    g -= Math.PI * 2
                End If

                V11.X = radius * Math.Sin(g)
                V11.Y = radius * Math.Cos(g)
                V11.Z = j1 * pitch / sections
                V12.X = radius * Math.Sin(g + Math.PI * 2 / sections)
                V12.Y = radius * Math.Cos(g + Math.PI * 2 / sections)
                V12.Z = (j1 + 1) * pitch / sections
                If ((V2.X <> V1.X) Or (V2.Y <> V1.Y)) Then
                    If ((Math.Sin(t) = 0) Or (Math.Sin(a) = 0)) Then
                        If ((Math.Sin(t) = 0) And (Math.Sin(a) = 0)) Then
                            V21.X = -V11.Z / (Math.Cos(t) * Math.Cos(a))
                            V21.Y = V11.X / Math.Cos(t)
                            V21.Z = V11.Y / Math.Cos(a)

                            V22.X = -V12.Z / (Math.Cos(t) * Math.Cos(a))
                            V22.Y = V12.X / Math.Cos(t)
                            V22.Z = V12.Y / Math.Cos(a)
                        Else
                            If (Math.Sin(t) = 0) Then
                                V21.X = (V11.Y * Math.Sin(a) + V11.Z * Math.Cos(a)) / Math.Cos(t)
                                V21.Y = V11.X / Math.Cos(t)
                                V21.Z = (-V11.Z - V21.X * Math.Cos(t) * Math.Cos(a)) / Math.Sin(a)

                                V22.X = (V12.Y * Math.Sin(a) + V12.Z * Math.Cos(a)) / Math.Cos(t)
                                V22.Y = V12.X / Math.Cos(t)
                                V22.Z = (-V12.Z - V22.X * Math.Cos(t) * Math.Cos(a)) / Math.Sin(a)
                            End If
                            If (Math.Sin(a) = 0) Then
                                V21.X = -(V11.X * Math.Sin(t) * Math.Cos(a) + V11.Z * Math.Cos(t)) / Math.Cos(a)
                                V21.Y = -(V11.Z + V21.X * Math.Cos(t) * Math.Cos(a)) / (Math.Sin(t) * Math.Cos(a))
                                V21.Z = V11.Y / Math.Cos(a)
                                V22.X = -(V12.X * Math.Sin(t) * Math.Cos(a) + V12.Z * Math.Cos(t)) / Math.Cos(a)
                                V22.Y = -(V12.Z + V22.X * Math.Cos(t) * Math.Cos(a)) / (Math.Sin(t) * Math.Cos(a))
                                V22.Z = V12.Y / Math.Cos(a)
                            End If
                        End If
                    Else
                        V21.Z = V11.Y * Math.Cos(a) - V11.Z * Math.Sin(a)
                        V21.Y = (-V11.Y * Math.Sin(t) + V11.X * Math.Cos(t) * Math.Sin(a) + V21.Z * Math.Cos(a) * Math.Sin(t)) / Math.Sin(a)
                        V21.X = (V21.Y * Math.Cos(t) - V11.X) / Math.Sin(t)
                        V22.Z = V12.Y * Math.Cos(a) - V12.Z * Math.Sin(a)
                        V22.Y = (-V12.Y * Math.Sin(t) + V12.X * Math.Cos(t) * Math.Sin(a) + V22.Z * Math.Cos(a) * Math.Sin(t)) / Math.Sin(a)
                        V22.X = (V22.Y * Math.Cos(t) - V12.X) / Math.Sin(t)
                    End If
                Else
                    If (V1.Z < V2.Z) Then
                        V21.X = -V11.X
                        V21.Y = -V11.Y
                        V21.Z = -V11.Z
                        V22.X = -V12.X
                        V22.Y = -V12.Y
                        V22.Z = -V12.Z
                    Else
                        V21 = V11
                        V21.Z = V21.Z
                        V22 = V12
                        V22.Z = V22.Z
                    End If
                End If
                If N = 0 Then
                    V21.X = -V21.X + V1.X
                    V21.Y = -V21.Y + V1.Y
                    V21.Z = (-V21.Z + V1.Z) + offset
                    N += 1
                    ReDim Preserve pMHPSet(0 To N)
                    pMHPSet(N) = V21
                End If

                V22.X = -V22.X + V1.X
                V22.Y = -V22.Y + V1.Y
                V22.Z = (-V22.Z + V1.Z) + offset
                N += 1
                ReDim Preserve pMHPSet(0 To N)
                pMHPSet(N) = V22
            Next j1
        Next i
        NsHRKG = pMHPSet
    End Function

End Module



'Public Function mHR(ByVal pMHTimPSet() As Point3D, ByVal radius As Double, pitch As Double) As Point3D()
'    'Tot khong chinh
'    Dim pMHPSet() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim pMHPNum As Integer = 0, N As Integer = 0
'    Dim i As Long, t As Double, a As Double, i1 As Double, j1 As Double, g As Double ' j As Long,, l As Long
'    Dim sections As Double = 0
'    Dim offset As Double
'    N = 0
'    sections = 6
'    offset = 10.0 * radius
'    i = 0
'    ' l = 0
'    t = 0.0#
'    a = 0.0#
'    i1 = 0.0#
'    Dim tsc As Integer
'    tsc = 1
'    Dim V1 As Point3D, V2 As Point3D
'    Dim V11 As Point3D, V12 As Point3D, V21 As Point3D, V22 As Point3D

'    For i = 0 To pMHTimPSet.Count - 2
'        V1 = pMHTimPSet(i)
'        V1.Z = V1.Z * tsc
'        V2 = pMHTimPSet(i + 1)
'        V2.Z = V2.Z * tsc

'        If (V2.X <> V1.X) Then
'            t = Math.Atan((V2.Y - V1.Y) / (V2.X - V1.X))
'            If ((V2.X - V1.X) < 0) Then
'                t = t + Math.PI
'            End If
'        Else
'            t = 0
'        End If

'        If ((V2.X <> V1.X) Or (V2.Y <> V1.Y)) Then
'            a = Math.Atan((V2.Z - V1.Z) / Math.Sqrt((V2.X - V1.X) * (V2.X - V1.X) + (V2.Y - V1.Y) * (V2.Y - V1.Y)))
'        End If

'        i1 = Math.Sqrt((V2.X - V1.X) * (V2.X - V1.X) + (V2.Y - V1.Y) * (V2.Y - V1.Y) + (V2.Z - V1.Z) * (V2.Z - V1.Z)) / (pitch / sections)
'        j1 = 0
'        For j1 = 0 To i1
'            g = j1 * Math.PI * 2 / sections
'            If (g > Math.PI * 2) Then
'                g = g - Math.PI * 2
'            End If

'            V11.X = radius * Math.Sin(g)
'            V11.Y = radius * Math.Cos(g)
'            V11.Z = j1 * pitch / sections
'            V12.X = radius * Math.Sin(g + Math.PI * 2 / sections)
'            V12.Y = radius * Math.Cos(g + Math.PI * 2 / sections)
'            V12.Z = (j1 + 1) * pitch / sections

'            If ((V2.X <> V1.X) Or (V2.Y <> V1.Y)) Then
'                If ((Math.Sin(t) = 0) Or (Math.Sin(a) = 0)) Then
'                    If ((Math.Sin(t) = 0) And (Math.Sin(a) = 0)) Then
'                        V21.X = -V11.Z / (Math.Cos(t) * Math.Cos(a))
'                        V21.Y = V11.X / Math.Cos(t)
'                        V21.Z = V11.Y / Math.Cos(a)

'                        V22.X = -V12.Z / (Math.Cos(t) * Math.Cos(a))
'                        V22.Y = V12.X / Math.Cos(t)
'                        V22.Z = V12.Y / Math.Cos(a)
'                    Else
'                        If (Math.Sin(t) = 0) Then
'                            V21.X = (V11.Y * Math.Sin(a) + V11.Z * Math.Cos(a)) / Math.Cos(t)
'                            V21.Y = V11.X / Math.Cos(t)
'                            V21.Z = (-V11.Z - V21.X * Math.Cos(t) * Math.Cos(a)) / Math.Sin(a)

'                            V22.X = (V12.Y * Math.Sin(a) + V12.Z * Math.Cos(a)) / Math.Cos(t)
'                            V22.Y = V12.X / Math.Cos(t)
'                            V22.Z = (-V12.Z - V22.X * Math.Cos(t) * Math.Cos(a)) / Math.Sin(a)
'                        End If
'                        If (Math.Sin(a) = 0) Then
'                            V21.X = -(V11.X * Math.Sin(t) * Math.Cos(a) + V11.Z * Math.Cos(t)) / Math.Cos(a)
'                            V21.Y = -(V11.Z + V21.X * Math.Cos(t) * Math.Cos(a)) / (Math.Sin(t) * Math.Cos(a))
'                            V21.Z = V11.Y / Math.Cos(a)
'                            V22.X = -(V12.X * Math.Sin(t) * Math.Cos(a) + V12.Z * Math.Cos(t)) / Math.Cos(a)
'                            V22.Y = -(V12.Z + V22.X * Math.Cos(t) * Math.Cos(a)) / (Math.Sin(t) * Math.Cos(a))
'                            V22.Z = V12.Y / Math.Cos(a)
'                        End If
'                    End If
'                Else
'                    V21.Z = V11.Y * Math.Cos(a) - V11.Z * Math.Sin(a)
'                    V21.Y = (-V11.Y * Math.Sin(t) + V11.X * Math.Cos(t) * Math.Sin(a) + V21.Z * Math.Cos(a) * Math.Sin(t)) / Math.Sin(a)
'                    V21.X = (V21.Y * Math.Cos(t) - V11.X) / Math.Sin(t)
'                    V22.Z = V12.Y * Math.Cos(a) - V12.Z * Math.Sin(a)
'                    V22.Y = (-V12.Y * Math.Sin(t) + V12.X * Math.Cos(t) * Math.Sin(a) + V22.Z * Math.Cos(a) * Math.Sin(t)) / Math.Sin(a)
'                    V22.X = (V22.Y * Math.Cos(t) - V12.X) / Math.Sin(t)
'                End If
'            Else
'                If (V1.Z < V2.Z) Then
'                    V21.X = -V11.X
'                    V21.Y = -V11.Y
'                    V21.Z = -V11.Z
'                    V22.X = -V12.X
'                    V22.Y = -V12.Y
'                    V22.Z = -V12.Z
'                Else
'                    V21 = V11
'                    V21.Z = V21.Z
'                    V22 = V12
'                    V22.Z = V22.Z
'                End If
'            End If

'            If N = 0 Then
'                V21.X = -V21.X + V1.X
'                V21.Y = -V21.Y + V1.Y
'                V21.Z = (-V21.Z + V1.Z) + offset
'                N = N + 1
'                ReDim Preserve pMHPSet(0 To N)
'                pMHPSet(N) = V21
'            End If

'            V22.X = -V22.X + V1.X
'            V22.Y = -V22.Y + V1.Y
'            V22.Z = (-V22.Z + V1.Z) + offset
'            N = N + 1
'            ReDim Preserve pMHPSet(0 To N)
'            pMHPSet(N) = V22
'        Next j1
'    Next i
'    pMHPNum = N
'    mHR = pMHPSet
'End Function

'Public Sub NoisuyTim(ByVal pVts() As Point3D, ByRef PVtsKQ2() As Point3D) 'ByRef PVtsKQ1() As Point3D,
'    Dim SplPs() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim SplPsNum As Long
'    Dim SPlPs1T() As Point3D = Enumerable.Empty(Of Point3D).ToArray, SPlPs1P() As Point3D = Enumerable.Empty(Of Point3D).ToArray,
'        SPlPs2T() As Point3D = Enumerable.Empty(Of Point3D).ToArray, SPlPs2P() As Point3D = Enumerable.Empty(Of Point3D).ToArray,
'        SPlPs3T() As Point3D = Enumerable.Empty(Of Point3D).ToArray, SPlPs3P() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim DauMT1(0 To 3) As Point3D, DauMT2(0 To 3) As Point3D, DauMT3(0 To 3) As Point3D

'    Dim KcDau As Double, KcDuoi As Double ', DaiDuoi As Double
'    KcDau = 0.0001351936 * Tyle * 1.0 ' 3.5
'    KcDuoi = KcDau
'    Vmt(pVts, pVts.Length - 1, SplPs, SplPsNum)
'    Noisuy2canh(SplPs, SplPsNum, SPlPs1T, SPlPs1P, KcDau, KcDuoi, 2, False)
'    Noisuy2canh(SplPs, SplPsNum, SPlPs2T, SPlPs2P, KcDau * 2 / 3, KcDuoi * 2 / 3, 2, False)
'    Noisuy2canh(SplPs, SplPsNum, SPlPs3T, SPlPs3P, KcDau / 3, KcDuoi / 2, 2, False)

'    Dim PsT11() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsT12() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsT13() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim PsP11() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsP12() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PsP13() As Point3D = Enumerable.Empty(Of Point3D).ToArray

'    Dim PsT11Num As Long, PsP12Num As Long, PsT13Num As Long, PsP13Num As Long, PsP11Num As Long, PsT12Num As Long

'    CopyMangdiem(SPlPs1T, SplPsNum, PsT11, PsT11Num)
'    CopyMangdiem(SPlPs2T, SplPsNum, PsT12, PsT12Num)
'    CopyMangdiem(SPlPs3T, SplPsNum, PsT13, PsT13Num)

'    CopyMangdiem(SPlPs1P, SplPsNum, PsP11, PsP11Num)
'    CopyMangdiem(SPlPs2P, SplPsNum, PsP12, PsP12Num)
'    CopyMangdiem(SPlPs3P, SplPsNum, PsP13, PsP13Num)

'    Cat_duong(PsT11, PsT11Num, 1, KcDau * 11.0#)
'    Cat_duong(PsP11, PsP11Num, 1, KcDau * 11.0#)
'    Cat_duong(PsT12, PsT12Num, 1, KcDau * 10.0#)
'    Cat_duong(PsP12, PsP12Num, 1, KcDau * 10.0#)
'    Cat_duong(PsT13, PsT13Num, 1, KcDau * 9.0#)
'    Cat_duong(PsP13, PsP13Num, 1, KcDau * 9.0#)

'    Dim DauTg1() As Point3D = Enumerable.Empty(Of Point3D).ToArray, DauTg2() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim DauNum As Long

'    Ve_dau_2(SplPs, SplPsNum, KcDau, DauMT1)
'    ReDim DauTg1(0 To 5)

'    DauTg1(1) = PsT11(PsT11Num)
'    DauTg1(5) = PsP11(PsP11Num)
'    DauTg1(2) = DauMT1(1)
'    DauTg1(3) = DauMT1(2)
'    DauTg1(4) = DauMT1(3)
'    OffsetPolyline(DauTg1, 5, False, DauTg2, DauNum, KcDau / 3.0)
'    DauMT2(1) = DauTg2(2)
'    DauMT2(2) = DauTg2(3)
'    DauMT2(3) = DauTg2(4)

'    OffsetPolyline(DauTg1, 5, False, DauTg2, DauNum, KcDau * 2.0 / 3.0)
'    DauMT3(1) = DauTg2(2)
'    DauMT3(2) = DauTg2(3)
'    DauMT3(3) = DauTg2(4)

'    Dim PartDau1() As Point3D = Enumerable.Empty(Of Point3D).ToArray, PartDau2() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim PartDau1Num As Long, PartDau2Num As Long
'    Tao_Part_DauMT(PsT11, PsT11Num, DauMT1, PsP11, PsP11Num, PsT12, PsT12Num, DauMT2, PsP12, PsP12Num, PartDau1, PartDau1Num)
'    Dim PsTg1() As Point3D = Enumerable.Empty(Of Point3D).ToArray
'    Dim PsTg1Num As Long
'    Ghep_mang(PsT12, PsT12Num, 1, DauMT2, 3, 1, PsTg1, PsTg1Num)
'    Ghep_mang(PsTg1, PsTg1Num, 1, PsP12, PsP12Num, -1, PartDau2, PartDau2Num)
'    LineToPolygon(PartDau2, PartDau2Num)
'    ReDim PVtsKQ2(0 To PartDau2Num + 1)
'    PVtsKQ2 = PartDau2
'End Sub