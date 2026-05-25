using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Devices.Queries.GetDevice;

namespace ProjectManager.Application.Plants.Queries.GetPlant;

public class GetPlantQueryHandlercs : IRequestHandler<GetPlantQuery, PlantDto>
{
    private readonly IApplicationDbContext _context;

    public GetPlantQueryHandlercs(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<PlantDto> Handle(GetPlantQuery request, CancellationToken cancellationToken)
    {
        return await _context
           .Plants
           .Where(x => x.UserId == request.Id)
           .Select(x => new PlantDto
           {
               Id = x.Id,
               Name = x.Name,
               Location = x.Location,
               CreatedAt = x.CreatedAt,
               Devices = x.Devices
               .OrderBy(d => d.Name)
               .Select(d => new DeviceDto
               {
                   Id = d.Id,
                   Name = d.Name,
                   DeviceType = d.DeviceType,
                   CreatedAt = d.CreatedAt,
                   IsConfigured = d.IsConfigured
               }).ToList()
           }).FirstOrDefaultAsync(cancellationToken);
    }
}
