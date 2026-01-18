using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class WorkScopeCostConfiguration : IEntityTypeConfiguration<WorkScopeCost>
{
    public void Configure(EntityTypeBuilder<WorkScopeCost> builder)
    {
        builder.ToTable("WorkScopeCosts");

        builder
            .HasOne(x => x.SubContractor)
            .WithMany(x => x.WorkScopeCosts)
            .HasForeignKey(x => x.SubContractorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.WorkScope)
            .WithMany(x => x.WorkScopeCosts)
            .HasForeignKey(x => x.WorkScopeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.CostStatusType)
            .IsRequired()
            .HasDefaultValue(CostStatusType.Invoice);

        builder.Property(x => x.UnitType)
            .IsRequired()
            .HasDefaultValue(UnitType.Set);

    }
}
