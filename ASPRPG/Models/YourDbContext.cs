using Microsoft.EntityFrameworkCore;

namespace ASPRPG.Models
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options) 
        {
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Enemy> Enemy { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            
        }
    }
}
