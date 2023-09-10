namespace ToDoList.Models
{
    /// <summary>
    /// AllTheToDos is a list of everything that needs to be done.
    /// </summary>
    public class AllTheToDos
    {
        /// <summary>
        /// List of each ToDo item
        /// </summary>
        public List<ToDoDetail> ToDoDetails { get; set; }

        public AllTheToDos() 
        {
            ToDoDetails = new List<ToDoDetail>();
        }

        /// <summary>
        /// Summary of all the times in the ToDoList
        /// </summary>
        public int TimeToComplete()
        {
            return ToDoDetails.Select(t => t.Hours).Sum();
        }
    }
}
