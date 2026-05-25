using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Services;

public class DeviceParamsService : IDeviceParamsService
{
    private readonly IApplicationDbContext _context;


    public DeviceParamsService(
        IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task SaveDeviceParamsAsync(int deviceId, IDeviceParam dto)
    {
        var device = await _context.Devices
            .FirstOrDefaultAsync(x => x.Id == deviceId);

        if (device == null)
            throw new Exception("Device not found");

        var entity = CreateEntityForDevice(device.DeviceType);

        entity.GetType().GetProperty("DeviceId")?.SetValue(entity, deviceId);

        MapDtoToEntity(dto, entity);

        
        switch (device.DeviceType)
        {

            default:
                throw new NotSupportedException("Unsupported device type");
        }

        await _context.SaveChangesAsync();
    }



    private object CreateEntityForDevice(DeviceType type)
    {
        return type switch
        {

            _ => throw new NotSupportedException("Unsupported device type")
        };
    }

    private void MapDtoToEntity(IDeviceParam dto, object entity)
    {
        var dtoProps = dto.GetType().GetProperties()
            .Where(p => p.Name.StartsWith("Parametr") || p.Name == "TimeStamp");

        var entityProps = entity.GetType().GetProperties()
            .Where(p => p.Name.StartsWith("Parametr") || p.Name == "TimeStamp");

        foreach (var dtoProp in dtoProps)
        {
            var target = entityProps.FirstOrDefault(p => p.Name == dtoProp.Name);
            if (target != null)
            {
                var value = dtoProp.GetValue(dto);
                target.SetValue(entity, value);
            }
        }
    }
}
