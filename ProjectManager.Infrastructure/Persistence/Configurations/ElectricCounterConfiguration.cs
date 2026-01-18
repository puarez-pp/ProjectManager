using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ElectricCounterConfiguration : IEntityTypeConfiguration<ElectricCounter>
{
    public void Configure(EntityTypeBuilder<ElectricCounter> builder)
    {
        builder.ToTable("ElectricCounters");
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.ElectricCounters)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
