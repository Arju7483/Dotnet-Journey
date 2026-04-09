using CleanArchitectureCRUD.Application.DTOs;
using CleanArchitectureCRUD.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureCRUD.API.Controllers
{
    [ApiController] 
    [Route("api/[controller]")] 
    public class HomeController : ControllerBase 
    {
        private readonly IPersonService _personService;
        private readonly ICourseService _courseService;
        public HomeController(IPersonService personService, ICourseService courseService)
        {
            _personService = personService;
            _courseService = courseService;
        }

        [HttpGet] 
        [Route("/")]
        public IActionResult Index()
        {
            return Ok("API is running smoothly!");
        }

        [HttpPost]
        [Route("/add")]
        public async Task<PersonResponse> AddPerson([FromBody] PersonAddRequest request)
        {
            return await _personService.AddPerson(request);
        }
        [HttpGet]
        [Route("/getall")]
        public async Task<List<PersonResponse>> GetAllPerson()
        {
            return await _personService.GetAllPerson();
        }
        [HttpPut]
        [Route("/update")]
        public async Task<PersonResponse> UpdatePerson(PersonUpdateRequest request)
        {
            return await _personService.UpdatePerson(request);
        }
        [HttpGet]
        [Route("/all-course")]
        public async Task<List<CourseResponse>> GetAllCourse()
        {
            return await _courseService.GetAllCourses();

        }
        //[HttpPost]
        //[Route("/add-student")]
        //public async Task<StudentResponse> AddStudent([FromBody] StudentAddRequest request)
        //{

        //}
    }
}