using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Devices.Queries.GetDevice
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public DeviceType DeviceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsConfigured { get; set; }
    }
}
