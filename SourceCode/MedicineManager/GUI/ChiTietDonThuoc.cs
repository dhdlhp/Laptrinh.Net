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
    public partial class ChiTietDonThuoc : Form
    {

        private BusBenhNhan busBenhNhan;
        private BusHDX busHDX;
        private HoaDonXuat hdx;
        private BenhNhan benhNhan;
        public ChiTietDonThuoc(HoaDonXuat hdx)
        {
            InitializeComponent();
            busBenhNhan = new BusBenhNhan();
            busHDX = new BusHDX();
            this.hdx = hdx;
        }

        private void ChiTietDonThuoc_Load(object sender, EventArgs e)
        {
            lblMaDonThuoc.Text = hdx.MaHDX.ToString();
            lblNgayLap.Text = DateTimeConvert.FormatVN(hdx.NgayLap, "dd/MM/yyyy");
            lblTienThuoc.Text = String.Format("{0:0,0}", Convert.ToInt32(hdx.TongTienThuoc)) + " VND";
            lblTienThue.Text = hdx.TongThue.ToString();
            lblTienHoaDon.Text = String.Format("{0:0,0}", Convert.ToInt32(hdx.TongTienHD)) + " VND";
            
            benhNhan = busBenhNhan.GetBenhNhanDetails(hdx.MaBN);
            lblMaBN_DT.Text = benhNhan.MaBN;
            lblTenBN_DT.Text = benhNhan.HoTen;
            lblTuoiBN_DT.Text = benhNhan.Tuoi.ToString();
            lblSoDienThoaiBN_DT.Text = benhNhan.DienThoai;
            lblDiaChiBN_DT.Text = benhNhan.DiaChi;

            ArrayList arrChiTietHDX = busHDX.GetAllChiTietHDX(hdx.MaHDX);
            foreach (ChiTietHoaDonXuat chiTietHDX in arrChiTietHDX)
            {
                ListViewItem lVItem = new ListViewItem(chiTietHDX.TenThuoc);
                lVItem.SubItems.Add(chiTietHDX.SoLuong.ToString());
                lVItem.SubItems.Add(String.Format("{0:0,0}", Convert.ToInt32(chiTietHDX.GiaBan)) + " VND");
                lVItem.SubItems.Add(chiTietHDX.Thue.ToString());
                lVItem.SubItems.Add(chiTietHDX.DonVi);
                lVDanhSachChiTietHDX.Items.Add(lVItem);
            }
        }
    }
}