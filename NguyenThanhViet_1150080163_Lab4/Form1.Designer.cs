namespace QuanLyBanHang
{
    partial class Form1
    {
        private void InitializeComponent()
        {
            this.btnMoKetNoi = new System.Windows.Forms.Button();
            this.btnDongKetNoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMoKetNoi
            // 
            this.btnMoKetNoi.Location = new System.Drawing.Point(30, 30);
            this.btnMoKetNoi.Name = "btnMoKetNoi";
            this.btnMoKetNoi.Size = new System.Drawing.Size(75, 23);
            this.btnMoKetNoi.TabIndex = 0;
            this.btnMoKetNoi.Text = "Mở kết nối";
            this.btnMoKetNoi.Click += new System.EventHandler(this.btnMoKetNoi_Click);
            // 
            // btnDongKetNoi
            // 
            this.btnDongKetNoi.Location = new System.Drawing.Point(150, 30);
            this.btnDongKetNoi.Name = "btnDongKetNoi";
            this.btnDongKetNoi.Size = new System.Drawing.Size(123, 23);
            this.btnDongKetNoi.TabIndex = 1;
            this.btnDongKetNoi.Text = "Đóng kết nối";
            this.btnDongKetNoi.Click += new System.EventHandler(this.btnDongKetNoi_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 100);
            this.Controls.Add(this.btnMoKetNoi);
            this.Controls.Add(this.btnDongKetNoi);
            this.Name = "Form1";
            this.Text = "Kết nối SQL";
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnMoKetNoi;
        private System.Windows.Forms.Button btnDongKetNoi;
    }
}
