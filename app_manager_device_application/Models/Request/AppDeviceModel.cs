namespace app_manager_device_application.Models.Request
{
    public class AppDeviceModel
    {
        public string Id { get; set; } = null;
        public string Device { get; set; }
        public string Uri { get; set; }
        public string Version { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
