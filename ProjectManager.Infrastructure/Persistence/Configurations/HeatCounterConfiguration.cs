using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class HeatCounterConfiguration : IEntityTypeConfiguration<HeatCounter>
{
    public void Configure(EntityTypeBuilder<HeatCounter> builder)
    {
        builder.ToTable("HeatCounters");
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.HeatCounters)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);

    }
}
