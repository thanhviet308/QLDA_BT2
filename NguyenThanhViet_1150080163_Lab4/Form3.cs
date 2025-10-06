using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoSinhVien
{
    public partial class Form1 : Form
    {
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=Quanlybanhang;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = btnXemThongTin; // nhấn Enter để tìm
            btnXemThongTin.Click += btnXemThongTin_Click;
        }

        private void ClearOutputs()
        {
            txtTenSV.Text = "";
            txtGioiTinh.Text = "";
            txtNgaySinh.Text = "";
            txtQueQuan.Text = "";
            txtMaLop.Text = "";
        }

        private void btnXemThongTin_Click(object sender, EventArgs e)
        {
            string maSV = (txtMaSV.Text ?? "").Trim();

            if (string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaSV.Focus();
                return;
            }

            try
            {
                using (var con = new SqlConnection(strCon))
                using (var cmd = new SqlCommand(@"
                    SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop
                    FROM dbo.SinhVien
                    WHERE MaSV = @maSV;", con))
                {
                    cmd.Parameters.Add("@maSV", SqlDbType.VarChar, 10).Value = maSV;

                    con.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (reader.Read())
                        {
                            // Lấy theo tên cột để tránh phụ thuộc vị trí
                            txtTenSV.Text = reader["TenSV"] is DBNull ? "" : reader["TenSV"].ToString();
                            txtGioiTinh.Text = reader["GioiTinh"] is DBNull ? "" : reader["GioiTinh"].ToString();

                            if (reader["NgaySinh"] is DBNull)
                                txtNgaySinh.Text = "";
                            else
                                txtNgaySinh.Text = ((DateTime)reader["NgaySinh"]).ToString("dd/MM/yyyy");

                            txtQueQuan.Text = reader["QueQuan"] is DBNull ? "" : reader["QueQuan"].ToString();
                            txtMaLop.Text = reader["MaLop"] is DBNull ? "" : reader["MaLop"].ToString();
                        }
                        else
                        {
                            ClearOutputs();
                            MessageBox.Show("Không tìm thấy sinh viên có mã: " + maSV,
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClearOutputs();
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
