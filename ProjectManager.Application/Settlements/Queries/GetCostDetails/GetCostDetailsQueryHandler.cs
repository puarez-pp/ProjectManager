using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Queries.GetGenerator;

namespace ProjectManager.Application.Settlements.Queries.GetCostDetails;

public class GetCostDetailsQueryHandler : IRequestHandler<GetCostDetailsQuery, CostDetailsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetCostDetailsQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<CostDetailsVm> Handle(GetCostDetailsQuery request, CancellationToken cancellationToken)
    {
        var workScopes = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.SettlementId == request.Id)
            .Select(s => new WorkScopDto
            {
                Id = s.Id,
                Description = s.Description,
                Order = s.Order,
                Total = _financeService.RoundAmount(s.WorkScopeCosts.Sum(y => y.Quantity * y.NetAmount)),
                Costs = s.WorkScopeCosts.Select(y => new WorkScopeCostDto
                {
                    Id = y.Id,
                    Description = y.Description,
                    Order = y.Order,
                    UnitType = y.UnitType,
                    Quantity = y.Quantity,
                    NetAmount = y.NetAmount,
                    Total = _financeService.RoundAmount(y.Quantity * y.NetAmount),
                    SubContractor = y.SubContractor.Name,
                }).OrderBy(x => x.Order)
                .ToList()
            }).OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);
        
        var vm = new CostDetailsVm
        {
            WorkScopes = workScopes
        };
        return vm;
    }
}
