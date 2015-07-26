using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class SystemLog
    {

        public SystemLog()
        { }

        //Thêm UserName
        public SystemLog(int _ID, int _IDUser,string _UserName, string _DateLogin, string _Description)
        {
            this.ID = _ID;
            this.IDUser = _IDUser;
            this._UserName = _UserName;
            this.DateLogin = _DateLogin;
            this.Description = _Description;
        }

        public SystemLog(int _IDUser, string _DateLogin, string _Description)
        {
            this.IDUser = _IDUser;
            this.DateLogin = _DateLogin;
            this.Description = _Description;
        }

        public SystemLog(int _ID,int _IDUser, string _DateLogin, string _Description)
        {
            this.ID = _ID;
            this.IDUser = _IDUser;
            this.DateLogin = _DateLogin;
            this.Description = _Description;
        }
        
        
        protected int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        protected int _IDUser;
        public int IDUser
        {
            get { return _IDUser; }
            set { _IDUser = value; }
        }

        //Hungnc
        protected string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        protected string _DateLogin;
        public string DateLogin
        {
            get { return _DateLogin; }
            set { _DateLogin = value; }
        }

        protected string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
    }
}
