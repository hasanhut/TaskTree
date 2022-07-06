namespace TaskTree.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /*
        public Requirement Requirement
        public MileStone MileStone
        */
    }
}
