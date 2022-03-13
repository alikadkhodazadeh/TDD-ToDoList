using ToDoList.Application.Contracts;

namespace ToDoList.Persistence.Repositories;

public sealed class UnitOfWorkFactory
{
    public IUnitOfWork CreateUnitOfWork()
    {
        return new UnitOfWork(new ContextFactory().CreateDbContext());
    }
}