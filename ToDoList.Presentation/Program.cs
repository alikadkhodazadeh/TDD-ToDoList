using ToDoList.Persistence;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        #region Services
        var services = builder.Services;

        services.AddPersistence();

        services.AddControllers();
        #endregion

        #region Middleware
        var app = builder.Build();

        app.UseRouting();

        app.MapControllers();

        app.Run();
        #endregion
    }
}