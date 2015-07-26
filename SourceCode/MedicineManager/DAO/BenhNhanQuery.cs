using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.ENTITY;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace MedicineManager.DAO
{
    class BenhNhanQuery
    {
        private DBHelper dbHelper;
        public BenhNhanQuery()
        {
            dbHelper = new DBHelper();
        }

        public ArrayList SelectAllBenhNhanByMaBN(string _MaBN)
        {
            _MaBN = _MaBN.Replace("'", "''");
            SqlDataReader rd = dbHelper.ExecuteQuery("GetBenhNhanDetails N'%"+_MaBN+"%'");
            ArrayList arrLBenhNhan = new ArrayList();
            while (rd.Read())
            {
                BenhNhan benhNhan = new BenhNhan(rd.GetInt32(0),rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetString(4), rd.GetString(5));
                arrLBenhNhan.Add(benhNhan);
            }
            rd.Close();
            return arrLBenhNhan;
        }

        public BenhNhan SelectBenhNhanDetails(string _MaBN)
        {
            _MaBN = _MaBN.Replace("'", "''");
            SqlDataReader rd = dbHelper.ExecuteQuery("GetBenhNhanDetails N'%" + _MaBN + "%'");
            if (rd.Read())
            {
                BenhNhan benhNhan = new BenhNhan(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetString(4), rd.GetString(5));
                rd.Close();
                return benhNhan;
            }
            rd.Close();
            return null;
        }

        public BenhNhan SelectBenhNhanDetails(int _IDBN)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("GetBenhNhan_IDBN "+_IDBN+"");
            if (rd.Read())
            {
                BenhNhan benhNhan = new BenhNhan(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetString(4), rd.GetString(5));
                rd.Close();
                return benhNhan;
            }
            rd.Close();
            return null;
        }

        public int InsertBenhNhan(BenhNhan benhNhan)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaBN", SqlDbType.NVarChar);
            param.Value = benhNhan.MaBN.Replace("'", "''"); ;
            paramList.Add(param);
            param = new SqlParameter("@HoTen", SqlDbType.NVarChar);
            param.Value = benhNhan.HoTen.Replace("'", "''"); ;
            paramList.Add(param);
            param = new SqlParameter("@Tuoi", SqlDbType.Int);
            param.Value = benhNhan.Tuoi;
            paramList.Add(param);
            param = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            param.Value = benhNhan.DiaChi.Replace("'", "''"); ;
            paramList.Add(param);
            param = new SqlParameter("@DienThoai", SqlDbType.NVarChar);
            param.Value = benhNhan.DienThoai;
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("InsertBenhNhan_Haitx", paramList);
            return i;
        }

        public int UpdateBenhNhan(BenhNhan benhNhan)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@IDBN", SqlDbType.Int);
            param.Value = benhNhan.IDBN;
            paramList.Add(param);
            param = new SqlParameter("@MaBN", SqlDbType.NVarChar);
            param.Value = benhNhan.MaBN.Replace("'", "''"); ;
            paramList.Add(param);
            param = new SqlParameter("@HoTen", SqlDbType.NVarChar);
            param.Value = benhNhan.HoTen.Replace("'", "''"); ;
            paramList.Add(param);
            param = new SqlParameter("@Tuoi", SqlDbType.Int);
            param.Value = benhNhan.Tuoi;
            paramList.Add(param);
            param = new SqlParameter("@DiaChi", SqlDbType.NVarChar);
            param.Value = benhNhan.DiaChi.Replace("'", "''"); ;
            paramList.Add(param);
            param = new SqlParameter("@DienThoai", SqlDbType.NVarChar);
            param.Value = benhNhan.DienThoai;
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("UpdateBenhNhan_Haitx", paramList);
            return i;
        }

        public BenhNhan SelectLastBenhNhan()
        {
            SqlDataReader rd = dbHelper.ExecuteQuery("SelectLastBenhNhan_Haitx");
            if (rd.Read())
            {
                BenhNhan benhNhan = new BenhNhan(rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetInt32(3), rd.GetString(4), rd.GetString(5));
                rd.Close();
                return benhNhan;
            }
            rd.Close();
            return null;
        }

        public int DeleteBenhNhan(int _IDBN)
        {
            int i = dbHelper.ExecuteNonQuery("DeleteBenhNhan "+_IDBN+"");
            return i;
        }
    }
}
