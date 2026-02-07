using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.EditWorkScopeCost;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeCost;

public class GetEditWorkScopeCostQueryHandler : IRequestHandler<GetEditWorkScopeCostQuery, EditWorkScopeCostVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditWorkScopeCostQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditWorkScopeCostVm> Handle(GetEditWorkScopeCostQuery request, CancellationToken cancellationToken)
    {
        var subContractors = await _context
           .SubContractors
           .AsNoTracking ()
           .Select(x => x.ToSubContractorBasicsDto())
           .AsNoTracking()
           .ToListAsync(cancellationToken);

        var cost = await _context
            .WorkScopeCosts
            .Where(c => c.Id == request.Id)
            .Select(c => new
            {
                SettlementId = c.WorkScope.SettlementId,
                WorkScopeCost = c
            })
            .FirstOrDefaultAsync();


        var vm = new EditWorkScopeCostVm
        {
            SettlementId = cost.SettlementId,
            SubContractors = subContractors,
            ScopeCost = new EditWorkScopeCostCommand
            {
                Id = request.Id,
                Description = cost.WorkScopeCost.Description,
                Quantity = cost.WorkScopeCost.Quantity,
                UnitType = cost.WorkScopeCost.UnitType,
                NetAmount = cost.WorkScopeCost.NetAmount,
                EuroNetAmount = cost.WorkScopeCost.EuroNetAmount,
                EuroRate = cost.WorkScopeCost.EuroRate,
                SubContractorId = cost.WorkScopeCost.SubContractorId
            }
        };
        return vm;
    }
}
