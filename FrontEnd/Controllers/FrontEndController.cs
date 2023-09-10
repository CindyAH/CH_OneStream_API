using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using ToDoList.Models;

namespace FrontEnd.Controllers
{
    /// <summary>
    /// FrontEndController calls the APIs for WordList and ToDoList.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class FrontEndController : ControllerBase
    {
        private readonly string WordListUri;
        private readonly string ToDoListUri;
        HttpClient _httpClient;
        private readonly ILogger<FrontEndController> _logger;
        private readonly IConfiguration _configuration;

        public FrontEndController(IConfiguration configuation, ILogger<FrontEndController> logger)
        {
            _logger = logger;
            _configuration = configuation;
            _httpClient = new();

            WordListUri = _configuration.GetValue<string>($"ExternalProviders:{nameof(WordListUri)}");
            ToDoListUri = _configuration.GetValue<string>($"ExternalProviders:{nameof(ToDoListUri)}");
        }

        /// <summary>
        /// Call the WordList API to add a new word to the list
        /// </summary>
        [HttpPost]
        [Route("PostWord")]
        public async Task<HttpResponseMessage> AddWord([FromBody] string word)
        {
            var response = await _httpClient.PostAsync(WordListUri, JsonContent.Create(word));
            return response;
        }

        /// <summary>
        /// Get the list of all the words from the word list
        /// </summary>
        [HttpGet]
        [Route("GetWordList")]
        public async Task<List<string>> GetWords()
        {
            var response = await _httpClient.GetAsync(WordListUri);

            var content = await response.Content.ReadAsStringAsync();
            var words = JsonConvert.DeserializeObject<List<string>>(content);

            return words ?? new List<string>();
        }

        /// <summary>
        /// Add a new ToDo item, using a DTO to avoid having the user supply the ID.
        /// </summary>
        /// <param name="todo">The user-visible portions of the ToDo list</param>
        [HttpPost]
        [Route("PostToDo")]
        public async Task<HttpResponseMessage> AddToDo([FromBody] ToDo todo)
        {
            var response = await _httpClient.PostAsync(ToDoListUri, JsonContent.Create(todo));
            return response;
        }

        /// <summary>
        /// Get all the ToDos on the ToDoList.
        /// </summary>
        [HttpGet]
        [Route("GetToDoList")]
        public async Task<List<ToDoDetail>> GetToDoList()
        {
            var response = await _httpClient.GetAsync(ToDoListUri);

            var content = await response.Content.ReadAsStringAsync();
            var toDos = JsonConvert.DeserializeObject<List<ToDoDetail>>(content);

            return toDos ?? new List<ToDoDetail>();
        }

        /// <summary>
        /// Get the total time required to do everything on the ToDoList.
        /// </summary>
        [HttpGet]
        [Route("GetToDoTime")]
        public async Task<string> GetToDoTime()
        {
            var response = await _httpClient.GetAsync(ToDoListUri + "/Time");

            var content = await response.Content.ReadAsStringAsync();
            var hours = Convert.ToInt32(content ?? "0");

            return $"It will take {hours} hours to finish everything on the list.";
        }
    }
}