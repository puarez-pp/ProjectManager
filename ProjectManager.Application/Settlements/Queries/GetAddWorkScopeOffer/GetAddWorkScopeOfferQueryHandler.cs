using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.AddWorkScopeOffer;
using ProjectManager.Application.SubContractors.Extension;

namespace ProjectManager.Application.Settlements.Queries.GetAddWorkScopeOffer;

public class GetAddWorkScopeOfferQueryHandler : IRequestHandler<GetAddWorkScopeOfferQuery, AddWorkScopeOfferVm>
{
    private readonly IApplicationDbContext _context;

    public GetAddWorkScopeOfferQueryHandler(
        IApplicationDbContext context,
        IFinanceService financeService )
    {
        _context = context;
    }
    public async Task<AddWorkScopeOfferVm> Handle(GetAddWorkScopeOfferQuery request, CancellationToken cancellationToken)
    {
        var subContractors = await _context
            .SubContractors
            .AsNoTracking ()
            .Select(x=>x.ToSubContractorBasicsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var workScope = await _context
            .WorkScopes
            .Where(w => w.Id == request.Id)
            .Select(w => new
            {
                SettlementId = w.SettlementId,
                WorkScopeType = w.WorkScopeType,
            }).FirstOrDefaultAsync();

        var vm = new AddWorkScopeOfferVm
        {
            SettlementId = workScope.SettlementId,
            ScopeType = workScope.WorkScopeType,
            SubContractors = subContractors,
            ScopeOffer = new AddWorkScopeOfferCommand { WorkScopeId = request.Id }
        };
        return vm;
    }
}
