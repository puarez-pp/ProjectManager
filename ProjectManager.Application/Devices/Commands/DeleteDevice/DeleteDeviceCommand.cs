using MediatR;

namespace ProjectManager.Application.Devices.Commands.DeleteDevice;

public class DeleteDeviceCommand : IRequest
{
    public int Id { get; set; }
}
