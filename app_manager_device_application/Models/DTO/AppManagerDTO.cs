namespace app_manager_device_application.Models.DTO
{
    public class AppManagerDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string IconUri { get; set; }
        public string Version { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<AppDeviceDTO> Devices { get; set; }

    }
}