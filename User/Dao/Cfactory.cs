
using System.Data.SqlClient;

//Setting up the connectionstring to the games database

    public class Cfactory
    {
        public static string CnnString;

        static Cfactory()
        {
            CnnString = "Data Source = NAJEE\\SQLEXPRESS; Initial Catalog = GamesDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";


        }
            public static SqlConnection getConnection()
            {
                SqlConnection cnn = new SqlConnection(CnnString);
                return cnn;
            }

    }


