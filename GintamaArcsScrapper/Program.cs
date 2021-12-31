using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GintamaArcsScrapper.Configuration;
using GintamaArcsScrapper.Context;
using GintamaArcsScrapper.Infrastructure;
using GintamaArcsScrapper.Models;
using GintamaArcsScrapper.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GintamaArcsScrapper
{
    static class MainClass
    {
        public static async Task Main(string[] args)
        {
            // Configure services to DB connection
            var services = new ServiceCollection();
            
            var connectionString = DbConnectionConfig.GetConnectionString();
            services.AddSingleton<DbDao>();
            services.AddDbContext<GintamaContext>(options => options.UseMySql(connectionString,
                ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Name },
                    LogLevel.Information)
                .EnableSensitiveDataLogging() // <-- These two calls are optional but help
                .EnableDetailedErrors());
            
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            var dbService = serviceProvider.GetService<DbDao>();
            
            
            // scrape and save data to json file in disk
            var scraper = new PageScraper();
            scraper.Start();
            var json = await FileHandler.ConvertOutputFileToJson();

            
            // save the data of the json in the DB
            var arcsInfo = JsonConvert.DeserializeObject<List<Arc>>(json);
            if (dbService != null)
            {
                await dbService.Insert(arcsInfo);
            }
        }
    }
    
}
