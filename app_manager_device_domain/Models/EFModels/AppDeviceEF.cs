namespace app_manager_device_domain.Models.EFModels
{
    public class AppDeviceEF : ITrackable
    {
        public string Id { get; set; }
        public string Device { get; set; }
        public string AppManagerId { get; set; }
        public string Uri { get; set; }
        public string Version { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public AppManagerEF AppManager { get; set; }

    }
}
