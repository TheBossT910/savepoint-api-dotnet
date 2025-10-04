using AutoMapper;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Models.Api;

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

    // For GameIGDB to Game
    public class DeveloperIGDBResolver : IValueResolver<GameIGDB, Game, List<Developer>>
    {
        private readonly SavePointDbContext _context;

        public DeveloperIGDBResolver(SavePointDbContext context)
        {
            _context = context;
        }
        public List<Developer> Resolve(GameIGDB source, Game destination, List<Developer> destMember, ResolutionContext context)
        {
            // Return empty list if no involved companies
            if (source.InvolvedCompanies == null || !source.InvolvedCompanies.Any())
                return new List<Developer>();

            // Extract developer names from involved companies
            var developerNames = source.InvolvedCompanies
                .Where(ic => ic.Developer)
                .Select(ic => ic.Company.Name)
                .Distinct()
                .ToList();

            // Return empty list if no developer names found
            if (!developerNames.Any())
                return new List<Developer>();

            // Fetch existing developers from the database
            var existingDevelopers = _context.Developers
                .Where(d => developerNames.Contains(d.Name))
                .ToList();

            // Identify new developers that need to be added
            var newDeveloperNames = developerNames
                .Except(existingDevelopers.Select(d => d.Name))
                .ToList();
            var newDevelopers = newDeveloperNames
                .Select(name => new Developer { Name = name, Country = source.InvolvedCompanies.Where(ic => ic.Developer).FirstOrDefault(ic => ic.Company.Name == name)?.Company.CountryName ?? "" })
                .ToList();

            // Add new developers to the database
            if (newDevelopers.Any())
            {
                _context.Developers.AddRange(newDevelopers);
                _context.SaveChanges();
            }

            // Combine existing and new developers
            return existingDevelopers.Concat(newDevelopers).ToList();
        }
    }
}