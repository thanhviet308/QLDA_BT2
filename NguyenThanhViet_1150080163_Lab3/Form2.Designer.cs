namespace ThucHanh2
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitleTop = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbList = new System.Windows.Forms.GroupBox();
            this.lvStudents = new System.Windows.Forms.ListView();
            this.gbInfo.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.gbList.SuspendLayout();
            this.SuspendLayout();
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 520);
            this.MinimumSize = new System.Drawing.Size(836, 559);
            this.Name = "Form2";
            this.Text = "Danh sách sinh viên";
            // 
            // lblTitleTop
            // 
            this.lblTitleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleTop.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitleTop.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitleTop.Location = new System.Drawing.Point(0, 0);
            this.lblTitleTop.Name = "lblTitleTop";
            this.lblTitleTop.Size = new System.Drawing.Size(820, 60);
            this.lblTitleTop.TabIndex = 0;
            this.lblTitleTop.Text = "DANH MỤC SINH VIÊN";
            this.lblTitleTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtAddress);
            this.gbInfo.Controls.Add(this.label4);
            this.gbInfo.Controls.Add(this.txtClass);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.dtpDob);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.txtName);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Location = new System.Drawing.Point(12, 70);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(796, 120);
            this.gbInfo.TabIndex = 1;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Thông tin sinh viên:";
            // 
            // label1 (Họ tên)
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.Text = "Họ tên:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 23);
            // 
            // label3 (Lớp)
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.Text = "Lớp:";
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(420, 26);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(150, 23);
            // 
            // label2 (Ngày sinh)
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.Text = "Ngày sinh:";
            // 
            // dtpDob
            // 
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(80, 68);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(120, 23);
            // 
            // label4 (Địa chỉ)
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 15);
            this.label4.Text = "Địa chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(270, 68);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(400, 23);
            // 
            // gbActions
            // 
            this.gbActions.Controls.Add(this.btnExit);
            this.gbActions.Controls.Add(this.btnDelete);
            this.gbActions.Controls.Add(this.btnEdit);
            this.gbActions.Controls.Add(this.btnAdd);
            this.gbActions.Location = new System.Drawing.Point(12, 196);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(796, 72);
            this.gbActions.TabIndex = 2;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Chức năng:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(150, 28);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 30);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(276, 28);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(676, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // gbList
            // 
            this.gbList.Controls.Add(this.lvStudents);
            this.gbList.Location = new System.Drawing.Point(12, 274);
            this.gbList.Name = "gbList";
            this.gbList.Size = new System.Drawing.Size(796, 222);
            this.gbList.TabIndex = 3;
            this.gbList.TabStop = false;
            this.gbList.Text = "Thông tin chung sinh viên:";
            // 
            // lvStudents
            // 
            this.lvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvStudents.Location = new System.Drawing.Point(3, 19);
            this.lvStudents.Name = "lvStudents";
            this.lvStudents.Size = new System.Drawing.Size(790, 200);
            this.lvStudents.TabIndex = 0;
            this.lvStudents.UseCompatibleStateImageBehavior = false; // sẽ set View=Details trong code-behind
            // 
            // Add controls to Form
            // 
            this.Controls.Add(this.gbList);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.lblTitleTop);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitleTop;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbList;
        private System.Windows.Forms.ListView lvStudents;
    }
}
