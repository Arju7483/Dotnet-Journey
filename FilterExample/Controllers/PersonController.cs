using FilterExample.Entities;
using FilterExample.Services;
using FilterExample.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FilterExample.Filters.ActionFilters;
using FilterExample.Filters.Authorization_Filters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace FilterExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    [TypeFilter(typeof(PersonActionFilter))]
    // filter with argument
    [TypeFilter(typeof(CustomActionFilerWithArgument), Arguments = new Object[] {1})]


    [HttpPost("add")]
    public async Task<IActionResult> AddPerson([FromBody] AddPersonDto personDto)
    {
        if (personDto == null)
        {
            return BadRequest("Person data is null.");
        }

        var result = await _personService.AddPersonAsync(personDto);
        
        return Ok(new { message = "Person added successfully", data = result });
    }

    [HttpGet("all")]
    [TypeFilter(typeof(CustomActionFilerWithArgument), Arguments = new Object[] { 2 })]
    // authorization filter
    [TypeFilter(typeof(TokenAuthorization))]
    public async Task<IActionResult> GetAllPersons()
    {
        var persons = await _personService.GetAllPersonsAsync();
        return Ok(persons);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonById(Guid id)
    {
        var person = await _personService.GetPersonByIdAsync(id);
        if (person == null)
        {
            return NotFound($"Person with Id {id} not found.");
        }
        return Ok(person);
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "User"),
            new Claim(ClaimTypes.Role, "Admin"),
        };

        var claimsIdentity = new ClaimsIdentity(claims, "MyCookieAuth");

        await HttpContext.SignInAsync("MyCookieAuth", new ClaimsPrincipal(claimsIdentity));

        return Ok(new { message = "Logged in successfully. Cookie 'Auth-key' has been set." });
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("MyCookieAuth");
        return Ok(new { message = "Logged out successfully." });
    }
}
