using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeaders;

public class EditDeviceHeadersCommandHandler : IRequestHandler<EditDeviceHeadersCommand>
{
    private readonly IApplicationDbContext _context;

    public EditDeviceHeadersCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditDeviceHeadersCommand request, CancellationToken cancellationToken)
    {
        if (request.Headers == null || !request.Headers.Any())
            return Unit.Value;

        foreach (var header in request.Headers)
        {
            var headerEntity = await _context.DeviceHeaders.FirstOrDefaultAsync(x=>x.Id == header.Id);
            if (headerEntity != null)
            {
                headerEntity.Used = header.Used;
            }
        }
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
