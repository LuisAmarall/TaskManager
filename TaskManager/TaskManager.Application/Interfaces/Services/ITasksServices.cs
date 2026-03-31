using TaskManager.Application.Contracts.Requests;
using TaskManager.Domain.Model;

namespace TaskManager.Application.Interfaces.Services;

public interface ITasksServices
{
    Task <Tasks> AddAsync(CreateTasksRequest request);

    Task <Tasks> GetByIdAsync(Guid id);

    Task <IReadOnlyList<Task>> GetAllAsync();

    Task <Tasks> UpdateAsync(Guid id, UpdateTasksRequest request);

    Task <bool> DeleteAsync(Guid id);
}