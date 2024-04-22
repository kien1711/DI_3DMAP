Module mdlSnipScreen
    Public Structure lrect
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    'SOURCE Stuff
    Public hwndSrc% 'handle to object
    Public hwndDest%
    Public PIC As New PictureBox()

    Private Declare Function BitBlt Lib "GDI32" (ByVal hDestDC%, ByVal X%, ByVal Y%, ByVal nWidth%, ByVal nHeight%,
                                               ByVal hSrcDC%, ByVal XSrc%, ByVal YSrc%, ByVal dwRop&) As Integer

    Private Declare Function GetDesktopWindow Lib "user32" () As Integer
    Private Declare Function GetDC Lib "user32" (ByVal hWnd%) As Integer
    Private Declare Function ReleaseDC Lib "user32" (ByVal hWnd%, ByVal hDC%) As Integer
    Private Declare Sub GetWindowRect Lib "user32" (ByVal hWnd%, ByVal lpRect As lrect)



    Public Function GetBitmap(ByVal pCtrl As Control) As Drawing.Bitmap
        Dim myBmp As New Bitmap(pCtrl.Width, pCtrl.Height)
        Dim g As Graphics = Graphics.FromImage(myBmp)
        Dim pOffset As New Point((pCtrl.Parent.Width - pCtrl.Parent.ClientRectangle.Width) + 4, (pCtrl.Parent.Height - pCtrl.Parent.ClientRectangle.Height) + 4)
        g.CopyFromScreen(pCtrl.Parent.Location + pCtrl.Location + pOffset, Point.Empty, myBmp.Size)
        Return myBmp
        g.Dispose()
    End Function

    'Public Function getBitmap(ByVal pCtrl As Control) As Drawing.Bitmap
    '    Dim myBmp As New Bitmap(pCtrl.Width, pCtrl.Height)
    '    Dim g As Graphics = Graphics.FromImage(myBmp)
    '    Dim pOffset As New Point(pCtrl.Parent.Width - pCtrl.Parent.ClientRectangle.Width - 4, pCtrl.Parent.Height - pCtrl.Parent.ClientRectangle.Height + 4)
    '    g.CopyFromScreen(pCtrl.Parent.Location + pCtrl.Location + pOffset, Point.Empty, myBmp.Size)
    '    Return myBmp
    '    g.Dispose()
    'End Function



End Module
