using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using AutoMapper;
using MediatR;

namespace app_manager_device_application.Commands.AppDevice.GetByFilter
{
    public class DeviceGetByFilterHandler(
            IAppDeviceRepository repository,
            IMapper mapper
        ) : IRequestHandler<DeviceGetByFilterRequest, ResponseModel<List<AppDeviceDTO>>>
    {
        public async Task<ResponseModel<List<AppDeviceDTO>>> Handle(DeviceGetByFilterRequest request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetByFilter(request.Device);

            if (entities.Count == 0) return new ResponseModel<List<AppDeviceDTO>>(false, "No entities found");

            var response = mapper.Map<List<AppDeviceDTO>>(entities);

            return new ResponseModel<List<AppDeviceDTO>>(response);
        }
    }
}
