

using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
public class EmployeeBasicsDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Position Position { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
}
