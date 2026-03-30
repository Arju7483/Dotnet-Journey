using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.Marshalling;

namespace HttpClientExample.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();

            // 2. Setup the request
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://jsonplaceholder.typicode.com/todos/1"),
                Method = HttpMethod.Get,
            };

            // 3. Capture as HttpResponseMessage
            using (HttpResponseMessage response = await httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    // 4. Read the actual body content
                    var content = await response.Content.ReadAsStringAsync();

                    // 5. Return the data, not the response object itself
                    return Ok(content);
                }

                return StatusCode((int)response.StatusCode, "Failed to fetch data.");
            }
        }

    }
}
