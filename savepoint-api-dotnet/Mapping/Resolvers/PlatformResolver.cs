using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

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
}