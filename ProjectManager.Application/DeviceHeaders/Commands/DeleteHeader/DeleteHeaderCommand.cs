using MediatR;

namespace ProjectManager.Application.DeviceHeaders.Commands.DeleteHeader;

public class DeleteHeaderCommand : IRequest
{
    public int Id { get; set; }
}
