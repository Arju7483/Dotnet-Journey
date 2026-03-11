using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OptionsPatternExample.Models;

namespace OptionsPatternExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly EmailSettings _emailSettings;
        public HomeController(IConfiguration configuration, IOptions<EmailSettings>settings)
        {
            _configuration = configuration;
            _emailSettings = settings.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            EmailSettings result = new EmailSettings()
            {
                Host = _emailSettings.Host,
                Port = _emailSettings.Port
            };
            return Ok(result);
        }

    }
}
