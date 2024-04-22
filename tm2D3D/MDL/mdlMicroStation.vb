Imports MicroStationDGN
Imports TerraExplorerX

Module mdlMicroStation

#Region "  Bien"
    Public MS As MicroStationDGN.Application
    Dim mauMSDem As Integer = 0, mauMS As Integer = 0, mauMSDen As Integer = 0, mau3MS As Integer = 0, mau4MS As Integer = 0, mauXanhMS As Integer = 0, mauXamMS As Integer = 0, mauNauMS As Integer = 0, mauChuMS As Integer = 0, mauH2OMS As Integer = 0, mau3ChuMS As Integer = 0
    Dim TyleMS As Double = 0, HesoDuong As Double = 0, HesoTPchu As Double = 0, HesoWGS84 As Double = 0, HesoWGS84Duong As Double = 0
    Dim mLevel As MicroStationDGN.Level
    ReadOnly lc As MicroStationDGN.LineStyle
    Dim Pdgn As MicroStationDGN.Point3d, Pdgn1 As MicroStationDGN.Point3d, GocMS As MicroStationDGN.Point3d
    Declare Function mdlSheetDef_setPaperSize Lib "stdmdlbltin.dll" (ByVal sheetDefIn As Long, ByVal paperWidthIn As Double, ByVal paperHeightIn As Double) As Long
    Declare Function mdlModelRef_loadReferenceModels Lib "stdmdlbltin.dll" (ByVal modelRef As Long, ByVal loadCache As Long, ByVal loadRasterRefs As Long, ByVal loadUndisplayedRefs As Long) As Long
#End Region

    Public Sub OpenDGN()
        FrmMain.Instance.mnuReferenceFile.Enabled = True
        FrmMain.Instance.mnuPDF.Enabled = True
        FrmMain.Instance.mnuAnh_DGN.Enabled = True
        Dim oAL As ApplicationObjectConnector
        If FrmMain.Instance.lbChonMS.Text <> Trim("Chọn tập tin MicroStation") Then
            oAL = New ApplicationObjectConnector
            MS = oAL.Application
            MS.Visible = True
            MS.OpenDesignFile(fileMs, False, MsdV7Action.msdV7ActionUpgradeToV8)
            MS.CadInputQueue.SendKeyin("ct= " & PathData & "\RSC\2D3D.tbl")
            MS.CadInputQueue.SendKeyin("lc=" & "2D3D001")
            MS.AttachCellLibrary(PathData & "\RSC\2D3D.cel", Nothing)
            Dim mT As Integer = 7
            If (myScreens.Length = 1) Then
                If FrmMain.Instance.chebOpen3Dbd.Checked = False Then
                    MS.TopPosition = 0
                    MS.LeftPosition = Screen.PrimaryScreen.WorkingArea.Width / 2 - mT
                    MS.Height = Screen.PrimaryScreen.WorkingArea.Height
                    MS.Width = Screen.PrimaryScreen.WorkingArea.Width / 2 + (mT * 3)
                ElseIf FrmMain.Instance.chebOpen3Dbd.Checked = True Then
                    MS.TopPosition = Screen.PrimaryScreen.WorkingArea.Top + Screen.PrimaryScreen.WorkingArea.Height / 2
                    MS.LeftPosition = Screen.PrimaryScreen.WorkingArea.Left + Screen.PrimaryScreen.WorkingArea.Width / 2 - mT
                    MS.Height = Screen.PrimaryScreen.WorkingArea.Height / 2
                    MS.Width = Screen.PrimaryScreen.WorkingArea.Width / 2 + (mT * 3)
                End If

            ElseIf (myScreens.Length = 2) Then
                If FrmMain.Instance.chebOpen3Dbd.Checked = False Then
                    MS.TopPosition = Screen.AllScreens(1).WorkingArea.Top
                    MS.LeftPosition = Screen.AllScreens(1).WorkingArea.Left - mT
                    MS.Height = Screen.AllScreens(1).WorkingArea.Height
                    MS.Width = Screen.AllScreens(1).WorkingArea.Width + (mT * 3)
                ElseIf FrmMain.Instance.chebOpen3Dbd.Checked = True Then
                    MS.TopPosition = Screen.AllScreens(1).WorkingArea.Top
                    MS.LeftPosition = Screen.AllScreens(1).WorkingArea.Left + Screen.AllScreens(1).WorkingArea.Width / 2 - mT
                    MS.Height = Screen.AllScreens(1).WorkingArea.Height
                    MS.Width = Screen.AllScreens(1).WorkingArea.Width / 2 + (mT * 3)
                End If
            End If
            Level()
            Dim oView As MicroStationDGN.View = MS.ActiveDesignFile.Views(1)
            MS.CadInputQueue.SendKeyin("LINESTYLE SET SCALE ON")
            MS.CadInputQueue.SendKeyin("TASKTOOLBOX CLOSE")
            mMicrostation = True
            oView.Maximize()
            MS.CadInputQueue.SendCommand("fit view extended")
            MS.CadInputQueue.SendKeyin("DMSG CLOSEALLDIALOGS")
            MS.CadInputQueue.SendKeyin("wt=0")
            MS.CadInputQueue.SendKeyin("WINDOW MAXIMIZE")
            MS.Caption = fileMs
        Else
            Exit Sub
        End If
    End Sub

#Region "   Level"
    Private Sub Level()
        Try
            Dim cLevel As MicroStationDGN.Level
            For i As Integer = 1 To 7
                cLevel = MS.ActiveDesignFile.Levels.Find("GD" & i.ToString)
                If cLevel Is Nothing Then
                    cLevel = MS.ActiveDesignFile.AddNewLevel("GD" & i.ToString)
                    MS.ActiveDesignFile.Levels.Rewrite()
                End If
            Next
            cLevel = MS.ActiveDesignFile.Levels.Find("Trinh bay")
            If cLevel Is Nothing Then
                cLevel = MS.ActiveDesignFile.AddNewLevel("Trinh bay")
                MS.ActiveDesignFile.Levels.Rewrite()
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ChonLeveltheoGiaidoan()
        Dim sTT As Integer
        If mNetwork = False Then
            sTT = FrmMain.Instance.cbGiaidoan.SelectedIndex + 1
        Else

            sTT = System.Convert.ToInt32(GiaidoanNet.Substring(2, 1))
        End If
        Dim tenGD As String
        tenGD = "GD" & sTT.ToString
        MS.ActiveSettings.Level = MS.ActiveDesignFile.Levels.Find(tenGD, Nothing)
        mLevel = MS.ActiveDesignFile.Levels.Find(tenGD, Nothing)
        If lenhveMS = "vekhung" Or lenhveMS = "Trinhbay" Then
            MS.ActiveSettings.Level = MS.ActiveDesignFile.Levels.Find("Trinh bay", Nothing)
            mLevel = MS.ActiveDesignFile.Levels.Find("Trinh bay", Nothing)
        ElseIf lenhveMS = "veco" Or lenhveMS = "Taungam" Then
            MS.CadInputQueue.SendKeyin("mdl load calculat;calculat tcb->lineStyle.scale= " & 0)
            MS.CadInputQueue.SendKeyin("lc=" & "0")
        Else
            MS.CadInputQueue.SendKeyin("mdl load calculat;calculat tcb->lineStyle.scale= 1") ' & 1)
        End If
    End Sub

#End Region

    Private Sub SMauMS(tenGD As String, TenTaDP As String)
        mauXanhMS = 223
        mauNauMS = 224
        mauXamMS = 222
        mauH2OMS = 7
        If TenTaDP = "0" Then
            mauMS = 3
            mau3MS = 1
            mauMSDen = 10
            mauChuMS = 10
            mau3ChuMS = 1
        ElseIf TenTaDP = "1" Then
            mauMS = 1
            mau3MS = 3
            mauMSDen = 1
            mauChuMS = 1
            mau3ChuMS = 10
        End If
        mauMSDem = mauMS + (System.Convert.ToInt32(tenGD.Substring(2, 1)) * 2)
        mau4MS = mau3MS + (System.Convert.ToInt32(tenGD.Substring(2, 1)) * 2)
        If mNetwork = False Then
            If TenTaDP = "0" Then
                If mauKT = True Then
                    mauMSDem = mauXamMS
                    mauMS = mauMSDen
                Else
                    mauMSDem = mauMSDem
                    mauMS = mauMS
                End If
            ElseIf TenTaDP = "1" Then
                mauMS = mauMS
                If mauKT = True Then
                    mauMSDem = 203
                Else
                    mauMSDem = mauMSDem
                End If
            End If

        End If


    End Sub

    Private Sub MauTQ()
        If lenhveMS = "gopvung2" Or lenhveMS = "catvung2" Or lenhveMS = "catvung" Or lenhveMS = "giaovung" Or lenhveMS = "gopvung" Or lenhveMS = "chuyenGroup" Or lenhveMS = "chuyenGroupNet" Or lenhveMS = "chuyenDTNet" Then
            If FrmMain.Instance.txtGroup.Text.Contains(",") Then
                Giaidoan = FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(0)
                tenKH = FrmMain.Instance.txtGroup.Text.Split(",")(0).Split("\")(1)
            Else
                Giaidoan = FrmMain.Instance.txtGroup.Text.Split("\")(0)
                tenKH = FrmMain.Instance.txtGroup.Text.Split("\")(1)
            End If

        End If
        Giaidoan = "GD" & (FrmMain.Instance.cbGiaidoan.SelectedIndex + 1).ToString
        If mNetwork = False Then
            SMauMS(Giaidoan, FrmMain.Instance.cbTa_DP.SelectedIndex.ToString)
        Else
            SMauMS(GiaidoanNet, mKHTa_DP)
        End If
    End Sub

    Function ConvertColorMs(maMau As String) As Integer
        Dim mauDT As Integer = 0
        Select Case maMau
            Case "16711680"
                mauDT = 200
            Case "16737535"
                mauDT = 202
            Case "16776960"
                mauDT = 204
            Case "15384855"
                mauDT = 206
            Case "16282673"
                mauDT = 208
            Case "15818779"
                mauDT = 210
            Case "11075328"
                mauDT = 212
            Case "3322980"
                mauDT = 214
            Case "255"
                mauDT = 201
            Case "65535"
                mauDT = 203
            Case "46335"
                mauDT = 205
            Case "2003199"
                mauDT = 207
            Case "4419310"
                mauDT = 209
            Case "1602765"
                mauDT = 211
            Case "39835"
                mauDT = 213
            Case "65535" 'Mau Xam
                mauDT = 222
            Case "3725312" 'Mau Xanh
                mauDT = 223
            Case "15759872" 'Mau Nau
                mauDT = 224
            Case "0" 'Mau den
                mauDT = 10
            Case "855309" 'Mau den
                mauDT = 10
            Case "0" 'Mau den
                mauDT = 10
            Case "9539985" 'Mau Xam
                mauDT = 222
            Case "13816320"  'Vang
                mauDT = 4
            Case "12779520"
                mauDT = 3
            Case "16772876" 'Mau HH
                mauDT = 28
            Case "16737280" 'MauNau
                mauDT = 6
            Case "16777215" 'MauTrang
                mauDT = 0
        End Select
        ConvertColorMs = mauDT
    End Function

    Private Sub STyleMS()
        If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
            HesoWGS84 = 12000
            HesoWGS84Duong = 90000
        Else
            HesoWGS84 = 1
            HesoWGS84Duong = 4 ' 1
        End If
        TyleMS = (Tyle * 2.4) / HesoWGS84 ' HesoWGS84 ' TyleMS = (Tyle * 2.4) / HesoWGS84
        HesoDuong = (Dorongduong / 15.0) / HesoWGS84Duong
        HesoTPchu = Tyle * 20
    End Sub

    Public Sub MicroStation()
        If lenhveMS2 = "dichuyen" Then
            ToadoMs(mPointMS1)
            Dim oView As MicroStationDGN.View
            oView = MS.ActiveDesignFile.Views(1)
            oView.Center = Pdgn
            oView.Redraw()
        End If

        If lenhveMS = "" Then
            Exit Sub
        Else
            'MsgBox("LenhveMs = " & lenhveMS)
            STyleMS()
            ChonLeveltheoGiaidoan()
            MauTQ()
            MS.ActiveSettings.LineWeight = 0
            MS.CadInputQueue.SendKeyin("choose none")
            If mChebNhom = True Then
                MS.CadInputQueue.SendKeyin("mdl silentload selectby;Select type none;selectby type cell; selectby cellname " & tenKH & ";selectby level " & Giaidoan & ";selectby execute")
                MS.CadInputQueue.SendKeyin("mdl unload selectby")
            End If
            '  MsgBox(Bd3D.ToString & ",,," & mMicrostation.ToString)
            If lenhveMS = "vekhung" Or lenhveMS = "Trinhbay" Or lenhveMS = "XoaGrtheoDT" Or lenhveMS = "XoaGroup2" Then
                SXoaDT()
            End If

            If lenhveMS = "Venhieuco" Or lenhveMS = "veco" Or lenhveMS = "Taungam" Or lenhveMS = "TaungamPB" Or lenhveMS = "kvchupanh" Then
                MultiCells()
                'ElseIf lenhveMS = "pdf" Then
                '    PDF()
            ElseIf lenhveMS = "Doituongchu" Then
                TextMsArray(mLabelArray)
            ElseIf lenhveMS = "chuyenGroup" Or lenhveMS = "transLABEL" Or lenhveMS = "transMODEL" Or lenhveMS = "transPOLYLINE" Or lenhveMS = "transPOLYGON" Then
                TransGroupMS()
            ElseIf lenhveMS = "ModelNet" Or lenhveMS = "ModelNet" Or lenhveMS = "Phaobobien" Or lenhveMS = "PhaoMDbanbien" Or lenhveMS = "pTuhanh" Or lenhveMS = "pNDTuhanh" Or lenhveMS = "plNDTuhanh" Or
                lenhveMS = "mohinhPB" Or lenhveMS = "ModelNet" Or lenhveMS = "Phaoluutuhanh" Or lenhveMS = "Phaonongdaituhanh" Or lenhveMS = "Phaoluunongdaituhanh" Then
                ModelMs()
            ElseIf lenhveMS = "ChieusauTS" Or lenhveMS = "MBchupanhTS" Or lenhveMS = "Gioituyen" Or lenhveMS = "veduongsongsong" Or lenhveMS = "duongbienphong" Or lenhveMS = "giaothonghao" Or lenhveMS = "Doituongduong" Or lenhveMS = "LineNet" Or lenhveMS = "nhiemvutruocmat" Or lenhveMS = "nhiemvutieptheo" Or lenhveMS = "TuyengiaoNvu" Or lenhveMS = "Daihiepdong" Or
           lenhveMS = "tuyendanhchan" Or lenhveMS = "kvTuantieu" Or lenhveMS = "Giaothonghaoconap" Or lenhveMS = "toTrsTrongdich" Or lenhveMS = "toTrSDieutra" Or lenhveMS = "capdachien" Or lenhveMS = "capquang" Or lenhveMS = "capdongtruc" Or lenhveMS = "capnguondien" Or lenhveMS = "capliendai" Or lenhveMS = "DbanMtuy" Or lenhveMS = "Diaban" Or
           lenhveMS = "doboduongkhong" Or lenhveMS = "doboduongkhongTrT" Or lenhveMS = "Tieptebangdu" Or lenhveMS = "kvkhoinguytrang" Or lenhveMS = "tuyenkhoinguytrang" Or lenhveMS = "kvVaybat" Or lenhveMS = "vetNXdudoan" Or lenhveMS = "vetNXthucte" Or lenhveMS = "kvTKHHdukien" Or lenhveMS = "hangraobungnhung" Or lenhveMS = "diadao" Or lenhveMS = "cuma" Or lenhveMS = "TrTbiHH" Or lenhveMS = "DDbotrimin" Or
           lenhveMS = "TSTiengdong" Or lenhveMS = "tuyenbanCS" Or lenhveMS = "BanChsangChihuongTC" Or lenhveMS = "BanCSphanchiaGioituyen" Or lenhveMS = "duonglanhhai" Or lenhveMS = "SungBBbanMB" Or lenhveMS = "tuyenbancodinh" Or lenhveMS = "2130004" Or lenhveMS = "catduong" Or lenhveMS = "noiduong" Or lenhveMS = "KvTrSHHBangMB" Or lenhveMS = "kvgiaochien" Or
           lenhveMS = "Duongongxangdaucodinh" Or lenhveMS = "Duongongxangdaudachien" Or lenhveMS = "dexungyeu" Or lenhveMS = "satlo" Or lenhveMS = "TuongCoRaogai" Or lenhveMS = "duonghanhquantaudobo" Or lenhveMS = "duonghanhquantauchiendau" Or lenhveMS = "hamphao" Or lenhveMS = "hamVK" Or lenhveMS = "hambetong" Or lenhveMS = "Duongcothhacanh" Or lenhveMS = "BkinhMB" Or
           lenhveMS = "duonghanhquantaudobo" Or lenhveMS = "duonghanhquantauvantai" Or lenhveMS = "2130003" Or lenhveMS = "2130002" Or lenhveMS = "2130001" Or lenhveMS = "2130007" Or lenhveMS = "2130006" Or lenhveMS = "2130005" Or lenhveMS = "hoalucV" Or lenhveMS = "hoalucCN" Or lenhveMS = "tuyenVCkhongno" Or lenhveMS = "tuyenVChonhop" Or lenhveMS = "tuyenRMhonhop" Or lenhveMS = "tuyenRMbangTrT" Or
           lenhveMS = "KVdongquan" Or lenhveMS = "khuvucphongthutrongdiem" Or lenhveMS = "khuvucphaigiu" Or lenhveMS = "khuvucphongthuthenchot" Or lenhveMS = "KVTrinhsatSN" Or lenhveMS = "KVTrinhsatSCN" Or lenhveMS = "KvTRanhchap" Or lenhveMS = "KvXamcanh" Or lenhveMS = "KvBdCongnghe" Or lenhveMS = "TuyenMBcatcanh" Or lenhveMS = "tuyenthoay" Or
           lenhveMS = "cancuhauphuong" Or lenhveMS = "cancuchiendau" Or lenhveMS = "ANQP" Or lenhveMS = "KvDichmoiden" Or lenhveMS = "MTCanbaove" Or lenhveMS = "KvLanchiem" Or lenhveMS = "CCCDBP" Or lenhveMS = "KvHoaluc" Or lenhveMS = "KvTieutay" Or lenhveMS = "KVbitran" Or lenhveMS = "KvKho" Or lenhveMS = "KvKT" Or lenhveMS = "baihacanh" Or lenhveMS = "TuyenchuyentiepChuy" Or
           lenhveMS = "KVNgapnuoc" Or lenhveMS = "KVCatvui" Or lenhveMS = "KvKhotrandau" Or lenhveMS = "KvTautrandau" Or lenhveMS = "KvGkhoantrandau" Or lenhveMS = "KvCamTbVTD" Or lenhveMS = "KvBvMtieuBangGnhieungoinoVT" Or lenhveMS = "KvBiphahuyHN" Or lenhveMS = "cuamoBB" Or lenhveMS = "cuamoXT" Or lenhveMS = "kvtsmatdat" Or lenhveMS = "kvtstrenkhong" Or lenhveMS = "HQhanhquan" Or
           lenhveMS = "caucogioi" Or lenhveMS = "CaugoCaubetong" Or lenhveMS = "Causat" Or lenhveMS = "Caungam" Or lenhveMS = "Cautreo" Or lenhveMS = "Cautre" Or lenhveMS = "CauPMP" Or lenhveMS = "Caubidanhpha" Or lenhveMS = "BenloiBB" Or lenhveMS = "BenloiOto" Or lenhveMS = "BenloiXT" Or lenhveMS = "BenvuotBangthuyen" Or lenhveMS = "BenvuotsongPha" Or lenhveMS = "BenPhatuhanh" Or lenhveMS = "BenvuotsongnhieuPT" Or
           lenhveMS = "DgVongtranh" Or lenhveMS = "DgTieudoc" Or lenhveMS = "AntoanHatnhan" Or lenhveMS = "GioiHanHatnhan" Or lenhveMS = "HrNganthuyloi" Or lenhveMS = "DDgnguytrangLuoi" Or lenhveMS = "DDgdichphahoai" Or lenhveMS = "DDgdichphahoaiMB" Or lenhveMS = "DDGngapnuoc" Or lenhveMS = "DgVongtranh" Or lenhveMS = "DDgCoDichmatdat" Or lenhveMS = "Phacau" Or lenhveMS = "Phaduong" Or
            lenhveMS = "GioihanvungTrSDientuSN" Or lenhveMS = "GioihanvungTrSdienttuSCNVHF" Or lenhveMS = "GioihanvungTrSdientuSCNUHF" Or lenhveMS = "GioihanvungTrSDTsieucaotan" Or lenhveMS = "GihanVungcheap" Or lenhveMS = "Caugiabangmatphanxa" Or lenhveMS = "Manchanchongrada" Or lenhveMS = "Moibayhongngoai" Or lenhveMS = "GiHanNvuTCDT" Or
            lenhveMS = "KnNguytrangcongTrSrada" Or lenhveMS = "LLTructiep" Or lenhveMS = "LLVuotcap" Or lenhveMS = "LLHiepdong" Or lenhveMS = "LLthuongxuyen2" Or lenhveMS = "KvNhieutieucuc" Or lenhveMS = "KvBandoclaptieudoan" Or lenhveMS = "KvBanDoclapDaidoi" Or lenhveMS = "KvBanTTrTieudoan" Or lenhveMS = "KvBanTTrDaidoi" Or
            lenhveMS = "HuongTCChuyeuKQchendich" Or lenhveMS = "HuongTCThuyeuKQchendich" Or lenhveMS = "HuongTCChuyeuKQchienthuat" Or lenhveMS = "khongquandanhbien" Or lenhveMS = "danhhuongchuyeuHQ" Or lenhveMS = "danhhuongthuyeuHQ" Or lenhveMS = "tuyenPHkoLTlon" Or lenhveMS = "tuyenPHLTLon" Then
                SDuongMsAr()
            ElseIf lenhveMS = "Trinhbay" Then
                TrinhbayMS()
            ElseIf lenhveMS = "duongtovung" Or lenhveMS = "vungtoduong" Or lenhveMS = "gopvung2" Or lenhveMS = "gopvung" Or lenhveMS = "catvung2" Or lenhveMS = "catvung" Or lenhveMS = "giaovung" Then 'Or lenhveMS = "catduong"
                SuaVungMs()
                'ElseIf lenhveMS = "duongtovung" Or lenhveMS = "catduong" Or lenhveMS = "noiduong" Then
                '    Vung_DuongMs()
            Else
                VungArrayMS2()
            End If
            lenhveMS = ""
            lenhveMS2 = ""
            FrmMain.Instance.BienEmpty()
            mNetwork = False
        End If

    End Sub

    Private Sub ToadoMs(cPoint As IPosition71)
        FrmMain.Instance.SVn2000(cPoint)
        Pdgn.X = yVN2000
        Pdgn.Y = xVN2000
        Pdgn.Z = 0
        Pdgn1.X = yVN2000
        Pdgn1.Y = xVN2000 + 100
        Pdgn1.Z = 0

        'If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
        '    'Pdgn.X = cPoint.X
        '    'Pdgn.Y = cPoint.Y
        '    'Pdgn.Z = 0
        '    'Pdgn1.X = cPoint.X
        '    'Pdgn1.Y = cPoint.Y + 100
        '    'Pdgn1.Z = 0


        '    Pdgn.X = cPoint.Y
        '    Pdgn.Y = cPoint.X
        '    Pdgn.Z = 0
        '    Pdgn1.X = cPoint.Y
        '    Pdgn1.Y = cPoint.X + 100
        '    Pdgn1.Z = 0



        'Else
        '    FrmMain.Instance.SVn2000(cPoint)
        '    Pdgn.X = yVN2000
        '    Pdgn.Y = xVN2000
        '    Pdgn.Z = 0
        '    Pdgn1.X = yVN2000
        '    Pdgn1.Y = xVN2000 + 100
        '    Pdgn1.Z = 0
        'End If
    End Sub

    Private Sub ToadoMsDiemxoay(cPoint As IPosition71)
        If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
            GocMS.X = cPoint.X
            GocMS.Y = cPoint.Y
            GocMS.Z = 0
        Else
            FrmMain.Instance.SVn2000(cPoint)
            GocMS.X = yVN2000
            GocMS.Y = xVN2000
            GocMS.Z = 0
        End If
    End Sub

    Private Sub TextMSTQ(mChu As ITerrainLabel71, MauText As Integer, dx As Double, dy As Double)
        ToadoMs(mChu.Position)
        STyleMS()
        If mChu.Text = "" Then
            Exit Sub
        Else
            If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
                dx = dx
                dy = dy
                HesoTPchu = HesoTPchu
            Else
                dx *= 10
                dy *= 10
                HesoTPchu /= 10
            End If
            If mChu.ImageFileName = "" Then
                dx = dx
                dy = dy
            Else
                Dim mFileName As String = mChu.ImageFileName.Substring(mChu.ImageFileName.LastIndexOf("\")).Split("\")(1)
                Dim Ta_DP As String = mFileName.Split(".")(0).Substring(mFileName.Split(".")(0).Length - 2, 1)
                Dim sChieuKH As String
                If mFileName.Contains("N") Then
                    sChieuKH = "N"
                Else
                    sChieuKH = ""
                End If
                If Ta_DP = "1" Then
                    If sChieuKH = "N" Then
                        dx = dx
                    Else
                        dx = -1 * dx
                    End If
                ElseIf Ta_DP = "2" Then
                    If sChieuKH = "N" Then
                        dx = -1 * dx
                    Else
                        dx = dx
                    End If
                End If
            End If
            Dim PdgnChu As MicroStationDGN.Point3d
            PdgnChu.X = Pdgn.X + (dx * TyleMS)
            PdgnChu.Y = Pdgn.Y + (dy * TyleMS)
            Dim ele As MicroStationDGN.Element = Nothing
            Dim Kieuchu As MicroStationDGN.TextStyle = MS.ActiveSettings.TextStyle
            Kieuchu.Font = MS.ActiveDesignFile.Fonts.Find(MsdFontType.msdFontTypeWindowsTrueType, "UTM Cafeta") ' "UTM HelvetIns") ".VnArial Narrow" "Arial Narrow"
            Kieuchu.Height = (mChu.Style.Scale * System.Convert.ToDouble(mChu.Style.FontSize) * TyleMS) / HesoTPchu * 0.85
            Kieuchu.Width = Kieuchu.Height * 0.6
            If lenhveMS = "Trinhbay" Or lenhveMS = "Taungam" Then
                Kieuchu.Width *= 0.74
                Kieuchu.Height *= 0.74
            End If
            Kieuchu.IsBold = True
            If lenhveMS = "Taungam" Then
                Kieuchu.Justification = MsdTextJustification.msdTextJustificationCenterBottom
            ElseIf lenhveMS = "Trinhbay" Then
                Kieuchu.Justification = MsdTextJustification.msdTextJustificationCenterTop '
            Else
                If loaiKH = "100008" Or loaiKH = "1100008" Or loaiKH = "2000015" Or
                       loaiKH = "2000115" Or loaiKH = "130014" Or loaiKH = "280114" Or loaiKH = "140007" Or loaiKH = "130006" Or loaiKH = "130007" Or
                       loaiKH = "100009" Or loaiKH = "1100009" Or loaiKH = "130008" Or loaiKH = "130015" Or loaiKH = "280115" Or loaiKH = "140008" Or
                       loaiKH = "130009" Or loaiKH = "100010" Or loaiKH = "1100010" Or loaiKH = "280116" Or loaiKH = "140009" Or loaiKH = "130010" Or
                       loaiKH = "130011" Or loaiKH = "130016" Or loaiKH = "130013" Or loaiKH = "130012" Then
                    Kieuchu.Justification = MsdTextJustification.msdTextJustificationLeftCenter
                ElseIf loaiKH = "130000" Or loaiKH = "1200001" Or loaiKH = "130001" Then
                    Kieuchu.Justification = MsdTextJustification.msdTextJustificationRightCenter
                Else
                    Kieuchu.Justification = MsdTextJustification.msdTextJustificationCenterCenter
                End If
            End If
            If lenhveMS = "dienngingo" Then
                mChu.Text = "?"
            End If
            mChu.Text.Replace("              ", "")
            Dim ChuMs As MicroStationDGN.TextElement = MS.CreateTextElement1(ele, mChu.Text, PdgnChu, MS.Matrix3dIdentity)
            ChuMs.DisplayPriority = 5
            ChuMs.TextStyle = Kieuchu
            ChuMs.TextStyle.Justification = Kieuchu.Justification
            ChuMs.Color = MauText
            ChuMs.Level = mLevel
            MS.ActiveModelReference.AddElement(ChuMs)
            ChuMs.Redraw(MsdDrawingMode.msdDrawingModeNormal)
            MS.CommandState.StartDefaultCommand()
            MS.ActiveModelReference.SelectElement(ChuMs)
        End If
        '  HesoTPchu = 0
    End Sub

    Private Sub TransGroupMS()
        MultiCells()
        SDuongMsAr()
        VungArrayMS2()
        ModelMs()
        MS.CadInputQueue.SendKeyin("group selection")
        MS.CadInputQueue.SendKeyin("choose none")
        Lenhve = ""
        lenhveMS = ""
    End Sub

#Region " Cell MicroDtation"

    Function SoCell(cLoaiKH As String) As Integer
        Dim sCell As Integer ' cLoaiKH = "260009" Or
        If cLoaiKH = "1200002" Or cLoaiKH = "1200003" Or cLoaiKH = "1200004" Or cLoaiKH = "260009" Or cLoaiKH = "26b015" Or cLoaiKH = "610030" Or cLoaiKH = "410100" Or cLoaiKH = "410029" Or cLoaiKH = "410080" Or cLoaiKH = "410092" Or cLoaiKH = "410020" Or
            cLoaiKH = "1300012" Or cLoaiKH = "260010" Or cLoaiKH = "260011" Or cLoaiKH = "260016" Or cLoaiKH = "260014" Or cLoaiKH = "250019" Or cLoaiKH = "250020" Or cLoaiKH = "270294" Or cLoaiKH = "270295" Or cLoaiKH = "410081" Or cLoaiKH = "21200003" Or cLoaiKH = "21200002" Or cLoaiKH = "21200004" Or
           cLoaiKH = "270296" Or cLoaiKH = "270297" Or cLoaiKH = "270298" Or cLoaiKH = "270299" Or cLoaiKH = "270274" Or cLoaiKH = "270275" Or cLoaiKH = "270282" Or cLoaiKH = "270283" Or cLoaiKH = "270284" Or cLoaiKH = "70005" Or cLoaiKH = "70006" Or cLoaiKH = "70007" Or cLoaiKH = "70008" Or cLoaiKH = "70009" Or cLoaiKH = "70010" Or cLoaiKH = "70011" Or
           cLoaiKH = "270285" Or cLoaiKH = "270286" Or cLoaiKH = "270287" Or cLoaiKH = "270288" Or cLoaiKH = "270289" Or cLoaiKH = "270290" Or cLoaiKH = "270291" Or cLoaiKH = "270292" Or cLoaiKH = "270293" Or cLoaiKH = "2110034" Or cLoaiKH = "2110033" Or cLoaiKH = "2110032" Or cLoaiKH = "2110035" Or
           cLoaiKH = "610018" Or cLoaiKH = "261013" Or cLoaiKH = "261014" Or cLoaiKH = "251017" Or cLoaiKH = "251018" Or cLoaiKH = "251019" Or cLoaiKH = "610023" Or cLoaiKH = "1200026" Or cLoaiKH = "1200037" Then
            sCell = 3
        ElseIf lenhveMS = "hamchong" Or lenhveMS = "baicocchongtang" Or lenhveMS = "tuyenRMbangTrT" Or lenhveMS = "mohinhPB" Or cLoaiKH = "261017" Or cLoaiKH = "261018" Or cLoaiKH = "261019" Or cLoaiKH = "261020" Or cLoaiKH = "261021" Or cLoaiKH = "1200125" Or cLoaiKH = "1200225" Or cLoaiKH = "1200325" Or cLoaiKH = "1200425" Or cLoaiKH = "1200525" Then
            sCell = 1
        Else
            sCell = 2
        End If
        SoCell = sCell
    End Function

    Private Sub MauCell(soGD As Integer, cTA_DP As String, dtMS As MicroStationDGN.CellElement, P As String, sCell As Integer, cLoaiKH As String)
        mauXanhMS = 223
        mauNauMS = 224
        mauXamMS = 222
        If cTA_DP = "1" Then
            mauMS = 200
            mau3MS = 201
            mauMSDen = 10
        ElseIf cTA_DP = "2" Then
            mauMS = 201
            mau3MS = 200
            mauMSDen = 201
        End If
        mauMSDem = mauMS + (soGD * 2)
        mau4MS = mau3MS + (soGD * 2)

        If P = "P" Then
            Select Case sCell
                Case 1
                    dtMS.Color = mauMSDen
                Case 2
                    dtMS.Color = mauXamMS
                Case 3
                    dtMS.Color = 6
            End Select
        End If
        If P = "" Then
            Select Case sCell
                Case 1
                    If cLoaiKH = "260011" Or cLoaiKH = "251001" Or cLoaiKH = "250004" Then
                        dtMS.Color = mauXanhMS
                    ElseIf cLoaiKH = "2110035" Or cLoaiKH = "1300016" Or cLoaiKH = "261018" Or cLoaiKH = "261017" Or cLoaiKH = "1200030" Or cLoaiKH = "1200031" Or cLoaiKH = "1200032" Or cLoaiKH = "2130036" Then
                        dtMS.Color = mauMSDen
                    ElseIf cLoaiKH = "250005" Or cLoaiKH = "250006" Or cLoaiKH = "82017" Or cLoaiKH = "82018" Or cLoaiKH = "82019" Or cLoaiKH = "2110034" Or cLoaiKH = "2110033" Or cLoaiKH = "2110032" Or cLoaiKH = "1200025" Then
                        dtMS.Color = mau3MS
                    Else
                        dtMS.Color = mauMS
                    End If
                Case 2
                    If cLoaiKH = "1300017" Or cLoaiKH = "1300018" Then
                        dtMS.Color = mauMSDen
                    ElseIf cLoaiKH = "250005" Or cLoaiKH = "250006" Or cLoaiKH = "82017" Or cLoaiKH = "82018" Or cLoaiKH = "82019" Or cLoaiKH = "2110034" Or cLoaiKH = "2110033" Or cLoaiKH = "2110032" Or cLoaiKH = "1200025" Then
                        dtMS.Color = mau4MS
                    Else
                        dtMS.Color = mauMSDem
                    End If
                Case 3
                    If cLoaiKH = "260011" Or cLoaiKH = "260010" Or cLoaiKH = "2110034" Or cLoaiKH = "2110033" Or cLoaiKH = "2110032" Then
                        dtMS.Color = mauMS
                    ElseIf cLoaiKH = "260014" Or cLoaiKH = "260009" Or cLoaiKH = "250019" Or cLoaiKH = "250020" Or cLoaiKH = "13000121" Or cLoaiKH = "261002" Or cLoaiKH = "1200037" Or cLoaiKH = "1200036" Then
                        dtMS.Color = mau3MS
                    ElseIf cLoaiKH = "270282" Or cLoaiKH = "270283" Or cLoaiKH = "270284" Or cLoaiKH = "270285" Or cLoaiKH = "270286" Or cLoaiKH = "260016" Or cLoaiKH = "251017" Or cLoaiKH = "251018" Or cLoaiKH = "251019" Or cLoaiKH = "270287" Or cLoaiKH = "270288" Or cLoaiKH = "270289" Or
                        cLoaiKH = "26b015" Or cLoaiKH = "270290" Or cLoaiKH = "270291" Or cLoaiKH = "270292" Or cLoaiKH = "270293" Or cLoaiKH = "270294" Or cLoaiKH = "270295" Or cLoaiKH = "270296" Or cLoaiKH = "270297" Or cLoaiKH = "270298" Or cLoaiKH = "270299" Then
                        dtMS.Color = mauMSDen
                    ElseIf cLoaiKH = "13000122" Then
                        dtMS.Color = mau4MS
                    ElseIf cLoaiKH = "13000123" Then
                        dtMS.Color = mauMS
                    ElseIf cLoaiKH = "261013" Or cLoaiKH = "261014" Then
                        dtMS.Color = 4
                    ElseIf cLoaiKH = "2110035" Then
                        dtMS.Color = mauNauMS
                    ElseIf cLoaiKH = "21200002" Or cLoaiKH = "21200003" Or cLoaiKH = "21200004" Or cLoaiKH = "1200002" Or cLoaiKH = "1200003" Or cLoaiKH = "1200004" Then
                        dtMS.Color = mauXanhMS
                    Else
                        dtMS.Color = mauChuMS
                    End If
                    dtMS.DisplayPriority = 3
            End Select
        End If
    End Sub

    Private Sub ChieuCell(mCell As MicroStationDGN.CellElement)
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 0 Or mKHTa_DP = "0" Then
            If FrmMain.Instance.cbChieuKH.SelectedIndex = 1 Or mChieuKH = "1" Then
                mCell.Mirror(Pdgn, Pdgn1)
            End If
        End If
        If FrmMain.Instance.cbTa_DP.SelectedIndex = 1 Or mKHTa_DP = "1" Then
            If FrmMain.Instance.cbChieuKH.SelectedIndex = 0 Or mChieuKH = "0" Then
                mCell.Mirror(Pdgn, Pdgn1)
            End If
        End If
    End Sub

    Private Sub MultiCells()
        Dim Ta_DP As String, cLoaiKH As String
        If mLabelArray.Count > 0 Then
            Dim mScale As MicroStationDGN.Point3d
            mScale.X = TyleMS
            mScale.Y = TyleMS
            For i As Integer = 0 To mLabelArray.Count - 1
                Dim cLabel As ITerrainLabel71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mLabelArray(i).ID)
                ToadoMs(cLabel.Position)

                If lenhveMS = "Venhieuco" Then
                    If i >= 1 Then
                        Pdgn.Y += (Val(cLabel.Tooltip.Text.Split(",")(1)) * TyleMS) - (70 * i * TyleMS)
                    End If
                End If

                Dim dtMS As MicroStationDGN.CellElement

                If cLabel.ImageFileName = "" Then
                    GoTo txt
                Else
                    GoTo image
                End If
image:
                Dim mFileName As String = cLabel.ImageFileName.Substring(cLabel.ImageFileName.LastIndexOf("\")).Split("\")(1)
                Dim P As String
                If mFileName.Contains("P") Then
                    mFileName = mFileName.Replace("P", "")
                    P = "P"
                Else
                    P = ""
                End If
                If mFileName.Contains("N") Then 'MauDemKT
                    mFileName = mFileName.Replace("N", "")
                End If
                cLoaiKH = Mid(mFileName, 1, mFileName.Count - 6)

                Dim mThumuc As String = cLabel.ImageFileName.Split("\")(cLabel.ImageFileName.Split("\").Count - 2) '(paraLebel(11).Length - 1)
                If mThumuc = "2XD2" Then
                    cLoaiKH = cLoaiKH.Substring(1, cLoaiKH.Length - 1)
                Else
                    cLoaiKH = cLoaiKH
                End If
                Dim sCell As Integer = SoCell(cLoaiKH)
                Dim soGD As Integer = System.Convert.ToInt32(mFileName.Split(".")(0).Substring(mFileName.Split(".")(0).Length - 1, 1))
                Ta_DP = mFileName.Split(".")(0).Substring(mFileName.Split(".")(0).Length - 2, 1)
                For j As Integer = 1 To sCell
                    Dim tenCell As String = cLoaiKH & j.ToString
                    ' MsgBox(tenCell)
                    dtMS = MS.CreateCellElement2(tenCell, Pdgn, mScale, True, MS.Matrix3dIdentity)
                    Dim Oridy As Integer
                    If j = 1 Then
                        Oridy = 2
                    ElseIf j = 3 Then
                        Oridy = 3
                    Else
                        Oridy = 0
                    End If
                    dtMS.DisplayPriority = Oridy
                    MauCell(soGD, Ta_DP, dtMS, P, j, cLoaiKH)
                    dtMS.Level = mLevel
                    ChieuCell(dtMS)
                    MS.ActiveModelReference.AddElement(dtMS)
                    dtMS.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                    MS.CommandState.StartDefaultCommand()
                    MS.ActiveModelReference.SelectElement(dtMS)
                Next
txt:
                '   MsgBox(loaiKH)
                If loaiKH = "218045" Or loaiKH = "218046" Or loaiKH = "218047" Then
                    cLabel.Text = "LT"
                ElseIf loaiKH = "218044" Then
                    cLabel.Text = "TH"
                    'ElseIf loaiKH = "" Then
                    '    cLabel.Text = "KT"
                ElseIf loaiKH = "218055" Or loaiKH = "218056" Then
                    cLabel.Text = "scVK"
                ElseIf loaiKH = "218057" Or loaiKH = "218058" Then
                    cLabel.Text = "KĐKT"
                ElseIf loaiKH = "218059" Then
                    cLabel.Text = "CK"
                ElseIf loaiKH = "218062" Then
                    cLabel.Text = "TTG"
                End If

                If cLabel.Text <> "" Then
                    If lenhveMS = "Taungam" Then
                        If loaiKH = "260005" Or loaiKH = "260006" Or loaiKH = "260010" Or loaiKH = "260007" Or loaiKH = "260008" Or loaiKH = "260009" Or loaiKH = "260011" Or loaiKH = "250020" Or loaiKH = "218044" Or loaiKH = "218045" Or loaiKH = "218046" Or loaiKH = "218047" Then 'Or loaiKH = "218044" Or loaiKH = "218045" Or loaiKH = "218046" Or loaiKH = "218047"
                            TextMSTQ(cLabel, mauChuMS, 0, 5)
                        Else
                            TextMSTQ(cLabel, mauChuMS, 0, -5)
                        End If

                    ElseIf lenhveMS = "Venhieuco" Then
                        If i = 0 Then
                            TextMSTQ(cLabel, mauChuMS, 30, 52.5)
                        Else
                            TextMSTQ(cLabel, mauChuMS, 30, 26.0 - (i * 9.0))
                        End If
                    ElseIf loaiKH = "100008" Or loaiKH = "1100008" Or loaiKH = "2000015" Or
                       loaiKH = "2000115" Or loaiKH = "130014" Or loaiKH = "280114" Or loaiKH = "140007" Or loaiKH = "130006" Or loaiKH = "130007" Or
                       loaiKH = "100009" Or loaiKH = "1100009" Or loaiKH = "130008" Or loaiKH = "130015" Or loaiKH = "280115" Or loaiKH = "140008" Or
                       loaiKH = "130009" Or loaiKH = "100010" Or loaiKH = "1100010" Or loaiKH = "280116" Or loaiKH = "140009" Or loaiKH = "130010" Or
                       loaiKH = "130011" Or loaiKH = "130016" Or loaiKH = "130013" Or loaiKH = "130012" Then
                        TextMSTQ(cLabel, mauChuMS, 5, 0)
                    ElseIf loaiKH = "130000" Or loaiKH = "1200001" Or loaiKH = "130001" Then
                        TextMSTQ(cLabel, mauChuMS, 0, 10)
                    Else
                        TextMSTQ(cLabel, mauChuMS, 30, 52.7)
                    End If
                End If
            Next

Kthuc:
            mLabelArray.Clear()
            If lenhveMS = "TaungamPB" Then
                VungArrayMS2()
                SDuongMsAr()
            End If
            If lenhveMS = "kvchupanh" Then
                DuongMsAr("2D3D001")
            End If
            MS.CadInputQueue.SendKeyin("group selection")
            GroupCell(tenKH)
            MS.CadInputQueue.SendKeyin("choose none")
        End If
    End Sub

    Public Sub RotateElementAboutZ(ByRef ele As Element, ByVal pntFixed As MicroStationDGN.Point3d, ByVal dblRadians As Double)
        Dim RotationMatrix As MicroStationDGN.Matrix3d
        Dim Eltrans As Transform3d
        Dim Axis As MicroStationDGN.Point3d
        Axis.X = 0
        Axis.Y = 0
        Axis.Z = 1
        RotationMatrix = MS.Matrix3dFromVectorAndRotationAngle(Axis, dblRadians)
        Eltrans = MS.Transform3dFromMatrix3dAndFixedPoint3d(RotationMatrix, pntFixed)
        ele.Transform(Eltrans)
    End Sub

    Public Function GocXoay(ByVal GocMS As MicroStationDGN.Point3d, ByVal DXoay As MicroStationDGN.Point3d) As Double
        Dim a As Double
        a = 0.0#
        If DXoay.X - GocMS.X = 0 Then
            If DXoay.Y - GocMS.Y > 0 Then
                a = 0 'Math.PI * 3.0# / 2.0#
            Else
                If DXoay.Y - GocMS.Y = 0 Then
                    Return 100
                Else
                    a = Math.PI '/ 2.0#
                End If
            End If
        End If
        If DXoay.X - GocMS.X <> 0 And DXoay.Y - GocMS.Y <> 0 Then
            a = Math.Atan((DXoay.Y - GocMS.Y) / (DXoay.X - GocMS.X))
            If (DXoay.X - GocMS.X) < 0 And (DXoay.Y - GocMS.Y) > 0 Then
                a = Math.PI / 2.0# + a
            End If
            If (DXoay.X - GocMS.X) < 0 And (DXoay.Y - GocMS.Y) < 0 Then
                a += Math.PI / 2.0#
            End If
            If (DXoay.X - GocMS.X) > 0 And (DXoay.Y - GocMS.Y) < 0 Then
                a = Math.PI * 3.0# / 2.0# + a
            End If
            If (DXoay.X - GocMS.X) > 0 And (DXoay.Y - GocMS.Y) > 0 Then
                a = Math.PI * 3.0# / 2.0# + a
            End If
        End If
        Return a
    End Function

    Public Sub XoayCel(ByRef ele As Element, ByVal GocMS As MicroStationDGN.Point3d, ByVal DXoay As MicroStationDGN.Point3d)
        Dim GX As Double
        GX = GocXoay(GocMS, DXoay)
        RotateElementAboutZ(ele, GocMS, GX)
    End Sub

    Private Sub ModelMs()
        If mModelArray.Count > 0 Then
            Dim mScale As MicroStationDGN.Point3d
            Dim mauDT As Integer
            '    MS.CadInputQueue.SendKeyin("choose none")
            For i As Integer = 0 To mModelArray.Count - 1
                Dim sModel As ITerrainModel71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mModelArray(i).ID)
                ToadoMs(sModel.Position)
                Dim P1 As IPosition71 = sModel.Position.Move(1000 * TyleMS, sModel.Position.Yaw, 0)
                ToadoMsDiemxoay(P1)
                Dim mFileName As String = sModel.ModelFileName.Substring(sModel.ModelFileName.LastIndexOf("\")).Split("\")(1)
                Dim cLoaiKH As String = Mid(mFileName, 1, mFileName.Count - 6)
                If mFileName.Split(".")(0).Substring(mFileName.Split(".")(0).Length - 1, 1) = "1" Then
                    mauDT = 10
                Else
                    mauDT = 201
                End If
                Dim heso As Double
                If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
                    heso = 0.065
                Else
                    heso = 0.65
                End If
                mScale.Y = TyleMS * heso
                mScale.X = TyleMS * heso
                Dim MS As New MicroStationDGN.ApplicationClass '= New MicroStationDGN.ApplicationClass()
                Dim dtMS As MicroStationDGN.CellElement = MS.CreateCellElement2(cLoaiKH, Pdgn, mScale, True, MS.Matrix3dIdentity)
                XoayCel(dtMS, Pdgn, GocMS)
                dtMS.LineWeight = 0
                dtMS.LineStyle = MS.ActiveDesignFile.LineStyles("0")
                dtMS.Color = mauDT
                dtMS.Level = mLevel
                dtMS.DisplayPriority = 4
                MS.ActiveModelReference.AddElement(dtMS)
                dtMS.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                MS.CommandState.StartDefaultCommand()
                MS.ActiveModelReference.SelectElement(dtMS)
            Next
            If lenhveMS = "mohinhPB" Or lenhveMS = "pTuhanh" Or lenhveMS = "pNDTuhanh" Or lenhveMS = "plNDTuhanh" Or lenhveMS = "Phaobobien" Or lenhveMS = "PhaoMDbanbien" Then
                VungArrayMS2()
                SDuongMsAr()
            End If
            MS.CadInputQueue.SendKeyin("group selection")
            GroupCell(tenKH)
            MS.CadInputQueue.SendKeyin("choose none")
            mModelArray.Clear()
        End If
    End Sub

#End Region

#Region "  Vung, Duong Ms"
    Private Sub VungArrayMS2()
        If mRegionArray.Count = 0 Then
            Exit Sub
        Else
            Dim Kieuduong As String
            Dim mauDuong As Integer, mauVung As Integer
            For i As Integer = 0 To mRegionArray.Count - 1
                Dim mRegion As ITerrainPolygon71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mRegionArray(i).ID)
                mauDuong = ConvertColorMs(mRegion.LineStyle.Color.ToRGBColor.ToString)
                mauVung = ConvertColorMs(mRegion.FillStyle.Color.ToRGBColor.ToString)
                MS.CadInputQueue.SendCommand("Active Color " & mauDuong)
                Dim ListPoint() As String = mRegion.Geometry.Clone.Wks.ExportToWKT().Replace("POLYGON Z ((", "").Replace("))", "").Replace(", ", ",").Split(",")
                Dim PointDGN = Array.CreateInstance(GetType(MicroStationDGN.Point3d), ListPoint.Length)

                For j As Integer = 0 To ListPoint.Length - 1
                    xWGS84 = Val(ListPoint(j).Split(" ")(0))
                    yWGS84 = Val(ListPoint(j).Split(" ")(1))
                    Dim point = New MicroStationDGN.Point3d()
                    If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
                        point.X = xWGS84
                        point.Y = yWGS84
                        point.Z = 0
                    Else
                        point.X = FrmMain.Instance.Vn2000(0)
                        point.Y = FrmMain.Instance.Vn2000(1)
                        point.Z = 0
                    End If
                    PointDGN.SetValue(point, j)
                Next

                If mRegionArray.Count = 1 Then
                    TextEmpty(PTextEmpty(ListPoint))
                End If
                Dim mStyleLine As MsdFillMode

                If mRegion.LineStyle.Width = 0 Then
                    MS.ActiveSettings.Color = mauVung
                    Kieuduong = "0"
                    MS.CadInputQueue.SendKeyin("wt=0")
                    mStyleLine = MsdFillMode.msdFillModeFilled
                    mauDuong = ConvertColorMs(mRegion.FillStyle.Color.ToRGBColor.ToString)
                Else
                    mStyleLine = MsdFillMode.msdFillModeOutlined
                    If lenhveMS = "muctieuthenchot" Then
                        Kieuduong = "0"
                        MS.CadInputQueue.SendKeyin("wt=0")
                    Else
                        If lenhveMS = "mohinhPB" Or lenhveMS = "TaungamPB" Then
                            Kieuduong = "2D3D004"
                        Else
                            Kieuduong = "2D3D001"
                        End If
                        MS.ActiveSettings.Color = mauDuong
                    End If

                End If

                If mRegion.FillStyle.Texture.FileName <> "" Then
                    Kieuduong = "0"
                    Dim mTexture As String = mRegion.FillStyle.Texture.FileName.Split("\")(mRegion.FillStyle.Texture.FileName.Split("\").Count - 1)
                    Dim MauDT As Integer
                    If mTexture = "Blue.gif" Then
                        MauDT = mau3MS
                    ElseIf mTexture = "Black.gif" Then
                        MauDT = mauChuMS
                    ElseIf mTexture = "Brown.gif" Then
                        MauDT = mauNauMS
                    ElseIf mTexture = "Red.gif" Then
                        MauDT = mauMS
                    ElseIf mTexture = "Green.gif" Then
                        MauDT = mauXanhMS
                    ElseIf mTexture = "H2O.gif" Then
                        MauDT = mauH2OMS
                    ElseIf mTexture = "Xamcanh.gif" Then
                        MauDT = mauXanhMS
                    End If
                    Dim mShapPatern As MicroStationDGN.ShapeElement = MS.CreateShapeElement1(Nothing, PointDGN, mStyleLine) 'MsdFillMode.msdFillModeOutlined)\
                    Dim mHatchPattern As MicroStationDGN.Pattern
                    If mTexture = "Xamcanh.gif" Then
                        mHatchPattern = MS.CreateAreaPattern(Tyle * 100, Tyle * 100, 0, "Xamcanh", Tyle)
                    Else
                        mHatchPattern = MS.CreateHatchPattern1(80.0, 45.0 * Math.PI / 180)
                    End If
                    'Dim mHatchPattern As HatchPattern = MS.CreateHatchPattern1(80.0, 45.0 * Math.PI / 180)
                    mHatchPattern.Color = mShapPatern.Color
                    mShapPatern.SetPattern(mHatchPattern, MS.Matrix3dIdentity)
                    mShapPatern.Color = MauDT
                    mShapPatern.FillColor = MauDT
                    mShapPatern.Level = mLevel
                    mShapPatern.LineStyle = MS.ActiveDesignFile.LineStyles(Kieuduong)
                    mShapPatern.FillMode = MsdFillMode.msdFillModeNotFilled
                    MS.ActiveModelReference.AddElement(mShapPatern)
                    mShapPatern.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                    MS.CommandState.StartDefaultCommand()
                    MS.ActiveModelReference.SelectElement(mShapPatern)
                Else
                    Dim mShap As MicroStationDGN.ShapeElement = MS.CreateShapeElement1(Nothing, PointDGN, mStyleLine) 'MsdFillMode.msdFillModeOutlined)
                    If lenhveMS = "vunghoaluc" Then
                        mShap.DisplayPriority = i
                        If i = 1 Then
                            mShap.FillMode = 0
                        End If
                    Else
                        mShap.DisplayPriority = System.Convert.ToInt32(mRegion.Terrain.DrawOrder)
                    End If

                    mShap.Color = mauDuong
                    mShap.FillColor = mauVung
                    mShap.Level = mLevel
                    mShap.LineStyle = MS.ActiveDesignFile.LineStyles(Kieuduong)
                    MS.ActiveModelReference.AddElement(mShap)
                    mShap.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                    MS.CommandState.StartDefaultCommand()
                    MS.ActiveModelReference.SelectElement(mShap)
                End If

            Next

            If lenhveMS = "TauBPkiemtra" Or lenhveMS = "TauBPbatgiu" Or lenhveMS = "nganchanBP" Or lenhveMS = "phuckichBP" Or lenhveMS = "dayNquayve" Or lenhveMS = "nganchandamdong" Or lenhveMS = "dacnhiemBP" Or lenhveMS = "Luongraquet" Or lenhveMS = "BkinhTu" Or lenhveMS = "Tuyentucanhgioi" Or lenhveMS = "sanbaycap2" Or lenhveMS = "hanhlangbay" Or lenhveMS = "sanbaycap1" Or lenhveMS = "sanbayvuotcap" Or lenhveMS = "sanbaytrenbien" Or lenhveMS = "ovatcan" Or lenhveMS = "KvVatcan" Or lenhveMS = "xuongBBDL10" Or lenhveMS = "DaiBanchinh" Or lenhveMS = "BanchanDidong" Or lenhveMS = "XTchuyenPngu" Or lenhveMS = "XTPngutrongTD" Or lenhveMS = "tamnguytrang" Or lenhveMS = "luoinguytrang" Or lenhveMS = "kvvkhatnhanno" Or lenhveMS = "kvvksinhhoc" Or
                lenhveMS = "tenluacocanhtamgan" Or lenhveMS = "tenluacocanhtamtrung" Or lenhveMS = "tenluacocanhtamxa" Or lenhveMS = "tenluacocanhtamxa2Ranh" Or lenhveMS = "tenluacocanhtamgan2Ranh" Or lenhveMS = "tenluacocanhtamtrung2Ranh" Or lenhveMS = "lienlacVT" Or lenhveMS = "lienlacViba" Or lenhveMS = "tuyenthuyloineo" Or lenhveMS = "tuyenthuyloiday" Or lenhveMS = "KvTamdung" Or lenhveMS = "KvDoiTu" Or lenhveMS = "KvCodong" Or lenhveMS = "KvTuantieu" Or lenhveMS = "Langchiendau" Or lenhveMS = "Cumlangchiendau" Then
                SDuongMsAr()
            ElseIf lenhveMS = "HiepdongKQPK" Or lenhveMS = "toTSDN" Or lenhveMS = "toTSDQTV" Or lenhveMS = "dontho" Or lenhveMS = "todaccong" Or lenhveMS = "tocongtacBP" Or lenhveMS = "dacnhiemBP" Or lenhveMS = "donthuy" Or lenhveMS = "tenluaB72" Or lenhveMS = "tenluaPhagot" Or lenhveMS = "Phaophanluccotrung" Or lenhveMS = "PhaophanlucKyhieuchung" Or lenhveMS = "Phaophanluccolon" Or lenhveMS = "tramtaptrungQNDB" Or lenhveMS = "tramtaptrungPTKT" Or lenhveMS = "tramtaptrungQNDBcm" Or lenhveMS = "kvttllDongvien" Or lenhveMS = "tohoahoc" Or lenhveMS = "toTrSHHCodong" Or
                  lenhveMS = "tramtiepnhanQNDB" Or lenhveMS = "tramtiepnhanPTKT" Or lenhveMS = "tramGiao_nhan" Or lenhveMS = "Coi120" Or lenhveMS = "Coi160" Or lenhveMS = "Coi82" Or lenhveMS = "muctieuphaibaove" Or lenhveMS = "tocodongdiettang" Or lenhveMS = "coilui" Or lenhveMS = "DHPNBB" Or lenhveMS = "DHPNBBXT" Or lenhveMS = "KvPNthenchot" Or lenhveMS = "baiminchongtangHTD" Or lenhveMS = "ANQP" Or lenhveMS = "kvTKHHxuly" Or lenhveMS = "khudancumoi" Or lenhveMS = "kvbaidobo" Or lenhveMS = "tuyenTochucDoihinh" Or lenhveMS = "tuyenTKdobo" Or lenhveMS = "tuyenPTdobo" Or lenhveMS = "tuyenXPdobo" Then
                TextMsArray(mLabelArray)
                SDuongMsAr()
            ElseIf lenhveMS = "tauquetNoi" Or lenhveMS = "HuongTCThuyeuKQchendich" Or lenhveMS = "TsatBangChiendau" Or lenhveMS = "toanTSDN" Or lenhveMS = "xeTSPT76" Or lenhveMS = "DCTCbangTauDS" Or lenhveMS = "DCTCbangTauNgam" Or lenhveMS = "muidaccongTC" Or lenhveMS = "doidaccongTC" Or lenhveMS = "todaccong" Or
                 lenhveMS = "tautuantieuTS" Or lenhveMS = "muidaccong" Or lenhveMS = "doidaccong" Or lenhveMS = "tauhuanluyen" Or lenhveMS = "tauquetloi" Or lenhveMS = "xeTScanhgioi" Or lenhveMS = "xeTSBMP" Or lenhveMS = "doicongtacBP" Or
                 lenhveMS = "Canotrinhsat" Or lenhveMS = "tauCuunan" Or lenhveMS = "TLChongngamNBC" Or lenhveMS = "MatcuBLLD" Or lenhveMS = "MatcuA2" Or lenhveMS = "XeBAT" Or lenhveMS = "doicongbinh" Or
                 lenhveMS = "todaccongnuoc" Or lenhveMS = "doiTShonhop" Or lenhveMS = "DChoatrang" Or lenhveMS = "doidaccongnuoc" Or lenhveMS = "muidaccongnuoc" Or lenhveMS = "trinhsatKGM" Or
                 lenhveMS = "muidaccongcodong" Or lenhveMS = "tauBinan" Or lenhveMS = "DCTCbangTauNN" Or lenhveMS = "CongNongLamtruongCD" Or lenhveMS = "doihoahoc" Or
                 lenhveMS = "caulacboPD" Or lenhveMS = "diemnong" Or lenhveMS = "kvcophandong" Or lenhveMS = "MatcuBLLD" Or lenhveMS = "khuvucBLTieutay" Or lenhveMS = "hanhquanbo" Or lenhveMS = "HQbangoto" Or lenhveMS = "HQbangxelua" Or lenhveMS = "HQbangTau" Or lenhveMS = "HQbangMB" Then
                TextMsArray(mLabelArray)
            ElseIf lenhveMS = "hamchong" Or lenhveMS = "baicocchongtang" Or lenhveMS = "TrandiaBtcdt" Or lenhveMS = "TrandiaCtcdt" Then
                MultiCells()
            End If

            MS.CadInputQueue.SendKeyin("group selection")
            If Not lenhveMS = "Trinhbay" And Not lenhveMS = "vekhung" Then
                GroupCell(tenKH)
            Else
                GroupCell(tenKH)
            End If
            MS.CadInputQueue.SendKeyin("choose none")
            If solan > 0 Then
                FrmMain.Instance.sgworldMain.ProjectTree.DeleteItem(FrmMain.Instance.sgworldMain.ProjectTree.FindItem(tenMayNet & "\" & GiaidoanNet & "\" & tenKH & "\" & "temp"))
            End If
        End If
    End Sub

    Function PTextEmpty(ListPoint() As String) As MicroStationDGN.Point3d
        xWGS84 = Val(ListPoint(0).Split(" ")(0))
        yWGS84 = Val(ListPoint(0).Split(" ")(1))
        Dim point = New MicroStationDGN.Point3d()
        If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
            point.X = xWGS84
            point.Y = yWGS84
            point.Z = 0
        Else
            point.X = FrmMain.Instance.Vn2000(0)
            point.Y = FrmMain.Instance.Vn2000(1)
            point.Z = 0
        End If
        PTextEmpty = point
    End Function

    Function TextEmpty(Pd As MicroStationDGN.Point3d) As MicroStationDGN.TextElement
        Dim ChuMs As MicroStationDGN.TextElement = MS.CreateTextElement1(Nothing, "     ", Pd, MS.Matrix3dIdentity)
        ChuMs.DisplayPriority = 1000
        MS.ActiveModelReference.AddElement(ChuMs)
        ChuMs.Redraw(MsdDrawingMode.msdDrawingModeNormal)
        MS.CommandState.StartDefaultCommand()
        MS.ActiveModelReference.SelectElement(ChuMs)
        TextEmpty = ChuMs
    End Function

    Private Sub DuongMsAr(Kieuduong As String)
        If mLineArray.Count > 0 Then
            Dim mauDuong As Integer
            For i As Integer = 0 To mLineArray.Count - 1
                Dim k1 As ITerrainPolyline71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mLineArray(i).ID)
                Dim ListPoint() As String = k1.Geometry.Clone.Wks.ExportToWKT().Replace("LINESTRING Z (", "").Replace(")", "").Replace(", ", ",").Split(",")
                Dim PointDGN = Array.CreateInstance(GetType(MicroStationDGN.Point3d), ListPoint.Length)
                For j As Integer = 0 To ListPoint.Length - 1
                    xWGS84 = Val(ListPoint(j).Split(" ")(0))
                    yWGS84 = Val(ListPoint(j).Split(" ")(1))
                    Dim point = New MicroStationDGN.Point3d()
                    If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
                        point.X = xWGS84
                        point.Y = yWGS84
                        point.Z = 0
                    Else
                        point.X = FrmMain.Instance.Vn2000(0)
                        point.Y = FrmMain.Instance.Vn2000(1)
                        point.Z = 0
                    End If
                    PointDGN.SetValue(point, j)
                Next
                If mLineArray.Count = 1 Or lenhveMS = "noiduong" Or lenhveMS = "catduong" Then ' And Not lenhveMS = "hangraobungnhung"
                    TextEmpty(PTextEmpty(ListPoint))
                End If

                mauDuong = ConvertColorMs(k1.LineStyle.Color.ToRGBColor.ToString)
                MS.ActiveSettings.Color = mauDuong

                If lenhveMS = "Gioituyen" Or lenhveMS = "hangraobungnhung" Then
                    Kieuduong = loaiKH
                    MS.CadInputQueue.SendKeyin("mdl load calculat;calculat tcb->lineStyle.scale= " & HesoDuong)
                End If

                If k1.Spline = True Then
                    '  Kieuduong = loaiKH
                    Dim mcurve As New InterpolationCurve
                    mcurve.SetFitPoints(PointDGN)
                    Dim mDuong As MicroStationDGN.BsplineCurveElement = MS.CreateBsplineCurveElement2(Nothing, mcurve)
                    mDuong.LineWeight = 0
                    mDuong.Level = mLevel
                    mDuong.DisplayPriority = System.Convert.ToInt32(k1.Terrain.DrawOrder)
                    mDuong.LineStyle = MS.ActiveDesignFile.LineStyles(Kieuduong)
                    MS.ActiveModelReference.AddElement(mDuong)
                    mDuong.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                    MS.CommandState.StartDefaultCommand()
                    MS.ActiveModelReference.SelectElement(mDuong)
                    'If loaiKH = "hangraobungnhung" Then
                    '    Dim mDuong2 As MicroStationDGN.BsplineCurveElement = MS.CreateBsplineCurveElement2(Nothing, mcurve)
                    '    mDuong2.Color = mauMSDem
                    '    mDuong2.LineWeight = 0
                    '    mDuong2.Level = mLevel
                    '    mDuong2.DisplayPriority = System.Convert.ToInt32(k1.Terrain.DrawOrder)
                    '    mDuong2.LineStyle = MS.ActiveDesignFile.LineStyles(Kieuduong & "2")
                    '    MS.ActiveModelReference.AddElement(mDuong2)
                    '    mDuong2.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                    '    MS.CommandState.StartDefaultCommand()
                    '    MS.ActiveModelReference.SelectElement(mDuong2)
                    'End If

                Else

                    Dim Duong As MicroStationDGN.LineElement = MS.CreateLineElement1(Nothing, PointDGN)
                    Duong.Color = mauDuong
                    Duong.LineWeight = 0
                    Duong.Level = mLevel
                    Duong.DisplayPriority = System.Convert.ToInt32(k1.Terrain.DrawOrder)
                    Duong.LineStyle = MS.ActiveDesignFile.LineStyles(Kieuduong)
                    MS.ActiveModelReference.AddElement(Duong)
                    Duong.Redraw(MsdDrawingMode.msdDrawingModeNormal)
                    MS.CommandState.StartDefaultCommand()
                    MS.ActiveModelReference.SelectElement(Duong)
                End If
            Next
        End If
    End Sub

    Private Sub SDuongMsAr()
        If lenhveMS = "noiduong" Or lenhveMS = "catduong" Then
            Dim IDdtBicat1 As Long = IDElement(ChonDT(FrmMain.Instance.txtGroup.Text)(1), ChonDT(FrmMain.Instance.txtGroup.Text)(0))  'SelectDT(FrmMain.Instance.txtGroup.Text.Split(",")(0))(0), SelectDT(FrmMain.Instance.txtGroup.Text.Split(",")(0))(1))
            Dim IDdCat As Long = IDElement(ChonDT(FrmMain.Instance.txtGroup.Text)(3), ChonDT(FrmMain.Instance.txtGroup.Text)(2))
            If IDdtBicat1 = 0 Or IDdCat = 0 Then
                Exit Sub
            Else
                SXoaDT()
                If xoaDTcat = True Then
                    SXoaDT()
                End If
            End If
        End If

        If lenhveMS = "mohinhPB" Or lenhveMS = "TaungamPB" Or lenhveMS = "tenluacocanhtamgan" Or lenhveMS = "tenluacocanhtamtrung" Or lenhveMS = "tenluacocanhtamxa" Or lenhveMS = "tenluacocanhtamxa2Ranh" Or lenhveMS = "tenluacocanhtamgan2Ranh" Or lenhveMS = "tenluacocanhtamtrung2Ranh" Then
            DuongMsAr("2D3D004")
        Else
            DuongMsAr("2D3D001")
        End If
        If lenhveMS = "doboduongkhong" Or lenhveMS = "doboduongkhongTrT" Or lenhveMS = "Tieptebangdu" Or lenhveMS = "SungBBbanMB" Or lenhveMS = "kvchupanh" Or lenhveMS = "KvDichmoiden" Or lenhveMS = "KvKhotrandau" Or lenhveMS = "KvTautrandau" Or lenhveMS = "KVTrinhsatSCN" Or lenhveMS = "KVTrinhsatSN" Or lenhveMS = "KvHoaluc" Or lenhveMS = "KvKho" Or lenhveMS = "KvBdCongnghe" Or lenhveMS = "CCCDBP" Or lenhveMS = "DDgdichphahoaiMB" Then
            MultiCells()
        End If
        If lenhveMS = "DbanMtuy" Or lenhveMS = "Diaban" Or lenhveMS = "HuongTCChuyeuKQchendich" Or lenhveMS = "HuongTCThuyeuKQchendich" Or lenhveMS = "Duongcothhacanh" Or lenhveMS = "baihacanh" Or lenhveMS = "TuyengiaoNvu" Or lenhveMS = "TrTbiHH" Or Lenhve2D = "kvtstrenkhong" Or Lenhve2D = "kvtsmatdat" Or lenhveMS = "KvBandoclaptieudoan" Or lenhveMS = "KvBanDoclapDaidoi" Or lenhveMS = "KvBanTTrTieudoan" Or lenhveMS = "KvBanTTrDaidoi" Then
            TextMsArray(mLabelArray)
        End If
        If lenhveMS = "KvLanchiem" Or lenhveMS = "KvTRanhchap" Or lenhveMS = "KvXamcanh" Or lenhveMS = "tuyenPHkoLTlon" Or lenhveMS = "BkinhMB" Or lenhveMS = "kvgiaochien" Or lenhveMS = "DDbotrimin" Or lenhveMS = "BanChsangChihuongTC" Or lenhveMS = "ChieusauTS" Or lenhveMS = "MBchupanhTS" Or lenhveMS = "nhiemvutruocmat" Or lenhveMS = "nhiemvutieptheo" Or lenhveMS = "kvTKHHdukien" Or lenhveMS = "kvTochucDoihinh" Or lenhveMS = "kvTuantieu" Or lenhveMS = "kvVaybat" Or lenhveMS = "vetNXdudoan" Or lenhveMS = "vetNXthucte" Or lenhveMS = "HrNganthuyloi" Or lenhveMS = "DDgCoDichmatdat" Or lenhveMS = "DgVongtranh" Or lenhveMS = "DgTieudoc" Or lenhveMS = "GiHanNvuTCDT" Or lenhveMS = "Daihiepdong" Or
               lenhveMS = "kvTKHHdukien" Or lenhveMS = "KvTTrHoalucphandoi" Or lenhveMS = "khuvucphongthuthenchot" Or lenhveMS = "cancuhauphuong" Or lenhveMS = "cancuchiendau" Or lenhveMS = "khuvucphongthutrongdiem" Or lenhveMS = "caucogioi" Or lenhveMS = "BenloiXT" Or lenhveMS = "BenvuotsongnhieuPT" Or lenhveMS = "Cautreo" Or lenhveMS = "BenPhatuhanh" Or lenhveMS = "tuyenVChonhop" Or lenhveMS = "tuyenRMhonhop" Or lenhveMS = "GioihanvungTrSDTsieucaotan" Or lenhveMS = "GihanVungcheap" Then
            VungArrayMS2()
        End If
        If lenhveMS = "toTrsTrongdich" Or lenhveMS = "toTrSDieutra" Or lenhveMS = "danhhuongchuyeuHQ" Or lenhveMS = "danhhuongthuyeuHQ" Or lenhveMS = "khongquandanhbien" Then
            TextMsArray(mLabelArray)
            VungArrayMS2()
        End If
        If lenhveMS = "tuyenRMbangTrT" Or lenhveMS = "HQhanhquan" Or lenhveMS = "KvBvMtieuBangGnhieungoinoVT" Or lenhveMS = "KvCamTbVTD" Then
            MultiCells()
            VungArrayMS2()
        End If
        MS.CadInputQueue.SendKeyin("group selection")
        GroupCell(tenKH)
        'If lenhveMS = "veduongsongsong" Or lenhveMS = "trinhbay" Then
        '    GroupCell(tenKH)
        'End If
        MS.CadInputQueue.SendKeyin("choose none")
    End Sub

#Region "     Sua Duong & Vung"
    Private Sub SuaVungMs()
        Dim IDdCat As Long
        Dim shapes1 As MicroStationDGN.ShapeElement = Nothing, shapes2 As MicroStationDGN.ShapeElement = Nothing
        Dim IDdtBicat1 As Long = IDElement(ChonDT(FrmMain.Instance.txtGroup.Text)(1), ChonDT(FrmMain.Instance.txtGroup.Text)(0))
        If Not lenhveMS = "vungtoduong" And Not lenhveMS = "duongtovung" Then
            IDdCat = IDElement(ChonDT(FrmMain.Instance.txtGroup.Text)(3), ChonDT(FrmMain.Instance.txtGroup.Text)(2))
            shapes1 = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtBicat1))
            shapes2 = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdCat))
        End If
        Dim ee As ElementEnumerator
        If lenhveMS = "catvung2" Then
            Dim shapes12 As MicroStationDGN.ShapeElement
            Dim IDdtBicat2 As Long = IDdtBicat1 - 1
            shapes12 = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtBicat2))
            ee = shapes1.GetDifferenceShapes(shapes2)
            CrVung_SuaDT(ee, shapes1)
            ee = shapes12.GetDifferenceShapes(shapes2)
            CrVung_SuaDT(ee, shapes12)
        ElseIf lenhveMS = "catvung" Then
            ee = shapes1.GetDifferenceShapes(shapes2)
            CrVung_SuaDT(ee, shapes1)
        ElseIf lenhveMS = "gopvung" Then
            ee = shapes1.GetUnionShapes(shapes2)
            CrVung_SuaDT(ee, shapes1)
        ElseIf lenhveMS = "gopvung2" Then
            Dim IDdtGop1 As Long = IDdtBicat1 - 1
            Dim IDdtGop2 As Long = IDdCat - 1
            Dim shapeGop1 As MicroStationDGN.ShapeElement = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtGop1))
            Dim shapeGop2 As MicroStationDGN.ShapeElement = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtGop2))
            ee = shapeGop1.GetUnionShapes(shapeGop2)
            CrVung_SuaDT(ee, shapeGop1)
            MS.ActiveModelReference.RemoveElement(shapeGop2)
            ee = shapes1.GetUnionShapes(shapes2)
            CrVung_SuaDT(ee, shapes1)
            MS.ActiveModelReference.RemoveElement(shapes2)
        ElseIf lenhveMS = "giaovung" Then
            ee = shapes1.GetIntersectionShapes(shapes2)
            CrVung_SuaDT(ee, shapes1)
        ElseIf lenhveMS = "vungtoduong" Then
            Dim shapes11 As MicroStationDGN.ShapeElement = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtBicat1))
            Dim vertices() As MicroStationDGN.Point3d
            vertices = shapes11.ConstructVertexList(0.0000001)
            Dim myLine1 As MicroStationDGN.LineElement
            myLine1 = MS.CreateLineElement1(Nothing, vertices)
            myLine1.Color = shapes11.Color
            myLine1.Level = shapes11.Level
            myLine1.LineStyle = shapes11.LineStyle
            myLine1.DisplayPriority = shapes11.DisplayPriority
            MS.ActiveModelReference.AddElement(myLine1)
            myLine1.Redraw(MsdDrawingMode.msdDrawingModeNormal)
            MS.CommandState.StartDefaultCommand()
            MS.ActiveModelReference.SelectElement(myLine1)
            TextEmpty(vertices(0))
            MS.ActiveModelReference.RemoveElement(shapes11)
        ElseIf lenhveMS = "duongtovung" Then
            Dim line1 As MicroStationDGN.LineElement = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtBicat1))
            Dim vertices() As MicroStationDGN.Point3d
            vertices = line1.ConstructVertexList(0.0000001)
            Dim myShape1 As MicroStationDGN.ShapeElement
            myShape1 = MS.CreateShapeElement1(Nothing, vertices, 1)
            myShape1.Color = line1.Color
            myShape1.FillColor = mauMSDem
            myShape1.Level = line1.Level
            myShape1.LineStyle = line1.LineStyle
            myShape1.DisplayPriority = line1.DisplayPriority
            MS.ActiveModelReference.AddElement(myShape1)
            myShape1.Redraw(MsdDrawingMode.msdDrawingModeNormal)
            MS.CommandState.StartDefaultCommand()
            MS.ActiveModelReference.SelectElement(myShape1)
            TextEmpty(vertices(0))
            MS.ActiveModelReference.RemoveElement(line1)
        End If

        If lenhveMS = "catvung2" Or lenhveMS = "gopvung" Or lenhveMS = "catvung" Or lenhveMS = "giaovung" Then 'Or lenhveMS = "catduong"
            If FrmMain.Instance.ChebTheoNhom.Checked = True Then
                MS.ActiveModelReference.RemoveElement(MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdCat - 1)))
                If xoaDTcat = True Then
                    MS.ActiveModelReference.RemoveElement(shapes2)
                End If
            Else
            End If
        End If
        MS.CadInputQueue.SendKeyin("group selection")
        GroupCell(ChonDT(FrmMain.Instance.txtGroup.Text)(1))
        MS.CadInputQueue.SendKeyin("choose none")
        'If xoaDTcat = True Then
        '    sXoaDT(DtCat, mLevelDTCat)
        'End If
    End Sub

    Private Sub CrVung_SuaDT(ee As ElementEnumerator, shapesBicat As MicroStationDGN.ShapeElement)
        Dim vertices() As MicroStationDGN.Point3d
        Do While ee.MoveNext
            Dim elm As ComplexShapeElement
            elm = ee.Current.AsComplexShapeElement
            vertices = elm.ConstructVertexList(0.0000001)
            If Not lenhveMS = "gopvung2" And Not lenhveMS = "catvung2" Then
                TextEmpty(vertices(0))
            End If
            Dim myShape1 As MicroStationDGN.ShapeElement
            myShape1 = MS.CreateShapeElement1(Nothing, vertices, 1)
            myShape1.Color = shapesBicat.Color
            myShape1.FillColor = shapesBicat.FillColor
            myShape1.Level = shapesBicat.Level
            myShape1.LineStyle = shapesBicat.LineStyle
            myShape1.LineWeight = shapesBicat.LineWeight
            myShape1.FillMode = shapesBicat.FillMode
            myShape1.DisplayPriority = shapesBicat.DisplayPriority
            MS.ActiveModelReference.AddElement(myShape1)
            myShape1.Redraw(MsdDrawingMode.msdDrawingModeNormal)
            MS.CommandState.StartDefaultCommand()
            MS.ActiveModelReference.SelectElement(myShape1)
        Loop
        MS.ActiveModelReference.RemoveElement(shapesBicat)
    End Sub

    Function IDElement(tenDT As String, mLevel As String) As Long
        Dim mypoint As MicroStationDGN.Point3d  ' for fit view data point
        MS.CadInputQueue.SendKeyin("mdl silentload selectby;Select type none;selectby type cell; selectby cellname " & tenDT & ";selectby level " & mLevel & ";selectby execute")
        MS.CadInputQueue.SendKeyin("mdl unload selectby")
        Dim ee As ElementEnumerator
        ee = MS.ActiveModelReference.GetSelectedElements
        Dim IDdt As Long
        Do While ee.MoveNext
            Dim ele As Element
            ele = ee.Current
            IDdt = MS.DLongToLong(ele.ID) - 1
        Loop
        If Not Lenhve = "pdf" Then
            MS.CadInputQueue.SendCommand("DROP element", True)
        End If
        mypoint.X = 100
        mypoint.Y = 100
        mypoint.Z = 100
        MS.CadInputQueue.SendDataPoint(mypoint, MS.ActiveDesignFile.Views(1)) ', MS.ActiveDesignFile.Views(1)
        IDElement = IDdt
    End Function

#End Region

#End Region

    Private Sub TextMsArray(mTextArray As List(Of ITerrainLabel71))
        For i As Integer = 0 To mTextArray.Count - 1
            Dim mText As ITerrainLabel71 = FrmMain.Instance.sgworldMain.Creator.GetObject(mTextArray(i).ID)
            If lenhveMS = "TuyengiaoNvu" Or lenhveMS = "baihacanh" Or lenhveMS = "Duongcothhacanh" Then
                TextMSTQ(mText, mauMS, 0, 0)
            ElseIf lenhveMS = "danhhuongchuyeuHQ" Or lenhveMS = "danhhuongthuyeuHQ" Or lenhveMS = "khongquandanhbien" Then
                TextMSTQ(mText, mau3ChuMS, 0, 0)
            ElseIf lenhveMS = "Trinhbay" Then
                TextMSTQ(mText, mauChuMS, 0, 150)
            Else
                TextMSTQ(mText, mauChuMS, 0, 0)
            End If
        Next

        If Not lenhveMS = "Trinhbay" And Not lenhveMS = "Coi120" And Not lenhveMS = "Coi160" And Not lenhveMS = "Coi82" And Not lenhveMS = "dontho" And Not lenhveMS = "todaccong" And Not lenhveMS = "donthuy" Then
            MS.CadInputQueue.SendKeyin("group selection")
            GroupCell(tenKH)
        End If
    End Sub

    Private Sub TrinhbayMS()
        TextMsArray(mLabelArray)
        DuongMsAr("2D3D001")
        LuoiKmMs()
        MS.CadInputQueue.SendKeyin("group selection")
        GroupCell("Trinh bay")
        MS.CadInputQueue.SendKeyin("choose none")
    End Sub

    Public Sub TaoFene()
        Dim PointDGN = Array.CreateInstance(GetType(MicroStationDGN.Point3d), 10)
        Dim IDdtBicat1 As Long = IDElement("Khung", "Trinh bay")
        Dim shapes2 As MicroStationDGN.ShapeElement = MS.ActiveModelReference.GetElementByID(MS.DLongFromLong(IDdtBicat1))
        Dim Pdinh() As MicroStationDGN.Point3d
        Pdinh = shapes2.ConstructVertexList(0.0000001)
        PointDGN.SetValue(Pdinh(0), 0)
        PointDGN.SetValue(Pdinh(1), 1)
        PointDGN.SetValue(Pdinh(2), 2)
        PointDGN.SetValue(Pdinh(3), 3)
        ''////////////
        Dim pts1 As MicroStationDGN.Point3d = Pms(Pdinh(0), 10, 10)
        Dim pts3 As MicroStationDGN.Point3d = Pms(Pdinh(3), 3000, -3000)
        Dim pts4 As MicroStationDGN.Point3d = Pms(Pdinh(2), 3000, 3000)
        Dim pts5 As MicroStationDGN.Point3d = Pms(Pdinh(1), -3000, 3000)
        Dim pts6 As MicroStationDGN.Point3d = Pms(Pdinh(0), -3000, -3000)
        Dim pts7 As MicroStationDGN.Point3d = Pms(pts6, 10, 10)
        ''///////////////////////
        PointDGN.SetValue(pts1, 4)
        PointDGN.SetValue(pts7, 5)
        PointDGN.SetValue(pts3, 6)
        PointDGN.SetValue(pts4, 7)
        PointDGN.SetValue(pts5, 8)
        PointDGN.SetValue(pts7, 9)

        Dim mShapPatern As MicroStationDGN.ShapeElement = MS.CreateShapeElement1(Nothing, PointDGN, MsdFillMode.msdFillModeFilled)
        mShapPatern.Color = 11
        mShapPatern.FillColor = 11
        mShapPatern.Level = mLevel
        mShapPatern.LineStyle = MS.ActiveDesignFile.LineStyles("0")
        mShapPatern.DisplayPriority = 0
        MS.ActiveModelReference.AddElement(mShapPatern)
        MS.CommandState.StartDefaultCommand()
        Dim pFence1 As MicroStationDGN.Point3d = Pms(Pdinh(2), 3000 * Tyle, 3000 * Tyle)
        Dim pFence2 As MicroStationDGN.Point3d = Pms(Pdinh(0), -3000 * Tyle, -3000 * Tyle)
        Dim mView As MicroStationDGN.View = MS.ActiveDesignFile.Views(1)
        mView.SetArea(pFence2, pFence1, MS.Matrix3dIdentity(), 0)
        mView.Redraw()
        Dim PaperX As Double = pFence1.X - pFence2.X
        Dim PaperY As Double = pFence1.Y - pFence2.Y
        Dim pt(4) As MicroStationDGN.Point2d
        pt(2).Y = PaperY
        pt(3).X = PaperX
        pt(3).Y = PaperY
        pt(4).X = PaperX
        With MS.ActiveDesignFile.Fence
            .DefineFromViewPoints(mView, pt)
            .Draw()
        End With
        Dim mausoTyle As Integer = 0
        Select Case FrmMain.Instance.cbTylebando.SelectedIndex
            Case 0 '1/10.000
                mausoTyle = 10000
            Case 1 '1/25000
                mausoTyle = 25000
            Case 2 '1/50.000
                mausoTyle = 50000
            Case 3   '1/100.000
                mausoTyle = 100000
            Case 4  '1/250.000
                mausoTyle = 250000
            Case 5   '1/500.000
                mausoTyle = 500000
            Case 6   '1/1000.000
                mausoTyle = 1000000
        End Select
        MS.CadInputQueue.SendCommand("DIALOG PLOT")
        MS.CadInputQueue.SendKeyin("print boundary fence")
        MS.CadInputQueue.SendKeyin("print colormode color")
        MS.CadInputQueue.SendCommand("PRINT DRIVER " & "printer.pltcfg")
        '' MS.CadInputQueue.SendCommand("PRINT DRIVER " & "pdf.pltcfg")
        MS.CadInputQueue.SendKeyin("print unit meter")
        MS.CadInputQueue.SendCommand("PRINT YFORM " & (PaperX / mausoTyle).ToString)
        MS.CadInputQueue.SendCommand("PRINT XFORM " & (PaperY / mausoTyle).ToString)
        MS.CadInputQueue.SendKeyin("print SCALE " & mausoTyle.ToString)
        ''   MS.CadInputQueue.SendCommand("PRINT EXECUTE")
        ''   MS.CommandState.StartDefaultCommand()
    End Sub

    Function Pms(P As MicroStationDGN.Point3d, dX As Double, dY As Double) As MicroStationDGN.Point3d
        Dim pKs As MicroStationDGN.Point3d = Nothing
        pKs.X = P.X + dX
        pKs.Y = P.Y + dY
        pKs.Z = 0
        Pms = pKs
    End Function


    Private Sub GroupCell(tenGroup As String)
        Dim ee As ElementEnumerator
        ee = MS.ActiveModelReference.GetSelectedElements
        Do While ee.MoveNext
            Dim mCell2 As MicroStationDGN.CellElement
            mCell2 = ee.Current
            mCell2.Name = tenGroup
            mCell2.Rewrite()
            mCell2.Redraw()
            Pdgn = mCell2.Origin
        Loop
        Dim oView As MicroStationDGN.View
        oView = MS.ActiveDesignFile.Views(1)
        oView.Center = Pdgn
        oView.Redraw()
    End Sub

    Private Sub SXoaDT()
        Try
            If lenhveMS = "vekhung" Then
                MS.CadInputQueue.SendKeyin("mdl silentload selectby;select type cell; selectby level " & "Trinh bay" & "; selectby cellname " & "Khung" & ";selectby execute; delete element")
            ElseIf lenhveMS = "Trinhbay" Then ''Trinhbay
                MS.CadInputQueue.SendKeyin("mdl silentload selectby;select type cell; selectby level " & "Trinh bay" & "; selectby cellname " & "Trinh bay" & ";selectby execute; delete element")
            Else
                If ChonDT(FrmMain.Instance.txtGroup.Text)(1) = "" Then
                    MS.CadInputQueue.SendKeyin("mdl silentload selectby;select type cell; selectby level " & ChonDT(FrmMain.Instance.txtGroup.Text)(0) & ";selectby execute; delete element")
                Else
                    MS.CadInputQueue.SendKeyin("mdl silentload selectby;select type cell; selectby level " & ChonDT(FrmMain.Instance.txtGroup.Text)(0) & "; selectby cellname " & ChonDT(FrmMain.Instance.txtGroup.Text)(1) & ";selectby execute; delete element")
                End If
            End If
            MS.CadInputQueue.SendKeyin("mdl unload selectby")
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Function ChonDT(mText As String) As List(Of String)
        Dim mLevel1 As String = "", mEle1 As String = ""
        Dim mEleSelect As New List(Of String)
        If Not mText.Contains(",") Then
            Dim count As Integer = mText.Count(Function(x) x = "\")
            If count = 0 Then
            ElseIf count = 1 Then
                mLevel1 = mText.Split("\")(1)
                mEle1 = ""
            ElseIf count = 2 Then
                mLevel1 = mText.Split("\")(1)
                mEle1 = mText.Split("\")(2)
            End If
            mEleSelect.Add(mLevel1)
            mEleSelect.Add(mEle1)
        Else
            For i As Integer = 0 To mText.Split(",").Length - 1
                mLevel1 = mText.Split(",")(i).Split("\")(1)
                mEleSelect.Add(mLevel1)
                mEle1 = mText.Split(",")(i).Split("\")(2)
                mEleSelect.Add(mEle1)
            Next

        End If
        ChonDT = mEleSelect
    End Function

#Region "   Luoi Km"

    Function PointMs(cPoint As IPosition71) As MicroStationDGN.Point3d
        Dim Pms As MicroStationDGN.Point3d = Nothing
        If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
            Pms.X = cPoint.X
            Pms.Y = cPoint.Y
            Pms.Z = 0
        Else
            FrmMain.Instance.SVn2000(cPoint)
            Pms.X = yVN2000
            Pms.Y = xVN2000
            Pms.Z = 0
        End If
        PointMs = Pms
    End Function

    Public Sub TextLuoi(Pm As MicroStationDGN.Point3d, SoKM As String, Justification As MsdTextJustification)
        Dim Kieuchu As MicroStationDGN.TextStyle
        Kieuchu = MS.ActiveSettings.TextStyle
        Kieuchu.Font = MS.ActiveDesignFile.Fonts.Find(MsdFontType.msdFontTypeWindowsTrueType, "UTM Cafeta")
        Kieuchu.Height = TyleMS * 150
        Kieuchu.Width = Kieuchu.Height * 0.7
        Dim ChuMs As TextElement = MS.CreateTextElement1(Nothing, SoKM, Pm, MS.Matrix3dIdentity)
        ChuMs.DisplayPriority = 20
        ChuMs.TextStyle = Kieuchu
        ChuMs.TextStyle.Justification = Justification
        ChuMs.Color = mauMSDen
        ChuMs.Level = mLevel
        MS.ActiveModelReference.AddElement(ChuMs)
        ChuMs.Redraw(MsdDrawingMode.msdDrawingModeNormal)
        MS.CommandState.StartDefaultCommand()
        MS.ActiveModelReference.SelectElement(ChuMs)
    End Sub

    Private Sub LuoiKmMs()
        If FrmMain.Instance.chebLuoiKm.Checked = False Then
            Exit Sub
        Else
            Dim sgKm As Double
            If FrmMain.Instance.cbTylebando.SelectedIndex = 3 Then
                sgKm = 2
            ElseIf FrmMain.Instance.cbTylebando.SelectedIndex = 0 Or FrmMain.Instance.cbTylebando.SelectedIndex = 1 Or FrmMain.Instance.cbTylebando.SelectedIndex = 2 Then
                sgKm = 1
            End If
            Dim Pmin As IPosition71 = FrmMain.Instance.MaxMinPointKhung(0) ' FrmMain.Instance.sgworldMain.Creator.CreatePosition(Xmin, Ymin, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)
            Dim Pmax As IPosition71 = FrmMain.Instance.MaxMinPointKhung(1) ' FrmMain.Instance.sgworldMain.Creator.CreatePosition(Xmax, Ymax, 0, AltitudeTypeCode.ATC_ON_TERRAIN, 0, 0, 0, 0)

            Dim PmX As MicroStationDGN.Point3d = Nothing
            Dim PmY As MicroStationDGN.Point3d = Nothing
            Dim KmXmin As String = TdMs(Pmin)(0).ToString.Split(".")(0).Substring(0, 3)
            Dim KmYmin As String = TdMs(Pmin)(1).ToString.Split(".")(0).Substring(0, 4)
            Dim soKmX As Double, soKmY As Double
            Dim KmXmax As String = TdMs(Pmax)(0).ToString.Split(".")(0).Substring(0, 3)
            Dim KmYmax As String = TdMs(Pmax)(1).ToString.Split(".")(0).Substring(0, 4)
            Dim Xmax As Double = TdMs(Pmax)(0)
            Dim Ymax As Double = TdMs(Pmax)(1)
            'Dim SoTextX As Integer = System.Convert.ToInt32(Val(KmXmax) - Val(KmXmin))
            'Dim SoTextY As Integer = System.Convert.ToInt32(Val(KmYmax) - Val(KmYmin)) '- 1 System.Convert.ToInt32(Val(KmXmax) - Val(KmXmin)
            soKmX = Val(KmXmin)
            PmX.Y = TdMs(Pmin)(1) - (300.0 * Tyle)
            soKmX = Km100000(soKmX)
            'Hang duoi
            For i As Integer = 1 To (System.Convert.ToInt32(Val(KmXmax) - Val(KmXmin)) - 1) Step sgKm
                soKmX += sgKm
                PmX.X = soKmX * 1000
                TextLuoi(PmX, soKmX, MsdTextJustification.msdTextJustificationCenterCenter) '.msdTextJustificationRightCenter)
            Next
            If Xmax - PmX.X > 1000 * sgKm Then
                soKmX += sgKm
                PmX.X += 1000 * sgKm
                TextLuoi(PmX, soKmX, MsdTextJustification.msdTextJustificationCenterCenter) '.msdTextJustificationRightCenter)
            End If
            'Hang tren
            soKmX = Val(KmXmin)
            soKmX = Km100000(soKmX)
            PmX.Y = TdMs(Pmax)(1) + (300.0 * Tyle)
            For i As Integer = 1 To (System.Convert.ToInt32(Val(KmXmax) - Val(KmXmin)) - 1) Step sgKm
                soKmX += sgKm
                PmX.X = soKmX * 1000
                TextLuoi(PmX, soKmX, MsdTextJustification.msdTextJustificationCenterCenter) '.msdTextJustificationRightCenter)
            Next
            If Xmax - PmX.X > 1000 * sgKm Then
                soKmX += sgKm
                PmX.X += 1000 * sgKm
                TextLuoi(PmX, soKmX, MsdTextJustification.msdTextJustificationCenterCenter) '.msdTextJustificationRightCenter)
            End If
            'Hang trai
            soKmY = Val(KmYmin)
            soKmY = Km100000(soKmY)
            PmY.X = TdMs(Pmin)(0) - (150.0 * Tyle)
            For i As Integer = 1 To (System.Convert.ToInt32(Val(KmYmax) - Val(KmYmin)) - 1) Step sgKm
                soKmY += sgKm
                PmY.Y = soKmY * 1000
                TextLuoi(PmY, soKmY, MsdTextJustification.msdTextJustificationRightCenter) '.msdTextJustificationRightCenter)
            Next
            If Ymax - PmY.Y > 1000 * sgKm Then
                soKmY += sgKm
                PmY.Y += 1000 * sgKm
                TextLuoi(PmY, soKmY, MsdTextJustification.msdTextJustificationRightCenter) '.msdTextJustificationRightCenter)
            End If
            'Hang phai
            soKmY = Val(KmYmin)
            soKmY = Km100000(soKmY)
            PmY.X = TdMs(Pmax)(0) + (200.0 * Tyle)
            For i As Integer = 1 To (System.Convert.ToInt32(Val(KmYmax) - Val(KmYmin)) - 1) Step sgKm
                soKmY += sgKm
                PmY.Y = soKmY * 1000
                TextLuoi(PmY, soKmY, MsdTextJustification.msdTextJustificationLeftCenter) '.msdTextJustificationRightCenter)
            Next
            If Ymax - PmY.Y > 1000 * sgKm Then
                soKmY += sgKm
                PmY.Y += 1000 * sgKm
                TextLuoi(PmY, soKmY, MsdTextJustification.msdTextJustificationLeftCenter) '.msdTextJustificationRightCenter)
            End If
        End If
    End Sub

    Function TdMs(cPoint As IPosition71) As List(Of Double)
        Dim liToadoMs As New List(Of Double)
        If FrmMain.Instance.cbMuiChieu.SelectedIndex = 9 Then
            liToadoMs.Add(cPoint.X.ToString)
            liToadoMs.Add(cPoint.Y.ToString)
            liToadoMs.Add(0)
        Else
            FrmMain.Instance.SVn2000(cPoint)
            liToadoMs.Add(yVN2000.ToString)
            liToadoMs.Add(xVN2000.ToString)
            liToadoMs.Add("0")
        End If
        TdMs = liToadoMs
    End Function

    Function Km100000(soKm As Double) As Double
        Dim soKm1 As Double
        If FrmMain.Instance.cbTylebando.SelectedIndex = 3 Then
            If (soKm Mod 2 = 0) Then
                soKm1 = soKm
            Else
                soKm1 = soKm - 1
            End If
        Else
            soKm1 = soKm
        End If
        Km100000 = soKm1
    End Function
#End Region

End Module






