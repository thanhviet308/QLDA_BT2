using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YourApp
{
    public partial class Form4 : Form
    {
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=Quanlybanhang;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        public Form4()
        {
            InitializeComponent();
        }

        // NHỚ: tên event phải đúng với Designer: btnListView_Click
        private void btnListView_Click(object sender, EventArgs e)
        {
            try
            {
                lsvList.Items.Clear();

                using (var con = new SqlConnection(strCon))
                using (var cmd = new SqlCommand("SELECT MaSV, TenSV, GioiTinh, QueQuan, MaLop FROM dbo.SinhVien", con))
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maSV = reader["MaSV"]?.ToString();
                            string tenSV = reader["TenSV"]?.ToString();
                            string gioiTinh = reader["GioiTinh"] is DBNull ? "" : reader["GioiTinh"].ToString();
                            string queQuan = reader["QueQuan"] is DBNull ? "" : reader["QueQuan"].ToString();
                            string maLop = reader["MaLop"] is DBNull ? "" : reader["MaLop"].ToString();

                            var item = new ListViewItem(maSV);
                            item.SubItems.Add(tenSV);
                            item.SubItems.Add(gioiTinh);
                            item.SubItems.Add(queQuan);
                            item.SubItems.Add(maLop);
                            lsvList.Items.Add(item);
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
