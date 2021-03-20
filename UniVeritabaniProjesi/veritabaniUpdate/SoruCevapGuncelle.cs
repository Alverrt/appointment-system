using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniUpdate
{
    class SoruCevapGuncelle
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        public SoruCevapGuncelle()
        {

        }
        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();

            return conn;
        }

        public void cevapGuncelle(int soruID, string cevap)
        {
            SqlCommand aramacmd = new SqlCommand();
            aramacmd.CommandText = "UPDATE soruCevapKayitlari SET cevap= @cevap WHERE Id= @soruID";
            aramacmd.Parameters.AddWithValue("cevap", cevap);
            aramacmd.Parameters.AddWithValue("soruID", soruID);
            SqlConnection con = veritabaniBaglantisiKur(aramacmd);
            aramacmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
