namespace ApiToDoJson.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public bool IsCompleted {  get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
