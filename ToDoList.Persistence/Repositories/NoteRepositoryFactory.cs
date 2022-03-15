namespace ToDoList.Persistence.Repositories;

public sealed class NoteRepositoryFactory : IRepositoryFactory<INoteRepository>
{
    public INoteRepository CreateRepository()
    {
        return new NoteRepository(new ContextFactory().CreateDbContext());
    }
}