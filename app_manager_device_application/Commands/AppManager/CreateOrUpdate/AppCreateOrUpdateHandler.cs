using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using app_manager_device_domain.Models.EFModels;
using AutoMapper;
using MediatR;

namespace app_manager_device_application.Commands.AppManager.CreateOrUpdate
{
    public class AppCreateOrUpdateHandler(
        IAppManagerRepository repository,
        IMapper mapper
        ) : IRequestHandler<AppCreateOrUpdateRequest, ResponseModel<AppManagerDTO>>
    {
        public async Task<ResponseModel<AppManagerDTO>> Handle(AppCreateOrUpdateRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<AppManagerEF>(request);

            entity = await repository.CreateOrUpdate(entity);

            var response = mapper.Map<AppManagerDTO>(entity);

            return new ResponseModel<AppManagerDTO>(response);
        }
    }
}
