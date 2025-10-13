using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NguyenThanhViet_1150080163_Lab5
{
    public partial class Form3 : Form
    {
        // ===== Chuỗi kết nối dùng đúng đường dẫn bạn nêu =====
        private readonly string _strCon =
@"Data Source=(LocalDB)\MSSQLLocalDB;
  AttachDbFilename=D:\PTPMHDT\NGUYENTHANHVIET_1150080163_LAB5\DBCONNECT.MDF;
  Integrated Security=True;
  Connect Timeout=30;";

        private SqlConnection _con;
        private string _maSVDangChon = "";

        public Form3()
        {
            InitializeComponent();
        }

        // ===== MỞ/ĐÓNG KẾT NỐI =====
        private void MoKetNoi()
        {
            if (_con == null) _con = new SqlConnection(_strCon);
            if (_con.State == ConnectionState.Closed) _con.Open();
        }
        private void DongKetNoi()
        {
            if (_con != null && _con.State == ConnectionState.Open) _con.Close();
        }

        // ===== HIỂN THỊ DS SINH VIÊN LÊN LISTVIEW =====
        private void HienThiDSSinhVien()
        {
            try
            {
                MoKetNoi();

                using (var cmd = new SqlCommand("SELECT * FROM dbo.SinhVien", _con))
                using (var reader = cmd.ExecuteReader())
                {
                    lsvDanhSach.Items.Clear();

                    while (reader.Read())
                    {
                        string maSV = reader.GetString(0);
                        string tenSV = reader.GetString(1);
                        string gioi = reader.GetString(2);
                        string ngay = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                        string que = reader.GetString(4);
                        string maLop = reader.GetString(5);

                        var lvi = new ListViewItem(maSV);
                        lvi.SubItems.Add(tenSV);
                        lvi.SubItems.Add(gioi);
                        lvi.SubItems.Add(ngay);
                        lvi.SubItems.Add(que);
                        lvi.SubItems.Add(maLop);
                        lsvDanhSach.Items.Add(lvi);
                    }
                }

                _maSVDangChon = ""; // reset lựa chọn sau khi tải
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hiển thị danh sách: " + ex.Message);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // ===== FORM LOAD =====
        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDSSinhVien();
        }

        // ===== CHỌN DÒNG TRONG LISTVIEW =====
        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDanhSach.SelectedItems.Count == 0)
            {
                _maSVDangChon = "";
                return;
            }

            var lvi = lsvDanhSach.SelectedItems[0];
            _maSVDangChon = lvi.SubItems[0].Text.Trim(); // MaSV
        }

        // ===== NÚT TẢI LẠI =====
        private void btnTaiLai_Click(object sender, EventArgs e) => HienThiDSSinhVien();

        // ===== NÚT XÓA (không dùng Parameter) =====
        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_maSVDangChon))
            {
                MessageBox.Show("Bạn chưa chọn sinh viên nào để xóa!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(
                $"Bạn có thực sự muốn xóa sinh viên có Mã: {_maSVDangChon} ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            XoaSV(_maSVDangChon);
        }

        // ===== XÓA SV (ExecuteNonQuery, KHÔNG dùng Parameter) =====
        private void XoaSV(string maSV)
        {
            try
            {
                MoKetNoi();

                // chú ý: đây là phiên bản không dùng parameter theo yêu cầu bài
                string sql = "DELETE FROM dbo.SinhVien WHERE MaSV = '" + maSV.Replace("'", "''") + "'";

                using (var cmd = new SqlCommand(sql, _con))
                {
                    int kq = cmd.ExecuteNonQuery();
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa sinh viên thành công!");
                        HienThiDSSinhVien();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy Mã SV để xóa.");
                    }
                }
            }
            catch (SqlException ex)
            {
                // Ví dụ: lỗi khóa ngoại nếu đang bị bảng khác tham chiếu
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
