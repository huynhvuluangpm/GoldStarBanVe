using QLCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    public class DAO_HoaDon
    {
        private static DAO_HoaDon instance;

        public static DAO_HoaDon Instance
        {
            get { if (instance == null) instance = new DAO_HoaDon(); return DAO_HoaDon.instance; }
           private set { DAO_HoaDon.instance = value; }
        }
        private DAO_HoaDon() { }

        /// <summary>
        /// Thành công HoaDonID
        /// Thất bại -1;
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int GetHoaDonByIDBan(int id)
        {
            string sTruyVan = string.Format(@"SELECT * FROM [CF_HoaDon] WHERE ID = {0} AND [TrangThai] = 0", id);
            DataTable data = new DataTable();
            data = DataProvider.TruyVanLayDuLieu(sTruyVan);
            if (data.Rows.Count > 0)
            {
                DTO_HoaDon hd = new DTO_HoaDon(data.Rows[0]);
                return hd.ID;
            }

            return -1;
        }

    }
}
