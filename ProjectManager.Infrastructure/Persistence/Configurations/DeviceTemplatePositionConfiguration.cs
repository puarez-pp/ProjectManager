using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DeviceTemplatePositionConfiguration : IEntityTypeConfiguration<DeviceTemplatePosition>
{
    public void Configure(EntityTypeBuilder<DeviceTemplatePosition> builder)
    {
        builder.ToTable("TemplatePositions");
        builder.HasKey(x => x.Id);
        builder
           .HasOne(x => x.Template)
           .WithMany(x => x.TemplatePositions)
           .HasForeignKey(x => x.TemplateId)
           .OnDelete(DeleteBehavior.Restrict);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Description)
            .HasMaxLength(1000);
    }
}
