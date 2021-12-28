using System.IO;

namespace GintamaArcsScrapper.Utils
{
    public static class FileHandler
    {
        static string FILEPATH =
            Path.Combine(Directory.GetCurrentDirectory(), "Scrape", "results.json");
        
        public static void ConverOutputFileToJson()
        {
            string text = System.IO.File.ReadAllText(FILEPATH);
        }
    }
}