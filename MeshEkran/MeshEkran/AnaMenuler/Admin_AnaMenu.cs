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

        #region OperatorListesiTabGrid
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
                    OperatorlerGrid.ReadOnly = true;
                    OperatorlerGrid.DataSource = ds.Tables[0];

                    OperatorlerGrid.RowHeadersVisible = false;
                    OperatorlerGrid.Columns[0].HeaderCell.Value = "Operatör ID";
                    OperatorlerGrid.Columns[1].HeaderCell.Value = "Ad";
                    OperatorlerGrid.Columns[2].HeaderCell.Value = "Soyad";
                    OperatorlerGrid.Columns[3].HeaderCell.Value = "TC Kimlik NO";
                    OperatorlerGrid.Columns[4].HeaderCell.Value = "Doğum Tarihi";
                    OperatorlerGrid.Columns[5].HeaderCell.Value = "Sicil Numarası";
                    OperatorlerGrid.Columns[6].HeaderCell.Value = "İşe Başlangıç Tarihi";
                    OperatorlerGrid.Columns[7].HeaderCell.Value = "İşten Çıkış Tarihi";
                    OperatorlerGrid.Columns[8].HeaderCell.Value = "Durum-Aktif\\Pasif";

                    OperatorlerGrid.Columns[6].Width = 150;
                    OperatorlerGrid.Columns[7].Width = 150;
                    OperatorlerGrid.Columns[0].Width = 100;
                    // dataGridView1.Columns[0].Width = 300;
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
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
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
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
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
            }
        }
        #endregion

        #region UrunlerListesiTabGrid
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
                    UrunlerGrid.ReadOnly = false;
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
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);

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
            Giris_Admin ac = new Giris_Admin
            {
                StartPosition = FormStartPosition.CenterScreen
            };
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
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        MakineAdi = MakineAdText.Text,
                        MakineKodu = MakineKoduText.Text,
                        OperasyonID = Convert.ToInt32(OperasyonIDText.Text)
                    };


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

            textBox16.Text = MeshEkran.Classlar.SQLIslemleri.PSoperasyonid;
            textBox17.Text = MeshEkran.Classlar.SQLIslemleri.PSkodu;
            textBox18.Text = MeshEkran.Classlar.SQLIslemleri.PSid;

            if (MakineIDBox.Text == "")
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

        #region OperatorlerGrid CellClick Eventi
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.OperatorlerGrid.Rows[e.RowIndex];
                label2.Text = row.Cells[0].Value.ToString();
                SOperatorIDBox.Text = row.Cells[0].Value.ToString();
                EAdBox.Text = row.Cells[1].Value.ToString();
                ESoyadBox.Text = row.Cells[2].Value.ToString();
                DogumDateTimeBox.Text = row.Cells[4].Value.ToString();
                ESicilNoBox.Text = row.Cells[5].Value.ToString();
                EDurumBox.Text = row.Cells[8].Value.ToString();
                IstenCikisDateTimeBox.Text = row.Cells[6].Value.ToString();
            }
        }
        #endregion

        #region OperatorEklemeButonEvent
        private void OperatorEklemeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EAdBox.Text == "" && ESoyadBox.Text == "" && DogumDateTimeBox.Text == "" && ESicilNoBox.Text == "" && EDurumBox.Text == "" && isgirisdatetimebox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        MakineAdi = MakineAdText.Text,
                        MakineKodu = MakineKoduText.Text,
                        OperasyonID = Convert.ToInt32(OperasyonIDText.Text)
                    };


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

        #region OperatorSilButonEvent
        private void OperatorSilBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SOperatorIDBox.Text == "")
                {
                    MessageBox.Show("Lütfen Operator ID isimli kutucuğu boş bırakmayınız. Aksi takdirde silme işlemi yapamayacaksınız.");
                }
                else
                {

                    MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                    KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                    {
                        OperatorID = Convert.ToInt32(label2.Text)
                    };



                    if (islem.OperatorSilme(giris))
                    {
                        MessageBox.Show("Operatör silme işlemi başarıyla tammalandı.");
                        OperatorGrid();
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

        #region OperatorGuncelleButonEvent
        private void OperatorGuncelleBtn_Click(object sender, EventArgs e)
        {



            try
            {
                if (durumcheck.Checked)
                {
                    EDurumBox.Enabled = false;
                    EDurumBox.Text = "0";

                    if (SOperatorIDBox.Text == "" && EAdBox.Text == "" && ESoyadBox.Text == "" && ESicilNoBox.Text == "" & EDurumBox.Text == "" & DogumDateTimeBox.Text == "")
                    {
                        MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                    }
                    else
                    {

                        MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                        KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                        {
                            DurumAP = 0,
                            OperatorID = Convert.ToInt32(label2.Text),
                            Isim = MakineKoduText.Text,
                            Soyisim = ESoyadBox.Text,
                            DogumTarihi = DogumDateTimeBox.Value,
                            //DateTime.Parse(DogumDateTimeBox,System.Globalization.CultureInfo.InvariantCulture);
                            SicilNO = ESicilNoBox.Text,
                            IsCikisTarihi = DateTime.Now
                        };



                        if (islem.OperatorGuncelleme(giris))
                        {
                            MessageBox.Show("Operatör güncelleme işlemi başarıyla yapıldı.");
                            OperatorGrid();
                        }

                    }
                }
                else
                {
                    if (SOperatorIDBox.Text == "" && EAdBox.Text == "" && ESoyadBox.Text == "" && ESicilNoBox.Text == "" & EDurumBox.Text == "" & DogumDateTimeBox.Text == "")
                    {
                        MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                    }
                    else
                    {

                        MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                        KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                        {
                            DurumAP = 1,
                            OperatorID = Convert.ToInt32(label2.Text),
                            Isim = MakineKoduText.Text,
                            Soyisim = ESoyadBox.Text,
                            DogumTarihi = DogumDateTimeBox.Value,
                            SicilNO = ESicilNoBox.Text
                        };



                        if (islem.OperatorGuncelleme(giris))
                        {
                            MessageBox.Show("Operatör güncelleme işlemi başarıyla yapıldı.");
                            OperatorGrid();
                        }

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

        #region OperatorTabPageClickEventListesi
        private void TabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == tabControl3.TabPages["tabPage17"]) //ekleme
            {

                TextBoxTemizle(this);
                SOperatorIDBox.Enabled = false;
                EAdBox.Enabled = true;
                ESoyadBox.Enabled = true;
                DogumDateTimeBox.Enabled = true;
                ESicilNoBox.Enabled = true;
                IstenCikisDateTimeBox.Enabled = false;
                durumcheck.Enabled = false;
                EDurumBox.Enabled = true;
                isgirisdatetimebox.Enabled = true;

                EDurumBox.Text = "1";



            }
            if (tabControl3.SelectedTab == tabControl3.TabPages["tabPage18"]) //silme
            {

                TextBoxTemizle(this);
                SOperatorIDBox.Enabled = true;
                EAdBox.Enabled = false;
                ESoyadBox.Enabled = false;
                DogumDateTimeBox.Enabled = false;
                ESicilNoBox.Enabled = false;
                IstenCikisDateTimeBox.Enabled = false;
                durumcheck.Enabled = false;
                EDurumBox.Enabled = false;
                isgirisdatetimebox.Enabled = false;

            }
            if (tabControl3.SelectedTab == tabControl3.TabPages["tabPage16"]) //güncelleme
            {

                TextBoxTemizle(this);
                SOperatorIDBox.Enabled = false;
                EAdBox.Enabled = true;
                ESoyadBox.Enabled = true;
                DogumDateTimeBox.Enabled = true;
                ESicilNoBox.Enabled = true;
                IstenCikisDateTimeBox.Enabled = true;
                durumcheck.Enabled = true;
                EDurumBox.Enabled = true;
                isgirisdatetimebox.Enabled = true;

            }
        }

        #endregion

        #region ÜrünEklemeButonEvent
        private void UrunEkleBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (urunaciklamabox.Text == "" && urunadibox.Text == "" && urunkodubox.Text == "" && enbox.Text == "" && boybox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        UrunAciklama = urunaciklamabox.Text,
                        UrunAdi = urunadibox.Text,
                        UrunKodu = urunkodubox.Text,
                        UrunEn = Convert.ToInt32(enbox.Text),
                        UrunBoy = Convert.ToInt32(boybox.Text),
                    };


                    if (islem.UrunEkleme(giris))
                    {
                        MessageBox.Show("Ürün ekleme işlemi başarıyla tamamlandı.");
                        UrunlerListesiGrid();
                    }
                    else
                    {
                        MessageBox.Show("Bu ürün koduna ait bir ürün zaten mevcuttur. Ekleme işlemi yapılamadı.");
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

        #region ÜrünSilButonEvent
        private void UrunSilmeBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (UrunKoduSBox.Text == "")
                {
                    MessageBox.Show("Lütfen Ürün Kodu isimli kutucuğu boş bırakmayınız. Aksi takdirde silme işlemi yapamayacaksınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        UrunKodu = UrunKoduSBox.Text,
                    };



                    if (islem.UrunSilme(giris))
                    {
                        MessageBox.Show("Ürün silme işlemi başarıyla tammalandı.");
                        UrunlerListesiGrid();
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

        private void UrunGuncelleBtn_Click(object sender, EventArgs e)
        {
         
            if (GUrunAcikBox.Text == "" && GUrunAdiBox.Text == "" && GUrunKoduBox.Text == "" && GUrunIDBox.Text == "" & GUrunBoyBox.Text == "" & GUrunEnBox.Text == "")
            {
                MessageBox.Show("Lütfen boş kısım bırakmayınız.");
            }
            else
            {

                Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                MasDLL.Rapor giris = new MasDLL.Rapor
                {
                    UrunID = Convert.ToInt32(GUrunIDBox.Text),
                    UrunAdi = GUrunAdiBox.Text,
                    UrunKodu = GUrunKoduBox.Text,
                    UrunAciklama = GUrunAcikBox.Text,
                    UrunBoy = Convert.ToInt32(GUrunBoyBox.Text),
                    UrunEn = Convert.ToInt32(GUrunEnBox.Text)
                };

                if (islem.UrunGuncelleme(giris))
                {
                    MessageBox.Show("Ürün güncelleme işlemi başarıyla yapıldı.");
                    UrunlerListesiGrid();
                }
            }
        }
    }
}

