using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class HoaDonNhap
    {
        protected  int _MaHDN ;
        protected  int _MaNPP ;
        //Hungnc
        protected string _TenNPP;

        protected  string _NguoiGiao ;
        protected  string _NguoiNhan ;
        protected  decimal _TongTienThuoc ;
        protected  double _TongThue ;
        protected  decimal _TongTienHD ;
        protected  DateTime _NgayViet ;
        protected  DateTime _NgayNhap ;
        public  HoaDonNhap()
        {
        }
        public  HoaDonNhap( int _MaHDN ,int _MaNPP ,string _NguoiGiao ,string _NguoiNhan ,decimal _TongTienThuoc ,double _TongThue ,decimal _TongTienHD ,DateTime _NgayViet ,DateTime _NgayNhap  )
        {
           this.MaHDN = _MaHDN ;
           this.MaNPP = _MaNPP ;
           this.NguoiGiao = _NguoiGiao ;
           this.NguoiNhan = _NguoiNhan ;
           this.TongTienThuoc = _TongTienThuoc ;
           this.TongThue = _TongThue ;
           this.TongTienHD = _TongTienHD ;
           this.NgayViet = _NgayViet ;
           this.NgayNhap = _NgayNhap ;
        }

        //Hungnc
        public HoaDonNhap(int _MaHDN,int _MaNPP, String _TenNPP, String _NguoiGiao, String _NguoiNhan, Decimal _TongTienThuoc, Double _TongThue, Decimal _TongTienHD, DateTime _NgayViet, DateTime _NgayNhap) {
            this.MaHDN = _MaHDN;
            this.MaNPP = _MaNPP;
            this.TenNPP = _TenNPP;
            this.NguoiGiao = _NguoiGiao;
            this.NguoiNhan = _NguoiNhan;
            this.TongTienThuoc = _TongTienThuoc;
            this.TongThue = _TongThue;
            this.TongTienHD = _TongTienHD;
            this.NgayViet = _NgayViet;
            this.NgayNhap = _NgayNhap;
        }
        public int MaHDN
        {
            get { return _MaHDN ; }
            set { _MaHDN = value ; }
        }
        public int MaNPP
        {
            get { return _MaNPP ; }
            set { _MaNPP = value ; }
        }
        public string TenNPP
        {
            get { return _TenNPP; }
            set { _TenNPP = value; }
        }
        public string NguoiGiao
        {
            get { return _NguoiGiao ; }
            set { _NguoiGiao = value ; }
        }
        public string NguoiNhan
        {
            get { return _NguoiNhan ; }
            set { _NguoiNhan = value ; }
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
        public DateTime NgayViet
        {
            get { return _NgayViet ; }
            set { _NgayViet = value ; }
        }
        public DateTime NgayNhap
        {
            get { return _NgayNhap ; }
            set { _NgayNhap = value ; }
        }
    }
}
