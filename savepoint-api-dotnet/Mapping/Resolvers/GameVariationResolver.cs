using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameCreateDto
    public class GameVariationCreateResolver : IValueResolver<GameCreateDto, Game, List<GameVariation>>
    {
        private readonly SavePointDbContext _context;

        public GameVariationCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<GameVariation> Resolve(GameCreateDto source, Game destination, List<GameVariation> destMember, ResolutionContext context)
        {
            if (source.GameVariationIds == null || !source.GameVariationIds.Any())
                return new List<GameVariation>();

            return _context.GameVariations
                .Where(d => source.GameVariationIds.Contains(d.Id))
                .ToList();
        }
    }

    // For GameUpdateDto
    public class GameVariationUpdateResolver : IValueResolver<GameUpdateDto, Game, List<GameVariation>>
    {
        private readonly SavePointDbContext _context;

        public GameVariationUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<GameVariation> Resolve(GameUpdateDto source, Game destination, List<GameVariation> destMember, ResolutionContext context)
        {
            destination.GameVariations?.Clear();

            if (source.GameVariationIds == null || !source.GameVariationIds.Any())
                return new List<GameVariation>();

            return _context.GameVariations
                .Where(d => source.GameVariationIds.Contains(d.Id))
                .ToList();
        }
    }
}