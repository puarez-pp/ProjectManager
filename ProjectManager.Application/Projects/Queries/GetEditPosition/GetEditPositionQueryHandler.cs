using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Projects.Commands.EditPosition;

namespace ProjectManager.Application.Projects.Queries.GetEditPosition;

public class GetEditPositionQueryHandler : IRequestHandler<GetEditPositionQuery, EditPositionCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditPositionQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

public async Task<EditPositionCommand> Handle(GetEditPositionQuery request, CancellationToken cancellationToken)
    {
        var position = await _context
            .ProjectScopePositions
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return new EditPositionCommand
        {
            Id = request.Id,
            Description = position.Description,
            CompletionDate = position.CompletionDate
        };
    }
}
