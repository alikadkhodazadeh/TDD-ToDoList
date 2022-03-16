using Microsoft.Extensions.DependencyInjection;
using ToDoList.Persistence.Repositories;

namespace ToDoList.Persistence;

public static class IocConfig
{
    public static void AddContext(this IServiceCollection services)
    {
        services.AddDbContext<Context>();
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}
