using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Settlements.Calculations;

namespace ProjectManager.Application.Settlements.Queries.GetAssumption;

public class GetAssumptionsQueryHandler : IRequestHandler<GetAssumptionQuery, AssumptionsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ISettlementService _calc;

    public GetAssumptionsQueryHandler(
        IApplicationDbContext context,
        ISettlementService calc)
    {
        _context = context;
        _calc = calc;
    }

    public async Task<AssumptionsVm> Handle(GetAssumptionQuery request, CancellationToken cancellationToken)
    {
        var projectEntity = await _context.Projects
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        var project = projectEntity?.ToBasicsProjectDto();

        var settlement = await _context.Settlements
            .AsNoTracking()
            .Where(x => x.ProjectId == request.Id)
            .Select(p => new SettlementDto
            {
                Id = p.Id,
                Assumption = new AssumptionDto
                {
                    Id = p.Assumption.Id,
                    Discount = p.Assumption.Discount,
                    Insurance = p.Assumption.Insurance,
                    MarginGen = p.Assumption.MarginGen,
                    MarginInstall = p.Assumption.MarginInstall,
                    Maturity = p.Assumption.Maturity,
                    CompanyCost = p.Assumption.CompanyCost,
                    CompanyGuarantee = p.Assumption.CompanyGuarantee,
                }
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (settlement == null)
        {
            return new AssumptionsVm
            {
                Project = project,
                Assumption = new AssumptionDto { Id = 0 }
            };
        }

        var assumption = settlement.Assumption;

        var offersBase = await _context.WorkScopeOffers
            .AsNoTracking()
            .Where(o => o.WorkScope.SettlementId == settlement.Id)
            .GroupBy(o => o.WorkScope.WorkScopeType)
            .Select(g => new WorkScopeBaseAmount
            {
                WorkScopeType = g.Key,
                TotalBase = g.Sum(x => x.Quantity * x.NetAmount)
            })
            .ToListAsync(cancellationToken);

        var costsBase = await _context.WorkScopeCosts
            .AsNoTracking()
            .Where(c => c.WorkScope.SettlementId == settlement.Id)
            .GroupBy(c => c.WorkScope.WorkScopeType)
            .Select(g => new WorkScopeBaseAmount
            {
                WorkScopeType = g.Key,
                TotalBase = g.Sum(x => x.Quantity * x.NetAmount)
            })
            .ToListAsync(cancellationToken);

        var summary = _calc.CalculateAssumptionsSummary(assumption, offersBase, costsBase);

        return new AssumptionsVm
        {
            Project = project,
            Assumption = settlement.Assumption,
            WorkScopesSum = summary
        };
    }
}
