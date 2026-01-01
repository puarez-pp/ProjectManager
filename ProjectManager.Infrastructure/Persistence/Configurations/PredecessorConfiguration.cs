using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class PredecessorConfiguration : IEntityTypeConfiguration<Predecessor>
{
    public void Configure(EntityTypeBuilder<Predecessor> builder)
    {
        builder.ToTable("Predecessor");

        builder
            .HasOne(x => x.Activity)
            .WithMany(x => x.Predecessors)
            .HasForeignKey(x => x.ActivityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}