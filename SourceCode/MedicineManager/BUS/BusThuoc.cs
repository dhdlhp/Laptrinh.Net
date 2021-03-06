using System;
using System.Collections.Generic;
using System.Text;

using MedicineManager.DAO;
using System.Data.SqlClient;
using System.Data;
using MedicineManager.ENTITY;
using System.Collections;
using MedicineManager.GUI;

namespace MedicineManager.BUS
{
    class BusThuoc
    {
        ThuocQuery thuocQ;
        private BusUser busUser;
        public BusThuoc()
        {
            thuocQ = new ThuocQuery();
            busUser = new BusUser();
        }

        public ArrayList GetAllThuoc2(string _TenThuoc)
        {
            ArrayList arrLThuoc = new ArrayList();
            arrLThuoc = thuocQ.SelectAllThuoc2(_TenThuoc);
            if (arrLThuoc.Count != 0)
                return arrLThuoc;
            else
                return null; 
        }

        public ArrayList GetAllThuoc(string _TenThuoc)
        {
            ArrayList arrLThuoc = new ArrayList();
            arrLThuoc = thuocQ.SelectAllThuoc(_TenThuoc);
            if (arrLThuoc.Count != 0)
                return arrLThuoc;
            else
                return null;
        }

        public Thuoc GetThuocDetails(int _IDThuoc)
        {
            return thuocQ.SelectThuocDetails(_IDThuoc);
        }

        public Thuoc GetThuocDetails2(string _MaThuoc)
        {
            return thuocQ.SelectThuocDetails2(_MaThuoc);
        }

        public Boolean UpdateThuoc(Thuoc thuoc) {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Sửa thuốc");
            busUser.SetSystemLog(systemLog);
            if (thuocQ.UpdateThuoc(thuoc) > 0)
            {
                return true;
            }
            else return false;
        }

        public Boolean InsertThuoc(Thuoc thuoc)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Thêm thuốc");
            busUser.SetSystemLog(systemLog);
            if (thuocQ.InsertThuoc(thuoc) > 0)
            {
                return true;
            }
            else return false;
        }

        
        public string DelThuocByMaThuoc(string MaThuoc)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Xóa thuốc ");
            busUser.SetSystemLog(systemLog);
            String kq;
            if (thuocQ.KiemTraThuocHDN(MaThuoc))
                kq = "Xóa hết Hóa Đơn Nhập liên quan đến Thuốc này";
            else if (thuocQ.KiemTraThuocHDX(MaThuoc))
                kq = "Xóa hết Hóa Đơn Xuất liên quan đến Thuốc này";
            else
            {
                kq = "OK";
                thuocQ.DelThuocByMaThuoc(MaThuoc);
            }
            return kq;
        }

        public ArrayList TimKiemThuoc(string MaThuoc,int MaNhom,int MaNSX)
        {
            ArrayList arrLThuoc = new ArrayList();
            arrLThuoc = thuocQ.TimKiemThuoc(MaThuoc, MaNhom, MaNSX);
            if (arrLThuoc.Count != 0)
                return arrLThuoc;
            else
                return null;
        }
    }
}
