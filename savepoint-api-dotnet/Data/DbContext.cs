using Microsoft.EntityFrameworkCore;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Data
{
    public class SavePointDbContext : DbContext
    {
        public SavePointDbContext(DbContextOptions<SavePointDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create a new id when given a blank GUID
            modelBuilder.Entity<Game>()
                .Property(g => g.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
            modelBuilder.Entity<Stack>()
                .Property(s => s.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");
        }

        // Tables in SQL
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Stack> Stacks { get; set; }
        public DbSet<List> Lists { get; set; }
    }
}
