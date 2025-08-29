using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Dtos.Games;
using savepoint_api_dotnet.Dtos.Stacks;
using savepoint_api_dotnet.Services;

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
        /// Creates a new stack. Throws an error if the stack already exists in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult CreateStack([FromBody] StackCreateDto stackCreateDto)
        {
            var createdStackDto = _stackService.AddStack(stackCreateDto);
            return CreatedAtAction(nameof(GetStack), new { id = createdStackDto.Id }, createdStackDto);
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

        /// <summary>
        /// Updates a specific stack
        /// </summary>
        /// <param name="id">
        /// Stack's id
        /// </param>
        /// <returns></returns>
        [HttpPut("")]
        public IActionResult UpdateStack([FromBody] StackUpdateDto stackUpdateDto)
        {
            _stackService.UpdateStack(stackUpdateDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific stack
        /// </summary>
        /// <param name="id">
        /// Stack's id
        /// </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteStack(Guid id)
        {
            _stackService.DeleteStack(id);
            return NoContent();
        }
    }
}
