using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab6
{
    public partial class Form1 : Form
    {
        // 🔹 Chuỗi kết nối
        string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=QuanLyBanSach;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        // 🔹 Đối tượng kết nối
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
        }

        // 🔹 Hàm mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        // 🔹 Hàm đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
                sqlCon.Close();
        }

        // 🔹 Hàm hiển thị danh sách Nhà Xuất Bản
        private void HienThiDanhSachNXB()
        {
            MoKetNoi();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "HienThiNXB"; // ⚠️ phải trùng tên thủ tục trong SQL
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDanhSach.Items.Clear();

            while (reader.Read())
            {
                string maXB = reader.GetString(0);
                string tenXB = reader.GetString(1);
                string diaChi = reader.GetString(2);

                ListViewItem lvi = new ListViewItem(maXB);
                lvi.SubItems.Add(tenXB);
                lvi.SubItems.Add(diaChi);
                lsvDanhSach.Items.Add(lvi);
            }

            reader.Close();
        }

        // 🔹 Sự kiện khi Form load
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNXB();
        }

        // 🔹 Khi click chọn 1 dòng trong ListView
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;

            ListViewItem lvi = lsvDanhSach.SelectedItems[0];
            string maXB = lvi.SubItems[0].Text;

            HienThiThongTinNXBTheoMa(maXB);
        }

        // 🔹 Hiển thị chi tiết NXB theo mã
        private void HienThiThongTinNXBTheoMa(string maXB)
        {
            MoKetNoi();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.CommandText = "HienThiChiTietNXB"; // ⚠️ trùng tên SP
            sqlCmd.Connection = sqlCon;

            SqlParameter parMaXB = new SqlParameter("@maXB", SqlDbType.Char);
            parMaXB.Value = maXB;
            sqlCmd.Parameters.Add(parMaXB);

            SqlDataReader reader = sqlCmd.ExecuteReader();

            txtMaXB.Text = txtTenXB.Text = txtDiaChi.Text = "";

            if (reader.Read())
            {
                txtMaXB.Text = reader.GetString(0);
                txtTenXB.Text = reader.GetString(1);
                txtDiaChi.Text = reader.GetString(2);
            }

            reader.Close();
        }
    }
}
