
using MedicineManager.DAO;
using System.Data.SqlClient;
using System.Data;
using MedicineManager.ENTITY;
using System.Collections;
using MedicineManager.GUI;
using System;

namespace MedicineManager.BUS
{
    class BusHDX
    {
        public HDXQuery hdxQ;

        public BusHDX()
        {
            hdxQ = new HDXQuery();

        }

        public bool TaoHoaDonXuat(HoaDonXuat hdx, ArrayList arrThuoc)
        {
            int i = hdxQ.InsertHDX(hdx);            
            if (i > 0)
            {

                HoaDonXuat hdxTemp = hdxQ.SelectLastHoaDonXuat();
                int MaHDX = hdxTemp.MaHDX;
                    int j = 0;
                    foreach (Thuoc thuoc in arrThuoc)
                    {
                          ChiTietHoaDonXuat chiTietHDX = new ChiTietHoaDonXuat(MaHDX, thuoc.IDThuoc, thuoc.SoLuong, thuoc.GiaBan, thuoc.Thue, thuoc.TenDVT);
                          j += hdxQ.InsertChiTietHDX(chiTietHDX);
                    }
                    if (j == arrThuoc.Count)
                    {
                        foreach (Thuoc thuoc in arrThuoc)
                        {
                            hdxQ.UpdateSoLuongThuoc(thuoc.IDThuoc, thuoc.SoLuong);
                        }
                        return true;
                    }
                    else
                    {
                        hdxQ.DelChiTietHDXByMaHDX(MaHDX);
                        hdxQ.DelHoaDonXuatByMaHDX(MaHDX);
                        return false;
                    }
            }
            else {
                return false;
            }
        }

        public ArrayList GetAllHDX(string _MaBN, string _ToDate, string _FromDate)
        {
            return hdxQ.SelectAllHDX(_MaBN, _ToDate, _FromDate);
        }

        public ArrayList GetHDXByMaHDX(int _MaHDX)
        {
            return hdxQ.SelectHDXByMaHDX(_MaHDX);
        }

        public ArrayList GetAllChiTietHDX(int _MaHDX)
        {
            return hdxQ.SelectAllChiTietHDX(_MaHDX);
        }

        public HoaDonXuat GetChiTietHDX(int _MaHDX)
        {
            return hdxQ.SelectHoaDonXuat(_MaHDX);
        }

        public void DelHoaDonXuat(int _MaHDX)
        {
            hdxQ.DelChiTietHDXByMaHDX(_MaHDX);
            hdxQ.DelHoaDonXuatByMaHDX(_MaHDX);
        }

        public HoaDonXuat GetLastHoaDonXuat()
        {
            return hdxQ.SelectLastHoaDonXuat();
        }

        public DataSet GetDonThuocByMaHSX(int _MaHDX)
        {
            return hdxQ.SelectDonThuocByMaHSX(_MaHDX);
        }

        

    }
}
