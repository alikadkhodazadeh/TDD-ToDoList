namespace ToDoList.Application;

public interface IRepositoryFactory<T>
{
    public T CreateRepository();
}