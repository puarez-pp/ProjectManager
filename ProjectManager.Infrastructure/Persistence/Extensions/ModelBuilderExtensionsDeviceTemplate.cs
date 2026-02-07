using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsTemplate
{
    public static void SeedTemplates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceTemplate>().HasData(
            new DeviceTemplate
            {
                Id = 1,
                DeviceType = DeviceType.Engine
            },
            new DeviceTemplate
            {
                Id = 2,
                DeviceType = DeviceType.HeatCounter
            },
            new DeviceTemplate
            {
                Id = 3,
                DeviceType = DeviceType.GasCounter

            },
            new DeviceTemplate
            {
                Id = 4,
                DeviceType = DeviceType.ElectricCounter
            },
            new DeviceTemplate
            {
                Id = 5,
                DeviceType = DeviceType.Other
            });
    }
}
 