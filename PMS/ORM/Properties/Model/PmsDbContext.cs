using System.Data.Entity;

namespace ORM.Properties.Model
{
    public class PmsDbContext : DbContext
    {
        public PmsDbContext() : base("PmsDatabase") { }

        public DbSet<OrmProject> Projects { get; set; }
        public DbSet<OrmUser> Users { get; set; }
        public DbSet<OrmTask> Tasks { get; set; }
        public DbSet<OrmTaskAssignee> TaskAssignees { get; set; }
        public DbSet<OrmComment> Comments { get; set; }
        public DbSet<OrmProjectMember> ProjectMembers { get; set; }
        public DbSet<OrmTimeLog> TimeLogs { get; set; }
    }
}
