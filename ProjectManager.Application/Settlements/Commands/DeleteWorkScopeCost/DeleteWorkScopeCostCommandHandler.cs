using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.DeleteWorkScopeCost;

public class DeleteWorkScopeCostCommandHandler : IRequestHandler<DeleteWorkScopeCostCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteWorkScopeCostCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteWorkScopeCostCommand request, CancellationToken cancellationToken)
    {
        var cost = await _context
            .WorkScopeCosts
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (cost != null)
        {
            _context.WorkScopeCosts.Remove(cost);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
