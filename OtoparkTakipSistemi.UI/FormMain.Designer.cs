namespace OtoparkTakipSistemi.UI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnCheckIn = new Button();
            cmbSlots = new ComboBox();
            cmbVehicleType = new ComboBox();
            txtPlate = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label = new Label();
            groupBox2 = new GroupBox();
            btnCheckOut = new Button();
            label1 = new Label();
            dgvActiveRecords = new DataGridView();
            btnRefresh = new Button();
            lblSlotCount = new Label();
            groupBox3 = new GroupBox();
            dgvSlotStatus = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActiveRecords).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSlotStatus).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCheckIn);
            groupBox1.Controls.Add(cmbSlots);
            groupBox1.Controls.Add(cmbVehicleType);
            groupBox1.Controls.Add(txtPlate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label);
            groupBox1.Location = new Point(5, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(260, 230);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Araç Giriş İşlemi";
            // 
            // btnCheckIn
            // 
            btnCheckIn.Location = new Point(67, 167);
            btnCheckIn.Name = "btnCheckIn";
            btnCheckIn.Size = new Size(161, 57);
            btnCheckIn.TabIndex = 7;
            btnCheckIn.Text = "Giriş Yap";
            btnCheckIn.UseVisualStyleBackColor = true;
            btnCheckIn.Click += btnCheckIn_Click;
            // 
            // cmbSlots
            // 
            cmbSlots.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSlots.FormattingEnabled = true;
            cmbSlots.Location = new Point(67, 121);
            cmbSlots.Name = "cmbSlots";
            cmbSlots.Size = new Size(161, 23);
            cmbSlots.TabIndex = 6;
            // 
            // cmbVehicleType
            // 
            cmbVehicleType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVehicleType.FormattingEnabled = true;
            cmbVehicleType.Location = new Point(67, 86);
            cmbVehicleType.Name = "cmbVehicleType";
            cmbVehicleType.Size = new Size(161, 23);
            cmbVehicleType.TabIndex = 5;
            // 
            // txtPlate
            // 
            txtPlate.Location = new Point(67, 45);
            txtPlate.Name = "txtPlate";
            txtPlate.Size = new Size(161, 23);
            txtPlate.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 124);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 2;
            label3.Text = "Park Yeri:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 89);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "Araç Tipi:";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(7, 48);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 0;
            label.Text = "Plaka:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnCheckOut);
            groupBox2.Location = new Point(12, 258);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(260, 85);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Araç Çıkış İşlemi";
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(0, 22);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(253, 57);
            btnCheckOut.TabIndex = 0;
            btnCheckOut.Text = "Seçili Aracı Çıkar ve Ücret Al";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(307, 19);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 2;
            label1.Text = "Otoparktaki Aktif Araçlar";
            // 
            // dgvActiveRecords
            // 
            dgvActiveRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActiveRecords.Location = new Point(307, 45);
            dgvActiveRecords.Name = "dgvActiveRecords";
            dgvActiveRecords.ReadOnly = true;
            dgvActiveRecords.Size = new Size(450, 298);
            dgvActiveRecords.TabIndex = 3;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1010, 11);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(124, 28);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Yenile";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblSlotCount
            // 
            lblSlotCount.AutoSize = true;
            lblSlotCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblSlotCount.ForeColor = Color.DarkGreen;
            lblSlotCount.Location = new Point(470, 15);
            lblSlotCount.Name = "lblSlotCount";
            lblSlotCount.Size = new Size(260, 25);
            lblSlotCount.TabIndex = 5;
            lblSlotCount.Text = "Toplam Boş Yer: - / -";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dgvSlotStatus);
            groupBox3.Location = new Point(770, 11);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(220, 332);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Park Yerleri Durumu";
            // 
            // dgvSlotStatus
            // 
            dgvSlotStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSlotStatus.Location = new Point(6, 22);
            dgvSlotStatus.Name = "dgvSlotStatus";
            dgvSlotStatus.ReadOnly = true;
            dgvSlotStatus.Size = new Size(208, 300);
            dgvSlotStatus.TabIndex = 0;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 360);
            Controls.Add(groupBox3);
            Controls.Add(lblSlotCount);
            Controls.Add(btnRefresh);
            Controls.Add(dgvActiveRecords);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Otopark Takip Otomasyonu";
            Load += FormMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActiveRecords).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSlotStatus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbSlots;
        private ComboBox cmbVehicleType;
        private TextBox txtPlate;
        private Label label3;
        private Label label2;
        private Label label;
        private Button btnCheckIn;
        private GroupBox groupBox2;
        private Button btnCheckOut;
        private Label label1;
        private DataGridView dgvActiveRecords;
        private Button btnRefresh;
        private Label lblSlotCount;
        private GroupBox groupBox3;
        private DataGridView dgvSlotStatus;
    }
}