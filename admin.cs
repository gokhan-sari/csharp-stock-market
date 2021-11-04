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
using System.Xml;

namespace borsa_projesi
{
    public partial class admin : Form
    {
        private const string ConnectionString = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;";
        private static OleDbConnection baglanti;
        private static OleDbCommand komut;
        private static OleDbDataReader sorgu;
        private static OleDbDataAdapter adaptor;

        public admin()
        {
            InitializeComponent();
            baglanti = new OleDbConnection(ConnectionString);
        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            kur_bilgisi_getir();
            tablo_doldur();
        }

        private void kur_bilgisi_getir()
        {
            XmlTextReader rdr = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            XmlDocument myxml = new XmlDocument();
            myxml.Load(rdr);

            XmlNodeList kod = myxml.SelectNodes("/Tarih_Date/Currency/@Kod");
            XmlNodeList doviz_kuru = myxml.SelectNodes("/Tarih_Date/Currency/ForexSelling");

            for (int i = 0; i < 15; i++)
            {
                string birim = kod.Item(i).InnerText.ToString();

                if (birim == "USD")
                {
                    usd_kuru.Text = doviz_kuru.Item(i).InnerText.ToString();
                }
                if (birim == "EUR")
                {
                    eur_kuru.Text = doviz_kuru.Item(i).InnerText.ToString();
                }
                if (birim == "GBP")
                {
                    gbp_kuru.Text = doviz_kuru.Item(i).InnerText.ToString();
                }
                if (usd_kuru.Text != "x" && eur_kuru.Text != "x" && gbp_kuru.Text != "x")
                    break;
            }
        }

        private void tablo_doldur()
        {
            baglanti.Open();

            onay_listesi.Items.Clear();

            adaptor = new OleDbDataAdapter("select kuladi,urun,miktar from onaytablosu where durum='Beklemede'", baglanti);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);

            for (int i = 0; i < tablo.Rows.Count; i++)
            {
                onay_listesi.Items.Add(tablo.Rows[i][0] + "\t\t" + tablo.Rows[i][1] + "\t\t" + tablo.Rows[i][2]);
            }

            komut = new OleDbCommand("select para from kullanicilar where kuladi='admin'", baglanti);
            sorgu = komut.ExecuteReader();

            while (sorgu.Read())
            {
                admin_para.Text = sorgu["para"].ToString();
            }

            baglanti.Close();
        }

        private void onayla(int secim)
        {
            baglanti.Open();

            adaptor = new OleDbDataAdapter("select kimlik,kuladi,urun,miktar from onaytablosu where durum='Beklemede'", baglanti);
            DataTable tablo = new DataTable();
            adaptor.Fill(tablo);

            for (int i = 0; i <= secim; i++)
            {
                if (i == secim)
                {
                    string id = Convert.ToString(tablo.Rows[i][1]);
                    string urun = Convert.ToString(tablo.Rows[i][2]);
                    int miktar = Convert.ToInt32(tablo.Rows[i][3]);

                    urunekle(id, urun, miktar);

                    komut = new OleDbCommand("update onaytablosu set durum='Onaylandı' where kimlik=" + tablo.Rows[i][0] + "", baglanti);
                    komut.ExecuteNonQuery();
                }
            }

            baglanti.Close();
        }

        private void urunekle(string id, string urun, int miktar)
        {
            switch (urun)
            {
                case "Buğday":
                    OleDbCommand bugdayekle = new OleDbCommand("update kullanicilar set bugday=bugday+'" + miktar + "' where kuladi='" + id + "'", baglanti);
                    bugdayekle.ExecuteNonQuery();
                    break;
                case "Arpa":
                    OleDbCommand arpaekle = new OleDbCommand("update kullanicilar set arpa=arpa+'" + miktar + "' where kuladi='" + id + "'", baglanti);
                    arpaekle.ExecuteNonQuery();
                    break;
                case "Yulaf":
                    OleDbCommand yulafekle = new OleDbCommand("update kullanicilar set yulaf=yulaf+'" + miktar + "' where kuladi='" + id + "'", baglanti);
                    yulafekle.ExecuteNonQuery();
                    break;
                case "Petrol":
                    OleDbCommand petrolekle = new OleDbCommand("update kullanicilar set petrol=petrol+'" + miktar + "' where kuladi='" + id + "'", baglanti);
                    petrolekle.ExecuteNonQuery();
                    break;
                case "Pamuk":
                    OleDbCommand pamukekle = new OleDbCommand("update kullanicilar set pamuk=pamuk+'" + miktar + "' where kuladi='" + id + "'", baglanti);
                    pamukekle.ExecuteNonQuery();
                    break;
                default:
                    paraekle(id, urun, miktar);
                    break;
            }
        }

        private void paraekle(string id, string birim, int miktar)
        {
            int guncel_tutar;

            switch (birim)
            {
                case "Türk Lirası (TL)":
                    OleDbCommand tlekle = new OleDbCommand("update kullanicilar set para=para+'" + miktar + "' where kuladi='" + id + "'", baglanti);
                    tlekle.ExecuteNonQuery();
                    break;
                case "Dolar (USD)":
                    guncel_tutar = kur_cevir(usd_kuru.Text, miktar);
                    OleDbCommand usdekle = new OleDbCommand("update kullanicilar set para=para+'" + guncel_tutar + "' where kuladi='" + id + "'", baglanti);
                    usdekle.ExecuteNonQuery();
                    break;
                case "Euro (EUR)":
                    guncel_tutar = kur_cevir(eur_kuru.Text, miktar);
                    OleDbCommand eurekle = new OleDbCommand("update kullanicilar set para=para+'" + guncel_tutar + "' where kuladi='" + id + "'", baglanti);
                    eurekle.ExecuteNonQuery();
                    break;
                case "Sterlin (GBP)":
                    guncel_tutar = kur_cevir(gbp_kuru.Text, miktar);
                    OleDbCommand gbpekle = new OleDbCommand("update kullanicilar set para=para+'" + guncel_tutar + "' where kuladi='" + id + "'", baglanti);
                    gbpekle.ExecuteNonQuery();
                    break;
                default:
                    MessageBox.Show("Hatalı İşlem.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private int kur_cevir(string doviz_kuru, int doviz_miktari)
        {
            int gonder;
            double tutar, kur;

            doviz_kuru = doviz_kuru.Replace('.', ',');
            kur = Convert.ToDouble(doviz_kuru);

            tutar = kur * doviz_miktari;
            tutar = Math.Round(tutar);

            gonder = Convert.ToInt32(tutar);

            return gonder;
        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void onay_listesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ekleme İşlemini Onaylıyor Musunuz?", "Onaylama Gerçekleştiriliyor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                int secim = onay_listesi.SelectedIndex;

                if (secim != -1)
                {
                    onayla(secim);
                    tablo_doldur();
                    MessageBox.Show("Ekleme İşlemi Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Seçim Yapınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
