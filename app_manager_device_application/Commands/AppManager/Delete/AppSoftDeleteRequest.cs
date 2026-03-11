using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppManager.Delete
{
    public class AppSoftDeleteRequest : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; }

        public AppSoftDeleteRequest(string id)
        {
            Id = id;
        }
    }
}
