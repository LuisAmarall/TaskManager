namespace TaskManager.Domain.Model;

public class Tasks
{
    public enum TaskStatus
    {
        ToDo,
        Doing,
        Done
    }

    private Tasks() { }

    public Tasks(string title, string description)
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

    public DateTime? DeleteAt { get; private set; }
    public bool IsDeleted() => DeleteAt != null;

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
            throw new InvalidOperationException("Tasks must be ToDo to start");

        Status = TaskStatus.Doing;
        InProcess = DateTime.UtcNow;
    }

    public void Complete()
    {
        if (Status != TaskStatus.Doing)
            throw new InvalidOperationException("Tasks must be Doing to complete");

        Status = TaskStatus.Done;
        CompletedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        if (Status == TaskStatus.Done && DeleteAt != null)
            return;

        DeleteAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        if (DeleteAt == null)
            return;

        DeleteAt = null;
    }
}