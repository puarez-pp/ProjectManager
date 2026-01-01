using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder 
            .HasOne(x => x.Address)
            .WithOne(x => x.Client)
            .HasForeignKey<Address>(x=>x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
    }
}
