namespace ToDoList.Application;

public interface ITaskRepository : IDisposable
{
    List<Domain.Task> GetAll();
    Guid Create(Domain.Task task);
}