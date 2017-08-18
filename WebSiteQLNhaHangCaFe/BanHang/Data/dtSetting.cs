using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Web;

namespace BanHang.Data
{
    public class dtSetting
    {
        //public static void CapNhatKho(string IDHangHoa, string SoLuongMoi)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        try
        //        {
        //            myConnection.Open();
        //            string cmdText = "UPDATE [GPM_HangHoaTonKho] SET [SoLuongCon] = @SoLuongMoi, [NgayCapNhat] = getdate() WHERE [IDHangHoa] = @IDHangHoa ";
        //            using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
        //                myCommand.Parameters.AddWithValue("@SoLuongMoi", SoLuongMoi);
        //                myCommand.ExecuteNonQuery();
        //            }
        //            myConnection.Close();
        //        }
        //        catch
        //        {
        //            throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
        //        }
        //    }
        //}
        public static int SoLuong_TonKho(string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT TrongLuong FROM [CF_TonKho] WHERE [IDNguyenLieu] = '" + IDNguyenLieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return Int32.Parse(dr["TrongLuong"].ToString());
                    }
                    else return -1;
                }
            }
        }
        //public static void TruTonKho(string IDHangHoa, string SoLuongCon)
        //{
        //    using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
        //    {
        //        try
        //        {
        //            myConnection.Open();
        //            string cmdText = "UPDATE [GPM_HangHoaTonKho] SET [SoLuongCon] = [SoLuongCon] - @SoLuongCon, [NgayCapNhat] = getdate() WHERE [IDHangHoa] = @IDHangHoa";
        //            using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
        //            {
        //                myCommand.Parameters.AddWithValue("@IDHangHoa", IDHangHoa);
        //                myCommand.Parameters.AddWithValue("@SoLuongCon", SoLuongCon);

        //                myCommand.ExecuteNonQuery();
        //            }
        //            myConnection.Close();
        //        }
        //        catch
        //        {
        //            throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
        //        }
        //    }
        //}
        public static void CongTonKho(string IDNguyenLieu, string TrongLuong, string IDChiNhanh)
        {
            using (SqlConnection myConnection = new SqlConnection(StaticContext.ConnectionString))
            {
                try
                {
                    myConnection.Open();
                    string cmdText = "UPDATE [CF_TonKho] SET [TrongLuong] = [TrongLuong] + @TrongLuong WHERE [IDNguyenLieu] = @IDNguyenLieu AND [IDChiNhanh] = @IDChiNhanh";
                    using (SqlCommand myCommand = new SqlCommand(cmdText, myConnection))
                    {
                        myCommand.Parameters.AddWithValue("@IDNguyenLieu", IDNguyenLieu);
                        myCommand.Parameters.AddWithValue("@IDChiNhanh", IDChiNhanh);
                        myCommand.Parameters.AddWithValue("@TrongLuong", TrongLuong);
                        myCommand.ExecuteNonQuery();
                    }
                    myConnection.Close();
                }
                catch
                {
                    throw new Exception("Lỗi: Quá trình thêm dữ liệu gặp lỗi");
                }
            }
        }
      
        public static string LayIDNguyenLieu(string MaNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = "SELECT ID FROM [CF_NguyenLieu] WHERE [MaNguyenLieu] = N'" + MaNguyenLieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        string ID = dr["ID"].ToString().Trim();
                        return ID;
                    }
                    return null;
                }
            }
        }
     
        public static float GiaMua(string IDNguyenLieu)
        {
            using (SqlConnection con = new SqlConnection(StaticContext.ConnectionString))
            {
                con.Open();
                string cmdText = " SELECT GiaMua FROM [CF_NguyenLieu] WHERE [ID] = '" + IDNguyenLieu + "'";
                using (SqlCommand command = new SqlCommand(cmdText, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable tb = new DataTable();
                    tb.Load(reader);
                    if (tb.Rows.Count != 0)
                    {
                        DataRow dr = tb.Rows[0];
                        return float.Parse(dr["GiaMua"].ToString());
                    }
                    else return -1;
                }
            }
        }
      
        public static string convertDauSangKhongDau(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToUpper();
        }
        public static string GetSHA1HashData(string data)
        {
            
            SHA1 sha1 = SHA1.Create();

            byte[] hashData = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(data + 123));

            System.Text.StringBuilder returnValue = new System.Text.StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString("x"));
            }

            return returnValue.ToString();
        }
    }
}