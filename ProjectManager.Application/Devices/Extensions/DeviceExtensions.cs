using ProjectManager.Application.Devices.Queries.GetAlarms;
using ProjectManager.Application.Devices.Queries.GetDevice;
using ProjectManager.Application.Users.Extensions;
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
            User = (device.User.ToUserDto()).FullName,
            CreatedDate = device.CreatedDate,
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
            Description = alarm.Description,
            TimeStamp = alarm.TimeStamp
        };
    }

    public static ElectricCounterDto ToElectricCounterDto(this ElectricCounter counter)
    {
        if (counter == null)
        {
            return null;
        }
        return new ElectricCounterDto
        {
            Id = counter.Id,
            TimeStamp = counter.TimeStamp,
            Parametr1 = counter.Parametr1,
            Parametr2 = counter.Parametr2,
            Parametr3 = counter.Parametr3,
            Parametr4 = counter.Parametr4,
            Parametr5 = counter.Parametr5,
            Parametr6 = counter.Parametr6,
            Parametr7 = counter.Parametr7,
            Parametr8 = counter.Parametr8,
            Parametr9 = counter.Parametr9,
            Parametr10 = counter.Parametr10,
            Parametr11 = counter.Parametr11,
            Parametr12 = counter.Parametr12,
            Parametr13 = counter.Parametr13,
            Parametr14 = counter.Parametr14,
            Parametr15 = counter.Parametr15,
            Parametr16 = counter.Parametr16,
            Parametr17 = counter.Parametr17,
            Parametr18 = counter.Parametr18,
            Parametr19 = counter.Parametr19,
            Parametr20 = counter.Parametr20,
        };
    }

    public static EngineDto ToEngineDto(this Engine engine)
    {
        if (engine == null)
        {
            return null;
        }
        return new EngineDto
        {
            Id = engine.Id,
            TimeStamp = engine.TimeStamp,
            Parametr1 = engine.Parametr1,
            Parametr2 = engine.Parametr2,
            Parametr3 = engine.Parametr3,
            Parametr4 = engine.Parametr4,
            Parametr5 = engine.Parametr5,
            Parametr6 = engine.Parametr6,
            Parametr7 = engine.Parametr7,
            Parametr8 = engine.Parametr8,
            Parametr9 = engine.Parametr9,
            Parametr10 = engine.Parametr10,
            Parametr11 = engine.Parametr11,
            Parametr12 = engine.Parametr12,
            Parametr13 = engine.Parametr13,
            Parametr14 = engine.Parametr14,
            Parametr15 = engine.Parametr15,
            Parametr16 = engine.Parametr16,
            Parametr17 = engine.Parametr17,
            Parametr18 = engine.Parametr18,
            Parametr19 = engine.Parametr19,
            Parametr20 = engine.Parametr20,
            Parametr21 = engine.Parametr21,
            Parametr22 = engine.Parametr22,
            Parametr23 = engine.Parametr23,
            Parametr24 = engine.Parametr24,
            Parametr25 = engine.Parametr25,
            Parametr26 = engine.Parametr26,
            Parametr27 = engine.Parametr27,
            Parametr28 = engine.Parametr28,
            Parametr29 = engine.Parametr29,
            Parametr30 = engine.Parametr30,
            Parametr31 = engine.Parametr31,
            Parametr32 = engine.Parametr32,
            Parametr33 = engine.Parametr33,
            Parametr34 = engine.Parametr34,
            Parametr35 = engine.Parametr35,
            Parametr36 = engine.Parametr36,
            Parametr37 = engine.Parametr37,
            Parametr38 = engine.Parametr38,
            Parametr39 = engine.Parametr39,
            Parametr40 = engine.Parametr40,
            Parametr41 = engine.Parametr41,
            Parametr42 = engine.Parametr42,
            Parametr43 = engine.Parametr43,
            Parametr44 = engine.Parametr44,
            Parametr45 = engine.Parametr45,
            Parametr46 = engine.Parametr46,
            Parametr47 = engine.Parametr47,
            Parametr48 = engine.Parametr48,
            Parametr49 = engine.Parametr49,
            Parametr50 = engine.Parametr50,
            Parametr51 = engine.Parametr51,
            Parametr52 = engine.Parametr52,
            Parametr53 = engine.Parametr53,
            Parametr54 = engine.Parametr54,
            Parametr55 = engine.Parametr55,
            Parametr56 = engine.Parametr56,
            Parametr57 = engine.Parametr57,
            Parametr58 = engine.Parametr58,
            Parametr59 = engine.Parametr59,
            Parametr60 = engine.Parametr60,
            Parametr61 = engine.Parametr61,
            Parametr62 = engine.Parametr62,
            Parametr63 = engine.Parametr63,
            Parametr64 = engine.Parametr64,
            Parametr65 = engine.Parametr65,
            Parametr66 = engine.Parametr66,
            Parametr67 = engine.Parametr67,
            Parametr68 = engine.Parametr68,
            Parametr69 = engine.Parametr69,
            Parametr70 = engine.Parametr70,
            Parametr71 = engine.Parametr71,
            Parametr72 = engine.Parametr72,
            Parametr73 = engine.Parametr73,
            Parametr74 = engine.Parametr74,
            Parametr75 = engine.Parametr75,
            Parametr76 = engine.Parametr76,
            Parametr77 = engine.Parametr77,
            Parametr78 = engine.Parametr78,
            Parametr79 = engine.Parametr79,
            Parametr80 = engine.Parametr80,
            Parametr81 = engine.Parametr81,
            Parametr82 = engine.Parametr82,
            Parametr83 = engine.Parametr83,
            Parametr84 = engine.Parametr84,
            Parametr85 = engine.Parametr85,
            Parametr86 = engine.Parametr86,
            Parametr87 = engine.Parametr87,
            Parametr88 = engine.Parametr88,
            Parametr89 = engine.Parametr89,
            Parametr90 = engine.Parametr90,
            Parametr91 = engine.Parametr91,
            Parametr92 = engine.Parametr92,
            Parametr93 = engine.Parametr93,
            Parametr94 = engine.Parametr94,
            Parametr95 = engine.Parametr95,
            Parametr96 = engine.Parametr96,
            Parametr97 = engine.Parametr97,
            Parametr98 = engine.Parametr98,
            Parametr99 = engine.Parametr99,
            Parametr100 = engine.Parametr100,
            Parametr101 = engine.Parametr101,
            Parametr102 = engine.Parametr102,
            Parametr103 = engine.Parametr103,
            Parametr104 = engine.Parametr104,
            Parametr105 = engine.Parametr105,
            Parametr106 = engine.Parametr106,
            Parametr107 = engine.Parametr107,
            Parametr108 = engine.Parametr108,
            Parametr109 = engine.Parametr109,
            Parametr110 = engine.Parametr110,
            Parametr111 = engine.Parametr111,
            Parametr112 = engine.Parametr112,
            Parametr113 = engine.Parametr113,
            Parametr114 = engine.Parametr114,
            Parametr115 = engine.Parametr115,
            Parametr116 = engine.Parametr116,
            Parametr117 = engine.Parametr117,
            Parametr118 = engine.Parametr118,
            Parametr119 = engine.Parametr119,
            Parametr120 = engine.Parametr120
        };
    }
    public static GasCounterDto ToGasCounterDto(this GasCounter counter)
    {
        if (counter == null)
        {
            return null;
        }
        return new GasCounterDto
        {
            Id = counter.Id,
            TimeStamp = counter.TimeStamp,
            Parametr1 = counter.Parametr1,
            Parametr2 = counter.Parametr2,
            Parametr3 = counter.Parametr3,
            Parametr4 = counter.Parametr4,
            Parametr5 = counter.Parametr5,
            Parametr6 = counter.Parametr6,
            Parametr7 = counter.Parametr7,
            Parametr8 = counter.Parametr8,
            Parametr9 = counter.Parametr9,
            Parametr10 = counter.Parametr10
        };
    }

    public static HeatCounterDto ToHeatCounterDto(this HeatCounter counter)
    {
        if (counter == null)
        {
            return null;
        }
        return new HeatCounterDto
        {
            Id = counter.Id,
            TimeStamp = counter.TimeStamp,
            Parametr1 = counter.Parametr1,
            Parametr2 = counter.Parametr2,
            Parametr3 = counter.Parametr3,
            Parametr4 = counter.Parametr4,
            Parametr5 = counter.Parametr5,
            Parametr6 = counter.Parametr6,
            Parametr7 = counter.Parametr7,
            Parametr8 = counter.Parametr8,
            Parametr9 = counter.Parametr9,
            Parametr10 = counter.Parametr10
        };
    }

    public static OtherCounterDto ToOtherCounterDto(this OtherCounter counter)
    {
        if (counter == null)
        {
            return null;
        }
        return new OtherCounterDto
        {
            Id = counter.Id,
            TimeStamp = counter.TimeStamp,
            Parametr1 = counter.Parametr1,
            Parametr2 = counter.Parametr2,
            Parametr3 = counter.Parametr3,
            Parametr4 = counter.Parametr4,
            Parametr5 = counter.Parametr5,
            Parametr6 = counter.Parametr6,
            Parametr7 = counter.Parametr7,
            Parametr8 = counter.Parametr8,
            Parametr9 = counter.Parametr9,
            Parametr10 = counter.Parametr10
        };
    }

}
