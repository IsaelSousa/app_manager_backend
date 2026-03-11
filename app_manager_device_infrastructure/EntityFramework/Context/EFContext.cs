using app_manager_device_domain.Models.EFModels;
using app_manager_device_infrastructure.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
namespace app_manager_device_infrastructure.EntityFramework.Context
{
    public class EFContext : DbContext
    {
        public string schema = "AppManager";
        //dotnet ef migrations add InitialMigration -p app_manager_device_infrastructure -s app_manager_device_backend
        public DbSet<AppManagerEF> Apps { get; set; }
        public DbSet<AppDeviceEF> Devices { get; set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(schema);

            builder.ApplyConfiguration(new AppManagerConfiguration());
            builder.ApplyConfiguration(new AppDeviceConfiguration());

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
