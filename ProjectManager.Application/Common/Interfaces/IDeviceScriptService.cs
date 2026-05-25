using ProjectManager.Application.Devices.Commands.AddScript;

namespace ProjectManager.Application.Common.Interfaces;

public interface IDeviceScriptService
{
    Task<Domain.Entities.File> GenerateScriptAsync(DeviceSriptVm model);
}
