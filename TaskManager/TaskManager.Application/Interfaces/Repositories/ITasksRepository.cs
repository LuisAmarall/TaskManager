using TaskManager.Domain.Model;

namespace TaskManager.Application.Interfaces.Repositories;

public interface ITasksRepository
{
    Task AddAsync(Tasks tasks);

    Task <Tasks?> GetById(Guid id);

    Task <Task> GetByTitle(string title);

    Task UpdateAsync(Tasks tasks);

    Task DeleteAsync(Tasks tasks);
}