using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class WorkScopePositionTemplateConfiguration : IEntityTypeConfiguration<WorkScopePositionTemplate>
{
    public void Configure(EntityTypeBuilder<WorkScopePositionTemplate> builder)
    {
        builder.ToTable("WorkScopePositionTemplates");

        builder
            .HasOne(x => x.WorkScopeTemplate)
            .WithMany(x => x.WorkScopePositions)
            .HasForeignKey(x => x.WorkScopeTemplateId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);
    }
}