using app_manager_device_domain.Models.EFModels;

namespace app_manager_device_domain.Entities.AppManagerAggregate
{
    public interface IAppManagerRepository
    {
        Task<List<AppManagerEF>> GetByFilter(string device);
        Task<AppManagerEF> CreateOrUpdate(AppManagerEF appManagerEF);
        Task<bool> Delete(string id);
    }
}
