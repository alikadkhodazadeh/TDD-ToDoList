namespace ToDoList.Application;

public interface ITaskRepository : IDisposable
{
    List<Domain.Task> GetAll();
    Guid Create(Domain.Task task);
    void Create(Domain.Task task, bool save);
    Domain.Task? GetById(Guid id);
    void Delete(Guid id);
    void Save();
}