namespace WordList.Models
{
    /// <summary>
    /// List of all the words that have been added
    /// </summary>
    public class AllTheWords
    {
        public List<string> Words { get; set; }

        public AllTheWords()
        {
            Words = new List<string>();
        }
    }
}
