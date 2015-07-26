using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class User
    {
        protected  int _IDUser ;
        protected  string _Username ;
        protected  string _Password ;
        protected  string _HoTen ;
        protected  string _DiaChi ;
        public  User()
        {
        }
        public  User( int _IDUser ,string _Username ,string _Password ,string _HoTen ,string _DiaChi  )
        {
           this.IDUser = _IDUser ;
           this.Username = _Username ;
           this.Password = _Password ;
           this.HoTen = _HoTen ;
           this.DiaChi = _DiaChi ;
        }
        public User(string _Username, string _Password)
        {
            this.Username = _Username;
            this.Password = _Password;
        }
        public int IDUser
        {
            get { return _IDUser ; }
            set { _IDUser = value ; }
        }
        public string Username
        {
            get { return _Username ; }
            set { _Username = value ; }
        }
        public string Password
        {
            get { return _Password ; }
            set { _Password = value ; }
        }
        public string HoTen
        {
            get { return _HoTen ; }
            set { _HoTen = value ; }
        }
        public string DiaChi
        {
            get { return _DiaChi ; }
            set { _DiaChi = value ; }
        }
    }
}
