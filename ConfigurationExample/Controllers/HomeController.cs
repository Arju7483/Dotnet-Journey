using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace ConfigurationExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Route("/")]
        public IActionResult Index()
        {
            // access MyKey from appsetting
            //string value = _configuration["MyKey"];
            string value = _configuration.GetValue<string>("MyKey");
            // accessing master key
            var master = _configuration.GetSection("MyMasterKey");
            // accessing subkey
            string subkey = _configuration["MyMasterKey:Subkey1"];
            return View(model:value);
        }
        [Route("GetSection")]
        public IActionResult GetSecionExample()
        {
            var emailSecion = _configuration.GetSection("EmailSettings");
            var result = new
            {
                Host = emailSecion["Host"],
                Port = emailSecion["Port"]
            };
            return Ok(result);
        }
    }
}
