using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using AutoMapper;
using MediatR;

namespace app_manager_device_application.Commands.AppManager.GetByFilter
{
    public class AppGetByFilterHandler(
            IAppManagerRepository repository,
            IMapper mapper
        ) : IRequestHandler<AppGetByFilterRequest, ResponseModel<List<AppManagerDTO>>>
    {
        public async Task<ResponseModel<List<AppManagerDTO>>> Handle(AppGetByFilterRequest request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetByFilter();

            if (entities.Count == 0) return new ResponseModel<List<AppManagerDTO>>(false, "No entities found");

            var response = mapper.Map<List<AppManagerDTO>>(entities);

            return new ResponseModel<List<AppManagerDTO>>(response);
        }
    }
}
