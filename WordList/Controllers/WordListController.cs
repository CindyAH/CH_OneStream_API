using Microsoft.AspNetCore.Mvc;

using WordList.Models;

namespace WordList.Controllers
{
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
        [HttpPost]
        public IActionResult AddWord([FromBody]string word)
        {
            Thread.Sleep(2000);

            _words.Words.Add(word);

            return Created(new Uri(Request.Path, UriKind.Relative), word);
        }

        [HttpGet(Name = "GetWordList")]
        public IActionResult Get()
        {
            Thread.Sleep(2000);

            return Ok(_words.Words.ToArray());
        }

    }
}