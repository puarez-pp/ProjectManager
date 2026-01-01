using MediatR;


namespace ProjectManager.Application.EmployeeEvents.Commands.DeleteEmployeeEvent;
public class DeleteEmployeeEventCommand : IRequest
{
    public int Id { get; set; }
}
