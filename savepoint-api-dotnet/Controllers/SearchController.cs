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
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult SearchGames([FromQuery] string searchTerm)
        {
            var gameDtos = _gameService.GetGames()
                .Where(g => g.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            g.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            g.Developers.Any(d => d.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                            g.Genres.Any(ge => ge.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                .ToList();
            return Ok(gameDtos);
        }
    }
}
