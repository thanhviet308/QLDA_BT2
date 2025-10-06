using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class Form1 : Form
    {
        // 🔹 Chuỗi kết nối đến SQL Server
        string strCon =
    @"Data Source=localhost,1433;
      Initial Catalog=Quanlybanhang;
      User ID=sa;
      Password=@Viet0337908394;
      TrustServerCertificate=True;";


        // 🔹 Đối tượng kết nối
        SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
        }

        // ================================
        // 🔸 1. Nút MỞ KẾT NỐI
        // ================================
        private void btnMoKetNoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                    MessageBox.Show("Kết nối thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // ================================
        // 🔸 2. Nút ĐÓNG KẾT NỐI
        // ================================
        private void btnDongKetNoi_Click(object sender, EventArgs e)
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
                MessageBox.Show("Đóng kết nối thành công!");
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối!");
            }
        }
    }
}
