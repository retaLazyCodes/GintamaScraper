using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GintamaArcsScrapper.Context;
using GintamaArcsScrapper.Models;
using Microsoft.EntityFrameworkCore;

namespace GintamaArcsScrapper.Infrastructure
{
    public class DbDao
    {
        private readonly GintamaContext _context;

        public DbDao(GintamaContext context)
        {
            _context = context;
        }

        public async Task Insert(List<Arc> arcs)
        {
            _context.Database.EnsureCreated();

            // remove all records if already exists
            if (_context.Arcs.Any())
            {
                _context.Database.ExecuteSqlRaw("TRUNCATE TABLE Arcs");
            }
            // Stores all scraped data
            await _context.Arcs.AddRangeAsync(arcs);
            await _context.SaveChangesAsync();
        } 
    }
}