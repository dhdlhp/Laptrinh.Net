using System;
using System.Collections.Generic;
using System.Text;

using MedicineManager.DAO;
using System.Data.SqlClient;
using System.Data;
using MedicineManager.ENTITY;
using System.Collections;

namespace MedicineManager.BUS
{
   public class BusUser
    {
        UserQuery userQ;
        public BusUser()
        {
            userQ = new UserQuery();
        }

        public User GetUser(string _Username, string _Password)
        {
            return userQ.SelectUser(_Username, _Password);
        }

        public void SetSystemLog(SystemLog _SystemLog)
        {
            userQ.InsertSystemLog(_SystemLog);
        }

        public SystemLog GetLastLoginUser(int _IDUser)
        {
            return userQ.SelectLastLoginUser(_IDUser);
        }   


        
        public ArrayList GetAllUser()
        {
            ArrayList arrUser = new ArrayList();
            arrUser = userQ.SelectAllUser();
            if (arrUser.Count != 0)
                return arrUser;
            else
                return null;
        }

    }
}
