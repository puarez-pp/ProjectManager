using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ElectricCounterConfiguration : IEntityTypeConfiguration<ElectricCounter>
{
    public void Configure(EntityTypeBuilder<ElectricCounter> builder)
    {
        builder.ToTable("ElectricCounters");
        builder.HasKey(x => x.Id);
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.ElectricCounters)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Used)
            .HasDefaultValue(true);
    }
}
