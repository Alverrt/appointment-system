using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniUpdate
{
    class RandevuDurumDegistir
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        public RandevuDurumDegistir()
        {

        }
        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();

            return conn;
        }

        public void randevuDurumGuncelle(int randevuID, int randevuDurum)
        {
            SqlCommand aramacmd = new SqlCommand();
            aramacmd.CommandText = "UPDATE randevuKayitlari SET randevuDurum= @randevuDurum WHERE randevuID= @randevuID";
            aramacmd.Parameters.AddWithValue("randevuDurum", randevuDurum);
            aramacmd.Parameters.AddWithValue("randevuID", randevuID);
            SqlConnection con = veritabaniBaglantisiKur(aramacmd);
            aramacmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
