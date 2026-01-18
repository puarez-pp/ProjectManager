using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("Devices");

        builder
           .HasOne(x => x.User)
           .WithMany(x => x.Devices)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Restrict);
        builder
           .HasOne(x => x.Plant)
           .WithMany(x => x.Devices)
           .HasForeignKey(x => x.PlantId)
           .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.DeviceType)
            .IsRequired()
            .HasDefaultValue(DeviceType.Engine);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Description)
            .HasMaxLength(1000);
    }
}
