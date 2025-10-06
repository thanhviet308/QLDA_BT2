namespace YourApp
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDSLop;
        private System.Windows.Forms.Label lblDSSV;
        private System.Windows.Forms.ListBox lsbDSLop;
        private System.Windows.Forms.ListView lsvDSSV;
        private System.Windows.Forms.ColumnHeader colMaSV;
        private System.Windows.Forms.ColumnHeader colTenSV;
        private System.Windows.Forms.ColumnHeader colGioiTinh;
        private System.Windows.Forms.ColumnHeader colQueQuan;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDSLop = new System.Windows.Forms.Label();
            this.lblDSSV = new System.Windows.Forms.Label();
            this.lsbDSLop = new System.Windows.Forms.ListBox();
            this.lsvDSSV = new System.Windows.Forms.ListView();
            this.colMaSV = new System.Windows.Forms.ColumnHeader();
            this.colTenSV = new System.Windows.Forms.ColumnHeader();
            this.colGioiTinh = new System.Windows.Forms.ColumnHeader();
            this.colQueQuan = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(200, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(150, 25);
            this.lblTitle.Text = "Áp dụng";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDSLop
            // 
            this.lblDSLop.AutoSize = true;
            this.lblDSLop.Location = new System.Drawing.Point(25, 50);
            this.lblDSLop.Text = "Danh sách lớp:";
            // 
            // lblDSSV
            // 
            this.lblDSSV.AutoSize = true;
            this.lblDSSV.Location = new System.Drawing.Point(230, 50);
            this.lblDSSV.Text = "Danh sách sinh viên:";
            // 
            // lsbDSLop
            // 
            this.lsbDSLop.Location = new System.Drawing.Point(25, 70);
            this.lsbDSLop.Size = new System.Drawing.Size(180, 250);
            this.lsbDSLop.SelectedIndexChanged += new System.EventHandler(this.lsbDSLop_SelectedIndexChanged);
            // 
            // lsvDSSV
            // 
            this.lsvDSSV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.colMaSV,
                this.colTenSV,
                this.colGioiTinh,
                this.colQueQuan});
            this.lsvDSSV.FullRowSelect = true;
            this.lsvDSSV.GridLines = true;
            this.lsvDSSV.Location = new System.Drawing.Point(230, 70);
            this.lsvDSSV.Size = new System.Drawing.Size(370, 250);
            this.lsvDSSV.View = System.Windows.Forms.View.Details;
            // 
            // Columns
            // 
            this.colMaSV.Text = "Mã SV";
            this.colMaSV.Width = 60;
            this.colTenSV.Text = "Tên sinh viên";
            this.colTenSV.Width = 120;
            this.colGioiTinh.Text = "Giới tính";
            this.colGioiTinh.Width = 70;
            this.colQueQuan.Text = "Quê quán";
            this.colQueQuan.Width = 110;
            // 
            // Form6
            // 
            this.ClientSize = new System.Drawing.Size(630, 350);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDSLop);
            this.Controls.Add(this.lblDSSV);
            this.Controls.Add(this.lsbDSLop);
            this.Controls.Add(this.lsvDSSV);
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Áp dụng - Hiển thị sinh viên theo lớp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
