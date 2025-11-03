using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab7
{
    public partial class Form2 : Form
    {
        // 🔗 Chuỗi kết nối của bạn (đã thay)
        private readonly string strCon = @"Data Source=localhost,1433;
                                           Initial Catalog=QuanLyBanSach;
                                           User ID=sa;
                                           Password=@Viet0337908394;
                                           TrustServerCertificate=True;";

        // Biến dùng chung
        private SqlConnection sqlCon = null;
        private SqlDataAdapter adapter = null;
        private DataSet ds = null;

        public Form2()
        {
            InitializeComponent();
        }

        // 🟢 Mở kết nối
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

        // 🔴 Đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
        }

        // 🧹 Xóa dữ liệu trong form
        private void XoaDuLieuForm()
        {
            txtMaXB.Text = "";
            txtTenXB.Text = "";
            txtDiaChi.Text = "";
        }

        // 📋 Hiển thị dữ liệu lên DataGridView
        private void HienThiDuLieu()
        {
            try
            {
                MoKetNoi();
                string query = "SELECT * FROM NhaXuatBan"; // tên bảng đúng của bạn

                adapter = new SqlDataAdapter(query, sqlCon);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                ds = new DataSet();
                adapter.Fill(ds, "tblNhaXuatBan");

                dgvDanhSach.DataSource = ds.Tables["tblNhaXuatBan"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // 🔄 Khi form load
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
            XoaDuLieuForm();
        }

        // ➕ Nút thêm dữ liệu
        private void btnThemDL_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = ds.Tables["tblNhaXuatBan"].NewRow();

                row["NXB"] = txtMaXB.Text.Trim();
                row["TenNXB"] = txtTenXB.Text.Trim();
                row["DiaChi"] = txtDiaChi.Text.Trim();

                ds.Tables["tblNhaXuatBan"].Rows.Add(row);

                int kq = adapter.Update(ds.Tables["tblNhaXuatBan"]);

                if (kq > 0)
                {
                    MessageBox.Show("Thêm dữ liệu thành công!");
                    HienThiDuLieu();
                    XoaDuLieuForm();
                }
                else
                {
                    MessageBox.Show("Thêm dữ liệu không thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm dữ liệu: " + ex.Message);
            }
        }
    }
}
