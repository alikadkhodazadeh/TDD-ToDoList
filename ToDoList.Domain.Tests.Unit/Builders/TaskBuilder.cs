namespace ToDoList.Domain.Tests.Unit;

public class TaskBuilder
{
    private string? _title = "Mock";
    public TaskBuilder WithTitle(string? title)
    {
        _title = title;
        return this;
    }
    public Task Build()
    {
        return new Task(_title);
    }
}
