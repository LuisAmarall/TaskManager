using TaskManager.Domain.Model;

namespace TaskManager.Application.Interfaces.Repositories;

public interface ITasksRepository
{
    Task AddAsync(Tasks tasks);

    Task <Tasks?> GetByIdAsync(Guid id);

    Task <Tasks> GetByTitleAsync(string title);

    Task<IReadOnlyList<Tasks>> GetAllAsync();

    Task UpdateAsync(Guid id, Tasks tasks);

    Task DeleteAsync(Tasks tasks);

    Task SaveChangesAsync();
}