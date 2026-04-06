using TaskManager.Domain.Exception;
using TaskManager.Application.Mappings;
using TaskManager.Application.Validations;
using TaskManager.Application.Contracts.Requests;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Application.Contracts.Responses;
using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Application.Services;

public sealed class TasksServices : ITasksServices
{
    public TasksServices(ITasksRepository tasksRepository)
    {
        _tasksRepository = tasksRepository;
    }

    private readonly ITasksRepository _tasksRepository;

    public async Task<TasksResponses> CreateAsync(CreateTasksRequest request)
    {
        TasksValidations.IsValid(request);

        var tasks = TasksMappings.ToEntity(request);

        await _tasksRepository.AddAsync(tasks);

        await _tasksRepository.SaveChangesAsync();

        return TasksMappings.ToResponse(tasks);
    }

    public async Task<TasksResponses> GetByIdAsync(Guid id)
    {
        var read = await _tasksRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Task with id {id} not found");

        return TasksMappings.ToResponse(read);
    }

    public async Task<TasksResponses> GetByTitleAsync(string title)
    {
        var read = await _tasksRepository.GetByTitleAsync(title) ?? throw new NotFoundException($"Task with title {title} not found");

        return TasksMappings.ToResponse(read);
    }

    public async Task<IReadOnlyList<TasksResponses>> GetAllAsync()
    {
        var tasks = await _tasksRepository.GetAllAsync();

        return tasks.Select(t => t.ToResponse()).ToList().AsReadOnly();
    }

    public async Task<TasksResponses> UpdateAsync(Guid id, CreateTasksRequest request)
    {
        var entity = await _tasksRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Task with id {id} not found");

        TasksValidations.IsValid(request);

        entity.UpdateTitle(request.Title);
        entity.UpdateDescription(request.Description);

        await _tasksRepository.SaveChangesAsync();

        return TasksMappings.ToResponse(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var tasks = await _tasksRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Task with id {id} not found");

        tasks.Delete();

        await _tasksRepository.SaveChangesAsync();
    }

    public async Task RestoreAsync(Guid id)
    {
        var tasks = await _tasksRepository.GetByIdAsync(id) ?? throw new NotFoundException($"Task with id {id} not found");

        tasks.Restore();

        await _tasksRepository.SaveChangesAsync();
    }
}