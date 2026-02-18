using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Queries.GetProjectBasics;
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
        var project = await _context
            .Projects
            .AsNoTracking()
            .Where(p => p.Settlement.WorkScopes.Any(s => s.Id == request.Id))
            .Select(p => new ProjectBasicsDto
            {
                Id = p.Id,
                Name = p.Name,
            })
            .FirstOrDefaultAsync(cancellationToken);
            
        var subContractors = await _context
            .SubContractors
            .AsNoTracking ()
            .Select(x=>x.ToSubContractorBasicsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var workScopeType = await _context
            .WorkScopes
            .Where(w => w.Id == request.Id)
            .Select(w => w.WorkScopeType)
            .FirstOrDefaultAsync();

        var vm = new AddWorkScopeOfferVm
        {
            Project = project,
            ScopeType = workScopeType,
            SubContractors = subContractors,
            ScopeOffer = new AddWorkScopeOfferCommand 
            { 
                WorkScopeId = request.Id, 
                Description = "Oferta", 
                Quantity = 1, 
                NetAmount = 1 
            }
        };
        return vm;
    }
}
