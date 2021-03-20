using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class RandevuKayit
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        private int randevuAlanKullaniciID;
        private int isYeriID;
        private int randevuGUN;
        private int randevuSAAT;


        public RandevuKayit(int kullaniciID, int isyeriID, int randevuGunu, int randevuSaati)
        {
            this.randevuAlanKullaniciID = kullaniciID;
            this.isYeriID = isyeriID;
            this.randevuGUN = randevuGunu;
            this.randevuSAAT = randevuSaati;
        }

        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public void randevuKaydet()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO randevuKayitlari (kullaniciID, isyeriID, randevuGun, randevuSaat) VALUES (@kullaniciID, @isyeriID, @randevuGun, @randevuSaat)";
            command.Parameters.AddWithValue("kullaniciID", this.randevuAlanKullaniciID);
            command.Parameters.AddWithValue("isyeriID", this.isYeriID);
            command.Parameters.AddWithValue("randevuGun", this.randevuGUN);
            command.Parameters.AddWithValue("randevuSaat", this.randevuSAAT);

            veritabaniBaglantisiKur(command);
            command.ExecuteNonQuery();

        }

    }
}
