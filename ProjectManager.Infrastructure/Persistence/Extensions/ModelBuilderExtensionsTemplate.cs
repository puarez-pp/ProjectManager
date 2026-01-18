using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsTemplate
{
    public static void SeedTemplates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Template>().HasData(
            new Template
            {
                Id = 1,
                DeviceType = DeviceType.Engine
            },
            new Template
            {
                Id = 2,
                DeviceType = DeviceType.HeatCounter
            },
            new Template
            {
                Id = 3,
                DeviceType = DeviceType.GasCounter

            },
            new Template
            {
                Id = 4,
                DeviceType = DeviceType.ElectricCounter
            },
            new Template
            {
                Id = 5,
                DeviceType = DeviceType.Other
            });
    }
}
 