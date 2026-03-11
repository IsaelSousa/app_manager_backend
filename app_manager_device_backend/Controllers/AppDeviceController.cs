using app_manager_device_application.Commands.AppDevice.CreateOrUpdate;
using app_manager_device_application.Commands.AppDevice.Delete;
using app_manager_device_application.Commands.AppDevice.GetByFilter;
using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace app_manager_device_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppDeviceController(IMediator mediator) : ControllerBase
    {
        [HttpGet("list-apps-by-device")]
        public Task<ResponseModel<AppDeviceDTO>> Get([FromQuery] DeviceGetByFilterRequest request)
        {
            return mediator.Send(request);
        }

        [HttpPost("create-or-update")]
        public Task<ResponseModel<AppDeviceDTO>> CreateOrUpdate(DeviceCreateOrUpdateRequest request)
        {
            return mediator.Send(request);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ResponseModel<bool>> DeleteById(string id)
        {
            return await mediator.Send(new DeviceSoftDeleteRequest(id));
        }
    }
}
