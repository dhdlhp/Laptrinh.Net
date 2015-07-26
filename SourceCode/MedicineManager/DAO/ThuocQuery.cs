using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.ENTITY;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MedicineManager.DAO
{

    class ThuocQuery
    {
        private DBHelper dbHelper;
        public ThuocQuery()
        {
            dbHelper = new DBHelper();
        }

        public ArrayList SelectAllThuoc(string _TenThuoc)
        {
            _TenThuoc = _TenThuoc.Replace("'", "''");
            SqlDataReader rd = dbHelper.ExecuteQuery("GetThuocBYTenThuoc N'%" + _TenThuoc + "%'");
            ArrayList arrLThuoc = new ArrayList();
            while (rd.Read())
            {
                Thuoc thuoc = new Thuoc(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetInt32(6), rd.GetDouble(7), rd.GetDecimal(8), rd.GetString(9), rd.GetString(10), rd.GetInt32(11), rd.GetString(12), rd.GetString(13), rd.GetString(14), rd.GetString(15), rd.GetString(16), rd.GetString(17), rd.GetString(18), rd.GetString(19), rd.GetString(20), rd.GetString(21));
                arrLThuoc.Add(thuoc);
            }
            rd.Close();
            return arrLThuoc;
        }

        public Thuoc SelectThuocDetails(int _IDThuoc)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("GetThuocDetails "+_IDThuoc+"");
            if (rd.Read())
            {
                Thuoc thuoc = new Thuoc(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetInt32(6), rd.GetDouble(7), rd.GetDecimal(8), rd.GetString(9), rd.GetString(10), rd.GetInt32(11), rd.GetString(12), rd.GetString(13), rd.GetString(14), rd.GetString(15), rd.GetString(16), rd.GetString(17), rd.GetString(18), rd.GetString(19), rd.GetString(20), rd.GetString(21));
                rd.Close();
                return thuoc;
            }
            else
            {
                rd.Close();
                return null;
            }
        }


        
        public ArrayList SelectAllThuoc2(string _TenThuoc)
        {

            SqlDataReader rd = dbHelper.ExecuteQuery("GetThuocBYTenThuoc_Hungnc N'%" + _TenThuoc.Replace("'", "''") + "%'");
            ArrayList arrLThuoc = new ArrayList();
            while (rd.Read())
            {
                Thuoc thuoc = new Thuoc(rd.GetInt32(0),rd.GetString(1), rd.GetString(2),rd.GetInt32(22),rd.GetString(3),rd.GetString(4),rd.GetInt32(23),rd.GetString(5),rd.GetInt32(6),rd.GetDouble(7),rd.GetDecimal(8),
rd.GetInt32(24), rd.GetString(9),rd.GetInt32(25),  rd.GetString(10), rd.GetInt32(11), rd.GetString(12), rd.GetString(13), rd.GetString(14),
rd.GetString(15), rd.GetString(16), rd.GetString(17), rd.GetString(18), rd.GetString(19), rd.GetString(20), rd.GetString(21));               
                arrLThuoc.Add(thuoc);
            }
            rd.Close();
            return arrLThuoc;
        }
        
        public Thuoc SelectThuocDetails2(string _MaThuoc)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("GetThuocDetails_Hungnc N'" + _MaThuoc.Replace("'", "''") + "'");
            if (rd.Read())
            {
                Thuoc thuoc = new Thuoc(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(22), rd.GetString(3), rd.GetString(4), rd.GetInt32(23), rd.GetString(5), rd.GetInt32(6), rd.GetDouble(7), rd.GetDecimal(8),
rd.GetInt32(24), rd.GetString(9), rd.GetInt32(25), rd.GetString(10), rd.GetInt32(11), rd.GetString(12), rd.GetString(13), rd.GetString(14),
rd.GetString(15), rd.GetString(16), rd.GetString(17), rd.GetString(18), rd.GetString(19), rd.GetString(20), rd.GetString(21));
                rd.Close();
                return thuoc;
            }
            else
            {
                rd.Close();
                return null;
            }
        }

        
        public int UpdateThuoc(Thuoc thuoc) {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@IDThuoc", SqlDbType.Int);
            param.Value = thuoc.IDThuoc;
            paramList.Add(param);
            param = new SqlParameter("@MaThuoc", SqlDbType.NVarChar);
            param.Value = thuoc.MaThuoc.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@TenThuoc", SqlDbType.NVarChar);
            param.Value = thuoc.TenThuoc.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@MaNhom", SqlDbType.Int);
            param.Value = thuoc.MaNhom;
            paramList.Add(param);
            param = new SqlParameter("@NguonGoc", SqlDbType.NVarChar);
            param.Value = thuoc.NguonGoc.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@MaNSX", SqlDbType.Int);
            param.Value = thuoc.MaNSX;
            paramList.Add(param);
            param = new SqlParameter("@SoLuong", SqlDbType.Int);
            param.Value = thuoc.SoLuong;
            paramList.Add(param);
            param = new SqlParameter("@Thue", SqlDbType.Float);
            param.Value = thuoc.Thue;
            paramList.Add(param);
            param = new SqlParameter("@GiaBan", SqlDbType.Money);
            param.Value = thuoc.GiaBan;
            paramList.Add(param);
            param = new SqlParameter("@MaDVT", SqlDbType.Int);
            param.Value = thuoc.MaDVT;
            paramList.Add(param);
            param = new SqlParameter("@DangDongGoi", SqlDbType.Int);
            param.Value = thuoc.DangDongGoi;
            paramList.Add(param);
            param = new SqlParameter("@SoLuongDongGoi", SqlDbType.Int);
            param.Value = thuoc.SoLuongDongGoi;
            paramList.Add(param);
            param = new SqlParameter("@SoDangKy", SqlDbType.NVarChar);
            param.Value = thuoc.SoDangKy.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@DangBaoChe", SqlDbType.NVarChar);
            param.Value = thuoc.DangBaoChe.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@ThanhPhan", SqlDbType.NVarChar);
            param.Value = thuoc.ThanhPhan.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@HamLuong", SqlDbType.NVarChar);
            param.Value = thuoc.HamLuong.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@CongDung", SqlDbType.NVarChar);
            param.Value = thuoc.CongDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@PhanTacDung", SqlDbType.NVarChar);
            param.Value = thuoc.PhanTacDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@CachDung", SqlDbType.NVarChar);
            param.Value = thuoc.CachDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@ChuY", SqlDbType.NVarChar);
            param.Value = thuoc.ChuY.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@HanSuDung", SqlDbType.NVarChar);
            param.Value = thuoc.HanSuDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@BaoQuan", SqlDbType.NVarChar);
            param.Value = thuoc.BaoQuan.Replace("'", "''");
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("UpdateThuoc", paramList);
            return i;
        }
        
        
        public int InsertThuoc(Thuoc thuoc)
        {            
            String MaThuoc = "";

            SqlDataReader rd = dbHelper.ExecuteQuery("GetThuocLast");
            if (rd.Read())
            {
                MaThuoc = rd.GetString(0);
            }
            rd.Close();
            int index = Convert.ToInt32(MaThuoc.Substring(3, 4));
            index++;
            String text = "";
            if (index > 999)
                text = "MT_";
            else if (index > 99)
                text = "MT_0";
            else if (index>9)
                text = "MT_00";
            else 
                text = "MT_000";
            thuoc.MaThuoc = text + index.ToString()+"_"+thuoc.TenThuoc;
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaThuoc", SqlDbType.NVarChar);
            param.Value = thuoc.MaThuoc.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@TenThuoc", SqlDbType.NVarChar);
            param.Value = thuoc.TenThuoc.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@MaNhom", SqlDbType.Int);
            param.Value = thuoc.MaNhom;
            paramList.Add(param);
            param = new SqlParameter("@NguonGoc", SqlDbType.NVarChar);
            param.Value = thuoc.NguonGoc.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@MaNSX", SqlDbType.Int);
            param.Value = thuoc.MaNSX;
            paramList.Add(param);
            param = new SqlParameter("@SoLuong", SqlDbType.Int);
            param.Value = thuoc.SoLuong;
            paramList.Add(param);
            param = new SqlParameter("@Thue", SqlDbType.Float);
            param.Value = thuoc.Thue;
            paramList.Add(param);
            param = new SqlParameter("@GiaBan", SqlDbType.Money);
            param.Value = thuoc.GiaBan;
            paramList.Add(param);
            param = new SqlParameter("@MaDVT", SqlDbType.Int);
            param.Value = thuoc.MaDVT;
            paramList.Add(param);
            param = new SqlParameter("@DangDongGoi", SqlDbType.Int);
            param.Value = thuoc.DangDongGoi;
            paramList.Add(param);
            param = new SqlParameter("@SoLuongDongGoi", SqlDbType.Int);
            param.Value = thuoc.SoLuongDongGoi;
            paramList.Add(param);
            param = new SqlParameter("@SoDangKy", SqlDbType.NVarChar);
            param.Value = thuoc.SoDangKy.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@DangBaoChe", SqlDbType.NVarChar);
            param.Value = thuoc.DangBaoChe.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@ThanhPhan", SqlDbType.NVarChar);
            param.Value = thuoc.ThanhPhan.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@HamLuong", SqlDbType.NVarChar);
            param.Value = thuoc.HamLuong.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@CongDung", SqlDbType.NVarChar);
            param.Value = thuoc.CongDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@PhanTacDung", SqlDbType.NVarChar);
            param.Value = thuoc.PhanTacDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@CachDung", SqlDbType.NVarChar);
            param.Value = thuoc.CachDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@ChuY", SqlDbType.NVarChar);
            param.Value = thuoc.ChuY.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@HanSuDung", SqlDbType.NVarChar);
            param.Value = thuoc.HanSuDung.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@BaoQuan", SqlDbType.NVarChar);
            param.Value = thuoc.BaoQuan.Replace("'", "''");
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("InsertThuoc", paramList);
            return i;
            
        }

        
        public bool KiemTraThuocHDN(string MaThuoc)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("KiemTraThuocHDN '" + MaThuoc.Replace("'", "''") + "'");
            try
            {
                while (rd.Read())
                {
                    rd.Close();
                    return true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                rd.Close();
                return false;
            }
            rd.Close();
            return false;
        }

        public bool KiemTraThuocHDX(string MaThuoc)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("KiemTraThuocHDX '" + MaThuoc.Replace("'", "''") + "'");
            try
            {
                while (rd.Read())
                {
                    rd.Close();
                    return true;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                rd.Close();
                return false;
            }
            rd.Close();
            return false;

        }

        public int DelThuocByMaThuoc(string MaThuoc)
        {
            return dbHelper.ExecuteNonQuery("DelThuoc'" + MaThuoc.Replace("'", "''") + "' ");
        }

        public ArrayList TimKiemThuoc(string MaThuoc,int MaNhom,int MaNSX)
        {

            SqlDataReader rd = dbHelper.ExecuteQuery("TimKiemThuoc N'%" + MaThuoc.Replace("'", "''") + "%'," + MaNhom + "," + MaNSX);
            ArrayList arrLThuoc = new ArrayList();
            while (rd.Read())
            {
                Thuoc thuoc = new Thuoc(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(22), rd.GetString(3), rd.GetString(4), rd.GetInt32(23), rd.GetString(5), rd.GetInt32(6), rd.GetDouble(7), rd.GetDecimal(8),
rd.GetInt32(24), rd.GetString(9), rd.GetInt32(25), rd.GetString(10), rd.GetInt32(11), rd.GetString(12), rd.GetString(13), rd.GetString(14),
rd.GetString(15), rd.GetString(16), rd.GetString(17), rd.GetString(18), rd.GetString(19), rd.GetString(20), rd.GetString(21));
                arrLThuoc.Add(thuoc);
            }
            rd.Close();
            return arrLThuoc;
        }
    }
}
