using TaskManager.Application.Contracts.Requests;
using TaskManager.Application.Contracts.Responses;
using TaskManager.Domain.Model;

namespace TaskManager.Application.Interfaces.Services;

public interface ITasksServices
{
    Task <TasksResponses> CreateAsync(CreateTasksRequest request);

    Task <TasksResponses> GetByIdAsync(Guid id);

    Task <TasksResponses> GetByTitleAsync(string title);

    Task<IReadOnlyList<TasksResponses>> GetAllAsync();

    Task <TasksResponses> UpdateAsync(Guid id, CreateTasksRequest request);

    Task <bool> DeleteAsync(Guid id);
}