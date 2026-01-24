using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;
using System.Linq.Dynamic.Core;

namespace ProjectManager.Application.Settlements.Queries.GetGenerator;

public class GetScopeTypeOfferQueryHandler : IRequestHandler<GetScopeTypeOfferQuery, WorkScopeTypeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IFinanceService _financeService;

    public GetScopeTypeOfferQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService)
    {
        _context = context;
        _financeService = financeService;
    }
    public async Task<WorkScopeTypeVm> Handle(GetScopeTypeOfferQuery request, CancellationToken cancellationToken)
    {
        var margin = await _context
            .Assumptions
            .AsNoTracking()
            .Where(x=>x.SettlementId == request.Id)
            .Select(x => (request.ScopeType == WorkScopeType.Agregat ? x.MarginGen : x.MarginInstall))
            .FirstOrDefaultAsync();

        var workScopes = await _context
            .WorkScopes
            .AsNoTracking()
            .Where(x => x.SettlementId == request.Id && x.WorkScopeType == request.ScopeType)
            .Select(s => new WorkScopDto
            {
                Id = s.Id,
                Description = s.Description,
                Order = s.Order,
                Total = s.WorkScopeOffers.Sum(y => _financeService.ApplyMargin(y.Quantity * y.NetAmount, margin)),
                Offers = s.WorkScopeOffers.Select(y => new WorkScopeOfferDto
                {
                    Id = y.Id,
                    Description = y.Description,
                    Order = y.Order,
                    IsUsed = y.IsUsed,
                    UnitType = y.UnitType,
                    Quantity = y.Quantity,
                    NetAmount = y.NetAmount,
                    Total = _financeService.ApplyMargin(y.Quantity * y.NetAmount, margin),
                    SubContractor = y.SubContractor.Name,
                }).OrderBy(x => x.Order)
                .ToList()
            }).OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var vm = new WorkScopeTypeVm
        {
            WorkScopeType = WorkScopeType.Agregat,
            Margin = margin,
            Total = workScopes.Sum(x => x.Total),
            WorkScopes = workScopes.ToList(),
        };
        return vm;

    }
}
