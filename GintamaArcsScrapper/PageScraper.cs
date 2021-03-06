using System;
using System.Linq;
using GintamaArcsScrapper.Models;
using GintamaArcsScrapper.Utils;
using IronWebScraper;

namespace GintamaArcsScrapper
{
    class PageScraper : WebScraper
    {
        private const string PAGE_URL = "https://gintama.fandom.com/wiki/";
        private static readonly string ARCS_LIST_URL = $"{PAGE_URL}Gintama_Episode_List";

        public override void Init()
        {
            this.LoggingLevel = WebScraper.LogLevel.All;
            this.Request(ARCS_LIST_URL, Parse);
        }

        public override void Parse(Response response)
        {
            var arcRowSelector = "#mw-content-text > div > table.wikitable > tbody > tr";
            var responseRows = response.Css(arcRowSelector).Skip(1);
            foreach (var rowHtmlNode in responseRows)
            {
                string strRow = rowHtmlNode.TextContentClean;
                var strCells = strRow.Separate('(', ')', '½');

                var arc = new Arc();
                arc.Name = strCells[0];
                arc.Episodes = strCells[1];
                arc.QuantityEpisodes = int.Parse(strCells[2]);

                // ex: convert 'Memory Loss Arc' to 'Memory_Loss_Arc' and is assigned in the arc.URL
                var link = arc.Name.Trim().Replace(' ', '_');
                arc.Url = $"{PAGE_URL}{link}";
                this.Request(arc.Url, ParseDetails, new MetaData() { { "arc", arc } });// to scrap Detailed
            }
        }

        private void ParseDetails(Response response)
        {
            var arc = response.MetaData.Get<Arc>("arc");
            var arcSummary = GetArcDescription(response);
            var arcImage = GetArcImage(response);
            var arcDateRelease = GetArcReleaseDate(response);

            arc.Description = arcSummary;
            arc.Image = arcImage;
            arc.ReleaseDate = arcDateRelease;
            Scrape(arc, "results.txt");
        }

        private string GetArcDescription(Response response)
        {
            var arcSummary = "";

            for (int i = 1; i <= 10; i++)
            {
                var selector = $"//*[@id=\"mw-content-text\"]/div/p[{i.ToString()}]";
                var node = response.XPath(selector);
                if (node.Length > 0 && node[0].TextContentClean != string.Empty)
                {
                    arcSummary = node[0].TextContentClean;
                    return arcSummary;
                }
            }
            return arcSummary;
        }

        private string GetArcImage(Response response)
        {
            var selector = ".pi-image-thumbnail";
            var node = response.QuerySelectorAll(selector);
            var imageUrl = node.Length > 1
                ? node[1].Attributes["src"]
                : node[0].Attributes["src"];

            return imageUrl.RemoveScale();
        }

        private string GetArcReleaseDate(Response response)
        {
            var selector = $"//*[@id=\"mw-content-text\"]/div/aside/section[1]/div[4]/div";
            HtmlNode[] node = null;
            try
            {
                node = response.XPath(selector);
            }
            catch (Exception e)
            {
                if (node == null)
                {
                    selector = "//*[@id=\"mw-content-text\"]/div/aside/section[1]/div[3]/div";
                    node = response.XPath(selector);
                }
            }

            var releaseDate = node[0].TextContentClean;
            return releaseDate;
        }

    }

    public static class StringExtension
    {
        public static string RemoveScale(this string str)
        {
            var strToRemove = "/revision/latest/scale-to-width-down/";
            var indexOfScale = str.LastIndexOf(strToRemove);
            if (indexOfScale != -1)
            {
                str = str.Remove(indexOfScale);
            }
            return str;
        }
    }
}