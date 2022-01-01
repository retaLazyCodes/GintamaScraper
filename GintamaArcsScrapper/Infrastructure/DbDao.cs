using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GintamaArcsScrapper.Context;
using GintamaArcsScrapper.Models;

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
            
            // remove all records
            var all = from c in _context.Arcs select c;
            if (all.Count() > 0)
            {
                _context.Arcs.RemoveRange(all);
                _context.SaveChanges();
            }
            
            // Add all scraped data
            await _context.Arcs.AddRangeAsync(arcs);
            await _context.SaveChangesAsync();
        } 
    }
}