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

namespace MedicineManager.GUI
{
    public partial class ViewChiTietHoaDonNhap : Form
    {
        private HoaDonNhap HDN;
        private BusHDN busHDN;
        public ViewChiTietHoaDonNhap(HoaDonNhap HDN)
        {
            this.HDN = HDN;
            busHDN = new BusHDN();
            InitializeComponent();
            ViewForm();
        }

        public void ViewForm() {

            lbl_MaHDN.Text = HDN.MaHDN.ToString();
            lbl_MaNPP.Text = HDN.MaNPP.ToString();
            lbl_NgayNhap.Text = DateTimeConvert.FormatVN(HDN.NgayViet, "dd/MM/yyyy");
            lbl_NgayViet.Text = DateTimeConvert.FormatVN(HDN.NgayNhap, "dd/MM/yyyy");
            lbl_NguoiGiao.Text = HDN.NguoiGiao;
            lbl_NguoiNhan.Text = HDN.NguoiNhan;
            lbl_TenNPP.Text = HDN.TenNPP;
            lbl_Thue.Text = HDN.TongThue.ToString() + " %";
            lbl_TienHang.Text = String.Format("{0:0,0}", Convert.ToInt32(HDN.TongTienThuoc)) + " VND";
            lbl_TongTien.Text = String.Format("{0:0,0}", Convert.ToInt32(HDN.TongTienHD)) + " VND";

            ArrayList arrCTHDN = busHDN.GetAllChiTietHDN(HDN.MaHDN);
            int i = 1;
            foreach (ChiTietHoaDonNhap CTHDN in arrCTHDN)
            {
                ListViewItem lVItem = new ListViewItem(i.ToString());
                lVItem.SubItems.Add(CTHDN.MaThuoc.ToString());
                lVItem.SubItems.Add(CTHDN.SoLuong.ToString());
                lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(CTHDN.GiaNhap)) + " VND");
                Decimal ThanhTien = CTHDN.SoLuong * CTHDN.GiaNhap;
                lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(ThanhTien)) + " VND");                
                lv_DanhSachCTHDN.Items.Add(lVItem);
                i++;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }        
    }
}