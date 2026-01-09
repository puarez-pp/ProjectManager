using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class AlarmConfiguration : IEntityTypeConfiguration<Alarm>
{
    public void Configure(EntityTypeBuilder<Alarm> builder)
    {
        builder.ToTable("Alarms");
        builder.HasKey(x => x.Id);
        builder
           .HasOne(x => x.Device)
           .WithMany(x => x.Alarms)
           .HasForeignKey(x => x.DeviceId)
           .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);
    }
}
