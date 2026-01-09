 using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ProjectManager.Infrastructure.Persistence.Extensions;

static class ModelBuilderExtensionsClients
{
    public static void SeedClient(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>().HasData(
            new Client
            {
                Id = 1,
                Name = "Klient domyślny"
            });
        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                ClientId = 1,
            });
    }
}


