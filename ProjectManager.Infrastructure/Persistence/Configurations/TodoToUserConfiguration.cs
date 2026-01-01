using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class TodoToUserConfiguration : IEntityTypeConfiguration<TodoToUser>
{
    public void Configure(EntityTypeBuilder<TodoToUser> builder)
    {
        builder.ToTable("TodoToUsers");

        builder
            .HasOne(x => x.Todo)
            .WithMany(x => x.TodoToUsers)
            .HasForeignKey(x => x.TodoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.TodoToUsers)
            .HasForeignKey(x => x.UserID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
