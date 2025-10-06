using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YourApp
{
    public partial class Form5 : Form
    {
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=Quanlybanhang;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        public Form5()
        {
            InitializeComponent();
            this.AcceptButton = btnXemDS; // Enter để tìm
        }

        private void btnXemDS_Click(object sender, EventArgs e)
        {
            string tenKhoa = (txtNhapTenKhoa.Text ?? "").Trim();
            if (string.IsNullOrEmpty(tenKhoa))
            {
                MessageBox.Show("Vui lòng nhập tên khoa!", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapTenKhoa.Focus();
                return;
            }

            try
            {
                lsvDanhSach.Items.Clear();

                using (var con = new SqlConnection(strCon))
                using (var cmd = new SqlCommand(@"
                    SELECT L.TenLop, L.MaLop
                    FROM dbo.Lop AS L
                    INNER JOIN dbo.Khoa AS K ON L.MaKhoa = K.MaKhoa
                    WHERE K.TenKhoa = @tenKhoa;", con))
                {
                    cmd.Parameters.Add("@tenKhoa", SqlDbType.NVarChar, 100).Value = tenKhoa;

                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        bool any = false;
                        while (reader.Read())
                        {
                            any = true;
                            string tenLop = reader["TenLop"].ToString();
                            string maLop = reader["MaLop"].ToString();

                            var item = new ListViewItem(tenLop);
                            item.SubItems.Add(maLop);
                            lsvDanhSach.Items.Add(item);
                        }

                        if (!any)
                        {
                            MessageBox.Show("Không tìm thấy lớp cho khoa: " + tenKhoa,
                                "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
