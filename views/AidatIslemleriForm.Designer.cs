namespace SiteYonetimSistemi.views
{
    partial class AidatIslemleriForm
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
            this.grpAidatBilgileri = new System.Windows.Forms.GroupBox();
            this.cmbDurum = new System.Windows.Forms.ComboBox();
            this.dtpAyYil = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpSonOdeme = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTutar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDaireNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAidatEkle = new System.Windows.Forms.Button();
            this.btnOdemeAl = new System.Windows.Forms.Button();
            this.btnAidatGuncelle = new System.Windows.Forms.Button();
            this.btnAidatSil = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.dgvAidatlar = new System.Windows.Forms.DataGridView();
            this.btnMailGonder = new System.Windows.Forms.Button();
            this.grpAidatBilgileri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAidatlar)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAidatBilgileri
            // 
            this.grpAidatBilgileri.Controls.Add(this.cmbDurum);
            this.grpAidatBilgileri.Controls.Add(this.dtpAyYil);
            this.grpAidatBilgileri.Controls.Add(this.label5);
            this.grpAidatBilgileri.Controls.Add(this.dtpSonOdeme);
            this.grpAidatBilgileri.Controls.Add(this.label4);
            this.grpAidatBilgileri.Controls.Add(this.txtTutar);
            this.grpAidatBilgileri.Controls.Add(this.label3);
            this.grpAidatBilgileri.Controls.Add(this.txtAdSoyad);
            this.grpAidatBilgileri.Controls.Add(this.label2);
            this.grpAidatBilgileri.Controls.Add(this.txtDaireNo);
            this.grpAidatBilgileri.Controls.Add(this.label1);
            this.grpAidatBilgileri.Location = new System.Drawing.Point(21, 49);
            this.grpAidatBilgileri.Name = "grpAidatBilgileri";
            this.grpAidatBilgileri.Size = new System.Drawing.Size(350, 250);
            this.grpAidatBilgileri.TabIndex = 0;
            this.grpAidatBilgileri.TabStop = false;
            this.grpAidatBilgileri.Text = "Aidat Bilgileri";
            // 
            // cmbDurum
            // 
            this.cmbDurum.FormattingEnabled = true;
            this.cmbDurum.Items.AddRange(new object[] {
            "Bekliyor",
            "Ödendi",
            "Gecikti"});
            this.cmbDurum.Location = new System.Drawing.Point(147, 216);
            this.cmbDurum.Name = "cmbDurum";
            this.cmbDurum.Size = new System.Drawing.Size(121, 21);
            this.cmbDurum.TabIndex = 10;
            this.cmbDurum.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dtpAyYil
            // 
            this.dtpAyYil.CustomFormat = "MMMM yyyy";
            this.dtpAyYil.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAyYil.Location = new System.Drawing.Point(147, 110);
            this.dtpAyYil.Name = "dtpAyYil";
            this.dtpAyYil.Size = new System.Drawing.Size(100, 20);
            this.dtpAyYil.TabIndex = 4;
            this.dtpAyYil.ValueChanged += new System.EventHandler(this.dtpAyYil_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Durum";
            // 
            // dtpSonOdeme
            // 
            this.dtpSonOdeme.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSonOdeme.Location = new System.Drawing.Point(147, 187);
            this.dtpSonOdeme.Name = "dtpSonOdeme";
            this.dtpSonOdeme.Size = new System.Drawing.Size(100, 20);
            this.dtpSonOdeme.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = " Son Ödeme";
            // 
            // txtTutar
            // 
            this.txtTutar.Location = new System.Drawing.Point(147, 148);
            this.txtTutar.Name = "txtTutar";
            this.txtTutar.Size = new System.Drawing.Size(100, 20);
            this.txtTutar.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tutar";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(147, 67);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(100, 20);
            this.txtAdSoyad.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ad Soyad";
            // 
            // txtDaireNo
            // 
            this.txtDaireNo.Location = new System.Drawing.Point(147, 31);
            this.txtDaireNo.Name = "txtDaireNo";
            this.txtDaireNo.Size = new System.Drawing.Size(100, 20);
            this.txtDaireNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Daire No";
            // 
            // btnAidatEkle
            // 
            this.btnAidatEkle.Location = new System.Drawing.Point(12, 373);
            this.btnAidatEkle.Name = "btnAidatEkle";
            this.btnAidatEkle.Size = new System.Drawing.Size(75, 23);
            this.btnAidatEkle.TabIndex = 1;
            this.btnAidatEkle.Text = "Aidat Ekle";
            this.btnAidatEkle.UseVisualStyleBackColor = true;
            this.btnAidatEkle.Click += new System.EventHandler(this.btnAidatEkle_Click);
            // 
            // btnOdemeAl
            // 
            this.btnOdemeAl.Location = new System.Drawing.Point(131, 373);
            this.btnOdemeAl.Name = "btnOdemeAl";
            this.btnOdemeAl.Size = new System.Drawing.Size(75, 23);
            this.btnOdemeAl.TabIndex = 2;
            this.btnOdemeAl.Text = "Ödeme Al";
            this.btnOdemeAl.UseVisualStyleBackColor = true;
            this.btnOdemeAl.Click += new System.EventHandler(this.btnOdemeAl_Click_1);
            // 
            // btnAidatGuncelle
            // 
            this.btnAidatGuncelle.Location = new System.Drawing.Point(271, 373);
            this.btnAidatGuncelle.Name = "btnAidatGuncelle";
            this.btnAidatGuncelle.Size = new System.Drawing.Size(75, 23);
            this.btnAidatGuncelle.TabIndex = 3;
            this.btnAidatGuncelle.Text = "Güncelle";
            this.btnAidatGuncelle.UseVisualStyleBackColor = true;
            this.btnAidatGuncelle.Click += new System.EventHandler(this.btnAidatGuncelle_Click_1);
            // 
            // btnAidatSil
            // 
            this.btnAidatSil.Location = new System.Drawing.Point(508, 373);
            this.btnAidatSil.Name = "btnAidatSil";
            this.btnAidatSil.Size = new System.Drawing.Size(75, 23);
            this.btnAidatSil.TabIndex = 4;
            this.btnAidatSil.Text = "Sil";
            this.btnAidatSil.UseVisualStyleBackColor = true;
            this.btnAidatSil.Click += new System.EventHandler(this.btnAidatSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(399, 373);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(75, 23);
            this.btnTemizle.TabIndex = 5;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click_1);
            // 
            // dgvAidatlar
            // 
            this.dgvAidatlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAidatlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAidatlar.Location = new System.Drawing.Point(390, 60);
            this.dgvAidatlar.Name = "dgvAidatlar";
            this.dgvAidatlar.ReadOnly = true;
            this.dgvAidatlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAidatlar.Size = new System.Drawing.Size(385, 239);
            this.dgvAidatlar.TabIndex = 6;
            this.dgvAidatlar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAidatlar_CellClick);
            // 
            // btnMailGonder
            // 
            this.btnMailGonder.Location = new System.Drawing.Point(642, 373);
            this.btnMailGonder.Name = "btnMailGonder";
            this.btnMailGonder.Size = new System.Drawing.Size(75, 24);
            this.btnMailGonder.TabIndex = 7;
            this.btnMailGonder.Text = "Mail Gönder";
            this.btnMailGonder.UseVisualStyleBackColor = true;
            this.btnMailGonder.Click += new System.EventHandler(this.btnMailGonder_Click);
            // 
            // AidatIslemleriForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMailGonder);
            this.Controls.Add(this.dgvAidatlar);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnAidatSil);
            this.Controls.Add(this.btnAidatGuncelle);
            this.Controls.Add(this.btnOdemeAl);
            this.Controls.Add(this.btnAidatEkle);
            this.Controls.Add(this.grpAidatBilgileri);
            this.Name = "AidatIslemleriForm";
            this.Text = "AidatIslemleriForm";
            this.Load += new System.EventHandler(this.AidatIslemleriForm_Load);
            this.grpAidatBilgileri.ResumeLayout(false);
            this.grpAidatBilgileri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAidatlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAidatBilgileri;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDaireNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAyYil;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDurum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpSonOdeme;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTutar;
        private System.Windows.Forms.Button btnAidatEkle;
        private System.Windows.Forms.Button btnOdemeAl;
        private System.Windows.Forms.Button btnAidatGuncelle;
        private System.Windows.Forms.Button btnAidatSil;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.DataGridView dgvAidatlar;
        private System.Windows.Forms.Button btnMailGonder;
    }
}