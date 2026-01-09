using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Plants.Extension;

namespace ProjectManager.Application.Plants.Queries.GetPlant;

public class GetPlantQueryHandlercs : IRequestHandler<GetPlantQuery, GetPlantVm>
{
    private readonly IApplicationDbContext _context;

    public GetPlantQueryHandlercs(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetPlantVm> Handle(GetPlantQuery request, CancellationToken cancellationToken)
    {
        var plant = await _context
           .Plants
           .Include(x => x.User)
           .Include(x => x.Devices)
           .AsNoTracking()
           .FirstOrDefaultAsync(x => x.Id == request.Id);

        var vm = new GetPlantVm()
        {
            Plant = plant.ToPlantDto(),
            Devices = plant.Devices.ToList()
        };
        return vm;
    }
}
