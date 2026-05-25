namespace ProjectManager.Application.Common.Interfaces;

public interface IDeviceParamsService
{
    Task SaveDeviceParamsAsync(int deviceId, IDeviceParam dto);
}

