using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
using ProjectManager.Application.Settlements.Calculations;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Queries.GetScopeTypeOffer;

public class GetScopeTypeOfferQueryHandler : IRequestHandler<GetScopeTypeOfferQuery, WorkScopeTypeVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ISettlementService _calc;

    public GetScopeTypeOfferQueryHandler(
        IApplicationDbContext context,
        ISettlementService calc)
    {
        _context = context;
        _calc = calc;
    }

    public async Task<WorkScopeTypeVm> Handle(GetScopeTypeOfferQuery request, CancellationToken cancellationToken)
    {
        var margin = await _context.Assumptions
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id)
            .Select(x => request.ScopeType == WorkScopeType.Agregat ? x.MarginGen : x.MarginInstall)
            .FirstOrDefaultAsync(cancellationToken);

        var project = await _context.Projects
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .Select(s => new ProjectBasicsDto
            {
                Id = s.Id,
                Name = s.Name,
                Number = s.Number
            })
            .FirstOrDefaultAsync(cancellationToken);

        var rawScopes = await _context.WorkScopes
            .AsNoTracking()
            .Where(x => x.Settlement.ProjectId == request.Id && x.WorkScopeType == request.ScopeType)
            .Select(s => new RawWorkScopeOffer
            {
                Id = s.Id,
                Description = s.Description,
                Order = s.Order,
                Offers = s.WorkScopeOffers.Select(y => new RawOfferItem
                {
                    Id = y.Id,
                    Description = y.Description,
                    Order = y.Order,
                    IsUsed = y.IsUsed,
                    UnitType = y.UnitType,
                    Quantity = y.Quantity,
                    NetAmount = y.NetAmount,
                    SubContractor = y.SubContractor.Name
                }).ToList()
            })
            .OrderBy(x => x.Order)
            .ToListAsync(cancellationToken);

        var workScopes = _calc.CalculateScopeTypeOffer(rawScopes, margin);

        return new WorkScopeTypeVm
        {
            Project = project,
            WorkScopeType = request.ScopeType,
            Margin = margin,
            Total = workScopes.Sum(x => x.Total),
            WorkScopes = workScopes.ToList()
        };
    }
}
