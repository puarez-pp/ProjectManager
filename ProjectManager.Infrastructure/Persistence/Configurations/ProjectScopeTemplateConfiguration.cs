using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ProjectScopeTemplateConfiguration : IEntityTypeConfiguration<ProjectScopeTemplate>
{
    public void Configure(EntityTypeBuilder<ProjectScopeTemplate> builder)
    {
        builder.ToTable("ProjectScopeTemplates");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);
    }
}