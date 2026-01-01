using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ProjectSettingPositionConfiguration : IEntityTypeConfiguration<ProjectSettingPosition>
{
    public void Configure(EntityTypeBuilder<ProjectSettingPosition> builder)
    {
        builder.ToTable("ProjectSettingPositions");

        builder
           .HasOne(x => x.ProjectSetting)
           .WithMany(x => x.Positions)
           .HasForeignKey(x => x.ProjectSettingId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Key)
            .IsRequired();

        builder.Property(x => x.Value)
           .IsRequired()
           .HasMaxLength(200);

    }
}
