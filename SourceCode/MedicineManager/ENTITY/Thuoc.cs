using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineManager.ENTITY
{
    public class Thuoc
    {
        protected int _IDThuoc;

        public int IDThuoc
        {
            get { return _IDThuoc; }
            set { _IDThuoc = value; }
        }
        protected  string _MaThuoc ;
        protected  string _TenThuoc ;
        protected  int _MaNhom ;
        protected string _TenNhom;
        protected  string _NguonGoc ;
        protected  int _MaNSX ;
        protected string _TenNSX;
        protected  int _SoLuong ;
        protected  double _Thue ;
        protected  decimal _GiaBan ;
        protected  int _MaDVT ;
        protected string _TenDVT;
        protected  int _DangDongGoi ;
        protected string _DangDongGoi_DVT;
        protected  int _SoLuongDongGoi ;
        protected  string _SoDangKy ;
        protected  string _DangBaoChe ;
        protected  string _ThanhPhan ;
        protected  string _HamLuong ;
        protected  string _CongDung ;
        protected  string _PhanTacDung ;
        protected  string _CachDung ;
        protected  string _ChuY ;
        protected  string _HanSuDung ;
        protected  string _BaoQuan ;
                
        public  Thuoc(string _TenThuoc)
        {
            this.TenThuoc = _TenThuoc;
        }        

        public string TenNhom
        {
            get { return _TenNhom; }
            set { _TenNhom = value; }
        }
                

        public string TenNSX
        {
            get { return _TenNSX; }
            set { _TenNSX = value; }
        }

        

        public string TenDVT
        {
            get { return _TenDVT; }
            set { _TenDVT = value; }
        }        

        public string DangDongGoi_DVT
        {
            get { return _DangDongGoi_DVT; }
            set { _DangDongGoi_DVT = value; }
        }

        public Thuoc(int _IDThuoc,string _MaThuoc, string _TenThuoc, int _SoLuong, decimal _GiaBan, string _TenDVT, double _Thue)
        {
            this.IDThuoc = _IDThuoc;
            this.MaThuoc = _MaThuoc;
            this.TenThuoc = _TenThuoc;
            this.SoLuong = _SoLuong;
            this.GiaBan = _GiaBan;
            this.TenDVT = _TenDVT;
            this.Thue = _Thue;
        }

        //Haitx thêm ID thuoc
        public Thuoc(int _IDThuoc,string _MaThuoc, string _TenThuoc, string _TenNhom, string _NguonGoc, string _TenNSX, int _SoLuong, double _Thue, decimal _GiaBan,
string _TenDVT, string _DangDongGoi_DVT, int _SoLuongDongGoi, string _SoDangKy, string _DangBaoChe, string _ThanhPhan,
string _HamLuong, string _CongDung, string _PhanTacDung, string _CachDung, string _ChuY, string _HanSuDung, string _BaoQuan)
        {
            this.IDThuoc = _IDThuoc;
            this.MaThuoc = _MaThuoc;
            this.TenThuoc = _TenThuoc;
            this.TenNhom = _TenNhom;
            this.NguonGoc = _NguonGoc;
            this.TenNSX = _TenNSX;
            this.SoLuong = _SoLuong;
            this.Thue = _Thue;
            this.GiaBan = _GiaBan;
            this.TenDVT = _TenDVT;
            this.DangDongGoi_DVT = _DangDongGoi_DVT;
            this.SoLuongDongGoi = _SoLuongDongGoi;
            this.SoDangKy = _SoDangKy;
            this.DangBaoChe = _DangBaoChe;
            this.ThanhPhan = _ThanhPhan;
            this.HamLuong = _HamLuong;
            this.CongDung = _CongDung;
            this.PhanTacDung = _PhanTacDung;
            this.CachDung = _CachDung;
            this.ChuY = _ChuY;
            this.HanSuDung = _HanSuDung;
            this.BaoQuan = _BaoQuan;
        }


        //Hungnc : Them MaNhom,MaNSX,MaDVT,ĐangongGoi
        //HaiTX : thêm IDthuoc
        public Thuoc(int _IDThuoc,string _MaThuoc, string _TenThuoc,int _MaNhom, string _TenNhom, string _NguonGoc,int _MaNSX, string _TenNSX,int _SoLuong,double _Thue, decimal _GiaBan,
int _MaDVT, string _TenDVT,int _DangDongGoi,  string _DangDongGoi_DVT, int _SoLuongDongGoi, string _SoDangKy, string _DangBaoChe, string _ThanhPhan,
string _HamLuong, string _CongDung, string _PhanTacDung, string _CachDung, string _ChuY, string _HanSuDung, string _BaoQuan)
        {
            this.IDThuoc = _IDThuoc;
            this.MaThuoc = _MaThuoc;
            this.TenThuoc = _TenThuoc;
            this.MaNhom = _MaNhom;
            this.TenNhom = _TenNhom;
            this.NguonGoc = _NguonGoc;
            this._MaNSX = _MaNSX;
            this.TenNSX = _TenNSX;
            this.SoLuong = _SoLuong;
            this.Thue = _Thue;
            this.GiaBan = _GiaBan;
            this._MaDVT = _MaDVT;
            this.TenDVT = _TenDVT;
            this._DangDongGoi = _DangDongGoi;
            this.DangDongGoi_DVT = _DangDongGoi_DVT;
            this.SoLuongDongGoi = _SoLuongDongGoi;
            this.SoDangKy = _SoDangKy;
            this.DangBaoChe = _DangBaoChe;
            this.ThanhPhan = _ThanhPhan;
            this.HamLuong = _HamLuong;
            this.CongDung = _CongDung;
            this.PhanTacDung = _PhanTacDung;
            this.CachDung = _CachDung;
            this.ChuY = _ChuY;
            this.HanSuDung = _HanSuDung;
            this.BaoQuan = _BaoQuan;
        }


        public  Thuoc( string _MaThuoc ,string _TenThuoc ,int _MaNhom ,string _NguonGoc ,int _MaNSX ,int _SoLuong ,double _Thue ,decimal _GiaBan ,int _MaDVT ,int _DangDongGoi ,int _SoLuongDongGoi ,string _SoDangKy ,string _DangBaoChe ,string _ThanhPhan ,string _HamLuong ,string _CongDung ,string _PhanTacDung ,string _CachDung ,string _ChuY ,string _HanSuDung ,string _BaoQuan)
        {
           this.MaThuoc = _MaThuoc ;
           this.TenThuoc = _TenThuoc ;
           this.MaNhom = _MaNhom ;
           this.NguonGoc = _NguonGoc ;
           this.MaNSX = _MaNSX ;
           this.SoLuong = _SoLuong ;
           this.Thue = _Thue ;
           this.GiaBan = _GiaBan ;
           this.MaDVT = _MaDVT ;
           this.DangDongGoi = _DangDongGoi ;
           this.SoLuongDongGoi = _SoLuongDongGoi ;
           this.SoDangKy = _SoDangKy ;
           this.DangBaoChe = _DangBaoChe ;
           this.ThanhPhan = _ThanhPhan ;
           this.HamLuong = _HamLuong ;
           this.CongDung = _CongDung ;
           this.PhanTacDung = _PhanTacDung ;
           this.CachDung = _CachDung ;
           this.ChuY = _ChuY ;
           this.HanSuDung = _HanSuDung ;
           this.BaoQuan = _BaoQuan ;
        }        

        //Hungnc : Hàm khởi tạo giá trị ban đầu
        public Thuoc() {
            this.MaThuoc = "";
            this.TenThuoc = "";
            this.MaNhom = 1;
            this.NguonGoc = "";
            this.MaNSX = 1;
            this.SoLuong = 0;
            this.Thue = 0;
            this.GiaBan = 0;
            this.MaDVT = 1;
            this.DangDongGoi = 1;
            this.SoLuongDongGoi = 0;
            this.SoDangKy = "";
            this.DangBaoChe = "";
            this.ThanhPhan = "";
            this.HamLuong = "";
            this.CongDung = "";
            this.PhanTacDung = "";
            this.CachDung = "";
            this.ChuY = "";
            this.HanSuDung = "";
            this.BaoQuan = "";
        }
        public string MaThuoc
        {
            get { return _MaThuoc ; }
            set { _MaThuoc = value ; }
        }
        public string TenThuoc
        {
            get { return _TenThuoc ; }
            set { _TenThuoc = value ; }
        }
        public int MaNhom
        {
            get { return _MaNhom ; }
            set { _MaNhom = value ; }
        }
        public string NguonGoc
        {
            get { return _NguonGoc ; }
            set { _NguonGoc = value ; }
        }
        public int MaNSX
        {
            get { return _MaNSX ; }
            set { _MaNSX = value ; }
        }
        public int SoLuong
        {
            get { return _SoLuong ; }
            set { _SoLuong = value ; }
        }
        public double Thue
        {
            get { return _Thue ; }
            set { _Thue = value ; }
        }
        public decimal GiaBan
        {
            get { return _GiaBan ; }
            set { _GiaBan = value ; }
        }
        public int MaDVT
        {
            get { return _MaDVT ; }
            set { _MaDVT = value ; }
        }
        public int DangDongGoi
        {
            get { return _DangDongGoi ; }
            set { _DangDongGoi = value ; }
        }
        public int SoLuongDongGoi
        {
            get { return _SoLuongDongGoi ; }
            set { _SoLuongDongGoi = value ; }
        }
        public string SoDangKy
        {
            get { return _SoDangKy ; }
            set { _SoDangKy = value ; }
        }
        public string DangBaoChe
        {
            get { return _DangBaoChe ; }
            set { _DangBaoChe = value ; }
        }
        public string ThanhPhan
        {
            get { return _ThanhPhan ; }
            set { _ThanhPhan = value ; }
        }
        public string HamLuong
        {
            get { return _HamLuong ; }
            set { _HamLuong = value ; }
        }
        public string CongDung
        {
            get { return _CongDung ; }
            set { _CongDung = value ; }
        }
        public string PhanTacDung
        {
            get { return _PhanTacDung ; }
            set { _PhanTacDung = value ; }
        }
        public string CachDung
        {
            get { return _CachDung ; }
            set { _CachDung = value ; }
        }
        public string ChuY
        {
            get { return _ChuY ; }
            set { _ChuY = value ; }
        }
        public string HanSuDung
        {
            get { return _HanSuDung ; }
            set { _HanSuDung = value ; }
        }
        public string BaoQuan
        {
            get { return _BaoQuan ; }
            set { _BaoQuan = value ; }
        }
    }
}
