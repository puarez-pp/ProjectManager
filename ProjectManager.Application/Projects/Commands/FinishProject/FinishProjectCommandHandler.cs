using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Projects.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public FinishProjectCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (project != null)
        {
            project.EditAt = _dateTime.Now;
            project.FinishedAt = _dateTime.Now;
            project.UserUpdatorId = _currentUser.UserId;
            project.Status = ProjectStatus.Completed;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
