using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using MedicineManager.BUS;

namespace MedicineManager.GUI
{
    public partial class CreateConnectionDB : Form
    {
        public CreateConnectionDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtServer.Text.Equals("") || txtDatabase.Text.Equals("") || txtUser.Text.Equals("") || txtPass.Text.Equals(""))
            {
                MessageBox.Show("Data cannot empty!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string xmlPath = "Config.xml";
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ServerName", System.Type.GetType("System.String"));
                    dt.Columns.Add("Database", System.Type.GetType("System.String"));
                    dt.Columns.Add("UserName", System.Type.GetType("System.String"));
                    dt.Columns.Add("PassWord", System.Type.GetType("System.String"));
                    ds.Tables.Add(dt);
                    DataRow dr = ds.Tables[0].NewRow();
                    dr["ServerName"] = txtServer.Text;
                    dr["Database"] = txtDatabase.Text;
                    dr["UserName"] = txtUser.Text;
                    dr["PassWord"] = txtPass.Text;
                    dt.Rows.Add(dr);
                    ds.WriteXml(xmlPath);
                    BusCommon busCommon = new BusCommon();
                    if (busCommon.CheckConnectDB())
                    {
                        MessageBox.Show(this, "Create Server successful!", "Create Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show(this, "Create Server faill!", "Create Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show(this,"File Config.xml doesn't exist!", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}