using MediatR;

namespace ProjectManager.Application.Tools.Queries.GetRents;

public class GetRentsQuery : IRequest<List<ToolRentsDto>>
{
    public int Id { get; set; }
}
