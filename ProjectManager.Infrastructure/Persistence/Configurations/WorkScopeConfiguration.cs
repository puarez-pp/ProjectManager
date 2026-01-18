using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class WorkScopeConfiguration : IEntityTypeConfiguration<WorkScope>
{
    public void Configure(EntityTypeBuilder<WorkScope> builder)
    {
        builder.ToTable("WorkScopes");

        builder
            .HasOne(x => x.Settlement)
            .WithMany(x => x.WorkScopes)
            .HasForeignKey(x => x.SettlementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(200);
    }
}
