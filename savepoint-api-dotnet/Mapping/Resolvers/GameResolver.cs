using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Stacks;
using savepoint_api_dotnet.Dtos.Lists;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Mapping
{
    // For StackCreateDto
    public class StackGameCreateResolver : IValueResolver<StackCreateDto, Stack, List<Game>>
    {
        private readonly SavePointDbContext _context;

        public StackGameCreateResolver(SavePointDbContext context)
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
    public class StackGameUpdateResolver : IValueResolver<StackUpdateDto, Stack, List<Game>>
    {
        private readonly SavePointDbContext _context;

        public StackGameUpdateResolver(SavePointDbContext context)
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

    // For ListCreateDto
    public class ListGameCreateResolver : IValueResolver<ListCreateDto, List, List<Game>>
    {
        private readonly SavePointDbContext _context;

        public ListGameCreateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Game> Resolve(ListCreateDto source, List destination, List<Game> destMember, ResolutionContext context)
        {
            if (source.GameIds == null || !source.GameIds.Any())
                return new List<Game>();

            return _context.Games
                .Where(g => source.GameIds.Contains(g.Id))
                .ToList();
        }
    }

    // For ListUpdateDto
    public class ListGameUpdateResolver : IValueResolver<ListUpdateDto, List, List<Game>>
    {
        private readonly SavePointDbContext _context;

        public ListGameUpdateResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Game> Resolve(ListUpdateDto source, List destination, List<Game> destMember, ResolutionContext context)
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