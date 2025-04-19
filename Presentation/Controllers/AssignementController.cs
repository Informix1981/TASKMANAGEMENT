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
        public async Task<IActionResult> Get()
        {
            var assignments = await _assignmentService.GetAllAsync();
            return Ok(assignments);
        }

        // GET api/<AssignementController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var assignment = await _assignmentService.GetByIdAsync(id);
            if (assignment == null)
            {
                return NotFound($"Assignment with ID {id} not found.");
            }
            return Ok(assignment);
        }

        // POST api/<AssignementController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Assignment value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAssignment = await _assignmentService.CreateAsync(value);
            return CreatedAtAction(nameof(Get), new { id = createdAssignment.Id }, createdAssignment);
        }

        // PUT api/<AssignementController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Assignment value)
        {
            if (id != value.Id)
            {
                return BadRequest("ID in the URL does not match the ID in the body.");
            }

            var existingAssignment = await _assignmentService.GetByIdAsync(id);
            if (existingAssignment == null)
            {
                return NotFound($"Assignment with ID {id} not found.");
            }

            await _assignmentService.UpdateAsync(value);
            return NoContent();
        }

        // DELETE api/<AssignementController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingAssignment = await _assignmentService.GetByIdAsync(id);
            if (existingAssignment == null)
            {
                return NotFound($"Assignment with ID {id} not found.");
            }

            await _assignmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}