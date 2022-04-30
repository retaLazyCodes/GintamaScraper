using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using GintamaArcsScrapper.Utils;

namespace GintamaArcsScrapper.Configuration
{
    public class DbConnectionConfig
    {
        public static string GetConnectionString()
        {            
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "user-db-config.json");
            string jsonDbConfig = File.ReadAllText(jsonPath);
            dynamic parsedJson = JsonConvert.DeserializeObject(jsonDbConfig);

            return @$"server={parsedJson.Server.Value};
                    user={parsedJson.User.Value};
                    password={parsedJson.Password.Value};
                    database={parsedJson.Database.Value};
                    port={parsedJson.Port.Value}";
        }
    }
}