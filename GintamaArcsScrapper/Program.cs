using System.Threading.Tasks;
using GintamaArcsScrapper.Utils;

namespace GintamaArcsScrapper
{
    static class MainClass
    {
        public static async Task Main(string[] args)
        {
            var scraper = new PageScraper();
            scraper.Start();
            await FileHandler.ConvertOutputFileToJson();
        }
    }
    
}
