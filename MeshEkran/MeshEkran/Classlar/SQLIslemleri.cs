using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshEkran.Classlar
{
    public class SQLIslemleri
    {

        public static string PSid, PSadi, PSkodu, PSoperasyonid;


        #region MakineVarmiKontrolu
        private bool MakineVarsa(MasDLL.Rapor degisken)
        {


            bool result = false;
            using (var connection = MeshEkran.Veritabani.Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM MakinelerTablosu WHERE MakineKodu='" + degisken.MakineKodu + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;

        }
        #endregion

        #region MakineEkleme
        public bool MakineEkleme(MasDLL.Rapor degisken)
        {

            bool result = false;
            if (!MakineVarsa(degisken))
            {
                using (var baglanti = MeshEkran.Veritabani.Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into MakinelerTablosu(MakineAdi,MakineKodu,OperasyonID) values (@makineadi,@makinekodu,@operasyonid)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@makineadi", degisken.MakineAdı);
                        komut.Parameters.AddWithValue("@makinekodu", degisken.MakineKodu);
                        komut.Parameters.AddWithValue("@operasyonid", degisken.OperasyonID);
                        baglanti.Open();
                        if (komut.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }
                        baglanti.Close();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu. \n\n\n\n" + hata.Message);
                    }

                    return result;
                }
            }
            return result;
        }
        #endregion

        #region MakineSilme
        public bool MakineSilme(MasDLL.Rapor degisken)
        {

            bool result = false;
            using (var baglanti = MeshEkran.Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from MakinelerTablosu where MakineID=@MakineID";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@MakineID", degisken.MakineID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["MakineID"].ToString();
                    string adi = dr["MakineAdi"].ToString();
                    string kodu = dr["MakineKodu"].ToString();

                    //////////////////////////
                    PSid = dr["MakineID"].ToString();
                    PSadi = dr["MakineAdi"].ToString();
                    PSkodu = dr["MakineKodu"].ToString();
                    PSoperasyonid = dr["OperasyonID"].ToString();
                    /////////////////////////

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numarali " + adi + " " + kodu + " isimli makineyi veritabanından silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        string silmeSorgusu = "DELETE from MakinelerTablosu where MakineID=@MakineID";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@MakineID", degisken.MakineID);
                        if (silKomutu.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }


                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir makine yok.");
                }

                return result;
            }
        }
        #endregion

        #region MakineGuncelleme

        #endregion

        #region OperatorVarmiKontrolu
        public bool OperatorVarmiKontrolu(KullaniciDLL.Operator degisken)
        {
            bool result = false;
            using (var connection = MeshEkran.Veritabani.Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM Operator WHERE SicilNo='" + degisken.SicilNO + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;
        }
        #endregion

        #region OperatorEkleme
        public bool OperatorEkleme(KullaniciDLL.Operator degisken)
        {
            bool result = false;
            if (!OperatorVarmiKontrolu(degisken))
            {
                using (var baglanti = MeshEkran.Veritabani.Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into Operator(Ad,Soyad,DogumTarihi,SicilNo,IseBaslangicTarihi,DurumAP) values (@ad,@soyad,@dogumtarihi,@sicilno,@isebaslangictarihi,@durumap)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@ad", degisken.Isim);
                        komut.Parameters.AddWithValue("@soyad", degisken.Soyisim);
                        komut.Parameters.AddWithValue("@dogumtarihi", degisken.DogumTarihi);
                        komut.Parameters.AddWithValue("@sicilno", degisken.SicilNO);
                        komut.Parameters.AddWithValue("@isebaslangictarihi", degisken.IsBaslangicTarihi);
                        komut.Parameters.AddWithValue("@durumap", degisken.DurumAP);

                        baglanti.Open();
                        if (komut.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }
                        baglanti.Close();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu. \n\n\n\n" + hata.Message);
                    }

                    return result;
                }
            }
            return result;
        }
        #endregion

        #region OperatorSilme
        public bool OperatorSilme(KullaniciDLL.Operator degisken)
        {
            bool result = false;
            using (var baglanti = MeshEkran.Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from Operator where OperatorID=@opid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@opid", degisken.OperatorID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["OperatorID"].ToString();
                    string adsoyad = dr["Ad"].ToString() + " " + dr["Soyad"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + adsoyad + " kişisini veritabanından silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        string silmeSorgusu = "DELETE from Operator where OperatorID=@opid";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@opid", degisken.OperatorID);
                        if (silKomutu.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }


                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir kişi bulunamadı.");
                }

                return result;
            }
        }
        #endregion

        #region OperatorGuncelleme
        public bool OperatorGuncelleme(KullaniciDLL.Operator degisken)
        {
            bool result = false;
            using (var baglanti = MeshEkran.Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from Operator where OperatorID=@opid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@opid", degisken.OperatorID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["OperatorID"].ToString();
                    string adsoyad = dr["Ad"].ToString() + " " + dr["Soyad"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + adsoyad + " kişisini güncellemek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {

                        string kayit = "UPDATE Operator SET Ad=@ad,Soyad=@soyad,DogumTarihi=@dogumtarihi,SicilNo=@sicilno,IseBaslangicTarihi=@isbaslangictar,IstenCikisTarihi=@iscikistar,DurumAP=@durumap where OperatorID=@OPID";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@ad", degisken.Isim);
                        komut.Parameters.AddWithValue("@soyad", degisken.Soyisim);
                        komut.Parameters.AddWithValue("@dogumtarihi", degisken.DogumTarihi);
                        komut.Parameters.AddWithValue("@sicilno", degisken.SicilNO);
                        komut.Parameters.AddWithValue("@isbaslangictar", degisken.IsBaslangicTarihi);
                        komut.Parameters.AddWithValue("@iscikistar", degisken.IsCikisTarihi);
                        komut.Parameters.AddWithValue("@durumap", degisken.DurumAP);
                        komut.Parameters.AddWithValue("@OPID", degisken.OperatorID);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Operatör bilgileri başarıyla güncellendi.");

                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir operatör bulunamadı.");
                }

                return result;
            }
        }
        #endregion

        #region UrunVarmiKontrolu
        private bool UrunVarsa(MasDLL.Rapor degisken)
        {


            bool result = false;
            using (var connection = MeshEkran.Veritabani.Database.GetConnection())
            {
                var command = new SqlCommand("SELECT * FROM UrunTablosu WHERE UrunKodu='" + degisken.UrunKodu + "'")
                {
                    Connection = connection
                };
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = true;
                    }
                }
                connection.Close();
            }
            return result;

        }
        #endregion

        #region UrunEkleme
        public bool UrunEkleme(MasDLL.Rapor degisken)
        {

            bool result = false;
            if (!UrunVarsa(degisken))
            {
                using (var baglanti = Veritabani.Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into UrunTablosu(UrunAdi,UrunAciklama,UrunKodu,En,Boy) values (@urunad,@urunaciklama,@urunkodu,@en,@boy)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@urunad", degisken.UrunAdi);
                        komut.Parameters.AddWithValue("@urunaciklama", degisken.UrunAciklama);
                        komut.Parameters.AddWithValue("@urunkodu", degisken.UrunKodu);
                        komut.Parameters.AddWithValue("@en", degisken.UrunEn);
                        komut.Parameters.AddWithValue("@boy", degisken.UrunBoy);

                        baglanti.Open();
                        if (komut.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }
                        baglanti.Close();

                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("İşlem Sırasında Hata Oluştu. \n\n\n\n" + hata.Message);
                    }

                    return result;
                }
            }
            return result;
        }
        #endregion

        #region UrunSilme
        public bool UrunSilme(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = MeshEkran.Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from UrunTablosu where UrunKodu=@urunkodu";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@urunkodu", degisken.UrunKodu);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["UrunID"].ToString();
                    string urunadkod = dr["UrunAdi"].ToString() + " " + dr["UrunKodu"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + urunadkod + " ürününü veritabanından silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        string silmeSorgusu = "DELETE from UrunTablosu where UrunKodu=@urunkodu";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@urunkodu", degisken.UrunKodu);
                        if (silKomutu.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }


                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir ürün bulunamadı. Silme işlemi tamamlanamadı.");
                }

                return result;
            }
        }
        #endregion

        #region UrunGuncelleme
        public bool UrunGuncelleme(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from UrunTablosu where UrunKodu=@urunkod";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@urunkod", degisken.UrunKodu);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["UrunID"].ToString();
                    string urunadkod = dr["UrunAdi"].ToString() + " " + dr["UrunKodu"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + urunadkod + " ürününü güncellemek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {

                        string kayit = "UPDATE UrunTablosu SET UrunAdi=@urunad,UrunAciklama=@urunaciklama,UrunKodu=@urunkodu,En=@urunen,Boy=@urunboy where UrunKodu=@urunkod";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@urunad", degisken.UrunAdi);
                        komut.Parameters.AddWithValue("@urunaciklama", degisken.UrunAciklama);
                        komut.Parameters.AddWithValue("@urunkodu", degisken.UrunKodu);
                        komut.Parameters.AddWithValue("@urunen", degisken.UrunEn);
                        komut.Parameters.AddWithValue("@urunboy", degisken.UrunBoy);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Ürün bilgileri başarıyla güncellendi.");

                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir ürün bulunamadı.");
                }

                return result;
            }
        }
        #endregion
    }
}
