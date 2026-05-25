using MediatR;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.DeviceHeaders.Commands.EditDeviceHeader;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.DeviceHeaders.Queries.GetEditDeviceHeader;

public class GetEditDeviceHeaderQueryHandler : IRequestHandler<GetEditDeviceHeaderQuery, EditDeviceHeaderCommand>
{
    private readonly IApplicationDbContext _context;

    public GetEditDeviceHeaderQueryHandler(
        IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<EditDeviceHeaderCommand> Handle(GetEditDeviceHeaderQuery request, CancellationToken cancellationToken)
    {
        var header = await _context
            .DeviceHeaders
            .FirstOrDefaultAsync(x=>x.Id == request.Id);

        if (header == null)
            throw new Exception("Device header not found.");

        return new EditDeviceHeaderCommand
        {
            Id = header.Id,
            DeviceId = header.DeviceId,
            Name = header.Name,
            Description = header.Description,
            Used = header.Used
        };
    }
}
