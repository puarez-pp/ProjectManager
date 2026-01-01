using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsSubContractor
{
    public static void SeedSubContractor(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubContractor>().HasData(
            new SubContractor
            {
                Id = 1,
                Name = "Bergerat Monnoyeur"
            });
    }
}
