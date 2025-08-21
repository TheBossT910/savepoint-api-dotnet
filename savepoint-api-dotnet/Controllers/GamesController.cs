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

        // Create
        [HttpPost("")]
        public IActionResult CreateGame()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        // Read
        [HttpGet("")]
        public IActionResult GetGames()
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        [HttpGet("{id}")]
        public IActionResult GetGame(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        // Update

        /// <summary>
        /// Logs in a user and returns a JWT token.
        /// </summary>
        /// <param name="request">Login request with username and password</param>
        /// <returns>JWT token if authentication is successful</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }
    }
}
