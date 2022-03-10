namespace ToDoList.Persistence.Repositories;

public sealed class NoteRepositoryFactory : IRepositoryFactory<INoteRepository>
{
    public INoteRepository Create()
    {
        return new NoteRepository(new ContextFactory().CreateDbContext());
    }
}