using app_manager_device_application.Commands.CheckUpdate;
using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace app_manager_device_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckUpdateController(IMediator mediator) : ControllerBase
    {
        [HttpGet("to-update")]
        public Task<ResponseModel<List<CheckUpdateDTO>>> Get([FromQuery] CheckUpdateRequest request)
        {
            return mediator.Send(request);
        }
    }
}
