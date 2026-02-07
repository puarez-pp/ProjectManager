using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Commands.CopySettlement;

public class CopySettlementQueryHandler : IRequestHandler<CopySettlementQuery>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTimeService;

    public CopySettlementQueryHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(CopySettlementQuery request, CancellationToken cancellationToken)
    {
        var source = await LoadFullSettlement(request.SourceId);
        if (source == null)
        {
            var clone = new Settlement
            {
                ProjectId = request.CloneId,
                UserId = _currentUser.UserId,
                CreatedAt = _dateTimeService.Now,
                Assumption = new Assumption
                {
                    MarginGen = source.Assumption.MarginGen,
                    MarginInstall = source.Assumption.MarginInstall,
                    Discount = source.Assumption.Discount,
                    Maturity = source.Assumption.Maturity,
                    CompanyCost = source.Assumption.CompanyCost,
                    CompanyGuarantee = source.Assumption.CompanyGuarantee,
                    Insurance = source.Assumption.Insurance
                },
                WorkScopes = source.WorkScopes.Select(ws => new WorkScope
                {
                    WorkScopeType = ws.WorkScopeType,
                    Description = ws.Description,
                    Order = ws.Order,
                    WorkScopeOffers = ws.WorkScopeOffers.Select(o => new WorkScopeOffer
                    {
                        Description = o.Description,
                        Comment = o.Comment,
                        Order = o.Order,
                        IsUsed = o.IsUsed,
                        UnitType = o.UnitType,
                        Quantity = o.Quantity,
                        NetAmount = o.NetAmount,
                        EuroNetAmount = o.EuroNetAmount,
                        EuroRate = o.EuroRate,
                        SubContractorId = o.SubContractorId
                    }).ToList(),
                    WorkScopeCosts = ws.WorkScopeCosts.Select(c => new WorkScopeCost
                    {
                        Description = c.Description,
                        Order = c.Order,
                        UnitType = c.UnitType,
                        Quantity = c.Quantity,
                        NetAmount = c.NetAmount,
                        EuroNetAmount = c.EuroNetAmount,
                        EuroRate = c.EuroRate,
                        SubContractorId = c.SubContractorId

                    }).ToList()
                }).ToList()
            };
            _context.Settlements.Add(clone);
            await _context.SaveChangesAsync();
        }
        return Unit.Value;
    }

                
    private async Task<Settlement> LoadFullSettlement(int id)
    {
        return await _context
            .Settlements
            .Where(s => s.ProjectId == id)
            .Include(s => s.Assumption)
            .Include(s => s.WorkScopes)
                .ThenInclude(ws => ws.WorkScopeOffers)
                    .ThenInclude(o => o.SubContractor)
            .Include(s => s.WorkScopes)
                .ThenInclude(ws => ws.WorkScopeCosts)
                    .ThenInclude(o => o.SubContractor)
            .FirstOrDefaultAsync();
    }

}
