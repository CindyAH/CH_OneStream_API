namespace ToDoList.Models
{
    /// <summary>
    /// The complete ToDo item, including the Id key.
    /// </summary>
    public class ToDoDetail
    {
#warning _nextId is temporary code until there is a real datastore.
        private static int _nextId;

        /// <summary>
        /// ID, will eventually come from the data store but just incremented for now
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ToDoItem (clean car, etc.)
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Hours it will take to complete the task
        /// </summary>
        public int Hours { get; set; }

        /// <summary>
        /// Create a ToDoDetail from a ToDo.
        /// </summary>
        /// <param name="toDo"></param>
        public ToDoDetail(ToDo toDo)
        {
            Id = _nextId++;
            Item = toDo.Item;
            Hours = toDo.Hours;
        }
        public ToDoDetail()
        {

        }
    }
}
