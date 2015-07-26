using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class DonViTinh
    {
        protected  int _MaDVT ;
        protected  string _Ten ;
        public  DonViTinh()
        {
        }
        public  DonViTinh( int _MaDVT ,string _Ten  )
        {
           this.MaDVT = _MaDVT ;
           this.Ten = _Ten ;
        }
        public int MaDVT
        {
            get { return _MaDVT ; }
            set { _MaDVT = value ; }
        }
        public string Ten
        {
            get { return _Ten ; }
            set { _Ten = value ; }
        }
    }
}
