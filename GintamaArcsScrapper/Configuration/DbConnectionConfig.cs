using System.Collections.Generic;

namespace GintamaArcsScrapper.Configuration
{
    public class DbConnectionConfig
    {
        public static string Server = "localhost";
        public static string User = "root";
        public static string Password = "finnelhumano";
        public static string Database = "gintama";
        public static int Port = 3306;
        

        public static string GetConnectionString()
        {
            return $"server={Server};user={User};password={Password};database={Database};port={Port}";
        }
    }
}