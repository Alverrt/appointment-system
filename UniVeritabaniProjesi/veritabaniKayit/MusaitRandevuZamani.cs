using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniVeritabaniProjesi.veritabaniUpdate;

namespace UniVeritabaniProjesi.veritabaniKayit
{
    class MusaitRandevuZamani
    {

        public MusaitRandevuZamani()
        {
            
        }

        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        private SqlConnection veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection con = new SqlConnection(conSTR);
            command.Connection = con;
            con.Open();
            return con;
        }


        public void musaitRandevuKayit(int isyeriID, ArrayList dize)
        {
            int sifir, bir, iki, uc, dort, bes, alti, yedi, gunID, k = 0, veriVarMi;

            SqlCommand kontrol = new SqlCommand();
            kontrol.CommandText = "SELECT COUNT(*) FROM musaitRandevuZamanlari WHERE isyeriID= @isyeriID";
            kontrol.Parameters.AddWithValue("isyeriID", isyeriID);
            SqlConnection conn = veritabaniBaglantisiKur(kontrol);
            veriVarMi = (int) kontrol.ExecuteScalar();
            if (veriVarMi > 0)
            {
                MusaitRandevuGuncelle guncelle = new MusaitRandevuGuncelle();
                conn.Close();
                guncelle.musaitRandevuZamaniGuncelle(isyeriID, dize);
                return;
            }

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
                cmd.CommandText = "INSERT INTO musaitRandevuZamanlari (isyeriID, gun, zamanAralik0, zamanAralik1, zamanAralik2, zamanAralik3, zamanAralik4, zamanAralik5, zamanAralik6, zamanAralik7) VALUES (@isyeriID, @gunID, @sifir, @bir, @iki, @uc, @dort, @bes, @alti, @yedi)";
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
                SqlConnection connect = veritabaniBaglantisiKur(cmd);

                cmd.ExecuteNonQuery();
                connect.Close();
            }
            k = 0;
            conn.Close();
        }
    }
}
