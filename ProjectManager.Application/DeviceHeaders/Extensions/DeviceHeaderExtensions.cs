using ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;
using ProjectManager.Domain.Entities;

public static class DeviceHeaderExtensions
{
    public static DeviceHeaderDto ToDeviceHeaderDto(this DeviceHeader header)
    {
        if (header == null)
        {
            return null;
        }
        return new DeviceHeaderDto
        {
            Id = header.Id,
            Name = header.Name,
            Description = header.Description,
            Used = header.Used,
            Order = header.Order
        };
    }
}
