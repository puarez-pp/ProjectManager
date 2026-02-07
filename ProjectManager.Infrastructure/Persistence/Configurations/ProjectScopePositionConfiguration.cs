using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ProjectScopePositionConfiguration : IEntityTypeConfiguration<ProjectScopePosition>
{
    public void Configure(EntityTypeBuilder<ProjectScopePosition> builder)
    {
        builder.ToTable("ProjectScopePositions");

        builder
           .HasOne(x => x.ProjectScope)
           .WithMany(x => x.Positions)
           .HasForeignKey(x => x.ProjectScopeId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);
    }
}
