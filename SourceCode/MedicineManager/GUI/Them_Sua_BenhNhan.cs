using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MedicineManager.BUS;
using MedicineManager.ENTITY;

namespace MedicineManager.GUI
{
    public partial class Them_Sua_BenhNhan : Form
    {
        private BusBenhNhan busBN;
        private string _lastMaBN;
        private int mode;
        private BenhNhan benhNhan;
        private int index;
        public delegate void dgBenhNhan(BenhNhan benhNhan, int index);
        public dgBenhNhan dgBN;
        public BusUser busUser;
        public Them_Sua_BenhNhan(BenhNhan benhNhan, int index, int mode)
        {
            InitializeComponent();
            busBN = new BusBenhNhan();
            this.benhNhan = benhNhan;
            this.mode = mode;
            this.index = index;
            busUser = new BusUser();
        }


        private void Them_Sua_BenhNhan_Load(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                // Them Benh Nhan
                btnThem.Text = "Thêm";
                BenhNhan lastBenhNhan = busBN.GetLastBenhNhan();

                if (lastBenhNhan != null)
                {
                    this._lastMaBN = lastBenhNhan.MaBN;
                }
                else
                {
                    this._lastMaBN = "BN_0_ABCD";
                }
            }
            else if (mode == 2)
            {
                btnThem.Text = "Cập nhật";
                txtMaBN.Text = benhNhan.MaBN;
                txtHoTen.Text = benhNhan.HoTen;
                txtTuoi.Text = benhNhan.Tuoi.ToString();
                txtDienThoai.Text = benhNhan.DienThoai;
                txtDiaChi.Text = benhNhan.DiaChi;
            }
        }

        public bool CheckFrom()
        {
            if (txtHoTen.Text.Equals(""))
            {
                MessageBox.Show(this, "Nhập Họ Tên!", "Thông báo");
                txtHoTen.Focus();
                return false;
            }
            else if (ValidateFrom.CheckNumber(txtTuoi.Text) == false)
            {
                MessageBox.Show(this, "Nhập Tuổi!\nChỉ được nhập số!", "Thông báo");
                txtTuoi.Focus();
                return false;
            }

            else if (txtDiaChi.Text.Equals(""))
            {
                MessageBox.Show(this, "Nhập địa chỉ!", "Thông báo");
                txtDiaChi.Focus();
                return false;
            }

            else if (ValidateFrom.CheckNumber(txtDienThoai.Text) == false)
            {
                MessageBox.Show(this, "Chưa nhập số điện thoại hoặc số không hợp lệ\nChỉ được nhập số!", "Thông báo");
                txtDienThoai.Focus();
                return false;
            }
            else
                return true;
        }
        
    

        private void button1_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                if (CheckFrom())
                {
                    BenhNhan benhNhan = new BenhNhan(txtMaBN.Text, txtHoTen.Text, Convert.ToInt32(txtTuoi.Text),txtDiaChi.Text,txtDienThoai.Text);
                    int i = busBN.InsertBenhNhan(benhNhan);
                    if (i > 0)
                    {
                        SystemLog systemLog = new SystemLog(SellMedicine.IDUser, DateTime.Now.ToString(), "Thêm bệnh nhân");
                        busUser.SetSystemLog(systemLog);
                        MessageBox.Show(this,"Thêm bệnh nhân thành công!","Thông báo");
                        BenhNhan lastBenhNhan = busBN.GetLastBenhNhan();
                        dgBN(lastBenhNhan, index);
                        this.Close();
                    }
                }
            }
            else if (mode == 2)
            {
                if (CheckFrom())
                {
                    BenhNhan benhNhan = new BenhNhan(this.benhNhan.IDBN, txtMaBN.Text, txtHoTen.Text, Convert.ToInt32(txtTuoi.Text), txtDiaChi.Text, txtDienThoai.Text);
                    int i = busBN.UpdateBenhNhan(benhNhan);
                    if (i > 0)
                    {
                        SystemLog systemLog = new SystemLog(SellMedicine.IDUser, DateTime.Now.ToString(), "Sửa thông tin bệnh nhân");
                        busUser.SetSystemLog(systemLog);
                        MessageBox.Show(this, "Sửa thông tin bệnh nhân thành công!", "Thông báo");
                        dgBN(benhNhan,index);
                        this.Close();
                    }
                }
            }
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int GetNumber(string str)
        {
            if (str.IndexOf("_") != -1)
            {
                str = str.Substring(str.IndexOf("_") + 1);
            }
            if (str.IndexOf("_") != -1)
            {
                str = str.Substring(0, str.IndexOf("_"));
            }
            int num = Convert.ToInt32(str);
            return num;
        }

        public void TaoMa(int num)
        {
            
            if (mode == 1)
            {
                num += 1;
            }
            string str = "BN_" + num + "_" + txtHoTen.Text + "";
            txtMaBN.Text = str;
        }

       

        private void txtHoTen_KeyUp(object sender, KeyEventArgs e)
        {
            if (mode == 1)
            {
                int i = GetNumber(this._lastMaBN);
                TaoMa(i);
            }
            else if (mode == 2)
            {
                int i = GetNumber(this.benhNhan.MaBN);
                TaoMa(i);
            }
        }
    }
}