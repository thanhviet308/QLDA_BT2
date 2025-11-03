namespace NguyenThanhViet_1150080163_Lab7
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Panel panelSep;
        private System.Windows.Forms.GroupBox grpChinhSua;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblTen;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtMaXB;
        private System.Windows.Forms.TextBox txtTenXB;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Button btnChinhSuaThongTin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.panelSep = new System.Windows.Forms.Panel();
            this.grpChinhSua = new System.Windows.Forms.GroupBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblTen = new System.Windows.Forms.Label();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtMaXB = new System.Windows.Forms.TextBox();
            this.txtTenXB = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.btnChinhSuaThongTin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.grpChinhSua.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 380);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            // 
            // lblTitle (tiêu đề chính)
            // 
            this.lblTitle.Text = "Chỉnh sửa thông tin dữ liệu";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.AutoSize = false;
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Size = new System.Drawing.Size(720, 26);
            this.Controls.Add(this.lblTitle);
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Text = "Danh sách nhà xuất bản:";
            this.lblListTitle.Location = new System.Drawing.Point(16, 55);
            this.Controls.Add(this.lblListTitle);
            // 
            // dgvDanhSach (bảng bên trái)
            // 
            this.dgvDanhSach.Location = new System.Drawing.Point(16, 75);
            this.dgvDanhSach.Size = new System.Drawing.Size(330, 280);
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.Controls.Add(this.dgvDanhSach);
            // 
            // panelSep (vạch ngăn cách)
            // 
            this.panelSep.Location = new System.Drawing.Point(360, 55);
            this.panelSep.Size = new System.Drawing.Size(2, 300);
            this.panelSep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelSep);
            // 
            // grpChinhSua (khung bên phải)
            // 
            this.grpChinhSua.Text = "Chỉnh sửa thông tin:";
            this.grpChinhSua.Location = new System.Drawing.Point(380, 70);
            this.grpChinhSua.Size = new System.Drawing.Size(320, 230);
            this.grpChinhSua.Controls.Add(this.lblMa);
            this.grpChinhSua.Controls.Add(this.txtMaXB);
            this.grpChinhSua.Controls.Add(this.lblTen);
            this.grpChinhSua.Controls.Add(this.txtTenXB);
            this.grpChinhSua.Controls.Add(this.lblDiaChi);
            this.grpChinhSua.Controls.Add(this.txtDiaChi);
            this.grpChinhSua.Controls.Add(this.btnChinhSuaThongTin);
            this.Controls.Add(this.grpChinhSua);
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Text = "Mã NXB:";
            this.lblMa.Location = new System.Drawing.Point(20, 35);
            // 
            // txtMaXB
            // 
            this.txtMaXB.Name = "txtMaXB";
            this.txtMaXB.Location = new System.Drawing.Point(100, 32);
            this.txtMaXB.Size = new System.Drawing.Size(190, 23);
            // 
            // lblTen
            // 
            this.lblTen.AutoSize = true;
            this.lblTen.Text = "Tên NXB:";
            this.lblTen.Location = new System.Drawing.Point(20, 75);
            // 
            // txtTenXB
            // 
            this.txtTenXB.Name = "txtTenXB";
            this.txtTenXB.Location = new System.Drawing.Point(100, 72);
            this.txtTenXB.Size = new System.Drawing.Size(190, 23);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Text = "Địa chỉ:";
            this.lblDiaChi.Location = new System.Drawing.Point(20, 115);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Location = new System.Drawing.Point(100, 112);
            this.txtDiaChi.Size = new System.Drawing.Size(190, 23);
            // 
            // btnChinhSuaThongTin
            // 
            this.btnChinhSuaThongTin.Name = "btnChinhSuaThongTin";
            this.btnChinhSuaThongTin.Text = "Chỉnh sửa thông tin";
            this.btnChinhSuaThongTin.Location = new System.Drawing.Point(100, 160);
            this.btnChinhSuaThongTin.Size = new System.Drawing.Size(190, 35);
            this.btnChinhSuaThongTin.Click += new System.EventHandler(this.btnChinhSuaThongTin_Click);
            //
            // finalize
            //
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.grpChinhSua.ResumeLayout(false);
            this.grpChinhSua.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
