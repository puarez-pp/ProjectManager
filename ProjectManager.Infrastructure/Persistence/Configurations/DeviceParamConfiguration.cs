using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DeviceParamConfiguration : IEntityTypeConfiguration<DeviceParam>
{
    public void Configure(EntityTypeBuilder<DeviceParam> builder)
    {
        builder.ToTable("DeviceParams");
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.DeviceParams)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);

    }
}