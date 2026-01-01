using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class ToolRentalConfiguration : IEntityTypeConfiguration<ToolRental>
{
    public void Configure(EntityTypeBuilder<ToolRental> builder)
    {
        builder.ToTable("ToolRentals");

        builder
            .HasOne(x => x.Tool)
            .WithMany(x => x.ToolRentals)
            .HasForeignKey(x => x.ToolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.ToolRentals)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.RentalData)
            .IsRequired();

    }
}