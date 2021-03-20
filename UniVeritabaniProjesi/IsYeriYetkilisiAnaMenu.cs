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
using UniVeritabaniProjesi.veritabaniKayit;
using UniVeritabaniProjesi.veritabaniUpdate;

namespace UniVeritabaniProjesi
{
    public partial class IsYeriYetkilisiAnaMenu : Form
    {
        private bool insertedOnce = false;
        private int kullaniciID;

        DataTable randevular;
        DataTable sorular;
        public IsYeriYetkilisiAnaMenu(int kullaniciID)
        {
            InitializeComponent();
            this.kullaniciID = kullaniciID;
        }

        private int isyeriIDGetir()
        {
            IsYeriAramasi arama = new IsYeriAramasi();
            return arama.kullanicidanIsyeriIDGetir(kullaniciID);
        }

        private void sorularıGözdenGeçirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isYeriTabControl.SelectedTab = sorulariGozdenGecirTabPage;
        }

        private void randevuTalepleriniGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isYeriTabControl.SelectedTab = randevularaGozatTabPage;
        }

        private void randevuSaatleriniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isYeriTabControl.SelectedTab = isYeriRandevuSaatleriDuzenle;
        }

        private void destekTalebiAcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isYeriTabControl.SelectedTab = isYeriDestekTab;
        }

        private void IsYeriYetkilisiAnaMenu_Load(object sender, EventArgs e)
        {
            isYeriTabControl.Appearance = TabAppearance.FlatButtons;
            isYeriTabControl.ItemSize = new Size(0, 1);
            isYeriTabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void randevuListeleButon_Click(object sender, EventArgs e)
        {
            RandevuArama arama = new RandevuArama();
            DataTable dataTable = new DataTable();

            dataTable = arama.randevulariGetir(isyeriIDGetir());
            dataTable.Columns["randevuID"].ColumnMapping = MappingType.Hidden;
            randevular = dataTable;
            randevularBolumuDataGrid.DataSource = dataTable;

            MessageBox.Show("Randevular listelendi");
        }

        private void musaitZamanlariGuncelleButton_Click(object sender, EventArgs e)
        {
            ArrayList dize = new ArrayList();

            foreach (Control item in pazGrup.Controls)
            {
                if ((item is CheckBox) && ((CheckBox) item).Checked)
                {
                    dize.Add(1);
                }
                else
                {
                    dize.Add(0);
                }
            }

            foreach (Control item in salGrup.Controls)
            {
                if ((item is CheckBox) && ((CheckBox)item).Checked)
                {
                    dize.Add(1);
                }
                else
                {
                    dize.Add(0);
                }
            }

            foreach (Control item in carGrup.Controls)
            {
                if ((item is CheckBox) && ((CheckBox)item).Checked)
                {
                    dize.Add(1);
                }
                else
                {
                    dize.Add(0);
                }
            }

            foreach (Control item in perGrup.Controls)
            {
                if ((item is CheckBox) && ((CheckBox)item).Checked)
                {
                    dize.Add(1);
                }
                else
                {
                    dize.Add(0);
                }
            }

            foreach (Control item in cuGrup.Controls)
            {
                if ((item is CheckBox) && ((CheckBox)item).Checked)
                {
                    dize.Add(1);
                }
                else
                {
                    dize.Add(0);
                }
            }

            if (insertedOnce == false)
            {
                MusaitRandevuZamani musaitRandevu = new MusaitRandevuZamani();
                musaitRandevu.musaitRandevuKayit(isyeriIDGetir(), dize);
            }
            else
            {
                MusaitRandevuGuncelle guncelle = new MusaitRandevuGuncelle();
                guncelle.musaitRandevuZamaniGuncelle(isyeriIDGetir(), dize);
            }

            dize.Clear();
            insertedOnce = true;


        }

        private void randevuKabulEtButon_Click(object sender, EventArgs e)
        {
            RandevuDurumDegistir durum = new RandevuDurumDegistir();
            int index = randevularBolumuDataGrid.CurrentCell.RowIndex;
            durum.randevuDurumGuncelle(Convert.ToInt32(randevular.Rows[index]["randevuID"]), 1);
            MessageBox.Show("İşleminiz gerçekleşti. Yenilemek için tekrar Listele butonuna basın.");
        }

        private void randevuReddetButon_Click(object sender, EventArgs e)
        {
            RandevuDurumDegistir durum = new RandevuDurumDegistir();
            int index = randevularBolumuDataGrid.CurrentCell.RowIndex;
            durum.randevuDurumGuncelle(Convert.ToInt32(randevular.Rows[index]["randevuID"]), 2);
            MessageBox.Show("İşleminiz gerçekleşti. Yenilemek için tekrar Listele butonuna basın.");
        }

        private void sorulariListeleButton_Click(object sender, EventArgs e)
        {
            SoruArama soru = new SoruArama();
            DataTable table = soru.sorulariIsyerineGetir(isyeriIDGetir());
            sorular = table;

            table.Columns["soru"].ColumnMapping = MappingType.Hidden;
            table.Columns["cevap"].ColumnMapping = MappingType.Hidden;
            table.Columns["Id"].ColumnMapping = MappingType.Hidden;

            sorulariListeleDataGrid.DataSource = table;
        }

        private void sorulariListeleDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = sorulariListeleDataGrid.CurrentCell.RowIndex;
            sorulariGorBaslikTxtBox.Text = sorular.Rows[index]["baslik"].ToString();
            sorulariGorSoruTxtBox.Text = sorular.Rows[index]["soru"].ToString();
        }

        private void soruCevaplaButton_Click(object sender, EventArgs e)
        {
            int index = sorulariListeleDataGrid.CurrentCell.RowIndex;
            SoruCevapGuncelle soruguncelle = new SoruCevapGuncelle();
            soruguncelle.cevapGuncelle(Convert.ToInt32(sorular.Rows[index]["Id"]), sorulariGorCevapTxtBox.Text);
            MessageBox.Show("Cevap gönderildi.");
        }
    }
}
// Convert.ToInt32(randevular.Rows[randevularBolumuDataGrid.CurrentCell.RowIndex][0])