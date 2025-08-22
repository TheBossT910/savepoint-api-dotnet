using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameCreateDto
    public class GenreCreateResolver : IValueResolver<GameCreateDto, Game, List<Genre>>
    {
        private readonly SavePointDbContext _context;

        public GenreCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Genre> Resolve(GameCreateDto source, Game destination, List<Genre> destMember, ResolutionContext context)
        {
            if (source.GenreIds == null || !source.GenreIds.Any())
                return new List<Genre>();

            return _context.Genres
                .Where(d => source.GenreIds.Contains(d.Id))
                .ToList();
        }
    }

    // For GameUpdateDto
    public class GenreUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Genre>>
    {
        private readonly SavePointDbContext _context;

        public GenreUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Genre> Resolve(GameUpdateDto source, Game destination, List<Genre> destMember, ResolutionContext context)
        {
            destination.Genres?.Clear();

            if (source.GenreIds == null || !source.GenreIds.Any())
                return new List<Genre>();

            return _context.Genres
                .Where(d => source.GenreIds.Contains(d.Id))
                .ToList();
        }
    }
}