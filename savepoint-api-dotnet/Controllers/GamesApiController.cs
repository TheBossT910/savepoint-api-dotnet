using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Services.Apis;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesApiController : ControllerBase
    {
        private readonly GamesIGDBApiService _gameApiService;
        public GamesApiController(GamesIGDBApiService gameApiService)
        {
            _gameApiService = gameApiService;
        }

        /// <summary>
        /// Gets games from IGDB. Throws an error if games cannot be fetched
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<IActionResult> GetGamesFromIGDBAsync()
        {
            return Ok(await _gameApiService.GetGames());
        }

        /// <summary>
        /// Gets game from IGDB based on slug. Throws an error if game cannot be fetched
        /// </summary>
        /// <returns></returns>
        [HttpPost("game")]
        public async Task<IActionResult> GetGameFromIGDBAsync([FromQuery] string slug)
        {
            return Ok(await _gameApiService.GetGame(slug));
        }
    }
}
