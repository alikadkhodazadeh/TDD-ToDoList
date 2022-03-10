using ToDoList.Application;

namespace ToDoList.Persistence.Repositories;

public class NoteRepositoryFactory : IRepositoryFactory<INoteRepository>
{
    public INoteRepository Create()
    {
        return new NoteRepository();
    }
}