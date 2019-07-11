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
                var command = new SqlCommand("SELECT * FROM MakinelerTablosu WHERE MakineKodu='" + degisken.MakineKodu + "'");
                command.Connection = connection;
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
                    string PSid = dr["MakineID"].ToString();
                    string PSadi = dr["MakineAdi"].ToString();
                    string PSkodu = dr["MakineKodu"].ToString();
                    string PSoperasyonid = dr["OperasyonID"].ToString();
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

    }
}