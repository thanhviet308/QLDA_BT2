using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab6
{
    public partial class Form3 : Form
    {
        private readonly string strCon =
@"Data Source=localhost,1433;
  Initial Catalog=QuanLyBanSach;
  User ID=sa;
  Password=@Viet0337908394;
  TrustServerCertificate=True;";

        private SqlConnection sqlCon;

        public Form3()
        {
            InitializeComponent();
        }

        private void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State != ConnectionState.Open) sqlCon.Open();
        }
        private void DongKetNoi()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }

        // GẮN SỰ KIỆN NÀY TRONG Designer: this.Load += new System.EventHandler(this.Form3_Load);
        private void Form3_Load(object sender, EventArgs e)
        {
            HienThiDanhSachNXB();
        }

        private void HienThiDanhSachNXB()
        {
            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand("dbo.HienThiNXB", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var r = cmd.ExecuteReader())
                    {
                        lsvDanhSach.Items.Clear();
                        while (r.Read())
                        {
                            var ma = r["NXB"].ToString().Trim();
                            var ten = r["TenNXB"].ToString();
                            var dc = r["DiaChi"].ToString();

                            var it = new ListViewItem(ma);
                            it.SubItems.Add(ten);
                            it.SubItems.Add(dc);
                            lsvDanhSach.Items.Add(it);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
        }

        // GẮN SỰ KIỆN TRONG Designer: lsvDanhSach.SelectedIndexChanged += this.lsvDanhSach_SelectedIndexChanged;
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) return;
            var ma = lsvDanhSach.SelectedItems[0].SubItems[0].Text;
            HienThiThongTinNXBTheoMa(ma);
        }

        private void HienThiThongTinNXBTheoMa(string maNXB)
        {
            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand("dbo.HienThiChiTietNXB", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10) { Value = maNXB });

                    using (var r = cmd.ExecuteReader())
                    {
                        txtMaXB.Text = txtTenXB.Text = txtDiaChi.Text = "";
                        if (r.Read())
                        {
                            txtMaXB.Text = r["NXB"].ToString().Trim();
                            txtTenXB.Text = r["TenNXB"].ToString();
                            txtDiaChi.Text = r["DiaChi"].ToString();
                            btnCapNhat.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chi tiết: " + ex.Message);
            }
        }

        // GẮN SỰ KIỆN TRONG Designer: txtTenXB.TextChanged += Inputs_TextChanged; txtDiaChi.TextChanged += Inputs_TextChanged;
        private void Inputs_TextChanged(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = !string.IsNullOrWhiteSpace(txtMaXB.Text)
                              && !string.IsNullOrWhiteSpace(txtTenXB.Text);
        }

        // GẮN SỰ KIỆN TRONG Designer: btnCapNhat.Click += this.btnCapNhat_Click;
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaXB.Text))
            { MessageBox.Show("Chưa có Mã NXB."); return; }

            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand("dbo.CapNhatThongTin", sqlCon))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@maNXB", SqlDbType.Char, 10) { Value = txtMaXB.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@tenNXB", SqlDbType.NVarChar, 100) { Value = txtTenXB.Text.Trim() });
                    cmd.Parameters.Add(new SqlParameter("@diaChi", SqlDbType.NVarChar, 500) { Value = txtDiaChi.Text.Trim() });

                    // ExecuteNonQuery có thể trả 0 nếu trong SP có SET NOCOUNT ON
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    HienThiDanhSachNXB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật: " + ex.Message);
            }
        }
    }
}
