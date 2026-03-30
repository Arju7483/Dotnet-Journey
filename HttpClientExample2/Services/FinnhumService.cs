using System.Text.Json;

namespace HttpClientExample2.Services
{
    public class FinnhumService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public FinnhumService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, object>> GetStock(string stockSymbol)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient();
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token=d6udj5pr01qp1k9c5dlgd6udj5pr01qp1k9c5dm0"),
                Method = HttpMethod.Get,
            };
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            string response = await responseMessage.Content.ReadAsStringAsync();
            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);
            if (responseDictionary == null)
                throw new InvalidOperationException("No response from finnhub server");

            if (responseDictionary.ContainsKey("error"))
                throw new InvalidOperationException(Convert.ToString(responseDictionary["error"]));

            return responseDictionary;
        }
    }
}
