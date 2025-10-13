using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab5
{
    public partial class Form4 : Form
    {
        // Chuỗi kết nối tới DBConnect.mdf (LocalDB)
        private readonly string _strCon =
@"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=D:\PTPMHDT\NGUYENTHANHVIET_1150080163_LAB5\DBCONNECT.MDF;
  Integrated Security=True;
  Connect Timeout=30;";

        private SqlConnection _con;
        private string _maSVDangChon = "";

        public Form4()
        {
            InitializeComponent();
        }

        // ===== KẾT NỐI =====
        private void MoKetNoi()
        {
            if (_con == null) _con = new SqlConnection(_strCon);
            if (_con.State == ConnectionState.Closed) _con.Open();
        }
        private void DongKetNoi()
        {
            if (_con != null && _con.State == ConnectionState.Open) _con.Close();
        }

        // ===== LOAD DANH SÁCH LÊN LISTVIEW =====
        private void TaiDanhSach()
        {
            try
            {
                MoKetNoi();
                using (var cmd = new SqlCommand(
                    "SELECT MaSV, TenSV, GioiTinh, NgaySinh, QueQuan, MaLop FROM dbo.SinhVien", _con))
                using (var reader = cmd.ExecuteReader())
                {
                    lsvDanhSach.Items.Clear();
                    while (reader.Read())
                    {
                        string maSV = reader.GetString(0);
                        string tenSV = reader.GetString(1);
                        string gt = reader.GetString(2);
                        string ns = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                        string qq = reader.GetString(4);
                        string maLop = reader.GetString(5);

                        var lvi = new ListViewItem(maSV);
                        lvi.SubItems.Add(tenSV);
                        lvi.SubItems.Add(gt);
                        lvi.SubItems.Add(ns);
                        lvi.SubItems.Add(qq);
                        lvi.SubItems.Add(maLop);
                        lsvDanhSach.Items.Add(lvi);
                    }
                }
                _maSVDangChon = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // ===== FORM LOAD =====
        private void Form3_Load(object sender, EventArgs e) => TaiDanhSach();

        // ===== CHỌN DÒNG =====
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0) { _maSVDangChon = ""; return; }
            _maSVDangChon = lsvDanhSach.SelectedItems[0].SubItems[0].Text.Trim();
        }

        // ===== NÚT TẢI LẠI =====
        private void btnTaiLai_Click(object sender, EventArgs e) => TaiDanhSach();

        // ===== NÚT XÓA (DÙNG PARAMETER) =====
        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maSVDangChon))
            {
                MessageBox.Show("Bạn chưa chọn sinh viên nào để xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var cf = MessageBox.Show($"Bạn có chắc muốn xóa SV: {_maSVDangChon} ?",
                                     "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cf != DialogResult.Yes) return;

            XoaSinhVien(_maSVDangChon);
        }

        // ===== HÀM XÓA BẰNG PARAMETER =====
        private void XoaSinhVien(string maSV)
        {
            try
            {
                MoKetNoi();

                const string sql = "DELETE FROM dbo.SinhVien WHERE MaSV = @MaSV";
                using (var cmd = new SqlCommand(sql, _con))
                {
                    // Khai báo tham số đúng kiểu & độ dài
                    cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 10).Value = maSV;

                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa sinh viên thành công!");
                        TaiDanhSach();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Mã SV để xóa.");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Ví dụ: lỗi khóa ngoại nếu SV đang bị bảng khác tham chiếu
                MessageBox.Show("Xóa thất bại (SQL): " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        private void lblTieuDe_Click(object sender, EventArgs e)
        {

        }
    }
}
