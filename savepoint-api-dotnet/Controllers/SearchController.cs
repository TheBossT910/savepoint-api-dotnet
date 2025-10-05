using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Services;
using savepoint_api_dotnet.Dtos.Games;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly GameService _gameService;

        // Dependency injection
        public SearchController(GameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Returns search results for games
        /// </summary>
        /// <param name="searchTerm">
        /// Search term to look for in game names, descriptions, developers, and genres
        /// </param>
        /// <param name="searchDescription">
        /// Enable searching using description
        /// </param>
        /// <param name="searchDevelopers">
        /// Enable searching using developers
        /// </param>
        /// <param name="searchGenres">
        /// Enable searching using genres
        /// </param>
        /// <returns></returns>
        [HttpGet("games")]
        public async Task<IActionResult> SearchGames([FromQuery] string searchTerm)
        {
            var gameDtos = await _gameService.SearchGamesAsync(0, 50, searchTerm);
            return Ok(gameDtos);
        }
    }
}
