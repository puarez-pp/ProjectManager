using ProjectManager.Domain.Enums;

namespace ProjectManager.Application.Users.Queries.GetUser;

public  class UserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Manager { get; set; }
    public DateTime RegisterDateTime { get; set; }
}
