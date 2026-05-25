using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;

public class EditDeviceHeaderCommandHandler : IRequestHandler<EditDeviceHeaderCommand>
{
    private readonly IApplicationDbContext _context;

    public EditDeviceHeaderCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditDeviceHeaderCommand request, CancellationToken cancellationToken)
    {
        var header = await _context
            .DeviceHeaders
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
        if (header != null)
        {
            header.Name = request.Name;
            header.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);
        }
            return Unit.Value;
    }
}
