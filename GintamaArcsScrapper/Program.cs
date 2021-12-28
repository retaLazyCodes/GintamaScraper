namespace GintamaArcsScrapper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var scraper = new BlogScraper();
            scraper.Start();
        }
    }
    
}
