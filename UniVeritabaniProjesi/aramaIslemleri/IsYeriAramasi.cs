using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.aramaIslemleri
{
    class IsYeriAramasi
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public IsYeriAramasi()
        {

        }
        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public DataTable aramaGerceklestir(string aramaSTR)
        {
            SqlCommand aramacmd = new SqlCommand();
            aramacmd.CommandText = "SELECT * FROM isYeriKayitlari WHERE isyeriIsim LIKE @isyeriIsimStr";
            aramacmd.Parameters.AddWithValue("isyeriIsimStr", "%" + aramaSTR + "%");

            veritabaniBaglantisiKur(aramacmd);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(aramacmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return table;


           /* SqlDataReader dr = aramacmd.ExecuteReader();

            if (dr.Read())
            {
                ArrayList sonuclar = new ArrayList();
                while (dr.Read())
                {
                    sonuclar.Add(dr["isyeriIsim"]);
                    sonuclar.Add(dr["isyeriID"]);
                }
                return sonuclar;
            }
            else
            {
                // null döndür
                return default(ArrayList);
            }*/
        }

        public int isimdenIsYeriIDBul(string isyeriisim)
        {
            SqlCommand idbul = new SqlCommand();
            idbul.CommandText = "SELECT isyeriID FROM isYeriKayitlari WHERE isyeriIsim= @isyeriisim";
            idbul.Parameters.AddWithValue("isyeriisim", isyeriisim);

            veritabaniBaglantisiKur(idbul);

            SqlDataReader dr = idbul.ExecuteReader();
            if (dr.Read())
            {
                return Convert.ToInt32(dr["isyeriID"]);
            }
            else
            {
                return -1;
            }

        }

        public DataTable isYerleriniGetir()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM isyeriKayitlari";

            veritabaniBaglantisiKur(cmd);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable datatable = new DataTable();
            adapter.Fill(datatable);

            return datatable;
        }

        public int kullanicidanIsyeriIDGetir(int kullaniciID)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM isyeriKayitlari WHERE isyeriYetkiliID= @kullaniciID";
            sqlCommand.Parameters.AddWithValue("kullaniciID", kullaniciID);

            veritabaniBaglantisiKur(sqlCommand);

            SqlDataReader dr = sqlCommand.ExecuteReader();

            if (dr.Read())
            {
                return Convert.ToInt32(dr["isyeriID"]);
            }
            else
            {
                return default;
            }
        }


    }
}
