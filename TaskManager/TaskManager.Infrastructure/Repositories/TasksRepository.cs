using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Domain.Model;

namespace TaskManager.Infrastructure.Repositories;

public class TasksRepository : ITasksRepository
{
    public Task AddAsync(Tasks tasks)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Tasks tasks)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Tasks>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Tasks?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Tasks> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Guid id, Tasks tasks)
    {
        throw new NotImplementedException();
    }
}