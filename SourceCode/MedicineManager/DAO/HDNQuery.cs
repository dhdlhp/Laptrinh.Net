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
    class HDNQuery
    {
        public DBHelper dbHelper;
        public HDNQuery()
        {
            dbHelper = new DBHelper();
        }

        public int InsertHDN(HoaDonNhap HDN)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaNPP", SqlDbType.Int);
            param.Value = HDN.MaNPP;
            paramList.Add(param);
            param = new SqlParameter("@NguoiGiao", SqlDbType.NVarChar);
            param.Value = HDN.NguoiGiao.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@NguoiNhan", SqlDbType.NVarChar);
            param.Value = HDN.NguoiNhan.Replace("'", "''");
            paramList.Add(param);
            param = new SqlParameter("@TongTienThuoc", SqlDbType.Decimal);
            param.Value = HDN.TongTienThuoc;
            paramList.Add(param);
            param = new SqlParameter("@TongThue", SqlDbType.Float);
            param.Value = HDN.TongThue;
            paramList.Add(param);
            param = new SqlParameter("@TongTienHD", SqlDbType.Decimal);
            param.Value = HDN.TongTienHD;
            paramList.Add(param);
            param = new SqlParameter("@NgayViet", SqlDbType.DateTime);
            param.Value = HDN.NgayViet;
            paramList.Add(param);
            param = new SqlParameter("@NgayNhap", SqlDbType.DateTime);
            param.Value = HDN.NgayNhap;
            paramList.Add(param);

            int i = dbHelper.ExecuteNonQuery("HoaDonNhap_Insert", paramList);
            return i;
        }

        public int SelectLastMaHoaDonNhap()
        {
            SqlDataReader rd = null;
            rd = dbHelper.ExecuteQuery("GetLastMaHoaDonNhap");
            if (rd.Read())
            {
                int i = rd.GetInt32(0);
                rd.Close();
                return i;
            }
            else
            {
                rd.Close();
                return 0;
            }
        }

        //public HoaDonXuat SelectHoaDonXuat(int _MaHDX)
        //{
        //    SqlDataReader rd = null;
        //    rd = dbHelper.ExecuteQuery("GetHoaDonXuat_MaHDX "+_MaHDX+"");
        //    if (rd.Read())
        //    {
        //        HoaDonXuat hdx = new HoaDonXuat(rd.GetInt32(0), rd.GetString(1), rd.GetDateTime(2), rd.GetDecimal(3), rd.GetDouble(4), rd.GetDecimal(5));
        //        rd.Close();
        //        return hdx;
        //    }
        //    else
        //    {
        //        rd.Close();
        //        return null;
        //    }
        //}

        public ArrayList SelectAllChiTietHDN(int MaHDN)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery(" GetChiTietHDN_MaHDN " + MaHDN + " ");
            ArrayList arrCTHDN = new ArrayList();
            while (rd.Read())
            {
                ChiTietHoaDonNhap CTHDN = new ChiTietHoaDonNhap(rd.GetInt32(0),rd.GetInt32(1),rd.GetInt32(2),rd.GetString(3),rd.GetInt32(4),rd.GetDecimal(5));
                arrCTHDN.Add(CTHDN);
            }
            rd.Close();
            return arrCTHDN;
        }

        public int InsertChiTietHDN(ChiTietHoaDonNhap ctHDN)
        {
            List<SqlParameter> paramList = new List<SqlParameter>();
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@MaHDN", SqlDbType.Int);
            param.Value = ctHDN.MaDHN;
            paramList.Add(param);
            param = new SqlParameter("@IDThuoc", SqlDbType.Int);
            param.Value = ctHDN.IDThuoc;
            paramList.Add(param);
            param = new SqlParameter("@SoLuong", SqlDbType.Int);
            param.Value = ctHDN.SoLuong;
            paramList.Add(param);
            param = new SqlParameter("@GiaNhap", SqlDbType.Decimal);
            param.Value = ctHDN.GiaNhap;
            paramList.Add(param);            

            int i = dbHelper.ExecuteNonQuery("ChiTietHoaDonNhap_Insert", paramList);
            return i;
        }
        
        public int DelHoaDonNhapByMaHDN(int _MaHDN)
        {
            return dbHelper.ExecuteNonQuery("DelHoaDonNhapByMaHDN '" + _MaHDN + "' ");
        }

        public ArrayList SelectAllHDN(string TenNPP,string MaThuoc, string FromDate, string ToDate)
        {
            SqlDataReader rd = dbHelper.ExecuteQuery(" getAllHDN N'%" + TenNPP.Replace("'", "''") + "%',N'%" + MaThuoc.Replace("'", "''") + "%','" + FromDate + "','" + ToDate + "'");
            ArrayList arrHDN = new ArrayList();
            try
            {
                while (rd.Read())
                {
                    HoaDonNhap HDN = new HoaDonNhap(rd.GetInt32(0), rd.GetInt32(1),rd.GetString(2),rd.GetString(3),rd.GetString(4),rd.GetDecimal(5),rd.GetDouble(6),rd.GetDecimal(7),rd.GetDateTime(8),rd.GetDateTime(9));
                    arrHDN.Add(HDN);
                }
            }
            catch (SqlException e)
            {
                Console.Write(e.ToString());
            }
            rd.Close();
            return arrHDN;
        }

        public int UpdateSoLuongThuoc(int IdThuoc, int _SoLuong)
        {
            return dbHelper.ExecuteNonQuery("UpdateSoLuongThuocNhap " + IdThuoc + "," + _SoLuong + " ");
        }
    }
}
