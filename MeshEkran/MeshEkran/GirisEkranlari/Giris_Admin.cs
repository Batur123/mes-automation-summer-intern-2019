﻿using MeshEkran.Classlar;
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
    public partial class Giris_Admin : Form
    {
        public Giris_Admin()
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

        public KullaniciDLL.Admin adminkullanicisi;
        public AdminGiris islem;


        private void GirisYapButon_Click(object sender, EventArgs e)
        {


            try
            {
                if (KullaniciAdBox.Text == "" && SifreBox.Text == "")
                {
                    MessageBox.Show("Lütfen boş kısım bırakmayınız.");
                }
                else
                {
                    islem = new MeshEkran.Classlar.AdminGiris();
                    adminkullanicisi = islem.AdminKontrol(KullaniciAdBox.Text, SifreBox.Text);
                    if (adminkullanicisi != null)
                    {
                        Admin_AnaMenu a = new Admin_AnaMenu();
                        MessageBox.Show("Başarıyla giriş yaptınız.");
                        a.StartPosition = FormStartPosition.CenterScreen;
                        a.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre yanlıştır. Lütfen tekrar deneyiniz.");
                    }
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata oluştu. \n");
                MessageBox.Show(hata.Message);
            }


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            Metotlar.Ok("Naber", "İstenirse Title yazılır");
            Metotlar.Ok("Naber 2");
            Metotlar.No("başarısız mesaj");
            Metotlar.No("başarısız mesaj", "ekstra title");


            DialogResult sonuc = Metotlar.QuestionMesaj("Emin misin Reis ?", "iyi kaRAR ver");

            if (sonuc == DialogResult.OK)
            {
                Metotlar.Ok("emin mişsin");
            }
            else
            if (sonuc == DialogResult.No)
            {
                Metotlar.No("Emin değilmişsin, no ya bastın.");
            }
            else
            if (sonuc == DialogResult.Cancel)
            {
                Metotlar.No("İşlem kullanıcı tarafından iptal edildi.","İŞLEM İPTAL");
            }

        }
    }
}
