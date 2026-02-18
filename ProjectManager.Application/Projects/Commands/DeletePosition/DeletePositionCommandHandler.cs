using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Projects.Commands.DeletePosition;

public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly ICurrentUserService _currentUser;

    public DeletePositionCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTimeService = dateTimeService;
        _currentUser = currentUser;
    }
    public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        var position = await _context
            .ProjectScopePositions
            .Include(x => x.ProjectScope)
            .ThenInclude(x => x.Project)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (position == null)
            return Unit.Value;

        if (position.ProjectScope?.Project != null)
        {
            position.ProjectScope.Project.EditAt = _dateTimeService.Now;
            position.ProjectScope.Project.UserUpdatorId = _currentUser.UserId;
        }
        var posts = _context.PositionPosts.Where(x => x.PositionId == request.Id);
        _context.PositionPosts.RemoveRange(posts);

        _context.ProjectScopePositions.Remove(position);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;

    }

}
