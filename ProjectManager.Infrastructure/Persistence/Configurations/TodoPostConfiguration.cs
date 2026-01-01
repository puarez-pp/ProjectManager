using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class TodoPostConfiguration : IEntityTypeConfiguration<TodoPost>
{ 
    public void Configure(EntityTypeBuilder<TodoPost> builder)
    {
        builder.ToTable("TodoReplies");

        builder.Property(x => x.TodoId)
            .IsRequired();

        builder
            .HasOne(x => x.Todo)
            .WithMany(x => x.TodoPosts)
            .HasForeignKey(x => x.TodoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.TodoPosts)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(2000);
    }
}
