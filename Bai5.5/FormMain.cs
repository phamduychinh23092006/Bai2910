using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using InventoryManagement.BUS;
using InventoryManagement.DTO;

namespace InventoryManagement
{
    public partial class formMain : Form
    {
        private VatTuBUS vatTuBUS = new VatTuBUS();
        private NhaCungCapBUS nccBUS = new NhaCungCapBUS();
        private PhieuKhoBUS phieuBUS = new PhieuKhoBUS();

        private BindingList<ChiTietPhieuKhoDTO> currentChiTietList = new BindingList<ChiTietPhieuKhoDTO>();

        public formMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboLoaiPhieu.SelectedIndex = 0;
            LoadNhaCungCapCombo();
            LoadVatTuCombo();
            LoadVatTuGrid();

            dgvChiTietPhieu.DataSource = currentChiTietList;
        }

        private void LoadNhaCungCapCombo()
        {
            cboNCC.DataSource = nccBUS.GetAll();
            cboNCC.DisplayMember = "TenNCC";
            cboNCC.ValueMember = "MaNCC";
        }

        private void LoadVatTuCombo()
        {
            cboVatTu.DataSource = vatTuBUS.GetAll();
            cboVatTu.DisplayMember = "TenVatTu";
            cboVatTu.ValueMember = "MaVatTu";
        }

        private void LoadVatTuGrid()
        {
            dgvVatTu.DataSource = vatTuBUS.GetAll();
        }

        private void cboLoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loai = cboLoaiPhieu.SelectedItem.ToString();
            cboNCC.Enabled = (loai == "NHAP");
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            if (cboVatTu.SelectedValue == null) return;

            string maVT = cboVatTu.SelectedValue.ToString();
            string tenVT = cboVatTu.Text;
            decimal soLuong = nudSoLuong.Value;
            decimal donGia = nudDonGia.Value;

            foreach (var item in currentChiTietList)
            {
                if (item.MaVatTu == maVT)
                {
                    item.SoLuong += soLuong;
                    item.DonGia = donGia;
                    dgvChiTietPhieu.Refresh();
                    UpdateTongTienPhieu();
                    return;
                }
            }

            currentChiTietList.Add(new ChiTietPhieuKhoDTO
            {
                MaVatTu = maVT,
                TenVatTu = tenVT,
                SoLuong = soLuong,
                DonGia = donGia
            });

            UpdateTongTienPhieu();
        }

        private void UpdateTongTienPhieu()
        {
            decimal total = 0;
            foreach (var item in currentChiTietList)
            {
                total += item.ThanhTien;
            }
            lblTongTienPhieu.Text = $"Tổng tiền phiếu: {total:N0} VNĐ";
        }

        private void btnLuuPhieu_Click(object sender, EventArgs e)
        {
            string loaiPhieu = cboLoaiPhieu.SelectedItem.ToString();
            int? maNCC = loaiPhieu == "NHAP" ? (int?)Convert.ToInt32(cboNCC.SelectedValue) : null;

            decimal total = 0;
            List<ChiTietPhieuKhoDTO> details = new List<ChiTietPhieuKhoDTO>();
            foreach (var item in currentChiTietList)
            {
                total += item.ThanhTien;
                details.Add(item);
            }

            PhieuKhoDTO phieu = new PhieuKhoDTO
            {
                LoaiPhieu = loaiPhieu,
                MaNCC = maNCC,
                TongTien = total,
                ChiTiet = details
            };

            if (phieuBUS.SavePhieuKho(phieu, out string error))
            {
                MessageBox.Show($"Lưu phiếu {loaiPhieu} kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                currentChiTietList.Clear();
                UpdateTongTienPhieu();
                LoadVatTuGrid();
                LoadVatTuCombo();
            }
            else
            {
                MessageBox.Show("Lỗi lập phiếu: " + error, "Lỗi Transaction / Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemVatTu_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtTonDau.Text, out decimal tonDau))
            {
                MessageBox.Show("Số lượng tồn phải là số hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            VatTuDTO vt = new VatTuDTO
            {
                MaVatTu = txtMaVT.Text.Trim(),
                TenVatTu = txtTenVT.Text.Trim(),
                DVT = txtDVT.Text.Trim(),
                SoLuongTon = tonDau
            };

            if (vatTuBUS.Add(vt, out string err))
            {
                MessageBox.Show("Thêm vật tư mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadVatTuGrid();
                LoadVatTuCombo();
                txtMaVT.Clear();
                txtTenVT.Clear();
                txtDVT.Clear();
                txtTonDau.Text = "0";
            }
            else
            {
                MessageBox.Show(err, "Lỗi Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string key = txtSearchKey.Text.Trim();
            dgvVatTu.DataSource = vatTuBUS.Search(key);
        }

        private void btnLocCanhBao_Click(object sender, EventArgs e)
        {
            decimal nguong = nudNguong.Value;
            dgvCanhBao.DataSource = vatTuBUS.GetLowStock(nguong);
        }

        private void btnTinhTongGiaTri_Click(object sender, EventArgs e)
        {
            decimal totalVal = vatTuBUS.GetTotalInventoryValue();
            lblTongGiaTriKho.Text = $"Tổng giá trị hàng tồn kho: {totalVal:N0} VNĐ";
        }
    }
}