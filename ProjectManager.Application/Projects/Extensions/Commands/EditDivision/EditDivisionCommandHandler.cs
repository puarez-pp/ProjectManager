using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Commands.EditDivision;

public class EditDivisionCommandHandler : IRequestHandler<EditDivisionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTime;
    private readonly ICurrentUserService _currentUser;

    public EditDivisionCommandHandler(IApplicationDbContext context,
        IDateTimeService dateTime,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTime = dateTime;
        _currentUser = currentUser;
    }
    public async Task<Unit> Handle(EditDivisionCommand request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .Include(x => x.Divisions)
            .Where(x => x.Divisions.Any(y => y.Id == request.Id))
            .Select(x=>x)
            .FirstOrDefaultAsync();
            
        var division = await _context
            .Divisions
            .FirstOrDefaultAsync(x=>x.Id == request.Id);

        if (division!=null)
        {
            division.UserId = request.UserId;
            await _context.SaveChangesAsync();
            project.EditDate = _dateTime.Now;
            project.UserUpdatorId = _currentUser.UserId;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
