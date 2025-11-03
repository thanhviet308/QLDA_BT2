using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace NguyenThanhViet_1150080163_Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Chuỗi kết nối (đổi lại tên server máy bạn)
        private readonly string strCon = @"Data Source=localhost,1433;
                                    Initial Catalog=QuanLySinhVien;
                                    User ID=sa;
                                    Password=@Viet0337908394;
                                    TrustServerCertificate=True;";

        SqlConnection sqlCon = null;

        // Mở kết nối 
        private void MoKetNoi()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MoKetNoi();
                string query = "SELECT * FROM SinhVien";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlCon);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "SinhVien");

                // Trỏ tới file report (Embedded Resource đúng theo Default Namespace + tên file)
                this.reportViewer1.LocalReport.ReportEmbeddedResource =
                    "NguyenThanhViet_1150080163_Lab8.rptSinhVien.rdlc"; // Tên file RDLC trong project

                // Cấu hình datasource cho report - Name phải trùng với DataSetName trong RDLC (DataSet1)
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1"; // phải khớp với <DataSet Name="DataSet1"> trong RDLC
                rds.Value = ds.Tables["SinhVien"];

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
