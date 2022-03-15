namespace ToDoList.Persistence.Repositories;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly Context _context;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public void BeginTransaction()
    {
        _context.Database.BeginTransaction();
    }

    public void CommitTransaction()
    {
        _context.Database.CommitTransaction();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void RollbackTransaction()
    {
        _context.Database.RollbackTransaction();
    }
}
