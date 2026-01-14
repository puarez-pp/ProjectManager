using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Commands.AddPosition;

public class AddPositionCommandHandler : IRequestHandler<AddPositionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public AddPositionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AddPositionCommand request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .Include(x=>x.Divisions)
            .FirstOrDefaultAsync(x=>x.Divisions.Any(x=>x.Id == request.DivisionId));

        var position = new Domain.Entities.DivisionPosition();
        position.DivisionPositionType = request.DivisionPositionType;
        position.Comment = request.Comment;
        position.DivisionId = request.DivisionId;
        position.SubContractorId = 1;
        await _context.DivisionPositions.AddAsync(position);
        await _context.SaveChangesAsync(cancellationToken);
        return project.Id ;
    }
}
