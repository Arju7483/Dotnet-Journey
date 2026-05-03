using AuthorizationExample.DTOs;
using AuthorizationExample.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")] // Good practice to prefix with 'api'
public class RegisterAndLoginController : ControllerBase
{
    // Use the standard UserManager
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public RegisterAndLoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager)
    {
        _userManager = userManager;
        _signInManager = singInManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDTO user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        ApplicationUser newUser = new ApplicationUser()
        {
            Email = user.Email,
            UserName = user.Email,
            PhoneNumber = user.Phone,
            FullName = user.Name,
            DOB = user.DOB // Ensure your ApplicationUser class actually has this property!
        };

        // ADVANCED: Always capture the IdentityResult
        IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(newUser, isPersistent: false);
            return Ok(new { Message = "User registration successful" });
        }

        // ADVANCED: Instead of just saying "it failed," return the specific Identity errors
        // (e.g., "Password requires a non-alphanumeric character")
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(error.Code, error.Description);
        }

        return BadRequest(ModelState);
    }
    [Route("sign-in")]
    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] SignInDTO user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _signInManager.PasswordSignInAsync(
            user.Email,
            user.Password,
            isPersistent: false,
            lockoutOnFailure: true);

        // 3. The Response: You must tell the user what happened
        if (result.Succeeded)
        {
            return Ok(new { Message = "Logged in successfully" });
        }

        if (result.IsLockedOut)
        {
            return StatusCode(StatusCodes.Status423Locked, "Account is locked.");
        }

        // Generic error for security (don't reveal if email vs password was wrong)
        return Unauthorized("Invalid login attempt.");
    }
    [Route("logout")]
    [HttpGet]
    public async Task LogOut()
    {
        await _signInManager.SignOutAsync();
    }

    [Authorize]
    [HttpGet("current-user")]
    public async Task<IActionResult> GetCurrentUser()
    {
        // current loggin user can be found from User or HttpContext.User
        var current = HttpContext.User;
        var current2 = User;
        // UserManager can get the full user object from the ClaimsPrincipal
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }
        var roles = await _userManager.GetRolesAsync(user);
        return Ok(new
        {
            user.Id,
            user.Email,
            user.FullName,
            user.DOB,
            user.PhoneNumber,
            Roles = roles
        });
    }
}