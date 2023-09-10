using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrontEndController : ControllerBase
    {
        private const string WordListRequestUri = "https://localhost:7004/WordList";
        HttpClient _httpClient;
        private readonly ILogger<FrontEndController> _logger;

        public FrontEndController(ILogger<FrontEndController> logger)
        {
            _logger = logger;
            _httpClient = new();
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddWord([FromBody] string word)
        {
            var response = await _httpClient.PostAsync(WordListRequestUri, JsonContent.Create(word));

            return response;
        }

        [HttpGet(Name = "GetWordList")]
        public async Task<List<string>> Get()
        {
            var response = await _httpClient.GetAsync(WordListRequestUri);

            var content = await response.Content.ReadAsStringAsync();
            var words = JsonConvert.DeserializeObject<List<string>>(content);

            return words ?? new List<string>();
        }
    }
}