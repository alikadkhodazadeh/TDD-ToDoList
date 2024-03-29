﻿namespace ToDoList.Domain;

public sealed class Note
{
    public Note()
    {
        Tasks = new List<Task>();
    }

    public Note(string title, string description) :this()
    {
        Title = title;
        Description = description;

        Validator();
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<Task> Tasks { get; set; }

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
    public void ChangeId(Guid id)
    {
        Id = id;
    }
    public void AddTask(Task task)
    {
        task.TitleValidator();
        Tasks.Add(task);
    }
    public void Edit(string title, string description)
    {
        Title = title;
        Description = description;
    }
    public void ChangeStateTask(Guid id)
    {
        if (id == Guid.Empty)
            throw new InvalidOperationException();

        var task = Tasks.SingleOrDefault(t => t.Id.Equals(id));

        if (task is null)
            throw new ArgumentNullException(nameof(task));

        task.ChangeState();
    }
    public void Validator()
    {
        TitleValidator(); DescriptionValidator();
    }
    public override string ToString()
    {
        return Title;
    }
    public override bool Equals(object? obj)
    {
        if (!(obj is Note note))
            return false;

        return Id == note.Id;
    }
}
