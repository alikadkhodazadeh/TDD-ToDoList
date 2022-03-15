var builder = WebApplication.CreateBuilder(args);

#region Services
var services = builder.Services;

services.AddControllers();
#endregion

#region Middleware
var app = builder.Build();

app.MapControllers();

app.Run();
#endregion
