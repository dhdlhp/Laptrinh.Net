using MedicineManager.DAO;
using System.Data.SqlClient;
using System.Data;
using MedicineManager.ENTITY;
using System.Collections;
using MedicineManager.GUI;
using System;

namespace MedicineManager.BUS
{
    class BusHDN
    {
        public HDNQuery hdnQ;
        private BusUser busUser;
        public BusHDN()
        {
            hdnQ = new HDNQuery();
            busUser = new BusUser();
        }

        public bool TaoHoaDonNhap(HoaDonNhap HDN, ArrayList arrCTHDN)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Thêm hóa đơn nhập");
            busUser.SetSystemLog(systemLog);
            int i = hdnQ.InsertHDN(HDN);
            if (i > 0)
            {
                int MaHDN = hdnQ.SelectLastMaHoaDonNhap();                
                    int j = 0;
                    foreach (ChiTietHoaDonNhap ctHDN in arrCTHDN)
                    {
                        ctHDN.MaDHN = MaHDN;
                        j += hdnQ.InsertChiTietHDN(ctHDN);
                    }
                    if (j == arrCTHDN.Count)
                    {
                        foreach (ChiTietHoaDonNhap ctHDN in arrCTHDN)
                        {
                            hdnQ.UpdateSoLuongThuoc(ctHDN.IDThuoc, ctHDN.SoLuong);
                        }
                        return true;
                    }
                    else{
                        hdnQ.DelHoaDonNhapByMaHDN(MaHDN);
                        return false;
                    }
            }
            else {
                return false;
            }
        }

        public ArrayList GetAllHDN(string TenNPP,string MaThuoc, string FromDate, string ToDate)
        {
            return hdnQ.SelectAllHDN(TenNPP,MaThuoc, FromDate, ToDate);
        }

        public ArrayList GetAllChiTietHDN(int MaHDN)
        {
            return hdnQ.SelectAllChiTietHDN(MaHDN);
        }

        public bool DelHoaDonNhap(int MaHDN)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Xóa hóa đơn nhập");
            busUser.SetSystemLog(systemLog);
            if (hdnQ.DelHoaDonNhapByMaHDN(MaHDN) > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
