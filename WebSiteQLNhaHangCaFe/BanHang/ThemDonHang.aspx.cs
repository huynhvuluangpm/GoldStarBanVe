using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class ThemDonHang : System.Web.UI.Page
    {
        dtThemDonHangKho data = new dtThemDonHangKho();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data = new dtThemDonHangKho();
                //object IDPhieuDatHang = data.ThemPhieuDatHang();
               // IDThuMuaDatHang_Temp.Value = IDPhieuDatHang.ToString();
               // cmbKhoLap.Value = Session["IDChiNhanh"].ToString();
               // txtNguoiLap.Text = Session["TenDangNhap"].ToString();
                txtSoDonHang.Text = (Int32.Parse(Session["IDChiNhanh"].ToString())).ToString().Replace(".", "") + "-" + (DateTime.Now.ToString("ddMMyyyy-hhmmss"));
            }
            LoadGrid(IDThuMuaDatHang_Temp.Value.ToString());
        }

        private void LoadGrid(string p)
        {
            
        }

        protected void btnThem_Temp_Click(object sender, EventArgs e)
        {

        }

        protected void btnThem_Click(object sender, EventArgs e)
        {

        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {

        }
        protected void BtnXoaHang_Click(object sender, EventArgs e)
        {
            string ID = (((ASPxButton)sender).CommandArgument).ToString();
            string IDThuMuaDatHang = IDThuMuaDatHang_Temp.Value.ToString();
           
        }

        protected void cmbHangHoa_ItemRequestedByValue(object source, ListEditItemRequestedByValueEventArgs e)
        {
            long value = 0;
            if (e.Value == null || !Int64.TryParse(e.Value.ToString(), out value))
                return;
            ASPxComboBox comboBox = (ASPxComboBox)source;
            dsHangHoa.SelectCommand = @"SELECT CF_NguyenLieu.ID, CF_NguyenLieu.MaNguyenLieu, CF_NguyenLieu.TenNguyenLieu, CF_NguyenLieu.GiaMua, CF_DonViTinh.TenDonViTinh 
                                        FROM CF_DonViTinh INNER JOIN CF_NguyenLieu ON CF_DonViTinh.ID = CF_NguyenLieu.IDDonViTinh
                                        WHERE (CF_NguyenLieu.ID = @ID)";
            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("ID", TypeCode.Int64, e.Value.ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

        protected void cmbHangHoa_ItemsRequestedByFilterCondition(object source, ListEditItemsRequestedByFilterConditionEventArgs e)
        {
            ASPxComboBox comboBox = (ASPxComboBox)source;

            dsHangHoa.SelectCommand = @"SELECT [ID],[MaNguyenLieu], [TenNguyenLieu], [GiaMua], [TenDonViTinh]
                                        FROM (
	                                        select CF_NguyenLieu.ID, CF_NguyenLieu.MaNguyenLieu, CF_NguyenLieu.TenNguyenLieu,CF_NguyenLieu.GiaMua, CF_DonViTinh.TenDonViTinh, 
	                                        row_number()over(order by CF_NguyenLieu.MaNguyenLieu) as [rn] 
	                                        FROM CF_DonViTinh INNER JOIN CF_NguyenLieu ON CF_DonViTinh.ID = CF_NguyenLieu.IDDonViTinh           
	                                        WHERE ((CF_NguyenLieu.TenNguyenLieu LIKE @TenHang) OR (CF_NguyenLieu.MaNguyenLieu LIKE @MaHang)) AND (CF_NguyenLieu.DaXoa = 0)
	                                        ) as st 
                                        where st.[rn] between @startIndex and @endIndex";

            dsHangHoa.SelectParameters.Clear();
            dsHangHoa.SelectParameters.Add("TenHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("MaHang", TypeCode.String, string.Format("%{0}%", e.Filter));
            dsHangHoa.SelectParameters.Add("startIndex", TypeCode.Int64, (e.BeginIndex + 1).ToString());
            dsHangHoa.SelectParameters.Add("endIndex", TypeCode.Int64, (e.EndIndex + 1).ToString());
            comboBox.DataSource = dsHangHoa;
            comboBox.DataBind();
        }

        protected void cmbHangHoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHangHoa.Text != "")
            {
                //txtTrongLuong.Text = dtHangHoa.LayTrongLuong(cmbHangHoa.Value.ToString()).ToString();
                //txtTonKho.Text = dtCapNhatTonKho.SoLuong_TonKho(cmbHangHoa.Value.ToString(), Session["IDKho"].ToString()) + "";
                //txtDonGia.Text = dtHangHoa.LayGiaMuaSauThue(cmbHangHoa.Value.ToString()) + "";
                //txtSoLuong.Text = "0";
            }
        }

        protected void txtNgayLap_Init(object sender, EventArgs e)
        {
            txtNgayLap.Date = DateTime.Today;
        }
    }
}