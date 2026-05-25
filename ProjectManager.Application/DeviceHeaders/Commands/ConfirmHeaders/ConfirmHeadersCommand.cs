using MediatR;

namespace ProjectManager.Application.DeviceHeaders.Commands.ConfirmHeaders;

public class ConfirmHeadersCommand : IRequest
{
    public int Id { get; set; }
}
