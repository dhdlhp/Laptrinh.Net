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
    public partial class ChiTietThuoc : Form
    {
        private Thuoc thuocCurent;
        private BusThuoc busThuoc;
        private BusNhomThuoc busNT;
        private BusNSX busNSX;
        private BusDVT busDVT;
        private int type;
        public ChiTietThuoc(Thuoc thuoc,int type)
        {
            this.thuocCurent = thuoc;
            this.type = type;
            busThuoc = new BusThuoc();
            busNT = new BusNhomThuoc();
            busNSX = new BusNSX();
            busDVT = new BusDVT();
            InitializeComponent();
            DanhSachNhomThuoc();
            DanhSachNSX();
            DanhSachDVT();
            DanhSachDongGoi();

            if (type == 2)
            {
                ViewForm();
                btn_ThemThuoc.Visible = false;
            }
            else
                btn_CapNhap.Visible = false;
            txt_TenThuoc.Focus();
            
        }


        ArrayList arrNT = new ArrayList();

        public void DanhSachNhomThuoc()
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

        ArrayList arrNSX = new ArrayList();

        public void DanhSachNSX()
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

        ArrayList arrDVT = new ArrayList();

        public void DanhSachDVT()
        {
            arrDVT = busDVT.GetAllDvt();
            if (arrDVT != null)
            {
                cbb_DonViTinh.Items.Clear();
                foreach (DonViTinh DVT in arrDVT)
                {                    
                    cbb_DonViTinh.Items.Add(DVT.Ten);
                }
            }
        }

        ArrayList arrDG = new ArrayList();

        public void DanhSachDongGoi()
        {
            arrDG = busDVT.GetAllDvt();
            if (arrDG != null)
            {
                cbb_DangDongGoi.Items.Clear();
                foreach (DonViTinh DG in arrDG)
                {                    
                    cbb_DangDongGoi.Items.Add(DG.Ten);
                }
            }
        }

        public void ViewForm() {
            txt_TenThuoc.Text = thuocCurent.TenThuoc;
            cbb_DonViTinh.SelectedItem = thuocCurent.TenDVT;
            cbb_NhaSanXuat.SelectedItem = thuocCurent.TenNSX;
            cbb_DangDongGoi.SelectedItem = thuocCurent.DangDongGoi_DVT;
            cbb_NhomThuoc.SelectedItem = thuocCurent.TenNhom;
            lbl_TenThuoc.Text = thuocCurent.TenThuoc;
            txt_BaoQuan.Text = thuocCurent.BaoQuan;
            txt_CachDung.Text = thuocCurent.CachDung;
            txt_Chuy.Text = thuocCurent.ChuY;
            txt_CongDung.Text = thuocCurent.CongDung;
            txt_DangBaoChe.Text = thuocCurent.DangBaoChe;
            txt_HamLuong.Text = thuocCurent.HamLuong;
            txt_HanSuDung.Text = thuocCurent.HanSuDung;
            txt_NguonGoc.Text = thuocCurent.NguonGoc;
            txt_PhanTacDung.Text = thuocCurent.PhanTacDung;
            txt_SoDangKy.Text = thuocCurent.SoDangKy;
            txt_ThanhPhan.Text = thuocCurent.ThanhPhan;
            numUDLuongDongGoi.Value = thuocCurent.SoLuongDongGoi;
            numUD_SoLuong.Value = thuocCurent.SoLuong;
            txt_Thue.Text = thuocCurent.Thue.ToString();
            txt_GiaBan.Text = thuocCurent.GiaBan.ToString();
        }

        
        private void btn_CapNhap_Click(object sender, EventArgs e)
        {
            thuocCurent.NguonGoc = txt_NguonGoc.Text;
            thuocCurent.DangBaoChe = txt_DangBaoChe.Text;
            thuocCurent.SoLuongDongGoi = Convert.ToInt32(numUDLuongDongGoi.Value);
            thuocCurent.SoDangKy = txt_SoDangKy.Text;
            thuocCurent.ThanhPhan = txt_ThanhPhan.Text;
            thuocCurent.HamLuong = txt_HamLuong.Text;
            thuocCurent.PhanTacDung = txt_PhanTacDung.Text;
            thuocCurent.CongDung = txt_CongDung.Text;
            thuocCurent.CachDung = txt_CachDung.Text;
            thuocCurent.BaoQuan = txt_BaoQuan.Text;
            thuocCurent.HanSuDung = txt_HanSuDung.Text;
            thuocCurent.ChuY = txt_Chuy.Text;
            thuocCurent.SoLuong = Convert.ToInt32(numUD_SoLuong.Value);
            if (cbb_NhomThuoc.SelectedIndex == -1) {
                MessageBox.Show(this, "Chọn nhóm thuốc !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbb_NhaSanXuat.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn Nhà sản xuất !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbb_DonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn Đơn Vị Tính !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbb_DangDongGoi.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn dạng đóng gói !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (txt_TenThuoc.Text == "")
            {
                MessageBox.Show(this, "Nhập Tên Thuốc !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TenThuoc.Focus();
            }
            else if (txt_GiaBan.Text == "")
            {
                MessageBox.Show(this, "Nhập Giá Bán !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_GiaBan.Focus();
            }
            else if ((txt_GiaBan.Text != "") &&(!ValidateFrom.CheckNumber(txt_GiaBan.Text)))
            {
                MessageBox.Show(this, "Giá nhập phải là số !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_GiaBan.Focus();
            }
            else if ((txt_Thue.Text != "") && (!ValidateFrom.CheckNumber(txt_Thue.Text)))
            {
                MessageBox.Show(this, "Thuế phải là số !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Thue.Focus();
            }
            else
            {
                thuocCurent.TenThuoc = txt_TenThuoc.Text;
                thuocCurent.MaThuoc = thuocCurent.MaThuoc.Substring(0, 8) + thuocCurent.TenThuoc;
                thuocCurent.GiaBan = Convert.ToDecimal(txt_GiaBan.Text);
                if (txt_Thue.Text == "")
                {
                    thuocCurent.Thue = 0;
                }
                CapNhapThuoc();
            }
        }

        public void CapNhapThuoc() {
            if (busThuoc.UpdateThuoc(thuocCurent)){
                MessageBox.Show(this, "Cập nhập thành công !", "Thông báo");
            }
            else {
                MessageBox.Show(this, "Không được !", "Thông báo");
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbb_NhomThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_NhomThuoc.SelectedIndex > -1)
            {
                NhomThuoc NT = (NhomThuoc)arrNT.ToArray()[cbb_NhomThuoc.SelectedIndex];
                thuocCurent.MaNhom = NT.MaNhom;
            }            
        }

        private void cbb_NhaSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_NhaSanXuat.SelectedIndex > -1)
            {
                NhaSanXuat NSX = (NhaSanXuat)arrNSX.ToArray()[cbb_NhaSanXuat.SelectedIndex];
                thuocCurent.MaNSX = NSX.MaNSX;
            }            
        }

        private void cbb_DonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_DonViTinh.SelectedIndex > -1)
            {
                DonViTinh DVT = (DonViTinh)arrDVT.ToArray()[cbb_DonViTinh.SelectedIndex];
                thuocCurent.MaDVT = DVT.MaDVT;
            }           
        }

        private void cbb_DangDongGoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_DangDongGoi.SelectedIndex > -1)
            {
                DonViTinh DG = (DonViTinh)arrDG.ToArray()[cbb_DangDongGoi.SelectedIndex];
                thuocCurent.DangDongGoi = DG.MaDVT;
            }            
        }

        private void btn_ThemThuoc_Click(object sender, EventArgs e)
        {
            thuocCurent.NguonGoc = txt_NguonGoc.Text;
            thuocCurent.DangBaoChe = txt_DangBaoChe.Text;
            thuocCurent.SoLuongDongGoi = Convert.ToInt32(numUDLuongDongGoi.Value);
            thuocCurent.SoDangKy = txt_SoDangKy.Text;
            thuocCurent.ThanhPhan = txt_ThanhPhan.Text;
            thuocCurent.HamLuong = txt_HamLuong.Text;
            thuocCurent.PhanTacDung = txt_PhanTacDung.Text;
            thuocCurent.CongDung = txt_CongDung.Text;
            thuocCurent.CachDung = txt_CachDung.Text;
            thuocCurent.BaoQuan = txt_BaoQuan.Text;
            thuocCurent.HanSuDung = txt_HanSuDung.Text;
            thuocCurent.ChuY = txt_Chuy.Text;
            thuocCurent.SoLuong = Convert.ToInt32(numUD_SoLuong.Value);
            if (cbb_NhomThuoc.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn nhóm thuốc !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbb_NhaSanXuat.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn Nhà sản xuất !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbb_DonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn Đơn Vị Tính !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cbb_DangDongGoi.SelectedIndex == -1)
            {
                MessageBox.Show(this, "Chọn dạng đóng gói !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_TenThuoc.Text == "")
            {
                MessageBox.Show(this, "Nhập Tên Thuốc !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_TenThuoc.Focus();
            }
            else if (txt_GiaBan.Text == "")
            {
                MessageBox.Show(this, "Nhập Giá Bán !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_GiaBan.Focus();
            }
            else if ((txt_GiaBan.Text != "") && (!ValidateFrom.CheckNumber(txt_GiaBan.Text)))
            {
                MessageBox.Show(this, "Giá nhập phải là số !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_GiaBan.Focus();
            }
            else if ((txt_Thue.Text != "") && (!ValidateFrom.CheckNumber(txt_Thue.Text)))
            {
                MessageBox.Show(this, "Thuế phải là số !", "Thông Báo ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Thue.Focus();
            }
            else
            {
                thuocCurent.TenThuoc = txt_TenThuoc.Text;                
                thuocCurent.GiaBan = Convert.ToDecimal(txt_GiaBan.Text);
                if (txt_Thue.Text == "")
                {
                    thuocCurent.Thue = 0;
                }
                ThemThuoc();
            }
        }
        public void ThemThuoc()
        {
            if (busThuoc.InsertThuoc(thuocCurent))
            {
                MessageBox.Show(this, "Thêm thành công !", "Thông báo");
                ResetForm();
            }
            else
            {
                MessageBox.Show(this, "Không thêm được !", "Thông báo");
            }
        }

        public void ResetForm() {
            txt_TenThuoc.Text = "";
            cbb_DonViTinh.SelectedIndex = -1;
            cbb_NhaSanXuat.SelectedItem = -1;
            cbb_DangDongGoi.SelectedItem = -1;
            cbb_NhomThuoc.SelectedItem = -1;
            txt_BaoQuan.Text = "";
            txt_CachDung.Text = "";
            txt_Chuy.Text = "";
            txt_CongDung.Text = "";
            txt_DangBaoChe.Text = "";
            txt_HamLuong.Text = "";
            txt_HanSuDung.Text = "";
            txt_NguonGoc.Text = "";
            txt_PhanTacDung.Text = "";
            txt_SoDangKy.Text = "";
            txt_ThanhPhan.Text = "";
            numUDLuongDongGoi.Value = 0;
            numUD_SoLuong.Value = 0;
            txt_Thue.Text = "";
            txt_GiaBan.Text = "";
        }

        private void ChiTietThuoc_Load(object sender, EventArgs e)
        {
            txt_TenThuoc.Focus();
        }
        
    }
}