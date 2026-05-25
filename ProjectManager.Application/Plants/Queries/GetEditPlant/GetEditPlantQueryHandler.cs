using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Plants.Commands.EditPlant;

namespace ProjectManager.Application.Plants.Queries.GetEditPlant;

public class GetEditPlantQueryHandler : IRequestHandler<GetEditPlantQuery, EditPlantCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditPlantQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditPlantCommand> Handle(GetEditPlantQuery request, CancellationToken cancellationToken)
    {
        var user = await _context
            .Users
            .Include(x => x.Plant)
            .FirstOrDefaultAsync(x => x.Id == request.UserId);

        return new EditPlantCommand
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Plant.Name,
            Location = user.Plant.Location,
        };
    }
}
