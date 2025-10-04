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
        public async Task<IActionResult> GetGamesFromIGDBAsync([FromQuery] Boolean saveToDatabase)
        {
            var games = await _gameApiService.GetGames();
            if (saveToDatabase)
            {
                await _gameApiService.SaveGamesToDatabase(games);
                return Ok();
            }

            return Ok(games);
        }

        /// <summary>
        /// Gets games from IGDB based on a custom field. Throws an error if games cannot be fetched
        /// </summary>
        /// <returns></returns>
        [HttpPost("games/custom")]
        public async Task<IActionResult> GetGamesCustomFromIGDBAsync([FromQuery] Boolean saveToDatabase, [FromQuery] string field)
        {
            var games = await _gameApiService.GetGamesCustom(field);
            if (saveToDatabase)
            {
                await _gameApiService.SaveGamesToDatabase(games);
                return Ok();
            }

            return Ok(games);
        }

        /// <summary>
        /// Gets game from IGDB based on slug. Throws an error if game cannot be fetched
        /// </summary>
        /// <returns></returns>
        [HttpPost("game")]
        public async Task<IActionResult> GetGameFromIGDBAsync([FromQuery] Boolean saveToDatabase, [FromQuery] string slug)
        {
            var game = (await _gameApiService.GetGame(slug)).First();
            if (saveToDatabase && game != null)
            {
                await _gameApiService.SaveGamesToDatabase(new List<Game>() { game });
                return Ok();
            }

            return Ok(game);
        }
    }
}
