
namespace TaskManager.Application.Contracts.Requests;

public sealed record class UpdateTasksRequest(string Title, string Description);