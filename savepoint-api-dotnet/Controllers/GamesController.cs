using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Services;
using savepoint_api_dotnet.Dtos.Games;

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
        public IActionResult CreateGame([FromBody] GameCreateDto gameCreateDto)
        {
            var createdGameDto = _gameService.AddGame(gameCreateDto);
            return CreatedAtAction(nameof(GetGame), new { id = createdGameDto.Id }, createdGameDto);
        }

        /// <summary>
        /// Gets all games in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetGames([FromQuery] string category, [FromQuery] string genre, [FromQuery] string developer)
        {
            var gameDtos = _gameService.GetGames()
                // TODO: implement category filtering
                .Where(g => string.IsNullOrEmpty(genre) || 
                    g.Genres.Any(ge => ge.Name.Equals(genre, StringComparison.OrdinalIgnoreCase)))
                .Where(g => string.IsNullOrEmpty(developer) ||
                    g.Developers.Any(de => de.Name.Equals(developer, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            return Ok(gameDtos);
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
            var gameDto = _gameService.GetGameById(id);
            return Ok(gameDto);
        }

        /// <summary>
        /// Updates a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpPut("")]
        public IActionResult UpdateGame([FromBody] GameUpdateDto gameUpdateDto)
        {
            _gameService.UpdateGame(gameUpdateDto);
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
