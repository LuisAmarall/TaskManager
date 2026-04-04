using TaskManager.Application.Contracts.Requests;
using TaskManager.Application.Contracts.Responses;
using TaskManager.Domain.Model;

namespace TaskManager.Application.Mappings;

public static class TasksMappings
{
    public static Tasks ToEntity(this CreateTasksRequest request)
    {
        return new Tasks(request.Title, request.Description);
    }

    public static TasksResponses ToResponse(this Tasks tasks)
    {
        return new TasksResponses
         (
             tasks.Id,
             tasks.Title,
             tasks.Description,
             tasks.Status.ToString(),
             tasks.CreatedAt
         );
    }
}