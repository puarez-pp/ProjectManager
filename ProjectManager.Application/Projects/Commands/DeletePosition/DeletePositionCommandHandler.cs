using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

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
            .AsNoTracking ()
            .Include(x=>x.ProjectScope)
            .ThenInclude(x=>x.Project)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (position.ProjectScope.Project != null)
        {
            position.ProjectScope.Project.EditAt = _dateTimeService.Now;
            position.ProjectScope.Project.UserUpdatorId = _currentUser.UserId;
        }

        if (position != null)
        {
            _context.PositionPosts.RemoveRange(_context.PositionPosts.Where(x => x.Id == request.Id));
            _context.ProjectScopePositions.Remove(position);
        }
        await _context.SaveChangesAsync();

        return Unit.Value;
            
    }
}
