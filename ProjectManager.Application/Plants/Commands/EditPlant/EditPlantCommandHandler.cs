using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Application.Plants.Commands.EditPlant;

public class EditPlantCommandHandler : IRequestHandler<EditPlantCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUser;
    private readonly IDateTimeService _dateTime;

    public EditPlantCommandHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUser,
        IDateTimeService dateTime)
    {
        _context = context;
        _currentUser = currentUser;
        _dateTime = dateTime;
    }
    public async Task<Unit> Handle(EditPlantCommand request, CancellationToken cancellationToken)
    {

        var plant = await _context
            .Plants
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        plant.Id = request.Id;
        plant.Name = request.Name;
        plant.Location = request.Location;
        plant.UserId = _currentUser.UserId;
        plant.CreatedAt = _dateTime.Now;

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;

    }
}
