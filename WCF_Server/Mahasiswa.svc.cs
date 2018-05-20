using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WCF_Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Mahasiswa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Mahasiswa.svc or Mahasiswa.svc.cs at the Solution Explorer and start debugging.
    public class Mahasiswa : IMahasiswa
    {
        public bool login(string ID, string Password)
        {
            koneksi con = new koneksi();
            SqlConnection sqcon = con.connection();

            using (sqcon)
            {
                sqcon.Open();
                string com = "select COUNT (*) from mahasiswa where NIM = @NIM AND password = @pwd";
                SqlCommand sqcomm = new SqlCommand(com, sqcon);
                int result = 0;
                using (sqcomm)
                {
                    sqcomm.Parameters.AddWithValue("@pwd", Password);
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
    }
}
