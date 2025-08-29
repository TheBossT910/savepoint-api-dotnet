using Microsoft.AspNetCore.Mvc;
using savepoint_api_dotnet.Dtos.Lists;
using savepoint_api_dotnet.Services;

namespace savepoint_api_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListsController : ControllerBase
    {
        private readonly ListService _listService;

        // Dependency injection
        public ListsController(ListService listService)
        {
            _listService = listService;
        }

        /// <summary>
        /// Creates a new list. Throws an error if the list already exists in the database
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public IActionResult CreateList([FromBody] ListCreateDto listCreateDto)
        {
            var createdListDto = _listService.AddList(listCreateDto);
            return CreatedAtAction(nameof(GetList), new { id = createdListDto.Id }, createdListDto);
        }

        /// <summary>
        /// Gets all lists in the database
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public IActionResult GetLists()
        {
            var listDtos = _listService.GetLists();
            return Ok(listDtos);
        }

        /// <summary>
        /// Gets a specific list
        /// </summary>
        /// <param name="id">
        /// List's id
        /// </param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetList(Guid id)
        {
            var listDto = _listService.GetListById(id);
            return Ok(listDto);
        }

        /// <summary>
        /// Updates a specific list
        /// </summary>
        /// <param name="id">
        /// List's id
        /// </param>
        /// <returns></returns>
        [HttpPut("")]
        public IActionResult UpdateList([FromBody] ListUpdateDto listUpdateDto)
        {
            _listService.UpdateList(listUpdateDto);
            return NoContent();
        }

        /// <summary>
        /// Deletes a specific list
        /// </summary>
        /// <param name="id">
        /// List's id
        /// </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteList(Guid id)
        {
            _listService.DeleteList(id);
            return NoContent();
        }
    }
}
