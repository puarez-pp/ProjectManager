using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.EditWorkScopeOffer;

public class EditWorkScopeOfferCommandHandler : IRequestHandler<EditWorkScopeOfferCommand>
{
    private readonly IApplicationDbContext _context;

    public EditWorkScopeOfferCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(EditWorkScopeOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = await _context
            .WorkScopeOffers
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if(offer != null)
        {
            offer.Description = request.Description;
            offer.IsUsed = request.IsUsed;
            offer.UnitType = request.UnitType;
            offer.Quantity = request.Quantity;
            offer.NetAmount = request.NetAmount;
            offer.EuroNetAmount = request.EuroNetAmount;
            offer.EuroRate = request.EuroRate;
            offer.SubContractorId = request.SubContractorId;
        }
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
