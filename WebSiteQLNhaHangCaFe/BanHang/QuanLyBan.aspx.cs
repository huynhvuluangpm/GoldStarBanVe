using BanHang.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BanHang
{
    public partial class QuanLyBan : System.Web.UI.Page
    {
        dtBan data = new dtBan();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            data = new dtBan();
            gridDanhSach.DataSource = data.DanhSach();
            gridDanhSach.DataBind();
        }

        protected void gridDanhSach_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            data = new dtBan();
            if (dtBan.TrangThai(ID) != 0)
            {
                throw new Exception("Lỗi: Bàn này đã có món ăn?");
            }
            else
            {
                data.Xoa(ID);
            }
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

        protected void gridDanhSach_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            string TenBan = e.NewValues["TenBan"].ToString();
            string IDKhuVuc = e.NewValues["IDKhuVuc"].ToString();
            string MaBan = dtBan.Dem_Max(IDKhuVuc);
            data = new dtBan();
            if (dtBan.KTTenBan_IDKhuVuc(dtBan.LayKyHieuKhuVuc(IDKhuVuc) + " - " + TenBan, IDKhuVuc) == true)
            {
                data.Them(MaBan, dtBan.LayKyHieuKhuVuc(IDKhuVuc) + " - " + TenBan, IDKhuVuc, dtBan.IDChiNhanh(IDKhuVuc));
            }
            else
            {
                throw new Exception("Lỗi: Tên bàn đã tồn tại trong khu vực");
            }
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

        protected void gridDanhSach_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            string ID = e.Keys[0].ToString();
            string TenBan = e.NewValues["TenBan"].ToString();
            string IDKhuVuc = e.NewValues["IDKhuVuc"].ToString();
            data = new dtBan();
            data.Sua(ID, dtBan.LayKyHieuKhuVuc(IDKhuVuc) + " - " + TenBan, IDKhuVuc, dtBan.IDChiNhanh(IDKhuVuc));
            e.Cancel = true;
            gridDanhSach.CancelEdit();
            LoadGrid();
        }

        protected void ASPxFormLayout1_E2_Click(object sender, EventArgs e)
        {
            popupThemKhachHang.ShowOnPageLoad = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int TuSo = Int32.Parse(txtTuSo.Text);
            int DenSo = Int32.Parse(txtDenSo.Text);
            string IDKhuVuc = cmbKhuVuc.Value.ToString();
            string IDChiNhanh = dtBan.IDChiNhanh(IDKhuVuc);
            string KyHieu = dtBan.LayKyHieuKhuVuc(IDKhuVuc);
            for (int i = TuSo; i <= DenSo; i++)
            {
                string MaBan = dtBan.Dem_Max(IDKhuVuc);
                data = new dtBan();
                if (dtBan.KTTenBan_IDKhuVuc(KyHieu + " - " + i.ToString(), IDKhuVuc) == true)
                {
                    data.Them(MaBan, KyHieu + " - " + i, IDKhuVuc, IDChiNhanh);
                }
            }
            txtDenSo.Text = "";
            txtDenSo.Text = "";
            cmbKhuVuc.Text = "";
            LoadGrid();
            popupThemKhachHang.ShowOnPageLoad = false;
            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            txtDenSo.Text = "";
            txtDenSo.Text = "";
            cmbKhuVuc.Text = "";
            popupThemKhachHang.ShowOnPageLoad = false;
        }
    }
}