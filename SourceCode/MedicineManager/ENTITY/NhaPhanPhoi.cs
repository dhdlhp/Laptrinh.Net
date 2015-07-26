using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class NhaPhanPhoi
    {
        protected  int _MaNPP ;
        protected  string _TenNPP ;
        protected  string _DiaChi ;
        protected  string _DienThoai ;
        protected  string _Fax ;
        protected  string _Email ;
        protected  string _MaSoThue ;
        protected  string _GhiChu ;
        public  NhaPhanPhoi()
        {
        }
        public  NhaPhanPhoi( int _MaNPP ,string _TenNPP ,string _DiaChi ,string _DienThoai ,string _Fax ,string _Email ,string _MaSoThue ,string _GhiChu  )
        {
           this.MaNPP = _MaNPP ;
           this.TenNPP = _TenNPP ;
           this.DiaChi = _DiaChi ;
           this.DienThoai = _DienThoai ;
           this.Fax = _Fax ;
           this.Email = _Email ;
           this.MaSoThue = _MaSoThue ;
           this.GhiChu = _GhiChu ;
        }
        public int MaNPP
        {
            get { return _MaNPP ; }
            set { _MaNPP = value ; }
        }
        public string TenNPP
        {
            get { return _TenNPP ; }
            set { _TenNPP = value ; }
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
        public string MaSoThue
        {
            get { return _MaSoThue ; }
            set { _MaSoThue = value ; }
        }
        public string GhiChu
        {
            get { return _GhiChu ; }
            set { _GhiChu = value ; }
        }
    }
}
