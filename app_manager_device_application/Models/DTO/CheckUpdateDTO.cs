
namespace app_manager_device_application.Models.DTO
{
    public class CheckUpdateDTO
    {
        public string AppName { get; set; }
        public string Version { get; set; }
        public string DeviceVersion { get; set; }
        public bool ShouldUpdate { get; set; }
        public DateTimeOffset LastUpdateAppOnDevice { get; set; }
    }
}
