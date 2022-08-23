using Microsoft.EntityFrameworkCore;
using TaskTree.Models;

namespace TaskTree.Helpers
{
    public class DataContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProjectTask>()
        //        .HasOne<Project>(pr => pr.Project)
        //        .WithMany(p => p.ProjectTasks)
        //        .HasForeignKey(pr => pr.ProjectId)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}



        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }
}
