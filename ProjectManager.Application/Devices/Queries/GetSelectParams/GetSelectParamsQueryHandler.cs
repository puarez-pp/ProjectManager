using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Devices.Queries.GetSelectParams;

public class GetSelectParamsQueryHandler : IRequestHandler<GetSelectParamsQuery, DeviceParamNamesDto>
{
    private readonly IApplicationDbContext _context;

    public GetSelectParamsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DeviceParamNamesDto> Handle(GetSelectParamsQuery request, CancellationToken cancellationToken)
    {
        var device = await _context
                .Devices
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .Select(x => new DeviceParamNamesDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    DeviceType = x.DeviceType,
                    ParamNames = x.DeviceHeaders
                    .OrderBy(y => y.Order)
                    .Select(y => new ParamNamesDto
                    {
                        Id = y.Id,
                        Name = y.Name,
                        Selected = true
                    })
                    .Distinct()
                    .ToList()
                })
                .FirstOrDefaultAsync();
        return device;
        
    }
}