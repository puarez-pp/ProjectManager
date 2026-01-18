using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DeviceHeaderConfiguration : IEntityTypeConfiguration<DeviceHeader>
{
    public void Configure(EntityTypeBuilder<DeviceHeader> builder)
    {
        builder.ToTable("DeviceHeaders");
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.DeviceHeaders)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Description)
            .HasMaxLength(1000);
        builder.Property(x => x.Used)
            .HasDefaultValue(true);
    }
}
