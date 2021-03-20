using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class IsYeriYetkilisiKayit : KayitOlustur
    {
        private string tcNO;
        private string dogumTarihi;
        public IsYeriYetkilisiKayit(string ad, string soyad, string telNO, string adres, string email, string kullaniciAdi, string parola, string tcNO, string dogumTarihi) : base(ad, soyad, telNO, adres, email, kullaniciAdi, parola)
        {
            this.tcNO = tcNO;
            this.dogumTarihi = dogumTarihi;
        }
        public override void veritabaninaYaz()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO kullaniciKayitlari (isim, soyisim, tcno, dogumTarihi, eposta, adres, telno, username, password, kullaniciTuru) VALUES (@isim, @soyisim, @tcno, @dogumTarihi, @eposta, @adres, @telno, @kullaniciAdi, @sifre, @kullaniciTuru)");
            cmd.Parameters.AddWithValue("isim", ad);
            cmd.Parameters.AddWithValue("soyisim", soyad);
            cmd.Parameters.AddWithValue("tcno", tcNO);
            cmd.Parameters.AddWithValue("dogumTarihi", dogumTarihi);
            cmd.Parameters.AddWithValue("eposta", email);
            cmd.Parameters.AddWithValue("adres", adres);
            cmd.Parameters.AddWithValue("telno", telNo);
            cmd.Parameters.AddWithValue("kullaniciAdi", kullaniciAdi);
            cmd.Parameters.AddWithValue("sifre", parola);
            cmd.Parameters.AddWithValue("kullaniciTuru", 1);
            veritabaniKomutCalistir(cmd);
        }
    }
}
