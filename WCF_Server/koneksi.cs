using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WCF_Server
{
    public class koneksi
    {
        public SqlConnection connection()
        {
            SqlConnection con = new SqlConnection(
               "Data Source = DELL-PC;" +
               "Initial Catalog = VoteBEM;" +
               "User Id = sa;" +
               "Password = 1234567890"
               );

            return con;
        }
    }
}