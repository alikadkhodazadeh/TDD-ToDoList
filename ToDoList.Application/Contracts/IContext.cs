namespace ToDoList.Application;

public interface IContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);

    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}
