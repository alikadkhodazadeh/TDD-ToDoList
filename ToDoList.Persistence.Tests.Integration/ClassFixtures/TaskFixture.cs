namespace ToDoList.Persistence.Tests.Integration;

public sealed class TaskFixture : IDisposable
{
    public TaskFixture()
    {
        Transaction = new TransactionScope();
        TaskRepository = new TaskRepositoryFactory().CreateRepository();
        TaskBuilder = new TaskBuilder();
    }

    public TransactionScope Transaction { get; set; }
    public ITaskRepository TaskRepository { get; set; }
    public TaskBuilder TaskBuilder { get; set; }

    public void Dispose()
    {
        Transaction.Dispose();
        TaskRepository.Dispose();
    }
}