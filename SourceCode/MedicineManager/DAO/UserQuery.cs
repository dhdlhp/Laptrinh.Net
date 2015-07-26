using System;
using System.Collections.Generic;
using System.Text;

using MedicineManager.ENTITY;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace MedicineManager.DAO
{
    class UserQuery
    {
        private DBHelper dbHelper;
        public UserQuery()
        {
            dbHelper = new DBHelper();
        }

        public SystemLog SelectLastLoginUser(int _IDUser)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@IDUser", SqlDbType.Int);
            param.Value = _IDUser;
            paramList.Add(param);
            SqlDataReader rd = null;
            rd = dbHelper.ExecuteQuery("GetLastLoginUser", paramList);

            if (rd.Read())
            {                
                SystemLog systemLog = new SystemLog(rd.GetInt32(0),rd.GetInt32(1), rd.GetDateTime(2).ToString(), rd.GetString(3));
                rd.Close();
                return systemLog;
            }
            else
            {
                rd.Close();
                return null;
            }
        }

        public User SelectUser(string _Username, string _Password)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@Username", SqlDbType.NVarChar);
            param.Value = _Username.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@Password", SqlDbType.NVarChar);
            param.Value = _Password.Replace("'", "''");
            paramList.Add(param);


            SqlDataReader rd = null;
            rd = dbHelper.ExecuteQuery("GetUser", paramList);
            if (rd.Read())
            {
                User user = new User(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4));
                rd.Close();
                return user;

            }
            else
            {
                rd.Close();
                return null;
            }
        }

        public void InsertSystemLog(SystemLog systemLog)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@IDUser", SqlDbType.Int);
            param.Value = systemLog.IDUser;
            paramList.Add(param);
            param = new SqlParameter("@DateLogin", SqlDbType.DateTime);
            param.Value = DateTime.Now.ToString();
            paramList.Add(param);
            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Value = systemLog.Description;
            paramList.Add(param);

            dbHelper.ExecuteNonQuery("SetDateLoginUser", paramList);
        }

        public void InsertSystemLog(int _IDUser, string _Description)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@IDUser", SqlDbType.Int);
            param.Value = _IDUser;
            paramList.Add(param);
            param = new SqlParameter("@DateLogin", SqlDbType.DateTime);
            param.Value = DateTime.Now.ToString();
            paramList.Add(param);
            param = new SqlParameter("@Description", SqlDbType.NVarChar);
            param.Value = _Description;
            paramList.Add(param);

            dbHelper.ExecuteNonQuery("SetDateLoginUser", paramList);
        }

        
        public ArrayList SelectAllUser()
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("getAllUsers");
            ArrayList arrUser = new ArrayList();
            while (rd.Read())
            {
                User user = new User(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4));
                arrUser.Add(user);
            }
            rd.Close();
            return arrUser;
        }

    }
}
