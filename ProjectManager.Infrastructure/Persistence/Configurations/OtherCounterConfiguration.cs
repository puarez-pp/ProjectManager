using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class OtherCounterConfiguration : IEntityTypeConfiguration<OtherCounter>
{
    public void Configure(EntityTypeBuilder<OtherCounter> builder)
    {
        builder.ToTable("OtherCounters");
        builder.HasKey(x => x.Id);
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.OtherCounters)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
