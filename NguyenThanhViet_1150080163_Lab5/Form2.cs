using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab5
{
    public partial class Form2 : Form
    {
        // === Chuỗi kết nối tới DBConnect.mdf (LocalDB). Sửa đường dẫn nếu khác. ===
        private readonly string _strCon =
@"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=D:\PTPMHDT\NGUYENTHANHVIET_1150080163_LAB5\DBCONNECT.MDF;
  Integrated Security=True;
  Connect Timeout=30;";

        private SqlConnection _con;

        public Form2()
        {
            InitializeComponent();
        }

        // ===== KẾT NỐI =====
        private void MoKetNoi()
        {
            if (_con == null) _con = new SqlConnection(_strCon);
            if (_con.State == ConnectionState.Closed) _con.Open();
        }

        private void DongKetNoi()
        {
            if (_con != null && _con.State == ConnectionState.Open) _con.Close();
        }

        // ===== HIỂN THỊ DANH SÁCH =====
        private void HienThiDanhSach()
        {
            try
            {
                MoKetNoi();
                using (var da = new SqlDataAdapter(
                    "SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop FROM dbo.SinhVien", _con))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    dgvSinhVien.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // ===== FORM LOAD =====
        private void Form1_Load(object sender, EventArgs e)
        {
            if (cboGioiTinh.Items.Count == 0)
            {
                cboGioiTinh.Items.Add("Nam");
                cboGioiTinh.Items.Add("Nữ");
                cboGioiTinh.SelectedIndex = 0;
            }
            HienThiDanhSach();
        }

        // ===== CLICK DÒNG TRONG GRID -> ĐỔ LÊN Ô NHẬP =====
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvSinhVien.Rows[e.RowIndex];

            txtMaSV.Text = row.Cells["MaSV"].Value?.ToString();
            txtTenSV.Text = row.Cells["TenSV"].Value?.ToString();
            cboGioiTinh.Text = row.Cells["GioiTinh"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["NgaySinh"].Value?.ToString(), out var d))
                dtpNgaySinh.Value = d;

            txtQueQuan.Text = row.Cells["QueQuan"].Value?.ToString();
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString();
        }

        // ===== NÚT TẢI LẠI =====
        private void btnTaiLai_Click(object sender, EventArgs e) => HienThiDanhSach();

        // ===== NÚT SỬA (UPDATE) DÙNG PARAMETER =====
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập/chọn Mã SV cần sửa.");
                return;
            }

            try
            {
                MoKetNoi();

                string sql = @"
UPDATE dbo.SinhVien
   SET TenSV    = @TenSV,
       GioiTinh = @GioiTinh,
       NgaySinh = @NgaySinh,
       QueQuan  = @QueQuan,
       MaLop    = @MaLop
 WHERE MaSV     = @MaSV;";

                using (var cmd = new SqlCommand(sql, _con))
                {
                    // Khai báo đúng kiểu & độ dài để tránh lỗi implicit conversion
                    cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 10).Value = txtMaSV.Text.Trim();
                    cmd.Parameters.Add("@TenSV", SqlDbType.NVarChar, 50).Value = txtTenSV.Text.Trim();
                    cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 10).Value = cboGioiTinh.Text;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpNgaySinh.Value.Date;
                    cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar, 100).Value = txtQueQuan.Text.Trim();
                    cmd.Parameters.Add("@MaLop", SqlDbType.NVarChar, 10).Value = txtMaLop.Text.Trim();

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Sửa sinh viên thành công!");
                        HienThiDanhSach();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Mã SV để sửa.");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi SQL khi sửa dữ liệu: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }
    }
}
