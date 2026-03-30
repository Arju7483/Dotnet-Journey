using Microsoft.AspNetCore.Mvc;

namespace EnvironmentSpecificConfigurationAndSecretManager.Controllers
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
            return Ok($"{ _configuration["EnvironmentSettings:ClientID"]} \n {_configuration["Secrets:UserSecret"]}");
        }
        [Route("secrets")]
        public IActionResult UserSecrets()
        {
            return Ok(_configuration["Secrets:UserSecret"]);
        }
    }
}
