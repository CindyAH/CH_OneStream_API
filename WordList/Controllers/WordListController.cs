using Microsoft.AspNetCore.Mvc;

using WordList.Models;

namespace WordList.Controllers
{
    /// <summary>
    /// WordListController provides access to the WordList functionality and data
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WordListController : ControllerBase
    {
        private static readonly AllTheWords _words = new AllTheWords();
        private readonly ILogger<WordListController> _logger;

        public WordListController(ILogger<WordListController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Add a word to the list
        /// </summary>
        [HttpPost]
        public IActionResult AddWord([FromBody]string word)
        {
            Thread.Sleep(2000);

            _words.Words.Add(word);

            return Created(new Uri(Request.Path, UriKind.Relative), word);
        }

        /// <summary>
        /// Get the list of all the words
        /// </summary>
        /// <returns>List of all the words</returns>
        [HttpGet]
        public IActionResult Get()
        {
            Thread.Sleep(2000);

            return Ok(_words.Words.ToArray());
        }

    }
}