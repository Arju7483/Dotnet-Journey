using EFCoreExample.Entities;
using EFCoreExample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost("AddInstructor")]
        public async Task<IActionResult> AddInstructor([FromBody] Instructor instructor)
        {
            await _instructorService.AddInstructor(instructor);
            return Ok("Instructor added successfully");
        }

        [HttpGet("GetAllInstructor")]
        public async Task<IActionResult> GetAllInstructor()
        {
            var instructors = await _instructorService.GetAllInstructor();
            return Ok(instructors);
        }

        [HttpGet("GetInstructorById/{id}")]
        public async Task<IActionResult> GetInstructorById(Guid id)
        {
            var instructor = await _instructorService.GetInstructorById(id);
            if (instructor == null)
            {
                return NotFound("Instructor not found");
            }
            return Ok(instructor);
        }
    }
}

