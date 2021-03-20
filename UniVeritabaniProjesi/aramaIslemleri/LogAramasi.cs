using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.aramaIslemleri
{
    class LogAramasi
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public LogAramasi()
        {

        }

        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();

            return conn;
        }

        public DataTable loglariGetir()
        {
            SqlCommand logcmd = new SqlCommand();
            logcmd.CommandText = "SELECT * FROM girisLoglari";

            veritabaniBaglantisiKur(logcmd);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(logcmd);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);

            return table;
        }
    }
}
