using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.veritabaniUpdate
{
    class MusaitRandevuGuncelle
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";
        public MusaitRandevuGuncelle()
        {

        }
        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection con = new SqlConnection(conSTR);
            command.Connection = con;
            con.Open();
            return con;
        }

        public void musaitRandevuZamaniGuncelle(int isyeriID, ArrayList dize)
        {
            int gunID, sifir, bir, iki, uc, dort, bes, alti, yedi, k=0;

            for (int i = 0; i < 40; i += 8)
            {
                gunID = k;
                k++;
                sifir = Convert.ToInt32(dize[i]);
                bir = Convert.ToInt32(dize[i + 1]);
                iki = Convert.ToInt32(dize[i + 2]);
                uc = Convert.ToInt32(dize[i + 3]);
                dort = Convert.ToInt32(dize[i + 4]);
                bes = Convert.ToInt32(dize[i + 5]);
                alti = Convert.ToInt32(dize[i + 6]);
                yedi = Convert.ToInt32(dize[i + 7]);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE musaitRandevuZamanlari SET zamanAralik0= @sifir, zamanAralik1= @bir, zamanAralik2= @iki, zamanAralik3= @uc, zamanAralik4= @dort, zamanAralik5= @bes, zamanAralik6= @alti, zamanAralik7= @yedi WHERE isyeriID= @isyeriID AND gun= @gunID";
                cmd.Parameters.AddWithValue("isyeriID", isyeriID);
                cmd.Parameters.AddWithValue("gunID", gunID);
                cmd.Parameters.AddWithValue("sifir", sifir);
                cmd.Parameters.AddWithValue("bir", bir);
                cmd.Parameters.AddWithValue("iki", iki);
                cmd.Parameters.AddWithValue("uc", uc);
                cmd.Parameters.AddWithValue("dort", dort);
                cmd.Parameters.AddWithValue("bes", bes);
                cmd.Parameters.AddWithValue("alti", alti);
                cmd.Parameters.AddWithValue("yedi", yedi);
                SqlConnection con = veritabaniBaglantisiKur(cmd);
                cmd.ExecuteNonQuery();
                con.Close();
            
            }
            k = 0;
        }
    }
}
