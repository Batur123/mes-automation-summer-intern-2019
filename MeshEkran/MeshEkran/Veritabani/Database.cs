using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MeshEkran.Veritabani
{
    

    public class Database
    {

        public static string GlobalServerName = "BATUR" + "\\" + "BATUR";

        public static SqlConnection GetConnection()
        {
             


                 string connectionString = @"Data Source="+ GlobalServerName+"; Initial Catalog="+Giris_SecimEkran.DBAdiGlobal+";Integrated Security=True";

                return new SqlConnection(connectionString);
        }
        
    }
}
