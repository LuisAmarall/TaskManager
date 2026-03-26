namespace TaskManager.Application.Contracts.Requests;

public sealed record class CreateTesksRequest(string Title, string Description);