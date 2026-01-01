using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;
using File = ProjectManager.Domain.Entities.File;
namespace ProjectManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Address> Addresses { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Client> Clients { get; set; }
        DbSet<Cost> Costs { get; set; }
        DbSet<Division> Divisions { get; set; }
        DbSet<DivisionPosition> DivisionPositions { get; set; }
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
        DbSet<ToolRental> ToolRentals { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
