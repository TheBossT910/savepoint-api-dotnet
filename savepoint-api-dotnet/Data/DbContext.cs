using Microsoft.EntityFrameworkCore;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }  // The games table in Supabase
    }
}
