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
    class BusNSX
    {
        private NSXQuerry NsxQ;
        private BusUser busUser;
        public BusNSX()
        {
            NsxQ = new NSXQuerry();
            busUser = new BusUser();
        }

        public ArrayList GetAllNsx(string _TenNsx)
        {
            ArrayList arrNSX = new ArrayList();
            arrNSX = NsxQ.SelectAllNsx(_TenNsx);
            return arrNSX;
        }

        
        public Boolean UpdateNSX(NhaSanXuat NSX)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Sửa nhà sản xuất");
            busUser.SetSystemLog(systemLog);
            if (NsxQ.UpdateNSX(NSX) > 0)
            {
                return true;
            }
            else return false;
        }

        
        public Boolean TaoNSX()
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Thêm nhà sản xuất");
            busUser.SetSystemLog(systemLog);
            if (NsxQ.InsertNSX() > 0)
            {
                return true;
            }
            else return false;
        }

        public bool DelNhaSanXuatByMaNSX(int MaNSX)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Xóa nhà sản xuất");
            busUser.SetSystemLog(systemLog);
            if (NsxQ.KiemTraNSX(MaNSX)) return false;
            else
            {
                NsxQ.DelNhaSanXuatByMaNSX(MaNSX);
                return true;
            }
        }
    }
}
