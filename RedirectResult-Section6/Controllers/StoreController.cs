using Microsoft.AspNetCore.Mvc;
namespace RedirectResult_Section6.Controllers
{
    [Controller]
    [Route("/store")]
    public class StoreController:Controller
    {
        [HttpGet("book/{id}")]
        public IActionResult GetBook(string id)
        {
            return Ok(new
            {
                BookId = id,
                BookName = $"Clean Architecture {id}"

            });
        }
        [HttpGet("electronics/{id}")]
        public IActionResult getElectronics(int id)
        {
            return Ok("Smart TV");
        }
    }
}
