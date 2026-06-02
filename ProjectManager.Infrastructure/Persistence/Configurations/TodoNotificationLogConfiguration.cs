using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class TodoNotificationLogConfiguration : IEntityTypeConfiguration<TodoNotificationLog>
{ 
    public void Configure(EntityTypeBuilder<TodoNotificationLog> builder)
    {
        builder.ToTable("TodoNotificationLogs");
        builder.Property(x => x.TodoId)
            .IsRequired();

        builder
            .HasOne(x => x.Todo)
            .WithMany(x => x.TodoNotificationLogs)
            .HasForeignKey(x => x.TodoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
