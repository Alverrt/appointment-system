using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniVeritabaniProjesi.aramaIslemleri;
using UniVeritabaniProjesi.veritabaniDelete;
using UniVeritabaniProjesi.veritabaniKayit;
using UniVeritabaniProjesi.veritabaniUpdate;

namespace UniVeritabaniProjesi
{
    public partial class adminAnaMenu : Form
    {
        private DataTable datatable = new DataTable();
        private int kullaniciID;
        private DataTable isyeriBilgileriGlobal = new DataTable();
        private int globalIsyeriID;
        public adminAnaMenu()
        {
            InitializeComponent();
        }

        private void adminAnaMenu_Load(object sender, EventArgs e)
        {
            adminTabControl.Appearance = TabAppearance.FlatButtons;
            adminTabControl.ItemSize = new Size(0, 1);
            adminTabControl.SizeMode = TabSizeMode.Fixed;
            isYeriDuzenlePaneli.Hide();
        }

        private void işYeriEkleKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminTabControl.SelectedTab = adminIsYeriIslemleriTabPage;
        }

        private void yeniAdminEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void işYeriRaporlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminTabControl.SelectedTab = adminRaporSistemTabPage;
        }

        private void destekTaleplerineGözAtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminTabControl.SelectedTab = adminDestekTabPage;
        }

        private void adminYeniIsYeriEkle_Click(object sender, EventArgs e)
        {
            kullaniciID = Convert.ToInt32(datatable.Rows[adminIsYeriYetkiliListele.SelectedIndex][0]);
            YeniIsYeriKayit yenikayit = new YeniIsYeriKayit(isyeriIsimEkleTxtBox.Text, isyeriAdresEkleTxtBox.Text, isyeriTelEkleTxtBox.Text, isyeriTurEkleTxtBox.Text, kullaniciID);
            yenikayit.isyeriKaydet();
            MessageBox.Show("İş yeri kaydedildi.");
        }

        private void isyeriYetkiliIsimListele_Click(object sender, EventArgs e)
        {
            adminIsYeriYetkiliListele.Items.Clear();

            KullaniciAramasi isimListele = new KullaniciAramasi();
            DataTable dt = new DataTable();

            // kullanici turleri 0=normal 1=isyeri yetkilisi 2= admin
            dt = isimListele.kullaniciTurlerindenListele(1);
            datatable = dt;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                // isim soyisimi listboxa ekliyorum indexlerine bazlı olarak daha sonra kayıt yaparken kullanıcı idlerini alacağım
                adminIsYeriYetkiliListele.Items.Add(dt.Rows[i][1].ToString() + " " + dt.Rows[i][2]);
            }
        }

        private void isYeriniDuzenle_Click(object sender, EventArgs e)
        {
            if (isYeriDuzenleKaldirListBox.SelectedIndex > 0)
            {
                globalIsyeriID = Convert.ToInt32(isyeriBilgileriGlobal.Rows[isYeriDuzenleKaldirListBox.SelectedIndex][0]);
                duzenleIsYeriIsimTxtBox.Text = isyeriBilgileriGlobal.Rows[isYeriDuzenleKaldirListBox.SelectedIndex][1].ToString();
                duzenleIsYeriAdresTxtBox.Text = isyeriBilgileriGlobal.Rows[isYeriDuzenleKaldirListBox.SelectedIndex][2].ToString();
                duzenleIsYeriTelefonTxtBox.Text = isyeriBilgileriGlobal.Rows[isYeriDuzenleKaldirListBox.SelectedIndex][3].ToString();
                duzenleIsYeriTurTxtBox.Text = isyeriBilgileriGlobal.Rows[isYeriDuzenleKaldirListBox.SelectedIndex][4].ToString();
                isYeriDuzenlePaneli.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir iş yeri seçiniz.");
            }
        }

        private void isYeriDuzenleKaldirListeleButonu_Click(object sender, EventArgs e)
        {
            IsYeriAramasi arama = new IsYeriAramasi();
            DataTable isyerleri = new DataTable();
            isyerleri = arama.isYerleriniGetir();
            isyeriBilgileriGlobal = isyerleri;


            isYeriDuzenleKaldirListBox.Items.Clear();

            for (int i = 0; i < isyerleri.Rows.Count; i++)
            {
                isYeriDuzenleKaldirListBox.Items.Add(isyerleri.Rows[i][1].ToString());
            }
        }

        private void guncelleGonderButonu_Click(object sender, EventArgs e)
        {
            IsyeriUpdate update = new IsyeriUpdate(globalIsyeriID, duzenleIsYeriIsimTxtBox.Text, duzenleIsYeriAdresTxtBox.Text, duzenleIsYeriTelefonTxtBox.Text, duzenleIsYeriTurTxtBox.Text);
            update.isyeriGuncelle();
            MessageBox.Show("Güncellendi");
            isYeriDuzenlePaneli.Hide();
        }

        private void isYeriniKaldir_Click(object sender, EventArgs e)
        {
            IsyeriKaldir kaldir = new IsyeriKaldir(Convert.ToInt32(isyeriBilgileriGlobal.Rows[isYeriDuzenleKaldirListBox.SelectedIndex][0]));
            kaldir.isyeriKaldir();
            MessageBox.Show("İş Yeri Kaldirildi");

        }

        private void raporlamaTumKullanicilarButon_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            KullaniciAramasi arama = new KullaniciAramasi();
            data = arama.tumKullanicilariGetir();

            raporDataGrid.Rows.Clear();
            raporDataGrid.DataSource = data;
        }

        private void raporTumIsyerleriButon_Click(object sender, EventArgs e)
        {
            IsYeriAramasi arama = new IsYeriAramasi();
            DataTable data = new DataTable();

            data = arama.isYerleriniGetir();

            
            raporDataGrid.DataSource = data;
        }

        private void raporGirisLoglariButon_Click(object sender, EventArgs e)
        {
            LogAramasi arama = new LogAramasi();
            DataTable table = arama.loglariGetir();

            table.Columns["Id"].ColumnMapping = MappingType.Hidden;

            raporDataGrid.DataSource = table;

        }
    }
}
