using AuthorizationExample.DTOs;
using AuthorizationExample.IdentityEntities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace AuthorizationExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleManagementController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleManagementController(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("create-role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.RoleName))
                return BadRequest("Role name is required.");

            var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);
            if (roleExist)
                return BadRequest("Role already exists.");

            var newRole = new ApplicationRole { Name = request.RoleName };
            var result = await _roleManager.CreateAsync(newRole);

            if (result.Succeeded)
                return Ok(new { Message = "Role Created Successfully" });

            return StatusCode(500, result.Errors);
        }

        [HttpPost("assign-role")]
        public async Task<IActionResult> AssignUserToRole([FromBody] AssignRoleRequestDTO request)
        {
            var user = await _userManager.FindByEmailAsync(request.UserEmail);
            if (user == null)
                return NotFound("User not found.");

            var roleExist = await _roleManager.RoleExistsAsync(request.RoleName);
            if (!roleExist)
                return NotFound("Role does not exist.");

            if (await _userManager.IsInRoleAsync(user, request.RoleName))
                return BadRequest("User is already assigned to this role.");

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);

            if (result.Succeeded)
                return Ok(new { Message = $"User assigned to role {request.RoleName} successfully." });

            return StatusCode(500, result.Errors);
        }
    }
}
