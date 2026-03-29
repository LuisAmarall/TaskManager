using TaskManager.Application.Contracts.Requests;

namespace TaskManager.Application.Validations;

public static class TasksValidations
{
    public static void IsValid(CreateTasksRequest request)
    {
        if (request is null)
            throw new InvalidOperationException($"{nameof(request)} is required");

        if (string.IsNullOrWhiteSpace(request.Title))
            throw new InvalidOperationException($"{nameof(request.Title)}: Please note that Title field does not allow null values");

        if (string.IsNullOrEmpty(request.Description))
            throw new InvalidOperationException($"{nameof(request.Description)}: Please note that Description field does not allow null values")
    }
}