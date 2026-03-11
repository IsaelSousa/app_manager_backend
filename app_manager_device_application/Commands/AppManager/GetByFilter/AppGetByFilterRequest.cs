using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppManager.GetByFilter
{
    public class AppGetByFilterRequest : IRequest<ResponseModel<List<AppManagerDTO>>>
    {

    }
}
