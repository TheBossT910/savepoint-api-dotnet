using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Models;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        // TODO: create a GameService.cs file, where all logic happens
        private readonly ApplicationDbContext _context;

        // Dependency injection
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new game. Throws an error if the game already exists in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult CreateGame([FromBody] Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        /// <summary>
        /// Gets all games in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetGames()
        {
            var games = _context.Games.ToList();
            return Ok(games);
        }

        /// <summary>
        /// Gets a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetGame(Guid id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        /// <summary>
        /// Updates a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpPut("")]
        public IActionResult UpdateGame([FromBody] Game game)
        {
            _context.Games.Update(game);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(Guid id)
        {
            var game = _context.Games.Find(id);
            if (game == null)
            {
                return NotFound();
            }
            _context.Games.Remove(game);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
