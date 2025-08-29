using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Models;
using savepoint_api_dotnet.Services;
using savepoint_api_dotnet.Dtos.Games;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StacksController : ControllerBase
    {
        private readonly StackService _stackService;

        // Dependency injection
        public StacksController(StackService stackService)
        {
            _stackService = stackService;
        }

        /// <summary>
        /// Gets all stacks in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetStacks()
        {
            var stackDtos = _stackService.GetStacks();
            return Ok(stackDtos);
        }

        /// <summary>
        /// Gets a specific stack
        /// </summary>
        /// <param name="id">
        /// Stack's id
        /// </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetStack(Guid id)
        {
            var stackDto = _stackService.GetStackById(id);
            return Ok(stackDto);
        }
    }
}
