using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DivisionPositionConfiguration : IEntityTypeConfiguration<DivisionPosition>
{
    public void Configure(EntityTypeBuilder<DivisionPosition> builder)
    {
        builder.ToTable("DivisionPositions");

        builder
            .HasOne(x => x.SubContractor)
            .WithMany(x => x.DivisionItems)
            .HasForeignKey(x => x.SubContractorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasOne(x => x.Division)
           .WithMany(x => x.Positions)
           .HasForeignKey(x => x.DivisionId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
