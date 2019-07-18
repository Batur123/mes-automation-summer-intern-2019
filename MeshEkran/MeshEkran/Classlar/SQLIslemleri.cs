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

        #region Değişkenler
        public static string PSid, PSadi, PSkodu, PSoperasyonid;
        #endregion

        //Makine İşlemleri
        #region MakineVarmiKontrolu
        private bool MakineVarsa(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec PRC_MakineKontrol @makinekod";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@makinekod", degisken.MakineKodu);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    result = true;
                    baglanti.Close();
                }
                return result;

            }

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
                string secmeSorgusu = "exec PRC_MakineUpdateKontrol @makineid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@makineid", degisken.MakineID);
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
                        string silmeSorgusu = "exec PRC_MakineDelete @makineid";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@makineid", degisken.MakineID);
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
        public bool MakineGuncelleme(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec PRC_MakineUpdateKontrol @makineid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@makineid", degisken.MakineID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["MakineID"].ToString();
                    string urunadkod = dr["MakineAdi"].ToString() + " " + dr["MakineKodu"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + urunadkod + " makinesini güncellemek istediğinize emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        
                        //string kayit = "UPDATE MakinelerTablosu SET MakineAdi=@makineadi,MakineKodu=@makinekodu,OperasyonID=@opid where MakineID=@makineid";
                        string kayit = "exec PRC_MakineUpdate @makineadi,@makinekodu,@opid,@makineid";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@opid", degisken.OperasyonID);
                        komut.Parameters.AddWithValue("@makineadi", degisken.MakineAdi);
                        komut.Parameters.AddWithValue("@makinekodu", degisken.MakineKodu);
                        komut.Parameters.AddWithValue("@makineid", degisken.MakineID);
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Makine bilgileri başarıyla güncellendi.");

                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir makine bulunamadı.");
                }

                return result;
            }
        }
        #endregion
        //Makine İşlemleri

        //Operator İşlemleri
        #region OperatorVarmiKontrolu
        public bool OperatorVarmiKontrolu(KullaniciDLL.Operator degisken)
        {
            bool result = false;
            using (var connection = Veritabani.Database.GetConnection())
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
                string secmeSorgusu = "SELECT * from Operator where SicilNo=@sicilno";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@sicilno", degisken.SicilNO);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["SicilNo"].ToString();
                    string adsoyad = dr["Ad"].ToString() + " " + dr["Soyad"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + adsoyad + " kişisini veritabanından silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        string silmeSorgusu = "DELETE from Operator where SicilNo=@sicilno";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@sicilno", degisken.SicilNO);
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
            using (var baglanti = Veritabani.Database.GetConnection())
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
        //Operator İşlemleri

        //Ürün İşlemleri
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

                        string kayit = "UPDATE UrunTablosu SET UrunAdi=@urunad,UrunAciklama=@urunaciklama,En=@urunen,Boy=@urunboy where UrunKodu=@urunkod";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@urunad", degisken.UrunAdi);
                        komut.Parameters.AddWithValue("@urunaciklama", degisken.UrunAciklama);
                        komut.Parameters.AddWithValue("@urunkod", degisken.UrunKodu);
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
        //Ürün İşlemleri

        //Operasyon İşlemleri
        #region OperasyonVarmiKontrolu
        private bool OperasyonVarsa(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec PRC_OperasyonSelect @opid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@opid", degisken.OperasyonID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    result = true;
                    baglanti.Close();
                }
                return result;

            }

        }
        #endregion

        #region OperasyonEkle
        public bool OperasyonEkleme(MasDLL.Rapor degisken)
        {

            bool result = false;
            if (!OperasyonVarsa(degisken))
            {
                using (var baglanti = Veritabani.Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into OperasyonlarTablosu(OperasyonAdi) values (@opad)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@opad", degisken.OperasyonAdi);


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

        #region OperasyonGuncelle
        public bool OperasyonGuncelleme(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from OperasyonlarTablosu where OperasyonID=@opid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@opid", degisken.OperasyonID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["OperasyonID"].ToString();
                    string urunadkod = dr["OperasyonAdi"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + urunadkod + " operasyonu güncellemek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {

                        string kayit = "UPDATE OperasyonlarTablosu SET OperasyonAdi=@opad where OperasyonID=@opid";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@opid", degisken.OperasyonID);
                        komut.Parameters.AddWithValue("@opad", degisken.OperasyonAdi);

                        komut.ExecuteNonQuery();

                        MessageBox.Show("Operasyon bilgileri başarıyla güncellendi.");

                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir operasyon bulunamadı.");
                }

                return result;
            }
        }
        #endregion

        #region OperasyonSil
        public bool OperasyonSilme(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "PRC_OperasyonSelect @opid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@opid", degisken.OperasyonID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["OperasyonID"].ToString();
                    string opad = dr["OperasyonAdi"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + opad + " operasyonunu veritabanından silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        string silmeSorgusu = "DELETE from OperasyonlarTablosu where OperasyonID=@opid";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@opid", degisken.OperasyonID);
                        if (silKomutu.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }


                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir operasyon bulunamadı. Silme işlemi tamamlanamadı.");
                }

                return result;
            }
        }
        #endregion
        //Operasyon İşlemleri

        //Duruş İşlemleri
        #region DuruşVarmıKontrolü
        private bool DurusVarsa(MasDLL.Rapor degisken)
        {

            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec PRC_DurusInsertSelect @durusid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@durusid", degisken.DurusID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    result = true;
                    baglanti.Close();
                }
                return result;

            }

        }
        #endregion

        #region DuruşEkle
        public bool DurusEkle(MasDLL.Rapor degisken)
        {
            bool result = false;
            if (!DurusVarsa(degisken))
            {
                using (var baglanti = Veritabani.Database.GetConnection())
                {
                    try
                    {


                        string kayit = "insert into DurusTablosu(DurusAd,DurusAciklama) values (@durusad,@durusaciklama)";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@durusad", degisken.DurusAd);
                        komut.Parameters.AddWithValue("@durusaciklama", degisken.DurusAciklama);


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

        #region DuruşGüncelle
        public bool DurusGuncelle(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "SELECT * from DurusTablosu where DurusID=@durusid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@durusid", degisken.DurusID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["DurusID"].ToString();
                    string urunadkod = dr["DurusAd"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + urunadkod + " duruşunu güncellemek istediğinize emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {

                        string kayit = "UPDATE DurusTablosu SET DurusAd=@durusad,DurusAciklama=@durusaciklama where DurusID=@durusid";
                        SqlCommand komut = new SqlCommand(kayit, baglanti);
                        komut.Parameters.AddWithValue("@durusad", degisken.DurusAd);
                        komut.Parameters.AddWithValue("@durusaciklama", degisken.DurusAciklama);
                        komut.Parameters.AddWithValue("@durusid", degisken.DurusID);

                        komut.ExecuteNonQuery();

                        MessageBox.Show("Duruş bilgileri başarıyla güncellendi.");

                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir duruş bulunamadı.");
                }

                return result;
            }
        }
        #endregion

        #region DuruşSil
        public bool DurusSil(MasDLL.Rapor degisken)
        {
            bool result = false;
            using (var baglanti = Veritabani.Database.GetConnection())
            {
                baglanti.Open();
                string secmeSorgusu = "exec PRC_DurusSelect @durusid";
                SqlCommand secmeKomutu = new SqlCommand(secmeSorgusu, baglanti);
                secmeKomutu.Parameters.AddWithValue("@durusid", degisken.DurusID);
                SqlDataAdapter da = new SqlDataAdapter(secmeKomutu);
                SqlDataReader dr = secmeKomutu.ExecuteReader();
                if (dr.Read())
                {
                    string id = dr["DurusID"].ToString();
                    string opad = dr["DurusAd"].ToString();

                    dr.Close();
                    DialogResult durum = MessageBox.Show(id + " numaralı " + opad + " duruşunu veritabanından silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == durum)
                    {
                        string silmeSorgusu = "DELETE from DurusTablosu where DurusID=@durusid";
                        SqlCommand silKomutu = new SqlCommand(silmeSorgusu, baglanti);
                        silKomutu.Parameters.AddWithValue("@durusid", degisken.DurusID);
                        if (silKomutu.ExecuteNonQuery() != -1)
                        {
                            result = true;
                        }


                    }

                    baglanti.Close();


                }
                else
                {
                    MessageBox.Show("Böyle bir duruş bulunamadı. Silme işlemi tamamlanamadı.");
                }

                return result;
            }
        }
        #endregion
        //Duruş İşlemler,
    }
}
