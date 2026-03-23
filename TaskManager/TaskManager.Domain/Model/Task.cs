namespace TaskManager.Domain.Model;

public class Task
{
    public enum TaskStatus
    {
        ToDo,
        Doing,
        Done
    }

    private Task() { }

    public Task(string title, string description)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required", nameof(title));

        if (description is null)
            throw new ArgumentException("Description is required", nameof(description));

        Id = Guid.NewGuid();

        Title = title;
        Description = description;

        Status = TaskStatus.ToDo;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid Id { get; private set; }

    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public TaskStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? InProcess { get; private set; }
    public DateTime? CompletedAt { get; private set; }

    public void UpdateTitle(string title)
    {
        if (title is null)
            throw new InvalidOperationException("Title is required");

        if (string.Equals(Title?.Trim(), title?.Trim(), StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Title is the same as the current one");

        Title = title;
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new InvalidOperationException("Description is required");

        if (string.Equals(Description?.Trim(), description.Trim(), StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("Description is the same as the current one");

        Description = description;
    }

    public void Start()
    {
        if (Status != TaskStatus.ToDo)
            throw new InvalidOperationException("Task must be ToDo to start");

        Status = TaskStatus.Doing;
        InProcess = DateTime.UtcNow;
    }

    public void Complete()
    {
        if (Status != TaskStatus.Doing)
            throw new InvalidOperationException("Task must be Doing to complete");

        Status = TaskStatus.Done;
        CompletedAt = DateTime.UtcNow;
    }
}