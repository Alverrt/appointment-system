using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.aramaIslemleri
{
    class KullaniciAramasi
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        private int deneme { get; set; }

        public KullaniciAramasi()
        {

        }
        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public ArrayList aramaGerceklestir(string aramaSTR)
        {
            SqlCommand aramacmd = new SqlCommand();
            aramacmd.CommandText = "SELECT isyeriIsim FROM isYeriKayitlari WHERE isyeriIsim LIKE *@isyeriIsimStr*";
            aramacmd.Parameters.AddWithValue("isyeriIsim", aramaSTR);

            veritabaniBaglantisiKur(aramacmd);

            SqlDataReader dr = aramacmd.ExecuteReader();

            if (dr.Read())
            {
                ArrayList sonuclar = new ArrayList();
                while (dr.Read())
                {
                    sonuclar.Add(dr["isyeriIsim"]);
                }
                return sonuclar;
            }
            else
            {
                // null döndür
                return default(ArrayList);
            }
        }

        

        public DataTable kullaniciTurlerindenListele(int kullaniciTuru)
        {
            SqlCommand idbul = new SqlCommand();
            idbul.CommandText = "SELECT * FROM kullaniciKayitlari WHERE kullaniciTuru= @kullaniciTuru";
            idbul.Parameters.AddWithValue("kullaniciTuru", kullaniciTuru);

            veritabaniBaglantisiKur(idbul);

            if (true)
            {
                SqlDataAdapter adapter = new SqlDataAdapter(idbul);

                DataTable datatable = new DataTable();
                adapter.Fill(datatable);

                return datatable;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Bulunamadı.");
                return default;
            }
            

        }

        public DataTable tumKullanicilariGetir()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM kullaniciKayitlari";
            veritabaniBaglantisiKur(command);

            if (true)
            {
                
                DataTable dataTable = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                return dataTable;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Bulunamadı.");
                return default;
            }
        }

        public ArrayList kullaniciIDDenBilgileriGetir(int kullaniciID)
        {
            ArrayList dize = new ArrayList();
            
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT * FROM kullaniciKayitlari WHERE kullaniciID= @kullaniciID";
            command.Parameters.AddWithValue("kullaniciID", kullaniciID);
            veritabaniBaglantisiKur(command);

            SqlDataReader dr = command.ExecuteReader();
            dr.Read();

            dize.Add(dr["isim"]);
            dize.Add(dr["soyisim"]);

            return dize;
        }

    }

    /*
     *              kullanici.kullaniciID = Convert.ToInt32(dr["kullaniciID"]);
                    kullanici.isim = dr["isim"].ToString();
                    kullanici.soyisim = dr["soyisim"].ToString();
                    kullanici.tcno = dr["tcno"].ToString();
                    kullanici.dogumTarihi = dr["dogumTarihi"].ToString();
                    kullanici.eposta = dr["eposta"].ToString();
                    kullanici.adres = dr["adres"].ToString();
                    kullanici.telno = dr["telno"].ToString();
                    kullanici.kullaniciAdi = dr["username"].ToString();
                    kullanici.parola = dr["password"].ToString();
                    kullanici.kullaniciTuru = Convert.ToInt32(dr["kullaniciTuru"]);
    */
}
