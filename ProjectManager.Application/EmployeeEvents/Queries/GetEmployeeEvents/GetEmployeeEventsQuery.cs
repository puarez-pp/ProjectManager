using MediatR;

namespace ProjectManager.Application.EmployeeEvents.Queries.GetEmployeeEvents;
public class GetEmployeeEventsQuery : IRequest<IEnumerable<EmployeeEventDto>>
{

}
