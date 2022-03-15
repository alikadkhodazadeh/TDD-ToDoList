namespace ToDoList.Persistence.Repositories;

public sealed class TaskRepositoryFactory : IRepositoryFactory<ITaskRepository>
{
    public ITaskRepository CreateRepository()
    {
        return new TaskRepository(new ContextFactory().CreateDbContext());
    }
}