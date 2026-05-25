using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.DeviceHeaders.Commands.ConfirmHeaders;

public class ConfirmHeadersCommandHandler : IRequestHandler<ConfirmHeadersCommand>
{
    private readonly IApplicationDbContext _context;

    public ConfirmHeadersCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(ConfirmHeadersCommand request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if(device != null)
        {
            device.IsConfigured = !device.IsConfigured;
            await _context.SaveChangesAsync();
        }
        
        return Unit.Value;
    }
}