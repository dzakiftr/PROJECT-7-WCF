using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace WCF_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Kandidat" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Kandidat.svc or Kandidat.svc.cs at the Solution Explorer and start debugging.
    public class Kandidat : IKandidat
    {
        string date = DateTime.Today.ToString("YYYY-MM-DD");

        public List<KandidatInfo> ShowKandidat()
        {
            koneksi con = new koneksi();
            SqlConnection sqcon = con.connection();
            List<KandidatInfo> lisKad = new List<KandidatInfo>();

            using (sqcon)
            {
                sqcon.Open();

                string com = "select * from vKandidat";
                SqlCommand sqlcomm = new SqlCommand(com, sqcon);

                using (sqlcomm)
                {
                    SqlDataReader dr = sqlcomm.ExecuteReader();
                    //kd.nomorUrut = dr.GetInt32(0);
                    //kd.nama = dr.GetString(1);
                    //kd.jurusan = dr.GetString(2);
                    //kd.prodi = dr.GetString(3);
                    //kd.visi = (dr["Visi"]).ToString();
                    //kd.misi = (dr["Misi"]).ToString();
                    //if (!Convert.IsDBNull(dr["Foto"]))
                    //{
                    //    kd.picture = (byte[])(dr["Foto"]);
                    //}

                    //lisKad.Add(kd);

                    while (dr.Read())
                    {
                        KandidatInfo kd = new KandidatInfo();
                        kd.nomorUrut = dr.GetInt32(0);
                        kd.nama = dr.GetString(1);
                        kd.jurusan = dr.GetString(2);
                        kd.prodi = dr.GetString(3);
                        kd.visi = (dr["Visi"]).ToString();
                        kd.misi = (dr["Misi"]).ToString();
                        kd.picture = (dr["Foto"]).ToString();

                        lisKad.Add(kd);
                    }
                }
                sqcon.Close();
            }
            return lisKad;
        }

        public bool validateUser(string ID)
        {
            koneksi con = new koneksi();
            SqlConnection sqcon = con.connection();

            using (sqcon)
            {
                sqcon.Open();
                string com = "select COUNT (*) from Pemilihan where NIM = @NIM";
                SqlCommand sqcomm = new SqlCommand(com, sqcon);
                int result = 0;
                using (sqcomm)
                {
                    sqcomm.Parameters.AddWithValue("@NIM", ID);

                    result = (int)sqcomm.ExecuteScalar();
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
                sqcon.Close();
            }
        }

        public int doVote(VoteInfo suara)
        {
            koneksi con = new koneksi();
            SqlConnection sqcon = con.connection();
            int result = 0;

            var d = DateTime.ParseExact(date, "YYYY-MM-DD", CultureInfo.InvariantCulture);

            using (sqcon)
            {
                sqcon.Open();

                string com = "INSERT INTO Pemilihan VALUES(@nim, @nomor, @tgl)";
                SqlCommand sqcomm = new SqlCommand(com, sqcon);

                using (sqcomm)
                {
                    sqcomm.Parameters.AddWithValue("@nomor", suara.Nomor_Urut);
                    sqcomm.Parameters.AddWithValue("@nim", suara.NIM);
                    sqcomm.Parameters.AddWithValue("@tgl", d);

                    result = sqcomm.ExecuteNonQuery();
                }
                sqcon.Close();
            }
            return result;
        }
    }
}
