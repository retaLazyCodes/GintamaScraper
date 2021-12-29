using System;
using System.Linq;
using GintamaArcsScrapper.Utils;
using IronWebScraper;

namespace GintamaArcsScrapper
{
    class PageScraper : WebScraper
    {
        private const string PAGE_URL = "https://gintama.fandom.com/wiki/Gintama_Episode_List";
        private const string CSS_SELECTOR = "#mw-content-text > div > table.wikitable > tbody > tr";

        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request(PAGE_URL, Parse);
        }

        public override void Parse(Response response)
        {
            var responseRows= response.Css(CSS_SELECTOR).Skip(1);
            foreach (var rowHtmlNode in responseRows)
            {
                string strRow = rowHtmlNode.TextContentClean;
                var strCells = strRow.Separate('(', ')', '½');
                Scrape(new ScrapedData()
                {
                    {"Arc_Name", strCells[0]},
                    {"Episodes", strCells[1]},
                    {"Quantity_Episodes", Int32.Parse(strCells[2])},
                    {"Description", "lorem ipsum"},
                }, "results.txt");
            }
        }
    }
}