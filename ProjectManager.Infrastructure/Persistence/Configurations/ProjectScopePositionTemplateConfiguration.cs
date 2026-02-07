using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ProjectScopePositionTemplateConfiguration : IEntityTypeConfiguration<ProjectScopePositionTemplate>
{
    public void Configure(EntityTypeBuilder<ProjectScopePositionTemplate> builder)
    {
        builder.ToTable("ProjectScopePositionTemplates");

        builder
            .HasOne(x => x.ProjectScopeTemplate)
            .WithMany(x => x.ProjectScopePositions)
            .HasForeignKey(x => x.ProjectScopeTemplateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);
    }
}