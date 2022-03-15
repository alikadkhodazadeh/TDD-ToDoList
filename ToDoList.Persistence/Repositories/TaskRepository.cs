namespace ToDoList.Persistence.Repositories;

internal sealed class TaskRepository : ITaskRepository
{
    private readonly Context _context;

    public TaskRepository(Context context)
    {
        _context = context;
    }

    public List<Domain.Task> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
