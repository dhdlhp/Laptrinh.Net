using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.DAO;
using System.Collections;
using MedicineManager.ENTITY;
using MedicineManager.GUI;

namespace MedicineManager.BUS
{
    class BusNhomThuoc
    {
        NhomThuocQuery NhomQ;
        private BusUser busUser;
        public BusNhomThuoc()
        {
            NhomQ = new NhomThuocQuery();
            busUser = new BusUser();
        }

        
        public ArrayList GetAllNhomThuoc()
        {
            ArrayList arrNT = new ArrayList();
            arrNT = NhomQ.SelectAllNhomThuoc();
            if (arrNT.Count != 0)
                return arrNT;
            else
                return null;
        }
       

        
        public bool TaoNhomThuoc(NhomThuoc NT)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Thêm nhóm thuốc ");
            busUser.SetSystemLog(systemLog);
            int i = NhomQ.InsertNhomThuoc(NT);
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
        public Boolean UpdateNhomThuoc(NhomThuoc NT)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Sửa nhóm thuốc ");
            busUser.SetSystemLog(systemLog);
            if (NhomQ.UpdateNhomThuoc(NT) > 0)
            {
                return true;
            }
            else return false;
        }

        
        public bool DelNhomThuocByMaNhom(int MaNhom)
        {

            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Xóa nhóm thuốc ");
            busUser.SetSystemLog(systemLog);
            if (NhomQ.KiemTraNhomThuoc(MaNhom)) return false;
            else
            {
                NhomQ.DelNhomThuocByMaNhom(MaNhom);
                return true;
            }
        }
    }
}
