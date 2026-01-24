using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsWorkScopeTemplate
{
    public static void SeedWorkScopeTemplates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkScopeTemplate>().HasData(
            new WorkScopeTemplate
            {
                Id = 1,
                Description = "Agregat",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Agregat,
                Order = 1
            },
            new WorkScopeTemplate
            {
                Id = 2,
                Description = "Prace budowlano-konstrukcyjne",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Installation,
                Order = 2
            },
            new WorkScopeTemplate
            {
                Id = 3,
                Description = "Układ chłodzenia i wyprowadzenia ciepła",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Installation,
                Order = 3
            },
            new WorkScopeTemplate
            {
                Id = 4,
                Description = "Wentylacja",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Installation,
                Order = 4
            },
            new WorkScopeTemplate
            {
                Id = 5,
                Description = "Instalacje elektryczne",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Installation,
                Order = 5
            },
            new WorkScopeTemplate
            {
                Id = 6,
                Description = "Instalacja gazowa",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Installation,
                Order = 6
            },
            new WorkScopeTemplate
            {
                Id = 7,
                Description = "Zarządzenie projektem, dokumenetacja techniczna, rozruchy",
                ProjectType = ProjectType.Gas,
                WorkScopeType = WorkScopeType.Aadministration,
                Order = 7
            },
            new WorkScopeTemplate
            {
                Id = 8,
                Description = "Zespół prądotwórczy",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Agregat,
                Order = 1
            },
            new WorkScopeTemplate
            {
                Id = 9,
                Description = "Zespół prądotwórczy - Logistyka",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Agregat,
                Order = 2
            },
            new WorkScopeTemplate
            {
                Id = 10,
                Description = "Instalacje elektryczne",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 3
            },
            new WorkScopeTemplate
            {
                Id = 11,
                Description = "Układ chłodzenia silnika",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 4
            },
            new WorkScopeTemplate
            {
                Id = 12,
                Description = "Układ odprowadzenia spalin",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 5
            },
            new WorkScopeTemplate
            {
                Id = 13,
                Description = "Instalacja paliwowa",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 6
            },
            new WorkScopeTemplate
            {
                Id = 14,
                Description = "Instalacja olejowa",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 7
            },
            new WorkScopeTemplate
            {
                Id = 15,
                Description = "Wentylacja",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 8
            },
            new WorkScopeTemplate
            {
                Id = 16,
                Description = "Prace budowlano-konstrukcyjne",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Installation,
                Order = 9
            },
            new WorkScopeTemplate
            {
                Id = 17,
                Description = "Zarządzenie projektem, dokumenetacja techniczna, rozruchy",
                ProjectType = ProjectType.Diesel,
                WorkScopeType = WorkScopeType.Aadministration,
                Order = 10
            });
    }
}
