using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.ENTITY;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MedicineManager.DAO
{
    class NSXQuerry
    {
        private DBHelper dbHelper;
        public NSXQuerry()
        {
            dbHelper = new DBHelper();
        }

        public ArrayList SelectAllNsx(string _TenNsx)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("GetNSXBYTenNSX N'%" + _TenNsx.Replace("'", "''") + "%'");
            ArrayList arrNsx = new ArrayList();            
            while (rd.Read())
                {
                    NhaSanXuat NSX = new NhaSanXuat(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6));
                    arrNsx.Add(NSX);
                }
            rd.Close();
            return arrNsx;
        }

        
        public int UpdateNSX(NhaSanXuat NSX)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaNSX", SqlDbType.Int);
            param.Value = NSX.MaNSX;
            paramList.Add(param);
            param = new SqlParameter("@TenNSX", SqlDbType.NVarChar);
            param.Value = NSX.TenNSX.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            param.Value = NSX.DiaChi.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@DienThoai", SqlDbType.NVarChar);
            param.Value = NSX.DienThoai.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@Fax", SqlDbType.NVarChar);
            param.Value = NSX.Fax.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@Email", SqlDbType.NVarChar);
            param.Value = NSX.Email.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@GhiChu", SqlDbType.NVarChar);
            param.Value = NSX.GhiChu.Replace("'", "''");
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("NSX_Update", paramList);
            return i;
        }

        
        public int InsertNSX()
        {
            return dbHelper.ExecuteNonQuery("NSX_Insert");
        }

        public bool KiemTraNSX(int MaNSX)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("KiemTraNSX " + MaNSX);            
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

        public int DelNhaSanXuatByMaNSX(int MaNSX)
        {
            return dbHelper.ExecuteNonQuery("DelNhaSanXuatByMaNSX '" + MaNSX + "' ");
        }
    }
}
