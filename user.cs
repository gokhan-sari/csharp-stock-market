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
    public partial class user : Form
    {
        private const string ConnectionString = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;";
        private static OleDbConnection baglanti;
        private static OleDbCommand komut;
        private static OleDbDataReader sorgu;

        public user()
        {
            InitializeComponent();
            baglanti = new OleDbConnection(ConnectionString);
        }

        private void user_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void user_Load(object sender, EventArgs e)
        {
            para_mal_guncelle();
            satis_tablosu_guncelle();
            emir_tablosu_doldur();
        }

        private void emir_tablosu_doldur()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
            con.Open();

            komut = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat,tarih from satis where islem='Alınacak'", con);

            DataTable tablo = new DataTable();
            tablo.Load(komut.ExecuteReader());
            emir_tablosu.DataSource = tablo;

            con.Close();
        }

        private void alis_emri_kontrol(int son_satis)
        {
            baglanti.Open();

            OleDbCommand cmd = new OleDbCommand("select urun,miktar,fiyat from satis where kimlik=" + son_satis + "", baglanti);
            OleDbDataReader sorgu = cmd.ExecuteReader();

            string emir_urun, emir_id, son_urun, son_durum;
            int emir_miktar, emir_fiyat, emir_kimlik, son_miktar, son_fiyat, kalan_satilik_miktar, tam_tutar, eksik_tutar;


            while (sorgu.Read())
            {
                son_urun = Convert.ToString(sorgu["urun"]);
                son_miktar = Convert.ToInt32(sorgu["miktar"]);
                son_fiyat = Convert.ToInt32(sorgu["fiyat"]);

                OleDbCommand cmd1 = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat from satis where islem='Alınacak'", baglanti);
                DataTable tablo1 = new DataTable();
                tablo1.Load(cmd1.ExecuteReader());

                int emir_sayisi = tablo1.Rows.Count;

                for (int i = 0; i < emir_sayisi; i++) 
                {
                    emir_kimlik = Convert.ToInt32(tablo1.Rows[i]["kimlik"].ToString());
                    emir_id = tablo1.Rows[i]["kuladi"].ToString();
                    emir_urun = tablo1.Rows[i]["urun"].ToString();
                    emir_miktar = Convert.ToInt32(tablo1.Rows[i]["miktar"].ToString());
                    emir_fiyat = Convert.ToInt32(tablo1.Rows[i]["fiyat"].ToString());

                    tam_tutar = emir_miktar * son_fiyat;
                    eksik_tutar = son_miktar * son_fiyat;
                    kalan_satilik_miktar = son_miktar - emir_miktar;

                    if (emir_urun == son_urun)    
                    {
                        if (emir_fiyat >= son_fiyat)      
                        {
                            if (emir_miktar <= son_miktar)
                            {
                                if (kalan_satilik_miktar == 0)
                                {
                                    son_durum = "Satıldı";
                                }
                                else
                                {
                                    son_durum = "Satılık";
                                }

                                OleDbCommand cmd2 = new OleDbCommand("update satis set miktar=miktar-'" + emir_miktar + "', islem='" + son_durum + "' where kimlik=" + son_satis + "", baglanti);
                                cmd2.ExecuteNonQuery();   

                                string secilen_urun = urun_bul(son_urun);
                                OleDbCommand cmd3 = new OleDbCommand("update kullanicilar set " + secilen_urun + "=" + secilen_urun + "+'" + emir_miktar + "', para=para-" + tam_tutar + " where kuladi='" + emir_id + "'", baglanti);
                                cmd3.ExecuteNonQuery();    

                                OleDbCommand cmd4 = new OleDbCommand("update kullanicilar set para=para+'" + tam_tutar + "' where kuladi='" + login.kullanici + "'", baglanti);
                                cmd4.ExecuteNonQuery();  

                                OleDbCommand cmd5 = new OleDbCommand("update satis set miktar='0', islem='Alındı' where kimlik=" + emir_kimlik + "", baglanti);
                                cmd5.ExecuteNonQuery();    

                                son_miktar = son_miktar - emir_miktar;

                                MessageBox.Show("Alım Emri Bulundu ve Satış Gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                OleDbCommand cmd2 = new OleDbCommand("update satis set miktar='0', islem='Satıldı' where kimlik=" + son_satis + "", baglanti);
                                cmd2.ExecuteNonQuery();

                                string secilen_urun = urun_bul(son_urun);
                                OleDbCommand cmd3 = new OleDbCommand("update kullanicilar set " + secilen_urun + "=" + secilen_urun + "+'" + son_miktar + "', para=para-" + eksik_tutar + " where kuladi='" + emir_id + "'", baglanti);
                                cmd3.ExecuteNonQuery(); 

                                OleDbCommand cmd4 = new OleDbCommand("update kullanicilar set para=para+'" + eksik_tutar + "' where kuladi='" + login.kullanici + "'", baglanti);
                                cmd4.ExecuteNonQuery();  

                                OleDbCommand cmd5 = new OleDbCommand("update satis set miktar=miktar-'" + son_miktar + "' where kimlik=" + emir_kimlik + "", baglanti);
                                cmd5.ExecuteNonQuery();    

                                MessageBox.Show("Alım Emri Bulundu ve Satış Gerçekleştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                            }
                        }
                        else
                        {                            
                        }
                    }
                    else
                    {                        
                    }
                }
            }

            baglanti.Close();
        }

        private void para_mal_guncelle()
        {
            baglanti.Open();

            komut = new OleDbCommand("select * from kullanicilar where kuladi='" + login.kullanici + "'", baglanti);
            sorgu = komut.ExecuteReader();

            while (sorgu.Read())
            {
                bakiye.Text = Convert.ToString(sorgu["para"]);
                bugday_mikt.Text = Convert.ToString(sorgu["bugday"]);
                arpa_mikt.Text = Convert.ToString(sorgu["arpa"]);
                yulaf_mikt.Text = Convert.ToString(sorgu["yulaf"]);
                petrol_mikt.Text = Convert.ToString(sorgu["petrol"]);
                pamuk_mikt.Text = Convert.ToString(sorgu["pamuk"]);
            }

            baglanti.Close();
        }

        private void para_mal_ekle(string eklenecek)
        {
            baglanti.Open();

            if (eklenecek == "para")
            {
                if (paralar.Text != "Dövizi Seçiniz" && para_gir.Text != "" && para_gir.Text != "0")
                {
                    komut = new OleDbCommand("insert into onaytablosu (kuladi,urun,miktar,durum) values('" + login.kullanici + "','" + paralar.Text + "','" + para_gir.Text + "','" + "Beklemede" + "')", baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ekleme İşlemi Tamamlandı. Admin Onayı Bekleniyor.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    paralar.Text = "Dövizi Seçiniz";
                    para_gir.Text = "";
                }
                else
                {
                    MessageBox.Show("Döviz Türü Seçiniz ve Miktar Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (eklenecek == "mal")
            {
                if (mallar.Text != "Ürünü Seçiniz" && mal_gir.Text != "" && mal_gir.Text != "0")
                {
                    komut = new OleDbCommand("insert into onaytablosu (kuladi,urun,miktar,durum) values('" + login.kullanici + "','" + mallar.Text + "','" + mal_gir.Text + "','" + "Beklemede" + "')", baglanti);
                    komut.ExecuteNonQuery();

                    MessageBox.Show("Ekleme İşlemi Tamamlandı. Admin Onayı Bekleniyor.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    mallar.Text = "Ürünü Seçiniz";
                    mal_gir.Text = "";
                }
                else
                {
                    MessageBox.Show("Ürün Seçiniz ve Miktar Giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            baglanti.Close();
        }

        private void satis_tablosu_guncelle()
        {
            baglanti.Open();

            komut = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat,tarih from satis where islem='Satılık'", baglanti);
            DataTable tablo = new DataTable();
            tablo.Load(komut.ExecuteReader());
            satis_tablosu.DataSource = tablo;

            satis_tablosu.Sort(satis_tablosu.Columns[0], ListSortDirection.Ascending);

            baglanti.Close();
        }

        private void satisa_cikart(string satilacak_urun, int satilacak_miktar, int satilacak_fiyat)
        {
            baglanti.Open();

            string secilen_urun = urun_bul(satilacak_urun);

            DateTime dt = new DateTime();
            dt = DateTime.Now;

            komut = new OleDbCommand("insert into satis (kuladi,urun,ilk_miktar,miktar,fiyat,islem,tarih) values('" + login.kullanici + "','" + satilacak_urun + "','" + satilacak_miktar + "','" + satilacak_miktar + "','" + satilacak_fiyat + "','" + "Satılık" + "','" + dt.ToString("dd/MM/yyyy") + "')", baglanti);
            komut.ExecuteNonQuery();

            komut = new OleDbCommand("update kullanicilar set " + secilen_urun + "=" + secilen_urun + "-'" + satilacak_miktar + "' where kuladi='" + login.kullanici + "'", baglanti);
            komut.ExecuteNonQuery();

            MessageBox.Show("Ürün Satışa Çıkarıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            baglanti.Close();
        }

        private string urun_bul(string secim)
        {
            string urun = "";

            switch (secim)
            {
                case "Buğday":
                    urun = "bugday";
                    break;
                case "Arpa":
                    urun = "arpa";
                    break;
                case "Yulaf":
                    urun = "yulaf";
                    break;
                case "Petrol":
                    urun = "petrol";
                    break;
                case "Pamuk":
                    urun = "pamuk";
                    break;
                default:
                    MessageBox.Show("Hatalı İşlem.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            return urun;
        }

        private int komisyon_al(int alinacak_miktar, int alinacak_fiyat)
        {
            int komisyon = 1;
            double tutar, miktar, fiyat;

            miktar = Convert.ToDouble(alinacak_miktar);
            fiyat = Convert.ToDouble(alinacak_fiyat);

            tutar = ((miktar * fiyat) / 100);

            tutar = Math.Round(tutar);

            if (tutar > komisyon)
            {
                komisyon = Convert.ToInt32(tutar);
            }

            baglanti.Open();

            komut = new OleDbCommand("update kullanicilar set para=para+'" + komisyon + "' where kuladi='admin'", baglanti);
            komut.ExecuteNonQuery();

            komut = new OleDbCommand("update kullanicilar set para=para-'" + komisyon + "' where kuladi='" + login.kullanici + "'", baglanti);
            komut.ExecuteNonQuery();

            baglanti.Close();

            return komisyon;
        }

        private void urunler1_SelectedIndexChanged(object sender, EventArgs e)
        {
            alim_listesi_guncelle();
        }

        private void alim_listesi_guncelle()
        {
            baglanti.Open();

            komut = new OleDbCommand("select kimlik,kuladi,urun,miktar,fiyat,tarih from satis where urun='" + urunler1.Text + "' and islem='Satılık'", baglanti);

            DataTable tablo = new DataTable();
            tablo.Load(komut.ExecuteReader());
            satis_tablosu.DataSource = tablo;

            satis_tablosu.Sort(satis_tablosu.Columns[4], ListSortDirection.Ascending);

            baglanti.Close();
        }

        private void alis_yap(string alinacak_urun, int alinacak_miktar, int alinacak_fiyat)
        {
            baglanti.Open();

            int satir_sayisi = satis_tablosu.Rows.Count - 1;
            string durum, id;
            int fiyat, miktar, kalan, kimlik, tam_tutar, eksik_tutar;

            for (int i = 0; i < satir_sayisi; i++)
            {
                fiyat = Convert.ToInt32(satis_tablosu.Rows[i].Cells["fiyat"].Value.ToString());
                miktar = Convert.ToInt32(satis_tablosu.Rows[i].Cells["miktar"].Value.ToString());
                kimlik = Convert.ToInt32(satis_tablosu.Rows[i].Cells["kimlik"].Value.ToString());
                id = satis_tablosu.Rows[i].Cells["kuladi"].Value.ToString();
                tam_tutar = fiyat * alinacak_miktar;
                eksik_tutar = fiyat * miktar;

                if (fiyat <= alinacak_fiyat)
                {
                    if (miktar >= alinacak_miktar)
                    {
                        kalan = miktar - alinacak_miktar;

                        if (kalan == 0)
                        {
                            durum = "Satıldı";
                        }
                        else
                        {
                            durum = "Satılık";
                        }

                        komut = new OleDbCommand("update satis set miktar=miktar-'" + alinacak_miktar + "', islem='" + durum + "' where kimlik=" + kimlik + "", baglanti);
                        komut.ExecuteNonQuery();

                        string secilen_urun = urun_bul(alinacak_urun);
                        komut = new OleDbCommand("update kullanicilar set " + secilen_urun + "=" + secilen_urun + "+'" + alinacak_miktar + "', para=para-" + tam_tutar + " where kuladi='" + login.kullanici + "'", baglanti);
                        komut.ExecuteNonQuery();

                        komut = new OleDbCommand("update kullanicilar set para=para+'" + tam_tutar + "' where kuladi='" + id + "'", baglanti);
                        komut.ExecuteNonQuery();

                        alinacak_miktar = 0;

                        MessageBox.Show("Alış İşlemi Tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        break;
                    }
                    else
                    {
                        komut = new OleDbCommand("update satis set miktar='0', islem='Satıldı' where kimlik=" + kimlik + "", baglanti);
                        komut.ExecuteNonQuery();

                        string secilen_urun = urun_bul(alinacak_urun);
                        komut = new OleDbCommand("update kullanicilar set " + secilen_urun + "=" + secilen_urun + "+'" + miktar + "', para=para-" + eksik_tutar + " where kuladi='" + login.kullanici + "'", baglanti);
                        komut.ExecuteNonQuery();

                        komut = new OleDbCommand("update kullanicilar set para=para+'" + eksik_tutar + "' where kuladi='" + id + "'", baglanti);
                        komut.ExecuteNonQuery();

                        alinacak_miktar = alinacak_miktar - miktar;
                    }
                }
                else
                {
                    MessageBox.Show("Kalan Ürünler İçin Alış Emri Oluşturuldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
            }

            DateTime dt = new DateTime();
            dt = DateTime.Now;

            if (alinacak_miktar == 0)
            {
                komut = new OleDbCommand("insert into satis (kuladi,urun,ilk_miktar,miktar,fiyat,islem,tarih) values('" + login.kullanici + "','" + alinacak_urun + "','" + Convert.ToInt32(alis_miktari.Text) + "','" + alinacak_miktar + "','" + alinacak_fiyat + "','" + "Alındı" + "','" + dt.ToString("dd/MM/yyyy") + "')", baglanti);
                komut.ExecuteNonQuery();
            }
            else
            {
                komut = new OleDbCommand("insert into satis (kuladi,urun,ilk_miktar,miktar,fiyat,islem,tarih) values('" + login.kullanici + "','" + alinacak_urun + "','" + Convert.ToInt32(alis_miktari.Text) + "','" + alinacak_miktar + "','" + alinacak_fiyat + "','" + "Alınacak" + "','" + dt.ToString("dd/MM/yyyy") + "')", baglanti);
                komut.ExecuteNonQuery();
            }

            emir_tablosu_doldur();

            baglanti.Close();
        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void para_ekle_Click(object sender, EventArgs e)
        {
            para_mal_ekle("para");
        }

        private void urun_ekle_Click(object sender, EventArgs e)
        {
            para_mal_ekle("mal");
        }

        private void satis_Click(object sender, EventArgs e)
        {
            if (urunler.Text != "Seçiniz" && satis_miktari.Text != "" && satis_miktari.Text != "0" && satis_fiyati.Text != "" && satis_fiyati.Text != "0")
            {
                if ((urunler.Text == "Buğday" && (Convert.ToInt32(bugday_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Arpa" && (Convert.ToInt32(arpa_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Yulaf" && (Convert.ToInt32(yulaf_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Petrol" && (Convert.ToInt32(petrol_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))) ||
                    (urunler.Text == "Pamuk" && (Convert.ToInt32(pamuk_mikt.Text) >= Convert.ToInt32(satis_miktari.Text))))
                {
                    string satilacak_urun = urunler.Text;
                    int satilacak_miktar = Convert.ToInt32(satis_miktari.Text);
                    int satilacak_fiyat = Convert.ToInt32(satis_fiyati.Text);

                    satisa_cikart(satilacak_urun, satilacak_miktar, satilacak_fiyat);
                    satis_tablosu_guncelle();
                    para_mal_guncelle();

                    satis_tablosu.FirstDisplayedScrollingRowIndex = satis_tablosu.RowCount - 1;

                    satis_tablosu.ClearSelection();  
                    satis_tablosu[0, satis_tablosu.RowCount - 2].Selected = true;
                    satis_tablosu.CurrentCell = satis_tablosu.Rows[satis_tablosu.RowCount - 2].Cells[0];

                    int son_satis = satis_tablosu.RowCount - 2;
                    son_satis = Convert.ToInt32(satis_tablosu[0, son_satis].Value.ToString());

                    alis_emri_kontrol(son_satis);  
                    emir_tablosu_doldur();


                    urunler.Text = "Seçiniz";
                    satis_miktari.Text = "";
                    satis_fiyati.Text = "";



                }
                else
                {
                    MessageBox.Show("Hatalı Değer Girildi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Satılacak Ürünü Seçip Bilgileri Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alis_Click(object sender, EventArgs e)
        {
            if (urunler1.Text != "Seçiniz" && alis_miktari.Text != "" && alis_miktari.Text != "0" && alis_fiyati.Text != "" && alis_fiyati.Text != "0")
            {
                int miktar = Convert.ToInt32(alis_miktari.Text);
                int fiyat = Convert.ToInt32(alis_fiyati.Text);
                int para = Convert.ToInt32(bakiye.Text);
                int alinacak_komisyon = komisyon_al(miktar, fiyat);

                if (para >= (alinacak_komisyon + (miktar * fiyat)))
                {
                    MessageBox.Show(String.Format("{0}TL Komisyon Tahsil Edildi.", Convert.ToString(alinacak_komisyon)), "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string alinacak_urun = urunler1.Text;
                    alis_yap(alinacak_urun, miktar, fiyat);

                    para_mal_guncelle();
                    satis_tablosu_guncelle();
                    alim_listesi_guncelle();
                    emir_tablosu_doldur();

                    urunler1.Text = "Seçiniz";
                    alis_miktari.Text = "";
                    alis_fiyati.Text = "";
                }
                else
                {
                    MessageBox.Show("Paranız Yeterli Değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yapıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rapor_olustur_Click(object sender, EventArgs e)
        {
            this.Hide();
            rapor rapor = new rapor();
            rapor.Show();
        }

        private void alim_emirleri_Click(object sender, EventArgs e)
        {
            if(emir_tablosu.Visible == false)
            {
                emir_tablosu.Visible = true;
            }
            else
            {
                emir_tablosu.Visible = false;
            }
        }
    }
}
