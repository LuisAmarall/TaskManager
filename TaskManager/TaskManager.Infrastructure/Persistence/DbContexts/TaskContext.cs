using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Model;

namespace TaskManager.Infrastructure.Persistence.DbContexts;

public class TasksContext : DbContext
{
    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }

    public DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TasksContext).Assembly);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Tasks>()
            .HasQueryFilter(t => t.DeletedAt == null);
    }
}