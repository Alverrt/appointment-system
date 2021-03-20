using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniVeritabaniProjesi.veritabaniKayit;

namespace UniVeritabaniProjesi
{
    public partial class kayitOl : Form
    {
        public kayitOl()
        {
            InitializeComponent();
        }

        private void normalUyelikGecisButonu_Click(object sender, EventArgs e)
        {
            kayitOlmaDugmeleriPanel.Visible = false;
            kayitNormalUyelikPanel.Visible = true;
        }

        private void isYeriYetkiliGecisButonu_Click(object sender, EventArgs e)
        {
            kayitOlmaDugmeleriPanel.Visible = false;
            kayitİsYeriYetkiliPanel.Visible = true;
        }

        private void kayitOlNormal_Click(object sender, EventArgs e)
        {
            var textBoxCollection = new[] { isimNormalUye, soyisimNormalUye, adresNormalUye, telnoNormalUye, emailNormalUye, kullaniciAdiNormalUye, sifreNormalUye };
            bool boslukKontrol = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text));
            if (boslukKontrol == false)
            {
                MessageBox.Show("Kaydınız tamamlandı.");
                // Polymorphism
                KayitOlustur normalKayit = new NormalKayit(isimNormalUye.Text, soyisimNormalUye.Text, telnoNormalUye.Text, adresNormalUye.Text, emailNormalUye.Text, kullaniciAdiNormalUye.Text, sifreNormalUye.Text);
                normalKayit.veritabaninaYaz();

                loginForm form = new loginForm();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurunuz!");
            }

            
        }

        private void kayitOlİsYeriYetkilisi_Click(object sender, EventArgs e)
        {

            var textBoxCollection = new[] { isimİsYeri, soyisimİsYeri, tcnoİsYeri, adresİsYeri, telNoİsYeri, emailİsYeri, kullanıcıAdıİsyeri, sifreİsYeri };
            bool boslukKontrol = textBoxCollection.Any(t => String.IsNullOrWhiteSpace(t.Text));
            if (boslukKontrol == false)
            {
                MessageBox.Show("Kaydınız tamamlandı.");
                // Polymorphism
                KayitOlustur isYeriYetkilisiKayit = new IsYeriYetkilisiKayit(isimİsYeri.Text, soyisimİsYeri.Text, telNoİsYeri.Text, adresİsYeri.Text, emailİsYeri.Text, kullanıcıAdıİsyeri.Text, sifreİsYeri.Text, tcnoİsYeri.Text, dogumTarihiİsYeri.Text);
                isYeriYetkilisiKayit.veritabaninaYaz();

                loginForm form = new loginForm();
                this.Hide();
                form.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bütün boşlukları doldurunuz!");
            }
        }

        private void geriDonNormal_Click(object sender, EventArgs e)
        {
            kayitNormalUyelikPanel.Visible = false;
            kayitOlmaDugmeleriPanel.Visible = true;
        }

        private void geriDonİsYeri_Click(object sender, EventArgs e)
        {
            kayitİsYeriYetkiliPanel.Visible = false;
            kayitOlmaDugmeleriPanel.Visible = true;
        }

        private void giriseGeriDon_Click(object sender, EventArgs e)
        {
            var girisPanel = new loginForm();
            this.Hide();
            girisPanel.Show();
        }
    }
}
