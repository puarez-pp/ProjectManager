using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Plants.Commands.EditPlant;
using ProjectManager.Application.Plants.Extension;

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
        var plant = new EditPlantCommand();
        plant = (await _context
            .Plants
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id))
            .ToEditPlantCommand();

        return plant;
    }
}
