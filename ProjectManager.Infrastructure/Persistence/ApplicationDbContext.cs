using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Domain.Entities;
using ProjectManager.Infrastructure.Persistence.Extensions;
using System.Reflection;
using File = ProjectManager.Domain.Entities.File;

namespace ProjectManager.Infrastructure.Persistence;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<SubConAddress> SubConAddresses { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<ProjectScope> ProjectScopes { get; set; }
    public DbSet<SettingsPosition> SettingsPositions { get; set; }
    public DbSet<Settings> Settings { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectSetting> ProjectSettings { get; set; }
    public DbSet<ProjectSettingPosition> ProjectSettingPositions { get; set; }
    public DbSet<SubContractor> SubContractors { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeEvent> EmployeeEvents { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public DbSet<TodoPost> TodoPosts { get; set; }
    public DbSet<ProjectScopePosition> ProjectScopePositions { get; set; }
    public DbSet<PostReply> PostReplies { get; set; }
    public DbSet<PositionPost> PositionPosts { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<ToolRent> Rents { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Predecessor> Predecessors { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<Device> Devices { get; set; }
    public DbSet<DeviceTemplate> DeviceTemplates { get; set; }
    public DbSet<DeviceTemplatePosition> DeviceTemplatePositions { get; set; }
    public DbSet<DeviceHeader> DeviceHeaders { get; set; }
    public DbSet<Alarm> Alarms { get; set; }
    public DbSet<OtherCounter> OtherCounters { get; set; }
    public DbSet<ElectricCounter> ElectricCounters { get; set; }
    public DbSet<HeatCounter> HeatCounters { get; set; }
    public DbSet<GasCounter> GasCounters { get; set; }
    public DbSet<Engine> Engines { get; set; }
    public DbSet<Assumption> Assumptions { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Settlement> Settlements { get; set; }
    public DbSet<WorkScope> WorkScopes { get; set; }
    public DbSet<WorkScopeCost> WorkScopeCosts { get; set; }
    public DbSet<WorkScopeOffer> WorkScopeOffers { get; set; }
    public DbSet<WorkScopePositionTemplate> WorkScopePositionTemplates { get; set; }
    public DbSet<WorkScopeTemplate> WorkScopeTemplates { get; set; }
    public DbSet<ProjectScopeTemplate> ProjectScopeTemplates { get; set; }
    public DbSet<ProjectScopePositionTemplate> ProjectScopePositionTemplates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.SeedClient();
        modelBuilder.SeedProjectSettings();
        modelBuilder.SeedSettings();
        modelBuilder.SeedSettingsPosition();
        modelBuilder.SeedRoles();
        modelBuilder.SeedSubContractor();
        modelBuilder.SeedTemplates();
        modelBuilder.SeedTemplatePositions();
        modelBuilder.SeedWorkScopeTemplates();
        modelBuilder.SeedWorkScopePositionTemplates();
        modelBuilder.SeedProjectScopeTemplates();
        modelBuilder.SeedProjectScopePositionTemplates();

        base.OnModelCreating(modelBuilder);
    }

}
