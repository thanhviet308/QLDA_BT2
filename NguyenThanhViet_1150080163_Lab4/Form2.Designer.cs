namespace DemoScalar
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCount;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnCount = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCount
            // 
            this.btnCount.Name = "btnCount";
            this.btnCount.Text = "Số lượng sinh viên";
            this.btnCount.Size = new System.Drawing.Size(220, 48);
            this.btnCount.TabIndex = 0;
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            // đặt nút ở giữa form 400x240
            this.btnCount.Location = new System.Drawing.Point(
                (400 - 220) / 2, // 90
                (240 - 48) / 2   // 96
            );
            this.btnCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 240);
            this.Controls.Add(this.btnCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê sinh viên";
            this.ResumeLayout(false);
        }
    }
}
