using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class SubContractorConfiguration : IEntityTypeConfiguration<SubContractor>
{
    public void Configure(EntityTypeBuilder<SubContractor> builder)
    {
        builder.ToTable("SubContractors");

        builder
            .HasOne(x => x.Address)
            .WithOne(x => x.SubContractor)
            .HasForeignKey<SubConAddress>(x => x.SubContractorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
    }
}
