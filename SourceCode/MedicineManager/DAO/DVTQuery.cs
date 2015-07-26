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
    class DVTQuery
    {
        public DBHelper dbHelper;
        public DVTQuery()
        {
            dbHelper = new DBHelper();
        }

        
        public ArrayList SelectAllDVT()
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("GetAllDVT");
            ArrayList arrDVT = new ArrayList();
            while (rd.Read())
            {
                DonViTinh DVT = new DonViTinh(rd.GetInt32(0), rd.GetString(1));
                arrDVT.Add(DVT);
            }
            rd.Close();
            return arrDVT;
        }

        
        public int UpdateDVT(DonViTinh DVT)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaDVT", SqlDbType.Int);
            param.Value = DVT.MaDVT;
            paramList.Add(param);
            param = new SqlParameter("@TenDVT", SqlDbType.NVarChar);
            param.Value = DVT.Ten.Replace("'", "''");
            paramList.Add(param);            

            int i = dbHelper.ExecuteNonQuery("UpdateDVT", paramList);
            return i;
        }

        
        public int InsertNDVT()
        {
            return dbHelper.ExecuteNonQuery("DVT_Insert");
        }

        public bool KiemTraDVT(int MaDVT)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("KiemTraDVT " + MaDVT);
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

        public int DelDonViTInhByMaDVT(int MaDVT)
        {
            return dbHelper.ExecuteNonQuery("DelDonViTinhByMaDVT '" + MaDVT + "' ");
        }
    }
}
