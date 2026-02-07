using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class GasCounterConfiguration : IEntityTypeConfiguration<GasCounter>
{
    public void Configure(EntityTypeBuilder<GasCounter> builder)
    {
        builder.ToTable("GasCounters");
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.LogGasCounters)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
