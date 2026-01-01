using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Projects.Commands.EditProject;

public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTime;
    private readonly ICurrentUserService _currentUser;

    public EditProjectCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTime,
        ICurrentUserService currentUser)
    {
        _context = context;
        _dateTime = dateTime;
        _currentUser = currentUser;
    }
    public async Task<Unit> Handle(EditProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context
            .Projects
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (project != null)
        {
            project.Name = request.Name;
            project.Number = request.Number;
            project.Comment = request.Comment;
            project.ProjectType = request.ProjectType;
            project.Status = request.ProjectStatus;
            project.ClientId = request.ClientId;
            project.Sharepoint = request.Sharepoint;
            project.EditDate = _dateTime.Now;
            project.UserUpdatorId = _currentUser.UserId;
            project.UserPMId = request.UserPMId;
            await _context.SaveChangesAsync(cancellationToken);
        }
        return Unit.Value;
    }
}
