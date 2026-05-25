using ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;

namespace ProjectManager.Application.Devices.Commands.AddScript;

public class DeviceSriptVm
{
    public int DeviceId { get; set; }
    public string DeviceName { get; set; }
    public string AuthUrl { get; set; }
    public string ApiUrl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int IntervalMs { get; set; }
    public IEnumerable<DeviceHeaderDto> Headers { get; set; }
}
