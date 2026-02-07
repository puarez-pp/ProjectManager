using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsProjectScopeTemplate
{
    public static void SeedProjectScopeTemplates(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectScopeTemplate>().HasData(
            new ProjectScopeTemplate { Id = 1, Description = "Zestaw kogeneracyjny Caterpillar", ProjectType = ProjectType.Gas, Order = 1 },
            new ProjectScopeTemplate { Id = 2, Description = "Projekt i uruchomienie", ProjectType = ProjectType.Gas, Order = 2 },
            new ProjectScopeTemplate { Id = 3, Description = "Instalacja elektryczna", ProjectType = ProjectType.Gas, Order = 3 },
            new ProjectScopeTemplate { Id = 4, Description = "Układ chłodzenia i produkcji ciepłej wody z bloku silnika", ProjectType = ProjectType.Gas, Order = 4 },
            new ProjectScopeTemplate { Id = 5, Description = "Układ odprowadzenia spalin", ProjectType = ProjectType.Gas, Order = 5 },
            new ProjectScopeTemplate { Id = 6, Description = "Ścieżka gazowa", ProjectType = ProjectType.Gas, Order = 6 },
            new ProjectScopeTemplate { Id = 7, Description = "Układ gospodarki oleju silnikowego", ProjectType = ProjectType.Gas, Order = 7 },
            new ProjectScopeTemplate { Id = 8, Description = "Obudowa kontenerowa zespołu prądotwórczego oraz prace budowlane", ProjectType = ProjectType.Gas, Order = 8 },
            new ProjectScopeTemplate { Id = 9, Description = "Opomiarowanie", ProjectType = ProjectType.Gas, Order = 9 },
            new ProjectScopeTemplate { Id = 10, Description = "Instalacje technologiczne – odzysk ciepła, instalacja gazowa", ProjectType = ProjectType.Gas, Order = 10 },
            new ProjectScopeTemplate { Id = 11, Description = "Dostawa nadrzędnego systemu sterowania", ProjectType = ProjectType.Gas, Order = 11 });

    }
}
