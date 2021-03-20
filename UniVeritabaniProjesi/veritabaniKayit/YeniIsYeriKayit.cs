using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class YeniIsYeriKayit
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        private string isyeriIsim;
        private string isyeriAdres;
        private string isyeriTelefon;
        private string isyeriTur;
        private int isyeriYetkiliID;

        public YeniIsYeriKayit(string isyeriIsim, string isyeriAdres, string isyeriTelefon, string isyeriTur, int isyeriYetkiliID)
        {
            this.isyeriIsim = isyeriIsim;
            this.isyeriAdres = isyeriAdres;
            this.isyeriTelefon = isyeriTelefon;
            this.isyeriTur = isyeriTur;
            this.isyeriYetkiliID = isyeriYetkiliID;
        }

        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public void isyeriKaydet()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "INSERT INTO isYeriKayitlari (isyeriIsim, isyeriAdres, isyeriTelefon, isyeriTur, isyeriYetkiliID) VALUES (@isyeriisim, @isyeriadres, @isyeritelefon, @isyeritur, @isyeriyetkiliID)";
            command.Parameters.AddWithValue("isyeriisim", isyeriIsim);
            command.Parameters.AddWithValue("isyeriadres", isyeriAdres);
            command.Parameters.AddWithValue("isyeritelefon", isyeriTelefon);
            command.Parameters.AddWithValue("isyeritur", isyeriTur);
            command.Parameters.AddWithValue("isyeriyetkiliID", isyeriYetkiliID);
            veritabaniBaglantisiKur(command);
            command.ExecuteNonQuery();

        }
    }
}
