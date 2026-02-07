using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using System;

namespace ProjectManager.Application.Projects.Commands.EditPosition;

public class EditPositionCommandHandler : IRequestHandler<EditPositionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTimeService;

    public EditPositionCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTimeService = dateTime;
    }
    public async Task<Unit> Handle(EditPositionCommand request, CancellationToken cancellationToken)
    {
        var position = await _context
            .ProjectScopePositions
            .Include(x => x.ProjectScope)
            .ThenInclude(x => x.Project)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (position.ProjectScope.Project != null)
        {
            position.ProjectScope.Project.EditAt = _dateTimeService.Now;
            position.ProjectScope.Project.UserUpdatorId = _currentUser.UserId;
        }

        if (position != null)
        {
            position.Description = request.Description;
            position.CompletionDate = request.CompletionDate;
        }
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
