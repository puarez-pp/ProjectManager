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
            .DivisionPositions
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        var project = await _context
            .Projects
            .Include(x => x.Divisions)
            .ThenInclude(x => x.Positions)
            .Where(x => x.Divisions.Any(y => y.Positions.Any(c => c.Id == request.Id)))
            .FirstOrDefaultAsync();

        if (project != null)
        {
            project.EditDate = _dateTimeService.Now;
            project.UserUpdatorId = _currentUser.UserId;
            await _context.SaveChangesAsync(cancellationToken);
        }

        if (position != null)
        {
            _context.DivisionPositions.Remove(position);
            await _context.SaveChangesAsync(cancellationToken);
        }


        return Unit.Value;
            
    }
}
