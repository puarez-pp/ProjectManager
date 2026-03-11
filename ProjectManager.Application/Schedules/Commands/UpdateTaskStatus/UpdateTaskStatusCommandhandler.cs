using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Schedules.Commands.UpdateTaskStatus;

public class UpdateTaskStatusCommandhandler : IRequestHandler<UpdateTaskStatusCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTaskStatusCommandhandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _context
            .ScheduleTasks
            .FirstOrDefaultAsync(x => x.Id == request.TaskId);

        task.Status = request.Status;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}


