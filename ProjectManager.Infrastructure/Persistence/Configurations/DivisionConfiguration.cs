using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DivisionConfiguration : IEntityTypeConfiguration<Division>
{
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.ToTable("Divisions"); 

        builder 
            .HasOne(x => x.User)
            .WithMany(x=>x.Divisions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder
           .HasOne(x => x.Project)
           .WithMany(x => x.Divisions)
           .HasForeignKey(x => x.ProjectId)
           .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Comment)
            .HasMaxLength(2000);

    }
}
