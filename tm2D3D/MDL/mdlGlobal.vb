Module mdlGlobal
    Public Function Chianhodoanthang2D(ByVal Pt1 As Point3D, ByVal Pt2 As Point3D, ByVal DeltaD As Double) As Point3D()
        Dim LinePts() As Point3D
        ReDim LinePts(0 To 1)
        LinePts(1) = Pt1

        Dim D1 As Double, D2 As Double
        Dim D As Double = Math.Sqrt(Math.Pow((Pt1.X - Pt2.X), 2) + Math.Sqrt(Math.Pow((Pt1.Y - Pt2.Y), 2)))
        D2 = D
        Dim i As Double = 0
        While (D2 > DeltaD)
            i += 1
            D1 = DeltaD * i
            D2 = D - D1
            Dim Pt As Point3D
            Pt.X = Pt1.X - D1 / D * (Pt1.X - Pt2.X)
            Pt.Y = Pt1.Y - D1 / D * (Pt1.Y - Pt2.Y)
            ReDim Preserve LinePts(0 To i + 1)
            LinePts(i + 1) = Pt
        End While

        ReDim Preserve LinePts(0 To i + 2)
        LinePts(i + 2) = Pt2
        Return LinePts
    End Function

    Public Function Chianhoduonggapkhuc2D(ByVal LinePts() As Point3D, ByVal DeltaD As Double) As Point3D()
        Dim KQLinePts() As Point3D
        ReDim KQLinePts(0 To 1)

        Dim Pt1 As Point3D, Pt2 As Point3D
        Dim LinePts1() As Point3D

        Dim i1 As Integer, i2 As Integer, i3 As Integer = 0
        For i1 = 1 To LinePts.Length - 2
            Pt1 = LinePts(i1)
            Pt2 = LinePts(i1 + 1)
            LinePts1 = Chianhodoanthang2D(Pt1, Pt2, DeltaD)
            For i2 = 1 To LinePts1.Length - 2
                i3 += 1
                ReDim Preserve KQLinePts(0 To i3)
                KQLinePts(i3) = LinePts1(i2)
            Next i2
        Next i1

        ReDim Preserve KQLinePts(0 To i3 + 1)
        KQLinePts(i3 + 1) = LinePts(LinePts.Length - 1)
        Return KQLinePts
    End Function

    Public Sub ThemphantuvaoMangLine(ByVal InsertLinePts() As Point3D, ByRef LinePts() As Point3D)
        Dim i As Integer
        Dim PtCount As Integer = LinePts.Length - 1
        For i = 1 To InsertLinePts.Length - 1
            ReDim Preserve LinePts(PtCount + i)
            LinePts(PtCount + i) = InsertLinePts(i)

        Next i
    End Sub
End Module
