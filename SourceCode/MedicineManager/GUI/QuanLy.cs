using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MedicineManager.ENTITY;
using System.Collections;
using MedicineManager.BUS;

namespace MedicineManager.GUI
{
    public partial class QuanLy : Form
    {

        public static int _IDUser;

        public static int IDUser
        {
            get { return QuanLy._IDUser; }
            set { QuanLy._IDUser = value; }
        }

        private User currentUser;
        private BusUser busUser;
        private BusSystem busSys;
        private BusHDX busHDX;
        private BusNhomThuoc busNT;
        private BusThuoc busThuoc;
        private BusNSX busNSX;
        private BusDVT busDVT;
        private BusNPP busNNP;
        private BusHDN busHDN;
        ArrayList arrUser = new ArrayList();
        ArrayList arrSys = new ArrayList();
        ArrayList arrNSX = new ArrayList();
        ArrayList arrCTHDN;

        private Control[] Editors;
        public QuanLy(User currentUser)
        {
            InitializeComponent();
            busUser = new BusUser();
            busSys = new BusSystem();
            busHDX = new BusHDX();
            busNT = new BusNhomThuoc();
            busThuoc = new BusThuoc();
            busNSX = new BusNSX();
            busDVT = new BusDVT();
            busNNP = new BusNPP();
            busHDN = new BusHDN();
            arrCTHDN = new ArrayList();
            this.currentUser = currentUser;
            IDUser = currentUser.IDUser;
        }

        private void Menu_DangXuat_Click(object sender, EventArgs e)
        {
            UserLogout();
            Login login = new Login();
            login.Show();
            this.Visible = false;
        }

        public void UserLogout()
        {
            SystemLog systemLog = new SystemLog(currentUser.IDUser, DateTime.Now.ToString(), "Logout");
            busUser.SetSystemLog(systemLog);
        }

        private void Menu_Thoat_Click(object sender, EventArgs e)
        {
            UserLogout();
            Application.Exit();
        }

        private void btn_HeThong_Click(object sender, EventArgs e)
        {
            setPanelControl();
            pnl_HeThong.Visible = true;
            pnl_HeThong.Height = 425;
            toolStrip3.Height = 395;

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NguoiDung);
            page_NguoiDung.Text = "Quản lý Users";
            DanhSachUser();
        }

        private void btn_DanhMuc_Click(object sender, EventArgs e)
        {
            setPanelControl();
            pnl_DanhMuc.Visible = true;
            pnl_DanhMuc.Height = 425;
            toolStrip2.Height = 395;

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NhomThuoc);
            page_NhomThuoc.Text = "Quản Lý Nhóm Thuốc";
            DanhSachNhomThuoc();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            setPanelControl();
            pnl_HeThong.Visible = true;
            pnl_HeThong.Height = 425;
            toolStrip3.Height = 395;
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NguoiDung);
            page_NguoiDung.Text = "Quản lý Users";
            DanhSachUser();
            SystemLog systemLog = busUser.GetLastLoginUser(currentUser.IDUser);            
            if (systemLog != null)
            {
                lblCurrentUserLastLogin.Text = DateTimeConvert.FormatVN(systemLog.DateLogin);
                lblCurrentUserName.Text = currentUser.Username;
            }
            
            tmrTime.Start();
        }

        private void btn_HoaDon_Click(object sender, EventArgs e)
        {
            setPanelControl();
            pnl_HoaDon.Visible = true;
            pnl_HoaDon.Height = 425;
            toolStrip4.Height = 395;

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_TaoHDN);
            tabControl1.TabPages.Add(page_HoaDonNhap);
            page_TaoHDN.Text = "Tạo Hóa Đơn Nhập";
            page_HoaDonNhap.Text = "Danh Sách Hóa Đơn Nhập";
            arrThuoc = busThuoc.GetAllThuoc2("");
            dtp_NgayNhap.Value = DateTime.Now;
            dtp_ToHDN.Value = DateTime.Now;
            AddCBB_NhaPhanPhoi();
            DanhSachHDN();  
        }

        public void setPanelControl() {
            pnl_HeThong.Visible = false;
            pnl_DanhMuc.Visible = false;
            pnl_HoaDon.Visible = false;
            pnl_DoiTac.Visible = false;
        }

        private void btn_DoiTac_Click(object sender, EventArgs e)
        {
            setPanelControl();
            pnl_DoiTac.Visible = true;
            pnl_DoiTac.Height = 425;
            toolStrip5.Height = 395;

            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NXS);
            page_NXS.Text = "Quản Lý Nhà Sản Xuất";
            DanhSachNSX();
        }

        private void btn_NguoiDung_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NguoiDung);
            page_NguoiDung.Text = "Quản lý Users";
            DanhSachUser();
        }

        public void DanhSachUser() {
            arrUser = busUser.GetAllUser();
            if (arrUser != null)
            {
                lv_DanhSachUser.Items.Clear();
                foreach (User user in arrUser)
                {
                    ListViewItem lVItem = new ListViewItem(user.IDUser.ToString());
                    lVItem.SubItems.Add(user.Username.ToString());
                    lVItem.SubItems.Add(user.HoTen.ToString());
                    lVItem.SubItems.Add(user.DiaChi.ToString());
                    lv_DanhSachUser.Items.Add(lVItem);
                }
            }
            else lv_DanhSachUser.Items.Clear();
        }

        public void FillSystemLog()
        {
            arrSys = busSys.GetAllSystem(dtpFromSystem.Value.ToString(),dtpToSys.Value.ToString());            
            if (arrSys != null)
            {
                lv_SystemLog.Items.Clear();
                foreach (SystemLog sys in arrSys)
                {
                    ListViewItem lVItem = new ListViewItem(sys.ID.ToString());
                    lVItem.SubItems.Add(sys.UserName.ToString());
                    lVItem.SubItems.Add(DateTimeConvert.FormatVN(sys.DateLogin));                    
                    lVItem.SubItems.Add(sys.Description.ToString());
                    lv_SystemLog.Items.Add(lVItem);
                }                
            }
            else lv_SystemLog.Items.Clear();
        }

        private void btn_SystemLog_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NhatKy);
            page_NhatKy.Text = "Nhật Ký Hệ Thống";            
            dtpToSys.Value = DateTime.Now;
            FillSystemLog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btn_XemSystem_Click(object sender, EventArgs e)
        {
            FillSystemLog();
        }

        private void btn_XoaSysten_Click(object sender, EventArgs e)
        {
            this.XoaSystem();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.XoaSystem();
        }

        public void XoaSystem() {
            if (lv_SystemLog.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SystemLog sys = (SystemLog)arrSys.ToArray()[lv_SystemLog.FocusedItem.Index];
                    busSys.DelSystemLog(sys.ID);
                    this.FillSystemLog();
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhật Ký !", "Error !");
            }
        }

        private void btn_HDX_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_HoaDonXuat);
            page_HoaDonXuat.Text = "Hóa Đơn Xuất";
            dTPTo_DSHDX.Value = DateTime.Now;
            DanhSachHDX();
        }

        ArrayList arrLAllHDX = new ArrayList();
        public void DanhSachHDX()
        {
            arrLAllHDX = busHDX.GetAllHDX(txtMaBN_DSHDX.Text, dTPFrom_DSHDX.Value.Date.ToString(), dTPTo_DSHDX.Value.Date.ToString());
            if (arrLAllHDX != null)
            {
                lvDanhSachHDX.Items.Clear();
                foreach (HoaDonXuat hdx in arrLAllHDX)
                {
                    ListViewItem lVItem = new ListViewItem(hdx.MaHDX.ToString());
                    lVItem.SubItems.Add(hdx.MaBN);
                    lVItem.SubItems.Add(hdx.TenBenhNhan);
                    lVItem.SubItems.Add(DateTimeConvert.FormatVN(hdx.NgayLap, "dd/MM/yyyy"));
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(hdx.TongTienHD)) + " VND");
                    lvDanhSachHDX.Items.Add(lVItem);
                }
            }
            else lvDanhSachHDX.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhSachHDX();
        }

        private void xemchitietToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvDanhSachHDX.SelectedItems.Count > 0)
            {
                HoaDonXuat hdx = (HoaDonXuat)arrLAllHDX.ToArray()[lvDanhSachHDX.FocusedItem.Index];
                ChiTietDonThuoc chiTietDT = new ChiTietDonThuoc(hdx);
                chiTietDT.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }
        }

        private void xoaHoaDonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvDanhSachHDX.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDonXuat hdx = (HoaDonXuat)arrLAllHDX.ToArray()[lvDanhSachHDX.FocusedItem.Index];
                    SystemLog systemLog = new SystemLog(currentUser.IDUser, DateTime.Now.ToString(), "Xóa đơn thuốc");
                    busUser.SetSystemLog(systemLog);
                    busHDX.DelHoaDonXuat(hdx.MaHDX);                    
                    DanhSachHDX();
                }
            }
            else
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }
        }

        private void lvDanhSachHDX_DoubleClick(object sender, EventArgs e)
        {
            HoaDonXuat hdx = (HoaDonXuat)arrLAllHDX.ToArray()[lvDanhSachHDX.FocusedItem.Index];
            ChiTietDonThuoc chiTietDT = new ChiTietDonThuoc(hdx);
            chiTietDT.ShowDialog();
        }

        private void btn_NhomThuoc_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NhomThuoc);
            page_NhomThuoc.Text = "Quản Lý Nhóm Thuốc";
            DanhSachNhomThuoc();
        }

        ArrayList arrNT = new ArrayList();

        public void DanhSachNhomThuoc()
        {
            arrNT = busNT.GetAllNhomThuoc();
            if (arrNT != null)
            {
                lv_DanhSachNhomThuoc.Items.Clear();                
                int i = 1;                
                foreach (NhomThuoc NT in arrNT)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(NT.MaNhom.ToString());
                    lVItem.SubItems.Add(NT.TenNhom);
                    lVItem.SubItems.Add(NT.GhiChu);
                    lv_DanhSachNhomThuoc.Items.Add(lVItem);                   
                    i++;
                }
            }
            else lv_DanhSachNhomThuoc.Items.Clear();
        }

        public void AddCBB_NhomThuoc()
        {
            arrNT = busNT.GetAllNhomThuoc();
            if (arrNT != null)
            {
                cbb_NhomThuoc.Items.Clear();                
                foreach (NhomThuoc NT in arrNT)
                {
                    cbb_NhomThuoc.Items.Add(NT.TenNhom);
                }
            }
        }
        public void AddCBB_NSX()
        {
            arrNSX = busNSX.GetAllNsx("");
            if (arrNSX != null)
            {
                cbb_NhaSanXuat.Items.Clear();
                foreach (NhaSanXuat NSX in arrNSX)
                {
                    cbb_NhaSanXuat.Items.Add(NSX.TenNSX);
                }
            }
        }
        private ArrayList arrDVT = new ArrayList();
        private ArrayList arrDongGOi = new ArrayList();
        public void AddCBB_DVT()
        {
            arrDVT = busDVT.GetAllDvt();
            arrDongGOi = busDVT.GetAllDvt();
            if (arrDVT != null)
            {
                cbb_DVT.Items.Clear();
                cbb_DongGoi.Items.Clear();
                foreach (DonViTinh DVT in arrDVT)
                {
                    cbb_DVT.Items.Add(DVT.Ten);
                    cbb_DongGoi.Items.Add(DVT.Ten);
                }
            }
        }

        private void btn_ThemNhomThuoc_Click(object sender, EventArgs e)
        {
            NhomThuoc NT = new NhomThuoc("Tên Nhóm", "Ghi Chú");
            if (busNT.TaoNhomThuoc(NT))
            {
                DanhSachNhomThuoc();                
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmi_ThemNhomThuoc_Click(object sender, EventArgs e)
        {
            NhomThuoc NT = new NhomThuoc("", "");
            if (busNT.TaoNhomThuoc(NT))
                DanhSachNhomThuoc();
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Thuoc_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_Thuoc);
            page_Thuoc.Text = "Quản Lý Thuốc";
            DanhSachThuoc();
            AddCBB_NhomThuoc();
            AddCBB_DVT();
            AddCBB_NSX();
        }

        ArrayList arrThuoc = new ArrayList();

        public void DanhSachThuoc()
        {
            arrThuoc = busThuoc.GetAllThuoc2("");
            if (arrThuoc != null)
            {
                lv_DanhSachThuoc.Items.Clear();
                int i = 1;
                foreach (Thuoc thuoc in arrThuoc)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(thuoc.MaThuoc.ToString());
                    lVItem.SubItems.Add(thuoc.TenThuoc);
                    lVItem.SubItems.Add(thuoc.TenNhom);
                    lVItem.SubItems.Add(thuoc.NguonGoc);
                    lVItem.SubItems.Add(thuoc.TenNSX);
                    lVItem.SubItems.Add(thuoc.SoLuong.ToString());
                    lVItem.SubItems.Add(thuoc.TenDVT);
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(thuoc.GiaBan)) + " VND");
                    lVItem.SubItems.Add(thuoc.Thue.ToString());
                    lVItem.SubItems.Add(thuoc.DangDongGoi_DVT);
                    lVItem.SubItems.Add(thuoc.SoLuongDongGoi.ToString());
                    lVItem.SubItems.Add(thuoc.SoDangKy);
                    lv_DanhSachThuoc.Items.Add(lVItem);
                    i++;
                }
            }
            else lv_DanhSachThuoc.Items.Clear();
        }

        private void btn_TimKiemThuoc_Click(object sender, EventArgs e)
        {
            DanhSachThuoc();
        }

        private void tsmi_ThongTinThuoc_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachThuoc.SelectedItems.Count > 0)
            {
                Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
                ChiTietThuoc ctThuoc = new ChiTietThuoc(thuoc,2);
                ctThuoc.ShowDialog();
                DanhSachThuoc();
            }
            else
            {
                MessageBox.Show(this, "Hãy chọn 1 loại thuốc !", "Thông báo");
            }
        }

        private void lv_DanhSachThuoc_DoubleClick(object sender, EventArgs e)
        {
            if (lv_DanhSachThuoc.SelectedItems.Count > 0)
            {
                Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
                ChiTietThuoc ctThuoc = new ChiTietThuoc(thuoc,2);
                ctThuoc.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Hãy chọn 1 loại thuốc !", "Thông báo");
            }
        }        

        private void lv_DanhSachNhomThuoc_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            Editors = new Control[] { lbl_Label, lbl_Label,txt_TenNhom,txt_GhiChu };            
            lv_DanhSachNhomThuoc.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);            
        }                 

        private void lv_DanhSachNhomThuoc_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            UpdateNhomThuoc();
        }

        private void tsmi_XoaNhomThuoc_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachNhomThuoc.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhomThuoc NT = (NhomThuoc)arrNT.ToArray()[lv_DanhSachNhomThuoc.FocusedItem.Index];
                    if (busNT.DelNhomThuocByMaNhom(NT.MaNhom))
                        this.DanhSachNhomThuoc();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Thuốc của Nhóm Thuốc này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhóm Thuốc !", "Error !");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachThuoc.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
                    String KQ = busThuoc.DelThuocByMaThuoc(thuoc.MaThuoc);
                    if (KQ == "OK")
                        this.DanhSachThuoc();
                    else
                        MessageBox.Show(this, KQ.ToString(), "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Thuốc !", "Error !");
            }
        }

        private void btn_CapNhapNhomThuoc_Click(object sender, EventArgs e)
        {
            UpdateNhomThuoc();
        }

        public void UpdateNhomThuoc() {
            if (MessageBox.Show(this, "Bạn có muốn cập nhập dự liệu không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                NhomThuoc NT = (NhomThuoc)arrNT.ToArray()[lv_DanhSachNhomThuoc.FocusedItem.Index];
                if (txt_TenNhom.Text != "")
                {
                    NT.TenNhom = txt_TenNhom.Text.ToString();
                }
                if (txt_GhiChu.Text != "")
                    NT.GhiChu = txt_GhiChu.Text.ToString();
                if ((txt_GhiChu.Text == "") && (txt_TenNhom.Text == ""))
                    NT.GhiChu = txt_GhiChu.Text.ToString();

              
                //String TenNhom = lv_DanhSachNhomThuoc.Items[lv_DanhSachNhomThuoc.FocusedItem.Index].SubItems[2].Text;
                //String GhiChu = lv_DanhSachNhomThuoc.Items[lv_DanhSachNhomThuoc.FocusedItem.Index].SubItems[3].Text;
                //MessageBox.Show(this, TenNhom + "   " + GhiChu, "");
                if (busNT.UpdateNhomThuoc(NT))
                {                    
                    DanhSachNhomThuoc();
                }
                else
                {
                    MessageBox.Show(this, "Không cập nhập được !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txt_GhiChu.Text = "";
                txt_TenNhom.Text = "";
            }
            else DanhSachNhomThuoc();
        }
        private void btn_ThemThuoc_Click(object sender, EventArgs e)
        {
            Thuoc thuoc = new Thuoc();
            ChiTietThuoc ctThuoc = new ChiTietThuoc(thuoc, 1);
            ctThuoc.ShowDialog();
            DanhSachThuoc();
        }

        private void lv_DanhSachThuoc_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            Editors = new Control[] { lbl_MaThuoc, lbl_MaThuoc, txt_TenThuoc, cbb_NhomThuoc, txt_NguonGoc, cbb_NhaSanXuat, numUD_SoLuong, cbb_DVT, txt_GiaBan, txt_Thue, cbb_DongGoi, numUD_SoLuongDongGoi, txt_SoDangKy };
            lv_DanhSachThuoc.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);

            Thuoc thuocCurrent = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
            MaCu = thuocCurrent.MaThuoc;
            cbb_NhomThuoc.SelectedItem = thuocCurrent.TenNhom;
            cbb_NhaSanXuat.SelectedItem = thuocCurrent.TenNSX;
            cbb_DVT.SelectedItem = thuocCurrent.TenDVT;
            cbb_DongGoi.SelectedItem = thuocCurrent.DangDongGoi_DVT;
            txt_GiaBan.Text = thuocCurrent.GiaBan.ToString();
            numUD_SoLuong.Value = thuocCurrent.SoLuong;
            numUD_SoLuongDongGoi.Value = thuocCurrent.SoLuongDongGoi;
        }

        private String MaCu;
        
        private void lv_DanhSachThuoc_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {            
            UpdateThuoc();
        }        

        public void UpdateThuoc()
        {
            if (MessageBox.Show(this, "Bạn có muốn cập nhập dự liệu không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
                thuoc.MaThuoc = lv_DanhSachThuoc.Items[lv_DanhSachThuoc.FocusedItem.Index].SubItems[1].Text;
                if (txt_TenThuoc.Text != "")
                {
                    thuoc.TenThuoc = txt_TenThuoc.Text.ToString();
                }

                if (txt_NguonGoc.Text != "")
                {
                    thuoc.NguonGoc = txt_NguonGoc.Text.ToString(); ;
                }
                if (txt_Thue.Text != "")
                    if (ValidateFrom.CheckNumber(txt_Thue.Text))
                    {
                        try
                        {
                            thuoc.Thue = Convert.ToDouble(txt_Thue.Text);
                        }
                        catch (FormatException evt) {
                            Console.WriteLine(evt.Message);
                        }
                    }

                if (ValidateFrom.CheckNumber(txt_GiaBan.Text))
                {
                    try
                    {
                        thuoc.GiaBan = Convert.ToDecimal(txt_GiaBan.Text);
                    }
                    catch (FormatException evt)
                    {
                        Console.WriteLine(evt.Message);
                    }                    
                }

                if (cbb_NhomThuoc.SelectedIndex != -1)
                {
                    NhomThuoc NT = (NhomThuoc)arrNT.ToArray()[cbb_NhomThuoc.SelectedIndex];
                    thuoc.MaNhom = NT.MaNhom;
                }
                if (cbb_NhaSanXuat.SelectedIndex != -1)
                {
                    NhaSanXuat NSX = (NhaSanXuat)arrNSX.ToArray()[cbb_NhaSanXuat.SelectedIndex];
                    thuoc.MaNSX = NSX.MaNSX;
                }
                if (cbb_DVT.SelectedIndex != -1)
                {
                    DonViTinh DVT = (DonViTinh)arrDVT.ToArray()[cbb_DVT.SelectedIndex];
                    thuoc.MaDVT = DVT.MaDVT;
                }
                if (cbb_DongGoi.SelectedIndex != -1)
                {
                    DonViTinh DongGoi = (DonViTinh)arrDongGOi.ToArray()[cbb_DongGoi.SelectedIndex];
                    thuoc.DangDongGoi = DongGoi.MaDVT;
                }
                thuoc.SoLuong = Convert.ToInt32(numUD_SoLuong.Value);
                thuoc.SoLuongDongGoi = Convert.ToInt32(numUD_SoLuongDongGoi.Value);

                //MessageBox.Show(this,MaCu+" ; "+ thuoc.MaThuoc + " ; " + thuoc.TenThuoc + " ; " + thuoc.TenNhom + " ; " + thuoc.NguonGoc + " ; " + thuoc.TenNSX + " ; " + thuoc.SoLuong + " ; " + thuoc.TenDVT + " ; " + thuoc.GiaBan + " ; " + thuoc.Thue + " ; " + thuoc.DangDongGoi_DVT + " ; " + thuoc.SoLuongDongGoi + " ; " + thuoc.SoDangKy, "Thông Báo !");
                if (busThuoc.UpdateThuoc(thuoc))
                {                    
                    txt_TenThuoc.Text = "";
                    txt_NguonGoc.Text = "";
                    txt_Thue.Text = "";
                    txt_GiaBan.Text = "";
                    DanhSachThuoc();
                }
                else
                {
                    MessageBox.Show(this, "Không cập nhập được !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_TenThuoc_KeyUp(object sender, KeyEventArgs e)
        {
            Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
            thuoc.MaThuoc = thuoc.MaThuoc.Substring(0, 8) + txt_TenThuoc.Text;
            lv_DanhSachThuoc.Items[lv_DanhSachThuoc.FocusedItem.Index].SubItems[1].Text = thuoc.MaThuoc;
        }

        
        public void DanhSachDVT()
        {
            arrDVT = busDVT.GetAllDvt();
            if (arrDVT != null)
            {
                lv_DonViTinh.Items.Clear();
                int i = 1;
                foreach (DonViTinh DVT in arrDVT)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(DVT.MaDVT.ToString());
                    lVItem.SubItems.Add(DVT.Ten.ToString());
                    lv_DonViTinh.Items.Add(lVItem);
                    i++;
                }
            }
            else lv_DonViTinh.Items.Clear();
        }

        private void btn_DVT_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_DVT);
            page_DVT.Text = "Đơn Vị Tính";
            DanhSachDVT();    
        }

        private void lv_DonViTinh_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            Editors = new Control[] {lbl_MaDVT,lbl_MaDVT, txt_TenDVT };
            lv_DonViTinh.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);           
        }

        private void lv_DonViTinh_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            UpdateDVT();
        }

        public void UpdateDVT() {
            if (MessageBox.Show(this, "Bạn có muốn cập nhập dự liệu không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                DonViTinh DVT = (DonViTinh)arrDVT.ToArray()[lv_DonViTinh.FocusedItem.Index];                
                if (txt_TenDVT.Text != "")
                {
                    DVT.Ten = txt_TenDVT.Text.ToString();
                }

                //MessageBox.Show(this,MaCu+" ; "+ thuoc.MaThuoc + " ; " + thuoc.TenThuoc + " ; " + thuoc.TenNhom + " ; " + thuoc.NguonGoc + " ; " + thuoc.TenNSX + " ; " + thuoc.SoLuong + " ; " + thuoc.TenDVT + " ; " + thuoc.GiaBan + " ; " + thuoc.Thue + " ; " + thuoc.DangDongGoi_DVT + " ; " + thuoc.SoLuongDongGoi + " ; " + thuoc.SoDangKy, "Thông Báo !");
                if (busDVT.UpdateDVT(DVT))
                {
                    DanhSachDVT();
                }
                else
                {
                    MessageBox.Show(this, "Không cập nhập được !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txt_TenDVT.Text = "";
            }
            else DanhSachDVT();
        }

        private void btn_ThemDVT_Click(object sender, EventArgs e)
        {            
            if (busDVT.TaoDVT())
            {
                DanhSachDVT();
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmi_ThemDVT_Click(object sender, EventArgs e)
        {
            if (busDVT.TaoDVT())
            {
                DanhSachDVT();
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_NSX_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NXS);
            page_NXS.Text = "Quản Lý Nhà Sản Xuất";
            DanhSachNSX();
        }

        public void DanhSachNSX()
        {
            arrNSX = busNSX.GetAllNsx("");
            if (arrNSX != null)
            {
                lv_DanhSachNSX.Items.Clear();
                int i = 1;
                foreach (NhaSanXuat NSX in arrNSX)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(NSX.MaNSX.ToString());
                    lVItem.SubItems.Add(NSX.TenNSX);
                    lVItem.SubItems.Add(NSX.DiaChi);
                    lVItem.SubItems.Add(NSX.DienThoai);
                    lVItem.SubItems.Add(NSX.Fax);
                    lVItem.SubItems.Add(NSX.Email);
                    lVItem.SubItems.Add(NSX.GhiChu);
                    lv_DanhSachNSX.Items.Add(lVItem);
                    i++;
                }
            } else lv_DanhSachNSX.Items.Clear();
        }

        private void tsbtn_THemNSX_Click(object sender, EventArgs e)
        {
            if (busNSX.TaoNSX())
            {
                DanhSachNSX();
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmi_ThemNSX_Click(object sender, EventArgs e)
        {
            if (busNSX.TaoNSX())
            {
                DanhSachNSX();
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lv_DanhSachNSX_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            Editors = new Control[] { lbl_MaNSX,lbl_MaNSX, txt_TenNSX,txt_DiaChi,txt_DienThoai,txt_Fax,txt_Email,txt_GhiCHu_NSX};
            lv_DanhSachNSX.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);
        }

        private void lv_DanhSachNSX_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            UpdateNSX();
        }

        public void UpdateNSX()
        {
            if (MessageBox.Show(this, "Bạn có muốn cập nhập dự liệu không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NhaSanXuat NSX = (NhaSanXuat)arrNSX.ToArray()[lv_DanhSachNSX.FocusedItem.Index];
                Boolean test=true;
                if (txt_TenNSX.Text != "")
                {
                    NSX.TenNSX = txt_TenNSX.Text.ToString();
                }
                if (txt_DiaChi.Text != "")
                {
                    NSX.DiaChi = txt_DiaChi.Text.ToString();
                }
                if (txt_DienThoai.Text != "")
                {
                    if (ValidateFrom.CheckPhoneNumber(txt_DienThoai.Text))
                        NSX.DienThoai = txt_DienThoai.Text.ToString();
                    else
                    {
                        test = false;
                        MessageBox.Show(this, "Điện Thoại không đúng định dạng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DanhSachNSX();
                    }
                }
                if (txt_Fax.Text != "")
                {
                    NSX.Fax = txt_Fax.Text.ToString();
                }
                if (txt_Email.Text != "")
                {
                    if (ValidateFrom.CheckEmail(txt_Email.Text))
                        NSX.Email = txt_Email.Text.ToString();
                    else
                    {
                        test = false;
                        MessageBox.Show(this, "Email không đúng định dạng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DanhSachNSX();                       
                    }
                }
                if (txt_GhiCHu_NSX.Text != "")
                {
                    NSX.GhiChu = txt_GhiCHu_NSX.Text.ToString();
                }

                //MessageBox.Show(this,MaCu+" ; "+ thuoc.MaThuoc + " ; " + thuoc.TenThuoc + " ; " + thuoc.TenNhom + " ; " + thuoc.NguonGoc + " ; " + thuoc.TenNSX + " ; " + thuoc.SoLuong + " ; " + thuoc.TenDVT + " ; " + thuoc.GiaBan + " ; " + thuoc.Thue + " ; " + thuoc.DangDongGoi_DVT + " ; " + thuoc.SoLuongDongGoi + " ; " + thuoc.SoDangKy, "Thông Báo !");
                if (test == true)
                {
                    if (busNSX.UpdateNSX(NSX))
                    {
                        DanhSachNSX();
                    }
                    else
                    {
                        MessageBox.Show(this, "Không cập nhập được !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txt_TenNSX.Text = "";
                txt_DiaChi.Text = "";
                txt_DienThoai.Text = "";
                txt_Fax.Text = "";
                txt_Email.Text = "";
                txt_GhiCHu_NSX.Text = "";
            }
            else DanhSachNSX();
        }

        private void btn_NPP_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_NPP);
            page_NPP.Text = "Quản Lý Nhà Phân Phối";
            DanhSachNPP();
        }

        ArrayList arrNPP = new ArrayList();
        public void DanhSachNPP()
        {
            arrNPP = busNNP.GetAllNpp("");
            if (arrNPP != null)
            {
                lv_DanhSachNPP.Items.Clear();
                int i = 1;
                foreach (NhaPhanPhoi NPP in arrNPP)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(NPP.MaNPP.ToString());
                    lVItem.SubItems.Add(NPP.TenNPP);
                    lVItem.SubItems.Add(NPP.DiaChi);
                    lVItem.SubItems.Add(NPP.DienThoai);
                    lVItem.SubItems.Add(NPP.Fax);
                    lVItem.SubItems.Add(NPP.Email);
                    lVItem.SubItems.Add(NPP.MaSoThue);
                    lVItem.SubItems.Add(NPP.GhiChu);
                    lv_DanhSachNPP.Items.Add(lVItem);
                    i++;
                }
            }
            else lv_DanhSachNPP.Items.Clear();
        }

        private void btn_ThemNPP_Click(object sender, EventArgs e)
        {
            if (busNNP.TaoNNPP())
            {
                DanhSachNPP();
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmi_ThemNPP_Click(object sender, EventArgs e)
        {
            if (busNNP.TaoNNPP())
            {
                DanhSachNPP();
            }
            else
            {
                MessageBox.Show(this, "Không Thêm Được", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lv_DanhSachNPP_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            Editors = new Control[] { lbl_MaNPP, lbl_MaNPP, txt_TenNPP, txt_DiaChi_NPP, txt_DienThoaiNPP, txt_EmailNPP, txt_FaxNPP,txt_MasoThueNPP, txt_GhiChuNPP };
            lv_DanhSachNPP.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);
        }

        private void lv_DanhSachNPP_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            UpdateNPP();
        }

        public void UpdateNPP()
        {
            if (MessageBox.Show(this, "Bạn có muốn cập nhập dự liệu không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NhaPhanPhoi NPP = (NhaPhanPhoi)arrNPP.ToArray()[lv_DanhSachNPP.FocusedItem.Index];
                Boolean test = true;
                if (txt_TenNPP.Text != "")
                {
                    NPP.TenNPP = txt_TenNPP.Text.ToString();
                }
                if (txt_DiaChi_NPP.Text != "")
                {
                    NPP.DiaChi = txt_DiaChi_NPP.Text.ToString();
                }
                if (txt_DienThoaiNPP.Text != "")
                {
                    if (ValidateFrom.CheckPhoneNumber(txt_DienThoaiNPP.Text))
                        NPP.DienThoai = txt_DienThoaiNPP.Text.ToString();
                    else
                    {
                        test = false;
                        MessageBox.Show(this, "Điện Thoại không đúng định dạng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DanhSachNPP();
                    }
                }
                if (txt_FaxNPP.Text != "")
                {
                    NPP.Fax = txt_FaxNPP.Text.ToString();
                }
                if (txt_EmailNPP.Text != "")
                {
                    if (ValidateFrom.CheckEmail(txt_EmailNPP.Text))
                        NPP.Email = txt_EmailNPP.Text.ToString();
                    else
                    {
                        test = false;
                        MessageBox.Show(this, "Email không đúng định dạng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DanhSachNPP();
                    }
                }
                if (txt_MasoThueNPP.Text != "")
                {
                    NPP.MaSoThue = txt_MasoThueNPP.Text.ToString();
                }
                if (txt_GhiChuNPP.Text != "")
                {
                    NPP.GhiChu = txt_GhiChuNPP.Text.ToString();
                }

                //MessageBox.Show(this,MaCu+" ; "+ thuoc.MaThuoc + " ; " + thuoc.TenThuoc + " ; " + thuoc.TenNhom + " ; " + thuoc.NguonGoc + " ; " + thuoc.TenNSX + " ; " + thuoc.SoLuong + " ; " + thuoc.TenDVT + " ; " + thuoc.GiaBan + " ; " + thuoc.Thue + " ; " + thuoc.DangDongGoi_DVT + " ; " + thuoc.SoLuongDongGoi + " ; " + thuoc.SoDangKy, "Thông Báo !");
                if (test == true)
                {
                    if (busNNP.UpdateNPP(NPP))
                    {
                        DanhSachNPP();
                    }
                    else
                    {
                        MessageBox.Show(this, "Không cập nhập được !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txt_TenNPP.Text = "";
                txt_DiaChi_NPP.Text = "";
                txt_DienThoaiNPP.Text = "";
                txt_FaxNPP.Text = "";
                txt_EmailNPP.Text = "";
                txt_MasoThueNPP.Text = "";
                txt_GhiChuNPP.Text = "";
            }
            else DanhSachNPP();
        }

        private void btn_HDN_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(page_TaoHDN);
            tabControl1.TabPages.Add(page_HoaDonNhap);
            page_TaoHDN.Text = "Tạo Hóa Đơn Nhập";
            page_HoaDonNhap.Text = "Danh Sách Hóa Đơn Nhập";
            arrThuoc = busThuoc.GetAllThuoc2("");
            dtp_NgayNhap.Value = DateTime.Now;
            dtp_ToHDN.Value = DateTime.Now;
            AddCBB_NhaPhanPhoi();
            DanhSachHDN();            
        }

        ArrayList arrHDN = new ArrayList();
        public void DanhSachHDN()
        {
            arrHDN = busHDN.GetAllHDN(txt_TenNPP_HDN.Text,txt_MaThuoc_TKHDN.Text, dtp_FromHDN.Value.ToString(), dtp_ToHDN.Value.ToString());
            //MessageBox.Show(this, " getAllHDN N'%" + txt_TenNPP_HDN.Text.Replace("'", "''") + "%',N'%" + txt_MaThuoc_TKHDN.Text.Replace("'", "''") + "%','" + dtp_FromHDN.Value.ToString() + "','" + dtp_ToHDN.Value.ToString() + "'", "Thông báo !");
            if (arrLAllHDX != null)
            {
                lv_DanhSachHDN.Items.Clear();
                int i = 1;
                foreach (HoaDonNhap HDN in arrHDN)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(HDN.MaHDN.ToString());
                    lVItem.SubItems.Add(HDN.TenNPP.ToString());
                    lVItem.SubItems.Add(DateTimeConvert.FormatVN(HDN.NgayNhap, "dd/MM/yyyy"));
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(HDN.TongTienHD)) + " VND");
                    lv_DanhSachHDN.Items.Add(lVItem);
                    i++;
                }
            }
            else lv_DanhSachHDN.Items.Clear();
        }

        public void AddCBB_NhaPhanPhoi() {
            arrNPP = busNNP.GetAllNpp("");
            if (arrNPP != null)
            {
                cbb_NPP.Items.Clear();                
                foreach (NhaPhanPhoi NPP in arrNPP)
                {
                    cbb_NPP.Items.Add(NPP.TenNPP);
                }
            }
        }

        private void txt_MaThuocHDN_TextChanged(object sender, EventArgs e)
        {            

        }

        public void SearchThuocHDN() {
            arrThuoc = busThuoc.GetAllThuoc2(txt_MaThuocHDN.Text.ToString());            
            if (arrThuoc != null)
            {                     
                lv_DanhSachThuocHDN.Items.Clear();
                foreach (Thuoc thuoc in arrThuoc)
                {
                    ListViewItem lVItem = new ListViewItem(thuoc.MaThuoc.ToString());                    
                    lVItem.SubItems.Add(thuoc.TenNSX);
                    lVItem.SubItems.Add(thuoc.TenDVT);
                    lVItem.SubItems.Add(thuoc.DangDongGoi_DVT);
                    lv_DanhSachThuocHDN.Items.Add(lVItem);                    
                }
            }
            else lv_DanhSachThuocHDN.Items.Clear();
        }

        private void btn_ChonMaThuoc_Click(object sender, EventArgs e)
        {
            if (pnl_TimThuoc.Visible == false)
            {
                pnl_TimThuoc.Visible = true;
                txt_MaThuocHDN.Text = "";
                SearchThuocHDN();
            }
            else pnl_TimThuoc.Visible = false;
        }

        private void btn_ThemThuocHDN_Click(object sender, EventArgs e)
        {
            if (KiemTraMaThuocHDN() == true)
                MessageBox.Show(this, "Thuốc này đã có trong danh sách !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                int SoLuong = Convert.ToInt32(numUD_SoLuongThuocNhap.Value);
                decimal GiaNhap = 0;
                if (SoLuong == 0)
                {
                    MessageBox.Show(this, "Chưa nhập số lượng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!ValidateFrom.CheckNumber(txt_GiaNhap.Text))
                {
                    MessageBox.Show(this, "Giá nhập không đúng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_GiaNhap.Text = "";
                    txt_GiaNhap.Focus();
                }
                else
                {
                    Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuocHDN.FocusedItem.Index];
                    try
                    {
                        GiaNhap = Convert.ToDecimal(txt_GiaNhap.Text);
                        ChiTietHoaDonNhap ctHDN = new ChiTietHoaDonNhap();
                        ctHDN.IDThuoc = thuoc.IDThuoc;
                        ctHDN.MaThuoc = thuoc.MaThuoc;
                        ctHDN.SoLuong = SoLuong;
                        ctHDN.GiaNhap = GiaNhap;
                        arrCTHDN.Add(ctHDN);
                        ViewCTHDN();
                        txt_MaThuocHDN.Text = "";
                        numUD_SoLuongThuocNhap.Value = 0;
                        txt_GiaNhap.Text = "";
                        btn_ThemThuocHDN.Enabled = false;
                    }
                    catch (FormatException evt) {

                        Console.WriteLine(evt.Message);
                        MessageBox.Show(this, "Giá nhập không đúng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_GiaNhap.Text = "";
                        txt_GiaNhap.Focus();
                    }
                }
            }
        }

        public void ViewCTHDN() {
            if (arrCTHDN != null)
            {
                lv_DanhSachCTHDN.Items.Clear();
                int i = 1;
                decimal TienHang = 0;
                foreach (ChiTietHoaDonNhap CTHDN in arrCTHDN)
                {
                    decimal ThanhTien = CTHDN.SoLuong * CTHDN.GiaNhap;
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(CTHDN.MaThuoc);
                    lVItem.SubItems.Add(CTHDN.SoLuong.ToString());
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(CTHDN.GiaNhap)) + " VND");
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(ThanhTien)) + " VND");
                    lv_DanhSachCTHDN.Items.Add(lVItem);
                    TienHang += ThanhTien;
                    i++;
                }
                lbl_TienHang.Text = TienHang.ToString();
                if (ValidateFrom.CheckNumber(txt_ThueHDN.Text))
                {
                    Double Thue = Convert.ToDouble(txt_ThueHDN.Text);
                    int TienHang2 = Convert.ToInt32(lbl_TienHang.Text);
                    Double TongTien = TienHang2 * (1 - Thue / 100);
                    lbl_TongTien.Text = TongTien.ToString();
                }
            }
            else lv_DanhSachCTHDN.Items.Clear();
        }

        public Boolean KiemTraMaThuocHDN() {
            
            foreach (ChiTietHoaDonNhap CTHDN in arrCTHDN)
            {
                if (CTHDN.MaThuoc == txt_MaThuocHDN.Text)
                    return true;
            }
            return false;
        }

        private void lv_DanhSachCTHDN_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachCTHDN.Items.Count > 0)
            {
                btn_XoaThuocHDN.Enabled = true;
            }
            else
                btn_XoaThuocHDN.Enabled = false;
            
        }

        private void btn_XoaThuocHDN_Click(object sender, EventArgs e)
        {
            arrCTHDN.RemoveAt(lv_DanhSachCTHDN.FocusedItem.Index);
            ViewCTHDN();
            btn_XoaThuocHDN.Enabled = false;
        }

        private void lv_DanhSachThuocHDN_DoubleClick(object sender, EventArgs e)
        {
            Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuocHDN.FocusedItem.Index];
            txt_MaThuocHDN.Text = thuoc.MaThuoc;
            pnl_TimThuoc.Visible = false;
            btn_ThemThuocHDN.Enabled = true;
        }

        private void txt_MaThuocHDN_KeyUp(object sender, KeyEventArgs e)
        {
            pnl_TimThuoc.Visible = true;
            btn_ThemThuocHDN.Enabled = false;
            SearchThuocHDN();
        }


        private void txt_ThueHDN_TextChanged(object sender, EventArgs e)
        {            
            if (ValidateFrom.CheckNumber(txt_ThueHDN.Text))
            {
                try
                {
                    Double Thue = Convert.ToDouble(txt_ThueHDN.Text);
                    if (Thue >= 100)
                    {
                        MessageBox.Show(this, "Không được > 100", "Thông Báo ...");
                    }
                    else
                    {
                        int TienHang = Convert.ToInt32(lbl_TienHang.Text);
                        Double TongTien = TienHang * (1 + Thue / 100);
                        lbl_TongTien.Text = TongTien.ToString();
                    }
                }
                catch (FormatException evt)
                {
                    Console.WriteLine(evt.Message);
                    MessageBox.Show(this, "Không đúng định dạng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_ThueHDN.Text = "0";
                    txt_ThueHDN.Focus();
                }
                
            }
            else {
                MessageBox.Show(this, "Không đúng định dạng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ThueHDN.Text = "0";
                txt_ThueHDN.Focus();
            }
        }

        private void btn_LuuHDN_Click(object sender, EventArgs e)
        {
            if (arrCTHDN.Count == 0)
            {
                MessageBox.Show(this, "Chưa có thuốc trong hóa đơn", "Thông báo");
                txt_MaThuocHDN.Focus();
            }
            else if (cbb_NPP.SelectedIndex<0)
            {
                MessageBox.Show(this, "Chưa chọn nhà phân phối", "Thông báo");                
            }            
            else
            {
                NhaPhanPhoi NPP = (NhaPhanPhoi)arrNPP.ToArray()[cbb_NPP.SelectedIndex];
                String NguoiGiao = txt_NguoiGiao.Text;
                String NguoiNhan = txt_NguoiNhan.Text;
                Decimal TongTienThuoc = Convert.ToDecimal(lbl_TienHang.Text);
                Double Thue = Convert.ToDouble(txt_ThueHDN.Text);
                Decimal TongTien = Convert.ToDecimal(lbl_TongTien.Text);
                HoaDonNhap HDN = new HoaDonNhap(0, NPP.MaNPP, NguoiGiao, NguoiNhan, TongTienThuoc, Thue, TongTien, dtp_NgayViet.Value.Date, dtp_NgayNhap.Value.Date);
                bool flag = busHDN.TaoHoaDonNhap(HDN, arrCTHDN);
                if (flag)
                {
                    MessageBox.Show(this, "Tạo hóa đơn thành công!", "Thông báo");
                    DanhSachHDN();
                }
                else
                {
                    MessageBox.Show(this, "Không tạo được hóa đơn!", "Thông báo");
                }
                ResetFormHDN();
            }
        }
        public void ResetFormHDN() {
            lv_DanhSachCTHDN.Items.Clear();
            arrCTHDN = new ArrayList();
            txt_MaThuocHDN.Text = "";
            numUD_SoLuongThuocNhap.Value = 0;
            txt_GiaNhap.Text = "";
            cbb_NPP.SelectedIndex = -1;
            lbl_TienHang.Text = "0";
            txt_ThueHDN.Text = "0";
            lbl_TongTien.Text = "0";
            txt_NguoiGiao.Text = "";
            txt_NguoiNhan.Text = "";
        }

        private void btn_TaoLaiHDN_Click(object sender, EventArgs e)
        {
            ResetFormHDN();
        }

        private void bn_XemHDN_Click(object sender, EventArgs e)
        {
            DanhSachHDN();
        }

        private void btn_XoaHDN_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachHDN.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    HoaDonNhap HDN = (HoaDonNhap)arrHDN.ToArray()[lv_DanhSachHDN.FocusedItem.Index];
                    if (busHDN.DelHoaDonNhap(HDN.MaHDN)==true)
                        this.DanhSachHDN();
                    else
                        MessageBox.Show(this, "Không xóa được !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }
        }

        private void lv_DanhSachCTHDN_SubItemClicked(object sender, ListViewEx.SubItemEventArgs e)
        {
            Editors = new Control[] { lbl_MaNPP, lbl_MaNPP, numUD_SoLuongThuoc_CTHDN, txt_GiaNhapSua,lbl_MaNPP};
            lv_DanhSachCTHDN.StartEditing(Editors[e.SubItem], e.Item, e.SubItem);
            ChiTietHoaDonNhap CTHDN = (ChiTietHoaDonNhap)arrCTHDN.ToArray()[lv_DanhSachCTHDN.FocusedItem.Index];
            txt_GiaNhapSua.Text = CTHDN.GiaNhap.ToString();
            numUD_SoLuongThuoc_CTHDN.Value = CTHDN.SoLuong;
        }

        private void lv_DanhSachCTHDN_SubItemEndEditing(object sender, ListViewEx.SubItemEndEditingEventArgs e)
        {
            UpdateChiTietHDN();
        }

        public void UpdateChiTietHDN()
        {
            if (MessageBox.Show(this, "Bạn có muốn cập nhập dự liệu không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChiTietHoaDonNhap CTHDN = (ChiTietHoaDonNhap)arrCTHDN.ToArray()[lv_DanhSachCTHDN.FocusedItem.Index];
                Boolean test = false;
                CTHDN.SoLuong = Convert.ToInt32(numUD_SoLuongThuoc_CTHDN.Value);
                if (txt_GiaNhapSua.Text != "")
                {
                    if (ValidateFrom.CheckNumber(txt_GiaNhapSua.Text))
                    {
                        try
                        {
                            
                            CTHDN.GiaNhap = Convert.ToDecimal(txt_GiaNhapSua.Text);
                            test = true;
                        }
                        catch (FormatException evt) {
                            Console.WriteLine(evt.Message);
                            MessageBox.Show(this, "Giá nhập không đúng !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ViewCTHDN();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Giá nhập phải là số !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_GiaNhapSua.Text = String.Format("{0:0,0}", Convert.ToInt32(CTHDN.GiaNhap)) + " VND";
                    }
                }

                //MessageBox.Show(this,MaCu+" ; "+ thuoc.MaThuoc + " ; " + thuoc.TenThuoc + " ; " + thuoc.TenNhom + " ; " + thuoc.NguonGoc + " ; " + thuoc.TenNSX + " ; " + thuoc.SoLuong + " ; " + thuoc.TenDVT + " ; " + thuoc.GiaBan + " ; " + thuoc.Thue + " ; " + thuoc.DangDongGoi_DVT + " ; " + thuoc.SoLuongDongGoi + " ; " + thuoc.SoDangKy, "Thông Báo !");
                if (test == true)
                {
                    arrCTHDN.RemoveAt(lv_DanhSachCTHDN.FocusedItem.Index);
                    arrCTHDN.Add(CTHDN);
                    ViewCTHDN();
                }
                txt_GiaNhapSua.Text = "";
                numUD_SoLuongThuoc_CTHDN.Value = 1;
            }
            else ViewCTHDN();
        }

        private void lv_DanhSachHDN_DoubleClick(object sender, EventArgs e)
        {
            if (lv_DanhSachHDN.SelectedItems.Count > 0)
            {
                HoaDonNhap HDN = (HoaDonNhap)arrHDN.ToArray()[lv_DanhSachHDN.FocusedItem.Index];
                ViewChiTietHoaDonNhap VCTHDN = new ViewChiTietHoaDonNhap(HDN);
                VCTHDN.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }            
        }

        private void btn_ChiTietHDN_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachHDN.SelectedItems.Count > 0)
            {
                HoaDonNhap HDN = (HoaDonNhap)arrHDN.ToArray()[lv_DanhSachHDN.FocusedItem.Index];
                ViewChiTietHoaDonNhap VCTHDN = new ViewChiTietHoaDonNhap(HDN);
                VCTHDN.ShowDialog();
            }
            else
            {
                MessageBox.Show(this, "Chọn một hóa đơn", "Thông báo");
            }
        }       


        private void btn_XoaNPP_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachNPP.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhaPhanPhoi NPP = (NhaPhanPhoi)arrNPP.ToArray()[lv_DanhSachNPP.FocusedItem.Index];
                    if (busNNP.DelNPPByMaNPP(NPP.MaNPP))
                        this.DanhSachNPP();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Hóa Đơn Nhập có Nhà Phân Phối này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhà Phân Phối !", "Error !");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachNSX.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhaSanXuat NSX = (NhaSanXuat)arrNSX.ToArray()[lv_DanhSachNSX.FocusedItem.Index];
                    if (busNSX.DelNhaSanXuatByMaNSX(NSX.MaNSX))
                        this.DanhSachNSX();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Thuốc của Nhà Sản Xuất này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhà Sản Xuất !", "Error !");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (lv_DonViTinh.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DonViTinh DVT = (DonViTinh)arrDVT.ToArray()[lv_DonViTinh.FocusedItem.Index];
                    if (busDVT.DelDonViTInhByMaDVT(DVT.MaDVT))
                        this.DanhSachDVT();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Thuốc có Đơn Vị Tính này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Đơn VỊ Tính !", "Error !");
            }
        }

        private void btn_XoaNhomThuoc_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachNhomThuoc.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhomThuoc NT = (NhomThuoc)arrNT.ToArray()[lv_DanhSachNhomThuoc.FocusedItem.Index];
                    if (busNT.DelNhomThuocByMaNhom(NT.MaNhom))
                        this.DanhSachNhomThuoc();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Thuốc của Nhóm Thuốc này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhóm Thuốc !", "Error !");
            }
        }

        private void tsmi_XoaDVT_Click(object sender, EventArgs e)
        {
            if (lv_DonViTinh.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DonViTinh DVT = (DonViTinh)arrDVT.ToArray()[lv_DonViTinh.FocusedItem.Index];
                    if (busDVT.DelDonViTInhByMaDVT(DVT.MaDVT))
                        this.DanhSachDVT();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Thuốc có Đơn Vị Tính này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Đơn VỊ Tính !", "Error !");
            }
        }

        private void tsmi_XoaNSX_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachNSX.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhaSanXuat NSX = (NhaSanXuat)arrNSX.ToArray()[lv_DanhSachNSX.FocusedItem.Index];
                    if (busNSX.DelNhaSanXuatByMaNSX(NSX.MaNSX))
                        this.DanhSachNSX();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Thuốc của Nhà Sản Xuất này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhà Sản Xuất !", "Error !");
            }
        }

        private void tsmi_XoaNPP_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachNPP.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhaPhanPhoi NPP = (NhaPhanPhoi)arrNPP.ToArray()[lv_DanhSachNPP.FocusedItem.Index];
                    if (busNNP.DelNPPByMaNPP(NPP.MaNPP))
                        this.DanhSachNPP();
                    else
                        MessageBox.Show(this, "Hãy xóa hết Hóa Đơn Nhập có Nhà Phân Phối này !", "Thông Báo !");
                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Nhà Phân Phối !", "Error !");
            }
        }

        private void btn_XoaThuoc_Click(object sender, EventArgs e)
        {
            if (lv_DanhSachThuoc.SelectedItems.Count > 0)
            {
                if (MessageBox.Show(this, "Bạn có muốn xóa không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Thuoc thuoc = (Thuoc)arrThuoc.ToArray()[lv_DanhSachThuoc.FocusedItem.Index];
                    String KQ = busThuoc.DelThuocByMaThuoc(thuoc.MaThuoc);
                    if (KQ=="OK")
                        this.DanhSachThuoc();
                    else
                        MessageBox.Show(this,KQ.ToString() , "Thông Báo !");                    
                }
            }
            else
            {
                MessageBox.Show(this, "Chưa chọn Thuốc !", "Error !");
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {            
            lblToday.Text = DateTimeConvert.FormatVN(DateTime.Now,"dd/MM/yyyy - h:m:s tt");
        }

        private void btn_TimKiemChiTietThuoc_Click(object sender, EventArgs e)
        {
            pnl_TimKiemChiTietThuoc.Visible = true;
            lv_DanhSachThuoc.Enabled = false;
            AddCBB_NhomThuoc_TkThuoc();
            AddCBB_NSX_TKThuoc();
            txt_MaThuoc_TKThuoc.Text = "";            
        }

        public void AddCBB_NhomThuoc_TkThuoc()
        {
            arrNT = busNT.GetAllNhomThuoc();
            if (arrNT != null)
            {
                cbb_NhomThuoc_TKThuoc.Items.Clear();
                cbb_NhomThuoc_TKThuoc.Items.Add("----- Tất cả -----");
                foreach (NhomThuoc NT in arrNT)
                {
                    cbb_NhomThuoc_TKThuoc.Items.Add(NT.TenNhom);
                }
            }
        }
        public void AddCBB_NSX_TKThuoc()
        {
            arrNSX = busNSX.GetAllNsx("");
            if (arrNSX != null)
            {
                cbb_NhaSanXuat_TKThuoc.Items.Clear();
                cbb_NhaSanXuat_TKThuoc.Items.Add("----- Tất cả -----");
                foreach (NhaSanXuat NSX in arrNSX)
                {
                    cbb_NhaSanXuat_TKThuoc.Items.Add(NSX.TenNSX);                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pnl_TimKiemChiTietThuoc.Visible = false;
            lv_DanhSachThuoc.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
            SearchThuoc();
            cbb_NhomThuoc_TKThuoc.SelectedIndex = -1;
            cbb_NhaSanXuat_TKThuoc.SelectedIndex = -1;
            pnl_TimKiemChiTietThuoc.Visible = false;
            lv_DanhSachThuoc.Enabled = true;
        }
        public void SearchThuoc()
        {
            int MaNhom=0;
            if (cbb_NhomThuoc_TKThuoc.SelectedIndex > 0) {
                NhomThuoc NT = (NhomThuoc)arrNT.ToArray()[cbb_NhomThuoc_TKThuoc.SelectedIndex-1];
                MaNhom = NT.MaNhom;
            }
            int MaNSX=0;
            if (cbb_NhaSanXuat_TKThuoc.SelectedIndex > 0)
            {
                NhaSanXuat NSX = (NhaSanXuat)arrNSX.ToArray()[cbb_NhaSanXuat_TKThuoc.SelectedIndex-1];
                MaNSX = NSX.MaNSX;
            }


            arrThuoc = busThuoc.TimKiemThuoc(txt_MaThuoc_TKThuoc.Text,MaNhom,MaNSX);
            if (arrThuoc != null)
            {
                lv_DanhSachThuoc.Items.Clear();
                int i = 1;
                foreach (Thuoc thuoc in arrThuoc)
                {
                    ListViewItem lVItem = new ListViewItem(i.ToString());
                    lVItem.SubItems.Add(thuoc.MaThuoc.ToString());
                    lVItem.SubItems.Add(thuoc.TenThuoc);
                    lVItem.SubItems.Add(thuoc.TenNhom);
                    lVItem.SubItems.Add(thuoc.NguonGoc);
                    lVItem.SubItems.Add(thuoc.TenNSX);
                    lVItem.SubItems.Add(thuoc.SoLuong.ToString());
                    lVItem.SubItems.Add(thuoc.TenDVT);
                    lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(thuoc.GiaBan)) + " VND");
                    lVItem.SubItems.Add(thuoc.Thue.ToString());
                    lVItem.SubItems.Add(thuoc.DangDongGoi_DVT);
                    lVItem.SubItems.Add(thuoc.SoLuongDongGoi.ToString());
                    lVItem.SubItems.Add(thuoc.SoDangKy);
                    lv_DanhSachThuoc.Items.Add(lVItem);
                    i++;
                }
            }
            else lv_DanhSachThuoc.Items.Clear();
        }

        private void txt_MaThuocHDN_DoubleClick(object sender, EventArgs e)
        {
            if (pnl_TimThuoc.Visible==false){
                pnl_TimThuoc.Visible=true;
                SearchThuocHDN();
            }
            else pnl_TimThuoc.Visible = false;
        }
    }
}