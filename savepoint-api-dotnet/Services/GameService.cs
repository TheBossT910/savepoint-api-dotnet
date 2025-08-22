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
            // We need to include Developers and Genres for the resolver to properly map
            var game = _context.Games
                .Include(g => g.Developers)
                .Include(g => g.Genres)
                .FirstOrDefault(g => g.Id == gameUpdateDto.Id);
            if (game == null)
                throw new Exception($"Update failed. Game with id {gameUpdateDto.Id} not found");
            _mapper.Map(gameUpdateDto, game);
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
