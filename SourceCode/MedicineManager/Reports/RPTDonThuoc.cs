using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using MedicineManager.DAO;
using MedicineManager.BUS;

namespace MedicineManager.Reports
{
    public partial class RPTDonThuoc : Form
    {

        private BusHDX busHDX;
        private int _MaHDX;
        public RPTDonThuoc(int _MaHDX)
        {
            InitializeComponent();
            busHDX = new BusHDX();
            this._MaHDX = _MaHDX;
        }

        private void RPTDonThuoc_Load(object sender, EventArgs e)
        {
            ReportDonThuoc1.SetDataSource(busHDX.GetDonThuocByMaHSX(this._MaHDX).Tables[0]);
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}