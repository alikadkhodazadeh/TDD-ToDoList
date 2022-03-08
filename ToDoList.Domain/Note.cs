namespace ToDoList.Domain;

public class Note
{
    public Note(string? title, string? description)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;

        TitleValidator(); DescriptionValidator();

        Tasks = new List<Task>();
    }

    public Guid Id { get; private init; }
    public string? Title { get; private set; }
    public string? Description { get; private set; }
    public IList<Task>? Tasks { get; private set; }

    public void TitleValidator()
    {
        if (string.IsNullOrEmpty(Title))
            throw new InvalidOperationException();
    }
    public void DescriptionValidator()
    {
        if (string.IsNullOrEmpty(Description))
            throw new InvalidOperationException();
    }
    public void AddTask(Task task)
    {
        task.TitleValidator();
        Tasks?.Add(task);
    }
    public void ChangeStateTask(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidOperationException();

        var task = Tasks?.SingleOrDefault(t => t.Id.Equals(id));

        if(task is null)
            throw new ArgumentNullException(nameof(task));

        task.ChangeState();
    }
    public override string? ToString()
    {
        return Title;
    }
}
