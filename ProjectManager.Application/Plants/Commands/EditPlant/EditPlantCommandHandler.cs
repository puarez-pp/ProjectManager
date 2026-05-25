using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Plants.Commands.EditPlant;

public class EditPlantCommandHandler : IRequestHandler<EditPlantCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTime;

    public EditPlantCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(EditPlantCommand request, CancellationToken cancellationToken)
    {

        var user = await _context
            .Users
            .Include(x => x.Plant)
            .FirstOrDefaultAsync(x => x.Id == request.Id);


        if (user.Plant == null)
        {
            user.Plant = new Plant();
            user.Plant.CreatedAt = _dateTime.Now;
        }
        user.Email = request.Email;
        user.Plant.UserId = request.Id;
        user.Plant.Name = request.Name;
        user.Plant.Location = request.Location;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
