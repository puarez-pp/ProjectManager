using ProjectManager.Application.Common.Interfaces;
using ProjectManager.Application.Dictionaries;
using ProjectManager.Application.Users.Extensions;
using MediatR;

namespace ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
public class GetEmployeeBasicsQueryHandler : IRequestHandler<GetEmployeeBasicsQuery, IEnumerable<EmployeeBasicsDto>>
{
    private readonly IUserRoleManagerService _userRoleManagerService;

    public GetEmployeeBasicsQueryHandler(
        IUserRoleManagerService userRoleManagerService)
    {
        _userRoleManagerService = userRoleManagerService;
    }

    public async Task<IEnumerable<EmployeeBasicsDto>> Handle(GetEmployeeBasicsQuery request, CancellationToken cancellationToken)
    {
        var employees = (await _userRoleManagerService
            .GetUsersInRoleAsync(RolesDict.Pracownik))
            .Select(x => x.ToEmployeeBasicsDto())
            .OrderBy(x=>x.Name);
        return employees;
    }
}
