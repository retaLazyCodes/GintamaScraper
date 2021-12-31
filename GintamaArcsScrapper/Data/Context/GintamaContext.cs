using GintamaArcsScrapper.Models;
using Microsoft.EntityFrameworkCore;

namespace GintamaArcsScrapper.Context
{
    public class GintamaContext : DbContext
    {
        public GintamaContext(DbContextOptions<GintamaContext> options) : base(options)
        {
  
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        //entities
        public DbSet<Arc> Arcs { get; set; }
    }
}