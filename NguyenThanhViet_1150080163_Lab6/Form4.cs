using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab6
{
    public partial class Form4 : Form
    {
        private readonly string strCon = @"Data Source=localhost,1433;
                                           Initial Catalog=QuanLyBanSach;
                                           User ID=sa;
                                           Password=@Viet0337908394;
                                           TrustServerCertificate=True;";
        private SqlConnection sqlCon;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadNXB();
        }

        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State != ConnectionState.Open)
                sqlCon.Open();
        }

        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        private void LoadNXB()
        {
            try
            {
                MoKetNoi();

                // ✅ Đúng tên cột trong DB: NXB, TenNXB, DiaChi
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT NXB, TenNXB, DiaChi FROM NhaXuatBan", sqlCon);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvNXB.AutoGenerateColumns = false; // dùng cột có sẵn trong Designer
                dgvNXB.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        private void dgvNXB_SelectionChanged(object sender, EventArgs e)
        {
            btnXoa.Enabled = dgvNXB.CurrentRow != null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNXB.CurrentRow == null) return;

            string ma = dgvNXB.CurrentRow.Cells["colMaNXB"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Không lấy được mã NXB.");
                return;
            }

            var confirm = MessageBox.Show(
                $"Bạn có chắc muốn xóa NXB có mã '{ma.Trim()}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                MoKetNoi();

                using (SqlCommand cmd = new SqlCommand("XoaNXB", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // ✅ Vì NXB là CHAR(10) → cần xử lý khoảng trắng đuôi
                    string maFixed = ma.Trim().PadRight(10, ' ');
                    var p = cmd.Parameters.Add("@maNXB", SqlDbType.Char, 10);
                    p.Value = maFixed;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Xóa thành công!", "Thông báo");
                LoadNXB();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Lỗi khi xóa: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }
    }
}
