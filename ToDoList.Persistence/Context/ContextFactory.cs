using Microsoft.EntityFrameworkCore.Design;

namespace ToDoList.Persistence;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[]? args = null)
    {
        const string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=ToDo_db";
        var options = new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options;
        return new Context(options);
    }
}
