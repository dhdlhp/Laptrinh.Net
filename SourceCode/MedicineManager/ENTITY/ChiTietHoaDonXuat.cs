using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class ChiTietHoaDonXuat
    {
        protected int _IDThuoc;

        public int IDThuoc
        {
            get { return _IDThuoc; }
            set { _IDThuoc = value; }
        }
        
        protected  int _MaCTHDX ;
        protected  int _MaHDX ;
        protected  string _MaThuoc ;
        protected  int _SoLuong ;
        protected  decimal _GiaBan ;
        protected  double _Thue ;
        protected  string _DonVi ;

        protected string _TenThuoc;

        public string TenThuoc
        {
            get { return _TenThuoc; }
            set { _TenThuoc = value; }
        }

        public  ChiTietHoaDonXuat()
        {
        }
        // Sua
        public ChiTietHoaDonXuat( int _MaHDX, int _IDThuoc, int _SoLuong, decimal _GiaBan, double _Thue, string _DonVi)
        {
            this.MaHDX = _MaHDX;
            this.IDThuoc = _IDThuoc;
            this.SoLuong = _SoLuong;
            this.GiaBan = _GiaBan;
            this.Thue = _Thue;
            this.DonVi = _DonVi;
        }
        public  ChiTietHoaDonXuat( int _MaCTHDX ,int _MaHDX ,string _MaThuoc ,int _SoLuong ,decimal _GiaBan ,double _Thue ,string _DonVi  )
        {
           this.MaCTHDX = _MaCTHDX ;
           this.MaHDX = _MaHDX ;
           this.MaThuoc = _MaThuoc ;
           this.SoLuong = _SoLuong ;
           this.GiaBan = _GiaBan ;
           this.Thue = _Thue ;
           this.DonVi = _DonVi ;
        }

        public ChiTietHoaDonXuat(int _MaCTHDX, int _MaHDX, string _MaThuoc, int _SoLuong, decimal _GiaBan, double _Thue, string _DonVi, string _TenThuoc)
        {
            this.MaCTHDX = _MaCTHDX;
            this.MaHDX = _MaHDX;
            this.MaThuoc = _MaThuoc;
            this.SoLuong = _SoLuong;
            this.GiaBan = _GiaBan;
            this.Thue = _Thue;
            this.DonVi = _DonVi;
            this.TenThuoc = _TenThuoc;
        }
        // Them
        public ChiTietHoaDonXuat(int _MaCTHDX, int _MaHDX,int _IDThuoc, string _MaThuoc, int _SoLuong, decimal _GiaBan, double _Thue, string _DonVi, string _TenThuoc)
        {
            this.MaCTHDX = _MaCTHDX;
            this.MaHDX = _MaHDX;
            this.IDThuoc = _IDThuoc;
            this.MaThuoc = _MaThuoc;
            this.SoLuong = _SoLuong;
            this.GiaBan = _GiaBan;
            this.Thue = _Thue;
            this.DonVi = _DonVi;
            this.TenThuoc = _TenThuoc;
        }

        public int MaCTHDX
        {
            get { return _MaCTHDX ; }
            set { _MaCTHDX = value ; }
        }
        public int MaHDX
        {
            get { return _MaHDX ; }
            set { _MaHDX = value ; }
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
        public decimal GiaBan
        {
            get { return _GiaBan ; }
            set { _GiaBan = value ; }
        }
        public double Thue
        {
            get { return _Thue ; }
            set { _Thue = value ; }
        }
        public string DonVi
        {
            get { return _DonVi ; }
            set { _DonVi = value ; }
        }
    }
}
