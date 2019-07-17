using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //sql
using MeshEkran.Classlar;

namespace MeshEkran
{
    public partial class Giris_SecimEkran : Form
    {
        public Giris_SecimEkran()
        {
            InitializeComponent();
        }

        #region Değişkenler
        public static bool Kontrol;
        public static string DBAdiGlobal;
        public string ServerName = "BATUR" + "\\" + "BATUR";
        #endregion

        #region Giris_SecimEkran Load Eventi
        private void Giris_SecimEkran_Load(object sender, EventArgs e)
        {
           
            AdminButon.Enabled = false;
            OperatorButon.Enabled = false;

            string DBSecimAd = "FirmaDBList";


            SqlConnection baglanti = new SqlConnection("Data Source=" + ServerName + ";Initial Catalog=" + DBSecimAd + ";Integrated Security=TRUE");
            SqlCommand komut = new SqlCommand("SELECT dbID, dbName FROM DBAdlari", baglanti);
            SqlDataAdapter da;
            DataTable dt;
            DataRow row;
            baglanti.Open();
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);

            row = dt.NewRow();
            row["dbID"] = 0;
            row["dbName"] = "Lütfen veritabanını seçiniz.";
            dt.Rows.InsertAt(row, 0);


            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "dbID";
            comboBox1.DisplayMember = "dbName";
            baglanti.Close();


        }
        #endregion

        #region VeritabaniComboboxSeçimEventi
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            string DBSecimAd;
            DBSecimAd = comboBox1.Text;

            if(DBSecimAd == "" || comboBox1.SelectedIndex == 0)
            {
                pictureBox3.Image = Properties.Resources.RedIcon;
                AdminButon.Enabled = false;
                OperatorButon.Enabled = false;
                Kontrol = false;
            }
            else
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBSecimAd + ";Integrated Security=TRUE";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();

                    MessageBox.Show("Veritabanı bağlantısı kuruldu. Veritabanınız: " + DBSecimAd);
                    pictureBox3.Image = Properties.Resources.greenicon;

                    DBAdiGlobal = DBSecimAd;
                    AdminButon.Enabled = true;
                    OperatorButon.Enabled = true;
                    Kontrol = true;

                    cnn.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Veritabanı bağlantısı kurulamadı. Seçmeye çalıştığınız veritabanı: " + DBSecimAd);
                    MessageBox.Show(ex.Message);
                    pictureBox3.Image = Properties.Resources.RedIcon;

                    this.dBAdlariTableAdapter.Fill(this.firmaDBListDataSet.DBAdlari);

                    AdminButon.Enabled = false;
                    OperatorButon.Enabled = false;
                    Kontrol = false;
                    comboBox1.SelectedIndex = 0;

                }
            }
           
        }
        #endregion

        #region OperatorGirisEkrani Buton Eventi
        private void OperatorButon_Click(object sender, EventArgs e)
        {
 
            if(Kontrol == true)
            {
                MessageBox.Show("Operatör Ekranına yönlendiriliyorsunuz...");

            }
            else
            {
                MessageBox.Show("Veritabanı bağlantınız düzgün sağlanamadı. Lütfen tekrar deneyiniz.");
            }
        }
        #endregion

        #region AdminGirişEkranı Buton Eventi
        private void AdminButon_Click(object sender, EventArgs e)
        {
            if (Kontrol == true)
            {
                MessageBox.Show("Admin Ekranına yönlendiriliyorsunuz...");

                //Admin_AnaMenu ac = new Admin_AnaMenu();
                Giris_Admin ac = new Giris_Admin
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                ac.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Veritabanı bağlantınız düzgün sağlanamadı. Lütfen tekrar deneyiniz.");
            }
        }
        #endregion
    }
}
