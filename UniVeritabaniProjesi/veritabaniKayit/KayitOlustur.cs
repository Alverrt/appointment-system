using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi
{
    public class KayitOlustur
    {
        protected string ad { get; set; }
        protected string soyad { get; set; }
        protected string telNo { get; set; }
        protected string adres { get; set; }
        protected string email { get; set; }
        protected string kullaniciAdi { get; set; }
        protected string parola { get; set; }

        protected string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public KayitOlustur(string ad, string soyad, string telNo, string adres, string email, string kullaniciAdi, string parola)
        {
            this.ad = ad;
            this.soyad = soyad;
            this.telNo = telNo;
            this.adres = adres;
            this.email = email;
            this.kullaniciAdi = kullaniciAdi;
            this.parola = parola;
        }

        private void veritabaninaBaglan(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            cmd.Connection = conn;
            conn.Open();
            
        }

        protected void veritabaniKomutCalistir(SqlCommand cmd)
        {
            veritabaninaBaglan(cmd);
            cmd.ExecuteNonQuery();
        }

        public virtual void veritabaninaYaz()
        {

        }
    }
}
