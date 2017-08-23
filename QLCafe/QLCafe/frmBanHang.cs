using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLCafe.BUS;
using QLCafe.DTO;
using DevExpress.SpreadsheetSource.Implementation;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;
using QLCafe.DAO;
using DevExpress.XtraBars;

namespace QLCafe
{
    public partial class frmBanHang : DevExpress.XtraEditors.XtraForm
    {
       
        public frmBanHang()
        {
            InitializeComponent();
            DanhSachBan();
            DanhSachMonAn();
            cmbDanhSachBan();
           // DanhSachHangHoa();
            DanhSachNhomHangHoa();
        }
        public static int IDBan = 0;
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

        }
        public  void DanhSachBan()
        {

            tblTable1.Controls.Clear();
            string IDChiNhanh = frmDangNhap.NguoiDung.Idchinhanh;
            DataTable dt = BUS_KhuVuc.DanhSachBanTheoKhuVuc(IDChiNhanh);
            DataRow dr11 = dt.Rows[0];
            btnTrong.Text = "Trống (" + BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 0) + ")";

            btnDatTruoc.Text = "Đã Đặt (" + BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 1) + ")";
            btnDatTruoc.ForeColor = Color.OrangeRed;
            btnDatTruoc.StyleController = null;
            btnDatTruoc.LookAndFeel.UseDefaultLookAndFeel = false;
            btnDatTruoc.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;

            btnCoNguoi.Text = "Có Người (" + BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 2) + ")";
            btnCoNguoi.ForeColor = Color.Red;
            btnCoNguoi.StyleController = null;
            btnCoNguoi.LookAndFeel.UseDefaultLookAndFeel = false;
            btnCoNguoi.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;

            float SLPhucVu = BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 2);
            float TongSLBan = BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 2) + BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 0) + BUS_BAN.DanhSachThongKe(dr11["ID"].ToString(), 1);
            float TyLePhucVu = SLPhucVu / (float)TongSLBan;
            txtTyLyPhucVu.Text = "Tỷ lệ phục vụ: " + Math.Round(TyLePhucVu, 2) + "%";
            foreach (DataRow dr in dt.Rows)
            {
                string TenKhuVuc = dr["TenKhuVuc"].ToString();
                string IDKhuVuc = dr["ID"].ToString();
                List<DTO_BAN> tablelist = DAO_BAN.Instance.LoadTableList(IDKhuVuc);
                foreach (DTO_BAN item in tablelist)
                {
                    int TrangThai = item.Trangthai;
                    string TenBan = item.Tenban;
                    SimpleButton btn = new SimpleButton();
                    btn.Width = 50;
                    btn.Height = 50;
                    btn.Text = TenBan;
                    btn.Click += btn_Click;
                    btn.MouseDown +=btn_MouseDown;
                    btn.Tag = item;
                    switch (TrangThai)
                    {
                        case 0:
                            tblTable1.Controls.Add(btn);
                            btn.ToolTip = "Bàn trống";
                            break;
                        case 1:
                            btn.ForeColor = Color.OrangeRed;
                            btn.StyleController = null;
                            btn.LookAndFeel.UseDefaultLookAndFeel = false;
                            btn.ToolTip = "Bàn có người đặt";
                            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                            tblTable1.Controls.Add(btn);
                            break;

                        case 2:
                            btn.ForeColor = Color.Red;
                            btn.StyleController = null;
                            btn.LookAndFeel.UseDefaultLookAndFeel = false;
                            btn.ToolTip = "Bàn có người ngồi";
                            btn.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
                            tblTable1.Controls.Add(btn);
                            break;
                    }
                }
            }
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                 IDBan = ((sender as SimpleButton).Tag as DTO_BAN).Id;
                 menuBan.ShowPopup(Control.MousePosition);
            }
        }
       
        public void HienThiHoaDon(int id)
        {
            List<DTO_ChiTietHoaDon> DanhSachHoaDon = DAO_ChiTietHoaDon.Instance.ChiTietHoaDon(DAO_HoaDon.Instance.GetHoaDonByIDBan(id));
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int IDBan = ((sender as SimpleButton).Tag as DTO_BAN).Id;
            HienThiHoaDon(IDBan);
        }
        public void DanhSachMonAn()
        {
            DSMonAn.BeginUpdate();
            DSMonAn.Nodes.Clear();
            DataTable dt = BUS_NhomHang.DanhSachNhomHang();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string TenNhom = dr["TenNhom"].ToString();
                    string IDNhom = dr["ID"].ToString();
                    TreeNode root = new TreeNode(TenNhom);
                    DataTable dthh = BUS_HangHoa.DSHangHoa(IDNhom);
                    foreach (DataRow drhh in dthh.Rows)
                    {
                        string IDHH = drhh["ID"].ToString();
                        string TenHangHoa = drhh["TenHangHoa"].ToString();
                        root.Nodes.Add(TenHangHoa);
                    }
                    DSMonAn.Nodes.Add(root);
                    DSMonAn.EndUpdate();
                }
            }
          
        }
        public void cmbDanhSachBan()
        {
            string IDChiNhanh = frmDangNhap.NguoiDung.Idchinhanh;
            DataTable dt = BUS_KhuVuc.DanhSachBanTheoKhuVuc(IDChiNhanh);
            foreach (DataRow dr in dt.Rows)
            {
                string IDKhuVuc = dr["ID"].ToString();
                DataTable btBan = BUS_BAN.DanhSachBanTheoKhuVuc(IDKhuVuc);
                foreach (DataRow drban in btBan.Rows)
                {
                    cmbBan.Properties.Items.Add(drban["TenBan"].ToString());
                    
                }
                
            }
        }

        private void frmBanHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel,MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void DSMonAn_DragOver(object sender, DragEventArgs e)
        {
            DSMonAn.Scroll();
        }
        public void DanhSachNhomHangHoa()
        {
            List<DTO_NhomHangHoa> danhsachnhomhang = DAO_NhomHang.Instance.DanhSanhNhomHangFull();
            gridNhomHangHoa.Properties.DataSource = danhsachnhomhang;
            gridNhomHangHoa.Properties.DisplayMember = "TenNhom";
            gridNhomHangHoa.Properties.ValueMember = "ID";
        }
        public void DanhSachHangHoaID(int id)
        {
            List<DTO_HangHoa> danhsachhanghoa = DAO_HangHoa.Instance.DanhSachHangHoaID(id);
            gridHangHoa.Properties.DataSource = danhsachhanghoa;
            gridHangHoa.Properties.DisplayMember = "TenHangHoa";
            gridHangHoa.Properties.ValueMember = "ID";
        }
        private void gridNhomHangHoa_EditValueChanged(object sender, EventArgs e)
        {
            int id = 0;
            object displayValue = gridNhomHangHoa.EditValue;
            id = Int32.Parse(displayValue.ToString());
            DanhSachHangHoaID(id);
        }

        private void barButtonDatBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmDatBan fr = new frmDatBan();
            fr.MyGetData = new frmDatBan.GetString(GetValue);
            fr.ShowDialog();
        }
        public void GetValue(String str1, String str2,DateTime a)
        {
            string TenKhachHang = str1;
            string DienThoai = str2;
            DateTime GioDat = a;
            bool KT = DAO_BAN.ThemKhachDatBan(TenKhachHang, DienThoai, GioDat, IDBan);
            if (KT == true)
            {
                DAO_BAN.DoiTrangThaiDatBan(IDBan);
                MessageBox.Show("Đặt bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DanhSachBan();
            }
            else
            {
                MessageBox.Show("Đặt bàn Thất Bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DanhSachBan();
            }
        }
        private void barButtonXoaBan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (MessageBox.Show("Chuyển trạng thái bàn về Trống?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                bool KT = DAO_BAN.XoaBanVeMatDinh(IDBan);
                if (KT == true)
                {
                    MessageBox.Show("Cập Nhật Thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DanhSachBan();
                }
                else
                {
                    MessageBox.Show("Cập Nhật Thất Bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DanhSachBan();
                }
            }
        } 
    }
}