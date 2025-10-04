using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;

namespace savepoint_api_dotnet.Mapping
{
    // For GameCreateDto
    public class PlatformCreateResolver : IValueResolver<GameCreateDto, Game, List<Platform>>
    {
        private readonly SavePointDbContext _context;

        public PlatformCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Platform> Resolve(GameCreateDto source, Game destination, List<Platform> destMember, ResolutionContext context)
        {
            if (source.PlatformIds == null || !source.PlatformIds.Any())
                return new List<Platform>();

            return _context.Platforms
                .Where(p => source.PlatformIds.Contains(p.Id))
                .ToList();
        }
    }

    // For GameUpdateDto
    public class PlatformUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Platform>>
    {
        private readonly SavePointDbContext _context;

        public PlatformUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Platform> Resolve(GameUpdateDto source, Game destination, List<Platform> destMember, ResolutionContext context)
        {
            destination.Platforms?.Clear();

            if (source.PlatformIds == null || !source.PlatformIds.Any())
                return new List<Platform>();

            return _context.Platforms
                .Where(p => source.PlatformIds.Contains(p.Id))
                .ToList();
        }
    }

    // For GameIGDB to Game
    public class PlatformIGDBResolver : IValueResolver<GameIGDB, Game, List<Platform>>
    {
        private readonly SavePointDbContext _context;

        public PlatformIGDBResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Platform> Resolve(GameIGDB source, Game destination, List<Platform> destMember, ResolutionContext context)
        {
            // Return empty list if no platforms
            if (source.Platforms == null || !source.Platforms.Any())
                return new List<Platform>();

            // Extract platform hardware names from involved companies
            var platformNames = source.Platforms
                .Select(p => p.Platform)
                .Distinct()
                .ToList();

            // Return empty list if no platform names found
            if (!platformNames.Any())
                return new List<Platform>();

            // Fetch existing platforms from the database
            var existingPlatforms = _context.Platforms
                .Where(g => platformNames.Contains(g.Hardware))
                .ToList();

            // Identify new platforms that need to be added
            var newPlatformNames = platformNames
                .Except(existingPlatforms.Select(g => g.Hardware))
                .ToList();
            var newPlatforms = newPlatformNames
                .Select(hardware => new Platform { Hardware = hardware, PlatformLogo = source.Platforms.FirstOrDefault(p => p.Platform == hardware)?.PlatformLogo.Url ?? "", Url = source.Platforms.FirstOrDefault(p => p.Platform == hardware)?.Websites?.First().Url ?? null })
                .ToList();

            // Add new platforms to the database
            if (newPlatforms.Any())
            {
                _context.Platforms.AddRange(newPlatforms);
                _context.SaveChanges();
            }

            // Combine existing and new plaforms
            return existingPlatforms.Concat(newPlatforms).ToList();
        }
    }
}