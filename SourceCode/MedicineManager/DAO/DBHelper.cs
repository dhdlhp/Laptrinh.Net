using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace MedicineManager.DAO
{
    class DBHelper
    {
        private bool connectStatus = true;

        public bool ConnectStatus
        {
            get { return connectStatus; }
            set { connectStatus = value; }
        }
        private static SqlConnection conn = null;
        //private static Common common = new Common();
        private string strServerName = "", strDatabaseName = "", strUserName = "", strPass = "";
        public DBHelper()
        {
            try
            {
                if (conn == null || conn.State == ConnectionState.Closed)
                    initConnection();
            }
            catch (SqlException e)
            {
                // e.StackTrace();
                ConnectStatus = false;
                Console.WriteLine("Can not open Connection" + e.Message);
            }
        }
        private void initConnection()
        {
            //get sqlServer
            //string sqlServer=common.getConnectionString();
            ReadXML();
            string strConn = "Server ='" + strServerName + "';Initial Catalog ='" + strDatabaseName + "';User Id='" + strUserName + "';pwd='" + strPass + "';";
            conn = new SqlConnection(strConn);
            conn.Open();
            //ConnectStatus = true;
            Console.WriteLine("Connection is opening");
        }

        private void ReadXML()
        {
            string xmlPath = "Config.xml";
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml(xmlPath);

                if ((ds != null) && (ds.Tables[0].Rows.Count > 0))
                {
                    strServerName = ds.Tables[0].Rows[0]["ServerName"].ToString().Trim();
                    strDatabaseName = ds.Tables[0].Rows[0]["Database"].ToString().Trim();
                    strUserName = ds.Tables[0].Rows[0]["UserName"].ToString().Trim();
                    strPass = ds.Tables[0].Rows[0]["PassWord"].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                ConnectStatus = false;
                Console.WriteLine(ex.Message);
            }

        }

        public DataSet ExecuteDSQuery(string sql, List<SqlParameter> paramlist)
        {
            SqlCommand cmd = new SqlCommand();
            prepareCommand(cmd, sql, paramlist);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            return dataset;
        }

        protected void prepareCommand(SqlCommand cmd, string sql, List<SqlParameter> paramlist)
        {
            // Init SqlCommand
            if (conn == null || conn.State == ConnectionState.Closed)
                initConnection();
            cmd.CommandTimeout = 1000;
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sql;
            // Process paramlist
            if (paramlist != null)
            {
                foreach (SqlParameter param in paramlist)
                {
                    cmd.Parameters.Add(param);
                }
            }
        }
        public SqlDataReader ExecuteQuery(string sql)
        {
            SqlDataReader reader = null;
            try
            {

                SqlCommand cmd = new SqlCommand(sql, conn);
                return reader = cmd.ExecuteReader();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Can not create Command" + e.Message);
            }

            return reader;
        }
        public SqlDataReader ExecuteQuery(string sql, List<SqlParameter> paramlist)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                prepareCommand(cmd, sql, paramlist);
                reader = cmd.ExecuteReader();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Can not create Command" + e.Message);
            }

            return reader;
        }
        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();

        }
        public int ExecuteNonQuery(String sql, List<SqlParameter> paramlist)
        {
            SqlCommand cmd = new SqlCommand();
            prepareCommand(cmd, sql, paramlist);
            return cmd.ExecuteNonQuery();
        }
        public int ExecuteScalar(string sql, List<SqlParameter> paramlist)
        {
            int num = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                prepareCommand(cmd, sql, paramlist);
                num = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException e)
            {
                Console.WriteLine("Can not create Command" + e.Message);
                num = 0;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine("Can not get Data" + e.Message);
                num = 0;
            }
            return num;
        }

        #region Chinv Additional functions
        public int ExecuteScalar(string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = conn;
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public int FillDataTable(DataTable dt, string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = conn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            return da.Fill(dt);
        }
        #endregion
        public void Dispose()
        {
            if (conn != null || conn.State != ConnectionState.Closed)
            {
                conn.Close();
                ConnectStatus = false;
            }
        }
    }

}
