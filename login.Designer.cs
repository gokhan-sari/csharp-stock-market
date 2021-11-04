
namespace borsa_projesi
{
    partial class login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.kayit_ol = new System.Windows.Forms.Button();
            this.pw = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.adres = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.telno = new System.Windows.Forms.TextBox();
            this.tcno = new System.Windows.Forms.TextBox();
            this.soyad = new System.Windows.Forms.TextBox();
            this.ad = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.giris_butonu = new System.Windows.Forms.Button();
            this.sifre = new System.Windows.Forms.TextBox();
            this.kullanici_adi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kayit_ol
            // 
            this.kayit_ol.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kayit_ol.Location = new System.Drawing.Point(1025, 625);
            this.kayit_ol.Name = "kayit_ol";
            this.kayit_ol.Size = new System.Drawing.Size(250, 50);
            this.kayit_ol.TabIndex = 58;
            this.kayit_ol.Text = "Kayıt Ol";
            this.kayit_ol.UseVisualStyleBackColor = true;
            this.kayit_ol.Click += new System.EventHandler(this.kayit_ol_Click);
            // 
            // pw
            // 
            this.pw.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.pw.Location = new System.Drawing.Point(1050, 555);
            this.pw.Name = "pw";
            this.pw.Size = new System.Drawing.Size(200, 40);
            this.pw.TabIndex = 57;
            // 
            // id
            // 
            this.id.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.id.Location = new System.Drawing.Point(1050, 485);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(200, 40);
            this.id.TabIndex = 56;
            // 
            // adres
            // 
            this.adres.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.adres.Location = new System.Drawing.Point(1050, 415);
            this.adres.Name = "adres";
            this.adres.Size = new System.Drawing.Size(200, 40);
            this.adres.TabIndex = 55;
            // 
            // email
            // 
            this.email.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.email.Location = new System.Drawing.Point(1050, 345);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(200, 40);
            this.email.TabIndex = 54;
            // 
            // telno
            // 
            this.telno.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.telno.Location = new System.Drawing.Point(1050, 275);
            this.telno.Name = "telno";
            this.telno.Size = new System.Drawing.Size(200, 40);
            this.telno.TabIndex = 53;
            // 
            // tcno
            // 
            this.tcno.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tcno.Location = new System.Drawing.Point(1050, 205);
            this.tcno.Name = "tcno";
            this.tcno.Size = new System.Drawing.Size(200, 40);
            this.tcno.TabIndex = 52;
            // 
            // soyad
            // 
            this.soyad.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.soyad.Location = new System.Drawing.Point(1050, 135);
            this.soyad.Name = "soyad";
            this.soyad.Size = new System.Drawing.Size(200, 40);
            this.soyad.TabIndex = 51;
            // 
            // ad
            // 
            this.ad.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ad.Location = new System.Drawing.Point(1050, 65);
            this.ad.Name = "ad";
            this.ad.Size = new System.Drawing.Size(200, 40);
            this.ad.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(921, 562);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 29);
            this.label8.TabIndex = 49;
            this.label8.Text = "Parola";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(962, 492);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 29);
            this.label7.TabIndex = 48;
            this.label7.Text = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(927, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 29);
            this.label6.TabIndex = 47;
            this.label6.Text = "Adres";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(922, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 29);
            this.label5.TabIndex = 46;
            this.label5.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(918, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 29);
            this.label4.TabIndex = 45;
            this.label4.Text = "Tel No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(925, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 44;
            this.label3.Text = "Tc No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(960, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 29);
            this.label1.TabIndex = 43;
            this.label1.Text = "Ad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(923, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 29);
            this.label2.TabIndex = 42;
            this.label2.Text = "Soyad";
            // 
            // giris_butonu
            // 
            this.giris_butonu.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.giris_butonu.Location = new System.Drawing.Point(395, 388);
            this.giris_butonu.Name = "giris_butonu";
            this.giris_butonu.Size = new System.Drawing.Size(250, 50);
            this.giris_butonu.TabIndex = 49;
            this.giris_butonu.Text = "Giriş";
            this.giris_butonu.UseVisualStyleBackColor = true;
            this.giris_butonu.Click += new System.EventHandler(this.giris_butonu_Click);
            // 
            // sifre
            // 
            this.sifre.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre.Location = new System.Drawing.Point(395, 294);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(250, 40);
            this.sifre.TabIndex = 48;
            this.sifre.UseSystemPasswordChar = true;
            // 
            // kullanici_adi
            // 
            this.kullanici_adi.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullanici_adi.Location = new System.Drawing.Point(395, 200);
            this.kullanici_adi.Name = "kullanici_adi";
            this.kullanici_adi.Size = new System.Drawing.Size(250, 40);
            this.kullanici_adi.TabIndex = 47;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(265, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 34);
            this.label9.TabIndex = 60;
            this.label9.Text = "Şifre";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(180, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 34);
            this.label10.TabIndex = 59;
            this.label10.Text = "Kulanıcı Adı";
            // 
            // login
            // 
            this.AcceptButton = this.giris_butonu;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.giris_butonu);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullanici_adi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.kayit_ol);
            this.Controls.Add(this.pw);
            this.Controls.Add(this.id);
            this.Controls.Add(this.adres);
            this.Controls.Add(this.email);
            this.Controls.Add(this.telno);
            this.Controls.Add(this.tcno);
            this.Controls.Add(this.soyad);
            this.Controls.Add(this.ad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button kayit_ol;
        public System.Windows.Forms.TextBox pw;
        public System.Windows.Forms.TextBox id;
        public System.Windows.Forms.TextBox adres;
        public System.Windows.Forms.TextBox email;
        public System.Windows.Forms.TextBox telno;
        public System.Windows.Forms.TextBox tcno;
        public System.Windows.Forms.TextBox soyad;
        public System.Windows.Forms.TextBox ad;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button giris_butonu;
        public System.Windows.Forms.TextBox sifre;
        public System.Windows.Forms.TextBox kullanici_adi;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label10;
    }
}

