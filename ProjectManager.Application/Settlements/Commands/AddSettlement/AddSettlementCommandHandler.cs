using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Commands.AddSettlement;
public class AddSettlementCommandHandler : IRequestHandler<AddSettlementCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUser;
    private int _createdSettlementId;

    public AddSettlementCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _currentUser = currentUser;
    }

    public async Task<int> Handle(AddSettlementCommand request, CancellationToken cancellationToken)
    {
        var projectType = _context
            .Projects
            .Where(p => p.Id == request.Id).Select(x => x.ProjectType)
            .FirstOrDefault();

        var settlement = new Settlement
        {
            ProjectId = request.Id,
            UserId = _currentUser.UserId,
            CreatedDate = _dateTimeService.Now,
        };
        await _context.Settlements.AddAsync(settlement, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        _createdSettlementId = _context.Settlements.Where(s => s.ProjectId == request.Id).Select(x => x.Id).FirstOrDefault();
        settlement.Assumption = new Assumption
        {
            SettlementId = _createdSettlementId,
            MarginGen = request.MarginGen,
            MarginInstall = request.MarginInstall,
            Discount = request.Discount,
            Maturity = request.Maturity,
            CompanyCost = request.CompanyCost,
            CompanyGuarantee = request.CompanyGuarantee,
            Insurance = request.Insurance,
        };
        await _context.Assumptions.AddAsync(settlement.Assumption, cancellationToken);

        var workScopePositions = await _context
                    .WorkScopeTemplates
                    .AsNoTracking()
                    .OrderBy(x => x.Order)
                    .Where(x => x.ProjectType == projectType)
                    .Include(x => x.WorkScopePositions.OrderBy(x=>x.Order))
                    .Select(x => x.WorkScopePositions.ToList())
                    .ToListAsync(cancellationToken);


        foreach (var workScopePos in workScopePositions)
        {
            var workScope = new WorkScope
            {
                SettlementId = _createdSettlementId,
                Description = workScopePos.First().WorkScopeTemplate.Description,
                Order = workScopePos.First().WorkScopeTemplate.Order,
            };
            await _context.WorkScopes.AddAsync(workScope, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            foreach (var position in workScopePos)
            {
                var workScopeOffer = new WorkScopeOffer
                {
                    WorkScopeId = workScope.Id,
                    Description = position.Description,
                    Order = position.Order,
                };
                await _context.WorkScopeOffers.AddAsync(workScopeOffer, cancellationToken);

                var workScopeCost = new WorkScopeCost
                {
                    WorkScopeId = workScope.Id,
                    Description = position.Description,
                    Order = position.Order,
                };
                await _context.WorkScopeCosts.AddAsync(workScopeCost, cancellationToken);
            }
        }
        await _context.SaveChangesAsync(cancellationToken);
        return _createdSettlementId;
    }

}
