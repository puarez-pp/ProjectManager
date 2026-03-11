using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ScheduleStageConfiguration : IEntityTypeConfiguration<ScheduleStage>
{
    public void Configure(EntityTypeBuilder<ScheduleStage> builder)
    {
        builder.ToTable("ScheduleStages");

        builder
           .HasOne(x => x.Schedule)
           .WithMany(x => x.Stages)
           .HasForeignKey(x => x.ScheduleId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

    }
}
