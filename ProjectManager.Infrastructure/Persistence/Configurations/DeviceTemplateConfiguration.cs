using ProjectManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectManager.Infrastructure.Persistence.Configurations;

class DeviceTemplateConfiguration : IEntityTypeConfiguration<DeviceTemplate>
{
    public void Configure(EntityTypeBuilder<DeviceTemplate> builder)
    {
        builder.ToTable("Templates");
        builder.HasKey(x => x.Id);
    }
}
