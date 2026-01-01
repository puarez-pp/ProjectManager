using MediatR;

namespace ProjectManager.Application.Projects.Queries.GetEditDivision;

public class GetEditDivisionQuery:IRequest<EditDivisionVm>
{
    public int Id { get; set; }
}
