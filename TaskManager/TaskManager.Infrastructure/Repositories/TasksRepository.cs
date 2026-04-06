using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Model;
using TaskManager.Infrastructure.Persistence.DbContexts;

namespace TaskManager.Infrastructure.Repositories;

public class TasksRepository : ITasksRepository
{
    public TasksRepository(TasksContext context)
    {
        _context = context;
    }

    private readonly TasksContext _context;

    public async Task AddAsync(Tasks tasks)
    {
        await _context.Tasks.AddAsync(tasks);
        await _context.SaveChangesAsync();
    }

    public async Task<Tasks?> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(i  => i.Id == id);
    }

    public async Task<Tasks> GetByTitleAsync(string title)
    {
        return await _context.Tasks.AsNoTracking().FirstOrDefaultAsync(t =>  t.Title == title);
    }

    public async Task<IReadOnlyList<Tasks>> GetAllAsync()
    {
        return await _context.Tasks.AsNoTracking().ToListAsync();
    }

    public async Task UpdateAsync(Tasks tasks)
    {
        var newValue = await _context.Tasks.Where(i => i.Id ==  tasks.Id).FirstOrDefaultAsync();

        _context.Entry(newValue).CurrentValues.SetValues(tasks);
        _context.Update<Tasks>(tasks);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tasks tasks)
    {
        tasks.Delete();
        await UpdateAsync(tasks);
    }
}