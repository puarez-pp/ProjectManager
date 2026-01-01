using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsProjectSettings
{
    public static void SeedProjectSettings(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectSetting>().HasData(
            new ProjectSetting
            {
                Id = 1,
                ProjectType = ProjectType.Gas
            },
            new ProjectSetting
            {
                Id = 2,
                ProjectType = ProjectType.Diesel
            },
            new ProjectSetting
            {
                Id = 3,
                ProjectType = ProjectType.Turbine
            },
            new ProjectSetting
            {
                Id = 4,
                ProjectType = ProjectType.Renewable
            });
    }
}
