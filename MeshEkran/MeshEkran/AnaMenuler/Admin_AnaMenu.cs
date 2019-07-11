using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshEkran
{
    public partial class Admin_AnaMenu : Form
    {
        public Admin_AnaMenu()
        {
            InitializeComponent();
        }

        #region FormLoadEkrani
        private void Admin_AnaMenu_Load(object sender, EventArgs e)
        {

            OperatorGrid();
            MakinelerGrid();
            OperasyonlarGrid();
            UrunlerListesiGrid();

        }
        #endregion

        #region OperatorListesiTab
        private void OperatorGrid()
        {
           
            try
            {
                using (var connection = MeshEkran.Veritabani.Database.GetConnection())
                {

                    // WHERE KullaniciAdi='" + KullaniciAdi + "'and Sifre='" + Sifre + "'"


                    var select = "SELECT * FROM Operator";

                    var dataAdapter = new SqlDataAdapter(select, connection);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    dataGridView1.ReadOnly = true;
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.Columns[0].HeaderCell.Value = "Operatör ID";
                    dataGridView1.Columns[1].HeaderCell.Value = "Ad";
                    dataGridView1.Columns[2].HeaderCell.Value = "Soyad";
                    dataGridView1.Columns[3].HeaderCell.Value = "TC Kimlik NO";
                    dataGridView1.Columns[4].HeaderCell.Value = "Doğum Tarihi";
                    dataGridView1.Columns[5].HeaderCell.Value = "Sicil Numarası";
                    dataGridView1.Columns[6].HeaderCell.Value = "İşe Başlangıç Tarihi";
                    dataGridView1.Columns[7].HeaderCell.Value = "İşten Çıkış Tarihi";
                    dataGridView1.Columns[8].HeaderCell.Value = "Durum-Aktif\\Pasif";

                    dataGridView1.Columns[6].Width = 150;
                    dataGridView1.Columns[7].Width = 150;
                    dataGridView1.Columns[0].Width = 100;
                    // dataGridView1.Columns[0].Width = 300;
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız.");
            }



        }
        #endregion

        #region MakineListesiTabGrid
        private void MakinelerGrid()
        {
           
            try
            {
                using (var connection = MeshEkran.Veritabani.Database.GetConnection())
                {

                    // WHERE KullaniciAdi='" + KullaniciAdi + "'and Sifre='" + Sifre + "'"


                    var select = "SELECT * FROM MakinelerTablosu";

                    var dataAdapter = new SqlDataAdapter(select, connection);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    MakineGrid.RowHeadersVisible = false;
                    MakineGrid.ReadOnly = true;
                    MakineGrid.DataSource = ds.Tables[0];

                    MakineGrid.Columns[0].HeaderCell.Value = "Makine ID";
                    MakineGrid.Columns[1].HeaderCell.Value = "Makine Adı";
                    MakineGrid.Columns[2].HeaderCell.Value = "Makine Kodu";
                    MakineGrid.Columns[3].HeaderCell.Value = "Operasyon ID";

                    MakineGrid.Columns[1].Width = 125;
                    MakineGrid.Columns[2].Width = 125;


                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız.");
            }


            
        }
        #endregion

        #region OperasyonListesiTabGrid
        private void OperasyonlarGrid()
        {

            try
            {
                using (var connection = MeshEkran.Veritabani.Database.GetConnection())
                {

                    // WHERE KullaniciAdi='" + KullaniciAdi + "'and Sifre='" + Sifre + "'"


                    var select = "SELECT * FROM OperasyonlarTablosu";

                    var dataAdapter = new SqlDataAdapter(select, connection);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    OperasyonGrid.ReadOnly = true;
                    OperasyonGrid.DataSource = ds.Tables[0];

                    OperasyonGrid.RowHeadersVisible = false;
                    OperasyonGrid.Columns[0].HeaderCell.Value = "Operasyon ID";
                    OperasyonGrid.Columns[1].HeaderCell.Value = "Operasyon Adı";

                    OperasyonGrid.Columns[0].Width = 80;
                    OperasyonGrid.Columns[1].Width = 120;

                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız.");
            }
        }
        #endregion

        #region UrunlerListesiGrid
        private void UrunlerListesiGrid()
        {

            try
            {
                using (var connection = MeshEkran.Veritabani.Database.GetConnection())
                {

                    var select = "SELECT * FROM UrunTablosu";

                    var dataAdapter = new SqlDataAdapter(select, connection);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    UrunlerGrid.ReadOnly = true;
                    UrunlerGrid.DataSource = ds.Tables[0];

                    UrunlerGrid.RowHeadersVisible = false;
                    UrunlerGrid.Columns[0].HeaderCell.Value = "Ürün ID";
                    UrunlerGrid.Columns[1].HeaderCell.Value = "Ürün Adı";
                    UrunlerGrid.Columns[2].HeaderCell.Value = "Ürün Açıklama";
                    UrunlerGrid.Columns[3].HeaderCell.Value = "Ürün Kodu";
                    UrunlerGrid.Columns[4].HeaderCell.Value = "En";
                    UrunlerGrid.Columns[5].HeaderCell.Value = "Boy";

                    UrunlerGrid.Columns[0].Width = 80;
                    UrunlerGrid.Columns[1].Width = 120;
                    UrunlerGrid.Columns[2].Width = 220;
                    UrunlerGrid.Columns[3].Width = 120;
                    UrunlerGrid.Columns[4].Width = 70;
                    UrunlerGrid.Columns[5].Width = 70;

                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız.");
            }
        }
        #endregion

        #region ProgramiKapatmaEvent
        private void KapatButon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region BirGeriFormaDonmeEventi
        private void GeriDonButon_Click(object sender, EventArgs e)
        {
            Giris_Admin ac = new Giris_Admin();
            ac.StartPosition = FormStartPosition.CenterScreen;
            ac.Show();
            this.Hide();
        }
        #endregion

        #region TextBoxlariTemizlemeEventi
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }
        #endregion

        #region TextBoxlariTemizlemeEventi
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }
        #endregion

        #region TextBoxTemizlemeFonksiyonu
        public void TextBoxTemizle(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    TextBoxTemizle(c);
                }
            }
        }
        #endregion

        #region MakineEklemeButonEvent
        private void MakineEkleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MakineAdText.Text == "" && MakineKoduText.Text == "" && OperasyonIDText.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor();

                    giris.MakineAdi = MakineAdText.Text;
                    giris.MakineKodu = MakineKoduText.Text;
                    giris.OperasyonID = Convert.ToInt32(OperasyonIDText.Text);
                   

                    if (islem.MakineEkleme(giris))
                    {
                        MessageBox.Show("Makine ekleme işlemi başarıyla tamamlandı.");
                        MakinelerGrid();
                        OperasyonlarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Bu Makine koduna ait bir makine zaten mevcuttur. Ekleme işlemi yapılamadı.");
                    }
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \n");
                MessageBox.Show(hata.Message);
            }

        }
        #endregion

        #region MakineSilmeButonEvent
        private void MakineSilmeBtn_Click(object sender, EventArgs e)
        {
            MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
            MasDLL.Rapor giris = new MasDLL.Rapor();

            if(MakineIDBox.Text == "")
            {
                MessageBox.Show("Boş alan bırakmayınız.");
            }
            else
            {
                giris.MakineID = Convert.ToInt32(MakineIDBox.Text);

                if (islem.MakineSilme(giris))
                {
                    MessageBox.Show("Makine silindi.");
                }

                MakinelerGrid();
                OperasyonlarGrid();

            }
           
        }
        #endregion

        #region TextBoxlariTemizlemeEvent
        private void IptalSBtn_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }
        #endregion

        #region TextBoxlara Girilecek Değerlerin KeyPress Kontrolleri
        private void MakineIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void OperasyonIDText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
      

        
        private void TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
