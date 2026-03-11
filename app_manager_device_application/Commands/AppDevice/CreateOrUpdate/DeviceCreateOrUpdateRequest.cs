using app_manager_device_application.Models.DTO;
using app_manager_device_application.Models.Request;
using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppDevice.CreateOrUpdate
{
    public class DeviceCreateOrUpdateRequest : AppDeviceModel, IRequest<ResponseModel<AppDeviceDTO>> { }
}
