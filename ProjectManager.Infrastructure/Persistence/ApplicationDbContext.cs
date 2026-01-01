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
    public DbSet<Client> Clients { get; set; }
    public DbSet<Cost> Costs { get; set; }
    public DbSet<Division> Divisions { get; set; }
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
    public DbSet<DivisionPosition> DivisionPositions { get; set; }
    public DbSet<PostReply> PostReplies { get; set; }

    public DbSet<PositionPost> PositionPosts { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<ToolRental> ToolRentals { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Predecessor> Predecessors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.SeedClient();
        modelBuilder.SeedProjectSettings();
        modelBuilder.SeedSettings();
        modelBuilder.SeedSettingsPosition();
        modelBuilder.SeedRoles();
        modelBuilder.SeedSubContractor();

        base.OnModelCreating(modelBuilder);
    }

}
