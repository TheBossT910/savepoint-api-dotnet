using savepoint_api_dotnet.Data;
using System;
using savepoint_api_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using savepoint_api_dotnet.Dtos.Games;
using AutoMapper.QueryableExtensions;

namespace savepoint_api_dotnet.Services
{
    public class GameService
	{
        private readonly SavePointDbContext _context;
        private readonly IMapper _mapper;
        public GameService(SavePointDbContext context, IMapper mapper)
		{
			_context = context;
            _mapper = mapper;
		}

		// Add game
		public GameDto AddGame(GameCreateDto gameCreateDto)
		{
            var game = _mapper.Map<Game>(gameCreateDto);
            _context.Games.Add(game);
			_context.SaveChanges();
            return _mapper.Map<GameDto>(game);
		}

        // Get all games with filtering
        private async Task<List<GameDto>> GetGamesAsync(int page, int pageSize, string? category, string? genre, string? developer, string? name, string? description)
        {
            var query = _context.Games.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(g => g.Categories.Any(c => c.Name.Contains(category.ToLower())));
            }
            if (!string.IsNullOrEmpty(genre))
            {
                query = query.Where(g => g.Genres.Any(ge => ge.Name.Contains(genre.ToLower())));
            }
            if (!string.IsNullOrEmpty(developer))
            {
                query = query.Where(g => g.Developers.Any(de => de.Name.Contains(developer.ToLower())));
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(g => g.Name.Contains(name.ToLower()));
            }
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(g => g.Description != null && g.Description.Contains(description.ToLower()));
            }

            var games = await query
                .AsSplitQuery()
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .Include(g => g.Categories)
                .Include(g => g.Images)
                .Include(g => g.Videos)
                .Include(g => g.GameVariations)
                    .ThenInclude(gv => gv.Games)
                .Include(g => g.Reviews)
                .Include(g => g.PlayTime)
                .Include(g => g.Platforms)
                .OrderBy(g => g.Name)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return _mapper.Map<List<GameDto>>(games);
        }

        // Overloaded methods for different filtering scenarios
        // Get all games without filters
        public async Task<List<GameDto>> GetGamesAsync(int page, int pageSize) =>
            await GetGamesAsync(page, pageSize, null, null, null, null, null);

        // Get games with specific filters
        public async Task<List<GameDto>> GetGamesFilteredAsync(int page, int pageSize, string? category, string? genre, string? developer ) =>
            await GetGamesAsync(page, pageSize, category, genre, developer, null, null);

        // Search games by name, description, developers, and genres
        public async Task<List<GameDto>> SearchGamesAsync(int page, int pageSize, string searchTerm) =>
            // TODO: fix this. We want to match each/or, NOT all!
            await GetGamesAsync(page, pageSize, null, null, null, searchTerm, null);

        // Get a specific game via id
        public async Task<GameDto> GetGameByIdAsync(Guid id)
        {
            var game = await _context.Games
                .AsSplitQuery()
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .Include(g => g.Categories)
                .Include(g => g.Images)
                .Include(g => g.Videos)
                .Include(g => g.GameVariations)
                    .ThenInclude(gv => gv.Games)
                .Include(g => g.Reviews)
                .Include(g => g.PlayTime)
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
                throw new Exception($"Game with id {id} not found");
            return _mapper.Map<GameDto>(game);
        }

        // Update game
        public async Task UpdateGameAsync(GameUpdateDto gameUpdateDto)
		{
            // We need to include for the resolver to properly map
            var game = await _context.Games
                .Include(g => g.Images)
                .Include(g => g.Videos)
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .Include(g => g.Categories)
                .Include(g => g.GameVariations)
                .Include(g => g.Reviews)
                .Include(g => g.PlayTime)
                .Include(g => g.Platforms)
                .FirstOrDefaultAsync(g => g.Id == gameUpdateDto.Id);
            if (game == null)
                throw new Exception($"Update failed. Game with id {gameUpdateDto.Id} not found");
            _mapper.Map(gameUpdateDto, game);
            _context.Games.Update(game);
			await _context.SaveChangesAsync();
		}

		// Delete game
		public void DeleteGame(Guid id)
		{
            var game = _context.Games.Find(id);
			if (game == null)
				return;
            _context.Games.Remove(game);
            _context.SaveChanges();
        }
	}
}
