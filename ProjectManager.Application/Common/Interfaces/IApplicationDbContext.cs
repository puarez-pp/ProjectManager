using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using File = ProjectManager.Domain.Entities.File;
namespace ProjectManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<SubConAddress> SubConAddresses { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<ProjectScope> ProjectScopes { get; set; }
        DbSet<ProjectScopePosition> ProjectScopePositions { get; set; }
        DbSet<PositionPost> PositionPosts { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<EmployeeEvent> EmployeeEvents { get; set; }
        DbSet<File> Files { get; set; }
        DbSet<Post> Posts { get; set; }
        DbSet<PostReply> PostReplies { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectSetting> ProjectSettings { get; set; }
        DbSet<ProjectSettingPosition> ProjectSettingPositions { get; set; }
        DbSet<Domain.Entities.Settings> Settings { get; set; }
        DbSet<SettingsPosition> SettingsPositions { get; set; }
        DbSet<SubContractor> SubContractors { get; set; }
        DbSet<Todo> Todos { get; set; }
        DbSet<TodoPost> TodoPosts { get; set; }
        DbSet<Tool> Tools { get; set; }
        DbSet<ToolRent> Rents { get; set; }
        DbSet<Plant> Plants { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<DeviceTemplate> DeviceTemplates { get; set; }
        DbSet<DeviceTemplatePosition> DeviceTemplatePositions { get; set; }
        DbSet<DeviceHeader> DeviceHeaders { get; set; }
        DbSet<Alarm> Alarms { get; set; }
        DbSet<OtherCounter> OtherCounters { get; set; }
        DbSet<ElectricCounter> ElectricCounters { get; set; }
        DbSet<HeatCounter> HeatCounters { get; set; }
        DbSet<GasCounter> GasCounters { get; set; }
        DbSet<Engine> Engines { get; set; }
        DbSet<Assumption> Assumptions { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        DbSet<Settlement> Settlements { get; set; }
        DbSet<WorkScope> WorkScopes { get; set; }
        DbSet<WorkScopeCost> WorkScopeCosts { get; set; }
        DbSet<WorkScopeOffer> WorkScopeOffers { get; set; }
        DbSet<WorkScopePositionTemplate> WorkScopePositionTemplates { get; set; }
        DbSet<WorkScopeTemplate> WorkScopeTemplates { get; set; }
        DbSet<ProjectScopeTemplate> ProjectScopeTemplates { get; set; }
        DbSet<ProjectScopePositionTemplate> ProjectScopePositionTemplates { get; set; }



        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
