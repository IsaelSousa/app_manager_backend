using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppDevice.GetByFilter
{
    public class DeviceGetByFilterRequest : IRequest<ResponseModel<List<AppDeviceDTO>>>
    {
        public string Device { get; set; }
    }
}
