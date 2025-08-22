using savepoint_api_dotnet.Data;
using System;
using savepoint_api_dotnet.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using savepoint_api_dotnet.Dtos.Games;

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

            // Many-to-many: Developers
            if (gameCreateDto.DeveloperIds != null && gameCreateDto.DeveloperIds.Any())
            {
                game.Developers = _context.Developers
                    .Where(d => gameCreateDto.DeveloperIds.Contains(d.Id))
                    .ToList();
            }

            // Many-to-many: Genres
            if (gameCreateDto.GenreIds != null && gameCreateDto.GenreIds.Any())
            {
                game.Genres = _context.Genres
                    .Where(g => gameCreateDto.GenreIds.Contains(g.Id))
                    .ToList();
            }

            // One-to-many: Images
            if (gameCreateDto.Images != null && gameCreateDto.Images.Any())
            {
                game.Images = gameCreateDto.Images
                    .Select(i => _mapper.Map<Image>(i))
                    .ToList();
            }

            // One-to-many: Videos
            if (gameCreateDto.Videos != null && gameCreateDto.Videos.Any())
            {
                game.Videos = gameCreateDto.Videos
                    .Select(v => _mapper.Map<Video>(v))
                    .ToList();
            }

            _context.Games.Add(game);
			_context.SaveChanges();
            return _mapper.Map<GameDto>(game);
		}

        // Get all games
        public List<GameDto> GetGames()
        {
            var games = _context.Games
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .Include(g => g.Images)
                .Include(g => g.Videos)
                .ToList();
            return _mapper.Map<List<GameDto>>(games);
        }

        // Get a specific game via id
        public GameDto GetGameById(Guid id)
        {
            var game = _context.Games
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .Include(g => g.Images)
                .Include(g => g.Videos)
                .FirstOrDefault(g => g.Id == id);
            if (game == null)
                throw new Exception($"Game with id {id} not found");
            return _mapper.Map<GameDto>(game);
        }

        // Update game
        public void UpdateGame(GameUpdateDto gameUpdateDto)
		{
            var game = _mapper.Map<Game>(gameUpdateDto);

            // Many-to-many: Developers
            if (gameUpdateDto.DeveloperIds != null && gameUpdateDto.DeveloperIds.Any())
            {
                game.Developers = _context.Developers
                    .Where(d => gameUpdateDto.DeveloperIds.Contains(d.Id))
                    .ToList();
            }

            // Many-to-many: Genres
            if (gameUpdateDto.GenreIds != null && gameUpdateDto.GenreIds.Any())
            {
                game.Genres = _context.Genres
                    .Where(g => gameUpdateDto.GenreIds.Contains(g.Id))
                    .ToList();
            }

            // One-to-many: Images
            if (gameUpdateDto.Images != null && gameUpdateDto.Images.Any())
            {
                game.Images = gameUpdateDto.Images
                    .Select(i => _mapper.Map<Image>(i))
                    .ToList();
            }

            // One-to-many: Videos
            if (gameUpdateDto.Videos != null && gameUpdateDto.Videos.Any())
            {
                game.Videos = gameUpdateDto.Videos
                    .Select(v => _mapper.Map<Video>(v))
                    .ToList();
            }

            _context.Games.Update(game);
			_context.SaveChanges();
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
