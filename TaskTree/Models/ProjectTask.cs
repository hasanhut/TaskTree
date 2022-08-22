namespace TaskTree.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public User Assignee { get; set; }
        public User Reporter { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
