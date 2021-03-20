using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniVeritabaniProjesi.girisIslemleri;
using UniVeritabaniProjesi.veritabaniKayit;

namespace UniVeritabaniProjesi
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void kayitOlFormunaGit_Click(object sender, EventArgs e)
        {
            var kayitOl = new kayitOl();
            kayitOl.Show();
            this.Hide();

        }

        private void logAl(int kullaniciID)
        {

        }

        private void girisYap_Click(object sender, EventArgs e)
        {
            int[] kullaniciIDveTur;
            GirisGerceklestir giris = new GirisGerceklestir();
            kullaniciIDveTur = giris.girisKontrol(girisKullaniciAdi.Text, girisSifre.Text);
            if (kullaniciIDveTur == null)
            {
                MessageBox.Show("Öyle bir kayıt yok.");
                return;
            }
            if (kullaniciIDveTur[0] > 0)
            {
                DateTime dateTime = DateTime.Now;
                GirisLoglari girisLoglari = new GirisLoglari();
                girisLoglari.logKayit(kullaniciIDveTur[0], dateTime);
                this.Hide();
                switch (kullaniciIDveTur[1])
                {
                    case 0:
                        NormalKullaniciAnaMenu anaMenuYonlendirmesi = new NormalKullaniciAnaMenu(kullaniciIDveTur[0]);
                        anaMenuYonlendirmesi.Show();
                        break;
                    case 1:
                        IsYeriYetkilisiAnaMenu isYeriYetkilisiAna = new IsYeriYetkilisiAnaMenu(kullaniciIDveTur[0]);
                        isYeriYetkilisiAna.Show();
                        break;
                    case 2:
                        adminAnaMenu adminAnaMenu = new adminAnaMenu();
                        adminAnaMenu.Show();
                        break;
                    default:
                        MessageBox.Show("Giriş yapılırken bir hata oldu.");
                        break;
                }
                
            }
            else
            {
                MessageBox.Show("Kullanici adi veya sifre yanlis! Lutfen tekrar deneyin.");
            }
            
        }
    }
}
