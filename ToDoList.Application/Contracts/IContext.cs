using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ToDoList.Application
{
    public interface IContext
    {
        DatabaseFacade Database { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();
        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
