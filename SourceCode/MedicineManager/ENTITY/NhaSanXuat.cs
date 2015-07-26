using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class NhaSanXuat
    {
        protected  int _MaNSX ;
        protected  string _TenNSX ;
        protected  string _DiaChi ;
        protected  string _DienThoai ;
        protected  string _Fax ;
        protected  string _Email ;
        protected  string _GhiChu ;
        
        public  NhaSanXuat( int _MaNSX ,string _TenNSX ,string _DiaChi ,string _DienThoai ,string _Fax ,string _Email ,string _GhiChu  )
        {
           this.MaNSX = _MaNSX ;
           this.TenNSX = _TenNSX ;
           this.DiaChi = _DiaChi ;
           this.DienThoai = _DienThoai ;
           this.Fax = _Fax ;
           this.Email = _Email ;
           this.GhiChu = _GhiChu ;
        }
        public int MaNSX
        {
            get { return _MaNSX ; }
            set { _MaNSX = value ; }
        }
        public string TenNSX
        {
            get { return _TenNSX ; }
            set { _TenNSX = value ; }
        }
        public string DiaChi
        {
            get { return _DiaChi ; }
            set { _DiaChi = value ; }
        }
        public string DienThoai
        {
            get { return _DienThoai ; }
            set { _DienThoai = value ; }
        }
        public string Fax
        {
            get { return _Fax ; }
            set { _Fax = value ; }
        }
        public string Email
        {
            get { return _Email ; }
            set { _Email = value ; }
        }
        public string GhiChu
        {
            get { return _GhiChu ; }
            set { _GhiChu = value ; }
        }
    }
}
