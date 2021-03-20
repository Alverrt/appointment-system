using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniVeritabaniProjesi.aramaIslemleri
{
    class RandevuArama
    {
        private string conSTR = "Data Source=./;Initial Catalog=test;Integrated Security=True;Pooling=False";

        public RandevuArama()
        {
        }

        private void veritabaniBaglantisiKur(SqlCommand command)
        {
            SqlConnection conn = new SqlConnection(conSTR);
            command.Connection = conn;
            conn.Open();
        }

        public DataTable middleFixer(DataTable dataTable)
        {
            // Databasede sayılarla kodlu olan günler ve saat aralıklarını okunabillir hale getiriyorum
            foreach (DataRow row in dataTable.Rows)
            {

                switch (row["randevuGun"].ToString())
                {
                    case "0":
                        row["randevuGun"] = "Pazartesi";
                        break;
                    case "1":
                        row["randevuGun"] = "Sali";
                        break;
                    case "2":
                        row["randevuGun"] = "Çarşamba";
                        break;
                    case "3":
                        row["randevuGun"] = "Perşembe";
                        break;
                    case "4":
                        row["randevuGun"] = "Cuma";
                        break;
                    default:
                        break;
                }

                switch (row["randevuSaat"])
                {
                    case "0":
                        row["randevuSaat"] = "08:00 - 09:00";
                        break;
                    case "1":
                        row["randevuSaat"] = "09:00 - 10:00";
                        break;
                    case "2":
                        row["randevuSaat"] = "10:00 - 11:00";
                        break;
                    case "3":
                        row["randevuSaat"] = "11:00 - 12:00";
                        break;
                    case "4":
                        row["randevuSaat"] = "13:00 - 14:00";
                        break;
                    case "5":
                        row["randevuSaat"] = "14:00 - 15:00";
                        break;
                    case "6":
                        row["randevuSaat"] = "15:00 - 16:00";
                        break;
                    case "7":
                        row["randevuSaat"] = "16:00 - 17:00";
                        break;
                    default:
                        break;
                }

                switch (row["randevuDurum"].ToString())
                {
                    case "0":
                        row["randevuDurum"] = "Beklemede";
                        break;
                    case "1":
                        row["randevuDurum"] = "Kabul Edildi";
                        break;
                    case "2":
                        row["randevuDurum"] = "Reddedildi";
                        break;
                    default:
                        break;
                }
            }
            return dataTable;
        }

        
        public DataTable randevulariGetir(int isyeriID)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "randevuListesiGetir";
            veritabaniBaglantisiKur(command);


            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);
            return middleFixer(dataTable);
            
            
            // dataTable.Columns["randevuID"].ColumnMapping = MappingType.Hidden;
            // dataTable.Columns["kullaniciID"].ColumnMapping = MappingType.Hidden;
            // dataTable.Columns["isyeriID"].ColumnMapping = MappingType.Hidden;
            
        }

        public DataTable kullaniciRandevulariniGetir(int kullaniciID)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "SELECT isyeriKayitlari.isyeriIsim, isyeriKayitlari.isyeriTur, randevuKayitlari.randevuID, randevuKayitlari.randevuGun, randevuKayitlari.randevuSaat, randevuKayitlari.randevuDurum FROM isyeriKayitlari INNER JOIN randevuKayitlari ON isyeriKayitlari.isyeriID = randevuKayitlari.isyeriID WHERE randevuKayitlari.kullaniciID= @kullaniciID";
            command.Parameters.AddWithValue("kullaniciID", kullaniciID);
            veritabaniBaglantisiKur(command);

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return middleFixer(dataTable);
        }
    }
}
