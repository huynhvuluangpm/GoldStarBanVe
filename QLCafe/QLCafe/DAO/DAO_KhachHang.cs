using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_KhachHang
    {
        private static DAO_KhachHang instance;

        public static DAO_KhachHang Instance
        {
            get {if(instance == null) instance = new DAO_KhachHang(); return DAO_KhachHang.instance; }
           private set { DAO_KhachHang.instance = value; }
        }

        public List<DTO_KhachHang> listKhachHang()
        {
            List<DTO_KhachHang> list = new List<DTO_KhachHang>();
            string sTruyVan = string.Format(@"SELECT * FROM [GPM_KhachHang]");
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            foreach (DataRow item in data.Rows)
            {
                DTO_KhachHang table = new DTO_KhachHang(item);
                list.Add(table);
            }
            return list;
        }
        public static DataTable KhachHangID(string IDKhachHang)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [GPM_KhachHang] WHERE [ID] = {0}", IDKhachHang);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                return data;
            }
            else
                return null;
        }
    }
}
