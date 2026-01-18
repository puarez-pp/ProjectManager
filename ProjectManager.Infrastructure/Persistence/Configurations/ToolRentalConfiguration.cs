using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ToolRentalConfiguration : IEntityTypeConfiguration<ToolRent>
{
    public void Configure(EntityTypeBuilder<ToolRent> builder)
    {
        builder.ToTable("ToolRentals");

        builder
            .HasOne(x => x.Tool)
            .WithMany(x => x.Rents)
            .HasForeignKey(x => x.ToolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.Rents)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.RentDate)
            .IsRequired();

    }
}