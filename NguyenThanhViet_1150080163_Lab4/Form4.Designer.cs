namespace YourApp
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnListView;
        private System.Windows.Forms.ListView lsvList;
        private System.Windows.Forms.ColumnHeader colMaSV;
        private System.Windows.Forms.ColumnHeader colTenSV;
        private System.Windows.Forms.ColumnHeader colGioiTinh;
        private System.Windows.Forms.ColumnHeader colQueQuan;
        private System.Windows.Forms.ColumnHeader colMaLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnListView = new System.Windows.Forms.Button();
            this.lsvList = new System.Windows.Forms.ListView();
            this.colMaSV = new System.Windows.Forms.ColumnHeader();
            this.colTenSV = new System.Windows.Forms.ColumnHeader();
            this.colGioiTinh = new System.Windows.Forms.ColumnHeader();
            this.colQueQuan = new System.Windows.Forms.ColumnHeader();
            this.colMaLop = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(40, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Hiển thị thông tin các sinh viên";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnListView
            // 
            this.btnListView.Location = new System.Drawing.Point(220, 50);
            this.btnListView.Name = "btnListView";
            this.btnListView.Size = new System.Drawing.Size(200, 35);
            this.btnListView.TabIndex = 1;
            this.btnListView.Text = "Xem danh sách";
            this.btnListView.UseVisualStyleBackColor = true;
            this.btnListView.Click += new System.EventHandler(this.btnListView_Click);
            // 
            // lsvList
            // 
            this.lsvList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMaSV,
            this.colTenSV,
            this.colGioiTinh,
            this.colQueQuan,
            this.colMaLop});
            this.lsvList.FullRowSelect = true;
            this.lsvList.GridLines = true;
            this.lsvList.HideSelection = false;
            this.lsvList.Location = new System.Drawing.Point(25, 100);
            this.lsvList.Name = "lsvList";
            this.lsvList.Size = new System.Drawing.Size(570, 260);
            this.lsvList.TabIndex = 2;
            this.lsvList.UseCompatibleStateImageBehavior = false;
            this.lsvList.View = System.Windows.Forms.View.Details;
            // 
            // Columns
            // 
            this.colMaSV.Text = "Mã sinh viên";
            this.colMaSV.Width = 100;
            this.colTenSV.Text = "Tên sinh viên";
            this.colTenSV.Width = 180;
            this.colGioiTinh.Text = "Giới tính";
            this.colGioiTinh.Width = 80;
            this.colQueQuan.Text = "Quê quán";
            this.colQueQuan.Width = 140;
            this.colMaLop.Text = "Mã lớp";
            this.colMaLop.Width = 70;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 380);
            this.Controls.Add(this.lsvList);
            this.Controls.Add(this.btnListView);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên";
            this.ResumeLayout(false);
        }
    }
}
