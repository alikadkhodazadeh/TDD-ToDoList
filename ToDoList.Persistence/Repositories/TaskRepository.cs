﻿namespace ToDoList.Persistence.Repositories;

internal sealed class TaskRepository : ITaskRepository
{
    private readonly Context _context;

    public TaskRepository(Context context)
    {
        _context = context;
    }

    public List<Domain.Task> GetAll()
    {
        return _context.Tasks.AsNoTracking().ToList();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Guid Create(Domain.Task task)
    {
        _context.Tasks.Add(task);
        Save();
        return task.Id;
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public Domain.Task? GetById(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentNullException(nameof(id));
        var task = _context.Tasks.Find(id);
        return task;
    }

    public void Delete(Guid id)
    {
        var task = _context.Tasks.Find(id);
        if (task is null)
            throw new ArgumentNullException(nameof(id));
        _context.Tasks.Remove(task);
        Save();
    }

    public void Create(Domain.Task task, bool save)
    {
        _context.Tasks.Add(task);
        if (save)
            Save();
    }
}
