using System;
using System.Collections.Generic;
using System.Text;
using MedicineManager.DAO;
using MedicineManager.ENTITY;
using System.Collections;
using MedicineManager.GUI;

namespace MedicineManager.BUS
{
    class BusBenhNhan
    {
        public BenhNhanQuery benhNhanQ;

        public BusBenhNhan()
        {
            benhNhanQ = new BenhNhanQuery();

        }

        public BenhNhan GetBenhNhanDetails(string _MaBN)
        {
            return benhNhanQ.SelectBenhNhanDetails(_MaBN);
        }

        public BenhNhan GetBenhNhanDetails(int _IDBN)
        {
            return benhNhanQ.SelectBenhNhanDetails(_IDBN);
        }

        public ArrayList GetBenhNhanByMaBN(string _MaBN)
        {
            return benhNhanQ.SelectAllBenhNhanByMaBN(_MaBN);
        }

        public int InsertBenhNhan(BenhNhan benhNhan)
        {
            return benhNhanQ.InsertBenhNhan(benhNhan);
        }

        public BenhNhan GetLastBenhNhan()
        {
            return benhNhanQ.SelectLastBenhNhan();
        }

        public int UpdateBenhNhan(BenhNhan benhNhan)
        {
            return benhNhanQ.UpdateBenhNhan(benhNhan);
        }

        public int DeleteBenhNhan(int _IDBN)
        {
            return benhNhanQ.DeleteBenhNhan(_IDBN);
        }
    }
}
