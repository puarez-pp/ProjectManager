using ProjectManager.Application.Common.Extensions;
using ProjectManager.Application.Employees.Commands.EditEmployee;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Users.Commands.EditUser;
using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Users.Extensions;
public static class UserExtensions
{
    public static UserDto ToUserDto(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Phone = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FullName = $"{user.FirstName} {user.LastName}",
            Position = (user.Employee.Position).GetDisplayName(),
            RegisterDateTime = user.RegisterDateTime
        };
    }


    public static EmployeeBasicsDto ToEmployeeBasicsDto(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new EmployeeBasicsDto
        {
            Id = user.Id,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Name = !string.IsNullOrWhiteSpace(user.FirstName) || 
                   !string.IsNullOrWhiteSpace(user.LastName) 
                   ? $"{user.LastName} {user.FirstName}" : "-",
            IsDeleted = user.IsDeleted
        };
    }


    public static EditUserCommand ToEditUser(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new EditUserCommand
        {
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            ManagerId = user.Employee?.ManagerId,
            ImageUrl = user.Employee?.ImageUrl,
            PositionId = (int?)user.Employee?.Position ?? (int)Domain.Enums.Position.Electric
        };
    }

    public static EditEmployeeCommand ToEmployee(this ApplicationUser user)
    {
        if (user == null)
            return null;

        return new EditEmployeeCommand
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Id = user.Id,
            ManagerId = user.Employee?.ManagerId,
            ImageUrl = user.Employee?.ImageUrl,
            PositionId = (int?)user.Employee?.Position ?? (int)Domain.Enums.Position.Electric
        };
    }
}
