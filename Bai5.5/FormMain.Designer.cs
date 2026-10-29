namespace InventoryManagement
{
    partial class formMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpPhieuKho = new System.Windows.Forms.TabPage();
            this.lblTongTienPhieu = new System.Windows.Forms.Label();
            this.btnLuuPhieu = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.dgvChiTietPhieu = new System.Windows.Forms.DataGridView();
            this.nudDonGia = new System.Windows.Forms.NumericUpDown();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cboVatTu = new System.Windows.Forms.ComboBox();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.cboLoaiPhieu = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpVatTu = new System.Windows.Forms.TabPage();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.btnThemVatTu = new System.Windows.Forms.Button();
            this.txtTonDau = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtTenVT = new System.Windows.Forms.TextBox();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.dgvVatTu = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tpCanhBao = new System.Windows.Forms.TabPage();
            this.lblTongGiaTriKho = new System.Windows.Forms.Label();
            this.btnTinhTongGiaTri = new System.Windows.Forms.Button();
            this.btnLocCanhBao = new System.Windows.Forms.Button();
            this.nudNguong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCanhBao = new System.Windows.Forms.DataGridView();
            this.tcMain.SuspendLayout();
            this.tpPhieuKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.tpVatTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).BeginInit();
            this.tpCanhBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNguong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpPhieuKho);
            this.tcMain.Controls.Add(this.tpVatTu);
            this.tcMain.Controls.Add(this.tpCanhBao);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(884, 561);
            this.tcMain.TabIndex = 0;
            // 
            // tpPhieuKho
            // 
            this.tpPhieuKho.Controls.Add(this.lblTongTienPhieu);
            this.tpPhieuKho.Controls.Add(this.btnLuuPhieu);
            this.tpPhieuKho.Controls.Add(this.btnThemMon);
            this.tpPhieuKho.Controls.Add(this.dgvChiTietPhieu);
            this.tpPhieuKho.Controls.Add(this.nudDonGia);
            this.tpPhieuKho.Controls.Add(this.nudSoLuong);
            this.tpPhieuKho.Controls.Add(this.cboVatTu);
            this.tpPhieuKho.Controls.Add(this.cboNCC);
            this.tpPhieuKho.Controls.Add(this.cboLoaiPhieu);
            this.tpPhieuKho.Controls.Add(this.label6);
            this.tpPhieuKho.Controls.Add(this.label5);
            this.tpPhieuKho.Controls.Add(this.label4);
            this.tpPhieuKho.Controls.Add(this.label3);
            this.tpPhieuKho.Controls.Add(this.label2);
            this.tpPhieuKho.Location = new System.Drawing.Point(4, 22);
            this.tpPhieuKho.Name = "tpPhieuKho";
            this.tpPhieuKho.Padding = new System.Windows.Forms.Padding(3);
            this.tpPhieuKho.Size = new System.Drawing.Size(876, 535);
            this.tpPhieuKho.TabIndex = 0;
            this.tpPhieuKho.Text = "Lập Phiếu Nhập / Xuất Kho";
            this.tpPhieuKho.UseVisualStyleBackColor = true;
            // 
            // lblTongTienPhieu
            // 
            this.lblTongTienPhieu.AutoSize = true;
            this.lblTongTienPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTienPhieu.ForeColor = System.Drawing.Color.Red;
            this.lblTongTienPhieu.Location = new System.Drawing.Point(18, 485);
            this.lblTongTienPhieu.Name = "lblTongTienPhieu";
            this.lblTongTienPhieu.Size = new System.Drawing.Size(183, 20);
            this.lblTongTienPhieu.TabIndex = 13;
            this.lblTongTienPhieu.Text = "Tổng tiền phiếu: 0 VNĐ";
            // 
            // btnLuuPhieu
            // 
            this.btnLuuPhieu.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnLuuPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuPhieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuPhieu.Location = new System.Drawing.Point(680, 470);
            this.btnLuuPhieu.Name = "btnLuuPhieu";
            this.btnLuuPhieu.Size = new System.Drawing.Size(175, 45);
            this.btnLuuPhieu.TabIndex = 12;
            this.btnLuuPhieu.Text = "LƯU PHIẾU KHO";
            this.btnLuuPhieu.UseVisualStyleBackColor = false;
            this.btnLuuPhieu.Click += new System.EventHandler(this.btnLuuPhieu_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(710, 60);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(145, 23);
            this.btnThemMon.TabIndex = 11;
            this.btnThemMon.Text = "Thêm Vào Danh Sách";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // dgvChiTietPhieu
            // 
            this.dgvChiTietPhieu.AllowUserToAddRows = false;
            this.dgvChiTietPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPhieu.Location = new System.Drawing.Point(22, 100);
            this.dgvChiTietPhieu.Name = "dgvChiTietPhieu";
            this.dgvChiTietPhieu.ReadOnly = true;
            this.dgvChiTietPhieu.Size = new System.Drawing.Size(833, 350);
            this.dgvChiTietPhieu.TabIndex = 10;
            // 
            // nudDonGia
            // 
            this.nudDonGia.DecimalPlaces = 2;
            this.nudDonGia.Location = new System.Drawing.Point(540, 61);
            this.nudDonGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudDonGia.Name = "nudDonGia";
            this.nudDonGia.Size = new System.Drawing.Size(150, 20);
            this.nudDonGia.TabIndex = 9;
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.DecimalPlaces = 2;
            this.nudSoLuong.Location = new System.Drawing.Point(300, 61);
            this.nudSoLuong.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(150, 20);
            this.nudSoLuong.TabIndex = 8;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboVatTu
            // 
            this.cboVatTu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVatTu.FormattingEnabled = true;
            this.cboVatTu.Location = new System.Drawing.Point(80, 60);
            this.cboVatTu.Name = "cboVatTu";
            this.cboVatTu.Size = new System.Drawing.Size(150, 21);
            this.cboVatTu.TabIndex = 7;
            // 
            // cboNCC
            // 
            this.cboNCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new System.Drawing.Point(340, 20);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(350, 21);
            this.cboNCC.TabIndex = 6;
            // 
            // cboLoaiPhieu
            // 
            this.cboLoaiPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiPhieu.FormattingEnabled = true;
            this.cboLoaiPhieu.Items.AddRange(new object[] { "NHAP", "XUAT" });
            this.cboLoaiPhieu.Location = new System.Drawing.Point(80, 20);
            this.cboLoaiPhieu.Name = "cboLoaiPhieu";
            this.cboLoaiPhieu.Size = new System.Drawing.Size(150, 21);
            this.cboLoaiPhieu.TabIndex = 5;
            this.cboLoaiPhieu.SelectedIndexChanged += new System.EventHandler(this.cboLoaiPhieu_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Đơn giá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vật tư:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nhà cung cấp:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại phiếu:";
            // 
            // tpVatTu
            // 
            this.tpVatTu.Controls.Add(this.btnSearch);
            this.tpVatTu.Controls.Add(this.txtSearchKey);
            this.tpVatTu.Controls.Add(this.btnThemVatTu);
            this.tpVatTu.Controls.Add(this.txtTonDau);
            this.tpVatTu.Controls.Add(this.txtDVT);
            this.tpVatTu.Controls.Add(this.txtTenVT);
            this.tpVatTu.Controls.Add(this.txtMaVT);
            this.tpVatTu.Controls.Add(this.dgvVatTu);
            this.tpVatTu.Controls.Add(this.label10);
            this.tpVatTu.Controls.Add(this.label9);
            this.tpVatTu.Controls.Add(this.label8);
            this.tpVatTu.Controls.Add(this.label7);
            this.tpVatTu.Location = new System.Drawing.Point(4, 22);
            this.tpVatTu.Name = "tpVatTu";
            this.tpVatTu.Padding = new System.Windows.Forms.Padding(3);
            this.tpVatTu.Size = new System.Drawing.Size(876, 535);
            this.tpVatTu.TabIndex = 1;
            this.tpVatTu.Text = "Quản Lý Vật Tư";
            this.tpVatTu.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(760, 105);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(520, 107);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(230, 20);
            this.txtSearchKey.TabIndex = 10;
            // 
            // btnThemVatTu
            // 
            this.btnThemVatTu.Location = new System.Drawing.Point(85, 105);
            this.btnThemVatTu.Name = "btnThemVatTu";
            this.btnThemVatTu.Size = new System.Drawing.Size(100, 25);
            this.btnThemVatTu.TabIndex = 9;
            this.btnThemVatTu.Text = "Thêm Vật Tư";
            this.btnThemVatTu.UseVisualStyleBackColor = true;
            this.btnThemVatTu.Click += new System.EventHandler(this.btnThemVatTu_Click);
            // 
            // txtTonDau
            // 
            this.txtTonDau.Location = new System.Drawing.Point(520, 60);
            this.txtTonDau.Name = "txtTonDau";
            this.txtTonDau.Size = new System.Drawing.Size(150, 20);
            this.txtTonDau.TabIndex = 8;
            this.txtTonDau.Text = "0";
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(85, 60);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(150, 20);
            this.txtDVT.TabIndex = 7;
            // 
            // txtTenVT
            // 
            this.txtTenVT.Location = new System.Drawing.Point(520, 20);
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.Size = new System.Drawing.Size(335, 20);
            this.txtTenVT.TabIndex = 6;
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(85, 20);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(150, 20);
            this.txtMaVT.TabIndex = 5;
            // 
            // dgvVatTu
            // 
            this.dgvVatTu.AllowUserToAddRows = false;
            this.dgvVatTu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVatTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVatTu.Location = new System.Drawing.Point(20, 145);
            this.dgvVatTu.Name = "dgvVatTu";
            this.dgvVatTu.ReadOnly = true;
            this.dgvVatTu.Size = new System.Drawing.Size(835, 370);
            this.dgvVatTu.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(440, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Số lượng tồn:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Đơn vị tính:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tên vật tư:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Mã vật tư:";
            // 
            // tpCanhBao
            // 
            this.tpCanhBao.Controls.Add(this.lblTongGiaTriKho);
            this.tpCanhBao.Controls.Add(this.btnTinhTongGiaTri);
            this.tpCanhBao.Controls.Add(this.btnLocCanhBao);
            this.tpCanhBao.Controls.Add(this.nudNguong);
            this.tpCanhBao.Controls.Add(this.label1);
            this.tpCanhBao.Controls.Add(this.dgvCanhBao);
            this.tpCanhBao.Location = new System.Drawing.Point(4, 22);
            this.tpCanhBao.Name = "tpCanhBao";
            this.tpCanhBao.Size = new System.Drawing.Size(876, 535);
            this.tpCanhBao.TabIndex = 2;
            this.tpCanhBao.Text = "Cảnh Báo Tồn Kho & Báo Cáo";
            this.tpCanhBao.UseVisualStyleBackColor = true;
            // 
            // lblTongGiaTriKho
            // 
            this.lblTongGiaTriKho.AutoSize = true;
            this.lblTongGiaTriKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongGiaTriKho.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTongGiaTriKho.Location = new System.Drawing.Point(20, 485);
            this.lblTongGiaTriKho.Name = "lblTongGiaTriKho";
            this.lblTongGiaTriKho.Size = new System.Drawing.Size(262, 18);
            this.lblTongGiaTriKho.TabIndex = 5;
            this.lblTongGiaTriKho.Text = "Tổng giá trị hàng tồn kho: 0 VNĐ";
            // 
            // btnTinhTongGiaTri
            // 
            this.btnTinhTongGiaTri.Location = new System.Drawing.Point(660, 480);
            this.btnTinhTongGiaTri.Name = "btnTinhTongGiaTri";
            this.btnTinhTongGiaTri.Size = new System.Drawing.Size(195, 30);
            this.btnTinhTongGiaTri.TabIndex = 4;
            this.btnTinhTongGiaTri.Text = "Tính Tổng Giá Trị Tồn Kho";
            this.btnTinhTongGiaTri.UseVisualStyleBackColor = true;
            this.btnTinhTongGiaTri.Click += new System.EventHandler(this.btnTinhTongGiaTri_Click);
            // 
            // btnLocCanhBao
            // 
            this.btnLocCanhBao.Location = new System.Drawing.Point(280, 18);
            this.btnLocCanhBao.Name = "btnLocCanhBao";
            this.btnLocCanhBao.Size = new System.Drawing.Size(120, 23);
            this.btnLocCanhBao.TabIndex = 3;
            this.btnLocCanhBao.Text = "Lọc Cảnh Báo";
            this.btnLocCanhBao.UseVisualStyleBackColor = true;
            this.btnLocCanhBao.Click += new System.EventHandler(this.btnLocCanhBao_Click);
            // 
            // nudNguong
            // 
            this.nudNguong.Location = new System.Drawing.Point(140, 20);
            this.nudNguong.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.nudNguong.Name = "nudNguong";
            this.nudNguong.Size = new System.Drawing.Size(120, 20);
            this.nudNguong.TabIndex = 2;
            this.nudNguong.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngưỡng tồn an toàn:";
            // 
            // dgvCanhBao
            // 
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCanhBao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCanhBao.Location = new System.Drawing.Point(20, 60);
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.Size = new System.Drawing.Size(835, 400);
            this.dgvCanhBao.TabIndex = 0;
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tcMain);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Quy Trình Xuất - Nhập Kho Nguyên Vật Liệu";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tcMain.ResumeLayout(false);
            this.tpPhieuKho.ResumeLayout(false);
            this.tpPhieuKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPhieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.tpVatTu.ResumeLayout(false);
            this.tpVatTu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVatTu)).EndInit();
            this.tpCanhBao.ResumeLayout(false);
            this.tpCanhBao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNguong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpPhieuKho;
        private System.Windows.Forms.TabPage tpVatTu;
        private System.Windows.Forms.TabPage tpCanhBao;
        private System.Windows.Forms.DataGridView dgvCanhBao;
        private System.Windows.Forms.Label lblTongGiaTriKho;
        private System.Windows.Forms.Button btnTinhTongGiaTri;
        private System.Windows.Forms.Button btnLocCanhBao;
        private System.Windows.Forms.NumericUpDown nudNguong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDonGia;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.ComboBox cboVatTu;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.ComboBox cboLoaiPhieu;
        private System.Windows.Forms.Button btnLuuPhieu;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.DataGridView dgvChiTietPhieu;
        private System.Windows.Forms.Label lblTongTienPhieu;
        private System.Windows.Forms.Button btnThemVatTu;
        private System.Windows.Forms.TextBox txtTonDau;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtTenVT;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.DataGridView dgvVatTu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchKey;
    }
}