using app_manager_device_application.Models.DTO;
using app_manager_device_application.Models.Request;
using app_manager_device_domain.Models.EFModels;
using AutoMapper;

namespace app_manager_device_application.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // App Manager Mappings
            CreateMap<AppManagerModel, AppManagerEF>()
                .ReverseMap();

            CreateMap<AppManagerEF, AppManagerDTO>()
                .ReverseMap();

            CreateMap<AppManagerModel, AppManagerDTO>()
                .ReverseMap();

            // App Device Mappings

            CreateMap<AppDeviceModel, AppDeviceEF>()
                .ReverseMap();

            CreateMap<AppDeviceEF, AppDeviceDTO>()
                .ReverseMap();

            CreateMap<AppDeviceModel, AppDeviceDTO>()
                .ReverseMap();

        }
    }
}
