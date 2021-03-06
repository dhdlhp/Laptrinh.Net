using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MedicineManager.Reports;
using MedicineManager.ENTITY;
using System.Collections;
using MedicineManager.BUS;

namespace MedicineManager.GUI
{
    public partial class SuLyInDonThuoc : Form
    {
        public delegate void dgDonThuoc(bool b);
        public dgDonThuoc dgDT;
        private HoaDonXuat hdx;
        private ArrayList arrList;
        private BusHDX busHDX;
        private BusUser busUser;
        public SuLyInDonThuoc(HoaDonXuat hdx,ArrayList arrList)
        {
            InitializeComponent();
            busHDX = new BusHDX();
            this.hdx = hdx;
            this.arrList = arrList;
            busUser = new BusUser();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dgDT(false);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            bool flag = busHDX.TaoHoaDonXuat(hdx, arrList);
            SystemLog systemLog = new SystemLog(SellMedicine.IDUser, DateTime.Now.ToString(), "Tạo đơn thuốc");
            busUser.SetSystemLog(systemLog);
            if (flag)
            {
                HoaDonXuat hdxTemp = busHDX.GetLastHoaDonXuat();
                RPTDonThuoc rptDT = new RPTDonThuoc(hdxTemp.MaHDX);
                rptDT.ShowDialog();
                dgDT(flag);
                this.Close();
            }
        }

    }
}