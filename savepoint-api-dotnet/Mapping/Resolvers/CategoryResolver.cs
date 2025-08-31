using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For GameCreateDto
    public class CategoryCreateResolver : IValueResolver<GameCreateDto, Game, List<Category>>
    {
        private readonly SavePointDbContext _context;

        public CategoryCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Category> Resolve(GameCreateDto source, Game destination, List<Category> destMember, ResolutionContext context)
        {
            if (source.CategoryIds == null || !source.CategoryIds.Any())
                return new List<Category>();

            return _context.Categories
                .Where(c => source.CategoryIds.Contains(c.Id))
                .ToList();
        }
    }

    // For GameUpdateDto
    public class CategoryUpdateResolver : IValueResolver<GameUpdateDto, Game, List<Category>>
    {
        private readonly SavePointDbContext _context;

        public CategoryUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Category> Resolve(GameUpdateDto source, Game destination, List<Category> destMember, ResolutionContext context)
        {
            destination.Categories?.Clear();

            if (source.CategoryIds == null || !source.CategoryIds.Any())
                return new List<Category>();

            return _context.Categories
                .Where(c => source.CategoryIds.Contains(c.Id))
                .ToList();
        }
    }
}