using System.Collections.Generic;
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
            await _context.Arcs.AddRangeAsync(arcs);
            await _context.SaveChangesAsync();
        } 
    }
}