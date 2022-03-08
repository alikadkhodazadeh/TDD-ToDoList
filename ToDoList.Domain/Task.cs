namespace ToDoList.Domain;

public class Task
{
    public Task(string? title)
    {
        Title = title;

        Undone();
        TitleValidator();
    }

    public Guid Id { get; private init; }
    public string? Title { get; private set; }
    public bool IsDone { get; private set; }

    public void Done()
    {
        IsDone = true;
    }
    public void Undone()
    {
        IsDone = false;
    }
    public void ChangeState()
    {
        IsDone = !IsDone;
    }
    public void TitleValidator()
    {
        if (string.IsNullOrEmpty(Title))
            throw new InvalidOperationException();
    }
    public override string? ToString()
    {
        return Title;
    }
}