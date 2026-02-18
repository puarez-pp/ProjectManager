using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using System.Linq.Dynamic.Core;

namespace ProjectManager.Application.Settlements.Commands.AddWorkScopeOffer;

public class AddWorkScopeOfferCommandHandler : IRequestHandler<AddWorkScopeOfferCommand>
{
    private readonly IApplicationDbContext _context;

    public AddWorkScopeOfferCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddWorkScopeOfferCommand request, CancellationToken cancellationToken)
    {
        var order = await _context
            .WorkScopeOffers
            .AsNoTracking()
            .Where(x => x.WorkScopeId == request.WorkScopeId)
            .Select(x => x.Order)
            .ToListAsync(cancellationToken);

        int maxOrder = order.Count > 0 ? order.Max() : 0;

        var offer = new WorkScopeOffer
        {
            WorkScopeId = request.WorkScopeId,
            Description = request.Description,
            Comment = request.Comment,
            Order = maxOrder + 1,
            IsUsed = request.IsUsed,
            UnitType = request.UnitType,
            Quantity = request.Quantity,
            NetAmount = request.NetAmount,
            EuroNetAmount = request.EuroNetAmount,
            EuroRate = request.EuroRate,
            SubContractorId = request.SubContractorId,
        };
        await _context.WorkScopeOffers.AddAsync(offer);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
