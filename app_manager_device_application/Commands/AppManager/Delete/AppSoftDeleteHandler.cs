using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using MediatR;

namespace app_manager_device_application.Commands.AppManager.Delete
{
    public class AppSoftDeleteHandler(
        IAppManagerRepository repository
        ) : IRequestHandler<AppSoftDeleteRequest, ResponseModel<bool>>
    {
        public async Task<ResponseModel<bool>> Handle(AppSoftDeleteRequest request, CancellationToken cancellationToken)
        {
            var entity = await repository.Delete(request.Id);
            
            if (entity == null) return new ResponseModel<bool>(false, "Entity not found");

            return new ResponseModel<bool>(true);
        }
    }
}
