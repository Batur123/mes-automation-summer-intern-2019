using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeshEkran
{
    public partial class Giris_Operator : Form
    {
        public Giris_Operator()
        {
            InitializeComponent();
        }

        private void KapatButon_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GeriDonButon_Click(object sender, EventArgs e)
        {
            Giris_SecimEkran ac = new Giris_SecimEkran();
            ac.Show();
            this.Hide();
        }

        private void GirisYapButon_Click(object sender, EventArgs e)
        {
            if (KullaniciAdBox.Text == "" && SifreBox.Text == "")
            {
                MessageBox.Show("Lütfen boş kısım bırakmayınız.");
            }
            else
            {

                //Diğer İşlemler


            }
        }
    }
}
