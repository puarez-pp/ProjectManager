using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class SubConAddressConfiguration : IEntityTypeConfiguration<SubConAddress>
{
    public void Configure(EntityTypeBuilder<SubConAddress> builder)
    {
        builder.ToTable("SubConAddresses");

        builder.Property(x => x.City)
            .HasMaxLength(200);

        builder.Property(x => x.Street)
            .HasMaxLength(200);

        builder.Property(x => x.StreetNumber)
            .HasMaxLength(100);

        builder.Property(x => x.ZipCode)
            .HasMaxLength(10);

    }
}
