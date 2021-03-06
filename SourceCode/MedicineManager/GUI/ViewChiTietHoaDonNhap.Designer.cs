namespace MedicineManager.GUI
{
    partial class ViewChiTietHoaDonNhap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_TenThuoc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_MaHDN = new System.Windows.Forms.Label();
            this.lbl_MaNPP = new System.Windows.Forms.Label();
            this.lbl_TenNPP = new System.Windows.Forms.Label();
            this.lbl_NguoiNhan = new System.Windows.Forms.Label();
            this.lbl_NguoiGiao = new System.Windows.Forms.Label();
            this.lbl_TienHang = new System.Windows.Forms.Label();
            this.lbl_Thue = new System.Windows.Forms.Label();
            this.lbl_TongTien = new System.Windows.Forms.Label();
            this.lbl_NgayViet = new System.Windows.Forms.Label();
            this.lbl_NgayNhap = new System.Windows.Forms.Label();
            this.lv_DanhSachCTHDN = new ListViewEx.ListViewEx();
            this.columnHeader55 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader56 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader57 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader58 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader59 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lbl_TenThuoc
            // 
            this.lbl_TenThuoc.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_TenThuoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TenThuoc.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenThuoc.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lbl_TenThuoc.Location = new System.Drawing.Point(0, 0);
            this.lbl_TenThuoc.Name = "lbl_TenThuoc";
            this.lbl_TenThuoc.Size = new System.Drawing.Size(645, 34);
            this.lbl_TenThuoc.TabIndex = 1;
            this.lbl_TenThuoc.Text = "Chi Tiết Hóa Đơn Nhập";
            this.lbl_TenThuoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(40, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Hóa Đơn :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(65, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã NPP :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(62, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên NPP :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(49, 107);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Người Giao :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(44, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Người Nhận :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(416, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Tiền Hàng :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(444, 61);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Thuế :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(416, 84);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Tổng Tiền :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(419, 107);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Ngày Viết :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(411, 130);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Ngày Nhập :";
            // 
            // lbl_MaHDN
            // 
            this.lbl_MaHDN.AutoSize = true;
            this.lbl_MaHDN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaHDN.ForeColor = System.Drawing.Color.Black;
            this.lbl_MaHDN.Location = new System.Drawing.Point(128, 38);
            this.lbl_MaHDN.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_MaHDN.Name = "lbl_MaHDN";
            this.lbl_MaHDN.Size = new System.Drawing.Size(19, 15);
            this.lbl_MaHDN.TabIndex = 12;
            this.lbl_MaHDN.Text = "---";
            // 
            // lbl_MaNPP
            // 
            this.lbl_MaNPP.AutoSize = true;
            this.lbl_MaNPP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MaNPP.ForeColor = System.Drawing.Color.Black;
            this.lbl_MaNPP.Location = new System.Drawing.Point(128, 61);
            this.lbl_MaNPP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_MaNPP.Name = "lbl_MaNPP";
            this.lbl_MaNPP.Size = new System.Drawing.Size(19, 15);
            this.lbl_MaNPP.TabIndex = 13;
            this.lbl_MaNPP.Text = "---";
            // 
            // lbl_TenNPP
            // 
            this.lbl_TenNPP.AutoSize = true;
            this.lbl_TenNPP.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNPP.ForeColor = System.Drawing.Color.Black;
            this.lbl_TenNPP.Location = new System.Drawing.Point(128, 84);
            this.lbl_TenNPP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_TenNPP.Name = "lbl_TenNPP";
            this.lbl_TenNPP.Size = new System.Drawing.Size(19, 15);
            this.lbl_TenNPP.TabIndex = 14;
            this.lbl_TenNPP.Text = "---";
            // 
            // lbl_NguoiNhan
            // 
            this.lbl_NguoiNhan.AutoSize = true;
            this.lbl_NguoiNhan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NguoiNhan.ForeColor = System.Drawing.Color.Black;
            this.lbl_NguoiNhan.Location = new System.Drawing.Point(128, 130);
            this.lbl_NguoiNhan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_NguoiNhan.Name = "lbl_NguoiNhan";
            this.lbl_NguoiNhan.Size = new System.Drawing.Size(19, 15);
            this.lbl_NguoiNhan.TabIndex = 15;
            this.lbl_NguoiNhan.Text = "---";
            // 
            // lbl_NguoiGiao
            // 
            this.lbl_NguoiGiao.AutoSize = true;
            this.lbl_NguoiGiao.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NguoiGiao.ForeColor = System.Drawing.Color.Black;
            this.lbl_NguoiGiao.Location = new System.Drawing.Point(128, 107);
            this.lbl_NguoiGiao.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_NguoiGiao.Name = "lbl_NguoiGiao";
            this.lbl_NguoiGiao.Size = new System.Drawing.Size(19, 15);
            this.lbl_NguoiGiao.TabIndex = 16;
            this.lbl_NguoiGiao.Text = "---";
            // 
            // lbl_TienHang
            // 
            this.lbl_TienHang.AutoSize = true;
            this.lbl_TienHang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TienHang.ForeColor = System.Drawing.Color.Black;
            this.lbl_TienHang.Location = new System.Drawing.Point(491, 38);
            this.lbl_TienHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_TienHang.Name = "lbl_TienHang";
            this.lbl_TienHang.Size = new System.Drawing.Size(19, 15);
            this.lbl_TienHang.TabIndex = 17;
            this.lbl_TienHang.Text = "---";
            // 
            // lbl_Thue
            // 
            this.lbl_Thue.AutoSize = true;
            this.lbl_Thue.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Thue.ForeColor = System.Drawing.Color.Black;
            this.lbl_Thue.Location = new System.Drawing.Point(491, 61);
            this.lbl_Thue.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_Thue.Name = "lbl_Thue";
            this.lbl_Thue.Size = new System.Drawing.Size(19, 15);
            this.lbl_Thue.TabIndex = 18;
            this.lbl_Thue.Text = "---";
            // 
            // lbl_TongTien
            // 
            this.lbl_TongTien.AutoSize = true;
            this.lbl_TongTien.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TongTien.ForeColor = System.Drawing.Color.Black;
            this.lbl_TongTien.Location = new System.Drawing.Point(491, 84);
            this.lbl_TongTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_TongTien.Name = "lbl_TongTien";
            this.lbl_TongTien.Size = new System.Drawing.Size(19, 15);
            this.lbl_TongTien.TabIndex = 19;
            this.lbl_TongTien.Text = "---";
            // 
            // lbl_NgayViet
            // 
            this.lbl_NgayViet.AutoSize = true;
            this.lbl_NgayViet.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgayViet.ForeColor = System.Drawing.Color.Black;
            this.lbl_NgayViet.Location = new System.Drawing.Point(491, 107);
            this.lbl_NgayViet.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_NgayViet.Name = "lbl_NgayViet";
            this.lbl_NgayViet.Size = new System.Drawing.Size(19, 15);
            this.lbl_NgayViet.TabIndex = 20;
            this.lbl_NgayViet.Text = "---";
            // 
            // lbl_NgayNhap
            // 
            this.lbl_NgayNhap.AutoSize = true;
            this.lbl_NgayNhap.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NgayNhap.ForeColor = System.Drawing.Color.Black;
            this.lbl_NgayNhap.Location = new System.Drawing.Point(491, 130);
            this.lbl_NgayNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbl_NgayNhap.Name = "lbl_NgayNhap";
            this.lbl_NgayNhap.Size = new System.Drawing.Size(19, 15);
            this.lbl_NgayNhap.TabIndex = 21;
            this.lbl_NgayNhap.Text = "---";
            // 
            // lv_DanhSachCTHDN
            // 
            this.lv_DanhSachCTHDN.AllowColumnReorder = true;
            this.lv_DanhSachCTHDN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader55,
            this.columnHeader56,
            this.columnHeader57,
            this.columnHeader58,
            this.columnHeader59});
            this.lv_DanhSachCTHDN.DoubleClickActivation = true;
            this.lv_DanhSachCTHDN.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_DanhSachCTHDN.FullRowSelect = true;
            this.lv_DanhSachCTHDN.GridLines = true;
            this.lv_DanhSachCTHDN.Location = new System.Drawing.Point(5, 152);
            this.lv_DanhSachCTHDN.Name = "lv_DanhSachCTHDN";
            this.lv_DanhSachCTHDN.Size = new System.Drawing.Size(631, 207);
            this.lv_DanhSachCTHDN.TabIndex = 22;
            this.lv_DanhSachCTHDN.UseCompatibleStateImageBehavior = false;
            this.lv_DanhSachCTHDN.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader55
            // 
            this.columnHeader55.Text = "STT";
            this.columnHeader55.Width = 40;
            // 
            // columnHeader56
            // 
            this.columnHeader56.Text = "Mã Thuốc";
            this.columnHeader56.Width = 230;
            // 
            // columnHeader57
            // 
            this.columnHeader57.Text = "Số Lượng";
            this.columnHeader57.Width = 110;
            // 
            // columnHeader58
            // 
            this.columnHeader58.Text = "Giá Nhập";
            this.columnHeader58.Width = 110;
            // 
            // columnHeader59
            // 
            this.columnHeader59.Text = "Thành Tiền";
            this.columnHeader59.Width = 120;
            // 
            // ViewChiTietHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(645, 364);
            this.Controls.Add(this.lv_DanhSachCTHDN);
            this.Controls.Add(this.lbl_NgayNhap);
            this.Controls.Add(this.lbl_NgayViet);
            this.Controls.Add(this.lbl_TongTien);
            this.Controls.Add(this.lbl_Thue);
            this.Controls.Add(this.lbl_TienHang);
            this.Controls.Add(this.lbl_NguoiGiao);
            this.Controls.Add(this.lbl_NguoiNhan);
            this.Controls.Add(this.lbl_TenNPP);
            this.Controls.Add(this.lbl_MaNPP);
            this.Controls.Add(this.lbl_MaHDN);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_TenThuoc);
            this.Controls.Add(this.label1);
            this.Name = "ViewChiTietHoaDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChiTietHoaDonNhap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TenThuoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_MaHDN;
        private System.Windows.Forms.Label lbl_MaNPP;
        private System.Windows.Forms.Label lbl_TenNPP;
        private System.Windows.Forms.Label lbl_NguoiNhan;
        private System.Windows.Forms.Label lbl_NguoiGiao;
        private System.Windows.Forms.Label lbl_TienHang;
        private System.Windows.Forms.Label lbl_Thue;
        private System.Windows.Forms.Label lbl_TongTien;
        private System.Windows.Forms.Label lbl_NgayViet;
        private System.Windows.Forms.Label lbl_NgayNhap;
        private ListViewEx.ListViewEx lv_DanhSachCTHDN;
        private System.Windows.Forms.ColumnHeader columnHeader55;
        private System.Windows.Forms.ColumnHeader columnHeader56;
        private System.Windows.Forms.ColumnHeader columnHeader57;
        private System.Windows.Forms.ColumnHeader columnHeader58;
        private System.Windows.Forms.ColumnHeader columnHeader59;
    }
}