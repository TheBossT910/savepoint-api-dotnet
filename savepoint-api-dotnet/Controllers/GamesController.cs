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
        /// <param name="page">
        /// The page number (0-indexed)
        /// </param>
        /// <param name="pageSize">
        /// The number of items per page
        /// </param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetGames([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string? category, [FromQuery] string? genre, [FromQuery] string? developer)
        {
            var gameDtos = await _gameService.GetGamesFilteredAsync(page, pageSize, category, genre, developer);
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
        public async Task<IActionResult> GetGame(Guid id)
        {
            var gameDto = await _gameService.GetGameByIdAsync(id);
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
        public async Task<IActionResult> UpdateGame([FromBody] GameUpdateDto gameUpdateDto)
        {
            await _gameService.UpdateGameAsync(gameUpdateDto);
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
