using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class SoruKayit
    {
        public SoruKayit()
        {

        }
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public void soruEkle(int isyeriID, int kullaniciID, string baslik, string soru, int durum)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO soruCevapKayitlari (isyeriID, soranID, baslik, soru, durum) VALUES (@isyeriID, @kullaniciID, @baslik, @soru, @durum)";
            command.Parameters.AddWithValue("isyeriID", isyeriID);
            command.Parameters.AddWithValue("kullaniciID", kullaniciID);
            command.Parameters.AddWithValue("baslik", baslik);
            command.Parameters.AddWithValue("soru", soru);
            command.Parameters.AddWithValue("durum", durum);

            veritabaniBaglantisiKur(command);
            command.ExecuteNonQuery();

        }
    }
}
