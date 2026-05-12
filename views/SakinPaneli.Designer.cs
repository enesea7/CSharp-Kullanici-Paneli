namespace SiteYonetimSistemi.views
{
    partial class SakinPaneli
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
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.lblDaireNo = new System.Windows.Forms.Label();
            this.dgvSakinAidatlar = new System.Windows.Forms.DataGridView();
            this.btnOdemeYap = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSakinAidatlar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Location = new System.Drawing.Point(101, 39);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(66, 13);
            this.lblAdSoyad.TabIndex = 0;
            this.lblAdSoyad.Text = "Hoş Geldiniz";
            // 
            // lblDaireNo
            // 
            this.lblDaireNo.AutoSize = true;
            this.lblDaireNo.Location = new System.Drawing.Point(101, 100);
            this.lblDaireNo.Name = "lblDaireNo";
            this.lblDaireNo.Size = new System.Drawing.Size(49, 13);
            this.lblDaireNo.TabIndex = 1;
            this.lblDaireNo.Text = "Daire No";
            // 
            // dgvSakinAidatlar
            // 
            this.dgvSakinAidatlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSakinAidatlar.Location = new System.Drawing.Point(326, 56);
            this.dgvSakinAidatlar.Name = "dgvSakinAidatlar";
            this.dgvSakinAidatlar.Size = new System.Drawing.Size(462, 198);
            this.dgvSakinAidatlar.TabIndex = 2;
            // 
            // btnOdemeYap
            // 
            this.btnOdemeYap.Location = new System.Drawing.Point(12, 231);
            this.btnOdemeYap.Name = "btnOdemeYap";
            this.btnOdemeYap.Size = new System.Drawing.Size(75, 23);
            this.btnOdemeYap.TabIndex = 3;
            this.btnOdemeYap.Text = "Ödeme Yap";
            this.btnOdemeYap.UseVisualStyleBackColor = true;
            this.btnOdemeYap.Click += new System.EventHandler(this.btnOdemeYap_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(199, 231);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(75, 23);
            this.btnCikis.TabIndex = 4;
            this.btnCikis.Text = "Çıkış Yap";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // SakinPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnOdemeYap);
            this.Controls.Add(this.dgvSakinAidatlar);
            this.Controls.Add(this.lblDaireNo);
            this.Controls.Add(this.lblAdSoyad);
            this.Name = "SakinPaneli";
            this.Text = "SakinPaneli";
            this.Load += new System.EventHandler(this.SakinPaneli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSakinAidatlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdSoyad;
        private System.Windows.Forms.Label lblDaireNo;
        private System.Windows.Forms.DataGridView dgvSakinAidatlar;
        private System.Windows.Forms.Button btnOdemeYap;
        private System.Windows.Forms.Button btnCikis;
    }
}