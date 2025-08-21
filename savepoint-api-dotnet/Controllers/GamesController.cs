using Microsoft.AspNetCore.Mvc;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GamesController : ControllerBase
    {
        // Dependency injection
        public GamesController()
        {
            // No dependencies yet
        }

        /// <summary>
        /// Creates a new game. Throws an error if the game already exists in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult CreateGame()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Gets all games in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetGames()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Gets a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetGame(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Updates a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        /// <summary>
        /// Deletes a specific game
        /// </summary>
        /// <param name="id">
        /// Game's id
        /// </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
