using Application.Service.PersistenceDb.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignementController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssignementController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }
        // GET: api/<AssignementController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get Assignement");
        }
        // GET api/<AssignementController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Get Assignement with id {id}");
        }
        // POST api/<AssignementController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Assignment value)
        {
            return Ok($"Post Assignement with value {value}");
        }
        // PUT api/<AssignementController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok($"Put Assignement with id {id} and value {value}");
        }
        // DELETE api/<AssignementController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok($"Delete Assignement with id {id}");
        }
    }
}
