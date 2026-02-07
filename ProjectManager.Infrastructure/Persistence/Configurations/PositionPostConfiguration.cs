using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class PositionPostConfiguration : IEntityTypeConfiguration<PositionPost>
{
    public void Configure(EntityTypeBuilder<PositionPost> builder)
    {

        builder.ToTable("PositionPosts");

        builder
            .HasOne(x => x.Position)
            .WithMany(x => x.PositionPosts)
            .HasForeignKey(x => x.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.PositionPosts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Body)
            .IsRequired()
            .HasMaxLength(2000);
    }

}