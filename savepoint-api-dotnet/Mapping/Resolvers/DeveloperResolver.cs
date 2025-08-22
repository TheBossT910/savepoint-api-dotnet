using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameCreateDto
    public class DeveloperCreateResolver : IValueResolver<GameCreateDto, Game, List<Developer>>
    {
        private readonly SavePointDbContext _context;

        public DeveloperCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Developer> Resolve(GameCreateDto source, Game destination, List<Developer> destMember, ResolutionContext context)
        {
            if (source.DeveloperIds == null || !source.DeveloperIds.Any())
                return new List<Developer>();

            return _context.Developers
                .Where(d => source.DeveloperIds.Contains(d.Id))
                .ToList();
        }
    }

    // For GameUpdateDto
    public class DeveloperUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Developer>>
    {
        private readonly SavePointDbContext _context;

        public DeveloperUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Developer> Resolve(GameUpdateDto source, Game destination, List<Developer> destMember, ResolutionContext context)
        {
            destination.Developers?.Clear();

            if (source.DeveloperIds == null || !source.DeveloperIds.Any())
                return new List<Developer>();

            return _context.Developers
                .Where(d => source.DeveloperIds.Contains(d.Id))
                .ToList();
        }
    }
}