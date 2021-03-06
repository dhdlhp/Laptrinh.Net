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
    public partial class Login : Form
    {
        private BusCommon busCommon;
        private BusUser busUser;
        private User user; 
        public Login()
        {
            InitializeComponent();
            busCommon = new BusCommon();
            busUser = new BusUser();
            user = new User();

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Submit();
        }

        public void Submit()
        {
            if (!ValidateFrom.CheckEmty(txtUsername.Text))
            {
                txtUsername.Focus();
                MessageBox.Show(this, "UserName Invalid!");
            }
            else if (!ValidateFrom.CheckEmty(txtPassword.Text))
            {
                txtPassword.Focus();                
                MessageBox.Show(this, "Password Invalid!");
            }
            else
            {                
                User user = busUser.GetUser(txtUsername.Text,txtPassword.Text);
                if (user != null)
                {

                    if (radioButton1.Checked)
                    {
                        SystemLog systemLog = new SystemLog(user.IDUser, DateTime.Now.ToString(), "Đăng nhập vào quản lý");
                        busUser.SetSystemLog(systemLog);

                        QuanLy ql = new QuanLy(user);
                        ql.Visible = true;
                        this.Visible = false;
                    }
                    else if (radioButton2.Checked)
                    {
                        SystemLog systemLog = new SystemLog(user.IDUser, DateTime.Now.ToString(), "Đăng nhập vào kê đơn");
                        busUser.SetSystemLog(systemLog);

                        SellMedicine mm = new SellMedicine(user);
                        mm.Show();
                        this.Visible = false;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Not find user!");
                    txtUsername.Focus();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!busCommon.CheckConnectDB())
            {
                CreateConnectionDB createConnDB = new CreateConnectionDB();
                createConnDB.ShowDialog();
                this.Visible = false;
            }

        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}