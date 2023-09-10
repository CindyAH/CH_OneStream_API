using Microsoft.AspNetCore.Mvc;

using ToDoList.Models;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private static readonly AllTheToDos _toDos = new ();
        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Add a new ToDo item, using a DTO to avoid having the user supply the ID.
        /// </summary>
        /// <param name="todo">The user-visible portions of the ToDo list</param>
        [HttpPost]
        public IActionResult AddToDo([FromBody] ToDo toDo)
        {
            Thread.Sleep(2000);

            _toDos.ToDoDetails.Add(new ToDoDetail(toDo));

            return Created(new Uri(Request.Path, UriKind.Relative), toDo);
        }

        /// <summary>
        /// Get all the items in the ToDoList.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetList()
        {
            Thread.Sleep(2000);

            return Ok(_toDos.ToDoDetails.ToArray());
        }

        /// <summary>
        /// Get the total time it will take to do all the ToDos on the list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Time")]
        public IActionResult GetTotalTime()
        {
            Thread.Sleep(2000);

            return Ok(_toDos.TimeToComplete());
        }
    }
}