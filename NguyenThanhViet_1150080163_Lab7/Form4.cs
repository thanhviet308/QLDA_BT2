using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab7
{
    public partial class Form4 : Form
    {
        // 🔗 Chuỗi kết nối (dùng SQL Server thật)
        private readonly string strCon = @"Data Source=localhost,1433;
                                           Initial Catalog=QuanLyBanSach;
                                           User ID=sa;
                                           Password=@Viet0337908394;
                                           TrustServerCertificate=True;";

        // ⚙️ Các biến toàn cục
        private SqlConnection sqlCon = null;
        private SqlDataAdapter adapter = null;
        private DataSet ds = null;
        private int vt = -1; // vị trí dòng đang chọn

        public Form4()
        {
            InitializeComponent();
        }

        // 🟢 Mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        // 🔴 Đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        // 📋 Hiển thị dữ liệu lên DataGridView
        private void HienThiDuLieu()
        {
            try
            {
                MoKetNoi();

                // ⚠️ Đổi tên bảng thật của bạn ở đây (vd: haXuatBan hoặc NhaXuatBan)
                string query = "SELECT * FROM NhaXuatBan";

                adapter = new SqlDataAdapter(query, sqlCon);

                // BẮT BUỘC để SqlCommandBuilder sinh ra DeleteCommand
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                ds = new DataSet();
                adapter.Fill(ds, "tblNhaXuatBan");

                dgvDanhSach.DataSource = ds.Tables["tblNhaXuatBan"];
                vt = -1;
                btnXoaDuLieu.Enabled = false; // chưa chọn dòng thì tắt nút
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

        // 🧭 Khi form load
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        // 📌 Khi click chọn 1 dòng trong DataGridView
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vt = e.RowIndex;
            if (vt >= 0)
                btnXoaDuLieu.Enabled = true;
        }

        // ❌ Nút "Xóa dữ liệu"
        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            if (vt < 0 || ds == null || ds.Tables["tblNhaXuatBan"].Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa dòng này không?",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                DataRow row = ds.Tables["tblNhaXuatBan"].Rows[vt];
                row.Delete(); // xóa trong DataSet

                // ⚙️ Cập nhật thay đổi xuống database
                int kq = adapter.Update(ds.Tables["tblNhaXuatBan"]);

                if (kq > 0)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!");
                    HienThiDuLieu();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
            }
        }
    }
}
