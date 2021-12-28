using System;
using System.IO;
using System.Threading.Tasks;

namespace GintamaArcsScrapper.Utils
{
    public static class FileHandler
    {
        public static string FILEPATH =
            Path.Combine(Directory.GetCurrentDirectory(), "Scrape", "results");
        
        public static async Task ConvertOutputFileToJson()
        {
           string jsonFormatText = GiveJsonFormat();
           string cleanJson = CleanJsonText(jsonFormatText);
           await WriteFileInDisk(cleanJson);
        }
        
        private static string GiveJsonFormat()
        {
            string newFileText = "[";
            // Read the file line by line.  
            foreach (string line in File.ReadLines(FILEPATH))
            {
                var newLine = line + ',';
                newFileText += newLine + Environment.NewLine;
            }
            
            return newFileText;
        }
        
        private static string CleanJsonText(string jsonFormatText)
        {
            var textLength = jsonFormatText.Length;
            
            // replaces the last char (',') with the char ']'
            var cleanText = 
                jsonFormatText.Remove(textLength -2) + "]";
            return cleanText;
        }
        
        static async Task WriteFileInDisk(string inputText)
        {
            Console.WriteLine("Writing JSON file in disk ...");
            await File.WriteAllTextAsync(FILEPATH + ".json", inputText);
            Console.WriteLine("File Written successfully!!");
        }


       
    }
}