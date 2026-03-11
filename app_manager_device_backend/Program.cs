using app_manager_device_infrastructure.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace app_manager_device_backend;
class Program : Startup
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var startup = new Startup();
        startup.ConfigureServices(builder.Services);
        startup.ConfigureDatabase(builder.Configuration, builder.Services);
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyHeader());
        app.UseAuthorization();
        app.MapControllers();

        InitializeDatabase(app.Services);

        app.Run();
    }

    public static void InitializeDatabase(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<EFContext>();
            dbContext.Database.Migrate();
        }
    }
}