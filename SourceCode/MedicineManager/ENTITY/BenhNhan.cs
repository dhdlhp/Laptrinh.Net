using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class BenhNhan
    {
        private int _IDBN;

        public int IDBN
        {
            get { return _IDBN; }
            set { _IDBN = value; }
        }
        protected  string _MaBN ;
        protected  string _HoTen ;
        protected  int _Tuoi ;
        protected  string _DiaChi ;
        protected  string _DienThoai ;
        public  BenhNhan()
        {
        }
        public  BenhNhan( string _MaBN ,string _HoTen ,int _Tuoi ,string _DiaChi ,string _DienThoai  )
        {
           this.MaBN = _MaBN ;
           this.HoTen = _HoTen ;
           this.Tuoi = _Tuoi ;
           this.DiaChi = _DiaChi ;
           this.DienThoai = _DienThoai ;
        }
        public BenhNhan(int _IDBN,string _MaBN, string _HoTen, int _Tuoi, string _DiaChi, string _DienThoai)
        {
            this.IDBN = _IDBN;
            this.MaBN = _MaBN;
            this.HoTen = _HoTen;
            this.Tuoi = _Tuoi;
            this.DiaChi = _DiaChi;
            this.DienThoai = _DienThoai;
        }
        public string MaBN
        {
            get { return _MaBN ; }
            set { _MaBN = value ; }
        }
        public string HoTen
        {
            get { return _HoTen ; }
            set { _HoTen = value ; }
        }
        public int Tuoi
        {
            get { return _Tuoi ; }
            set { _Tuoi = value ; }
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
    }
}
