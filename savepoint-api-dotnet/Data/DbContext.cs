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
        }

        public DbSet<Game> Games { get; set; }  // The games table in SQL
    }
}
