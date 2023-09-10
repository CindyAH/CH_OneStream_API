namespace ToDoList.Models
{
    /// <summary>
    /// DTO for the ToDoDetail, showing only what the user needs to create a ToDo item.
    /// </summary>
    public class ToDo
    {
        /// <summary>
        /// ToDoItem (clean car, etc.)
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Hours it will take to complete the task
        /// </summary>
        public int Hours { get; set; }
    }
}

