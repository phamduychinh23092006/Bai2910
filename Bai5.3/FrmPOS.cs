using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CafePOSProject
{
    public partial class FrmPOS : Form
    {
        private FlowLayoutPanel flowPanelBans;
        private DataGridView dgvChiTietHoaDon;
        private ComboBox cbDanhMuc;
        private ComboBox cbMonAn;
        private NumericUpDown numSoLuong;
        private Button btnThemMon;
        private Button btnThanhToan;
        private Button btnQuanLyMenu;

        private int currentTableId = -1;
        private int currentInvoiceId = -1;

        public FrmPOS()
        {
            InitializeCustomLayout();
        }

        private void InitializeCustomLayout()
        {
            this.Text = "Hệ thống Quản lý Quán Cafe - POS";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Sơ đồ bàn (Bên trái)
            flowPanelBans = new FlowLayoutPanel();
            flowPanelBans.Location = new Point(12, 12);
            flowPanelBans.Size = new Size(350, 520);
            flowPanelBans.AutoScroll = true;
            flowPanelBans.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(flowPanelBans);

            // 2. Bảng chi tiết hóa đơn (Bên phải)
            dgvChiTietHoaDon = new DataGridView();
            dgvChiTietHoaDon.Location = new Point(380, 12);
            dgvChiTietHoaDon.Size = new Size(590, 350);
            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(dgvChiTietHoaDon);

            // 3. Điều khiển chọn danh mục, món ăn, số lượng
            Label lblDM = new Label() { Text = "Danh mục:", Location = new Point(380, 380), AutoSize = true };
            cbDanhMuc = new ComboBox() { Location = new Point(380, 400), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            cbDanhMuc.SelectedIndexChanged += cbDanhMuc_SelectedIndexChanged;
            this.Controls.AddRange(new Control[] { lblDM, cbDanhMuc });

            Label lblMon = new Label() { Text = "Món ăn:", Location = new Point(600, 380), AutoSize = true };
            cbMonAn = new ComboBox() { Location = new Point(600, 400), Size = new Size(220, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.AddRange(new Control[] { lblMon, cbMonAn });

            Label lblSL = new Label() { Text = "Số lượng:", Location = new Point(840, 380), AutoSize = true };
            numSoLuong = new NumericUpDown() { Location = new Point(840, 400), Size = new Size(130, 25), Minimum = 1, Value = 1 };
            this.Controls.AddRange(new Control[] { lblSL, numSoLuong });

            // 4. Các nút chức năng
            btnThemMon = new Button() { Text = "Thêm Món", Location = new Point(380, 450), Size = new Size(120, 45), BackColor = Color.LightSkyBlue };
            btnThemMon.Click += btnThemMon_Click;
            this.Controls.Add(btnThemMon);

            btnThanhToan = new Button() { Text = "Thanh Toán", Location = new Point(520, 450), Size = new Size(120, 45), BackColor = Color.LightGreen };
            btnThanhToan.Click += btnThanhToan_Click;
            this.Controls.Add(btnThanhToan);

            btnQuanLyMenu = new Button() { Text = "Quản lý Thực Đơn", Location = new Point(830, 450), Size = new Size(140, 45) };
            btnQuanLyMenu.Click += (s, e) => { new FrmMenuManagement().ShowDialog(); LoadTableButtons(); };
            this.Controls.Add(btnQuanLyMenu);

            this.Load += FrmPOS_Load;
        }

        private void FrmPOS_Load(object sender, EventArgs e)
        {
            LoadTableButtons();
            LoadDanhMuc();
        }

        private void LoadTableButtons()
        {
            flowPanelBans.Controls.Clear();
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT MaBan, TenBan, TrangThai FROM BanAn", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                foreach (DataRow row in dt.Rows)
                {
                    Button btn = new Button();
                    btn.Width = 100;
                    btn.Height = 80;
                    btn.Text = $"{row["TenBan"]}\n({row["TrangThai"]})";
                    btn.Tag = row["MaBan"];
                    btn.Font = new Font("Arial", 9, FontStyle.Bold);

                    if (row["TrangThai"].ToString() == "Có khách")
                    {
                        btn.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        btn.BackColor = Color.LightGreen;
                    }

                    btn.Click += TableButton_Click;
                    flowPanelBans.Controls.Add(btn);
                }
            }
        }

        private void LoadDanhMuc()
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

        private void cbDanhMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDanhMuc.SelectedValue != null && int.TryParse(cbDanhMuc.SelectedValue.ToString(), out int maDanhMuc))
            {
                LoadMonAnTheoDanhMuc(maDanhMuc);
            }
        }

        private void LoadMonAnTheoDanhMuc(int maDanhMuc)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT MaMon, TenMon, DonGia FROM MonAn WHERE MaDanhMuc = @MaDanhMuc", conn);
                cmd.Parameters.AddWithValue("@MaDanhMuc", maDanhMuc);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cbMonAn.DataSource = dt;
                cbMonAn.DisplayMember = "TenMon";
                cbMonAn.ValueMember = "MaMon";
            }
        }

        private void TableButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            currentTableId = Convert.ToInt32(btn.Tag);
            currentInvoiceId = GetUnpaidInvoiceId(currentTableId);

            LoadOrderDetails(currentInvoiceId);
        }

        private int GetUnpaidInvoiceId(int maBan)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT MaHoaDon FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0", conn);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        private void LoadOrderDetails(int maHoaDon)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                string query = @"SELECT m.TenMon, c.SoLuong, c.DonGia, (c.SoLuong * c.DonGia) AS ThanhTien 
                                 FROM ChiTietHoaDon c 
                                 JOIN MonAn m ON c.MaMon = m.MaMon 
                                 WHERE c.MaHoaDon = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvChiTietHoaDon.DataSource = dt;
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (currentTableId == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gọi món!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbMonAn.SelectedValue == null) return;

            int maMon = Convert.ToInt32(cbMonAn.SelectedValue);
            int soLuong = (int)numSoLuong.Value;
            decimal donGia = 0;

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlCommand cmdPrice = new SqlCommand("SELECT DonGia FROM MonAn WHERE MaMon = @MaMon", conn);
                cmdPrice.Parameters.AddWithValue("@MaMon", maMon);
                donGia = Convert.ToDecimal(cmdPrice.ExecuteScalar());

                if (currentInvoiceId == -1)
                {
                    SqlCommand cmdCreateHD = new SqlCommand("INSERT INTO HoaDon (MaBan, GioVao, TrangThai) OUTPUT INSERTED.MaHoaDon VALUES (@MaBan, GETDATE(), 0)", conn);
                    cmdCreateHD.Parameters.AddWithValue("@MaBan", currentTableId);
                    currentInvoiceId = (int)cmdCreateHD.ExecuteScalar();

                    SqlCommand cmdUpdateBan = new SqlCommand("UPDATE BanAn SET TrangThai = N'Có khách' WHERE MaBan = @MaBan", conn);
                    cmdUpdateBan.Parameters.AddWithValue("@MaBan", currentTableId);
                    cmdUpdateBan.ExecuteNonQuery();
                }

                SqlCommand cmdCheck = new SqlCommand("SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon", conn);
                cmdCheck.Parameters.AddWithValue("@MaHoaDon", currentInvoiceId);
                cmdCheck.Parameters.AddWithValue("@MaMon", maMon);
                int exits = (int)cmdCheck.ExecuteScalar();

                if (exits > 0)
                {
                    SqlCommand cmdUpdateCT = new SqlCommand("UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong WHERE MaHoaDon = @MaHoaDon AND MaMon = @MaMon", conn);
                    cmdUpdateCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdUpdateCT.Parameters.AddWithValue("@MaHoaDon", currentInvoiceId);
                    cmdUpdateCT.Parameters.AddWithValue("@MaMon", maMon);
                    cmdUpdateCT.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmdInsertCT = new SqlCommand("INSERT INTO ChiTietHoaDon (MaHoaDon, MaMon, SoLuong, DonGia) VALUES (@MaHoaDon, @MaMon, @SoLuong, @DonGia)", conn);
                    cmdInsertCT.Parameters.AddWithValue("@MaHoaDon", currentInvoiceId);
                    cmdInsertCT.Parameters.AddWithValue("@MaMon", maMon);
                    cmdInsertCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdInsertCT.Parameters.AddWithValue("@DonGia", donGia);
                    cmdInsertCT.ExecuteNonQuery();
                }
            }

            LoadOrderDetails(currentInvoiceId);
            LoadTableButtons();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentInvoiceId == -1 || currentTableId == -1)
            {
                MessageBox.Show("Bàn này không có hóa đơn nào để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = 0;
            if (dgvChiTietHoaDon.DataSource is DataTable dt)
            {
                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }
            }

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    SqlCommand cmdHD = new SqlCommand("UPDATE HoaDon SET GioRa = GETDATE(), TongTien = @TongTien, TrangThai = 1 WHERE MaHoaDon = @MaHoaDon", conn, transaction);
                    cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                    cmdHD.Parameters.AddWithValue("@MaHoaDon", currentInvoiceId);
                    cmdHD.ExecuteNonQuery();

                    SqlCommand cmdBan = new SqlCommand("UPDATE BanAn SET TrangThai = N'Trống' WHERE MaBan = @MaBan", conn, transaction);
                    cmdBan.Parameters.AddWithValue("@MaBan", currentTableId);
                    cmdBan.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show($"Thanh toán thành công!\nTổng tiền: {tongTien:N0} VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    currentInvoiceId = -1;
                    currentTableId = -1;
                    dgvChiTietHoaDon.DataSource = null;
                    LoadTableButtons();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}