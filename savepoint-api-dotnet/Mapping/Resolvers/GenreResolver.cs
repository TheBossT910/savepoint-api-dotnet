using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;

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

    // For GameIGDB to Game
    public class GenreIGDBResolver : IValueResolver<GameIGDB, Game, List<Genre>>
    {
        private readonly SavePointDbContext _context;

        public GenreIGDBResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Genre> Resolve(GameIGDB source, Game destination, List<Genre> destMember, ResolutionContext context)
        {
            // Return empty list if no genres
            if (source.Genres == null || !source.Genres.Any())
                return new List<Genre>();

            // Extract genre names from involved companies
            var genreNames = source.Genres
                .Select(g => g.Name)
                .Distinct()
                .ToList();

            // Return empty list if no genre names found
            if (!genreNames.Any())
                return new List<Genre>();

            // Fetch existing genres from the database
            var existingGenres = _context.Genres
                .Where(g => genreNames.Contains(g.Name))
                .ToList();

            // Identify new genres that need to be added
            var newGenreNames = genreNames
                .Except(existingGenres.Select(g => g.Name))
                .ToList();
            var newGenres = newGenreNames
                .Select(name => new Genre { Name = name })
                .ToList();

            // Add new genres to the database
            if (newGenres.Any())
            {
                _context.Genres.AddRange(newGenres);
                _context.SaveChanges();
            }

            // Combine existing and new genres
            return existingGenres.Concat(newGenres).ToList();
        }
    }
}