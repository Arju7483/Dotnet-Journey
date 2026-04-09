using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCRUD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        { 
            _courseService = courseService;
        }
        [HttpPost]
        [Route("add")]
        public async Task<CourseResponse> AddCourse([FromBody] CourseAddRequest request)
        {
            return await _courseService.AddCourse(request);
        }
        [HttpGet]
        [Route("/get")]
        public async Task<CourseResponse> GetById(string id)
        {
            Guid courseId = Guid.Parse(id);
            return await _courseService.GetCourseById(courseId);
        }
    }
}
