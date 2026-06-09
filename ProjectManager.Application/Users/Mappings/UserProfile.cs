using AutoMapper;
using ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
using ProjectManager.Application.Users.Queries.GetUser;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Users.Mappings;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
            .ForMember(dest => dest.Employee,
                opt => opt.MapFrom(src => new EmployeeDto()));
    }
}
