
namespace app_manager_device_domain.Models.EFModels
{
    public interface ITrackable
    {
        public DateTimeOffset LastUpdate { get; set; }
    }
}
