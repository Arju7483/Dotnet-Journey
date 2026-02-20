using Microsoft.AspNetCore.Mvc;
using SectionSeven_assignment.Models;
using System.Security.Cryptography;

namespace SectionSeven_assignment.Controllers
{
    [Controller]
    public class OrderController : Controller
    {
        [HttpPost("/order")]
        public IActionResult CreateOrder([FromBody] Order order)
        {
            if (ModelState.IsValid)
            {
                var orderId = RandomNumberGenerator.GetInt32(0, 100000);
                order.OrderNo = orderId;
                var response = new
                {
                    OrderNumber = orderId,
                };
                return Ok(response);
            }
            return BadRequest(ModelState);
        }
    }
}
