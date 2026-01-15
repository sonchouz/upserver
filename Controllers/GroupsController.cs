using Microsoft.AspNetCore.Mvc;
using upserver.Data;
using upserver.DTO;

namespace upserver.Controllers
{
    [ApiController]
    [Route("api")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _service;

        public GroupsController(IGroupsService service, AppDbContext db)
        {
            _service = service;
        }

        [HttpGet("group")]
        public async Task<IActionResult> GetGroups()
        {
            var result = await _service.GetGroups();
            return Ok(result);
        }
    }
}
