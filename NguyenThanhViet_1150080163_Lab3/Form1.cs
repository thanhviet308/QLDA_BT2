using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;              // ✅ cần để tải ảnh từ URL
using System.Windows.Forms;
using System.Drawing;          // ✅ cần để xử lý hình ảnh

namespace FastFoodOrderApp
{
    public partial class Form1 : Form
    {
        // Model món ăn
        public class FoodItem
        {
            public string TenMon { get; set; }
            public int SoLuong { get; set; }
        }

        // Danh sách order hiện tại
        private List<FoodItem> orderList = new List<FoodItem>();

        // Danh sách món ăn hiển thị trên nút
        private string[] menu = new string[]
        {
            "Cơm chiên trứng", "Bánh mì ốp la", "Coca", "Lipton",
            "Ốc rang muối", "Khoai tây chiên", "7 up", "Cam",
            "Mỳ xào hải sản", "Cá viên chiên", "Pepsi", "Cafe",
            "Burger bò nướng", "Đùi gà rán", "Bún bò Huế"
        };

        public Form1()
        {
            InitializeComponent();
            LoadForm();
        }

        // === Load giao diện và dữ liệu ban đầu ===
        private void LoadForm()
        {
            // Tiêu đề
            lblTitle.Text = "Quán ăn nhanh Thành Việt";
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            pnlTitle.BackColor = System.Drawing.Color.ForestGreen;

            // ✅ Tải ảnh logo từ link online
            LoadOnlineLogo("https://png.pngtree.com/png-vector/20240715/ourmid/pngtree-hamburger-png-image_13094305.png");

            // Load danh sách bàn
            for (int i = 1; i <= 10; i++) cboTable.Items.Add("Bàn " + i);
            cboTable.SelectedIndex = 0;

            // Sinh nút món ăn trong FlowLayoutPanel
            foreach (string tenMon in menu)
            {
                Button btn = new Button();
                btn.Text = tenMon;
                btn.Width = 120;
                btn.Height = 35;
                btn.Margin = new Padding(5);
                btn.Click += Btn_Click; // Gắn sự kiện click
                flpMenu.Controls.Add(btn);
            }

            // Cấu hình DataGridView
            dgvOrder.Columns.Clear();
            dgvOrder.Columns.Add("TenMon", "Tên món");
            dgvOrder.Columns.Add("SoLuong", "Số lượng");
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.RowHeadersVisible = false;
        }

        // === Hàm tải ảnh logo online ===
        private void LoadOnlineLogo(string url)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    byte[] data = wc.DownloadData(url);
                    using (MemoryStream ms = new MemoryStream(data))
                    {
                        pbLogo.Image = Image.FromStream(ms);
                        pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được ảnh logo: " + ex.Message, "Lỗi ảnh");
            }
        }

        // === Khi click vào 1 nút món ===
        private void Btn_Click(object sender, EventArgs e)
        {
            string tenMon = (sender as Button) != null ? (sender as Button).Text : "";

            // Tìm xem món đã có trong orderList chưa
            FoodItem existing = orderList.FirstOrDefault(x => x.TenMon == tenMon);
            if (existing != null)
            {
                existing.SoLuong++; // tăng số lượng
            }
            else
            {
                orderList.Add(new FoodItem { TenMon = tenMon, SoLuong = 1 });
            }

            RefreshGrid();
        }

        // === Làm mới DataGridView ===
        private void RefreshGrid()
        {
            dgvOrder.Rows.Clear();
            foreach (FoodItem item in orderList)
            {
                dgvOrder.Rows.Add(item.TenMon, item.SoLuong);
            }
        }

        // === Nút Xóa món đang chọn ===
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvOrder.CurrentRow != null)
            {
                string tenMon = Convert.ToString(dgvOrder.CurrentRow.Cells[0].Value);
                orderList.RemoveAll(x => x.TenMon == tenMon);
                RefreshGrid();
            }
        }

        // === Nút Order ===
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (orderList.Count == 0)
            {
                MessageBox.Show("Chưa có món nào được chọn!", "Thông báo");
                return;
            }

            string tenBan = Convert.ToString(cboTable.SelectedItem);
            string fileName = tenBan.Replace(" ", "_") + "_Order.txt";

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("=== DANH SÁCH ORDER CHO " + tenBan.ToUpper() + " ===");
                foreach (FoodItem item in orderList)
                    sw.WriteLine(item.TenMon + " - SL: " + item.SoLuong);
                sw.WriteLine("===============================");
                sw.WriteLine("Thời gian: " + DateTime.Now.ToString());
            }

            MessageBox.Show("Đã lưu order ra file " + fileName, "Thông báo");
            orderList.Clear();
            RefreshGrid();
        }
    }
}
