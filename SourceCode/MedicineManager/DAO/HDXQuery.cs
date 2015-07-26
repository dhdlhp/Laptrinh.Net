using System;
using System.Collections.Generic;
using System.Text;

using MedicineManager.ENTITY;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace MedicineManager.DAO
{
    class HDXQuery
    {
        public DBHelper dbHelper;
        public HDXQuery()
        {
            dbHelper = new DBHelper();
        }

        public int InsertHDX(HoaDonXuat hdx)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@IDBN", SqlDbType.Int);
            param.Value = hdx.IDBN;
            paramList.Add(param);
            param = new SqlParameter("@NgayLap", SqlDbType.NVarChar);
            param.Value = hdx.NgayLap;
            paramList.Add(param);
            param = new SqlParameter("@TongTienThuoc", SqlDbType.Decimal);
            param.Value = hdx.TongTienThuoc;
            paramList.Add(param);
            param = new SqlParameter("@TongThue", SqlDbType.Float);
            param.Value = hdx.TongThue;
            paramList.Add(param);
            param = new SqlParameter("@TongTienHD", SqlDbType.Decimal);
            param.Value = hdx.TongTienHD;
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("HoaDonXuat_Insert", paramList);
            return i;
        }

        public HoaDonXuat SelectLastHoaDonXuat()
        {
            SqlDataReader rd = null;
            rd = dbHelper.ExecuteQuery("GetLastHoaDonXuat");
            if (rd.Read())
            {
                HoaDonXuat hdx = new HoaDonXuat(rd.GetInt32(0), rd.GetInt32(1), rd.GetDateTime(2), rd.GetDecimal(3), rd.GetDouble(4), rd.GetDecimal(5));
                rd.Close();
                return hdx;
            }
            else
            {
                rd.Close();
                return null;
            }
        }

        public HoaDonXuat SelectHoaDonXuat(int _MaHDX)
        {
            SqlDataReader rd = null;
            rd = dbHelper.ExecuteQuery("GetHoaDonXuat_MaHDX " + _MaHDX + "");
            if (rd.Read())
            {
                HoaDonXuat hdx = new HoaDonXuat(rd.GetInt32(0), rd.GetString(1), rd.GetDateTime(2), rd.GetDecimal(3), rd.GetDouble(4), rd.GetDecimal(5));
                rd.Close();
                return hdx;
            }
            else
            {
                rd.Close();
                return null;
            }
        }

        public ArrayList SelectAllChiTietHDX(int _MaHDX)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery(" GetChiTietHD_MaHDX " + _MaHDX + " ");
            ArrayList arrLChiTietHDX = new ArrayList();
            while (rd.Read())
            {
                ChiTietHoaDonXuat chiTietHDX = new ChiTietHoaDonXuat(rd.GetInt32(0), rd.GetInt32(1),rd.GetInt32(2), rd.GetString(3), rd.GetInt32(4), rd.GetDecimal(5), rd.GetDouble(6), rd.GetString(7), rd.GetString(8));
                arrLChiTietHDX.Add(chiTietHDX);
            }
            rd.Close();
            return arrLChiTietHDX;
        }

        public int InsertChiTietHDX(ChiTietHoaDonXuat chiTietHDX)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaHDX", SqlDbType.Int);
            param.Value = chiTietHDX.MaHDX;
            paramList.Add(param);
            param = new SqlParameter("@IDThuoc", SqlDbType.Int);
            param.Value = chiTietHDX.IDThuoc;
            paramList.Add(param);
            param = new SqlParameter("@SoLuong", SqlDbType.Int);
            param.Value = chiTietHDX.SoLuong;
            paramList.Add(param);
            param = new SqlParameter("@GiaBan", SqlDbType.Decimal);
            param.Value = chiTietHDX.GiaBan;
            paramList.Add(param);
            param = new SqlParameter("@Thue", SqlDbType.Float);
            param.Value = chiTietHDX.Thue;
            paramList.Add(param);
            param = new SqlParameter("@DonVi", SqlDbType.NVarChar);
            param.Value = chiTietHDX.DonVi;
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("ChiTietHoaDonXuat_Insert", paramList);
            return i;
        }

        public int DelChiTietHDXByMaHDX(int _MaHDX)
        {
            return dbHelper.ExecuteNonQuery(" DelChiTietHDXByMaHDX '" + _MaHDX + "' ");
        }
        public int DelHoaDonXuatByMaHDX(int _MaHDX)
        {
            return dbHelper.ExecuteNonQuery("DelHoaDonXuatByMaHDX '" + _MaHDX + "' ");
        }

        public ArrayList SelectAllHDX(string _MaBN, string _ToDate, string _FromDate)
        {
            _MaBN = _MaBN.Replace("'", "''");
            SqlDataReader rd = dbHelper.ExecuteQuery(" DSHDX_NgayThangMaBN N'%" + _MaBN + "%','" + _ToDate + "','" + _FromDate + "' ");
            ArrayList arrLHDX = new ArrayList();
            while (rd.Read())
            {
                HoaDonXuat hdx = new HoaDonXuat(rd.GetInt32(0),rd.GetInt32(1), rd.GetString(2), rd.GetDateTime(3), rd.GetDecimal(4), rd.GetDouble(5), rd.GetDecimal(6), rd.GetString(7));
                arrLHDX.Add(hdx);
            }
            rd.Close();
            return arrLHDX;
        }

        public ArrayList SelectHDXByMaHDX(int _MaHDX)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery(" GetHDXByMaHDX "+_MaHDX+" ");
            ArrayList arrLHDX = new ArrayList();
            while (rd.Read())
            {
                HoaDonXuat hdx = new HoaDonXuat(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetDateTime(3), rd.GetDecimal(4), rd.GetDouble(5), rd.GetDecimal(6), rd.GetString(7));
                arrLHDX.Add(hdx);
            }
            rd.Close();
            return arrLHDX;
        }

        public int UpdateSoLuongThuoc(int _IDThuoc, int _SoLuong)
        {
            return dbHelper.ExecuteNonQuery("UpdateSoLuongThuoc " + _IDThuoc + "," + _SoLuong + " ");
        }

        public DataSet SelectDonThuocByMaHSX(int _MaHDX)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaHDX", SqlDbType.Int);
            param.Value = _MaHDX;
            paramList.Add(param);
            return dbHelper.ExecuteDSQuery("GetDonThuocByMaHDX", paramList);
        }

    }
}
