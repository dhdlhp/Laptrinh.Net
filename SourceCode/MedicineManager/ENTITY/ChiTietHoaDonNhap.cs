using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class ChiTietHoaDonNhap
    {
        protected int _IDThuoc;

        public int IDThuoc
        {
            get { return _IDThuoc; }
            set { _IDThuoc = value; }
        }

        protected  int _MaCTHDN ;
        protected  int _MaDHN ;
        protected  string _MaThuoc ;
        protected  int _SoLuong ;
        protected  decimal _GiaNhap ;
        public  ChiTietHoaDonNhap()
        {
            this.MaCTHDN = 0;
            this.MaDHN = 0;
            this.MaThuoc = "";
            this.MaCTHDN = 0;
            this.MaCTHDN = 0;
        }
        public  ChiTietHoaDonNhap( int _MaCTHDN ,int _MaDHN ,string _MaThuoc ,int _SoLuong ,decimal _GiaNhap  )
        {
           this.MaCTHDN = _MaCTHDN ;
           this.MaDHN = _MaDHN ;
           this.MaThuoc = _MaThuoc ;
           this.SoLuong = _SoLuong ;
           this.GiaNhap = _GiaNhap ;
        }

        public ChiTietHoaDonNhap(int _MaCTHDN, int _MaDHN,int _IDThuoc, string _MaThuoc, int _SoLuong, decimal _GiaNhap)
        {
            this.IDThuoc = _IDThuoc;
            this.MaCTHDN = _MaCTHDN;
            this.MaDHN = _MaDHN;
            this.MaThuoc = _MaThuoc;
            this.SoLuong = _SoLuong;
            this.GiaNhap = _GiaNhap;
        }
        public int MaCTHDN
        {
            get { return _MaCTHDN ; }
            set { _MaCTHDN = value ; }
        }
        public int MaDHN
        {
            get { return _MaDHN ; }
            set { _MaDHN = value ; }
        }
        public string MaThuoc
        {
            get { return _MaThuoc ; }
            set { _MaThuoc = value ; }
        }
        public int SoLuong
        {
            get { return _SoLuong ; }
            set { _SoLuong = value ; }
        }
        public decimal GiaNhap
        {
            get { return _GiaNhap ; }
            set { _GiaNhap = value ; }
        }
    }
}
