using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCafe.DTO
{
    public class DTO_ChiTietHoaDon
    {
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int iDHoaDon;

        public int IDHoaDon
        {
            get { return iDHoaDon; }
            set { iDHoaDon = value; }
        }
        private int iDHangHoa;

        public int IDHangHoa
        {
            get { return iDHangHoa; }
            set { iDHangHoa = value; }
        }
        private int soLuong;

        public int SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private float donGia;

        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        private float thanhTien;

        public float ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        public DTO_ChiTietHoaDon(int getid, int getidhoadon, int getidhanghoa, int getsoluong, float getdongia, float getthanhtien)
        {
            this.ID = getid;
            this.IDHoaDon = getidhoadon;
            this.IDHangHoa = getidhanghoa;
            this.SoLuong = getsoluong;
            this.DonGia = getdongia;
            this.ThanhTien = getthanhtien;
        }
        public DTO_ChiTietHoaDon(DataRow dr)
        {
            this.ID = (int)dr["ID"];
            this.IDHoaDon = (int)dr["IDHoaDon"];
            this.IDHangHoa = (int)dr["IDHangHoa"];
            this.SoLuong = (int)dr["SoLuong"];
            this.DonGia = (float)dr["DonGia"];
            this.ThanhTien = (float)dr["ThanhTien"];
        }
    }
}
