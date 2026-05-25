using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Devices.Extension;

public static class DeviceExtensions
{
    public static DeviceDto ToDeviceDto(this Device device)
    {
        if (device == null)
        {
            return null;
        }
        return new DeviceDto
        {
            Id = device.Id,
            Name = device.Name,
            Description = device.Description,
            DeviceType = device.DeviceType,
            CreatedAt = device.CreatedAt,
            IsConfigured = device.IsConfigured
        };
    }

    public static AlarmDto ToAlarmDto(this Alarm alarm)
    {
        if (alarm == null)
        {
            return null;
        }
        return new AlarmDto
        {
            Id = alarm.Id,
            AlarmType = alarm.AlarmType,
            Name = alarm.Name,
            TimeStamp = alarm.TimeStamp
        };
    }

    public static DeviceParamDto ToDeviceParamDto(this DeviceParam device)
    {
        if (device == null)
        {
            return null;
        }
        return new DeviceParamDto
        {
            Id = device.Id,
            TimeStamp = device.TimeStamp,
            Name = device.Name,
            Value = device.Value
        };
    }
}
