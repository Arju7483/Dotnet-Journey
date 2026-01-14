using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("myApi/[controller]")]
    public class OrderController: ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult GetOrderById(int id)
        {
            return Ok($"No order found for {id}");
        }

        // handling multiple route parameter
        [HttpGet("Gender/{gender}/City/{city}")]
        public ActionResult GetOrderByGenderAndCity(string gender, string city)
        {
            return Ok($"Order for {gender} and {city} is not found");
        }
        // multiple endpoints for same method
        [HttpGet("All")]
        [HttpGet("GetAll")]
        [HttpGet("AllOrder")]
        public ActionResult GetOrderUsingMultipleEndpoint()
        {
            return Ok("This is exmple for multiple endpoint for same method");
        }
        // routing constraint
        // FIX: Removed the space in :int
        [HttpGet("Customer/{id:int}")]
        public ActionResult GetCustomerById(int id)
        {
            return Ok($"customer with id {id} is not found");
        }

        [HttpGet("Customer/{name}")]
        public ActionResult GetCustomerByName(string name)
        {
            return Ok($"customer with name {name} is not found");
        }
        [HttpGet("Customer/{customerCode:regex(^CUS-[[0-9]]{{5}}$)}")]
        public ActionResult GetProductByCode(string customerCode)
        {
            return Ok($"Your product code id {customerCode}");
        }

    }
}
