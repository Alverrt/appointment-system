using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniDelete
{
    class IsyeriKaldir
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        private int isyeriID;
        public IsyeriKaldir(int isyeriID)
        {
            this.isyeriID = isyeriID;
        }
        private void veritabaninaBaglan(SqlCommand cmd)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            cmd.Connection = conn;
            conn.Open();

        }

        public void isyeriKaldir()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM isYeriKayitlari WHERE isyeriID= @id";           
            cmd.Parameters.AddWithValue("id", isyeriID);
            veritabaninaBaglan(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}
