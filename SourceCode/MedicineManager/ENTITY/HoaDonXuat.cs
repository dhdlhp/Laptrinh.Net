using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class HoaDonXuat
    {

        protected int _IDBN;

        public int IDBN
        {
            get { return _IDBN; }
            set { _IDBN = value; }
        }
        
        protected  int _MaHDX ;
        protected  string _MaBN ;
        protected  DateTime _NgayLap ;
        protected  decimal _TongTienThuoc ;
        protected  double _TongThue ;
        protected  decimal _TongTienHD ;

        private string _TenBenhNhan;

        public string TenBenhNhan
        {
            get { return _TenBenhNhan; }
            set { _TenBenhNhan = value; }
        }
        public  HoaDonXuat()
        {
        }

        public HoaDonXuat( int _IDBN, DateTime _NgayLap, decimal _TongTienThuoc, double _TongThue, decimal _TongTienHD)
        {
            this.IDBN = _IDBN;
            this.NgayLap = _NgayLap;
            this.TongTienThuoc = _TongTienThuoc;
            this.TongThue = _TongThue;
            this.TongTienHD = _TongTienHD;
        }

        public  HoaDonXuat( int _MaHDX ,int _IDBN ,DateTime _NgayLap ,decimal _TongTienThuoc ,double _TongThue ,decimal _TongTienHD  )
        {
           this.MaHDX = _MaHDX ;
           this.IDBN = _IDBN ;
           this.NgayLap = _NgayLap ;
           this.TongTienThuoc = _TongTienThuoc ;
           this.TongThue = _TongThue ;
           this.TongTienHD = _TongTienHD ;
        }

        public HoaDonXuat(int _MaHDX, string _MaBN, DateTime _NgayLap, decimal _TongTienThuoc, double _TongThue, decimal _TongTienHD)
        {
            this.MaHDX = _MaHDX;
            this.MaBN = _MaBN;
            this.NgayLap = _NgayLap;
            this.TongTienThuoc = _TongTienThuoc;
            this.TongThue = _TongThue;
            this.TongTienHD = _TongTienHD;
        }

        public HoaDonXuat(int _MaHDX,int _IDBN, string _MaBN, DateTime _NgayLap, decimal _TongTienThuoc, double _TongThue, decimal _TongTienHD,string _TenBenhNhan)
        {
            this.MaHDX = _MaHDX;
            this.IDBN = _IDBN;
            this.MaBN = _MaBN;
            this.NgayLap = _NgayLap;
            this.TongTienThuoc = _TongTienThuoc;
            this.TongThue = _TongThue;
            this.TongTienHD = _TongTienHD;
            this.TenBenhNhan = _TenBenhNhan;
        }

        public int MaHDX
        {
            get { return _MaHDX ; }
            set { _MaHDX = value ; }
        }
        public string MaBN
        {
            get { return _MaBN ; }
            set { _MaBN = value ; }
        }
        public DateTime NgayLap
        {
            get { return _NgayLap ; }
            set { _NgayLap = value ; }
        }
        public decimal TongTienThuoc
        {
            get { return _TongTienThuoc ; }
            set { _TongTienThuoc = value ; }
        }
        public double TongThue
        {
            get { return _TongThue ; }
            set { _TongThue = value ; }
        }
        public decimal TongTienHD
        {
            get { return _TongTienHD ; }
            set { _TongTienHD = value ; }
        }
    }
}
