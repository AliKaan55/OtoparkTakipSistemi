using OtoparkTakipSistemi.Business;
using OtoparkTakipSistemi.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoparkTakipSistemi.UI
{
    public partial class FormMain : Form
    {
        private readonly ParkingManager _parkingManager;
        public FormMain()
        {
            InitializeComponent();
            _parkingManager = new ParkingManager();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadVehicleTypes();
            RefreshFormComponents();
        }
        private void LoadVehicleTypes()
        {
            cmbVehicleType.DataSource = Enum.GetValues(typeof(VehicleType));
        }
        private void LoadEmptySlots()
        {
            cmbSlots.DataSource = _parkingManager.GetEmptySlots();
            cmbSlots.DisplayMember = "DisplayText"; 
            cmbSlots.ValueMember = "Id";
        }
        private void LoadSlotStatus()
        {
            dgvSlotStatus.DataSource = null;
            dgvSlotStatus.DataSource = _parkingManager.GetAllSlots();

            if (dgvSlotStatus.Columns["Id"] != null)
                dgvSlotStatus.Columns["Id"].Visible = false;
            if (dgvSlotStatus.Columns["DisplayText"] != null)
                dgvSlotStatus.Columns["DisplayText"].Visible = false;
            if (dgvSlotStatus.Columns["IsFull"] != null)
                dgvSlotStatus.Columns["IsFull"].Visible = false;

            if (dgvSlotStatus.Columns["SlotNumber"] != null)
                dgvSlotStatus.Columns["SlotNumber"].HeaderText = "Park Yeri";
            if (dgvSlotStatus.Columns["Floor"] != null)
                dgvSlotStatus.Columns["Floor"].HeaderText = "Kat";
            if (dgvSlotStatus.Columns["Capacity"] != null)
                dgvSlotStatus.Columns["Capacity"].HeaderText = "Kapasite";
            if (dgvSlotStatus.Columns["OccupiedCount"] != null)
                dgvSlotStatus.Columns["OccupiedCount"].HeaderText = "Dolu";
            if (dgvSlotStatus.Columns["AvailableCount"] != null)
                dgvSlotStatus.Columns["AvailableCount"].HeaderText = "Boş";
        }
        private void LoadActiveRecords()
        {
            dgvActiveRecords.DataSource = null;
            dgvActiveRecords.DataSource = _parkingManager.GetActiveRecords();

            if (dgvActiveRecords.Columns["ParkingSlot"] != null)
                dgvActiveRecords.Columns["ParkingSlot"].Visible = false;
            if (dgvActiveRecords.Columns["ParkingSlotId"] != null)
                dgvActiveRecords.Columns["ParkingSlotId"].Visible = false;
            if (dgvActiveRecords.Columns["Id"] != null)
                dgvActiveRecords.Columns["Id"].Visible = false;

            if (dgvActiveRecords.Columns["LicensePlate"] != null)
                dgvActiveRecords.Columns["LicensePlate"].HeaderText = "Plaka";
            if (dgvActiveRecords.Columns["VehicleType"] != null)
                dgvActiveRecords.Columns["VehicleType"].HeaderText = "Araç Tipi";
            if (dgvActiveRecords.Columns["CheckInTime"] != null)
                dgvActiveRecords.Columns["CheckInTime"].HeaderText = "Giriş Zamanı";
            if (dgvActiveRecords.Columns["CheckOutTime"] != null)
                dgvActiveRecords.Columns["CheckOutTime"].HeaderText = "Çıkış Zamanı";
            if (dgvActiveRecords.Columns["TotalPrice"] != null)
                dgvActiveRecords.Columns["TotalPrice"].HeaderText = "Toplam Ücret";
            if (dgvActiveRecords.Columns["IsActive"] != null)
                dgvActiveRecords.Columns["IsActive"].HeaderText = "Aktif";
        }
        private void RefreshFormComponents()
        {
            LoadEmptySlots();
            LoadActiveRecords();
            LoadSlotStatus();
            UpdateSlotCountLabel();
            txtPlate.Text = string.Empty;
        }

        private void UpdateSlotCountLabel()
        {
            int totalSlots = _parkingManager.GetTotalSlotCount();
            int emptySlots = _parkingManager.GetEmptySlotCount();

            lblSlotCount.Text = $"Toplam Boş Yer: {emptySlots} / {totalSlots}";

            lblSlotCount.ForeColor = emptySlots <= 0 ? Color.Red : Color.DarkGreen;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlate.Text))
            {
                MessageBox.Show("Lütfen geçerli bir plaka giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbSlots.SelectedValue == null)
            {
                MessageBox.Show("Lütfen boş bir park yeri seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string plate = txtPlate.Text;
            VehicleType selectedType = (VehicleType)cmbVehicleType.SelectedItem;
            int selectedSlotId = (int)cmbSlots.SelectedValue;

            string result = _parkingManager.CheckIn(plate, selectedType, selectedSlotId);
            MessageBox.Show(result, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshFormComponents();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (dgvActiveRecords.CurrentRow == null)
            {
                MessageBox.Show("Lütfen çıkış yapacak aracı listeden seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int recordId = Convert.ToInt32(dgvActiveRecords.CurrentRow.Cells["Id"].Value);
            string result = _parkingManager.CheckOut(recordId);

            MessageBox.Show(result, "Ödeme Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            RefreshFormComponents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFormComponents();
        }
    }
}
