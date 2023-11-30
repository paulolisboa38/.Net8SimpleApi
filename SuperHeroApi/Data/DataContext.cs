using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
