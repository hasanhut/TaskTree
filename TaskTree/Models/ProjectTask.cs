namespace TaskTree.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User? Assignee { get; set; }
        public User? Reporter { get; set; }
    }
}
