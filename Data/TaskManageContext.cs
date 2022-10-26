
using Data.Configuration;
using Domain;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class TaskManageContext : DbContext
    {
        public TaskManageContext(DbContextOptions<TaskManageContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Log_Activity> Log_Activity { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Persian_100_CS_AI");
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly);
        }

    }
}
