using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.CheckUpdate
{
    public class CheckUpdateRequest : IRequest<ResponseModel<List<CheckUpdateDTO>>>
    {
        public string Device { get; set; }
    }
}
