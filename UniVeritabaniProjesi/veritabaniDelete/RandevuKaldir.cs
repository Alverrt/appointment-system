using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniDelete
{
    class RandevuKaldir
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        private int randevuID;
        public RandevuKaldir()
        {
            
        }
        private void veritabaninaBaglan(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            cmd.Connection = conn;
            conn.Open();

        }

        public void randevuKaldir(int randevuID)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM randevuKayitlari WHERE randevuID= @id";
            cmd.Parameters.AddWithValue("id", randevuID);
            veritabaninaBaglan(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
