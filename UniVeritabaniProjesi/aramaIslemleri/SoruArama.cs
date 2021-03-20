using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.aramaIslemleri
{
    class SoruArama
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public SoruArama()
        {

        }

        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();

            return conn;
        }

        public DataTable middleFixer(DataTable dataTable)
        {
            // Databasede sayılarla kodlu olan günler ve saat aralıklarını okunabillir hale getiriyorum
            foreach (DataRow row in dataTable.Rows)
            {
                switch (row["durum"].ToString())
                {
                    case "0":
                        row["durum"] = "Beklemede";
                        break;
                    case "1":
                        row["durum"] = "Cevaplandı";
                        break;
                    default:
                        break;
                }
            }
            return dataTable;
        }

        public DataTable sorulariGetir(int soranID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM soruCevapKayitlari WHERE soranID= @soranID";
            cmd.Parameters.AddWithValue("soranID", soranID);
            SqlConnection con = veritabaniBaglantisiKur(cmd);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            con.Close();

            return middleFixer(table);
        }

        public DataTable sorulariIsyerineGetir(int isyeriID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT kullaniciKayitlari.isim, kullaniciKayitlari.soyisim, soruCevapKayitlari.Id, soruCevapKayitlari.baslik, soruCevapKayitlari.soru, soruCevapKayitlari.cevap, soruCevapKayitlari.durum FROM kullaniciKayitlari INNER JOIN soruCevapKayitlari ON kullaniciKayitlari.kullaniciID = soruCevapKayitlari.soranID WHERE soruCevapKayitlari.isyeriID= @isyeriID";
            cmd.Parameters.AddWithValue("isyeriID", isyeriID);
            SqlConnection con = veritabaniBaglantisiKur(cmd);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            con.Close();

            return middleFixer(table);
        }
    }
}
