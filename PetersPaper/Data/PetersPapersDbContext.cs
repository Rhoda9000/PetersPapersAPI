using Microsoft.EntityFrameworkCore;
using PetersPaper.Data.Maps;
using PetersPaper.Data.Models;

namespace PetersPaper.Data
{
    public class PetersPapersDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().HasQueryFilter(i => !i.IsDeleted);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new DepartmentMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new TaskStatusMap());

        }

        public PetersPapersDbContext(DbContextOptions<PetersPapersDbContext> options) : base(options)
        {

        }
    }
}
