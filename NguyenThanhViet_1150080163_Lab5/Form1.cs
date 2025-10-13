using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab5
{
    public partial class Form1 : Form
    {
        // === Chuỗi kết nối: sửa lại đường dẫn .mdf cho đúng máy bạn ===
        private readonly string _strCon =
@"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=D:\PTPMHDT\NGUYENTHANHVIET_1150080163_LAB5\DBCONNECT.MDF;
  Integrated Security=True;
  Connect Timeout=30;";



        private SqlConnection _con;

        public Form1()
        {
            InitializeComponent();
        }

        // ===== MỞ / ĐÓNG KẾT NỐI =====
        private void MoKetNoi()
        {
            if (_con == null) _con = new SqlConnection(_strCon);
            if (_con.State == ConnectionState.Closed) _con.Open();
        }

        private void DongKetNoi()
        {
            if (_con != null && _con.State == ConnectionState.Open) _con.Close();
        }

        // ===== HIỂN THỊ DANH SÁCH LÊN DataGridView =====
        private void HienThiDanhSach()
        {
            try
            {
                MoKetNoi();
                using (var da = new SqlDataAdapter(
                    "SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop FROM SinhVien", _con))
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

        // ===== NÚT THÊM SINH VIÊN (KHÔNG dùng Parameter) =====
        private void btnThem_Click(object sender, EventArgs e)
        {
            // validate tối thiểu
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || string.IsNullOrWhiteSpace(txtTenSV.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã SV và Tên SV.");
                return;
            }

            try
            {
                MoKetNoi();

                string maSV = txtMaSV.Text.Trim();
                string tenSV = txtTenSV.Text.Trim().Replace("'", "''"); // tránh gãy câu lệnh
                string gioi = cboGioiTinh.Text;                        // "Nam"/"Nữ"
                string ngaySQL = dtpNgaySinh.Value.ToString("yyyy-MM-dd"); // định dạng an toàn cho SQL
                string que = txtQueQuan.Text.Trim().Replace("'", "''");
                string maLop = txtMaLop.Text.Trim();

                string sql = "INSERT INTO SinhVien VALUES (" +
                             $"'{maSV}', N'{tenSV}', N'{gioi}', '{ngaySQL}', N'{que}', '{maLop}')";

                using (var cmd = new SqlCommand(sql, _con))
                {
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm sinh viên thành công!");
                        HienThiDanhSach();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Thêm sinh viên thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        private void ClearInputs()
        {
            txtMaSV.Clear();
            txtTenSV.Clear();
            txtQueQuan.Clear();
            txtMaLop.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            txtMaSV.Focus();
        }

        // ===== FORM LOAD =====
        private void Form1_Load(object sender, EventArgs e)
        {
            // nạp combobox giới tính (nếu Designer chưa thêm)
            if (cboGioiTinh.Items.Count == 0)
            {
                cboGioiTinh.Items.Add("Nam");
                cboGioiTinh.Items.Add("Nữ");
                cboGioiTinh.SelectedIndex = 0;
            }

            HienThiDanhSach();
        }
    }
}
