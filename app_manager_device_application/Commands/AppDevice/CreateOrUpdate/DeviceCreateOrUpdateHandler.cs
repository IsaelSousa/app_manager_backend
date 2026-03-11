using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using app_manager_device_domain.Models.EFModels;
using AutoMapper;
using MediatR;

namespace app_manager_device_application.Commands.AppDevice.CreateOrUpdate
{
    public class DeviceCreateOrUpdateHandler(
        IAppDeviceRepository repository,
        IMapper mapper
        ) : IRequestHandler<DeviceCreateOrUpdateRequest, ResponseModel<AppDeviceDTO>>
    {
        public async Task<ResponseModel<AppDeviceDTO>> Handle(DeviceCreateOrUpdateRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<AppDeviceEF>(request);

            entity = await repository.CreateOrUpdate(entity);

            var response = mapper.Map<AppDeviceDTO>(entity);

            return new ResponseModel<AppDeviceDTO>(response);
        }
    }
}
