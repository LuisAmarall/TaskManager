namespace TaskManager.Application.Contracts.Responses;

public sealed record class CreateTasksResponses(Guid Id, string Title, string Description, string Status, DateTime CreatedAt);