using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Commands.ClosePosition;

public class ClosePositionCommandHandler : IRequestHandler<ClosePositionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public ClosePositionCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(ClosePositionCommand request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .Include(x => x.Divisions)
            .ThenInclude(x => x.Positions)
            .FirstOrDefaultAsync(x => x.Divisions.Any(y => y.Positions.Any(x => x.Id == request.Id)));

        project
       .Divisions
       .SelectMany(x => x.Positions)
       .FirstOrDefault(x => x.Id == request.Id)
       .PerformedData = _dateTime.Now;

        project
       .Divisions
       .SelectMany(x => x.Positions)
       .FirstOrDefault(x => x.Id == request.Id)
       .IsCompleted = true;

        project.UserUpdatorId = _currentUser.UserId;
        project.EditDate = _dateTime.Now;
        await _context.SaveChangesAsync(cancellationToken);


        var post = new Domain.Entities.PositionPost
        {
            PositionId = request.Id,
            Content = $"{project.Divisions.SelectMany(x => x.Positions).FirstOrDefault(x => x.Id == request.Id).DivisionPositionType} zakończono.",
            UserId = _currentUser.UserId,
            CreatedDate = _dateTime.Now,
        };
        await _context.PositionPosts.AddAsync(post);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;

    }
}
