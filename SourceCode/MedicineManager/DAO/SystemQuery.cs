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
    class SystemQuery
    {
        private DBHelper dbHelper;
        public SystemQuery()
        {
            dbHelper = new DBHelper();
        }

        
        public ArrayList SelectAllSystem(String _FromDate,String _ToDate)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("getAllSystem '"+_FromDate+"','"+_ToDate+"'");            
            ArrayList arrSys = new ArrayList();
            while (rd.Read())
            {
                SystemLog sys = new SystemLog(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetDateTime(3).ToString(), rd.GetString(4));                
                arrSys.Add(sys);
            }
            rd.Close();
            return arrSys;
        }

        
        public int DelSystemLog(int _ID)
        {
            return dbHelper.ExecuteNonQuery("DelSystemLogByID " + _ID);
        }
    }
}
