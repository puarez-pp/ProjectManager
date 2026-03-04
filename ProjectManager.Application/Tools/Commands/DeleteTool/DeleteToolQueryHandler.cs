using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Tools.Commands.DeleteTool;

public class DeleteToolQueryHandler : IRequestHandler<DeleteToolQuery>
{
    private readonly IApplicationDbContext _context;

    public DeleteToolQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteToolQuery request, CancellationToken cancellationToken)
    {
        var tool = await _context
            .Tools
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (tool != null)
        {
            _context.Rents.RemoveRange(tool.Rents);
            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
        }
        return Unit.Value;
    }
}
