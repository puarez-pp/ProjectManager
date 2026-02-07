using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Settlements.Commands.EditWorkScopeOffer;
using ProjectManager.Application.SubContractors.Extension;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Settlements.Queries.GetEditWorkScopeOffer;

public class GetEditWorkScopeOfferQueryHandler : IRequestHandler<GetEditWorkScopeOfferQuery, EditWorkScopeOfferVm>
{
    private readonly IApplicationDbContext _context;

    public GetEditWorkScopeOfferQueryHandler(
        IApplicationDbContext context
        )
    {
        _context = context;
    }
    public async Task<EditWorkScopeOfferVm> Handle(GetEditWorkScopeOfferQuery request, CancellationToken cancellationToken)
    {
        var subContractors = await _context
            .SubContractors
            .Select(x => x.ToSubContractorBasicsDto())
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var offer = await _context
            .WorkScopeOffers
            .Where(o => o.Id == request.Id)
            .Select(o => new 
            { 
                SettlementId = o.WorkScope.SettlementId, 
                WorkScopeType = o.WorkScope.WorkScopeType, 
                WorkScopeOffer = o 
            }).FirstOrDefaultAsync();



        var vm = new EditWorkScopeOfferVm
        {
            SettlementId = offer.SettlementId,
            ScopeType = offer.WorkScopeType,
            SubContractors = subContractors,
            ScopeOffer = new EditWorkScopeOfferCommand 
            { 
                Id = request.Id,
                Description = offer.WorkScopeOffer.Description,
                Comment = offer.WorkScopeOffer.Comment,
                Quantity = offer.WorkScopeOffer.Quantity,
                UnitType = offer.WorkScopeOffer.UnitType,
                NetAmount = offer.WorkScopeOffer.NetAmount,
                EuroNetAmount = offer.WorkScopeOffer.EuroNetAmount,
                EuroRate = offer.WorkScopeOffer.EuroRate,
                IsUsed = offer.WorkScopeOffer.IsUsed,
                SubContractorId = offer.WorkScopeOffer.SubContractorId
            }
        };
        return vm;
    }
}
