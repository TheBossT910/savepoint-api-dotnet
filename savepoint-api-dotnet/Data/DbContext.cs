using Microsoft.EntityFrameworkCore;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Data
{
    public class SavePointDbContext : DbContext
    {
        public SavePointDbContext(DbContextOptions<SavePointDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }  // The games table in Supabase
    }
}
