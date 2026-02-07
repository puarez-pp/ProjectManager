using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Commands.AddPosition;

public class AddPositionCommandHandler : IRequestHandler<AddPositionCommand>
{
    private readonly IApplicationDbContext _context;

    public AddPositionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddPositionCommand request, CancellationToken cancellationToken)
    {
        var position = new ProjectScopePosition
        {
            ProjectScopeId = request.ProjectScopeId,
            Description = request.Description,
            Order = await _context
            .ProjectScopePositions
            .Where(x => x.ProjectScopeId == request.ProjectScopeId)
            .MaxAsync(x => x.Order) + 1
        };
        await _context.ProjectScopePositions.AddAsync(position);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
