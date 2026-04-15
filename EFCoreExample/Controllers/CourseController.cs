using EFCoreExample.Entities;
using EFCoreExample.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            await _courseService.AddCourse(course);
            return Ok("Course added successfully");
        }

        [HttpGet("GetAllCourse")]
        public async Task<IActionResult> GetAllCourse()
        {
            var courses = await _courseService.GetAllCourse();
            return Ok(courses);
        }

        [HttpGet("GetCourseById/{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            return Ok(course);
        }
    }
}
