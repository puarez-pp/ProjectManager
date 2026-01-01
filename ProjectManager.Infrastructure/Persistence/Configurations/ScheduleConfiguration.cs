using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Schedules)
            .HasForeignKey(x => x.UserID)
            .OnDelete(DeleteBehavior.Restrict);
        builder
           .HasOne(x => x.Project)
           .WithMany(x => x.Schedules)
           .HasForeignKey(x => x.ProjectId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Title)
            .HasMaxLength(200);

    }
}
