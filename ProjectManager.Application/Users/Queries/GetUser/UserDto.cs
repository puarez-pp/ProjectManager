using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;

namespace ProjectManager.Application.Users.Queries.GetUser;

public  class UserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public EmployeeDto Employee { get; set; }
    public DateTime RegisterDateTime { get; set; }
}
