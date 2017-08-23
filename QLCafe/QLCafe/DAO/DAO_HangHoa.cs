﻿using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_HangHoa
    {
        public static DataTable DanhSachHangHoa(string IDNhomHang)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HangHoa] WHERE [IDNhomHang] = {0}", IDNhomHang);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data;
        }

        public static DataTable DanhSachHangHoa_Full()
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HangHoa]");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data;
        }


        private static DAO_HangHoa instance;

        internal static DAO_HangHoa Instance
        {
            get { if (instance == null) instance = new DAO_HangHoa(); return DAO_HangHoa.instance; }
             private set { DAO_HangHoa.instance = value; }
        }
        public DAO_HangHoa() { }
        public List<DTO_HangHoa> DanhSachHangHoaID(int IDNhomHang)
        {
            List<DTO_HangHoa> tablelist = new List<DTO_HangHoa>();
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HangHoa] WHERE [IDNhomHang] = {0}", IDNhomHang);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_HangHoa table = new DTO_HangHoa(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
    }
}
