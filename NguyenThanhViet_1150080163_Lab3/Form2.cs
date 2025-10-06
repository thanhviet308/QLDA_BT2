using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ThucHanh2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;

            // Gán sự kiện cho nút
            btnAdd.Click += btnAdd_Click;
            btnEdit.Click += btnEdit_Click;
            btnDelete.Click += btnDelete_Click;
            btnExit.Click += (s, e) => this.Close();

            // Khi chọn 1 dòng -> hiện thông tin lên các ô nhập
            lvStudents.SelectedIndexChanged += lvStudents_SelectedIndexChanged;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Cấu hình ListView
            lvStudents.View = View.Details;
            lvStudents.FullRowSelect = true;
            lvStudents.GridLines = true;
            lvStudents.HideSelection = false;

            // Tạo cột
            lvStudents.Columns.Clear();
            lvStudents.Columns.Add("Họ tên", 180);
            lvStudents.Columns.Add("Ngày sinh", 100);
            lvStudents.Columns.Add("Lớp", 90);
            lvStudents.Columns.Add("Địa chỉ", 220);

            // Giá trị mặc định
            dtpDob.Value = new DateTime(2002, 1, 1);
        }

        // ---------------------- HÀM PHỤ -----------------------
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi nhập liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private ListViewItem GetSelectedItem()
        {
            if (lvStudents.SelectedItems.Count == 0) return null;
            return lvStudents.SelectedItems[0];
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtClass.Clear();
            txtAddress.Clear();
            dtpDob.Value = DateTime.Today;
            txtName.Focus();
        }

        // ---------------------- CHỨC NĂNG -----------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            string name = txtName.Text.Trim();
            string dob = dtpDob.Value.ToShortDateString();
            string cls = txtClass.Text.Trim();
            string addr = txtAddress.Text.Trim();

            var item = new ListViewItem(new string[] { name, dob, cls, addr });
            lvStudents.Items.Add(item);

            ClearInputs();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedItem();
            if (sel == null)
            {
                MessageBox.Show("Hãy chọn 1 dòng để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            sel.SubItems[0].Text = txtName.Text.Trim();
            sel.SubItems[1].Text = dtpDob.Value.ToShortDateString();
            sel.SubItems[2].Text = txtClass.Text.Trim();
            sel.SubItems[3].Text = txtAddress.Text.Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var sel = GetSelectedItem();
            if (sel == null)
            {
                MessageBox.Show("Hãy chọn 1 dòng để xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Xóa dòng đã chọn?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lvStudents.Items.Remove(sel);
                ClearInputs();
            }
        }

        private void lvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            var sel = GetSelectedItem();
            if (sel == null) return;

            txtName.Text = sel.SubItems[0].Text;
            DateTime dob;
            if (DateTime.TryParse(sel.SubItems[1].Text, out dob))
                dtpDob.Value = dob;
            else
                dtpDob.Value = DateTime.Today;

            txtClass.Text = sel.SubItems[2].Text;
            txtAddress.Text = sel.SubItems[3].Text;
        }
    }
}
