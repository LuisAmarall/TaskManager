namespace TaskManager.Application.Contracts.Requests;

public sealed record class CreateTasksRequest(string Title, string Description);