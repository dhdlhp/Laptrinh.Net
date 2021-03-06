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
    class BusDVT
    {
        private DVTQuery DvtQ;
        private BusUser busUser;
        public BusDVT()
        {
            DvtQ = new DVTQuery();
            busUser = new BusUser();
        }
                
        public ArrayList GetAllDvt()
        {
            ArrayList arrDVT = new ArrayList();
            arrDVT = DvtQ.SelectAllDVT();
            return arrDVT;
        }

        
        public Boolean UpdateDVT(DonViTinh DVT) {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Sửa đơn vị tính");
            busUser.SetSystemLog(systemLog);
            if (DvtQ.UpdateDVT(DVT) > 0)
            {
                return true;
            }
            else return false;
        }

        
        public Boolean TaoDVT()
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Thêm đơn vị tính");
            busUser.SetSystemLog(systemLog);
            if (DvtQ.InsertNDVT() > 0)
            {
                return true;
            }
            else return false;
        }

        public bool DelDonViTInhByMaDVT(int MaDVT)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Xóa đơn vị tính");
            busUser.SetSystemLog(systemLog);
            if (DvtQ.KiemTraDVT(MaDVT)) 
                return false;
            else
            {
                DvtQ.DelDonViTInhByMaDVT(MaDVT);
                return true;
            }
        }
    }
}
