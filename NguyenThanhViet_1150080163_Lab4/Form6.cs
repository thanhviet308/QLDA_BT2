using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace YourApp
{
    public partial class Form6 : Form
    {
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=Quanlybanhang;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        public Form6()
        {
            InitializeComponent();
            LoadDSLop();
        }

        // Load danh sách lớp khi mở form
        private void LoadDSLop()
        {
            try
            {
                using (var con = new SqlConnection(strCon))
                using (var cmd = new SqlCommand("SELECT MaLop, TenLop FROM dbo.Lop", con))
                {
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string maLop = reader["MaLop"].ToString();
                        string tenLop = reader["TenLop"].ToString();
                        lsbDSLop.Items.Add($"{maLop} - {tenLop}");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lớp: " + ex.Message);
            }
        }

        // Khi chọn lớp → hiển thị danh sách sinh viên
        private void lsbDSLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbDSLop.SelectedItem == null) return;

            string selected = lsbDSLop.SelectedItem.ToString();
            string maLop = selected.Split('-')[0].Trim(); // lấy mã lớp

            lsvDSSV.Items.Clear();

            try
            {
                using (var con = new SqlConnection(strCon))
                using (var cmd = new SqlCommand(@"
                    SELECT MaSV, TenSV, GioiTinh, QueQuan
                    FROM dbo.SinhVien
                    WHERE MaLop = @maLop;", con))
                {
                    cmd.Parameters.AddWithValue("@maLop", maLop);
                    con.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["MaSV"].ToString());
                        item.SubItems.Add(reader["TenSV"].ToString());
                        item.SubItems.Add(reader["GioiTinh"].ToString());
                        item.SubItems.Add(reader["QueQuan"].ToString());
                        lsvDSSV.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sinh viên: " + ex.Message);
            }
        }
    }
}
