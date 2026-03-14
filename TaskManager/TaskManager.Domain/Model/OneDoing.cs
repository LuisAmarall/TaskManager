namespace TaskManager.Domain.Model;

public class OneDoing
{
    private OneDoing() { }

    public OneDoing(string title, string description, bool done)
    {
        if (title is null)
            throw new ArgumentException("Title is required", nameof(title));

        ToDoId = Guid.NewGuid();
        Title = title;
        Description = description;
        Done = done;
        CreatedAt = DateTime.UtcNow;
    }

    public Guid ToDoId { get; private set; }

    public string Title { get; private set; }
    public string Description { get; private set; }
    
    public bool Done { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ValidatedData { get; private set; }

    public void UpdateTitle(string title)
    {
        if (title is null)
            throw new ArgumentException("Title is required", nameof(title));

        if (title.Equals(Title))
            throw new Exception("Title is the same as the current one");

        Title = title;
    }

    public void UpdateDescription(string description)
    {
        var verify = false;
        if (string.Equals(Description?.Trim(), description?.Trim(), StringComparison.OrdinalIgnoreCase))
            throw new Exception("Description is the same as the current one");
 
        else
        {
            verify = true;
            Description = description;
        }
    }

    public bool UpdateDone(bool done)
    {
        if (done == Done)
            throw new Exception("Done is the same as the current one");

        return Done = done;
    }

    public void UpdateValidatedData(bool done)
    {
        if (done != Done)
            throw new Exception("The task has not yet been completed.");

        ValidatedData = DateTime.UtcNow;
    }
}