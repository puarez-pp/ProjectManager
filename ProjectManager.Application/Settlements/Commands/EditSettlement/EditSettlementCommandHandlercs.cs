using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.EditSettlement;

public class EditSettlementCommandHandlercs : IRequestHandler<EditSettlementCommand>
{
    private readonly IApplicationDbContext _context;

    public EditSettlementCommandHandlercs(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditSettlementCommand request, CancellationToken cancellationToken)
    {
        var settlement = await _context
            .Settlements
            .Include(s => s.Assumption)
            .FirstOrDefaultAsync(s => s.ProjectId == request.Id, cancellationToken);
        if (settlement != null)
        {
            settlement.Id = request.Id;
            settlement.Assumption.MarginGen = request.MarginGen;
            settlement.Assumption.MarginInstall = request.MarginInstall;
            settlement.Assumption.Discount = request.Discount;
            settlement.Assumption.Maturity = request.Maturity;
            settlement.Assumption.CompanyCost = request.CompanyCost;
            settlement.Assumption.CompanyGuarantee = request.CompanyGuarantee;
            settlement.Assumption.Insurance = request.Insurance;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;

    }
}
