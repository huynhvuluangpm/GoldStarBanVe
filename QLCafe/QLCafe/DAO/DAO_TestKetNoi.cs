using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DAO
{
    class DAO_TestKetNoi
    {
        public static bool TestKetNoiServer()
        {
            try
            {
                string sTruyVan = "Select * from CF_NguoiDung";
                DataTable data = new DataTable();
                data = DataProvider.TruyVanLayDuLieu(sTruyVan);
                if (data.Rows.Count != 0)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
