using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class EngineConfiguration : IEntityTypeConfiguration<Engine>
{
    public void Configure(EntityTypeBuilder<Engine> builder)
    {
        builder.ToTable("Engines");
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.Engines)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);

    }
}