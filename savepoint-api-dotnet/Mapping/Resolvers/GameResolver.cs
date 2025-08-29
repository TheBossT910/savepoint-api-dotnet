using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Stacks;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For StackCreateDto
    public class GameCreateResolver : IValueResolver<StackCreateDto, Stack, List<Game>>
    {
        private readonly SavePointDbContext _context;

        public GameCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Game> Resolve(StackCreateDto source, Stack destination, List<Game> destMember, ResolutionContext context)
        {
            if (source.GameIds == null || !source.GameIds.Any())
                return new List<Game>();

            return _context.Games
                .Where(g => source.GameIds.Contains(g.Id))
                .ToList();
        }
    }

    // For StackUpdateDto
    public class GameUpdateResolver : IValueResolver<StackUpdateDto, Stack, List<Game>>
    {
        private readonly SavePointDbContext _context;

        public GameUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Game> Resolve(StackUpdateDto source, Stack destination, List<Game> destMember, ResolutionContext context)
        {
            destination.Games?.Clear();

            if (source.GameIds == null || !source.GameIds.Any())
                return new List<Game>();

            return _context.Games
                .Where(g => source.GameIds.Contains(g.Id))
                .ToList();
        }
    }
}