namespace TaskTree.Models
{
    public class ProjectTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int AssigneeId { get; set; }
        public virtual User? Assignee { get; set; }
        public int ReporterId { get; set; }
        public virtual User? Reporter { get; set; }
        public int ProjectId { get; set; }
        public virtual Project? Project { get; set; }
    }
}
