using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.aramaIslemleri
{
    class MusaitRandevuAra
    {

        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public MusaitRandevuAra()
        {

        }
        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();

            return conn;
        }

        public ArrayList musaitRandevulariGetir(int isyeriID, int gunKodu)
        {
            ArrayList zamanlar = new ArrayList();
            SqlCommand aramacmd = new SqlCommand();
            aramacmd.CommandText = "SELECT * FROM musaitRandevuZamanlari WHERE isyeriID= @isyeriID AND gun= @gunID";
            aramacmd.Parameters.AddWithValue("isyeriID", isyeriID);
            aramacmd.Parameters.AddWithValue("gunID", gunKodu);

            SqlConnection con = veritabaniBaglantisiKur(aramacmd);

            SqlDataReader dr = aramacmd.ExecuteReader();

            if (dr.Read())
            {
                for (int i = 3; i < 11; i++)
                {
                    zamanlar.Add(dr[i]);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("İş yeri yetkilisi randevu zamanlarını eklememiş.");
            }
            con.Close();
            return zamanlar;
        }
    }
}
