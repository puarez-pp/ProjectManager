using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Plants.Commands.AddPlant;

public class AddPlantCommandHandler : IRequestHandler<AddPlantCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IUserManagerService _userManagerService;
    private readonly IDateTimeService _dateTimeService;

    public AddPlantCommandHandler(
        IApplicationDbContext context,
        IUserManagerService userManagerService,
        IDateTimeService dateTimeService)
    {
        _context = context;
        _userManagerService = userManagerService;
        _dateTimeService = dateTimeService;
    }
    public async Task<Unit> Handle(AddPlantCommand request, CancellationToken cancellationToken)
    {
        var userId = await _userManagerService.CreateAsync(request.Email, request.Password, RolesDict.Telemetria);

        var user = await _context.Users
            .Include(x => x.Plant)
            .FirstOrDefaultAsync(x => x.Id == userId);

        user.FirstName = string.Empty;
        user.LastName = string.Empty;
        user.RegisterDateTime = _dateTimeService.Now;
        user.EmailConfirmed = false;

        user.Plant = new Plant();
        user.Plant.UserId = userId;
        user.Plant.Name = request.Name;
        user.Plant.Location = request.Location;
        user.Plant.CreatedAt = _dateTimeService.Now;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
