using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        string connectionString = "Data Source=LAPTOP-54NOARJ3;Initial Catalog=WCFReservasi;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection connection;
        //untuk menghubungkan database
        SqlCommand com;

        public string deletePemesanan(string idPemesanan)
        {
            throw new NotImplementedException();
        }

        public List<DetailLokasi> DetailLokasi()
        {
            //deklarasi nama List
            List<DetailLokasi> LokasiFull = new List<DetailLokasi>();
            try
            {
                string sql = "select ID_lokasi, Nama_lokasi, Deskripsi_full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DetailLokasi data = new DetailLokasi();
                    data.IDLokasi = reader.GetString(0);
                    data.NamaLokasi = reader.GetString(1);
                    data.DeskripsiFull = reader.GetString(2);
                    data.Kuota = reader.GetInt32(3);
                    LokasiFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }

        public string editPemesanan(string iDPemesanan, string namaCustomer)
        {
            throw new NotImplementedException();
        }

        public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelpon, int JumlahPemesanan, string IDLokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.Pemesanan values ('" + IDPemesanan + "','" + NamaCustomer + "','" + NoTelpon + "'," + JumlahPemesanan + ",'" + IDLokasi + "')";
                connection = new SqlConnection(connectionString);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "Sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        public List<CekLokasi> reviewLokasi()
        {
            throw new NotImplementedException();
        }
    }
    }