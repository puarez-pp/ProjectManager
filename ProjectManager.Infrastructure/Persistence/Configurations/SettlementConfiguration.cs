using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
{
    public void Configure(EntityTypeBuilder<Settlement> builder)
    {
        builder.ToTable("Settlements");
        builder
            .HasOne(x => x.Assumption)
            .WithOne(x => x.Settlement)
            .HasForeignKey<Assumption>(x => x.SettlementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Settlements)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
