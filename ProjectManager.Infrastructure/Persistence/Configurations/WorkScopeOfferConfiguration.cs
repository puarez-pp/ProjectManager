using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager.Domain.Enums;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class WorkScopeOfferConfiguration : IEntityTypeConfiguration<WorkScopeOffer>
{
    public void Configure(EntityTypeBuilder<WorkScopeOffer> builder)
    {
        builder.ToTable("WorkScopeOffers");

        builder
            .HasOne(x => x.SubContractor)
            .WithMany(x => x.WorkScopeOffers)
            .HasForeignKey(x => x.SubContractorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.WorkScope)
            .WithMany(x => x.WorkScopeOffers)
            .HasForeignKey(x => x.WorkScopeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.IsUsed)
            .HasDefaultValue(true);

        builder.Property(x => x.UnitType)
            .IsRequired()
            .HasDefaultValue(UnitType.Set);
    }
}
