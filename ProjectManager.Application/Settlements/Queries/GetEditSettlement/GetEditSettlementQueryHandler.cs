using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.EditSettlement;

namespace ProjectManager.Application.Settlements.Queries.GetEditSettlement;

public class GetEditSettlementQueryHandler : IRequestHandler<GetEditSettlementQuery, EditSettlementCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditSettlementQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditSettlementCommand> Handle(GetEditSettlementQuery request, CancellationToken cancellationToken)
    {
        var settlement = await _context
            .Settlements
            .Include(s => s.Assumption)
            .FirstOrDefaultAsync(s => s.ProjectId == request.Id, cancellationToken);

        if (settlement == null)
        {
            return null;
        }

        return new EditSettlementCommand
        {
            Id = settlement.Id,
            MarginGen = settlement.Assumption.MarginGen,
            MarginInstall = settlement.Assumption.MarginInstall,
            Discount = settlement.Assumption.Discount,
            Maturity = settlement.Assumption.Maturity,
            CompanyCost = settlement.Assumption.CompanyCost,
            CompanyGuarantee = settlement.Assumption.CompanyGuarantee,
            Insurance = settlement.Assumption.Insurance,
        };
    }
}
