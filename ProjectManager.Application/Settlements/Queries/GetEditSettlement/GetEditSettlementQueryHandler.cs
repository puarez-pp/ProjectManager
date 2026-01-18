using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Extensions;
using ProjectManager.Application.Settlements.Commands.EditSettlement;

namespace ProjectManager.Application.Settlements.Queries.GetEditSettlement;

public class GetEditSettlementQueryHandler : IRequestHandler<GetEditSettlementQuery, EditSettlementVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditSettlementQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditSettlementVm> Handle(GetEditSettlementQuery request, CancellationToken cancellationToken)
    {
        var settlement = await _context
            .Projects
            .Include(p => p.Settlement)
            .ThenInclude(s => s.Assumption)
            .FirstOrDefaultAsync(p => p.Settlement.Id == request.Id, cancellationToken);

        if (settlement == null) { return null; }
        var assumption = settlement.Settlement.Assumption;
        var vm = new EditSettlementVm
        {
            Project = settlement.ToProjectDto(),
            Settlement = new EditSettlementCommand
            {
                Id = settlement.Settlement.Id,
                MarginGen = assumption.MarginGen,
                MarginInstall = assumption.MarginInstall,
                Discount = assumption.Discount,
                Maturity = assumption.Maturity,
                CompanyCost = assumption.CompanyCost,
                CompanyGuarantee = assumption.CompanyGuarantee,
                Insurance = assumption.Insurance,
            },
        };
        return vm;
    }
}
