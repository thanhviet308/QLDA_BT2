using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab6
{
    public partial class Form2 : Form
    {
        // ✅ Chuỗi kết nối: sửa đúng đường dẫn .mdf của bạn và để 1 dòng
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=QuanLyBanSach;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        private SqlConnection sqlCon;

        public Form2()
        {
            InitializeComponent();
        }

        // ✅ Mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State != ConnectionState.Open) sqlCon.Open();
        }

        // ✅ Đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }

        // ✅ Hiển thị danh sách NXB
        private void HienThiDanhSachNXB()
        {
            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand("dbo.HienThiNXB", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        lsvDanhSach.Items.Clear();
                        while (reader.Read())
                        {
                            string ma = reader["NXB"].ToString().Trim();     // CHAR(10) => Trim
                            string ten = reader["TenNXB"].ToString();
                            string diachi = reader["DiaChi"].ToString();

                            var lvi = new ListViewItem(ma);
                            lvi.SubItems.Add(ten);
                            lvi.SubItems.Add(diachi);
                            lsvDanhSach.Items.Add(lvi);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        // ✅ Load form
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNXB();
            txtMaXB.Focus();
        }

        // ✅ Chọn 1 dòng → hiển thị chi tiết
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            string ma = lsvDanhSach.SelectedItems[0].SubItems[0].Text;
            HienThiThongTinNXBTheoMa(ma);
        }

        // ✅ Xem chi tiết theo mã
        private void HienThiThongTinNXBTheoMa(string maNXB)
        {
            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand("dbo.HienThiChiTietNXB", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Thủ tục của bạn dùng @maNXB (không phải @maXB)
                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10) { Value = maNXB });

                    using (var reader = cmd.ExecuteReader())
                    {
                        txtMaXB.Text = txtTenXB.Text = txtDiaChi.Text = "";
                        if (reader.Read())
                        {
                            txtMaXB.Text = reader["NXB"].ToString().Trim();
                            txtTenXB.Text = reader["TenNXB"].ToString();
                            txtDiaChi.Text = reader["DiaChi"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
            }
        }

        // ✅ Nút Thêm dữ liệu
        private void btnThemDL_Click(object sender, EventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtMaXB.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã NXB.");
                txtMaXB.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtTenXB.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên NXB.");
                txtTenXB.Focus(); return;
            }

            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand("dbo.ThemDuLieu", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Nếu cột NXB là CHAR(10), có thể PadRight để đủ 10 ký tự (không bắt buộc)
                    string ma = txtMaXB.Text.Trim();
                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10) { Value = ma });
                    cmd.Parameters.Add(new SqlParameter("@tenNXB", SqlDbType.NVarChar, 100) { Value = txtTenXB.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@diaChi", SqlDbType.NVarChar, 500) { Value = txtDiaChi.Text.Trim() });

                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!");
                        HienThiDanhSachNXB();
                        txtMaXB.Clear(); txtTenXB.Clear(); txtDiaChi.Clear();
                        txtMaXB.Focus();
                    }
                }
            }
            catch (SqlException ex)
            {
                // 2627: trùng khóa chính
                if (ex.Number == 2627)
                    MessageBox.Show("Mã NXB đã tồn tại. Vui lòng nhập mã khác.");
                else
                    MessageBox.Show("Lỗi SQL: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
