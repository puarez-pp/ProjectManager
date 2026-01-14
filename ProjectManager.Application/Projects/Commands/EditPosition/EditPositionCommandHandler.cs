using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Commands.EditPosition;

public class EditPositionCommandHandler : IRequestHandler<EditPositionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public EditPositionCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(EditPositionCommand request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Include(x => x.Divisions)
            .ThenInclude(x => x.Positions)
            .FirstOrDefaultAsync(x => x.Divisions.Any(y => y.Positions.Any(x => x.Id == request.Id)));

        var position = await _context
            .DivisionPositions
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (position != null)
        {
            position.DivisionPositionType = request.DivisionPositionType;
            position.Comment = request.Comment;
            position.SubContractorId = request.SubContractorId;
            position.IsCompleted= request.IsCompleted;
            
            project.EditDate = _dateTime.Now;
            project.UserUpdatorId = _currentUser.UserId;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
