using ProjectManager.Application.DeviceHeaders.Queries.GetDeviceHeaders;
using ProjectManager.Application.Devices.Queries.GetDeviceParams;

namespace ProjectManager.Application.Common.Interfaces;

public interface IDeviceSelectedParams
{
    Task<List<DeviceSelectedParamsDto>> GetDeviceSelectedParamsAsync(int deviceId, List<int> paramIds);
    Task<List<DeviceHeaderDto>> GetDeviceHeadersAsync(int deviceId, List<int> paramIds);
}
