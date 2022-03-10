namespace ToDoList.Domain;

public class Task
{
    public Task(string title)
    {
        Id = Guid.NewGuid();
        Title = title;

        Undone();
        TitleValidator();
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDone { get; private set; }

    public Guid? NoteId { get; set; }
    public Note? Note { get; set; }

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
    public void ChangeId(Guid id)
    {
        Id = id;
    }
    public void TitleValidator()
    {
        if (string.IsNullOrEmpty(Title))
            throw new InvalidOperationException();
    }
    public override string ToString()
    {
        return Title;
    }
}