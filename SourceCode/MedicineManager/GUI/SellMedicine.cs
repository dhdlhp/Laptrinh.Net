using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MedicineManager.ENTITY;
using MedicineManager.BUS;
using System.Collections;
using MedicineManager.Reports;
//using MedicineManager.Reports;


namespace MedicineManager.GUI
{
    public partial class SellMedicine : Form
    {
        private User currentUser;
        private static int _IDUser;

        public static int IDUser
        {
            get { return SellMedicine._IDUser; }
            set { SellMedicine._IDUser = value; }
        }

        private BusUser busUser;
        private BusThuoc busThuoc;
        private BusBenhNhan busBenhNhan;
        private BusHDX busHDX;
        private int flagSuaXoaNhanBan = 0;
        public SellMedicine(User currentUser)
        {
            InitializeComponent();
            busUser = new BusUser();
            busThuoc = new BusThuoc();
            busBenhNhan = new BusBenhNhan();
            busHDX = new BusHDX();

            this.currentUser = currentUser;
            IDUser = currentUser.IDUser;

            this.ApplLoad();
        }

        public void ApplLoad()
        {
            SystemLog systemLog = busUser.GetLastLoginUser(currentUser.IDUser);

            if (systemLog != null)
            {
                lblCurrentUserLastLogin.Text = DateTimeConvert.FormatVN(systemLog.DateLogin);

                lblCurrentUserName.Text = currentUser.Username;
            }

            tmrTime.Start();

            lVChiTietHDX.DoubleClickActivation = true;

            tabControl1.TabPages.Clear();

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(lVChiTietHDX, "Nhấn chuột phải để xóa thuốc khỏi danh sách hoặc đổi số lượng!");
            toolTip.SetToolTip(lVSanhSachHDX, "Nhấn chuột phải để thao tác với hóa đơn!");
            toolTip.SetToolTip(lVDanhSachBenhNhan, "Nhấn đúp chuột để chọn bệnh nhân!");
            toolTip.SetToolTip(lVQuickSearchThuoc, "Nhấn đúp chuột để chọn thuốc!");
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.ApplLoad();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblToday.Text = DateTimeConvert.FormatVN(DateTime.Now,"dd/MM/yyyy - h:m:s tt");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogout();
            this.Dispose();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogout();
            Login login = new Login();
            login.Visible = true;
            this.Visible = false;
        }

        public void UserLogout()
        {
            SystemLog systemLog = new SystemLog(currentUser.IDUser, DateTime.Now.ToString(), "Logout");
            busUser.SetSystemLog(systemLog);
        }

        private void btnTaoDonMoi_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.KiemTraThuoc();
        }
        
        
        public ArrayList arrLlVChiTietHDX = new ArrayList();

        public bool CheckTenThuoc_SoLuong()
        {
            
            if (txtMaThuoc.Text.Equals(""))
            {
                MessageBox.Show(this, "Chưa nhập mã thuốc hoặc không hợp lệ!", "Thông báo");
                txtMaThuoc.Focus();
                return false;
            }
            else if (!ValidateFrom.CheckNumber(txtNTBSoLuongMua.Text))
            {
                MessageBox.Show(this, "Nhập số lượng mua!", "Thông báo");
                txtNTBSoLuongMua.Focus();
                return false;
            }
            else if (Convert.ToInt32(txtNTBSoLuongMua.Text)==0)
            {
                MessageBox.Show(this, "Số lượng mua phải khác 0!", "Thông báo");
                txtNTBSoLuongMua.Focus();
                return false;
            }
            else
            {
                return true;
            }
                
        }
        
        
        public void KiemTraThuoc()
        {
            if (CheckTenThuoc_SoLuong())
            {

                ArrayList arrList = busThuoc.GetAllThuoc(txtMaThuoc.Text);
                if (arrList != null)
                {
                    if (arrList.Count == 1)
                    {
                        Thuoc thuoc = (Thuoc)arrList.ToArray()[0];
                        bool KiemTraThuoc = true;
                        foreach (Thuoc thuocTemp in arrLlVChiTietHDX)
                        {
                            if (thuocTemp.IDThuoc == thuoc.IDThuoc)
                            {
                                KiemTraThuoc = false;
                                MessageBox.Show(this, "Thuốc này đã có trong danh sách.\nHãy đổi số lượng mua nếu muốn mua thêm.", "Thông báo");
                                txtMaThuoc.Focus();
                            }
                        }

                        if (KiemTraThuoc)
                        {

                            if (Convert.ToInt32(txtNTBSoLuongMua.Text) <= thuoc.SoLuong)
                            {
                                thuoc.SoLuong = Convert.ToInt32(txtNTBSoLuongMua.Text);

                                arrLlVChiTietHDX.Add(thuoc);
                                this.ThemThuocVaoDS();
                                this.TinhTienHDX();
                            }
                            else
                            {
                                if (thuoc.SoLuong == 0)
                                {
                                    MessageBox.Show(this, "Thuốc này đã hết!", "Thông báo");
                                    txtMaThuoc.Focus();
                                }
                                else
                                {
                                    MessageBox.Show(this, "Trong kho còn: [ " + thuoc.SoLuong + " " + thuoc.TenDVT + "] \nSố lượng mua vượt quá số thuốc trong kho...", "Thông báo");
                                    txtNTBSoLuongMua.Focus();
                                }
                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("Không có!", "Thông báo");
                }
                
                
            }
        }
        private double _TienThue = 0;
        private double _TienThuoc = 0;
        private double _TongTienHD = 0;
        public void TinhTienHDX()
        {
            
            _TienThue = 0;
            _TienThuoc = 0;
            _TongTienHD = 0;
            foreach (Thuoc thuoc in arrLlVChiTietHDX)
            {
                _TienThue += thuoc.SoLuong * (Convert.ToDouble(thuoc.GiaBan) * thuoc.Thue) / 100;
                _TienThuoc += Convert.ToDouble(thuoc.GiaBan)*thuoc.SoLuong;
            }
            _TongTienHD = _TienThue + _TienThuoc;
            lblTienThue.Text = String.Format("{0:0,0}", _TienThue)+ " VND";
            lblTienThuoc.Text = String.Format("{0:0,0}", _TienThuoc) + " VND";
            lblTongTien.Text = String.Format("{0:0,0}", _TongTienHD) + " VND";
        }

        private void ThemThuocVaoDS()
        {
            lVChiTietHDX.Items.Clear();
            foreach (Thuoc thuoc in arrLlVChiTietHDX)
            {
                
                ListViewItem lVItem = new ListViewItem(thuoc.MaThuoc);
                lVItem.SubItems.Add(thuoc.TenThuoc);
                lVItem.SubItems.Add(thuoc.SoLuong.ToString()+" "+thuoc.TenDVT);
                lVItem.SubItems.Add(String.Format("{0:0,0}",thuoc.GiaBan) + " VND");
                lVItem.SubItems.Add(thuoc.Thue.ToString()+" %("+((Convert.ToDouble(thuoc.GiaBan) * thuoc.Thue) / 100)+" VND)");
                double thanhTien = (Convert.ToDouble(thuoc.GiaBan) + ((Convert.ToDouble(thuoc.GiaBan) * thuoc.Thue) / 100)) * thuoc.SoLuong;
                lVItem.SubItems.Add(String.Format("{0:0,0}",thanhTien) + " VND");
                lVChiTietHDX.Items.Add(lVItem);
            }
        }

        
        private void sdfsfgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.XoaThuocTrongDS();
        }

        public void XoaThuocTrongDS()
        {
            if (lVChiTietHDX.SelectedItems.Count > 0)
            {
                arrLlVChiTietHDX.RemoveAt(lVChiTietHDX.FocusedItem.Index);
                this.ThemThuocVaoDS();
                this.TinhTienHDX();
            }
            else
            {
                MessageBox.Show(this, "Chọn một loại thuốc!", "Thông báo");
            }
        }


        public void LayMaThuocTuKQRK(Thuoc thuoc)
        {

            int SoLuong = Convert.ToInt32(txtNTBSoLuongMua.Text);
            if (SoLuong <= thuoc.SoLuong)
            {
                bool KiemTraThuoc = true;
                foreach (Thuoc thuocTemp in arrLlVChiTietHDX)
                {
                    if (thuocTemp.IDThuoc == thuoc.IDThuoc)
                    {
                        KiemTraThuoc = false;
                        MessageBox.Show(this, "Thuốc này đã có trong danh sách.\nHãy đổi số lượng mua nếu muốn mua thêm.", "Thông báo");
                        txtMaThuoc.Focus();
                    }
                }
                if (KiemTraThuoc)
                {
                    thuoc.SoLuong = SoLuong;
                    arrLlVChiTietHDX.Add(thuoc);
                    this.ThemThuocVaoDS();
                    this.TinhTienHDX();
                }
            }
            else
            {
                if (thuoc.SoLuong == 0)
                {
                    MessageBox.Show(this, "Thuốc này đã hết!", "Thông báo");
                    txtMaThuoc.Focus();
                }
                else
                {
                    MessageBox.Show(this, "Trong kho còn: [ " + thuoc.SoLuong + " " + thuoc.TenDVT + "] \nSố lượng mua vượt quá số thuốc trong kho...", "Thông báo");
                    txtNTBSoLuongMua.Focus();
                }
            }
            
        }

        private void fsdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flagSuaXoaNhanBan = 1;
            SuaSoLuongThuoc();
        }

        public void SuaSoLuongMua()
        {

                int index = lVChiTietHDX.FocusedItem.Index;    
                Thuoc thuoc = (Thuoc)arrLlVChiTietHDX.ToArray()[index];    
                    thuoc.SoLuong = Convert.ToInt32(txtNTBEditCellForListView.Text);
                    arrLlVChiTietHDX.RemoveAt(index);
                    arrLlVChiTietHDX.Insert(index, thuoc);
                    this.ThemThuocVaoDS();
                    this.TinhTienHDX();
 
        }

        public void FillBenhNhanDetails(BenhNhan benhNhan)
        {
            txtMaBN.Text = benhNhan.MaBN;
            lblMaBN_DT.Text = benhNhan.MaBN;
            lblTenBN_DT.Text = benhNhan.HoTen;
            lblTuoiBN_DT.Text = benhNhan.Tuoi.ToString();
            lblDiaChiBN_DT.Text = benhNhan.DiaChi;
            lblSoDienThoaiBN_DT.Text = benhNhan.DienThoai;
        }

        private BenhNhan benhNhanHDX;
        private void btnLuuHD_Click(object sender, EventArgs e)
        {
            if (arrLlVChiTietHDX.Count == 0)
            {
                MessageBox.Show(this, "Chưa có thuốc trong hóa đơn", "Thông báo");
                txtMaThuoc.Focus();
                return;
            }
            else if (benhNhanHDX == null)
            {
                MessageBox.Show(this, "Chưa có thông tin bệnh nhân", "Thông báo");
                txtMaBN.Focus();
                return;
            }
            else
            {
                HoaDonXuat hdx = new HoaDonXuat(benhNhanHDX.IDBN, DateTime.Now, Convert.ToDecimal(this._TienThuoc), Convert.ToDouble(this._TienThue), Convert.ToDecimal(this._TongTienHD));
                SuLyInDonThuoc suLyDT = new SuLyInDonThuoc(hdx, arrLlVChiTietHDX);
                suLyDT.dgDT = new SuLyInDonThuoc.dgDonThuoc(TaoDonThuocOK);
                suLyDT.ShowDialog();
            }
        }


        public void TaoDonThuocOK(bool flag)
        {
            if (flag)
            {
                this.ClearHoaDon();
            }
        }


        private void btnView_DSHDX_Click(object sender, EventArgs e)
        {
            this.lVDanhSachHDX();
        }

        ArrayList arrLAllHDX = new ArrayList();
        public void lVDanhSachHDX()
        {
            dTPFrom_DSHDX = new DateTimePicker();


            if (txtNTBMaHSX.Text.Equals(""))
            {
                arrLAllHDX = busHDX.GetAllHDX(txtMaBN_DSHDX.Text, dTPTo_DSHDX.Value.Date.ToString(), dTPFrom_DSHDX.Value.ToString());
            }
            else
            {
                arrLAllHDX = busHDX.GetHDXByMaHDX(Convert.ToInt32(txtNTBMaHSX.Text));
            }
            if (arrLAllHDX != null)
            {
                lVSanhSachHDX.Items.Clear();
                foreach (HoaDonXuat hdx in arrLAllHDX)
                {
                    ListViewItem lVItem = new ListViewItem(hdx.MaHDX.ToString());
                    lVItem.SubItems.Add(hdx.MaBN);
                    lVItem.SubItems.Add(DateTimeConvert.FormatVN(hdx.NgayLap, "dd/MM/yyyy - h:m:s tt"));
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(hdx.TongTienHD))+" VND");
                    lVSanhSachHDX.Items.Add(lVItem);
                }
            }
        }


        private void btnGetDonThuoc_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPDanhSachHDX);
            tPDanhSachHDX.Text = "Danh sách hóa đơn";
            this.lVDanhSachHDX();

        }

        private void lVSanhSachHDX_DoubleClick(object sender, EventArgs e)
        {
            XemChiTietDonThuoc();
        }
        private void xemchitietToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemChiTietDonThuoc();
        }

        public void XemChiTietDonThuoc()
        {
            if (lVSanhSachHDX.SelectedItems.Count > 0)
            {
                HoaDonXuat hdx = (HoaDonXuat)arrLAllHDX.ToArray()[lVSanhSachHDX.FocusedItem.Index];
                RPTDonThuoc rptDT = new RPTDonThuoc(hdx.MaHDX);
                rptDT.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }
        }


        private void xoaHoaDonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XoaDonThuoc();
        }

        public void XoaDonThuoc()
        {
            if (lVSanhSachHDX.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this,"Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    HoaDonXuat hdx = (HoaDonXuat)arrLAllHDX.ToArray()[lVSanhSachHDX.FocusedItem.Index];
                    busHDX.DelHoaDonXuat(hdx.MaHDX);
                    SystemLog systemLog = new SystemLog(SellMedicine.IDUser, DateTime.Now.ToString(), "Xóa đơn thuốc");
                    busUser.SetSystemLog(systemLog);
                    MessageBox.Show(this, "Xóa thành công!","Thông báo");
                    this.lVDanhSachHDX();
                }
            }
            else 
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }
        }


        private void taothemhoadonnayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            NhanBanDonThuoc();
        }

        public void NhanBanDonThuoc()
        {
                if (lVSanhSachHDX.SelectedItems.Count > 0)
                {
                    HoaDonXuat hdxOLD = (HoaDonXuat)arrLAllHDX.ToArray()[lVSanhSachHDX.FocusedItem.Index];
                    if (MessageBox.Show("Bạn có muốn tạo thêm một hóa đơn như này không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        tabControl1.TabPages.Clear();
                        tabControl1.TabPages.Add(tPTaoDon);
                        tPTaoDon.Text = "Tạo Đơn Thuốc Mới";

                        lblbtnCopy.Visible = false;
                        lblbtnXemChiTiet.Visible = false;
                        lblbtnXoa.Visible = true;
                        lblbtnSua.Visible = true;

                        benhNhanHDX = busBenhNhan.GetBenhNhanDetails(hdxOLD.IDBN);
                        txtMaBN.Text = benhNhanHDX.MaBN;
                        lblMaBN_DT.Text = benhNhanHDX.MaBN;
                        lblTenBN_DT.Text = benhNhanHDX.HoTen;
                        lblTuoiBN_DT.Text = benhNhanHDX.Tuoi.ToString();
                        lblDiaChiBN_DT.Text = benhNhanHDX.DiaChi;
                        lblSoDienThoaiBN_DT.Text = benhNhanHDX.DienThoai;

                        arrLlVChiTietHDX.Clear();
                        ArrayList arrlTemp = busHDX.GetAllChiTietHDX(hdxOLD.MaHDX);

                        foreach (ChiTietHoaDonXuat chiTietHDX in arrlTemp)
                        {
                            Thuoc thuoc = new Thuoc(chiTietHDX.IDThuoc,chiTietHDX.MaThuoc, chiTietHDX.TenThuoc, chiTietHDX.SoLuong, chiTietHDX.GiaBan, chiTietHDX.DonVi, chiTietHDX.Thue);
                            arrLlVChiTietHDX.Add(thuoc);
                        }

                        this.ThemThuocVaoDS();
                        this.TinhTienHDX();

                    }
                }
                else
                {
                    MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
                }
            
        }

        private void btnTaoDon_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPTaoDon);
            tPTaoDon.Text = "Tạo Đơn Thuốc Mới";
        }

        private void tạoĐơnThuốcMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPTaoDon);
            tPTaoDon.Text = "Tạo Đơn Thuốc Mới";
        }

        private void danhSáchĐơnThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPDanhSachHDX);
            tPDanhSachHDX.Text = "Danh sách hóa đơn";
            this.lVDanhSachHDX();

        }

        private void btnTaoLaiDon_Click(object sender, EventArgs e)
        {

            this.ClearHoaDon();
        }

        public void ClearHoaDon()
        {
            arrLlVChiTietHDX.Clear();
            this.ThemThuocVaoDS();
            txtMaThuoc.Text = "";
            txtNTBSoLuongMua.Text = "";
            txtMaBN.Text = "";

            lblTienThue.Text = "---";
            lblTienThuoc.Text = "---";
            lblTongTien.Text = "---";

            benhNhanHDX = null;
            lblMaBN_DT.Text = "---";
            lblTenBN_DT.Text = "---";
            lblTuoiBN_DT.Text = "---";
            lblDiaChiBN_DT.Text = "---";
            lblSoDienThoaiBN_DT.Text = "---";
        }

    

        private void dangnhaplaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogout();
            Login login = new Login();
            login.Visible = true;
            this.Visible = false;
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogout();
            Application.Exit();
        }

        private void taoDonThuocMoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPTaoDon);
            tPTaoDon.Text = "Tạo Đơn Thuốc Mới";
        }

        private void danhSachDonThuocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPDanhSachHDX);
            tPDanhSachHDX.Text = "Danh sách hóa đơn";
            this.lVDanhSachHDX();
        }

        private void MedicineManager_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPTaoDon);
            tPTaoDon.Text = "Tạo Đơn Thuốc Mới";

            flagSuaXoaNhanBan = 1;

            lblbtnCopy.Visible = false;
            lblbtnXemChiTiet.Visible = false;
            lblbtnXoa.Visible = true;
            lblbtnSua.Visible = true;

        }


    

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPTaoDon);
            tPTaoDon.Text = "Tạo Đơn Thuốc Mới";

            flagSuaXoaNhanBan = 1;


            lblbtnCopy.Visible = false;
            lblbtnXemChiTiet.Visible = false;
            lblbtnXoa.Visible = true;
            lblbtnSua.Visible = true;
        }

 

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoái khỏi trường trình?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UserLogout();
                Application.Exit();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            UserLogout();
            Login login = new Login();
            login.Visible = true;
            this.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            pLDSKQTimKiemThuoc.Visible = false;

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(tPDanhSachHDX);
            tPDanhSachHDX.Text = "Danh sách hóa đơn";
            this.lVDanhSachHDX();
            
            flagSuaXoaNhanBan = 2;

  

            lblbtnCopy.Visible = true;
            lblbtnXemChiTiet.Visible = true;
            lblbtnXoa.Visible = true;
            lblbtnSua.Visible = false;

        }




        public void SuaSoLuongThuoc()
        {
            if (flagSuaXoaNhanBan == 1 && lVChiTietHDX.SelectedItems.Count != 0)
            {
                lVChiTietHDX.StartEditing(txtNTBEditCellForListView, lVChiTietHDX.FocusedItem, 2);
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn thuốc!2", "Thông báo");
            } 
        }

        private void lblbtnSua_Click(object sender, EventArgs e)
        {
            flagSuaXoaNhanBan = 1;
            SuaSoLuongThuoc();
        }

        private void lblbtnXoa_Click(object sender, EventArgs e)
        {
            if (flagSuaXoaNhanBan == 1)
            {
                this.XoaThuocTrongDS();
            }
            else if (flagSuaXoaNhanBan == 2)
            {
                
                this.XoaDonThuoc();
            }
        }

        private void lblbtnXemChiTiet_Click(object sender, EventArgs e)
        {
            this.XemChiTietDonThuoc();
        }

        private void lblbtnCopy_Click(object sender, EventArgs e)
        {
            this.NhanBanDonThuoc();
        }


        private void lVChiTietHDX_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            flagSuaXoaNhanBan = 1;
            SuaSoLuongThuoc();
            
        }

        private void txtNTBEditCellForListView_Leave(object sender, EventArgs e)
        {
            if (arrLlVChiTietHDX.Count > 0)
            {
                int index = lVChiTietHDX.FocusedItem.Index;
                Thuoc thuoc = (Thuoc)arrLlVChiTietHDX.ToArray()[index];
                if (txtNTBEditCellForListView.Text.Equals("") || Convert.ToInt32(txtNTBEditCellForListView.Text) == 0)
                {
                    txtNTBEditCellForListView.Text = thuoc.SoLuong.ToString();
                }
                string strSoLuong = txtNTBEditCellForListView.Text;
                int SoLuong = Convert.ToInt32(strSoLuong);
                Thuoc thuocTemp = busThuoc.GetThuocDetails(thuoc.IDThuoc);
                if (SoLuong > thuocTemp.SoLuong)
                {
                    MessageBox.Show(this, "Trong kho còn: [ " + thuocTemp.SoLuong + " " + thuocTemp.TenDVT + "] \nSố lượng mua vượt quá số thuốc trong kho...", "Thông báo");
                    txtNTBEditCellForListView.Text = "" + thuocTemp.SoLuong + "";
                    this.SuaSoLuongMua();
                }
                else
                {
                    this.SuaSoLuongMua();
                }
            }
            
        }

        private void txtNTBEditCellForListView_Enter(object sender, EventArgs e)
        {
            txtNTBEditCellForListView.Text = "";
        }

        private void txtMaThuoc_KeyUp(object sender, KeyEventArgs e)
        {
            ShowDSKQTKThuoc();
        }

        public void ShowDSKQTKThuoc()
        {
            pLDSKQTimKiemThuoc.Visible = true;
            lVQuickSearchThuoc.Items.Clear();
            ArrayList arrLThuoc = busThuoc.GetAllThuoc(txtMaThuoc.Text);
            if (arrLThuoc != null)
            {
                ListViewItem lVItem;
                foreach (Thuoc thuoc in arrLThuoc)
                {
                    lVItem = new ListViewItem(thuoc.MaThuoc);
                    lVItem.SubItems.Add(thuoc.TenThuoc);
                    lVItem.SubItems.Add(thuoc.TenNhom);
                    lVItem.SubItems.Add(thuoc.SoLuong.ToString());
                    lVItem.SubItems.Add(thuoc.NguonGoc);
                    lVItem.SubItems.Add(thuoc.TenDVT);
                    lVQuickSearchThuoc.Items.Add(lVItem);
                }
            }
        }

        ArrayList arrLDSBenhNhan = new ArrayList();

        public void GetNewBenhNhan(BenhNhan benhNhan,int index)
        {
            arrLDSBenhNhan.Insert(index,benhNhan);
            RefreshListBenhNhan();
        }

        public void SuaBenhNhan(BenhNhan benhNhan,int index)
        {
            arrLDSBenhNhan.RemoveAt(index);
            arrLDSBenhNhan.Insert(index, benhNhan);
            RefreshListBenhNhan();
        }

        public void RefreshListBenhNhan()
        {
                lVDanhSachBenhNhan.Items.Clear();
                ListViewItem lVItem;
                foreach (BenhNhan benhNhanTemp in arrLDSBenhNhan)
                {
                    lVItem = new ListViewItem(benhNhanTemp.MaBN);
                    lVItem.SubItems.Add(benhNhanTemp.HoTen);
                    lVItem.SubItems.Add(benhNhanTemp.Tuoi.ToString());
                    lVItem.SubItems.Add(benhNhanTemp.DiaChi);
                    lVItem.SubItems.Add(benhNhanTemp.DienThoai);
                    lVDanhSachBenhNhan.Items.Add(lVItem);
                }
        }

        public void ShowKQTKBenhNhan()
        {
            plDSKQTimKiemBN.Visible = true;
            arrLDSBenhNhan = busBenhNhan.GetBenhNhanByMaBN(txtMaBN.Text);
            lVDanhSachBenhNhan.Items.Clear();
            ListViewItem lVItem;
            foreach (BenhNhan benhNhan in arrLDSBenhNhan)
            {
                lVItem = new ListViewItem(benhNhan.HoTen);
                lVItem.SubItems.Add(benhNhan.Tuoi.ToString());
                lVItem.SubItems.Add(benhNhan.DienThoai);
                lVItem.SubItems.Add(benhNhan.DiaChi);
                lVDanhSachBenhNhan.Items.Add(lVItem);
            }
        }

        private void txtMaBN_KeyUp(object sender, KeyEventArgs e)
        {
            ShowKQTKBenhNhan();
        }

        private void lVQuickSearchThuoc_DoubleClick(object sender, EventArgs e)
        {
            txtMaThuoc.Text = lVQuickSearchThuoc.Items[lVQuickSearchThuoc.FocusedItem.Index].SubItems[0].Text;
            lblTenDVT.Text = lVQuickSearchThuoc.Items[lVQuickSearchThuoc.FocusedItem.Index].SubItems[5].Text;
            pLDSKQTimKiemThuoc.Visible = false;
            txtNTBSoLuongMua.Focus();
        }

        private void lVDanhSachBenhNhan_DoubleClick(object sender, EventArgs e)
        {
            benhNhanHDX = (BenhNhan)arrLDSBenhNhan.ToArray()[lVDanhSachBenhNhan.FocusedItem.Index];
            FillBenhNhanDetails(benhNhanHDX);
            plDSKQTimKiemBN.Visible = false;
            this.btnLuuHD.Focus();
        }

        private void txtMaBN_DoubleClick(object sender, EventArgs e)
        {
            if (plDSKQTimKiemBN.Visible == false)
                ShowKQTKBenhNhan();
            else plDSKQTimKiemBN.Visible = false;
        }

        private void txtMaThuoc_DoubleClick(object sender, EventArgs e)
        {
            if (pLDSKQTimKiemThuoc.Visible == false)
                ShowDSKQTKThuoc();
            else pLDSKQTimKiemThuoc.Visible = false;
        }

        private void txtNTBSoLuongMua_Enter(object sender, EventArgs e)
        {
            pLDSKQTimKiemThuoc.Visible = false;
 

        }

        private void panel3_MouseHover(object sender, EventArgs e)
        {
            plDSKQTimKiemBN.Visible = false;
            pLDSKQTimKiemThuoc.Visible = false;
        }

        private void tabControl1_MouseHover(object sender, EventArgs e)
        {
            plDSKQTimKiemBN.Visible = false;
            pLDSKQTimKiemThuoc.Visible = false;
        }

        private void lVChiTietHDX_MouseHover(object sender, EventArgs e)
        {
            plDSKQTimKiemBN.Visible = false;
            pLDSKQTimKiemThuoc.Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Them_Sua_BenhNhan tsBN = new Them_Sua_BenhNhan(null,0,1);
            tsBN.dgBN = new Them_Sua_BenhNhan.dgBenhNhan(GetNewBenhNhan);
            tsBN.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (lVDanhSachBenhNhan.SelectedItems.Count > 0)
            {
                int index = lVDanhSachBenhNhan.FocusedItem.Index;
                BenhNhan benhNhan = (BenhNhan)arrLDSBenhNhan.ToArray()[index];
                Them_Sua_BenhNhan tsBN = new Them_Sua_BenhNhan(benhNhan, index, 2);
                tsBN.dgBN = new Them_Sua_BenhNhan.dgBenhNhan(SuaBenhNhan);
                tsBN.ShowDialog();
            }
            else
            {
                MessageBox.Show(this,"Chọn một bệnh nhân","Thông báo");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (lVDanhSachBenhNhan.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa bệnh nhân không?\n Nếu xóa tất cả các đơn thuốc của bệnh nhân này cũng sẽ bị xóa!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int index = lVDanhSachBenhNhan.FocusedItem.Index;
                    BenhNhan benhNhan = (BenhNhan)arrLDSBenhNhan.ToArray()[index];
                    int i = busBenhNhan.DeleteBenhNhan(benhNhan.IDBN);
                    if (i > 0)
                    {
                        SystemLog systemLog = new SystemLog(SellMedicine.IDUser, DateTime.Now.ToString(), "Thêm bệnh nhân");
                        busUser.SetSystemLog(systemLog);
                        MessageBox.Show(this, "Xóa thành công!", "Thông báo");
                        arrLDSBenhNhan.RemoveAt(index);
                        RefreshListBenhNhan();
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Chọn một bệnh nhân", "Thông báo");
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            plDSKQTimKiemBN.Visible = false;
        }

        private void txtMTBMaHSX_Enter(object sender, EventArgs e)
        {
            txtMaBN_DSHDX.Text = "";
        }

        private void txtMaBN_DSHDX_Enter(object sender, EventArgs e)
        {
            txtNTBMaHSX.Text = "";
        }

        private void dTPFrom_DSHDX_Enter(object sender, EventArgs e)
        {
            txtNTBMaHSX.Text = "";
        }

        private void dTPTo_DSHDX_Enter(object sender, EventArgs e)
        {
            txtNTBMaHSX.Text = "";
        }

    }
}