using MediatR;

namespace ProjectManager.Application.Employees.Queries.GetEmployeeBasicsQuery;
public class GetEmployeeBasicsQuery : IRequest<IEnumerable<EmployeeBasicsDto>>
{

}
