using BanHang.Data;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class PhieuXuatKhac : System.Web.UI.Page
    {
        dtPhieuXuatKhac data = new dtPhieuXuatKhac();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                data = new dtPhieuXuatKhac();
                //object IDPhieuXuatKhac = data.ThemPhieuXuatKhac_Temp();
               // IDPhieuXuatKhac_Temp.Value = IDPhieuXuatKhac.ToString();
                txtNguoiLapPhieu.Text = Session["TenDangNhap"].ToString();
               
            }
            LoadGrid(IDPhieuXuatKhac_Temp.Value.ToString());  
        }
       
        public void Clear()
        {
            cmbHangHoa.Text = "";
            txtSoLuong.Text = "";
            txtTonKho.Text = "";
            cmbDonViTinh.Text = "";
          
        }
        protected void cmbNgayLapPhieu_Init(object sender, EventArgs e)
        {
            cmbNgayLapPhieu.Date = DateTime.Today;
        }
        private void LoadGrid(string IDPhieuXuatKhac)
        {
            data = new dtPhieuXuatKhac();
            //gridDanhSachHangHoa_Temp.DataSource = data.LayDanhSachPhieuXuatKhac_Temp(IDPhieuXuatKhac);
          //  gridDanhSachHangHoa_Temp.DataBind();

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
                txtTonKho.Text = dtSetting.SoLuong_TonKho(cmbHangHoa.Value.ToString()) + "";
                cmbDonViTinh.Value = dtThemHangHoa.LayIDDonViTinh(cmbHangHoa.Value.ToString());
                txtSoLuong.Text = "0";
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {

        }

        protected void btnThemPhieuXuatKhac_Click(object sender, EventArgs e)
        {

        }

        protected void btnHuyPhieuXuatKhac_Click(object sender, EventArgs e)
        {

        }

        protected void gridDanhSachHangHoa_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

        }

    }
}