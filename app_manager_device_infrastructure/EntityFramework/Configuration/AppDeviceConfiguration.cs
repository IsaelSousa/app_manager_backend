using app_manager_device_domain.Models.EFModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace app_manager_device_infrastructure.EntityFramework.Configuration
{
    public class AppDeviceConfiguration : IEntityTypeConfiguration<AppDeviceEF>
    {
        public void Configure(EntityTypeBuilder<AppDeviceEF> builder)
        {
            builder.HasKey(am => am.Id);

            builder.Property(am => am.Id).HasColumnType("varchar(40)").ValueGeneratedNever();
            builder.Property(am => am.Device).IsRequired().HasMaxLength(200);
            builder.Property(am => am.Uri).IsRequired().HasMaxLength(500);
            builder.Property(am => am.Version).IsRequired().HasMaxLength(100);

            builder.Property(am => am.CreatedAt)
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .IsRequired();

            builder.Property(am => am.LastUpdate)
                .HasColumnType("datetimeoffset")
                .HasDefaultValueSql("SYSDATETIMEOFFSET()")
                .IsRequired();

            builder.Property(am => am.IsDeleted).HasDefaultValue(false);
        }
    }
}
