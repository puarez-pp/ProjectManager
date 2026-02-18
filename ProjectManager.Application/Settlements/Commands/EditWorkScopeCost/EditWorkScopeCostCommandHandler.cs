using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.EditWorkScopeCost;

public class EditWorkScopeCostCommandHandler : IRequestHandler<EditWorkScopeCostCommand>
{
    private readonly IApplicationDbContext _context;

    public EditWorkScopeCostCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditWorkScopeCostCommand request, CancellationToken cancellationToken)
    {
        var cost = await _context
            .WorkScopeCosts
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (cost != null)
        {
            cost.Description = request.Description;
            cost.CostStatusType = request.CostStatusType;
            cost.UnitType = request.UnitType;
            cost.Quantity = request.Quantity;
            cost.NetAmount = request.NetAmount;
            cost.EuroNetAmount = request.EuroNetAmount;
            cost.EuroRate = request.EuroRate;
            cost.SubContractorId = request.SubContractorId;
        }
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
