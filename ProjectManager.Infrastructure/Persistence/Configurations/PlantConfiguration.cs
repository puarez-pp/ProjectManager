using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class PlantConfiguration : IEntityTypeConfiguration<Plant>
{
    public void Configure(EntityTypeBuilder<Plant> builder)
    {
        builder.ToTable("Plant");

        builder
           .HasOne(x => x.User)
           .WithMany(x => x.Plants)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Location)
            .HasMaxLength(100);
    }
}
