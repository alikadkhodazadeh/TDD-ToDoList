using ToDoList.Persistence;

var builder = WebApplication.CreateBuilder(args);

#region Services
var services = builder.Services;

services.AddContext();
services.AddRepositories();

services.AddControllers();
#endregion

#region Middleware
var app = builder.Build();

app.MapControllers();

app.Run();
#endregion
