using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CafePOSProject
{
    public partial class FrmMenuManagement : Form
    {
        private DataGridView dgvMenu;
        private TextBox txtTenMon;
        private TextBox txtDonGia;
        private ComboBox cbDanhMuc;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private ErrorProvider errorProvider1;
        private int selectedMaMon = -1;

        public FrmMenuManagement()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "Quản lý Thực đơn & Món ăn";
            this.Size = new Size(750, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            errorProvider1 = new ErrorProvider();

            dgvMenu = new DataGridView();
            dgvMenu.Location = new Point(12, 12);
            dgvMenu.Size = new Size(450, 400);
            dgvMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMenu.CellClick += DgvMenu_CellClick;
            this.Controls.Add(dgvMenu);

            Label lbl1 = new Label() { Text = "Tên món:", Location = new Point(480, 20), AutoSize = true };
            txtTenMon = new TextBox() { Location = new Point(480, 45), Size = new Size(220, 25) };
            this.Controls.AddRange(new Control[] { lbl1, txtTenMon });

            Label lbl2 = new Label() { Text = "Danh mục:", Location = new Point(480, 85), AutoSize = true };
            cbDanhMuc = new ComboBox() { Location = new Point(480, 110), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.AddRange(new Control[] { lbl2, cbDanhMuc });

            Label lbl3 = new Label() { Text = "Đơn giá:", Location = new Point(480, 150), AutoSize = true };
            txtDonGia = new TextBox() { Location = new Point(480, 175), Size = new Size(220, 25) };
            this.Controls.AddRange(new Control[] { lbl3, txtDonGia });

            btnThem = new Button() { Text = "Thêm", Location = new Point(480, 230), Size = new Size(70, 35) };
            btnThem.Click += BtnThem_Click;

            btnSua = new Button() { Text = "Sửa", Location = new Point(560, 230), Size = new Size(70, 35) };
            btnSua.Click += BtnSua_Click;

            btnXoa = new Button() { Text = "Xóa", Location = new Point(640, 230), Size = new Size(70, 35) };
            btnXoa.Click += BtnXoa_Click;

            this.Controls.AddRange(new Control[] { btnThem, btnSua, btnXoa });

            this.Load += FrmMenuManagement_Load;
        }

        private void FrmMenuManagement_Load(object sender, EventArgs e)
        {
            LoadComboBoxDanhMuc();
            LoadDataGridMenu();
        }

        private void LoadComboBoxDanhMuc()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DanhMuc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbDanhMuc.DataSource = dt;
                cbDanhMuc.DisplayMember = "TenDanhMuc";
                cbDanhMuc.ValueMember = "MaDanhMuc";
            }
        }

        private void LoadDataGridMenu()
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = @"SELECT m.MaMon, m.TenMon, d.TenDanhMuc, m.DonGia, m.MaDanhMuc 
                                 FROM MonAn m JOIN DanhMuc d ON m.MaDanhMuc = d.MaDanhMuc";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMenu.DataSource = dt;
                if (dgvMenu.Columns["MaDanhMuc"] != null)
                    dgvMenu.Columns["MaDanhMuc"].Visible = false;
            }
        }

        private bool ValidateInput()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtTenMon.Text))
            {
                errorProvider1.SetError(txtTenMon, "Tên món không được để trống!");
                isValid = false;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                errorProvider1.SetError(txtDonGia, "Đơn giá phải là số hợp lệ và lớn hơn hoặc bằng 0!");
                isValid = false;
            }

            return isValid;
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia) VALUES (@TenMon, @MaDanhMuc, @DonGia)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDanhMuc", cbDanhMuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@DonGia", decimal.Parse(txtDonGia.Text));
                    cmd.ExecuteNonQuery();
                }
            }
            LoadDataGridMenu();
            MessageBox.Show("Thêm món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (selectedMaMon == -1)
            {
                MessageBox.Show("Vui lòng chọn món cần sửa trong bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInput()) return;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                string query = "UPDATE MonAn SET TenMon = @TenMon, MaDanhMuc = @MaDanhMuc, DonGia = @DonGia WHERE MaMon = @MaMon";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text.Trim());
                    cmd.Parameters.AddWithValue("@MaDanhMuc", cbDanhMuc.SelectedValue);
                    cmd.Parameters.AddWithValue("@DonGia", decimal.Parse(txtDonGia.Text));
                    cmd.Parameters.AddWithValue("@MaMon", selectedMaMon);
                    cmd.ExecuteNonQuery();
                }
            }
            LoadDataGridMenu();
            MessageBox.Show("Cập nhật món thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (selectedMaMon == -1)
            {
                MessageBox.Show("Vui lòng chọn món cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM MonAn WHERE MaMon = @MaMon";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@MaMon", selectedMaMon);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadDataGridMenu();
                    selectedMaMon = -1;
                    txtTenMon.Clear();
                    txtDonGia.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa món này do đã phát sinh hóa đơn giao dịch cũ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];
                selectedMaMon = Convert.ToInt32(row.Cells["MaMon"].Value);
                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                cbDanhMuc.Text = row.Cells["TenDanhMuc"].Value.ToString();
            }
        }
    }
}