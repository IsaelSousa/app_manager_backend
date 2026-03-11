using app_manager_device_domain.Models.EFModels;

namespace app_manager_device_domain.Entities.AppManagerAggregate
{
    public interface IAppDeviceRepository
    {
        Task<List<AppDeviceEF>> GetByFilter(string device);
        Task<AppDeviceEF> CreateOrUpdate(AppDeviceEF appManagerEF);
        Task<bool> Delete(string id);
    }
}
