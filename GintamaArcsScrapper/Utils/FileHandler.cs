using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GintamaArcsScrapper.Utils
{
    public static class FileHandler
    {
        public static readonly string FILE_PATH =
            Path.Combine(Directory.GetCurrentDirectory(), "Scrape", "results.txt");
        
        public static async Task<string> ConvertOutputFileToJson()
        {
           string jsonFormatText = GiveJsonFormat();
           string cleanJson = CleanJsonText(jsonFormatText);
           try
           {
               await WriteFileInDisk(cleanJson);
               var jsonFile = ReadJsonFromDisk();
               return cleanJson;
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               throw;
           }
        }
        
        private static string GiveJsonFormat()
        {
            var newFileText = new StringBuilder("[");
            // Read the file line by line.  
            foreach (string line in File.ReadLines(FILE_PATH))
            {
                var newLine = line + ',';
                newFileText.AppendLine(newLine);
            }
            
            return newFileText.ToString();
        }
        
        private static string CleanJsonText(string jsonFormatText)
        {
            var textLength = jsonFormatText.Length;
            
            // replaces the last char (',') with the char ']'
            var cleanText = 
                jsonFormatText.Remove(textLength -2) + "]";
            return cleanText;
        }
        
        public static async Task WriteFileInDisk(string inputText)
        {
            Console.WriteLine("Writing JSON file in disk ...");
            await File.WriteAllTextAsync
                (FILE_PATH.Replace(".txt", ".json"), inputText);
            Console.WriteLine("File Written successfully!!");
        }

        private static string ReadJsonFromDisk()
        {
            string text = File.ReadAllText((FILE_PATH.Replace(".txt", ".json")));
            return text;
        }

       
    }
}