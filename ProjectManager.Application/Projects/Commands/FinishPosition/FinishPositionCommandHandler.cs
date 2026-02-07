using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Projects.Commands.FinishPosition;

public class FinishPositionCommandHandler : IRequestHandler<FinishPositionCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public FinishPositionCommandHandler(
        IApplicationDbContext context,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(FinishPositionCommand request, CancellationToken cancellationToken)
    {
        var position = await _context
            .ProjectScopePositions
            .FirstOrDefaultAsync(x => x.Id == request.Id);
        position = position ?? throw new ArgumentException(nameof(position));
        position.IsCompleted = request.IsCompleted;
        position.CompletionDate = _dateTimeService.Now;
        await _context.SaveChangesAsync();
        return Unit.Value;
    }
}
