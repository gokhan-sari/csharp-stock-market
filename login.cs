using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace borsa_projesi
{
    public partial class login : Form
    {
        private const string ConnectionString = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;";
        private static OleDbConnection baglanti;
        private static OleDbCommand komut;
        private static OleDbDataReader sorgu;

        public static string kullanici;

        public login()
        {
            InitializeComponent();
            baglanti = new OleDbConnection(ConnectionString);
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void girisYap(string kuladi, string sifre)
        {
            baglanti.Open();

            komut = new OleDbCommand("select * from kullanicilar where kuladi='" + kuladi + "' and sifre='" + sifre + "'", baglanti);
            sorgu = komut.ExecuteReader();

            if(sorgu.Read())
            {
                kullanici = kullanici_adi.Text;

                if (kullanici_adi.Text == "admin")
                {
                    this.Hide();
                    admin admin = new admin();
                    admin.Show();
                }
                else
                {
                    this.Hide();
                    user user = new user();
                    user.Show();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }

        private void kayitOl()
        {
            if ((ad.Text == "") || (soyad.Text == "") || (tcno.Text == "") || (telno.Text == "") ||
                (email.Text == "") || (adres.Text == "") || (id.Text == "") || (pw.Text == ""))
            {
                MessageBox.Show("Tüm Bilgileri Giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {                
                baglanti.Open();

                komut = new OleDbCommand("insert into kullanicilar (adi,soyadi,tcno,telno,email,adres,kuladi,sifre) values ('" + ad.Text + "','" + soyad.Text + "','" + tcno.Text + "','" + telno.Text + "','" + email.Text + "','" + adres.Text + "','" + id.Text + "','" + pw.Text + "')", baglanti);
                komut.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Kayıt Tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ad.Text = "";
                soyad.Text = "";
                tcno.Text = "";
                telno.Text = "";
                email.Text = "";
                adres.Text = "";
                id.Text = "";
                pw.Text = "";
            }
        }

        private void giris_butonu_Click(object sender, EventArgs e)
        {
            girisYap(kullanici_adi.Text, sifre.Text);
        }

        private void kayit_ol_Click(object sender, EventArgs e)
        {
            kayitOl();
        }
        
    }
}
