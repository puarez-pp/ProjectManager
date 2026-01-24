using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Settlements.Commands.AddWorkScopeOffer;

public class AddWorkScopeOfferCommandHandler : IRequestHandler<AddWorkScopeOfferCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddWorkScopeOfferCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddWorkScopeOfferCommand request, CancellationToken cancellationToken)
    {
        var order = await _context
            .WorkScopeOffers
            .AsNoTracking()
            .Where(x => x.WorkScopeId == request.WorkScopeId)
            .MaxAsync(x => x.Order);

        var offer = new WorkScopeOffer
        {
            WorkScopeId = request.WorkScopeId,
            Description = request.Description,
            Comment = request.Comment,
            Order = order + 1,
            IsUsed = false,
            UnitType = UnitType.Set,
            Quantity = request.Quantity,
            NetAmount = request.NetAmount,
            EuroNetAmount = request.EuroNetAmount,
            EuroRate = request.EuroRate,
            SubContractorId = request.SubContractorId,
        };
        await _context.WorkScopeOffers.AddAsync(offer);
        await _context.SaveChangesAsync(cancellationToken);
        return offer.Id;
    }
}
