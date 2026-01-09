using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

         builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Client)
            .WithMany(x=>x.Projects)
            .HasForeignKey(x => x.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasOne(x => x.User)
           .WithMany(x => x.ProjectsCreator)
           .HasForeignKey(x => x.UserID)
           .OnDelete(DeleteBehavior.Restrict);

        builder
         .HasOne(x => x.UserPM)
         .WithMany(x => x.ProjectsPM)
         .HasForeignKey(x => x.UserPMId)
         .OnDelete(DeleteBehavior.Restrict);

        builder
         .HasOne(x => x.UserUpdator)
         .WithMany(x => x.ProjectsUpdator)
         .HasForeignKey(x => x.UserUpdatorId)
         .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.ProjectType)
            .IsRequired()
            .HasDefaultValue(ProjectType.Gas);
            
        builder.Property(x => x.Number)
            .HasMaxLength(100);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Comment)
            .HasMaxLength(1000);
    }
}
