using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.DeviceHeaders.Commands.DeleteHeader;

public class DeleteHeaderCommandHandler : IRequestHandler<DeleteHeaderCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteHeaderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteHeaderCommand request, CancellationToken cancellationToken)
    {
        var header = await _context.DeviceHeaders
             .AsNoTracking()
             .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (header != null)
        {
            _context.DeviceHeaders.Remove(header);
            await _context.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
