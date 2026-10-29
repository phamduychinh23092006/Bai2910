using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using HotelDAL;

namespace HotelGUI
{
    public partial class FrmQuanLyPhong : Form
    {
        private DataGridView dgvPhong;
        private TextBox txtTimKiem;
        private Label lblTimKiem;
        private DataTable dtPhong;
        private DataView dvPhong;

        public FrmQuanLyPhong()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "Quản lý & Tìm kiếm Phòng Khách Sạn";
            this.Size = new Size(800, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Label hướng dẫn tìm kiếm
            lblTimKiem = new Label();
            lblTimKiem.Text = "Tìm kiếm (Loại phòng / Trạng thái):";
            lblTimKiem.Location = new Point(12, 15);
            lblTimKiem.AutoSize = true;
            this.Controls.Add(lblTimKiem);

            // 2. Ô nhập từ khóa tìm kiếm
            txtTimKiem = new TextBox();
            txtTimKiem.Location = new Point(230, 12);
            txtTimKiem.Size = new Size(300, 25);
            txtTimKiem.TextChanged += new EventHandler(this.txtTimKiem_TextChanged);
            this.Controls.Add(txtTimKiem);

            // 3. Bảng hiển thị danh sách phòng
            dgvPhong = new DataGridView();
            dgvPhong.Location = new Point(12, 50);
            dgvPhong.Size = new Size(760, 390);
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dgvPhong);

            this.Load += new EventHandler(this.FrmQuanLyPhong_Load);
        }

        private void FrmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadDataPhong();
        }

        // Nạp dữ liệu phòng dùng SqlDataAdapter (Disconnected Model)
        private void LoadDataPhong()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Phong", conn);
                dtPhong = new DataTable();
                da.Fill(dtPhong);

                // Gán vào DataView để lọc dữ liệu trực tiếp trên client
                dvPhong = new DataView(dtPhong);
                dgvPhong.DataSource = dvPhong;
            }
        }

        // Sự kiện lọc theo Loại phòng hoặc Trạng thái
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                dvPhong.RowFilter = "";
            }
            else
            {
                // Lọc theo LoaiPhong hoặc TrangThai chứa từ khóa
                dvPhong.RowFilter = $"LoaiPhong LIKE '%{keyword}%' OR TrangThai LIKE '%{keyword}%'";
            }
        }
    }
}