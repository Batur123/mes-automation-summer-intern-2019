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
            DurusListesiGrid();
            AliciGridleri();
           
            UrunIDBox.Enabled = false;
            SOperatorIDBox.Enabled = false;
            DurusIDBox.Enabled = false;
            MakineIDBox.Enabled = false;
            IstenCikisDateTimeBox.Visible = false;


        }
        #endregion

        #region Operator Listesi Grid Doldurma
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

        #region Makine Listesi Grid Doldurma
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

        #region Operasyon Listesi Grid Doldurma
        private void OperasyonlarGrid()
        {

            try
            {
                using (var connection = MeshEkran.Veritabani.Database.GetConnection())
                {

                    // WHERE KullaniciAdi='" + KullaniciAdi + "'and Sifre='" + Sifre + "'"


                    var select = "exec PRC_OPERASYON";

                    var dataAdapter = new SqlDataAdapter(select, connection);

                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();
                    dataAdapter.Fill(ds);
                    //makinelerdeki op gridi
                    OperasyonGrid.ReadOnly = true;
                    OperasyonGrid.DataSource = ds.Tables[0];

                    OperasyonGrid.RowHeadersVisible = false;
                    OperasyonGrid.Columns[0].HeaderCell.Value = "Operasyon ID";
                    OperasyonGrid.Columns[1].HeaderCell.Value = "Operasyon Adı";

                    OperasyonGrid.Columns[0].Width = 90;
                    OperasyonGrid.Columns[1].Width = 150;
                    //makinelerdeki op gridi

                    //operasyon main grid
                    OperasyonlarMainGrid.ReadOnly = true;
                    OperasyonlarMainGrid.DataSource = ds.Tables[0];

                    OperasyonlarMainGrid.RowHeadersVisible = false;
                    OperasyonlarMainGrid.Columns[0].HeaderCell.Value = "Operasyon ID";
                    OperasyonlarMainGrid.Columns[1].HeaderCell.Value = "Operasyon Adı";

                    OperasyonlarMainGrid.Columns[0].Width = 150;
                    OperasyonlarMainGrid.Columns[1].Width = 1000;
                    //operasyon main grid
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
            }
        }
        #endregion

        #region Ürünler Listesi Grid Doldurma
        private void UrunlerListesiGrid()
        {

            try
            {
                using (var connection = Veritabani.Database.GetConnection())
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

        #region Duruş Listesi Grid Doldurma
        private void DurusListesiGrid()
        {

            try
            {
                using (var connection = Veritabani.Database.GetConnection())
                {

                    var select = "exec PRC_DurusSelect";
                    var dataAdapter = new SqlDataAdapter(select, connection);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();

                    dataAdapter.Fill(ds);
                    DurusGrid.ReadOnly = true;
                    DurusGrid.DataSource = ds.Tables[0];

                    DurusGrid.RowHeadersVisible = false;
                    DurusGrid.Columns[0].HeaderCell.Value = "Duruş ID";
                    DurusGrid.Columns[1].HeaderCell.Value = "Duruş Adı";
                    DurusGrid.Columns[2].HeaderCell.Value = "Duruş Açıklama";

                    DurusGrid.Columns[0].Width = 120;
                    DurusGrid.Columns[1].Width = 250;
                    DurusGrid.Columns[2].Width = 1000;

                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
            }
        }
        #endregion

        #region Alıcı Listesi Grid Doldurma
        private void AliciGridleri()
        {

            try
            {
                using (var connection = Veritabani.Database.GetConnection())
                {

                    var select = "exec PRC_AliciSelect";
                    var dataAdapter = new SqlDataAdapter(select, connection);
                    var commandBuilder = new SqlCommandBuilder(dataAdapter);
                    var ds = new DataSet();

                    dataAdapter.Fill(ds);
                    datagridview32.ReadOnly = true;
                    datagridview32.DataSource = ds.Tables[0];

                    datagridview32.RowHeadersVisible = false;
                    datagridview32.Columns[0].HeaderCell.Value = "Alıcı ID";
                    datagridview32.Columns[1].HeaderCell.Value = "Alıcı Adı";
                    datagridview32.Columns[2].HeaderCell.Value = "Alıcı Şirket Numarası";

                    datagridview32.Columns[0].Width = 120;
                    datagridview32.Columns[1].Width = 144;
                    datagridview32.Columns[2].Width = 200;

                }
            }
            catch (Exception msg)
            {
                MessageBox.Show("Veritabanı bağlantınız kurulamadı veya sistemde teknik bir hata oluştu. Lütfen programı kapatıp açınız." + "\n" + msg);
            }
        }
        #endregion

        #region Operatör Ekleme - Buton
        private void OperatorEklemeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (EAdBox.Text == "" || ESoyadBox.Text == "" || DogumDateTimeBox.Text == "" || ESicilNoBox.Text == "" || EDurumBox.Text == "" || isgirisdatetimebox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();

                    DogumDateTimeBox.Format = DateTimePickerFormat.Custom;
                    DogumDateTimeBox.CustomFormat = "yyyy/MM/dd hh:mm:ss";

                    isgirisdatetimebox.Format = DateTimePickerFormat.Custom;
                    isgirisdatetimebox.CustomFormat = "yyyy/MM/dd hh:mm:ss";

                    KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                    {
                        Isim = EAdBox.Text,
                        Soyisim = ESoyadBox.Text,
                        SicilNO = ESicilNoBox.Text,
                        DurumAP = Convert.ToInt32(EDurumBox.Text),
                        IsBaslangicTarihi = isgirisdatetimebox.Value,
                        DogumTarihi = DogumDateTimeBox.Value
                    };


                    if (islem.OperatorEkleme(giris))
                    {
                        MessageBox.Show("Operator ekleme işlemi başarıyla tamamlandı.");
                        OperatorGrid();
                    }
                    else
                    {
                        MessageBox.Show("Bu Operator numarasına ait bir makine zaten mevcuttur. Ekleme işlemi yapılamadı.");
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

        #region Operatör Silme - Buton
        private void OperatorSilBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ESicilNoBox.Text == "")
                {
                    MessageBox.Show("Lütfen Operator Sicil Numarası isimli kutucuğu boş bırakmayınız. Silme işlemi Operatorün Sicil Numarasına göre yapılmaktadır. Aksi takdirde işleminiz gerçekleşmeyecektir.");
                }
                else
                {

                    MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                    KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                    {
                        SicilNO = ESicilNoBox.Text
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

        #region Operatör Güncelleme - Buton
        private void OperatorGuncelleBtn_Click(object sender, EventArgs e)
        {


            try
            {
                if (durumcheck.Checked)
                {
                    EDurumBox.Enabled = false;
                    EDurumBox.Text = "0";

                    if (SOperatorIDBox.Text == "" || EAdBox.Text == "" || ESoyadBox.Text == "" || ESicilNoBox.Text == "" || EDurumBox.Text == "" || DogumDateTimeBox.Text == "")
                    {
                        MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                    }
                    else
                    {

                        DogumDateTimeBox.Format = DateTimePickerFormat.Custom;
                        DogumDateTimeBox.CustomFormat = "yyyy/MM/dd hh:mm:ss";

                        isgirisdatetimebox.Format = DateTimePickerFormat.Custom;
                        isgirisdatetimebox.CustomFormat = "yyyy/MM/dd hh:mm:ss";


                        Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                        KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                        {
                            OperatorID = Convert.ToInt32(SOperatorIDBox.Text),
                            Isim = EAdBox.Text,
                            Soyisim = ESoyadBox.Text,
                            DogumTarihi = DogumDateTimeBox.Value,
                            SicilNO = ESicilNoBox.Text,
                            DurumAP = 0,
                            IsBaslangicTarihi = isgirisdatetimebox.Value,
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
                        DogumDateTimeBox.Format = DateTimePickerFormat.Custom;
                        DogumDateTimeBox.CustomFormat = "yyyy/MM/dd hh:mm:ss";

                        isgirisdatetimebox.Format = DateTimePickerFormat.Custom;
                        isgirisdatetimebox.CustomFormat = "yyyy/MM/dd hh:mm:ss";


                        Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                        KullaniciDLL.Operator giris = new KullaniciDLL.Operator
                        {
                            OperatorID = Convert.ToInt32(SOperatorIDBox.Text),
                            Isim = EAdBox.Text,
                            Soyisim = ESoyadBox.Text,
                            DogumTarihi = DogumDateTimeBox.Value,
                            SicilNO = ESicilNoBox.Text,
                            DurumAP = 0,
                            IsBaslangicTarihi = isgirisdatetimebox.Value,
                            IsCikisTarihi = DateTime.Now
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

        #region Ürün Ekleme - Buton
        private void UrunEkleBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (UrunAciklamaBox.Text == "" || UrunAdiBox.Text == "" || UrunKoduBox.Text == "" || UrunEnBox.Text == "" || UrunBoyBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    MeshEkran.Classlar.SQLIslemleri islem = new MeshEkran.Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        UrunAciklama = UrunAciklamaBox.Text,
                        UrunAdi = UrunAdiBox.Text,
                        UrunKodu = UrunKoduBox.Text,
                        UrunEn = Convert.ToInt32(UrunEnBox.Text),
                        UrunBoy = Convert.ToInt32(UrunBoyBox.Text),
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

        #region Ürün Silme - Buton
        private void UrunSilmeBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (UrunKoduBox.Text == "")
                {
                    MessageBox.Show("Lütfen Ürün Kodu isimli kutucuğu boş bırakmayınız. Aksi takdirde silme işlemi yapamayacaksınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        UrunKodu = UrunKoduBox.Text,
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

        #region Ürün Güncelleme - Buton
        private void UrunGuncelleBtn_Click(object sender, EventArgs e)
        {

            if (UrunEnBox.Text == "" || UrunBoyBox.Text == "" || UrunAciklamaBox.Text == "" || UrunAdiBox.Text == "" || UrunKoduBox.Text == "" || UrunIDBox.Text == "")
            {
                MessageBox.Show("Lütfen boş kısım bırakmayınız.");
            }
            else
            {

                Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                MasDLL.Rapor giris = new MasDLL.Rapor
                {
                    UrunID = Convert.ToInt32(UrunIDBox.Text),
                    UrunAdi = UrunAdiBox.Text,
                    UrunKodu = UrunKoduBox.Text,
                    UrunAciklama = UrunAciklamaBox.Text,
                    UrunBoy = Convert.ToInt32(UrunBoyBox.Text),
                    UrunEn = Convert.ToInt32(UrunEnBox.Text)
                };

                if (islem.UrunGuncelleme(giris))
                {
                    MessageBox.Show("Ürün güncelleme işlemi başarıyla yapıldı.");
                    UrunlerListesiGrid();
                }
            }
            UrunlerListesiGrid();
        }


        #endregion

        #region Makine Silme - Buton
        private void MakineSilBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (MakineIDBox.Text == "")
                {
                    MessageBox.Show("Lütfen Makine ID isimli kutucuğu boş bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        MakineID = Convert.ToInt32(MakineIDBox.Text)
                    };



                    if (islem.MakineSilme(giris))
                    {
                        MessageBox.Show("Makine silme işlemi başarıyla tamamlandı.");
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

        #region Makine Güncelle - Buton
        private void MakineGuncelleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MakineAdiBox.Text == "" || MakineOperasyonIDBox.Text == "" || MakineIDBox.Text == "" || MakineKoduBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        MakineID = Convert.ToInt32(MakineIDBox.Text),
                        MakineAdi = MakineAdiBox.Text,
                        MakineKodu = MakineKoduBox.Text,
                        OperasyonID = Convert.ToInt32(MakineOperasyonIDBox.Text),

                    };

                    if (islem.MakineGuncelleme(giris))
                    {
                        MessageBox.Show("Makine güncelleme işlemi başarıyla yapıldı.");
                        MakinelerGrid();
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

        #region Makine Ekleme - Buton
        private void MakineEkleBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MakineAdiBox.Text == "" || MakineKoduBox.Text == "" || String.IsNullOrEmpty(MakineOperasyonIDBox.Text))
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        MakineAdi = MakineAdiBox.Text,
                        MakineKodu = MakineKoduBox.Text,
                        OperasyonID = Convert.ToInt32(MakineOperasyonIDBox.Text)
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

        #region Operasyon Ekleme - Buton
        private void OpMainEkle_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperasyonAdiMainBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        OperasyonAdi = OperasyonAdiMainBox.Text,
                        
                    };


                    if (islem.OperasyonEkleme(giris))
                    {
                        MessageBox.Show("Operasyon ekleme işlemi başarıyla tamamlandı.");
                        OperasyonlarGrid();
                    }
                    else
                    {
                        MessageBox.Show("Bu Operasyon koduna ait bir makine zaten mevcuttur. Ekleme işlemi yapılamadı.");
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

        #region Operasyon Silme - Buton
        private void OpMainSil_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperasyonIDMainBox.Text == "")
                {
                    MessageBox.Show("Lütfen Operasyon ID isimli kutucuğu boş bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        OperasyonID = Convert.ToInt32(OperasyonIDMainBox.Text)
                    };



                    if (islem.OperasyonSilme(giris))
                    {
                        MessageBox.Show("Operasyon silme işlemi başarıyla tamamlandı.");
                        OperasyonlarGrid();
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

        #region Operasyon Güncelleme - Buton
        private void OpMainGuncelle_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperasyonIDMainBox.Text == "" || OperasyonAdiMainBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        OperasyonAdi = OperasyonAdiMainBox.Text,
                        OperasyonID = Convert.ToInt32(OperasyonIDMainBox.Text),

                    };

                    if (islem.OperasyonGuncelleme(giris))
                    {
                        MessageBox.Show("Operasyon güncelleme işlemi başarıyla yapıldı.");
                        OperasyonlarGrid();
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

        #region Duruş Ekleme - Buton
        private void DurusEkle_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DurusAdBox.Text == "" || DurusAciklamaBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        DurusAd = DurusAdBox.Text,
                        DurusAciklama = DurusAciklamaBox.Text

                    };


                    if (islem.DurusEkle(giris))
                    {
                        MessageBox.Show("Duruş ekleme işlemi başarıyla tamamlandı.");
                        DurusListesiGrid();
                    }
                    else
                    {
                        MessageBox.Show("Bu koda ait bir duruş zaten mevcuttur. Ekleme işlemi yapılamadı.");
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

        #region Duruş Silme - Buton
        private void DurusSil_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DurusIDBox.Text == "")
                {
                    MessageBox.Show("Lütfen Duruş ID isimli kutucuğu boş bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        DurusID = Convert.ToInt32(DurusIDBox.Text)
                    };



                    if (islem.DurusSil(giris))
                    {
                        MessageBox.Show("Duruş silme işlemi başarıyla tamamlandı.");
                        DurusListesiGrid();
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

        #region Duruş Güncelleme - Buton
        private void DurusGuncelle_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (DurusAciklamaBox.Text == "" || DurusAdBox.Text == "" || DurusIDBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        DurusAd = DurusAdBox.Text,
                        DurusID = Convert.ToInt32(DurusIDBox.Text),
                        DurusAciklama = DurusAciklamaBox.Text

                    };

                    if (islem.DurusGuncelle(giris))
                    {
                        MessageBox.Show("Duruş güncelleme işlemi başarıyla yapıldı.");
                        OperasyonlarGrid();
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

        #region Giriş Ekranına Dönme - Buton
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

        #region Textbox'ları Temizleme - Butonlar
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }

        private void IptalSBtn_Click(object sender, EventArgs e)
        {
            TextBoxTemizle(this);
        }
        #endregion

        #region Textbox'ları Temizleme Fonksiyonu
        public void TextBoxTemizle(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
                if(c is RichTextBox)
                {
                    ((RichTextBox)c).Clear();
                }
                if (c.Controls.Count > 0)
                {
                    TextBoxTemizle(c);
                }
            }
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

        private void TextBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void MakineOperasyonIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void MakineIDBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox8_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox7_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UrunIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UrunEnBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void UrunBoyBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void TextBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TextBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SOperatorIDBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ESicilNoBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EDurumBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region DataGridView'ların CellClick Eventleri
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                TextBoxTemizle(this);
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

        private void UrunlerGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TextBoxTemizle(this);
                DataGridViewRow row = this.UrunlerGrid.Rows[e.RowIndex];
                UrunIDBox.Text = row.Cells[0].Value.ToString();
                UrunAdiBox.Text = row.Cells[1].Value.ToString();
                UrunAciklamaBox.Text = row.Cells[2].Value.ToString();
                UrunKoduBox.Text = row.Cells[3].Value.ToString();
                UrunEnBox.Text = row.Cells[4].Value.ToString();
                UrunBoyBox.Text = row.Cells[5].Value.ToString();
            }
        }

        private void MakineGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TextBoxTemizle(this);
                DataGridViewRow row = this.MakineGrid.Rows[e.RowIndex];
                MakineIDBox.Text = row.Cells[0].Value.ToString();
                MakineAdiBox.Text = row.Cells[1].Value.ToString();
                MakineKoduBox.Text = row.Cells[2].Value.ToString();
                MakineOperasyonIDBox.Text = row.Cells[3].Value.ToString();

            }
        }

        private void OperasyonGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TextBoxTemizle(this);
                DataGridViewRow row = this.OperasyonGrid.Rows[e.RowIndex];
                MakineOperasyonIDBox.Text = row.Cells[0].Value.ToString();

            }
        }


        private void OperasyonlarMainGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                TextBoxTemizle(this);
                DataGridViewRow row = this.OperasyonlarMainGrid.Rows[e.RowIndex];
                OperasyonAdiMainBox.Text = row.Cells[1].Value.ToString();
                OperasyonIDMainBox.Text = row.Cells[0].Value.ToString(); ;
            }
        }

        private void DurusGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                TextBoxTemizle(this);
                DataGridViewRow row = this.DurusGrid.Rows[e.RowIndex];
                DurusIDBox.Text = row.Cells[0].Value.ToString();
                DurusAdBox.Text = row.Cells[1].Value.ToString();
                DurusAciklamaBox.Text = row.Cells[2].Value.ToString();

            }
        }
        #endregion

        #region TabPageClick Eventleri
        private void TabControl3_SelectedIndexChanged(object sender, EventArgs e) //OperatorTab
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
                IstenCikisDateTimeBox.Visible = false;
                durumcheck.Enabled = false;
                EDurumBox.Enabled = false; ;
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
                IstenCikisDateTimeBox.Visible = true;
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
                IstenCikisDateTimeBox.Visible = true;
                durumcheck.Enabled = true;
                EDurumBox.Enabled = true;
                isgirisdatetimebox.Enabled = true;

            }
        }

        private void TabControl5_SelectedIndexChanged(object sender, EventArgs e) //UrunListesiTab
        {
            if (tabControl5.SelectedTab == tabControl5.TabPages["tabPage20"]) //ekleme
            {

                TextBoxTemizle(this);
                UrunIDBox.Enabled = false;
                UrunKoduBox.Enabled = true;
                UrunAciklamaBox.Enabled = true;
                UrunEnBox.Enabled = true;
                UrunBoyBox.Enabled = true;
                UrunAdiBox.Enabled = true;


            }
            if (tabControl5.SelectedTab == tabControl5.TabPages["tabPage21"]) //silme
            {

                TextBoxTemizle(this);
                UrunIDBox.Enabled = false;
                UrunKoduBox.Enabled = true;
                UrunAciklamaBox.Enabled = false;
                UrunEnBox.Enabled = false;
                UrunBoyBox.Enabled = false;
                UrunAdiBox.Enabled = false;

            }
            if (tabControl5.SelectedTab == tabControl5.TabPages["tabPage22"]) //güncelleme
            {

                TextBoxTemizle(this);
                UrunIDBox.Enabled = false;
                UrunKoduBox.Enabled = false;
                UrunAciklamaBox.Enabled = true;
                UrunEnBox.Enabled = true;
                UrunBoyBox.Enabled = true;
                UrunAdiBox.Enabled = true;

            }
        }

        private void TabControl2_SelectedIndexChanged(object sender, EventArgs e) // Makine Listesindeki Ekleme,Güncelleme,Silme İşlemini Yapan TabControl Eventi
        {
            if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage14"]) //ekleme
            {

                TextBoxTemizle(this);
                MakineIDBox.Enabled = false;
                MakineAdiBox.Enabled = true;
                MakineKoduBox.Enabled = true;
                MakineOperasyonIDBox.Enabled = false;
                MessageBox.Show("Lütfen Operasyon ID'sini sağdaki tablolardan seçiniz. Kutucuk üzerinde değiştirme yapamazsınız.");


            }
            if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage15"]) //silme
            {

                TextBoxTemizle(this);
                MakineIDBox.Enabled = true;
                MakineAdiBox.Enabled = false;
                MakineKoduBox.Enabled = false;
                MakineOperasyonIDBox.Enabled = false;

            }
            if (tabControl2.SelectedTab == tabControl2.TabPages["tabPage23"]) //güncelleme
            {

                TextBoxTemizle(this);
                MakineIDBox.Enabled = false;
                MakineAdiBox.Enabled = true;
                MakineKoduBox.Enabled = true;
                MakineOperasyonIDBox.Enabled = true;

            }

        }

        private void TabControl18_SelectedIndexChanged(object sender, EventArgs e) //OperasyonMainTab
        {
            if (tabControl18.SelectedTab == tabControl18.TabPages["tabPage45"]) //ekleme
            {

                TextBoxTemizle(this);
                OperasyonIDMainBox.Enabled = false;
                OperasyonAdiMainBox.Enabled = true;



            }
            if (tabControl18.SelectedTab == tabControl18.TabPages["tabPage46"]) //silme
            {

                TextBoxTemizle(this);
                OperasyonIDMainBox.Enabled = true;
                OperasyonAdiMainBox.Enabled = false;

            }
            if (tabControl18.SelectedTab == tabControl18.TabPages["tabPage47"]) //güncelleme
            {

                TextBoxTemizle(this);
                OperasyonIDMainBox.Enabled = false;
                OperasyonAdiMainBox.Enabled = true;

            }
        }

        private void DurusTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DurusTab.SelectedTab == DurusTab.TabPages["tabPage41"]) //ekleme
            {

                TextBoxTemizle(this);
                DurusAciklamaBox.Enabled = true;
                DurusIDBox.Enabled = false;
                DurusAdBox.Enabled = true;



            }
            if (DurusTab.SelectedTab == DurusTab.TabPages["tabPage43"]) //silme
            {

                TextBoxTemizle(this);
                DurusAciklamaBox.Enabled = false;
                DurusIDBox.Enabled = true;
                DurusAdBox.Enabled = false;

            }
            if (DurusTab.SelectedTab == DurusTab.TabPages["tabPage42"]) //güncelleme
            {

                TextBoxTemizle(this);
                DurusAciklamaBox.Enabled = true;
                DurusIDBox.Enabled = false;
                DurusAdBox.Enabled = true;

            }
        }

        #endregion

        #region Operator - Durum Checkbox Kontrolü
        private void Durumcheck_CheckedChanged(object sender, EventArgs e)
        {
            if (durumcheck.Checked)
            {

                EDurumBox.Enabled = false;
                EDurumBox.Text = "0";
                isgirisdatetimebox.Enabled = false;
                DateTimePicker IstenCikisDateTimeBox = new DateTimePicker();
                IstenCikisDateTimeBox.Value = DateTime.Now;


            }
            else
            {
                EDurumBox.Enabled = true;
                EDurumBox.Text = "1";
                isgirisdatetimebox.Enabled = true;
            }
        }
        #endregion

        #region Programı Yenile
        private void PictureBox5_Click(object sender, EventArgs e)
        {
            OperatorGrid();
            MakinelerGrid();
            UrunlerListesiGrid();
            OperasyonlarGrid();
            DurusListesiGrid();
            AliciGridleri();
        }
        #endregion

        #region ProgramiKapatmaEvent
        private void KapatButon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }








        #endregion

        #region Alıcı Ekleme - Buton
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (AliciAdBox.Text == "" || AliciNoBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        AliciAD = AliciAdBox.Text,
                        AliciSirketNo = Convert.ToInt32(AliciNoBox.Text)

                    };


                    if (islem.AliciEkle(giris))
                    {
                        MessageBox.Show("Alıcı ekleme işlemi başarıyla tamamlandı.");
                        AliciGridleri();
                    }
                    else
                    {
                        MessageBox.Show("Bu koda ait bir alıcı zaten mevcuttur. Ekleme işlemi yapılamadı.");
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

        #region Alıcı Güncelleme - Buton
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (OperasyonIDMainBox.Text == "" || OperasyonAdiMainBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        OperasyonAdi = OperasyonAdiMainBox.Text,
                        OperasyonID = Convert.ToInt32(OperasyonIDMainBox.Text),

                    };

                    if (islem.OperasyonGuncelleme(giris))
                    {
                        MessageBox.Show("Alıcı bilgileri güncelleme işlemi başarıyla yapıldı.");
                        OperasyonlarGrid();
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

        #region Alıcı Silme - Buton
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (DurusIDBox.Text == "")
                {
                    MessageBox.Show("Lütfen Alıcı ID isimli kutucuğu boş bırakmayınız.");
                }
                else
                {

                    Classlar.SQLIslemleri islem = new Classlar.SQLIslemleri();
                    MasDLL.Rapor giris = new MasDLL.Rapor
                    {
                        DurusID = Convert.ToInt32(DurusIDBox.Text)
                    };



                    if (islem.DurusSil(giris))
                    {
                        MessageBox.Show("Alıcı silme işlemi başarıyla tamamlandı.");
                        DurusListesiGrid();
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

        
    }
}

