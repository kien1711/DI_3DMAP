
Public Class LineBusiness

    Public point1 As Point3D
    Public point2 As Point3D
    '#Disable Warning IDE0017 ' Simplify object initialization
    '#Disable Warning IDE0140 ' Simplify object initialization
    Public ReadOnly Property Length() As Double
        Get
            Return Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2))
        End Get
    End Property

    Public Sub New(ByVal X1 As Double, ByVal Y1 As Double, ByVal X2 As Double, ByVal Y2 As Double)
        point1 = New Point3D()
        point1.X = X1
        point1.Y = Y1
        point2 = New Point3D()
        point2.X = X2
        point2.Y = Y2
    End Sub

    Public Function CreatePolygonPoints(ByVal points As List(Of Point3D), ByVal distance As Double) As List(Of Point3D)
        Dim result As New List(Of Point3D) From {points(0)}, tempList As New List(Of Point3D)
        result.Add(points(0))
        Dim tempPoint As Point3D
        Dim tempPoint2 As Point3D
        For i As Integer = 1 To points.Count - 1
            result.Add(points(i))
            tempPoint = CreatePoint(points(i - 1), points(i), distance)
            If tempList.Count > 0 Then
                If CalculateAngle(points(i - 2), points(i - 1), points(i), tempPoint2, tempPoint) Then
                    Dim point As Point3D = New Point3D()
                    point.X = (tempPoint.X + tempPoint2.X) / 2
                    point.Y = (tempPoint.Y + tempPoint2.Y) / 2
                    point = IntersectinoCircleLine(points(i - 1), distance, points(i - 1), point, -1)
                    If Not SameSide(points(i - 2), points(i - 1), tempList(tempList.Count - 1), point) Then
                        point = IntersectinoCircleLine(points(i - 1), distance, points(i - 1), point, 1)
                    End If
                    tempList.Add(point)
                    tempPoint2 = CreatePoint(points(i), points(i - 1), distance)
                Else
                    tempPoint = CreatePoint(points(i - 1), points(i), -distance)
                    Dim point As Point3D = New Point3D()
                    point.X = (tempPoint.X + tempPoint2.X) / 2
                    point.Y = (tempPoint.Y + tempPoint2.Y) / 2
                    point = IntersectinoCircleLine(points(i - 1), distance, points(i - 1), point, -1)
                    If Not SameSide(points(i - 2), points(i - 1), tempList(tempList.Count - 1), point) Then
                        point = IntersectinoCircleLine(points(i - 1), distance, points(i - 1), point, 1)
                    End If
                    tempList.Add(point)
                    tempPoint2 = CreatePoint(points(i), points(i - 1), -distance)
                End If
            Else
                tempList.Add(tempPoint)
                tempPoint2 = CreatePoint(points(i), points(i - 1), distance)
            End If
        Next
        tempPoint = CreatePoint(points(points.Count - 1), points(points.Count - 2), distance)
        If SameSide(points(points.Count - 1), points(points.Count - 2), tempList(tempList.Count - 1), tempPoint) Then
            tempList.Add(tempPoint)
        Else
            tempList.Add(CreatePoint(points(points.Count - 1), points(points.Count - 2), -distance))
        End If
        For i As Integer = tempList.Count - 1 To 1 Step -1
            result.Add(tempList(i))
        Next
        If (SameSide(points(0), points(1), tempList(0), tempList(1))) Then
            result.Add(tempList(0))
        Else
            result.Add(CreatePoint(points(0), points(1), -distance))
        End If
        Return result
    End Function

    'Public Function SplitLine(ByVal distance As Double) As List(Of Point3D)
    '    Dim result As New List(Of Point3D)()
    '    Dim x As Double = point1.X
    '    Dim y As Double = point1.Y
    '    Dim count As Integer = Math.Floor(Me.Length / distance)
    '    If x <> point2.X Then
    '        While count > 0
    '            Dim p1 As Point3D = New Point3D()
    '            p1.X = x
    '            p1.Y = y
    '            result.Add(p1)
    '            x = Math.Round(x + distance * (point2.X - point1.X) / Me.Length)
    '            y = Math.Round(y + distance * (point2.Y - point1.Y) / Me.Length)
    '            count -= 1
    '        End While
    '    Else
    '        Dim sign = (point2.Y - point1.Y) / Math.Abs(point2.Y - point1.Y)
    '        While count > 0
    '            Dim p1 As Point3D = New Point3D()
    '            p1.X = x
    '            p1.Y = y
    '            result.Add(p1)
    '            y = Math.Round(y + sign * distance)
    '            count -= 1
    '        End While
    '    End If
    '    Return result
    'End Function

    Public Function CreateParalellPolyline(ByVal points As List(Of Point3D), ByVal dist2Lines As Double) As List(Of Point3D)
        Dim result As New List(Of Point3D) '= New List(Of Point3D)()
        Try
            If points.Count = 2 Then
                Dim line = New Line3D(points(0), points(1))
                result.Add(CreatePoint(points(0), points(1), dist2Lines))
                Dim temp = CreatePoint(points(1), points(0), dist2Lines)
                If Not line.SameSide(result.Last, temp) Then
                    temp = CreatePoint(points(1), points(0), -dist2Lines)
                End If
                result.Add(temp)
            Else
                For i As Integer = 0 To points.Count - 3 Step 1
                    Dim temp = CreatePointIntersection(points(i), points(i + 1), points(i + 2), dist2Lines)
                    If i = 0 Then
                        result.Add(temp(0))
                        result.Add(temp(1))
                    Else
                        Dim lineTemp As New Line3D(points(i + 0), points(i + 1))
                        If Not lineTemp.SameSide(result.Last, temp(1)) Then
                            temp = CreatePointIntersection(points(i), points(i + 1), points(i + 2), -dist2Lines)
                        End If
                        result.Add(temp(1))
                    End If
                Next
                Dim line As New Line3D(points(points.Count - 1), points(points.Count - 2))
                Dim tempPoint As Point3D = CreatePoint(line.Point1, line.Point2, dist2Lines)
                If Not line.SameSide(result.Last, tempPoint) Then
                    tempPoint = CreatePoint(line.Point1, line.Point2, -dist2Lines)
                End If
                result.Add(tempPoint)
            End If
        Catch ex As Exception

        End Try
        Return result
    End Function

    Public Function CreatePointIntersection(ByVal point1 As Point3D, ByVal point2 As Point3D, ByVal point3 As Point3D, ByVal dist2Lines As Double) As List(Of Point3D)
        Dim result As New List(Of Point3D) '= New List(Of Point3D)()
        Dim line1 As New Line3D(point1, point2)
        Dim line2 As New Line3D(point3, point2)
        Dim line3 = CreateParallelLine(line1, dist2Lines)
        Dim line4 = CreateParallelLine(line2, dist2Lines)
        If (line1.SameSide(line3.Point1, line4.Point1) <> line2.SameSide(line3.Point1, line4.Point1)) Then
            line4 = CreateParallelLine(line2, -dist2Lines)
        End If
        result.Add(line3.Point1)
        result.Add(line3.Intersection(line4))
        Return result
    End Function

    Public Function CreateParallelLine(ByVal line As Line3D, ByVal dist2Lines As Double) As Line3D
        Dim tempList1, tempList2 As Point3D
        tempList1 = CreatePoint(line.Point1, line.Point2, dist2Lines)
        tempList2 = CreatePoint(line.Point2, line.Point1, dist2Lines)
        If Not line.SameSide(tempList1, tempList2) Then
            tempList2 = CreatePoint(line.Point2, line.Point1, -dist2Lines)
        End If
        Return New Line3D(tempList1, tempList2)
    End Function

    Public Function Create2Points(ByVal point1 As Point3D, ByVal point2 As Point3D, ByVal dist2Lines As Double) As List(Of Point3D)
        Dim result As New List(Of Point3D)()
        Dim p1 As Point3D = CreatePoint(point1, point2, dist2Lines)
        Dim p2 As Point3D = CreatePoint(point1, point2, -dist2Lines)
        result.Add(p1)
        result.Add(p2)
        Return result
    End Function

    Public Function CreatePoint(ByVal point1 As Point3D, ByVal point2 As Point3D, ByVal dist2Lines As Double) As Point3D
        Dim result As Point3D
        If point1.X <> point2.X Then
            Dim tempValue As Double = (point1.Y - point2.Y) / (point1.X - point2.X)
            Dim y1 As Double = (point1.Y + dist2Lines / Math.Sqrt(1 + tempValue * tempValue))
            Dim x1 As Double = (-tempValue * (y1 - point1.Y) + point1.X)
            result.X = x1
            result.Y = y1
        Else
            result.X = point1.X + dist2Lines
            result.Y = point1.Y
        End If
        Return result
    End Function

    Public Function SameSide(ByVal point1 As Point3D, ByVal point2 As Point3D, ByVal point3 As Point3D, ByVal point4 As Point3D) As Boolean
        Dim a As Double = point1.Y - point2.Y
        Dim b As Double = point2.X - point1.X
        Dim c As Double = point1.X * point2.Y - point1.Y * point2.X
        Dim d As Double = (a * point3.X + b * point3.Y + c) * (a * point4.X + b * point4.Y + c)
        If (d > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CalculateAngle(ByVal point1 As Point3D, ByVal point2 As Point3D, ByVal point3 As Point3D, ByVal point4 As Point3D, ByVal point5 As Point3D) As Boolean
        Dim angle1 As Double = Math.Atan2(point2.Y - point1.Y, point2.X - point1.X) - Math.Atan2(point3.Y - point2.Y, point3.X - point2.X)
        Dim angle2 As Double
        If (angle1 < 0) Then
            angle2 = Math.Atan2(point2.Y - point4.Y, point2.X - point4.X) - Math.Atan2(point5.Y - point2.Y, point5.X - point2.X)
        Else
            angle2 = Math.Atan2(point4.Y - point2.Y, point4.X - point2.X) - Math.Atan2(point2.Y - point5.Y, point2.X - point5.X)
        End If
        If Math.Abs(angle1 - angle2) < 0.0001 Then
            Return False
        End If
        Return True
    End Function

    Public Function IntersectinoCircleLine(ByVal point1 As Point3D, ByVal distance As Double, ByVal lineP1 As Point3D, ByVal lineP2 As Point3D, ByVal signInt As Integer) As Point3D
        Dim M As Double = (lineP2.Y - lineP1.Y) / (lineP2.X - lineP1.X)
        Dim B = lineP1.Y - M * lineP1.X
        Dim a = 1 + M * M
        Dim b1 = 2 * (M * B - M * point1.Y - point1.X)
        Dim c = point1.X * point1.X + B * B + point1.Y * point1.Y - distance * distance - 2 * B * point1.Y
        Dim sqRtTerm = Math.Sqrt(b1 * b1 - 4 * a * c)
        Dim result As Point3D = New Point3D()
        result.X = (-b1 + signInt * sqRtTerm) / (2 * a)
        result.Y = M * result.X + B
        Return result
    End Function

End Class


Public Class Line3D
    Public Point1, Point2 As Point3D

    Public Sub New(p1 As Point3D, p2 As Point3D)
        Me.Point1 = p1
        Me.Point2 = p2
    End Sub

    Public Function SameSide(ByVal p1 As Point3D, ByVal p2 As Point3D) As Boolean
        Dim a As Double = Point1.Y - Point2.Y
        Dim b As Double = Point2.X - Point1.X
        Dim c As Double = Point1.X * Point2.Y - Point1.Y * Point2.X
        Dim d As Double = (a * p1.X + b * p1.Y + c) * (a * p2.X + b * p2.Y + c)
        If (d > 0) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Intersection(ByVal line As Line3D) As Point3D
        Dim result As Point3D = Nothing
        Dim dy1 As Double = Me.Point2.Y - Me.Point1.Y
        Dim dx1 As Double = Me.Point2.X - Me.Point1.X
        Dim dy2 As Double = line.Point2.Y - line.Point1.Y
        Dim dx2 As Double = line.Point2.X - line.Point1.X
        Dim p As New Point
        'check whether the two line parallel
        If dy1 * dx2 <> dy2 * dx1 Then
            Dim x As Double = ((line.Point1.Y - Me.Point1.Y) * dx1 * dx2 + dy1 * dx2 * Me.Point1.X - dy2 * dx1 * line.Point1.X) / (dy1 * dx2 - dy2 * dx1)
            Dim y As Double = Me.Point1.Y + (dy1 / dx1) * (x - Me.Point1.X)
            result = New Point3D()
            result.X = x
            result.Y = y
        End If
        Return result
    End Function
    '#Enable Warning IDE0017 ' Simplify object initialization
    '#Enable Warning IDE0140 ' Simplify object initialization
End Class

