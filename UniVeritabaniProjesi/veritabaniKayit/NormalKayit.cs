using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class NormalKayit : KayitOlustur
    {
        public NormalKayit(string ad, string soyad, string telNO, string adres, string email, string kullaniciAdi, string parola) : base(ad, soyad, telNO, adres, email, kullaniciAdi, parola)
        {

        }
        
        public override void veritabaninaYaz()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO kullaniciKayitlari (isim, soyisim, eposta, adres, telno, username, password, kullaniciTuru) VALUES (@isim, @soyisim, @eposta, @adres, @telno, @kullaniciAdi, @sifre, @kullaniciTuru)");
            cmd.Parameters.AddWithValue("isim", ad);
            cmd.Parameters.AddWithValue("soyisim", soyad);
            cmd.Parameters.AddWithValue("eposta", email);
            cmd.Parameters.AddWithValue("adres", adres);
            cmd.Parameters.AddWithValue("telno", telNo);
            cmd.Parameters.AddWithValue("kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("sifre", parola);
            cmd.Parameters.AddWithValue("kullaniciTuru", 0);
            veritabaniKomutCalistir(cmd);
        }
    }
}
