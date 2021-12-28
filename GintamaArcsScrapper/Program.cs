﻿using System.Threading.Tasks;
using GintamaArcsScrapper.Utils;

namespace GintamaArcsScrapper
{
    class MainClass
    {
        public static async Task Main(string[] args)
        {
            System.IO.File.Delete(FileHandler.FILEPATH);

            var scraper = new PageScraper();
            scraper.Start();
            await FileHandler.ConvertOutputFileToJson();
        }
    }
    
}
