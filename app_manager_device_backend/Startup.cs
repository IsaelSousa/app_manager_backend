using app_manager_device_application.Commands.AppDevice.CreateOrUpdate;
using app_manager_device_application.Commands.AppDevice.Delete;
using app_manager_device_application.Commands.AppDevice.GetByFilter;
using app_manager_device_application.Commands.AppManager.CreateOrUpdate;
using app_manager_device_application.Commands.AppManager.Delete;
using app_manager_device_application.Commands.AppManager.GetByFilter;
using app_manager_device_application.Mappers;
using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_infrastructure.EntityFramework.Context;
using app_manager_device_infrastructure.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace app_manager_device_backend
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AppCreateOrUpdateRequest).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AppSoftDeleteRequest).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AppGetByFilterRequest).GetTypeInfo().Assembly));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeviceCreateOrUpdateRequest).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeviceSoftDeleteRequest).GetTypeInfo().Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DeviceGetByFilterRequest).GetTypeInfo().Assembly));

            services.AddAutoMapper(typeof(MapperProfile));

            services.AddTransient<IAppManagerRepository, AppManagerRepository>();
            services.AddTransient<IAppDeviceRepository, AppDeviceRepository>();
        }

        public void ConfigureDatabase(IConfigurationManager manager, IServiceCollection services)
        {
            var connectionString = manager.GetConnectionString("DefaultConnection");

            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(connectionString, sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsHistoryTable("__EFMigrationsHistory", "dbo");

                    sqlServerOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }),
                ServiceLifetime.Scoped
            );
        }
    }
}
