using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.ToTable("Invoices");

        builder
            .HasOne(x => x.Vendor)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.VendorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.Settlement)
            .WithMany(x => x.Invoices)
            .HasForeignKey(x => x.SettlementId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Number)
            .IsRequired()
            .HasMaxLength(100);
    }
}
