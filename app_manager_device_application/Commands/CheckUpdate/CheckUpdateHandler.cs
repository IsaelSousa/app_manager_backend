using app_manager_device_application.Models.DTO;
using app_manager_device_domain.Entities.AppManagerAggregate;
using app_manager_device_domain.Models;
using AutoMapper;
using MediatR;

namespace app_manager_device_application.Commands.CheckUpdate
{
    public class CheckUpdateHandler(
        IMapper mapper,
        IAppManagerRepository appManagerRepository) : IRequestHandler<CheckUpdateRequest, ResponseModel<List<CheckUpdateDTO>>>
    {
        public async Task<ResponseModel<List<CheckUpdateDTO>>> Handle(CheckUpdateRequest request, CancellationToken cancellationToken)
        {
            var apps = await appManagerRepository.GetByFilter(request.Device);

            var dtos = mapper.Map<List<CheckUpdateDTO>>(apps);

            var shouldUpdate = dtos.Where(dto => dto.ShouldUpdate);

            return new ResponseModel<List<CheckUpdateDTO>>([.. shouldUpdate]).SetStatus(true);
        }
    }
}
