using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_KhuVuc
    {
        public static DataTable DanhSachKhuVuc(string IDChiNhanh)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_KhuVuc] WHERE IDChiNhanh = {0} ", IDChiNhanh);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            return data;
        }
    }
}
