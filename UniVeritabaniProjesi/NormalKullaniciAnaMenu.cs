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

namespace UniVeritabaniProjesi
{
    public partial class NormalKullaniciAnaMenu : Form
    {
        private int kullaniciID;
        private int isyeriID;
        private string aramaStr;

        private string isYeriSecimi;
        private int randevuGun;
        private int randevuSaat;
        private DataTable isyerleri;
        private DataTable randevular;
        private DataTable soru_isyerleri;
        private DataTable sorular;
        public NormalKullaniciAnaMenu(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private void randevuAlStripMenuItem_Click(object sender, EventArgs e)
        {
            formTab.SelectedTab = randevuAlTab;
        }

        private void soruSorStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aramaYapStripMenu_Click(object sender, EventArgs e)
        {

        }

        private void araIsYeriRandevuButonu_Click(object sender, EventArgs e)
        {
            aramaStr = isYeriAramaBolumuRandevuAl.Text;
            DataTable aramaSonuclari = new DataTable();
            IsYeriAramasi yeniArama = new IsYeriAramasi();
            aramaSonuclari = yeniArama.aramaGerceklestir(aramaStr);
            if (aramaSonuclari != null)
            {
                isYeriAramaSonucRandevuAl.Items.Clear();
                foreach (DataRow row in aramaSonuclari.Rows)
                {
                    isYeriAramaSonucRandevuAl.Items.Add(row[1].ToString());
                }
                isyerleri = aramaSonuclari;
            }
            else
            {
                MessageBox.Show("Hiçbir arama sonuç ile eşleşmedi lütfen tekrar deneyin.");
            }
        }

        private void NormalKullaniciAnaMenu_Load(object sender, EventArgs e)
        {
            formTab.Appearance = TabAppearance.FlatButtons;
            formTab.ItemSize = new Size(0, 1);
            formTab.SizeMode = TabSizeMode.Fixed;

            string[] gunler = { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma" };

            randevuGunSecim.Items.AddRange(gunler);
        }

        private int isYeriIDGetir(string isyeriismi)
        {
            IsYeriAramasi idgetir = new IsYeriAramasi();
            return idgetir.isimdenIsYeriIDBul(isyeriismi);
        }

        private void randevuAlGecisButonu_Click(object sender, EventArgs e)
        {
            if (isYeriAramaSonucRandevuAl.Text != null && randevuGunSecim.SelectedItem != null && randevuSaatSecim.SelectedItem != null)
            {
                isYeriSecimi = (string)isYeriAramaSonucRandevuAl.SelectedItem;
                randevuGun = randevuGunSecim.SelectedIndex;
                randevuSaat = randevuSaatSecim.SelectedIndex;
                isyeriID = isYeriIDGetir(isYeriSecimi);
                RandevuKayit randevuKayit = new RandevuKayit(this.kullaniciID, isyeriID, randevuGun, randevuSaat);
                randevuKayit.randevuKaydet();
                MessageBox.Show("Randevunuz başarıyla alındı!");
            }
            else
            {
                MessageBox.Show("Lütfen gerekli yerleri seçtiğinizden emin olun.");
            }
            
        }

        private void isYeriAramaSonucRandevuAl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void randevuGunSecim_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] gunPeriyodlari = { "08:00 - 09:00", "09:00 - 10:00", "10:00 - 11:00", "11:00 - 12:00", "12:00 - 13:00", "13:00 - 14:00", "14:00 - 15:00", "15:00 - 16:00" };
            int gunKodu, isyeriID = 0;
            switch (randevuGunSecim.SelectedItem.ToString())
            {
                case "Pazartesi":
                    gunKodu = 0;
                    break;
                case "Salı":
                    gunKodu = 1;
                    break;
                case "Çarşamba":
                    gunKodu = 2;
                    break;
                case "Perşembe":
                    gunKodu = 3;
                    break;
                case "Cuma":
                    gunKodu = 4;
                    break;
                default:
                    gunKodu = 0;
                    break;
            }
            MusaitRandevuAra ara = new MusaitRandevuAra();
            foreach (DataRow item in isyerleri.Rows)
            {
                if (isYeriAramaSonucRandevuAl.SelectedIndex == Convert.ToInt32(item[0]))
                {
                    isyeriID = Convert.ToInt32(item[0]);
                }
            }

            ArrayList zamanlar = ara.musaitRandevulariGetir(isyeriID, gunKodu);

            for (int i = 0; i < zamanlar.Count; i++)
            {
                if (Convert.ToInt32(zamanlar[i]) == 1)
                {
                    randevuSaatSecim.Items.Add(gunPeriyodlari[i]);
                }
            }
        }

        private void randevularımıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTab.SelectedTab = normalRandevularimTabPage;
        }

        private void normalRandevuListeleButon_Click(object sender, EventArgs e)
        {
            RandevuArama ara = new RandevuArama();
            DataTable table = ara.kullaniciRandevulariniGetir(kullaniciID);
            randevular = table;
            table.Columns["randevuID"].ColumnMapping = MappingType.Hidden;
            normalRandevularimDataGrid.DataSource = table;
        }

        private void normalRandevuIptalButon_Click(object sender, EventArgs e)
        {
            int index = normalRandevularimDataGrid.CurrentCell.RowIndex;

            RandevuKaldir kaldir = new RandevuKaldir();
            kaldir.randevuKaldir(Convert.ToInt32(randevular.Rows[index]["randevuID"]));
            MessageBox.Show("Randevu kaldırıldı. Yenilemek için tekrar listeleyin.");
        }

        private void normalSoruEklemeIsyerleriListeleButton_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            IsYeriAramasi arama = new IsYeriAramasi();
            table = arama.isYerleriniGetir();
            soru_isyerleri = table;

            table.Columns["isyeriID"].ColumnMapping = MappingType.Hidden;
            table.Columns["isyeriAdres"].ColumnMapping = MappingType.Hidden;
            table.Columns["isyeriTelefon"].ColumnMapping = MappingType.Hidden;
            table.Columns["isyeriYetkiliID"].ColumnMapping = MappingType.Hidden;

            normalIsyerleriListeleDataGrid.DataSource = table;
        }

        private void yeniSoruSorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTab.SelectedTab = normalSoruEkleTabPage;
        }

        private void normalSoruGonderButton_Click(object sender, EventArgs e)
        {
            int index = normalIsyerleriListeleDataGrid.CurrentCell.RowIndex;
            string baslik = soruEkleBaslikTxtBox.Text;
            string soru = soruEkleSoruTxtBox.Text;
            SoruKayit sor = new SoruKayit();
            sor.soruEkle(Convert.ToInt32(soru_isyerleri.Rows[index]["isyeriID"]), kullaniciID, baslik, soru, 0);
            soruEkleBaslikTxtBox.Text = "";
            soruEkleSoruTxtBox.Text = "";
            MessageBox.Show("Sorunuz başarıyla gönderildi.");
        }

        private void normalSorulariListeleButton_Click(object sender, EventArgs e)
        {
            SoruArama soru = new SoruArama();
            DataTable table = soru.sorulariGetir(kullaniciID);
            sorular = table;
            table.Columns["Id"].ColumnMapping = MappingType.Hidden;
            table.Columns["isyeriID"].ColumnMapping = MappingType.Hidden;
            table.Columns["soranID"].ColumnMapping = MappingType.Hidden;
            table.Columns["soru"].ColumnMapping = MappingType.Hidden;
            table.Columns["cevapID"].ColumnMapping = MappingType.Hidden;
            table.Columns["cevap"].ColumnMapping = MappingType.Hidden;

            normalSorulariListeleDataGrid.DataSource = table;
        }

        private void normalSorulariListeleDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = normalSorulariListeleDataGrid.CurrentCell.RowIndex;
            sorulariGorBaslikTxtBox.Text = sorular.Rows[index]["baslik"].ToString();
            sorulariGorSoruTxtBox.Text = sorular.Rows[index]["soru"].ToString();
            if (sorular.Rows[index]["cevap"].ToString() != "")
            {
                sorulariGorCevapTxtBox.Text = sorular.Rows[index]["cevap"].ToString();
            }
            else
            {
                sorulariGorCevapTxtBox.Text = "Henüz cevap verilmedi.";
            }
            
        }

        private void sorularımıKontrolEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formTab.SelectedTab = normalSorulariListeleTabPage;
        }
    }
}
