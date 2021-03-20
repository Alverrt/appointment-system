using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.girisIslemleri
{
    class GirisGerceklestir
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public GirisGerceklestir()
        {
            
        }

        private void veritabaninaBaglan(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            cmd.Connection = conn;
            conn.Open();

        }

        public int[] girisKontrol(string kullaniciAdi, string sifre)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM kullaniciKayitlari WHERE username= @kullaniciAdi AND password= @sifre";
            cmd.Parameters.AddWithValue("kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("sifre", sifre);

            veritabaninaBaglan(cmd);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
            int[] girisBilgileri = { Convert.ToInt32(dr["kullaniciID"]), Convert.ToInt32(dr["kullaniciTuru"]) };

               return girisBilgileri;
            }
            else
            {
                return default;
            }
        }
    }
}
