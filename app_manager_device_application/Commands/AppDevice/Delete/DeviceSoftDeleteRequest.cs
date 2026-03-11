using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppDevice.Delete
{
    public class DeviceSoftDeleteRequest : IRequest<ResponseModel<bool>>
    {
        public string Id { get; set; }

        public DeviceSoftDeleteRequest(string id)
        {
            Id = id;
        }
    }
}
