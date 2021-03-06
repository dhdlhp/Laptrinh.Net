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
    class BusNPP
    {
        private NPPQuery NppQ;
        public BusUser busUser;
        public BusNPP()
        {
            NppQ = new NPPQuery();
            busUser = new BusUser();
        }

        public ArrayList GetAllNpp(string _TenNpp)
        {
            ArrayList arrNPP = new ArrayList();
            arrNPP = NppQ.SelectAllNpp(_TenNpp);
            return arrNPP;
        }

        
        public Boolean UpdateNPP(NhaPhanPhoi NPP)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Sửa nhà phân phối");
            busUser.SetSystemLog(systemLog);
            if (NppQ.UpdateNPP(NPP) > 0)
            {
                return true;
            }
            else return false;
        }

        
        public Boolean TaoNNPP()
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Thêm nhà phân phối");
            busUser.SetSystemLog(systemLog);
            if (NppQ.InsertNPP() > 0)
            {
                return true;
            }
            else return false;
        }

        public bool DelNPPByMaNPP(int MaNPP)
        {
            SystemLog systemLog = new SystemLog(QuanLy.IDUser, DateTime.Now.ToString(), "Xóa nhà phân phôi");
            busUser.SetSystemLog(systemLog);
            if (NppQ.KiemTraNPP(MaNPP)) return false;
            else
            {
                NppQ.DelNhaPhanPhoiByMaNPP(MaNPP);
                return true;
            }
        }
    }
}
