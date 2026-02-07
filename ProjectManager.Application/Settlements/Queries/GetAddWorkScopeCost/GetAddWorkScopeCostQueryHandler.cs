using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.AddWorkScopeCost;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeCost;

public class GetAddWorkScopeCostQueryHandler : IRequestHandler<GetAddWorkScopeCostQuery, AddWorkScopeCostVm>
{
    private readonly IApplicationDbContext _context;

    public GetAddWorkScopeCostQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<AddWorkScopeCostVm> Handle(GetAddWorkScopeCostQuery request, CancellationToken cancellationToken)
    {
        var subContractors = await _context
            .SubContractors
            .Select(x => x.ToSubContractorBasicsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var workScope = await _context
            .WorkScopes
            .Where(w => w.Id == request.Id)
            .Select(w => new
            {
                SettlementId = w.SettlementId,
            }).FirstOrDefaultAsync();

        var vm = new AddWorkScopeCostVm
        {
            SettlementId = workScope.SettlementId,
            SubContractors = subContractors,
            ScopeCost = new AddWorkScopeCostCommand { WorkScopeId = request.Id }
        };
        return vm;
    }
}
