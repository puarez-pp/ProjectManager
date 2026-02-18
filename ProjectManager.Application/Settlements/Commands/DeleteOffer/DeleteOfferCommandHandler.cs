using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Settlements.Commands.DeleteOffer;

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOfferCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        var offer = await _context
            .WorkScopeOffers
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (offer != null)
        {
            _context.WorkScopeOffers.Remove(offer);
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
