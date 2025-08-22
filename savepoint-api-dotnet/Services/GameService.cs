using savepoint_api_dotnet.Data;
using System;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Services
{
    public class GameService
	{
        private readonly SavePointDbContext _context;
        public GameService(SavePointDbContext context)
		{
			_context = context;
		}

		// Add game
		public Game AddGame(Game game)
		{
			_context.Games.Add(game);
			_context.SaveChanges();
            return game;
		}

        // Get all games
        public List<Game> GetGames()
        {
            return _context.Games.ToList();
        }

        // Get a specific game via id
        public Game GetGameById(Guid id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
                throw new Exception($"Game with id {id} not found");
            return game;
        }

        // Update game
        public void UpdateGame(Game game)
		{
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
