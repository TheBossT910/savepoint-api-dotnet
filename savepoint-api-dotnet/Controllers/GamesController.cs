using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Data;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Services;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        // TODO: create a GameService.cs file, where all logic happens
        private readonly GameService _gameService;

        // Dependency injection
        public GamesController(GameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Creates a new game. Throws an error if the game already exists in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult CreateGame([FromBody] Game game)
        {
            _gameService.AddGame(game);
            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        /// <summary>
        /// Gets all games in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetGames()
        {
            var games = _gameService.GetGames();
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
            var game = _gameService.GetGameById(id);
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
            _gameService.UpdateGame(game);
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
            _gameService.DeleteGame(id);
            return NoContent();
        }
    }
}
