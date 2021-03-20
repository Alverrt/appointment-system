using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniUpdate
{
    class IsyeriUpdate
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        private int id;
        private string isim;
        private string adres;
        private string telno;
        private string tur;
        public IsyeriUpdate(int id, string isim, string adres, string telno, string tur)
        {
            this.id = id;
            this.isim = isim;
            this.adres = adres;
            this.telno = telno;
            this.tur = tur;
        }

        private void veritabaninaBaglan(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            cmd.Connection = conn;
            conn.Open();

        }

        public void isyeriGuncelle()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE isyeriKayitlari SET isyeriIsim= @isyeriisim, isyeriAdres= @isyeriadres, isyeriTelefon= @isyeritelefon, isyeriTur= @isyeritur WHERE isyeriID= @id";
            cmd.Parameters.AddWithValue("isyeriisim", isim);
            cmd.Parameters.AddWithValue("isyeriadres", adres);
            cmd.Parameters.AddWithValue("isyeritelefon", telno);
            cmd.Parameters.AddWithValue("isyeritur", tur);
            cmd.Parameters.AddWithValue("id", id);

            veritabaninaBaglan(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
