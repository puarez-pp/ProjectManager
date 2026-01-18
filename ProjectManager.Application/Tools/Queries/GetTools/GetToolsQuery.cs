using MediatR;

namespace ProjectManager.Application.Tools.Queries.GetTools;

public class GetToolsQuery : IRequest<List<ToolDto>>
{
}
