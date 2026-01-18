using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class WorkScopeTemplateConfiguration : IEntityTypeConfiguration<WorkScopeTemplate>
{
    public void Configure(EntityTypeBuilder<WorkScopeTemplate> builder)
    {
        builder.ToTable("WorkScopeTemplates");

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);
    }
}
