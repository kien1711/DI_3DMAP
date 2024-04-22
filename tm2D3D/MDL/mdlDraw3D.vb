Imports TerraExplorerX

Module mdlDraw3D

    Public fLabelStyle3D As ILabelStyle71 = Nothing
    Dim CtenMay As String, CGiaidoan As String
    Public KLipoint As New List(Of IPosition71)

    Public Sub Bdt3Dbd_3DA(mAxinfor As AxTerraExplorerX.AxTEInformationWindowEx, mAxWindows3D As AxTerraExplorerX.AxTE3DWindowEx)
        mAxinfor.Height = mAxWindows3D.Height / 2
        If (myScreens.Length = 1) Then
            mAxinfor.Width = Screen.AllScreens(0).Bounds.Width / 8
        ElseIf (myScreens.Length = 2) Then
            mAxinfor.Width = Screen.AllScreens(1).Bounds.Width / 8
        End If
        Dim Point1 As Point
        If FrmMain.Instance.pnTrinhchieu.Visible = True Or FrmMain.Instance.ChebBangDT.Checked = False Then
            Point1.Y = mAxWindows3D.Height + mAxinfor.Height + 100
        ElseIf FrmMain.Instance.pnTrinhchieu.Visible = False Or FrmMain.Instance.ChebBangDT.Checked = True Then
            Point1.Y = mAxWindows3D.Height - (mAxinfor.Height + 2)
        End If
        Point1.X = 2
        mAxinfor.Location = Point1
        mAxinfor.AttachTo3dWindow(mAxWindows3D.GetOcx())
        mAxinfor.Visible = True
        mAxinfor.BringToFront()
    End Sub

    Public Sub VKTC3D()
        If Lenhve2D2 = "dichuyen" Then
            Dichuyen()
        End If
        If Lenhve2D = "" Then
            Exit Sub
        Else
            ' MsgBox("Lenhve2D = " & Lenhve2D)
            'If Not Lenhve2D = "duongtovung" And Not Lenhve2D = "vungtoduong" And Not Lenhve2D = "noiduong" And Not Lenhve2D = "catduong" And Not Lenhve2D = "catvung" And Not Lenhve2D = "gopvung" And Not Lenhve2D = "giaovung" And
            '       Lenhve <> "chonDTnhapnhay" And Not Lenhve2D = "chonDTan" And Not Lenhve2D = "chonPhim" And Not Lenhve2D = "chonDTchuyendong" And Not Lenhve2D = "radaquay" Then  'And Not Lenhve2D = "noiduong"
            '    Giaidoan = "GD" & (FrmMain.Instance.cbGiaidoan.SelectedIndex + 1).ToString
            '    '    GroupBac23DBd = Gr02(sgworld3DBd, Giaidoan, tenKH)
            '    If A3D = True Then
            '        '      GroupBac23DA = Gr02(sgworld3DA, Giaidoan, tenKH)
            '    End If
            'ElseIf Lenhve2D = "noiduong" Then
            '    GroupBac23DBd = sgworld3DBd.ProjectTree.FindItem(Giaidoan & "\" & tenKH)

            'End If
            'Dim CtenMay As String, CGiaidoan As String
            If tenMayNet = "" Then
                CtenMay = System.Environment.MachineName
            Else
                CtenMay = tenMayNet
            End If
            If GiaidoanNet = "" Then
                CGiaidoan = Giaidoan
            Else
                CGiaidoan = GiaidoanNet
            End If
            If Not Lenhve2D = "vekhung" And Not Lenhve2D = "trinhbay" Then '
                CGiaidoan = CGiaidoan '"GD" & (FrmMain.Instance.cbGiaidoan.SelectedIndex + 1).ToString
                tenKH = tenKH
                GroupBac23DBd = Gr03(sgworld3DBd, CtenMay, CGiaidoan, tenKH)
                If A3D = True Then
                    GroupBac23DA = Gr03(sgworld3DA, CtenMay, CGiaidoan, tenKH)
                End If
            Else
                If A3D = True Then
                    XoaKhung(sgworld3DA, "Khung")
                End If
                If Lenhve2D = "vekhung" Then
                    XoaKhung(sgworld3DBd, "Khung")
                    tenKH = "Khung"
                Else
                    XoaKhung(sgworld3DBd, "Trinh bay")
                    tenKH = "Trinh bay"
                End If
                CGiaidoan = "Trinh bay"
                GroupBac23DBd = Gr02(sgworld3DBd, CGiaidoan, tenKH)
                If A3D = True Then
                    GroupBac23DA = Gr02(sgworld3DA, CGiaidoan, tenKH)
                End If
            End If
            If Lenhve2D = "Venhieuco" Or Lenhve2D = "veco" Or Lenhve2D = "Taungam" Or Lenhve2D = "Doituongchu" Or Lenhve2D = "chenanh" Or Lenhve2D = "TaungamPB" Or Lenhve2D = "kvchupanh" Then 'Or Lenhve2D = "transLABEL"
                CreateLabel3D()
            ElseIf Lenhve2D = "taophim" Then
                Video3D()
            ElseIf Lenhve2D = "ModelNet" Or Lenhve2D = "Phaobobien" Or Lenhve2D = "PhaoMDbanbien" Or Lenhve2D = "pTuhanh" Or Lenhve2D = "pNDTuhanh" Or Lenhve2D = "plNDTuhanh" Or Lenhve2D = "mohinhPB" Or Lenhve2D = "mohinh" Or Lenhve2D = "chenmohinh" Then
                MohinhPB3D()
            ElseIf Lenhve2D = "ModelMotionNet" Or Lenhve2D = "mohinhnguoidung" Or Lenhve2D = "1DTchuyendontheoduong" Or Lenhve2D = "dtChuyendongMH" Or Lenhve2D = "MHNDchuyendong" Or Lenhve2D = "chonDuongtaoChuoiND" Or Lenhve2D = "2DTchuyendondoc" Or Lenhve2D = "2DTchuyendongngang" Or Lenhve2D = "3DTchuyendonTG" Or Lenhve2D = "3DTchuyendonTG1" Or Lenhve2D = "3DTchuyendonNgang" Or Lenhve2D = "3DTchuyendondoc" Then
                DTchuyendong3D()
            ElseIf Lenhve2D = "ChieusauTS" Or Lenhve2D = "MBchupanhTS" Or Lenhve2D = "giaothonghao" Or Lenhve2D = "Duonghanhquan" Or Lenhve2D = "Doituongduong" Or Lenhve2D = "duongbienphong" Or Lenhve2D = "LineNet" Or Lenhve2D = "nhiemvutruocmat" Or Lenhve2D = "nhiemvutieptheo" Or Lenhve2D = "hamphao" Or Lenhve2D = "hamVK" Or Lenhve2D = "hambetong" Or Lenhve2D = "TuyengiaoNvu" Or Lenhve2D = "Daihiepdong" Or Lenhve2D = "DDbotrimin" Or
                   Lenhve2D = "tuyendanhchan" Or Lenhve2D = "kvTuantieu" Or Lenhve2D = "Giaothonghaoconap" Or Lenhve2D = "toTrsTrongdich" Or Lenhve2D = "toTrSDieutra" Or Lenhve2D = "tuyenbancodinh" Or Lenhve2D = "diadao" Or Lenhve2D = "capdachien" Or Lenhve2D = "capquang" Or Lenhve2D = "capdongtruc" Or Lenhve2D = "capnguondien" Or Lenhve2D = "capliendai" Or Lenhve2D = "BkinhMB" Or Lenhve2D = "DbanMtuy" Or Lenhve2D = "Diaban" Or
                   Lenhve2D = "veduongsongsong" Or Lenhve2D = "vetNXdudoan" Or Lenhve2D = "vetNXthucte" Or Lenhve2D = "hangraobungnhung" Or Lenhve2D = "TSTiengdong" Or Lenhve2D = "tuyenbanCS" Or Lenhve2D = "hoalucV" Or Lenhve2D = "hoalucCN" Or Lenhve2D = "tuyenVCkhongno" Or Lenhve2D = "tuyenVChonhop" Or Lenhve2D = "tuyenRMhonhop" Or Lenhve2D = "tuyenRMbangTrT" Or Lenhve2D = "TuyenMBcatcanh" Or Lenhve2D = "tuyenthoay" Or
                   Lenhve2D = "doboduongkhong" Or Lenhve2D = "doboduongkhongTrT" Or Lenhve2D = "Tieptebangdu" Or Lenhve2D = "kvkhoinguytrang" Or Lenhve2D = "tuyenkhoinguytrang" Or Lenhve2D = "kvVaybat" Or Lenhve2D = "SungBBbanMB" Or Lenhve2D = "kvTKHHdukien" Or Lenhve2D = "BanChsangChihuongTC" Or Lenhve2D = "BanCSphanchiaGioituyen" Or Lenhve2D = "cuma" Or Lenhve2D = "cuamoBB" Or Lenhve2D = "cuamoXT" Or Lenhve2D = "TrTbiHH" Or Lenhve2D = "kvtstrenkhong" Or Lenhve2D = "kvtsmatdat" Or
                   Lenhve2D = "KVdongquan" Or Lenhve2D = "khuvucphongthutrongdiem" Or Lenhve2D = "khuvucphaigiu" Or Lenhve2D = "khuvucphongthuthenchot" Or Lenhve2D = "KVTrinhsatSN" Or Lenhve2D = "KVTrinhsatSCN" Or Lenhve2D = "KvTRanhchap" Or Lenhve2D = "KvXamcanh" Or Lenhve2D = "KvBdCongnghe" Or Lenhve2D = "KvTrSHHBangMB" Or Lenhve2D = "LLTructiep" Or Lenhve2D = "LLVuotcap" Or Lenhve2D = "LLHiepdong" Or Lenhve2D = "LLthuongxuyen2" Or
                   Lenhve2D = "cancuhauphuong" Or Lenhve2D = "cancuchiendau" Or Lenhve2D = "ANQP" Or Lenhve2D = "KvDichmoiden" Or Lenhve2D = "MTCanbaove" Or Lenhve2D = "KvLanchiem" Or Lenhve2D = "CCCDBP" Or Lenhve2D = "KvHoaluc" Or Lenhve2D = "KvTieutay" Or Lenhve2D = "KVbitran" Or Lenhve2D = "KvKho" Or Lenhve2D = "KvKT" Or Lenhve2D = "tohoahoc" Or Lenhve2D = "toTrSHHCodong" Or Lenhve2D = "Duongcothhacanh" Or Lenhve2D = "kvgiaochien" Or
                   Lenhve2D = "KVNgapnuoc" Or Lenhve2D = "KVCatvui" Or Lenhve2D = "KvKhotrandau" Or Lenhve2D = "KvTautrandau" Or Lenhve2D = "KvGkhoantrandau" Or Lenhve2D = "KvCamTbVTD" Or Lenhve2D = "KvBvMtieuBangGnhieungoinoVT" Or Lenhve2D = "KvBiphahuyHN" Or Lenhve2D = "HrNganthuyloi" Or Lenhve2D = "DDgnguytrangLuoi" Or Lenhve2D = "DDgdichphahoai" Or Lenhve2D = "DDgdichphahoaiMB" Or Lenhve2D = "DDGngapnuoc" Or Lenhve2D = "DDgVongtranh" Or Lenhve2D = "DDgCoDichmatdat" Or Lenhve2D = "Phacau" Or Lenhve2D = "Phaduong" Or
                   Lenhve2D = "caucogioi" Or Lenhve2D = "CaugoCaubetong" Or Lenhve2D = "Causat" Or Lenhve2D = "Caungam" Or Lenhve2D = "Cautreo" Or Lenhve2D = "Cautre" Or Lenhve2D = "CauPMP" Or Lenhve2D = "Caubidanhpha" Or Lenhve2D = "BenloiBB" Or Lenhve2D = "BenloiOto" Or Lenhve2D = "BenloiXT" Or Lenhve2D = "BenvuotBangthuyen" Or Lenhve2D = "BenvuotsongPha" Or Lenhve2D = "BenPhatuhanh" Or Lenhve2D = "BenvuotsongnhieuPT" Or Lenhve2D = "TuyenchuyentiepChuy" Or Lenhve2D = "HQhanhquan" Or
                   Lenhve2D = "DgVongtranh" Or Lenhve2D = "DgTieudoc" Or Lenhve2D = "AntoanHatnhan" Or Lenhve2D = "GioiHanHatnhan" Or Lenhve2D = "GioihanvungTrSDientuSN" Or Lenhve2D = "GioihanvungTrSdienttuSCNVHF" Or Lenhve2D = "GioihanvungTrSdientuSCNUHF" Or Lenhve2D = "GioihanvungTrSDTsieucaotan" Or Lenhve2D = "GihanVungcheap" Or Lenhve2D = "Caugiabangmatphanxa" Or Lenhve2D = "Manchanchongrada" Or Lenhve2D = "Moibayhongngoai" Or Lenhve2D = "GiHanNvuTCDT" Or Lenhve2D = "HuongTCChuyeuKQchienthuat" Or
                Lenhve2D = "KnNguytrangcongTrSrada" Or Lenhve2D = "KvNhieutieucuc" Or Lenhve2D = "KvBandoclaptieudoan" Or Lenhve2D = "KvBanDoclapDaidoi" Or Lenhve2D = "KvBanTTrTieudoan" Or Lenhve2D = "baihacanh" Or Lenhve2D = "KvBanTTrDaidoi" Or Lenhve2D = "HuongTCChuyeuKQchendich" Or Lenhve2D = "HuongTCThuyeuKQchendich" Or Lenhve2D = "khongquandanhbien" Or Lenhve2D = "danhhuongchuyeuHQ" Or Lenhve2D = "danhhuongthuyeuHQ" Or Lenhve2D = "tuyenPHkoLTlon" Or Lenhve2D = "tuyenPHLTLon" Then
                LineArray3D()
            ElseIf Lenhve2D = "trinhbay" Then
                Trinhbay3D()
            ElseIf Lenhve2D = "XoaGrtheoDT" Or Lenhve2D = "XoaGroup2" Then
                XoaGroup3D()
            ElseIf Lenhve2D = "hanhquanbo" Or Lenhve2D = "HQbangoto" Or Lenhve2D = "HQbangxelua" Or Lenhve2D = "HQbangTau" Or Lenhve2D = "HQbangMB" Then
                HQ3D()
            ElseIf Lenhve2D = "vungtoduong" Or Lenhve2D = "catvung" Or Lenhve2D = "giaovung" Or Lenhve2D = "gopvung" Or Lenhve2D = "gopvung2" Or Lenhve2D = "catvung2" Then
                Suavung3D()
            ElseIf Lenhve2D = "catduong" Or Lenhve2D = "noiduong" Or Lenhve2D = "duongtovung" Then
                SuaDuong3D()
            Else
                DTvung3D()
            End If
            If mMicrostation = False Then
                If Lenhve2D = "mohinh" Or Lenhve2D = "dtChuyendongMH" Or Lenhve2D = "mohinh" Or Lenhve2D = "2DTchuyendongngang" Or Lenhve2D = "2DTchuyendondoc" Or Lenhve2D = "3DTchuyendonTG" Or Lenhve2D = "3DTchuyendonTG1" Or Lenhve2D = "3DTchuyendonNgang" Or Lenhve2D = "3DTchuyendondoc" Then
                    FrmMain.Instance.TxtTenKH.Text = ""
                End If
                FrmMain.Instance.BienEmpty()
            End If
        End If
        Lenhve2D = ""
        CtenMay = ""
        CGiaidoan = ""
    End Sub

    Private Sub Dichuyen()
        If Not Lenhve = "chonDTnhapnhay" And Not Lenhve = "chonDTan" And Not Lenhve = "chonMTchuyendong" And Not Lenhve = "chonDTchuyendong" And Not Lenhve = "radaquay" And Not Lenhve = "chonPhim" And Not Lenhve = "amthanh" Then
            SMove(mPointMS1)
        End If
        Lenhve2D2 = ""
    End Sub

    Public Sub SMove(mPtt As IPosition71)
        Dim mpbd3D As IPosition71 = sgworld3DBd.Creator.CreatePosition(mPtt.X, mPtt.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 340, 0.145, 15.0 * mPtt.Altitude)
        sgworld3DBd.Navigate.JumpTo(mpbd3D)
        If A3D = True Then
            Dim mpA3D As IPosition71 = sgworld3DA.Creator.CreatePosition(mPtt.X, mPtt.Y, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 180, -20, 0.145, 15.0 * mPtt.Altitude)
            sgworld3DA.Navigate.JumpTo(mpA3D)
        End If
        FrmMain.Instance.Focus()
    End Sub

    Private Sub XoaGroup3D()
        Try
            XoaGr(sgworld3DBd, FrmMain.Instance.txtGroup.Text)
            If A3D = True Then
                XoaGr(sgworld3DA, FrmMain.Instance.txtGroup.Text)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CreateLabel3D() 'sCreateLabel3D
        LabelArray(sgworld3DBd, GroupBac23DBd)
        If A3D = True Then
            LabelArray(sgworld3DA, GroupBac23DA)
        End If
        If Lenhve2D = "TaungamPB" Then
            DTvung3D()
            LineArray3D()
        ElseIf Lenhve2D = "kvchupanh" Then
            LineArray3D()
        End If
        'DTvung3D()
        'LineArray3D()
    End Sub

    Private Sub LabelArray(sgworldK As SGWorld71, mGroup As String)
        fLabelStyle3D = SLabelStyleTQ(sgworldK)
        fileImage = ""
        If mLabelArray.Count > 0 Then
            For i As Integer = 0 To mLabelArray.Count - 1
                Dim mText As ITerrainLabel71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mLabelArray(i).ID)
                If Lenhve2D = "taungam" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "baicocchongtang" Or Lenhve2D = "hamchong" Then
                    fileImage = mText.ImageFileName
                Else
                    If mText.ImageFileName <> "" Then
                        Dim mtenGiaidoan As String, x2 As String, cThumuc As String
                        x2 = ""
                        cThumuc = "\2X\"
                        Dim dsKH As List(Of String) = MLoaiKH(mText.ImageFileName)
                        mP = dsKH(0)
                        ChieuKH = dsKH(1)
                        loaiKH = dsKH(2)
                        Ta_Doiphuong = dsKH(3)
                        mtenGiaidoan = dsKH(4)
                        fileImage = PathLabel(cThumuc, loaiKH, ChieuKH, mP, x2, Ta_Doiphuong, mtenGiaidoan)
                    Else
                        fileImage = ""
                    End If
                End If
                Dim Pk As IPosition71
                If Lenhve2D = "Venhieuco" Then
                    Pk = mLabelArray(mLabelArray.Count - 1).Position
                    Pk.Altitude = Val(mText.Tooltip.Text.Split(",")(2))
                Else
                    Pk = mText.Position
                    Pk.Altitude = mText.Position.Altitude
                End If
                CreateLabel3D(sgworldK, mText, Pk, fileImage, mGroup, mText.TreeItem.Name)
            Next
        End If
    End Sub

    Private Sub CreateLabel3D(sgworldK As SGWorld71, mText As ITerrainLabel71, P As IPosition71, mFile As String, mGroup As String, tenDT As String)
        fLabelStyle3D.FontName = mText.Style.FontName
        fLabelStyle3D.Scale = mText.Style.Scale
        fLabelStyle3D.TextColor = mText.Style.TextColor
        fLabelStyle3D.TextAlignment = mText.Style.TextAlignment
        fLabelStyle3D.FontSize = mText.Style.FontSize
        fLabelStyle3D.PivotAlignment = mText.Style.PivotAlignment
        fLabelStyle3D.BackgroundColor = mText.Style.BackgroundColor
        fLabelStyle3D.SmallestVisibleSize = 0
        Dim cLabel As ITerrainLabel71 = sgworldK.Creator.CreateLabel(P, mText.Text, mFile, fLabelStyle3D, mGroup, tenDT)
        cLabel.Terrain.DrawOrder = mText.Terrain.DrawOrder
        If Lenhve2D = "tramtaptrungQNDB" Or Lenhve2D = "tramtaptrungPTKT" Or Lenhve2D = "tramtaptrungQNDBcm" Or Lenhve2D = "kvttllDongvien" Or Lenhve2D = "kvchupanh" Or
           Lenhve2D = "tramtiepnhanPTKT" Or Lenhve2D = "tramtiepnhanQNDB" Or Lenhve2D = "tramGiao_nhan" Or Lenhve2D = "kvcophandong" Or Lenhve2D = "khuvucBLTieutay" Or Lenhve2D = "MatcuBLLD" Then
            cLabel.Style.LockMode = mText.Style.LockMode
        Else
            cLabel.Style.LockMode = LabelLockMode.LM_DECAL 'fLabelStyle3D.LockMode.LM_DECAL '.LockMode.LM_DECAL
        End If
        cLabel.Tooltip.Text = mText.Tooltip.Text
        ZoomLAND(sgworldK, cLabel)
    End Sub

    Private Sub HQ3D()
        fLabelStyle3D = SLabelStyleTQ(sgworld3DBd) ' sgworld3DBd.Creator.CreateLabelStyle(SGLabelStyle.LS_DEFAULT)
        SAnhDVHQ(Lenhve2D, sgworld3DBd, GroupBac23DBd, fLabelStyle3D)
        If A3D = True Then
            fLabelStyle3D = SLabelStyleTQ(sgworld3DA) ' sgworld3DA.Creator.CreateLabelStyle(SGLabelStyle.LS_DEFAULT)
            SAnhDVHQ(Lenhve2D, sgworld3DA, GroupBac23DA, fLabelStyle3D)
        End If
    End Sub

    Private Sub Trinhbay3D()
        LabelArray(sgworld3DBd, GroupBac23DBd)
        LineArray3D()
    End Sub


#Region "  Video"

    Public Sub Video3D()
        Video3DTQ(sgworld3DBd, mVideo3D, GroupBac23DBd)
        If A3D = True Then
            Video3DTQ(sgworld3DA, mVideo3D, GroupBac23DA)
        End If
    End Sub

    Private Sub Video3DTQ(sgworldK As SGWorld71, mvideo1 As ITerrainVideo71, mGroup As String)
        Dim mVideo As ITerrainVideo71 = sgworldK.Creator.CreateVideoOnTerrain(mvideo1.VideoFileName, mvideo1.Position, mGroup, tenKH)
        mVideo.Terrain.DrawOrder = mvideo1.Terrain.DrawOrder
        mVideo.MaximumProjectionDistance = mvideo1.MaximumProjectionDistance
        mVideo.Position.AltitudeType = mvideo1.Position.AltitudeType
        mVideo.Position.Altitude = mvideo1.Position.Altitude
        mVideo.Position.Yaw = mvideo1.Position.Yaw
        mVideo.Position.Pitch = 0
        mVideo.PlayVideoOnStartup = mvideo1.PlayVideoOnStartup
        mVideo.PlayVideo()
        mVideo.Mute = True
        ZoomLAND(sgworldK, mVideo)
        ' ZoomTQ(sgworldK)
    End Sub

#End Region

#Region "  Doi tuong duong"

    Private Sub LineArray3D()
        Line3D(sgworld3DBd, GroupBac23DBd)
        If A3D = True Then
            Line3D(sgworld3DA, GroupBac23DA)
        End If
        If Lenhve2D = "KvLanchiem" Or Lenhve2D = "KvTRanhchap" Or Lenhve2D = "KvXamcanh" Or Lenhve2D = "BkinhMB" Or Lenhve2D = "tuyenPHkoLTlon" Or Lenhve2D = "kvgiaochien" Or Lenhve2D = "DDbotrimin" Or Lenhve2D = "HrNganthuyloi" Or Lenhve2D = "DDgCoDichmatdat" Or Lenhve2D = "caucogioi" Or Lenhve2D = "BenloiXT" Or Lenhve2D = "BenvuotsongnhieuPT" Or Lenhve2D = "Cautreo" Or Lenhve2D = "BenPhatuhanh" Or Lenhve2D = "BanChsangChihuongTC" Or Lenhve2D = "ChieusauTS" Or Lenhve2D = "MBchupanhTS" Or Lenhve2D = "nhiemvutruocmat" Or Lenhve2D = "nhiemvutieptheo" Or Lenhve2D = "kvTochucDoihinh" Or Lenhve2D = "kvTuantieu" Or Lenhve2D = "kvVaybat" Or Lenhve2D = "vetNXdudoan" Or Lenhve = "vetNXthucte" Or Lenhve2D = "kvTKHHdukien" Or Lenhve2D = "KvTTrHoalucphandoi" Or Lenhve2D = "khuvucphongthuthenchot" Or
            Lenhve2D = "tuyenVChonhop" Or Lenhve2D = "tuyenRMhonhop" Or Lenhve2D = "tuyenRMbangTrT" Or Lenhve2D = "cancuchiendau" Or Lenhve2D = "khuvucphongthutrongdiem" Or Lenhve2D = "DgVongtranh" Or Lenhve2D = "DgTieudoc" Or Lenhve2D = "GioihanvungTrSDTsieucaotan" Or Lenhve2D = "GihanVungcheap" Or Lenhve2D = "GiHanNvuTCDT" Or Lenhve2D = "Daihiepdong" Then
            VungAr3D()
        ElseIf Lenhve2D = "DbanMtuy" Or Lenhve2D = "Diaban" Or Lenhve2D = "HuongTCChuyeuKQchendich" Or Lenhve2D = "HuongTCThuyeuKQchendich" Or Lenhve2D = "doboduongkhong" Or Lenhve2D = "doboduongkhongTrT" Or Lenhve2D = "Tieptebangdu" Or Lenhve2D = "DDgdichphahoaiMB" Or Lenhve2D = "SungBBbanMB" Or Lenhve2D = "KvDichmoiden" Or Lenhve2D = "KvKhotrandau" Or Lenhve2D = "KvTautrandau" Or Lenhve2D = "KVTrinhsatSCN" Or Lenhve2D = "KVTrinhsatSN" Or Lenhve2D = "KvHoaluc" Or Lenhve2D = "KvKho" Or Lenhve2D = "KvBdCongnghe" Or Lenhve2D = "TrTbiHH" Or Lenhve2D = "CCCDBP" Or Lenhve2D = "kvtstrenkhong" Or Lenhve2D = "kvtsmatdat" Or
            Lenhve2D = "KvBandoclaptieudoan" Or Lenhve2D = "KvBanDoclapDaidoi" Or Lenhve2D = "KvBanTTrTieudoan" Or Lenhve2D = "KvBanTTrDaidoi" Or Lenhve2D = "baihacanh" Or Lenhve2D = "Duongcothhacanh" Or Lenhve2D = "TuyengiaoNvu" Then
            CreateLabel3D()
        ElseIf Lenhve2D = "toTrsTrongdich" Or Lenhve2D = "toTrSDieutra" Or Lenhve2D = "tuyenRMbangTrT" Or Lenhve2D = "danhhuongchuyeuHQ" Or Lenhve2D = "danhhuongthuyeuHQ" Or Lenhve2D = "khongquandanhbien" Or Lenhve2D = "HQhanhquan" Or Lenhve2D = "KvBvMtieuBangGnhieungoinoVT" Or Lenhve2D = "KvCamTbVTD" Then
            CreateLabel3D()
            VungAr3D()
        End If
    End Sub

    Private Sub Line3D(sgworldK As SGWorld71, mGroup As String)
        ' Dim D1 As ITerrainPolyline71 '= Nothing
        'If Lenhve2D = "catduong" Or Lenhve2D = "noiduong" Then
        '    Dim k1 As ITerrainPolyline71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(FrmMain.Instance.txtGroup.Text.Split(",")(0)))
        '    sgworldK.Creator.DeleteObject(k1.ID)
        '    '  SXoaDTCat(sgworldK)
        'End If
        Dim D1 As ITerrainPolyline71 = Nothing

        If Lenhve2D = "hangraobungnhung" Then
            If mLineArrayHR.Count > 0 Then
                Dim k1 As ITerrainPolyline71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mLineArrayHR(0).ID)
                D1 = sgworldK.Creator.CreatePolylineFromArray(DTtoArray(sgworldK, k1), k1.LineStyle.Color, k1.Position.AltitudeType, mGroup, k1.TreeItem.Name)
                D1.LineStyle.Width = k1.LineStyle.Width
                D1.FillStyle.Color.SetAlpha(k1.LineStyle.Color.GetAlpha)
                D1.LineStyle.Pattern = k1.LineStyle.Pattern
                D1.LineStyle.BackColor = k1.LineStyle.BackColor
                D1.LineStyle.BackColor.SetAlpha(k1.LineStyle.BackColor.GetAlpha)
                D1.Terrain.DrawOrder = k1.Terrain.DrawOrder
                D1.Position.AltitudeType = k1.Position.AltitudeType
                D1.Tooltip.Text = k1.Tooltip.Text
                D1.Spline = True
                D1.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
                D1.Position.Altitude = Tyle * 160
                mLineArrayHR.Clear()
            End If
        Else
            If mLineArray.Count > 0 Then
                For i As Integer = 0 To mLineArray.Count - 1
                    Dim k1 As ITerrainPolyline71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mLineArray(i).ID)
                    D1 = sgworldK.Creator.CreatePolylineFromArray(DTtoArray(sgworldK, k1), mLineArray(i).LineStyle.Color, k1.Position.AltitudeType, mGroup, k1.TreeItem.Name)
                    D1.LineStyle.Width = k1.LineStyle.Width
                    D1.FillStyle.Color.SetAlpha(k1.LineStyle.Color.GetAlpha)
                    D1.LineStyle.Pattern = k1.LineStyle.Pattern
                    D1.Spline = k1.Spline
                    D1.LineStyle.BackColor = k1.LineStyle.BackColor
                    D1.LineStyle.BackColor.SetAlpha(k1.LineStyle.BackColor.GetAlpha)
                    D1.Terrain.DrawOrder = k1.Terrain.DrawOrder
                    D1.Position.AltitudeType = k1.Position.AltitudeType
                    D1.Tooltip.Text = k1.Tooltip.Text
                Next
            End If
        End If


        If Not Lenhve2D = "trinhbay" Then
            ZoomLAND(sgworldK, D1)
        End If

    End Sub


#End Region

#Region "  Doi tuong Vung"

    Private Sub VungAr3D()
        VungArray(sgworld3DBd, GroupBac23DBd)
        If A3D = True Then
            VungArray(sgworld3DA, GroupBac23DA)
        End If
    End Sub

    Private Sub VungArray(sgworldK As SGWorld71, mGroup As String)
        Dim cPolygon As ITerrainPolygon71 = Nothing
        If mRegionArray.Count > 0 Then
            For i As Integer = 0 To mRegionArray.Count - 1
                Dim k1 As ITerrainPolygon71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mRegionArray(i).ID)
                ' Dim cPolygon As ITerrainPolygon71 = sgworldK.Creator.CreatePolygon(GeoformDT(sgworldK, k1), k1.LineStyle.Color, k1.FillStyle.Color, k1.Position.AltitudeType, mGroup, k1.TreeItem.Name)
                cPolygon = sgworldK.Creator.CreatePolygonFromArray(DTtoArray(sgworldK, k1), k1.LineStyle.Color, k1.FillStyle.Color, k1.Position.AltitudeType, mGroup, k1.TreeItem.Name)
                cPolygon.LineStyle.Pattern = k1.LineStyle.Pattern
                cPolygon.LineStyle.Width = k1.LineStyle.Width
                cPolygon.LineStyle.Color.SetAlpha(k1.LineStyle.Color.GetAlpha)
                cPolygon.FillStyle.Color.SetAlpha(k1.FillStyle.Color.GetAlpha)
                cPolygon.Terrain.DrawOrder = k1.Terrain.DrawOrder
                cPolygon.FillStyle.Texture.FileName = k1.FillStyle.Texture.FileName
                cPolygon.FillStyle.Texture.ScaleX = k1.FillStyle.Texture.ScaleX
                cPolygon.FillStyle.Texture.ScaleY = k1.FillStyle.Texture.ScaleY
                cPolygon.FillStyle.Texture.RotateAngle = k1.FillStyle.Texture.RotateAngle
                cPolygon.Spline = k1.Spline
                cPolygon.Tooltip.Text = k1.Tooltip.Text
                cPolygon.FillStyle.Texture.TilingMethod = k1.FillStyle.Texture.TilingMethod
            Next
        End If
        ZoomLAND(sgworldK, cPolygon)
    End Sub

    Private Sub DTvung3D()
        Try
            VungAr3D()
            If Lenhve2D = "tauquetNoi" Or Lenhve2D = "HuongTCThuyeuKQchendich" Or Lenhve2D = "TsatBangChiendau" Or Lenhve2D = "toanTSDN" Or Lenhve2D = "xeTSPT76" Or Lenhve2D = "DCTCbangTauDS" Or Lenhve2D = "DCTCbangTauNgam" Or Lenhve2D = "muidaccongTC" Or Lenhve2D = "doidaccongTC" Or Lenhve2D = "todaccong" Or
                Lenhve2D = "tautuantieuTS" Or Lenhve2D = "muidaccong" Or Lenhve2D = "doidaccong" Or Lenhve2D = "tauhuanluyen" Or Lenhve2D = "tauquetloi" Or Lenhve2D = "xeTScanhgioi" Or Lenhve2D = "xeTSBMP" Or Lenhve2D = "doicongtacBP" Or
                Lenhve2D = "Canotrinhsat" Or Lenhve2D = "tauCuunan" Or Lenhve2D = "TLChongngamNBC" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "MatcuA2" Or Lenhve2D = "XeBAT" Or Lenhve2D = "doicongbinh" Or Lenhve2D = "TrandiaBtcdt" Or Lenhve2D = "TrandiaCtcdt" Or
                Lenhve2D = "hamchong" Or Lenhve2D = "todaccongnuoc" Or Lenhve2D = "doiTShonhop" Or Lenhve2D = "DChoatrang" Or Lenhve2D = "doidaccongnuoc" Or Lenhve2D = "muidaccongnuoc" Or
                Lenhve2D = "muidaccongcodong" Or Lenhve2D = "tauBinan" Or Lenhve2D = "DCTCbangTauNN" Or Lenhve2D = "CongNongLamtruongCD" Or Lenhve2D = "doihoahoc" Or Lenhve2D = "trinhsatKGM" Or
                Lenhve2D = "caulacboPD" Or Lenhve2D = "diemnong" Or Lenhve2D = "kvcophandong" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "khuvucBLTieutay" Or Lenhve2D = "baicocchongtang" Then
                CreateLabel3D()
            ElseIf Lenhve2D = "Phaoluutuhanh" Or Lenhve2D = "Phaonongdaituhanh" Or Lenhve2D = "Phaoluunongdaituhanh" Then
                Model3DTQ(sgworld3DBd, GroupBac23DBd)
                If A3D = True Then
                    Model3DTQ(sgworld3DA, GroupBac23DA)
                End If
            ElseIf Lenhve2D = "HiepdongKQPK" Or Lenhve2D = "toTSDN" Or Lenhve2D = "toTSDQTV" Or Lenhve2D = "tramtaptrungQNDB" Or Lenhve2D = "todaccong" Or Lenhve2D = "dontho" Or Lenhve2D = "donthuy" Or Lenhve2D = "tramtaptrungPTKT" Or Lenhve2D = "tramtaptrungQNDBcm" Or Lenhve2D = "kvttllDongvien" Or Lenhve2D = "kvbaidobo" Or Lenhve2D = "tuyenTochucDoihinh" Or Lenhve2D = "tuyenTKdobo" Or Lenhve2D = "tuyenPTdobo" Or Lenhve2D = "tuyenXPdobo" Or
                   Lenhve2D = "tramtiepnhanPTKT" Or Lenhve2D = "tramtiepnhanQNDB" Or Lenhve2D = "tramGiao_nhan" Or Lenhve2D = "Coi82" Or Lenhve2D = "Coi120" Or Lenhve2D = "Coi160" Or Lenhve2D = "tenluaB72" Or Lenhve2D = "tenluaPhagot" Or Lenhve2D = "Phaophanluccotrung" Or Lenhve2D = "PhaophanlucKyhieuchung" Or Lenhve2D = "Phaophanluccolon" Then
                LineArray3D()
                CreateLabel3D()
            ElseIf Lenhve2D = "TauBPkiemtra" Or Lenhve2D = "TauBPbatgiu" Or Lenhve2D = "nganchanBP" Or Lenhve2D = "phuckichBP" Or Lenhve2D = "dayNquayve" Or Lenhve2D = "nganchandamdong" Or Lenhve2D = "tocongtacBP" Or Lenhve2D = "dacnhiemBP" Or Lenhve2D = "Luongraquet" Or Lenhve2D = "BkinhTu" Or Lenhve2D = "Tuyentucanhgioi" Or Lenhve2D = "khongquandanhbien" Or Lenhve2D = "hanhlangbay" Or Lenhve2D = "sanbaycap2" Or Lenhve2D = "sanbaycap1" Or Lenhve2D = "sanbayvuotcap" Or Lenhve2D = "sanbaytrenbien" Or Lenhve2D = "ovatcan" Or Lenhve2D = "KvVatcan" Or Lenhve2D = "tenluacocanhtamgan" Or Lenhve2D = "tenluacocanhtamtrung" Or Lenhve2D = "tenluacocanhtamxa" Or Lenhve2D = "tenluacocanhtamxa2Ranh" Or Lenhve2D = "tenluacocanhtamgan2Ranh" Or Lenhve2D = "tenluacocanhtamtrung2Ranh" Or Lenhve2D = "tamnguytrang" Or Lenhve2D = "luoinguytrang" Or Lenhve2D = "lienlacVT" Or Lenhve2D = "lienlacViba" Or Lenhve2D = "kvvkhatnhanno" Or Lenhve2D = "kvvksinhhoc" Or
                Lenhve2D = "DaiBanchinh" Or Lenhve2D = "BanchanDidong" Or Lenhve2D = "XTchuyenPngu" Or Lenhve2D = "XTPngutrongTD" Or Lenhve2D = "muctieuphaibaove" Or Lenhve2D = "tocodongdiettang" Or Lenhve2D = "coilui" Or Lenhve2D = "DHPNBB" Or Lenhve2D = "DHPNBBXT" Or Lenhve2D = "KvPNthenchot" Or Lenhve2D = "baiminchongtangHTD" Or Lenhve2D = "ANQP" Or Lenhve2D = "kvTKHHxuly" Or Lenhve2D = "muctieuthenchot" Or Lenhve2D = "khudancumoi" Or Lenhve2D = "tuyenthuyloineo" Or Lenhve2D = "tuyenthuyloiday" Or Lenhve2D = "KvTamdung" Or Lenhve2D = "KvDoiTu" Or Lenhve2D = "KvCodong" Or Lenhve2D = "KvTuantieu" Or Lenhve2D = "Langchiendau" Or Lenhve2D = "Cumlangchiendau" Then
                LineArray3D()

            ElseIf Lenhve2D = "vunghoaluc" Then
                VungHL3D(sgworld3DBd)
                If A3D = True Then
                    VungHL3D(sgworld3DA)
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

#End Region

#Region " Mo hinh  &  Doi tuong chuyen dong"

    Private Sub MohinhPB3D()
        Try
            Model3DTQ(sgworld3DBd, GroupBac23DBd)
            If A3D = True Then
                Model3DTQ(sgworld3DA, GroupBac23DA)
            End If
            CreateLabel3D()
            DTvung3D()
            LineArray3D()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub Model3DTQ(sgworldK As SGWorld71, mGroup As String)
        If mModelArray.Count > 0 Then
            Dim Doituong As ITerrainModel71 = Nothing
            For i As Integer = 0 To mModelArray.Count - 1
                Doituong = sgworldK.Creator.CreateModel(mModelArray(i).Position, mModelArray(i).ModelFileName, mModelArray(i).ScaleFactor, ModelTypeCode.MT_NORMAL, mGroup, tenKH)
                Doituong.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
                Doituong.Position.Altitude = Tyle * 20
                Doituong.Position.Pitch = 10
                Doituong.Tooltip.Text = mModelArray(i).Tooltip.Text
            Next
            ZoomLAND(sgworldK, Doituong)
        End If
    End Sub

    Private Sub DTchuyendong3D()
        If mMotionModelArray.Count > 0 Then
            For i As Integer = 0 To mMotionModelArray.Count - 1
                DtChuyendong3DTQ(sgworld3DBd, GroupBac23DBd, mMotionModelArray(i))
                If A3D = True Then
                    DtChuyendong3DTQ(sgworld3DA, GroupBac23DA, mMotionModelArray(i))
                End If
            Next
        End If
    End Sub

    Private Sub DtChuyendong3DTQ(sgworldK As SGWorld71, mGroup As String, dtChuyendong As ITerrainDynamicObject71)
        Dim WaypointArr3D() As IRouteWaypoint71 = Enumerable.Empty(Of IRouteWaypoint71).ToArray
        For i As Integer = 0 To dtChuyendong.Waypoints.Count - 1
            ReDim Preserve WaypointArr3D(0 To dtChuyendong.Waypoints.Count - 1)
            WaypointArr3D(i) = sgworldK.Creator.CreateRouteWaypoint(dtChuyendong.Waypoints.GetWaypoint(i).X, dtChuyendong.Waypoints.GetWaypoint(i).Y, dtChuyendong.Waypoints.GetWaypoint(i).Altitude, dtChuyendong.Waypoints.GetWaypoint(i).Speed, 0, 0, 0, tenKH)
        Next
        Dim DTCD As ITerrainDynamicObject71 = sgworldK.Creator.CreateDynamicObject(WaypointArr3D, dtChuyendong.MotionStyle, dtChuyendong.DynamicType, dtChuyendong.FileName, dtChuyendong.ScaleFactor, dtChuyendong.AltitudeType, mGroup, dtChuyendong.TreeItem.Name)
        DTCD.Tooltip.Text = dtChuyendong.Tooltip.Text
        DTCD.Acceleration = dtChuyendong.Acceleration
        DTCD.CircularRoute = dtChuyendong.CircularRoute
        DTCD.Position.Distance = 10000 * Tyle
        sgworldK.Navigate.FlyTo(DTCD, ActionCode.AC_FOLLOWBEHINDANDABOVE)
    End Sub

#End Region

#Region "  Sua doi tuong"

    Private Sub Suavung3D()
        Suavung(sgworld3DBd, Lenhve2D)
        ZoomTQ(sgworld3DBd)
        If A3D = True Then
            Suavung(sgworld3DA, Lenhve2D)
            ZoomTQ(sgworld3DA)
        End If
    End Sub


    Private Sub SuaDuong3D()
        Suaduong(sgworld3DBd, Lenhve2D)
        ZoomTQ(sgworld3DBd)
        If A3D = True Then
            Suaduong(sgworld3DA, Lenhve2D)
            ZoomTQ(sgworld3DA)
        End If
    End Sub

    'Private Sub DuongtoVung3D()
    '    '   SDuong_Vung(sgworld3DBd)
    '    ZoomTQ(sgworld3DBd)
    '    If A3D = True Then
    '        '   SDuong_Vung(sgworld3DA)
    '        ZoomTQ(sgworld3DA)
    '    End If
    '    '  FrmMain.Instance.panelSuaDT1.Visible = False
    'End Sub

#End Region


End Module


'Public Sub Fly1_2(Wie As Form, AxTE3 As AxTE3DWindowEx, Sgw3DBD12 As SGWorld71, lbBDA As Label, LbFile As ToolStripLabel)
'    Sgw3DBD12 = AxTE3.CreateInstance("TerraExplorerX.SGWorld71")
'    Try
'        If lbBDA.Text <> Trim("Chọn tập tin 3D (*.fly)") Then
'            Sgw3DBD12.Project.Open(file3Dbd, True, Nothing, Nothing)
'            AxTE3.Visible = True
'            Sgw3DBD12.Project.Settings("RemoveSkylineCopyright") = 1
'        Else
'            Wie.Close()
'            Exit Sub
'        End If
'    Catch ex As Exception
'    End Try
'    Sgw3DBD12.Command.Execute(1052, 0)
'    LbFile.Text = Sgw3DBD12.Project.Name
'    Sgw3DBD12.Command.Execute(1065, 0)
'    SOpen(Sgw3DBD12, 0)
'End Sub