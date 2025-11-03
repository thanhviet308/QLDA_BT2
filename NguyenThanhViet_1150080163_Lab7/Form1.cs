using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab7
{
    public partial class Form1 : Form
    {
        // 🔗 Chuỗi kết nối của bạn
        private readonly string strCon = @"Data Source=localhost,1433;
                                           Initial Catalog=QuanLyBanSach;
                                           User ID=sa;
                                           Password=@Viet0337908394;
                                           TrustServerCertificate=True;";

        // Đối tượng kết nối
        private SqlConnection sqlCon = null;

        public Form1()
        {
            InitializeComponent();
        }

        // 🟢 Hàm mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        // 🔴 Hàm đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        // 🖱️ Sự kiện click nút "Hiển thị danh sách"
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            try
            {
                MoKetNoi();

                // Truy vấn bảng NhaXuatBan
                string sql = "SELECT * FROM NhaXuatBan";

                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlCon);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "tblNhaXuatBan");

                dgvDanhSach.DataSource = ds.Tables["tblNhaXuatBan"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }
    }
}
