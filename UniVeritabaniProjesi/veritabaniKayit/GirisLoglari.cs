using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVeritabaniProjesi.aramaIslemleri;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class GirisLoglari
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public GirisLoglari()
        {

        }
        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public void logKayit(int kullaniciID, DateTime time)
        {
            KullaniciAramasi arama = new KullaniciAramasi();
            ArrayList isimSoyisim = arama.kullaniciIDDenBilgileriGetir(kullaniciID);

            string isim = isimSoyisim[0].ToString();
            string soyisim = isimSoyisim[1].ToString();

            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO girisLoglari (kullaniciID, isim, soyisim, tarih) VALUES (@kullaniciID, @isim, @soyisim, @tarih)";
            command.Parameters.AddWithValue("kullaniciID", kullaniciID);
            command.Parameters.AddWithValue("isim", isim);
            command.Parameters.AddWithValue("soyisim", soyisim);
            command.Parameters.AddWithValue("tarih", time);

            veritabaniBaglantisiKur(command);
            command.ExecuteNonQuery();

        }
    }


}
