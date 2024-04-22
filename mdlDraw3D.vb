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
        If FrmMain.pnTrinhchieu.Visible = True Or FrmMain.ChebBangDT.Checked = False Then
            Point1.Y = mAxWindows3D.Height + mAxinfor.Height + 100
        ElseIf FrmMain.pnTrinhchieu.Visible = False Or FrmMain.ChebBangDT.Checked = True Then
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
            '  MsgBox("Lenhve2D = " & Lenhve2D)
            'If Not Lenhve2D = "duongtovung" And Not Lenhve2D = "vungtoduong" And Not Lenhve2D = "noiduong" And Not Lenhve2D = "catduong" And Not Lenhve2D = "catvung" And Not Lenhve2D = "gopvung" And Not Lenhve2D = "giaovung" And
            '       Lenhve <> "chonDTnhapnhay" And Not Lenhve2D = "chonDTan" And Not Lenhve2D = "chonPhim" And Not Lenhve2D = "chonDTchuyendong" And Not Lenhve2D = "radaquay" Then  'And Not Lenhve2D = "noiduong"
            '    Giaidoan = "GD" & (FrmMain.cbGiaidoan.SelectedIndex + 1).ToString
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
                CGiaidoan = CGiaidoan '"GD" & (FrmMain.cbGiaidoan.SelectedIndex + 1).ToString
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
            If Lenhve2D = "Venhieuco" Or Lenhve2D = "veco" Or Lenhve2D = "Taungam" Or Lenhve2D = "Doituongchu" Or Lenhve2D = "chenanh" Or Lenhve2D = "TaungamPB" Or Lenhve2D = "kvchupanh" Or Lenhve2D = "baicocchongtang" Then 'Or Lenhve2D = "transLABEL"
                CreateLabel3D()
            ElseIf Lenhve2D = "taophim" Then
                Video3D()
            ElseIf Lenhve2D = "ModelNet" Or Lenhve2D = "mohinhPB" Or Lenhve2D = "mohinh" Or Lenhve2D = "chenmohinh" Then
                MohinhPB3D()
            ElseIf Lenhve2D = "ModelMotionNet" Or Lenhve2D = "mohinhnguoidung" Or Lenhve2D = "1DTchuyendontheoduong" Or Lenhve2D = "dtChuyendongMH" Or Lenhve2D = "MHNDchuyendong" Or Lenhve2D = "chonDuongtaoChuoiND" Or Lenhve2D = "2DTchuyendondoc" Or Lenhve2D = "2DTchuyendongngang" Or Lenhve2D = "3DTchuyendonTG" Or Lenhve2D = "3DTchuyendonTG1" Or Lenhve2D = "3DTchuyendonNgang" Or Lenhve2D = "3DTchuyendondoc" Then
                DTchuyendong3D()
            ElseIf Lenhve2D = "ChieusauTS" Or Lenhve2D = "MBchupanhTS" Or Lenhve2D = "giaothonghao" Or Lenhve2D = "Duonghanhquan" Or Lenhve2D = "Doituongduong" Or Lenhve2D = "duongbienphong" Or Lenhve2D = "LineNet" Or Lenhve2D = "nhiemvutruocmat" Or Lenhve2D = "nhiemvutieptheo" Or
                   Lenhve2D = "tuyendanhchan" Or Lenhve2D = "kvTapket" Or Lenhve2D = "kvTochucDoihinh" Or Lenhve2D = "kvCodong" Or Lenhve2D = "kvTuantieu" Or lenhve2D = "Giaothonghaoconap" Or Lenhve2D = "toTrsTrongdich" Or Lenhve2D = "toTrSDieutra" Or
                   Lenhve2D = "veduongsongsong" Or Lenhve2D = "kvTamdung" Or Lenhve2D = "kvDoitau" Or Lenhve2D = "vetNXdudoan" Or Lenhve2D = "vetNXthucte" Or Lenhve2D = "hangraobungnhung" Or
                   Lenhve2D = "doboduongkhong" Or Lenhve2D = "kvkhoinguytrang" Or Lenhve2D = "tuyenkhoinguytrang" Or Lenhve2D = "kvVaybat" Or Lenhve2D = "SungBBbanMB" Or Lenhve2D = "kvTKHHdukien" Or
                   Lenhve2D = "KVdongquan" Or Lenhve2D = "khuvucphongthutrongdiem" Or Lenhve2D = "khuvucphaigiu" Or Lenhve2D = "khuvucphongthuthenchot" Or Lenhve2D = "langchiendau" Or Lenhve2D = "KVTrinhsatSN" Or Lenhve2D = "KVTrinhsatSCN" Or Lenhve2D = "KvTRanhchap" Or Lenhve2D = "KvXamcanh" Or Lenhve2D = "KvXamcu" Or Lenhve2D = "KvBdCongnghe" Or
                   Lenhve2D = "cancuhauphuong" Or Lenhve2D = "cancuchiendau" Or Lenhve2D = "ANQP" Or Lenhve2D = "KvDichmoiden" Or Lenhve2D = "MTCanbaove" Or Lenhve2D = "KvLanchiem" Or Lenhve2D = "CCCDBP" Or Lenhve2D = "KvHoaluc" Or Lenhve2D = "KvTieutay" Or Lenhve2D = "KVbitran" Or Lenhve2D = "KvKho" Or Lenhve2D = "KvKT" Or
                   Lenhve2D = "KVNgapnuoc" Or Lenhve2D = "KVCatvui" Or Lenhve2D = "KvKhotrandau" Or Lenhve2D = "KvTautrandau" Or Lenhve2D = "KvGkhoantrandau" Or Lenhve2D = "KvCamTbVTD" Or Lenhve2D = "KvBvMtieuBangGnhieungoinoVT" Or Lenhve2D = "KvBiphahuyHN" Then
                LineArray3D()
                'ElseIf Lenhve2D = "tn500" Or Lenhve2D = "tn1000" Or Lenhve2D = "tn5000" Or Lenhve2D = "tnNT1000" Or Lenhve2D = "tnNT5000" Or Lenhve2D = "tnNT6000" Or Lenhve2D = "tnKTV" Or Lenhve2D = "tnKTVkoRo" Or Lenhve2D = "TNchongTN" Then
                '    ImageOnRegion()
                'DT Vung
            ElseIf Lenhve2D = "ANQP" Or Lenhve2D = "vekhung" Or Lenhve2D = "hinhchunhat" Or Lenhve2D = "Doituongvung" Or Lenhve2D = "kvtrucban" Or Lenhve2D = "baihacanh" Or Lenhve2D = "sanbaygia" Or Lenhve2D = "sanbaydachien" Or Lenhve2D = "sanbayvuotcap" Or Lenhve2D = "sanbaycap1" Or
                           Lenhve2D = "sanbaycap2" Or Lenhve2D = "sanbaycap3" Or Lenhve2D = "HamkiencochongNBC" Or Lenhve2D = "baiminHQ" Or Lenhve2D = "khudancumoi" Or Lenhve2D = "diadao" Or Lenhve2D = "ngaplut" Or Lenhve2D = "kvdautran" Or Lenhve2D = "catcuuhoa" Or Lenhve2D = "minchongtang" Or
                           Lenhve2D = "trunglien" Or Lenhve2D = "dailien" Or Lenhve2D = "phongluu" Or Lenhve2D = "b40" Or Lenhve2D = "b41" Or Lenhve2D = "coi60" Or Lenhve2D = "congsuhoakhiconap" Or Lenhve2D = "congsu" Or Lenhve2D = "hamkhongconap" Or
                           Lenhve2D = "hamNBC" Or Lenhve2D = "xetanghangtrung" Or Lenhve2D = "xetangloinuoc" Or Lenhve2D = "xetangromooc" Or Lenhve2D = "xetangquetmin" Or Lenhve2D = "Tanguidat" Or Lenhve2D = "thietgiap" Or Lenhve2D = "thietgiaploinuoc" Or
                           Lenhve2D = "xechobobinh" Or Lenhve2D = "PhaophanlucKyhieuchung" Or Lenhve2D = "Phaophanluccotrung" Or Lenhve2D = "Phaophanluccolon" Or Lenhve2D = "tenluaB72" Or Lenhve2D = "tenluaPhagot" Or Lenhve2D = "tenluacocanhhatnhan" Or
                           Lenhve2D = "TLChongngamNBC" Or Lenhve2D = "TLNguloiTudanT" Or Lenhve2D = "TLNguloiTudanNBC" Or Lenhve2D = "tenluaCCMDchienthuat" Or Lenhve2D = "tenluaCCtuMB" Or Lenhve2D = "tenluaChongRada" Or
                           Lenhve2D = "TSTiengdong" Or Lenhve2D = "tuyenbancodinh" Or Lenhve2D = "hoaluc" Or Lenhve2D = "tausanbay" Or Lenhve2D = "tausanbayChongngam" Or Lenhve2D = "xuongdobo" Or Lenhve2D = "taulaikeo" Or
                           Lenhve2D = "taudoboKCH" Or Lenhve2D = "taudoboNHO" Or Lenhve2D = "taudoboVUA" Or Lenhve2D = "taudoboLON" Or Lenhve2D = "TauTuantieuChongngam" Or Lenhve2D = "tauphongloicanhngam" Or Lenhve2D = "TauVTdansu" Or
                           Lenhve2D = "TauhodauDS" Or Lenhve2D = "TauDanhcaDS" Or Lenhve2D = "TauDanhcaVT" Or Lenhve2D = "TauDanhcaNN" Or Lenhve2D = "canoDS" Or Lenhve2D = "canoHQ" Or Lenhve2D = "xuongcheotay" Or Lenhve2D = "thuyloineo" Or
                           Lenhve2D = "thuyloiday" Or Lenhve2D = "thuyloitroi" Or Lenhve2D = "thuyloiAngten" Or Lenhve2D = "toanTSDN" Or Lenhve2D = "toTSDN" Or Lenhve2D = "toTSDQTV" Or
                           Lenhve2D = "trienkhaitienconge" Or Lenhve2D = "tiencongquaylai" Or Lenhve2D = "vayep" Or Lenhve2D = "hamngamDP" Or Lenhve2D = "hamngamDPNBC" Or Lenhve2D = "muitiencongkep" Or Lenhve2D = "muitiencongCYngan" Or
                           Lenhve2D = "chotchan" Or Lenhve2D = "hoalucV" Or Lenhve2D = "hoalucCN" Or Lenhve2D = "tangcancau" Or Lenhve2D = "toQStrenXT" Or Lenhve2D = "toQStrenTG" Or Lenhve2D = "nganchandamdong" Or Lenhve2D = "DQTVcodong" Or
                           Lenhve2D = "phuckich" Or Lenhve2D = "dontho" Or Lenhve2D = "tohoahoc" Or Lenhve2D = "doihoahoc" Or Lenhve2D = "hambimat" Or Lenhve2D = "tuyenxamnhap" Or Lenhve2D = "doicongtacBP" Or Lenhve2D = "dacnhiemBP" Or
                           Lenhve2D = "tauphaonho" Or Lenhve2D = "tautuantieu" Or Lenhve2D = "tauhuanluyen" Or Lenhve2D = "tauquetloi" Or Lenhve2D = "xuongkhonoi" Or Lenhve2D = "tocongtacBP" Or Lenhve2D = "doidaccong" Or
                           Lenhve2D = "muidaccong" Or Lenhve2D = "todaccong" Or Lenhve2D = "doidaccongTC" Or Lenhve2D = "muidaccongTC" Or Lenhve2D = "DCTCbangTauNgam" Or Lenhve2D = "DCTCbangTauDS" Or Lenhve2D = "xeTSPT76" Or
                           Lenhve2D = "xeTSBMP" Or Lenhve2D = "xeTScanhgioi" Or Lenhve2D = "tautuantieuTS" Or Lenhve2D = "Canotrinhsat" Or Lenhve2D = "tauCuunan" Or Lenhve2D = "cuma" Or
                           Lenhve2D = "khuvucbieutinhVT" Or Lenhve2D = "khuvucaoloankoVT" Or Lenhve2D = "khuvucbieutinhkoVT" Or
                           Lenhve2D = "MatcuA2" Or Lenhve2D = "doiKPHQ" Or Lenhve2D = "khitaiTPP" Or Lenhve2D = "xuongBBDL10" Or Lenhve2D = "Phatuhanh" Or Lenhve2D = "Xeloinuocbanhxich" Or Lenhve2D = "XeBAT" Or Lenhve2D = "doicongbinh" Or
                           Lenhve2D = "canoCB" Or Lenhve2D = "hamphao" Or Lenhve2D = "hamVK" Or Lenhve2D = "minbobinh" Or Lenhve2D = "hamchong" Or Lenhve2D = "cuamoBB" Or Lenhve2D = "cuamoXT" Or Lenhve2D = "tuyenRMbangTrT" Or
                           Lenhve2D = "luoinguytrang" Or Lenhve2D = "tamnguytrang" Or Lenhve2D = "sanbaytrenbien" Or Lenhve2D = "HuongTCKQchienluoc" Or Lenhve2D = "tuyenthoatly" Or Lenhve2D = "muitiencongchuyeu" Or Lenhve2D = "muiteincongthuyeu" Or 'Lenhve2D = "baicocchongtang" Or
                           Lenhve2D = "vantaitauthuyen" Or Lenhve2D = "dayNquayve" Or Lenhve2D = "congsuhoakhikhongnap" Or Lenhve2D = "hamconap" Or Lenhve2D = "HamdachienchongNBC" Or Lenhve2D = "xetanghangnang" Or
                           Lenhve2D = "TangchoBB" Or Lenhve2D = "TangHong" Or Lenhve2D = "TangbiTieudiet" Or Lenhve2D = "tangsalay" Or Lenhve2D = "tangmaccan" Or Lenhve2D = "Coi82" Or
                           Lenhve2D = "tenluaB72xe" Or Lenhve2D = "tenluaCCMDchiendich" Or Lenhve2D = "tautuanduongTLDH" Or Lenhve2D = "taukhutrucTLDH" Or Lenhve2D = "tautieutu" Or Lenhve2D = "taupharaoloi" Or Lenhve2D = "tauthaloi" Or
                           Lenhve2D = "tauthaluoi" Or Lenhve2D = "TauVTquansu" Or Lenhve2D = "TauVTnuocngoai" Or Lenhve2D = "TauhodauQS" Or Lenhve2D = "TauhoNuoc" Or Lenhve2D = "TauQuany" Or Lenhve2D = "banphongno" Or
                           Lenhve2D = "TauTLHatnhan" Or Lenhve2D = "Tiencong_VeXP" Or Lenhve2D = "coilui" Or Lenhve2D = "khusotannhandan" Or Lenhve2D = "hambimatNBC" Or
                           Lenhve2D = "tocodongdiettang" Or Lenhve2D = "luonsau" Or Lenhve2D = "Donlong" Or Lenhve2D = "vaylan" Or Lenhve2D = "donthuy" Or Lenhve2D = "kvTKHHbangphao" Or Lenhve2D = "kvTKHHbangCoi" Or Lenhve2D = "kvTKHHbangMB" Or
                           Lenhve2D = "kvTKHHbangTL" Or Lenhve2D = "kvsucoHH" Or Lenhve2D = "phuckichBP" Or Lenhve2D = "doidaccongnuoc" Or Lenhve2D = "muidaccongnuoc" Or
                           Lenhve2D = "muidaccongcodong" Or Lenhve2D = "DChoatrang" Or Lenhve2D = "doiTShonhop" Or Lenhve2D = "todaccongnuoc" Or Lenhve2D = "xecuuhoa" Or Lenhve2D = "tauBinan" Or Lenhve2D = "khusotanBaolut" Or
                           Lenhve2D = "Phaoluutuhanh" Or Lenhve2D = "Phaonongdaituhanh" Or Lenhve2D = "Phaoluunongdaituhanh" Or Lenhve2D = "baoloanHH" Or Lenhve2D = "khugiaututhi" Or Lenhve2D = "kvemsanLL" Or Lenhve2D = "muctieuDKchiem" Or
                           Lenhve2D = "muctiechatno" Or Lenhve2D = "mindinhhuong" Or Lenhve2D = "ominchongtang" Or Lenhve2D = "tramcapnuoc" Or Lenhve2D = "muctieuDachiem" Or Lenhve2D = "muctieuHH" Or Lenhve2D = "maybaychivien" Or
                           Lenhve2D = "canoBP" Or Lenhve2D = "tramxulytauNN" Or Lenhve2D = "xetanghangnhe" Or Lenhve2D = "ThapphaoXT" Or Lenhve2D = "xetangbaccau" Or
                           Lenhve2D = "Coi120" Or Lenhve2D = "tenluaCCMDchienluoc" Or Lenhve2D = "tuyenbanCS" Or Lenhve2D = "Taudemkhongkhi" Or Lenhve2D = "TauBanhvien" Or Lenhve2D = "TSPKbatTB" Or Lenhve2D = "TSbatcocTB" Or
                           Lenhve2D = "trienkhaitiencongXTe" Or Lenhve2D = "sucsaotruylung" Or Lenhve2D = "quanlon" Or Lenhve2D = "DHPNBB" Or Lenhve2D = "DHPNBBXT" Or Lenhve2D = "KvPNthenchot" Or
                           Lenhve2D = "Tiencong_Dung" Or Lenhve2D = "PNtiepxuc" Or Lenhve2D = "coiDKZlui" Or Lenhve2D = "emsan" Or Lenhve2D = "nganchan" Or Lenhve2D = "tuyenPTdobo" Or Lenhve2D = "huongxamnhapCY" Or Lenhve2D = "huongxamnhapTY" Or
                           Lenhve2D = "nganchanBP" Or Lenhve2D = "DCTCbangTauNN" Or Lenhve2D = "tauchuachay" Or Lenhve2D = "caubitroi" Or Lenhve2D = "dephanlucham" Or Lenhve2D = "khuvucaoloanVT" Or
                           Lenhve2D = "muctieuBLLD" Or Lenhve2D = "noigiamcontin" Or Lenhve2D = "khitaiPMP" Or Lenhve2D = "caucogioi" Or Lenhve2D = "Xeraimin" Or Lenhve2D = "hambetong" Or Lenhve2D = "baiminchongtau" Or
                           Lenhve2D = "tuyenVChonhop" Or Lenhve2D = "tuyenRMhonhop" Or Lenhve2D = "khusotanCQXN" Or Lenhve2D = "hanhlangbay" Or Lenhve2D = "HuongTCKQchienthuat" Or Lenhve2D = "HuongTCKQchienthuat2" Or Lenhve2D = "kvXuaduoi" Or
                           Lenhve2D = "Coi160" Or Lenhve2D = "TSTKbatTB" Or Lenhve2D = "tapkich" Or Lenhve2D = "baiminHonHop" Or Lenhve2D = "baiminBB" Or Lenhve2D = "baiminchongtangHTD" Or
                           Lenhve2D = "tuyenVCkhongno" Or Lenhve2D = "maybayhoatdong" Or Lenhve2D = "tuyenPHLTLon" Or Lenhve2D = "PhaoPKtuhanh" Or Lenhve2D = "TauBPbatgiu" Or Lenhve2D = "TauBPapgiai" Or
                           Lenhve2D = "tuyenthuyloineo" Or Lenhve2D = "tuyenthuyloiday" Or Lenhve2D = "CongNongLamtruongCD" Or Lenhve2D = "cumcongsu" Or Lenhve2D = "trandiachongtang" Or
                           Lenhve2D = "danhhuongthuyeu" Or Lenhve2D = "kvbaidobo" Or Lenhve2D = "tuyenTochucDoihinh" Or Lenhve2D = "tuyenTKdobo" Or Lenhve2D = "tuyenXPdobo" Or Lenhve2D = "causap" Or Lenhve2D = "tuyenPHLTnho" Or Lenhve2D = "PhaoPKtuhanhR" Or
                           Lenhve2D = "TauBPkiemtra" Or Lenhve2D = "muctieuthenchot" Or Lenhve2D = "DiemtuaTrungdoi" Or Lenhve2D = "DiemtuaDaidoi" Or Lenhve2D = "KvhoatdongMBTcdt" Or Lenhve2D = "KvNhieutieucuc" Or
                           Lenhve2D = "Biendoitauhanhquan" Or Lenhve2D = "kvgiaochien" Or Lenhve2D = "khongquandanhbien" Or Lenhve2D = "toanTSsucsao" Or Lenhve2D = "toTSsucsao" Or Lenhve2D = "toTSDPsucsao" Or Lenhve2D = "danhhuongchuyeu" Or Lenhve2D = "tuantraBP" Or
                           Lenhve2D = "tauBPtuantra" Or Lenhve2D = "tuyenPHkoLTnho" Or Lenhve2D = "tuyenPHkoLTlon" Or Lenhve2D = "TsatBangChiendau" Or
                           Lenhve2D = "kvTKHHxuly" Or Lenhve2D = "vungNet" Or Lenhve2D = "GioituyenHcTang" Or Lenhve2D = "DHPNBB" Or Lenhve2D = "DHPNBBXT" Or Lenhve2D = "muctieuthenchot" Or
                           Lenhve2D = "mucbucxa" Or Lenhve2D = "choneotau" Or Lenhve2D = "tramtaptrungQNDB" Or Lenhve2D = "tramtaptrungPTKT" Or Lenhve2D = "tramtaptrungQNDBcm" Or Lenhve2D = "chuongngaivat" Or Lenhve2D = "ovatcan" Or Lenhve2D = "diaban" Or
                           Lenhve2D = "tamnhiemxa" Or Lenhve2D = "diemnong" Or Lenhve2D = "kvvkhatnhanno" Or Lenhve2D = "hinhtron" Or Lenhve2D = "kvttllDongvien" Or Lenhve2D = "caulacboPD" Or Lenhve2D = "daisuquan" Or Lenhve2D = "dienngingo" Or
                           Lenhve2D = "muctieuphaibaove" Or Lenhve2D = "kvvksinhhoc" Or Lenhve2D = "kvcophandong" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "ellipse" Or Lenhve2D = "tramtiepnhanQNDB" Or Lenhve2D = "tramtiepnhanPTKT" Or
                           Lenhve2D = "Khuvucnganchanchotgiu" Or Lenhve2D = "khuvucbieutinhVT" Or Lenhve2D = "khuvucbieutinhkoVT" Or Lenhve2D = "baoloanHH" Or Lenhve2D = "khuvucBLTieutay" Or Lenhve2D = "khuvucaoloanVT" Or Lenhve2D = "khuvucaoloankoVT" Or
                           Lenhve2D = "kvMuctieukoDemat" Or Lenhve2D = "tramGiao_nhan" Or Lenhve2D = "KVgayroi" Or Lenhve2D = "danhcatgiaothong" Or Lenhve2D = "baiminhoahoc" Or Lenhve2D = "baiminlua" Or Lenhve2D = "baiminhoahocNo" Or
                           Lenhve2D = "taukhutruc" Or Lenhve2D = "tauten2Ong" Or Lenhve2D = "tauten4Ong" Or Lenhve2D = "tautuanduonghangnhe" Or Lenhve2D = "tautuanduonghangnang" Or Lenhve2D = "tauhove" Or Lenhve2D = "tauphaonho" Or Lenhve2D = "tauphaolon" Or Lenhve2D = "tautenluanho" Or Lenhve2D = "tauChongngam" Or
                           Lenhve2D = "tenluacocanhtamgan" Or Lenhve2D = "tenluacocanhtamtrung" Or Lenhve2D = "tenluacocanhtamxa" Or Lenhve2D = "tenluacocanhtamxa2Ranh" Or Lenhve2D = "tenluacocanhtamgan2Ranh" Or Lenhve2D = "tenluacocanhtamtrung2Ranh" Or
                           Lenhve2D = "GioituyenCDsudoan" Or Lenhve2D = "ranhgioihaitieukhu" Or Lenhve2D = "ranhgioihaidonbienphong" Or Lenhve2D = "ranhgioikhucam" Or Lenhve2D = "ranhgioichieusaukhuvucbiengioi" Or Lenhve2D = "biengioitrenbien" Or Lenhve2D = "duonglanhhai" Or
                           Lenhve2D = "GioituyenVachdung" Or Lenhve2D = "GioituyenHrCDcomin" Or Lenhve2D = "GioituyenHrKGCC" Or Lenhve2D = "GioituyenHrCD" Or Lenhve2D = "Gioituyen" Or Lenhve2D = "DoihinhBBTamdung" Or Lenhve2D = "DhinhBaovaydich" Or Lenhve2D = "Muithocsau" Or Lenhve2D = "DoihinhBbXPquaCuamo" Or
                           Lenhve2D = "GioituyenHcTang" Or Lenhve2D = "Duongongxangdaucodinh" Or Lenhve2D = "Duongongxangdaudachien" Or Lenhve2D = "dexungyeu" Or Lenhve2D = "satlo" Or Lenhve2D = "TuongCoRaogai" Or Lenhve2D = "duonghanhquantaudobo" Or
                           Lenhve2D = "duonghanhquantauchiendau" Or Lenhve2D = "duonghanhquantaudobo" Or Lenhve2D = "duonghanhquantauvantai" Or Lenhve2D = "2130003" Or Lenhve2D = "2130002" Or Lenhve2D = "2130001" Or Lenhve2D = "2130007" Or Lenhve2D = "2130006" Or
                           Lenhve2D = "2130005" Or Lenhve2D = "2130004" Or Lenhve2D = "GioituyenCDcBB" Or Lenhve2D = "GioituyenCDdBB" Or Lenhve2D = "GioituyenCDtrungdoan" Or Lenhve2D = "GioituyenCDsudoan" Or Lenhve2D = "GioituyenCDquandoan" Or Lenhve2D = "GioituyenCDquankhu" Or
                           Lenhve2D = "RGcumchiendaulienhoan" Or Lenhve2D = "duonghanhquan" Or Lenhve2D = "GioituyenCapdachien" Or Lenhve2D = "GioituyenCapquang" Or Lenhve2D = "GioituyenGioituyenCapdachienduongdai" Or Lenhve2D = "GioituyenCapdongtruc" Or Lenhve2D = "GioituyenCapnguondien" Or
                           Lenhve2D = "tn500" Or Lenhve2D = "tn1000" Or Lenhve2D = "tn5000" Or Lenhve2D = "tnNT1000" Or Lenhve2D = "tnNT5000" Or Lenhve2D = "tnNT6000" Or Lenhve2D = "tnKTV" Or Lenhve2D = "tnKTVkoRo" Or Lenhve2D = "TNchongTN" Or Lenhve2D = "kvtsmatdat" Or Lenhve2D = "kvtstrenkhong" Or
                           Lenhve2D = "TuyenTrKTcBobinh" Or Lenhve2D = "TuyenTrKTcBobinhXetang" Or Lenhve2D = "TuyenTrKTcBBtruocXT" Or Lenhve2D = "TuyenTrKTcXTtruocBB" Or Lenhve2D = "vunghoaluc" Or Lenhve2D = "KvTTrHoalucphandoi" Or
                           Lenhve2D = "OneXTTc" Or Lenhve2D = "XTPhuckich" Or Lenhve2D = "XTBantructiep" Or Lenhve2D = "XTTiencong" Or Lenhve2D = "TuyenbanXT" Or Lenhve2D = "XTchuyenPngu" Or Lenhve2D = "XTPngutrongTD" Then

                DTvung3D()
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
                'ElseIf Lenhve2D = "vunghoaluc" Then
                '    MsgBox(Lenhve2D)
                '    VHL3D()
            End If
            If mMicrostation = False Then
                If Lenhve2D = "mohinh" Or Lenhve2D = "dtChuyendongMH" Or Lenhve2D = "mohinh" Or Lenhve2D = "2DTchuyendongngang" Or Lenhve2D = "2DTchuyendondoc" Or Lenhve2D = "3DTchuyendonTG" Or Lenhve2D = "3DTchuyendonTG1" Or Lenhve2D = "3DTchuyendonNgang" Or Lenhve2D = "3DTchuyendondoc" Then
                    FrmMain.TxtTenKH.Text = ""
                End If
                FrmMain.BienEmpty()
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
        FrmMain.Focus()
    End Sub

    Private Sub XoaGroup3D()
        Try
            XoaGr(sgworld3DBd, frmMain.txtGroup.Text)
            If A3D = True Then
                XoaGr(sgworld3DA, frmMain.txtGroup.Text)
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
            VungAr3D()
            LineArray3D()
        ElseIf Lenhve2D = "kvchupanh" Then
            LineArray3D()
        End If
    End Sub

    Private Sub LabelArray(sgworldK As SGWorld71, mGroup As String)
        fLabelStyle3D = SLabelStyleTQ(sgworldK)
        fileImage = ""
        '  MsgBox(mLabelArray.Count.ToString)
        If mLabelArray.Count > 0 Then
            For i As Integer = 0 To mLabelArray.Count - 1
                Dim mText As ITerrainLabel71 = FrmMain.sgworldMain.Creator.GetObject(mLabelArray(i).ID)
                If Lenhve2D = "taungam" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "baicocchongtang" Then
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
        Else
            Exit Sub
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
        If Lenhve2D = "ChieusauTS" Or Lenhve2D = "MBchupanhTS" Or Lenhve2D = "nhiemvutruocmat" Or Lenhve2D = "nhiemvutieptheo" Or Lenhve2D = "kvTochucDoihinh" Or Lenhve2D = "kvTuantieu" Or Lenhve2D = "kvVaybat" Or Lenhve2D = "vetNXdudoan" Or Lenhve = "vetNXthucte" Or Lenhve2D = "kvTKHHdukien" Or Lenhve2D = "KvTTrHoalucphandoi" Or Lenhve2D = "khuvucphongthuthenchot" Or Lenhve2D = "cancuchiendau" Or Lenhve2D = "khuvucphongthutrongdiem" Then
            VungAr3D()
        ElseIf Lenhve2D = "doboduongkhong" Or Lenhve2D = "SungBBbanMB" Or Lenhve2D = "KvDichmoiden" Or Lenhve2D = "KvKhotrandau" Or Lenhve2D = "KvTautrandau" Or Lenhve2D = "KVTrinhsatSCN" Or Lenhve2D = "KVTrinhsatSN" Or Lenhve2D = "KvHoaluc" Or Lenhve2D = "KvBvMtieuBangGnhieungoinoVT" Or Lenhve2D = "KvCamTbVTD" Or Lenhve2D = "KvKho" Or Lenhve2D = "KvBdCongnghe" Or Lenhve2D = "CCCDBP" Then
            CreateLabel3D()
        ElseIf Lenhve2D = "toTrsTrongdich" Or Lenhve2D = "toTrSDieutra" Then
            CreateLabel3D()
            VungAr3D()
        End If
    End Sub

    Private Sub Line3D(sgworldK As SGWorld71, mGroup As String)
        ' Dim D1 As ITerrainPolyline71 '= Nothing
        'If Lenhve2D = "catduong" Or Lenhve2D = "noiduong" Then
        '    Dim k1 As ITerrainPolyline71 = sgworldK.ProjectTree.GetObject(sgworldK.ProjectTree.FindItem(FrmMain.txtGroup.Text.Split(",")(0)))
        '    sgworldK.Creator.DeleteObject(k1.ID)
        '    '  SXoaDTCat(sgworldK)
        'End If
        Dim k1 As ITerrainPolyline71, D1 As ITerrainPolyline71 = Nothing
        If mLineArrayHR.Count > 0 Then
            If Lenhve2D = "hangraobungnhung" Then
                k1 = FrmMain.sgworldMain.Creator.GetObject(mLineArrayHR(0).ID)
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
            Else
                For i As Integer = 0 To mLineArray.Count - 1
                    k1 = FrmMain.sgworldMain.Creator.GetObject(mLineArray(i).ID)
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
            If Not Lenhve2D = "trinhbay" Then
                ZoomLAND(sgworldK, D1)
                ' ZoomTQ(sgworldK)
            End If
        Else
            Exit Sub
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
                Dim k1 As ITerrainPolygon71 = FrmMain.sgworldMain.Creator.GetObject(mRegionArray(i).ID)
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
                cPolygon.Tooltip.Text = k1.Tooltip.Text
                cPolygon.FillStyle.Texture.TilingMethod = k1.FillStyle.Texture.TilingMethod
            Next
        Else
            Exit Sub
        End If
        ZoomLAND(sgworldK, cPolygon)
    End Sub

    Private Sub DTvung3D()
        Try
            VungAr3D()
            If Lenhve2D = "tangcancau" Or Lenhve2D = "toQStrenXT" Or Lenhve2D = "toQStrenTG" Then
                ImageOnRegion()
            ElseIf Lenhve2D = "TsatBangChiendau" Or Lenhve2D = "toanTSDN" Or Lenhve2D = "xeTSPT76" Or Lenhve2D = "DCTCbangTauDS" Or Lenhve2D = "DCTCbangTauNgam" Or Lenhve2D = "muidaccongTC" Or Lenhve2D = "doidaccongTC" Or Lenhve2D = "todaccong" Or
                Lenhve2D = "tautuantieuTS" Or Lenhve2D = "muidaccong" Or Lenhve2D = "doidaccong" Or Lenhve2D = "tauhuanluyen" Or Lenhve2D = "tauquetloi" Or Lenhve2D = "xeTScanhgioi" Or Lenhve2D = "xeTSBMP" Or Lenhve2D = "doicongtacBP" Or
                Lenhve2D = "Canotrinhsat" Or Lenhve2D = "tauCuunan" Or Lenhve2D = "TLChongngamNBC" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "MatcuA2" Or Lenhve2D = "XeBAT" Or Lenhve2D = "doicongbinh" Or Lenhve2D = "tuyenRMbangTrT" Or
                Lenhve2D = "khongquandanhbien" Or Lenhve2D = "hamchong" Or Lenhve2D = "todaccongnuoc" Or Lenhve2D = "doiTShonhop" Or Lenhve2D = "DChoatrang" Or Lenhve2D = "doidaccongnuoc" Or Lenhve2D = "muidaccongnuoc" Or
                Lenhve2D = "muidaccongcodong" Or Lenhve2D = "tauBinan" Or Lenhve2D = "DCTCbangTauNN" Or Lenhve2D = "CongNongLamtruongCD" Or Lenhve2D = "Biendoitauhanhquan" Or
                Lenhve2D = "caulacboPD" Or Lenhve2D = "diemnong" Or Lenhve2D = "kvcophandong" Or Lenhve2D = "MatcuBLLD" Or Lenhve2D = "khuvucBLTieutay" Then
                CreateLabel3D()
            ElseIf Lenhve2D = "Phaoluutuhanh" Or Lenhve2D = "Phaonongdaituhanh" Or Lenhve2D = "Phaoluunongdaituhanh" Then
                Model3DTQ(sgworld3DBd, GroupBac23DBd)
                If A3D = True Then
                    Model3DTQ(sgworld3DA, GroupBac23DA)
                End If
                'ElseIf Lenhve2D = "Coi82" Or Lenhve2D = "Coi120" Or Lenhve2D = "Coi160" Or Lenhve2D = "tenluaB72" Or Lenhve2D = "tenluaPhagot" Or Lenhve2D = "Phaophanluccotrung" Or Lenhve2D = "PhaophanlucKyhieuchung" Or Lenhve2D = "Phaophanluccolon" Then
                '    suLineArray3D()
                '    sCreateLabel3D()
            ElseIf Lenhve2D = "XTchuyenPngu" Or Lenhve2D = "XTPngutrongTD" Or Lenhve2D = "muctieuphaibaove" Or Lenhve2D = "tocodongdiettang" Or Lenhve2D = "coilui" Or Lenhve2D = "DHPNBB" Or Lenhve2D = "DHPNBBXT" Or Lenhve2D = "KvPNthenchot" Or Lenhve2d = "baiminchongtangHTD" Or Lenhve2D = "ANQP" Or Lenhve2D = "kvTKHHxuly" Or Lenhve2D = "muctieuthenchot" Or Lenhve2D = "khudancumoi" Then
                LineArray3D()
            ElseIf Lenhve2D = "toTSDN" Or Lenhve2D = "toTSDQTV" Or Lenhve2D = "tramtaptrungQNDB" Or Lenhve2D = "todaccong" Or Lenhve2D = "dontho" Or Lenhve2D = "donthuy" Or Lenhve2D = "tramtaptrungPTKT" Or Lenhve2D = "tramtaptrungQNDBcm" Or Lenhve2D = "kvttllDongvien" Or
                   Lenhve2D = "tramtiepnhanPTKT" Or Lenhve2D = "tramtiepnhanQNDB" Or Lenhve2D = "tramGiao_nhan" Or Lenhve2D = "Coi82" Or Lenhve2D = "Coi120" Or Lenhve2D = "Coi160" Or Lenhve2D = "tenluaB72" Or Lenhve2D = "tenluaPhagot" Or Lenhve2D = "Phaophanluccotrung" Or Lenhve2D = "PhaophanlucKyhieuchung" Or Lenhve2D = "Phaophanluccolon" Then
                LineArray3D()
                CreateLabel3D()
            ElseIf Lenhve2D = "taukhutruc" Or Lenhve2D = "tauten2Ong" Or Lenhve2D = "tauten4Ong" Or Lenhve2D = "tautuanduonghangnhe" Or Lenhve2D = "tautuanduonghangnang" Or Lenhve2D = "tauhove" Or Lenhve2D = "tauphaonho" Or Lenhve2D = "tauphaolon" Or Lenhve2D = "tautenluanho" Or Lenhve2D = "tauChongngam" Then
                If frmMain.cbTenluahaiquan.SelectedIndex > 1 Then
                    ImageOnRegion()
                End If
            ElseIf Lenhve2D = "tenluacocanhtamgan" Or Lenhve2D = "tenluacocanhtamtrung" Or Lenhve2D = "tenluacocanhtamxa" Or Lenhve2D = "tenluacocanhtamxa2Ranh" Or Lenhve2D = "tenluacocanhtamgan2Ranh" Or Lenhve2D = "tenluacocanhtamtrung2Ranh" Then
                If frmMain.cbLoaiTrandia.SelectedIndex = 9 Then
                    LineArray3D()
                End If

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
        Else
            Exit Sub
        End If
    End Sub

    Private Sub DTchuyendong3D()

        If mMotionModelArray.Count > 0 Then
            For i As Integer = 0 To mMotionModelArray.Count - 1
                DtChuyendong3DTQ(sgworld3DBd, GroupBac23DBd, mMotionModelArray(i))
                If A3D = True Then
                    dtChuyendong3DTQ(sgworld3DA, GroupBac23DA, mMotionModelArray(i))
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

    Private Sub ImageOnRegion()
        Dim Kh As String = String.Empty
        Dim gdKH As String = String.Empty
        Dim Kc As Double = 0
        Dim Goc1 As Double = Phuongvi * 180 / Math.PI
        If Lenhve2D = "tautuanduonghangnhe" Or Lenhve2D = "tautuanduonghangnang" Or Lenhve2D = "tauhove" Or Lenhve2D = "tauphaonho" Or Lenhve2D = "tauphaolon" Or Lenhve2D = "tautenluanho" Or Lenhve2D = "tauChongngam" Then
            Select Case frmMain.cbTenluahaiquan.SelectedIndex
                Case 2
                    Kh = "2130047"
                    Kc = 195.1
                Case 3
                    Kh = "2130048"
                    Kc = 525.67
                Case 4
                    Kh = "2130050"
                    Kc = 195.1
                Case 5
                    Kh = "2130049"
                    Kc = 195.1
            End Select
        ElseIf Lenhve2D = "taukhutruc" Or Lenhve2D = "tauten2Ong" Or Lenhve2D = "tauten4Ong" Then
            Select Case frmMain.cbTenluahaiquan.SelectedIndex
                Case 2
                    Kh = "2130047"
                    Kc = 115.0
                Case 3
                    Kh = "2130048"
                    Kc = 499.0
                Case 4
                    Kh = "2130050"
                    Kc = 115.0
            End Select
        ElseIf Lenhve2D = "tn500" Or Lenhve2D = "tn1000" Or Lenhve2D = "tn5000" Or Lenhve2D = "tnNT1000" Or Lenhve2D = "tnNT5000" Or Lenhve2D = "tnNT6000" Or Lenhve2D = "tnKTV" Or Lenhve2D = "tnKTVkoRo" Or Lenhve2D = "TNchongTN" Then
            Kc = 0
            Kh = loaiKH
        ElseIf Lenhve2D = "tangcancau" Then
            Kh = "200013"
            Kc = 225
            If frmMain.cbTa_DP.SelectedIndex = 0 Then
                frmMain.fLabelStyleMain.PivotAlignment = "Bottom, Left"
            Else
                frmMain.fLabelStyleMain.PivotAlignment = "Bottom, Right"
            End If
        ElseIf Lenhve2D = "toQStrenXT" Or Lenhve2D = "toQStrenTG" Then
            Kh = "200014"
            Kc = 225
        End If
        If Lenhve2D = "tn500" Or Lenhve2D = "tn1000" Or Lenhve2D = "tn5000" Or Lenhve2D = "tnNT1000" Or Lenhve2D = "tnNT5000" Or Lenhve2D = "tnNT6000" Or Lenhve2D = "tnKTV" Or Lenhve2D = "tnKTVkoRo" Or Lenhve2D = "TNchongTN" Then
            Select Case frmMain.cbGiaidoan.SelectedIndex
                Case 0
                    gdKH = "1"
                Case 1
                    gdKH = "2"
                Case 2
                    gdKH = "3"
                Case 3
                    gdKH = "4"
                Case 4
                    gdKH = "5"
                Case 5
                    gdKH = "6"
                Case 6
                    gdKH = "7"
            End Select
        Else
            gdKH = ""
        End If
        fileImage = PathData & "\2X\" & ChieuKH & Kh & Ta_Doiphuong & gdKH & ".mkx"
        Dim P1 As IPosition71 = frmMain.mPointClick.Move(Kc * 3.0 * Tyle, 90 - Goc1, 0)
        frmMain.fLabelStyleMain.LockMode = LabelLockMode.LM_DECAL
        Image3DTQ(sgworld3DBd, P1, fileImage, GroupBac23DBd)
        If A3D = True Then
            Image3DTQ(sgworld3DA, P1, fileImage, GroupBac23DA)
        End If
    End Sub

    Private Sub Image3DTQ(sgworldK As SGWorld71, P As IPosition71, fileImage As String, mGroup As String)
        Dim P1 As IPosition71 = sgworldK.Creator.CreatePosition(P.X, P.Y, P.Altitude, AltitudeTypeCode.ATC_TERRAIN_RELATIVE, 0, 0, 0, 0)
        Dim ImageOnRegion As ITerrainLabel71 = sgworldK.Creator.CreateLabel(P, "", fileImage, frmMain.fLabelStyleMain, mGroup, tenKH)
        ImageOnRegion.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
        ImageOnRegion.Tooltip.Text = ""
        ZoomLAND(sgworldK, ImageOnRegion)
    End Sub

    Public Sub TenluaDKHaiquan3D()
        Dim k1 As ITerraExplorerObject61 = FrmMain.sgworldMain.Creator.GetObject(coCell1.ID)
        If k1.ObjectType = ObjectTypeCode.OT_LABEL Then
            Dim k2 As ITerrainLabel71 = k1
            Dim mPoint3D As IPosition71 = k2.Position
            mPoint3D.AltitudeType = AltitudeTypeCode.ATC_ON_TERRAIN
            FrmMain.fLabelStyleMain.Scale = k2.Style.Scale
            k2.Position.Altitude = Tyle * 80
            If Bd3D = True Then
                Dim Tenlua = sgworld3DBd.Creator.CreateLabel(k2.Position, "", k2.ImageFileName, FrmMain.fLabelStyleMain, GroupBac23DBd, tenKH)
                Tenlua.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
                Tenlua.Tooltip.Text = mota
            End If
            If A3D = True Then
                Dim Tenlua = sgworld3DA.Creator.CreateLabel(k2.Position, "", k2.ImageFileName, FrmMain.fLabelStyleMain, GroupBac23DA, tenKH)
                Tenlua.Position.AltitudeType = AltitudeTypeCode.ATC_TERRAIN_RELATIVE
                Tenlua.Tooltip.Text = mota
            End If
        End If
    End Sub


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
    '    '  frmMain.panelSuaDT1.Visible = False
    'End Sub

#End Region


End Module
