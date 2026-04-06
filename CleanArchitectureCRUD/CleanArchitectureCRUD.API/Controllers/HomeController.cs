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

        public HomeController(IPersonService personService)
        {
            _personService = personService;
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
    }
}