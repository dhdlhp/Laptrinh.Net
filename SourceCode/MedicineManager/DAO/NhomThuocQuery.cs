using System;
using System.Collections.Generic;
using System.Text;

using MedicineManager.ENTITY;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace MedicineManager.DAO
{
    class NhomThuocQuery
    {

        private DBHelper dbHelper;
        public NhomThuocQuery()
        {
            dbHelper = new DBHelper();
        }

        
        public ArrayList SelectAllNhomThuoc()
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("getAllNhomThuoc");
            ArrayList arrNT = new ArrayList();
            while (rd.Read())
            {
                NhomThuoc NT = new NhomThuoc(rd.GetInt32(0), rd.GetString(1), rd.GetString(2));
                arrNT.Add(NT);
            }
            rd.Close();
            return arrNT;
        }

        
        public int InsertNhomThuoc(NhomThuoc NT)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@TenNhom", SqlDbType.NVarChar);
            param.Value = NT.TenNhom.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@GhiChu", SqlDbType.NVarChar);
            param.Value = NT.GhiChu.Replace("'", "''");
            paramList.Add(param);
            return dbHelper.ExecuteNonQuery("NhomThuoc_Insert", paramList);            
        }

        
        public int UpdateNhomThuoc(NhomThuoc NT)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaNhom", SqlDbType.Int);
            param.Value = NT.MaNhom;
            paramList.Add(param);
            param = new SqlParameter("@TenNhom", SqlDbType.NVarChar);
            param.Value = NT.TenNhom.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@GhiChu", SqlDbType.NVarChar);
            param.Value = NT.GhiChu.Replace("'", "''");
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("UpdateNhomThuoc", paramList);
            return i;
        }

        
        public bool KiemTraNhomThuoc(int MaNhom)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("KiemTraNhomThuoc " + MaNhom);
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

        public int DelNhomThuocByMaNhom(int MaNhom)
        {
            return dbHelper.ExecuteNonQuery("DelNhomThuocByMaNhom'" + MaNhom + "' ");
        }
    }
}
