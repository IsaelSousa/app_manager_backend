using app_manager_device_application.Commands.AppManager.CreateOrUpdate;
using app_manager_device_application.Commands.AppManager.Delete;
using app_manager_device_application.Commands.AppManager.GetByFilter;
using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace app_manager_device_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppManagerController(IMediator mediator) : ControllerBase
    {
        [HttpGet("list-apps")]
        public Task<ResponseModel<List<AppManagerDTO>>> Get()
        {
            return mediator.Send(new AppGetByFilterRequest());
        }

        [HttpPost("create-or-update")]
        public Task<ResponseModel<AppManagerDTO>> CreateOrUpdate(AppCreateOrUpdateRequest request)
        {
            return mediator.Send(request);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ResponseModel<bool>> DeleteById(string id)
        {
            return await mediator.Send(new AppSoftDeleteRequest(id));
        }
    }
}
