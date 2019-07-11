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

namespace MeshEkran
{
     
    public partial class Giris_SecimEkran : Form
    {
        public Giris_SecimEkran()
        {
            InitializeComponent();
        }

        public string ServerName = "BATUR"+"\\"+"BATUR";

        private void Giris_SecimEkran_Load(object sender, EventArgs e)
        {
           
            AdminButon.Enabled = false;
            OperatorButon.Enabled = false;
            this.dBAdlariTableAdapter.Fill(this.firmaDBListDataSet.DBAdlari);

        }

        public static bool Kontrol;
        public static string DBAdiGlobal;
 
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DBSecimAd = null;
            DBSecimAd = comboBox1.Text;

            if(DBSecimAd == "")
            {
                pictureBox3.Image = MeshEkran.Properties.Resources.RedIcon;
            }
            else
            {
                string connetionString = null;
                SqlConnection cnn;
                connetionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBSecimAd + ";Integrated Security=TRUE";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();

                    MessageBox.Show("Veritabanı bağlantısı kuruldu. Veritabanınız: " + DBSecimAd);
                    pictureBox3.Image = MeshEkran.Properties.Resources.greenicon;

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
                    pictureBox3.Image = MeshEkran.Properties.Resources.RedIcon;

                    this.dBAdlariTableAdapter.Fill(this.firmaDBListDataSet.DBAdlari);

                    AdminButon.Enabled = false;
                    OperatorButon.Enabled = false;
                    Kontrol = false;

                }
            }
           
        }

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

        private void AdminButon_Click(object sender, EventArgs e)
        {
            if (Kontrol == true)
            {
                MessageBox.Show("Admin Ekranına yönlendiriliyorsunuz...");

                Giris_Admin ac = new Giris_Admin();
                ac.StartPosition = FormStartPosition.CenterScreen;
                ac.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Veritabanı bağlantınız düzgün sağlanamadı. Lütfen tekrar deneyiniz.");
            }
        }
    }
}
