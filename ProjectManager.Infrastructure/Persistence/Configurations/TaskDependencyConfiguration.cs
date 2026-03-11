using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class TaskDependencyConfiguration : IEntityTypeConfiguration<TaskDependency>
{
    public void Configure(EntityTypeBuilder<TaskDependency> builder)
    {
        builder.ToTable("TaskDependencies");

        builder
           .HasOne(x => x.PredecessorTask)
           .WithMany(x => x.Predecessors)
           .HasForeignKey(x => x.PredecessorTaskId)
           .OnDelete(DeleteBehavior.Restrict);

        builder
           .HasOne(x => x.SuccessorTask)
           .WithMany(x => x.Dependencies)
           .HasForeignKey(x => x.SuccessorTaskId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
