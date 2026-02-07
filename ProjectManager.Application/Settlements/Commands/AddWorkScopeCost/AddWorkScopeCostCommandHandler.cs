using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Commands.AddWorkScopeCost;

public class AddWorkScopeCostCommandHandler : IRequestHandler<AddWorkScopeCostCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddWorkScopeCostCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    async Task<int> IRequestHandler<AddWorkScopeCostCommand, int>.Handle(AddWorkScopeCostCommand request, CancellationToken cancellationToken)
    {
        var order = await _context
            .WorkScopeCosts
            .AsNoTracking()
            .Where(x => x.WorkScopeId == request.WorkScopeId)
            .MaxAsync(x => x.Order);

        var cost = new WorkScopeCost
        {
            WorkScopeId = request.WorkScopeId,
            Description = request.Description,
            CostStatusType = request.CostStatusType,
            Order = order + 1,
            UnitType = request.UnitType,
            Quantity = request.Quantity,
            NetAmount = request.NetAmount,
            EuroNetAmount = request.EuroNetAmount,
            EuroRate = request.EuroRate,
            SubContractorId = request.SubContractorId,
        };
        await _context.WorkScopeCosts.AddAsync(cost);
        await _context.SaveChangesAsync(cancellationToken);
        return cost.Id;
    }

}
