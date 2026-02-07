using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ProjectScopeConfiguration : IEntityTypeConfiguration<ProjectScope>
{
    public void Configure(EntityTypeBuilder<ProjectScope> builder)
    {
        builder.ToTable("ProjectScopes"); 

        builder
           .HasOne(x => x.Project)
           .WithMany(x => x.ProjectScopes)
           .HasForeignKey(x => x.ProjectId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

    }
}


