using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.ENTITY;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MedicineManager.DAO
{
    class NPPQuery
    {

        private DBHelper dbHelper;
        public NPPQuery()
        {
            dbHelper = new DBHelper();
        }

        public ArrayList SelectAllNpp(string _TenNpp)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("GetNPPBYTenNPP N'%" + _TenNpp.Replace("'", "''") + "%'");
            ArrayList arrNpp = new ArrayList();            
            while (rd.Read())
                {
                    NhaPhanPhoi NPP = new NhaPhanPhoi(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6),rd.GetString(7));
                    arrNpp.Add(NPP);
                }
            rd.Close();
            return arrNpp;
        }

        
        public int UpdateNPP(NhaPhanPhoi NPP)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaNPP", SqlDbType.Int);
            param.Value = NPP.MaNPP;
            paramList.Add(param);
            param = new SqlParameter("@TenNPP", SqlDbType.NVarChar);
            param.Value = NPP.TenNPP.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            param.Value = NPP.DiaChi.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@DienThoai", SqlDbType.NVarChar);
            param.Value = NPP.DienThoai.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@Fax", SqlDbType.NVarChar);
            param.Value = NPP.Fax.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@Email", SqlDbType.NVarChar);
            param.Value = NPP.Email.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@MaSoThue", SqlDbType.NVarChar);
            param.Value = NPP.MaSoThue.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@GhiChu", SqlDbType.NVarChar);
            param.Value = NPP.GhiChu.Replace("'", "''");
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("NPP_Update", paramList);
            return i;
        }

        
        public int InsertNPP()
        {
            return dbHelper.ExecuteNonQuery("NPP_Insert");
        }

        
        public bool KiemTraNPP(int MaNPP)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("KiemTraNPP " + MaNPP);            
            try
            {
                while (rd.Read())
                {
                    rd.Close();
                    return true;
                }
            }
            catch (SqlException e) {
                Console.WriteLine(e.Message);
                rd.Close();
                return false;
            }
            rd.Close();
            return false;
            
        }

        public int DelNhaPhanPhoiByMaNPP(int MaNPP)
        {
            return dbHelper.ExecuteNonQuery("DelNhaPhanPhoiByMaNPP '" + MaNPP + "' ");
        }

    }
}
