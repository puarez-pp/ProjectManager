using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Application.Common.Interfaces;

namespace ProjectManager.Application.Devices.Commands.AddScript;

public class GenerateScriptCommandHandler : IRequestHandler<GenerateScriptCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IDeviceScriptService _scriptService;
    private readonly IConfiguration _configuration;
    private readonly string _baseUrl;

    public GenerateScriptCommandHandler(
        IApplicationDbContext context,
        IDeviceScriptService scriptService,
        IConfiguration configuration)
    {
        _context = context;
        _scriptService = scriptService;
        _configuration = configuration;
        _baseUrl = _configuration.GetValue<string>("ApiTelemetry:BaseUrl");
    }
    public async Task<Unit> Handle(GenerateScriptCommand request, CancellationToken cancellationToken)
    {
        var device = await _context
            .Devices
            .Include(x=>x.Plant)
            .ThenInclude(x=>x.User)
            .Include(x=>x.DeviceHeaders)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (device == null)
            throw new Exception("Device not found");

        var model = new DeviceSriptVm
        {
            DeviceId = request.Id,
            DeviceName = device.Name,
            AuthUrl = $"{_baseUrl}api/tokens",
            ApiUrl = $"{_baseUrl}api/telemetries/params",
            Username = device.Plant.User.UserName,
            Password = device.Plant.User.PasswordHash,
            IntervalMs = 60000,
            Headers = device.DeviceHeaders.Select(x => x.ToDeviceHeaderDto())
        };
        var file = await _scriptService.GenerateScriptAsync(model);
        var fileInDb = await _context.Files.FirstOrDefaultAsync(x => x.Name == file.Name);

        if (fileInDb == null)
        {
            await _context.Files.AddAsync(file, cancellationToken);
        }

        else
        {
            fileInDb.Name = file.Name;
            fileInDb.Description = file.Description;
            fileInDb.Bytes = file.Bytes;
        }
            
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}