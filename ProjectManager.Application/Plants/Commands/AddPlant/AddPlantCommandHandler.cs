using MediatR;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Plants.Commands.AddPlant;

public class AddPlantCommandHandler : IRequestHandler<AddPlantCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public AddPlantCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(AddPlantCommand request, CancellationToken cancellationToken)
    {
        var plant = new Plant
        {
            Name = request.Name,
            Location = request.Location,
            UserId = _currentUser.UserId,
            CreatedAt = _dateTime.Now  
        };
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
