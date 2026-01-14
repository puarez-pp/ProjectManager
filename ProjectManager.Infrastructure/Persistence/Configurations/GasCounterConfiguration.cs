using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class GasCounterConfiguration : IEntityTypeConfiguration<GasCounter>
{
    public void Configure(EntityTypeBuilder<GasCounter> builder)
    {
        builder.ToTable("GasCounters");
        builder.HasKey(x => x.Id);
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.GasCounters)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
