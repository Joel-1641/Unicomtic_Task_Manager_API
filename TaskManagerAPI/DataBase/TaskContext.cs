using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.DataBase
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(a => a.Address)
            .WithOne(b => b.User)
            .HasForeignKey<Address>(c => c.userId);

            modelBuilder.Entity<TaskItem>()
           .HasOne(o => o.Assignee)
           .WithMany(p => p.Tasks)
           .HasForeignKey(o => o.AssigneeId);

            modelBuilder.Entity<TaskItem>()
            .HasMany(a => a.CheckList)
            .WithOne(a => a.Task)
            .HasForeignKey(o => o.TaskId);
            

            base.OnModelCreating(modelBuilder);

         

        }
        public DbSet<TaskManagerAPI.Models.UserLogin> UserLogin { get; set; } = default!;


    }
}
