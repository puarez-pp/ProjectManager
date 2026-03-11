using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ScheduleTaskConfiguration : IEntityTypeConfiguration<ScheduleTask>
{
    public void Configure(EntityTypeBuilder<ScheduleTask> builder)
    {
        builder.ToTable("ScheduleTasks");

        builder
           .HasOne(x => x.Stage)
           .WithMany(x => x.Tasks)
           .HasForeignKey(x => x.StageId)
           .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasOne(x => x.AssignedUser)
           .WithMany(x => x.ScheduleTasks)
           .HasForeignKey(x => x.AssignedUserId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

    }
}
