using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("Todos");

        builder
            .HasOne(x => x.Project)
            .WithMany(x => x.Todos)
            .HasForeignKey(x => x.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.UserFrom)
            .WithMany(x => x.TodosFrom)
            .HasForeignKey(x => x.UserFromId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.UserTo)
            .WithMany(x => x.TodosTo)
            .HasForeignKey(x => x.UserToId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.Content)
            .HasMaxLength(2000);
    }
}
