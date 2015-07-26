using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class NhomThuoc
    {
        protected  int _MaNhom ;
        protected  string _TenNhom ;
        protected  string _GhiChu ;
        public  NhomThuoc()
        {
        }
        public  NhomThuoc( int _MaNhom ,string _TenNhom ,string _GhiChu  )
        {
           this.MaNhom = _MaNhom ;
           this.TenNhom = _TenNhom ;
           this.GhiChu = _GhiChu ;
        }

        //hungnc
        public NhomThuoc(string _TenNhom, string _GhiChu)
        {            
            this.TenNhom = _TenNhom;
            this.GhiChu = _GhiChu;
        }
        public int MaNhom
        {
            get { return _MaNhom ; }
            set { _MaNhom = value ; }
        }
        public string TenNhom
        {
            get { return _TenNhom ; }
            set { _TenNhom = value ; }
        }
        public string GhiChu
        {
            get { return _GhiChu ; }
            set { _GhiChu = value ; }
        }
    }
}
