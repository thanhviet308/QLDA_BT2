using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab7
{
    public partial class Form3 : Form
    {
        // 🔗 Chuỗi kết nối SQL Server thật (đã thay)
        private readonly string strCon = @"Data Source=localhost,1433;
                                           Initial Catalog=QuanLyBanSach;
                                           User ID=sa;
                                           Password=@Viet0337908394;
                                           TrustServerCertificate=True;";

        // 🧩 Các biến toàn cục
        private SqlConnection sqlCon = null;
        private SqlDataAdapter adapter = null;
        private DataSet ds = null;
        private int vt = -1; // vị trí hàng chọn trong DataGridView

        public Form3()
        {
            InitializeComponent();
        }

        // 🟢 Mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        // 🔴 Đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        // 🧹 Xóa dữ liệu trên form
        private void XoaDuLieuForm()
        {
            txtMaXB.Text = "";
            txtTenXB.Text = "";
            txtDiaChi.Text = "";
        }

        // 📋 Hiển thị dữ liệu ra DataGridView
        private void HienThiDuLieu()
        {
            try
            {
                MoKetNoi();

                string query = "SELECT * FROM NhaXuatBan"; // đổi tên bảng thật ở đây

                adapter = new SqlDataAdapter(query, sqlCon);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                ds = new DataSet();
                adapter.Fill(ds, "tblNhaXuatBan");
                dgvDanhSach.DataSource = ds.Tables["tblNhaXuatBan"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // 🔄 Khi form load
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            XoaDuLieuForm();
        }

        // 🖱️ Khi click chọn 1 dòng trong DataGridView
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt == -1) return;

            DataRow row = ds.Tables["tblNhaXuatBan"].Rows[vt];
            txtMaXB.Text = row["NXB"].ToString().Trim();      // cột trong SQL là NXB
            txtTenXB.Text = row["TenNXB"].ToString().Trim();
            txtDiaChi.Text = row["DiaChi"].ToString().Trim();
        }

        // ✏️ Nút chỉnh sửa thông tin
        private void btnChinhSuaThongTin_Click(object sender, EventArgs e)
        {
            if (vt == -1)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để chỉnh sửa!");
                return;
            }

            try
            {
                DataRow row = ds.Tables["tblNhaXuatBan"].Rows[vt];
                row.BeginEdit();
                row["NXB"] = txtMaXB.Text.Trim();       // đổi đúng tên cột NXB
                row["TenNXB"] = txtTenXB.Text.Trim();
                row["DiaChi"] = txtDiaChi.Text.Trim();
                row.EndEdit();

                int kq = adapter.Update(ds.Tables["tblNhaXuatBan"]);

                if (kq > 0)
                {
                    MessageBox.Show("Chỉnh sửa dữ liệu thành công!");
                    HienThiDuLieu();
                    XoaDuLieuForm();
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa dữ liệu không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chỉnh sửa: " + ex.Message);
            }
        }
    }
}
