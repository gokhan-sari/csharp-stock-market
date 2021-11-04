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
using Microsoft.Office.Interop.Excel;
using excel = Microsoft.Office.Interop.Excel;

namespace borsa_projesi
{
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        private void rapor_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void rapor_getir()
        {
            if ((mallar.Text != "Ürün Seçiniz") && (islemler.Text != "İşlem Seçiniz") &&
               (dateTimePicker1.Value.ToString() != "30.06.2021 00:00:00" || dateTimePicker2.Value.ToString() != "30.06.2021 00:00:00"))
            {
                OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=vt.accdb;");
                baglanti.Open();

                OleDbCommand komut = new OleDbCommand("select tarih,urun,islem,fiyat,ilk_miktar from satis where kuladi='" + login.kullanici + "' and urun='" + mallar.Text + "' and islem='" + islemler.Text + "' and [tarih] BETWEEN ? AND ?", baglanti);
                komut.Parameters.AddWithValue("Tarih1", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("Tarih2", dateTimePicker2.Value);
                System.Data.DataTable tablo = new System.Data.DataTable();  
                tablo.Load(komut.ExecuteReader());
                rapor_tablosu.DataSource = tablo;   

                rapor_tablosu.Sort(rapor_tablosu.Columns[0], ListSortDirection.Ascending);

                baglanti.Close();
            }
        }

        private void rapor_olustur()
        {
            int i, j;

            excel.Application app = new excel.Application();     
            app.Visible = true;
            Workbook kitap = app.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sayfa = (Worksheet)kitap.Sheets[1];    

            for (i = 0; i < rapor_tablosu.Columns.Count; i++)     
            {
                Range alan = (Range)sayfa.Cells[1, 1];
                alan.Cells[1, i + 1] = rapor_tablosu.Columns[i].HeaderText;
            }

            for (i = 0; i < rapor_tablosu.Columns.Count; i++)     
            {
                for (j = 0; j < rapor_tablosu.Rows.Count; j++)
                {
                    Range alan2 = (Range)sayfa.Cells[j + 1, i + 1];
                    alan2.Cells[2, 1] = rapor_tablosu[i, j].Value;
                }
            }
        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            user user = new user();
            user.Show();
        }

        private void mallar_SelectedIndexChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void islemler_SelectedIndexChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            rapor_getir();
        }

        private void raporu_al_Click(object sender, EventArgs e)
        {
            rapor_olustur();
        }
    }
}
