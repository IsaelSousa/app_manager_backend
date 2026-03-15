using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models.EFModels;
using AutoMapper;

namespace app_manager_device_application.Mappers.Converters
{
    public class CheckUpdateConverter : ITypeConverter<AppManagerEF, CheckUpdateDTO>
    {
        public CheckUpdateDTO Convert(AppManagerEF source, CheckUpdateDTO destination, ResolutionContext context)
        {
            destination ??= new CheckUpdateDTO();

            destination.AppName = source.Title;
            destination.Version = source.Version;
            destination.DeviceVersion = source.Devices?.FirstOrDefault()?.Version ?? string.Empty;
            destination.ShouldUpdate = !string.IsNullOrEmpty(destination.DeviceVersion) && destination.Version != destination.DeviceVersion;
            destination.LastUpdateAppOnDevice = source.Devices?.FirstOrDefault()?.LastUpdate ?? DateTimeOffset.MinValue;

            return destination;
        }
    }
}
