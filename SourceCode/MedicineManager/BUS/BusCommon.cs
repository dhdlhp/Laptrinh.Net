using System;
using System.Collections.Generic;
using System.Text;

using MedicineManager.BUS;
using MedicineManager.DAO;

namespace MedicineManager.BUS
{
    class BusCommon
    {
        DBHelper dbHelper;
        public BusCommon()
        {
            dbHelper = new DBHelper();
        }

        public bool CheckConnectDB()
        {
            if (dbHelper.ConnectStatus)
                return true;
            else
                return false;
        }

        public static void SetSystemLog(int _IDUser, string _Description)
        {
            UserQuery userQ = new UserQuery();
            userQ.InsertSystemLog(_IDUser, _Description);
        }
    }
}
