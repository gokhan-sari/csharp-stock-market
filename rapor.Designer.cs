
namespace borsa_projesi
{
    partial class rapor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.geri_butonu = new System.Windows.Forms.Button();
            this.raporu_al = new System.Windows.Forms.Button();
            this.islemler = new System.Windows.Forms.ComboBox();
            this.rapor_tablosu = new System.Windows.Forms.DataGridView();
            this.tarih = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.islem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiyat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ilk_miktar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mallar = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.rapor_tablosu)).BeginInit();
            this.SuspendLayout();
            // 
            // geri_butonu
            // 
            this.geri_butonu.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geri_butonu.Location = new System.Drawing.Point(12, 12);
            this.geri_butonu.Name = "geri_butonu";
            this.geri_butonu.Size = new System.Drawing.Size(160, 40);
            this.geri_butonu.TabIndex = 78;
            this.geri_butonu.Text = "Anasayfa";
            this.geri_butonu.UseVisualStyleBackColor = true;
            this.geri_butonu.Click += new System.EventHandler(this.geri_butonu_Click);
            // 
            // raporu_al
            // 
            this.raporu_al.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.raporu_al.Location = new System.Drawing.Point(1131, 608);
            this.raporu_al.Name = "raporu_al";
            this.raporu_al.Size = new System.Drawing.Size(210, 50);
            this.raporu_al.TabIndex = 88;
            this.raporu_al.Text = "Raporu Al";
            this.raporu_al.UseVisualStyleBackColor = true;
            this.raporu_al.Click += new System.EventHandler(this.raporu_al_Click);
            // 
            // islemler
            // 
            this.islemler.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.islemler.FormattingEnabled = true;
            this.islemler.Items.AddRange(new object[] {
            "Satıldı",
            "Alındı"});
            this.islemler.Location = new System.Drawing.Point(331, 622);
            this.islemler.Name = "islemler";
            this.islemler.Size = new System.Drawing.Size(221, 36);
            this.islemler.TabIndex = 87;
            this.islemler.Text = "İşlem Seçiniz";
            this.islemler.SelectedIndexChanged += new System.EventHandler(this.islemler_SelectedIndexChanged);
            // 
            // rapor_tablosu
            // 
            this.rapor_tablosu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rapor_tablosu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.rapor_tablosu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rapor_tablosu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tarih,
            this.urun,
            this.islem,
            this.fiyat,
            this.ilk_miktar});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rapor_tablosu.DefaultCellStyle = dataGridViewCellStyle6;
            this.rapor_tablosu.Location = new System.Drawing.Point(41, 90);
            this.rapor_tablosu.Name = "rapor_tablosu";
            this.rapor_tablosu.RowHeadersWidth = 51;
            this.rapor_tablosu.RowTemplate.Height = 30;
            this.rapor_tablosu.Size = new System.Drawing.Size(1300, 450);
            this.rapor_tablosu.TabIndex = 85;
            // 
            // tarih
            // 
            this.tarih.DataPropertyName = "tarih";
            this.tarih.HeaderText = "Tarih";
            this.tarih.MinimumWidth = 6;
            this.tarih.Name = "tarih";
            // 
            // urun
            // 
            this.urun.DataPropertyName = "urun";
            this.urun.HeaderText = "Ürün Tipi";
            this.urun.MinimumWidth = 6;
            this.urun.Name = "urun";
            // 
            // islem
            // 
            this.islem.DataPropertyName = "islem";
            this.islem.HeaderText = "İşlem";
            this.islem.MinimumWidth = 6;
            this.islem.Name = "islem";
            // 
            // fiyat
            // 
            this.fiyat.DataPropertyName = "fiyat";
            this.fiyat.HeaderText = "Tutar";
            this.fiyat.MinimumWidth = 6;
            this.fiyat.Name = "fiyat";
            // 
            // ilk_miktar
            // 
            this.ilk_miktar.DataPropertyName = "ilk_miktar";
            this.ilk_miktar.HeaderText = "Miktar";
            this.ilk_miktar.MinimumWidth = 6;
            this.ilk_miktar.Name = "ilk_miktar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(876, 575);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 84;
            this.label3.Text = "Bitiş Tarihi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(611, 575);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 29);
            this.label2.TabIndex = 83;
            this.label2.Text = "Başlangıç Tarihi";
            // 
            // mallar
            // 
            this.mallar.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mallar.FormattingEnabled = true;
            this.mallar.Items.AddRange(new object[] {
            "Buğday",
            "Arpa",
            "Yulaf",
            "Petrol",
            "Pamuk"});
            this.mallar.Location = new System.Drawing.Point(41, 622);
            this.mallar.Name = "mallar";
            this.mallar.Size = new System.Drawing.Size(221, 36);
            this.mallar.TabIndex = 81;
            this.mallar.Text = "Ürün Seçiniz";
            this.mallar.SelectedIndexChanged += new System.EventHandler(this.mallar_SelectedIndexChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(881, 629);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker2.TabIndex = 80;
            this.dateTimePicker2.Value = new System.DateTime(2021, 6, 30, 0, 0, 0, 0);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(616, 629);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 29);
            this.dateTimePicker1.TabIndex = 79;
            this.dateTimePicker1.Value = new System.DateTime(2021, 6, 30, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1382, 753);
            this.Controls.Add(this.raporu_al);
            this.Controls.Add(this.islemler);
            this.Controls.Add(this.rapor_tablosu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mallar);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.geri_butonu);
            this.Name = "rapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.rapor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.rapor_tablosu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button geri_butonu;
        public System.Windows.Forms.Button raporu_al;
        private System.Windows.Forms.ComboBox islemler;
        private System.Windows.Forms.DataGridView rapor_tablosu;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarih;
        private System.Windows.Forms.DataGridViewTextBoxColumn urun;
        private System.Windows.Forms.DataGridViewTextBoxColumn islem;
        private System.Windows.Forms.DataGridViewTextBoxColumn fiyat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ilk_miktar;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox mallar;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}