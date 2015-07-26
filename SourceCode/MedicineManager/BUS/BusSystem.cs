using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.DAO;
using System.Collections;

namespace MedicineManager.BUS
{
    class BusSystem
    {
        SystemQuery SysQ;
        public BusSystem()
        {
            SysQ = new SystemQuery();
        }

        
        public ArrayList GetAllSystem(String _FromDate, String _ToDate)
        {
            ArrayList arrSys = new ArrayList();
            arrSys = SysQ.SelectAllSystem(_FromDate, _ToDate);
            if (arrSys.Count != 0)
                return arrSys;
            else
                return null;
        }
                
        public int DelSystemLog(int _ID)
        {
            return SysQ.DelSystemLog(_ID);
        }
    }
}
