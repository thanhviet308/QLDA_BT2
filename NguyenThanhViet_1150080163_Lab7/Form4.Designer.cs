namespace NguyenThanhViet_1150080163_Lab7
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblListTitle;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnXoaDuLieu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblListTitle = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.btnXoaDuLieu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 400);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Text = "Xóa dữ liệu trong database";
            this.lblTitle.Location = new System.Drawing.Point(0, 10);
            this.lblTitle.Size = new System.Drawing.Size(540, 30);
            this.Controls.Add(this.lblTitle);
            // 
            // lblListTitle
            // 
            this.lblListTitle.AutoSize = true;
            this.lblListTitle.Text = "Danh sách nhà xuất bản:";
            this.lblListTitle.Location = new System.Drawing.Point(20, 50);
            this.Controls.Add(this.lblListTitle);
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(20, 70);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowTemplate.Height = 25;
            this.dgvDanhSach.Size = new System.Drawing.Size(490, 250);
            this.dgvDanhSach.TabIndex = 2;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.Controls.Add(this.dgvDanhSach);
            // 
            // btnXoaDuLieu
            // 
            this.btnXoaDuLieu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnXoaDuLieu.Text = "Xóa dữ liệu";
            this.btnXoaDuLieu.Location = new System.Drawing.Point(180, 335);
            this.btnXoaDuLieu.Size = new System.Drawing.Size(180, 40);
            this.btnXoaDuLieu.Enabled = false;
            this.btnXoaDuLieu.Click += new System.EventHandler(this.btnXoaDuLieu_Click);
            this.Controls.Add(this.btnXoaDuLieu);
            // 
            // End layout
            // 
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
