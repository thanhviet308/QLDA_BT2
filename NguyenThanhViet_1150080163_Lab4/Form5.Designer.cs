namespace YourApp
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblNhapTenKhoa;
        private System.Windows.Forms.TextBox txtNhapTenKhoa;
        private System.Windows.Forms.Button btnXemDS;
        private System.Windows.Forms.ListView lsvDanhSach;
        private System.Windows.Forms.ColumnHeader colTenLop;
        private System.Windows.Forms.ColumnHeader colMaLop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNhapTenKhoa = new System.Windows.Forms.Label();
            this.txtNhapTenKhoa = new System.Windows.Forms.TextBox();
            this.btnXemDS = new System.Windows.Forms.Button();
            this.lsvDanhSach = new System.Windows.Forms.ListView();
            this.colTenLop = new System.Windows.Forms.ColumnHeader();
            this.colMaLop = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblNhapTenKhoa
            // 
            this.lblNhapTenKhoa.AutoSize = true;
            this.lblNhapTenKhoa.Location = new System.Drawing.Point(20, 20);
            this.lblNhapTenKhoa.Name = "lblNhapTenKhoa";
            this.lblNhapTenKhoa.Size = new System.Drawing.Size(90, 15);
            this.lblNhapTenKhoa.Text = "Nhập tên khoa:";
            // 
            // txtNhapTenKhoa
            // 
            this.txtNhapTenKhoa.Location = new System.Drawing.Point(120, 17);
            this.txtNhapTenKhoa.Name = "txtNhapTenKhoa";
            this.txtNhapTenKhoa.Size = new System.Drawing.Size(260, 23);
            // 
            // btnXemDS
            // 
            this.btnXemDS.Location = new System.Drawing.Point(20, 55);
            this.btnXemDS.Name = "btnXemDS";
            this.btnXemDS.Size = new System.Drawing.Size(360, 32);
            this.btnXemDS.Text = "Xem danh sách";
            this.btnXemDS.UseVisualStyleBackColor = true;
            this.btnXemDS.Click += new System.EventHandler(this.btnXemDS_Click);
            // 
            // lsvDanhSach
            // 
            this.lsvDanhSach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTenLop,
            this.colMaLop});
            this.lsvDanhSach.FullRowSelect = true;
            this.lsvDanhSach.GridLines = true;
            this.lsvDanhSach.HideSelection = false;
            this.lsvDanhSach.Location = new System.Drawing.Point(20, 100);
            this.lsvDanhSach.Name = "lsvDanhSach";
            this.lsvDanhSach.Size = new System.Drawing.Size(360, 220);
            this.lsvDanhSach.UseCompatibleStateImageBehavior = false;
            this.lsvDanhSach.View = System.Windows.Forms.View.Details;
            // 
            // colTenLop
            // 
            this.colTenLop.Text = "Tên lớp";
            this.colTenLop.Width = 230;
            // 
            // colMaLop
            // 
            this.colMaLop.Text = "Mã lớp";
            this.colMaLop.Width = 110;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 340);
            this.Controls.Add(this.lsvDanhSach);
            this.Controls.Add(this.btnXemDS);
            this.Controls.Add(this.txtNhapTenKhoa);
            this.Controls.Add(this.lblNhapTenKhoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra cứu lớp theo khoa";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
