using MediatR;


namespace ProjectManager.Application.Employees.Queries.GetEmployeePage;
public class GetEmployeePageQuery : IRequest<Employee1PageDto>
{
    public string Url { get; set; }
}
