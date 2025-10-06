using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DemoScalar
{
    public partial class Form1 : Form
    {
        // Chuỗi kết nối bạn đã đưa
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=Quanlybanhang;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        public Form1()
        {
            InitializeComponent();
            // Gắn handler nếu bạn chưa gắn trong Designer
            this.btnCount.Click += btnCount_Click;
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.SinhVien", con))
                {
                    con.Open();
                    int soLuongSV = Convert.ToInt32(cmd.ExecuteScalar());
                    MessageBox.Show("Số lượng sinh viên là: " + soLuongSV,
                        "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
