using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppDevice.Delete
{
    public class DeviceSoftDeleteHandler(
        IAppDeviceRepository repository
        ) : IRequestHandler<DeviceSoftDeleteRequest, ResponseModel<bool>>
    {
        public async Task<ResponseModel<bool>> Handle(DeviceSoftDeleteRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Delete(request.Id);
            
            if (entity == null) return new ResponseModel<bool>(false, "Entity not found");

            return new ResponseModel<bool>(true);
        }
    }
}
