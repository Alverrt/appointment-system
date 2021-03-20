namespace UniVeritabaniProjesi
{
    partial class loginForm
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
            this.loginLabel = new System.Windows.Forms.Label();
            this.loginLabelSmall = new System.Windows.Forms.Label();
            this.girisKullaniciAdi = new System.Windows.Forms.TextBox();
            this.girisSifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.girisYap = new System.Windows.Forms.Button();
            this.kayitOlFormunaGit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginLabel
            // 
            this.loginLabel.BackColor = System.Drawing.Color.CadetBlue;
            this.loginLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.loginLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.loginLabel.Location = new System.Drawing.Point(12, 29);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(448, 161);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "İŞ YERİ YÖNETİM SİSTEMİ";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginLabelSmall
            // 
            this.loginLabelSmall.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.loginLabelSmall.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.loginLabelSmall.Location = new System.Drawing.Point(66, 234);
            this.loginLabelSmall.Name = "loginLabelSmall";
            this.loginLabelSmall.Size = new System.Drawing.Size(329, 65);
            this.loginLabelSmall.TabIndex = 1;
            this.loginLabelSmall.Text = "Lütfen sisteme giriş yapın. Kaydınız yoksa kayıt ol butonuna basın.";
            this.loginLabelSmall.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // girisKullaniciAdi
            // 
            this.girisKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.girisKullaniciAdi.Location = new System.Drawing.Point(197, 354);
            this.girisKullaniciAdi.Name = "girisKullaniciAdi";
            this.girisKullaniciAdi.Size = new System.Drawing.Size(180, 30);
            this.girisKullaniciAdi.TabIndex = 2;
            // 
            // girisSifre
            // 
            this.girisSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.girisSifre.Location = new System.Drawing.Point(197, 402);
            this.girisSifre.Name = "girisSifre";
            this.girisSifre.Size = new System.Drawing.Size(180, 30);
            this.girisSifre.TabIndex = 3;
            this.girisSifre.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(77, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanıcı Adı:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(91, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // girisYap
            // 
            this.girisYap.Location = new System.Drawing.Point(246, 453);
            this.girisYap.Name = "girisYap";
            this.girisYap.Size = new System.Drawing.Size(89, 32);
            this.girisYap.TabIndex = 6;
            this.girisYap.Text = "Giriş Yap";
            this.girisYap.UseVisualStyleBackColor = true;
            this.girisYap.Click += new System.EventHandler(this.girisYap_Click);
            // 
            // kayitOlFormunaGit
            // 
            this.kayitOlFormunaGit.Location = new System.Drawing.Point(371, 503);
            this.kayitOlFormunaGit.Name = "kayitOlFormunaGit";
            this.kayitOlFormunaGit.Size = new System.Drawing.Size(89, 32);
            this.kayitOlFormunaGit.TabIndex = 7;
            this.kayitOlFormunaGit.Text = "Kayıt Ol";
            this.kayitOlFormunaGit.UseVisualStyleBackColor = true;
            this.kayitOlFormunaGit.Click += new System.EventHandler(this.kayitOlFormunaGit_Click);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(472, 547);
            this.Controls.Add(this.kayitOlFormunaGit);
            this.Controls.Add(this.girisYap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.girisSifre);
            this.Controls.Add(this.girisKullaniciAdi);
            this.Controls.Add(this.loginLabelSmall);
            this.Controls.Add(this.loginLabel);
            this.Name = "loginForm";
            this.Text = "Giriş Yap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label loginLabelSmall;
        private System.Windows.Forms.TextBox girisKullaniciAdi;
        private System.Windows.Forms.TextBox girisSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button girisYap;
        private System.Windows.Forms.Button kayitOlFormunaGit;
    }
}

