using Microsoft.AspNetCore.Mvc;
namespace RedirectResult_Section6.Controllers
{
    [Controller]
    [Route("/bookstore")]
    public class HomeController : Controller
    {
        // example of RedirectToActionResult
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            // manually creating the action result object
             return new RedirectToActionResult("GetBook", "Store", new {id = id},true);

            // using helper method
            // 1.move temporary
            // return RedirectToAction("GetBook", "Store", new {id = id});
            // 2.move parmanently
            // return RedirectToActionPermanent("GetBook", "Store", new { id = id });

        }

        // example of RedirectResult
        [HttpGet("novel/{id}")]
        public IActionResult GetBookById(int id)
        {
            // redirection to external URL 
            // return new RedirectResult($"https://www.britannica.com/art/novel");

            // redirect to local url
            return new RedirectResult($"/store/book/novel-{id}",permanent:true,preserveMethod:true);
        }
    }
}
