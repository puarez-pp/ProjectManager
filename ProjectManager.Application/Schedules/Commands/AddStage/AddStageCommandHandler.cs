using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Schedules.Commands.AddStage;

public class AddStageCommandHandler : IRequestHandler<AddStageCommand>
{
    private readonly IApplicationDbContext _context;

    public AddStageCommandHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(AddStageCommand request, CancellationToken cancellationToken)
    {
        var stage = new ScheduleStage
        {
            ScheduleId = request.ScheduleId,
            Name = request.Name,
            Description = request.Description
        };
        await _context.ScheduleStages.AddAsync(stage);
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}

