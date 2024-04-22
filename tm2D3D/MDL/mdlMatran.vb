Public Structure Point3D
    Dim X As Double
    Dim Y As Double
    Dim Z As Double
End Structure
Module mdlMatran
#Disable Warning IDE0060 ' Remove unused parameter
    Public Sub NhanhangMt(ByRef Mt() As Double, ByVal socot As Long, ByVal sohang As Long, ByVal hang As Integer, ByVal sonhan As Double)
#Enable Warning IDE0060 ' Remove unused parameter
        Dim i As Long
        For i = 1 To socot
            Mt(socot * (hang - 1) + i) = Mt(socot * (hang - 1) + i) * sonhan
        Next i
    End Sub

#Disable Warning IDE0060 ' Remove unused parameter
    Public Sub ConghangMt(ByRef Mt() As Double, ByVal socot As Long, ByVal sohang As Long, ByVal hangbicong As Long, ByVal hangcong As Long, ByVal heso As Double)
#Enable Warning IDE0060 ' Remove unused parameter
        Dim i As Long
        For i = 1 To socot
            Mt(socot * (hangbicong - 1) + i) = Mt(socot * (hangbicong - 1) + i) + Mt(socot * (hangcong - 1) + i) * heso
        Next i
    End Sub

    Public Sub DoihangMt(ByRef Mt() As Double, ByVal socot As Long, ByVal hang1 As Long, ByVal hang2 As Long)
        Dim i As Long
        Dim trunggian As Double
        For i = 1 To socot
            trunggian = Mt(socot * (hang1 - 1) + i)
            Mt(socot * (hang1 - 1) + i) = Mt(socot * (hang2 - 1) + i)
            Mt(socot * (hang2 - 1) + i) = trunggian
        Next i
    End Sub

    Public Sub NghichdaoMt(ByRef Mtgoc() As Double, ByRef MtND() As Double, ByVal sohang As Long)
        ReDim MtND(0 To sohang * sohang)
        Dim i As Long
        Dim j As Long
        ' Dim k As Long
        ' Dim l As Long

        Dim sonhan As Double
        Dim Max As Double

        For i = 1 To sohang
            MtND((i - 1) * sohang + i) = 1
        Next i

        Dim hangchon As Long
        For i = 1 To sohang - 1
            Max = Math.Abs(Mtgoc((i - 1) * sohang + i))
            hangchon = i
            For j = i + 1 To sohang
                If Math.Abs(Mtgoc((j - 1) * sohang + i)) > Max Then
                    Max = Math.Abs(Mtgoc((j - 1) * sohang + i))
                    hangchon = j
                End If
            Next j
            If hangchon <> i Then
                DoihangMt(Mtgoc, sohang, i, hangchon)
                DoihangMt(MtND, sohang, i, hangchon)
            End If
            For j = i + 1 To sohang
                sonhan = -Mtgoc((j - 1) * sohang + i) / Mtgoc((i - 1) * sohang + i)
                ConghangMt(Mtgoc, sohang, sohang, j, i, sonhan)
                ConghangMt(MtND, sohang, sohang, j, i, sonhan)
            Next j
        Next i

        For i = sohang To 2 Step -1
            For j = i - 1 To 1 Step -1
                sonhan = -Mtgoc((j - 1) * sohang + i) / Mtgoc((i - 1) * sohang + i)
                ConghangMt(Mtgoc, sohang, sohang, j, i, sonhan)
                ConghangMt(MtND, sohang, sohang, j, i, sonhan)
            Next j
        Next i

        For i = 1 To sohang
            sonhan = 1 / Mtgoc((i - 1) * sohang + i)
            NhanhangMt(Mtgoc, sohang, sohang, i, sonhan)
            NhanhangMt(MtND, sohang, sohang, i, sonhan)
        Next i

    End Sub

    Public Sub NghichdaoMttrunggian(ByVal sohang As Long, ByRef MtND() As Double)
        Dim MtTG() As Double
        ReDim MtTG(0 To sohang * sohang)
        Dim i As Long
        ' Dim j As Long
        For i = 2 To sohang - 1
            MtTG((i - 1) * sohang + i - 1) = 1
            MtTG((i - 1) * sohang + i) = 4
            MtTG((i - 1) * sohang + i + 1) = 1
        Next i
        MtTG(1) = 2
        MtTG(2) = 1
        MtTG(sohang * sohang) = 2
        MtTG(sohang * sohang - 1) = 1

        NghichdaoMt(MtTG, MtND, sohang)
    End Sub

    Public Sub Tinhmatrandaohambac1(ByRef P2dSet() As Point3D, ByVal sodiem As Long, ByRef P2dDH1() As Point3D)
        Dim Mt_hieuX() As Double
        ReDim Mt_hieuX(0 To sodiem)
        Dim Mt_hieuY() As Double
        ReDim Mt_hieuY(0 To sodiem)
        ReDim P2dDH1(0 To sodiem)
        Dim i As Long
        Dim j As Long

        For i = 2 To sodiem - 1
            Mt_hieuX(i) = (P2dSet(i + 1).X - P2dSet(i - 1).X) * 3
            Mt_hieuY(i) = (P2dSet(i + 1).Y - P2dSet(i - 1).Y) * 3
        Next i
        Mt_hieuX(1) = (P2dSet(2).X - P2dSet(1).X) * 3
        Mt_hieuY(1) = (P2dSet(2).Y - P2dSet(1).Y) * 3

        Mt_hieuX(sodiem) = (P2dSet(sodiem).X - P2dSet(sodiem - 1).X) * 3
        Mt_hieuY(sodiem) = (P2dSet(sodiem).Y - P2dSet(sodiem - 1).Y) * 3

        Dim MtND() As Double = Nothing
        NghichdaoMttrunggian(sodiem, MtND)

        For i = 1 To sodiem
            P2dDH1(i).X = 0
            P2dDH1(i).Y = 0
        Next i

        For i = 1 To sodiem
            For j = 1 To sodiem
                P2dDH1(i).X = P2dDH1(i).X + MtND((i - 1) * sodiem + j) * Mt_hieuX(j)
                P2dDH1(i).Y = P2dDH1(i).Y + MtND((i - 1) * sodiem + j) * Mt_hieuY(j)
            Next j
        Next i
    End Sub

    Public Sub SplineMt(ByRef P2dSet() As Point3D, ByVal sodiem As Long, ByVal phandoan As Double, ByRef SplPSet() As Point3D, ByRef sodiemSpl As Long)
        ReDim SplPSet(0 To (sodiem - 1) * phandoan + 1)
        Dim i As Long
        Dim j As Long
        Dim t As Double
        Dim Index As Long
        Dim DH1() As Point3D = Nothing
        Dim aX3 As Double, aX2 As Double, aX1 As Double, aX0 As Double
        Dim aY3 As Double, aY2 As Double, aY1 As Double, aY0 As Double

        Tinhmatrandaohambac1(P2dSet, sodiem, DH1)
        For i = 1 To sodiem - 1
            aX3 = 2 * P2dSet(i).X - 2 * P2dSet(i + 1).X + DH1(i).X + DH1(i + 1).X
            aX2 = -3 * P2dSet(i).X + 3 * P2dSet(i + 1).X - 2 * DH1(i).X - DH1(i + 1).X
            aX1 = DH1(i).X
            aX0 = P2dSet(i).X

            aY3 = 2 * P2dSet(i).Y - 2 * P2dSet(i + 1).Y + DH1(i).Y + DH1(i + 1).Y
            aY2 = -3 * P2dSet(i).Y + 3 * P2dSet(i + 1).Y - 2 * DH1(i).Y - DH1(i + 1).Y
            aY1 = DH1(i).Y
            aY0 = P2dSet(i).Y

            Index = (i - 1) * phandoan
            SplPSet(Index + 1).X = P2dSet(i).X
            SplPSet(Index + 1).Y = P2dSet(i).Y
            For j = 2 To phandoan
                t = (j - 1) / phandoan
                SplPSet(Index + j).X = aX3 * t * t * t + aX2 * t * t + aX1 * t + aX0
                SplPSet(Index + j).Y = aY3 * t * t * t + aY2 * t * t + aY1 * t + aY0
            Next j
        Next i
        SplPSet((sodiem - 1) * phandoan + 1).X = P2dSet(sodiem).X
        SplPSet((sodiem - 1) * phandoan + 1).Y = P2dSet(sodiem).Y
        sodiemSpl = (sodiem - 1) * phandoan + 1
    End Sub
End Module
