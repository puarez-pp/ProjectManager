using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Commands.AddSettlement;
public class AddSettlementCommandHandler : IRequestHandler<AddSettlementCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUser;

    public AddSettlementCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _currentUser = currentUser;
    }

    public async Task<Unit> Handle(AddSettlementCommand request, CancellationToken cancellationToken)
    {
        var projectType = await _context
            .Projects
            .Where(p => p.Id == request.Id)
            .Select(x => x.ProjectType)
            .FirstOrDefaultAsync();

        // 1. Pobranie szablonów
        var templates = await _context
            .WorkScopeTemplates
            .Include(x => x.WorkScopePositions)
            .Where(x => x.ProjectType == projectType)
            .OrderBy(x => x.Order)
            .ToListAsync();

        if (!templates.Any())
            throw new InvalidOperationException("Brak szablonów dla podanego typu projektu.");

        // 2. Utworzenie Settlement
        var settlement = new Settlement
        {
            ProjectId = request.Id,
            UserId = _currentUser.UserId,
            CreatedAt = _dateTimeService.Now,
            Assumption = new Assumption
            {
                MarginGen = request.MarginGen,
                MarginInstall = request.MarginInstall,
                Discount = request.Discount,
                Maturity = request.Maturity,
                CompanyCost = request.CompanyCost,
                CompanyGuarantee = request.CompanyGuarantee,
                Insurance = request.Insurance,
            }
        };

        // 3. Tworzenie WorkScope na podstawie szablonów
        foreach (var template in templates)
        {
            var workScope = new WorkScope
            {
                WorkScopeType = template.WorkScopeType,
                Description = template.Description,
                Order = template.Order
            };

            // 4. Tworzenie pozycji WorkScope (Offer/Cost)
            foreach (var pos in template.WorkScopePositions.OrderBy(p => p.Order))
            {
                workScope.WorkScopeOffers.Add(new WorkScopeOffer
                {
                    Description = pos.Description,
                    Comment = string.Empty,
                    Order = pos.Order,
                    IsUsed = true,
                    UnitType = UnitType.Set, 
                    Quantity = 1,
                    NetAmount = 0,
                    EuroNetAmount = 0,
                    EuroRate = 0,
                    SubContractorId = 1
                });

                workScope.WorkScopeCosts.Add(new WorkScopeCost
                {
                    Description = pos.Description,
                    Order = pos.Order,
                    CostStatusType = CostStatusType.Invoice,
                    UnitType = UnitType.Set,
                    Quantity = 1,
                    NetAmount = 0,
                    EuroNetAmount = 0,
                    EuroRate = 0,
                    SubContractorId = 1
                });
            }
            settlement.WorkScopes.Add(workScope);
        }
        // 5. Zapis do bazy
        _context.Settlements.Add(settlement);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}

