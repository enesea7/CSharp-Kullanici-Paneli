namespace SiteYonetimSistemi
{
    partial class SifremiUnuttumForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSifreDegistir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYeniSifre = new System.Windows.Forms.TextBox();
            this.txtYeniSifreTekrar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtKod = new System.Windows.Forms.TextBox();
            this.btnKodGonder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-posta Adresi:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(412, 155);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // btnSifreDegistir
            // 
            this.btnSifreDegistir.Location = new System.Drawing.Point(346, 376);
            this.btnSifreDegistir.Name = "btnSifreDegistir";
            this.btnSifreDegistir.Size = new System.Drawing.Size(122, 23);
            this.btnSifreDegistir.TabIndex = 2;
            this.btnSifreDegistir.Text = "Şifreyi Değiştir";
            this.btnSifreDegistir.UseVisualStyleBackColor = true;
            this.btnSifreDegistir.Click += new System.EventHandler(this.btnSifreDegistir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Yeni Şifre:";
            // 
            // txtYeniSifre
            // 
            this.txtYeniSifre.Location = new System.Drawing.Point(412, 232);
            this.txtYeniSifre.Name = "txtYeniSifre";
            this.txtYeniSifre.Size = new System.Drawing.Size(100, 20);
            this.txtYeniSifre.TabIndex = 4;
            this.txtYeniSifre.UseSystemPasswordChar = true;
            // 
            // txtYeniSifreTekrar
            // 
            this.txtYeniSifreTekrar.Location = new System.Drawing.Point(412, 274);
            this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
            this.txtYeniSifreTekrar.Size = new System.Drawing.Size(100, 20);
            this.txtYeniSifreTekrar.TabIndex = 5;
            this.txtYeniSifreTekrar.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Yeni Şifre Tekrar:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Doğrulama Kodu:";
            // 
            // txtKod
            // 
            this.txtKod.Location = new System.Drawing.Point(412, 193);
            this.txtKod.Name = "txtKod";
            this.txtKod.Size = new System.Drawing.Size(100, 20);
            this.txtKod.TabIndex = 8;
            this.txtKod.UseSystemPasswordChar = true;
            // 
            // btnKodGonder
            // 
            this.btnKodGonder.Location = new System.Drawing.Point(571, 155);
            this.btnKodGonder.Name = "btnKodGonder";
            this.btnKodGonder.Size = new System.Drawing.Size(75, 23);
            this.btnKodGonder.TabIndex = 9;
            this.btnKodGonder.Text = "Kod Gönder";
            this.btnKodGonder.UseVisualStyleBackColor = true;
            this.btnKodGonder.Click += new System.EventHandler(this.btnKodGonder_Click);
            // 
            // SifremiUnuttumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKodGonder);
            this.Controls.Add(this.txtKod);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtYeniSifreTekrar);
            this.Controls.Add(this.txtYeniSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSifreDegistir);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Name = "SifremiUnuttumForm";
            this.Text = "SifremiUnuttumForm";
            this.Load += new System.EventHandler(this.SifremiUnuttumForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSifreDegistir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtYeniSifre;
        private System.Windows.Forms.TextBox txtYeniSifreTekrar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.Button btnKodGonder;
    }
}